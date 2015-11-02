namespace HCMS.Reports.Comments
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using HCMS.Reports.PDWorkflowNotesTableAdapters;

    /// <summary>
    /// Summary description for PDWorkflowComments.
    /// </summary>
    public partial class PDWorkflowComments : Telerik.Reporting.Report
    {
        public PDWorkflowComments()
        {
            /// <summary>
            /// Required for telerik Reporting designer support
            /// </summary>
            InitializeComponent();
           
            // TODO: This line of code loads data into the 'pDWorkflowNotes.PDWorkflowNotesTable' table. You can move, or remove it, as needed.
            //try
            //{
            //    long pdid = Convert.ToInt64(this.ReportParameters["PDID"].Value);

            //    this.pdWorkflowNotesTableAdapter1.Fill(this.pDWorkflowNotes.PDWorkflowNotesTable, pdid);
            //}
            //catch (System.Exception ex)
            //{
            //    // An error has occurred while filling the data set. Please check the exception for more information.
            //    System.Diagnostics.Debug.WriteLine(ex.Message);
            //}
        }

        private void PDWorkflowComments_NeedDataSource(object sender, EventArgs e)
        {
            
            long pdid = Convert.ToInt64(this.ReportParameters["PDID"].Value);
            PDWorkflowNotesTableAdapter adapter = new PDWorkflowNotesTableAdapter();
            PDWorkflowNotes.PDWorkflowNotesTableDataTable dt = new PDWorkflowNotes.PDWorkflowNotesTableDataTable();
            dt = adapter.GetData(pdid);
           ((Telerik.Reporting.Processing.Report)sender).DataSource = dt.DefaultView;

        }

       
    }
}