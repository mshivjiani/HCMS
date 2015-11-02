using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BasePages;
using System.Diagnostics;
using System.Data;
using HCMS.Business.Admin.Workforce;

namespace HCMS.Portal.Admin
{
    public partial class OrgChart : AdminPageBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.TopMenu = enumTopMenuType.AdminMenu;

            base.PageTitle = "Organization Chart";

            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Process p = new Process();
            //p.StartInfo.FileName = "C:\\Test\\OrganizationChartWPFDemo\\bin\\Debug\\OrganizationChartWPFDemo.exe";

            //p.Start();

        }




        public DataTable CreateOrgChart()
        {

            OrgChartManager oc = new OrgChartManager();
            DataTable dt = oc.GetOrgChartData();

            return dt;

        }

        [System.Web.Services.WebMethod()]
        public static DataTable GetOrgChart()
        {

            OrgChartManager oc = new OrgChartManager();
            DataTable dt = oc.GetOrgChartData();

            return dt;

        }

        [System.Web.Services.WebMethod()]
        public string GetOrgChartData()
        {
            String daresult = null;
            DataTable yourDatable = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(CreateOrgChart());
            daresult = DataSetToJSON(CreateOrgChart());
            return daresult;
        }


        public string DataSetToJSON(DataTable dt)
        {

            Dictionary<string, object> dict = new Dictionary<string, object>();
            //foreach (DataTable dt in ds.Tables)
            //{
                object[] arr = new object[dt.Rows.Count + 1];

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    arr[i] = dt.Rows[i].ItemArray;
                }

                dict.Add(dt.TableName, arr);
            //}

            System.Web.Script.Serialization.JavaScriptSerializer json = new System.Web.Script.Serialization.JavaScriptSerializer();
            return json.Serialize(dict);
        }
    }
}