namespace HCMS.Reports.Comments
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    partial class PDGSSGRecommendations
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
            this.GSSGFactorTitleDataTextBox = new Telerik.Reporting.TextBox();
            this.levelIDDataTextBoxGSSG = new Telerik.Reporting.TextBox();
            this.pointDataTextBoxGSSG = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.GSSGFactorDescriptionDataTextBox = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.GSSGShape1 = new Telerik.Reporting.Shape();
            this.pDFactorRecommendations = new HCMS.Reports.PDFactorRecommendations();
            this.titleTextBoxGSSG = new Telerik.Reporting.TextBox();
            this.pdFactorRecommendationTableAdapter1 = new HCMS.Reports.PDFactorRecommendationsTableAdapters.PDFactorRecommendationTableAdapter();
            this.group1 = new Telerik.Reporting.Group();
            this.groupFooterSection1 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection1 = new Telerik.Reporting.GroupHeaderSection();
            ((System.ComponentModel.ISupportInitialize)(this.pDFactorRecommendations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = new Telerik.Reporting.Drawing.Unit(1.6999999284744263, Telerik.Reporting.Drawing.UnitType.Inch);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.GSSGFactorTitleDataTextBox,
            this.levelIDDataTextBoxGSSG,
            this.pointDataTextBoxGSSG,
            this.textBox1,
            this.GSSGFactorDescriptionDataTextBox,
            this.textBox2,
            this.textBox3,
            this.GSSGShape1});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            // 
            // GSSGFactorTitleDataTextBox
            // 
            this.GSSGFactorTitleDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.099999986588954926, Telerik.Reporting.Drawing.UnitType.Inch));
            this.GSSGFactorTitleDataTextBox.Name = "GSSGFactorTitleDataTextBox";
            this.GSSGFactorTitleDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(7.0000801086425781, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000003278255463, Telerik.Reporting.Drawing.UnitType.Inch));
            this.GSSGFactorTitleDataTextBox.Style.Font.Bold = true;
            this.GSSGFactorTitleDataTextBox.Style.Font.Name = "Arial";
            this.GSSGFactorTitleDataTextBox.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(12, Telerik.Reporting.Drawing.UnitType.Point);
            this.GSSGFactorTitleDataTextBox.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(2, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.GSSGFactorTitleDataTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.GSSGFactorTitleDataTextBox.StyleName = "Data";
            this.GSSGFactorTitleDataTextBox.Value = "= Fields.FactorTitle + \": \"";
            // 
            // levelIDDataTextBoxGSSG
            // 
            this.levelIDDataTextBoxGSSG.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.9418537198798731E-05, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.40000000596046448, Telerik.Reporting.Drawing.UnitType.Inch));
            this.levelIDDataTextBoxGSSG.Name = "levelIDDataTextBoxGSSG";
            this.levelIDDataTextBoxGSSG.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.6029666662216187, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000003278255463, Telerik.Reporting.Drawing.UnitType.Inch));
            this.levelIDDataTextBoxGSSG.Style.Font.Bold = true;
            this.levelIDDataTextBoxGSSG.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(10, Telerik.Reporting.Drawing.UnitType.Point);
            this.levelIDDataTextBoxGSSG.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(2, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.levelIDDataTextBoxGSSG.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.levelIDDataTextBoxGSSG.StyleName = "Data";
            this.levelIDDataTextBoxGSSG.Value = "= \"[Factor Level \" + Fields.FactorID + \" - \" + Fields.LevelID + \"] - \"";
            // 
            // pointDataTextBoxGSSG
            // 
            this.pointDataTextBoxGSSG.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(1.603084921836853, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.40000000596046448, Telerik.Reporting.Drawing.UnitType.Inch));
            this.pointDataTextBoxGSSG.Name = "pointDataTextBoxGSSG";
            this.pointDataTextBoxGSSG.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(2.3969151973724365, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000003278255463, Telerik.Reporting.Drawing.UnitType.Inch));
            this.pointDataTextBoxGSSG.Style.Font.Bold = true;
            this.pointDataTextBoxGSSG.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(10, Telerik.Reporting.Drawing.UnitType.Point);
            this.pointDataTextBoxGSSG.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch);
            this.pointDataTextBoxGSSG.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.pointDataTextBoxGSSG.StyleName = "Data";
            this.pointDataTextBoxGSSG.Value = "=Fields.Point + \" points\"";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.9418537198798731E-05, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.699999988079071, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.7000001668930054, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000012218952179, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(10, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox1.Value = "Factor Language:";
            // 
            // GSSGFactorDescriptionDataTextBox
            // 
            this.GSSGFactorDescriptionDataTextBox.CanShrink = true;
            this.GSSGFactorDescriptionDataTextBox.KeepTogether = false;
            this.GSSGFactorDescriptionDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.90000009536743164, Telerik.Reporting.Drawing.UnitType.Inch));
            this.GSSGFactorDescriptionDataTextBox.Name = "GSSGFactorDescriptionDataTextBox";
            this.GSSGFactorDescriptionDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(7.0000400543212891, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.24775958061218262, Telerik.Reporting.Drawing.UnitType.Inch));
            this.GSSGFactorDescriptionDataTextBox.Style.Font.Bold = false;
            this.GSSGFactorDescriptionDataTextBox.Style.Font.Name = "Arial";
            this.GSSGFactorDescriptionDataTextBox.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(10, Telerik.Reporting.Drawing.UnitType.Point);
            this.GSSGFactorDescriptionDataTextBox.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(2, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.GSSGFactorDescriptionDataTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.GSSGFactorDescriptionDataTextBox.StyleName = "Data";
            this.GSSGFactorDescriptionDataTextBox.Value = "= Fields.Language";
            // 
            // textBox2
            // 
            this.textBox2.KeepTogether = false;
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(7.8837074397597462E-05, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(1.1999999284744263, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.8999212980270386, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000012218952179, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox2.Style.Font.Bold = true;
            this.textBox2.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(10, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox2.Value = "Factor Recommendation:";
            // 
            // textBox3
            // 
            this.textBox3.CanShrink = true;
            this.textBox3.KeepTogether = false;
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(1.4000000953674316, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(7.0000004768371582, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000012218952179, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox3.Value = "=Fields.RecommendationNote";
            // 
            // GSSGShape1
            // 
            this.GSSGShape1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(1.6000000238418579, Telerik.Reporting.Drawing.UnitType.Inch));
            this.GSSGShape1.Name = "GSSGShape1";
            this.GSSGShape1.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.GSSGShape1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.0000004768371582, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.090000003576278687, Telerik.Reporting.Drawing.UnitType.Inch));
            // 
            // pDFactorRecommendations
            // 
            this.pDFactorRecommendations.DataSetName = "PDFactorRecommendations";
            this.pDFactorRecommendations.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // titleTextBoxGSSG
            // 
            this.titleTextBoxGSSG.KeepTogether = false;
            this.titleTextBoxGSSG.Name = "titleTextBoxGSSG";
            this.titleTextBoxGSSG.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(7.0000014305114746, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.28740167617797852, Telerik.Reporting.Drawing.UnitType.Inch));
            this.titleTextBoxGSSG.Style.BackgroundColor = System.Drawing.Color.White;
            this.titleTextBoxGSSG.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.titleTextBoxGSSG.Style.BorderWidth.Default = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.titleTextBoxGSSG.Style.Color = System.Drawing.Color.Black;
            this.titleTextBoxGSSG.Style.Font.Bold = true;
            this.titleTextBoxGSSG.Style.Font.Name = "Arial";
            this.titleTextBoxGSSG.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(12, Telerik.Reporting.Drawing.UnitType.Point);
            this.titleTextBoxGSSG.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(2, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.titleTextBoxGSSG.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.titleTextBoxGSSG.StyleName = "Title";
            this.titleTextBoxGSSG.Value = "GSSG Factor Recommendations:";
            // 
            // pdFactorRecommendationTableAdapter1
            // 
            this.pdFactorRecommendationTableAdapter1.ClearBeforeFill = true;
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
            this.groupFooterSection1.KeepTogether = false;
            this.groupFooterSection1.Name = "groupFooterSection1";
            // 
            // groupHeaderSection1
            // 
            this.groupHeaderSection1.Height = new Telerik.Reporting.Drawing.Unit(0.30000004172325134, Telerik.Reporting.Drawing.UnitType.Inch);
            this.groupHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBoxGSSG});
            this.groupHeaderSection1.KeepTogether = false;
            this.groupHeaderSection1.Name = "groupHeaderSection1";
            // 
            // PDGSSGRecommendations
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
            reportParameter2.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter2.Visible = true;
            reportParameter2.Value = "2";
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
            this.NeedDataSource += new System.EventHandler(this.PDGSSGRecommendations_NeedDataSource);
            ((System.ComponentModel.ISupportInitialize)(this.pDFactorRecommendations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DetailSection detail;
        private PDFactorRecommendations pDFactorRecommendations;
        private Telerik.Reporting.TextBox titleTextBoxGSSG;
        private Telerik.Reporting.TextBox GSSGFactorTitleDataTextBox;
        private Telerik.Reporting.TextBox levelIDDataTextBoxGSSG;
        private Telerik.Reporting.TextBox pointDataTextBoxGSSG;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox GSSGFactorDescriptionDataTextBox;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Shape GSSGShape1;
        private HCMS.Reports.PDFactorRecommendationsTableAdapters.PDFactorRecommendationTableAdapter pdFactorRecommendationTableAdapter1;
        private Group group1;
        private GroupFooterSection groupFooterSection1;
        private GroupHeaderSection groupHeaderSection1;

    }
}
