namespace HCMS.Reports.CareerLadderDocuments
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using Telerik.Reporting.Processing;
    using HCMS.Reports.CareerLadderDocuments;
    using HCMS.Business.Common;

    /// <summary>
    /// Summary description for Report1.
    /// </summary>
    public partial class PDDocument : Telerik.Reporting.Report
    {
        public PDDocument()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            AddShowFactorJustificationParameter();

            this.detail.Height = Telerik.Reporting.Drawing.Unit.Pixel(1);
        }
        private void AddShowFactorJustificationParameter()
        {
            try
            {
                string visible = "0";

                #region [ add ShowFactorJustification parameter to FES Factors sub-report ]
                Telerik.Reporting.Report rptFESFactors = pdfesFactors1;
                if (rptFESFactors != null)
                {
                    rptFESFactors.ReportParameters.Add("ShowFactorJustification", ReportParameterType.String, visible);
                    
                }
                #endregion

                #region [ add ShowFactorJustification parameter to GSSG Factors sub-report ]
                Telerik.Reporting.Report rptGSSGFactors = pdgssgFactors1;
                if (rptGSSGFactors != null)
                {
                    rptGSSGFactors.ReportParameters.Add("ShowFactorJustification", ReportParameterType.String, visible);
                }
                #endregion

                #region [ add ShowFactorJustification parameter to Narrative Factors sub-report ]
                Telerik.Reporting.Report rptNarrFactors = pdNarrativeFactors1;
                if (rptNarrFactors != null)
                {
                    rptNarrFactors.ReportParameters.Add("ShowFactorJustification", ReportParameterType.String, visible);
                }
                #endregion

                #region [ add ShowFactorJustification parameter to Narrative supervisory Factors sub-report ]
                Telerik.Reporting.Report rptNarrSupFactors = pdNarrativeSupervisoryFactors1;
                if (rptNarrSupFactors != null)
                {
                    rptNarrSupFactors.ReportParameters.Add("ShowFactorJustification", ReportParameterType.String, visible);
                }
                #endregion
            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        private void PDDocument_NeedDataSource(object sender, EventArgs e)
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
            Telerik.Reporting.Processing.DetailSection section = (Telerik.Reporting.Processing.DetailSection)sender;
            // From the section object get the current DataRow
            Telerik.Reporting.Processing.IDataObject dataObject = (Telerik.Reporting.Processing.IDataObject)section.DataObject;
            object rowdata = (object)section.DataObject.RawData;
            if ((dataObject["PositionDescriptionID"] != null) && (dataObject["PositionDescriptionID"].ToString().Length != 0))
            {

                long pdid = Convert.ToInt64(dataObject["PositionDescriptionID"]);

                this.pdTableAdapter.Fill(this.clpdDataSet.PDTable, pdid);

            }
        }

        private void subrptDuties_ItemDataBound(object sender, EventArgs e)
        {
            showHideSubReport(sender, e, "groupHeaderSection2");
        }

        private void subrptCOEs_ItemDataBound(object sender, EventArgs e)
        {
            showHideSubReport(sender, e, "detail");
        }

        private void subrptOverallQuals_ItemDataBound(object sender, EventArgs e)
        {
            showHideSubReport(sender, e, "detail");
        }

        private void subrptFESFactors_ItemDataBound(object sender, EventArgs e)
        {
            showHideSubReport(sender, e, "detail");
        }

        private void subrptGSSGFactors_ItemDataBound(object sender, EventArgs e)
        {
            showHideSubReport(sender, e, "detail");
        }

        private void subrptNarrativeFactors_ItemDataBound(object sender, EventArgs e)
        {
            showHideSubReport(sender, e, "detail");
        }


        private void subrptNarrativeSup_ItemDataBound(object sender, EventArgs e)
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
