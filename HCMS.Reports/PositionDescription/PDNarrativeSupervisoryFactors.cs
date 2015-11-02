namespace HCMS.Reports.PositionDescription
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for PDNarrativeSupervisoryFactors.
    /// </summary>
    public partial class PDNarrativeSupervisoryFactors : Telerik.Reporting.Report
    {
        public PDNarrativeSupervisoryFactors()
        {
            /// <summary>
            /// Required for telerik Reporting designer support
            /// </summary>
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

            // TODO: This line of code loads data into the 'pDExpressDataSetNarrativeSupervisoryFactors.PDExpressDataSetNarrativeSupervisoryFactorsTable' table. You can move, or remove it, as needed.
            try
            {
                this.pdExpressDataSetNarrativeSupervisoryFactorsTableAdapter1.Fill(this.pDExpressDataSetNarrativeSupervisoryFactors.PDExpressDataSetNarrativeSupervisoryFactorsTable);
            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        private void SetFactorJustificationVisibility()
        {
            try
            {
                bool visible = true;

                #region [ retrieve parameter ShowFactorJustification and its value ]
                ReportParameter showFactorJustification = this.ReportParameters["ShowFactorJustification"];
                if (showFactorJustification != null)
                {
                    visible = Convert.ToString(showFactorJustification.Value) == "Yes" ? true : false;
                }
                #endregion

                textBox2.Visible = textBoxNarrativeFactorJustification.Visible = visible;
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void PDNarrativeSupervisoryFactors_ItemDataBinding(object sender, EventArgs e)
        {
            SetFactorJustificationVisibility();
        }

        
    }
}