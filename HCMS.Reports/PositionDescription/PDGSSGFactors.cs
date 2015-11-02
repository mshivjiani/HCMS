namespace HCMS.Reports.PositionDescription
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for PDGSSGFactors.
    /// </summary>
    public partial class PDGSSGFactors : Telerik.Reporting.Report
    {
        public PDGSSGFactors()
        {
            /// <summary>
            /// Required for telerik Reporting designer support
            /// </summary>
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

            // TODO: This line of code loads data into the 'pDExpressDataSetGSSGFactors.PDExpressDataSetGSSGFactorsTable' table. You can move, or remove it, as needed.
            try
            {
                this.pdExpressDataSetGSSGFactorsTableAdapter1.Fill(this.pDExpressDataSetGSSGFactors.PDExpressDataSetGSSGFactorsTable);
                this.Report.DataSource = this.pDExpressDataSetGSSGFactors;
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

        private void detail_ItemDataBinding(object sender, EventArgs e)
        {
            SetFactorJustificationVisibility();
            //Telerik.Reporting.Processing.ReportItemBase item = (Telerik.Reporting.Processing.ReportItemBase)sender;

            //long pdid = (long)item.DataObject["PositionDescriptionID"];
            //InstanceReportSource instancereportsource = new InstanceReportSource();
            //instancereportsource.ReportDocument = this.subrptGradePointTotal.Report;
            //int factorformatypeid = 2;
            //instancereportsource.Parameters["PDID"].Value = pdid;
            //instancereportsource.Parameters["FactorFormatTypeID"].Value = factorformatypeid;
            //this.subrptGradePointTotal.ReportSource.ReportParameters["PDID"].Value = pdid;            
           // this.subrptGradePointTotal.ReportSource.ReportParameters["FactorFormatTypeID"].Value = factorformatypeid;


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

                textBox2.Visible = this.textBoxGSSGFactorJustification.Visible = visible;
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
       
    }
}
