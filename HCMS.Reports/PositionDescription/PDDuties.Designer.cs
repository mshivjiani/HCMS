namespace HCMS.Reports.PositionDescription
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    partial class PDDuties
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
            this.positionDutyKSAs1 = new HCMS.Reports.PositionDescription.PositionDutyKSAs();
            this.detail = new Telerik.Reporting.DetailSection();
            this.percentageOfTimeDataTextBox = new Telerik.Reporting.TextBox();
            this.dutyDescriptionDataTextBox = new Telerik.Reporting.TextBox();
            this.textBoxRowNumber = new Telerik.Reporting.TextBox();
            this.dutyTypeDataTextBox = new Telerik.Reporting.TextBox();
            this.pDExpressDataSetDuties = new HCMS.Reports.PDExpressDataSetDuties();
            this.pdExpressDataSetDutiesTableAdapter1 = new HCMS.Reports.PDExpressDataSetDutiesTableAdapters.PDExpressDataSetDutiesTableAdapter();
            this.textBoxDutiesHeader = new Telerik.Reporting.TextBox();
            this.dutiesShape2 = new Telerik.Reporting.Shape();
            this.group1 = new Telerik.Reporting.Group();
            this.groupFooterSection1 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection1 = new Telerik.Reporting.GroupHeaderSection();
            this.group2 = new Telerik.Reporting.Group();
            this.groupFooterSection2 = new Telerik.Reporting.GroupFooterSection();
            this.shape1 = new Telerik.Reporting.Shape();
            this.groupHeaderSection2 = new Telerik.Reporting.GroupHeaderSection();
            this.subReportDutyKSAs = new Telerik.Reporting.SubReport();
            this.group3 = new Telerik.Reporting.Group();
            this.groupFooterSection3 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection3 = new Telerik.Reporting.GroupHeaderSection();
            ((System.ComponentModel.ISupportInitialize)(this.positionDutyKSAs1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pDExpressDataSetDuties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // positionDutyKSAs1
            // 
            this.positionDutyKSAs1.Name = "PositionDutyKSAs";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0D);
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            this.detail.Style.BackgroundColor = System.Drawing.Color.White;
            // 
            // percentageOfTimeDataTextBox
            // 
            this.percentageOfTimeDataTextBox.Format = "{0}";
            this.percentageOfTimeDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.6000000238418579D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.percentageOfTimeDataTextBox.Name = "percentageOfTimeDataTextBox";
            this.percentageOfTimeDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.400001049041748D), Telerik.Reporting.Drawing.Unit.Inch(0.20015738904476166D));
            this.percentageOfTimeDataTextBox.Style.Color = System.Drawing.Color.Black;
            this.percentageOfTimeDataTextBox.Style.Font.Name = "Arial";
            this.percentageOfTimeDataTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.percentageOfTimeDataTextBox.StyleName = "Data";
            this.percentageOfTimeDataTextBox.Value = "=Fields.PercentageOfTime + \"%\"";
            // 
            // dutyDescriptionDataTextBox
            // 
            this.dutyDescriptionDataTextBox.CanShrink = true;
            this.dutyDescriptionDataTextBox.KeepTogether = false;
            this.dutyDescriptionDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.20023632049560547D));
            this.dutyDescriptionDataTextBox.Name = "dutyDescriptionDataTextBox";
            this.dutyDescriptionDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0000004768371582D), Telerik.Reporting.Drawing.Unit.Inch(0.29972401261329651D));
            this.dutyDescriptionDataTextBox.Style.Color = System.Drawing.Color.Black;
            this.dutyDescriptionDataTextBox.Style.Font.Name = "Arial";
            this.dutyDescriptionDataTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.dutyDescriptionDataTextBox.StyleName = "";
            this.dutyDescriptionDataTextBox.Value = "=Fields.DutyDescription";
            // 
            // textBoxRowNumber
            // 
            this.textBoxRowNumber.Name = "textBoxRowNumber";
            this.textBoxRowNumber.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.5999212265014648D), Telerik.Reporting.Drawing.Unit.Inch(0.19999997317790985D));
            this.textBoxRowNumber.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxRowNumber.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Top;
            this.textBoxRowNumber.Value = "= RowNumber() + \". Percentage Of Time:\"";
            // 
            // dutyTypeDataTextBox
            // 
            this.dutyTypeDataTextBox.CanShrink = true;
            this.dutyTypeDataTextBox.Name = "dutyTypeDataTextBox";
            this.dutyTypeDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0000004768371582D), Telerik.Reporting.Drawing.Unit.Inch(0.30000010132789612D));
            this.dutyTypeDataTextBox.Style.Color = System.Drawing.Color.Black;
            this.dutyTypeDataTextBox.Style.Font.Bold = true;
            this.dutyTypeDataTextBox.Style.Font.Name = "Arial";
            this.dutyTypeDataTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.dutyTypeDataTextBox.StyleName = "Data";
            this.dutyTypeDataTextBox.Value = "= IIF(Fields.DutyType = \"Major\", \"Major: \", \"Other: \")";
            // 
            // pDExpressDataSetDuties
            // 
            this.pDExpressDataSetDuties.DataSetName = "PDExpressDataSetDuties";
            this.pDExpressDataSetDuties.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pdExpressDataSetDutiesTableAdapter1
            // 
            this.pdExpressDataSetDutiesTableAdapter1.ClearBeforeFill = true;
            // 
            // textBoxDutiesHeader
            // 
            this.textBoxDutiesHeader.CanShrink = true;
            this.textBoxDutiesHeader.KeepTogether = false;
            this.textBoxDutiesHeader.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBoxDutiesHeader.Name = "textBoxDutiesHeader";
            this.textBoxDutiesHeader.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0000004768371582D), Telerik.Reporting.Drawing.Unit.Inch(0.29996052384376526D));
            this.textBoxDutiesHeader.Style.BackgroundColor = System.Drawing.Color.White;
            this.textBoxDutiesHeader.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxDutiesHeader.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxDutiesHeader.Style.Font.Bold = true;
            this.textBoxDutiesHeader.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.textBoxDutiesHeader.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxDutiesHeader.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxDutiesHeader.Value = "Duties:";
            // 
            // dutiesShape2
            // 
            this.dutiesShape2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.3000788688659668D));
            this.dutiesShape2.Name = "dutiesShape2";
            this.dutiesShape2.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.dutiesShape2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7D), Telerik.Reporting.Drawing.Unit.Inch(0.059999998658895493D));
            this.dutiesShape2.Style.Font.Bold = false;
            // 
            // group1
            // 
            this.group1.DocumentMapText = null;
            this.group1.GroupFooter = this.groupFooterSection1;
            this.group1.GroupHeader = this.groupHeaderSection1;
            this.group1.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping("=Fields.DutyType")});
            this.group1.Name = "group1";
            // 
            // groupFooterSection1
            // 
            this.groupFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D);
            this.groupFooterSection1.Name = "groupFooterSection1";
            this.groupFooterSection1.Style.Visible = false;
            // 
            // groupHeaderSection1
            // 
            this.groupHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.36450472474098206D);
            this.groupHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.dutyTypeDataTextBox,
            this.dutiesShape2});
            this.groupHeaderSection1.Name = "groupHeaderSection1";
            // 
            // group2
            // 
            this.group2.DocumentMapText = null;
            this.group2.GroupFooter = this.groupFooterSection2;
            this.group2.GroupHeader = this.groupHeaderSection2;
            this.group2.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping("=Fields.DutyID")});
            this.group2.Name = "group2";
            // 
            // groupFooterSection2
            // 
            this.groupFooterSection2.Height = Telerik.Reporting.Drawing.Unit.Inch(0D);
            this.groupFooterSection2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.shape1});
            this.groupFooterSection2.Name = "groupFooterSection2";
            // 
            // shape1
            // 
            this.shape1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.036204177886247635D));
            this.shape1.Name = "shape1";
            this.shape1.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.shape1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7D), Telerik.Reporting.Drawing.Unit.Inch(0.05000000074505806D));
            // 
            // groupHeaderSection2
            // 
            this.groupHeaderSection2.Height = Telerik.Reporting.Drawing.Unit.Inch(0.93549507856369019D);
            this.groupHeaderSection2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.percentageOfTimeDataTextBox,
            this.dutyDescriptionDataTextBox,
            this.textBoxRowNumber,
            this.subReportDutyKSAs});
            this.groupHeaderSection2.KeepTogether = false;
            this.groupHeaderSection2.Name = "groupHeaderSection2";
            // 
            // subReportDutyKSAs
            // 
            this.subReportDutyKSAs.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.53549522161483765D));
            this.subReportDutyKSAs.Name = "subReportDutyKSAs";
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("dutyID", "=Fields.DutyID"));
            instanceReportSource1.ReportDocument = this.positionDutyKSAs1;
            this.subReportDutyKSAs.ReportSource = instanceReportSource1;
            this.subReportDutyKSAs.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.9999618530273438D), Telerik.Reporting.Drawing.Unit.Inch(0.299999862909317D));
            this.subReportDutyKSAs.ItemDataBound += new System.EventHandler(this.subReportDutyKSAs_ItemDataBound);
            // 
            // group3
            // 
            this.group3.GroupFooter = this.groupFooterSection3;
            this.group3.GroupHeader = this.groupHeaderSection3;
            this.group3.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping("=Fields.PositionDescriptionID")});
            this.group3.Name = "group3";
            // 
            // groupFooterSection3
            // 
            this.groupFooterSection3.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D);
            this.groupFooterSection3.Name = "groupFooterSection3";
            // 
            // groupHeaderSection3
            // 
            this.groupHeaderSection3.Height = Telerik.Reporting.Drawing.Unit.Inch(0.30000019073486328D);
            this.groupHeaderSection3.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBoxDutiesHeader});
            this.groupHeaderSection3.Name = "groupHeaderSection3";
            // 
            // PDDuties
            // 
            this.DataSource = this.pDExpressDataSetDuties;
            this.Filters.AddRange(new Telerik.Reporting.Filter[] {
            new Telerik.Reporting.Filter("=Fields.PositionDescriptionID", Telerik.Reporting.FilterOperator.Equal, "=Parameters.DutiesPDID")});
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            this.group3,
            this.group1,
            this.group2});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupHeaderSection3,
            this.groupFooterSection3,
            this.groupHeaderSection1,
            this.groupFooterSection1,
            this.groupHeaderSection2,
            this.groupFooterSection2,
            this.detail});
            this.Name = "PDDuties";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "DutiesPDID";
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
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(7.0000014305114746D);
            ((System.ComponentModel.ISupportInitialize)(this.positionDutyKSAs1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pDExpressDataSetDuties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DetailSection detail;
        private Telerik.Reporting.TextBox percentageOfTimeDataTextBox;
        private Telerik.Reporting.TextBox dutyDescriptionDataTextBox;
        private Telerik.Reporting.TextBox dutyTypeDataTextBox;
        private PDExpressDataSetDuties pDExpressDataSetDuties;
        private HCMS.Reports.PDExpressDataSetDutiesTableAdapters.PDExpressDataSetDutiesTableAdapter pdExpressDataSetDutiesTableAdapter1;
        private Telerik.Reporting.TextBox textBoxDutiesHeader;
        private Telerik.Reporting.TextBox textBoxRowNumber;
        private Shape dutiesShape2;
        private Group group1;
        private GroupFooterSection groupFooterSection1;
        private GroupHeaderSection groupHeaderSection1;
        private Group group2;
        private GroupFooterSection groupFooterSection2;
        private GroupHeaderSection groupHeaderSection2;
        private Shape shape1;
        private Group group3;
        private GroupFooterSection groupFooterSection3;
        private GroupHeaderSection groupHeaderSection3;
        private SubReport subReportDutyKSAs;
        private PositionDutyKSAs positionDutyKSAs1;

    }
}
