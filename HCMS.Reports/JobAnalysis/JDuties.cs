namespace HCMS.Reports.JobAnalysis
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Processing;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for PDDuties.
    /// </summary>
    public partial class JDDuties : Telerik.Reporting.Report
    {
        public JDDuties()
        {
            /// <summary>
            /// Required for telerik Reporting designer support
            /// </summary>
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

            // TODO: This line of code loads data into the 'pDExpressDataSetDuties.PDExpressDataSetDutiesTable' table. You can move, or remove it, as needed.
            try
            {
                this.pdExpressDataSetDutiesTableAdapter1.Fill(this.pDExpressDataSetDuties.PDExpressDataSetDutiesTable);
            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        //Overall Qualifications
        void subReportPositionQual_ItemDataBound(object sender, System.EventArgs e)
        {
            showHideSubReport(sender, e, "detail");
            //Telerik.Reporting.Processing.SubReport subReport = (Telerik.Reporting.Processing.SubReport)sender;
            //Telerik.Reporting.Processing.Report mainReport = (Telerik.Reporting.Processing.Report)subReport.Report;
            //subReport.Visible = Telerik.Reporting.Processing.ElementTreeHelper.FindChildByName(subReport, "detail", true).Length > 0;
         
        }

        private void subReportDutyQual_ItemDataBound(object sender, EventArgs e)
        {
            showHideSubReport(sender, e, "detail");
            //Telerik.Reporting.Processing.SubReport subReport = (Telerik.Reporting.Processing.SubReport)sender;
            //Telerik.Reporting.Processing.Report mainReport = (Telerik.Reporting.Processing.Report)subReport.Report;

            //subReport.Visible = Telerik.Reporting.Processing.ElementTreeHelper.FindChildByName(subReport, "detail", true).Length > 0;

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