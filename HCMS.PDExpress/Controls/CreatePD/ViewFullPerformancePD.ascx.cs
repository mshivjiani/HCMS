using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

using HCMS.WebFramework.BaseControls;
using HCMS.Business.PD;
using HCMS.Business.PD.Collections;

namespace HCMS.PDExpress.Controls.CreatePD
{
    public partial class ViewFullPerformancePD : CreatePDUserControlBase
    {
        #region Page Events

        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            this.linkButtonEditFullPD.Click += new EventHandler(linkButtonEditFullPD_Click);
            this.buttonValidate.Click += new EventHandler(buttonValidate_Click);
            base.OnInit(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                loadData();
        }

        private void loadData()
        {
            try
            {
                panelValidate.Visible = this.ShowValidation;
                panelErrors.Visible = false;

                bool isLadderStepPD = base.CurrentPDID != NULLPDID && (base.CurrentPDChoice == PDChoiceType.CareerLadderPD || base.CurrentPDChoice == PDChoiceType.CLStatementOfDifferencePD) && base.CurrentPD.LadderPosition > 0;
                panelMain.Visible = isLadderStepPD && (base.CurrentPD.GetCurrentPDStatus() != PDStatus.Published);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion

        #region Properties

        private bool OriginalShowValidation
        {
            get
            {
                if (ViewState["OriginalShowValidation"] == null)
                    ViewState["OriginalShowValidation"] = false;

                return (bool)ViewState["OriginalShowValidation"];
            }
            set
            {
                ViewState["OriginalShowValidation"] = value;
            }
        }

        public bool ShowValidation
        {
            get
            {
                if (ViewState["ShowValidation"] == null)
                    ViewState["ShowValidation"] = false;

                return (bool)ViewState["ShowValidation"];
            }
            set
            {
                ViewState["ShowValidation"] = value;
            }
        }

        #endregion

        #region Link Button Events

        private void linkButtonEditFullPD_Click(object sender, EventArgs e)
        {
            try
            {
                long associatedfullpdid = base.CurrentPD.AssociatedFullPD;
                PositionDescription associatedFullPD = new PositionDescription(associatedfullpdid);

                bool isCheckedOut = false;
                bool isCheckedOutByCurrentUser = false;
                bool canCheckOut = base.CanCheckOut(associatedfullpdid);
                bool isView = true;

                if (associatedFullPD.CheckedOutByID != -1) // PD is checked out
                {
                    isCheckedOut = true;

                    if (associatedFullPD.CheckedOutByID == base.CurrentUser.UserID) //PD is checked out by current user
                    {
                        isCheckedOutByCurrentUser = true;
                        isView = false; // can edit
                    }
                    else //PD is not checked out by current user
                    {
                        isCheckedOutByCurrentUser = false;
                        isView = true;
                    }
                }
                else // PD is not checked out
                {
                    isCheckedOut = false;
                    if (canCheckOut)
                    {
                        //check out the PD
                        base.CheckOutPositionDescription(associatedfullpdid, base.CurrentUser.UserID);
                        isView = false;

                    }
                    else
                    {
                        isView = true;
                    }

                }

                base.ReloadCurrentPD(associatedfullpdid);
                base.GoToPDLink("~/CreatePD/Occupation.aspx", isView);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion

        public void ReloadControl()
        {
            loadData();
        }

        private void buttonValidate_Click(object sender, EventArgs e)
        {
            try
            {
                if (base.CurrentPDID != NULLPDID)
                {
                    panelErrors.Visible = true;
                    panelValidate.Visible = false;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
    }
}
