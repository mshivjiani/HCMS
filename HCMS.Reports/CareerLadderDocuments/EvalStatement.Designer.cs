namespace HCMS.Reports.CareerLadderDocuments
{
    partial class EvalStatement
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
            Telerik.Reporting.InstanceReportSource instanceReportSource4 = new Telerik.Reporting.InstanceReportSource();
            Telerik.Reporting.InstanceReportSource instanceReportSource5 = new Telerik.Reporting.InstanceReportSource();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            this.headerTable1 = new HCMS.Reports.CareerLadderDocuments.HeaderTable();
            this.pdfesFactors1 = new HCMS.Reports.PositionDescription.PDFESFactors();
            this.pdgssgFactors1 = new HCMS.Reports.PositionDescription.PDGSSGFactors();
            this.pdNarrativeFactors1 = new HCMS.Reports.PositionDescription.PDNarrativeFactors();
            this.pdNarrativeSupervisoryFactors1 = new HCMS.Reports.PositionDescription.PDNarrativeSupervisoryFactors();
            this.detail = new Telerik.Reporting.DetailSection();
            this.subrptPDTable = new Telerik.Reporting.SubReport();
            this.subrptFesFactors = new Telerik.Reporting.SubReport();
            this.subrptGssgFactors = new Telerik.Reporting.SubReport();
            this.subrptNarrativeFactors = new Telerik.Reporting.SubReport();
            this.subrptNarrativeSupFactors = new Telerik.Reporting.SubReport();
            this.pageFooterSection1 = new Telerik.Reporting.PageFooterSection();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            this.clpdDataSet = new HCMS.Reports.CareerLadderDocuments.CLPDDataSet();
            this.clpdTableAdapter = new HCMS.Reports.CareerLadderDocuments.CLPDDataSetTableAdapters.CLPDTableAdapter();
            this.pdTableAdapter = new HCMS.Reports.CareerLadderDocuments.CLPDDataSetTableAdapters.PDTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.headerTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdfesFactors1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdgssgFactors1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdNarrativeFactors1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdNarrativeSupervisoryFactors1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clpdDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // headerTable1
            // 
            this.headerTable1.Name = "HeaderTable";
            // 
            // pdfesFactors1
            // 
            this.pdfesFactors1.Name = "PDFESFactors";
            // 
            // pdgssgFactors1
            // 
            this.pdgssgFactors1.Name = "pdgssgFactors1";
            // 
            // pdNarrativeFactors1
            // 
            this.pdNarrativeFactors1.Name = "pdNarrativeFactors1";
            // 
            // pdNarrativeSupervisoryFactors1
            // 
            this.pdNarrativeSupervisoryFactors1.Name = "pdNarrativeSupervisoryFactors1";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(2.1999213695526123D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.subrptPDTable,
            this.subrptFesFactors,
            this.subrptGssgFactors,
            this.subrptNarrativeFactors,
            this.subrptNarrativeSupFactors});
            this.detail.Name = "detail";
            this.detail.PageBreak = Telerik.Reporting.PageBreak.After;
            this.detail.ItemDataBinding += new System.EventHandler(this.detail_ItemDataBinding);
            // 
            // subrptPDTable
            // 
            this.subrptPDTable.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.099999986588954926D));
            this.subrptPDTable.Name = "subrptPDTable";
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("DocTitle", "Evaluation Statement"));
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("ShowEvalRows", "Yes"));
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("PositionDescriptionID", "=Fields.PositionDescriptionID"));
            instanceReportSource1.ReportDocument = this.headerTable1;
            this.subrptPDTable.ReportSource = instanceReportSource1;
            this.subrptPDTable.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7D), Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134D));
            // 
            // subrptFesFactors
            // 
            this.subrptFesFactors.KeepTogether = false;
            this.subrptFesFactors.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.099999986588954926D), Telerik.Reporting.Drawing.Unit.Inch(0.50000005960464478D));
            this.subrptFesFactors.Name = "subrptFesFactors";
            instanceReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("FESFactorsPDID", "=Fields.PositionDescriptionID"));
            instanceReportSource2.ReportDocument = this.pdfesFactors1;
            this.subrptFesFactors.ReportSource = instanceReportSource2;
            this.subrptFesFactors.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.9000000953674316D), Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134D));
            this.subrptFesFactors.ItemDataBound += new System.EventHandler(this.subrptFesFactors_ItemDataBound);
            // 
            // subrptGssgFactors
            // 
            this.subrptGssgFactors.KeepTogether = false;
            this.subrptGssgFactors.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.099999986588954926D), Telerik.Reporting.Drawing.Unit.Inch(0.89999991655349731D));
            this.subrptGssgFactors.Name = "subrptGssgFactors";
            instanceReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("GSSGFactorsPDID", "=Fields.PositionDescriptionID"));
            instanceReportSource3.ReportDocument = this.pdgssgFactors1;
            this.subrptGssgFactors.ReportSource = instanceReportSource3;
            this.subrptGssgFactors.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.9000000953674316D), Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134D));
            this.subrptGssgFactors.ItemDataBound += new System.EventHandler(this.subrptGssgFactors_ItemDataBound);
            // 
            // subrptNarrativeFactors
            // 
            this.subrptNarrativeFactors.KeepTogether = false;
            this.subrptNarrativeFactors.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.099999986588954926D), Telerik.Reporting.Drawing.Unit.Inch(1.3000000715255737D));
            this.subrptNarrativeFactors.Name = "subrptNarrativeFactors";
            instanceReportSource4.Parameters.Add(new Telerik.Reporting.Parameter("NFactorsPDID", "=Fields.PositionDescriptionID"));
            instanceReportSource4.Parameters.Add(new Telerik.Reporting.Parameter("ShowFactorJustification", "=\"Yes\""));
            instanceReportSource4.ReportDocument = this.pdNarrativeFactors1;
            this.subrptNarrativeFactors.ReportSource = instanceReportSource4;
            this.subrptNarrativeFactors.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.9000000953674316D), Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134D));
            this.subrptNarrativeFactors.ItemDataBound += new System.EventHandler(this.subrptNarrativeFactors_ItemDataBound);
            // 
            // subrptNarrativeSupFactors
            // 
            this.subrptNarrativeSupFactors.KeepTogether = false;
            this.subrptNarrativeSupFactors.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.099999986588954926D), Telerik.Reporting.Drawing.Unit.Inch(1.6999999284744263D));
            this.subrptNarrativeSupFactors.Name = "subrptNarrativeSupFactors";
            instanceReportSource5.Parameters.Add(new Telerik.Reporting.Parameter("NSPDID", "=Fields.PositionDescriptionID"));
            instanceReportSource5.ReportDocument = this.pdNarrativeSupervisoryFactors1;
            this.subrptNarrativeSupFactors.ReportSource = instanceReportSource5;
            this.subrptNarrativeSupFactors.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.9000000953674316D), Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134D));
            this.subrptNarrativeSupFactors.ItemDataBound += new System.EventHandler(this.subrptNarrativeSupFactors_ItemDataBound);
            // 
            // pageFooterSection1
            // 
            this.pageFooterSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(0.3999999463558197D);
            this.pageFooterSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.currentTimeTextBox,
            this.pageInfoTextBox});
            this.pageFooterSection1.Name = "pageFooterSection1";
            // 
            // currentTimeTextBox
            // 
            this.currentTimeTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.currentTimeTextBox.Name = "currentTimeTextBox";
            this.currentTimeTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.1979167461395264D), Telerik.Reporting.Drawing.Unit.Inch(0.20000003278255463D));
            this.currentTimeTextBox.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(141)))), ((int)(((byte)(105)))));
            this.currentTimeTextBox.Style.Font.Name = "Gill Sans MT";
            this.currentTimeTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.currentTimeTextBox.StyleName = "PageInfo";
            this.currentTimeTextBox.Value = "=NOW()";
            // 
            // pageInfoTextBox
            // 
            this.pageInfoTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.2000002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.pageInfoTextBox.Name = "pageInfoTextBox";
            this.pageInfoTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.7999999523162842D), Telerik.Reporting.Drawing.Unit.Inch(0.20000003278255463D));
            this.pageInfoTextBox.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(141)))), ((int)(((byte)(105)))));
            this.pageInfoTextBox.Style.Font.Name = "Gill Sans MT";
            this.pageInfoTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.pageInfoTextBox.StyleName = "PageInfo";
            this.pageInfoTextBox.Value = "=PageNumber";
            // 
            // clpdDataSet
            // 
            this.clpdDataSet.DataSetName = "CLPDDataSet";
            this.clpdDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // clpdTableAdapter
            // 
            this.clpdTableAdapter.ClearBeforeFill = true;
            // 
            // pdTableAdapter
            // 
            this.pdTableAdapter.ClearBeforeFill = true;
            // 
            // EvalStatement
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail,
            this.pageFooterSection1});
            this.Name = "EvalStatement";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "PositionDescriptionID";
            reportParameter1.Text = "PDID?";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Float;
            reportParameter1.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(7.3000006675720215D);
            this.NeedDataSource += new System.EventHandler(this.EvalStatement_NeedDataSource);
            ((System.ComponentModel.ISupportInitialize)(this.headerTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdfesFactors1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdgssgFactors1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdNarrativeFactors1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdNarrativeSupervisoryFactors1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clpdDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooterSection1;
        private Telerik.Reporting.SubReport subrptPDTable;
        private Telerik.Reporting.TextBox currentTimeTextBox;
        private Telerik.Reporting.TextBox pageInfoTextBox;
        private Telerik.Reporting.SubReport subrptFesFactors;
        private HCMS.Reports.PositionDescription.PDFESFactors pdfesFactors1;
        private Telerik.Reporting.SubReport subrptGssgFactors;
        private HCMS.Reports.PositionDescription.PDGSSGFactors pdgssgFactors1;
        private Telerik.Reporting.SubReport subrptNarrativeFactors;
        private HCMS.Reports.PositionDescription.PDNarrativeFactors pdNarrativeFactors1;
        private Telerik.Reporting.SubReport subrptNarrativeSupFactors;
        private HCMS.Reports.PositionDescription.PDNarrativeSupervisoryFactors pdNarrativeSupervisoryFactors1;
        private CLPDDataSet clpdDataSet;
        private HCMS.Reports.CareerLadderDocuments.CLPDDataSetTableAdapters.CLPDTableAdapter clpdTableAdapter;
        private HCMS.Reports.CareerLadderDocuments.CLPDDataSetTableAdapters.PDTableAdapter pdTableAdapter;
        private HeaderTable headerTable1;
    }
}
