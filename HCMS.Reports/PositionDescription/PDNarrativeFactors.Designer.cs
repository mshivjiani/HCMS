namespace HCMS.Reports.PositionDescription
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    partial class PDNarrativeFactors
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
            this.narrativeFactorTitleDataTextBox = new Telerik.Reporting.TextBox();
            this.narrativeFactorDescriptionDataTextBox = new Telerik.Reporting.TextBox();
            this.narrativeShape1 = new Telerik.Reporting.Shape();
            this.textBoxNarrativeFactorJustification = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.titleTextBoxNarrative = new Telerik.Reporting.TextBox();
            this.group1 = new Telerik.Reporting.Group();
            this.groupFooterSection1 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection1 = new Telerik.Reporting.GroupHeaderSection();
            this.pdExpressDataSetNarrativeFactorsTableAdapter1 = new HCMS.Reports.PDExpressDataSetNarrativeFactorsTableAdapters.PDExpressDataSetNarrativeFactorsTableAdapter();
            this.pdExpressDataSetNarrativeFactors = new HCMS.Reports.PDExpressDataSetNarrativeFactors();
            this.objectDataSource1 = new Telerik.Reporting.ObjectDataSource();
            ((System.ComponentModel.ISupportInitialize)(this.pdExpressDataSetNarrativeFactors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(1.1521228551864624D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.narrativeFactorTitleDataTextBox,
            this.narrativeFactorDescriptionDataTextBox,
            this.narrativeShape1,
            this.textBoxNarrativeFactorJustification,
            this.textBox2});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            //this.detail.ItemDataBinding += new System.EventHandler(this.detail_ItemDataBinding);
            // 
            // narrativeFactorTitleDataTextBox
            // 
            this.narrativeFactorTitleDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.099803291261196136D));
            this.narrativeFactorTitleDataTextBox.Name = "narrativeFactorTitleDataTextBox";
            this.narrativeFactorTitleDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.9995837211608887D), Telerik.Reporting.Drawing.Unit.Inch(0.25D));
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
            this.narrativeFactorDescriptionDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.37079396843910217D));
            this.narrativeFactorDescriptionDataTextBox.Name = "narrativeFactorDescriptionDataTextBox";
            this.narrativeFactorDescriptionDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.9995837211608887D), Telerik.Reporting.Drawing.Unit.Inch(0.25D));
            this.narrativeFactorDescriptionDataTextBox.Style.Font.Bold = false;
            this.narrativeFactorDescriptionDataTextBox.Style.Font.Name = "Arial";
            this.narrativeFactorDescriptionDataTextBox.Style.Font.Strikeout = false;
            this.narrativeFactorDescriptionDataTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.narrativeFactorDescriptionDataTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.narrativeFactorDescriptionDataTextBox.StyleName = "Data";
            this.narrativeFactorDescriptionDataTextBox.Value = "= Fields.Language";
            // 
            // narrativeShape1
            // 
            this.narrativeShape1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.047641277313232422D));
            this.narrativeShape1.Name = "narrativeShape1";
            this.narrativeShape1.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.narrativeShape1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.9999604225158691D), Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D));
            // 
            // textBoxNarrativeFactorJustification
            // 
            this.textBoxNarrativeFactorJustification.CanShrink = true;
            this.textBoxNarrativeFactorJustification.KeepTogether = false;
            this.textBoxNarrativeFactorJustification.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.90212279558181763D));
            this.textBoxNarrativeFactorJustification.Name = "textBoxNarrativeFactorJustification";
            this.textBoxNarrativeFactorJustification.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.9995837211608887D), Telerik.Reporting.Drawing.Unit.Inch(0.25D));
            this.textBoxNarrativeFactorJustification.Style.Font.Bold = false;
            this.textBoxNarrativeFactorJustification.Style.Font.Name = "Arial";
            this.textBoxNarrativeFactorJustification.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxNarrativeFactorJustification.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.textBoxNarrativeFactorJustification.StyleName = "Data";
            this.textBoxNarrativeFactorJustification.Value = "= Fields.FactorJustification";
            this.textBoxNarrativeFactorJustification.ItemDataBinding += new System.EventHandler(this.factorJustification_ItemDataBinding);
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.65212279558181763D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6999607086181641D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.textBox2.Style.Font.Bold = true;
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox2.Value = "Factor Justification";
            // 
            // titleTextBoxNarrative
            // 
            this.titleTextBoxNarrative.KeepTogether = false;
            this.titleTextBoxNarrative.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.titleTextBoxNarrative.Name = "titleTextBoxNarrative";
            this.titleTextBoxNarrative.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.9999604225158691D), Telerik.Reporting.Drawing.Unit.Inch(0.28740167617797852D));
            this.titleTextBoxNarrative.Style.BackgroundColor = System.Drawing.Color.White;
            this.titleTextBoxNarrative.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.titleTextBoxNarrative.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.titleTextBoxNarrative.Style.Color = System.Drawing.Color.Black;
            this.titleTextBoxNarrative.Style.Font.Bold = true;
            this.titleTextBoxNarrative.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.titleTextBoxNarrative.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.titleTextBoxNarrative.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.titleTextBoxNarrative.StyleName = "Title";
            this.titleTextBoxNarrative.Value = "Narrative Factors:";
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
            this.groupHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.3125D);
            this.groupHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBoxNarrative});
            this.groupHeaderSection1.KeepTogether = false;
            this.groupHeaderSection1.Name = "groupHeaderSection1";
            // 
            // pdExpressDataSetNarrativeFactorsTableAdapter1
            // 
            this.pdExpressDataSetNarrativeFactorsTableAdapter1.ClearBeforeFill = true;
            // 
            // pdExpressDataSetNarrativeFactors
            // 
            this.pdExpressDataSetNarrativeFactors.DataSetName = "PDExpressDataSetNarrativeFactors";
            this.pdExpressDataSetNarrativeFactors.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataMember = "GetData";
            this.objectDataSource1.DataSource = typeof(HCMS.Reports.PDExpressDataSetNarrativeFactorsTableAdapters.PDExpressDataSetNarrativeFactorsTableAdapter);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // PDNarrativeFactors
            // 
            this.DataSource = this.objectDataSource1;
            this.Filters.AddRange(new Telerik.Reporting.Filter[] {
            new Telerik.Reporting.Filter("=Fields.PositionDescriptionID", Telerik.Reporting.FilterOperator.Equal, "=Parameters.NFactorsPDID")});
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            this.group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupHeaderSection1,
            this.groupFooterSection1,
            this.detail});
            this.Name = "PDNarrativeFactors";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "NFactorsPDID";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter1.Value = "= Parameters.NFactorsPDID.Value";
            reportParameter1.Visible = true;
            reportParameter2.Name = "ShowFactorJustification";
            reportParameter2.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(7.3000001907348633D);
            //this.ItemDataBinding += new System.EventHandler(this.PDNarrativeFactors_ItemDataBinding);
            ((System.ComponentModel.ISupportInitialize)(this.pdExpressDataSetNarrativeFactors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox titleTextBoxNarrative;
        private Telerik.Reporting.TextBox narrativeFactorTitleDataTextBox;
        private Telerik.Reporting.TextBox narrativeFactorDescriptionDataTextBox;
        private Shape narrativeShape1;
        private Telerik.Reporting.TextBox textBoxNarrativeFactorJustification;
        private Telerik.Reporting.TextBox textBox2;
        private Group group1;
        private GroupFooterSection groupFooterSection1;
        private GroupHeaderSection groupHeaderSection1;
        private PDExpressDataSetNarrativeFactorsTableAdapters.PDExpressDataSetNarrativeFactorsTableAdapter pdExpressDataSetNarrativeFactorsTableAdapter1;
        private PDExpressDataSetNarrativeFactors pdExpressDataSetNarrativeFactors;
        private ObjectDataSource objectDataSource1;
    }
}
