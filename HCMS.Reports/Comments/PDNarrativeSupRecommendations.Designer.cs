namespace HCMS.Reports.Comments
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    partial class PDNarrativeSupRecommendations
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            this.detail = new Telerik.Reporting.DetailSection();
            this.fESFactorTitleDataTextBox = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.shape1 = new Telerik.Reporting.Shape();
            this.pDFactorRecommendations = new HCMS.Reports.PDFactorRecommendations();
            this.group1 = new Telerik.Reporting.Group();
            this.groupFooterSection1 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection1 = new Telerik.Reporting.GroupHeaderSection();
            this.titleTextBoxFES = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pDFactorRecommendations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = new Telerik.Reporting.Drawing.Unit(1.1999999284744263, Telerik.Reporting.Drawing.UnitType.Inch);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.fESFactorTitleDataTextBox,
            this.textBox1,
            this.textBox3,
            this.textBox2,
            this.textBox4,
            this.shape1});
            this.detail.Name = "detail";
            // 
            // fESFactorTitleDataTextBox
            // 
            this.fESFactorTitleDataTextBox.Name = "fESFactorTitleDataTextBox";
            this.fESFactorTitleDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(7.0000004768371582, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000003278255463, Telerik.Reporting.Drawing.UnitType.Inch));
            this.fESFactorTitleDataTextBox.Style.Color = System.Drawing.Color.Black;
            this.fESFactorTitleDataTextBox.Style.Font.Bold = true;
            this.fESFactorTitleDataTextBox.Style.Font.Name = "Arial";
            this.fESFactorTitleDataTextBox.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(12, Telerik.Reporting.Drawing.UnitType.Point);
            this.fESFactorTitleDataTextBox.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(2, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.fESFactorTitleDataTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.fESFactorTitleDataTextBox.StyleName = "Data";
            this.fESFactorTitleDataTextBox.Value = "= Fields.FactorTitle + \": \"";
            // 
            // textBox1
            // 
            this.textBox1.KeepTogether = false;
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.30000004172325134, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(2.2000000476837158, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000012218952179, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Value = "Factor Language:";
            // 
            // textBox3
            // 
            this.textBox3.CanShrink = true;
            this.textBox3.KeepTogether = false;
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.5, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.9999613761901855, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.19999997317790985, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox3.Style.Font.Bold = false;
            this.textBox3.Value = "=Fields.Language";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.699999988079071, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(2.1999607086181641, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000012218952179, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox2.Style.Font.Bold = true;
            this.textBox2.Value = "Factor Recommendation:";
            // 
            // textBox4
            // 
            this.textBox4.CanShrink = true;
            this.textBox4.KeepTogether = false;
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.90000009536743164, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(7.0000004768371582, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.19999997317790985, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox4.Style.Font.Bold = false;
            this.textBox4.Value = "=Fields.RecommendationNote";
            // 
            // shape1
            // 
            this.shape1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(1.1000000238418579, Telerik.Reporting.Drawing.UnitType.Inch));
            this.shape1.Name = "shape1";
            this.shape1.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.shape1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(7.0000004768371582, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.099999904632568359, Telerik.Reporting.Drawing.UnitType.Inch));
            // 
            // pDFactorRecommendations
            // 
            this.pDFactorRecommendations.DataSetName = "PDFactorRecommendations";
            this.pDFactorRecommendations.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // group1
            // 
            this.group1.Bookmark = null;
            this.group1.GroupFooter = this.groupFooterSection1;
            this.group1.GroupHeader = this.groupHeaderSection1;
            this.group1.Grouping.AddRange(new Telerik.Reporting.Data.Grouping[] {
            new Telerik.Reporting.Data.Grouping("=Fields.FactorFormatTypeID")});
            // 
            // groupFooterSection1
            // 
            this.groupFooterSection1.Height = new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch);
            this.groupFooterSection1.Name = "groupFooterSection1";
            // 
            // groupHeaderSection1
            // 
            this.groupHeaderSection1.Height = new Telerik.Reporting.Drawing.Unit(0.30000004172325134, Telerik.Reporting.Drawing.UnitType.Inch);
            this.groupHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBoxFES});
            this.groupHeaderSection1.Name = "groupHeaderSection1";
            // 
            // titleTextBoxFES
            // 
            this.titleTextBoxFES.CanShrink = true;
            this.titleTextBoxFES.KeepTogether = false;
            this.titleTextBoxFES.Name = "titleTextBoxFES";
            this.titleTextBoxFES.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(7.0000400543212891, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.28740167617797852, Telerik.Reporting.Drawing.UnitType.Inch));
            this.titleTextBoxFES.Style.BackgroundColor = System.Drawing.Color.White;
            this.titleTextBoxFES.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.titleTextBoxFES.Style.BorderWidth.Default = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.titleTextBoxFES.Style.Color = System.Drawing.Color.Black;
            this.titleTextBoxFES.Style.Font.Bold = true;
            this.titleTextBoxFES.Style.Font.Name = "Arial";
            this.titleTextBoxFES.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(12, Telerik.Reporting.Drawing.UnitType.Point);
            this.titleTextBoxFES.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(2, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.titleTextBoxFES.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.titleTextBoxFES.StyleName = "Title";
            this.titleTextBoxFES.Value = "Narrative Supervisory Factor Recommendations:";
            // 
            // PDNarrativeSupRecommendations
            // 
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            this.group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupHeaderSection1,
            this.groupFooterSection1,
            this.detail});
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = new Telerik.Reporting.Drawing.Unit(0.5, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Left = new Telerik.Reporting.Drawing.Unit(0.5, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Right = new Telerik.Reporting.Drawing.Unit(0.5, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Top = new Telerik.Reporting.Drawing.Unit(0.5, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "PDID";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Float;
            reportParameter1.Visible = true;
            reportParameter2.Name = "FactorFormatTypeID";
            reportParameter2.Visible = true;
            reportParameter2.Value = "4";
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
            styleRule1.Style.Color = System.Drawing.Color.Black;
            styleRule1.Style.Font.Bold = true;
            styleRule1.Style.Font.Italic = false;
            styleRule1.Style.Font.Name = "Tahoma";
            styleRule1.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(20, Telerik.Reporting.Drawing.UnitType.Point);
            styleRule1.Style.Font.Strikeout = false;
            styleRule1.Style.Font.Underline = false;
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
            styleRule2.Style.Color = System.Drawing.Color.Black;
            styleRule2.Style.Font.Name = "Tahoma";
            styleRule2.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(11, Telerik.Reporting.Drawing.UnitType.Point);
            styleRule2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
            styleRule3.Style.Font.Name = "Tahoma";
            styleRule3.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(11, Telerik.Reporting.Drawing.UnitType.Point);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("PageInfo")});
            styleRule4.Style.Font.Name = "Tahoma";
            styleRule4.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(11, Telerik.Reporting.Drawing.UnitType.Point);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4});
            this.Width = new Telerik.Reporting.Drawing.Unit(7.3000001907348633, Telerik.Reporting.Drawing.UnitType.Inch);
            this.NeedDataSource += new System.EventHandler(this.PDNarrativeSupRecommendations_NeedDataSource);
            ((System.ComponentModel.ISupportInitialize)(this.pDFactorRecommendations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DetailSection detail;
        private PDFactorRecommendations pDFactorRecommendations;
        private Group group1;
        private GroupFooterSection groupFooterSection1;
        private GroupHeaderSection groupHeaderSection1;
        private Telerik.Reporting.TextBox titleTextBoxFES;
        private Telerik.Reporting.TextBox fESFactorTitleDataTextBox;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox4;
        private Shape shape1;

    }
}
