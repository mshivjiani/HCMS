namespace HCMS.JNP.Reports
{
    partial class JNPWorkflowNoteSubRpt1
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
            this.detail = new Telerik.Reporting.DetailSection();
            this.JNPWorkflowNoteSubReport2 = new Telerik.Reporting.SubReport();
            this.titleTextBoxGSSG = new Telerik.Reporting.TextBox();
            this.jnpWorkflowNoteSubRpt21 = new HCMS.JNP.Reports.JNPWorkflowNoteSubRpt2();
            ((System.ComponentModel.ISupportInitialize)(this.jnpWorkflowNoteSubRpt21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.67708331346511841D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.JNPWorkflowNoteSubReport2,
            this.titleTextBoxGSSG});
            this.detail.Name = "detail";
            // 
            // JNPWorkflowNoteSubReport2
            // 
            this.JNPWorkflowNoteSubReport2.KeepTogether = false;
            this.JNPWorkflowNoteSubReport2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.3229166567325592D));
            this.JNPWorkflowNoteSubReport2.Name = "JNPWorkflowNoteSubReport2";
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("jNPID", "=Parameters.jNPID.Value"));
            instanceReportSource1.ReportDocument = this.jnpWorkflowNoteSubRpt21;
            this.JNPWorkflowNoteSubReport2.ReportSource = instanceReportSource1;
            this.JNPWorkflowNoteSubReport2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4435935020446777D), Telerik.Reporting.Drawing.Unit.Inch(0.31248021125793457D));
            // 
            // titleTextBoxGSSG
            // 
            this.titleTextBoxGSSG.KeepTogether = false;
            this.titleTextBoxGSSG.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.titleTextBoxGSSG.Name = "titleTextBoxGSSG";
            this.titleTextBoxGSSG.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.447878360748291D), Telerik.Reporting.Drawing.Unit.Inch(0.28740167617797852D));
            this.titleTextBoxGSSG.Style.BackgroundColor = System.Drawing.Color.White;
            this.titleTextBoxGSSG.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.titleTextBoxGSSG.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.titleTextBoxGSSG.Style.Color = System.Drawing.Color.Black;
            this.titleTextBoxGSSG.Style.Font.Bold = true;
            this.titleTextBoxGSSG.Style.Font.Name = "Arial";
            this.titleTextBoxGSSG.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(12D);
            this.titleTextBoxGSSG.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.titleTextBoxGSSG.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.titleTextBoxGSSG.StyleName = "Title";
            this.titleTextBoxGSSG.Value = "Workflow Notes:";
            // 
            // jnpWorkflowNoteSubRpt21
            // 
            this.jnpWorkflowNoteSubRpt21.Name = "JNPWorkflowNoteSubRpt2";
            // 
            // JNPWorkflowNoteSubRpt1
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.Name = "JNPWorkflowNoteSubRpt1";
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "jNPID";
            reportParameter1.Value = "= Parameters.jNPID.Value";
            reportParameter1.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.5D);
            ((System.ComponentModel.ISupportInitialize)(this.jnpWorkflowNoteSubRpt21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.SubReport JNPWorkflowNoteSubReport2;
        private Telerik.Reporting.TextBox titleTextBoxGSSG;
        private JNPWorkflowNoteSubRpt2 jnpWorkflowNoteSubRpt21;
    }
}