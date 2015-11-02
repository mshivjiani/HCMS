using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.Business.JA;
using HCMS.Business.JA.Collections;
using HCMS.Business.Lookups.Collections;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;
using Telerik.Web.UI;
using HCMS.Business.JQ;
using HCMS.Business.PD;
using HCMS.Business.CR;
using System.Data;
using HCMS.JNP.Controls.Workflow;
using System.Web.UI.HtmlControls;
using HCMS.WebFramework.Security;
namespace HCMS.JNP.Controls.JA
{
    public partial class ctrlJAFinalKSA : JNPUserControlBase
    {
        private const string DUTYCOUNTERS = "DutyCounterList";

        //long previousJADutyID = 0;
        long currentDutyNumber = 0; 
        List<CheckBox> chkKSA;
        ctrlDutyDescription DutyDescription = new ctrlDutyDescription();

        #region Properties

        public string EmptyLiteralValue
        {
            get
            {
                if (ViewState["EmptyLiteralValue"] == null)
                    ViewState["EmptyLiteralValue"] = GetLocalResourceObject("EmptyLiteralValue").ToString();

                return ViewState["EmptyLiteralValue"].ToString();
            }
        }

        public JobAnalysisDutyKSAFactorCollection JADutyKSAFactorList
        {
            get
            {
                if (ViewState["JADutyKSAList"] == null)
                    ViewState["JADutyKSAList"] = new JobAnalysisDutyKSAFactorCollection();

                return (JobAnalysisDutyKSAFactorCollection)ViewState["JADutyKSAList"];
            }
            set
            {
                ViewState["JADutyKSAList"] = value;
            }
        }
        public List<JQFactor> JAKSAFactorList
        {
            get
            {
                if (ViewState["JAKSAFactorList"] == null)
                    ViewState["JAKSAFactorList"] = new List<JQFactor>();

                return (List<JQFactor>)ViewState["JAKSAFactorList"];
            }
            set
            {
                ViewState["JAKSAFactorList"] = value;
            }
        }

        public long CurrentFullPDID
        {
            get
            {
                if (ViewState["CurrentFullPDID"] == null)
                {
                    if (base.CurrentFullPDID != null)
                    {
                        ViewState["CurrentFullPDID"] = Convert.ToInt32(Request.QueryString["CurrentFullPDID"]);
                    }
                    else
                    {
                        ViewState["CurrentFullPDID"] = -1;
                    }
                }
                return Convert.ToInt64(ViewState["CurrentFullPDID"]);
            }
            set
            {
                ViewState["CurrentFullPDID"] = value;
            }
        }

        #endregion

        #region Methods

        protected override void OnInit(EventArgs e)
        {
            this.gridDutyKSA.ItemDataBound += new GridItemEventHandler(gridDutyKSA_ItemDataBound);
            this.gridDutyKSA.SortCommand += new GridSortCommandEventHandler(gridDutyKSA_SortCommand);
            this.gridDutyKSA.EditCommand += new GridCommandEventHandler(gridDutyKSA_EditCommand);
            this.gridDutyKSA.CancelCommand += new GridCommandEventHandler(gridDutyKSA_CancelCommand);
        
            base.OnInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            if (!IsPostBack)
            {
                if (IsValidJA())
                {
                    bindData();
                    gridDutyKSAEmploymentConditions.Rebind();
                }
            }
            base.OnLoad(e);
        }

        private static int sortJADutyKSAByPercOfTime(JobAnalysisDutyKSAFactor jaDutyKSAFactor1, JobAnalysisDutyKSAFactor jaDutyKSAFactor2)
        {
            return jaDutyKSAFactor1.PercentageOfTime.CompareTo(jaDutyKSAFactor2.PercentageOfTime);

        }

        private static int sortJADutyKSAByJADutyID(JobAnalysisDutyKSAFactor jaDutyKSAFactor1, JobAnalysisDutyKSAFactor jaDutyKSAFactor2)
        {
            return jaDutyKSAFactor1.JADutyID.CompareTo(jaDutyKSAFactor2.JADutyID);

        }

        private void bindData()
        {
            try
            {
                // Create a "lookup" list of DutyCounters to show correct Duty number in grid. This fix
                //  even allows for Duties that have no DutyKSAs and shows number skips as needed
                List<JobAnalysisDuty> currentJADuties = base.CurrentJobAnalysis.GetJobAnalysisDuty();
                currentJADuties = currentJADuties
                    .OrderByDescending(ob => ob.JAPercentageOfTime)
                    .ThenBy(ob2 => ob2.JADutyID).ToList();
                DutyCounters = null;
                int dutyNum = 1;
                foreach (var d in currentJADuties)
                {
                    DutyCounters.Add(new DutyCounter() { Number = dutyNum, JADutyID = d.JADutyID });
                    dutyNum++;
                }
                
                
                this.JADutyKSAFactorList = CurrentJobAnalysis.GetJobAnalysisDutyKSAFactor();
                List<JobAnalysisDutyKSAFactor> lstJobAnalysisDutyKSACollection = new List<JobAnalysisDutyKSAFactor>();
                lstJobAnalysisDutyKSACollection = JADutyKSAFactorList
                    .Where(p => (p.QualificationTypeID != (int)enumQualificationType.ConditionOfEmployment))
                    .ToList();

                // Issue: 729/768
                // Mark Deibert, 9/16/2013
                // Using exact same sorting as in ctrlDutyKSA
                this.gridDutyKSA.DataSource = lstJobAnalysisDutyKSACollection
                    .OrderByDescending(ob => ob.PercentageOfTime)
                    .ThenBy(ob2 => ob2.JADutyID);
                this.gridDutyKSA.DataBind();

                SetPageView();


            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        //Issue Id: 169
        //Author: Deepali Anuje
        //Date Fixed: 2/21/2012
        //Description: Cond of Emp+Sel Factors from PDs Overall Quals are NOT appearing in COE table on Final KSA screen of JA 
        protected void gridDutyKSAEmploymentConditions_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            if (base.CurrentFullPDID > 0)
            {    
                
                this.JAKSAFactorList = CurrentJobAnalysis.GetJAKSAFactor();

                //gridDutyKSAEmploymentConditions.DataSource = JAKSAFactorList.Where(p => (p.QualificationTypeID == (int)enumQualificationType.ConditionOfEmployment))
                //                                .OrderBy(p => (p.QualificationTypeName)).ToList();

                List<JQFactor> ls = JAKSAFactorList.Where(p => (p.QualificationTypeID == (int)enumQualificationType.ConditionOfEmployment))
                                                            .OrderBy(p => (p.QualificationTypeName)).ToList();

                gridDutyKSAEmploymentConditions.DataSource = ls;


                lblConditionOfEmpHeader.Visible = (ls.Count > 0);
                gridDutyKSAEmploymentConditions.Visible = (ls.Count > 0);

            }
        }

        protected void gridDutyKSAEmploymentConditions_ItemDataBound(object sender, GridItemEventArgs e)
        {
            HideRefreshButton(e);
        }



        private void SetPageView()
        {
            try
            {

                chkKSA = new List<CheckBox>();
                bool countOK = this.JADutyKSAFactorList.GetFinalDutyKSAList().ContainsAtLeastOneFinalizedKSA();

                if (base.ShowEditFields(enumDocumentType.JA))
                {
                    //if in final review except admin no body should be be allowed to make any changes.
                    if ((!base.IsAdmin) && (CurrentJNPWS == enumJNPWorkflowStatus.FinalReview))
                    {
                        //Issue 1060 Editable for HR in FinalReview
                        if ((base.HasHRGroupPermission) && (CurrentJNPWS == enumJNPWorkflowStatus.FinalReview) && (!CurrentJNP.IsJNPSignedByHR))
                        {
                            EnableCheckboxes(true);
                            EnableDisableDropDowns(true);
                        }
                        else
                        {
                            EnableCheckboxes(false);
                            EnableDisableDropDowns(false);
                        }
                    }
                    else
                    {
                        EnableCheckboxes(true);
                        EnableDisableDropDowns(true);
                    }
                }
                else
                {
                    EnableCheckboxes(false);
                    EnableDisableDropDowns(false);
                }
            }


            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void EnableCheckboxes(bool enabled)
        {
            foreach (GridDataItem item in gridDutyKSA.MasterTableView.Items)
            {
                CheckBox chk = (CheckBox)item.FindControl("checkboxIsFinalKSA1");
                Literal literalQualificationTypeName = (Literal)item.FindControl("literalQualificationTypeName");

                if (literalQualificationTypeName != null && literalQualificationTypeName.Text != "Selective Factor")
                {
                    // Set the value here
                    chk.Enabled = enabled;
                }
                else 
                {
                    chk.Enabled = false;
                }
            }
        }

        private void EnableDisableDropDowns(bool enabled)
        {
            foreach (GridDataItem item in gridDutyKSA.MasterTableView.Items)
            {
                RadComboBox ddImportance = (RadComboBox)item.FindControl("dropdownImportance");
                RadComboBox ddNeedAtEntry = (RadComboBox)item.FindControl("dropdownNeedAtEntry");
                RadComboBox ddDistinguishingValue = (RadComboBox)item.FindControl("dropdownDistinguishingValue");

                ddImportance.Enabled = enabled;
                ddNeedAtEntry.Enabled = enabled;
                ddDistinguishingValue.Enabled = enabled;
            }
        }

      
        private void HideRefreshButton(GridItemEventArgs e)
        {
            GridItem gridItem = e.Item;
            //hide the refresh button Telerik.Web.UI.GridLinkButton
            if (gridItem is GridCommandItem)
            {
                gridItem.FindControl("RebindGridButton").Visible = false;

            }
        }

        private void gridDutyKSA_ItemDataBound(object sender, GridItemEventArgs e)
        {
            try
            {

                HideRefreshButton(e);
                JobAnalysisDutyKSAFactor currentKSAFactor = e.Item.DataItem as JobAnalysisDutyKSAFactor;

                if (e.Item is GridDataItem)
                {

                    Literal literalKSADescription = e.Item.FindControl("literalKSADescription") as Literal;
                    Literal literalQualificationTypeName = e.Item.FindControl("literalQualificationTypeName") as Literal;
                    Literal literalTotalScore = e.Item.FindControl("literalTotalScore") as Literal;
                    //Label lblDutyNumber = e.Item.FindControl("lblDutyNumber") as Label;
                    //Label tooltipDutyNumber = e.Item.FindControl("ToolTipDutyNumber") as Label;
                    TextBox txtDutyNumber = e.Item.FindControl("txtDutyNumber") as TextBox;

                    CheckBox checkboxIsFinalKSA1 = e.Item.FindControl("checkboxIsFinalKSA1") as CheckBox;
                    RadComboBox dropdownImportance = e.Item.FindControl("dropdownImportance") as RadComboBox;
                    RadComboBox dropdownNeedAtEntry = e.Item.FindControl("dropdownNeedAtEntry") as RadComboBox;
                    RadComboBox dropdownDistinguishingValue = e.Item.FindControl("dropdownDistinguishingValue") as RadComboBox;

                    // bind importance scale
                    ControlUtility.BindRadComboBoxControl(dropdownImportance, LookupWrapper.GetImportanceScale(false), null, "ImportanceName", "ImportanceID", "[-- Select --]");

                    // bind need at entry
                    ControlUtility.BindRadComboBoxControl(dropdownNeedAtEntry, LookupWrapper.GetNeedAtEntryScale(false), null, "NeedAtEntryName", "NeedAtEntryID", "[-- Select --]");

                    // bind distinguishing value scale
                    ControlUtility.BindRadComboBoxControl(dropdownDistinguishingValue, LookupWrapper.GetDistinguishingValueScale(false), null, "ScaleName", "ScaleID", "[-- Select --]");

                    // now set values
                    ControlUtility.SafeListControlSelect(dropdownImportance, (int)currentKSAFactor.ImportanceID);
                    ControlUtility.SafeListControlSelect(dropdownNeedAtEntry, (int)currentKSAFactor.NeedAtEntryID);
                    ControlUtility.SafeListControlSelect(dropdownDistinguishingValue, (int)currentKSAFactor.DistinguishingValueScaleID);


                    literalKSADescription.Text = currentKSAFactor.JQFactorTitle;
                    literalQualificationTypeName.Text = currentKSAFactor.QualificationTypeName;
                    literalTotalScore.Text = currentKSAFactor.TotalScore.ToString();

                    // Lookup the correct Duty sequence number stored in list of DutyCounters created in ctrlDutyKSA.ascx bindData()
                    currentDutyNumber = DutyCounters.Find(c => c.JADutyID == currentKSAFactor.JADutyID).Number;
                    txtDutyNumber.Text = "Duty " + (currentDutyNumber == null ? "" : currentDutyNumber.ToString());

                    //Add the image id to the tooltip manager 
                    this.RadToolTipManager1.TargetControls.Add(txtDutyNumber.ClientID, currentDutyNumber.ToString() + "|" + currentKSAFactor.JADutyID.ToString(), true);


                    if (checkboxIsFinalKSA1 != null)
                    {
                        checkboxIsFinalKSA1.Checked = currentKSAFactor.IsFinalKSA;
                    }

                    if (currentKSAFactor.QualificationTypeID == (int)enumQualificationType.SelectiveFactor)
                    {
                        checkboxIsFinalKSA1.Checked = true;
                        checkboxIsFinalKSA1.Enabled = false;
                    }

                }
                else if (e.Item is GridEditableItem && e.Item.IsInEditMode)
                {
                    RadComboBox dropdownImportance = e.Item.FindControl("dropdownImportance") as RadComboBox;
                    RadComboBox dropdownNeedAtEntry = e.Item.FindControl("dropdownNeedAtEntry") as RadComboBox;
                    RadComboBox dropdownDistinguishingValue = e.Item.FindControl("dropdownDistinguishingValue") as RadComboBox;
                    CheckBox checkboxIsFinalKSA1 = e.Item.FindControl("checkboxIsFinalKSA1") as CheckBox;

                    // bind importance scale
                    ControlUtility.BindRadComboBoxControl(dropdownImportance, LookupWrapper.GetImportanceScale(false), null, "ImportanceName", "ImportanceID", "[-- Select --]");

                    // bind need at entry
                    ControlUtility.BindRadComboBoxControl(dropdownNeedAtEntry, LookupWrapper.GetNeedAtEntryScale(false), null, "NeedAtEntryName", "NeedAtEntryID", "[-- Select --]");

                    // bind distinguishing value scale
                    ControlUtility.BindRadComboBoxControl(dropdownDistinguishingValue, LookupWrapper.GetDistinguishingValueScale(false), null, "ScaleName", "ScaleID", "[-- Select --]");

                    // now set values
                    ControlUtility.SafeListControlSelect(dropdownImportance, (int)currentKSAFactor.ImportanceID);
                    ControlUtility.SafeListControlSelect(dropdownNeedAtEntry, (int)currentKSAFactor.NeedAtEntryID);
                    ControlUtility.SafeListControlSelect(dropdownDistinguishingValue, (int)currentKSAFactor.DistinguishingValueScaleID);

                    if (checkboxIsFinalKSA1 != null)
                    {
                        checkboxIsFinalKSA1.Checked = currentKSAFactor.IsFinalKSA;
                    }

                    if (currentKSAFactor.QualificationTypeID == (int)enumQualificationType.SelectiveFactor)
                    {
                        checkboxIsFinalKSA1.Checked = true;
                        checkboxIsFinalKSA1.Enabled = false;
                    }

                }
                SetPageView();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void dropdownImportance_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                RadComboBox dropdownImportance = (RadComboBox)sender;
                GridEditableItem editedItem = (GridEditableItem)dropdownImportance.NamingContainer;

                RadComboBox dropdownNeedAtEntry = editedItem.FindControl("dropdownNeedAtEntry") as RadComboBox;
                RadComboBox dropdownDistinguishingValue = editedItem.FindControl("dropdownDistinguishingValue") as RadComboBox;

                long jQFactorID = (long)editedItem.OwnerTableView.DataKeyValues[editedItem.ItemIndex]["JQFactorID"];
                JobAnalysisDutyKSAFactor currentKSAFactor = new JobAnalysisDutyKSAFactor(jQFactorID);


                if (currentKSAFactor != null)
                {

                    if (dropdownImportance.SelectedValue != "")
                        currentKSAFactor.ImportanceID = (enumImportanceScale)ControlUtility.GetDropdownValue(dropdownImportance);
                    if (dropdownNeedAtEntry.SelectedValue != "")
                        currentKSAFactor.NeedAtEntryID = (enumNeedAtEntryScale)ControlUtility.GetDropdownValue(dropdownNeedAtEntry);
                    if (dropdownDistinguishingValue.SelectedValue != "")
                        currentKSAFactor.DistinguishingValueScaleID = (enumDistinguishingValueScale)ControlUtility.GetDropdownValue(dropdownDistinguishingValue);
                    currentKSAFactor.UpdatedByID = base.CurrentUserID;
                    currentKSAFactor.UpdateScaleAndFinalInformation();
                    bindData();

                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void dropdownNeedAtEntry_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                RadComboBox dropdownNeedAtEntry = (RadComboBox)sender;
                GridEditableItem editedItem = (GridEditableItem)dropdownNeedAtEntry.NamingContainer;

                RadComboBox dropdownImportance = editedItem.FindControl("dropdownImportance") as RadComboBox;
                RadComboBox dropdownDistinguishingValue = editedItem.FindControl("dropdownDistinguishingValue") as RadComboBox;

                long jQFactorID = (long)editedItem.OwnerTableView.DataKeyValues[editedItem.ItemIndex]["JQFactorID"];
                JobAnalysisDutyKSAFactor currentKSAFactor = new JobAnalysisDutyKSAFactor(jQFactorID);

                if (currentKSAFactor != null)
                {

                    if (dropdownImportance.SelectedValue != "")
                        currentKSAFactor.ImportanceID = (enumImportanceScale)ControlUtility.GetDropdownValue(dropdownImportance);
                    if (dropdownNeedAtEntry.SelectedValue != "")
                        currentKSAFactor.NeedAtEntryID = (enumNeedAtEntryScale)ControlUtility.GetDropdownValue(dropdownNeedAtEntry);
                    if (dropdownDistinguishingValue.SelectedValue != "")
                        currentKSAFactor.DistinguishingValueScaleID = (enumDistinguishingValueScale)ControlUtility.GetDropdownValue(dropdownDistinguishingValue);
                    currentKSAFactor.UpdatedByID = base.CurrentUserID;
                    currentKSAFactor.UpdateScaleAndFinalInformation();
                    bindData();

                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void dropdownDistinguishingValue_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                RadComboBox dropdownDistinguishingValue = (RadComboBox)sender;
                GridEditableItem editedItem = (GridEditableItem)dropdownDistinguishingValue.NamingContainer;

                RadComboBox dropdownImportance = editedItem.FindControl("dropdownImportance") as RadComboBox;
                RadComboBox dropdownNeedAtEntry = editedItem.FindControl("dropdownNeedAtEntry") as RadComboBox;

                long jQFactorID = (long)editedItem.OwnerTableView.DataKeyValues[editedItem.ItemIndex]["JQFactorID"];
                JobAnalysisDutyKSAFactor currentKSAFactor = new JobAnalysisDutyKSAFactor(jQFactorID);

                if (currentKSAFactor != null)
                {


                    if (dropdownImportance.SelectedValue != "")
                        currentKSAFactor.ImportanceID = (enumImportanceScale)ControlUtility.GetDropdownValue(dropdownImportance);
                    if (dropdownNeedAtEntry.SelectedValue != "")
                        currentKSAFactor.NeedAtEntryID = (enumNeedAtEntryScale)ControlUtility.GetDropdownValue(dropdownNeedAtEntry);
                    if (dropdownDistinguishingValue.SelectedValue != "")
                        currentKSAFactor.DistinguishingValueScaleID = (enumDistinguishingValueScale)ControlUtility.GetDropdownValue(dropdownDistinguishingValue);
                    currentKSAFactor.UpdatedByID = base.CurrentUserID;
                    currentKSAFactor.UpdateScaleAndFinalInformation();
                    bindData();

                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void checkboxIsFinalKSA1_CheckedChange(object sender, EventArgs e)
        {
            try
            {
                string script = string.Empty;
                string navigateurl = string.Empty;

                script = string.Format("GetKSACheckedCount();");
                CheckBox chkbx = (CheckBox)sender;
                GridEditableItem editedItem = (GridEditableItem)chkbx.NamingContainer;

                RadComboBox dropdownImportance = editedItem.FindControl("dropdownImportance") as RadComboBox;
                RadComboBox dropdownNeedAtEntry = editedItem.FindControl("dropdownNeedAtEntry") as RadComboBox;
                RadComboBox dropdownDistinguishingValue = editedItem.FindControl("dropdownDistinguishingValue") as RadComboBox;

                // MD 8/1: Disable this check for now, per Pam
                //// Make sure all of the Scale dropdowns are selected before allowing 'Is Final' to be checked
                //litNoScalesSelected.Visible = false;
                //if (chkbx.Checked && (
                //    dropdownImportance.SelectedIndex < 1 || 
                //    dropdownNeedAtEntry.SelectedIndex < 1 || 
                //    dropdownDistinguishingValue.SelectedIndex < 1))
                //{
                //    litNoScalesSelected.Visible = true;
                //    chkbx.Checked = false;
                //    return;
                //}


                TextBox txtDutyNumber = editedItem.FindControl("txtDutyNumber") as TextBox;

                JobAnalysisDutyKSAFactor currentKSAFactor = new JobAnalysisDutyKSAFactor();

                CheckBox checkboxIsFinalKSA1 = editedItem.FindControl("checkboxIsFinalKSA1") as CheckBox;

                if (GetCheckedKSACount(true) <= 8 && currentKSAFactor != null)
                {

                    currentKSAFactor.JQFactorID = (long)editedItem.OwnerTableView.DataKeyValues[editedItem.ItemIndex]["JQFactorID"];
                    currentKSAFactor.JQID = base.CurrentJQID;
                    currentKSAFactor.JADutyID = (long)editedItem.OwnerTableView.DataKeyValues[editedItem.ItemIndex]["JADutyID"];
                    currentKSAFactor.ImportanceID = (enumImportanceScale)ControlUtility.GetDropdownValue(dropdownImportance);
                    currentKSAFactor.NeedAtEntryID = (enumNeedAtEntryScale)ControlUtility.GetDropdownValue(dropdownNeedAtEntry);
                    currentKSAFactor.DistinguishingValueScaleID = (enumDistinguishingValueScale)ControlUtility.GetDropdownValue(dropdownDistinguishingValue);
                    currentKSAFactor.IsFinalKSA = checkboxIsFinalKSA1.Checked;
                    currentKSAFactor.UpdatedByID = base.CurrentUserID;
                    currentKSAFactor.UpdateScaleAndFinalInformation();

                    txtDutyNumber.Text = txtDutyNumber.Text;

                    //Add to the tooltip manager 
                    this.RadToolTipManager1.TargetControls.Add(txtDutyNumber.ClientID, txtDutyNumber.Text.Substring(txtDutyNumber.Text.Length - 1) + "|" + currentKSAFactor.JADutyID.ToString(), true);

                    bindData();

                }
                else
                {
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
                    chkbx.Checked = false;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        protected void customValOneFinalKSA_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int totalfinalcount = GetCheckedKSACount(false);
            string errorMessage = "Using the 'Is Final' checkbox, please set at least one KSA or Quality Ranking Factor to Final.";
            if (totalfinalcount == 0)
            {
                args.IsValid = false;
                customValOneFinalKSA.ErrorMessage = errorMessage;

            }
           
        }
        protected void customValMaxFinalKSA_ServerValidate(object source, ServerValidateEventArgs args)
        {//Include SF to count in final count
            int totalfinalcount = GetCheckedKSACount(true);
            string errorMessage = "Maximum of 8 Final KSAs are allowed.";
            if (totalfinalcount >8)
            {
                args.IsValid = false;
                customValMaxFinalKSA.ErrorMessage = errorMessage;

            }

        }
        private int GetCheckedKSACount(bool blnCountIncludeSF)
        {
            int count = 0;

            foreach (GridEditableItem row in gridDutyKSA.Items)
            {
                CheckBox chkBx = (CheckBox)row.FindControl("checkboxIsFinalKSA1");
                int qualtypeid = int.Parse (row["QualificationTypeID"].Text);
                if (chkBx != null && chkBx.Checked)
                {
                    
                   
                    if (blnCountIncludeSF) //For final count sf should be included
                    {
                        count = count + 1;
                    }
                    else // for giving validation message -- SF should not be included in count
                    {
                        if (qualtypeid == (int)enumQualificationType.KSA || qualtypeid == (int)enumQualificationType.KSAQualityRankingFactor)
                        {
                            count = count + 1;
                        }
                    }
                }
            }

            return count;

        }

        private void gridDutyKSA_CancelCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                bindData();

            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void gridDutyKSA_EditCommand(object sender, GridCommandEventArgs e)
        {
            try
            {

                bindData();

            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void gridDutyKSA_SortCommand(object sender, GridSortCommandEventArgs e)
        {
            gridDutyKSA.SortingSettings.SortedBackColor = System.Drawing.Color.Azure;
            bindData();

        }

        #endregion

        protected void btnContinue_Click(object sender, EventArgs e)
        {
            bool navigate=true;

            //invoke validation only in non view mode
            if (CurrentNavMode != enumNavigationMode.View)
            {
                if (!Page.IsValid)
                {
                    navigate = false;
                }

               
            }

            if (navigate)
            {
                enumJNPWorkflowStatus currentws = base.CurrentJNPWS;
                if ((currentws == enumJNPWorkflowStatus.Draft) &&
                    (CurrentUser.RoleID == (int)enumRole.PDDeveloper ||
                     CurrentUser.RoleID == (int)enumRole.Supervisor))
                {
                    GoToLink("~/JQ/JQKSA.aspx", base.CurrentNavMode);
                }
                else
                {
                    GoToLink("~/JQ/Qualifications.aspx", base.CurrentNavMode);
                }
            }
        }

        protected void OnAjaxUpdate(object sender, ToolTipUpdateEventArgs args)
        {
            this.UpdateToolTip(args.Value, args.UpdatePanel);
        }

        private void UpdateToolTip(string elementID, UpdatePanel panel)
        {

            Control ctrl = Page.LoadControl("~/Controls/JA/ctrlDutyDescription.ascx");
            panel.ContentTemplateContainer.Controls.Add(ctrl);
            long dutyNumber = Convert.ToInt64(elementID.Split('|')[0]);
            long jaDutyId = Convert.ToInt64(elementID.Split('|')[1]);
            ctrlDutyDescription details = (ctrlDutyDescription)ctrl;
            details.LoadData(jaDutyId, dutyNumber);

        }





    }
}
