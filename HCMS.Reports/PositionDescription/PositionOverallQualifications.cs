namespace HCMS.Reports.PositionDescription
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for PositionOverallQualifications.
    /// </summary>
    public partial class PositionOverallQualifications : Telerik.Reporting.Report
    {
        public PositionOverallQualifications()
        {
            /// <summary>
            /// Required for telerik Reporting designer support
            /// </summary>
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

            // TODO: This line of code loads data into the 'pDExpressDataSetPositionQual.PDExpressDataSetPositionQualTable' table. You can move, or remove it, as needed.
            try
            {
                this.pdExpressDataSetPositionQualTableAdapter1.Fill(this.pDExpressDataSetPositionQual.PDExpressDataSetPositionQualTable);
                this.groupHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Pixel(1);
                this.detail.Height = Telerik.Reporting.Drawing.Unit.Pixel(1);

            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
