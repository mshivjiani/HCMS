namespace HCMS.Reports.JobAnalysis
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    partial class JobAnalysis
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JobAnalysis));
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
            Telerik.Reporting.TableGroup tableGroup30 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup31 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup32 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup33 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup34 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup35 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.InstanceReportSource instanceReportSource1 = new Telerik.Reporting.InstanceReportSource();
            Telerik.Reporting.InstanceReportSource instanceReportSource2 = new Telerik.Reporting.InstanceReportSource();
            Telerik.Reporting.InstanceReportSource instanceReportSource3 = new Telerik.Reporting.InstanceReportSource();
            Telerik.Reporting.InstanceReportSource instanceReportSource4 = new Telerik.Reporting.InstanceReportSource();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            this.jdDuties1 = new HCMS.Reports.JobAnalysis.JDDuties();
            this.positionOverallQualifications1 = new HCMS.Reports.PositionDescription.PositionOverallQualifications();
            this.positionCOEs1 = new HCMS.Reports.PositionDescription.PositionCOEs();
            this.pDExpressDataSetJobAnalysis = new HCMS.Reports.PDExpressDataSetJobAnalysis();
            this.pdExpressDataSetJobAnalysisTableAdapter1 = new HCMS.Reports.PDExpressDataSetJobAnalysisTableAdapters.PDExpressDataSetJobAnalysisTableAdapter();
            this.pageFooter = new Telerik.Reporting.PageFooterSection();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            this.reportHeader = new Telerik.Reporting.ReportHeaderSection();
            this.titleTextBox = new Telerik.Reporting.TextBox();
            this.pictureBoxLogo = new Telerik.Reporting.PictureBox();
            this.table2 = new Telerik.Reporting.Table();
            this.textBoxPDNumberCaption = new Telerik.Reporting.TextBox();
            this.textBoxPayPlanCaption = new Telerik.Reporting.TextBox();
            this.textBoxPayPlanData = new Telerik.Reporting.TextBox();
            this.textBoxPDID = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBoxSuperSignatureCaption = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.textBoxSuperTitleCaption = new Telerik.Reporting.TextBox();
            this.textBoxSuperSignedOnCaption = new Telerik.Reporting.TextBox();
            this.textBox70 = new Telerik.Reporting.TextBox();
            this.textBox74 = new Telerik.Reporting.TextBox();
            this.textBox18 = new Telerik.Reporting.TextBox();
            this.textBox72 = new Telerik.Reporting.TextBox();
            this.textBox19 = new Telerik.Reporting.TextBox();
            this.textBox21 = new Telerik.Reporting.TextBox();
            this.textBox24 = new Telerik.Reporting.TextBox();
            this.textBox25 = new Telerik.Reporting.TextBox();
            this.textBox28 = new Telerik.Reporting.TextBox();
            this.textBox29 = new Telerik.Reporting.TextBox();
            this.textBox30 = new Telerik.Reporting.TextBox();
            this.textBox32 = new Telerik.Reporting.TextBox();
            this.textBox34 = new Telerik.Reporting.TextBox();
            this.textBox36 = new Telerik.Reporting.TextBox();
            this.textBox45 = new Telerik.Reporting.TextBox();
            this.textBox49 = new Telerik.Reporting.TextBox();
            this.textBox37 = new Telerik.Reporting.TextBox();
            this.ActivityLocationData = new Telerik.Reporting.TextBox();
            this.textBox39 = new Telerik.Reporting.TextBox();
            this.textBox43 = new Telerik.Reporting.TextBox();
            this.DutyLocationData = new Telerik.Reporting.TextBox();
            this.textBox44 = new Telerik.Reporting.TextBox();
            this.textBox35 = new Telerik.Reporting.TextBox();
            this.textBoxFWSTitleData = new Telerik.Reporting.TextBox();
            this.textBoxFPGradeData = new Telerik.Reporting.TextBox();
            this.textBoxOPMTitleData = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
            this.subReport3 = new Telerik.Reporting.SubReport();
            this.subReport2 = new Telerik.Reporting.SubReport();
            this.subReportCOEs = new Telerik.Reporting.SubReport();
            this.textBoxPDNumberData = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox64 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox15 = new Telerik.Reporting.TextBox();
            this.textBox17 = new Telerik.Reporting.TextBox();
            this.textBox20 = new Telerik.Reporting.TextBox();
            this.textBox22 = new Telerik.Reporting.TextBox();
            this.textBox23 = new Telerik.Reporting.TextBox();
            this.textBox26 = new Telerik.Reporting.TextBox();
            this.textBox27 = new Telerik.Reporting.TextBox();
            this.textBox31 = new Telerik.Reporting.TextBox();
            this.textBox33 = new Telerik.Reporting.TextBox();
            this.textBox38 = new Telerik.Reporting.TextBox();
            this.textBox40 = new Telerik.Reporting.TextBox();
            this.textBox41 = new Telerik.Reporting.TextBox();
            this.textBox42 = new Telerik.Reporting.TextBox();
            this.subReportFactorLang = new Telerik.Reporting.SubReport();
            this.positionFactor1Language1 = new HCMS.Reports.JobAnalysis.PositionFactor1Language();
            ((System.ComponentModel.ISupportInitialize)(this.jdDuties1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionOverallQualifications1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionCOEs1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pDExpressDataSetJobAnalysis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionFactor1Language1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // jdDuties1
            // 
            this.jdDuties1.Name = "JDDuties";
            // 
            // positionOverallQualifications1
            // 
            this.positionOverallQualifications1.Name = "PositionOverallQualifications";
            // 
            // positionCOEs1
            // 
            this.positionCOEs1.Name = "PositionCOEs";
            // 
            // pDExpressDataSetJobAnalysis
            // 
            this.pDExpressDataSetJobAnalysis.DataSetName = "PDExpressDataSetJobAnalysis";
            this.pDExpressDataSetJobAnalysis.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pdExpressDataSetJobAnalysisTableAdapter1
            // 
            this.pdExpressDataSetJobAnalysisTableAdapter1.ClearBeforeFill = true;
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
            this.currentTimeTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.0791666507720947D), Telerik.Reporting.Drawing.Unit.Inch(0.20000003278255463D));
            this.currentTimeTextBox.StyleName = "PageInfo";
            this.currentTimeTextBox.Value = "=NOW()";
            // 
            // pageInfoTextBox
            // 
            this.pageInfoTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.100078821182251D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.pageInfoTextBox.Name = "pageInfoTextBox";
            this.pageInfoTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.8999216556549072D), Telerik.Reporting.Drawing.Unit.Inch(0.20000003278255463D));
            this.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.pageInfoTextBox.StyleName = "PageInfo";
            this.pageInfoTextBox.Value = "=PageNumber";
            // 
            // reportHeader
            // 
            this.reportHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(8.27416706085205D);
            this.reportHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBox,
            this.pictureBoxLogo,
            this.table2});
            this.reportHeader.Name = "reportHeader";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(1.1999999284744263D));
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0000004768371582D), Telerik.Reporting.Drawing.Unit.Inch(0.38740167021751404D));
            this.titleTextBox.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(227)))), ((int)(((byte)(240)))));
            this.titleTextBox.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.titleTextBox.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.titleTextBox.Style.Color = System.Drawing.Color.Black;
            this.titleTextBox.Style.Font.Bold = true;
            this.titleTextBox.Style.Font.Name = "Arial";
            this.titleTextBox.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(20D);
            this.titleTextBox.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(0D);
            this.titleTextBox.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.titleTextBox.StyleName = "Title";
            this.titleTextBox.Value = "Job Analysis";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.MimeType = "image/png";
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0000004768371582D), Telerik.Reporting.Drawing.Unit.Inch(1.2000000476837158D));
            this.pictureBoxLogo.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(227)))), ((int)(((byte)(240)))));
            this.pictureBoxLogo.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pictureBoxLogo.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pictureBoxLogo.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.Solid;
            this.pictureBoxLogo.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.pictureBoxLogo.Style.BorderWidth.Right = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.pictureBoxLogo.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.pictureBoxLogo.Value = ((object)(resources.GetObject("pictureBoxLogo.Value")));
            // 
            // table2
            // 
            this.table2.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(2.4500002861022949D)));
            this.table2.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(4.5500001907348633D)));
            this.table2.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30000013113021851D)));
            this.table2.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30000028014183044D)));
            this.table2.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30000013113021851D)));
            this.table2.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30000013113021851D)));
            this.table2.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30000013113021851D)));
            this.table2.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30000013113021851D)));
            this.table2.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.29000017046928406D)));
            this.table2.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.29000017046928406D)));
            this.table2.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D)));
            this.table2.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30000004172325134D)));
            this.table2.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(1.0000002384185791D)));
            this.table2.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.29000014066696167D)));
            this.table2.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.29000014066696167D)));
            this.table2.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.29000017046928406D)));
            this.table2.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.29000017046928406D)));
            this.table2.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.29000017046928406D)));
            this.table2.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.29000017046928406D)));
            this.table2.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30000013113021851D)));
            this.table2.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30000013113021851D)));
            this.table2.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30000013113021851D)));
            this.table2.Body.SetCellContent(0, 0, this.textBoxPDNumberCaption);
            this.table2.Body.SetCellContent(4, 0, this.textBoxPayPlanCaption);
            this.table2.Body.SetCellContent(4, 1, this.textBoxPayPlanData);
            this.table2.Body.SetCellContent(0, 1, this.textBoxPDID);
            this.table2.Body.SetCellContent(1, 0, this.textBox1);
            this.table2.Body.SetCellContent(1, 1, this.textBox2);
            this.table2.Body.SetCellContent(6, 0, this.textBox3);
            this.table2.Body.SetCellContent(6, 1, this.textBox4);
            this.table2.Body.SetCellContent(7, 0, this.textBox5);
            this.table2.Body.SetCellContent(7, 1, this.textBox6);
            this.table2.Body.SetCellContent(11, 1, this.textBox8);
            this.table2.Body.SetCellContent(11, 0, this.textBoxSuperSignatureCaption);
            this.table2.Body.SetCellContent(12, 1, this.textBox10);
            this.table2.Body.SetCellContent(13, 1, this.textBox12);
            this.table2.Body.SetCellContent(14, 1, this.textBox14);
            this.table2.Body.SetCellContent(15, 1, this.textBox16);
            this.table2.Body.SetCellContent(12, 0, this.textBoxSuperTitleCaption);
            this.table2.Body.SetCellContent(13, 0, this.textBoxSuperSignedOnCaption);
            this.table2.Body.SetCellContent(14, 0, this.textBox70);
            this.table2.Body.SetCellContent(15, 0, this.textBox74);
            this.table2.Body.SetCellContent(16, 1, this.textBox18);
            this.table2.Body.SetCellContent(16, 0, this.textBox72);
            this.table2.Body.SetCellContent(2, 0, this.textBox19);
            this.table2.Body.SetCellContent(2, 1, this.textBox21);
            this.table2.Body.SetCellContent(3, 0, this.textBox24);
            this.table2.Body.SetCellContent(3, 1, this.textBox25);
            this.table2.Body.SetCellContent(5, 0, this.textBox28);
            this.table2.Body.SetCellContent(5, 1, this.textBox29);
            this.table2.Body.SetCellContent(17, 0, this.textBox30);
            this.table2.Body.SetCellContent(18, 0, this.textBox32);
            this.table2.Body.SetCellContent(19, 0, this.textBox34);
            this.table2.Body.SetCellContent(17, 1, this.textBox36);
            this.table2.Body.SetCellContent(18, 1, this.textBox45);
            this.table2.Body.SetCellContent(19, 1, this.textBox49);
            this.table2.Body.SetCellContent(8, 0, this.textBox37);
            this.table2.Body.SetCellContent(8, 1, this.ActivityLocationData);
            this.table2.Body.SetCellContent(9, 0, this.textBox39);
            this.table2.Body.SetCellContent(10, 0, this.textBox43);
            this.table2.Body.SetCellContent(9, 1, this.DutyLocationData);
            this.table2.Body.SetCellContent(10, 1, this.textBox44);
            this.table2.ColumnGroups.Add(tableGroup1);
            this.table2.ColumnGroups.Add(tableGroup2);
            this.table2.DataMember = "";
            this.table2.DataSource = this.pDExpressDataSetJobAnalysis;
            this.table2.Filters.AddRange(new Telerik.Reporting.Filter[] {
            new Telerik.Reporting.Filter("=Fields.PositionDescriptionID", Telerik.Reporting.FilterOperator.Equal, "=Parameters.PositionDescriptionID")});
            this.table2.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBoxPDNumberCaption,
            this.textBoxPayPlanCaption,
            this.textBoxPayPlanData,
            this.textBoxPDID,
            this.textBox1,
            this.textBox2,
            this.textBox3,
            this.textBox4,
            this.textBox5,
            this.textBox6,
            this.textBox8,
            this.textBoxSuperSignatureCaption,
            this.textBox10,
            this.textBox12,
            this.textBox14,
            this.textBox16,
            this.textBoxSuperTitleCaption,
            this.textBoxSuperSignedOnCaption,
            this.textBox70,
            this.textBox74,
            this.textBox18,
            this.textBox72,
            this.textBox19,
            this.textBox21,
            this.textBox24,
            this.textBox25,
            this.textBox28,
            this.textBox29,
            this.textBox30,
            this.textBox32,
            this.textBox34,
            this.textBox36,
            this.textBox45,
            this.textBox49,
            this.textBox37,
            this.ActivityLocationData,
            this.textBox39,
            this.textBox43,
            this.DutyLocationData,
            this.textBox44});
            this.table2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(1.6000000238418579D));
            this.table2.Name = "table2";
            tableGroup4.Name = "Group1";
            tableGroup5.Name = "Group6";
            tableGroup6.Name = "Group21";
            tableGroup7.Name = "Group22";
            tableGroup8.Name = "Group2";
            tableGroup9.Name = "Group4";
            tableGroup10.Name = "Group7";
            tableGroup11.Name = "Group8";
            tableGroup3.ChildGroups.Add(tableGroup4);
            tableGroup3.ChildGroups.Add(tableGroup5);
            tableGroup3.ChildGroups.Add(tableGroup6);
            tableGroup3.ChildGroups.Add(tableGroup7);
            tableGroup3.ChildGroups.Add(tableGroup8);
            tableGroup3.ChildGroups.Add(tableGroup9);
            tableGroup3.ChildGroups.Add(tableGroup10);
            tableGroup3.ChildGroups.Add(tableGroup11);
            tableGroup3.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping("")});
            tableGroup3.Name = "DetailGroup";
            tableGroup13.Name = "Group28";
            tableGroup12.ChildGroups.Add(tableGroup13);
            tableGroup12.Name = "Group27";
            tableGroup15.Name = "Group30";
            tableGroup14.ChildGroups.Add(tableGroup15);
            tableGroup14.Name = "Group29";
            tableGroup17.Name = "Group32";
            tableGroup16.ChildGroups.Add(tableGroup17);
            tableGroup16.Name = "Group31";
            tableGroup19.Name = "Group10";
            tableGroup18.ChildGroups.Add(tableGroup19);
            tableGroup18.Name = "Group9";
            tableGroup21.Name = "Group12";
            tableGroup20.ChildGroups.Add(tableGroup21);
            tableGroup20.Name = "Group11";
            tableGroup23.Name = "Group14";
            tableGroup22.ChildGroups.Add(tableGroup23);
            tableGroup22.Name = "Group13";
            tableGroup25.Name = "Group16";
            tableGroup24.ChildGroups.Add(tableGroup25);
            tableGroup24.Name = "Group15";
            tableGroup27.Name = "Group18";
            tableGroup26.ChildGroups.Add(tableGroup27);
            tableGroup26.Name = "Group17";
            tableGroup29.Name = "Group20";
            tableGroup28.ChildGroups.Add(tableGroup29);
            tableGroup28.Name = "Group19";
            tableGroup31.Name = "Group5";
            tableGroup30.ChildGroups.Add(tableGroup31);
            tableGroup30.Name = "Group3";
            tableGroup33.Name = "Group24";
            tableGroup32.ChildGroups.Add(tableGroup33);
            tableGroup32.Name = "Group23";
            tableGroup35.Name = "Group26";
            tableGroup34.ChildGroups.Add(tableGroup35);
            tableGroup34.Name = "Group25";
            this.table2.RowGroups.Add(tableGroup3);
            this.table2.RowGroups.Add(tableGroup12);
            this.table2.RowGroups.Add(tableGroup14);
            this.table2.RowGroups.Add(tableGroup16);
            this.table2.RowGroups.Add(tableGroup18);
            this.table2.RowGroups.Add(tableGroup20);
            this.table2.RowGroups.Add(tableGroup22);
            this.table2.RowGroups.Add(tableGroup24);
            this.table2.RowGroups.Add(tableGroup26);
            this.table2.RowGroups.Add(tableGroup28);
            this.table2.RowGroups.Add(tableGroup30);
            this.table2.RowGroups.Add(tableGroup32);
            this.table2.RowGroups.Add(tableGroup34);
            this.table2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0000004768371582D), Telerik.Reporting.Drawing.Unit.Inch(6.6200008392333984D));
            // 
            // textBoxPDNumberCaption
            // 
            this.textBoxPDNumberCaption.Name = "textBoxPDNumberCaption";
            this.textBoxPDNumberCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4500002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.textBoxPDNumberCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxPDNumberCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxPDNumberCaption.Style.Font.Bold = true;
            this.textBoxPDNumberCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxPDNumberCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxPDNumberCaption.Value = "PD No.:";
            // 
            // textBoxPayPlanCaption
            // 
            this.textBoxPayPlanCaption.Name = "textBoxPayPlanCaption";
            this.textBoxPayPlanCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4500002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.textBoxPayPlanCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxPayPlanCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxPayPlanCaption.Style.Font.Bold = true;
            this.textBoxPayPlanCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxPayPlanCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxPayPlanCaption.Value = "Pay Plan, Series & Grade:";
            // 
            // textBoxPayPlanData
            // 
            this.textBoxPayPlanData.Name = "textBoxPayPlanData";
            this.textBoxPayPlanData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5500001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.textBoxPayPlanData.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxPayPlanData.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxPayPlanData.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxPayPlanData.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxPayPlanData.Value = "= Fields.PayPlanAbbrev + \'-\' + Substr(Format(\'0000{0}\', Fields.JobSeries), Len(Fo" +
    "rmat(\'0000{0}\', Fields.JobSeries))-4, 4) + \' : \' + Fields.SeriesName + \'-\' + Fie" +
    "lds.ProposedGrade";
            // 
            // textBoxPDID
            // 
            this.textBoxPDID.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3D), Telerik.Reporting.Drawing.Unit.Inch(0.11244058609008789D));
            this.textBoxPDID.Name = "textBoxPDID";
            this.textBoxPDID.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5500001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.textBoxPDID.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxPDID.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxPDID.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxPDID.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxPDID.Value = "=Fields.PositionDescriptionID";
            // 
            // textBox1
            // 
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4500002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.30000013113021851D));
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
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5500001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.30000013113021851D));
            this.textBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox2.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox2.Value = "= Fields.FPPSPDID";
            // 
            // textBox3
            // 
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4500002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.29000002145767212D));
            this.textBox3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox3.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox3.Style.Font.Bold = true;
            this.textBox3.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox3.Value = "Is Interdisciplinary PD?";
            // 
            // textBox4
            // 
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5500001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.29000002145767212D));
            this.textBox4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox4.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox4.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox4.Value = "=iif(Fields.IsInterdisciplinaryPD,\"YES\",\"NO\")";
            // 
            // textBox5
            // 
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4500002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.29000002145767212D));
            this.textBox5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox5.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox5.Style.Font.Bold = true;
            this.textBox5.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox5.Value = "Additional Series:";
            // 
            // textBox6
            // 
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5500001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.29000002145767212D));
            this.textBox6.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox6.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox6.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox6.Value = "=Fields.AdditionalSeries";
            // 
            // textBox8
            // 
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5500001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.28999999165534973D));
            this.textBox8.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox8.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox8.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox8.Value = "= Fields.SupervisorFullName";
            // 
            // textBoxSuperSignatureCaption
            // 
            this.textBoxSuperSignatureCaption.Name = "textBoxSuperSignatureCaption";
            this.textBoxSuperSignatureCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4500002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.28999999165534973D));
            this.textBoxSuperSignatureCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxSuperSignatureCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxSuperSignatureCaption.Style.Font.Bold = true;
            this.textBoxSuperSignatureCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxSuperSignatureCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxSuperSignatureCaption.Value = "Supervisor Signature:";
            // 
            // textBox10
            // 
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5500001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.28999999165534973D));
            this.textBox10.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox10.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox10.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox10.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox10.Value = "= Fields.SupervisorOrgTitle";
            // 
            // textBox12
            // 
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5500001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.29000002145767212D));
            this.textBox12.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox12.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox12.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox12.Value = "= Fields.SupervisorSignDate";
            // 
            // textBox14
            // 
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5500001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.29000002145767212D));
            this.textBox14.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox14.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox14.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox14.Value = "= Fields.AdditionalSupervisorFullName";
            // 
            // textBox16
            // 
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5500001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.29000002145767212D));
            this.textBox16.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox16.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox16.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox16.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox16.Value = "= Fields.AdditionalSupOrgTitle";
            // 
            // textBoxSuperTitleCaption
            // 
            this.textBoxSuperTitleCaption.Name = "textBoxSuperTitleCaption";
            this.textBoxSuperTitleCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4500002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.28999999165534973D));
            this.textBoxSuperTitleCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxSuperTitleCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxSuperTitleCaption.Style.Font.Bold = true;
            this.textBoxSuperTitleCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxSuperTitleCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxSuperTitleCaption.Value = "Supervisor Title:";
            // 
            // textBoxSuperSignedOnCaption
            // 
            this.textBoxSuperSignedOnCaption.Name = "textBoxSuperSignedOnCaption";
            this.textBoxSuperSignedOnCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4500002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.29000002145767212D));
            this.textBoxSuperSignedOnCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxSuperSignedOnCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxSuperSignedOnCaption.Style.Font.Bold = true;
            this.textBoxSuperSignedOnCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxSuperSignedOnCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxSuperSignedOnCaption.Value = "Supervisor Sign Date:";
            // 
            // textBox70
            // 
            this.textBox70.Name = "textBox70";
            this.textBox70.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4500002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.29000002145767212D));
            this.textBox70.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox70.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox70.Style.Font.Bold = true;
            this.textBox70.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox70.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox70.Value = "Approving Official Signature:";
            // 
            // textBox74
            // 
            this.textBox74.Name = "textBox74";
            this.textBox74.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4500002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.29000002145767212D));
            this.textBox74.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox74.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox74.Style.Font.Bold = true;
            this.textBox74.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox74.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox74.Value = "Approving Official Title:";
            // 
            // textBox18
            // 
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5500001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.29000002145767212D));
            this.textBox18.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox18.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox18.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox18.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox18.Value = "= Fields.AdditionalSupervisorSignDate";
            // 
            // textBox72
            // 
            this.textBox72.Name = "textBox72";
            this.textBox72.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4500002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.29000002145767212D));
            this.textBox72.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox72.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox72.Style.Font.Bold = true;
            this.textBox72.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox72.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox72.Value = "Approving Official Sign Date:";
            // 
            // textBox19
            // 
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4500002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D));
            this.textBox19.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox19.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox19.Style.Font.Bold = true;
            this.textBox19.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox19.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox19.Value = "FWS Title:";
            // 
            // textBox21
            // 
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5500001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D));
            this.textBox21.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox21.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox21.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox21.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox21.Value = "=Fields.AgencyPositionTitle";
            // 
            // textBox24
            // 
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4500002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.textBox24.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox24.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox24.Style.Font.Bold = true;
            this.textBox24.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox24.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox24.Value = "OPM Title:";
            // 
            // textBox25
            // 
            this.textBox25.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3D), Telerik.Reporting.Drawing.Unit.Inch(1.0124406814575195D));
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5500001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.textBox25.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox25.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox25.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox25.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox25.Value = "=Fields.OPMJobTitle";
            // 
            // textBox28
            // 
            this.textBox28.Name = "textBox28";
            this.textBox28.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4500002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D));
            this.textBox28.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox28.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox28.Style.Font.Bold = true;
            this.textBox28.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox28.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox28.Value = "Full Performance Level:";
            // 
            // textBox29
            // 
            this.textBox29.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3D), Telerik.Reporting.Drawing.Unit.Inch(0.71244078874588013D));
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5500001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D));
            this.textBox29.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox29.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox29.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox29.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox29.Value = "=Fields.ProposedFPGrade";
            // 
            // textBox30
            // 
            this.textBox30.Name = "textBox30";
            this.textBox30.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4500002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.textBox30.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox30.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox30.Style.Font.Bold = true;
            this.textBox30.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox30.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox30.Value = "Classifier Signature:";
            // 
            // textBox32
            // 
            this.textBox32.Name = "textBox32";
            this.textBox32.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4500002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D));
            this.textBox32.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox32.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox32.Style.Font.Bold = true;
            this.textBox32.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox32.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox32.Value = "Classifier Title:";
            // 
            // textBox34
            // 
            this.textBox34.Name = "textBox34";
            this.textBox34.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4500002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.textBox34.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox34.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox34.Style.Font.Bold = true;
            this.textBox34.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox34.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox34.Value = "Classifier Sign Date:";
            // 
            // textBox36
            // 
            this.textBox36.Name = "textBox36";
            this.textBox36.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5500001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.textBox36.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox36.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox36.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox36.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox36.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox36.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox36.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox36.Value = "=Fields.ClassifierFullName";
            // 
            // textBox45
            // 
            this.textBox45.Name = "textBox45";
            this.textBox45.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5500001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D));
            this.textBox45.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox45.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox45.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox45.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox45.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox45.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox45.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox45.Value = "=Fields.ClassifierOrgTitle";
            // 
            // textBox49
            // 
            this.textBox49.Name = "textBox49";
            this.textBox49.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5500001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.textBox49.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox49.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox49.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox49.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox49.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox49.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox49.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox49.Value = "=Fields.ClassifierSignDate";
            // 
            // textBox37
            // 
            this.textBox37.Name = "textBox37";
            this.textBox37.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4500002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.textBox37.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox37.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox37.Style.Font.Bold = true;
            this.textBox37.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox37.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox37.Value = "Employing Office Location:";
            // 
            // ActivityLocationData
            // 
            this.ActivityLocationData.Name = "ActivityLocationData";
            this.ActivityLocationData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5500001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.ActivityLocationData.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.ActivityLocationData.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.ActivityLocationData.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.ActivityLocationData.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.ActivityLocationData.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.ActivityLocationData.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.ActivityLocationData.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.ActivityLocationData.Value = "=Fields.EmployingOfficeLocation";
            // 
            // textBox39
            // 
            this.textBox39.Name = "textBox39";
            this.textBox39.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4500002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.textBox39.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox39.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox39.Style.Font.Bold = true;
            this.textBox39.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox39.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox39.Value = "Duty Location:";
            // 
            // textBox43
            // 
            this.textBox43.Name = "textBox43";
            this.textBox43.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4500002861022949D), Telerik.Reporting.Drawing.Unit.Inch(1D));
            this.textBox43.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox43.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox43.Style.Font.Bold = true;
            this.textBox43.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox43.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox43.Value = "Organization Structure:";
            // 
            // DutyLocationData
            // 
            this.DutyLocationData.Name = "DutyLocationData";
            this.DutyLocationData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5500001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.DutyLocationData.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.DutyLocationData.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.DutyLocationData.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.DutyLocationData.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.DutyLocationData.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.DutyLocationData.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.DutyLocationData.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.DutyLocationData.Value = "=Fields.DutyLocation";
            // 
            // textBox44
            // 
            this.textBox44.Name = "textBox44";
            this.textBox44.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5500001907348633D), Telerik.Reporting.Drawing.Unit.Inch(1D));
            this.textBox44.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox44.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox44.Style.Padding.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox44.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox44.Style.Padding.Right = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox44.Style.Padding.Top = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox44.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox44.Value = resources.GetString("textBox44.Value");
            // 
            // textBox35
            // 
            this.textBox35.Name = "textBox35";
            this.textBox35.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5500001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.textBox35.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox35.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox35.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox35.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBoxFWSTitleData
            // 
            this.textBoxFWSTitleData.Name = "textBoxFWSTitleData";
            this.textBoxFWSTitleData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.0373954772949219D), Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D));
            // 
            // textBoxFPGradeData
            // 
            this.textBoxFPGradeData.Name = "textBoxFPGradeData";
            this.textBoxFPGradeData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.0373954772949219D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            // 
            // textBoxOPMTitleData
            // 
            this.textBoxOPMTitleData.Name = "textBoxOPMTitleData";
            this.textBoxOPMTitleData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.0373954772949219D), Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D));
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(1.3258329629898071D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.subReport3,
            this.subReport2,
            this.subReportCOEs,
            this.subReportFactorLang});
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            // 
            // subReport3
            // 
            this.subReport3.KeepTogether = false;
            this.subReport3.Name = "subReport3";
            instanceReportSource1.Parameters.Add(new Telerik.Reporting.Parameter("DutiesPDID", "=Fields.PositionDescriptionID"));
            instanceReportSource1.ReportDocument = this.jdDuties1;
            this.subReport3.ReportSource = instanceReportSource1;
            this.subReport3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0000004768371582D), Telerik.Reporting.Drawing.Unit.Inch(0.29992067813873291D));
            this.subReport3.ItemDataBound += new System.EventHandler(this.subReport3_ItemDataBound);
            // 
            // subReport2
            // 
            this.subReport2.KeepTogether = false;
            this.subReport2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.60007792711257935D));
            this.subReport2.Name = "subReport2";
            instanceReportSource2.Parameters.Add(new Telerik.Reporting.Parameter("PDID", "=Parameters.PositionDescriptionID.Value"));
            instanceReportSource2.ReportDocument = this.positionOverallQualifications1;
            this.subReport2.ReportSource = instanceReportSource2;
            this.subReport2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0000004768371582D), Telerik.Reporting.Drawing.Unit.Inch(0.32583364844322205D));
            this.subReport2.ItemDataBound += new System.EventHandler(this.subReport2_ItemDataBound);
            // 
            // subReportCOEs
            // 
            this.subReportCOEs.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.29999923706054688D));
            this.subReportCOEs.Name = "subReportCOEs";
            instanceReportSource3.Parameters.Add(new Telerik.Reporting.Parameter("PDID", "=Parameters.PositionDescriptionID.Value"));
            instanceReportSource3.ReportDocument = this.positionCOEs1;
            this.subReportCOEs.ReportSource = instanceReportSource3;
            this.subReportCOEs.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0000009536743164D), Telerik.Reporting.Drawing.Unit.Inch(0.299999862909317D));
            this.subReportCOEs.ItemDataBound += new System.EventHandler(this.subReportCOEs_ItemDataBound);
            // 
            // textBoxPDNumberData
            // 
            this.textBoxPDNumberData.Name = "textBoxPDNumberData";
            this.textBoxPDNumberData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.0373954772949219D), Telerik.Reporting.Drawing.Unit.Inch(0.29999995231628418D));
            // 
            // textBox7
            // 
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.1000001430511475D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.textBox7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox7.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox7.Style.Font.Bold = true;
            this.textBox7.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox64
            // 
            this.textBox64.Name = "textBox64";
            this.textBox64.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.1000001430511475D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.textBox64.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox64.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox64.Style.Font.Bold = true;
            this.textBox64.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox64.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox64.Value = "Supervisor Certification Text:";
            // 
            // textBox9
            // 
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.1000001430511475D), Telerik.Reporting.Drawing.Unit.Inch(0.28999999165534973D));
            this.textBox9.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox9.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox9.Style.Font.Bold = true;
            this.textBox9.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox11
            // 
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.1000001430511475D), Telerik.Reporting.Drawing.Unit.Inch(0.28999999165534973D));
            this.textBox11.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox11.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox11.Style.Font.Bold = true;
            this.textBox11.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox11.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox13
            // 
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.1000001430511475D), Telerik.Reporting.Drawing.Unit.Inch(0.29000002145767212D));
            this.textBox13.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox13.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox13.Style.Font.Bold = true;
            this.textBox13.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox15
            // 
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.1000001430511475D), Telerik.Reporting.Drawing.Unit.Inch(0.28999999165534973D));
            this.textBox15.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox15.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox15.Style.Font.Bold = true;
            this.textBox15.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox15.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox17
            // 
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.1000001430511475D), Telerik.Reporting.Drawing.Unit.Inch(0.28999999165534973D));
            this.textBox17.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox17.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox17.Style.Font.Bold = true;
            this.textBox17.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox17.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox20
            // 
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5500001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.textBox20.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox20.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox20.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox20.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox22
            // 
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4500002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.textBox22.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox22.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox22.Style.Font.Bold = true;
            this.textBox22.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox22.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox23
            // 
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5500001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.textBox23.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox23.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox23.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox23.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox26
            // 
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4500002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.textBox26.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox26.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox26.Style.Font.Bold = true;
            this.textBox26.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox26.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox27
            // 
            this.textBox27.Name = "textBox27";
            this.textBox27.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5500001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.textBox27.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox27.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox27.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox27.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox31
            // 
            this.textBox31.Name = "textBox31";
            this.textBox31.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5500001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.textBox31.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox31.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox31.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox31.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox33
            // 
            this.textBox33.Name = "textBox33";
            this.textBox33.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5500001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.textBox33.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox33.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox33.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox33.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox38
            // 
            this.textBox38.Name = "textBox38";
            this.textBox38.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5500001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.textBox38.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox38.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox38.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox38.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox40
            // 
            this.textBox40.Name = "textBox40";
            this.textBox40.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5500001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.textBox40.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox40.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox40.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox40.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox41
            // 
            this.textBox41.Name = "textBox41";
            this.textBox41.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4500002861022949D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.textBox41.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox41.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox41.Style.Font.Bold = true;
            this.textBox41.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox41.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // textBox42
            // 
            this.textBox42.Name = "textBox42";
            this.textBox42.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5500001907348633D), Telerik.Reporting.Drawing.Unit.Inch(0.60000002384185791D));
            this.textBox42.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox42.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox42.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox42.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            // 
            // subReportFactorLang
            // 
            this.subReportFactorLang.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.92583274841308594D));
            this.subReportFactorLang.Name = "subReportFactorLang";
            instanceReportSource4.Parameters.Add(new Telerik.Reporting.Parameter("PDID", "=Parameters.PositionDescriptionID.Value"));
            instanceReportSource4.ReportDocument = this.positionFactor1Language1;
            this.subReportFactorLang.ReportSource = instanceReportSource4;
            this.subReportFactorLang.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.9999613761901855D), Telerik.Reporting.Drawing.Unit.Inch(0.30000051856040955D));
            this.subReportFactorLang.ItemDataBound += new System.EventHandler(this.subReportFactorLang_ItemDataBound);
            // 
            // positionFactor1Language1
            // 
            this.positionFactor1Language1.Name = "PositionFactor1Language";
            // 
            // JobAnalysis
            // 
            this.DataSource = this.pDExpressDataSetJobAnalysis;
            this.Filters.AddRange(new Telerik.Reporting.Filter[] {
            new Telerik.Reporting.Filter("=Fields.PositionDescriptionID", Telerik.Reporting.FilterOperator.Equal, "=Parameters.PositionDescriptionID")});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageFooter,
            this.reportHeader,
            this.detail});
            this.Name = "JobAnalysis";
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Left = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Right = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.Margins.Top = Telerik.Reporting.Drawing.Unit.Inch(0.5D);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "PositionDescriptionID";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Integer;
            reportParameter1.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
            styleRule1.Style.BackgroundColor = System.Drawing.Color.Empty;
            styleRule1.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(112)))));
            styleRule1.Style.Font.Name = "Tahoma";
            styleRule1.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(18D);
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
            styleRule2.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(58)))), ((int)(((byte)(112)))));
            styleRule2.Style.Color = System.Drawing.Color.White;
            styleRule2.Style.Font.Bold = true;
            styleRule2.Style.Font.Italic = false;
            styleRule2.Style.Font.Name = "Tahoma";
            styleRule2.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(11D);
            styleRule2.Style.Font.Strikeout = false;
            styleRule2.Style.Font.Underline = false;
            styleRule2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
            styleRule3.Style.Color = System.Drawing.Color.Black;
            styleRule3.Style.Font.Name = "Tahoma";
            styleRule3.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(10D);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("PageInfo")});
            styleRule4.Style.Color = System.Drawing.Color.Black;
            styleRule4.Style.Font.Name = "Tahoma";
            styleRule4.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(8D);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4});
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(7.0000004768371582D);
            ((System.ComponentModel.ISupportInitialize)(this.jdDuties1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionOverallQualifications1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionCOEs1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pDExpressDataSetJobAnalysis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.positionFactor1Language1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private PageFooterSection pageFooter;
        private Telerik.Reporting.TextBox currentTimeTextBox;
        private Telerik.Reporting.TextBox pageInfoTextBox;
        private DetailSection detail;
        private PDExpressDataSetJobAnalysis pDExpressDataSetJobAnalysis;
        private HCMS.Reports.PDExpressDataSetJobAnalysisTableAdapters.PDExpressDataSetJobAnalysisTableAdapter pdExpressDataSetJobAnalysisTableAdapter1;
        private ReportHeaderSection reportHeader;
        private Telerik.Reporting.TextBox titleTextBox;
        private Telerik.Reporting.PictureBox pictureBoxLogo;
        private SubReport subReport2;
        private Table table2;
        private Telerik.Reporting.TextBox textBoxPDNumberCaption;
        private Telerik.Reporting.TextBox textBoxPDNumberData;
        private Telerik.Reporting.TextBox textBoxPayPlanCaption;
        private Telerik.Reporting.TextBox textBoxPayPlanData;
        private Telerik.Reporting.TextBox textBoxFPGradeData;
        private Telerik.Reporting.TextBox textBoxOPMTitleData;
        private Telerik.Reporting.TextBox textBoxFWSTitleData;
        private Telerik.Reporting.TextBox textBoxPDID;
        private SubReport subReport3;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private HCMS.Reports.JobAnalysis.JDDuties jdDuties1;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBox64;
        private Telerik.Reporting.TextBox textBoxSuperSignatureCaption;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.TextBox textBox15;
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.TextBox textBoxSuperTitleCaption;
        private Telerik.Reporting.TextBox textBoxSuperSignedOnCaption;
        private Telerik.Reporting.TextBox textBox70;
        private Telerik.Reporting.TextBox textBox74;
        private Telerik.Reporting.TextBox textBox17;
        private Telerik.Reporting.TextBox textBox18;
        private Telerik.Reporting.TextBox textBox72;
        private Telerik.Reporting.TextBox textBox19;
        private Telerik.Reporting.TextBox textBox21;
        private Telerik.Reporting.TextBox textBox24;
        private Telerik.Reporting.TextBox textBox25;
        private Telerik.Reporting.TextBox textBox28;
        private Telerik.Reporting.TextBox textBox29;
        private Telerik.Reporting.TextBox textBox20;
        private Telerik.Reporting.TextBox textBox22;
        private Telerik.Reporting.TextBox textBox23;
        private Telerik.Reporting.TextBox textBox26;
        private Telerik.Reporting.TextBox textBox27;
        private Telerik.Reporting.TextBox textBox30;
        private Telerik.Reporting.TextBox textBox31;
        private Telerik.Reporting.TextBox textBox32;
        private Telerik.Reporting.TextBox textBox33;
        private Telerik.Reporting.TextBox textBox34;
        private Telerik.Reporting.TextBox textBox35;
        private Telerik.Reporting.TextBox textBox36;
        private Telerik.Reporting.TextBox textBox45;
        private Telerik.Reporting.TextBox textBox49;
        private Telerik.Reporting.TextBox textBox37;
        private Telerik.Reporting.TextBox textBox38;
        private Telerik.Reporting.TextBox ActivityLocationData;
        private Telerik.Reporting.TextBox textBox39;
        private Telerik.Reporting.TextBox textBox40;
        private Telerik.Reporting.TextBox textBox42;
        private Telerik.Reporting.TextBox textBox43;
        private Telerik.Reporting.TextBox textBox41;
        private Telerik.Reporting.TextBox DutyLocationData;
        private Telerik.Reporting.TextBox textBox44;
        private SubReport subReportCOEs;
        private PositionDescription.PositionCOEs positionCOEs1;
        private PositionDescription.PositionOverallQualifications positionOverallQualifications1;
        private SubReport subReportFactorLang;
        private PositionFactor1Language positionFactor1Language1;

    }
}