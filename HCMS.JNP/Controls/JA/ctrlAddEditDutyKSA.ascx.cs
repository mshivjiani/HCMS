using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.Business.JA;
using HCMS.Business.Lookups;

using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Utilities;
namespace HCMS.JNP.Controls.JA
{
    public partial class ctrlAddEditDutyKSA : JNPUserControlBase
    {
        #region Private Properties

        private eMode CurrentMode
        {
            get
            {
                if (ViewState["CurrentMode"] == null)
                {
                    string currentMode = Request.QueryString["Mode"];
                    if (string.IsNullOrEmpty(currentMode) || currentMode.Equals("View"))
                    {
                        ViewState["CurrentMode"] = eMode.View;
                    }
                    else
                    {
                        if (currentMode.Equals("Insert"))
                        {
                            ViewState["CurrentMode"] = eMode.Insert;
                        }
                        else
                        {
                            ViewState["CurrentMode"] = eMode.Edit;
                        }

                    }
                }
                return (eMode)ViewState["CurrentMode"];
            }
            set { ViewState["CurrentMode"] = value; }
        }

        private long JADutyID
        {
            get
            {
                if (ViewState["JADutyID"] == null)
                {
                    string JADutyIDParam = Request.QueryString["JADutyID"];

                    if (String.IsNullOrEmpty(JADutyIDParam))
                        ViewState["JADutyID"] = -1;
                    else
                        ViewState["JADutyID"] = long.Parse(JADutyIDParam);
                }
                return (long)ViewState["JADutyID"];

            }
            set
            {
                ViewState["JADutyID"] = value;
            }
        }

        private long JQFactorID
        {
            get
            {
                if (ViewState["JQFactorID"] == null)
                {
                    string JQFactorIDParam = Request.QueryString["JQFactorID"];

                    if (String.IsNullOrEmpty(JQFactorIDParam))
                        ViewState["JQFactorID"] = 0;
                    else
                        ViewState["JQFactorID"] = long.Parse(JQFactorIDParam);
                }
                return (long)ViewState["JQFactorID"];

            }
            set
            {
                ViewState["JQFactorID"] = value;
            }
        }

        private List<KSA> KSAList
        {
            get
            {
                List<KSA> ksalist = new List<KSA>();
                int seriesid = -1;
                int grade = -1;
                string cacheKey = string.Empty;
                if (base.CurrentJAID > 0)
                {
                    JobAnalysis currentJA = new JobAnalysis(base.CurrentJAID);
                    seriesid = currentJA.SeriesID;
                    grade = currentJA.HighestAdvertisedGrade;
                    cacheKey = string.Format("{0}-{1}", seriesid.ToString(), grade.ToString());
                    if (Cache[cacheKey] == null)
                    {
                        ksalist = Series.GetSeriesGradeKSA(seriesid, grade);
                        Cache.Insert(cacheKey, ksalist, null, DateTime.UtcNow.AddMinutes(5), System.Web.Caching.Cache.NoSlidingExpiration);
                    }
                    else
                    {
                        ksalist = (List<KSA>)Cache[cacheKey];
                    }

                }
                return ksalist;
            }
        }

        #endregion

        protected override void OnInit(EventArgs e)
        {
            this.SearchKSA.KSASearchCompleted += new Search.ctrlSearchKSA.KSASearchCompletedHandler(SearchKSA_KSASearchCompleted);
            this.SearchKSA.KSASearchCancelCompleted += new Search.ctrlSearchKSA.KSASearchCancelCompleteHandler(SearchKSA_KSASearchCancelCompleted);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                    BindData();
                    SetSearchControl();
                    SetPageView();
   
            }
        }

        #region Private Methods
        private void BindKSACombo()
        {
            var orderedList = KSAList.OrderBy(o => o.KSAText).ToList();
            this.radcomboKSA.DataSource = orderedList;
            this.radcomboKSA.DataBind();
            ControlUtility.BindRadComboBoxControl(radcomboKSA, orderedList, null, "KSAText", "KSAID", "<<--Select KSA First-->>");
            //Issue Id: 26
            //Author: Deepali Anuje
            //Date Fixed: 1/28/2012
            //Description:   Duty KSA Screen of JA 
            if (KSAList.Count < 2 && KSAList[0].KSAText == UserControlBase.OTHERKSATEXT)
            {
                radcomboKSA.SelectedValue = "0";
            }
        }
        private void BindData()
        {

                BindKSACombo();
                if ((CurrentMode == eMode.View) || (CurrentMode == eMode.Edit))
                {
                    JobAnalysisDutyKSA jaDutyKSA = new JobAnalysisDutyKSA(JQFactorID);
                    this.radEditorJAKSADescription.Content = jaDutyKSA.JAKSADescription;
                    this.radComboDutyQualID.SelectedValue = jaDutyKSA.QualificationID.ToString();
                    this.radcomboQualificationTypeID.SelectedValue = jaDutyKSA.QualificationTypeID.ToString();
                    this.radcomboKSA.SelectedValue = jaDutyKSA.KSAID.ToString();
                }
            
        }
        protected void SetPageView()
        {
            if ((CurrentMode == eMode.View) || (CurrentMode == eMode.None))
            {
                this.radcomboKSA.Enabled = false;
                this.radComboDutyQualID.Enabled = false;
                this.radcomboQualificationTypeID.Enabled = false;
                this.btnUpdate.Enabled = false;
            }
            else
            {
                this.radcomboKSA.Enabled = true ;
                this.radComboDutyQualID.Enabled = true;
                this.radcomboQualificationTypeID.Enabled = true;
                this.btnUpdate.Enabled = true ;
            }

            
        }
        private void SetSearchControl()
        {
            this.SearchKSA.SeriesID = CurrentJNP.SeriesID;
            this.literalSearchmsg.Text = string.Empty;
        }
        private void AssignValues(JobAnalysisDutyKSAFactor jaDutyKSAFactor)
        {


            jaDutyKSAFactor.JADutyID = JADutyID;
            jaDutyKSAFactor.JQFactorTitle = this.radEditorJAKSADescription.Text;
            jaDutyKSAFactor.KSAID = long.Parse(this.radcomboKSA.SelectedValue);
            jaDutyKSAFactor.QualificationID = int.Parse(this.radComboDutyQualID.SelectedValue);
            jaDutyKSAFactor.JQFactorTypeID = int.Parse(this.radcomboQualificationTypeID.SelectedValue);
            jaDutyKSAFactor.UpdatedByID = base.CurrentUserID;
            jaDutyKSAFactor.UpdateDate = DateTime.Now;
            if (CurrentMode == eMode.Insert)
            {
                jaDutyKSAFactor.IsFinalKSA = false;
                jaDutyKSAFactor.ImportanceID = enumImportanceScale.None;
                jaDutyKSAFactor.NeedAtEntryID = enumNeedAtEntryScale.None;
                jaDutyKSAFactor.DistinguishingValueScaleID = enumDistinguishingValueScale.None;
                jaDutyKSAFactor.CreatedByID = base.CurrentUserID;
                jaDutyKSAFactor.CreateDate = DateTime.Now;
            }


        }

        #endregion

        #region Control Events

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            JobAnalysisDutyKSAFactor jaDutyKSAFactor;
            try
            {
                    if (CurrentMode == eMode.Insert)
                    {
                        if (JADutyID > 0)
                        {
                                jaDutyKSAFactor = new JobAnalysisDutyKSAFactor();
                                AssignValues(jaDutyKSAFactor);
                                jaDutyKSAFactor.Add();
                                lblmsg.Text = "Duty-KSA added successfully.";
                                JQFactorID = jaDutyKSAFactor.JQFactorID;
                                CurrentMode = eMode.Edit;

                        } 
                        else
                        {
                            this.lblError.Text = "Current Job Analysis Duty is not set";
                        } 
                    }
                    else if (CurrentMode == eMode.Edit)
                    {
                        jaDutyKSAFactor = new JobAnalysisDutyKSAFactor(JQFactorID);
                        this.JADutyID = jaDutyKSAFactor.JADutyID;
                        AssignValues(jaDutyKSAFactor);
                        jaDutyKSAFactor.Update();
                        lblmsg.Text = "Duty-KSA updated successfully.";
                    }
               
               
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
      
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            
            string script = string.Empty;
            switch (this.CurrentMode)
            {
                case eMode.None:
                    break;
                case eMode.Edit:
                case eMode.Insert :
                    base.CurrentJADutyID = this.CurrentJADutyID;
                    base.CurrentNavMode = enumNavigationMode.Edit;
                    break;
                 //commenting setting currentNavMode when in view
                //setting currentNavMode to view  was causing issue 95-moving from editable section of a package to a read-only section
                //and then back to an editable section leaves the package in read-only mode 
                //case eMode.View:
                //    base.CurrentNavMode =enumNavigationMode.View;
                //    break;
                default:
                    break;
            }
            script = string.Format("EditDutyKSAClose();");
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        protected void radcomboKSA_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            this.radEditorJAKSADescription.Content = radcomboKSA.Text;
        }
        private void SearchKSA_KSASearchCancelCompleted(object sender,EventArgs e)
        {
            BindKSACombo();
        }

        private void SearchKSA_KSASearchCompleted(object sender,EventArgs e)
        {
            this.literalSearchmsg.Text = "KSA search completed successfully. Please select KSA from the drop down list.";
            radcomboKSA.Items.Clear();
            var orderedList = SearchKSA.KSAList.OrderBy(o => o.KSAText).ToList();

            //ControlUtility.BindRadComboBoxControl(this.radcomboKSA, orderedList, null, "KSAText", "KSAID", "<<--Select KSA First-->>");
            ControlUtility.BindRadComboBoxControlWithBackground(this.radcomboKSA, orderedList, null, "KSAText", "KSAID", "<<--Select KSA First-->>");
        }
        #endregion
    }
}