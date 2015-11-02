using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Web.UI;

using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Utilities;
using HCMS.Business.PD;
using HCMS.Business.Lookups;
using HCMS.Business.Security;
using HCMS.Business.SeriesFactorLevelLanguage;

namespace HCMS.PDExpress.Controls.CreatePD.Factors
{
    public partial class NarrativeFactorLanguagePopupCtrl : CreatePDUserControlBase
    {
        #region [ Page Event Handlers ]
        protected void Page_Init(object sender, EventArgs e)
        {
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
                //if (String.IsNullOrEmpty(txtFactorJustification.Text))
                if (string.IsNullOrEmpty(RadEditFactorJustification.Text))
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
                if (base.CurrentPDChoice != PDChoiceType.StatementOfDifferencePD)
                {
                    btnSave.Enabled = true;

                    //enable Factor level and language only in draft/Revise mode
                    if ((currentPDStatus == PDStatus.Draft) || (currentPDStatus == PDStatus.Review) || (currentPDStatus == PDStatus.Revise))
                    {
                        this.trFactorLanguage.Attributes.Add("class", "");
                    }
                    else
                    {
                        this.trFactorLanguage.Attributes.Add("class", "disabled");
                        this.RadEditFactorLanguage.Enabled = false;
                        //txtFactorLanguage is not disabled as it prevents the scrolling
                        //this.txtFactorLanguage.Attributes.Add("readonly", "readonly");
                       
                    }

                    if ((currentPDStatus == PDStatus.Review) || (currentPDStatus == PDStatus.Revise))
                    {
                        //Enable Recommendation note only in Review 
                        this.trFactorRecommendation.Visible = true;
                        this.trReviewed.Visible = true;

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
                        else //current status =Revise
                        {
                            if (!string.IsNullOrEmpty(PF.RecommendationNote))
                            {
                                bool reviewed = false;
                                if (PF.Reviewed.HasValue)
                                {

                                    reviewed = (bool)PF.Reviewed;

                                }
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
                                            this.RadWindowManager1.Windows[0].NavigateUrl = Page.ResolveUrl(string.Format("~/CreatePD/PositionFactorReviewPopup.aspx?PositionFactorID={0}", PositionFactorIDQS.ToString()));
                                            this.RadWindowManager1.Windows[0].VisibleOnPageLoad = true;
                                        }
                                    }

                                }
                            }

                            this.trReviewed.Attributes.Add("class", "");
                            this.chkReviewed.Enabled = true;
                        }

                        if ((currentPDStatus == PDStatus.Review || currentPDStatus == PDStatus.FinalReview) && base.HasPermission(enumPermission.MaintainFactorRecommendation))
                        {
                            this.trFactorJustification.Attributes.Add("class", "");
                            this.RadEditFactorJustification.Enabled = true;
                            //this.txtFactorJustification.Enabled = true;
                        }
                        else
                        {
                            this.trFactorJustification.Attributes.Add("class", "disabled");
                            this.RadEditFactorJustification.Enabled = false;
                            //this.txtFactorJustification.Attributes.Add("readonly", "readonly");
                        }
                    }
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
                            this.RadEditFactorJustification.Enabled = false;
                            //this.txtFactorJustification.Attributes.Add("readonly", "readonly");
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
            this.hdnPositionFactorID.Value = this.PositionFactorIDQS.ToString();
            // get it from Query String, not from PF.FactorTitle
            lblFactorTitle.Text = FactorTitleQS;
            RefreshGrid = ((enumFactorFormatType)PF.FactorFormatTypeID).ToString();
            RadEditFactorLanguage.Content = PF.Language.Replace("\n", "<br />");
            //can not assign html content to hidden field -- as it causes page.RequestValidation to fail
            hdnFactorLanguageToCompareWith.Value = RadEditFactorLanguage.Text;
            //ControlUtility.SafeTextBoxAssign(txtFactorLanguage, PF.Language);
            //hdnFactorLanguageToCompareWith.Value = txtFactorLanguage.Text;
            ControlUtility.SafeTextBoxAssign(txtFactorRecommendation, PF.RecommendationNote);
            bool reviewed = false;
            if (PF.Reviewed.HasValue)
            {
                reviewed = (bool)PF.Reviewed;
            }
            chkReviewed.Checked = reviewed;
            RadEditFactorJustification.Content = PF.FactorJustification.Replace ("\n","<br />");
            //ControlUtility.SafeTextBoxAssign(txtFactorJustification, PF.FactorJustification);
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
                        if (hasHRGroupPermission)
                        {
                            if (currentStatus == PDStatus.Review || currentStatus == PDStatus.FinalReview)
                            {
                                canEdit = true;
                            }
                        }
                    }
                }
            }

            return canEdit;
        }
        #endregion

        #region [ Even Handlers ]
        void btnSave_Click(object sender, EventArgs e)
        {
            string language = String.Empty;
            string existinglanguage = string.Empty;
            string newlanguage = string.Empty;
            string radlanguagecontentcleaned = string.Empty;
            PDStatus currentPDStatus = base.CurrentPD.GetCurrentPDStatus();

            if (!String.IsNullOrEmpty(PF.Language))
            {
                language = PF.Language;
            }
            existinglanguage = language;
            //radeditor inserts extra '\r' and '\n' along with <br />
            //therefore replacing <br /> to '' to save it to db so that it does not create extra new line
            //saving radeditor's text because if user formats the text,it will insert
            //html tags with content. Don't want to save html tags in the database 
            radlanguagecontentcleaned = RadEditFactorLanguage.Text;
            newlanguage = radlanguagecontentcleaned;
            int intcompare = string.Compare(existinglanguage, newlanguage, true);
            //int intcompare = string.Compare(PF.Language, this.txtFactorLanguage.Text, true);
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
            PF.Language = radlanguagecontentcleaned;//this.txtFactorLanguage.Text;
            PF.Reviewed = this.chkReviewed.Checked;
            //saving radeditor's text because if user formats the text,it will insert
            //html tags with content. Don't want to save html tags in the database 
            PF.FactorJustification = RadEditFactorJustification.Text;//this.txtFactorJustification.Text;
            PF.UpdatedByID = base.CurrentUser.UserID;
            PF.UpdateDate = DateTime.Now;
            PF.Update();

            // update grid row background
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