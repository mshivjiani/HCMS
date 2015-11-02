namespace HCMS.JNP.Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for JobAnalysisCOEsSubreport.
    /// </summary>
    public partial class JobAnalysisCOEsSubreport : Telerik.Reporting.Report
    {
        public JobAnalysisCOEsSubreport()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
             
            long iJNPID = HCMS.Business.JNP.JNPManager.jnpid;
            
            System.Data.DataTable dt = Business.Base.BusinessBase.ExecuteDataTable("spr_GetConditionsOfEmploymentByJNPID", iJNPID);

            table1.Visible = !(dt.Rows.Count == 0);
            textBox6.Visible = !(dt.Rows.Count == 0);      
        }
    }
}