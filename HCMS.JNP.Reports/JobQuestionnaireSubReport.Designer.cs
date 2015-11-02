namespace HCMS.JNP.Reports
{
    partial class JobQuestionnaireSubReport
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
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            this.objDataSourceGetJNPByID = new Telerik.Reporting.ObjectDataSource();
            this.objDSQualificationAndInstruction = new Telerik.Reporting.ObjectDataSource();
            this.detail = new Telerik.Reporting.DetailSection();
            this.list1 = new Telerik.Reporting.List();
            this.panel1 = new Telerik.Reporting.Panel();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.subReport2 = new Telerik.Reporting.SubReport();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.jobQuestionaireQuestionsSubReport1 = new HCMS.JNP.Reports.JobQuestionaireQuestionsSubReport();
            this.jobQuestionaireQuestionsSubReport2 = new HCMS.JNP.Reports.JobQuestionaireQuestionsSubReport();
            ((System.ComponentModel.ISupportInitialize)(this.jobQuestionaireQuestionsSubReport1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobQuestionaireQuestionsSubReport2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // objDataSourceGetJNPByID
            // 
            this.objDataSourceGetJNPByID.DataMember = "GetData";
            this.objDataSourceGetJNPByID.DataSource = typeof(HCMS.JNP.Reports.JNPDataSetTableAdapters.spr_rptGetJNPByIDTableAdapter);
            this.objDataSourceGetJNPByID.Name = "objDataSourceGetJNPByID";
            this.objDataSourceGetJNPByID.Parameters.AddRange(new Telerik.Reporting.ObjectDataSourceParameter[] {
            new Telerik.Reporting.ObjectDataSourceParameter("jNPID", typeof(System.Nullable<long>), "=Parameters.jNPID.Value")});
            // 
            // objDSQualificationAndInstruction
            // 
            this.objDSQualificationAndInstruction.DataMember = "GetData";
            this.objDSQualificationAndInstruction.DataSource = typeof(HCMS.JNP.Reports.JNPDataSetTableAdapters.spr_GetJQFactorByJQIDTableAdapter);
            this.objDSQualificationAndInstruction.Name = "objDataSourceGetJQFactorByJQID";
            this.objDSQualificationAndInstruction.Parameters.AddRange(new Telerik.Reporting.ObjectDataSourceParameter[] {
            new Telerik.Reporting.ObjectDataSourceParameter("jQID", typeof(System.Nullable<long>), "=Parameters.jQID.Value")});
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(1.1228777170181274D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.list1});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            // 
            // list1
            // 
            this.list1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(6.46180534362793D)));
            this.list1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(1.0208333730697632D)));
            this.list1.Body.SetCellContent(0, 0, this.panel1);
            tableGroup1.Name = "ColumnGroup";
            this.list1.ColumnGroups.Add(tableGroup1);
            this.list1.DataSource = this.objDSQualificationAndInstruction;
            this.list1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel1});
            this.list1.KeepTogether = false;
            this.list1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.033333301544189453D));
            this.list1.Name = "list1";
            tableGroup2.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping(null)});
            tableGroup2.Name = "DetailGroup";
            this.list1.RowGroups.Add(tableGroup2);
            this.list1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.46180534362793D), Telerik.Reporting.Drawing.Unit.Inch(1.0208333730697632D));
            // 
            // panel1
            // 
            this.panel1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox4,
            this.textBox2,
            this.textBox3,
            this.subReport2,
            this.textBox1});
            this.panel1.KeepTogether = false;
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.46180534362793D), Telerik.Reporting.Drawing.Unit.Inch(1.0208333730697632D));
            this.panel1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            // 
            // textBox4
            // 
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.09375D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.72222232818603516D), Telerik.Reporting.Drawing.Unit.Inch(0.2135416716337204D));
            this.textBox4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox4.Style.Font.Bold = false;
            this.textBox4.Value = "FACTOR:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.3229166567325592D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.1597223281860352D), Telerik.Reporting.Drawing.Unit.Inch(0.30208340287208557D));
            this.textBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox2.Style.Font.Bold = false;
            this.textBox2.StyleName = "";
            this.textBox2.Value = "INSTRUCTIONS:";
            // 
            // textBox3
            // 
            this.textBox3.KeepTogether = false;
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.1770833730697632D), Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.253471851348877D), Telerik.Reporting.Drawing.Unit.Inch(0.28645831346511841D));
            this.textBox3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox3.Value = "= Fields.JQFactorInstruction";
            // 
            // subReport2
            // 
            this.subReport2.KeepTogether = false;
            this.subReport2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.66666668653488159D));
            this.subReport2.Name = "subReport2";
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("jQFactorID", "=Fields.JQFactorID"));
            instanceReportSource1.ReportDocument = this.jobQuestionaireQuestionsSubReport1;
            this.subReport2.ReportSource = instanceReportSource1;
            this.subReport2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4027771949768066D), Telerik.Reporting.Drawing.Unit.Inch(0.2708333432674408D));
            this.subReport2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.subReport2.Style.Font.Bold = false;
            this.subReport2.StyleName = "";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.72916668653488159D), Telerik.Reporting.Drawing.Unit.Inch(0.09375D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.71180534362793D), Telerik.Reporting.Drawing.Unit.Inch(0.20833341777324677D));
            this.textBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox1.StyleName = "";
            this.textBox1.Value = "= Fields.JQFactorTitle";
            // 
            // jobQuestionaireQuestionsSubReport1
            // 
            this.jobQuestionaireQuestionsSubReport1.Name = "JobQuestionaireQuestionsSubReport";
            // 
            // jobQuestionaireQuestionsSubReport2
            // 
            this.jobQuestionaireQuestionsSubReport2.Name = "JobQuestionaireQuestionsSubReport";
            // 
            // JobQuestionnaireSubReport
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.Name = "JobQuestionnaireSubReport";
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "jNPID";
            reportParameter1.Value = "= Parameters.jNPID.Value";
            reportParameter1.Visible = true;
            reportParameter2.AvailableValues.DataSource = this.objDataSourceGetJNPByID;
            reportParameter2.AvailableValues.ValueMember = "= Fields.JQID";
            reportParameter2.Name = "jQID";
            reportParameter2.Value = "= Fields.JQID";
            reportParameter2.Visible = true;
            reportParameter3.AllowNull = true;
            reportParameter3.AvailableValues.DataSource = this.objDSQualificationAndInstruction;
            reportParameter3.AvailableValues.ValueMember = "= Fields.JQFactorID";
            reportParameter3.Name = "jQFactorID";
            reportParameter3.Value = "= Fields.JQFactorID";
            reportParameter3.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.4861106872558594D);
            ((System.ComponentModel.ISupportInitialize)(this.jobQuestionaireQuestionsSubReport1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobQuestionaireQuestionsSubReport2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.ObjectDataSource objDataSourceGetJNPByID;
        private Telerik.Reporting.ObjectDataSource objDSQualificationAndInstruction;
        private Telerik.Reporting.List list1;
        private Telerik.Reporting.Panel panel1;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.SubReport subReport2;
        private Telerik.Reporting.TextBox textBox1;
        private JobQuestionaireQuestionsSubReport jobQuestionaireQuestionsSubReport2;
        private JobQuestionaireQuestionsSubReport jobQuestionaireQuestionsSubReport1;
    }
}