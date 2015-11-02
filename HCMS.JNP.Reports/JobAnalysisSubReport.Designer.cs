namespace HCMS.JNP.Reports
{
    partial class JobAnalysisSubReport
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.InstanceReportSource instanceReportSource1 = new Telerik.Reporting.InstanceReportSource();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            this.jobAnalysisDutySubReport1 = new HCMS.JNP.Reports.JobAnalysisDutySubReport();
            this.detail = new Telerik.Reporting.DetailSection();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.subRptJADutySubReport = new Telerik.Reporting.SubReport();
            this.objGetJobAnlaysisDutyByJAID = new Telerik.Reporting.ObjectDataSource();
            ((System.ComponentModel.ISupportInitialize)(this.jobAnalysisDutySubReport1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // jobAnalysisDutySubReport1
            // 
            this.jobAnalysisDutySubReport1.Name = "JobAnalysisDutySubReport";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(1.0487500429153442D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.subRptJADutySubReport});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            this.detail.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Inch(0D);
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.125D), Telerik.Reporting.Drawing.Unit.Inch(0.09375D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.46875D), Telerik.Reporting.Drawing.Unit.Inch(0.2395833283662796D));
            this.textBox1.Value = "Duty Description:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.6666666269302368D), Telerik.Reporting.Drawing.Unit.Inch(0.0833333358168602D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.6875D), Telerik.Reporting.Drawing.Unit.Inch(0.2395833283662796D));
            this.textBox2.Value = "=Fields.JADutyDescription";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.6875D), Telerik.Reporting.Drawing.Unit.Inch(0.5D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.6875D), Telerik.Reporting.Drawing.Unit.Inch(0.2395833283662796D));
            this.textBox3.Value = "=Fields.JAPercentageOfTime";
            // 
            // textBox4
            // 
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.1458333283662796D), Telerik.Reporting.Drawing.Unit.Inch(0.4895833432674408D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.46875D), Telerik.Reporting.Drawing.Unit.Inch(0.2395833283662796D));
            this.textBox4.Value = "Percentage of Time:";
            // 
            // subRptJADutySubReport
            // 
            this.subRptJADutySubReport.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.79166668653488159D));
            this.subRptJADutySubReport.Name = "subRptJADutySubReport";
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("jNPID", "=Parameters.jNPID.Value"));
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("jAID", "=parameters.jAID.Value"));
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("jADutyID", "=Fields.JADutyID"));
            instanceReportSource1.ReportDocument = this.jobAnalysisDutySubReport1;
            this.subRptJADutySubReport.ReportSource = instanceReportSource1;
            this.subRptJADutySubReport.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.1979165077209473D), Telerik.Reporting.Drawing.Unit.Inch(0.2395833283662796D));
            // 
            // objGetJobAnlaysisDutyByJAID
            // 
            this.objGetJobAnlaysisDutyByJAID.DataMember = "GetData";
            this.objGetJobAnlaysisDutyByJAID.DataSource = typeof(HCMS.JNP.Reports.JNPDataSetTableAdapters.spr_GetJobAnalysisDutyByJAIDTableAdapter);
            this.objGetJobAnlaysisDutyByJAID.Name = "objGetJobAnlaysisDutyByJAID";
            this.objGetJobAnlaysisDutyByJAID.Parameters.AddRange(new Telerik.Reporting.ObjectDataSourceParameter[] {
            new Telerik.Reporting.ObjectDataSourceParameter("JAID", typeof(System.Nullable<int>), "=Parameters.jAID.Value")});
            // 
            // JobAnalysisSubReport
            // 
            this.DataSource = this.objGetJobAnlaysisDutyByJAID;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.Name = "JobAnalysisSubReport";
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(0D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(0D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "jNPID";
            reportParameter1.Value = "= Parameters.JNPID.Value";
            reportParameter1.Visible = true;
            reportParameter2.AutoRefresh = true;
            reportParameter2.AvailableValues.ValueMember = "= Parameters.jAID.Value";
            reportParameter2.Name = "jAID";
            reportParameter2.Text = "jAID";
            reportParameter2.Value = "= Parameters.jAID.Value";
            reportParameter2.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.4800000190734863D);
            ((System.ComponentModel.ISupportInitialize)(this.jobAnalysisDutySubReport1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.ObjectDataSource objGetJobAnlaysisDutyByJAID;
        private Telerik.Reporting.SubReport subRptJADutySubReport;
        private JobAnalysisDutySubReport jobAnalysisDutySubReport1;

        //private JAKSADataSet JAKSADataSet;
        //private Telerik.Reporting.ObjectDataSource objDataSourceJAKSA;
        //private JAKSADataSetTableAdapters.spr_GetJAKSATableAdapter spr_GetJAKSATableAdapter;
      
    }
}