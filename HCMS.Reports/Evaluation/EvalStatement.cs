namespace HCMS.Reports.Evaluation
{
    using System;
    using Telerik.Reporting;
    using Telerik.Reporting.Processing;
    using TProcessing = Telerik.Reporting.Processing;
    /// <summary>
    /// Summary description for EvalStatement.
    /// </summary>
    public partial class EvalStatement : Telerik.Reporting.Report
    {
        public EvalStatement()
        {
            /// <summary>
            /// Required for telerik Reporting designer support
            /// </summary>
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

            // TODO: This line of code loads data into the 'pDExpressDataSetEvalStatement.PDExpressDataSetEvalStatementTable' table. You can move, or remove it, as needed.
            try
            {
                this.pdExpressDataSetEvalStatementTableAdapter1.Fill(this.pDExpressDataSetEvalStatement.PDExpressDataSetEvalStatementTable);

                AddShowFactorJustificationParameter();
            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void AddShowFactorJustificationParameter()
        {
            try
            {
                string visible = "Yes";

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

        private void subReportFESFactors_ItemDataBound(object sender, EventArgs e)
        {
            showHideSubReport(sender, e, "detail");
        }

        private void subReportGSSGFactors_ItemDataBound(object sender, EventArgs e)
        {
            showHideSubReport(sender, e, "detail");
        }

        private void subReportNarrativeFactors_ItemDataBound(object sender, EventArgs e)
        {
            showHideSubReport(sender, e, "detail");
        }

        private void subReportNarrativeSupFactors_ItemDataBound(object sender, EventArgs e)
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