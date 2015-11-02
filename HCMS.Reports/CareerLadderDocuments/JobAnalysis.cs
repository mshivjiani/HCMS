namespace HCMS.Reports.CareerLadderDocuments
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using TProcessing=Telerik.Reporting.Processing;
    using Telerik.Reporting.Processing;
    /// <summary>
    /// Summary description for JobAnalysis.
    /// </summary>
    public partial class JobAnalysis : Telerik.Reporting.Report
    {
        public JobAnalysis()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
        private void JobAnalysis_NeedDataSource(object sender, EventArgs e)
        {
            getCareerLadderBundle();
            ((Telerik.Reporting.Processing.Report)sender).DataSource = this.clpdDataSet.CLPDTable.DefaultView;

        }
        private void getCareerLadderBundle()
        {
            try
            {

                long pdid = Convert.ToInt64(this.ReportParameters["PositionDescriptionID"].Value);
                System.Diagnostics.Debug.WriteLine(string.Format("PDID:{0}", pdid.ToString()));
                this.clpdTableAdapter.Fill(this.clpdDataSet.CLPDTable, pdid);
                this.pdTableAdapter.Fill(this.clpdDataSet.PDTable, pdid);

            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }



        private void detail_ItemDataBinding(object sender, EventArgs e)
        {
            // Get the detail section object from sender
            TProcessing.DetailSection section = (TProcessing.DetailSection)sender;
            // From the section object get the current DataRow
            TProcessing.IDataObject dataObject = (TProcessing.IDataObject)section.DataObject;
            object rowdata = (object)section.DataObject.RawData;
            if ((dataObject["PositionDescriptionID"] != null) && (dataObject["PositionDescriptionID"].ToString().Length != 0))
            {
                long pdid = Convert.ToInt64(dataObject["PositionDescriptionID"]);
               // this.subrptPDTable.ReportSource.ReportParameters["PositionDescriptionID"].Value = pdid;
                this.pdTableAdapter.Fill(this.clpdDataSet.PDTable, pdid);
            }
        }

        private void subrptDuties_ItemDataBound(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.SubReport subReport = (Telerik.Reporting.Processing.SubReport)sender;
            subReport.Visible = Telerik.Reporting.Processing.ElementTreeHelper.FindChildByName(subReport, "groupHeaderSection2", true).Length > 0;

            //Telerik.Reporting.Processing.SubReport subReport = (Telerik.Reporting.Processing.SubReport)sender;
            //subReport.Visible = subReport.ChildElements.Find("groupHeaderSection2", true).Length > 0;
        }

        private void subrptPFLanguage_ItemDataBound(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.SubReport subReport = (Telerik.Reporting.Processing.SubReport)sender;
            subReport.Visible = Telerik.Reporting.Processing.ElementTreeHelper.FindChildByName(subReport, "detail", true).Length > 0;
            //Telerik.Reporting.Processing.SubReport subReport = (Telerik.Reporting.Processing.SubReport)sender;
            //subReport.Visible = subReport.ChildElements.Find("detail", true).Length > 0;
        }
      

        private void subReportCOEs_ItemDataBound(object sender, EventArgs e)
        {
            showHideSubReport(sender, e, "detail");
        }

        private void subReportPositionOverallQuals_ItemDataBound(object sender, EventArgs e)
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
