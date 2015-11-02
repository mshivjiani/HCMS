namespace HCMS.JNP.Reports
{
    partial class CategoryRating
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
            Telerik.Reporting.ReportParameter reportParameter4 = new Telerik.Reporting.ReportParameter();
            this.headerReport1 = new HCMS.JNP.Reports.HeaderReport();
            this.categoryRatingListOfKSAs1 = new HCMS.JNP.Reports.CategoryRatingListOfKSAs();
            this.categoryRatingQualifyingStatements1 = new HCMS.JNP.Reports.CategoryRatingQualifyingStatements();
            this.objDataSourceGetJNPByID = new Telerik.Reporting.ObjectDataSource();
            this.detail = new Telerik.Reporting.DetailSection();
            this.headerReport = new Telerik.Reporting.SubReport();
            this.subReportcategoryRatingListOfKSAs = new Telerik.Reporting.SubReport();
            this.subReportcategoryRatingQualifyingStatements = new Telerik.Reporting.SubReport();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.jnpDataSet1 = new HCMS.JNP.Reports.JNPDataSet();
            this.spr_rptGetJNPByIDTableAdapter1 = new HCMS.JNP.Reports.JNPDataSetTableAdapters.spr_rptGetJNPByIDTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.headerReport1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryRatingListOfKSAs1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryRatingQualifyingStatements1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jnpDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // headerReport1
            // 
            this.headerReport1.Name = "Report1";
            // 
            // categoryRatingListOfKSAs1
            // 
            this.categoryRatingListOfKSAs1.Name = "CategoryRatingListOfKSAs";
            // 
            // categoryRatingQualifyingStatements1
            // 
            this.categoryRatingQualifyingStatements1.Name = "CategoryRatingQualifyingStatements";
            // 
            // objDataSourceGetJNPByID
            // 
            this.objDataSourceGetJNPByID.DataMember = "GetData";
            this.objDataSourceGetJNPByID.DataSource = typeof(HCMS.JNP.Reports.JNPDataSetTableAdapters.spr_rptGetJNPByIDTableAdapter);
            this.objDataSourceGetJNPByID.Name = "objDataSourceGetJNPByID";
            this.objDataSourceGetJNPByID.Parameters.AddRange(new Telerik.Reporting.ObjectDataSourceParameter[] {
            new Telerik.Reporting.ObjectDataSourceParameter("jNPID", typeof(System.Nullable<long>), "=Parameters.jNPID.Value")});
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.92350751161575317D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.headerReport,
            this.subReportcategoryRatingListOfKSAs,
            this.subReportcategoryRatingQualifyingStatements});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            this.detail.PageBreak = Telerik.Reporting.PageBreak.After;
            // 
            // headerReport
            // 
            this.headerReport.KeepTogether = false;
            this.headerReport.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.03125D));
            this.headerReport.Name = "headerReport";
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("jNPID", "=Parameters.jNPID.Value"));
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("documentObjectTypeId", "=Parameters.documentObjectTypeId.Value"));
            instanceReportSource1.ReportDocument = this.headerReport1;
            this.headerReport.ReportSource = instanceReportSource1;
            this.headerReport.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4899997711181641D), Telerik.Reporting.Drawing.Unit.Inch(0.27000001072883606D));
            // 
            // subReportcategoryRatingListOfKSAs
            // 
            this.subReportcategoryRatingListOfKSAs.KeepTogether = false;
            this.subReportcategoryRatingListOfKSAs.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.34375D));
            this.subReportcategoryRatingListOfKSAs.Name = "subReportcategoryRatingListOfKSAs";
            instanceReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("jAID", "=Parameters.jAID.Value"));
            instanceReportSource2.ReportDocument = this.categoryRatingListOfKSAs1;
            this.subReportcategoryRatingListOfKSAs.ReportSource = instanceReportSource2;
            this.subReportcategoryRatingListOfKSAs.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4899997711181641D), Telerik.Reporting.Drawing.Unit.Inch(0.27000001072883606D));
            this.subReportcategoryRatingListOfKSAs.StyleName = "";
            // 
            // subReportcategoryRatingQualifyingStatements
            // 
            this.subReportcategoryRatingQualifyingStatements.KeepTogether = false;
            this.subReportcategoryRatingQualifyingStatements.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.64583331346511841D));
            this.subReportcategoryRatingQualifyingStatements.Name = "subReportcategoryRatingQualifyingStatements";
            instanceReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("cRID", "=Parameters.cRID.Value"));
            instanceReportSource3.ReportDocument = this.categoryRatingQualifyingStatements1;
            this.subReportcategoryRatingQualifyingStatements.ReportSource = instanceReportSource3;
            this.subReportcategoryRatingQualifyingStatements.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4899997711181641D), Telerik.Reporting.Drawing.Unit.Inch(0.27000001072883606D));
            this.subReportcategoryRatingQualifyingStatements.StyleName = "";
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.32083320617675781D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageInfoTextBox,
            this.currentTimeTextBox});
            this.pageFooterSection1.Name = "pageFooterSection1";
            this.pageFooterSection1.PrintOnLastPage = true;
            // 
            // pageInfoTextBox
            // 
            this.pageInfoTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.1979167461395264D), Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D));
            this.pageInfoTextBox.Name = "pageInfoTextBox";
            this.pageInfoTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.2540884017944336D), Telerik.Reporting.Drawing.Unit.Inch(0.20000003278255463D));
            this.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.pageInfoTextBox.StyleName = "PageInfo";
            this.pageInfoTextBox.TextWrap = true;
            this.pageInfoTextBox.Value = "= PageNumber";
            // 
            // currentTimeTextBox
            // 
            this.currentTimeTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D));
            this.currentTimeTextBox.Name = "currentTimeTextBox";
            this.currentTimeTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.0791666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000003278255463D));
            this.currentTimeTextBox.StyleName = "PageInfo";
            this.currentTimeTextBox.Value = "=NOW().ToShortDateString()";
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
            // CategoryRating
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail,
            this.pageFooterSection1});
            this.Name = "CategoryRating";
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "jNPID";
            reportParameter1.Value = "= Parameters.jNPID.Value";
            reportParameter1.Visible = true;
            reportParameter2.AvailableValues.DataSource = this.objDataSourceGetJNPByID;
            reportParameter2.AvailableValues.ValueMember = "= Fields.JAID";
            reportParameter2.Name = "jAID";
            reportParameter2.Value = "= Fields.JAID";
            reportParameter2.Visible = true;
            reportParameter3.AvailableValues.ValueMember = "= Fields.CRID";
            reportParameter3.Name = "cRID";
            reportParameter3.Value = "=Parameters.cRID.Value";
            reportParameter3.Visible = true;
            reportParameter4.Name = "documentObjectTypeId";
            reportParameter4.Value = "= Parameters.documentObjectTypeId.Value";
            reportParameter4.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            this.ReportParameters.Add(reportParameter4);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.5D);
            ((System.ComponentModel.ISupportInitialize)(this.headerReport1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryRatingListOfKSAs1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryRatingQualifyingStatements1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jnpDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.ObjectDataSource objDataSourceGetJNPByID;
        private JNPDataSet jnpDataSet1;
        private JNPDataSetTableAdapters.spr_rptGetJNPByIDTableAdapter spr_rptGetJNPByIDTableAdapter1;
        private Telerik.Reporting.TextBox pageInfoTextBox;
        private Telerik.Reporting.TextBox currentTimeTextBox;
        private Telerik.Reporting.SubReport headerReport;
        private Telerik.Reporting.SubReport subReportcategoryRatingListOfKSAs;
        private Telerik.Reporting.SubReport subReportcategoryRatingQualifyingStatements;
        private HeaderReport headerReport1;
        private CategoryRatingListOfKSAs categoryRatingListOfKSAs1;
        private CategoryRatingQualifyingStatements categoryRatingQualifyingStatements1;
    }
}