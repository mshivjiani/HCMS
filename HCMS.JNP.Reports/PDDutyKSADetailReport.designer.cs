namespace HCMS.JNP.Reports
{
    partial class PDDutyKSADetailReport
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
            this.detail = new Telerik.Reporting.DetailSection();
            this.list2 = new Telerik.Reporting.List();
            this.panel2 = new Telerik.Reporting.Panel();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.subReport1 = new Telerik.Reporting.SubReport();
            this.objectDataSource1 = new Telerik.Reporting.ObjectDataSource();
            this.pdDutyKSADetailSubReport2 = new HCMS.JNP.Reports.PDDutyKSADetailSubReport();
            this.pdDutyKSADetailSubReport1 = new HCMS.JNP.Reports.PDDutyKSADetailSubReport();
            ((System.ComponentModel.ISupportInitialize)(this.pdDutyKSADetailSubReport2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdDutyKSADetailSubReport1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.91474074125289917D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.list2});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            // 
            // list2
            // 
            this.list2.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(6.4800000190734863D)));
            this.list2.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.91470128297805786D)));
            this.list2.Body.SetCellContent(0, 0, this.panel2);
            tableGroup1.Name = "ColumnGroup";
            this.list2.ColumnGroups.Add(tableGroup1);
            this.list2.DataSource = this.objectDataSource1;
            this.list2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel2});
            this.list2.KeepTogether = false;
            this.list2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.list2.Name = "list2";
            tableGroup2.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping(null)});
            tableGroup2.Name = "DetailGroup";
            this.list2.RowGroups.Add(tableGroup2);
            this.list2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4800000190734863D), Telerik.Reporting.Drawing.Unit.Inch(0.91470128297805786D));
            this.list2.Sortings.AddRange(new Telerik.Reporting.Sorting[] {
            new Telerik.Reporting.Sorting("=Fields.PercentageOfTime", Telerik.Reporting.SortDirection.Desc)});
            this.list2.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            // 
            // panel2
            // 
            this.panel2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox6,
            this.textBox2,
            this.subReport1});
            this.panel2.KeepTogether = false;
            this.panel2.Name = "panel2";
            this.panel2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4800000190734863D), Telerik.Reporting.Drawing.Unit.Inch(0.91470128297805786D));
            // 
            // textBox6
            // 
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D), Telerik.Reporting.Drawing.Unit.Inch(0.34378933906555176D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4532942771911621D), Telerik.Reporting.Drawing.Unit.Inch(0.27000001072883606D));
            this.textBox6.StyleName = "";
            this.textBox6.Value = "= \"Percentage of time: \" + Fields.PercentageOfTime";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D), Telerik.Reporting.Drawing.Unit.Inch(3.9339065551757812E-05D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4532942771911621D), Telerik.Reporting.Drawing.Unit.Inch(0.31250005960464478D));
            this.textBox2.Value = "= \"Duty Description: \" + Fields.DutyDescription";
            // 
            // subReport1
            // 
            this.subReport1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.61470144987106323D));
            this.subReport1.Name = "subReport1";
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("dutyID", "=Fields.DutyID"));
            instanceReportSource1.ReportDocument = this.pdDutyKSADetailSubReport2;
            this.subReport1.ReportSource = instanceReportSource1;
            this.subReport1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.453333854675293D), Telerik.Reporting.Drawing.Unit.Inch(0.299999862909317D));
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataMember = "GetData";
            this.objectDataSource1.DataSource = typeof(HCMS.JNP.Reports.PDDutyDataSetTableAdapters.spr_GetPositionDutyByPositionDescriptionIDTableAdapter);
            this.objectDataSource1.Name = "objectDataSource1";
            this.objectDataSource1.Parameters.AddRange(new Telerik.Reporting.ObjectDataSourceParameter[] {
            new Telerik.Reporting.ObjectDataSourceParameter("positionDescriptionID", typeof(System.Nullable<long>), "=Parameters.positionDescriptionID.Value")});
            // 
            // pdDutyKSADetailSubReport2
            // 
            this.pdDutyKSADetailSubReport2.Name = "PDDutyKSADetailSubReport";
            // 
            // pdDutyKSADetailSubReport1
            // 
            this.pdDutyKSADetailSubReport1.Name = "PDDutyKSADetailSubReport";
            // 
            // PDDutyKSADetailReport
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.Name = "PDFDutyDetailReport";
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "positionDescriptionID";
            reportParameter1.Text = "positionDescriptionID";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter1.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.4800000190734863D);
            ((System.ComponentModel.ISupportInitialize)(this.pdDutyKSADetailSubReport2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdDutyKSADetailSubReport1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.List list2;
        private Telerik.Reporting.Panel panel2;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.SubReport subReport1;
        private Telerik.Reporting.ObjectDataSource objectDataSource1;
        private PDDutyKSADetailSubReport pdDutyKSADetailSubReport1;
        private PDDutyKSADetailSubReport pdDutyKSADetailSubReport2;
    }
}