namespace HCMS.Reports.JobAnalysis
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    partial class PositionFactor1Language
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
            this.languageDataTextBox = new Telerik.Reporting.TextBox();
            this.factorTitleDataTextBox = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.pDExpressDataSetPositionFactor1Lang = new HCMS.Reports.PDExpressDataSetPositionFactor1Lang();
            this.pdExpressDataSetPositionFactor1LangTableAdapter1 = new HCMS.Reports.PDExpressDataSetPositionFactor1LangTableAdapters.PDExpressDataSetPositionFactor1LangTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pDExpressDataSetPositionFactor1Lang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = new Telerik.Reporting.Drawing.Unit(0.949999988079071, Telerik.Reporting.Drawing.UnitType.Inch);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.languageDataTextBox,
            this.factorTitleDataTextBox,
            this.textBox1});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            // 
            // languageDataTextBox
            // 
            this.languageDataTextBox.KeepTogether = false;
            this.languageDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.64999991655349731, Telerik.Reporting.Drawing.UnitType.Inch));
            this.languageDataTextBox.Name = "languageDataTextBox";
            this.languageDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(7.0000004768371582, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.2999214231967926, Telerik.Reporting.Drawing.UnitType.Inch));
            this.languageDataTextBox.Style.Color = System.Drawing.Color.Black;
            this.languageDataTextBox.Style.Font.Name = "Arial";
            this.languageDataTextBox.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(2, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.languageDataTextBox.StyleName = "Data";
            this.languageDataTextBox.Value = "=Fields.Language";
            // 
            // factorTitleDataTextBox
            // 
            this.factorTitleDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.29992127418518066, Telerik.Reporting.Drawing.UnitType.Inch));
            this.factorTitleDataTextBox.Name = "factorTitleDataTextBox";
            this.factorTitleDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(7.0000004768371582, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.34999999403953552, Telerik.Reporting.Drawing.UnitType.Inch));
            this.factorTitleDataTextBox.Style.Color = System.Drawing.Color.Black;
            this.factorTitleDataTextBox.Style.Font.Bold = true;
            this.factorTitleDataTextBox.Style.Font.Name = "Arial";
            this.factorTitleDataTextBox.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(9, Telerik.Reporting.Drawing.UnitType.Point);
            this.factorTitleDataTextBox.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(2, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.factorTitleDataTextBox.StyleName = "Data";
            this.factorTitleDataTextBox.Value = "=Fields.FactorTitle";
            // 
            // textBox1
            // 
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(7.0000004768371582, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.25, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(11, Telerik.Reporting.Drawing.UnitType.Point);
            this.textBox1.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(2, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox1.Value = "Factor 1 Language:";
            // 
            // pDExpressDataSetPositionFactor1Lang
            // 
            this.pDExpressDataSetPositionFactor1Lang.DataSetName = "PDExpressDataSetPositionFactor1Lang";
            this.pDExpressDataSetPositionFactor1Lang.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pdExpressDataSetPositionFactor1LangTableAdapter1
            // 
            this.pdExpressDataSetPositionFactor1LangTableAdapter1.ClearBeforeFill = true;
            // 
            // PositionFactor1Language
            // 
            this.DataSource = this.pDExpressDataSetPositionFactor1Lang;
            this.Filters.AddRange(new Telerik.Reporting.Data.Filter[] {
            new Telerik.Reporting.Data.Filter("=Fields.PositionDescriptionID", Telerik.Reporting.Data.FilterOperator.Equal, "=Parameters.PDID")});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = new Telerik.Reporting.Drawing.Unit(0.5, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Left = new Telerik.Reporting.Drawing.Unit(0.5, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Right = new Telerik.Reporting.Drawing.Unit(0.5, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Top = new Telerik.Reporting.Drawing.Unit(0.10000000149011612, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "PDID";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Integer;
            this.ReportParameters.Add(reportParameter1);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
            styleRule1.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(222)))), ((int)(((byte)(201)))));
            styleRule1.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(39)))), ((int)(((byte)(28)))));
            styleRule1.Style.Font.Name = "Gill Sans MT";
            styleRule1.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(20, Telerik.Reporting.Drawing.UnitType.Point);
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
            styleRule2.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(222)))), ((int)(((byte)(201)))));
            styleRule2.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(39)))), ((int)(((byte)(28)))));
            styleRule2.Style.Font.Name = "Gill Sans MT";
            styleRule2.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(10, Telerik.Reporting.Drawing.UnitType.Point);
            styleRule2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
            styleRule3.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(39)))), ((int)(((byte)(28)))));
            styleRule3.Style.Font.Name = "Gill Sans MT";
            styleRule3.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(10, Telerik.Reporting.Drawing.UnitType.Point);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("PageInfo")});
            styleRule4.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(141)))), ((int)(((byte)(105)))));
            styleRule4.Style.Font.Name = "Gill Sans MT";
            styleRule4.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(9, Telerik.Reporting.Drawing.UnitType.Point);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4});
            this.Width = new Telerik.Reporting.Drawing.Unit(7.3000001907348633, Telerik.Reporting.Drawing.UnitType.Inch);
            this.Name = "PositionFactor1Language";
            ((System.ComponentModel.ISupportInitialize)(this.pDExpressDataSetPositionFactor1Lang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private DetailSection detail;
        private Telerik.Reporting.TextBox languageDataTextBox;
        private Telerik.Reporting.TextBox factorTitleDataTextBox;
        private PDExpressDataSetPositionFactor1Lang pDExpressDataSetPositionFactor1Lang;
        private HCMS.Reports.PDExpressDataSetPositionFactor1LangTableAdapters.PDExpressDataSetPositionFactor1LangTableAdapter pdExpressDataSetPositionFactor1LangTableAdapter1;
        private Telerik.Reporting.TextBox textBox1;

    }
}