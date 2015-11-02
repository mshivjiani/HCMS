namespace HCMS.Reports.CareerLadderDocuments
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for EvalStatement.
    /// </summary>
    public partial class EvalStatement : Telerik.Reporting.Report
    {
        public EvalStatement()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
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

        private void EvalStatement_NeedDataSource(object sender, EventArgs e)
        {
            getCareerLadderBundle();
            ((Telerik.Reporting.Processing.Report)sender).DataSource = this.clpdDataSet.CLPDTable.DefaultView;
        }

        private void detail_ItemDataBinding(object sender, EventArgs e)
        {
            // Get the detail section object from sender
            Telerik.Reporting.Processing.DetailSection section = (Telerik.Reporting.Processing.DetailSection)sender;
            // From the section object get the current DataRow
            Telerik.Reporting.Processing.IDataObject dataObject = (Telerik.Reporting.Processing.IDataObject)section.DataObject;
            object rowdata = (object)section.DataObject.RawData;
            if ((dataObject["PositionDescriptionID"] != null) && (dataObject["PositionDescriptionID"].ToString().Length != 0))
            {
                long pdid = Convert.ToInt64(dataObject["PositionDescriptionID"]);

                InstanceReportSource subrptPDTable = new InstanceReportSource();
                subrptPDTable = (InstanceReportSource)this.subrptPDTable.ReportSource;
                subrptPDTable.Parameters["PositionDescriptionID"].Value = pdid;
                subrptPDTable.Parameters["ShowEvalRows"].Value = "Yes";

                InstanceReportSource subrptFesFactors = new InstanceReportSource();
                subrptFesFactors = (InstanceReportSource)this.subrptFesFactors.ReportSource;
                subrptFesFactors.Parameters["FESFactorsPDID"].Value = pdid;

                InstanceReportSource subrptGssgFactors = new InstanceReportSource();
                subrptGssgFactors = (InstanceReportSource)this.subrptGssgFactors.ReportSource;
                subrptGssgFactors.Parameters["GSSGFactorsPDID"].Value = pdid;

                InstanceReportSource subrptNarrativeFactors = new InstanceReportSource();
                subrptNarrativeFactors = (InstanceReportSource)this.subrptNarrativeFactors.ReportSource;
                subrptNarrativeFactors.Parameters["NFactorsPDID"].Value = pdid;

                InstanceReportSource subrptNarrativeSupFactors = new InstanceReportSource();
                subrptNarrativeSupFactors = (InstanceReportSource)this.subrptNarrativeSupFactors.ReportSource;
                subrptNarrativeSupFactors.Parameters["NSPDID"].Value = pdid;                                    

            }
        }

        private void subrptFesFactors_ItemDataBound(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.SubReport subReport = (Telerik.Reporting.Processing.SubReport)sender;
            subReport.Visible = Telerik.Reporting.Processing.ElementTreeHelper.FindChildByName(subReport, "detail", true).Length > 0;

        }

        private void subrptGssgFactors_ItemDataBound(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.SubReport subReport = (Telerik.Reporting.Processing.SubReport)sender;
            subReport.Visible = Telerik.Reporting.Processing.ElementTreeHelper.FindChildByName(subReport, "detail", true).Length > 0;
        }

        private void subrptNarrativeFactors_ItemDataBound(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.SubReport subReport = (Telerik.Reporting.Processing.SubReport)sender;
            subReport.Visible = Telerik.Reporting.Processing.ElementTreeHelper.FindChildByName(subReport, "detail", true).Length > 0;

        }

        private void subrptNarrativeSupFactors_ItemDataBound(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.SubReport subReport = (Telerik.Reporting.Processing.SubReport)sender;
            subReport.Visible = Telerik.Reporting.Processing.ElementTreeHelper.FindChildByName(subReport, "detail", true).Length > 0;
        }
    }
}