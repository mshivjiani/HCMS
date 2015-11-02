using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using System.Configuration;
using HCMS.WebFramework.BasePages;

namespace HCMS.OrgChart
{
    public partial class OrgChartMaster : MasterPageBase
    {
        #region Object Declarations

        private PDControlType _pdControlType = PDControlType.Other;
        private enumTopMenuType _topMenuType = enumTopMenuType.None ;
        private LeftMenuType _leftMenuType = LeftMenuType.None;
        private enumFooterType _footerType = enumFooterType.None;
        private enumMenuType _subMenuType = enumMenuType.None;       
        private bool _showLeftMenu = false;
        private bool _showTopMenu = false;
        private bool _showSubMenu = false;
        private bool _showProgressBar = false;
        private bool _showInformationDiv = false;
        private enumProgressBarItem _progressBar = enumProgressBarItem.None;
        private enumProgressBarItem _selectProgressBar = enumProgressBarItem.None;
        private enumTopMenuItem _selectTopMenuItem = enumTopMenuItem.None;
        private enumLeftMenuItem _selectLeftMenuItem = enumLeftMenuItem.None;
        private enumTopMenuItem _disableTopMenuItem = enumTopMenuItem.None;
        private enumMenuItem _selectSubMenuItem = enumMenuItem.None;

        #endregion

        #region Properties

        public override string PageTitle
        {
            get
            {
                if (ViewState["PageTitle"] == null)
                    ViewState["PageTitle"] = string.Empty;

                return ViewState["PageTitle"].ToString();
            }
            set
            {
                ViewState["PageTitle"] = value;
                this.Page.Title = value;
            }
        }

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
                return this._showInformationDiv;
            }
            set
            {
                this._showInformationDiv = value;
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
        public override bool ShowProgressBar
        {
            get { return this._showProgressBar; }
            set { this._showProgressBar = value; }
        }

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

        public override enumTopMenuItem SelectTopMenuItem
        { get { return this._selectTopMenuItem; } set { this._selectTopMenuItem = value; } }
        public override enumLeftMenuItem SelectLeftMenuItem
        { get { return this._selectLeftMenuItem; } set { this._selectLeftMenuItem = value; } }

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

        public override enumTopMenuType TopMenuType
        {
            get { return this._topMenuType; }
            set { this._topMenuType = value; }
        }

        public override enumFooterType FooterType
        {
            get { return this._footerType; }
            set { this._footerType = value; }
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

        #endregion
        
        protected override void OnPreRender(EventArgs e)
        {
            this.literalPageTitle.Text = this.PageTitle;
            base.OnPreRender(e);
        }

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

        #region Methods: Print Error/System Messages

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
    }
}