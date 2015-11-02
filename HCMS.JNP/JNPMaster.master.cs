using System;
using HCMS.WebFramework.BasePages;
using Telerik.Web.UI;
using System.Web;
using HCMS.Business.JNP;
using System.Web.UI;
using System.Configuration;
using System.Xml.Linq;
//using System.Linq;
using System.Xml;
using System.Data;

namespace HCMS.JNP
{
    public partial class JNPMaster : MasterPageBase
    {
        private enumTopMenuItem _jnpselectTopMenuItem = enumTopMenuItem.None;
        private enumTopMenuItem _jnpdisableTopMenuItem = enumTopMenuItem.None;
        private enumLeftMenuItem _selectLeftMenuItem = enumLeftMenuItem.None;
        private enumMenuItem _selectSubMenuItem = enumMenuItem.None;
        private enumTopMenuType _topMenuType = enumTopMenuType.JNPHomeMenu;
        private LeftMenuType _leftMenuType = LeftMenuType.None;
        private enumFooterType _footerType = enumFooterType.JNP;
        private enumMenuType _subMenuType = enumMenuType.None;
        private PDControlType _pdControlType = PDControlType.Other;
        private bool _showLeftMenu = true;
        private bool _showTopMenu = true;
        private bool _showSubMenu = true;
        private string _title = string.Empty;
        private const string CurrentJNP = "CurrentJNP";
        private JNPackage _currentpackage = null;

        #region "Page Events/Methods"
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
            string portalbaseurl = ConfigurationManager.AppSettings["HCMSPortalBaseURL"].ToString();
            string timeouturl=string.Format ("{0}{1}",portalbaseurl, "Common/Timeout.aspx");
            hiddenTimeoutUrl.Value = timeouturl;
            //string redirecttoTimeout = string.Format("'redirecttoTimeout({0})',{1}", timeouturl, redirecttime.ToString());
            string strScriptRedirect = @"TimeoutTimerId=window.setInterval('redirecttoTimeout()'," + redirecttime.ToString() + @" );";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Timeout", strScriptRedirect, true);


        }
        protected override void OnPreRender(EventArgs e)
        {
            
            bool blnDisplay = Context.User.Identity.IsAuthenticated;
            //leftNav.Visible = blnDisplay;
            topNav.Visible = blnDisplay;

            if (blnDisplay)
            {
                literalPageTitle.Text = this.PageTitle;
                if (ShowInformationDiv)
                {
                    divPgTitle.Visible = false;
                }
                else
                {
                    divPgTitle.Visible = true;
                }
                if (ShowLeftMenu)
                {
                    SetLeftMenu();
                }
                if (ShowTopMenu)
                {
                    this.topNav.Visible = true;
                    SetTopMenu();
                    highLightSelectedTab();
                    DisableTab();
                }
                else
                {
                    this.topNav.Visible = false;
                    
                }
                if (ShowSubMenu)
                {
                    this.subNav.Visible = true;
                }
                else
                {
                    this.subNav.Visible = false;
                }
                if (ShowProgressBar) {
                    SetProgressBar();
                }
                
                setFooter();

            }
            base.OnPreRender(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
        }

        #endregion

        #region "Navigation Methods"

        private void SetLeftMenu()
        {
            switch (this.LeftMenu)
            {
                case LeftMenuType.JNPHomeMenu:
                    this.leftMenuDS.DataFile = Page.ResolveUrl("~/App_Data/LeftNavJNPHome.xml");
                    break;
                case LeftMenuType.JAMenu:
                    this.leftMenuDS.DataFile = Page.ResolveUrl("~/App_Data/LeftNavJA.xml");
                    break;
                case LeftMenuType.CRMenu:
                    this.leftMenuDS.DataFile = Page.ResolveUrl("~/App_Data/LeftNavCR.xml");
                    break;
                case LeftMenuType.JQMenu:
                    this.leftMenuDS.DataFile = Page.ResolveUrl("~/App_Data/LeftNavJQ.xml");
                    break;
            }
            radTabLeftMenu.DataBind();


        }
        private void SetTopMenu()
        {
            switch (this.TopMenuType)
            {
                case enumTopMenuType.JNPHomeMenu:
                    this.TopMenuDS.DataFile = Page.ResolveUrl("~/App_Data/TopNavJNP.xml");
                    break;
                case enumTopMenuType.JAMenu:
                case enumTopMenuType.CRMenu:
                case enumTopMenuType.JQMenu:
                case enumTopMenuType.ApprovalMenu:
                    //get current JNP WS - if not in approval hide the approval tab
                    const string CurrentJNPWS = "CurrentJNPWS";              
                 
                    if ((HttpContext.Current.Session[CurrentJNPWS] != null) && ((int)HttpContext.Current.Session[CurrentJNPWS] != -1))

                    {

                        this.lblCurrentStatus.Text  = ((enumJNPWorkflowStatus)HttpContext.Current.Session[CurrentJNPWS]).ToString ();
                        this.lblJAnPID.Text = CurrentPackage.JNPID.ToString();
                        enumJNPWorkflowStatus currentjnpws=(enumJNPWorkflowStatus)HttpContext.Current.Session[CurrentJNPWS];
                        if (currentjnpws  == enumJNPWorkflowStatus.Revise || currentjnpws == enumJNPWorkflowStatus.FinalReview || currentjnpws==enumJNPWorkflowStatus.Published )
                        {
                            this.TopMenuDS.DataFile = Page.ResolveUrl("~/App_Data/TopNavJNPWizardApproval.xml");
                        }
                        else
                        {
                           
                                this.TopMenuDS.DataFile = Page.ResolveUrl("~/App_Data/TopNavJNPWizard.xml");
                            
                        }
                    }
                    else
                    {
                        this.TopMenuDS.DataFile = Page.ResolveUrl("~/App_Data/TopNavJNPWizard.xml");
                    }
                    
                    break;
            }
            radTabJNPTopMenu.DataBind();


        }
        
        private void SetProgressBar() {
            var progBarNum = ((int)SelectProgressBar).ToString();
            imgProgressbar.ImageUrl = "~/App_Themes/JNP_Default/Images/progressBar_" + progBarNum  + ".png";
        }

        protected void radTabJNPTopMenu_DataBound(object sender, EventArgs e)
        {
            switch(this.TopMenuType)
            {
                
                case enumTopMenuType.JAMenu:
                case enumTopMenuType.CRMenu:
                case enumTopMenuType.JQMenu:
                case enumTopMenuType.ApprovalMenu:
                
                if (CurrentPackage  != null)
                {
                //checking  document exists or not 
                
                long crid = CurrentPackage.CRID;
                long jqid = CurrentPackage.JQID;
                    //CR inactive /does not exist then CR tab should not be visible
                if (CurrentPackage.HasActiveCR()==false)
                {
                    RadTab crtab = this.radTabJNPTopMenu.FindTabByValue("CategoryRating");
                    if (crtab != null)
                    {
                        crtab.Visible = false;
                    }
                }   

                }
                break ;
            default:
                break;
            }

            //moved this condition outside the switch statement as it only applies to JQMenu
            if (this.TopMenuType == enumTopMenuType.JQMenu)
            {
                RadTab jqtab = this.radTabJNPTopMenu.FindTabByValue("JobQuestionnaire");
                if (jqtab != null)
                {
                    if (base.IsAdmin)
                    {
                        jqtab.NavigateUrl = "~/JQ/Qualifications.aspx";
                    }
                    else
                    {
                        jqtab.NavigateUrl = "~/JQ/JQKSA.aspx";
                    }
                }

            }
        }
        private void highLightSelectedTab()
        {

            this.radTabJNPTopMenu.DataBind();
            this.radTabLeftMenu.DataBind();

            string selectTopTab = SelectTopMenuItem.ToString();
            string selectLeftTab = SelectLeftMenuItem.ToString();
            RadTab Toptab = this.radTabJNPTopMenu.FindTabByValue(selectTopTab);
            RadTab Lefttab = this.radTabLeftMenu.FindTabByValue(selectLeftTab);
            if (Toptab != null)
            {
                Toptab.Selected = true;
            }
            if (Lefttab != null)
            { Lefttab.Selected = true; }
        }
        private void DisableTab()
        {
            if (!base.IsAdmin)
            {
                if (this.TopMenuType == enumTopMenuType.JNPHomeMenu)
                {
                    RadTab adminTab = this.radTabJNPTopMenu.FindTabByValue(enumTopMenuItem.Admin.ToString());
                    if (adminTab != null)
                    {
                        adminTab.Enabled = false;
                    }
                }
            }



        }
        private void setFooter()
        {
            switch (this.FooterType)
            {
                case enumFooterType.None:
                    break;
                case enumFooterType.JNP:
                    
                    XmlDSFooter.DataFile = Page.ResolveUrl("~/App_Data/FooterJNP.xml");

                    break;
                default:
                    break;

            }
            radMenuFooter.DataBind();
        }

        #endregion

        #region MasterPageBase Properties

        public override string PageTitle
        {
            get
            {

                return this._title;
            }
            set
            {
                this._title = value;
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
                return this.tblInfo .Visible;
            }
            set
            {
                this.tblInfo.Visible = value;
            }
        }
        public override enumTopMenuType TopMenuType
        {

            get { return this._topMenuType; }
            set { this._topMenuType = value; }

        }

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
        public override enumTopMenuItem SelectTopMenuItem
        { get { return this._jnpselectTopMenuItem; } set { this._jnpselectTopMenuItem = value; } }


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
        public override enumTopMenuItem DisableTopMenuItem
        {
            get
            {
                return this._jnpdisableTopMenuItem;
            }
            set
            {
                this._jnpdisableTopMenuItem = value;
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

        public override bool ShowLeftMenu
        {

            get
            {
                return this._showLeftMenu;
            }
            set
            {
                this._showLeftMenu = value;
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
        public override enumLeftMenuItem SelectLeftMenuItem
        { get { return this._selectLeftMenuItem; } set { this._selectLeftMenuItem = value; } }

        public override enumFooterType FooterType
        {
            get { return this._footerType; }
            set { this._footerType = value; }
        }
        #endregion


        public override PDControlType PDControlName
        {
            get
            {
                return this._pdControlType;
            }
            set
            {
                this._pdControlType = value;
            }
        }
        public bool ShowNotesLink
        {
            get { return this.divWorkflowNotes.Visible; }
            set { this.divWorkflowNotes.Visible = value; }
        }

        protected JNPackage CurrentPackage
        {
            get
            {
                if (HttpContext.Current.Session[CurrentJNP] != null)
                {
                    _currentpackage = (JNPackage)HttpContext.Current.Session[CurrentJNP];
                }

                return _currentpackage;
            }
        }

        #region Print Message
        private void PrintMessage(string message, bool isError, bool showContentPane)
        {
            divRequiredField.Visible = false;
            divMessage.Visible = true;
            literalSystemMessage.Text = message;
            divMessage.Attributes.Add("class", (isError ? "errorMessage" : "systemMessage"));
            mainContent.Visible = showContentPane;
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

       
        protected void radMenuFooter_ItemDataBound(object sender, RadMenuEventArgs e)
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
                supportdeskitem.Target = "_blank";
            }

            RadMenuItem fwsLink = radMenuFooter.FindItemByValue("FWS");
            if (fwsLink != null)
            {
                fwsLink.Target = "_blank";
            }
        }

        protected void imgPrint_Click(object sender, ImageClickEventArgs e)
        {
            if (CurrentPackage != null)
            {
                long JNPID = CurrentPackage.JNPID;
                long JAID = CurrentPackage.JAID;
                long CRID = CurrentPackage.CRID;
                long JQID = CurrentPackage.JQID;
                Response.Redirect(Page.ResolveUrl(string.Format("~/Documents/OpenJNPDocument.aspx?id={0}&typeid={1}&documentformat={2}&jaid={3}&jqid={4}&crid={5}", JNPID, (int)enumDocumentType.All, enumDocumentFormat.PDF, JAID, JQID, CRID)));
            }
        }











    }
}