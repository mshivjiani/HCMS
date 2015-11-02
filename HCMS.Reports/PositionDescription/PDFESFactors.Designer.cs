namespace HCMS.Reports.PositionDescription
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    partial class PDFESFactors
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
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            this.positionFactorGradePointTotal1 = new HCMS.Reports.PositionDescription.PositionFactorGradePointTotal();
            this.titleTextBoxFES = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.fESFactorTitleDataTextBox = new Telerik.Reporting.TextBox();
            this.fESFactorDescriptionDataTextBox = new Telerik.Reporting.TextBox();
            this.levelIDDataTextBoxFES = new Telerik.Reporting.TextBox();
            this.pointDataTextBoxFES = new Telerik.Reporting.TextBox();
            this.FESShape1 = new Telerik.Reporting.Shape();
            this.textBoxFESFactorJustification = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.pDExpressDataSetFactors = new HCMS.Reports.PDExpressDataSetFactors();
            this.pdExpressDataSetFactorsTableAdapter1 = new HCMS.Reports.PDExpressDataSetFactorsTableAdapters.PDExpressDataSetFactorsTableAdapter();
            this.group1 = new Telerik.Reporting.Group();
            this.groupFooterSection1 = new Telerik.Reporting.GroupFooterSection();
            this.subrptGradePointTotal = new Telerik.Reporting.SubReport();
            this.groupHeaderSection1 = new Telerik.Reporting.GroupHeaderSection();
            this.objectDataSource1 = new Telerik.Reporting.ObjectDataSource();
            ((System.ComponentModel.ISupportInitialize)(this.positionFactorGradePointTotal1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pDExpressDataSetFactors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // positionFactorGradePointTotal1
            // 
            this.positionFactorGradePointTotal1.Name = "PositionFactorGradePointTotal";
            // 
            // titleTextBoxFES
            // 
            this.titleTextBoxFES.CanShrink = true;
            this.titleTextBoxFES.KeepTogether = false;
            this.titleTextBoxFES.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.titleTextBoxFES.Name = "titleTextBoxFES";
            this.titleTextBoxFES.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0207939147949219D), Telerik.Reporting.Drawing.Unit.Inch(0.28740167617797852D));
            this.titleTextBoxFES.Style.BackgroundColor = System.Drawing.Color.White;
            this.titleTextBoxFES.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.titleTextBoxFES.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.titleTextBoxFES.Style.Color = System.Drawing.Color.Black;
            this.titleTextBoxFES.Style.Font.Bold = true;
            this.titleTextBoxFES.Style.Font.Name = "Arial";
            this.titleTextBoxFES.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.titleTextBoxFES.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.titleTextBoxFES.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.titleTextBoxFES.StyleName = "Title";
            this.titleTextBoxFES.Value = "FES Factors:";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(1.3623032569885254D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.fESFactorTitleDataTextBox,
            this.fESFactorDescriptionDataTextBox,
            this.levelIDDataTextBoxFES,
            this.pointDataTextBoxFES,
            this.FESShape1,
            this.textBoxFESFactorJustification,
            this.textBox2});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            this.detail.Style.Font.Bold = true;
            this.detail.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.detail.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0D);
            this.detail.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Inch(0D);
            // 
            // fESFactorTitleDataTextBox
            // 
            this.fESFactorTitleDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.090788997709751129D));
            this.fESFactorTitleDataTextBox.Name = "fESFactorTitleDataTextBox";
            this.fESFactorTitleDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0207939147949219D), Telerik.Reporting.Drawing.Unit.Inch(0.20000003278255463D));
            this.fESFactorTitleDataTextBox.Style.Color = System.Drawing.Color.Black;
            this.fESFactorTitleDataTextBox.Style.Font.Bold = true;
            this.fESFactorTitleDataTextBox.Style.Font.Name = "Arial";
            this.fESFactorTitleDataTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.fESFactorTitleDataTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.fESFactorTitleDataTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.fESFactorTitleDataTextBox.StyleName = "Data";
            this.fESFactorTitleDataTextBox.Value = "= Fields.FactorTitle + \": \"";
            // 
            // fESFactorDescriptionDataTextBox
            // 
            this.fESFactorDescriptionDataTextBox.CanShrink = true;
            this.fESFactorDescriptionDataTextBox.KeepTogether = false;
            this.fESFactorDescriptionDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D), Telerik.Reporting.Drawing.Unit.Inch(0.5770835280418396D));
            this.fESFactorDescriptionDataTextBox.Name = "fESFactorDescriptionDataTextBox";
            this.fESFactorDescriptionDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0208334922790527D), Telerik.Reporting.Drawing.Unit.Inch(0.25D));
            this.fESFactorDescriptionDataTextBox.Style.Color = System.Drawing.Color.Black;
            this.fESFactorDescriptionDataTextBox.Style.Font.Bold = false;
            this.fESFactorDescriptionDataTextBox.Style.Font.Name = "Arial";
            this.fESFactorDescriptionDataTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.fESFactorDescriptionDataTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.fESFactorDescriptionDataTextBox.StyleName = "Data";
            this.fESFactorDescriptionDataTextBox.Value = "= Fields.Language";
            // 
            // levelIDDataTextBoxFES
            // 
            this.levelIDDataTextBoxFES.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D), Telerik.Reporting.Drawing.Unit.Inch(0.34803444147109985D));
            this.levelIDDataTextBoxFES.Name = "levelIDDataTextBoxFES";
            this.levelIDDataTextBoxFES.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5999606847763062D), Telerik.Reporting.Drawing.Unit.Inch(0.20000003278255463D));
            this.levelIDDataTextBoxFES.Style.Color = System.Drawing.Color.Black;
            this.levelIDDataTextBoxFES.Style.Font.Bold = true;
            this.levelIDDataTextBoxFES.Style.Font.Name = "Arial";
            this.levelIDDataTextBoxFES.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.levelIDDataTextBoxFES.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.levelIDDataTextBoxFES.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.levelIDDataTextBoxFES.StyleName = "Data";
            this.levelIDDataTextBoxFES.Value = "= \"[Factor Level \" + Fields.FactorID + \" - \" + Fields.LevelID + \"] - \"";
            // 
            // pointDataTextBoxFES
            // 
            this.pointDataTextBoxFES.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.60007905960083D), Telerik.Reporting.Drawing.Unit.Inch(0.34803444147109985D));
            this.pointDataTextBoxFES.Name = "pointDataTextBoxFES";
            this.pointDataTextBoxFES.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.92083388566970825D), Telerik.Reporting.Drawing.Unit.Inch(0.20000003278255463D));
            this.pointDataTextBoxFES.Style.Color = System.Drawing.Color.Black;
            this.pointDataTextBoxFES.Style.Font.Bold = true;
            this.pointDataTextBoxFES.Style.Font.Name = "Arial";
            this.pointDataTextBoxFES.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.pointDataTextBoxFES.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Inch(0D);
            this.pointDataTextBoxFES.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.pointDataTextBoxFES.StyleName = "Data";
            this.pointDataTextBoxFES.Value = "=Fields.Point + \" points\"";
            // 
            // FESShape1
            // 
            this.FESShape1.Name = "FESShape1";
            this.FESShape1.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.FESShape1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0208339691162109D), Telerik.Reporting.Drawing.Unit.Inch(0.090710319578647614D));
            this.FESShape1.Style.Font.Bold = false;
            // 
            // textBoxFESFactorJustification
            // 
            this.textBoxFESFactorJustification.CanShrink = true;
            this.textBoxFESFactorJustification.KeepTogether = false;
            this.textBoxFESFactorJustification.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D), Telerik.Reporting.Drawing.Unit.Inch(1.104245662689209D));
            this.textBoxFESFactorJustification.Name = "textBoxFESFactorJustification";
            this.textBoxFESFactorJustification.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0208334922790527D), Telerik.Reporting.Drawing.Unit.Inch(0.25805759429931641D));
            this.textBoxFESFactorJustification.Style.Color = System.Drawing.Color.Black;
            this.textBoxFESFactorJustification.Style.Font.Bold = false;
            this.textBoxFESFactorJustification.Style.Font.Name = "Arial";
            this.textBoxFESFactorJustification.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxFESFactorJustification.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.textBoxFESFactorJustification.StyleName = "Data";
            this.textBoxFESFactorJustification.Value = "= Fields.FactorJustification";
            this.textBoxFESFactorJustification.ItemDataBinding += new System.EventHandler(this.factorJustification_ItemDataBinding);
            // 
            // textBox2
            // 
            this.textBox2.CanShrink = true;
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D), Telerik.Reporting.Drawing.Unit.Inch(0.85208338499069214D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.6999607086181641D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.textBox2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            this.textBox2.Value = "Factor Justification";
            // 
            // pDExpressDataSetFactors
            // 
            this.pDExpressDataSetFactors.DataSetName = "PDExpressDataSetFactors";
            this.pDExpressDataSetFactors.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pdExpressDataSetFactorsTableAdapter1
            // 
            this.pdExpressDataSetFactorsTableAdapter1.ClearBeforeFill = true;
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
            this.groupFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.21863174438476563D);
            this.groupFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.subrptGradePointTotal});
            this.groupFooterSection1.Name = "groupFooterSection1";
            // 
            // subrptGradePointTotal
            // 
            this.subrptGradePointTotal.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.000118255615234375D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.subrptGradePointTotal.Name = "subrptGradePointTotal";
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("PDID", "=Parameters.FESFactorsPDID.Value"));
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("FactorFormatTypeID", "=1"));
            instanceReportSource1.ReportDocument = this.positionFactorGradePointTotal1;
            this.subrptGradePointTotal.ReportSource = instanceReportSource1;
            this.subrptGradePointTotal.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.020754337310791D), Telerik.Reporting.Drawing.Unit.Inch(0.21863174438476563D));
            // 
            // groupHeaderSection1
            // 
            this.groupHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D);
            this.groupHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBoxFES});
            this.groupHeaderSection1.Name = "groupHeaderSection1";
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataMember = "GetData";
            this.objectDataSource1.DataSource = typeof(HCMS.Reports.PDExpressDataSetFactorsTableAdapters.PDExpressDataSetFactorsTableAdapter);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // PDFESFactors
            // 
            this.DataMember = "PDExpressDataSetFactorsTable";
            this.DataSource = this.objectDataSource1;
            this.Filters.AddRange(new Telerik.Reporting.Filter[] {
            new Telerik.Reporting.Filter("=Fields.PositionDescriptionID", Telerik.Reporting.FilterOperator.Equal, "=Parameters.FESFactorsPDID")});
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            this.group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupHeaderSection1,
            this.groupFooterSection1,
            this.detail});
            this.Name = "PDFESFactors";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "FESFactorsPDID";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter1.Value = "= Parameters.FESFactorsPDID.Value";
            reportParameter1.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
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
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(7.0208725929260254D);
            this.NeedDataSource += new System.EventHandler(this.PDFESFactors_NeedDataSource);
            //this.ItemDataBinding += new System.EventHandler(this.PDFESFactors_ItemDataBinding);
            ((System.ComponentModel.ISupportInitialize)(this.positionFactorGradePointTotal1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pDExpressDataSetFactors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.TextBox titleTextBoxFES;
        private DetailSection detail;
        private Telerik.Reporting.TextBox fESFactorTitleDataTextBox;
        private Telerik.Reporting.TextBox fESFactorDescriptionDataTextBox;
        private Telerik.Reporting.TextBox levelIDDataTextBoxFES;
        private Telerik.Reporting.TextBox pointDataTextBoxFES;
        private PDExpressDataSetFactors pDExpressDataSetFactors;
        private HCMS.Reports.PDExpressDataSetFactorsTableAdapters.PDExpressDataSetFactorsTableAdapter pdExpressDataSetFactorsTableAdapter1;
        private Shape FESShape1;
        private Telerik.Reporting.TextBox textBoxFESFactorJustification;
        private Telerik.Reporting.TextBox textBox2;
        private SubReport subrptGradePointTotal;
        private Group group1;
        private GroupFooterSection groupFooterSection1;
        private GroupHeaderSection groupHeaderSection1;
        private PositionFactorGradePointTotal positionFactorGradePointTotal1;
        private ObjectDataSource objectDataSource1;
        // private HCMS.Reports.Evaluation.PositionFactorGradePoint positionFactorGradePoint1;

    }
}
