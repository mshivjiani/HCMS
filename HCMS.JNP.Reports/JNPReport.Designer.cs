namespace HCMS.JNP.Reports
{
    partial class JNPReport
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.InstanceReportSource instanceReportSource1 = new Telerik.Reporting.InstanceReportSource();
            Telerik.Reporting.InstanceReportSource instanceReportSource2 = new Telerik.Reporting.InstanceReportSource();
            Telerik.Reporting.InstanceReportSource instanceReportSource3 = new Telerik.Reporting.InstanceReportSource();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter3 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter4 = new Telerik.Reporting.ReportParameter();
            this.detail = new Telerik.Reporting.DetailSection();
            this.subReportJA = new Telerik.Reporting.SubReport();
            this.subReportJQ = new Telerik.Reporting.SubReport();
            this.group1 = new Telerik.Reporting.Group();
            this.groupFooterSection1 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection1 = new Telerik.Reporting.GroupHeaderSection();
            this.group2 = new Telerik.Reporting.Group();
            this.groupFooterSection2 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection2 = new Telerik.Reporting.GroupHeaderSection();
            this.group3 = new Telerik.Reporting.Group();
            this.groupFooterSection3 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection3 = new Telerik.Reporting.GroupHeaderSection();
            this.subReportCR = new Telerik.Reporting.SubReport();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.jobAnalysis1 = new HCMS.JNP.Reports.JobAnalysis();
            this.jobQuestionaire1 = new HCMS.JNP.Reports.JobQuestionaire();
            this.categoryRating1 = new HCMS.JNP.Reports.CategoryRating();
            ((System.ComponentModel.ISupportInitialize)(this.jobAnalysis1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobQuestionaire1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryRating1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D);
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            this.detail.PageBreak = Telerik.Reporting.PageBreak.None;
            this.detail.Style.Visible = false;
            // 
            // subReportJA
            // 
            this.subReportJA.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9339065551757812E-05D), Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D));
            this.subReportJA.Name = "subReportJA";
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("jNPID", "=Parameters.jNPID.Value"));
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("jAID", "=Parameters.jAID.Value"));
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("documentObjectTypeId", "1"));
            instanceReportSource1.ReportDocument = this.jobAnalysis1;
            this.subReportJA.ReportSource = instanceReportSource1;
            this.subReportJA.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4998817443847656D), Telerik.Reporting.Drawing.Unit.Inch(0.29996061325073242D));
            // 
            // subReportJQ
            // 
            this.subReportJQ.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9339065551757812E-05D), Telerik.Reporting.Drawing.Unit.Inch(7.8837074397597462E-05D));
            this.subReportJQ.Name = "subReportJQ";
            instanceReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("jNPID", "=Parameters.jNPID.Value"));
            instanceReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("documentObjectTypeId", "3"));
            instanceReportSource2.ReportDocument = this.jobQuestionaire1;
            this.subReportJQ.ReportSource = instanceReportSource2;
            this.subReportJQ.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4998817443847656D), Telerik.Reporting.Drawing.Unit.Inch(0.29992136359214783D));
            // 
            // group1
            // 
            this.group1.GroupFooter = this.groupFooterSection1;
            this.group1.GroupHeader = this.groupHeaderSection1;
            this.group1.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping(null)});
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
            this.groupHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134D);
            this.groupHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.subReportJA});
            this.groupHeaderSection1.Name = "groupHeaderSection1";
            this.groupHeaderSection1.PageBreak = Telerik.Reporting.PageBreak.After;
            // 
            // group2
            // 
            this.group2.GroupFooter = this.groupFooterSection2;
            this.group2.GroupHeader = this.groupHeaderSection2;
            this.group2.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping(null)});
            this.group2.Name = "group2";
            // 
            // groupFooterSection2
            // 
            this.groupFooterSection2.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D);
            this.groupFooterSection2.Name = "groupFooterSection2";
            this.groupFooterSection2.Style.Visible = false;
            // 
            // groupHeaderSection2
            // 
            this.groupHeaderSection2.Height = Telerik.Reporting.Drawing.Unit.Inch(0.30000019073486328D);
            this.groupHeaderSection2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.subReportJQ});
            this.groupHeaderSection2.Name = "groupHeaderSection2";
            // 
            // group3
            // 
            this.group3.GroupFooter = this.groupFooterSection3;
            this.group3.GroupHeader = this.groupHeaderSection3;
            this.group3.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping(null)});
            this.group3.Name = "group3";
            // 
            // groupFooterSection3
            // 
            this.groupFooterSection3.Height = Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D);
            this.groupFooterSection3.Name = "groupFooterSection3";
            this.groupFooterSection3.Style.Visible = false;
            // 
            // groupHeaderSection3
            // 
            this.groupHeaderSection3.Height = Telerik.Reporting.Drawing.Unit.Inch(0.299999862909317D);
            this.groupHeaderSection3.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.subReportCR});
            this.groupHeaderSection3.Name = "groupHeaderSection3";
            this.groupHeaderSection3.PageBreak = Telerik.Reporting.PageBreak.Before;
            // 
            // subReportCR
            // 
            this.subReportCR.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9339065551757812E-05D), Telerik.Reporting.Drawing.Unit.Inch(7.8678131103515625E-05D));
            this.subReportCR.Name = "subReportCR";
            instanceReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("jNPID", "=Parameters.jNPID.Value"));
            instanceReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("jAID", "=Parameters.jAID.Value"));
            instanceReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("documentObjectTypeId", "2"));
            instanceReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("cRID", "=Parameters.cRID.Value"));
            instanceReportSource3.ReportDocument = this.categoryRating1;
            this.subReportCR.ReportSource = instanceReportSource3;
            this.subReportCR.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4998817443847656D), Telerik.Reporting.Drawing.Unit.Inch(0.2999211847782135D));
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.39166656136512756D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox1,
            this.textBox2});
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9339065551757812E-05D), Telerik.Reporting.Drawing.Unit.Inch(0.091666698455810547D));
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.399960994720459D), Telerik.Reporting.Drawing.Unit.Inch(0.29162707924842834D));
            this.textBox1.Value = "=NOW().ToShortDateString()";
            // 
            // textBox2
            // 
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.7000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(0.091666698455810547D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.7999212741851807D), Telerik.Reporting.Drawing.Unit.Inch(0.29166650772094727D));
            this.textBox2.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.textBox2.Value = "=PageNumber";
            // 
            // jobAnalysis1
            // 
            this.jobAnalysis1.Name = "JobAnalysis";
            // 
            // jobQuestionaire1
            // 
            this.jobQuestionaire1.Name = "JobQuestionnaire";
            // 
            // categoryRating1
            // 
            this.categoryRating1.Name = "CategoryRating";
            // 
            // JNPReport
            // 
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            this.group1,
            this.group2,
            this.group3});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupHeaderSection1,
            this.groupFooterSection1,
            this.groupHeaderSection2,
            this.groupFooterSection2,
            this.groupHeaderSection3,
            this.groupFooterSection3,
            this.detail,
            this.pageFooterSection1});
            this.Name = "JNPReport";
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(1D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(0D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "jNPID";
            reportParameter1.Value = "= Parameters.jNPID.Value";
            reportParameter1.Visible = true;
            reportParameter2.Name = "documentObjectTypeId";
            reportParameter2.Visible = true;
            reportParameter3.Name = "jAID";
            reportParameter3.Value = "= Parameters.jAID.Value";
            reportParameter3.Visible = true;
            reportParameter4.Name = "cRID";
            reportParameter4.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.ReportParameters.Add(reportParameter3);
            this.ReportParameters.Add(reportParameter4);
            this.Style.BackgroundColor = System.Drawing.Color.Empty;
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.4999604225158691D);
            ((System.ComponentModel.ISupportInitialize)(this.jobAnalysis1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobQuestionaire1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryRating1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.SubReport subReportJA;
        private Telerik.Reporting.SubReport subReportJQ;
        private JobAnalysis jobAnalysis1;
        private Telerik.Reporting.Group group1;
        private Telerik.Reporting.GroupFooterSection groupFooterSection1;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection1;
        private Telerik.Reporting.Group group2;
        private Telerik.Reporting.GroupFooterSection groupFooterSection2;
        private Telerik.Reporting.GroupHeaderSection groupHeaderSection2;
        private Telerik.Reporting.Group group3;
        private Telerik.Reporting.GroupFooterSection groupFooterSection3;
        private CategoryRating categoryRating1;
        private JobQuestionaire jobQuestionaire1;
        public Telerik.Reporting.SubReport subReportCR;
        public Telerik.Reporting.GroupHeaderSection groupHeaderSection3;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
    }
}