namespace HCMS.JNP.Reports
{
    partial class JobAnalysisDutySubReport
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
            Telerik.Reporting.TableGroup tableGroup3 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup4 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            this.txtFinalKSAHeader = new Telerik.Reporting.TextBox();
            this.txtScoreHeader = new Telerik.Reporting.TextBox();
            this.objDataSourceGetJobAnalysisDutyKSAFactorByJADutyID = new Telerik.Reporting.ObjectDataSource();
            this.detail = new Telerik.Reporting.DetailSection();
            this.tblJADutySubReport = new Telerik.Reporting.Table();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.jnpDataSet1 = new HCMS.JNP.Reports.JNPDataSet();
            this.spr_GetJobAnalysisDutyKSAFactorByJADutyIDTableAdapter1 = new HCMS.JNP.Reports.JNPDataSetTableAdapters.spr_GetJobAnalysisDutyKSAFactorByJADutyIDTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.jnpDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // txtFinalKSAHeader
            // 
            this.txtFinalKSAHeader.Name = "txtFinalKSAHeader";
            this.txtFinalKSAHeader.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.6656174659729D), Telerik.Reporting.Drawing.Unit.Inch(0.33499991893768311D));
            this.txtFinalKSAHeader.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.txtFinalKSAHeader.Style.Font.Bold = true;
            this.txtFinalKSAHeader.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.txtFinalKSAHeader.Value = "Final KSAs";
            // 
            // txtScoreHeader
            // 
            this.txtScoreHeader.Name = "txtScoreHeader";
            this.txtScoreHeader.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.7743829488754273D), Telerik.Reporting.Drawing.Unit.Inch(0.33499991893768311D));
            this.txtScoreHeader.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.txtScoreHeader.Style.Font.Bold = true;
            this.txtScoreHeader.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.txtScoreHeader.Value = "Score";
            // 
            // objDataSourceGetJobAnalysisDutyKSAFactorByJADutyID
            // 
            this.objDataSourceGetJobAnalysisDutyKSAFactorByJADutyID.DataMember = "GetData";
            this.objDataSourceGetJobAnalysisDutyKSAFactorByJADutyID.DataSource = typeof(HCMS.JNP.Reports.JNPDataSetTableAdapters.spr_GetJobAnalysisDutyKSAFactorByJADutyIDTableAdapter);
            this.objDataSourceGetJobAnalysisDutyKSAFactorByJADutyID.Name = "objDataSourceGetJobAnalysisDutyKSAByJADutyID";
            this.objDataSourceGetJobAnalysisDutyKSAFactorByJADutyID.Parameters.AddRange(new Telerik.Reporting.ObjectDataSourceParameter[] {
            new Telerik.Reporting.ObjectDataSourceParameter("jADutyID", typeof(System.Nullable<long>), "=Parameters.jADutyID.Value")});
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.70000004768371582D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.tblJADutySubReport});
            this.detail.KeepTogether = true;
            this.detail.Name = "detail";
            // 
            // tblJADutySubReport
            // 
            this.tblJADutySubReport.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(4.6656174659729D)));
            this.tblJADutySubReport.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.7743829488754273D)));
            this.tblJADutySubReport.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.33500006794929504D)));
            this.tblJADutySubReport.Body.SetCellContent(0, 0, this.textBox4);
            this.tblJADutySubReport.Body.SetCellContent(0, 1, this.textBox5);
            tableGroup1.ReportItem = this.txtFinalKSAHeader;
            tableGroup2.ReportItem = this.txtScoreHeader;
            this.tblJADutySubReport.ColumnGroups.Add(tableGroup1);
            this.tblJADutySubReport.ColumnGroups.Add(tableGroup2);
            this.tblJADutySubReport.DataSource = this.objDataSourceGetJobAnalysisDutyKSAFactorByJADutyID;
            this.tblJADutySubReport.Filters.AddRange(new Telerik.Reporting.Filter[] {
            new Telerik.Reporting.Filter("=Fields.IsFinalKSA", Telerik.Reporting.FilterOperator.Equal, "True")});
            this.tblJADutySubReport.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox4,
            this.textBox5,
            this.txtFinalKSAHeader,
            this.txtScoreHeader});
            this.tblJADutySubReport.KeepTogether = false;
            this.tblJADutySubReport.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.tblJADutySubReport.Name = "tblJADutySubReport";
            tableGroup4.Name = "Group1";
            tableGroup3.ChildGroups.Add(tableGroup4);
            tableGroup3.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping(null)});
            tableGroup3.Name = "DetailGroup";
            this.tblJADutySubReport.RowGroups.Add(tableGroup3);
            this.tblJADutySubReport.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.440000057220459D), Telerik.Reporting.Drawing.Unit.Inch(0.67000001668930054D));
            // 
            // textBox4
            // 
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.6656174659729D), Telerik.Reporting.Drawing.Unit.Inch(0.33500006794929504D));
            this.textBox4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox4.Value = "= Fields.JAKSADescription";
            // 
            // textBox5
            // 
            this.textBox5.KeepTogether = false;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.7743829488754273D), Telerik.Reporting.Drawing.Unit.Inch(0.33500006794929504D));
            this.textBox5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox5.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Center;
            this.textBox5.Value = "= Fields.TotalScore";
            // 
            // jnpDataSet1
            // 
            this.jnpDataSet1.DataSetName = "JNPDataSet";
            this.jnpDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spr_GetJobAnalysisDutyKSAFactorByJADutyIDTableAdapter1
            // 
            this.spr_GetJobAnalysisDutyKSAFactorByJADutyIDTableAdapter1.ClearBeforeFill = true;
            // 
            // JobAnalysisDutySubReport
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.Name = "JobAnalysisDutySubReport";
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(0D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(0D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(0D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.AutoRefresh = true;
            reportParameter1.Name = "jNPID";
            reportParameter1.Value = "= Parameters.jNPID.Value";
            reportParameter1.Visible = true;
            reportParameter2.AvailableValues.ValueMember = "= Parameters.jAID.Value";
            reportParameter2.Name = "jAID";
            reportParameter2.Value = "= Parameters.jAID.Value";
            reportParameter2.Visible = true;
            reportParameter3.AllowBlank = false;
            reportParameter3.AutoRefresh = true;
            reportParameter3.Name = "jADutyID";
            reportParameter3.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter3.Value = "= Parameters.jADutyID.Value";
            reportParameter3.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.4499998092651367D);
            ((System.ComponentModel.ISupportInitialize)(this.jnpDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.ObjectDataSource objDataSourceGetJobAnalysisDutyKSAFactorByJADutyID;
        private Telerik.Reporting.Table tblJADutySubReport;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox txtFinalKSAHeader;
        private Telerik.Reporting.TextBox txtScoreHeader;
        private JNPDataSet jnpDataSet1;
        private JNPDataSetTableAdapters.spr_GetJobAnalysisDutyKSAFactorByJADutyIDTableAdapter spr_GetJobAnalysisDutyKSAFactorByJADutyIDTableAdapter1;
    }
}