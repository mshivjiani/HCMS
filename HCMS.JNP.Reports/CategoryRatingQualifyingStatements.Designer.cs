namespace HCMS.JNP.Reports
{
    partial class CategoryRatingQualifyingStatements
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
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            this.detail = new Telerik.Reporting.DetailSection();
            this.list1 = new Telerik.Reporting.List();
            this.panel1 = new Telerik.Reporting.Panel();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.objDataSourceGetCategoryRatingGroupsByCRID = new Telerik.Reporting.ObjectDataSource();
            this.spr_GetCategoryRatingGroupsByCRIDTableAdapter1 = new HCMS.JNP.Reports.JNPDataSetTableAdapters.spr_GetCategoryRatingGroupsByCRIDTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.75632888078689575D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.list1});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            // 
            // list1
            // 
            this.list1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(6.4899997711181641D)));
            this.list1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.75628948211669922D)));
            this.list1.Body.SetCellContent(0, 0, this.panel1);
            tableGroup1.Name = "ColumnGroup";
            this.list1.ColumnGroups.Add(tableGroup1);
            this.list1.DataSource = this.objDataSourceGetCategoryRatingGroupsByCRID;
            this.list1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel1});
            this.list1.KeepTogether = false;
            this.list1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.list1.Name = "list1";
            tableGroup2.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping(null)});
            tableGroup2.Name = "DetailGroup";
            this.list1.RowGroups.Add(tableGroup2);
            this.list1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4899997711181641D), Telerik.Reporting.Drawing.Unit.Inch(0.75628948211669922D));
            this.list1.Sortings.AddRange(new Telerik.Reporting.Sorting[] {
            new Telerik.Reporting.Sorting("=Fields.ScoringRangeGroupTypeID", Telerik.Reporting.SortDirection.Asc)});
            // 
            // panel1
            // 
            this.panel1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox4,
            this.textBox2});
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4899997711181641D), Telerik.Reporting.Drawing.Unit.Inch(0.75628948211669922D));
            // 
            // textBox4
            // 
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.19996063411235809D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4899997711181641D), Telerik.Reporting.Drawing.Unit.Inch(0.20000000298023224D));
            this.textBox4.Style.Font.Bold = true;
            this.textBox4.StyleName = "";
            this.textBox4.Value = "= Fields.ScoringRangeGroupTypeName + \" (\" + Fields.RangeMin + \" - \" + Fields.Rang" +
    "eMax + \")\"";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.010416666977107525D), Telerik.Reporting.Drawing.Unit.Inch(0.40003934502601624D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4899997711181641D), Telerik.Reporting.Drawing.Unit.Inch(0.34999999403953552D));
            this.textBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox2.StyleName = "";
            this.textBox2.Value = "= Fields.QualifyingStatements";
            // 
            // objDataSourceGetCategoryRatingGroupsByCRID
            // 
            this.objDataSourceGetCategoryRatingGroupsByCRID.DataMember = "GetData";
            this.objDataSourceGetCategoryRatingGroupsByCRID.DataSource = typeof(HCMS.JNP.Reports.JNPDataSetTableAdapters.spr_GetCategoryRatingGroupsByCRIDTableAdapter);
            this.objDataSourceGetCategoryRatingGroupsByCRID.Name = "objDataSourceGetCategoryRatingGroupsByCRID";
            this.objDataSourceGetCategoryRatingGroupsByCRID.Parameters.AddRange(new Telerik.Reporting.ObjectDataSourceParameter[] {
            new Telerik.Reporting.ObjectDataSourceParameter("CRID", typeof(System.Nullable<long>), "=Parameters.cRID.Value")});
            // 
            // spr_GetCategoryRatingGroupsByCRIDTableAdapter1
            // 
            this.spr_GetCategoryRatingGroupsByCRIDTableAdapter1.ClearBeforeFill = true;
            // 
            // CategoryRatingQualifyingStatements
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.Name = "CategoryRatingQualifyingStatements";
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(0D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(0D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(0D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "cRID";
            reportParameter1.Value = "= Parameters.cRID.Value";
            reportParameter1.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.4899997711181641D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.ObjectDataSource objDataSourceGetCategoryRatingGroupsByCRID;
        private JNPDataSetTableAdapters.spr_GetCategoryRatingGroupsByCRIDTableAdapter spr_GetCategoryRatingGroupsByCRIDTableAdapter1;
        private Telerik.Reporting.List list1;
        private Telerik.Reporting.Panel panel1;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox2;
    }
}