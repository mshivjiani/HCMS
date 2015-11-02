using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Net.Mail;


using HCMS.Business.Security;
using HCMS.Business.Security.Collections;
using HCMS.WebFramework.Security;
using HCMS.WebFramework.Site.Wrappers;
using HCMS.Business.PD;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.OrganizationChart;


namespace HCMS.WebFramework.Site.Utilities
{
    public abstract class SiteUtility
    {
        protected const long NULLPDID = -1;
        protected const long NULLKEYID = -1;
        private const string CURRENTPD = "CurrentPD";
        private const string CURRENTPDID = "CurrentPDID";
        private const string CURRENTORGCHART = "CurrentOrgChart";
        private const string CURRENTORGCHARTID = "CurrentOrgChartID";


        // NOTE MD 6/10: Use this find any control on the page!...
        public static Control FindControlRecursive(Control Root, string Id, string exceptionMssg) 
        {
            if (Root.ID == Id) return Root;

            foreach (Control Ctl in Root.Controls)
            {
                Control FoundCtl = FindControlRecursive(Ctl, Id);
                if (FoundCtl != null) return FoundCtl;
            }

            if (exceptionMssg.Length > 0) throw new Exception(exceptionMssg);

            return null;
        }

        public static Control FindControlRecursive(Control Root, string Id)
        {
            return FindControlRecursive(Root, Id, "");
        }

        //public static T FindControl<T>(System.Web.UI.ControlCollection controls) where T : class
        //{
        //    T found = default(T);

        //    if (controls != null && controls.Count > 0)
        //    {
        //        for (int i = 0; i < controls.Count - 1; i++)
        //        {
        //            if (found != null) break;
        //            if (controls[i] is T)
        //            {
        //                found = controls[i] as T;
        //                break;
        //            }
        //            found = FindControl<T>(controls[i].Controls);
        //        }
        //    }

        //    return found;
        //}

        public static string ConvertRelativeUrlToAbsoluteUrl(string relativeUrl)
        {
            HttpRequest currentrequest = HttpContext.Current.Request;
            System.Web.UI.Page page = HttpContext.Current.Handler as System.Web.UI.Page;


            if (currentrequest.IsSecureConnection)
            {
                if (currentrequest.Url.IsDefaultPort)
                {

                    return string.Format("https://{0}{1}", currentrequest.Url.Host, page.ResolveUrl(relativeUrl));
                }
                else
                {
                    return string.Format("https://{0}:{1}{2}", currentrequest.Url.Host, currentrequest.Url.Port, page.ResolveUrl(relativeUrl));
                }
            }
            else
            {
                if (currentrequest.Url.IsDefaultPort)
                {

                    return string.Format("http://{0}{1}", currentrequest.Url.Host, page.ResolveUrl(relativeUrl));
                }
                else
                {
                    return string.Format("http://{0}:{1}{2}", currentrequest.Url.Host, currentrequest.Url.Port, page.ResolveUrl(relativeUrl));
                }

            }
        }

        public static void BuildAuthenticationCookie(User currentUser, RoleCollection roles, PermissionCollection permissions)
        {
            if (currentUser != null && currentUser.UserID != -1)
            {
                string userdata = string.Format("{0}|{1}|{2}|{3}|{4}", currentUser.UserID, currentUser.FirstName, currentUser.LastName, currentUser.EmailAddress, currentUser.RegionID);
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1,
                   currentUser.UserID.ToString(), DateTime.Now,
                   DateTime.Now.AddMinutes(ConfigWrapper.FormsAuthTimeout),
                   ConfigWrapper.PersistAuthCookie, userdata);

                var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket))
                {
                    HttpOnly = true,
                    Secure = FormsAuthentication.RequireSSL,
                    Path = FormsAuthentication.FormsCookiePath,
                    Domain = FormsAuthentication.CookieDomain
                };

                HttpContext.Current.User = new SitePrincipal(new SiteIdentity(currentUser, roles, permissions));

                HttpContext.Current.Response.Cookies.Remove(FormsAuthentication.FormsCookieName);
                HttpContext.Current.Response.Cookies.Add(authCookie);
            }
            else
            {
                throw new Exception("You cannot set an authentication cookie if the user is not valid.");
            }
        }

        public static void SendEmail(string from, string to, string subject, string message, string smtpserver, int port)
        {

              MailMessage mailmessage = new MailMessage(from, to, subject, message);
              SmtpClient smtpclient = new SmtpClient(smtpserver, port);

              smtpclient.Send(mailmessage);

   
        }
        private static SitePrincipal CurrentPrincipal()
        {
            return (SitePrincipal)HttpContext.Current.User;
        }

        internal static ISiteUser CurrentIdentityUser()
        {
            SitePrincipal thisPrincipal = CurrentPrincipal();
            User thisUser = new User();

            if (thisPrincipal != null)
            {
                SiteIdentity currentIdentity = (SiteIdentity)thisPrincipal.Identity;

                thisUser.UserID = currentIdentity.UserID;
                thisUser.FirstName = currentIdentity.FirstName;
                thisUser.LastName = currentIdentity.LastName;
                thisUser.EmailAddress = currentIdentity.EmailAddress;
                thisUser.RegionID = currentIdentity.RegionID;
            }

            return (ISiteUser)thisUser;
        }

        internal static bool IsInRole(enumRole roleEnumID)
        {
            SitePrincipal thisPrincipal = CurrentPrincipal();
            return (thisPrincipal != null) && (thisPrincipal.IsInRole(roleEnumID));
        }

        internal static bool HasPermission(enumPermission permissionEnumID)
        {
            SitePrincipal thisPrincipal = CurrentPrincipal();
            return (thisPrincipal != null) && (thisPrincipal.HasPermission(permissionEnumID));
        }
        /// <summary>
        /// This method checks the logged in user permissions and PD workflow status and
        /// evaluates PD Access type. It does not check wheather the PD is 
        /// checked out or not.
        /// </summary>
        /// <param name="thisPD"></param>
        /// <returns>PDAccessType</returns>
        internal static PDAccessType GetPDAccessType(PositionDescription thisPD)
        {
            // tighten permissions and only upgrade if user has valid permissions
            PDAccessType access = PDAccessType.None;
            if (thisPD.PositionDescriptionID != NULLPDID)
            {
                User currentUser = new User(SiteUtility.CurrentIdentityUser().UserID);
                // get all appropriate permissions now
                bool isPDCreator = thisPD.PDCreatorID.Equals(currentUser.UserID);
                bool isPDCreatorSupervisor = currentUser.IsPDCreatorSupervisor(thisPD.PositionDescriptionID);
                bool hasCompleteSupervisorCert = HasPermission(enumPermission.CompleteSupervisoryCertification);
                bool hasCompleteHRCert = HasPermission(enumPermission.CompleteHRCertification);
                bool hasMaintainEvalStatements = HasPermission(enumPermission.MaintainEvaluationStatements);
                bool hasMaintainHROnlySection = HasPermission(enumPermission.MaintainHRSection);
                bool hasMaintainFactorRecommendations = HasPermission(enumPermission.MaintainFactorRecommendation);
                bool hasPublishPositionDescription = HasPermission(enumPermission.PublishPD);

                // user should have at least one of the above
                // if not -- the user has no access
                if (isPDCreator || isPDCreatorSupervisor || hasCompleteSupervisorCert || hasCompleteHRCert ||
                    hasMaintainEvalStatements || hasMaintainHROnlySection ||
                    hasMaintainFactorRecommendations || hasPublishPositionDescription)
                {
                    PositionWorkflowStatus pws = thisPD.GetCurrentPositionWorkflowStatus();

                    if (pws.WorkflowRecID != NULLKEYID)
                    {
                        switch ((PDStatus)pws.WorkflowStatusID)
                        {
                            case PDStatus.Draft:
                            case PDStatus.Revise:
                                if (isPDCreator || isPDCreatorSupervisor || hasCompleteSupervisorCert)
                                    access = PDAccessType.Write;
                                else
                                    access = PDAccessType.ReadOnly;
                                break;
                            case PDStatus.Review:
                            case PDStatus.FinalReview:
                                if (hasCompleteHRCert || hasMaintainEvalStatements || hasMaintainHROnlySection ||
                                    hasMaintainFactorRecommendations || hasPublishPositionDescription)
                                    access = PDAccessType.Write;
                                else
                                    access = PDAccessType.ReadOnly;
                                break;
                            default:
                                // covers all other statuses -- including Published
                                access = PDAccessType.ReadOnly;
                                break;
                        }
                    }
                }
            }
            return access;
        }

        internal static long CurrentPDID
        {
            get
            {
                if (HttpContext.Current.Session[CURRENTPDID] == null)
                    HttpContext.Current.Session[CURRENTPDID] = NULLPDID;

                return (long)HttpContext.Current.Session[CURRENTPDID];
            }
            set
            {
                HttpContext.Current.Session[CURRENTPDID] = value;
            }
        }

        internal static PositionDescription CurrentPD
        {
            get
            {
                if (HttpContext.Current.Session[CURRENTPD] == null)
                {
                    if (CurrentPDID == NULLPDID)
                        HttpContext.Current.Session[CURRENTPD] = new PositionDescription();
                    else
                        HttpContext.Current.Session[CURRENTPD] = new PositionDescription(CurrentPDID);
                }

                return (PositionDescription)HttpContext.Current.Session[CURRENTPD];
            }
        }

        internal static void ClearCurrentPD()
        {
            HttpContext.Current.Session[CURRENTPDID] = null;
            HttpContext.Current.Session[CURRENTPD] = null;
        }


        internal static int CurrentOrgChartID
        {
            get
            {
                if (HttpContext.Current.Session[CURRENTORGCHARTID] == null)
                    HttpContext.Current.Session[CURRENTORGCHARTID] = -1;

                return (int)HttpContext.Current.Session[CURRENTORGCHARTID];
            }
            set
            {
                HttpContext.Current.Session[CURRENTORGCHARTID] = value;
            }
        }
        
        public static OrganizationChart CurrentOrgChart
        {

            get
            {
                if (HttpContext.Current.Session[CURRENTORGCHART] == null)
                {
                    if (CurrentOrgChartID   == -1)
                        HttpContext.Current.Session[CURRENTORGCHART] = new OrganizationChart();
                    else
                        HttpContext.Current.Session[CURRENTORGCHART] = OrganizationChartManager.Instance.GetByID(CurrentOrgChartID);
                }

                return (OrganizationChart )HttpContext.Current.Session[CURRENTORGCHART];
            }
        }

        internal static void ClearCurrentOrgChart()
        {
            HttpContext.Current.Session[CURRENTORGCHART] = null;
            HttpContext.Current.Session[CURRENTORGCHARTID] = null;
        }

        public static void RefreshOrgChartDataOnly()
        {
            int tempChartID = CurrentOrgChartID;
            HttpContext.Current.Session[CURRENTORGCHART] = OrganizationChartManager.Instance.GetByID(tempChartID);
        }
    }

}
