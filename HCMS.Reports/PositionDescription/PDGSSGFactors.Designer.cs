namespace HCMS.Reports.PositionDescription
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    partial class PDGSSGFactors
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.InstanceReportSource instanceReportSource1 = new Telerik.Reporting.InstanceReportSource();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            this.positionFactorGradePointTotal1 = new HCMS.Reports.PositionDescription.PositionFactorGradePointTotal();
            this.detail = new Telerik.Reporting.DetailSection();
            this.GSSGShape1 = new Telerik.Reporting.Shape();
            this.levelIDDataTextBoxGSSG = new Telerik.Reporting.TextBox();
            this.GSSGFactorDescriptionDataTextBox = new Telerik.Reporting.TextBox();
            this.GSSGFactorTitleDataTextBox = new Telerik.Reporting.TextBox();
            this.textBoxGSSGFactorJustification = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.titleTextBoxGSSG = new Telerik.Reporting.TextBox();
            this.pDExpressDataSetGSSGFactors = new HCMS.Reports.PDExpressDataSetGSSGFactors();
            this.pdExpressDataSetGSSGFactorsTableAdapter1 = new HCMS.Reports.PDExpressDataSetGSSGFactorsTableAdapters.PDExpressDataSetGSSGFactorsTableAdapter();
            this.subrptGradePointTotal = new Telerik.Reporting.SubReport();
            this.group1 = new Telerik.Reporting.Group();
            this.groupFooterSection1 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection1 = new Telerik.Reporting.GroupHeaderSection();
            this.objectDataSource1 = new Telerik.Reporting.ObjectDataSource();
            ((System.ComponentModel.ISupportInitialize)(this.positionFactorGradePointTotal1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pDExpressDataSetGSSGFactors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // positionFactorGradePointTotal1
            // 
            this.positionFactorGradePointTotal1.Name = "PositionFactorGradePointTotal";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(1.3312498331069946D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.GSSGShape1,
            this.levelIDDataTextBoxGSSG,
            this.GSSGFactorDescriptionDataTextBox,
            this.GSSGFactorTitleDataTextBox,
            this.textBoxGSSGFactorJustification,
            this.textBox2});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            this.detail.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Inch(0D);
            // 
            // GSSGShape1
            // 
            this.GSSGShape1.Name = "GSSGShape1";
            this.GSSGShape1.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.GSSGShape1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0000004768371582D), Telerik.Reporting.Drawing.Unit.Inch(0.090000003576278687D));
            // 
            // levelIDDataTextBoxGSSG
            // 
            this.levelIDDataTextBoxGSSG.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D), Telerik.Reporting.Drawing.Unit.Inch(0.35459685325622559D));
            this.levelIDDataTextBoxGSSG.Name = "levelIDDataTextBoxGSSG";
            this.levelIDDataTextBoxGSSG.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6029666662216187D), Telerik.Reporting.Drawing.Unit.Inch(0.20000003278255463D));
            this.levelIDDataTextBoxGSSG.Style.Font.Bold = true;
            this.levelIDDataTextBoxGSSG.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.levelIDDataTextBoxGSSG.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.levelIDDataTextBoxGSSG.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.levelIDDataTextBoxGSSG.StyleName = "Data";
            this.levelIDDataTextBoxGSSG.Value = "= \"[Level \" + Fields.LevelID + \" - \"  + Fields.Point + \" points]\"";
            // 
            // GSSGFactorDescriptionDataTextBox
            // 
            this.GSSGFactorDescriptionDataTextBox.CanShrink = true;
            this.GSSGFactorDescriptionDataTextBox.KeepTogether = false;
            this.GSSGFactorDescriptionDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.58136767148971558D));
            this.GSSGFactorDescriptionDataTextBox.Name = "GSSGFactorDescriptionDataTextBox";
            this.GSSGFactorDescriptionDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7D), Telerik.Reporting.Drawing.Unit.Inch(0.24775958061218262D));
            this.GSSGFactorDescriptionDataTextBox.Style.Font.Bold = false;
            this.GSSGFactorDescriptionDataTextBox.Style.Font.Name = "Arial";
            this.GSSGFactorDescriptionDataTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.GSSGFactorDescriptionDataTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.GSSGFactorDescriptionDataTextBox.StyleName = "Data";
            this.GSSGFactorDescriptionDataTextBox.Value = "= Fields.Language";
            // 
            // GSSGFactorTitleDataTextBox
            // 
            this.GSSGFactorTitleDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.10424534231424332D));
            this.GSSGFactorTitleDataTextBox.Name = "GSSGFactorTitleDataTextBox";
            this.GSSGFactorTitleDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0000400543212891D), Telerik.Reporting.Drawing.Unit.Inch(0.20000003278255463D));
            this.GSSGFactorTitleDataTextBox.Style.Font.Bold = true;
            this.GSSGFactorTitleDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.GSSGFactorTitleDataTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.GSSGFactorTitleDataTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.GSSGFactorTitleDataTextBox.StyleName = "Data";
            this.GSSGFactorTitleDataTextBox.Value = "= Fields.FactorTitle + \": \"";
            // 
            // textBoxGSSGFactorJustification
            // 
            this.textBoxGSSGFactorJustification.CanShrink = true;
            this.textBoxGSSGFactorJustification.KeepTogether = false;
            this.textBoxGSSGFactorJustification.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(1.0773192644119263D));
            this.textBoxGSSGFactorJustification.Name = "textBoxGSSGFactorJustification";
            this.textBoxGSSGFactorJustification.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.9999213218688965D), Telerik.Reporting.Drawing.Unit.Inch(0.25389131903648376D));
            this.textBoxGSSGFactorJustification.Style.Font.Bold = false;
            this.textBoxGSSGFactorJustification.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBoxGSSGFactorJustification.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxGSSGFactorJustification.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxGSSGFactorJustification.StyleName = "Data";
            this.textBoxGSSGFactorJustification.Value = "= Fields.FactorJustification";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.859375D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6999607086181641D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.textBox2.Style.Font.Bold = true;
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox2.Value = "Factor Justification";
            // 
            // titleTextBoxGSSG
            // 
            this.titleTextBoxGSSG.CanShrink = true;
            this.titleTextBoxGSSG.KeepTogether = false;
            this.titleTextBoxGSSG.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.titleTextBoxGSSG.Name = "titleTextBoxGSSG";
            this.titleTextBoxGSSG.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.9999613761901855D), Telerik.Reporting.Drawing.Unit.Inch(0.28740167617797852D));
            this.titleTextBoxGSSG.Style.BackgroundColor = System.Drawing.Color.White;
            this.titleTextBoxGSSG.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.titleTextBoxGSSG.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.titleTextBoxGSSG.Style.Color = System.Drawing.Color.Black;
            this.titleTextBoxGSSG.Style.Font.Bold = true;
            this.titleTextBoxGSSG.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.titleTextBoxGSSG.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.titleTextBoxGSSG.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.titleTextBoxGSSG.StyleName = "Title";
            this.titleTextBoxGSSG.Value = "GSSG Factors:";
            // 
            // pDExpressDataSetGSSGFactors
            // 
            this.pDExpressDataSetGSSGFactors.DataSetName = "PDExpressDataSetGSSGFactors";
            this.pDExpressDataSetGSSGFactors.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pdExpressDataSetGSSGFactorsTableAdapter1
            // 
            this.pdExpressDataSetGSSGFactorsTableAdapter1.ClearBeforeFill = true;
            // 
            // subrptGradePointTotal
            // 
            this.subrptGradePointTotal.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.subrptGradePointTotal.Name = "subrptGradePointTotal";
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("PDID", "=Parameters.GSSGFactorsPDID.Value"));
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("FactorFormatTypeID", "=2"));
            instanceReportSource1.ReportDocument = this.positionFactorGradePointTotal1;
            this.subrptGradePointTotal.ReportSource = instanceReportSource1;
            this.subrptGradePointTotal.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.9999213218688965D), Telerik.Reporting.Drawing.Unit.Inch(0.2395833283662796D));
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
            this.groupFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.25D);
            this.groupFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.subrptGradePointTotal});
            this.groupFooterSection1.Name = "groupFooterSection1";
            // 
            // groupHeaderSection1
            // 
            this.groupHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.33000001311302185D);
            this.groupHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBoxGSSG});
            this.groupHeaderSection1.Name = "groupHeaderSection1";
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataMember = "GetData";
            this.objectDataSource1.DataSource = typeof(HCMS.Reports.PDExpressDataSetGSSGFactorsTableAdapters.PDExpressDataSetGSSGFactorsTableAdapter);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // PDGSSGFactors
            // 
            this.DataSource = this.objectDataSource1;
            this.Filters.AddRange(new Telerik.Reporting.Filter[] {
            new Telerik.Reporting.Filter("=Fields.PositionDescriptionID", Telerik.Reporting.FilterOperator.Equal, "=Parameters.GSSGFactorsPDID")});
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            this.group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupHeaderSection1,
            this.groupFooterSection1,
            this.detail});
            this.Name = "PDGSSGFactors";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "GSSGFactorsPDID";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter1.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(7.3000001907348633D);
            this.ItemDataBinding += new System.EventHandler(this.detail_ItemDataBinding);
            ((System.ComponentModel.ISupportInitialize)(this.positionFactorGradePointTotal1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pDExpressDataSetGSSGFactors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox titleTextBoxGSSG;
        private Shape GSSGShape1;
        private Telerik.Reporting.TextBox levelIDDataTextBoxGSSG;
        private Telerik.Reporting.TextBox GSSGFactorDescriptionDataTextBox;
        private Telerik.Reporting.TextBox GSSGFactorTitleDataTextBox;
        private PDExpressDataSetGSSGFactors pDExpressDataSetGSSGFactors;
        private HCMS.Reports.PDExpressDataSetGSSGFactorsTableAdapters.PDExpressDataSetGSSGFactorsTableAdapter pdExpressDataSetGSSGFactorsTableAdapter1;
        private Telerik.Reporting.TextBox textBoxGSSGFactorJustification;
        private Telerik.Reporting.TextBox textBox2;
        private SubReport subrptGradePointTotal;
        private Group group1;
        private GroupFooterSection groupFooterSection1;
        private GroupHeaderSection groupHeaderSection1;
        private PositionFactorGradePointTotal positionFactorGradePointTotal1;
        private ObjectDataSource objectDataSource1;
    }
}
