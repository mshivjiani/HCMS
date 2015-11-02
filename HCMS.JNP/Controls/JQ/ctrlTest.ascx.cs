using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.Business.JQ;
using HCMS.WebFramework.BaseControls;
using Telerik.Web.UI;
namespace HCMS.JNP.Controls.JQ
{
    public partial class ctrlTest : JNPUserControlBase
    {
        JQManager jqm = new JQManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { BindData(); }
        }
        private void BindData()
        {

            rgFactors.DataSource = jqm.GetJQFactorByJQID(base.CurrentJQID);
            rgFactors.DataBind();
        }

        protected void rgFactors_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            rgFactors.DataSource = jqm.GetJQFactorByJQID(base.CurrentJQID);
        }

        protected void rgFactors_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            GridItem item = e.Item as GridItem;
            switch (e.CommandName)
            {
                case "moveup":

                    break;
                case "movedown":
                    break;
                default:
                    break;
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

        protected void rgFactors_ItemDataBound(object sender, GridItemEventArgs e)
        {
            HideRefreshButton(e);
            if (e.Item is GridDataItem)
            {
                GridDataItem item = e.Item as GridDataItem;
                Image imgup = item.FindControl("imgUp") as Image;
                imgup.Attributes.Add("onclick", "moveUp('" + item.ItemIndex + "')");
            }
        }
    }
}