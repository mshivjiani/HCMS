namespace HCMS.Reports.PositionDescription
{
    partial class PositionDutyKSAs : Telerik.Reporting.Report
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            this.detail = new Telerik.Reporting.DetailSection();
            this.textBoxDescr = new Telerik.Reporting.TextBox();
            this.textBoxQualType = new Telerik.Reporting.TextBox();
            this.textBoxQual = new Telerik.Reporting.TextBox();
            this.objectDataSource1 = new Telerik.Reporting.ObjectDataSource();
            this.reportHeaderSection1 = new Telerik.Reporting.ReportHeaderSection();
            this.textBoxHeaderQual = new Telerik.Reporting.TextBox();
            this.textBoxHeaderQualType = new Telerik.Reporting.TextBox();
            this.textBoxHeaderDescr = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.40000000596046448D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBoxDescr,
            this.textBoxQualType,
            this.textBoxQual});
            this.detail.Name = "detail";
            this.detail.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.detail.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.detail.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0D);
            // 
            // textBoxDescr
            // 
            this.textBoxDescr.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.5D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBoxDescr.Name = "textBoxDescr";
            this.textBoxDescr.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.6978380680084229D), Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134D));
            this.textBoxDescr.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBoxDescr.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBoxDescr.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBoxDescr.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBoxDescr.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBoxDescr.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBoxDescr.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0.125D);
            this.textBoxDescr.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Inch(0.05000000074505806D);
            this.textBoxDescr.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Inch(0.05000000074505806D);
            this.textBoxDescr.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxDescr.Value = "= Fields.CompetencyKSA";
            // 
            // textBoxQualType
            // 
            this.textBoxQualType.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.2000002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBoxQualType.Name = "textBoxQualType";
            this.textBoxQualType.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.7896226644515991D), Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134D));
            this.textBoxQualType.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBoxQualType.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBoxQualType.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBoxQualType.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBoxQualType.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBoxQualType.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBoxQualType.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBoxQualType.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0.125D);
            this.textBoxQualType.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Inch(0.05000000074505806D);
            this.textBoxQualType.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Inch(0.05000000074505806D);
            this.textBoxQualType.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxQualType.Value = "= Fields.QualificationTypeName";
            // 
            // textBoxQual
            // 
            this.textBoxQual.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBoxQual.Name = "textBoxQual";
            this.textBoxQual.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4999212026596069D), Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134D));
            this.textBoxQual.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBoxQual.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBoxQual.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBoxQual.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBoxQual.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBoxQual.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBoxQual.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0.125D);
            this.textBoxQual.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Inch(0.05000000074505806D);
            this.textBoxQual.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Inch(0.05000000074505806D);
            this.textBoxQual.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxQual.Value = "= Fields.QualificationName";
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataMember = "GetData";
            this.objectDataSource1.DataSource = typeof(HCMS.Reports.DutyQualDataSetTableAdapters.DutyCompetencyKSATableAdapter);
            this.objectDataSource1.Name = "objectDataSource1";
            this.objectDataSource1.Parameters.AddRange(new Telerik.Reporting.ObjectDataSourceParameter[] {
            new Telerik.Reporting.ObjectDataSourceParameter("dutyID", typeof(System.Nullable<int>), "=Parameters.dutyID.Value")});
            // 
            // reportHeaderSection1
            // 
            this.reportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134D);
            this.reportHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBoxHeaderQual,
            this.textBoxHeaderQualType,
            this.textBoxHeaderDescr});
            this.reportHeaderSection1.Name = "reportHeaderSection1";
            // 
            // textBoxHeaderQual
            // 
            this.textBoxHeaderQual.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBoxHeaderQual.Name = "textBoxHeaderQual";
            this.textBoxHeaderQual.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.4999212026596069D), Telerik.Reporting.Drawing.Unit.Inch(0.29996070265769958D));
            this.textBoxHeaderQual.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBoxHeaderQual.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBoxHeaderQual.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBoxHeaderQual.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBoxHeaderQual.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBoxHeaderQual.Style.Font.Bold = true;
            this.textBoxHeaderQual.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Inch(0.05000000074505806D);
            this.textBoxHeaderQual.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxHeaderQual.Value = "Qualification";
            // 
            // textBoxHeaderQualType
            // 
            this.textBoxHeaderQualType.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(5.1979169845581055D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBoxHeaderQualType.Name = "textBoxHeaderQualType";
            this.textBoxHeaderQualType.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.7896226644515991D), Telerik.Reporting.Drawing.Unit.Inch(0.29996064305305481D));
            this.textBoxHeaderQualType.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBoxHeaderQualType.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBoxHeaderQualType.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBoxHeaderQualType.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBoxHeaderQualType.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBoxHeaderQualType.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBoxHeaderQualType.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBoxHeaderQualType.Style.Font.Bold = true;
            this.textBoxHeaderQualType.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Inch(0.05000000074505806D);
            this.textBoxHeaderQualType.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxHeaderQualType.Value = "Qualification Type";
            // 
            // textBoxHeaderDescr
            // 
            this.textBoxHeaderDescr.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.5000001192092896D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBoxHeaderDescr.Name = "textBoxHeaderDescr";
            this.textBoxHeaderDescr.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.6978375911712646D), Telerik.Reporting.Drawing.Unit.Inch(0.29996064305305481D));
            this.textBoxHeaderDescr.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBoxHeaderDescr.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBoxHeaderDescr.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Point(0D);
            this.textBoxHeaderDescr.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBoxHeaderDescr.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Point(1D);
            this.textBoxHeaderDescr.Style.Font.Bold = true;
            this.textBoxHeaderDescr.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Inch(0.05000000074505806D);
            this.textBoxHeaderDescr.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxHeaderDescr.Value = "Description";
            // 
            // PositionDutyKSAs
            // 
            this.DataSource = this.objectDataSource1;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail,
            this.reportHeaderSection1});
            this.Name = "PositionDutyKSAs";
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "dutyID";
            reportParameter1.Text = "dutyID";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Integer;
            this.ReportParameters.Add(reportParameter1);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0.125D);
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.9896225929260254D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox textBoxDescr;
        private Telerik.Reporting.TextBox textBoxQualType;
        private Telerik.Reporting.ObjectDataSource objectDataSource1;
        private Telerik.Reporting.TextBox textBoxQual;
        private Telerik.Reporting.ReportHeaderSection reportHeaderSection1;
        private Telerik.Reporting.TextBox textBoxHeaderQual;
        private Telerik.Reporting.TextBox textBoxHeaderQualType;
        private Telerik.Reporting.TextBox textBoxHeaderDescr;
    }
}