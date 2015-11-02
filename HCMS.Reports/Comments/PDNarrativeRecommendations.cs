namespace HCMS.Reports.Comments
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using HCMS.Reports.PDFactorRecommendationsTableAdapters;


    /// <summary>
    /// Summary description for PDNarrativeRecommendations.
    /// </summary>
    public partial class PDNarrativeRecommendations : Telerik.Reporting.Report
    {
        public PDNarrativeRecommendations()
        {
            /// <summary>
            /// Required for telerik Reporting designer support
            /// </summary>
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void PDNarrativeRecommendations_NeedDataSource(object sender, EventArgs e)
        {
            try
            {
                long pdid = Convert.ToInt64(this.ReportParameters["PDID"].Value);
                int factorformattypeid = Convert.ToInt32(this.ReportParameters["FactorFormatTypeID"].Value);
                PDFactorRecommendationTableAdapter adapter = new PDFactorRecommendationTableAdapter();
                PDFactorRecommendations.PDFactorRecommendationTableDataTable dt = new PDFactorRecommendations.PDFactorRecommendationTableDataTable();
                dt = adapter.GetData(pdid, factorformattypeid);
                ((Telerik.Reporting.Processing.Report)sender).DataSource = dt.DefaultView;
            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

        }
    }
}