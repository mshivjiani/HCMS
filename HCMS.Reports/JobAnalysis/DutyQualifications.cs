namespace HCMS.Reports.JobAnalysis
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for DutyQualifications.
    /// </summary>
    public partial class DutyQualifications : Telerik.Reporting.Report
    {
        public DutyQualifications()
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
            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void DutyQualifications_NeedDataSource(object sender, EventArgs e)
        {
            try
            {
                int dutyid = Convert.ToInt32(this.ReportParameters["DutyID"].Value);
                this.dutyCompetencyKSATableAdapter1.Fill(this.dutyQualDataSet1.DutyCompetencyKSATable, dutyid);
                ((Telerik.Reporting.Processing.Report)sender).DataSource = dutyQualDataSet1.DutyCompetencyKSATable.DefaultView;
            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}