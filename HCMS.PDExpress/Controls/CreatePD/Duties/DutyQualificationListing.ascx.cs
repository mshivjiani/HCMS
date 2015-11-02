using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using HCMS.WebFramework.BaseControls;
using HCMS.Business.PD;
using HCMS.Business.Duty;
using HCMS.Business.Lookups;
using HCMS.Business.Security;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;

using Telerik.Web.UI;

namespace HCMS.PDExpress.Controls.CreatePD.Duties
{
    public partial class DutyQualificationListing : CreatePDUserControlBase
    {
        #region [ Page Event Handlers ]
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            base.OnInit(e);
        }

        // WHICH ONE TO USE: Page_Load() or OnLoad() ? 

        // overload virtual void PageBase.Page_Load(...)
        // order of execution: PagePase.Page_Load(...), then DutyQualificationPopup.Page_Load(...)
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData();
                setPageView();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void setPageView()
        {
            bool editable = !base.IsPDReadOnly;
            bool okToUse = false;
            bool isSOD = base.CurrentPDChoice == PDChoiceType.StatementOfDifferencePD;
            PDStatus status = base.CurrentPD.GetCurrentPDStatus();
            bool isPDCreator = base.CurrentPD.PDCreatorID.Equals(base.CurrentUser.UserID);
            bool isPDCreatorSupervisor = base.isPDCreatorSupervisor(false);
            bool hasHRGroupPermission = editable && (base.HasPermission(enumPermission.CompleteHRCertification) || base.HasPermission(enumPermission.MaintainEvaluationStatements) ||
             base.HasPermission(enumPermission.MaintainHRSection) || base.HasPermission(enumPermission.MaintainFactorRecommendation) ||
                    base.HasPermission(enumPermission.PublishPD));

            if (isSOD)
            {
                rgDutyQual.Columns[0].Visible = false;
                rgDutyQual.Columns[1].Visible = false;
                rgDutyQual.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
            }
            else
            {
                switch (status)
                {

                    case PDStatus.Draft:
                        okToUse = editable && ((isPDCreator || isPDCreatorSupervisor));
                        if (!okToUse)
                        {
                            rgDutyQual.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                        }
                        rgDutyQual.Columns[0].Visible = rgDutyQual.Columns[1].Visible = okToUse;  // Edit/delete column
                        break;

                    //Gives HR permission to Edit Duties
                    case PDStatus.Review:
                        okToUse = editable && hasHRGroupPermission;
                        if (!okToUse)
                        {
                            rgDutyQual.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                        }
                        rgDutyQual.Columns[0].Visible = rgDutyQual.Columns[1].Visible = okToUse;  // Edit/delete column
                        break;

                    case PDStatus.Revise:
                        okToUse = editable && ((isPDCreator || isPDCreatorSupervisor));
                        if (!okToUse)
                        {
                            rgDutyQual.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                        }
                        rgDutyQual.Columns[0].Visible = rgDutyQual.Columns[1].Visible = okToUse;  // Edit/delete column
                        break;

                    case PDStatus.FinalReview:
                        okToUse = editable && base.HasPermission(enumPermission.AllSystemAdministrationPermissions);

                        if (!okToUse)
                        {
                            rgDutyQual.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                        }

                        rgDutyQual.Columns[0].Visible = rgDutyQual.Columns[1].Visible = okToUse;  // Delete column
                        break;
                    default: //takes care of PUBLISHED Status as well
                        if (!editable)
                        {
                            rgDutyQual.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
                        }

                        rgDutyQual.Columns[0].Visible = rgDutyQual.Columns[1].Visible = editable;  // Delete column
                        break;
                }
            }
        }

        //// order of execution: DutyQualificationPopup.OnLoad(...), then PagePase.Page_Load(...)
        //protected override void OnLoad(EventArgs e)
        //{
        //    PositionDutyLoad();   
        //    base.OnLoad(e);
        //}
        #endregion

        #region [ Duty Qualification Grid Event Handlers and Methods]
        protected void rgDutyQual_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            List<DutyCompetencyKSA> qualList = positionDuty.GetDutyCompetencyKSA();
            rgDutyQual.DataSource = qualList;
        }
        protected void rgDutyQual_ItemDataBound(object sender, GridItemEventArgs e)
        {
            GridItem gridItem = e.Item;

            if (gridItem.ItemType == GridItemType.Item || gridItem.ItemType == GridItemType.AlternatingItem)
            {
                Label lblQualificationName = gridItem.FindControl("lblQualificationName") as Label;
                Label lblQualificationDescription = gridItem.FindControl("lblQualificationDescription") as Label;
                Label lblQualificationTypeName = gridItem.FindControl("lblQualificationTypeName") as Label;

                if (gridItem.DataItem is DutyCompetencyKSA)
                {
                    DutyCompetencyKSA positionQual = gridItem.DataItem as DutyCompetencyKSA;

                    lblQualificationName.Text = positionQual.QualificationName;
                    lblQualificationDescription.Text = positionQual.CompetencyKSA;
                    lblQualificationTypeName.Text = positionQual.QualificationTypeName;
                }
            }
            else if (gridItem.ItemType == GridItemType.EditItem)
            {
                RadComboBox rcbQualificationName = gridItem.FindControl("rcbQualificationName") as RadComboBox;
                TextBox tbQualificationDescription = gridItem.FindControl("tbQualificationDescription") as TextBox;
                RadComboBox rcbQualificationTypeName = gridItem.FindControl("rcbQualificationTypeName") as RadComboBox;

                if (gridItem.DataItem is DutyCompetencyKSA)
                {
                    // edit existing row
                    DutyCompetencyKSA qual = gridItem.DataItem as DutyCompetencyKSA;

                    rcbQualificationName.SelectedValue = qual.QualificationID.ToString();
                    ControlUtility.SafeTextBoxAssign(tbQualificationDescription, qual.CompetencyKSA);
                    rcbQualificationTypeName.SelectedValue = qual.QualificationTypeID.ToString();
                }
                else if (gridItem.DataItem is GridInsertionObject)
                {
                    // edit row to be inserted

                    rcbQualificationName.SelectedIndex = -1;
                    tbQualificationDescription.Text = String.Empty;
                    rcbQualificationTypeName.SelectedIndex = -1;
                }
            }
            //hide the refresh button Telerik.Web.UI.GridLinkButton
            if (gridItem is GridCommandItem)
            {
                gridItem.FindControl("RebindGridButton").Visible = false;

            }
        }
        protected void rgDutyQual_ItemCommand(object source, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                    break;

                case RadGrid.PerformInsertCommandName:
                    AddDutyQualification(source, e);
                    break;

                case RadGrid.EditCommandName:
                    break;

                case RadGrid.CancelCommandName:
                    break;

                case RadGrid.UpdateCommandName:
                    UpdateDutyQualification(source, e);
                    break;

                case RadGrid.DeleteCommandName:
                    DeleteDutyQualification(source, e);
                    break;

                default:
                    break;
            }
        }

        private void AddDutyQualification(object source, GridCommandEventArgs e)
        {
            DateTime createDate = DateTime.Now;

            if (source is RadGrid)
            {
                GridDataInsertItem gridItem = e.Item as GridDataInsertItem;

                if (gridItem.ItemType == GridItemType.EditItem)
                {
                    RadComboBox rcbQualificationName = gridItem.FindControl("rcbQualificationName") as RadComboBox;
                    TextBox tbQualificationDescription = gridItem.FindControl("tbQualificationDescription") as TextBox;
                    RadComboBox rcbQualificationTypeName = gridItem.FindControl("rcbQualificationTypeName") as RadComboBox;

                    DutyCompetencyKSA dutyCompetency = new DutyCompetencyKSA();

                    dutyCompetency.DutyID = DutyID;
                    dutyCompetency.CompetencyKSA = tbQualificationDescription.Text;
                    dutyCompetency.Certification = String.Empty;
                    dutyCompetency.QualificationTypeID = Convert.ToInt32(rcbQualificationTypeName.SelectedValue);
                    dutyCompetency.CreatedByID = base.CurrentUser.UserID;
                    dutyCompetency.CreateDate = createDate;
                    dutyCompetency.UpdatedByID = base.CurrentUser.UserID;
                    dutyCompetency.UpdateDate = createDate;
                    dutyCompetency.QualificationID = Convert.ToInt32(rcbQualificationName.SelectedValue);

                    dutyCompetency.Add();

                    rgDutyQual.Rebind();
                }
            }
        }
        private void UpdateDutyQualification(object source, GridCommandEventArgs e)
        {
            if (source is RadGrid)
            {
                RadGrid grid = source as RadGrid;

                GridDataItem gridItem = e.Item as GridDataItem;

                int dutyCompetencyKSAID = int.Parse(gridItem.GetDataKeyValue("DutyCompetencyKSAID").ToString());
                long dutyID = long.Parse(gridItem.GetDataKeyValue("DutyID").ToString());

                RadComboBox rcbQualificationName = gridItem.FindControl("rcbQualificationName") as RadComboBox;
                TextBox tbQualificationDescription = gridItem.FindControl("tbQualificationDescription") as TextBox;
                RadComboBox rcbQualificationTypeName = gridItem.FindControl("rcbQualificationTypeName") as RadComboBox;

                DutyCompetencyKSA dutyCompetency = new DutyCompetencyKSA(dutyCompetencyKSAID);

                dutyCompetency.CompetencyKSA = tbQualificationDescription.Text;
                dutyCompetency.QualificationTypeID = Convert.ToInt32(rcbQualificationTypeName.SelectedValue);
                dutyCompetency.QualificationID = Convert.ToInt32(rcbQualificationName.SelectedValue);

                dutyCompetency.Update();

                rgDutyQual.Rebind();
            }
        }
        private void DeleteDutyQualification(object source, GridCommandEventArgs e)
        {
            if (source is RadGrid)
            {
                GridDataItem gridItem = e.Item as GridDataItem;

                int dutyCompetencyKSAID = int.Parse(gridItem.GetDataKeyValue("DutyCompetencyKSAID").ToString());
                long dutyID = long.Parse(gridItem.GetDataKeyValue("DutyID").ToString());

                DutyCompetencyKSA dutyCompetency = new DutyCompetencyKSA(dutyCompetencyKSAID);
                dutyCompetency.Delete();

                rgDutyQual.Rebind();
            }
        }
        #endregion

        #region [ Private Methods ]
        private void LoadData()
        {
            positionDuty = new PositionDuty(DutyID);

            if (!IsPostBack)
            {
                ControlUtility.SafeTextBoxAssign(txtDutyQualification, positionDuty.DutyDescription);
            }
        }
        #endregion

        #region [ Private Properties ]
        private int DutyID
        {
            get
            {
                string DutyIDParam = Request.QueryString["DutyID"];

                if (String.IsNullOrEmpty(DutyIDParam))
                    return -1;
                else
                    return int.Parse(DutyIDParam);
            }
        }
        #endregion

        #region [ Private Fields ]
        private PositionDuty positionDuty;
        #endregion
    }
}
