namespace HCMS.Reports.PositionDescription
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    partial class PositionFactorGradePointTotal
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
            this.minPointCaptionTextBox = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.minPointDataTextBox = new Telerik.Reporting.TextBox();
            this.DataTotalPoints = new Telerik.Reporting.TextBox();
            this.txtGrade = new Telerik.Reporting.TextBox();
            this.lblGrade = new Telerik.Reporting.TextBox();
            this.lblTotalPoints = new Telerik.Reporting.TextBox();
            this.shape1 = new Telerik.Reporting.Shape();
            this.shape2 = new Telerik.Reporting.Shape();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.txtTotalPoints = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // minPointCaptionTextBox
            // 
            this.minPointCaptionTextBox.CanShrink = true;
            this.minPointCaptionTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.19996054470539093, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.59803485870361328, Telerik.Reporting.Drawing.UnitType.Inch));
            this.minPointCaptionTextBox.Name = "minPointCaptionTextBox";
            this.minPointCaptionTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.7999606132507324, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000000298023224, Telerik.Reporting.Drawing.UnitType.Inch));
            this.minPointCaptionTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.minPointCaptionTextBox.Style.Font.Bold = true;
            this.minPointCaptionTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.minPointCaptionTextBox.Value = "Grade Conversion Range:";
            // 
            // detail
            // 
            this.detail.Height = new Telerik.Reporting.Drawing.Unit(1.2378772497177124, Telerik.Reporting.Drawing.UnitType.Inch);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.minPointDataTextBox,
            this.minPointCaptionTextBox,
            this.DataTotalPoints,
            this.txtGrade,
            this.lblGrade,
            this.lblTotalPoints,
            this.shape1,
            this.shape2});
            this.detail.Name = "detail";
            // 
            // minPointDataTextBox
            // 
            this.minPointDataTextBox.CanShrink = true;
            this.minPointDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(2.0521621704101562, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.598074197769165, Telerik.Reporting.Drawing.UnitType.Inch));
            this.minPointDataTextBox.Name = "minPointDataTextBox";
            this.minPointDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4.34783935546875, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000000298023224, Telerik.Reporting.Drawing.UnitType.Inch));
            this.minPointDataTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.minPointDataTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.minPointDataTextBox.Value = "=Fields.MinPoint + \'-\' + Fields.MaxPoint";
            // 
            // DataTotalPoints
            // 
            this.DataTotalPoints.CanShrink = true;
            this.DataTotalPoints.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(2.0521621704101562, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.29811349511146545, Telerik.Reporting.Drawing.UnitType.Inch));
            this.DataTotalPoints.Name = "DataTotalPoints";
            this.DataTotalPoints.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4.34783935546875, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000004768371582, Telerik.Reporting.Drawing.UnitType.Inch));
            this.DataTotalPoints.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.DataTotalPoints.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.DataTotalPoints.Value = "=Fields.TotalPoints";
            // 
            // txtGrade
            // 
            this.txtGrade.CanShrink = true;
            this.txtGrade.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(2.0521621704101562, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.89807415008544922, Telerik.Reporting.Drawing.UnitType.Inch));
            this.txtGrade.Name = "txtGrade";
            this.txtGrade.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(4.3478388786315918, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000004768371582, Telerik.Reporting.Drawing.UnitType.Inch));
            this.txtGrade.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.txtGrade.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.txtGrade.Value = "=Fields.[GS Grade]";
            // 
            // lblGrade
            // 
            this.lblGrade.CanShrink = true;
            this.lblGrade.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.19999997317790985, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.89803498983383179, Telerik.Reporting.Drawing.UnitType.Inch));
            this.lblGrade.Name = "lblGrade";
            this.lblGrade.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.7999211549758911, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000000298023224, Telerik.Reporting.Drawing.UnitType.Inch));
            this.lblGrade.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.lblGrade.Style.Font.Bold = true;
            this.lblGrade.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.lblGrade.Value = "Grade:";
            // 
            // lblTotalPoints
            // 
            this.lblTotalPoints.CanShrink = true;
            this.lblTotalPoints.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0.19999997317790985, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.30000004172325134, Telerik.Reporting.Drawing.UnitType.Inch));
            this.lblTotalPoints.Name = "lblTotalPoints";
            this.lblTotalPoints.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.7999606132507324, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000000298023224, Telerik.Reporting.Drawing.UnitType.Inch));
            this.lblTotalPoints.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.lblTotalPoints.Style.Font.Bold = true;
            this.lblTotalPoints.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.lblTotalPoints.Value = "Total Points:";
            // 
            // shape1
            // 
            this.shape1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.099999986588954926, Telerik.Reporting.Drawing.UnitType.Inch));
            this.shape1.Name = "shape1";
            this.shape1.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.shape1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(7.0000004768371582, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.052083343267440796, Telerik.Reporting.Drawing.UnitType.Inch));
            this.shape1.Stretch = true;
            // 
            // shape2
            // 
            this.shape2.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(1.1478772163391113, Telerik.Reporting.Drawing.UnitType.Inch));
            this.shape2.Name = "shape2";
            this.shape2.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.shape2.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(7.0000004768371582, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.090000003576278687, Telerik.Reporting.Drawing.UnitType.Inch));
            this.shape2.Stretch = true;
            // 
            // textBox7
            // 
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(3.0416665077209473, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.35108089447021484, Telerik.Reporting.Drawing.UnitType.Inch));
            // 
            // txtTotalPoints
            // 
            this.txtTotalPoints.Name = "txtTotalPoints";
            this.txtTotalPoints.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(3.0416665077209473, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.35108089447021484, Telerik.Reporting.Drawing.UnitType.Inch));
            this.txtTotalPoints.Value = "=Fields.TotalPoinst";
            // 
            // PositionFactorGradePointTotal
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = new Telerik.Reporting.Drawing.Unit(0.5, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Left = new Telerik.Reporting.Drawing.Unit(0.5, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Right = new Telerik.Reporting.Drawing.Unit(0.5, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Top = new Telerik.Reporting.Drawing.Unit(0.5, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "PDID";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Float;
            reportParameter1.Value = "=Fields.PositionDescriptionID\r\n";
            reportParameter2.Name = "FactorFormatTypeID";
            reportParameter2.Type = Telerik.Reporting.ReportParameterType.Integer;
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
            this.Name = "PositionFactorGradePointTotal";
            this.NeedDataSource += new System.EventHandler(this.PositionFactorGradePointTotal_NeedDataSource);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.TextBox minPointCaptionTextBox;
        private DetailSection detail;
        private Telerik.Reporting.TextBox minPointDataTextBox;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox txtTotalPoints;
        private Telerik.Reporting.TextBox DataTotalPoints;
        private Telerik.Reporting.TextBox txtGrade;
        private Telerik.Reporting.TextBox lblGrade;
        private Telerik.Reporting.TextBox lblTotalPoints;
        private Shape shape1;
        private Shape shape2;

    }
}
