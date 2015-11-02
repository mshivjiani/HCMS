using System;
using System.Web.UI;
using Telerik.Web.UI;
using System.Data;
using HCMS.WebFramework.BaseControls;

using HCMS.Business.SSAS;
using System.Configuration;
namespace HCMS.Portal.Controls.Admin
{
    public partial class ctrlSSASRoles : UserControlBase 
    {
        protected AnalyisServicesRoleManager GetSSASRoleManager()
        {
            //not putting _ssasmgr in viewstate as MicrosoftAnalysisServices.Server is not serializable
            //so if we put this instance in viewstate it will throw seriealization error.
            AnalyisServicesRoleManager _ssasmgr = null;


            string ssasInstance = string.Empty;
            string ssasDB = string.Empty;
            string DashboardConnString = string.Empty;
            if (ConfigurationManager.AppSettings["SSASInstanceName"] != null)
            {


                ssasInstance = string.Format("{0}", ConfigurationManager.AppSettings["SSASInstanceName"].ToString());
            }

            if (ConfigurationManager.AppSettings["SSASDB"] != null)
            {
                ssasDB = ConfigurationManager.AppSettings["SSASDB"].ToString();
            }


            if (ConfigurationManager.AppSettings["WFPDashboardConnString"] != null)
            {
                DashboardConnString = ConfigurationManager.AppSettings["WFPDashboardConnString"].ToString();
            }

            if (!string.IsNullOrEmpty(ssasInstance) && !string.IsNullOrEmpty(ssasDB) && !string.IsNullOrEmpty(DashboardConnString))
            {
                _ssasmgr = new AnalyisServicesRoleManager(ssasInstance, ssasDB, DashboardConnString);

            }
            else
            {
                throw new ApplicationException("SSAS Role Manager could not be created.");
            }


            return _ssasmgr;


        }
        private void BindSSASRoles()
        {
            DataTable dt = new DataTable();
            AnalyisServicesRoleManager ssasmgr = GetSSASRoleManager();
            dt = ssasmgr.GetRoleMembers();

            rgSSASRoles.DataSource = dt;


        }

        protected void rgSSASRoles_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            BindSSASRoles();
        }

        protected void imgPdf_Click(object sender, ImageClickEventArgs e)
        {
            rgSSASRoles.MasterTableView.ExportToPdf();
        }

        protected void imgExcel_Click(object sender, ImageClickEventArgs e)
        {
            rgSSASRoles.MasterTableView.ExportToExcel();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}