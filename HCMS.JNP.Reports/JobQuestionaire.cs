namespace HCMS.JNP.Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using HCMS.Business.JQ;

    /// <summary>
    /// Summary description for JobQuestionnaire.
    /// </summary>
    public partial class JobQuestionaire : Telerik.Reporting.Report
    {
        public JobQuestionaire()
        {               
            InitializeComponent();
                
        }

       
       

        private void JobQuestionaire_NeedDataSource(object sender, EventArgs e)
        {
            long jnpid = Convert.ToInt64(this.ReportParameters["jNPID"].Value);
            this.spr_rptGetJNPByIDTableAdapter1.Fill(jnpDataSet1.spr_rptGetJNPByID, jnpid);
            ((Telerik.Reporting.Processing.Report)sender).DataSource = this.jnpDataSet1.spr_rptGetJNPByID.DefaultView;
        }

        
        private void detail_ItemDataBinding(object sender, EventArgs e)
        {
            // Get the detail section object from sender
            Telerik.Reporting.Processing.DetailSection section = (Telerik.Reporting.Processing.DetailSection)sender;
            // From the section object get the current DataRow
            Telerik.Reporting.Processing.IDataObject dataObject = (Telerik.Reporting.Processing.IDataObject)section.DataObject;
            long jqid = Convert.ToInt64(dataObject["JQID"]);
            JQManager jqMgr = new JQManager();
            string reportText = jqMgr.CreateUTF8JobQuestionnaireReportByJQID(jqid);
            txtUTF.Value = reportText;
        }


       

    }
}