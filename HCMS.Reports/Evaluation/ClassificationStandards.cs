namespace HCMS.Reports.Evaluation
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for ClassificationStandards.
    /// </summary>
    public partial class ClassificationStandards : Telerik.Reporting.Report
    {
        public ClassificationStandards()
        {
            /// <summary>
            /// Required for telerik Reporting designer support
            /// </summary>
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

            // TODO: This line of code loads data into the 'pDExpressDataSetStandards.PDExpressDataSetStandardsTable' table. You can move, or remove it, as needed.
            try
            {
                this.pdExpressDataSetStandardsTableAdapter1.Fill(this.pDExpressDataSetStandards.PDExpressDataSetStandardsTable);
            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}