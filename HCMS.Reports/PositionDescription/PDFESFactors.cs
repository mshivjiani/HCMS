namespace HCMS.Reports.PositionDescription
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for PDFESFactors.
    /// </summary>
    public partial class PDFESFactors : Telerik.Reporting.Report
    {
        public PDFESFactors()
        {
            /// <summary>
            /// Required for telerik Reporting designer support
            /// </summary>
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

            // TODO: This line of code loads data into the 'pDExpressDataSetFactors.PDExpressDataSetFactorsTable' table. You can move, or remove it, as needed.
            try
            {
                this.groupHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Pixel(1);
                this.groupFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Pixel(1);
                this.detail.Height = Telerik.Reporting.Drawing.Unit.Pixel(1);
              
            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void PDFESFactors_NeedDataSource(object sender, EventArgs e)
        {
            this.pdExpressDataSetFactorsTableAdapter1.Fill(this.pDExpressDataSetFactors.PDExpressDataSetFactorsTable);
            this.Report.DataSource = this.pDExpressDataSetFactors;
            Telerik.Reporting.Processing.ReportItemBase item =(Telerik.Reporting.Processing.ReportItemBase) sender;
        }

        private void factorJustification_ItemDataBinding(object sender, EventArgs e)
        {
            if (setFactorJustificationVisibility(sender))
            {
                string fldName = "FactorJustification";
                Telerik.Reporting.Processing.TextBox textBox = (Telerik.Reporting.Processing.TextBox)sender;
                Telerik.Reporting.Processing.IDataObject dataObject = (Telerik.Reporting.Processing.IDataObject)textBox.DataObject;
                string fj = (dataObject[fldName] == null ? "" : dataObject[fldName].ToString());
                if (fj.Length == 0 || fj == "Not Supplied")
                {
                    textBox2.Visible = false;
                }
            }
        }

        private bool setFactorJustificationVisibility(object sender)
        {
            bool visible = true;
            try
            {
                Telerik.Reporting.Processing.ReportItemBase item = (Telerik.Reporting.Processing.ReportItemBase)sender;

                ReportParameter showFactorJustification = this.ReportParameters["ShowFactorJustification"];
                if (showFactorJustification != null)
                {
                    visible = Convert.ToString(showFactorJustification.Value) == "Yes" ? true : false;
                }

                textBox2.Visible = textBoxFESFactorJustification.Visible = visible;
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return visible;
        }

    }

}
