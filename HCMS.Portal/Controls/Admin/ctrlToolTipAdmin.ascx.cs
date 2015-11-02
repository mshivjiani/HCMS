using System;
using System.Collections.Generic;
using lookups= HCMS.Business.Lookups;
using Telerik.Web.UI;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCMS.Portal.Controls.Admin
{
    public partial class ctrlToolTipAdmin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private List<lookups.ToolTip> GetAllToolTips()
        {
          return lookups.LookupManager.GetAllToolTips();
        }
        protected void rgToolTip_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            rgToolTip.DataSource = GetAllToolTips();
        }

        protected void rgToolTip_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case RadGrid.UpdateCommandName:
                    UpdateToolTip(sender, e);
                    break;
                case RadGrid.PerformInsertCommandName:
                    AddToolTip(sender, e);
                    break;

                default:
                    break;
            }
        }

        private void AddToolTip(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            lookups.ToolTip tooltip = new lookups.ToolTip();
            AssignToolTip(tooltip, e);
            tooltip.Add();

            
        }
        private void UpdateToolTip(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            lookups.ToolTip tooltip = new lookups.ToolTip();
            AssignToolTip(tooltip, e);
            tooltip.Update();
        }

        private void AssignToolTip(lookups.ToolTip tooltip, GridCommandEventArgs e)
        {
            GridEditFormItem editform = (GridEditFormItem)e.Item;
            Label lblid=editform.FindControl ("lblID") as Label;
            TextBox txtcaption=editform.FindControl ("txtCaption") as TextBox ;
            TextBox txtdescription=editform.FindControl ("txtDescription") as TextBox ;
            TextBox txtscreen =editform.FindControl ("txtScreen") as TextBox ;

            
            string caption=txtcaption.Text;
            string description=txtdescription.Text ;
            string screen =txtscreen.Text ;
            if (e.CommandName == RadGrid.UpdateCommandName)
            {
                int id = int.Parse(lblid.Text);
                tooltip.ToolTipID = id;
            }

            tooltip.ToolTipCaption = caption;
            tooltip.ToolTipDescription = description;
            tooltip.ToolTipScreen = screen;

        }
        protected void imgExcel_Click(object sender, ImageClickEventArgs e)
        {
            rgToolTip.MasterTableView.ExportToExcel();
        }
    }
}