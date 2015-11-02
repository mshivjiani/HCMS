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

namespace HCMS

{
    public partial class Site : MasterPageBase
    {
      
        private PDControlType _PDControlName = PDControlType.Other;
        private LeftMenuType _leftMenuType = LeftMenuType.None;
        private enumTopMenuItem _selectTopMenuItem = enumTopMenuItem.None;
        private enumLeftMenuItem _selectLeftMenuItem = enumLeftMenuItem.None;
        private enumMenuItem _selectSubMenuItem = enumMenuItem.None;
        private enumTopMenuItem _disableTopMenuItem = enumTopMenuItem.None;
        private enumTopMenuType _topMenuType = enumTopMenuType.None;
        private enumMenuType _subMenuType = enumMenuType.None; 
        private enumFooterType _footerType = enumFooterType.Site;
        private bool _showLeftMenu = false;
        private bool _showTopMenu = false;
        private bool _showSubMenu = false;
        public delegate bool FilterLeftMenuItem(PDControlType item);
        public static string ReplaceWithAppPath(string str)
        {
            string appPath = HttpContext.Current.Request.ApplicationPath;

            if (!appPath.EndsWith("/"))
                appPath += "/";

            return str.Replace("~/", appPath);
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

        public override enumTopMenuItem SelectTopMenuItem
        { get { return this._selectTopMenuItem; } set { this._selectTopMenuItem = value; } }

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
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
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


        public override  bool ShowTopMenu
        {
            get { return _showTopMenu; }
            set {  _showTopMenu = value; }
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

        #region Page Events
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
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }
        protected override void Render(HtmlTextWriter writer)
        {
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

        protected override void OnLoad(EventArgs e)
        {//JA issue ID :77


            if ((System.Configuration.ConfigurationManager.AppSettings["Version"] != null) && (System.Configuration.ConfigurationManager.AppSettings["Version"].ToString() == "Y"))
            {
                lblVersion.Visible = true;
                lblVersion.Text = "Version: " + GetAssemblyVersion();
            }

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            base.OnLoad(e);
        }
        protected override void OnPreRender(EventArgs e)
        {
            //Sets the default page title
            if (Context.User.Identity.IsAuthenticated)
            {
                
                setPageTitleDefault();
                leftNav.Visible = ShowLeftMenu;
                topNav.Visible = ShowTopMenu ;
                setTopMenu();                         
                setLeftMenu();
                highLightSelectedTab();
                setFooter();

            }
            else
            {
                leftNav.Visible = false;
                topNav.Visible = false;
                this.FooterType = enumFooterType.Other;
                setFooter();
            }
            base.OnPreRender(e);
        }

        public static string GetAssemblyVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Diagnostics.FileVersionInfo fvi = System.Diagnostics.FileVersionInfo.GetVersionInfo(assembly.Location);
            
            return fvi.FileVersion;

        }
        #endregion

        #region Private Methods
        private void setPageTitleDefault()
        {
            
                literalPageTitle.Text = this.PageTitle;
            
        }

        private void setTopMenu()
        {
            switch (this.TopMenuType)
            {
               
                case enumTopMenuType.ModuleSelector :
                    this.TopMenuDS.DataFile = Page.ResolveUrl("~/App_Data/TopNavModuleSelector.xml");
                    break;
                case enumTopMenuType.AdminMenu:
                    this.TopMenuDS.DataFile = Page.ResolveUrl("~/App_Data/TopNavAdmin.xml");
                    break;
                default:
                    break;
            }
            
        }

        private void setLeftMenu()
        {
            switch (this.LeftMenu)
            {
                case LeftMenuType.UserAdminMenu:
                    this.leftMenuDS.DataFile = Page.ResolveUrl("~/App_Data/LeftNavUserAdmin.xml");
                    break;
                case LeftMenuType.PDAminMenu:
                    this.leftMenuDS.DataFile = Page.ResolveUrl("~/App_Data/LeftNavPDAdmin.xml");
                    break;
                case LeftMenuType.OrgCodeAdminMenu:
                    this.leftMenuDS.DataFile = Page.ResolveUrl("~/App_Data/LeftNavOrgcodeAdmin.xml");
                    break;
                case LeftMenuType.JNPAdminMenu:
                    this.leftMenuDS.DataFile = Page.ResolveUrl("~/App_Data/LeftNavJNPAdmin.xml");
                    break;
                case LeftMenuType.DashboardRoleMenu:
                    this.leftMenuDS.DataFile = Page.ResolveUrl("~/App_Data/LeftNavDashboardRole.xml");
                    break;
                case LeftMenuType.MiscellaneousAdminMenu :
                    this.leftMenuDS.DataFile = Page.ResolveUrl("~/App_Data/LeftNavMiscellaneous.xml");
                    break;
                default:
                    break;
            }
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
                case enumFooterType.Other :
                    radMenuFooter.LoadContentFile("~/App_Data/FooterOtherMaster.xml");
                   
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

        protected void radMenuFooter_ItemDataBound(object sender, Telerik.Web.UI.RadMenuEventArgs e)
        {

        }

        private void highLightSelectedTab()
        {

            this.radTabTopMenu.DataBind();
            this.radTabLeftMenu.DataBind();

            string selectTopTab = SelectTopMenuItem.ToString();
            string selectLeftTab = SelectLeftMenuItem.ToString();
            RadTab Toptab = this.radTabTopMenu.FindTabByValue(selectTopTab);
            RadTab Lefttab = this.radTabLeftMenu.FindTabByValue(selectLeftTab);
            if (Toptab != null)
            {
                Toptab.Selected = true;
            }
            if (Lefttab != null)
            { Lefttab.Selected = true; }
        }
    }
}
