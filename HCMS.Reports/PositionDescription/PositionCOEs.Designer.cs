namespace HCMS.Reports.PositionDescription
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    partial class PositionCOEs
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            this.detail = new Telerik.Reporting.DetailSection();
            this.textBoxQualDescription = new Telerik.Reporting.TextBox();
            this.textBoxQualName = new Telerik.Reporting.TextBox();
            this.textBoxQualTypeName = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.objectDataSource1 = new Telerik.Reporting.ObjectDataSource();
            this.pdExpressDataSetCOEs1 = new HCMS.Reports.PDExpressDataSetCOEs();
            this.pdExpressDataSetCOEsTableAdapter1 = new HCMS.Reports.PDExpressDataSetCOEsTableAdapters.PDExpressDataSetCOEsTableAdapter();
            this.dutyCompetencyKSATableAdapter1 = new HCMS.Reports.DutyQualDataSetTableAdapters.DutyCompetencyKSATableAdapter();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.group1 = new Telerik.Reporting.Group();
            this.groupFooterSection1 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection1 = new Telerik.Reporting.GroupHeaderSection();
            ((System.ComponentModel.ISupportInitialize)(this.pdExpressDataSetCOEs1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.35204410552978516D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBoxQualDescription,
            this.textBoxQualName,
            this.textBoxQualTypeName});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            // 
            // textBoxQualDescription
            // 
            this.textBoxQualDescription.CanShrink = true;
            this.textBoxQualDescription.KeepTogether = false;
            this.textBoxQualDescription.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.8000788688659668D), Telerik.Reporting.Drawing.Unit.Inch(1.5894572413799324E-07D));
            this.textBoxQualDescription.Name = "textBoxQualDescription";
            this.textBoxQualDescription.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.7998428344726562D), Telerik.Reporting.Drawing.Unit.Inch(0.2999214231967926D));
            this.textBoxQualDescription.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBoxQualDescription.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBoxQualDescription.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxQualDescription.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxQualDescription.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxQualDescription.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxQualDescription.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxQualDescription.Value = "= Fields.CompetencyKSA";
            // 
            // textBoxQualName
            // 
            this.textBoxQualName.CanShrink = true;
            this.textBoxQualName.KeepTogether = false;
            this.textBoxQualName.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(1.5894572413799324E-07D));
            this.textBoxQualName.Name = "textBoxQualName";
            this.textBoxQualName.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.8000000715255737D), Telerik.Reporting.Drawing.Unit.Inch(0.2999214231967926D));
            this.textBoxQualName.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxQualName.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxQualName.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxQualName.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxQualName.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxQualName.Value = "= Fields.QualificationName";
            // 
            // textBoxQualTypeName
            // 
            this.textBoxQualTypeName.CanShrink = true;
            this.textBoxQualTypeName.KeepTogether = false;
            this.textBoxQualTypeName.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.6000003814697266D), Telerik.Reporting.Drawing.Unit.Inch(1.5894572413799324E-07D));
            this.textBoxQualTypeName.Name = "textBoxQualTypeName";
            this.textBoxQualTypeName.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3999608755111694D), Telerik.Reporting.Drawing.Unit.Inch(0.2999214231967926D));
            this.textBoxQualTypeName.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBoxQualTypeName.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBoxQualTypeName.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxQualTypeName.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxQualTypeName.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxQualTypeName.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxQualTypeName.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxQualTypeName.Value = "= Fields.QualificationTypeName";
            // 
            // textBox1
            // 
            this.textBox1.CanShrink = true;
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.400078684091568D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.8000000715255737D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox1.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox1.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox1.Value = "Qualification";
            // 
            // textBox2
            // 
            this.textBox2.CanShrink = true;
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.8000788688659668D), Telerik.Reporting.Drawing.Unit.Inch(0.40023636817932129D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.7998428344726562D), Telerik.Reporting.Drawing.Unit.Inch(0.19992136955261231D));
            this.textBox2.Style.Font.Bold = true;
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox2.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox2.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox2.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox2.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox2.Value = "Description";
            // 
            // textBox3
            // 
            this.textBox3.CanShrink = true;
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.6000003814697266D), Telerik.Reporting.Drawing.Unit.Inch(0.400078684091568D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3999601602554321D), Telerik.Reporting.Drawing.Unit.Inch(0.19992136955261231D));
            this.textBox3.Style.Font.Bold = true;
            this.textBox3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.textBox3.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox3.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox3.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox3.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox3.Value = "Qualification Type";
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataMember = "PDExpressDataSetCOEsTable";
            this.objectDataSource1.DataSource = this.pdExpressDataSetCOEs1;
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // pdExpressDataSetCOEs1
            // 
            this.pdExpressDataSetCOEs1.DataSetName = "PDExpressDataSetCOEs";
            this.pdExpressDataSetCOEs1.EnforceConstraints = false;
            this.pdExpressDataSetCOEs1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pdExpressDataSetCOEsTableAdapter1
            // 
            this.pdExpressDataSetCOEsTableAdapter1.ClearBeforeFill = true;
            // 
            // dutyCompetencyKSATableAdapter1
            // 
            this.dutyCompetencyKSATableAdapter1.ClearBeforeFill = true;
            // 
            // textBox4
            // 
            this.textBox4.CanShrink = true;
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0000004768371582D), Telerik.Reporting.Drawing.Unit.Inch(0.29999995231628418D));
            this.textBox4.Style.Font.Bold = true;
            this.textBox4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox4.Value = "Conditions of Employment:";
            // 
            // group1
            // 
            this.group1.GroupFooter = this.groupFooterSection1;
            this.group1.GroupHeader = this.groupHeaderSection1;
            this.group1.Name = "group1";
            // 
            // groupFooterSection1
            // 
            this.groupFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D);
            this.groupFooterSection1.Name = "groupFooterSection1";
            // 
            // groupHeaderSection1
            // 
            this.groupHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.60015773773193359D);
            this.groupHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4});
            this.groupHeaderSection1.Name = "groupHeaderSection1";
            // 
            // PositionCOEs
            // 
            this.DataSource = this.objectDataSource1;
            this.Filters.AddRange(new Telerik.Reporting.Filter[] {
            new Telerik.Reporting.Filter("=Fields.PositionDescriptionID", Telerik.Reporting.FilterOperator.Equal, "=Parameters.PDID.Value")});
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            this.group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupHeaderSection1,
            this.groupFooterSection1,
            this.detail});
            this.Name = "PositionCOEs";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "PDID";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Float;
            reportParameter1.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
            styleRule1.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(222)))), ((int)(((byte)(201)))));
            styleRule1.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(39)))), ((int)(((byte)(28)))));
            styleRule1.Style.Font.Name = "Gill Sans MT";
            styleRule1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(20D);
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
            styleRule2.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(222)))), ((int)(((byte)(201)))));
            styleRule2.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(39)))), ((int)(((byte)(28)))));
            styleRule2.Style.Font.Name = "Gill Sans MT";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            styleRule2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
            styleRule3.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(39)))), ((int)(((byte)(28)))));
            styleRule3.Style.Font.Name = "Gill Sans MT";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("PageInfo")});
            styleRule4.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(141)))), ((int)(((byte)(105)))));
            styleRule4.Style.Font.Name = "Gill Sans MT";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4});
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(7.0000004768371582D);
            this.NeedDataSource += new System.EventHandler(this.report_NeedDataSource);
            ((System.ComponentModel.ISupportInitialize)(this.pdExpressDataSetCOEs1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DetailSection detail;
        private Telerik.Reporting.TextBox textBoxQualName;
        private Telerik.Reporting.TextBox textBoxQualDescription;
        private Telerik.Reporting.TextBox textBoxQualTypeName;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private PDExpressDataSetCOEsTableAdapters.PDExpressDataSetCOEsTableAdapter pdExpressDataSetCOEsTableAdapter1;
        private PDExpressDataSetCOEs pdExpressDataSetCOEs1;
        private ObjectDataSource objectDataSource1;
        private DutyQualDataSetTableAdapters.DutyCompetencyKSATableAdapter dutyCompetencyKSATableAdapter1;
        private Telerik.Reporting.TextBox textBox4;
        private Group group1;
        private GroupFooterSection groupFooterSection1;
        private GroupHeaderSection groupHeaderSection1;

    }
}
