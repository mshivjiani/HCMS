using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;

using Telerik.Web.UI;
using Telerik.Web.UI.Editor.Diff;

using HCMS.Business.PD;
using HCMS.Business.LogObjects;
using HCMS.Business.Lookups;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.ConfigClasses;
using HCMS.Business.Duty;
using HCMS.PDExpress.Controls.Search;



namespace HCMS.PDExpress.Controls.CreatePD.Duties
{
    public partial class EditDuty : CreatePDUserControlBase
    {
        #region [Private Properties]

        private GridEditFormItem _editForm;

        private bool isSOD
        {
            get { return base.CurrentPDChoice == PDChoiceType.StatementOfDifferencePD; }
        }

        private int DutyCompetencyKSAID
        {
            get
            {
                if (ViewState["DutyCompetencyKSAID"] == null)
                {
                    string DutyCompetencyKSAIDParam = Request.QueryString["DutyCompetencyKSAID"];

                    if (String.IsNullOrEmpty(DutyCompetencyKSAIDParam))
                        ViewState["DutyCompetencyKSAID"] = -1;
                    else
                        ViewState["DutyCompetencyKSAID"] = int.Parse(DutyCompetencyKSAIDParam);
                }
                return (int)ViewState["DutyCompetencyKSAID"];

            }
            set
            {
                ViewState["DutyCompetencyKSAID"] = value;
            }
        }

        private bool IsInView
        {
            get
            {
                if (ViewState["IsInView"] == null)
                {
                    ViewState["IsInView"] = false;
                }
                return (bool)ViewState["IsInView"];
            }
            set
            {
                ViewState["IsInView"] = value;
            }
        }

        private int DutyID
        {
            get
            {

                return CurrentPDDutyID;

            }
            set
            {
                CurrentPDDutyID = value;
            }
        }

        #endregion


        #region [Page Events]

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            //this.btnContinue.Click += new EventHandler(btnContinue_Click);
            this.RGDutyQual.ItemCreated += new GridItemEventHandler(RGDutyQual_ItemCreated);
        }

       

        #region [searchKSA Events]

        private void searchKSA_KSASearchCancelCompleted(object sender, EventArgs e)
        {
            GridEditFormItem editform = _editForm;
            var radcomboKSA = editform.FindControl("radcomboKSA") as RadComboBox;
            ctrlSearchKSA searchKSA = editform.FindControl("SearchKSA") as ctrlSearchKSA;
            Label lblSearchmsg = editform.FindControl("lblSearchmsg") as Label;

            BindKSACombo(radcomboKSA);

           
        }

        private void searchKSA_KSASearchCompleted(object sender, EventArgs e)
        {
           // GridEditFormItem editform = RGDutyQual.MasterTableView.GetItems(GridItemType.EditFormItem)[0] as GridEditFormItem;
            GridEditFormItem editform = _editForm;
            var radcomboKSA = editform.FindControl("radcomboKSA") as RadComboBox;
            ctrlSearchKSA searchKSA = editform.FindControl("SearchKSA") as ctrlSearchKSA;
            Label lblSearchmsg = editform.FindControl("lblSearchmsg") as Label ;           
                    
            BindKSACombo (radcomboKSA);
             var keywordSearch = "";
            if (searchKSA.KeywordSearched.Length > 0) keywordSearch = ". Searched on keyword: " + searchKSA.KeywordSearched;

            if (searchKSA.ShowAllGradesChecked)
                lblSearchmsg.Text = string.Format("Search KSA in Series:{0}" + keywordSearch, searchKSA.SeriesID.ToString());
            else
                lblSearchmsg.Text = string.Format("Search KSA in Series:{0} - Grade:{1}" + keywordSearch, searchKSA.SeriesID.ToString(), searchKSA.CurrentGrade.ToString());
        }

        private void searchKSA_KSASearchClearCompleted(object sender, EventArgs e)
        {
            //GridEditFormItem editform = RGDutyQual.MasterTableView.GetItems(GridItemType.EditFormItem)[0] as GridEditFormItem;
            GridEditFormItem editform = _editForm;
            var radcomboKSA = editform.FindControl("radcomboKSA") as RadComboBox;
            ctrlSearchKSA searchKSA = editform.FindControl("SearchKSA") as ctrlSearchKSA;
            Label lblSearchmsg = editform.FindControl("lblSearchmsg") as Label;           

            BindKSACombo(radcomboKSA);
            lblSearchmsg.Text = string.Empty;
        }

        protected void radcomboKSA_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {

            GridEditFormItem editform = _editForm;          
            var radEditorQualDescription = editform.FindControl("radEditorQualDescription") as RadEditor;
            radEditorQualDescription.Content  = e.Text;
        }

        protected void radEditorQualDescription_PreRender(object sender, EventArgs e)
        {
            RadEditor edit = (RadEditor)sender;
            edit.Content = edit.Text.Replace("\n", "<br>");
        }

        protected void lblQualificationDescription_PreRender(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            lbl.Text = lbl.Text.Replace("\n", "<br>");
        }

        protected void RadEditDutyDescription_PreRender(object sender, EventArgs e)
        {
            RadEditor edit = (RadEditor)sender;
            edit.Content = edit.Text.Replace("\n", "<br>");
        }
       
        #endregion

       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                if (CurrentMode == eMode.Insert)
                {
                    rcbPercentageOfTime.SelectedValue = "0";
                    pnlDutyQual.Visible = false;
                    base.Page.Title = "Add Duty";

                }
                else if (CurrentMode == eMode.Edit)
                {
                    BindData();
                    //issue 1314 -disabling the percentageoftime selection when dutytype is "other"
                    if (rcbDutyType.SelectedValue == "2")
                    { 
                        rcbPercentageOfTime.Enabled = false;
                        pnlDutyQual.Visible = false;
                    }
                    
                    base.Page.Title = "Edit Duty";

                }
                else if (CurrentMode == eMode.View)
                {
                    BindData();
                    DisableControls();
                    //JA issue 890 -- changing the title to say "Duties"
                    base.Page.Title = "Duties";
                }
            }
            
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            
            base.GoToLink("~/CreatePD/Duties.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
             
            base.GoToLink("~/CreatePD/AddEditDuty.aspx");
        }
        
        #endregion

        #region [Duty Related]

        private void BindData()
        {
           PositionDuty  positionDuty = new PositionDuty(DutyID);
           RadEditDutyDescription.Content = positionDuty.DutyDescription.Replace ("\n","<br />");
            
           rcbDutyType.SelectedValue = positionDuty.DutyTypeID.ToString ();
           rcbPercentageOfTime.SelectedValue = positionDuty.PercentageOfTime.ToString ();
         

        }

        private void DisableControls()
        {
            btnSave.Enabled = false;
            RGDutyQual.Columns[0].Visible = false; //add/edit
            RGDutyQual.Columns[1].Display = false; //delete

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            PositionDuty positionDuty;
            try
            {
                if (CurrentMode == eMode.Insert)
                {
                    positionDuty = new PositionDuty();
                    AssignValues(positionDuty);
                    positionDuty.Add();
                    lblmsg.Text = "Duty added successfully.";
                    DutyID = positionDuty.DutyID;
                    CurrentMode = eMode.Edit;
                    base.Page.Title = "Edit Duty";
                }
                else if (CurrentMode == eMode.Edit)
                {
                    positionDuty = new PositionDuty(DutyID); 
                    bool ischanged = false;
                    ConfigMessagesSection cfms = ConfigMessagesSection.PDXMessagesSection;  
                    if (base.CurrentPD.CopyFromPDID != NULLPDID)
                    {                       
                        ischanged=IsDutyChanged();
                    }
                    AssignValues(positionDuty);                              
                    positionDuty.Update();
                    if (ischanged && (rcbDutyType.SelectedValue != "2"))
                    {
                       lblmsg.Text = string.Format("{0} {1}",cfms.PDXMessages["5"].Text,"Duty updated successfully");
                    }
                    else
                    {
                        lblmsg.Text = "Duty updated successfully.";
                    }
                }

                if (DutyID > 0)
                {
                    if (rcbDutyType.SelectedValue == "2")
                    {
                        pnlDutyQual.Visible = false;
                    }
                    else
                    {
                        pnlDutyQual.Visible = true;
                    }
                }
                RGDutyQual.Rebind();
               
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
           
    
        }

        private void AssignValues(PositionDuty positionDuty)
        {
            positionDuty.PositionDescriptionID = base.CurrentPD.PositionDescriptionID;
            positionDuty.DutyTypeID = int.Parse(rcbDutyType.SelectedValue);
            positionDuty.PercentageOfTime = int.Parse(rcbPercentageOfTime.SelectedValue);
            //saving radeditor's text because if user formats the text,it will insert
            //html tags with content. Don't want to save html tags in the database 
            string dutydesc = RadEditDutyDescription.Text;

            positionDuty.DutyDescription = dutydesc;
            positionDuty.UpdateDate = DateTime.Now;
            positionDuty.UpdatedByID = base.CurrentUser.UserID;
            if (CurrentMode == eMode.Insert)
            {
                positionDuty.CreateDate = DateTime.Now;
                positionDuty.CreatedByID = base.CurrentUser.UserID;
            }

        }

        #endregion

        #region [Duty Qualifications Related]
        protected void dutyOption_Std_CheckedChanged(object sender, EventArgs e)
        {
            var cb = (CheckBox)sender;
            var trKSACombo = (HtmlTableRow)cb.Parent.FindControl("trKSACombo");
            trKSACombo.Visible = cb.Checked;
    

        }

        protected void dutyOption_Copy_CheckedChanged(object sender, EventArgs e)
        {
            var cb = (CheckBox)sender;
            var trKSACombo = (HtmlTableRow)cb.Parent.FindControl("trKSACombo");
            var radcomboKSA = (RadComboBox)cb.Parent.FindControl("radcomboKSA");
            radcomboKSA.Items[1].Selected = true;
            trKSACombo.Visible = !cb.Checked;
        }

        private void BindKSACombo(RadComboBox radcomboKSA)
        {
            GridEditFormItem editform = _editForm;
            ctrlSearchKSA searchKSA = editform.FindControl("SearchKSA") as ctrlSearchKSA;
            radcomboKSA.Items.Clear();
            searchKSA.SeriesID = CurrentPD.JobSeries;
            searchKSA.CurrentGrade = CurrentPD.ProposedFPGrade;
            searchKSA.KSAComboBox = radcomboKSA;
            searchKSA.RunSearchFillKSAList();
        }
        private void SetEditForm(object sender, GridItemEventArgs e)
        {
            GridItem gridItem = e.Item as GridItem;
            GridEditFormItem editform = (GridEditFormItem)e.Item;

            if ((e.Item is GridEditFormItem) && (e.Item.IsInEditMode))
            {

                
                RadComboBox  radcomboKSA = editform.FindControl("radcomboKSA") as RadComboBox;     
                Button  btnUpdate = editform.FindControl("btnUpdate") as Button;
                HtmlTableRow  trKSACopyFromDutyInst = editform.FindControl("trKSACopyFromDutyInst") as HtmlTableRow;
                HtmlTableRow trKSADutyOption = editform.FindControl("trKSADutyOption") as HtmlTableRow;
                HtmlTableRow trKSACombo = editform.FindControl("trKSACombo") as HtmlTableRow;
                RadEditor radEditorQualDescription = editform.FindControl("radEditorQualDescription") as RadEditor;
                RadComboBox radComboDutyQualID = editform.FindControl("radComboDutyQualID") as RadComboBox;
                RadComboBox radcomboQualificationTypeID = editform.FindControl("radcomboQualificationTypeID") as RadComboBox;

                //Issue 1484 - Make "KSA" default instead of "KSA-Quality Ranking Factor"
                if (radcomboQualificationTypeID != null) radcomboQualificationTypeID.SelectedValue = "3";

                if (gridItem.DataItem is DutyCompetencyKSA)
                {
                    // edit existing row
                    var dutyQual = gridItem.DataItem as DutyCompetencyKSA;
                    radComboDutyQualID.SelectedValue = dutyQual.QualificationID.ToString();
                    radEditorQualDescription.Content = (dutyQual.CompetencyKSA.Length > 0 ? dutyQual.CompetencyKSA.Replace("\n", "<br/>") : string.Empty);
                    radcomboQualificationTypeID.SelectedValue = dutyQual.QualificationTypeID.ToString();

                    long ksaid = 0;
                    if (dutyQual.KSAID != null)
                    {
                        ksaid = long.Parse(dutyQual.KSAID.ToString());
                    }
                    
                    //This is added as Pam wanted to have current KSA ID selected in dropdown.
                    //This check about KSA exist or not, is needed because user might have selected KSA by expanding the search.
                    //By default ksa dropdown is populated with list of KSAs for current series and grade
                    //Therefore selected KSA may not always exist in the default list of KSA
                    //if it exists in the default list then select  it - otherwise look for that particular KSA in KSA lookup 
                    //and make that as selected value by adding it at index 0


                    //JA issue id 893: PDX Duty KSA: When editing a duty KSA, user should be able to see all the list of KSAs that they were originally presented with 
                    //binding KSA combo with default list for current series and grade
                    BindKSACombo(radcomboKSA);
                    if (radcomboKSA.FindItemByValue(dutyQual.KSAID.ToString()) != null)
                    {
                        radcomboKSA.SelectedValue = dutyQual.KSAID.ToString();
                    }
                    else
                    {
                        KSA currentksa =new KSA (ksaid);
                        radcomboKSA.Items.Insert(0, new RadComboBoxItem(currentksa.KSAText, dutyQual.KSAID.ToString ()));
                    }

                }

                if (e.Item is GridEditFormInsertItem)
                {

                    BindKSACombo(radcomboKSA);
                    btnUpdate.CommandName = RadGrid.PerformInsertCommandName;
                    btnUpdate.Text = "Add KSA";
                    RGDutyQual.ShowFooter = false;
                }
                else
                {


                    btnUpdate.CommandName = RadGrid.UpdateCommandName;
                    btnUpdate.Text = "Save KSA";

                    if (IsInView)
                    {
                        radComboDutyQualID.Enabled = false;
                        radcomboQualificationTypeID.Enabled = false;
                        btnUpdate.Enabled = false;

                    }
                    RGDutyQual.ShowFooter = true;
                }
            }

        }
        protected void RGDutyQual_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            if (DutyID > 0)
            {
                PositionDuty positionDuty = new PositionDuty(DutyID);
                List<DutyCompetencyKSA> qualList = positionDuty.GetDutyCompetencyKSA();
                RGDutyQual.DataSource = qualList;
            }

        }
        protected void RGDutyQual_ItemCreated(object sender, GridItemEventArgs e)
        {
            // The Duty Qualification RadGrid is being created. If we are in EditMode, then find 
            //  and create pointers to all of the individual edit controls in the editform template
            if (e.Item is GridEditFormItem && e.Item.IsInEditMode)
            {
                GridEditFormItem editform = (GridEditFormItem)e.Item;
                _editForm = editform;
                ctrlSearchKSA searchKSA = editform.FindControl("SearchKSA") as ctrlSearchKSA;
                RadComboBox radcomboKSA = (RadComboBox)editform.FindControl("radcomboKSA");
                searchKSA.KSAComboBox = radcomboKSA;
                searchKSA.RunSearchFillKSAList();
                searchKSA.KSASearchCompleted += new ctrlSearchKSA.KSASearchCompletedHandler(searchKSA_KSASearchCompleted);
                searchKSA.KSASearchCancelCompleted += new ctrlSearchKSA.KSASearchCancelCompleteHandler(searchKSA_KSASearchCancelCompleted);
                searchKSA.KSASearchClearCompleted += new ctrlSearchKSA.KSASearchClearCompleteHandler(searchKSA_KSASearchClearCompleted);
                radcomboKSA.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(radcomboKSA_SelectedIndexChanged);


            }
        }
        protected void RGDutyQual_ItemCommand(object source, GridCommandEventArgs e)
        {
            //string script = string.Empty;
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
        protected void RGDutyQual_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if ((e.Item is GridEditFormItem) && (e.Item.IsInEditMode))
            {
                SetEditForm(sender, e);
            }

           GridItem gridItem = e.Item;


           //hide the refresh button Telerik.Web.UI.GridLinkButton
           if (gridItem is GridCommandItem)
           {
               gridItem.FindControl("RebindGridButton").Visible = false;
               gridItem.FindControl("InitInsertButton").Visible = (CurrentMode != eMode.View);
           }

        }
        protected void RGDutyQual_ItemInserted(object source, GridInsertedEventArgs e)
        {
            if (e.Exception != null)
            {
                e.ExceptionHandled = true;
                e.KeepInInsertMode = true;
                DisplayMessage(true, "Duty qualification cannot be inserted. Reason: " + e.Exception.Message);
            }
            else
            {
                DisplayMessage(false, "Duty qualification inserted");
            }

        }
        protected void RGDutyQual_ItemUpdated(object source, GridUpdatedEventArgs e)
        {
            if (e.Exception != null)
            {
                e.KeepInEditMode = true;
                e.ExceptionHandled = true;
                DisplayMessage(true, "Duty Qual " + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["DutyCompetencyKSAID"] + " cannot be updated. Reason: " + e.Exception.Message);
            }
            else
            {
                DisplayMessage(false, "Duty Qual " + e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["DutyCompetencyKSAID"] + " updated");
            }

        }
        protected void RGDutyQual_PreRender(object sender, EventArgs e)
        {
            // making all other items invisible except edit form when adding new or editing
            GridItem[] gridcommanditems = RGDutyQual.MasterTableView.GetItems(GridItemType.CommandItem);

            //if (!_closeButtonClicked && (RGDutyQual.MasterTableView.IsItemInserted) || (RGDutyQual.EditItems.Count > 0))
            if (RGDutyQual.MasterTableView.IsItemInserted || RGDutyQual.EditItems.Count > 0)
            {
                foreach (GridItem item in RGDutyQual.Items)
                {
                    item.Visible = false;
                }

                //hiding all command items
                foreach (GridItem item in gridcommanditems)
                {
                    item.Visible = false;
                }
                //hiding headers
                RGDutyQual.MasterTableView.ShowHeader = false;
                RGDutyQual.MasterTableView.ShowFooter = false;
                RGDutyQual.ShowFooter = false;
                //this.btnCancel.Visible = false;
            }
            else
            {
                foreach (GridItem item in gridcommanditems)
                {
                    item.Visible = true;
                    //item.FindControl("RebindGridButton").Visible = false;
                }
                foreach (GridItem item in RGDutyQual.Items)
                {
                    item.Visible = true;
                }
                RGDutyQual.MasterTableView.ShowHeader = true;
                RGDutyQual.MasterTableView.ShowFooter = true;
                RGDutyQual.ShowFooter = true;
                //this.btnCancel.Visible = true;
            }

            if (RGDutyQual.EditIndexes.Count > 0)
            {
                if (isSOD || base.IsPDReadOnly)
                {
                    RGDutyQual.MasterTableView.GetColumn("DeleteCommandColumn").Visible = false;

                }
              
            }
        }
        protected void lblCopyDuty_PreRender(object sender, EventArgs e)
        {
            if (CurrentMode == eMode.View)
            {
                Label lblCopyDuty = (Label)sender;
                lblCopyDuty.Visible = false;
            }

        }
        private void AssignDutyCompetencyValues(DutyCompetencyKSA dutyCompetency, GridCommandEventArgs e)
        {
            GridEditFormItem editform = (GridEditFormItem)e.Item;

            RadComboBox radcomboKSA = (RadComboBox)editform.FindControl("radcomboKSA");
            RadEditor radEditorQualDescription = editform.FindControl("radEditorQualDescription") as RadEditor;
            RadComboBox radComboDutyQualID = (RadComboBox)editform.FindControl("radComboDutyQualID");
            RadComboBox radcomboQualificationTypeID = (RadComboBox)editform.FindControl("radcomboQualificationTypeID");
            if (e.CommandName == RadGrid.PerformInsertCommandName)
            {
                dutyCompetency.DutyID = DutyID;
                dutyCompetency.CreatedByID = base.CurrentUser.UserID;
                dutyCompetency.CreateDate = DateTime.Now;
            }
            //radeditor inserts extra '\r' and '\n' along with <br />
            //therefore replacing <br /> to '' to save it to db so that it does not create extra new line
            //saving radeditor's text because if user formats the text,it will insert
            //html tags with content. Don't want to save html tags in the database 
            dutyCompetency.CompetencyKSA = radEditorQualDescription.Text;
            dutyCompetency.QualificationTypeID = Convert.ToInt32(radcomboQualificationTypeID.SelectedValue);
            dutyCompetency.QualificationID = Convert.ToInt32(radComboDutyQualID.SelectedValue);
            dutyCompetency.UpdatedByID = base.CurrentUser.UserID;
            dutyCompetency.UpdateDate = DateTime.Now;
            if ((radcomboKSA != null) && ((radcomboKSA.SelectedValue.Length) > 0))
            {
                long ksaid = long.Parse(radcomboKSA.SelectedValue);
                if (ksaid > 0)
                {
                    dutyCompetency.KSAID = ksaid;
                }
                else
                {
                    dutyCompetency.KSAID = 0;
                }
            }
            else
            {
                dutyCompetency.KSAID = 0;
            }
        }
        private void AddDutyQualification(object source, GridCommandEventArgs e)
        {
     
            DateTime createDate = DateTime.Now;

            DutyCompetencyKSA dutyCompetency = new DutyCompetencyKSA();
            AssignDutyCompetencyValues(dutyCompetency, e);
            dutyCompetency.Add();
            DutyCompetencyKSAID = dutyCompetency.DutyCompetencyKSAID;
           
        }
        private void UpdateDutyQualification(object source, GridCommandEventArgs e)
        {
            if (source is RadGrid)
            {
                RadGrid grid = source as RadGrid;

                GridEditFormItem gridItem = e.Item as GridEditFormItem;

                int dutyCompetencyKSAID = int.Parse(gridItem.GetDataKeyValue("DutyCompetencyKSAID").ToString());
                DutyCompetencyKSA dutyCompetency = new DutyCompetencyKSA(dutyCompetencyKSAID);
                AssignDutyCompetencyValues(dutyCompetency, e);
                dutyCompetency.Update();

              
            }
        }
        private void DeleteDutyQualification(object source, GridCommandEventArgs e)
        {
            if (source is RadGrid)
            {
                GridDataItem gridItem = e.Item as GridDataItem;

                int dutyCompetencyKSAID = int.Parse(gridItem.GetDataKeyValue("DutyCompetencyKSAID").ToString());
                DutyCompetencyKSA dutyCompetency = new DutyCompetencyKSA(dutyCompetencyKSAID);
                dutyCompetency.Delete();

                RGDutyQual.Rebind();
            }
        }
        private void DisplayMessage(bool isError, string text)
        {
            lblmsg.Text = text;
        }

        #endregion

        protected void btnRefresh_Click(object sender, EventArgs e)
        {          
                RGDutyQual.Rebind();           
        }

        public bool IsDutyChanged()
        {
            bool isChanged = false;                    
            PositionDuty positionDuty = new PositionDuty(DutyID);
            int percentageOfTime = int.Parse(rcbPercentageOfTime.SelectedValue);
            string dutyDescription = RadEditDutyDescription.Content;
            if (base.CurrentPD.CopyFromPDID != NULLPDID 
                && (positionDuty.PercentageOfTime != percentageOfTime || positionDuty.DutyDescription.Equals(dutyDescription, StringComparison.InvariantCultureIgnoreCase) == false))
            {           
                isChanged = true;
            }
            return isChanged ;
           
        }

    }
}
