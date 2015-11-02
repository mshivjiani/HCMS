using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.Business.Lookups;
using HCMS.Business.Lookups.Collections;
using HCMS.Business.PD;
using HCMS.Business.PD.Collections;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;

using Telerik.Web.UI;

using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Validation.Integration.AspNet;

namespace HCMS.PDExpress.Controls.CreatePD
{
    public partial class CareerLadderBundle : CreatePDUserControlBase
    {
        private bool _validate = false;
        private enumValidationcode _validationcode = enumValidationcode.Null;
        public string ValidationMessage
        {
            get
            {
                return literalSystemMessage.Text.Trim();
            }
            set
            {
                literalSystemMessage.Text = value;
            }
        }
        public enumValidationcode ValidationCode
        {
            get
            {
                if (ViewState["CValidationCode"] == null)
                    ViewState["CValidationCode"] = _validationcode;
                return (enumValidationcode)ViewState["CValidationCode"];
            }
            set
            {
                _validationcode = value;
            }
        }
        public bool ValidatePD
        {
            get
            {
                if (ViewState["ValidatePD"] == null)
                    ViewState["ValidatePD"] = _validate;
                return (bool)ViewState["ValidatePD"];
            }
            set
            {
                _validate = value;
            }
        }

        private bool isLadderPosition
        {
            get
            {
                return (base.CurrentPD.LadderPosition > 0 && base.CurrentPD.AssociatedFullPD > 0);

            }
        }
        protected override void OnInit(EventArgs e)
        {
            this.gridViewCareerLadderPDs.RowCommand += new GridViewCommandEventHandler(gridViewCareerLadderPDs_RowCommand);
            this.gridViewCareerLadderPDs.RowDataBound += new GridViewRowEventHandler(gridViewCareerLadderPDs_RowDataBound);
            base.OnInit(e);
        }
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                if (!IsPostBack && base.CurrentPDID != -1)
                {
                    LoadData();
                }
                base.OnLoad(e);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void LoadData()
        {
            //Bind the grid and show only if Ladders are generated
            bool isCareerLadderPD = (base.CurrentPDChoice == PDChoiceType.CareerLadderPD || base.CurrentPDChoice == PDChoiceType.CLStatementOfDifferencePD)
                && (base.CurrentPD.LadderPosition != -1);
            if (isCareerLadderPD)
            {
                bindCareerLadderPDs();
                panelCareerLadderStepPDs.Visible = true;
                // show EDIT column if the PD is not Read-Only
                gridViewCareerLadderPDs.Columns[1].Visible = !base.IsPDReadOnly;
                //Hide View column when PD is not readonly
                gridViewCareerLadderPDs.Columns[0].Visible = base.IsPDReadOnly;
                //Hide Action column when PD is published
                gridViewCareerLadderPDs.Columns[7].Visible = !((PDStatus)base.CurrentPDWorkflowStatus.WorkflowStatusID == PDStatus.Published);
                divActionMessageSummary.Visible = this.ValidationMessage.Length > 0;
            }
            else
            {
                panelCareerLadderStepPDs.Visible = false;
            }
        }

        public void ReloadControl()
        {
            LoadData();
        }

        public void SetMessage(enumValidationcode validationcode, string validationerrors)
        {
            switch (validationcode)
            {
                case enumValidationcode.ValidationErrors:
                    literalSystemMessage.Text = validationerrors;
                    divActionMessageSummary.Visible = true;
                    divSaveAndUnlock.Visible = false;
                    divSignAndSubmit.Visible = false;
                    break;

                case enumValidationcode.SaveAndUnlock:
                    divActionMessageSummary.Visible = false;
                    divSignAndSubmit.Visible = false;
                    divSaveAndUnlock.Visible = true;
                    break;
                case enumValidationcode.SignAndSubmit:
                    divActionMessageSummary.Visible = false;
                    divSaveAndUnlock.Visible = false;
                    divSignAndSubmit.Visible = true;
                    break;
                default:
                    break;
            }
        }

        #region [ GridView Event ]

        private void bindCareerLadderPDs()
        {
            gridViewCareerLadderPDs.DataSource = base.CurrentPD.GetOtherCareerLadderPositionDescriptions();
            gridViewCareerLadderPDs.DataBind();
        }

        private void gridViewCareerLadderPDs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                    {
                        PositionDescription thisPD = (PositionDescription)e.Row.DataItem;
                        LinkButton linkButtonView = (LinkButton)e.Row.FindControl("linkButtonView");
                        LinkButton linkButtonEdit = (LinkButton)e.Row.FindControl("linkButtonEdit");
                        Label lblActions = (Label)e.Row.FindControl("lblActions");
                        Label lblLadderPosition = (Label)e.Row.FindControl("lblLadderPosition");
                        Image imgNoActions = (Image)e.Row.FindControl("imgNoActions");
                        ImageButton imgAction = (ImageButton)e.Row.FindControl("imgAction");

                        if (imgAction != null)
                        {
                            imgAction.Attributes.Add("onclick", "javascript:ShowCLActionsPopup(" + thisPD.PositionDescriptionID.ToString() + "); return false;");
                        }

                        lblLadderPosition.Text = String.Format("<span style='white-space: nowrap;'>{0}</span>", thisPD.PositionDescriptionTypeDisp);

                        linkButtonView.CommandArgument = thisPD.PositionDescriptionID.ToString();
                        linkButtonEdit.CommandArgument = thisPD.PositionDescriptionID.ToString();

                        PDValidationErrorCollection errorList = thisPD.GetValidationErrors(false, true);
                        lblActions.Text = errorList.Count.ToString();
                        lblActions.Visible = imgAction.Visible = errorList.Count > 0;
                        imgNoActions.Visible = errorList.Count == 0;

                        //Style the row if it is current PD
                        if (thisPD.PositionDescriptionID == base.CurrentPDID)
                        {
                            e.Row.Style["font-weight"] = "bold";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void gridViewCareerLadderPDs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                bool viewSelected = e.CommandName.Equals("ViewPD");
                long newPDID = Convert.ToInt64(e.CommandArgument);

                if (!viewSelected)
                {
                    PositionDescription thisPD = new PositionDescription();
                    base.CurrentGoBackPDID = base.CurrentPDID;
                    // EDIT -- check out the position description first
                    thisPD.PositionDescriptionID = newPDID;
                    thisPD.CheckOut(base.CurrentUser.UserID);
                }

                base.ReloadCurrentPD(newPDID);
                if (base.CurrentPDChoice != null && base.CurrentPDChoice == PDChoiceType.CLStatementOfDifferencePD)
                    base.GoToPDLink("~/CreatePD/SOD.aspx", viewSelected);
                else
                    base.GoToPDLink("~/CreatePD/Occupation.aspx", viewSelected);
            }
            catch (Exception ex)
            {
                base.PrintErrorMessage(ex, true);
            }
        }

        #endregion

        protected void SaveAndUnlock_Click(object sender, EventArgs e)
        {
            if (isLadderPosition)
            {
                long fplPDID = base.CurrentPD.AssociatedFullPD;
                base.ClearCurrentPD();
                base.CurrentPDID = fplPDID;
            }
            CurrentPD.CheckInCareerLadder(CurrentUser.UserID);
            //PDX issue:1516:recieving error message when PD Developers selects Save and Unlock on Factor Screen in Draft Status 
            //changed redirection url name - from default.aspx to redirectURL that is fetched from config.
            string redirectURL = System.Configuration.ConfigurationManager.AppSettings["PDExpressDefaultURL"].ToString();
            Response.Redirect(redirectURL);
        }

        protected void SignAndSubmit_Click(object sender, EventArgs e)
        {
            if (isLadderPosition)
            {
                long fplPDID = base.CurrentPD.AssociatedFullPD;
                base.ClearCurrentPD();
                base.CurrentPDID = fplPDID;
            }
            base.GoToPDLink("~/CreatePD/Approvals.aspx");

        }
    }
}
