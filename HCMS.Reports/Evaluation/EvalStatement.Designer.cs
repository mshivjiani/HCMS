namespace HCMS.Reports.Evaluation
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

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
            Telerik.Reporting.TableGroup tableGroup24 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup25 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup26 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup27 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup28 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup29 = new Telerik.Reporting.TableGroup();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EvalStatement));
            Telerik.Reporting.InstanceReportSource instanceReportSource5 = new Telerik.Reporting.InstanceReportSource();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.ReportParameter reportParameter2 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            this.pdfesFactors1 = new HCMS.Reports.PositionDescription.PDFESFactors();
            this.pdgssgFactors1 = new HCMS.Reports.PositionDescription.PDGSSGFactors();
            this.pdNarrativeFactors1 = new HCMS.Reports.PositionDescription.PDNarrativeFactors();
            this.pdNarrativeSupervisoryFactors1 = new HCMS.Reports.PositionDescription.PDNarrativeSupervisoryFactors();
            this.classificationStandards1 = new HCMS.Reports.Evaluation.ClassificationStandards();
            this.pageFooter = new Telerik.Reporting.PageFooterSection();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.subReportFESFactors = new Telerik.Reporting.SubReport();
            this.subReportGSSGFactors = new Telerik.Reporting.SubReport();
            this.subReportNarrativeFactors = new Telerik.Reporting.SubReport();
            this.subReportNarrativeSupFactors = new Telerik.Reporting.SubReport();
            this.tableEvalStatement = new Telerik.Reporting.Table();
            this.PDNumberCaption = new Telerik.Reporting.TextBox();
            this.PDNumberData = new Telerik.Reporting.TextBox();
            this.FWSTitleCaption = new Telerik.Reporting.TextBox();
            this.FWSTitleDatao = new Telerik.Reporting.TextBox();
            this.OPMTitleCaption = new Telerik.Reporting.TextBox();
            this.FWSTitleData = new Telerik.Reporting.TextBox();
            this.PayPlanCaption = new Telerik.Reporting.TextBox();
            this.PayPlanData = new Telerik.Reporting.TextBox();
            this.ActivityLocationCaption = new Telerik.Reporting.TextBox();
            this.ActivityLocationData = new Telerik.Reporting.TextBox();
            this.DutyLocationCaption = new Telerik.Reporting.TextBox();
            this.DutyLocationData = new Telerik.Reporting.TextBox();
            this.SeriesJustCaption = new Telerik.Reporting.TextBox();
            this.SeriesJustData = new Telerik.Reporting.TextBox();
            this.GradeJustCaption = new Telerik.Reporting.TextBox();
            this.GradeJustData = new Telerik.Reporting.TextBox();
            this.TitleJustCaption = new Telerik.Reporting.TextBox();
            this.TitleJustData = new Telerik.Reporting.TextBox();
            this.AddInfoCaption = new Telerik.Reporting.TextBox();
            this.AddInfoData = new Telerik.Reporting.HtmlTextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox20 = new Telerik.Reporting.TextBox();
            this.textBox21 = new Telerik.Reporting.TextBox();
            this.textBox22 = new Telerik.Reporting.TextBox();
            this.textBox23 = new Telerik.Reporting.TextBox();
            this.textBox24 = new Telerik.Reporting.TextBox();
            this.textBox25 = new Telerik.Reporting.TextBox();
            this.textBox27 = new Telerik.Reporting.TextBox();
            this.textBox28 = new Telerik.Reporting.TextBox();
            this.textBox29 = new Telerik.Reporting.TextBox();
            this.textBox31 = new Telerik.Reporting.TextBox();
            this.textBox32 = new Telerik.Reporting.TextBox();
            this.textBox33 = new Telerik.Reporting.TextBox();
            this.textBox34 = new Telerik.Reporting.TextBox();
            this.textBox36 = new Telerik.Reporting.TextBox();
            this.textBox39 = new Telerik.Reporting.TextBox();
            this.textBox40 = new Telerik.Reporting.TextBox();
            this.textBox43 = new Telerik.Reporting.TextBox();
            this.textBox44 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox45 = new Telerik.Reporting.TextBox();
            this.textBox48 = new Telerik.Reporting.TextBox();
            this.textBox49 = new Telerik.Reporting.TextBox();
            this.textBox50 = new Telerik.Reporting.TextBox();
            this.subReport1 = new Telerik.Reporting.SubReport();
            this.pDExpressDataSetEvalStatement = new HCMS.Reports.PDExpressDataSetEvalStatement();
            this.pdExpressDataSetEvalStatementTableAdapter1 = new HCMS.Reports.PDExpressDataSetEvalStatementTableAdapters.PDExpressDataSetEvalStatementTableAdapter();
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.textBox18 = new Telerik.Reporting.TextBox();
            this.textBox30 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.textBox15 = new Telerik.Reporting.TextBox();
            this.reportHeaderSection1 = new Telerik.Reporting.ReportHeaderSection();
            this.pictureEvalStatementHeader = new Telerik.Reporting.PictureBox();
            this.titleTextBox = new Telerik.Reporting.TextBox();
            this.textBox26 = new Telerik.Reporting.TextBox();
            this.textBox35 = new Telerik.Reporting.TextBox();
            this.textBox37 = new Telerik.Reporting.TextBox();
            this.textBox38 = new Telerik.Reporting.TextBox();
            this.textBox41 = new Telerik.Reporting.TextBox();
            this.textBox42 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox46 = new Telerik.Reporting.TextBox();
            this.textBox47 = new Telerik.Reporting.TextBox();
            this.textBox17 = new Telerik.Reporting.TextBox();
            this.textBox19 = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pdfesFactors1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdgssgFactors1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdNarrativeFactors1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdNarrativeSupervisoryFactors1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classificationStandards1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pDExpressDataSetEvalStatement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pdfesFactors1
            // 
            this.pdfesFactors1.Name = "pdfesFactors1";
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
            // classificationStandards1
            // 
            this.classificationStandards1.Name = "classificationStandards1";
            // 
            // pageFooter
            // 
            this.pageFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.22083346545696259D);
            this.pageFooter.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.currentTimeTextBox,
            this.pageInfoTextBox});
            this.pageFooter.Name = "pageFooter";
            // 
            // currentTimeTextBox
            // 
            this.currentTimeTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
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
            this.pageInfoTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(4.2395439147949219D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.pageInfoTextBox.Name = "pageInfoTextBox";
            this.pageInfoTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.7604167461395264D), Telerik.Reporting.Drawing.Unit.Inch(0.20000003278255463D));
            this.pageInfoTextBox.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(141)))), ((int)(((byte)(105)))));
            this.pageInfoTextBox.Style.Font.Name = "Gill Sans MT";
            this.pageInfoTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(9D);
            this.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.pageInfoTextBox.StyleName = "PageInfo";
            this.pageInfoTextBox.Value = "=PageNumber";
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(1.44992196559906D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.subReportFESFactors,
            this.subReportGSSGFactors,
            this.subReportNarrativeFactors,
            this.subReportNarrativeSupFactors});
            this.detail.Name = "detail";
            // 
            // subReportFESFactors
            // 
            this.subReportFESFactors.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.14000065624713898D));
            this.subReportFESFactors.Name = "subReportFESFactors";
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("FESFactorsPDID", "=Parameters.PositionDescriptionID.Value"));
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("ShowFactorJustification", "=Parameters.ShowFactorJustification.Value"));
            instanceReportSource1.ReportDocument = this.pdfesFactors1;
            this.subReportFESFactors.ReportSource = instanceReportSource1;
            this.subReportFESFactors.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7D), Telerik.Reporting.Drawing.Unit.Inch(0.29359304904937744D));
            this.subReportFESFactors.ItemDataBound += new System.EventHandler(this.subReportFESFactors_ItemDataBound);
            // 
            // subReportGSSGFactors
            // 
            this.subReportGSSGFactors.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.44000115990638733D));
            this.subReportGSSGFactors.Name = "subReportGSSGFactors";
            instanceReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("GSSGFactorsPDID", "=Parameters.PositionDescriptionID.Value"));
            instanceReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("", null));
            instanceReportSource2.ReportDocument = this.pdgssgFactors1;
            this.subReportGSSGFactors.ReportSource = instanceReportSource2;
            this.subReportGSSGFactors.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7D), Telerik.Reporting.Drawing.Unit.Inch(0.2800000011920929D));
            this.subReportGSSGFactors.ItemDataBound += new System.EventHandler(this.subReportGSSGFactors_ItemDataBound);
            // 
            // subReportNarrativeFactors
            // 
            this.subReportNarrativeFactors.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.76222485303878784D));
            this.subReportNarrativeFactors.Name = "subReportNarrativeFactors";
            instanceReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("NFactorsPDID", "=Parameters.PositionDescriptionID.Value"));
            instanceReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("ShowFactorJustification", "=1"));
            instanceReportSource3.ReportDocument = this.pdNarrativeFactors1;
            this.subReportNarrativeFactors.ReportSource = instanceReportSource3;
            this.subReportNarrativeFactors.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.9999604225158691D), Telerik.Reporting.Drawing.Unit.Inch(0.29992040991783142D));
            this.subReportNarrativeFactors.ItemDataBound += new System.EventHandler(this.subReportNarrativeFactors_ItemDataBound);
            // 
            // subReportNarrativeSupFactors
            // 
            this.subReportNarrativeSupFactors.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(1.06222403049469D));
            this.subReportNarrativeSupFactors.Name = "subReportNarrativeSupFactors";
            instanceReportSource4.Parameters.Add(new Telerik.Reporting.Parameter("NSPDID", "=Parameters.PositionDescriptionID.Value"));
            instanceReportSource4.Parameters.Add(new Telerik.Reporting.Parameter("ShowFactorJustification", "=1"));
            instanceReportSource4.ReportDocument = this.pdNarrativeSupervisoryFactors1;
            this.subReportNarrativeSupFactors.ReportSource = instanceReportSource4;
            this.subReportNarrativeSupFactors.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.9800000190734863D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.subReportNarrativeSupFactors.ItemDataBound += new System.EventHandler(this.subReportNarrativeSupFactors_ItemDataBound);
            // 
            // tableEvalStatement
            // 
            this.tableEvalStatement.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(2.4150002002716064D)));
            this.tableEvalStatement.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D)));
            this.tableEvalStatement.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30009192228317261D)));
            this.tableEvalStatement.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30009159445762634D)));
            this.tableEvalStatement.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30009192228317261D)));
            this.tableEvalStatement.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30009192228317261D)));
            this.tableEvalStatement.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30009192228317261D)));
            this.tableEvalStatement.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D)));
            this.tableEvalStatement.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.29008835554122925D)));
            this.tableEvalStatement.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.29008835554122925D)));
            this.tableEvalStatement.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30009192228317261D)));
            this.tableEvalStatement.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30009192228317261D)));
            this.tableEvalStatement.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.94403666257858276D)));
            this.tableEvalStatement.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D)));
            this.tableEvalStatement.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D)));
            this.tableEvalStatement.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D)));
            this.tableEvalStatement.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D)));
            this.tableEvalStatement.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D)));
            this.tableEvalStatement.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D)));
            this.tableEvalStatement.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D)));
            this.tableEvalStatement.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D)));
            this.tableEvalStatement.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D)));
            this.tableEvalStatement.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.99999970197677612D)));
            this.tableEvalStatement.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30009192228317261D)));
            this.tableEvalStatement.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30009192228317261D)));
            this.tableEvalStatement.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30009192228317261D)));
            this.tableEvalStatement.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30009159445762634D)));
            this.tableEvalStatement.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(1.0003036260604858D)));
            this.tableEvalStatement.Body.SetCellContent(0, 0, this.PDNumberCaption);
            this.tableEvalStatement.Body.SetCellContent(0, 1, this.PDNumberData);
            this.tableEvalStatement.Body.SetCellContent(2, 0, this.FWSTitleCaption);
            this.tableEvalStatement.Body.SetCellContent(2, 1, this.FWSTitleDatao);
            this.tableEvalStatement.Body.SetCellContent(3, 0, this.OPMTitleCaption);
            this.tableEvalStatement.Body.SetCellContent(3, 1, this.FWSTitleData);
            this.tableEvalStatement.Body.SetCellContent(4, 0, this.PayPlanCaption);
            this.tableEvalStatement.Body.SetCellContent(4, 1, this.PayPlanData);
            this.tableEvalStatement.Body.SetCellContent(8, 0, this.ActivityLocationCaption);
            this.tableEvalStatement.Body.SetCellContent(8, 1, this.ActivityLocationData);
            this.tableEvalStatement.Body.SetCellContent(9, 0, this.DutyLocationCaption);
            this.tableEvalStatement.Body.SetCellContent(9, 1, this.DutyLocationData);
            this.tableEvalStatement.Body.SetCellContent(21, 0, this.SeriesJustCaption);
            this.tableEvalStatement.Body.SetCellContent(21, 1, this.SeriesJustData);
            this.tableEvalStatement.Body.SetCellContent(22, 0, this.GradeJustCaption);
            this.tableEvalStatement.Body.SetCellContent(22, 1, this.GradeJustData);
            this.tableEvalStatement.Body.SetCellContent(23, 0, this.TitleJustCaption);
            this.tableEvalStatement.Body.SetCellContent(23, 1, this.TitleJustData);
            this.tableEvalStatement.Body.SetCellContent(25, 0, this.AddInfoCaption);
            this.tableEvalStatement.Body.SetCellContent(25, 1, this.AddInfoData);
            this.tableEvalStatement.Body.SetCellContent(1, 0, this.textBox1);
            this.tableEvalStatement.Body.SetCellContent(1, 1, this.textBox2);
            this.tableEvalStatement.Body.SetCellContent(24, 0, this.textBox3);
            this.tableEvalStatement.Body.SetCellContent(24, 1, this.textBox4);
            this.tableEvalStatement.Body.SetCellContent(10, 0, this.textBox5);
            this.tableEvalStatement.Body.SetCellContent(10, 1, this.textBox6);
            this.tableEvalStatement.Body.SetCellContent(6, 0, this.textBox20);
            this.tableEvalStatement.Body.SetCellContent(6, 1, this.textBox21);
            this.tableEvalStatement.Body.SetCellContent(7, 0, this.textBox22);
            this.tableEvalStatement.Body.SetCellContent(7, 1, this.textBox23);
            this.tableEvalStatement.Body.SetCellContent(5, 0, this.textBox24);
            this.tableEvalStatement.Body.SetCellContent(5, 1, this.textBox25);
            this.tableEvalStatement.Body.SetCellContent(11, 1, this.textBox27);
            this.tableEvalStatement.Body.SetCellContent(11, 0, this.textBox28);
            this.tableEvalStatement.Body.SetCellContent(12, 0, this.textBox29);
            this.tableEvalStatement.Body.SetCellContent(12, 1, this.textBox31);
            this.tableEvalStatement.Body.SetCellContent(13, 0, this.textBox32);
            this.tableEvalStatement.Body.SetCellContent(13, 1, this.textBox33);
            this.tableEvalStatement.Body.SetCellContent(14, 0, this.textBox34);
            this.tableEvalStatement.Body.SetCellContent(14, 1, this.textBox36);
            this.tableEvalStatement.Body.SetCellContent(15, 0, this.textBox39);
            this.tableEvalStatement.Body.SetCellContent(15, 1, this.textBox40);
            this.tableEvalStatement.Body.SetCellContent(16, 0, this.textBox43);
            this.tableEvalStatement.Body.SetCellContent(16, 1, this.textBox44);
            this.tableEvalStatement.Body.SetCellContent(17, 0, this.textBox7);
            this.tableEvalStatement.Body.SetCellContent(17, 1, this.textBox9);
            this.tableEvalStatement.Body.SetCellContent(18, 0, this.textBox13);
            this.tableEvalStatement.Body.SetCellContent(18, 1, this.textBox45);
            this.tableEvalStatement.Body.SetCellContent(19, 0, this.textBox48);
            this.tableEvalStatement.Body.SetCellContent(19, 1, this.textBox49);
            this.tableEvalStatement.Body.SetCellContent(20, 0, this.textBox50);
            this.tableEvalStatement.Body.SetCellContent(20, 1, this.subReport1);
            this.tableEvalStatement.ColumnGroups.Add(tableGroup1);
            this.tableEvalStatement.ColumnGroups.Add(tableGroup2);
            this.tableEvalStatement.DataMember = "";
            this.tableEvalStatement.DataSource = this.pDExpressDataSetEvalStatement;
            this.tableEvalStatement.Filters.AddRange(new Telerik.Reporting.Filter[] {
            new Telerik.Reporting.Filter("=Fields.PositionDescriptionID", Telerik.Reporting.FilterOperator.Equal, "=Parameters.PositionDescriptionID.Value")});
            this.tableEvalStatement.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.PDNumberCaption,
            this.PDNumberData,
            this.FWSTitleCaption,
            this.FWSTitleDatao,
            this.OPMTitleCaption,
            this.FWSTitleData,
            this.PayPlanCaption,
            this.PayPlanData,
            this.ActivityLocationCaption,
            this.ActivityLocationData,
            this.DutyLocationCaption,
            this.DutyLocationData,
            this.SeriesJustCaption,
            this.SeriesJustData,
            this.GradeJustCaption,
            this.GradeJustData,
            this.TitleJustCaption,
            this.TitleJustData,
            this.AddInfoCaption,
            this.AddInfoData,
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.textBox5,
            this.textBox6,
            this.textBox20,
            this.textBox21,
            this.textBox22,
            this.textBox23,
            this.textBox24,
            this.textBox25,
            this.textBox27,
            this.textBox28,
            this.textBox29,
            this.textBox31,
            this.textBox32,
            this.textBox33,
            this.textBox34,
            this.textBox36,
            this.textBox39,
            this.textBox40,
            this.textBox43,
            this.textBox44,
            this.textBox7,
            this.textBox9,
            this.textBox13,
            this.textBox45,
            this.textBox48,
            this.textBox49,
            this.textBox50,
            this.subReport1});
            this.tableEvalStatement.KeepTogether = false;
            this.tableEvalStatement.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(1.6000000238418579D));
            this.tableEvalStatement.Name = "tableEvalStatement";
            tableGroup4.Name = "Group1";
            tableGroup5.Name = "Group20";
            tableGroup6.Name = "Group2";
            tableGroup7.Name = "Group3";
            tableGroup8.Name = "Group4";
            tableGroup9.Name = "Group26";
            tableGroup10.Name = "Group17";
            tableGroup11.Name = "Group25";
            tableGroup12.Name = "Group5";
            tableGroup13.Name = "Group6";
            tableGroup14.Name = "Group7";
            tableGroup15.Name = "Group27";
            tableGroup16.Name = "Group28";
            tableGroup17.Name = "Group29";
            tableGroup18.Name = "Group12";
            tableGroup19.Name = "Group15";
            tableGroup20.Name = "Group16";
            tableGroup21.Name = "Group9";
            tableGroup22.Name = "Group22";
            tableGroup23.Name = "Group23";
            tableGroup24.Name = "Group18";
            tableGroup25.Name = "Group10";
            tableGroup26.Name = "Group11";
            tableGroup27.Name = "Group13";
            tableGroup28.Name = "Group21";
            tableGroup29.Name = "Group14";
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
            tableGroup3.ChildGroups.Add(tableGroup24);
            tableGroup3.ChildGroups.Add(tableGroup25);
            tableGroup3.ChildGroups.Add(tableGroup26);
            tableGroup3.ChildGroups.Add(tableGroup27);
            tableGroup3.ChildGroups.Add(tableGroup28);
            tableGroup3.ChildGroups.Add(tableGroup29);
            tableGroup3.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping("")});
            tableGroup3.Name = "DetailGroup";
            this.tableEvalStatement.RowGroups.Add(tableGroup3);
            this.tableEvalStatement.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0000004768371582D), Telerik.Reporting.Drawing.Unit.Inch(9.825526237487793D));
            this.tableEvalStatement.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Inch(0D);
            this.tableEvalStatement.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // PDNumberCaption
            // 
            this.PDNumberCaption.Name = "PDNumberCaption";
            this.PDNumberCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4149999618530273D), Telerik.Reporting.Drawing.Unit.Inch(0.300091952085495D));
            this.PDNumberCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.PDNumberCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.PDNumberCaption.Style.Font.Bold = true;
            this.PDNumberCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.PDNumberCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.PDNumberCaption.Value = "PD No.:";
            // 
            // PDNumberData
            // 
            this.PDNumberData.Name = "PDNumberData";
            this.PDNumberData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.300091952085495D));
            this.PDNumberData.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.PDNumberData.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.PDNumberData.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.PDNumberData.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.PDNumberData.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.PDNumberData.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.PDNumberData.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.PDNumberData.Value = "=Fields.PositionDescriptionID";
            // 
            // FWSTitleCaption
            // 
            this.FWSTitleCaption.Name = "FWSTitleCaption";
            this.FWSTitleCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4149999618530273D), Telerik.Reporting.Drawing.Unit.Inch(0.300091952085495D));
            this.FWSTitleCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.FWSTitleCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.FWSTitleCaption.Style.Font.Bold = true;
            this.FWSTitleCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.FWSTitleCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.FWSTitleCaption.Value = "FWS Title:";
            // 
            // FWSTitleDatao
            // 
            this.FWSTitleDatao.Name = "FWSTitleDatao";
            this.FWSTitleDatao.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.300091952085495D));
            this.FWSTitleDatao.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.FWSTitleDatao.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.FWSTitleDatao.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.FWSTitleDatao.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.FWSTitleDatao.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.FWSTitleDatao.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.FWSTitleDatao.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.FWSTitleDatao.Value = "=Fields.AgencyPositionTitle";
            // 
            // OPMTitleCaption
            // 
            this.OPMTitleCaption.Name = "OPMTitleCaption";
            this.OPMTitleCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4149999618530273D), Telerik.Reporting.Drawing.Unit.Inch(0.300091952085495D));
            this.OPMTitleCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.OPMTitleCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.OPMTitleCaption.Style.Font.Bold = true;
            this.OPMTitleCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.OPMTitleCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.OPMTitleCaption.Value = "OPM Title:";
            // 
            // FWSTitleData
            // 
            this.FWSTitleData.Name = "FWSTitleData";
            this.FWSTitleData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.300091952085495D));
            this.FWSTitleData.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.FWSTitleData.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.FWSTitleData.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.FWSTitleData.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.FWSTitleData.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.FWSTitleData.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.FWSTitleData.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.FWSTitleData.Value = "=Fields.OPMJobTitle";
            // 
            // PayPlanCaption
            // 
            this.PayPlanCaption.Name = "PayPlanCaption";
            this.PayPlanCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4149999618530273D), Telerik.Reporting.Drawing.Unit.Inch(0.300091952085495D));
            this.PayPlanCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.PayPlanCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.PayPlanCaption.Style.Font.Bold = true;
            this.PayPlanCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.PayPlanCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.PayPlanCaption.Value = "Pay Plan, Series & Grade:";
            // 
            // PayPlanData
            // 
            this.PayPlanData.Name = "PayPlanData";
            this.PayPlanData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.300091952085495D));
            this.PayPlanData.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.PayPlanData.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.PayPlanData.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.PayPlanData.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.PayPlanData.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.PayPlanData.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.PayPlanData.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.PayPlanData.Value = "= Fields.PayPlanAbbrev + \'-\' + Substr(Format(\'0000{0}\', Fields.JobSeries), Len(Fo" +
    "rmat(\'0000{0}\', Fields.JobSeries))-4, 4) + \' : \' + Fields.SeriesName + \'-\' + Fie" +
    "lds.ProposedGrade";
            // 
            // ActivityLocationCaption
            // 
            this.ActivityLocationCaption.Name = "ActivityLocationCaption";
            this.ActivityLocationCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4149999618530273D), Telerik.Reporting.Drawing.Unit.Inch(0.300091952085495D));
            this.ActivityLocationCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.ActivityLocationCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.ActivityLocationCaption.Style.Font.Bold = true;
            this.ActivityLocationCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.ActivityLocationCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.ActivityLocationCaption.Value = "Employing Office Location:";
            // 
            // ActivityLocationData
            // 
            this.ActivityLocationData.Name = "ActivityLocationData";
            this.ActivityLocationData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.300091952085495D));
            this.ActivityLocationData.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.ActivityLocationData.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.ActivityLocationData.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.ActivityLocationData.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.ActivityLocationData.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.ActivityLocationData.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.ActivityLocationData.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.ActivityLocationData.Value = "=Fields.EmployingOfficeLocation";
            // 
            // DutyLocationCaption
            // 
            this.DutyLocationCaption.Name = "DutyLocationCaption";
            this.DutyLocationCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4149999618530273D), Telerik.Reporting.Drawing.Unit.Inch(0.300091952085495D));
            this.DutyLocationCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.DutyLocationCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.DutyLocationCaption.Style.Font.Bold = true;
            this.DutyLocationCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.DutyLocationCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.DutyLocationCaption.Value = "Duty Location:";
            // 
            // DutyLocationData
            // 
            this.DutyLocationData.Name = "DutyLocationData";
            this.DutyLocationData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.300091952085495D));
            this.DutyLocationData.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.DutyLocationData.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.DutyLocationData.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.DutyLocationData.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.DutyLocationData.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.DutyLocationData.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.DutyLocationData.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.DutyLocationData.Value = "=Fields.DutyLocation";
            // 
            // SeriesJustCaption
            // 
            this.SeriesJustCaption.Name = "SeriesJustCaption";
            this.SeriesJustCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4149999618530273D), Telerik.Reporting.Drawing.Unit.Inch(0.300091952085495D));
            this.SeriesJustCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.SeriesJustCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.SeriesJustCaption.Style.Font.Bold = true;
            this.SeriesJustCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.SeriesJustCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.SeriesJustCaption.Value = "Series Justification:";
            // 
            // SeriesJustData
            // 
            this.SeriesJustData.Name = "SeriesJustData";
            this.SeriesJustData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.300091952085495D));
            this.SeriesJustData.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.SeriesJustData.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.SeriesJustData.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.SeriesJustData.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.SeriesJustData.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.SeriesJustData.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.SeriesJustData.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.SeriesJustData.Value = "=Fields.SeriesJustification";
            // 
            // GradeJustCaption
            // 
            this.GradeJustCaption.Name = "GradeJustCaption";
            this.GradeJustCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4149999618530273D), Telerik.Reporting.Drawing.Unit.Inch(0.300091952085495D));
            this.GradeJustCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.GradeJustCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.GradeJustCaption.Style.Font.Bold = true;
            this.GradeJustCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.GradeJustCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.GradeJustCaption.Value = "Title Justification:";
            // 
            // GradeJustData
            // 
            this.GradeJustData.Name = "GradeJustData";
            this.GradeJustData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.300091952085495D));
            this.GradeJustData.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.GradeJustData.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.GradeJustData.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.GradeJustData.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.GradeJustData.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.GradeJustData.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.GradeJustData.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.GradeJustData.Value = "=Fields.TitleJustification";
            // 
            // TitleJustCaption
            // 
            this.TitleJustCaption.Name = "TitleJustCaption";
            this.TitleJustCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4149999618530273D), Telerik.Reporting.Drawing.Unit.Inch(0.300091952085495D));
            this.TitleJustCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.TitleJustCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.TitleJustCaption.Style.Font.Bold = true;
            this.TitleJustCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.TitleJustCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.TitleJustCaption.Value = "Grade\t Justification:";
            // 
            // TitleJustData
            // 
            this.TitleJustData.Name = "TitleJustData";
            this.TitleJustData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.300091952085495D));
            this.TitleJustData.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.TitleJustData.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.TitleJustData.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.TitleJustData.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.TitleJustData.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.TitleJustData.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.TitleJustData.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.TitleJustData.Value = "=Fields.GradeJustification";
            // 
            // AddInfoCaption
            // 
            this.AddInfoCaption.Name = "AddInfoCaption";
            this.AddInfoCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4149999618530273D), Telerik.Reporting.Drawing.Unit.Inch(1.0003038644790649D));
            this.AddInfoCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.AddInfoCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.AddInfoCaption.Style.Font.Bold = true;
            this.AddInfoCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.AddInfoCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.AddInfoCaption.Value = "Additional Position Information:";
            // 
            // AddInfoData
            // 
            this.AddInfoData.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.2000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(5.1082353591918945D));
            this.AddInfoData.Name = "AddInfoData";
            this.AddInfoData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(1.0003038644790649D));
            this.AddInfoData.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.AddInfoData.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.AddInfoData.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.AddInfoData.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.AddInfoData.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.AddInfoData.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.AddInfoData.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.AddInfoData.Value = resources.GetString("AddInfoData.Value");
            // 
            // textBox1
            // 
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4149999618530273D), Telerik.Reporting.Drawing.Unit.Inch(0.30009150505065918D));
            this.textBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox1.Value = "FPPS PD No.:";
            // 
            // textBox2
            // 
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.30009150505065918D));
            this.textBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox2.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox2.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox2.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox2.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox2.Value = "= Fields.FPPSPDID";
            // 
            // textBox3
            // 
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4149999618530273D), Telerik.Reporting.Drawing.Unit.Inch(0.30009150505065918D));
            this.textBox3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox3.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox3.Style.Font.Bold = true;
            this.textBox3.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox3.Value = "Additional Justification:";
            // 
            // textBox4
            // 
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.30009150505065918D));
            this.textBox4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox4.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox4.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox4.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox4.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox4.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox4.Value = "= Fields.AdditionalJustification";
            // 
            // textBox5
            // 
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4149999618530273D), Telerik.Reporting.Drawing.Unit.Inch(0.94403707981109619D));
            this.textBox5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox5.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox5.Style.Font.Bold = true;
            this.textBox5.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox5.Value = "Organization Structure:";
            // 
            // textBox6
            // 
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.94403707981109619D));
            this.textBox6.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox6.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox6.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox6.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox6.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox6.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox6.Value = resources.GetString("textBox6.Value");
            // 
            // textBox20
            // 
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4149999618530273D), Telerik.Reporting.Drawing.Unit.Inch(0.29008832573890686D));
            this.textBox20.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox20.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox20.Style.Font.Bold = true;
            this.textBox20.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox20.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox20.Value = "Is Interdisciplinary PD?";
            // 
            // textBox21
            // 
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.29008832573890686D));
            this.textBox21.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox21.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox21.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox21.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox21.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox21.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox21.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox21.Value = "=IIF(Fields.IsInterdisciplinaryPD,\"YES\",\"NO\")";
            // 
            // textBox22
            // 
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4149999618530273D), Telerik.Reporting.Drawing.Unit.Inch(0.29008832573890686D));
            this.textBox22.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox22.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox22.Style.Font.Bold = true;
            this.textBox22.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox22.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox22.Value = "Additional Series:";
            // 
            // textBox23
            // 
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.29008832573890686D));
            this.textBox23.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox23.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox23.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox23.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox23.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox23.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox23.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox23.Value = "=Fields.AdditionalSeries";
            // 
            // textBox24
            // 
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4150002002716064D), Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D));
            this.textBox24.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox24.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox24.Style.Font.Bold = true;
            this.textBox24.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox24.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox24.Value = "Full Performance Level:";
            // 
            // textBox25
            // 
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D));
            this.textBox25.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox25.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox25.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox25.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox25.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox25.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox25.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox25.Value = "= Fields.ProposedFPGrade";
            // 
            // textBox27
            // 
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D));
            this.textBox27.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox27.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox27.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox27.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox27.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox27.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox27.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox27.Value = "=Fields.SupervisorFullName";
            // 
            // textBox28
            // 
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4150002002716064D), Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D));
            this.textBox28.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox28.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox28.Style.Font.Bold = true;
            this.textBox28.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox28.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox28.Value = "Supervisor Signature:";
            // 
            // textBox29
            // 
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4150002002716064D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.textBox29.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox29.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox29.Style.Font.Bold = true;
            this.textBox29.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox29.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox29.Value = "Supervisor Title:";
            // 
            // textBox31
            // 
            this.textBox31.Name = "textBox31";
            this.textBox31.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.textBox31.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox31.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox31.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox31.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox31.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox31.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox31.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox31.Value = "= Fields.SupervisorOrgTitle";
            // 
            // textBox32
            // 
            this.textBox32.Name = "textBox32";
            this.textBox32.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4150002002716064D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.textBox32.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox32.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox32.Style.Font.Bold = true;
            this.textBox32.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox32.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox32.Value = "Supervisor Sign Date:";
            // 
            // textBox33
            // 
            this.textBox33.Name = "textBox33";
            this.textBox33.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.textBox33.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox33.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox33.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox33.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox33.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox33.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox33.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox33.Value = "=Fields.SupervisorSignDate";
            // 
            // textBox34
            // 
            this.textBox34.Name = "textBox34";
            this.textBox34.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4150002002716064D), Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D));
            this.textBox34.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox34.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox34.Style.Font.Bold = true;
            this.textBox34.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox34.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox34.Value = "Approving Official Signature:";
            // 
            // textBox36
            // 
            this.textBox36.Name = "textBox36";
            this.textBox36.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D));
            this.textBox36.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox36.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox36.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox36.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox36.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox36.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox36.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox36.Value = "= Fields.AdditionalSupervisorFullName";
            // 
            // textBox39
            // 
            this.textBox39.Name = "textBox39";
            this.textBox39.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4150002002716064D), Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D));
            this.textBox39.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox39.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox39.Style.Font.Bold = true;
            this.textBox39.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox39.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox39.Value = "Approving Official Title:";
            // 
            // textBox40
            // 
            this.textBox40.Name = "textBox40";
            this.textBox40.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D));
            this.textBox40.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox40.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox40.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox40.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox40.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox40.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox40.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox40.Value = "= Fields.AdditionalSupOrgTitle";
            // 
            // textBox43
            // 
            this.textBox43.Name = "textBox43";
            this.textBox43.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4150002002716064D), Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D));
            this.textBox43.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox43.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox43.Style.Font.Bold = true;
            this.textBox43.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox43.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox43.Value = "Approving Official Sign Date:";
            // 
            // textBox44
            // 
            this.textBox44.Name = "textBox44";
            this.textBox44.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D));
            this.textBox44.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox44.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox44.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox44.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox44.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox44.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox44.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox44.Value = "= Fields.AdditionalSupervisorSignDate";
            // 
            // textBox7
            // 
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4150002002716064D), Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D));
            this.textBox7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox7.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox7.Style.Font.Bold = true;
            this.textBox7.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox7.Value = "Classifier Signature:";
            // 
            // textBox9
            // 
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D));
            this.textBox9.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox9.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox9.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox9.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox9.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox9.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox9.Value = "=Fields.ClassifierFullName";
            // 
            // textBox13
            // 
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4150002002716064D), Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D));
            this.textBox13.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox13.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox13.Style.Font.Bold = true;
            this.textBox13.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox13.Value = "Classifier Title:";
            // 
            // textBox45
            // 
            this.textBox45.Name = "textBox45";
            this.textBox45.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D));
            this.textBox45.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox45.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox45.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox45.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox45.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox45.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox45.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox45.Value = "=Fields.ClassifierOrgTitle";
            // 
            // textBox48
            // 
            this.textBox48.Name = "textBox48";
            this.textBox48.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4150002002716064D), Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D));
            this.textBox48.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox48.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox48.Style.Font.Bold = true;
            this.textBox48.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox48.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox48.Value = "Classifier Sign Date:";
            // 
            // textBox49
            // 
            this.textBox49.Name = "textBox49";
            this.textBox49.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D));
            this.textBox49.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox49.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox49.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox49.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox49.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox49.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox49.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox49.Value = "=Fields.ClassifierSignDate";
            // 
            // textBox50
            // 
            this.textBox50.Name = "textBox50";
            this.textBox50.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4150002002716064D), Telerik.Reporting.Drawing.Unit.Inch(1D));
            this.textBox50.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox50.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox50.Style.Font.Bold = true;
            this.textBox50.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox50.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox50.Value = "Standards Used to Classify the Job:";
            // 
            // subReport1
            // 
            this.subReport1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.2000000476837158D), Telerik.Reporting.Drawing.Unit.Inch(2.9207546710968018D));
            this.subReport1.Name = "subReport1";
            instanceReportSource5.Parameters.Add(new Telerik.Reporting.Parameter("PositionDescriptionID", "=Parameters.PositionDescriptionID"));
            instanceReportSource5.ReportDocument = this.classificationStandards1;
            this.subReport1.ReportSource = instanceReportSource5;
            this.subReport1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(1D));
            this.subReport1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.subReport1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.subReport1.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.subReport1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.subReport1.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.subReport1.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.subReport1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // pDExpressDataSetEvalStatement
            // 
            this.pDExpressDataSetEvalStatement.DataSetName = "PDExpressDataSetEvalStatement";
            this.pDExpressDataSetEvalStatement.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pdExpressDataSetEvalStatementTableAdapter1
            // 
            this.pdExpressDataSetEvalStatementTableAdapter1.ClearBeforeFill = true;
            // 
            // textBox16
            // 
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.929999828338623D), Telerik.Reporting.Drawing.Unit.Inch(1D));
            // 
            // textBox18
            // 
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.929999828338623D), Telerik.Reporting.Drawing.Unit.Inch(1.0000001192092896D));
            this.textBox18.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox18.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox18.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox18.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox30
            // 
            this.textBox30.Name = "textBox30";
            this.textBox30.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.929999828338623D), Telerik.Reporting.Drawing.Unit.Inch(0.99999994039535522D));
            // 
            // textBox11
            // 
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.0699996948242188D), Telerik.Reporting.Drawing.Unit.Inch(0.26666665077209473D));
            this.textBox11.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox11.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox11.Style.Font.Bold = true;
            this.textBox11.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox11.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox14
            // 
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.0699996948242188D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.textBox14.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox14.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox14.Style.Font.Bold = true;
            this.textBox14.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox15
            // 
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.929999828338623D), Telerik.Reporting.Drawing.Unit.Inch(0.31874999403953552D));
            this.textBox15.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox15.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox15.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox15.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox15.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox15.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox15.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // reportHeaderSection1
            // 
            this.reportHeaderSection1.Height = Telerik.Reporting.Drawing.Unit.Inch(11.500000953674316D);
            this.reportHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pictureEvalStatementHeader,
            this.titleTextBox,
            this.tableEvalStatement});
            this.reportHeaderSection1.KeepTogether = false;
            this.reportHeaderSection1.Name = "reportHeaderSection1";
            // 
            // pictureEvalStatementHeader
            // 
            this.pictureEvalStatementHeader.MimeType = "image/png";
            this.pictureEvalStatementHeader.Name = "pictureEvalStatementHeader";
            this.pictureEvalStatementHeader.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0000004768371582D), Telerik.Reporting.Drawing.Unit.Inch(1.1999211311340332D));
            this.pictureEvalStatementHeader.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(227)))), ((int)(((byte)(240)))));
            this.pictureEvalStatementHeader.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pictureEvalStatementHeader.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pictureEvalStatementHeader.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pictureEvalStatementHeader.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.pictureEvalStatementHeader.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.pictureEvalStatementHeader.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.pictureEvalStatementHeader.Value = ((object)(resources.GetObject("pictureEvalStatementHeader.Value")));
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(1.1999999284744263D));
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7D), Telerik.Reporting.Drawing.Unit.Inch(0.38999998569488525D));
            this.titleTextBox.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(227)))), ((int)(((byte)(240)))));
            this.titleTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.titleTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.titleTextBox.Style.Font.Bold = true;
            this.titleTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(20D);
            this.titleTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.titleTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.titleTextBox.Value = "Evaluation Statement";
            // 
            // textBox26
            // 
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4150002002716064D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.textBox26.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox26.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox26.Style.Font.Bold = true;
            this.textBox26.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox26.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox35
            // 
            this.textBox35.Name = "textBox35";
            this.textBox35.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.textBox35.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox35.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox35.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox35.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox35.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox35.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox35.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox37
            // 
            this.textBox37.Name = "textBox37";
            this.textBox37.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4150002002716064D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.textBox37.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox37.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox37.Style.Font.Bold = true;
            this.textBox37.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox37.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox38
            // 
            this.textBox38.Name = "textBox38";
            this.textBox38.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.textBox38.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox38.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox38.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox38.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox38.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox38.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox38.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox41
            // 
            this.textBox41.Name = "textBox41";
            this.textBox41.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4150002002716064D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.textBox41.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox41.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox41.Style.Font.Bold = true;
            this.textBox41.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox41.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox42
            // 
            this.textBox42.Name = "textBox42";
            this.textBox42.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.textBox42.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox42.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox42.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox42.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox42.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox42.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox42.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox8
            // 
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.textBox8.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox8.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox8.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox8.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox8.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox8.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox10
            // 
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4150002002716064D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.textBox10.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox10.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox10.Style.Font.Bold = true;
            this.textBox10.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox10.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox12
            // 
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.textBox12.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox12.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox12.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox12.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox12.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox12.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox46
            // 
            this.textBox46.Name = "textBox46";
            this.textBox46.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4150002002716064D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.textBox46.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox46.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox46.Style.Font.Bold = true;
            this.textBox46.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox46.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox47
            // 
            this.textBox47.Name = "textBox47";
            this.textBox47.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.textBox47.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox47.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox47.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox47.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox47.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox47.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox47.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox17
            // 
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4150002002716064D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.textBox17.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox17.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox17.Style.Font.Bold = true;
            this.textBox17.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox17.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox19
            // 
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5850000381469727D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.textBox19.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox19.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox19.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox19.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox19.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox19.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox19.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // EvalStatement
            // 
            this.DataSource = this.pDExpressDataSetEvalStatement;
            this.Filters.AddRange(new Telerik.Reporting.Filter[] {
            new Telerik.Reporting.Filter("=Fields.PositionDescriptionID", Telerik.Reporting.FilterOperator.Equal, "=Parameters.PositionDescriptionID")});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageFooter,
            this.detail,
            this.reportHeaderSection1});
            this.Name = "EvalStatement";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "PositionDescriptionID";
            reportParameter1.Text = "Enter PDID";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter1.Value = "= Parameters.PositionDescriptionID.Value";
            reportParameter1.Visible = true;
            reportParameter2.Name = "ShowFactorJustification";
            reportParameter2.Value = "Yes";
            this.ReportParameters.Add(reportParameter1);
            this.ReportParameters.Add(reportParameter2);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
            styleRule1.Style.Color = System.Drawing.Color.Black;
            styleRule1.Style.Font.Bold = true;
            styleRule1.Style.Font.Italic = false;
            styleRule1.Style.Font.Name = "Tahoma";
            styleRule1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(20D);
            styleRule1.Style.Font.Strikeout = false;
            styleRule1.Style.Font.Underline = false;
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
            styleRule2.Style.Color = System.Drawing.Color.Black;
            styleRule2.Style.Font.Name = "Tahoma";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            styleRule2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
            styleRule3.Style.Font.Name = "Tahoma";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("PageInfo")});
            styleRule4.Style.Font.Name = "Tahoma";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4});
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(7.3000001907348633D);
            ((System.ComponentModel.ISupportInitialize)(this.pdfesFactors1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdgssgFactors1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdNarrativeFactors1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pdNarrativeSupervisoryFactors1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classificationStandards1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pDExpressDataSetEvalStatement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private PageFooterSection pageFooter;
        private Telerik.Reporting.TextBox currentTimeTextBox;
        private Telerik.Reporting.TextBox pageInfoTextBox;
        private DetailSection detail;
        private Table tableEvalStatement;
        private Telerik.Reporting.TextBox PDNumberCaption;
        private Telerik.Reporting.TextBox PDNumberData;
        private PDExpressDataSetEvalStatement pDExpressDataSetEvalStatement;
        private HCMS.Reports.PDExpressDataSetEvalStatementTableAdapters.PDExpressDataSetEvalStatementTableAdapter pdExpressDataSetEvalStatementTableAdapter1;
        private Telerik.Reporting.TextBox FWSTitleCaption;
        private Telerik.Reporting.TextBox FWSTitleDatao;
        private Telerik.Reporting.TextBox OPMTitleCaption;
        private Telerik.Reporting.TextBox FWSTitleData;
        private Telerik.Reporting.TextBox PayPlanCaption;
        private Telerik.Reporting.TextBox PayPlanData;
        private Telerik.Reporting.TextBox ActivityLocationCaption;
        private Telerik.Reporting.TextBox ActivityLocationData;
        private Telerik.Reporting.TextBox DutyLocationCaption;
        private Telerik.Reporting.TextBox DutyLocationData;
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.TextBox textBox18;
        private Telerik.Reporting.TextBox SeriesJustCaption;
        private Telerik.Reporting.TextBox SeriesJustData;
        private Telerik.Reporting.TextBox GradeJustCaption;
        private Telerik.Reporting.TextBox GradeJustData;
        private Telerik.Reporting.TextBox TitleJustCaption;
        private Telerik.Reporting.TextBox TitleJustData;
        private Telerik.Reporting.TextBox AddInfoCaption;
        private Telerik.Reporting.TextBox textBox30;
        private HtmlTextBox AddInfoData;
        private ClassificationStandards classificationStandards1;
        private SubReport subReportFESFactors;
        private SubReport subReportGSSGFactors;
        private SubReport subReportNarrativeFactors;
        private HCMS.Reports.PositionDescription.PDFESFactors pdfesFactors1;
        private HCMS.Reports.PositionDescription.PDGSSGFactors pdgssgFactors1;
        private HCMS.Reports.PositionDescription.PDNarrativeFactors pdNarrativeFactors1;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.TextBox textBox15;
        private Telerik.Reporting.TextBox textBox20;
        private Telerik.Reporting.TextBox textBox21;
        private Telerik.Reporting.TextBox textBox22;
        private Telerik.Reporting.TextBox textBox23;
        private SubReport subReportNarrativeSupFactors;
        private HCMS.Reports.PositionDescription.PDNarrativeSupervisoryFactors pdNarrativeSupervisoryFactors1;
        private ReportHeaderSection reportHeaderSection1;
        private Telerik.Reporting.PictureBox pictureEvalStatementHeader;
        private Telerik.Reporting.TextBox titleTextBox;
        private Telerik.Reporting.TextBox textBox24;
        private Telerik.Reporting.TextBox textBox25;
        private Telerik.Reporting.TextBox textBox27;
        private Telerik.Reporting.TextBox textBox28;
        private Telerik.Reporting.TextBox textBox26;
        private Telerik.Reporting.TextBox textBox29;
        private Telerik.Reporting.TextBox textBox31;
        private Telerik.Reporting.TextBox textBox32;
        private Telerik.Reporting.TextBox textBox33;
        private Telerik.Reporting.TextBox textBox34;
        private Telerik.Reporting.TextBox textBox36;
        private Telerik.Reporting.TextBox textBox39;
        private Telerik.Reporting.TextBox textBox40;
        private Telerik.Reporting.TextBox textBox43;
        private Telerik.Reporting.TextBox textBox44;
        private Telerik.Reporting.TextBox textBox35;
        private Telerik.Reporting.TextBox textBox37;
        private Telerik.Reporting.TextBox textBox38;
        private Telerik.Reporting.TextBox textBox41;
        private Telerik.Reporting.TextBox textBox42;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox45;
        private Telerik.Reporting.TextBox textBox48;
        private Telerik.Reporting.TextBox textBox49;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.TextBox textBox46;
        private Telerik.Reporting.TextBox textBox47;
        private Telerik.Reporting.TextBox textBox50;
        private SubReport subReport1;
        private Telerik.Reporting.TextBox textBox17;
        private Telerik.Reporting.TextBox textBox19;

    }
}