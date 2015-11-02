using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.Admin.Workforce;



namespace HCMS.Portal.Controls.Admin
{
    public partial class ctrlOrgChart : UserControlBase
    {
        int RegionID;
        string OrgCode;
        int ServiceLevel;
        int RegionalLevel;
        int RD;
        int LevelID;

        protected void Page_Load(object sender, EventArgs e)
        {

            CreateOrgChart(RegionID, OrgCode, ServiceLevel, RegionalLevel, RD, LevelID);
        }

        private void CreateOrgChart(int RegionID, string OrgCode, int ServiceLevel, int RegionalLevel, int RD, int LevelID)
        {
           RadOrgChart1.NodeDataBound += new Telerik.Web.UI.OrgChartNodeDataBoundEventHandler(RadOrgChart1_NodeDataBound);

            OrgChartManager oc = new OrgChartManager();

            DataTable dt = oc.GetOrgChartData(1, "", 1, 1, 1,1);
            
            RadOrgChart1.DataFieldID = "PositionID";
            RadOrgChart1.DataFieldParentID = "ParentID";
            RadOrgChart1.DataTextField = "Name";


            RadOrgChart1.DataSource = dt;           
            RadOrgChart1.DataBind();
        }

        void RadOrgChart1_NodeDataBound(object sender, Telerik.Web.UI.OrgChartNodeDataBoundEventArguments e)
        {
            int i = int.Parse(e.Node.ID);

            if (e.Node.Level == 2)
                e.Node.ColumnCount = 1;

            //if (e.Node.ID == "2")

            //    e.Node.ColumnCount = 2;

            //if (e.Node.ID == "3")

            //    e.Node.ColumnCount = 1;

        }

    }
}
