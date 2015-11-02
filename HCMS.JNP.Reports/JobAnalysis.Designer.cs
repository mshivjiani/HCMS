namespace HCMS.JNP.Reports
{
    partial class JobAnalysis
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.InstanceReportSource instanceReportSource1 = new Telerik.Reporting.InstanceReportSource();
            Telerik.Reporting.InstanceReportSource instanceReportSource2 = new Telerik.Reporting.InstanceReportSource();
            Telerik.Reporting.InstanceReportSource instanceReportSource3 = new Telerik.Reporting.InstanceReportSource();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            this.detail = new Telerik.Reporting.DetailSection();
            this.headerReport = new Telerik.Reporting.SubReport();
            this.subReportCOEs = new Telerik.Reporting.SubReport();
            this.subReport2 = new Telerik.Reporting.SubReport();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            this.headerReport1 = new HCMS.JNP.Reports.HeaderReport();
            this.jobAnalysisCOEsSubreport1 = new HCMS.JNP.Reports.JobAnalysisCOEsSubreport();
            this.jobAnalysisSubReport1 = new HCMS.JNP.Reports.JobAnalysisSubReport();
            ((System.ComponentModel.ISupportInitialize)(this.headerReport1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobAnalysisCOEsSubreport1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobAnalysisSubReport1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.91291666030883789D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.headerReport,
            this.subReportCOEs,
            this.subReport2});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            // 
            // headerReport
            // 
            this.headerReport.KeepTogether = false;
            this.headerReport.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9339065551757812E-05D), Telerik.Reporting.Drawing.Unit.Inch(3.9339065551757812E-05D));
            this.headerReport.Name = "headerReport";
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("jNPID", "=Parameters.jNPID.Value"));
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("documentObjectTypeId", "1"));
            instanceReportSource1.ReportDocument = this.headerReport1;
            this.headerReport.ReportSource = instanceReportSource1;
            this.headerReport.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.5D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            // 
            // subReportCOEs
            // 
            this.subReportCOEs.KeepTogether = false;
            this.subReportCOEs.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.60416668653488159D));
            this.subReportCOEs.Name = "subReportCOEs";
            instanceReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("jNPID", "=Parameters.jNPID.Value"));
            instanceReportSource2.ReportDocument = this.jobAnalysisCOEsSubreport1;
            this.subReportCOEs.ReportSource = instanceReportSource2;
            this.subReportCOEs.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.5D), Telerik.Reporting.Drawing.Unit.Inch(0.25D));
            this.subReportCOEs.StyleName = "";
            this.subReportCOEs.ItemDataBinding += new System.EventHandler(this.subReportCOEs_ItemDataBinding);
            this.subReportCOEs.ItemDataBound += new System.EventHandler(this.subReportCOEs_ItemDataBound);
            // 
            // subReport2
            // 
            this.subReport2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D));
            this.subReport2.Name = "subReport2";
            instanceReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("jNPID", "=Parameters.jNPID.Value"));
            instanceReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("jAID", "=Parameters.jAID.Value"));
            instanceReportSource3.ReportDocument = this.jobAnalysisSubReport1;
            this.subReport2.ReportSource = instanceReportSource3;
            this.subReport2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.5D), Telerik.Reporting.Drawing.Unit.Inch(0.23999999463558197D));
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.34375D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.currentTimeTextBox,
            this.pageInfoTextBox});
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // currentTimeTextBox
            // 
            this.currentTimeTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.010416666977107525D), Telerik.Reporting.Drawing.Unit.Inch(0.0833333358168602D));
            this.currentTimeTextBox.Name = "currentTimeTextBox";
            this.currentTimeTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.0791666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000003278255463D));
            this.currentTimeTextBox.StyleName = "PageInfo";
            this.currentTimeTextBox.Value = "=NOW().ToShortDateString()";
            // 
            // pageInfoTextBox
            // 
            this.pageInfoTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.2395832538604736D), Telerik.Reporting.Drawing.Unit.Inch(0.09375D));
            this.pageInfoTextBox.Name = "pageInfoTextBox";
            this.pageInfoTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.2540884017944336D), Telerik.Reporting.Drawing.Unit.Inch(0.20000003278255463D));
            this.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.pageInfoTextBox.StyleName = "PageInfo";
            this.pageInfoTextBox.TextWrap = true;
            this.pageInfoTextBox.Value = "= PageNumber";
            // 
            // headerReport1
            // 
            this.headerReport1.Name = "Report1";
            // 
            // jobAnalysisCOEsSubreport1
            // 
            this.jobAnalysisCOEsSubreport1.Name = "JobAnalysisCOEsSubreport";
            // 
            // jobAnalysisSubReport1
            // 
            this.jobAnalysisSubReport1.Name = "JobAnalysisSubReport";
            // 
            // JobAnalysis
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail,
            this.pageFooterSection1});
            this.Name = "JobAnalysis";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(0D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "jNPID";
            reportParameter1.Value = "=Parameters.jNPID.Value";
            reportParameter1.Visible = true;
            reportParameter2.Name = "documentObjectTypeId";
            reportParameter2.Value = "=Parameters.documentObjectTypeId.Value";
            reportParameter2.Visible = true;
            reportParameter3.AutoRefresh = true;
            reportParameter3.Name = "jAID";
            reportParameter3.Value = "=Parameters.jAID.Value";
            reportParameter3.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.5D);
            ((System.ComponentModel.ISupportInitialize)(this.headerReport1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobAnalysisCOEsSubreport1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobAnalysisSubReport1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.SubReport headerReport;
        private HeaderReport headerReport1;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.TextBox currentTimeTextBox;
        private Telerik.Reporting.TextBox pageInfoTextBox;
        private Telerik.Reporting.SubReport subReportCOEs;
        private Telerik.Reporting.SubReport subReport2;
        private JobAnalysisSubReport jobAnalysisSubReport1;
        private JobAnalysisCOEsSubreport jobAnalysisCOEsSubreport1;
    }
}