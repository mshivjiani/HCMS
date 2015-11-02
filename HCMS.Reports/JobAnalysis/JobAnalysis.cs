namespace HCMS.Reports.JobAnalysis
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Processing;
    using Telerik.Reporting.Drawing;
    using HCMS.Reports.PositionDescription;
    /// <summary>
    /// Summary description for JobAnalysis.
    /// </summary>
    public partial class JobAnalysis : Telerik.Reporting.Report
    {
        public JobAnalysis()
        {
            /// <summary>
            /// Required for telerik Reporting designer support
            /// </summary>
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

            // TODO: This line of code loads data into the 'pDExpressDataSetJobAnalysis.PDExpressDataSetJobAnalysisTable' table. You can move, or remove it, as needed.
            try
            {
                this.pdExpressDataSetJobAnalysisTableAdapter1.Fill(this.pDExpressDataSetJobAnalysis.PDExpressDataSetJobAnalysisTable);
            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }


        }

        // Duties Subreport
        void subReport3_ItemDataBound(object sender, System.EventArgs e)
        {
            showHideSubReport(sender, e, "groupHeaderSection2");
        }

        // Overall Qualifications
        void subReport2_ItemDataBound(object sender, System.EventArgs e)
        {
            showHideSubReport(sender, e, "detail");
        }

        private void subReportCOEs_ItemDataBound(object sender, EventArgs e)
        {
            showHideSubReport(sender, e, "detail");
        }

        private void subReportFactorLang_ItemDataBound(object sender, EventArgs e)
        {
            showHideSubReport(sender, e, "detail");
        }

        private void showHideSubReport(object sender, System.EventArgs e, string reportSectionID)
        {
            if (sender is Telerik.Reporting.Processing.SubReport)
            {
                Telerik.Reporting.Processing.SubReport subReport = (Telerik.Reporting.Processing.SubReport)sender;
                Telerik.Reporting.Processing.Report report = (Telerik.Reporting.Processing.Report)subReport.InnerReport;
                LayoutElement[] layElem = Telerik.Reporting.Processing.ElementTreeHelper.FindChildByName(report, reportSectionID, true);
                subReport.Visible = (layElem.Length > 0);
            }
        }


    }
}