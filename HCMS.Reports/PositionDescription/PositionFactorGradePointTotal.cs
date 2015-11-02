namespace HCMS.Reports.PositionDescription
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using Telerik.Reporting.Processing.Expressions;
    using HCMS.Reports.PDGradePointTableAdapters;
    /// <summary>
    /// Summary description for PositionFactorGradePointTotal.
    /// </summary>
    public partial class PositionFactorGradePointTotal : Telerik.Reporting.Report
    {
        public PositionFactorGradePointTotal()
        {
            /// <summary>
            /// Required for telerik Reporting designer support
            /// </summary>
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

            // TODO: This line of code loads data into the 'pDGradePoint.PDGradePointTable' table. You can move, or remove it, as needed.
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Pixel(1);
        }

        private void PositionFactorGradePointTotal_NeedDataSource(object sender, EventArgs e)
        {
            long pdid = (long)this.ReportParameters["PDID"].Value;
            int factorformattypeid = (int)this.ReportParameters["FactorFormatTypeID"].Value;
            PDGradePointTableAdapter adapter = new PDGradePointTableAdapter();
            PDGradePoint.PDGradePointTableDataTable dt = new PDGradePoint.PDGradePointTableDataTable();
            dt = adapter.GetData(pdid, factorformattypeid);
            ((Telerik.Reporting.Processing.Report)sender).DataSource = dt.DefaultView;
        }
    }
}
