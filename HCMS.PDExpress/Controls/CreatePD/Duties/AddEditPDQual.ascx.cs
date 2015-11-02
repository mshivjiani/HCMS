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

using HCMS.PDExpress.Controls.Search;


namespace HCMS.PDExpress.Controls.CreatePD.Duties
{
    public partial class AddEditPDQual : CreatePDUserControlBase
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

        private int PositionCompetencyKSAID
        {
            get
            {
                if (ViewState["PositionCompetencyKSAID"] == null)
                {
                    string PositionCompetencyKSAIDParam = Request.QueryString["PositionCompetencyKSAID"];

                    if (String.IsNullOrEmpty(PositionCompetencyKSAIDParam))
                        ViewState["PositionCompetencyKSAID"] = -1;
                    else
                        ViewState["PositionCompetencyKSAID"] = int.Parse(PositionCompetencyKSAIDParam);
                }
                return (int)ViewState["PositionCompetencyKSAID"];

            }
            set
            {
                ViewState["PositionCompetencyKSAID"] = value;
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

                if (base.CurrentPD != null)
                {
                    seriesid = base.CurrentPD.JobSeries;
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

        private void BindData()
        {
            if (PositionCompetencyKSAID  > 0)
            {
                PositionCompetencyKSA pdQual = new PositionCompetencyKSA(PositionCompetencyKSAID);
                this.radEditorQualDescription.Content = pdQual.CompetencyKSA.Replace("\n", "<br />");
                this.radComboQualID.SelectedValue = pdQual.QualificationID.ToString();
                this.radcomboQualificationTypeID.SelectedValue = pdQual.QualificationTypeID.ToString();
                this.radcomboKSA.SelectedValue = pdQual.KSAID.ToString();
            }
        }
        private void AssignValues(PositionCompetencyKSA pdCompetency)
        {

            if (CurrentMode == eMode.Insert)
            {
                pdCompetency.PositionDescriptionID = CurrentPDID;
                pdCompetency.CreatedByID = base.CurrentUser.UserID;
                pdCompetency.CreateDate = DateTime.Now;
            }
            //radeditor inserts extra '\r' and '\n' along with <br />
            //therefore replacing <br /> to '' to save it to db so that it does not create extra new line
            //saving radeditor's text because if user formats the text,it will insert
            //html tags with content. Don't want to save html tags in the database 
            pdCompetency.CompetencyKSA = radEditorQualDescription.Text;
            pdCompetency.QualificationTypeID = Convert.ToInt32(radcomboQualificationTypeID.SelectedValue);
            pdCompetency.QualificationID = Convert.ToInt32(radComboQualID.SelectedValue);
            pdCompetency.UpdatedByID = base.CurrentUser.UserID;
            pdCompetency.UpdateDate = DateTime.Now;
            pdCompetency.KSAID = long.Parse(this.radcomboKSA.SelectedValue);
        }

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
                SearchKSA.KSAComboBox = radcomboKSA;
                SearchKSA.SearchMessageLabel = literalSearchmsg;
                //SearchKSA.ShowGradeSelection = false;
                BindKSACombo(radcomboKSA);
                //radcomboKSAReqVal.Enabled = (CurrentMode == eMode.Insert);
                if (CurrentMode == eMode.Edit)
                {
                    BindData();
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            PositionCompetencyKSA pdCompetency;
            string CloseScript = string.Empty;

            try
            {
                Page.Validate();

                if (Page.IsValid)
                {
                    if (CurrentMode == eMode.Insert)
                    {
                        pdCompetency = new PositionCompetencyKSA();
                        AssignValues(pdCompetency);
                        pdCompetency.Add();

                        //We are closing window hence this message is no longer required.
                        //lblmsg.Text = "Position KSA added successfully.";

                        PositionCompetencyKSAID = pdCompetency.CompetencyKSAID;
                        CurrentMode = eMode.Edit;

                    }
                    else if (CurrentMode == eMode.Edit)
                    {
                        pdCompetency = new PositionCompetencyKSA(PositionCompetencyKSAID);
                        AssignValues(pdCompetency);
                        pdCompetency.Update();

                        //We are closing window hence this message is no longer required.
                        //lblmsg.Text = "Position KSA updated successfully.";
                    }

                    CloseScript = string.Format("CloseWindow();");
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
            var orderedList = KSAList.OrderBy(o => o.KSAText).ToList();
            orderedList.RemoveAll(m => m.KSAText == UserControlBase.OTHERKSATEXT);
            var otherItem = new KSA() { KSAID = 0, KSAText = UserControlBase.OTHERKSATEXT };
            orderedList.Insert(0, otherItem);
            //radcomboKSA.DataSource = orderedList;
            //radcomboKSA.DataBind();
            ControlUtility.BindRadComboBoxControlWithBackground(radcomboKSA, orderedList, null, "KSAText", "KSAID", "<<--Select KSA First-->>");

            //if (KSAList.Count < 2 && KSAList[0].KSAText == "Other")
            //{
            //    radcomboKSA.SelectedValue = "0";
            //}
            //PopulateKSAComboBox();
        }

        private void PopulateKSAComboBox()
        {
            radcomboKSA.Items.Clear();
            var orderedList = SearchKSA.KSAList.OrderBy(o => o.KSAText).ToList();
            orderedList.RemoveAll(m => m.KSAText == UserControlBase.OTHERKSATEXT);
            var otherItem = new KSAEntity() { KSAID = 0, KSAText = UserControlBase.OTHERKSATEXT };
            orderedList.Insert(0, otherItem);
            ControlUtility.BindRadComboBoxControlWithBackground(radcomboKSA, orderedList, null, "KSAText", "KSAID", "<<--Select KSA First-->>");
        }

        protected void radcomboKSA_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        {
            this.radEditorQualDescription.Content = radcomboKSA.Text;
        }

        protected void radcomboQualificationTypeID_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
        {
            int qualtypeid = int.Parse(e.Item.Value);
            //only SF and COE are allowed at PD qual level
            if (qualtypeid != 2 && qualtypeid != 4)
            {
                e.Item.Remove();
            }
        }

        #region [searchKSA Events]

        private void SearchKSA_KSASearchCancelCompleted(object sender, EventArgs e)
        {
            BindKSACombo(radcomboKSA);
            literalSearchmsg.Text = string.Empty;
        }

        private void SearchKSA_KSASearchCompleted(object sender, EventArgs e)
        {
            PopulateKSAComboBox();
            var keywordSearch = "";
            if (SearchKSA.KeywordSearched.Length > 0) keywordSearch = ". Searched on keyword: " + SearchKSA.KeywordSearched;

            if (SearchKSA.ShowAllGradesChecked)
                literalSearchmsg.Text = string.Format("Search KSA in Series:{0}" + keywordSearch, SearchKSA.SeriesID.ToString());
            else
                literalSearchmsg.Text = string.Format("Search KSA in Series:{0} - Grade:{1}" + keywordSearch, SearchKSA.SeriesID.ToString(), SearchKSA.CurrentGrade.ToString());
        }

        private void SearchKSA_KSASearchClearCompleted(object sender, EventArgs e)
        {
            PopulateKSAComboBox();
            literalSearchmsg.Text = string.Empty;
        }

        #endregion

    }
}