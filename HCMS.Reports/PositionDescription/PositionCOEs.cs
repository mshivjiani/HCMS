namespace HCMS.Reports.PositionDescription
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for PositionCOEs
    /// </summary>
    public partial class PositionCOEs : Telerik.Reporting.Report
    {
        public PositionCOEs()
        {
            /// <summary>
            /// Required for telerik Reporting designer support
            /// </summary>
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

            //try
            //{
                this.pdExpressDataSetCOEsTableAdapter1.Fill(pdExpressDataSetCOEs1.PDExpressDataSetCOEsTable);
                this.groupHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Pixel(1);
                this.detail.Height = Telerik.Reporting.Drawing.Unit.Pixel(1);

            //}
            //catch (System.Exception ex)
            //{
            //    // An error has occurred while filling the data set. Please check the exception for more information.
            //    System.Diagnostics.Debug.WriteLine(ex.Message);
            //}
        }

        private void report_NeedDataSource(object sender, EventArgs e)
        {
            //this.pdExpressDataSetCOEsTableAdapter1.Fill(this.pdExpressDataSetCOEs1.PDExpressDataSetCOEsTable);
        }




    }
}
