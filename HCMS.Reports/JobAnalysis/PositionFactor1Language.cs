namespace HCMS.Reports.JobAnalysis
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using HCMS.Reports;

    /// <summary>
    /// Summary description for PositionFactor1Language.
    /// </summary>
    public partial class PositionFactor1Language : Telerik.Reporting.Report
    {
        public PositionFactor1Language()
        {
            /// <summary>
            /// Required for telerik Reporting designer support
            /// </summary>
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

            // TODO: This line of code loads data into the 'pDExpressDataSetPositionFactor1Lang.PDExpressDataSetPositionFactor1LangTable' table. You can move, or remove it, as needed.
            try
            {
                this.pdExpressDataSetPositionFactor1LangTableAdapter1.Fill(this.pDExpressDataSetPositionFactor1Lang.PDExpressDataSetPositionFactor1LangTable);
            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}