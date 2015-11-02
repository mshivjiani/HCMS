namespace HCMS.Reports.PositionDescription
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    partial class PositionOverallQualifications
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
            this.textBoxOverAllHeader = new Telerik.Reporting.TextBox();
            this.pDExpressDataSetPositionQual = new HCMS.Reports.PDExpressDataSetPositionQual();
            this.pdExpressDataSetPositionQualTableAdapter1 = new HCMS.Reports.PDExpressDataSetPositionQualTableAdapters.PDExpressDataSetPositionQualTableAdapter();
            this.group1 = new Telerik.Reporting.Group();
            this.groupFooterSection1 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection1 = new Telerik.Reporting.GroupHeaderSection();
            ((System.ComponentModel.ISupportInitialize)(this.pDExpressDataSetPositionQual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBoxQualDescription,
            this.textBoxQualName,
            this.textBoxQualTypeName,
            this.textBox1,
            this.textBox2,
            this.textBox3});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            // 
            // textBoxQualDescription
            // 
            this.textBoxQualDescription.CanShrink = true;
            this.textBoxQualDescription.KeepTogether = false;
            this.textBoxQualDescription.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.6000789403915405D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBoxQualDescription.Name = "textBoxQualDescription";
            this.textBoxQualDescription.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.9998428821563721D), Telerik.Reporting.Drawing.Unit.Inch(0.2999214231967926D));
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
            this.textBoxQualName.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBoxQualName.Name = "textBoxQualName";
            this.textBoxQualName.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5999606847763062D), Telerik.Reporting.Drawing.Unit.Inch(0.2999214231967926D));
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
            this.textBoxQualTypeName.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.6000003814697266D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
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
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6000000238418579D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
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
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.6000789403915405D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.9998428821563721D), Telerik.Reporting.Drawing.Unit.Inch(0.19992136955261231D));
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
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.6000003814697266D), Telerik.Reporting.Drawing.Unit.Inch(7.8757606388535351E-05D));
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
            // textBoxOverAllHeader
            // 
            this.textBoxOverAllHeader.CanShrink = true;
            this.textBoxOverAllHeader.Name = "textBoxOverAllHeader";
            this.textBoxOverAllHeader.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0000004768371582D), Telerik.Reporting.Drawing.Unit.Inch(0.29999995231628418D));
            this.textBoxOverAllHeader.Style.Font.Bold = true;
            this.textBoxOverAllHeader.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBoxOverAllHeader.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxOverAllHeader.Value = "Overall Qualifications:";
            // 
            // pDExpressDataSetPositionQual
            // 
            this.pDExpressDataSetPositionQual.DataSetName = "PDExpressDataSetPositionQual";
            this.pDExpressDataSetPositionQual.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pdExpressDataSetPositionQualTableAdapter1
            // 
            this.pdExpressDataSetPositionQualTableAdapter1.ClearBeforeFill = true;
            // 
            // group1
            // 
            this.group1.DocumentMapText = null;
            this.group1.GroupFooter = this.groupFooterSection1;
            this.group1.GroupHeader = this.groupHeaderSection1;
            this.group1.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping("=Fields.PositionDescriptionID")});
            this.group1.Name = "group1";
            // 
            // groupFooterSection1
            // 
            this.groupFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D);
            this.groupFooterSection1.Name = "groupFooterSection1";
            // 
            // groupHeaderSection1
            // 
            this.groupHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134D);
            this.groupHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBoxOverAllHeader});
            this.groupHeaderSection1.KeepTogether = false;
            this.groupHeaderSection1.Name = "groupHeaderSection1";
            // 
            // PositionOverallQualifications
            // 
            this.DataSource = this.pDExpressDataSetPositionQual;
            this.Filters.AddRange(new Telerik.Reporting.Filter[] {
            new Telerik.Reporting.Filter("=Fields.PositionDescriptionID", Telerik.Reporting.FilterOperator.Equal, "=Parameters.PDID.Value")});
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            this.group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupHeaderSection1,
            this.groupFooterSection1,
            this.detail});
            this.Name = "PositionOverallQualifications";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "PDID";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Integer;
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
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(7.3000001907348633D);
            ((System.ComponentModel.ISupportInitialize)(this.pDExpressDataSetPositionQual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DetailSection detail;
        private Telerik.Reporting.TextBox textBoxOverAllHeader;
        private PDExpressDataSetPositionQual pDExpressDataSetPositionQual;
        private HCMS.Reports.PDExpressDataSetPositionQualTableAdapters.PDExpressDataSetPositionQualTableAdapter pdExpressDataSetPositionQualTableAdapter1;
        private Telerik.Reporting.TextBox textBoxQualName;
        private Telerik.Reporting.TextBox textBoxQualDescription;
        private Telerik.Reporting.TextBox textBoxQualTypeName;
        private Group group1;
        private GroupFooterSection groupFooterSection1;
        private GroupHeaderSection groupHeaderSection1;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;

    }
}
