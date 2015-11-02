namespace HCMS.Reports.PositionDescription
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    partial class PDNarrativeSupervisoryFactors
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
            this.titleTextBoxNarrative = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.narrativeShape1 = new Telerik.Reporting.Shape();
            this.narrativeFactorTitleDataTextBox = new Telerik.Reporting.TextBox();
            this.narrativeFactorDescriptionDataTextBox = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBoxNarrativeFactorJustification = new Telerik.Reporting.TextBox();
            this.pDExpressDataSetNarrativeSupervisoryFactors = new HCMS.Reports.PDExpressDataSetNarrativeSupervisoryFactors();
            this.pdExpressDataSetNarrativeSupervisoryFactorsTableAdapter1 = new HCMS.Reports.PDExpressDataSetNarrativeSupervisoryFactorsTableAdapters.PDExpressDataSetNarrativeSupervisoryFactorsTableAdapter();
            this.group1 = new Telerik.Reporting.Group();
            this.groupFooterSection1 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection1 = new Telerik.Reporting.GroupHeaderSection();
            this.objectDataSource1 = new Telerik.Reporting.ObjectDataSource();
            ((System.ComponentModel.ISupportInitialize)(this.pDExpressDataSetNarrativeSupervisoryFactors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // titleTextBoxNarrative
            // 
            this.titleTextBoxNarrative.KeepTogether = false;
            this.titleTextBoxNarrative.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.titleTextBoxNarrative.Name = "titleTextBoxNarrative";
            this.titleTextBoxNarrative.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0103778839111328D), Telerik.Reporting.Drawing.Unit.Inch(0.28740167617797852D));
            this.titleTextBoxNarrative.Style.BackgroundColor = System.Drawing.Color.White;
            this.titleTextBoxNarrative.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.titleTextBoxNarrative.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.titleTextBoxNarrative.Style.Color = System.Drawing.Color.Black;
            this.titleTextBoxNarrative.Style.Font.Bold = true;
            this.titleTextBoxNarrative.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.titleTextBoxNarrative.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.titleTextBoxNarrative.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.titleTextBoxNarrative.StyleName = "Title";
            this.titleTextBoxNarrative.Value = "Narrative Supervisory Factors:";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(1.1999999284744263D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.narrativeShape1,
            this.narrativeFactorTitleDataTextBox,
            this.narrativeFactorDescriptionDataTextBox,
            this.textBox2,
            this.textBoxNarrativeFactorJustification});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            // 
            // narrativeShape1
            // 
            this.narrativeShape1.Name = "narrativeShape1";
            this.narrativeShape1.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.narrativeShape1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0103778839111328D), Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D));
            // 
            // narrativeFactorTitleDataTextBox
            // 
            this.narrativeFactorTitleDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.099999986588954926D));
            this.narrativeFactorTitleDataTextBox.Name = "narrativeFactorTitleDataTextBox";
            this.narrativeFactorTitleDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0100007057189941D), Telerik.Reporting.Drawing.Unit.Inch(0.25D));
            this.narrativeFactorTitleDataTextBox.Style.Font.Bold = true;
            this.narrativeFactorTitleDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.narrativeFactorTitleDataTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.narrativeFactorTitleDataTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.narrativeFactorTitleDataTextBox.StyleName = "Data";
            this.narrativeFactorTitleDataTextBox.Value = "= Fields.FactorTitle + \": \"";
            // 
            // narrativeFactorDescriptionDataTextBox
            // 
            this.narrativeFactorDescriptionDataTextBox.CanShrink = true;
            this.narrativeFactorDescriptionDataTextBox.KeepTogether = false;
            this.narrativeFactorDescriptionDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D));
            this.narrativeFactorDescriptionDataTextBox.Name = "narrativeFactorDescriptionDataTextBox";
            this.narrativeFactorDescriptionDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0100007057189941D), Telerik.Reporting.Drawing.Unit.Inch(0.25D));
            this.narrativeFactorDescriptionDataTextBox.Style.Font.Bold = false;
            this.narrativeFactorDescriptionDataTextBox.Style.Font.Name = "Arial";
            this.narrativeFactorDescriptionDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.narrativeFactorDescriptionDataTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.narrativeFactorDescriptionDataTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.narrativeFactorDescriptionDataTextBox.StyleName = "Data";
            this.narrativeFactorDescriptionDataTextBox.Value = "= Fields.Language";
            // 
            // textBox2
            // 
            this.textBox2.CanGrow = true;
            this.textBox2.CanShrink = true;
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.699999988079071D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6999607086181641D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.textBox2.Style.Font.Bold = true;
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox2.Value = "Factor Justification";
            // 
            // textBoxNarrativeFactorJustification
            // 
            this.textBoxNarrativeFactorJustification.CanShrink = true;
            this.textBoxNarrativeFactorJustification.KeepTogether = false;
            this.textBoxNarrativeFactorJustification.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.89999991655349731D));
            this.textBoxNarrativeFactorJustification.Name = "textBoxNarrativeFactorJustification";
            this.textBoxNarrativeFactorJustification.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0000004768371582D), Telerik.Reporting.Drawing.Unit.Inch(0.25D));
            this.textBoxNarrativeFactorJustification.Style.Font.Bold = false;
            this.textBoxNarrativeFactorJustification.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBoxNarrativeFactorJustification.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxNarrativeFactorJustification.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.textBoxNarrativeFactorJustification.Value = "= Fields.FactorJustification";
            // 
            // pDExpressDataSetNarrativeSupervisoryFactors
            // 
            this.pDExpressDataSetNarrativeSupervisoryFactors.DataSetName = "PDExpressDataSetNarrativeSupervisoryFactors";
            this.pDExpressDataSetNarrativeSupervisoryFactors.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pdExpressDataSetNarrativeSupervisoryFactorsTableAdapter1
            // 
            this.pdExpressDataSetNarrativeSupervisoryFactorsTableAdapter1.ClearBeforeFill = true;
            // 
            // group1
            // 
            this.group1.GroupFooter = this.groupFooterSection1;
            this.group1.GroupHeader = this.groupHeaderSection1;
            this.group1.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping("=Fields.PositionDescriptionID")});
            this.group1.Name = "group1";
            // 
            // groupFooterSection1
            // 
            this.groupFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0D);
            this.groupFooterSection1.Name = "groupFooterSection1";
            // 
            // groupHeaderSection1
            // 
            this.groupHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28740167617797852D);
            this.groupHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBoxNarrative});
            this.groupHeaderSection1.Name = "groupHeaderSection1";
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataMember = "GetData";
            this.objectDataSource1.DataSource = this.pdExpressDataSetNarrativeSupervisoryFactorsTableAdapter1;
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // PDNarrativeSupervisoryFactors
            // 
            this.DataSource = this.objectDataSource1;
            this.Filters.AddRange(new Telerik.Reporting.Filter[] {
            new Telerik.Reporting.Filter("=Fields.PositionDescriptionID", Telerik.Reporting.FilterOperator.Equal, "=Parameters.NSPDID")});
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            this.group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupHeaderSection1,
            this.groupFooterSection1,
            this.detail});
            this.Name = "PDNarrativeSupervisoryFactors";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "NSPDID";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Integer;
            this.ReportParameters.Add(reportParameter1);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
            styleRule1.Style.Color = System.Drawing.Color.Black;
            styleRule1.Style.Font.Bold = true;
            styleRule1.Style.Font.Italic = false;
            styleRule1.Style.Font.Name = "Tahoma";
            styleRule1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(20D);
            styleRule1.Style.Font.Strikeout = false;
            styleRule1.Style.Font.Underline = false;
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
            styleRule2.Style.Color = System.Drawing.Color.Black;
            styleRule2.Style.Font.Name = "Tahoma";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            styleRule2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
            styleRule3.Style.Font.Name = "Tahoma";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("PageInfo")});
            styleRule4.Style.Font.Name = "Tahoma";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4});
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(7.3000001907348633D);
            this.ItemDataBinding += new System.EventHandler(this.PDNarrativeSupervisoryFactors_ItemDataBinding);
            ((System.ComponentModel.ISupportInitialize)(this.pDExpressDataSetNarrativeSupervisoryFactors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DetailSection detail;
        private PDExpressDataSetNarrativeSupervisoryFactors pDExpressDataSetNarrativeSupervisoryFactors;
        private HCMS.Reports.PDExpressDataSetNarrativeSupervisoryFactorsTableAdapters.PDExpressDataSetNarrativeSupervisoryFactorsTableAdapter pdExpressDataSetNarrativeSupervisoryFactorsTableAdapter1;
        private Telerik.Reporting.TextBox titleTextBoxNarrative;
        private Shape narrativeShape1;
        private Telerik.Reporting.TextBox narrativeFactorTitleDataTextBox;
        private Telerik.Reporting.TextBox narrativeFactorDescriptionDataTextBox;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBoxNarrativeFactorJustification;
        private Group group1;
        private GroupFooterSection groupFooterSection1;
        private GroupHeaderSection groupHeaderSection1;
        private ObjectDataSource objectDataSource1;

    }
}
