namespace HCMS.JNP.Reports
{
    partial class CategoryRatingListOfKSAs
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
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.table1 = new Telerik.Reporting.Table();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.objDataSourceGetAllFinalKSAByJAID = new Telerik.Reporting.ObjectDataSource();
            this.spr_GetAllFinalKSAFactorByJAIDTableAdapter1 = new HCMS.JNP.Reports.JNPDataSetTableAdapters.spr_GetAllFinalKSAFactorByJAIDTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // textBox1
            // 
            this.textBox1.KeepTogether = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4895834922790527D), Telerik.Reporting.Drawing.Unit.Inch(0.1979166716337204D));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBox1.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox1.Value = "Final KSAs";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.6062501072883606D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.table1});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            // 
            // table1
            // 
            this.table1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(6.4895834922790527D)));
            this.table1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.20833344757556915D)));
            this.table1.Body.SetCellContent(0, 0, this.textBox4);
            tableGroup1.ReportItem = this.textBox1;
            this.table1.ColumnGroups.Add(tableGroup1);
            this.table1.DataSource = this.objDataSourceGetAllFinalKSAByJAID;
            this.table1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox4,
            this.textBox1});
            this.table1.KeepTogether = false;
            this.table1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9339065551757812E-05D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.table1.Name = "table1";
            tableGroup2.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping(null)});
            tableGroup2.Name = "DetailGroup";
            this.table1.RowGroups.Add(tableGroup2);
            this.table1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4895834922790527D), Telerik.Reporting.Drawing.Unit.Inch(0.40625014901161194D));
            // 
            // textBox4
            // 
            this.textBox4.KeepTogether = false;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4895834922790527D), Telerik.Reporting.Drawing.Unit.Inch(0.20833344757556915D));
            this.textBox4.Value = "= Fields.JAKSAdescription";
            // 
            // objDataSourceGetAllFinalKSAByJAID
            // 
            this.objDataSourceGetAllFinalKSAByJAID.DataMember = "GetData";
            this.objDataSourceGetAllFinalKSAByJAID.DataSource = typeof(HCMS.JNP.Reports.JNPDataSetTableAdapters.spr_GetAllFinalKSAFactorByJAIDTableAdapter);
            this.objDataSourceGetAllFinalKSAByJAID.Name = "objDataSourceGetAllFinalKSAByJAID";
            this.objDataSourceGetAllFinalKSAByJAID.Parameters.AddRange(new Telerik.Reporting.ObjectDataSourceParameter[] {
            new Telerik.Reporting.ObjectDataSourceParameter("JAID", typeof(System.Nullable<long>), "=Parameters.jAID.Value")});
            // 
            // spr_GetAllFinalKSAFactorByJAIDTableAdapter1
            // 
            this.spr_GetAllFinalKSAFactorByJAIDTableAdapter1.ClearBeforeFill = true;
            // 
            // CategoryRatingListOfKSAs
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.Name = "CategoryRatingListOfKSAs";
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(0D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(0D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(0D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "jAID";
            reportParameter1.Value = "= Parameters.jAID.Value";
            reportParameter1.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.4899997711181641D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.Table table1;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.ObjectDataSource objDataSourceGetAllFinalKSAByJAID;
        private JNPDataSetTableAdapters.spr_GetAllFinalKSAFactorByJAIDTableAdapter spr_GetAllFinalKSAFactorByJAIDTableAdapter1;
    }
}