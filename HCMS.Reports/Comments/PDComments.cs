namespace HCMS.Reports.Comments
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for PDComments.
    /// </summary>
    public partial class PDComments : Telerik.Reporting.Report
    {
        public PDComments()
        {
            /// <summary>
            /// Required for telerik Reporting designer support
            /// </summary>
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            try
            {
                long pdid = Convert.ToInt64(this.ReportParameters["PDID"].Value);
                this.positionDescriptionTableAdapter1.Fill(this.pdDataSet1 .PositionDescriptionTable, pdid);
               
            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

  
       

       

        private void PDComments_NeedDataSource(object sender, EventArgs e)
        {
            try
            {
                long pdid = Convert.ToInt64(this.ReportParameters["PDID"].Value);
                this.positionDescriptionTableAdapter1.Fill(this.pdDataSet1.PositionDescriptionTable, pdid);
                ((Telerik.Reporting.Processing.Report)sender).DataSource = this.pdDataSet1.PositionDescriptionTable.DefaultView;
            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

        }


      
      
    }
}