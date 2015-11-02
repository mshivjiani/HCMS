using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using HCMS.WebFramework.BasePages;
using HCMS.Business.PD;
using System.Web.Security;
using Telerik.Web.UI;
using System.Configuration;
namespace HCMS.PDExpress
{
    public partial class PDMaster : MasterPageBase
    {
        private PDControlType _PDControlName = PDControlType.Other;
        private LeftMenuType _leftMenuType = LeftMenuType.None;
        private enumTopMenuItem _disableTopMenuItem = enumTopMenuItem.None;
        private enumTopMenuItem _jnpselectTopMenuItem = enumTopMenuItem.None;
        private enumLeftMenuItem _selectLeftMenuItem = enumLeftMenuItem.None;
        private enumMenuItem _selectSubMenuItem = enumMenuItem.None;
        private enumTopMenuType _topMenuType = enumTopMenuType.None;
        private enumMenuType _subMenuType = enumMenuType.None;
        private enumFooterType _footerType = enumFooterType.Site;
        private bool _showLeftMenu = true;
        private bool _showTopMenu = true;
        private bool _showSubMenu = false;
        public delegate bool FilterLeftMenuItem(PDControlType item);
        public static string ReplaceWithAppPath(string str)
        {
            string appPath = HttpContext.Current.Request.ApplicationPath;

            if (!appPath.EndsWith("/"))
                appPath += "/";

            return str.Replace("~/", appPath);
        }

        #region "Page Events/Methods"
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                repeaterleftNav.DataBind();
        }
        protected override void OnPreRender(EventArgs e)
        {
            bool blnDisplay = Context.User.Identity.IsAuthenticated;
            leftNav.Visible = blnDisplay;
            topNav.Visible = blnDisplay;
            setPageTitleDefault();
            if (blnDisplay && ShowLeftMenu)
            {
                this.leftNav.Visible = true;
                SetLeftMenu();
            }
            else
            {
                this.leftNav.Visible = false;
            }
            this.FooterType = enumFooterType.PDExpress;
            setFooter();
            base.OnPreRender(e);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            hiddenSessionTimeout.Value = Session.Timeout.ToString();
            string strclearTimers = @"clearInterval(TimeoutTimerId);clearInterval(AlertTimerId);clearInterval(HideTimerId);";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ClearTimers", strclearTimers, true);
            //alert the user 2 mins prior to session time out
            int millisectimeout = (Session.Timeout * 60000) - 120000;
            string strScriptAlert = @"AlertTimerId=window.setInterval('showAlert()'," + millisectimeout.ToString() + @" );";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Alert", strScriptAlert, true);


            //hide the session timeout warning alert box 5secs before session timeout
            int timeoutfinal = (Session.Timeout * 60000) - 5000;
            string strScriptHideAlert = @"HideTimerId=window.setInterval('hide()'," + timeoutfinal.ToString() + @" );";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "HideAlert", strScriptHideAlert, true);


            //redirect to timeout page on timeout
            int redirecttime = (Session.Timeout * 60000);
            string strScriptRedirect = @"TimeoutTimerId=window.setInterval('redirecttoTimeout()'," + redirecttime.ToString() + @" );";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Timeout", strScriptRedirect, true);
        }


        protected override void OnLoad(EventArgs e)
        {//JA issue ID :77
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore(); 
            base.OnLoad(e);
        }
        protected override void Render(HtmlTextWriter writer)
        {
            //This method modifies the output by fixing the linked url
            //by calling ReplaceWithAppPath method
            MemoryStream ms = new MemoryStream();
            StreamWriter sw = new StreamWriter(ms);
            HtmlTextWriter htw = new HtmlTextWriter(sw);

            base.Render(htw);
            htw.Flush();
            ms.Position = 0;

            TextReader tr = new StreamReader(ms);
            string output = tr.ReadToEnd();
            string newOutput = ReplaceWithAppPath(output);
            writer.Write(newOutput);

            htw.Close();
            sw.Close();
            ms.Close();
        }
        #endregion

        #region "Navigation Methods"

        public void SetLeftMenu()
        {
            switch (this.LeftMenu)
            {
                case LeftMenuType.CreatePDMenu:
                    this.leftMenuDS.DataFile = Page.ResolveUrl("~/App_Data/LeftNavCreatePD.xml");
                    break;
                case LeftMenuType.PDHomeMenu:
                    this.leftMenuDS.DataFile = Page.ResolveUrl("~/App_Data/LeftNavHome.xml");
                    break;
            }

            repeaterleftNav.DataBind();
            setCreatePDMenuItems();
        }
        
        protected void setCreatePDMenuItems()
        {
            const string CURRENTPDID = "CurrentPDID";
            const string CURRENTASSOCIATEDPDID = "CurrentAssociatedPDID";
            const string CSS_DISABLED = "disabled";

            PDStatus currentPDStatus = PDStatus.Null;
            PositionDescription pd = null;
            PDChoiceType? pdChoice = null;
            if (this.LeftMenu == LeftMenuType.CreatePDMenu)
            {
                //get current pd status
                if ((HttpContext.Current.Session[CURRENTPDID] != null) && ((long)HttpContext.Current.Session[CURRENTPDID] != -1))
                {
                    long PDID = Convert.ToInt64(HttpContext.Current.Session[CURRENTPDID].ToString());
                    pd = new PositionDescription(PDID);
                    pdChoice = (PDChoiceType)pd.PositionDescriptionTypeID;

                    PositionWorkflowStatus currentWorkflowStatus = pd.GetCurrentPositionWorkflowStatus();
                    currentPDStatus = (PDStatus)currentWorkflowStatus.WorkflowStatusID;
                }

                foreach (RepeaterItem item in this.repeaterleftNav.Items)
                {
                    if ((item.ItemType == ListItemType.Item) || (item.ItemType == ListItemType.AlternatingItem))
                    {
                        HyperLink currentlink = item.FindControl("leftNavHyperlink") as HyperLink;
                        //new PD
                        if (Session[CURRENTPDID] != null && (long)Session[CURRENTPDID] == -1)
                        {
                            if (currentlink.Text == PDControlType.Duties.ToString() ||
                                currentlink.Text == PDControlType.Characteristics.ToString() ||
                                currentlink.Text == PDControlType.Factors.ToString() ||
                                currentlink.Text == PDControlType.Approvals.ToString())
                            {
                                // disable all links for new PD's
                                currentlink.Enabled = false;
                                currentlink.CssClass = CSS_DISABLED;
                            }
                            if (currentlink.Text == PDControlType.Occupation.ToString())
                            {
                                //Check if it SOD
                                if (Session[CURRENTASSOCIATEDPDID] != null && (long)Session[CURRENTASSOCIATEDPDID] != -1)
                                {
                                    currentlink.Enabled = false;
                                    currentlink.CssClass = CSS_DISABLED;
                                }
                                else //Otherwise Highlight it
                                    currentlink.BackColor = System.Drawing.Color.FromArgb(91, 179, 43);
                            }

                            if (currentlink.Text == PDControlType.SOD.ToString())
                            {
                                //Check if it SOD
                                if (Session[CURRENTASSOCIATEDPDID] != null && (long)Session[CURRENTASSOCIATEDPDID] != -1)
                                    currentlink.BackColor = System.Drawing.Color.FromArgb(91, 179, 43);
                                else //Otherwise Hide it
                                    item.Visible = false;
                            }
                        }
                        else //NOT NEW PD
                        {

                            //enable approvals link when PD status is Revise or FinalReview
                            if (currentlink.Text == PDControlType.Approvals.ToString())
                            {

                                bool isPDCreator = pd.PDCreatorID.Equals(base.CurrentUser.UserID);
                                bool isPDCreatorSupervisor = base.CurrentUser.IsPDCreatorSupervisor(pd.PositionDescriptionID);
                                bool hasCompleteSupervisorCert = base.HasPermission(enumPermission.CompleteSupervisoryCertification);


                                //enabling the approval for Published PD's as well
                                //added enumPermission.CompleteJNPCertification -- to the list of enabling approval link -- to allow Staffing Specialist/Staffing Manager to access approval page.
                                if (
                                    (currentPDStatus == PDStatus.Published || !base.IsPDReadOnly) &&
                                    (hasCompleteSupervisorCert || isPDCreatorSupervisor || base.HasPermission(enumPermission.CompleteHRCertification)||base.HasPermission(enumPermission.CompleteJNPCertification)) &&
                                    ((pdChoice != PDChoiceType.CareerLadderPD || (pdChoice == PDChoiceType.CareerLadderPD && pd.LadderPosition == 0))) &&
                                    (pdChoice != PDChoiceType.CLStatementOfDifferencePD) // adding check if it is not CL SOD
                                    )
                                {
                                    // In addition to permission checks, check to make sure that the PD is either
                                    // NOT a career ladder OR if it is a career ladder, it should be a full performance PD
                                    currentlink.Enabled = true;
                                }
                                else
                                {
                                    currentlink.Enabled = false;
                                    currentlink.CssClass = CSS_DISABLED;
                                }
                            }
                            if (currentlink.Text == PDControlType.SOD.ToString())
                            {
                                if ((pdChoice == PDChoiceType.StatementOfDifferencePD) || (pdChoice == PDChoiceType.CLStatementOfDifferencePD))
                                { item.Visible = true; }
                                else
                                { item.Visible = false; }
                            }

                            if (currentlink.Text == this.PDControlName.ToString())
                                currentlink.BackColor = System.Drawing.Color.FromArgb(91, 179, 43);

                            if (pdChoice == PDChoiceType.CLStatementOfDifferencePD)
                            {
                                if (currentlink.Text == PDControlType.Duties.ToString() ||
                                  currentlink.Text == PDControlType.Factors.ToString() ||
                                currentlink.Text == PDControlType.Approvals.ToString())
                                {
                                    item.Visible = false;
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Properties
        public override PDControlType PDControlName
        {
            get
            {
                return this._PDControlName;
            }
            set
            {
                this._PDControlName = value;
            }

        }

        public override LeftMenuType LeftMenu
        {
            get
            {
                return this._leftMenuType;
            }
            set
            {
                this._leftMenuType = value;
            }
        }

        private bool _showProgressBar = true;
        private enumProgressBarItem _progressBar = enumProgressBarItem.JAPositionInfo;
        private enumProgressBarItem _selectProgressBar = enumProgressBarItem.JAPositionInfo;

        public override enumProgressBarItem ProgressBar
        {
            get { return this._progressBar; }
            set { this._progressBar = value; }
        }
        public override enumProgressBarItem SelectProgressBar
        {

            get { return this._selectProgressBar; }
            set { this._selectProgressBar = value; }

        }
        public override bool ShowProgressBar
        {
            get { return this._showProgressBar; }
            set { this._showProgressBar = value; }
        }


        public override enumTopMenuItem SelectTopMenuItem
        { get { return this._jnpselectTopMenuItem; } set { this._jnpselectTopMenuItem = value; } }

        public override enumTopMenuItem DisableTopMenuItem
        {
            get
            {
                return this._disableTopMenuItem;
            }
            set
            {
                this._disableTopMenuItem = value;
            }
        }
        public override enumLeftMenuItem SelectLeftMenuItem
        { get { return this._selectLeftMenuItem; } set { this._selectLeftMenuItem = value; } }

        public override enumMenuItem SelectSubMenuItem
        {
            get
            {
                return this._selectSubMenuItem;
            }
            set
            {
                this._selectSubMenuItem = value;
            }
        }
        public override enumTopMenuType TopMenuType
        { get { return this._topMenuType; } set { this._topMenuType = value; } }

        public override enumMenuType SubMenuType
        {
            get
            {
                return this._subMenuType;
            }
            set
            {
                this._subMenuType = value;
            }
        }
        public override enumFooterType FooterType
        {
            get { return this._footerType; }
            set { this._footerType = value; }
        }
        
        public override string PageTitle
        {
            get
            {
                if (ViewState["PageTitle"] == null)
                    ViewState["PageTitle"] = this.Page.Title;

                return ViewState["PageTitle"].ToString();
            }
            set
            {
                this.Page.Title = value;
            }
        }

        public override bool ShowRequiredFieldMessage
        {
            get
            {
                return divRequiredField.Visible;
            }
            set
            {
                divRequiredField.Visible = value;
            }
        }

        public override bool ShowInformationDiv
        {
            get
            {
                return this.divInfo.Visible;
            }
            set
            {
                this.divInfo.Visible = value;
            }
        }
        public override bool ShowLeftMenu
        {

            get
            {
                return _showLeftMenu;
            }
            set
            {
                _showLeftMenu = value;
            }
        }
        public override bool ShowTopMenu
        {
            get
            {
                return this._showTopMenu;
            }
            set
            {
                this._showTopMenu = value;
            }
        }

        public override bool ShowSubMenu
        {
            get
            {
                return this._showSubMenu;
            }
            set
            {
                this._showSubMenu = value;
            }
        }
        #endregion

        #region Private Methods
        private void setPageTitleDefault()
        {
            if (Context.User.Identity.IsAuthenticated)
                literalPageTitle.Text = this.PageTitle;
            
        }
        private void setFooter()
        {
            switch (this.FooterType)
            {
                case enumFooterType.None:
                    break;
                case enumFooterType.Site:
                    radMenuFooter.LoadContentFile ("~/App_Data/FooterSiteMaster.xml");
                    break;
                case enumFooterType.PDExpress:
                    radMenuFooter.LoadContentFile("~/App_Data/FooterPDExpress.xml");
                    break;
                case enumFooterType.JNP:
                    radMenuFooter.LoadContentFile("~/App_Data/FooterJNP.xml");
                    break;
                default:
                    break;
            }
            setFooterLinks();
        }
        private void setFooterLinks()
        {
            RadMenuItem homeitem = radMenuFooter.FindItemByValue("Home");
            if (homeitem != null)
            {
                homeitem.NavigateUrl = ConfigurationManager.AppSettings["HCMSPortalDefaultURL"].ToString();
            }
            RadMenuItem supportdeskitem = radMenuFooter.FindItemByValue("SupportDesk");
            if (supportdeskitem != null)
            {
                supportdeskitem.NavigateUrl = ConfigurationManager.AppSettings["SupportDeskURL"].ToString();

            }
        }
        #endregion

        #region Print Message

        private void PrintMessage(string message, bool isError, bool showContentPane)
        {
            divRequiredField.Visible = false;
            divMessage.Visible = true;
            literalSystemMessage.Text = message;
            divMessage.Attributes.Add("class", (isError ? "errorMessage" : "systemMessage"));
           
        }

        public override void PrintSystemMessage(string message)
        {
            this.PrintSystemMessage(message, false);
        }

        public override void PrintSystemMessage(string message, bool showContentPane)
        {
            PrintMessage(message, false, showContentPane);
        }

        public override void PrintErrorMessage(Exception ex, bool showContentPane)
        {
            PrintMessage((Request.QueryString["showError"] == "1" ? ex.ToString() : ex.Message), true, showContentPane);
        }

        public override void PrintErrorMessage(Exception ex)
        {
            this.PrintErrorMessage(ex, false);
        }

        public override void PrintErrorMessage(string message, bool showContentPane)
        {
            PrintMessage(message, true, showContentPane);
        }

        public override void PrintErrorMessage(string message)
        {
            this.PrintErrorMessage(message, false);
        }

        #endregion


    }
}
