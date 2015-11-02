namespace HCMS.Reports.JobAnalysis
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using HCMS.Reports.PositionDescription;
    partial class JDDuties
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
            this.dutyQualifications1 = new HCMS.Reports.JobAnalysis.DutyQualifications();
            this.detail = new Telerik.Reporting.DetailSection();
            this.subReportDutyQual = new Telerik.Reporting.SubReport();
            this.percentageOfTimeDataTextBox = new Telerik.Reporting.TextBox();
            this.dutyDescriptionDataTextBox = new Telerik.Reporting.TextBox();
            this.textBoxRowNumber = new Telerik.Reporting.TextBox();
            this.dutyTypeDataTextBox = new Telerik.Reporting.TextBox();
            this.pDExpressDataSetDuties = new HCMS.Reports.PDExpressDataSetDuties();
            this.pdExpressDataSetDutiesTableAdapter1 = new HCMS.Reports.PDExpressDataSetDutiesTableAdapters.PDExpressDataSetDutiesTableAdapter();
            this.reportHeaderSection1 = new Telerik.Reporting.ReportHeaderSection();
            this.textBoxDutiesHeader = new Telerik.Reporting.TextBox();
            this.dutiesShape2 = new Telerik.Reporting.Shape();
            this.group1 = new Telerik.Reporting.Group();
            this.groupFooterSection1 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection1 = new Telerik.Reporting.GroupHeaderSection();
            this.reportFooterSection1 = new Telerik.Reporting.ReportFooterSection();
            this.group2 = new Telerik.Reporting.Group();
            this.groupFooterSection2 = new Telerik.Reporting.GroupFooterSection();
            this.shape1 = new Telerik.Reporting.Shape();
            this.groupHeaderSection2 = new Telerik.Reporting.GroupHeaderSection();
            ((System.ComponentModel.ISupportInitialize)(this.dutyQualifications1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pDExpressDataSetDuties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // dutyQualifications1
            // 
            this.dutyQualifications1.Name = "dutyQualifications1";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0D);
            this.detail.Name = "detail";
            // 
            // subReportDutyQual
            // 
            this.subReportDutyQual.KeepTogether = false;
            this.subReportDutyQual.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.00011889139568665996D), Telerik.Reporting.Drawing.Unit.Inch(0.535456120967865D));
            this.subReportDutyQual.Name = "subReportDutyQual";
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("DutyID", "=Fields.DutyID"));
            instanceReportSource1.ReportDocument = this.dutyQualifications1;
            this.subReportDutyQual.ReportSource = instanceReportSource1;
            this.subReportDutyQual.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.9998817443847656D), Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134D));
            this.subReportDutyQual.ItemDataBound += new System.EventHandler(this.subReportDutyQual_ItemDataBound);
            // 
            // percentageOfTimeDataTextBox
            // 
            this.percentageOfTimeDataTextBox.Format = "{0}";
            this.percentageOfTimeDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.6000000238418579D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.percentageOfTimeDataTextBox.Name = "percentageOfTimeDataTextBox";
            this.percentageOfTimeDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.4000000953674316D), Telerik.Reporting.Drawing.Unit.Inch(0.20015738904476166D));
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
            this.dutyDescriptionDataTextBox.StyleName = "Data";
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
            this.dutyTypeDataTextBox.KeepTogether = false;
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
            // reportHeaderSection1
            // 
            this.reportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.299999862909317D);
            this.reportHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBoxDutiesHeader});
            this.reportHeaderSection1.KeepTogether = false;
            this.reportHeaderSection1.Name = "reportHeaderSection1";
            // 
            // textBoxDutiesHeader
            // 
            this.textBoxDutiesHeader.KeepTogether = false;
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
            this.dutiesShape2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.9999604225158691D), Telerik.Reporting.Drawing.Unit.Inch(0.064425863325595856D));
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
            this.groupFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0D);
            this.groupFooterSection1.Name = "groupFooterSection1";
            // 
            // groupHeaderSection1
            // 
            this.groupHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.36450472474098206D);
            this.groupHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.dutyTypeDataTextBox,
            this.dutiesShape2});
            this.groupHeaderSection1.Name = "groupHeaderSection1";
            // 
            // reportFooterSection1
            // 
            this.reportFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D);
            this.reportFooterSection1.KeepTogether = false;
            this.reportFooterSection1.Name = "reportFooterSection1";
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
            this.groupFooterSection2.Height = Telerik.Reporting.Drawing.Unit.Inch(0.088287509977817535D);
            this.groupFooterSection2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.shape1});
            this.groupFooterSection2.Name = "groupFooterSection2";
            // 
            // shape1
            // 
            this.shape1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.036204177886247635D));
            this.shape1.Name = "shape1";
            this.shape1.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.shape1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.9999604225158691D), Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D));
            // 
            // groupHeaderSection2
            // 
            this.groupHeaderSection2.Height = Telerik.Reporting.Drawing.Unit.Inch(0.83549553155899048D);
            this.groupHeaderSection2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.percentageOfTimeDataTextBox,
            this.dutyDescriptionDataTextBox,
            this.textBoxRowNumber,
            this.subReportDutyQual});
            this.groupHeaderSection2.KeepTogether = false;
            this.groupHeaderSection2.Name = "groupHeaderSection2";
            // 
            // JDDuties
            // 
            this.DataSource = this.pDExpressDataSetDuties;
            this.Filters.AddRange(new Telerik.Reporting.Filter[] {
            new Telerik.Reporting.Filter("=Fields.PositionDescriptionID", Telerik.Reporting.FilterOperator.Equal, "=Parameters.DutiesPDID")});
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            this.group1,
            this.group2});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupHeaderSection1,
            this.groupFooterSection1,
            this.groupHeaderSection2,
            this.groupFooterSection2,
            this.detail,
            this.reportHeaderSection1,
            this.reportFooterSection1});
            this.Name = "JDDuties";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "DutiesPDID";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter1.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.Style.BackgroundColor = System.Drawing.Color.White;
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
            ((System.ComponentModel.ISupportInitialize)(this.dutyQualifications1)).EndInit();
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
        private ReportHeaderSection reportHeaderSection1;
        private Telerik.Reporting.TextBox textBoxDutiesHeader;
        private Telerik.Reporting.TextBox textBoxRowNumber;
        private Shape dutiesShape2;
        private Group group1;
        private GroupFooterSection groupFooterSection1;
        private GroupHeaderSection groupHeaderSection1;
        private ReportFooterSection reportFooterSection1;
        private Group group2;
        private GroupFooterSection groupFooterSection2;
        private GroupHeaderSection groupHeaderSection2;
        private Shape shape1;
        private SubReport subReportDutyQual;
        private HCMS.Reports.JobAnalysis.DutyQualifications dutyQualifications1;

    }
}