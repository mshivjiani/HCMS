namespace HCMS.JNP.Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for JobQuestionnaireSubReport.
    /// </summary>
    public partial class JobQuestionnaireSubReport : Telerik.Reporting.Report
    {
        public JobQuestionnaireSubReport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        private void JobQuestionnaireSubReport_NeedDataSource(object sender, EventArgs e)
        {
            long jnpid = Convert.ToInt64(this.ReportParameters["jNPID"].Value);
            
            

        }           
    }
}