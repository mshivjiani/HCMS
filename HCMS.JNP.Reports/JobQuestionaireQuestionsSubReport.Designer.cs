namespace HCMS.JNP.Reports
{
    partial class JobQuestionaireQuestionsSubReport
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.TableGroup tableGroup1 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup2 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.InstanceReportSource instanceReportSource1 = new Telerik.Reporting.InstanceReportSource();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            this.detail = new Telerik.Reporting.DetailSection();
            this.list1 = new Telerik.Reporting.List();
            this.panel1 = new Telerik.Reporting.Panel();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.subReport1 = new Telerik.Reporting.SubReport();
            this.objDataSourceGetJQFactorItemByJQFactorID = new Telerik.Reporting.ObjectDataSource();
            this.jobQuestionaireResponsesSubReport3 = new HCMS.JNP.Reports.JobQuestionaireResponsesSubReport();
            this.jobQuestionaireResponsesSubReport1 = new HCMS.JNP.Reports.JobQuestionaireResponsesSubReport();
            this.jobQuestionaireResponsesSubReport2 = new HCMS.JNP.Reports.JobQuestionaireResponsesSubReport();
            ((System.ComponentModel.ISupportInitialize)(this.jobQuestionaireResponsesSubReport3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobQuestionaireResponsesSubReport1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobQuestionaireResponsesSubReport2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.71045607328414917D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.list1});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            // 
            // list1
            // 
            this.list1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(6.44444465637207D)));
            this.list1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.65833330154418945D)));
            this.list1.Body.SetCellContent(0, 0, this.panel1);
            tableGroup1.Name = "ColumnGroup";
            this.list1.ColumnGroups.Add(tableGroup1);
            this.list1.DataSource = this.objDataSourceGetJQFactorItemByJQFactorID;
            this.list1.Filters.AddRange(new Telerik.Reporting.Filter[] {
            new Telerik.Reporting.Filter("=Fields.JQItemTypeID", Telerik.Reporting.FilterOperator.Equal, "1")});
            this.list1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel1});
            this.list1.KeepTogether = false;
            this.list1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.list1.Name = "list1";
            tableGroup2.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping(null)});
            tableGroup2.Name = "DetailGroup";
            this.list1.RowGroups.Add(tableGroup2);
            this.list1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.44444465637207D), Telerik.Reporting.Drawing.Unit.Inch(0.65833330154418945D));
            // 
            // panel1
            // 
            this.panel1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox2,
            this.textBox3,
            this.subReport1});
            this.panel1.KeepTogether = false;
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.44444465637207D), Telerik.Reporting.Drawing.Unit.Inch(0.65833330154418945D));
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.27704405784606934D), Telerik.Reporting.Drawing.Unit.Inch(0.09375D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.1062507629394531D), Telerik.Reporting.Drawing.Unit.Inch(0.22739844024181366D));
            this.textBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox2.Style.Font.Bold = false;
            this.textBox2.StyleName = "";
            this.textBox2.Value = "= Fields.JQItemText";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D), Telerik.Reporting.Drawing.Unit.Inch(0.093789421021938324D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.25609263777732849D), Telerik.Reporting.Drawing.Unit.Inch(0.22739844024181366D));
            this.textBox3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox3.Style.Font.Bold = false;
            this.textBox3.StyleName = "";
            this.textBox3.Value = "= Fields.JQItemNo + \".\"";
            // 
            // subReport1
            // 
            this.subReport1.KeepTogether = false;
            this.subReport1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.2291666716337204D), Telerik.Reporting.Drawing.Unit.Inch(0.3541666567325592D));
            this.subReport1.Name = "subReport1";
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("jQFactorItemID", "=Parameters.jQFactorID.Value"));
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("jQRatingScaleID", "=Fields.RatingScaleID"));
            instanceReportSource1.ReportDocument = this.jobQuestionaireResponsesSubReport3;
            this.subReport1.ReportSource = instanceReportSource1;
            this.subReport1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.15625D), Telerik.Reporting.Drawing.Unit.Inch(0.2604166567325592D));
            // 
            // objDataSourceGetJQFactorItemByJQFactorID
            // 
            this.objDataSourceGetJQFactorItemByJQFactorID.DataMember = "GetData";
            this.objDataSourceGetJQFactorItemByJQFactorID.DataSource = typeof(HCMS.JNP.Reports.JNPDataSetTableAdapters.spr_GetJQFactorItemByJQFactorIDTableAdapter);
            this.objDataSourceGetJQFactorItemByJQFactorID.Name = "objDataSourceGetJQFactorItemByJQFactorID";
            this.objDataSourceGetJQFactorItemByJQFactorID.Parameters.AddRange(new Telerik.Reporting.ObjectDataSourceParameter[] {
            new Telerik.Reporting.ObjectDataSourceParameter("JQFactorID", typeof(System.Nullable<long>), "=Parameters.jQFactorID.Value")});
            // 
            // jobQuestionaireResponsesSubReport3
            // 
            this.jobQuestionaireResponsesSubReport3.Name = "JobQuestionaireResponsesSubReport";
            // 
            // jobQuestionaireResponsesSubReport1
            // 
            this.jobQuestionaireResponsesSubReport1.Name = "JobQuestionaireResponsesSubReport";
            // 
            // jobQuestionaireResponsesSubReport2
            // 
            this.jobQuestionaireResponsesSubReport2.Name = "JobQuestionaireResponsesSubReport";
            // 
            // JobQuestionaireQuestionsSubReport
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.Name = "JobQuestionaireQuestionsSubReport";
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.AllowNull = true;
            reportParameter1.Name = "jQFactorID";
            reportParameter1.Value = "= Parameters.jQFactorID.Value";
            reportParameter1.Visible = true;
            reportParameter2.AllowNull = true;
            reportParameter2.AvailableValues.DataSource = this.objDataSourceGetJQFactorItemByJQFactorID;
            reportParameter2.AvailableValues.ValueMember = "= Fields.JQFactorItemID";
            reportParameter2.Name = "jQFactorItemID";
            reportParameter2.Value = "= Fields.JQFactorItemID";
            reportParameter2.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.4652771949768066D);
            ((System.ComponentModel.ISupportInitialize)(this.jobQuestionaireResponsesSubReport3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobQuestionaireResponsesSubReport1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobQuestionaireResponsesSubReport2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.ObjectDataSource objDataSourceGetJQFactorItemByJQFactorID;
        private Telerik.Reporting.List list1;
        private Telerik.Reporting.Panel panel1;
        private JobQuestionaireResponsesSubReport jobQuestionaireResponsesSubReport1;
        private JobQuestionaireResponsesSubReport jobQuestionaireResponsesSubReport2;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.SubReport subReport1;
        private JobQuestionaireResponsesSubReport jobQuestionaireResponsesSubReport3;
    }
}