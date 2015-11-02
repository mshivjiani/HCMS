using System;
using System.Data;
using HCMS.Business.PD;
using Telerik.Web.UI.Editor.Diff;
using Telerik.Web.UI;
using System.Web.UI.HtmlControls;

using HCMS.WebFramework.BaseControls;
using System.Collections;

namespace HCMS.PDExpress.Controls.CreatePD.Factors
{
    public partial class PositionFactorReview : CreatePDUserControlBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                BindGrid();
                rgPositionFactorComp.ExportSettings.FileName = ExportFileName;

            }
        }



        #region "Private Properties"
        private int currPFID
        {
            get
            {
                int positionFactorID = -1;
                if (ViewState["currPFID"] == null)
                {

                    if (!String.IsNullOrEmpty(Request["PositionFactorID"]))
                    {
                        positionFactorID = int.Parse(Page.Request.QueryString["PositionFactorID"]);
                    }
                    ViewState["currPFID"] = positionFactorID;
                }
                return (int)(ViewState["currPFID"]);
            }

        }
        private string currFactorTitle
        {
            get
            {
                string factortitle = string.Empty;
                if (ViewState["currFactorTitle"] == null)
                {
                    if (!string.IsNullOrEmpty(Request["FactorTitle"]))
                    {
                        factortitle = Page.Request.QueryString["FactorTitle"].ToString();
                    }
                    ViewState["currFactorTitle"] = factortitle;
                }
                return ViewState["currFactorTitle"].ToString();
            }
        }

        private DataTable dtPFComp
        {
            get
            {
                PositionFactor PF = new PositionFactor(currPFID);
                DataTable dt = PF.GetPositionFactorComparision();
                return dt;
            }
        }
        private string ExportFileName
        {
            get
            {
                PositionFactor PF = new PositionFactor(currPFID);
                return Server.HtmlEncode(string.Format("{0}-{1}", PF.PositionDescriptionID.ToString(), "ReviewChanges"));
            }
        }
        #endregion

        #region "Private Methods"
        private string Compare(string currenttext, string oldvalue)
        {
            string DiffContent = string.Empty;
            DiffEngine diff = new DiffEngine();
            return DiffContent = diff.GetDiffs(oldvalue, currenttext);
        }

        private void BindGrid()
        {



            DataTable dt = dtPFComp;
            if (dt.Rows.Count > 0)
            {
                rgPositionFactorComp.DataSource = dt;
                rgPositionFactorComp.DataBind();
            }
            else
            {
                base.PrintMessage("There is no existing language to compare.", true, false);
            }


        }

        #endregion

        #region "Grid Events"
        protected void rgPositionFactorComp_ItemDataBound(object sender, GridItemEventArgs e)
        {

            System.Data.DataTable dt = (System.Data.DataTable)(this.rgPositionFactorComp.DataSource);

            if (dt.Rows.Count > 0)
            {
                if ((e.Item.ItemType == GridItemType.Item) || (e.Item.ItemType == GridItemType.AlternatingItem))
                {
                    HtmlGenericControl divdd = e.Item.FindControl("divDiff") as HtmlGenericControl;

                    GridDataItem currentitem = e.Item as GridDataItem;
                    int factorformattypeid = 0;
                    if (currentitem["CurrentFactorFormatTypeID"].Text.Length > 0)
                    {
                        factorformattypeid = int.Parse(currentitem["CurrentFactorFormatTypeID"].Text);


                        if (factorformattypeid == 3 || factorformattypeid == 4)
                        {
                            currentitem["WorkflowFactorLevel"].Text = string.Empty;
                            currentitem["CurrentFactorLevel"].Text = string.Empty;
                        }
                    }
                    string currentlang = currentitem["CurrentLanguage"].Text;

                    string workflowlang = currentitem["WorkflowLanguage"].Text;

                    string divtext = Compare(workflowlang, currentlang);

                    string divtext1 = divtext.Replace("class=\"diff_deleted\"", "style='color: red;text-decoration:line-through; font-weight: bold;'");
                    string divtext2 = divtext1.Replace("class=\"diff_new\"", "style='background-color: #FFFF00;'");
                    divdd.InnerHtml = divtext2;




                }
            }
        }

        protected void rgPositionFactorComp_ItemCommand(object source, GridCommandEventArgs e)
        {
            System.Data.DataTable dt = dtPFComp;
            DataRow dr = dt.Rows[0];
            PositionFactor PF = new PositionFactor(currPFID);

            enumFactorFormatType currentfactorformattype = (enumFactorFormatType)PF.FactorFormatTypeID;

            switch (e.CommandName)
            {
                case "Accept":
                    if (currentfactorformattype == enumFactorFormatType.FES || currentfactorformattype == enumFactorFormatType.GSSG)
                    {
                        PF.FactorLevel = (int)dr["CurrentFactorLevelID"];
                        PF.Point = (int)dr["CurrentPoint"];
                    }
                    PF.Language = dr["CurrentLanguage"].ToString();
                    PF.Reviewed = true;
                    PF.RecommendationNote = dr["CurrentRecommendationNote"].ToString();
                    PF.FactorJustification = dr["CurrentFactorJustification"].ToString();
                    PF.UpdatedByID = base.CurrentUser.UserID;
                    PF.UpdateDate = DateTime.Now;
                    PF.Update();
                    this.BindGrid();
                    break;
                case "Reject":
                    if (currentfactorformattype == enumFactorFormatType.FES || currentfactorformattype == enumFactorFormatType.GSSG)
                    {

                        PF.FactorLevel = (int)dr["WorkflowFactorLevelID"];
                        PF.Point = (int)dr["WorkflowPoint"];
                    }
                    PF.Language = dr["WorkflowLanguage"].ToString();
                    PF.Reviewed = true;
                    PF.RecommendationNote = dr["CurrentRecommendationNote"].ToString();
                    PF.FactorJustification = dr["CurrentFactorJustification"].ToString();
                    PF.UpdatedByID = base.CurrentUser.UserID;
                    PF.UpdateDate = DateTime.Now;
                    PF.Update();
                    this.BindGrid();

                    string strurl = Page.ResolveUrl(string.Format("~/Controls/CreatePD/Factors/FactorLanguagePopup.aspx?PositionFactorID={0}&FactorTitle={1}", currPFID, currFactorTitle));
                    this.lblClose.Text = "<script type='text/javascript'>FactorReviewSaveClose()</script>";
                    break;
            }

        }

        //protected void btnAccept_Click(object sender, EventArgs e)
        //{

        //    System.Data.DataTable dt = dtPFComp;
        //    DataRow dr = dt.Rows[0];
        //    PositionFactor PF = new PositionFactor(currPFID);

        //    enumFactorFormatType currentfactorformattype = (enumFactorFormatType)PF.FactorFormatTypeID;

        //    if (currentfactorformattype == enumFactorFormatType.FES || currentfactorformattype == enumFactorFormatType.GSSG)
        //    {
        //        PF.FactorLevel = (int)dr["CurrentFactorLevelID"];
        //        PF.Point = (int)dr["CurrentPoint"];
        //    }
        //    PF.Language = dr["CurrentLanguage"].ToString();
        //    PF.Reviewed = true;
        //    PF.RecommendationNote = dr["CurrentRecommendationNote"].ToString();
        //    PF.FactorJustification = dr["CurrentFactorJustification"].ToString();
        //    PF.UpdatedByID = base.CurrentUser.UserID;
        //    PF.UpdateDate = DateTime.Now;
        //    PF.Update();

        //    //rgPositionFactorComp.Rebind();
        //}

        protected void ExportToWord_OnClick(object sender, System.EventArgs e)
        {

            rgPositionFactorComp.ExportSettings.FileName = ExportFileName;


        }

        protected void rgPositionFactorComp_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
        {
            DataTable dt = dtPFComp;
            if (dt.Rows.Count > 0)
            {
                rgPositionFactorComp.DataSource = dt;
            }
        }

        #endregion
    }


}