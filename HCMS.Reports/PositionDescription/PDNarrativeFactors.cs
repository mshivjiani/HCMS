namespace HCMS.Reports.PositionDescription
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for PDNarrativeFactors.
    /// </summary>
    public partial class PDNarrativeFactors : Telerik.Reporting.Report
    {
        public PDNarrativeFactors()
        {
            /// <summary>
            /// Required for telerik Reporting designer support
            /// </summary>
            InitializeComponent();

            // TODO: This line of code loads data into the 'pDExpressDataSetNarrativeFactors.PDExpressDataSetNarrativeFactorsTable' table. You can move, or remove it, as needed.
            try
            {
                this.pdExpressDataSetNarrativeFactorsTableAdapter1.Fill(this.pdExpressDataSetNarrativeFactors.PDExpressDataSetNarrativeFactorsTable);
                //setting the detail section height to minimum so that
                //if there is no data then it won't show as blank space.
                this.detail.Height = Telerik.Reporting.Drawing.Unit.Pixel(1);

            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void factorJustification_ItemDataBinding(object sender, EventArgs e)
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


}
