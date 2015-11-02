namespace HCMS.JNP.Reports
{
    partial class JNPComments
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
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            this.jnpWorkflowNoteSubRpt11 = new HCMS.JNP.Reports.JNPWorkflowNoteSubRpt1();
            this.headerReport2 = new HCMS.JNP.Reports.HeaderReport();
            this.detail = new Telerik.Reporting.DetailSection();
            this.JNPWorkflowNoteSubRpt1 = new Telerik.Reporting.SubReport();
            this.headerReport = new Telerik.Reporting.SubReport();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.jnpWorkflowNoteSubRpt11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerReport2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // jnpWorkflowNoteSubRpt11
            // 
            this.jnpWorkflowNoteSubRpt11.Name = "JNPWorkflowNoteSubRpt1";
            // 
            // headerReport2
            // 
            this.headerReport2.Name = "Report1";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.71666687726974487D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.JNPWorkflowNoteSubRpt1,
            this.headerReport});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            // 
            // JNPWorkflowNoteSubRpt1
            // 
            this.JNPWorkflowNoteSubRpt1.KeepTogether = false;
            this.JNPWorkflowNoteSubRpt1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.34378942847251892D));
            this.JNPWorkflowNoteSubRpt1.Name = "JNPWorkflowNoteSubRpt1";
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("jNPID", "=Parameters.jNPID.Value"));
            instanceReportSource1.ReportDocument = this.jnpWorkflowNoteSubRpt11;
            this.JNPWorkflowNoteSubRpt1.ReportSource = instanceReportSource1;
            this.JNPWorkflowNoteSubRpt1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4644265174865723D), Telerik.Reporting.Drawing.Unit.Inch(0.320794016122818D));
            // 
            // headerReport
            // 
            this.headerReport.KeepTogether = false;
            this.headerReport.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D), Telerik.Reporting.Drawing.Unit.Inch(0.012499809265136719D));
            this.headerReport.Name = "headerReport";
            instanceReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("jNPID", "=Parameters.jNPID.Value"));
            instanceReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("documentObjectTypeId", "=Parameters.documentObjectTypeId.Value"));
            instanceReportSource2.ReportDocument = this.headerReport2;
            this.headerReport.ReportSource = instanceReportSource2;
            this.headerReport.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4644265174865723D), Telerik.Reporting.Drawing.Unit.Inch(0.29996070265769958D));
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.30420604348182678D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.currentTimeTextBox,
            this.pageInfoTextBox});
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // currentTimeTextBox
            // 
            this.currentTimeTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.041706085205078125D));
            this.currentTimeTextBox.Name = "currentTimeTextBox";
            this.currentTimeTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.0791666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000003278255463D));
            this.currentTimeTextBox.StyleName = "PageInfo";
            this.currentTimeTextBox.Value = "=NOW().ToShortDateString()";
            // 
            // pageInfoTextBox
            // 
            this.pageInfoTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.170989990234375D), Telerik.Reporting.Drawing.Unit.Inch(0.041706085205078125D));
            this.pageInfoTextBox.Name = "pageInfoTextBox";
            this.pageInfoTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.2540884017944336D), Telerik.Reporting.Drawing.Unit.Inch(0.20000003278255463D));
            this.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.pageInfoTextBox.StyleName = "PageInfo";
            this.pageInfoTextBox.TextWrap = true;
            this.pageInfoTextBox.Value = "= PageNumber";
            // 
            // JNPComments
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail,
            this.pageFooterSection1});
            this.Name = "JNPComments";
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "jNPID";
            reportParameter1.Value = "= Parameters.jNPID.Value";
            reportParameter1.Visible = true;
            reportParameter2.Name = "documentObjectTypeId";
            reportParameter2.Value = "= Parameters.documentObjectTypeId.Value";
            reportParameter2.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.4895453453063965D);
            ((System.ComponentModel.ISupportInitialize)(this.jnpWorkflowNoteSubRpt11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerReport2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.SubReport JNPWorkflowNoteSubRpt1;
        private Telerik.Reporting.SubReport headerReport;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.TextBox currentTimeTextBox;
        private Telerik.Reporting.TextBox pageInfoTextBox;
        private JNPWorkflowNoteSubRpt1 jnpWorkflowNoteSubRpt11;
        private HeaderReport headerReport2;
    }
}