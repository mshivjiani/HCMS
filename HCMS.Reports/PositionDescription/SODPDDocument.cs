namespace HCMS.Reports.PositionDescription
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for SODPDDocument.
    /// </summary>
    public partial class SODPDDocument : Telerik.Reporting.Report
    {
        public SODPDDocument()
        {
            /// <summary>
            /// Required for telerik Reporting designer support
            /// </summary>
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

            // TODO: This line of code loads data into the 'pDExpressDataSet.PDExpressDataSetTable' table. You can move, or remove it, as needed.
            try
            {
                this.pdExpressDataSetTableAdapter1.Fill(this.pDExpressDataSet.PDExpressDataSetTable);
            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}