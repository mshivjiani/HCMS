using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using HCMS.Business.Lookups;
using HCMS.Business.Lookups.Collections;
using HCMS.Business.PD;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;

namespace HCMS.PDExpress.Controls.CreatePD.Factors
{
    public partial class LadderProgressions : CreatePDUserControlBase
    {
        const string RADIOGROUPNAME = "LadderProgression";
        public event EventHandler SuccessfulSave;
        public bool VisibleProgression = false;
        #region Page Events

        protected void OnSuccessfulSave(EventArgs e)
        {
            if (SuccessfulSave != null)
                SuccessfulSave(this, e);
        }

        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            this.gridViewProgressions.RowDataBound += new GridViewRowEventHandler(gridViewProgressions_RowDataBound);
            this.gridViewProgressions.RowCreated += new GridViewRowEventHandler(gridViewProgressions_RowCreated);
            this.customValPDTypeSelected.ServerValidate += new ServerValidateEventHandler(customValPDTypeSelected_ServerValidate);
            this.customValGradeSelected.ServerValidate += new ServerValidateEventHandler(customValGradeSelected_ServerValidate);
            this.customValProposedGrade.ServerValidate += new ServerValidateEventHandler(customValProposedGrade_ServerValidate);
            this.customValGradeInSequence.ServerValidate += new ServerValidateEventHandler(customValGradeInSequence_ServerValidate);
            this.buttonCreateLadderSteps.Click += new EventHandler(buttonCreateLadderSteps_Click);
            base.OnInit(e);
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                    loadData();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void loadData()
        {
            bool showProgressions = (VisibleProgression) && (base.CurrentPDID != NULLPDID) &&
                (base.CurrentPDChoice == PDChoiceType.CareerLadderPD) && (base.CurrentPD.LadderPosition == -1);

            panelMain.Visible = showProgressions;
            if (showProgressions)
            {
                this.customValProposedGrade.ErrorMessage = string.Format("The maximum grade selected in the progression must be less than the proposed full performance grade of {0}.", base.CurrentPD.ProposedFPGrade);
                this.customValGradeInSequence.ErrorMessage = string.Format("Grades cannot be skipped within a Career Ladder.  Please ensure no grades have been skipped between the lowest grade and full performance grade of {0}.", base.CurrentPD.ProposedFPGrade);

                bindProgressions();
            }
        }

        #endregion

        #region GridView Events

        private void bindProgressions()
        {
            gridViewProgressions.DataSource = LookupWrapper.GetCareerLadderPDTypes(false);
            gridViewProgressions.DataBind();
        }

        private void gridViewProgressions_RowCreated(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                    {
                        HtmlGenericControl span = e.Row.FindControl("checkBoxContainer") as HtmlGenericControl;
                        span.Attributes.Add("name", "checkBoxContainer" + e.Row.RowIndex);

                        CheckBoxList checkboxListCareerProgressions = (CheckBoxList)e.Row.FindControl("checkboxListCareerProgressions");
                        Literal literalRadio = (Literal)e.Row.FindControl("literalRadio");

                        literalRadio.Text = string.Format("<input type=\"radio\" name=\"{0}\" id=\"RowSelector{1}\" value=\"{1}\" ", RADIOGROUPNAME, e.Row.RowIndex);

                        // See if we need to add the "checked" attribute to preserve state
                        if (getRadioSelectionValue() == e.Row.RowIndex)
                        {
                            literalRadio.Text += "checked=\"checked\" ";
                        }
                        //disabling the Step-1 interval choice if Proposed FPL is >10
                        if (CurrentPD.ProposedFPGrade > 10)
                        {
                            if (e.Row.RowIndex == 0)
                            {
                                e.Row.Enabled = false;
                            }
                            else
                            {
                                literalRadio.Text += "checked=\"checked\" ";
                            }
                        }
                        // add 'onClick' event handler
                        literalRadio.Text += String.Format(" onClick=\"progressionCheckboxClicked({0});\" ", e.Row.RowIndex);

                        // Add the closing tag
                        literalRadio.Text += " />";
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void gridViewProgressions_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                    {
                        CareerLadderPDType currentItem = (CareerLadderPDType)e.Row.DataItem;
                        CheckBoxList checkboxListCareerProgressions = (CheckBoxList)e.Row.FindControl("checkboxListCareerProgressions");
                        Literal literalTypeName = (Literal)e.Row.FindControl("literalTypeName");

                        literalTypeName.Text = currentItem.LadderTypeName;

                        CareerLadderPDTypeGradeCollection coll = LookupWrapper.GetCareerLadderPDTypeGrades(true, currentItem.CareerLadderPDTypeID);

                        foreach (CareerLadderPDTypeGrade grade in coll.Reverse<CareerLadderPDTypeGrade>())
                        {
                            if (grade.Grade >= base.CurrentPD.ProposedFPGrade)
                            {
                                coll.Remove(grade);
                            }
                        }

                        ControlUtility.BindListControl(checkboxListCareerProgressions, coll, null, "Grade", "Grade");
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion

        #region Progression Type/Grade Validation

        private int getRadioSelectionValue()
        {
            return string.IsNullOrEmpty(Request.Form[RADIOGROUPNAME]) ? -1 : Convert.ToInt32(Request.Form[RADIOGROUPNAME]);
        }
        private bool isSelectionInSequence()
        {
            bool isInSequence = true;
            int rowSelected = getRadioSelectionValue();
            ArrayList selgradelist = getSelectedGrades(rowSelected);
            selgradelist.Sort();
            int totalselected = selgradelist.Count;
            int gradeMax = base.CurrentPD.ProposedFPGrade;

            if (rowSelected != -1)
            {
                if (totalselected > 0)
                {
                    int highestselected = (int)selgradelist[totalselected - 1];
                    if (totalselected > 1) //if more than one grade selected
                    {
                        GridViewRow itemRow = gridViewProgressions.Rows[rowSelected];

                        if (itemRow.RowType == DataControlRowType.DataRow)
                        {
                            if (itemRow.RowState == DataControlRowState.Normal || itemRow.RowState == DataControlRowState.Alternate)
                            {
                                CheckBoxList checkboxListCareerProgressions = (CheckBoxList)itemRow.FindControl("checkboxListCareerProgressions");
                                if (checkboxListCareerProgressions.SelectedIndex != -1)
                                {

                                    for (int i = 0; i < checkboxListCareerProgressions.Items.Count - 1; i++)
                                    {
                                        ListItem currentcb = (ListItem)checkboxListCareerProgressions.Items[i];

                                        ListItem nextcb = (ListItem)checkboxListCareerProgressions.Items[i + 1];
                                        if ((currentcb.Selected) && (!nextcb.Selected))
                                        {
                                            isInSequence = false;
                                            break;
                                        }



                                    }

                                }
                            }
                        }
                    } //total grade selected >1

                    if (rowSelected == 0) // 1-grade interval
                    {
                        if (highestselected != (gradeMax - 1))
                        {
                            isInSequence = false;
                        }
                    }
                    else // career progression 
                    {
                        if (gradeMax > 11) //above grade 11 it becomes 1 step interval
                        {
                            if (highestselected != (gradeMax - 1))
                            {
                                isInSequence = false;
                            }
                        }
                        else // at or below grade 11 it  is 2 step interval
                        {
                            if (highestselected != (gradeMax - 2))
                            {
                                isInSequence = false;
                            }
                        }
                    }

                } // total grade selected >0

                else //total grade selected =0
                {
                    isInSequence = false;
                }
            }//career ladder pd type selected

            else //no career ladder pd type selected
            {
                isInSequence = false;
            }

            return isInSequence;

        }
        private bool isAtLeastOneCheckboxSelected()
        {
            bool isChecked = false;
            int rowSelected = getRadioSelectionValue();

            if (rowSelected != -1)
            {
                GridViewRow itemRow = gridViewProgressions.Rows[rowSelected];

                if (itemRow.RowType == DataControlRowType.DataRow)
                {
                    if (itemRow.RowState == DataControlRowState.Normal || itemRow.RowState == DataControlRowState.Alternate)
                    {
                        CheckBoxList checkboxListCareerProgressions = (CheckBoxList)itemRow.FindControl("checkboxListCareerProgressions");
                        isChecked = (checkboxListCareerProgressions.SelectedIndex != -1);
                    }
                }
            }

            return isChecked;
        }

        private ArrayList getSelectedGrades(int rowSelected)
        {
            ArrayList finalList = new ArrayList();

            if (rowSelected != -1)
            {
                GridViewRow itemRow = gridViewProgressions.Rows[rowSelected];

                if (itemRow.RowType == DataControlRowType.DataRow)
                {
                    if (itemRow.RowState == DataControlRowState.Normal || itemRow.RowState == DataControlRowState.Alternate)
                    {
                        CheckBoxList checkboxListCareerProgressions = (CheckBoxList)itemRow.FindControl("checkboxListCareerProgressions");
                        foreach (ListItem item in checkboxListCareerProgressions.Items)
                        {
                            if (item.Selected)
                                finalList.Add(int.Parse(item.Value));
                        }
                    }
                }
            }

            return finalList;
        }

        private void customValPDTypeSelected_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            try
            {
                e.IsValid = getRadioSelectionValue() != -1;
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void customValGradeSelected_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            try
            {
                int rowSelected = getRadioSelectionValue();
                e.IsValid = (rowSelected == -1) || isAtLeastOneCheckboxSelected();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void customValProposedGrade_ServerValidate(object sender, ServerValidateEventArgs e)
        {
            try
            {
                bool isValid = false;
                int rowSelected = getRadioSelectionValue();
                int gradeMax = base.CurrentPD.ProposedFPGrade;

                if (rowSelected != -1 && isAtLeastOneCheckboxSelected())
                {
                    int checkCount = 0;
                    ArrayList items = getSelectedGrades(rowSelected);
                    foreach (int gradeItem in items)
                    {
                        if (gradeItem >= gradeMax)
                            break;

                        checkCount++;
                    }

                    // return true if checkcount is equal to item count
                    isValid = items.Count.Equals(checkCount);
                }

                e.IsValid = isValid;
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void customValGradeInSequence_ServerValidate(object source, ServerValidateEventArgs e)
        {
            try
            {
                int rowSelected = getRadioSelectionValue();
                e.IsValid = (rowSelected == -1) || isSelectionInSequence();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        #endregion

        #region Button Event

        private void clearSelection()
        {
            int rowSelected = getRadioSelectionValue();

            if (rowSelected != -1)
            {
                for (int cnt = 0; cnt < gridViewProgressions.Rows.Count; cnt++)
                {
                    if (cnt != rowSelected)
                    {
                        GridViewRow itemRow = gridViewProgressions.Rows[cnt];

                        if (itemRow.RowType == DataControlRowType.DataRow)
                        {
                            if (itemRow.RowState == DataControlRowState.Normal || itemRow.RowState == DataControlRowState.Alternate)
                                ((CheckBoxList)itemRow.FindControl("checkboxListCareerProgressions")).ClearSelection();
                        }
                    }
                }
            }
        }

        private void buttonCreateLadderSteps_Click(object sender, EventArgs e)
        {
            try
            {
                clearSelection();

                if (Page.IsValid)
                {
                    int rowSelected = this.getRadioSelectionValue();
                    ArrayList gradeList = getSelectedGrades(rowSelected);
                    //reversing the order so that ladders will be generated in correct order
                    //e.g FPL :13 -120920, CLSOD:12 -120921 , FullPD:11 -120922
                    gradeList.Reverse();
                    PositionDescription thisPD = new PositionDescription();

                    thisPD.PositionDescriptionID = base.CurrentPDID;
                    thisPD.UpdatedByID = base.CurrentUser.UserID;
                    thisPD.CareerLadderPDTypeID = rowSelected + 1;

                    thisPD.CreateLadderPositionDescriptions(gradeList);

                    // raise the SuccessfulSave event
                    OnSuccessfulSave(e);

                    // hide this control
                    panelInnerMain.Visible = false;
                    panelComplete.Visible = true;

                    // disable validators
                    this.customValGradeSelected.Enabled = false;
                    this.customValPDTypeSelected.Enabled = false;
                    this.customValProposedGrade.Enabled = false;
                    this.customValGradeInSequence.Enabled = false;
                }
                updatePanelMain.Update();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion

        #region public methods
        public void ReloadControl()
        {
            loadData();
        }
        #endregion

    }
}
