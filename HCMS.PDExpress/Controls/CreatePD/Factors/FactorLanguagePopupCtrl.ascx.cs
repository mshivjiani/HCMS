using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI;
using HCMS.Business.Factor;
using HCMS.Business.Lookups;
using HCMS.Business.PD;
using HCMS.Business.SeriesFactorLevelLanguage;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Utilities;
using Telerik.Web.UI;
using System.Data;


namespace HCMS.PDExpress.Controls.CreatePD.Factors
{
    public partial class FactorLanguagePopupCtrl : CreatePDUserControlBase
    {
        #region [ Page Event Handlers ]
        protected void Page_Init(object sender, EventArgs e)
        {
            rcbFactorLevel.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(rcbFactorLevel_SelectedIndexChanged);
            btnSave.Click += new EventHandler(btnSave_Click);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string jqurl = Page.ResolveClientUrl("~/Src/JsRelatedTocss/jQuery-1.3.2.js");
            ClientScriptManager cs = Page.ClientScript;

            if (!cs.IsClientScriptIncludeRegistered("jq"))
            {
                cs.RegisterClientScriptInclude("jq", jqurl);
                
            }

            if (IsPostBack == false)
            {
                LoadData();
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            PDStatus currentPDStatus = base.CurrentPD.GetCurrentPDStatus();

            if ((base.IsPDReadOnly) || (base.CurrentPDChoice == PDChoiceType.StatementOfDifferencePD))
            {
                btnSave.Enabled = false;

                this.trFactorLevel.Attributes.Add("class", "disabled");
                this.rcbFactorLevel.Enabled = false;

                this.trFactorLanguage.Attributes.Add("class", "disabled");
                //this.txtFactorLanguage.Attributes.Add("readonly", "readonly");
                this.RadEditFactorLanguage.Enabled = false;

                this.trFactorRecommendation.Visible = false;

                this.trReviewed.Visible = false;

                //Show Recommendation note and reviewed but disable it
                if ((base.CurrentPDChoice != PDChoiceType.StatementOfDifferencePD) && (currentPDStatus == PDStatus.Review || currentPDStatus == PDStatus.Revise || currentPDStatus == PDStatus.FinalReview))
                {
                    this.trFactorRecommendation.Visible = true;
                    this.trReviewed.Visible = true;
                    this.trFactorRecommendation.Attributes.Add("class", "disabled");
                    this.txtFactorRecommendation.Attributes.Add("readonly", "readonly");
                    this.trReviewed.Attributes.Add("class", "disabled");
                    this.chkReviewed.Enabled = false;
                }
                //not showing factor justification row if there is none
                //if (String.IsNullOrEmpty(txtFactorJustification.Text))
                if(string.IsNullOrEmpty(RadEditFactorJustification.Text))
                {
                    this.trFactorJustification.Visible = false;
                }
                else
                {
                    this.trFactorJustification.Attributes.Add("class", "disabled");
                    this.RadEditFactorJustification.Enabled = false;
                    //this.txtFactorJustification.Attributes.Add("readonly", "readonly");
                }
            }
            else //PD is not readonly
            {
                if (base.CurrentPDChoice != PDChoiceType.StatementOfDifferencePD)                {
                    btnSave.Enabled = true;
                    //enable Factor level and language in Draft/Review/Revise mode
                    if ((currentPDStatus == PDStatus.Draft) || (currentPDStatus == PDStatus.Revise) || (currentPDStatus == PDStatus.Review))
                    {
                        this.trFactorLevel.Attributes.Add("class", "");
                        this.rcbFactorLevel.Enabled = true;
                        this.trFactorLanguage.Attributes.Add("class", "");
                    }
                    else
                    {
                        this.trFactorLevel.Attributes.Add("class", "disabled");
                        this.rcbFactorLevel.Enabled = false;

                        this.trFactorLanguage.Attributes.Add("class", "disabled");
                        //this.txtFactorLanguage.Attributes.Add("readonly", "readonly");
                        this.RadEditFactorLanguage.Enabled = false;
                        //txtFactorLanguage is not disabled as it prevents the scrolling
                    }

                    //Review/Revise:

                    //make Recommendation note and Reviewed? - visible in Review/Revise
                    if ((currentPDStatus == PDStatus.Review) || (currentPDStatus == PDStatus.Revise))
                    {
                        this.trFactorRecommendation.Visible = true;
                        this.trReviewed.Visible = true;
                            //Enable Recommendation note only in Review for hr group
                        if (currentPDStatus == PDStatus.Review && base.HasPermission(enumPermission.MaintainFactorRecommendation))
                        {
                            this.trFactorRecommendation.Attributes.Add("class", "");
                            this.txtFactorRecommendation.Enabled = true;
                        }
                        else
                        {
                            this.trFactorRecommendation.Attributes.Add("class", "disabled");
                            this.txtFactorRecommendation.Attributes.Add("readonly", "readonly");
                          
                        }

                        //Enable Reviewed? only in Revise
                        if (currentPDStatus != PDStatus.Revise)
                        {
                            this.trReviewed.Attributes.Add("class", "disabled");
                            this.chkReviewed.Enabled = false;
                        }
                        else //current status = Revise enable reviewed
                        {
                            this.trReviewed.Attributes.Add("class", "");
                            this.chkReviewed.Enabled = true;     

                            //In Revise, check the recommendationnote
                            //if there is a recommendation note - check reviewed flag
                            //if reviewed flag is not updated, then display the accept/reject factor change window
                            if (!string.IsNullOrEmpty(PF.RecommendationNote))
                            {
                                bool reviewed = false;
                                if (PF.Reviewed.HasValue) 
                                {

                                    reviewed = (bool)PF.Reviewed;

                                }
                                //show the accept/reject factor review popup if recommendation is not reviewed
                                if (!reviewed)
                                {
                                    DataTable dt = PF.GetPositionFactorComparision();
                                    if (dt.Rows.Count > 0) // it will be zero if HR added new class standard
                                    {
                                        DataRow dr = dt.Rows[0];
                                        string currentlang = dr["CurrentLanguage"].ToString();
                                        string workflowlang = dr["WorkflowLanguage"].ToString();
                                        if (string.Compare(currentlang, workflowlang, true) != 0)
                                        {
                                            this.RadWindowManager1.Windows[0].NavigateUrl = Page.ResolveUrl(string.Format("~/CreatePD/PositionFactorReviewPopup.aspx?PositionFactorID={0}&FactorTitle={1}", PositionFactorIDQS.ToString(), FactorTitleQS.ToString()));
                                            this.RadWindowManager1.Windows[0].VisibleOnPageLoad = true;
                                        }
                                    }
                                }
                            }
                      
                        }
                        //allow hr to update factor justification in review and in final review
                        if ((currentPDStatus == PDStatus.Review || currentPDStatus == PDStatus.FinalReview) && base.HasPermission(enumPermission.MaintainFactorRecommendation))
                        {
                            this.trFactorJustification.Attributes.Add("class", "");
                            this.RadEditFactorJustification.Enabled = true;
                            //this.txtFactorJustification.Enabled = true;
                        }
                        else
                        {
                            this.trFactorJustification.Attributes.Add("class", "disabled");
                            //this.txtFactorJustification.Attributes.Add("readonly", "readonly");
                            this.RadEditFactorJustification.Enabled = false;
                        }
                    }// end of Review/Revise

                    //Final Review:
                    else if (currentPDStatus == PDStatus.FinalReview && base.HasPermission(enumPermission.MaintainFactorRecommendation))
                    {
                        this.trFactorRecommendation.Attributes.Add("class", "disabled");
                        this.txtFactorRecommendation.Attributes.Add("readonly", "readonly");
                        this.trFactorRecommendation.Visible = true;
                        this.trReviewed.Attributes.Add("class", "disabled");
                        this.chkReviewed.Enabled = false;
                        this.trReviewed.Visible = true;
                    }
                    else
                    {
                        this.trFactorRecommendation.Visible = false;
                        this.trReviewed.Visible = false;
                    }

                    //show Eval Justification only if Position has Eval Criteria
                    //and user has permission to enter Factor Justification note
                    if (base.CurrentPD.GetPositionEvalCriteria().Count > 0)
                    {
                        this.trFactorJustification.Visible = true;
                        bool canEdit = CanEditJustification();
                        if (canEdit == false)
                        {
                            this.trFactorJustification.Attributes.Add("class", "disabled");
                            //this.txtFactorJustification.Attributes.Add("readonly", "readonly");
                            this.RadEditFactorJustification.Enabled = false;
                        }
                        else
                        {
                            this.trFactorJustification.Attributes.Add("class", "");
                        }
                    }
                    else
                    {
                        this.trFactorJustification.Visible = false;
                    }
                }
            }
        }
        #endregion        
        #region [ Private Methods ]
        private void LoadData()
        {
            PDStatus currentPDStatus = base.CurrentPD.GetCurrentPDStatus();
            this.hdnPositionFactorID.Value = this.PositionFactorIDQS.ToString();
            //if (currentPDStatus == PDStatus.Review)
            //{
            //    txtFactorLanguage.Attributes.Add("onchange", string.Format("javascript:onFactorLanguageChanged({0})", PF.PositionFactorID));

            //}
            PopulateFactorLevelDropDownList();
            // get it from Query String, not from PF.FactorTitle
            lblFactorTitle.Text = FactorTitleQS;
            ControlUtility.SafeTextBoxAssign(txtFactorRecommendation, PF.RecommendationNote);
            bool reviewed = false;
            if (PF.Reviewed.HasValue)
            {
                reviewed = (bool)PF.Reviewed;
            }
            chkReviewed.Checked = reviewed;
            RadEditFactorJustification.Content = PF.FactorJustification.Replace("\n", "<br/>"); ;
           // ControlUtility.SafeTextBoxAssign(txtFactorJustification, PF.FactorJustification);
            // set properties
            CurrentFactorLevelID = int.Parse(rcbFactorLevel.SelectedValue);
            FactorLevelPoint currentFactorLevelPoint = new FactorLevelPoint(CurrentFactorLevelID, (enumFactorFormatType)PF.FactorFormatTypeID);
            CurrentPoint = currentFactorLevelPoint.Point;

            RefreshGrid = ((enumFactorFormatType)PF.FactorFormatTypeID).ToString();

            // populate Factor Language
            if (!String.IsNullOrEmpty(PF.Language))
            {
                //if the language is copied from the word document/from existing PD,  
                // it can have newline as '\n' and radeditor is an  html editor and it ignores \n
                // so it does not create newline. To force it to create newline, replacing all
                // '\n' with '<br />'
                RadEditFactorLanguage.Content = PF.Language.Replace ("\n","<br />");
                //ControlUtility.SafeTextBoxAssign(txtFactorLanguage, PF.Language);


            }
            else
            {
                int currentFactorID = currentFactorLevelPoint.FactorID;
                int levelID = currentFactorLevelPoint.LevelID;
                int factorlevelID = currentFactorLevelPoint.FactorLevelID;
                bool onlyPrimaryFes = PD.OnlyPrimaryFESStandard();
                enumFactorFormatType currentfactorformattype = (enumFactorFormatType)PF.FactorFormatTypeID;

                if ((currentfactorformattype == enumFactorFormatType.FES) && (onlyPrimaryFes))
                {
                    PrimaryFESFactorLevelLanguage currentPrimaryFactorLevelLanguage = new PrimaryFESFactorLevelLanguage(currentFactorID, levelID);
                    RadEditFactorLanguage.Content = currentPrimaryFactorLevelLanguage.FactorLevelLanguage.Replace("\n", "<br />");
                    //ControlUtility.SafeTextBoxAssign(this.txtFactorLanguage, currentPrimaryFactorLevelLanguage.FactorLevelLanguage);
                   
                }
                else
                {
                    SeriesFactorLevelLanguage currentFactorLevelLanguage = new SeriesFactorLevelLanguage(PD.JobSeries, factorlevelID, currentfactorformattype);
                    RadEditFactorLanguage.Content = currentFactorLevelLanguage.FactorLevelLanguage.Replace("\n", "<br />");
                    //ControlUtility.SafeTextBoxAssign(this.txtFactorLanguage, currentFactorLevelLanguage.FactorLevelLanguage);
                   
                }
                 
                //hdnFactorLanguageToCompareWith.Value = txtFactorLanguage.Text;

            }
            //can not assign html content to hidden field -- as it causes page.RequestValidation to fail
            hdnFactorLanguageToCompareWith.Value = RadEditFactorLanguage.Text ;

            if (currentPDStatus == PDStatus.Review)
            {
                //txtFactorLanguage.Attributes.Add("onchange", string.Format("javascript:onFactorLanguageChanged({0})", PF.PositionFactorID));
                RadEditFactorLanguage.Attributes.Add ("onchange",string.Format("javascript:onFactorLanguageChanged({0})", PF.PositionFactorID));
            }
           

        }

        private void PopulateFactorLevelDropDownList()
        {
            List<IFactorLevelPoint> factorLevelList = new List<IFactorLevelPoint>();

            if ((enumFactorFormatType)PF.FactorFormatTypeID == enumFactorFormatType.FES)
            {
                factorLevelList = FactorLevelPoint.GetFactorLevelPointsByFactorID(new FesFactorLevelPoints(), PF.FactorID);
            }
            else if ((enumFactorFormatType)PF.FactorFormatTypeID == enumFactorFormatType.GSSG)
            {
                factorLevelList = FactorLevelPoint.GetFactorLevelPointsByFactorID(new GSSGFactorLevelPoints(), PF.FactorID);
            }

            rcbFactorLevel.DataSource = factorLevelList;
            rcbFactorLevel.DataMember = "LevelID";
            rcbFactorLevel.DataValueField = "FactorLevelID";
            rcbFactorLevel.DataBind();

            ArrayList arrFactorLevelList = new ArrayList(factorLevelList.Count);
            int i = 0;

            foreach (IFactorLevelPoint factorLevelPoint in factorLevelList)
            {
                arrFactorLevelList.Add(string.Format("{0}-{1}", factorLevelPoint.LevelID, factorLevelPoint.Point));
            }

            for (i = 0; i < arrFactorLevelList.Count; i++)
            {
                rcbFactorLevel.Items[i].Text = arrFactorLevelList[i].ToString();
                int currentLevelId = int.Parse(rcbFactorLevel.Items[i].Value);
                if (currentLevelId == PF.FactorLevel)
                {
                    rcbFactorLevel.Items[i].Selected = true;
                }
            }
        }
        private bool CanEditJustification()
        {
            bool canEdit = false;

            bool isPDCreator = base.CurrentPD.PDCreatorID.Equals(base.CurrentUser.UserID);
            bool isPDCreatorSupervisor = base.isPDCreatorSupervisor(false);
            bool isSOD = base.CurrentPDChoice == PDChoiceType.StatementOfDifferencePD;
            bool hasHRGroupPermission = (base.HasPermission(enumPermission.CompleteHRCertification) || base.HasPermission(enumPermission.MaintainEvaluationStatements) ||
                                        base.HasPermission(enumPermission.MaintainHRSection) || base.HasPermission(enumPermission.MaintainFactorRecommendation) ||
                                        base.HasPermission(enumPermission.PublishPD));

            PDStatus currentStatus = PD.GetCurrentPDStatus();

            if (!(base.IsPDReadOnly || isSOD))
            {
                if (hasHRGroupPermission)
                {
                    if (isPDCreator || isPDCreatorSupervisor)
                    {
                        if (currentStatus == PDStatus.Draft || currentStatus == PDStatus.Review || currentStatus == PDStatus.Revise || currentStatus == PDStatus.FinalReview)
                        {
                            canEdit = true;
                        }
                    }
                    else
                    {
                        if (currentStatus == PDStatus.Review || currentStatus == PDStatus.FinalReview)
                        {
                            canEdit = true;
                        }
                    }
                }
            }

            return canEdit;
        }
        #endregion
        #region [ Even Handlers ]
        void rcbFactorLevel_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            CurrentFactorLevelID = int.Parse(e.Value);
            FactorLevelPoint currentFactorLevelPoint = new FactorLevelPoint(CurrentFactorLevelID, (enumFactorFormatType)PF.FactorFormatTypeID);
            int currentFactorID = currentFactorLevelPoint.FactorID;
            int levelID = currentFactorLevelPoint.LevelID;
            int factorlevelID = currentFactorLevelPoint.FactorLevelID;
            CurrentPoint = currentFactorLevelPoint.Point;
            enumFactorFormatType currentfactorformattype = (enumFactorFormatType)PF.FactorFormatTypeID;
            bool onlyPrimaryFes = PD.OnlyPrimaryFESStandard();
            if ((currentfactorformattype == enumFactorFormatType.FES) && (onlyPrimaryFes))
            {
                PrimaryFESFactorLevelLanguage currentPrimaryFactorLevelLanguage = new PrimaryFESFactorLevelLanguage(currentFactorID, levelID);
                RadEditFactorLanguage.Content = currentPrimaryFactorLevelLanguage.FactorLevelLanguage.Replace("\n", "<br/>"); ;
                //ControlUtility.SafeTextBoxAssign(this.txtFactorLanguage, currentPrimaryFactorLevelLanguage.FactorLevelLanguage);
            }
            else
            {
                SeriesFactorLevelLanguage currentFactorLevelLanguage = new SeriesFactorLevelLanguage(PD.JobSeries, factorlevelID, currentfactorformattype);
                RadEditFactorLanguage.Content = currentFactorLevelLanguage.FactorLevelLanguage.Replace("\n", "<br/>"); ;
                //ControlUtility.SafeTextBoxAssign(this.txtFactorLanguage, currentFactorLevelLanguage.FactorLevelLanguage);

            }
        }
        void btnSave_Click(object sender, EventArgs e)
        {
            PDStatus currentPDStatus = base.CurrentPD.GetCurrentPDStatus();
            string language = String.Empty;
            string existinglanguage = string.Empty;
            string newlanguage = string.Empty;
            string radlanguagecontentcleaned = string.Empty;

            if (!String.IsNullOrEmpty(PF.Language))
            {
                language = PF.Language ;
            }
            else
            {
                FactorLevelPoint currentFactorLevelPoint = new FactorLevelPoint(CurrentFactorLevelID, (enumFactorFormatType)PF.FactorFormatTypeID);
                int currentFactorID = currentFactorLevelPoint.FactorID;
                int levelID = currentFactorLevelPoint.LevelID;
                int factorlevelID = currentFactorLevelPoint.FactorLevelID;
                enumFactorFormatType currentfactorformattype = (enumFactorFormatType)PF.FactorFormatTypeID;
                SeriesFactorLevelLanguage currentFactorLevelLanguage = new SeriesFactorLevelLanguage(PD.JobSeries, factorlevelID, currentfactorformattype);
                language = currentFactorLevelLanguage.FactorLevelLanguage ;
            }

            PF.FactorLevel = CurrentFactorLevelID;
            PF.Point = CurrentPoint;

            existinglanguage = language;          
            
            
            //radeditor inserts extra '\r' and '\n' along with <br />
            //therefore replacing <br /> to '' to save it to db so that it does not create extra new line
            //saving radeditor's text because if user formats the text,it will insert
            //html tags with content. Don't want to save html tags in the database 
            radlanguagecontentcleaned = RadEditFactorLanguage.Text ;
            newlanguage = radlanguagecontentcleaned;
            int intcompare = string.Compare(existinglanguage, newlanguage, true);

            //JA issue id 849: PDX: Save and Close button on Factor screen (for each factor) does nothing in Final Review
            hdnShowMessage.Value = "";
            if (intcompare != 0)
            {
                hdnShowMessage.Value = "showMessage";
            }
            string script = String.Format("showMessage()");
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "showMessage", script, true);


            if ((intcompare != 0) && (currentPDStatus == PDStatus.Review))
            {
                if (txtFactorRecommendation.Text.Length == 0)
                {
                    PF.RecommendationNote = "This factor language has been updated by HR, ensure you have reviewed the changes";

                }
                else
                {
                    PF.RecommendationNote = this.txtFactorRecommendation.Text;
                }
            }
            else
            {
                PF.RecommendationNote = this.txtFactorRecommendation.Text;
            }

            PF.Language = radlanguagecontentcleaned;  //this.txtFactorLanguage.Text;
            PF.Reviewed = this.chkReviewed.Checked;
            //saving radeditor's text because if user formats the text,it will insert
            //html tags with content. Don't want to save html tags in the database 
            PF.FactorJustification = RadEditFactorJustification.Text;//this.txtFactorJustification.Text;
            PF.UpdatedByID = base.CurrentUser.UserID;
            PF.UpdateDate = DateTime.Now;

            PF.Update();
        }
        #endregion
        #region [ Private Properties ]
        private PositionDescription PD
        {
            get
            {
                if (pd == null)
                {
                    pd = base.CurrentPD;
                }

                return pd;
            }
        }
        private PositionFactor PF
        {
            get
            {
                if (pf == null)
                {
                    if (PositionFactorIDQS != -1)
                    {
                        pf = new PositionFactor(PositionFactorIDQS);
                    }
                }

                return pf;
            }
        }
        private int CurrentFactorLevelID
        {
            get
            {
                if (ViewState["CurrentFactorLevelID"] != null)
                    return (int)ViewState["CurrentFactorLevelID"];
                else
                    return -1;
            }
            set
            {
                ViewState["CurrentFactorLevelID"] = value;
            }
        }
        private int CurrentPoint
        {
            get
            {
                if (ViewState["CurrentPoint"] != null)
                    return (int)ViewState["CurrentPoint"];
                else
                    return -1;
            }
            set
            {
                ViewState["CurrentPoint"] = value;
            }
        }
        // Query String properties
        private int PositionFactorIDQS
        {
            get
            {
                int positionFactorID = -1;

                if (String.IsNullOrEmpty(Page.Request.QueryString["PositionFactorID"]) == false)
                {
                    positionFactorID = int.Parse(Page.Request.QueryString["PositionFactorID"]);
                }

                return positionFactorID;
            }
        }
        private string FactorTitleQS
        {
            get
            {
                string factorTitle = String.Empty;

                if (String.IsNullOrEmpty(Page.Request.QueryString["FactorTitle"]) == false)
                {
                    factorTitle = Page.Request.QueryString["FactorTitle"].ToString();
                }

                return factorTitle;
            }
        }
        private string RefreshGrid
        {
            get
            {
                return hdnRefreshGrid.Value;
            }
            set
            {
                hdnRefreshGrid.Value = value;
            }
        }
        #endregion
        #region [ Private Fields ]
        private PositionDescription pd = null;
        private PositionFactor pf = null;
        #endregion

   }
}