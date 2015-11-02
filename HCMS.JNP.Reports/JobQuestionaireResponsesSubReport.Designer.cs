namespace HCMS.JNP.Reports
{
    partial class JobQuestionaireResponsesSubReport
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
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.objDataSourceResponses = new Telerik.Reporting.ObjectDataSource();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.23962266743183136D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox3,
            this.textBox2});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.29996061325073242D), Telerik.Reporting.Drawing.Unit.Inch(0.22739844024181366D));
            this.textBox3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox3.Style.Font.Bold = false;
            this.textBox3.StyleName = "";
            this.textBox3.Value = "= Fields.JQResponseLetter";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.3333333432674408D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.0832161903381348D), Telerik.Reporting.Drawing.Unit.Inch(0.22739844024181366D));
            this.textBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox2.StyleName = "";
            this.textBox2.Value = "= Fields.JQResponseText";
            // 
            // objDataSourceResponses
            // 
            this.objDataSourceResponses.DataMember = "GetData";
            this.objDataSourceResponses.DataSource = typeof(HCMS.JNP.Reports.JNPDataSetTableAdapters.xref_RatingScaleResponseTableAdapter);
            this.objDataSourceResponses.Name = "objDataSourceResponses";
            this.objDataSourceResponses.Parameters.AddRange(new Telerik.Reporting.ObjectDataSourceParameter[] {
            new Telerik.Reporting.ObjectDataSourceParameter("JQRatingScaleID", typeof(long), "=Parameters.jQRatingScaleID.Value")});
            // 
            // JobQuestionaireResponsesSubReport
            // 
            this.DataSource = this.objDataSourceResponses;
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.Name = "JobQuestionaireResponsesSubReport";
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.AllowNull = true;
            reportParameter1.Name = "jQRatingScaleID";
            reportParameter1.Value = "= Parameters.jQRatingScaleID.Value";
            reportParameter1.Visible = true;
            reportParameter2.AllowNull = true;
            reportParameter2.Name = "jQFactorItemID";
            reportParameter2.Value = "= Parameters.jQFactorItemID.Value";
            reportParameter2.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.44444465637207D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.ObjectDataSource objDataSourceResponses;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox2;
    }
}