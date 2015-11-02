namespace HCMS.Reports.Comments
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    partial class PDFESRecommendations
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
            this.detail = new Telerik.Reporting.DetailSection();
            this.fESFactorTitleDataTextBox = new Telerik.Reporting.TextBox();
            this.pointDataTextBoxFES = new Telerik.Reporting.TextBox();
            this.levelIDDataTextBoxFES = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.shape1 = new Telerik.Reporting.Shape();
            this.pDFactorRecommendations = new HCMS.Reports.PDFactorRecommendations();
            this.pdFactorRecommendationTableAdapter1 = new HCMS.Reports.PDFactorRecommendationsTableAdapters.PDFactorRecommendationTableAdapter();
            this.titleTextBoxFES = new Telerik.Reporting.TextBox();
            this.group1 = new Telerik.Reporting.Group();
            this.groupFooterSection1 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection1 = new Telerik.Reporting.GroupHeaderSection();
            ((System.ComponentModel.ISupportInitialize)(this.pDFactorRecommendations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = new Telerik.Reporting.Drawing.Unit(1.5103774070739746, Telerik.Reporting.Drawing.UnitType.Inch);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.fESFactorTitleDataTextBox,
            this.pointDataTextBoxFES,
            this.levelIDDataTextBoxFES,
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.shape1});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            this.detail.Style.Font.Bold = true;
            // 
            // fESFactorTitleDataTextBox
            // 
            this.fESFactorTitleDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.099999986588954926, Telerik.Reporting.Drawing.UnitType.Inch));
            this.fESFactorTitleDataTextBox.Name = "fESFactorTitleDataTextBox";
            this.fESFactorTitleDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.9999604225158691, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000003278255463, Telerik.Reporting.Drawing.UnitType.Inch));
            this.fESFactorTitleDataTextBox.Style.Color = System.Drawing.Color.Black;
            this.fESFactorTitleDataTextBox.Style.Font.Bold = true;
            this.fESFactorTitleDataTextBox.Style.Font.Name = "Arial";
            this.fESFactorTitleDataTextBox.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(12, Telerik.Reporting.Drawing.UnitType.Point);
            this.fESFactorTitleDataTextBox.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(2, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.fESFactorTitleDataTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.fESFactorTitleDataTextBox.StyleName = "Data";
            this.fESFactorTitleDataTextBox.Value = "= Fields.FactorTitle + \": \"";
            // 
            // pointDataTextBoxFES
            // 
            this.pointDataTextBoxFES.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(1.6000394821166992, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.30000004172325134, Telerik.Reporting.Drawing.UnitType.Inch));
            this.pointDataTextBoxFES.Name = "pointDataTextBoxFES";
            this.pointDataTextBoxFES.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(2.4104173183441162, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000003278255463, Telerik.Reporting.Drawing.UnitType.Inch));
            this.pointDataTextBoxFES.Style.Color = System.Drawing.Color.Black;
            this.pointDataTextBoxFES.Style.Font.Bold = true;
            this.pointDataTextBoxFES.Style.Font.Name = "Arial";
            this.pointDataTextBoxFES.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(10, Telerik.Reporting.Drawing.UnitType.Point);
            this.pointDataTextBoxFES.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch);
            this.pointDataTextBoxFES.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.pointDataTextBoxFES.StyleName = "Data";
            this.pointDataTextBoxFES.Value = "=Fields.Point + \" points\"";
            // 
            // levelIDDataTextBoxFES
            // 
            this.levelIDDataTextBoxFES.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.30000004172325134, Telerik.Reporting.Drawing.UnitType.Inch));
            this.levelIDDataTextBoxFES.Name = "levelIDDataTextBoxFES";
            this.levelIDDataTextBoxFES.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.5999606847763062, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000003278255463, Telerik.Reporting.Drawing.UnitType.Inch));
            this.levelIDDataTextBoxFES.Style.Color = System.Drawing.Color.Black;
            this.levelIDDataTextBoxFES.Style.Font.Bold = true;
            this.levelIDDataTextBoxFES.Style.Font.Name = "Arial";
            this.levelIDDataTextBoxFES.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(10, Telerik.Reporting.Drawing.UnitType.Point);
            this.levelIDDataTextBoxFES.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(2, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.levelIDDataTextBoxFES.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.levelIDDataTextBoxFES.StyleName = "Data";
            this.levelIDDataTextBoxFES.Value = "= \"[Factor Level \" + Fields.FactorID + \" - \" + Fields.LevelID + \"] - \"";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.60000008344650269, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(2.2000000476837158, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000012218952179, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Value = "Factor Language:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.9418537198798731E-05, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(2.1999607086181641, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000012218952179, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox2.Style.Font.Bold = true;
            this.textBox2.Value = "Factor Recommendation:";
            // 
            // textBox3
            // 
            this.textBox3.CanShrink = true;
            this.textBox3.KeepTogether = false;
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.9418537198798731E-05, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.800000011920929, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.9999213218688965, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.19999997317790985, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox3.Style.Font.Bold = false;
            this.textBox3.Value = "=Fields.Language";
            // 
            // textBox4
            // 
            this.textBox4.CanShrink = true;
            this.textBox4.KeepTogether = false;
            this.textBox4.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(1.1999999284744263, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.9999604225158691, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.19999997317790985, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox4.Style.Font.Bold = false;
            this.textBox4.Value = "=Fields.RecommendationNote";
            // 
            // shape1
            // 
            this.shape1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.9378803194267675E-05, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(1.4000000953674316, Telerik.Reporting.Drawing.UnitType.Inch));
            this.shape1.Name = "shape1";
            this.shape1.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.shape1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.9999213218688965, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.099999904632568359, Telerik.Reporting.Drawing.UnitType.Inch));
            // 
            // pDFactorRecommendations
            // 
            this.pDFactorRecommendations.DataSetName = "PDFactorRecommendations";
            this.pDFactorRecommendations.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pdFactorRecommendationTableAdapter1
            // 
            this.pdFactorRecommendationTableAdapter1.ClearBeforeFill = true;
            // 
            // titleTextBoxFES
            // 
            this.titleTextBoxFES.CanShrink = true;
            this.titleTextBoxFES.KeepTogether = false;
            this.titleTextBoxFES.Name = "titleTextBoxFES";
            this.titleTextBoxFES.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.9999604225158691, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.28740167617797852, Telerik.Reporting.Drawing.UnitType.Inch));
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
            this.titleTextBoxFES.Value = "FES Factor Recommendations:";
            // 
            // group1
            // 
            this.group1.Bookmark = null;
            this.group1.Filters.AddRange(new Telerik.Reporting.Data.Filter[] {
            new Telerik.Reporting.Data.Filter("=Fields.FactorFormatTypeID", Telerik.Reporting.Data.FilterOperator.Equal, "=Parameters.FactorFormatTypeID")});
            this.group1.GroupFooter = this.groupFooterSection1;
            this.group1.GroupHeader = this.groupHeaderSection1;
            this.group1.Grouping.AddRange(new Telerik.Reporting.Data.Grouping[] {
            new Telerik.Reporting.Data.Grouping("=Fields.FactorFormatTypeID")});
            // 
            // groupFooterSection1
            // 
            this.groupFooterSection1.Height = new Telerik.Reporting.Drawing.Unit(0.0520833320915699, Telerik.Reporting.Drawing.UnitType.Inch);
            this.groupFooterSection1.Name = "groupFooterSection1";
            // 
            // groupHeaderSection1
            // 
            this.groupHeaderSection1.Height = new Telerik.Reporting.Drawing.Unit(0.30000004172325134, Telerik.Reporting.Drawing.UnitType.Inch);
            this.groupHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBoxFES});
            this.groupHeaderSection1.KeepTogether = false;
            this.groupHeaderSection1.Name = "groupHeaderSection1";
            // 
            // PDFESRecommendations
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
            reportParameter2.Value = "1";
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Width = new Telerik.Reporting.Drawing.Unit(7.3000001907348633, Telerik.Reporting.Drawing.UnitType.Inch);
            this.NeedDataSource += new System.EventHandler(this.PDFESRecommendations_NeedDataSource);
            ((System.ComponentModel.ISupportInitialize)(this.pDFactorRecommendations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private PDFactorRecommendations pDFactorRecommendations;
        private HCMS.Reports.PDFactorRecommendationsTableAdapters.PDFactorRecommendationTableAdapter pdFactorRecommendationTableAdapter1;
        private Telerik.Reporting.TextBox titleTextBoxFES;
        private Telerik.Reporting.TextBox fESFactorTitleDataTextBox;
        private Telerik.Reporting.TextBox pointDataTextBoxFES;
        private Telerik.Reporting.TextBox levelIDDataTextBoxFES;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Shape shape1;
        private Group group1;
        private GroupHeaderSection groupHeaderSection1;
        public GroupFooterSection groupFooterSection1;
    }
}
