namespace HCMS.JNP.Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for JobAnalysisDutySubReport.
    /// </summary>
    public partial class JobAnalysisDutySubReport : Telerik.Reporting.Report
    {
        public JobAnalysisDutySubReport()
        {             
            InitializeComponent();

             
            if (tblJADutySubReport.Body.Rows.Count == 1)
            {
                this.txtFinalKSAHeader.Bindings.Add(new Telerik.Reporting.Binding("Parent.Visible", "=Count(1) > 0"));
            }

        }

    }
}