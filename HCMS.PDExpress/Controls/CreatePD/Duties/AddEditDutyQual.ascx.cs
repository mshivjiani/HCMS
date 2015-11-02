using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Telerik.Web.UI;

using HCMS.Business.PD;
using HCMS.Business.Lookups;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Utilities;
using HCMS.Business.Duty;

using HCMS.PDExpress.Controls.Search;

namespace HCMS.PDExpress.Controls.CreatePD.Duties
{
    public partial class AddEditDutyQual : CreatePDUserControlBase
    {

        #region [Private Properties]

        private eMode CurrentMode
        {
            get
            {
                if (ViewState["CurrentMode"] == null)
                {
                    string currentMode = Request.QueryString["Mode"];
                    if (string.IsNullOrEmpty(currentMode))
                    {
                        ViewState["CurrentMode"] = eMode.None;
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

        private int DutyID
        {
            get
            {
                if (ViewState["DutyID"] == null)
                {
                    string DutyIDParam = Request.QueryString["DutyID"];

                    if (String.IsNullOrEmpty(DutyIDParam))
                        ViewState["DutyID"] = -1;
                    else
                        ViewState["DutyID"] = int.Parse(DutyIDParam);
                }
                return (int)ViewState["DutyID"];

            }
            set
            {
                ViewState["DutyID"] = value;
            }
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
        private List<KSA> KSAList
        {
            get
            {
                List<KSA> ksalist = new List<KSA>();
                int seriesid = -1;
                int grade = -1;
                string cacheKey = string.Empty;
               
                   if(base.CurrentPD!=null)
                   {
                        seriesid = base.CurrentPD.JobSeries ;
                        grade = base.CurrentPD.ProposedGrade;
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
            base.OnInit(e);

            SearchKSA.KSASearchCompleted += new ctrlSearchKSA.KSASearchCompletedHandler(SearchKSA_KSASearchCompleted);
            SearchKSA.KSASearchCancelCompleted += new ctrlSearchKSA.KSASearchCancelCompleteHandler(SearchKSA_KSASearchCancelCompleted);
            SearchKSA.KSASearchClearCompleted += new ctrlSearchKSA.KSASearchClearCompleteHandler(SearchKSA_KSASearchClearCompleted);

           
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SearchKSA.SeriesID = base.CurrentPD.JobSeries;
                SearchKSA.CurrentGrade = base.CurrentPD.ProposedGrade;
                //SearchKSA.ShowGradeSelection = false;
                SearchKSA.KSAComboBox = radcomboKSA;
                SearchKSA.SearchMessageLabel = literalSearchmsg;

                BindKSACombo(radcomboKSA);
               // radcomboKSAReqVal.Enabled =(CurrentMode==eMode.Insert );
                if (CurrentMode == eMode.Edit)
                {
                    
                    BindData();
                }

                 
                
            }

        }

        private void BindData()
        {
            if (DutyCompetencyKSAID > 0)
            {
                DutyCompetencyKSA dutyqual = new DutyCompetencyKSA(DutyCompetencyKSAID);
                this.radEditorQualDescription.Content = dutyqual.CompetencyKSA.Replace("\n", "<br />"); 
                this.radComboDutyQualID.SelectedValue = dutyqual.QualificationID.ToString();
                this.radcomboQualificationTypeID.SelectedValue = dutyqual.QualificationTypeID.ToString();
                this.radcomboKSA.SelectedValue = dutyqual.KSAID.ToString();
            }
        }
        private void AssignValues(DutyCompetencyKSA dutyCompetency)
        {

            if (CurrentMode == eMode.Insert)
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
            dutyCompetency.KSAID = long.Parse(this.radcomboKSA.SelectedValue);
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            DutyCompetencyKSA dutyCompetency;
            
            string CloseScript = string.Empty;

            try
            {
               
                Page.Validate();

                if (Page.IsValid)
                {
                    if (CurrentMode == eMode.Insert)
                    {
                        dutyCompetency = new DutyCompetencyKSA();
                        AssignValues(dutyCompetency);
                        dutyCompetency.Add();

                        //We are closing window hence this message is no longer required.
                        //lblmsg.Text = "Duty KSA added successfully.";

                        DutyCompetencyKSAID = dutyCompetency.DutyCompetencyKSAID;
                        CurrentMode = eMode.Edit;
                        hiddenID.Value = DutyCompetencyKSAID.ToString();
                        hiddenMode.Value = "Update";
                    }
                    else if (CurrentMode == eMode.Edit)
                    {
                        dutyCompetency = new DutyCompetencyKSA(DutyCompetencyKSAID);
                        AssignValues(dutyCompetency);
                        dutyCompetency.Update();

                        //We are closing window hence this message is no longer required.
                        //lblmsg.Text = "Duty KSA updated successfully.";
                    }

                    CloseScript = string.Format("EditDutyQualClose();");
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", CloseScript, true);

                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
           
        }

        private void BindKSACombo(RadComboBox radcomboKSA)
        {

            KSAList.RemoveAll(m => m.KSAText == UserControlBase.OTHERKSATEXT );
            var orderedList = KSAList.OrderBy(o => o.KSAText).ToList();
            var otherItem = new KSA() { KSAID = 0, KSAText = UserControlBase.OTHERKSATEXT  };
            orderedList.Insert(0, otherItem);
            //radcomboKSA.DataSource = orderedList;
            //radcomboKSA.DataBind();
            ControlUtility.BindRadComboBoxControlWithBackground(radcomboKSA, orderedList, null, "KSAText", "KSAID", "<<--Select KSA First-->>");
        }

        protected void radcomboKSA_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            radEditorQualDescription.Content = e.Text;

        }      


        #region [searchKSA Events]
        
        private void SearchKSA_KSASearchCancelCompleted(object sender, EventArgs e)
        {
            literalSearchmsg.Text = string.Empty;

        }

        private void SearchKSA_KSASearchCompleted(object sender, EventArgs e)
        {
            radcomboKSA.Items.Clear();
            var orderedList = SearchKSA.KSAList.OrderBy(o => o.KSAText).ToList();
            orderedList.RemoveAll(m => m.KSAText == UserControlBase.OTHERKSATEXT);
            var otherItem = new KSAEntity() { KSAID = 0, KSAText = UserControlBase.OTHERKSATEXT };
            orderedList.Insert(0, otherItem);
            
            ControlUtility.BindRadComboBoxControlWithBackground(radcomboKSA, orderedList, null, "KSAText", "KSAID", "<<--Select KSA First-->>");

            var keywordSearch = "";
            if (SearchKSA.KeywordSearched.Length > 0) keywordSearch = ". Searched on keyword: " + SearchKSA.KeywordSearched;

            if (SearchKSA.ShowAllGradesChecked)
                literalSearchmsg.Text = string.Format("Search KSA in Series:{0}" + keywordSearch, SearchKSA.SeriesID.ToString());
            else
                literalSearchmsg.Text = string.Format("Search KSA in Series:{0} - Grade:{1}" + keywordSearch, SearchKSA.SeriesID.ToString(), SearchKSA.CurrentGrade.ToString());
        }

        void SearchKSA_KSASearchClearCompleted(object sender, EventArgs e)
        {
            //BindKSACombo(radcomboKSA);

            radcomboKSA.Items.Clear();
            var orderedList = SearchKSA.KSAList.OrderBy(o => o.KSAText).ToList();
            orderedList.RemoveAll(m => m.KSAText == UserControlBase.OTHERKSATEXT);
            var otherItem = new KSAEntity() { KSAID = 0, KSAText = UserControlBase.OTHERKSATEXT };
            orderedList.Insert(0, otherItem);

            ControlUtility.BindRadComboBoxControlWithBackground(radcomboKSA, orderedList, null, "KSAText", "KSAID", "<<--Select KSA First-->>");

            literalSearchmsg.Text = string.Empty;

        }

        #endregion

        
    
    }
}