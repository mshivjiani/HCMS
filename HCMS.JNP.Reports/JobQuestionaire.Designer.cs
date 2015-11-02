namespace HCMS.JNP.Reports
{
    partial class JobQuestionaire
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
            this.headerReport2 = new HCMS.JNP.Reports.HeaderReport();
            this.objectDataSource1 = new Telerik.Reporting.ObjectDataSource();
            this.detail = new Telerik.Reporting.DetailSection();
            this.headerReport = new Telerik.Reporting.SubReport();
            this.txtUTF = new Telerik.Reporting.TextBox();
            this.jnpDataSet1 = new HCMS.JNP.Reports.JNPDataSet();
            this.spr_rptGetJNPByIDTableAdapter1 = new HCMS.JNP.Reports.JNPDataSetTableAdapters.spr_rptGetJNPByIDTableAdapter();
            this.headerReport1 = new HCMS.JNP.Reports.HeaderReport();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.headerReport2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jnpDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerReport1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // headerReport2
            // 
            this.headerReport2.Name = "Report1";
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataMember = "GetData";
            this.objectDataSource1.DataSource = typeof(HCMS.JNP.Reports.JNPDataSetTableAdapters.spr_rptGetJNPByIDTableAdapter);
            this.objectDataSource1.Name = "objectDataSource1";
            this.objectDataSource1.Parameters.AddRange(new Telerik.Reporting.ObjectDataSourceParameter[] {
            new Telerik.Reporting.ObjectDataSourceParameter("jNPID", typeof(System.Nullable<long>), "=Parameters.jNPID.Value")});
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.70000004768371582D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.headerReport,
            this.txtUTF});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            this.detail.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.detail.ItemDataBinding += new System.EventHandler(this.detail_ItemDataBinding);
            // 
            // headerReport
            // 
            this.headerReport.KeepTogether = false;
            this.headerReport.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.headerReport.Name = "headerReport";
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("jNPID", "=Parameters.jNPID.Value"));
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("documentObjectTypeId", "=Parameters.documentObjectTypeId.Value"));
            instanceReportSource1.ReportDocument = this.headerReport2;
            this.headerReport.ReportSource = instanceReportSource1;
            this.headerReport.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4899601936340332D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.headerReport.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // txtUTF
            // 
            this.txtUTF.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.txtUTF.Name = "txtUTF";
            this.txtUTF.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4899601936340332D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.txtUTF.Value = "textBox1";
            // 
            // jnpDataSet1
            // 
            this.jnpDataSet1.DataSetName = "JNPDataSet";
            this.jnpDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spr_rptGetJNPByIDTableAdapter1
            // 
            this.spr_rptGetJNPByIDTableAdapter1.ClearBeforeFill = true;
            // 
            // headerReport1
            // 
            this.headerReport1.Name = "Report1";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.currentTimeTextBox,
            this.pageInfoTextBox});
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // currentTimeTextBox
            // 
            this.currentTimeTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.currentTimeTextBox.Name = "currentTimeTextBox";
            this.currentTimeTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.0791666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000003278255463D));
            this.currentTimeTextBox.StyleName = "PageInfo";
            this.currentTimeTextBox.Value = "=NOW().ToShortDateString()";
            // 
            // pageInfoTextBox
            // 
            this.pageInfoTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.5358715057373047D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.pageInfoTextBox.Name = "pageInfoTextBox";
            this.pageInfoTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.9540884494781494D), Telerik.Reporting.Drawing.Unit.Inch(0.20000003278255463D));
            this.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.pageInfoTextBox.StyleName = "PageInfo";
            this.pageInfoTextBox.TextWrap = true;
            this.pageInfoTextBox.Value = "= PageNumber";
            // 
            // JobQuestionaire
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail,
            this.pageFooterSection1});
            this.Name = "JobQuestionnaire";
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(1D);
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
            this.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.4899997711181641D);
            this.NeedDataSource += new System.EventHandler(this.JobQuestionaire_NeedDataSource);
            ((System.ComponentModel.ISupportInitialize)(this.headerReport2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jnpDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerReport1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.SubReport headerReport;
        private Telerik.Reporting.ObjectDataSource objectDataSource1;
        private HeaderReport headerReport1;
        private JNPDataSet jnpDataSet1;
        private JNPDataSetTableAdapters.spr_rptGetJNPByIDTableAdapter spr_rptGetJNPByIDTableAdapter1;
        private HeaderReport headerReport2;
        private Telerik.Reporting.TextBox txtUTF;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.TextBox currentTimeTextBox;
        private Telerik.Reporting.TextBox pageInfoTextBox;
        //private JobQuestionnaireUTFSubReport jobQuestionnaireUTFSubReport1;
    }
}