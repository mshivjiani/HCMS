namespace HCMS.JNP.Reports
{
    partial class PDDutyKSAConditionsOfEmploymentReport
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
            Telerik.Reporting.TableGroup tableGroup5 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.table2 = new Telerik.Reporting.Table();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.objectDataSource1 = new Telerik.Reporting.ObjectDataSource();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // textBox7
            // 
            this.textBox7.KeepTogether = false;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4908332824707031D), Telerik.Reporting.Drawing.Unit.Inch(0.324848473072052D));
            this.textBox7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox7.Style.Font.Bold = true;
            this.textBox7.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Left;
            this.textBox7.Value = "Conditions of Employment And Selective Factors";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.669999897480011D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.table2});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            // 
            // table2
            // 
            this.table2.Bindings.Add(new Telerik.Reporting.Binding("Visible", "=IIf(Parameters.recCount.Value IS Null, False, True)"));
            this.table2.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(4.6605997085571289D)));
            this.table2.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(1.8302329778671265D)));
            this.table2.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.34515148401260376D)));
            this.table2.Body.SetCellContent(0, 0, this.textBox1);
            this.table2.Body.SetCellContent(0, 1, this.textBox2);
            tableGroup2.Name = "Group1";
            tableGroup1.ChildGroups.Add(tableGroup2);
            tableGroup1.ChildGroups.Add(tableGroup3);
            tableGroup1.ReportItem = this.textBox7;
            this.table2.ColumnGroups.Add(tableGroup1);
            this.table2.DataSource = this.objectDataSource1;
            this.table2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1,
            this.textBox2,
            this.textBox7});
            this.table2.KeepTogether = false;
            this.table2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.009166717529296875D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.table2.Name = "table2";
            tableGroup5.Name = "Group3";
            tableGroup4.ChildGroups.Add(tableGroup5);
            tableGroup4.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping(null)});
            tableGroup4.Name = "DetailGroup";
            this.table2.RowGroups.Add(tableGroup4);
            this.table2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4908332824707031D), Telerik.Reporting.Drawing.Unit.Inch(0.66999995708465576D));
            this.table2.Style.Visible = true;
            // 
            // textBox1
            // 
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.6605997085571289D), Telerik.Reporting.Drawing.Unit.Inch(0.34515148401260376D));
            this.textBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox1.StyleName = "";
            this.textBox1.Value = "= Fields.KSADescription";
            // 
            // textBox2
            // 
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.8302327394485474D), Telerik.Reporting.Drawing.Unit.Inch(0.34515148401260376D));
            this.textBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox2.StyleName = "";
            this.textBox2.Value = "= Fields.QualificationName";
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataMember = "GetData";
            this.objectDataSource1.DataSource = typeof(HCMS.JNP.Reports.PDDutyDataSetTableAdapters.spr_ConditionsOfEmploymentandSelectiveFactorPDDutyTableAdapter);
            this.objectDataSource1.Name = "objectDataSource1";
            this.objectDataSource1.Parameters.AddRange(new Telerik.Reporting.ObjectDataSourceParameter[] {
            new Telerik.Reporting.ObjectDataSourceParameter("positionDescriptionID", typeof(System.Nullable<long>), "=Parameters.positionDescriptionID.Value")});
            // 
            // PDDutyKSAConditionsOfEmploymentReport
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.Name = "PDDutyKSAConditionsOfEmploymentReport";
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "positionDescriptionID";
            reportParameter1.Value = "= Parameters.positionDescriptionID.Value";
            reportParameter1.Visible = true;
            reportParameter2.AllowNull = true;
            reportParameter2.AutoRefresh = true;
            reportParameter2.AvailableValues.DataSource = this.objectDataSource1;
            reportParameter2.AvailableValues.ValueMember = "= Count(Fields.KSADescription)";
            reportParameter2.Name = "recCount";
            reportParameter2.Value = "= Count(Fields.KSADescription)";
            reportParameter2.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.5D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.Table table2;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.ObjectDataSource objectDataSource1;
    }
}