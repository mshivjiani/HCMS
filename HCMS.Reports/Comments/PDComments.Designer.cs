namespace HCMS.Reports.Comments
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    partial class PDComments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDComments));
            Telerik.Reporting.TableGroup tableGroup1 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup2 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup3 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup4 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup5 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup6 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup7 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup8 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup9 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup10 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup11 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup12 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup13 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup14 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup15 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup16 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup17 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup18 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup19 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup20 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup21 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup22 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup23 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            this.pdWorkflowComments1 = new HCMS.Reports.Comments.PDWorkflowComments();
            this.pdfesRecommendations1 = new HCMS.Reports.Comments.PDFESRecommendations();
            this.pdgssgRecommendations1 = new HCMS.Reports.Comments.PDGSSGRecommendations();
            this.pdNarrativeRecommendations1 = new HCMS.Reports.Comments.PDNarrativeRecommendations();
            this.pdNarrativeSupRecommendations1 = new HCMS.Reports.Comments.PDNarrativeSupRecommendations();
            this.detail = new Telerik.Reporting.DetailSection();
            this.subrptWorkflowNotes = new Telerik.Reporting.SubReport();
            this.subrptFESRecomm = new Telerik.Reporting.SubReport();
            this.subrptGSSGRecomm = new Telerik.Reporting.SubReport();
            this.subrptNarrativeRecomm = new Telerik.Reporting.SubReport();
            this.subrptNarrativeSupRecomm = new Telerik.Reporting.SubReport();
            this.pageFooter = new Telerik.Reporting.PageFooterSection();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            this.reportHeaderSection1 = new Telerik.Reporting.ReportHeaderSection();
            this.pictureBox1 = new Telerik.Reporting.PictureBox();
            this.textBoxPDHeader = new Telerik.Reporting.TextBox();
            this.tablePDDetails = new Telerik.Reporting.Table();
            this.textBoxPDNoCaption = new Telerik.Reporting.TextBox();
            this.textBoxPDNoData = new Telerik.Reporting.TextBox();
            this.textBoxPayPlanCaption = new Telerik.Reporting.TextBox();
            this.textBoxPayPlanData = new Telerik.Reporting.TextBox();
            this.textBoxFPLevelCaption = new Telerik.Reporting.TextBox();
            this.textBoxOPMTitleCaption = new Telerik.Reporting.TextBox();
            this.textBoxFWSTitleCaption = new Telerik.Reporting.TextBox();
            this.textBoxDutyLocationCaption = new Telerik.Reporting.TextBox();
            this.textBoxCertifiedByCaption = new Telerik.Reporting.TextBox();
            this.textBoxClassifiedByCaption = new Telerik.Reporting.TextBox();
            this.textBoxFWSTitleData = new Telerik.Reporting.TextBox();
            this.textBoxOPMTitleData = new Telerik.Reporting.TextBox();
            this.textBoxDutyLocationData = new Telerik.Reporting.TextBox();
            this.textBoxClassifiedByData = new Telerik.Reporting.TextBox();
            this.textBoxCertifiedByData = new Telerik.Reporting.TextBox();
            this.textBoxFPLevelData = new Telerik.Reporting.TextBox();
            this.textBoxFPPSIDCaption = new Telerik.Reporting.TextBox();
            this.textBoxFPPSData = new Telerik.Reporting.TextBox();
            this.textBoxCertifiedOnCaption = new Telerik.Reporting.TextBox();
            this.textBoxClassifiedOnCaption = new Telerik.Reporting.TextBox();
            this.textBoxClassifiedOnData = new Telerik.Reporting.TextBox();
            this.textBoxCertifiedOnData = new Telerik.Reporting.TextBox();
            this.classifierTitleCaption = new Telerik.Reporting.TextBox();
            this.supervisorTitleCaption = new Telerik.Reporting.TextBox();
            this.textBoxSupervisorOrgTitleData = new Telerik.Reporting.TextBox();
            this.textBoxClassifierOrgTitleData = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.pdDataSet1 = new HCMS.Reports.PDDataSet();
            this.positionDescriptionTableAdapter1 = new HCMS.Reports.PDDataSetTableAdapters.PositionDescriptionTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pdWorkflowComments1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdfesRecommendations1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdgssgRecommendations1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdNarrativeRecommendations1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdNarrativeSupRecommendations1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pdWorkflowComments1
            // 
            this.pdWorkflowComments1.Name = "pdWorkflowComments1";
            // 
            // pdfesRecommendations1
            // 
            this.pdfesRecommendations1.Name = "pdfesRecommendations1";
            // 
            // pdgssgRecommendations1
            // 
            this.pdgssgRecommendations1.Name = "pdgssgRecommendations1";
            // 
            // pdNarrativeRecommendations1
            // 
            this.pdNarrativeRecommendations1.Name = "pdNarrativeRecommendations1";
            // 
            // pdNarrativeSupRecommendations1
            // 
            this.pdNarrativeSupRecommendations1.Name = "pdNarrativeSupRecommendations1";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(1.5020828247070313D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.subrptWorkflowNotes,
            this.subrptFESRecomm,
            this.subrptGSSGRecomm,
            this.subrptNarrativeRecomm,
            this.subrptNarrativeSupRecomm});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            // 
            // subrptWorkflowNotes
            // 
            this.subrptWorkflowNotes.KeepTogether = false;
            this.subrptWorkflowNotes.Name = "subrptWorkflowNotes";
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("PDID", "=Parameters.PDID.Value"));
            instanceReportSource1.ReportDocument = this.pdWorkflowComments1;
            this.subrptWorkflowNotes.ReportSource = instanceReportSource1;
            this.subrptWorkflowNotes.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7D), Telerik.Reporting.Drawing.Unit.Inch(0.30208268761634827D));
            // 
            // subrptFESRecomm
            // 
            this.subrptFESRecomm.KeepTogether = false;
            this.subrptFESRecomm.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.30216154456138611D));
            this.subrptFESRecomm.Name = "subrptFESRecomm";
            instanceReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("PDID", "=Parameters.PDID.Value"));
            instanceReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("FactorFormatTypeID", "=1"));
            instanceReportSource2.ReportDocument = this.pdfesRecommendations1;
            this.subrptFESRecomm.ReportSource = instanceReportSource2;
            this.subrptFESRecomm.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.9999995231628418D), Telerik.Reporting.Drawing.Unit.Inch(0.29992103576660156D));
            // 
            // subrptGSSGRecomm
            // 
            this.subrptGSSGRecomm.KeepTogether = false;
            this.subrptGSSGRecomm.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.60216140747070312D));
            this.subrptGSSGRecomm.Name = "subrptGSSGRecomm";
            instanceReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("PDID", "=Parameters.PDID.Value"));
            instanceReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("FactorFormatTypeID", "=2"));
            instanceReportSource3.ReportDocument = this.pdgssgRecommendations1;
            this.subrptGSSGRecomm.ReportSource = instanceReportSource3;
            this.subrptGSSGRecomm.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.9999995231628418D), Telerik.Reporting.Drawing.Unit.Inch(0.29992103576660156D));
            // 
            // subrptNarrativeRecomm
            // 
            this.subrptNarrativeRecomm.KeepTogether = false;
            this.subrptNarrativeRecomm.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.90216130018234253D));
            this.subrptNarrativeRecomm.Name = "subrptNarrativeRecomm";
            instanceReportSource4.Parameters.Add(new Telerik.Reporting.Parameter("PDID", "=Parameters.PDID.Value"));
            instanceReportSource4.Parameters.Add(new Telerik.Reporting.Parameter("FactorFormatTypeID", "=3"));
            instanceReportSource4.ReportDocument = this.pdNarrativeRecommendations1;
            this.subrptNarrativeRecomm.ReportSource = instanceReportSource4;
            this.subrptNarrativeRecomm.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.9999995231628418D), Telerik.Reporting.Drawing.Unit.Inch(0.2999216616153717D));
            // 
            // subrptNarrativeSupRecomm
            // 
            this.subrptNarrativeSupRecomm.KeepTogether = false;
            this.subrptNarrativeSupRecomm.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(1.2021617889404297D));
            this.subrptNarrativeSupRecomm.Name = "subrptNarrativeSupRecomm";
            instanceReportSource5.Parameters.Add(new Telerik.Reporting.Parameter("PDID", "=Parameters.PDID.Value"));
            instanceReportSource5.Parameters.Add(new Telerik.Reporting.Parameter("FactorFormatTypeID", "= 4"));
            instanceReportSource5.ReportDocument = this.pdNarrativeSupRecommendations1;
            this.subrptNarrativeSupRecomm.ReportSource = instanceReportSource5;
            this.subrptNarrativeSupRecomm.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7D), Telerik.Reporting.Drawing.Unit.Inch(0.29992103576660156D));
            // 
            // pageFooter
            // 
            this.pageFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.27996063232421875D);
            this.pageFooter.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.currentTimeTextBox,
            this.pageInfoTextBox});
            this.pageFooter.Name = "pageFooter";
            // 
            // currentTimeTextBox
            // 
            this.currentTimeTextBox.Name = "currentTimeTextBox";
            this.currentTimeTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.21875D), Telerik.Reporting.Drawing.Unit.Inch(0.20000003278255463D));
            this.currentTimeTextBox.StyleName = "PageInfo";
            this.currentTimeTextBox.Value = "=NOW()";
            // 
            // pageInfoTextBox
            // 
            this.pageInfoTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.2000002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.pageInfoTextBox.Name = "pageInfoTextBox";
            this.pageInfoTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.7999992370605469D), Telerik.Reporting.Drawing.Unit.Inch(0.20000003278255463D));
            this.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.pageInfoTextBox.StyleName = "PageInfo";
            this.pageInfoTextBox.Value = "=PageNumber";
            // 
            // reportHeaderSection1
            // 
            this.reportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(8.1999998092651367D);
            this.reportHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pictureBox1,
            this.textBoxPDHeader,
            this.tablePDDetails});
            this.reportHeaderSection1.Name = "reportHeaderSection1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.9418537198798731E-05D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.pictureBox1.MimeType = "image/png";
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.9999604225158691D), Telerik.Reporting.Drawing.Unit.Inch(1.2000000476837158D));
            this.pictureBox1.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(227)))), ((int)(((byte)(240)))));
            this.pictureBox1.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pictureBox1.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pictureBox1.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pictureBox1.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.pictureBox1.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.pictureBox1.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.pictureBox1.Value = ((object)(resources.GetObject("pictureBox1.Value")));
            // 
            // textBoxPDHeader
            // 
            this.textBoxPDHeader.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(1.2000001668930054D));
            this.textBoxPDHeader.Name = "textBoxPDHeader";
            this.textBoxPDHeader.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7D), Telerik.Reporting.Drawing.Unit.Inch(0.38999998569488525D));
            this.textBoxPDHeader.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(227)))), ((int)(((byte)(240)))));
            this.textBoxPDHeader.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxPDHeader.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxPDHeader.Style.Font.Bold = true;
            this.textBoxPDHeader.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(20D);
            this.textBoxPDHeader.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxPDHeader.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxPDHeader.Value = "Position Description Comments";
            // 
            // tablePDDetails
            // 
            this.tablePDDetails.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(2.4197525978088379D)));
            this.tablePDDetails.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(4.5802469253540039D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.29172837734222412D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.24588575959205627D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.28756061196327209D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.29006186127662659D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.29006186127662659D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.29006186127662659D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.29006180167198181D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.33965498208999634D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.33965498208999634D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30006393790245056D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.90019172430038452D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.29006186127662659D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.29798024892807007D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.29797989130020142D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.28408852219581604D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.31534510850906372D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.29006186127662659D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.3222905695438385D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.27714252471923828D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.29006174206733704D)));
            this.tablePDDetails.Body.SetCellContent(0, 0, this.textBoxPDNoCaption);
            this.tablePDDetails.Body.SetCellContent(0, 1, this.textBoxPDNoData);
            this.tablePDDetails.Body.SetCellContent(2, 0, this.textBoxPayPlanCaption);
            this.tablePDDetails.Body.SetCellContent(2, 1, this.textBoxPayPlanData);
            this.tablePDDetails.Body.SetCellContent(6, 0, this.textBoxFPLevelCaption);
            this.tablePDDetails.Body.SetCellContent(7, 0, this.textBoxOPMTitleCaption);
            this.tablePDDetails.Body.SetCellContent(8, 0, this.textBoxFWSTitleCaption);
            this.tablePDDetails.Body.SetCellContent(9, 0, this.textBoxDutyLocationCaption);
            this.tablePDDetails.Body.SetCellContent(11, 0, this.textBoxCertifiedByCaption);
            this.tablePDDetails.Body.SetCellContent(17, 0, this.textBoxClassifiedByCaption);
            this.tablePDDetails.Body.SetCellContent(8, 1, this.textBoxFWSTitleData);
            this.tablePDDetails.Body.SetCellContent(7, 1, this.textBoxOPMTitleData);
            this.tablePDDetails.Body.SetCellContent(9, 1, this.textBoxDutyLocationData);
            this.tablePDDetails.Body.SetCellContent(17, 1, this.textBoxClassifiedByData);
            this.tablePDDetails.Body.SetCellContent(11, 1, this.textBoxCertifiedByData);
            this.tablePDDetails.Body.SetCellContent(6, 1, this.textBoxFPLevelData);
            this.tablePDDetails.Body.SetCellContent(1, 0, this.textBoxFPPSIDCaption);
            this.tablePDDetails.Body.SetCellContent(1, 1, this.textBoxFPPSData);
            this.tablePDDetails.Body.SetCellContent(13, 0, this.textBoxCertifiedOnCaption);
            this.tablePDDetails.Body.SetCellContent(19, 0, this.textBoxClassifiedOnCaption);
            this.tablePDDetails.Body.SetCellContent(19, 1, this.textBoxClassifiedOnData);
            this.tablePDDetails.Body.SetCellContent(13, 1, this.textBoxCertifiedOnData);
            this.tablePDDetails.Body.SetCellContent(18, 0, this.classifierTitleCaption);
            this.tablePDDetails.Body.SetCellContent(12, 0, this.supervisorTitleCaption);
            this.tablePDDetails.Body.SetCellContent(12, 1, this.textBoxSupervisorOrgTitleData);
            this.tablePDDetails.Body.SetCellContent(18, 1, this.textBoxClassifierOrgTitleData);
            this.tablePDDetails.Body.SetCellContent(5, 0, this.textBox1);
            this.tablePDDetails.Body.SetCellContent(5, 1, this.textBox2);
            this.tablePDDetails.Body.SetCellContent(14, 0, this.textBox4);
            this.tablePDDetails.Body.SetCellContent(14, 1, this.textBox6);
            this.tablePDDetails.Body.SetCellContent(16, 0, this.textBox7);
            this.tablePDDetails.Body.SetCellContent(16, 1, this.textBox8);
            this.tablePDDetails.Body.SetCellContent(15, 0, this.textBox9);
            this.tablePDDetails.Body.SetCellContent(15, 1, this.textBox10);
            this.tablePDDetails.Body.SetCellContent(10, 0, this.textBox11);
            this.tablePDDetails.Body.SetCellContent(10, 1, this.textBox12);
            this.tablePDDetails.Body.SetCellContent(3, 0, this.textBox3);
            this.tablePDDetails.Body.SetCellContent(3, 1, this.textBox5);
            this.tablePDDetails.Body.SetCellContent(4, 0, this.textBox13);
            this.tablePDDetails.Body.SetCellContent(4, 1, this.textBox14);
            this.tablePDDetails.ColumnGroups.Add(tableGroup1);
            this.tablePDDetails.ColumnGroups.Add(tableGroup2);
            this.tablePDDetails.DataMember = "PositionDescriptionTable";
            this.tablePDDetails.DataSource = this.pdDataSet1;
            this.tablePDDetails.Filters.AddRange(new Telerik.Reporting.Filter[] {
            new Telerik.Reporting.Filter("=Fields.PositionDescriptionID", Telerik.Reporting.FilterOperator.Equal, "=Parameters.PDID")});
            this.tablePDDetails.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBoxPDNoCaption,
            this.textBoxPDNoData,
            this.textBoxPayPlanCaption,
            this.textBoxPayPlanData,
            this.textBoxFPLevelCaption,
            this.textBoxOPMTitleCaption,
            this.textBoxFWSTitleCaption,
            this.textBoxDutyLocationCaption,
            this.textBoxCertifiedByCaption,
            this.textBoxClassifiedByCaption,
            this.textBoxFWSTitleData,
            this.textBoxOPMTitleData,
            this.textBoxDutyLocationData,
            this.textBoxClassifiedByData,
            this.textBoxCertifiedByData,
            this.textBoxFPLevelData,
            this.textBoxFPPSIDCaption,
            this.textBoxFPPSData,
            this.textBoxCertifiedOnCaption,
            this.textBoxClassifiedOnCaption,
            this.textBoxClassifiedOnData,
            this.textBoxCertifiedOnData,
            this.classifierTitleCaption,
            this.supervisorTitleCaption,
            this.textBoxSupervisorOrgTitleData,
            this.textBoxClassifierOrgTitleData,
            this.textBox1,
            this.textBox2,
            this.textBox4,
            this.textBox6,
            this.textBox7,
            this.textBox8,
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.textBox12,
            this.textBox3,
            this.textBox5,
            this.textBox13,
            this.textBox14});
            this.tablePDDetails.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(1.6000000238418579D));
            this.tablePDDetails.Name = "tablePDDetails";
            tableGroup4.Name = "Group1";
            tableGroup5.Name = "Group10";
            tableGroup6.Name = "Group2";
            tableGroup7.Name = "Group19";
            tableGroup8.Name = "Group20";
            tableGroup9.Name = "Group15";
            tableGroup10.Name = "Group3";
            tableGroup11.Name = "Group4";
            tableGroup12.Name = "Group5";
            tableGroup13.Name = "Group6";
            tableGroup14.Name = "Group7";
            tableGroup15.Name = "Group8";
            tableGroup16.Name = "Group14";
            tableGroup17.Name = "Group11";
            tableGroup18.Name = "Group16";
            tableGroup19.Name = "Group18";
            tableGroup20.Name = "Group17";
            tableGroup21.Name = "Group9";
            tableGroup22.Name = "Group13";
            tableGroup23.Name = "Group12";
            tableGroup3.ChildGroups.Add(tableGroup4);
            tableGroup3.ChildGroups.Add(tableGroup5);
            tableGroup3.ChildGroups.Add(tableGroup6);
            tableGroup3.ChildGroups.Add(tableGroup7);
            tableGroup3.ChildGroups.Add(tableGroup8);
            tableGroup3.ChildGroups.Add(tableGroup9);
            tableGroup3.ChildGroups.Add(tableGroup10);
            tableGroup3.ChildGroups.Add(tableGroup11);
            tableGroup3.ChildGroups.Add(tableGroup12);
            tableGroup3.ChildGroups.Add(tableGroup13);
            tableGroup3.ChildGroups.Add(tableGroup14);
            tableGroup3.ChildGroups.Add(tableGroup15);
            tableGroup3.ChildGroups.Add(tableGroup16);
            tableGroup3.ChildGroups.Add(tableGroup17);
            tableGroup3.ChildGroups.Add(tableGroup18);
            tableGroup3.ChildGroups.Add(tableGroup19);
            tableGroup3.ChildGroups.Add(tableGroup20);
            tableGroup3.ChildGroups.Add(tableGroup21);
            tableGroup3.ChildGroups.Add(tableGroup22);
            tableGroup3.ChildGroups.Add(tableGroup23);
            tableGroup3.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping("")});
            tableGroup3.Name = "DetailGroup";
            this.tablePDDetails.RowGroups.Add(tableGroup3);
            this.tablePDDetails.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7D), Telerik.Reporting.Drawing.Unit.Inch(6.53000020980835D));
            // 
            // textBoxPDNoCaption
            // 
            this.textBoxPDNoCaption.Name = "textBoxPDNoCaption";
            this.textBoxPDNoCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4197525978088379D), Telerik.Reporting.Drawing.Unit.Inch(0.29172837734222412D));
            this.textBoxPDNoCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxPDNoCaption.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxPDNoCaption.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxPDNoCaption.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxPDNoCaption.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxPDNoCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxPDNoCaption.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxPDNoCaption.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxPDNoCaption.Style.Font.Bold = true;
            this.textBoxPDNoCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxPDNoCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxPDNoCaption.Value = "PD No.:";
            // 
            // textBoxPDNoData
            // 
            this.textBoxPDNoData.Name = "textBoxPDNoData";
            this.textBoxPDNoData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5802469253540039D), Telerik.Reporting.Drawing.Unit.Inch(0.29172837734222412D));
            this.textBoxPDNoData.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxPDNoData.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxPDNoData.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxPDNoData.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxPDNoData.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxPDNoData.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxPDNoData.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxPDNoData.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxPDNoData.Value = "=Fields.PositionDescriptionID";
            // 
            // textBoxPayPlanCaption
            // 
            this.textBoxPayPlanCaption.Name = "textBoxPayPlanCaption";
            this.textBoxPayPlanCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4197525978088379D), Telerik.Reporting.Drawing.Unit.Inch(0.28756067156791687D));
            this.textBoxPayPlanCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxPayPlanCaption.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxPayPlanCaption.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxPayPlanCaption.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxPayPlanCaption.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxPayPlanCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxPayPlanCaption.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxPayPlanCaption.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxPayPlanCaption.Style.Font.Bold = true;
            this.textBoxPayPlanCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxPayPlanCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxPayPlanCaption.Value = "Pay Plan, Series and Grade:";
            // 
            // textBoxPayPlanData
            // 
            this.textBoxPayPlanData.Name = "textBoxPayPlanData";
            this.textBoxPayPlanData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5802469253540039D), Telerik.Reporting.Drawing.Unit.Inch(0.28756067156791687D));
            this.textBoxPayPlanData.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxPayPlanData.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxPayPlanData.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxPayPlanData.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxPayPlanData.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxPayPlanData.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxPayPlanData.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxPayPlanData.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxPayPlanData.Value = "= Fields.PayPlanAbbrev + \'-\' + Substr(Format(\'0000{0}\', Fields.JobSeries), Len(Fo" +
    "rmat(\'0000{0}\', Fields.JobSeries))-4, 4) + \' : \' + Fields.SeriesName + \'-\' + Fie" +
    "lds.ProposedGrade";
            // 
            // textBoxFPLevelCaption
            // 
            this.textBoxFPLevelCaption.Name = "textBoxFPLevelCaption";
            this.textBoxFPLevelCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4197525978088379D), Telerik.Reporting.Drawing.Unit.Inch(0.2900618314743042D));
            this.textBoxFPLevelCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxFPLevelCaption.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxFPLevelCaption.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxFPLevelCaption.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxFPLevelCaption.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxFPLevelCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxFPLevelCaption.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxFPLevelCaption.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxFPLevelCaption.Style.Font.Bold = true;
            this.textBoxFPLevelCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxFPLevelCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxFPLevelCaption.Value = "Full Performance Level:";
            // 
            // textBoxOPMTitleCaption
            // 
            this.textBoxOPMTitleCaption.Name = "textBoxOPMTitleCaption";
            this.textBoxOPMTitleCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4197525978088379D), Telerik.Reporting.Drawing.Unit.Inch(0.33965501189231873D));
            this.textBoxOPMTitleCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxOPMTitleCaption.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxOPMTitleCaption.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxOPMTitleCaption.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxOPMTitleCaption.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxOPMTitleCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxOPMTitleCaption.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxOPMTitleCaption.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxOPMTitleCaption.Style.Font.Bold = true;
            this.textBoxOPMTitleCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxOPMTitleCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxOPMTitleCaption.Value = "OPM Title:";
            // 
            // textBoxFWSTitleCaption
            // 
            this.textBoxFWSTitleCaption.Name = "textBoxFWSTitleCaption";
            this.textBoxFWSTitleCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4197525978088379D), Telerik.Reporting.Drawing.Unit.Inch(0.33965501189231873D));
            this.textBoxFWSTitleCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxFWSTitleCaption.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxFWSTitleCaption.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxFWSTitleCaption.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxFWSTitleCaption.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxFWSTitleCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxFWSTitleCaption.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxFWSTitleCaption.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxFWSTitleCaption.Style.Font.Bold = true;
            this.textBoxFWSTitleCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxFWSTitleCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxFWSTitleCaption.Value = "FWS Title:";
            // 
            // textBoxDutyLocationCaption
            // 
            this.textBoxDutyLocationCaption.Name = "textBoxDutyLocationCaption";
            this.textBoxDutyLocationCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4197525978088379D), Telerik.Reporting.Drawing.Unit.Inch(0.30006393790245056D));
            this.textBoxDutyLocationCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxDutyLocationCaption.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxDutyLocationCaption.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxDutyLocationCaption.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxDutyLocationCaption.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxDutyLocationCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxDutyLocationCaption.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxDutyLocationCaption.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxDutyLocationCaption.Style.Font.Bold = true;
            this.textBoxDutyLocationCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxDutyLocationCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxDutyLocationCaption.Value = "Duty Location:";
            // 
            // textBoxCertifiedByCaption
            // 
            this.textBoxCertifiedByCaption.Name = "textBoxCertifiedByCaption";
            this.textBoxCertifiedByCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4197525978088379D), Telerik.Reporting.Drawing.Unit.Inch(0.29006186127662659D));
            this.textBoxCertifiedByCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxCertifiedByCaption.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxCertifiedByCaption.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxCertifiedByCaption.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxCertifiedByCaption.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxCertifiedByCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxCertifiedByCaption.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxCertifiedByCaption.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxCertifiedByCaption.Style.Font.Bold = true;
            this.textBoxCertifiedByCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxCertifiedByCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxCertifiedByCaption.Value = "Supervisor Signature:";
            // 
            // textBoxClassifiedByCaption
            // 
            this.textBoxClassifiedByCaption.Name = "textBoxClassifiedByCaption";
            this.textBoxClassifiedByCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4197525978088379D), Telerik.Reporting.Drawing.Unit.Inch(0.32229059934616089D));
            this.textBoxClassifiedByCaption.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxClassifiedByCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxClassifiedByCaption.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxClassifiedByCaption.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxClassifiedByCaption.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxClassifiedByCaption.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxClassifiedByCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxClassifiedByCaption.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxClassifiedByCaption.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxClassifiedByCaption.Style.Font.Bold = true;
            this.textBoxClassifiedByCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxClassifiedByCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxClassifiedByCaption.Value = "Classifier Signature:";
            // 
            // textBoxFWSTitleData
            // 
            this.textBoxFWSTitleData.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.379166841506958D), Telerik.Reporting.Drawing.Unit.Inch(1.2999212741851807D));
            this.textBoxFWSTitleData.Name = "textBoxFWSTitleData";
            this.textBoxFWSTitleData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5802469253540039D), Telerik.Reporting.Drawing.Unit.Inch(0.33965501189231873D));
            this.textBoxFWSTitleData.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxFWSTitleData.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxFWSTitleData.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxFWSTitleData.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxFWSTitleData.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxFWSTitleData.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxFWSTitleData.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxFWSTitleData.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxFWSTitleData.Value = "=Fields.AgencyPositionTitle";
            // 
            // textBoxOPMTitleData
            // 
            this.textBoxOPMTitleData.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.3791666030883789D), Telerik.Reporting.Drawing.Unit.Inch(0.99992126226425171D));
            this.textBoxOPMTitleData.Name = "textBoxOPMTitleData";
            this.textBoxOPMTitleData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5802469253540039D), Telerik.Reporting.Drawing.Unit.Inch(0.33965501189231873D));
            this.textBoxOPMTitleData.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxOPMTitleData.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxOPMTitleData.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxOPMTitleData.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxOPMTitleData.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxOPMTitleData.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxOPMTitleData.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxOPMTitleData.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxOPMTitleData.Value = "=Fields.OPMJobTitle";
            // 
            // textBoxDutyLocationData
            // 
            this.textBoxDutyLocationData.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.3791666030883789D), Telerik.Reporting.Drawing.Unit.Inch(1.6999212503433228D));
            this.textBoxDutyLocationData.Name = "textBoxDutyLocationData";
            this.textBoxDutyLocationData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5802469253540039D), Telerik.Reporting.Drawing.Unit.Inch(0.30006393790245056D));
            this.textBoxDutyLocationData.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxDutyLocationData.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxDutyLocationData.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxDutyLocationData.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxDutyLocationData.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxDutyLocationData.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxDutyLocationData.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxDutyLocationData.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxDutyLocationData.Value = "=Fields.DutyLocation";
            // 
            // textBoxClassifiedByData
            // 
            this.textBoxClassifiedByData.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.2791669368743896D), Telerik.Reporting.Drawing.Unit.Inch(3.3999214172363281D));
            this.textBoxClassifiedByData.Name = "textBoxClassifiedByData";
            this.textBoxClassifiedByData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5802469253540039D), Telerik.Reporting.Drawing.Unit.Inch(0.32229059934616089D));
            this.textBoxClassifiedByData.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxClassifiedByData.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxClassifiedByData.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxClassifiedByData.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxClassifiedByData.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxClassifiedByData.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxClassifiedByData.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxClassifiedByData.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxClassifiedByData.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxClassifiedByData.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxClassifiedByData.Value = "=Fields.ClassifierFullName";
            // 
            // textBoxCertifiedByData
            // 
            this.textBoxCertifiedByData.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.2791669368743896D), Telerik.Reporting.Drawing.Unit.Inch(3.0999212265014648D));
            this.textBoxCertifiedByData.Name = "textBoxCertifiedByData";
            this.textBoxCertifiedByData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5802469253540039D), Telerik.Reporting.Drawing.Unit.Inch(0.29006186127662659D));
            this.textBoxCertifiedByData.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxCertifiedByData.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxCertifiedByData.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxCertifiedByData.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxCertifiedByData.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxCertifiedByData.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxCertifiedByData.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxCertifiedByData.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxCertifiedByData.Value = "=Fields.SupervisorFullName";
            // 
            // textBoxFPLevelData
            // 
            this.textBoxFPLevelData.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.2791669368743896D), Telerik.Reporting.Drawing.Unit.Inch(0.6999213695526123D));
            this.textBoxFPLevelData.Name = "textBoxFPLevelData";
            this.textBoxFPLevelData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5802469253540039D), Telerik.Reporting.Drawing.Unit.Inch(0.2900618314743042D));
            this.textBoxFPLevelData.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxFPLevelData.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxFPLevelData.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxFPLevelData.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxFPLevelData.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxFPLevelData.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxFPLevelData.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxFPLevelData.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxFPLevelData.Value = "=Fields.ProposedFPGrade";
            // 
            // textBoxFPPSIDCaption
            // 
            this.textBoxFPPSIDCaption.Name = "textBoxFPPSIDCaption";
            this.textBoxFPPSIDCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4197525978088379D), Telerik.Reporting.Drawing.Unit.Inch(0.24588578939437866D));
            this.textBoxFPPSIDCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxFPPSIDCaption.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxFPPSIDCaption.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxFPPSIDCaption.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxFPPSIDCaption.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxFPPSIDCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxFPPSIDCaption.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxFPPSIDCaption.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxFPPSIDCaption.Style.Font.Bold = true;
            this.textBoxFPPSIDCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxFPPSIDCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxFPPSIDCaption.Value = "FPPS PD No.:";
            // 
            // textBoxFPPSData
            // 
            this.textBoxFPPSData.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.2000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(0.39992141723632812D));
            this.textBoxFPPSData.Name = "textBoxFPPSData";
            this.textBoxFPPSData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5802469253540039D), Telerik.Reporting.Drawing.Unit.Inch(0.24588578939437866D));
            this.textBoxFPPSData.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxFPPSData.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxFPPSData.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxFPPSData.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxFPPSData.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxFPPSData.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxFPPSData.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxFPPSData.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxFPPSData.Value = "=Fields.FPPSPDID";
            // 
            // textBoxCertifiedOnCaption
            // 
            this.textBoxCertifiedOnCaption.Name = "textBoxCertifiedOnCaption";
            this.textBoxCertifiedOnCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4197525978088379D), Telerik.Reporting.Drawing.Unit.Inch(0.29797995090484619D));
            this.textBoxCertifiedOnCaption.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxCertifiedOnCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxCertifiedOnCaption.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxCertifiedOnCaption.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxCertifiedOnCaption.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxCertifiedOnCaption.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxCertifiedOnCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxCertifiedOnCaption.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxCertifiedOnCaption.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxCertifiedOnCaption.Style.Font.Bold = true;
            this.textBoxCertifiedOnCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxCertifiedOnCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxCertifiedOnCaption.Value = "Supervisor Sign Date:";
            // 
            // textBoxClassifiedOnCaption
            // 
            this.textBoxClassifiedOnCaption.Name = "textBoxClassifiedOnCaption";
            this.textBoxClassifiedOnCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4197525978088379D), Telerik.Reporting.Drawing.Unit.Inch(0.29006174206733704D));
            this.textBoxClassifiedOnCaption.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxClassifiedOnCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxClassifiedOnCaption.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxClassifiedOnCaption.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxClassifiedOnCaption.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxClassifiedOnCaption.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxClassifiedOnCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxClassifiedOnCaption.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxClassifiedOnCaption.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxClassifiedOnCaption.Style.Font.Bold = true;
            this.textBoxClassifiedOnCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxClassifiedOnCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxClassifiedOnCaption.Value = "Classifier Sign Date:";
            // 
            // textBoxClassifiedOnData
            // 
            this.textBoxClassifiedOnData.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.2000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(4.29992151260376D));
            this.textBoxClassifiedOnData.Name = "textBoxClassifiedOnData";
            this.textBoxClassifiedOnData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5802469253540039D), Telerik.Reporting.Drawing.Unit.Inch(0.29006174206733704D));
            this.textBoxClassifiedOnData.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxClassifiedOnData.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxClassifiedOnData.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxClassifiedOnData.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxClassifiedOnData.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxClassifiedOnData.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxClassifiedOnData.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxClassifiedOnData.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxClassifiedOnData.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxClassifiedOnData.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxClassifiedOnData.Value = "=Fields.ClassifierSignDate";
            // 
            // textBoxCertifiedOnData
            // 
            this.textBoxCertifiedOnData.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.2000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(3.6999213695526123D));
            this.textBoxCertifiedOnData.Name = "textBoxCertifiedOnData";
            this.textBoxCertifiedOnData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5802469253540039D), Telerik.Reporting.Drawing.Unit.Inch(0.29797995090484619D));
            this.textBoxCertifiedOnData.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxCertifiedOnData.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxCertifiedOnData.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxCertifiedOnData.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxCertifiedOnData.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxCertifiedOnData.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxCertifiedOnData.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxCertifiedOnData.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxCertifiedOnData.Value = "=Fields.SupervisorSignDate";
            // 
            // classifierTitleCaption
            // 
            this.classifierTitleCaption.Name = "classifierTitleCaption";
            this.classifierTitleCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4197525978088379D), Telerik.Reporting.Drawing.Unit.Inch(0.27714252471923828D));
            this.classifierTitleCaption.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.classifierTitleCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.classifierTitleCaption.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.classifierTitleCaption.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.classifierTitleCaption.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.classifierTitleCaption.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.classifierTitleCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.classifierTitleCaption.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.classifierTitleCaption.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.classifierTitleCaption.Style.Font.Bold = true;
            this.classifierTitleCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.classifierTitleCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.classifierTitleCaption.Value = "Classifier Title:";
            // 
            // supervisorTitleCaption
            // 
            this.supervisorTitleCaption.Name = "supervisorTitleCaption";
            this.supervisorTitleCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4197525978088379D), Telerik.Reporting.Drawing.Unit.Inch(0.29798027873039246D));
            this.supervisorTitleCaption.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.Solid;
            this.supervisorTitleCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.supervisorTitleCaption.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.supervisorTitleCaption.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.supervisorTitleCaption.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.supervisorTitleCaption.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.supervisorTitleCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.supervisorTitleCaption.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.supervisorTitleCaption.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.supervisorTitleCaption.Style.Font.Bold = true;
            this.supervisorTitleCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.supervisorTitleCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.supervisorTitleCaption.Value = "Supervisor Title:";
            // 
            // textBoxSupervisorOrgTitleData
            // 
            this.textBoxSupervisorOrgTitleData.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.2000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(3.6999213695526123D));
            this.textBoxSupervisorOrgTitleData.Name = "textBoxSupervisorOrgTitleData";
            this.textBoxSupervisorOrgTitleData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5802469253540039D), Telerik.Reporting.Drawing.Unit.Inch(0.29798027873039246D));
            this.textBoxSupervisorOrgTitleData.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxSupervisorOrgTitleData.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxSupervisorOrgTitleData.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxSupervisorOrgTitleData.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxSupervisorOrgTitleData.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxSupervisorOrgTitleData.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxSupervisorOrgTitleData.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxSupervisorOrgTitleData.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxSupervisorOrgTitleData.Value = "=Fields.SupervisorOrgTitle";
            // 
            // textBoxClassifierOrgTitleData
            // 
            this.textBoxClassifierOrgTitleData.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.2000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(4.599921703338623D));
            this.textBoxClassifierOrgTitleData.Name = "textBoxClassifierOrgTitleData";
            this.textBoxClassifierOrgTitleData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5802469253540039D), Telerik.Reporting.Drawing.Unit.Inch(0.27714252471923828D));
            this.textBoxClassifierOrgTitleData.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxClassifierOrgTitleData.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxClassifierOrgTitleData.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxClassifierOrgTitleData.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxClassifierOrgTitleData.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxClassifierOrgTitleData.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxClassifierOrgTitleData.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxClassifierOrgTitleData.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxClassifierOrgTitleData.Value = "=Fields.ClassifierOrgTitle";
            // 
            // textBox1
            // 
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4197525978088379D), Telerik.Reporting.Drawing.Unit.Inch(0.29006186127662659D));
            this.textBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox1.Value = "Proposed Level:";
            // 
            // textBox2
            // 
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5802469253540039D), Telerik.Reporting.Drawing.Unit.Inch(0.29006186127662659D));
            this.textBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox2.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox2.Value = "= Fields.ProposedGrade";
            // 
            // textBox4
            // 
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4197525978088379D), Telerik.Reporting.Drawing.Unit.Inch(0.28408855199813843D));
            this.textBox4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox4.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox4.Style.Font.Bold = true;
            this.textBox4.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox4.Value = "Approving Official Signature:";
            // 
            // textBox6
            // 
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5802469253540039D), Telerik.Reporting.Drawing.Unit.Inch(0.28408855199813843D));
            this.textBox6.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox6.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox6.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox6.Value = "= Fields.AdditionalSupervisorFullName";
            // 
            // textBox7
            // 
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4197525978088379D), Telerik.Reporting.Drawing.Unit.Inch(0.29006186127662659D));
            this.textBox7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox7.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox7.Style.Font.Bold = true;
            this.textBox7.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox7.Value = "Approving Official Sign Date:";
            // 
            // textBox8
            // 
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5802469253540039D), Telerik.Reporting.Drawing.Unit.Inch(0.29006186127662659D));
            this.textBox8.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox8.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox8.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox8.Value = "= Fields.AdditionalSupervisorSignDate";
            // 
            // textBox9
            // 
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4197525978088379D), Telerik.Reporting.Drawing.Unit.Inch(0.31534510850906372D));
            this.textBox9.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox9.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox9.Style.Font.Bold = true;
            this.textBox9.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox9.Value = "Approving Official Title:";
            // 
            // textBox10
            // 
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5802469253540039D), Telerik.Reporting.Drawing.Unit.Inch(0.31534510850906372D));
            this.textBox10.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox10.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox10.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox10.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox10.Value = "= Fields.AdditionalSupOrgTitle";
            // 
            // textBox11
            // 
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4197525978088379D), Telerik.Reporting.Drawing.Unit.Inch(0.90019172430038452D));
            this.textBox11.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox11.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox11.Style.Font.Bold = true;
            this.textBox11.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox11.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox11.Value = "Organization Structure:";
            // 
            // textBox12
            // 
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5802469253540039D), Telerik.Reporting.Drawing.Unit.Inch(0.90019172430038452D));
            this.textBox12.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox12.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox12.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox12.Value = resources.GetString("textBox12.Value");
            // 
            // textBox3
            // 
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4197525978088379D), Telerik.Reporting.Drawing.Unit.Inch(0.29006186127662659D));
            this.textBox3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox3.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox3.Style.Font.Bold = true;
            this.textBox3.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox3.Value = "Is Interdisciplinary PD?";
            // 
            // textBox5
            // 
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5802469253540039D), Telerik.Reporting.Drawing.Unit.Inch(0.29006186127662659D));
            this.textBox5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox5.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox5.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox5.Value = "=IIF(Fields.IsInterdisciplinaryPD,\"YES\",\"NO\")";
            // 
            // textBox13
            // 
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4197525978088379D), Telerik.Reporting.Drawing.Unit.Inch(0.29006186127662659D));
            this.textBox13.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox13.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox13.Style.Font.Bold = true;
            this.textBox13.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox13.Value = "Additional Series:";
            // 
            // textBox14
            // 
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5802469253540039D), Telerik.Reporting.Drawing.Unit.Inch(0.29006186127662659D));
            this.textBox14.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox14.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox14.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox14.Value = "=Fields.AdditionalSeries";
            // 
            // pdDataSet1
            // 
            this.pdDataSet1.DataSetName = "PDDataSet";
            this.pdDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // positionDescriptionTableAdapter1
            // 
            this.positionDescriptionTableAdapter1.ClearBeforeFill = true;
            // 
            // PDComments
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail,
            this.pageFooter,
            this.reportHeaderSection1});
            this.Name = "PDComments";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "PDID";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Float;
            reportParameter1.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(7.3000001907348633D);
            this.NeedDataSource += new System.EventHandler(this.PDComments_NeedDataSource);
            ((System.ComponentModel.ISupportInitialize)(this.pdWorkflowComments1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdfesRecommendations1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdgssgRecommendations1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdNarrativeRecommendations1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdNarrativeSupRecommendations1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.PageFooterSection pageFooter;
        private PDDataSet pdDataSet1;
        private Telerik.Reporting.TextBox currentTimeTextBox;
        private Telerik.Reporting.TextBox pageInfoTextBox;
        private ReportHeaderSection reportHeaderSection1;
        private Telerik.Reporting.PictureBox pictureBox1;
        private Telerik.Reporting.TextBox textBoxPDHeader;
        private Table tablePDDetails;
        private Telerik.Reporting.TextBox textBoxPDNoCaption;
        private Telerik.Reporting.TextBox textBoxPDNoData;
        private Telerik.Reporting.TextBox textBoxPayPlanCaption;
        private Telerik.Reporting.TextBox textBoxPayPlanData;
        private Telerik.Reporting.TextBox textBoxFPLevelCaption;
        private Telerik.Reporting.TextBox textBoxOPMTitleCaption;
        private Telerik.Reporting.TextBox textBoxFWSTitleCaption;
        private Telerik.Reporting.TextBox textBoxDutyLocationCaption;
        private Telerik.Reporting.TextBox textBoxCertifiedByCaption;
        private Telerik.Reporting.TextBox textBoxClassifiedByCaption;
        private Telerik.Reporting.TextBox textBoxFWSTitleData;
        private Telerik.Reporting.TextBox textBoxOPMTitleData;
        private Telerik.Reporting.TextBox textBoxDutyLocationData;
        private Telerik.Reporting.TextBox textBoxClassifiedByData;
        private Telerik.Reporting.TextBox textBoxCertifiedByData;
        private Telerik.Reporting.TextBox textBoxFPLevelData;
        private Telerik.Reporting.TextBox textBoxFPPSIDCaption;
        private Telerik.Reporting.TextBox textBoxFPPSData;
        private Telerik.Reporting.TextBox textBoxCertifiedOnCaption;
        private Telerik.Reporting.TextBox textBoxClassifiedOnCaption;
        private Telerik.Reporting.TextBox textBoxClassifiedOnData;
        private Telerik.Reporting.TextBox textBoxCertifiedOnData;
        private Telerik.Reporting.TextBox classifierTitleCaption;
        private Telerik.Reporting.TextBox supervisorTitleCaption;
        private Telerik.Reporting.TextBox textBoxSupervisorOrgTitleData;
        private Telerik.Reporting.TextBox textBoxClassifierOrgTitleData;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox12;
        private HCMS.Reports.PDDataSetTableAdapters.PositionDescriptionTableAdapter positionDescriptionTableAdapter1;
        private SubReport subrptWorkflowNotes;
        private PDWorkflowComments pdWorkflowComments1;
        private SubReport subrptFESRecomm;
        private PDFESRecommendations pdfesRecommendations1;
        private SubReport subrptGSSGRecomm;
        private PDGSSGRecommendations pdgssgRecommendations1;
        private SubReport subrptNarrativeRecomm;
        private PDNarrativeRecommendations pdNarrativeRecommendations1;
        private SubReport subrptNarrativeSupRecomm;
        private PDNarrativeSupRecommendations pdNarrativeSupRecommendations1;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox14;
    }
}