namespace HCMS.JNP.Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Processing;
    using Telerik.Reporting.Drawing;
 

    /// <summary>
    /// Summary description for JobAnalysis.
    /// </summary>
    public partial class JobAnalysis : Telerik.Reporting.Report
    {
        public JobAnalysis()
        {               
            InitializeComponent();      
         
        }

        //private void JobAnalysis_NeedDataSource(object sender, EventArgs e)
        //{
        //    long jnpid = Convert.ToInt64(this.ReportParameters["jNPID"].Value);
        //    this.spr_rptGetJNPByIDTableAdapter1.Fill(jnpDataSet1.spr_rptGetJNPByID, jnpid); 
        //}

        private void subReportCOEs_ItemDataBinding(object sender, EventArgs e)
        {
        }

        private void subReportCOEs_ItemDataBound(object sender, EventArgs e)
        {
            showHideSubReport(sender, e, "detail");
        }

        private void showHideSubReport(object sender, System.EventArgs e, string reportSectionID)
        {
            if (sender is Telerik.Reporting.Processing.SubReport)
            {
                Telerik.Reporting.Processing.SubReport subReport = (Telerik.Reporting.Processing.SubReport)sender;
                //Telerik.Reporting.Processing.Report report = (Telerik.Reporting.Processing.Report)subReport.InnerReport;
                //LayoutElement[] layElem = Telerik.Reporting.Processing.ElementTreeHelper.FindChildByName(report, reportSectionID, true);
                //subReport.Visible = (layElem.Length > 0);

                long iJNPID = HCMS.Business.JNP.JNPManager.jnpid;

                System.Data.DataTable dt = Business.Base.BusinessBase.ExecuteDataTable("spr_GetConditionsOfEmploymentByJNPID", iJNPID);

                subReport.Visible = dt.Rows.Count > 0;

            }

        }

    }
}