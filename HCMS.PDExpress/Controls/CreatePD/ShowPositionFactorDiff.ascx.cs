using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Data;
using Telerik.Web.UI.Editor.Diff;
using Telerik.Web.UI;

using HCMS.Business.PD;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;

namespace HCMS.PDExpress.Controls.CreatePD
{
    public partial class ShowPositionFactorDiff : CreatePDUserControlBase
    {
        protected override void OnLoad(EventArgs e)
        {
            bindGrid();
            //rgFactorDiffGrid.ExportSettings.FileName = Server.HtmlEncode("ShowDifference" + PD.PositionDescriptionID.ToString());
            base.OnLoad(e);
        }

        protected void GoBack(object sender, EventArgs e)
        {
            SafeRedirect(String.Format("~/CreatePD/Factors.aspx{0}", Request.UrlReferrer.Query));
        }

        #region rgFactorDiffGrid Events
        private void bindGrid()
        {
            this.rgFactorDiffGrid.DataSource = PD.GetPositionFactorDiff();
            this.rgFactorDiffGrid.DataBind();
        }
        protected void rgFactorDiffGrid_PreRender(object sender, EventArgs e)
        {
            DataTable dt = (System.Data.DataTable)(this.rgFactorDiffGrid.DataSource);
            if (dt.Rows.Count > 0)
            {
                string datasourceofLanguage = dt.Rows[0].ItemArray[8].ToString();

                foreach (GridColumn column in rgFactorDiffGrid.Columns)
                {
                    if (column.UniqueName == "ELanguage")
                    {
                        (column as GridBoundColumn).ReadOnly = true;
                        (column as GridBoundColumn).HeaderText = string.Format("Language pre populated from {0}", datasourceofLanguage);
                        break;
                    }
                }
                rgFactorDiffGrid.Rebind();
            }
            else
            {
                base.PrintMessage("No standard language is available for this Job Series.  All language is new.", true, false);
            }
        }

        protected void rgFactorDiffGrid_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            System.Data.DataTable dt = (System.Data.DataTable)(this.rgFactorDiffGrid.DataSource);

            if (dt.Rows.Count > 0)
            {
                string msg = (dt.Rows[0].ItemArray[8].ToString());


                if ((e.Item.ItemType == GridItemType.Item) || (e.Item.ItemType == GridItemType.AlternatingItem))
                {
                    HtmlGenericControl divdd = e.Item.FindControl("divDiff") as HtmlGenericControl;
                    GridDataItem currentitem = e.Item as GridDataItem;

                    string currentlang = currentitem["CLanguage"].Text;

                    string feslang = currentitem["ELanguage"].Text;

                    string divtext = Compare(feslang, currentlang);

                    string divtext1 = divtext.Replace("class=\"diff_deleted\"", "style='color: red;text-decoration:line-through; font-weight: bold;'");
                    string divtext2 = divtext1.Replace("class=\"diff_new\"", "style='background-color: #FFFF00;'");
                    divdd.InnerHtml = divtext2;

                    // ---------------

                    DataRow dr = (e.Item.DataItem as DataRowView).Row;

                    if (Convert.ToInt32(dr["ELevelID"]) != -1)
                    {
                        Label lblELevelID = e.Item.FindControl("lblELevelID") as Label;
                        lblELevelID.Text = dr["ELevelID"].ToString();
                    }

                    if (dr["EPoint"] != DBNull.Value && (Convert.ToInt32(dr["EPoint"]) != -1))
                    {
                        Label lblEPoint = e.Item.FindControl("lblEPoint") as Label;
                        lblEPoint.Text = dr["EPoint"].ToString();
                    }

                    if (Convert.ToInt32(dr["CLevelID"]) != -1)
                    {
                        Label lblCLevelID = e.Item.FindControl("lblCLevelID") as Label;
                        lblCLevelID.Text = dr["CLevelID"].ToString();
                    }

                    if (dr["CPoint"] != DBNull.Value && Convert.ToInt32(dr["CPoint"]) != -1)
                    {
                        Label lblCPoint = e.Item.FindControl("lblCPoint") as Label;
                        lblCPoint.Text = dr["CPoint"].ToString();
                    }
                }
                else if (e.Item is GridCommandItem)
                {
                    GridCommandItem commandItem = e.Item as GridCommandItem;
                    Literal litmsg = commandItem.FindControl("litmsg") as Literal;
                    if (litmsg != null)
                    {
                        litmsg.Text = string.Format("Current Position Description : {0}", PD.PositionDescriptionID.ToString());
                    }
                }
            }
        }
        #endregion

        #region private prop
        private PositionDescription PD
        {
            get
            {
                PositionDescription pd = new PositionDescription();
                long id;
                if (Page.Request.QueryString["PDID"] != null)
                {
                    id = long.Parse(Page.Request.QueryString["PDID"]);
                    pd = new PositionDescription(id);
                }
                else
                {
                    pd = base.CurrentPD;
                }
                return pd;
            }
        }
        #endregion

        public string Compare(string currenttext, string oldvalue)
        {
            string DiffContent = string.Empty;
            DiffEngine diff = new DiffEngine();
            return DiffContent = diff.GetDiffs(oldvalue, currenttext);
        }

        protected void ExportToWord_OnClick(object sender, System.EventArgs e)
        {
            rgFactorDiffGrid.Page.Response.ClearHeaders();
            rgFactorDiffGrid.Page.Response.Cache.SetCacheability(HttpCacheability.Private);
            rgFactorDiffGrid.ExportSettings.FileName = Server.HtmlEncode("ShowDifference" + PD.PositionDescriptionID.ToString());

           
        }
    }
}