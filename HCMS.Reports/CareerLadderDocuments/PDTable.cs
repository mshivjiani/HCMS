namespace HCMS.Reports.CareerLadderDocuments
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;


    /// <summary>
    /// Summary description for PDTable.
    /// </summary>
    public partial class PDTable : Telerik.Reporting.Report
    {
        public PDTable()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

            // TODO: This line of code loads data into the 'pDExpressDataSet.PDExpressDataSetTable' table. You can move, or remove it, as needed.
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

        private void PDTable_NeedDataSource(object sender, EventArgs e)
        {
            long pdid = Convert.ToInt64(this.ReportParameters["PositionDescriptionID"].Value);
            this.positionDescriptionTableAdapter1.Fill(pdDataSet.PositionDescriptionTable, pdid);
            this.table1.DataSource = pdDataSet.PositionDescriptionTable.DefaultView;

        }

        private void PDTable_ItemDataBinding(object sender, EventArgs e)
        {
            SetEvalRowsVisibility();
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



        }
    }
}