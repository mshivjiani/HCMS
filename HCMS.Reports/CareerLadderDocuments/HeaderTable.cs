namespace HCMS.Reports.CareerLadderDocuments
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for EvalTable.
    /// </summary>
    public partial class HeaderTable : Telerik.Reporting.Report
    {
        public HeaderTable()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            try
            {
                SetEvalRowsVisibility();
            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        private void SetEvalRowsVisibility()
        {
            bool visible = false;
            ReportParameter showEvalRows = this.ReportParameters["ShowEvalRows"];
            if (showEvalRows != null && showEvalRows.Value != null)
            {
                if (string.Equals(showEvalRows.Value.ToString(), "Yes"))
                {
                    visible = true;
                }
            }


            this.lblSeriesJustification.Visible = this.txtSeriesJustification.Visible = visible;
            this.lblTitleJustification.Visible = this.txtTitleJustification.Visible = visible;
            this.lblGradeJustification.Visible = this.txtGradeJustification.Visible = visible;
            this.lblAdditionalJustification.Visible = this.txtAdditionalJustification.Visible = visible;
            this.lblAddInfo.Visible = this.txtAddInfo.Visible = visible;
            this.lblStdUsed.Visible = this.StandardsReport.Visible = visible;
            if (!visible)
            {
                this.lblStdUsed.Height = this.StandardsReport.Height = new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch);
                this.lblSeriesJustification.Height = this.txtSeriesJustification.Height = new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch);
                this.lblTitleJustification.Height = this.txtTitleJustification.Height = new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch);
                this.lblGradeJustification.Height = this.txtGradeJustification.Height = new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch);
                this.lblAdditionalJustification.Height = this.txtAdditionalJustification.Height = new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch);
                this.lblAddInfo.Height = this.txtAddInfo.Height = new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch);
                this.table1.Height = new Telerik.Reporting.Drawing.Unit(8.5, Telerik.Reporting.Drawing.UnitType.Inch);
                this.detail.Height = new Telerik.Reporting.Drawing.Unit(8.5, Telerik.Reporting.Drawing.UnitType.Inch);

            }

        }

        private void HeaderTable_NeedDataSource(object sender, EventArgs e)
        {
            long pdid = Convert.ToInt64(this.ReportParameters["PositionDescriptionID"].Value);
            this.positionDescriptionTableAdapter1.Fill(pdDataSet.PositionDescriptionTable, pdid);
            this.table1.DataSource = pdDataSet.PositionDescriptionTable.DefaultView;

        }

        private void HeaderTable_ItemDataBinding(object sender, EventArgs e)
        {
            SetEvalRowsVisibility();
        }
    }
}