namespace HCMS.Reports.CareerLadderDocuments
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for PDComments.
    /// </summary>
    public partial class PDComments : Telerik.Reporting.Report
    {
        public PDComments()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            getCareerLadderBundle();
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
        private void PDComments_NeedDataSource(object sender, EventArgs e)
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
                this.pdTableAdapter.Fill(this.clpdDataSet.PDTable, pdid);
                this.tablePDDetails.DataSource = this.clpdDataSet.PDTable.DefaultView;
                this.subrptWorkflowNotes.ReportSource.Parameters["PDID"].Value = pdid;
                this.subrptFESRecomm.ReportSource.Parameters["PDID"].Value = pdid;
                this.subrptFESRecomm.ReportSource.Parameters["FactorFormatTypeID"].Value = 1;
                this.subrptGSSGRecomm.ReportSource.Parameters["PDID"].Value = pdid;
                this.subrptGSSGRecomm.ReportSource.Parameters["FactorFormatTypeID"].Value = 2;
                this.subrptNarrativeRecomm.ReportSource.Parameters["PDID"].Value = pdid;
                this.subrptNarrativeRecomm.ReportSource.Parameters["FactorFormatTypeID"].Value = 3;
                this.subrptNarrativeSupRecomm.ReportSource.Parameters["PDID"].Value = pdid;
                this.subrptNarrativeSupRecomm.ReportSource.Parameters["FactorFormatTypeID"].Value = 4;


                //this.subrptWorkflowNotes.ReportSource.ReportParameters["PDID"].Value = pdid;
                //this.subrptFESRecomm.ReportSource.ReportParameters["PDID"].Value = pdid;
                //this.subrptFESRecomm.ReportSource.ReportParameters["FactorFormatTypeID"].Value = 1;
                //this.subrptGSSGRecomm.ReportSource.ReportParameters["PDID"].Value = pdid;
                //this.subrptGSSGRecomm.ReportSource.ReportParameters["FactorFormatTypeID"].Value = 2;
                //this.subrptNarrativeRecomm.ReportSource.ReportParameters["PDID"].Value = pdid;
                //this.subrptNarrativeRecomm.ReportSource.ReportParameters["FactorFormatTypeID"].Value = 3;
                //this.subrptNarrativeSupRecomm.ReportSource.ReportParameters["PDID"].Value = pdid;
                //this.subrptNarrativeSupRecomm.ReportSource.ReportParameters["FactorFormatTypeID"].Value = 4;

            }
        }

        private void subrptWorkflowNotes_ItemDataBound(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.SubReport subReport = (Telerik.Reporting.Processing.SubReport)sender;
            subReport.Visible = Telerik.Reporting.Processing.ElementTreeHelper.FindChildByName(subReport, "groupHeaderSection1", true).Length > 0;
            //subReport.Visible = subReport.ChildElements.Find("groupHeaderSection1", true).Length > 0;

        }

        private void subrptFESRecomm_ItemDataBound(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.SubReport subReport = (Telerik.Reporting.Processing.SubReport)sender;
            subReport.Visible = subReport.ChildElements.Find("groupHeaderSection1", true).Length > 0;

        }

        private void subrptGSSGRecomm_ItemDataBound(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.SubReport subReport = (Telerik.Reporting.Processing.SubReport)sender;
            subReport.Visible = subReport.ChildElements.Find("groupHeaderSection1", true).Length > 0;

        }

        private void subrptNarrativeRecomm_ItemDataBound(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.SubReport subReport = (Telerik.Reporting.Processing.SubReport)sender;
            subReport.Visible = subReport.ChildElements.Find("groupHeaderSection1", true).Length > 0;

        }

        private void subrptNarrativeSupRecomm_ItemDataBound(object sender, EventArgs e)
        {
            Telerik.Reporting.Processing.SubReport subReport = (Telerik.Reporting.Processing.SubReport)sender;
            subReport.Visible = subReport.ChildElements.Find("groupHeaderSection1", true).Length > 0;

        }

    }
}