namespace HCMS.Reports.PositionDescription
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    partial class SODPDDocument
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SODPDDocument));
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
            Telerik.Reporting.Drawing.FormattingRule formattingRule1 = new Telerik.Reporting.Drawing.FormattingRule();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            this.pageFooter = new Telerik.Reporting.PageFooterSection();
            this.currentTimeTextBox = new Telerik.Reporting.TextBox();
            this.pageInfoTextBox = new Telerik.Reporting.TextBox();
            this.reportHeader = new Telerik.Reporting.ReportHeaderSection();
            this.pictureBox1 = new Telerik.Reporting.PictureBox();
            this.textBoxPDHeader = new Telerik.Reporting.TextBox();
            this.tablePDDetails = new Telerik.Reporting.Table();
            this.textBoxPDNoCaption = new Telerik.Reporting.TextBox();
            this.textBoxPDNoData = new Telerik.Reporting.TextBox();
            this.textBoxPayPlanCaption = new Telerik.Reporting.TextBox();
            this.textBoxPayPlanData = new Telerik.Reporting.TextBox();
            this.textBoxDutyLocationCaption = new Telerik.Reporting.TextBox();
            this.textBoxCertifiedByCaption = new Telerik.Reporting.TextBox();
            this.textBoxClassifiedByCaption = new Telerik.Reporting.TextBox();
            this.textBoxDutyLocationData = new Telerik.Reporting.TextBox();
            this.textBoxClassifiedByData = new Telerik.Reporting.TextBox();
            this.textBoxCertifiedByData = new Telerik.Reporting.TextBox();
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
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.textBoxEmpOffLocationCaption = new Telerik.Reporting.TextBox();
            this.textBoxEmpOffLocation = new Telerik.Reporting.TextBox();
            this.textBoxIsInterDiscCaption = new Telerik.Reporting.TextBox();
            this.textBoxIsInterDisc = new Telerik.Reporting.TextBox();
            this.textBoxAdditionalSeriesCaption = new Telerik.Reporting.TextBox();
            this.textBoxAdditionalSeries = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.pDExpressDataSet = new HCMS.Reports.PDExpressDataSet();
            this.detail = new Telerik.Reporting.DetailSection();
            this.textBoxIntroductionCaption = new Telerik.Reporting.TextBox();
            this.introductionDataTextBox = new Telerik.Reporting.TextBox();
            this.htmlTextBoxSODPara1 = new Telerik.Reporting.HtmlTextBox();
            this.pdExpressDataSetTableAdapter1 = new HCMS.Reports.PDExpressDataSetTableAdapters.PDExpressDataSetTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.pDExpressDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pageFooter
            // 
            this.pageFooter.Height = Telerik.Reporting.Drawing.Unit.Inch(0.28125D);
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
            this.currentTimeTextBox.StyleName = "PageInfo";
            this.currentTimeTextBox.Value = "=NOW()";
            // 
            // pageInfoTextBox
            // 
            this.pageInfoTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.8020839691162109D), Telerik.Reporting.Drawing.Unit.Inch(0D));
            this.pageInfoTextBox.Name = "pageInfoTextBox";
            this.pageInfoTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(3.1979167461395264D), Telerik.Reporting.Drawing.Unit.Inch(0.20000003278255463D));
            this.pageInfoTextBox.Style.TextAlign = Telerik.Reporting.Drawing.HorizontalAlign.Right;
            this.pageInfoTextBox.StyleName = "PageInfo";
            this.pageInfoTextBox.Value = "=PageNumber";
            // 
            // reportHeader
            // 
            this.reportHeader.Height = Telerik.Reporting.Drawing.Unit.Inch(8.40000057220459D);
            this.reportHeader.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pictureBox1,
            this.textBoxPDHeader,
            this.tablePDDetails});
            this.reportHeader.Name = "reportHeader";
            // 
            // pictureBox1
            // 
            this.pictureBox1.MimeType = "image/png";
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0000004768371582D), Telerik.Reporting.Drawing.Unit.Inch(1.1999212503433228D));
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
            this.textBoxPDHeader.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0000004768371582D), Telerik.Reporting.Drawing.Unit.Inch(0.38734602928161621D));
            this.textBoxPDHeader.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(227)))), ((int)(((byte)(240)))));
            this.textBoxPDHeader.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxPDHeader.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxPDHeader.Style.Font.Bold = true;
            this.textBoxPDHeader.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(16D);
            this.textBoxPDHeader.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxPDHeader.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxPDHeader.Value = "= \'Statement of Difference for PD No. \' + Fields.AssociatedFullPD1";
            // 
            // tablePDDetails
            // 
            this.tablePDDetails.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(2.4171538352966309D)));
            this.tablePDDetails.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(4.5828471183776855D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.2916664183139801D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.24583332240581513D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.28749951720237732D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.29000005125999451D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.29000005125999451D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.34000003337860107D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.37083333730697632D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.93333417177200317D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.33958309888839722D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.297916978597641D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.2979167103767395D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.297916978597641D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.339583158493042D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.34999999403953552D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.27708372473716736D)));
            this.tablePDDetails.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(0.30833336710929871D)));
            this.tablePDDetails.Body.SetCellContent(0, 0, this.textBoxPDNoCaption);
            this.tablePDDetails.Body.SetCellContent(0, 1, this.textBoxPDNoData);
            this.tablePDDetails.Body.SetCellContent(4, 0, this.textBoxPayPlanCaption);
            this.tablePDDetails.Body.SetCellContent(4, 1, this.textBoxPayPlanData);
            this.tablePDDetails.Body.SetCellContent(9, 0, this.textBoxDutyLocationCaption);
            this.tablePDDetails.Body.SetCellContent(11, 0, this.textBoxCertifiedByCaption);
            this.tablePDDetails.Body.SetCellContent(17, 0, this.textBoxClassifiedByCaption);
            this.tablePDDetails.Body.SetCellContent(9, 1, this.textBoxDutyLocationData);
            this.tablePDDetails.Body.SetCellContent(17, 1, this.textBoxClassifiedByData);
            this.tablePDDetails.Body.SetCellContent(11, 1, this.textBoxCertifiedByData);
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
            this.tablePDDetails.Body.SetCellContent(10, 0, this.textBox1);
            this.tablePDDetails.Body.SetCellContent(10, 1, this.textBox2);
            this.tablePDDetails.Body.SetCellContent(14, 0, this.textBox3);
            this.tablePDDetails.Body.SetCellContent(14, 1, this.textBox4);
            this.tablePDDetails.Body.SetCellContent(16, 0, this.textBox5);
            this.tablePDDetails.Body.SetCellContent(16, 1, this.textBox6);
            this.tablePDDetails.Body.SetCellContent(15, 0, this.textBox7);
            this.tablePDDetails.Body.SetCellContent(15, 1, this.textBox8);
            this.tablePDDetails.Body.SetCellContent(8, 0, this.textBoxEmpOffLocationCaption);
            this.tablePDDetails.Body.SetCellContent(8, 1, this.textBoxEmpOffLocation);
            this.tablePDDetails.Body.SetCellContent(6, 0, this.textBoxIsInterDiscCaption);
            this.tablePDDetails.Body.SetCellContent(6, 1, this.textBoxIsInterDisc);
            this.tablePDDetails.Body.SetCellContent(7, 0, this.textBoxAdditionalSeriesCaption);
            this.tablePDDetails.Body.SetCellContent(7, 1, this.textBoxAdditionalSeries);
            this.tablePDDetails.Body.SetCellContent(2, 0, this.textBox9);
            this.tablePDDetails.Body.SetCellContent(2, 1, this.textBox10);
            this.tablePDDetails.Body.SetCellContent(3, 0, this.textBox11);
            this.tablePDDetails.Body.SetCellContent(3, 1, this.textBox12);
            this.tablePDDetails.Body.SetCellContent(5, 0, this.textBox13);
            this.tablePDDetails.Body.SetCellContent(5, 1, this.textBox14);
            this.tablePDDetails.ColumnGroups.Add(tableGroup1);
            this.tablePDDetails.ColumnGroups.Add(tableGroup2);
            this.tablePDDetails.DataMember = "";
            this.tablePDDetails.DataSource = this.pDExpressDataSet;
            this.tablePDDetails.Filters.AddRange(new Telerik.Reporting.Filter[] {
            new Telerik.Reporting.Filter("=Fields.PositionDescriptionID", Telerik.Reporting.FilterOperator.Equal, "=Parameters.PositionDescriptionID")});
            this.tablePDDetails.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBoxPDNoCaption,
            this.textBoxPDNoData,
            this.textBoxPayPlanCaption,
            this.textBoxPayPlanData,
            this.textBoxDutyLocationCaption,
            this.textBoxCertifiedByCaption,
            this.textBoxClassifiedByCaption,
            this.textBoxDutyLocationData,
            this.textBoxClassifiedByData,
            this.textBoxCertifiedByData,
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
            this.textBox3,
            this.textBox4,
            this.textBox5,
            this.textBox6,
            this.textBox7,
            this.textBox8,
            this.textBoxEmpOffLocationCaption,
            this.textBoxEmpOffLocation,
            this.textBoxIsInterDiscCaption,
            this.textBoxIsInterDisc,
            this.textBoxAdditionalSeriesCaption,
            this.textBoxAdditionalSeries,
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.textBox12,
            this.textBox13,
            this.textBox14});
            this.tablePDDetails.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(1.6000000238418579D));
            this.tablePDDetails.Name = "tablePDDetails";
            tableGroup4.Name = "Group1";
            tableGroup5.Name = "Group10";
            tableGroup6.Name = "Group21";
            tableGroup7.Name = "Group5";
            tableGroup8.Name = "Group2";
            tableGroup9.Name = "Group22";
            tableGroup10.Name = "Group19";
            tableGroup11.Name = "Group20";
            tableGroup12.Name = "Group18";
            tableGroup13.Name = "Group6";
            tableGroup14.Name = "Group7";
            tableGroup15.Name = "Group8";
            tableGroup16.Name = "Group14";
            tableGroup17.Name = "Group11";
            tableGroup18.Name = "Group15";
            tableGroup19.Name = "Group17";
            tableGroup20.Name = "Group16";
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
            this.tablePDDetails.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0000009536743164D), Telerik.Reporting.Drawing.Unit.Inch(6.7575006484985352D));
            // 
            // textBoxPDNoCaption
            // 
            this.textBoxPDNoCaption.Name = "textBoxPDNoCaption";
            this.textBoxPDNoCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4171538352966309D), Telerik.Reporting.Drawing.Unit.Inch(0.29166632890701294D));
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
            this.textBoxPDNoData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5828466415405273D), Telerik.Reporting.Drawing.Unit.Inch(0.29166632890701294D));
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
            this.textBoxPayPlanCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4171538352966309D), Telerik.Reporting.Drawing.Unit.Inch(0.28749942779541016D));
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
            this.textBoxPayPlanCaption.Value = "Pay Plan, Series & Grade:";
            // 
            // textBoxPayPlanData
            // 
            this.textBoxPayPlanData.Name = "textBoxPayPlanData";
            this.textBoxPayPlanData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5828466415405273D), Telerik.Reporting.Drawing.Unit.Inch(0.28749942779541016D));
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
            // textBoxDutyLocationCaption
            // 
            this.textBoxDutyLocationCaption.Name = "textBoxDutyLocationCaption";
            this.textBoxDutyLocationCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4171538352966309D), Telerik.Reporting.Drawing.Unit.Inch(0.37083309888839722D));
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
            this.textBoxCertifiedByCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4171538352966309D), Telerik.Reporting.Drawing.Unit.Inch(0.33958297967910767D));
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
            this.textBoxClassifiedByCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4171538352966309D), Telerik.Reporting.Drawing.Unit.Inch(0.3499998152256012D));
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
            // textBoxDutyLocationData
            // 
            this.textBoxDutyLocationData.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.3791666030883789D), Telerik.Reporting.Drawing.Unit.Inch(1.6999212503433228D));
            this.textBoxDutyLocationData.Name = "textBoxDutyLocationData";
            this.textBoxDutyLocationData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5828466415405273D), Telerik.Reporting.Drawing.Unit.Inch(0.37083309888839722D));
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
            this.textBoxClassifiedByData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5828466415405273D), Telerik.Reporting.Drawing.Unit.Inch(0.3499998152256012D));
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
            this.textBoxCertifiedByData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5828466415405273D), Telerik.Reporting.Drawing.Unit.Inch(0.33958297967910767D));
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
            // textBoxFPPSIDCaption
            // 
            this.textBoxFPPSIDCaption.Name = "textBoxFPPSIDCaption";
            this.textBoxFPPSIDCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4171538352966309D), Telerik.Reporting.Drawing.Unit.Inch(0.24583321809768677D));
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
            this.textBoxFPPSData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5828466415405273D), Telerik.Reporting.Drawing.Unit.Inch(0.24583321809768677D));
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
            this.textBoxCertifiedOnCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4171538352966309D), Telerik.Reporting.Drawing.Unit.Inch(0.29791656136512756D));
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
            this.textBoxClassifiedOnCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4171538352966309D), Telerik.Reporting.Drawing.Unit.Inch(0.30833336710929871D));
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
            this.textBoxClassifiedOnData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5828466415405273D), Telerik.Reporting.Drawing.Unit.Inch(0.30833336710929871D));
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
            this.textBoxCertifiedOnData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5828466415405273D), Telerik.Reporting.Drawing.Unit.Inch(0.29791656136512756D));
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
            this.classifierTitleCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4171538352966309D), Telerik.Reporting.Drawing.Unit.Inch(0.27708357572555542D));
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
            this.supervisorTitleCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4171538352966309D), Telerik.Reporting.Drawing.Unit.Inch(0.29791674017906189D));
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
            this.textBoxSupervisorOrgTitleData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5828466415405273D), Telerik.Reporting.Drawing.Unit.Inch(0.29791674017906189D));
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
            this.textBoxClassifierOrgTitleData.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5828466415405273D), Telerik.Reporting.Drawing.Unit.Inch(0.27708357572555542D));
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
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4171538352966309D), Telerik.Reporting.Drawing.Unit.Inch(0.93333375453948975D));
            this.textBox1.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox1.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox1.Style.Font.Bold = true;
            this.textBox1.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox1.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox1.Value = "Organization Structure:";
            // 
            // textBox2
            // 
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5828466415405273D), Telerik.Reporting.Drawing.Unit.Inch(0.93333375453948975D));
            this.textBox2.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox2.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox2.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox2.Value = resources.GetString("textBox2.Value");
            // 
            // textBox3
            // 
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4171538352966309D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.textBox3.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox3.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox3.Style.Font.Bold = true;
            this.textBox3.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox3.Value = "Approving Official Signature:";
            // 
            // textBox4
            // 
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5828471183776855D), Telerik.Reporting.Drawing.Unit.Inch(0.30000001192092896D));
            this.textBox4.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox4.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox4.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox4.Value = "= Fields.AdditionalSupervisorFullName";
            // 
            // textBox5
            // 
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4171538352966309D), Telerik.Reporting.Drawing.Unit.Inch(0.33958327770233154D));
            this.textBox5.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox5.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox5.Style.Font.Bold = true;
            this.textBox5.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox5.Value = "Approving Official Sign Date:";
            // 
            // textBox6
            // 
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5828466415405273D), Telerik.Reporting.Drawing.Unit.Inch(0.33958327770233154D));
            this.textBox6.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox6.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox6.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox6.Value = "= Fields.AdditionalSupervisorSignDate";
            // 
            // textBox7
            // 
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4171538352966309D), Telerik.Reporting.Drawing.Unit.Inch(0.29791674017906189D));
            this.textBox7.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox7.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox7.Style.Font.Bold = true;
            this.textBox7.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox7.Value = "Approving Official Title:";
            // 
            // textBox8
            // 
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5828466415405273D), Telerik.Reporting.Drawing.Unit.Inch(0.29791674017906189D));
            this.textBox8.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox8.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox8.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox8.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox8.Value = "= Fields.AdditionalSupOrgTitle";
            // 
            // textBoxEmpOffLocationCaption
            // 
            this.textBoxEmpOffLocationCaption.Name = "textBoxEmpOffLocationCaption";
            this.textBoxEmpOffLocationCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4171538352966309D), Telerik.Reporting.Drawing.Unit.Inch(0.34000006318092346D));
            this.textBoxEmpOffLocationCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxEmpOffLocationCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxEmpOffLocationCaption.Style.Font.Bold = true;
            this.textBoxEmpOffLocationCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxEmpOffLocationCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxEmpOffLocationCaption.Value = "Employee Office Location:";
            // 
            // textBoxEmpOffLocation
            // 
            this.textBoxEmpOffLocation.Name = "textBoxEmpOffLocation";
            this.textBoxEmpOffLocation.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5828466415405273D), Telerik.Reporting.Drawing.Unit.Inch(0.34000006318092346D));
            this.textBoxEmpOffLocation.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxEmpOffLocation.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxEmpOffLocation.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxEmpOffLocation.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxEmpOffLocation.Value = "= Fields.EmployingOfficeLocation";
            // 
            // textBoxIsInterDiscCaption
            // 
            this.textBoxIsInterDiscCaption.Name = "textBoxIsInterDiscCaption";
            this.textBoxIsInterDiscCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4171538352966309D), Telerik.Reporting.Drawing.Unit.Inch(0.28999999165534973D));
            this.textBoxIsInterDiscCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxIsInterDiscCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxIsInterDiscCaption.Style.Font.Bold = true;
            this.textBoxIsInterDiscCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxIsInterDiscCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxIsInterDiscCaption.Value = "Is Interdisciplinary PD?";
            // 
            // textBoxIsInterDisc
            // 
            this.textBoxIsInterDisc.Name = "textBoxIsInterDisc";
            this.textBoxIsInterDisc.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5828466415405273D), Telerik.Reporting.Drawing.Unit.Inch(0.28999999165534973D));
            this.textBoxIsInterDisc.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxIsInterDisc.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxIsInterDisc.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxIsInterDisc.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxIsInterDisc.Value = "=iif(Fields.IsInterdisciplinaryPD,\"YES\",\"NO\")";
            // 
            // textBoxAdditionalSeriesCaption
            // 
            this.textBoxAdditionalSeriesCaption.Name = "textBoxAdditionalSeriesCaption";
            this.textBoxAdditionalSeriesCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4171538352966309D), Telerik.Reporting.Drawing.Unit.Inch(0.28999999165534973D));
            this.textBoxAdditionalSeriesCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxAdditionalSeriesCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxAdditionalSeriesCaption.Style.Font.Bold = true;
            this.textBoxAdditionalSeriesCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxAdditionalSeriesCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxAdditionalSeriesCaption.Value = "Additional Series:";
            // 
            // textBoxAdditionalSeries
            // 
            this.textBoxAdditionalSeries.Name = "textBoxAdditionalSeries";
            this.textBoxAdditionalSeries.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5828466415405273D), Telerik.Reporting.Drawing.Unit.Inch(0.28999999165534973D));
            this.textBoxAdditionalSeries.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBoxAdditionalSeries.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxAdditionalSeries.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxAdditionalSeries.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxAdditionalSeries.Value = "= Fields.AdditionalSeries";
            // 
            // textBox9
            // 
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4171538352966309D), Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D));
            this.textBox9.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox9.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox9.Style.Font.Bold = true;
            this.textBox9.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox9.StyleName = "";
            this.textBox9.Value = "FWS Title:";
            // 
            // textBox10
            // 
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5828471183776855D), Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D));
            this.textBox10.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox10.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox10.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox10.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox10.StyleName = "";
            this.textBox10.Value = "=Fields.AgencyPositionTitle";
            // 
            // textBox11
            // 
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4171538352966309D), Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D));
            this.textBox11.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox11.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox11.Style.Font.Bold = true;
            this.textBox11.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox11.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox11.StyleName = "";
            this.textBox11.Value = "OPM Title:";
            // 
            // textBox12
            // 
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5828471183776855D), Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D));
            this.textBox12.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox12.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox12.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox12.StyleName = "";
            this.textBox12.Value = "=Fields.OPMJobTitle";
            // 
            // textBox13
            // 
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.4171538352966309D), Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D));
            this.textBox13.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox13.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox13.Style.Font.Bold = true;
            this.textBox13.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox13.StyleName = "";
            this.textBox13.Value = "Full Performance Level:";
            // 
            // textBox14
            // 
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(4.5828471183776855D), Telerik.Reporting.Drawing.Unit.Inch(0.29999998211860657D));
            this.textBox14.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.textBox14.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox14.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox14.StyleName = "";
            this.textBox14.Value = "=Fields.ProposedFPGrade";
            // 
            // pDExpressDataSet
            // 
            this.pDExpressDataSet.DataSetName = "PDExpressDataSet";
            this.pDExpressDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(1.2000789642333984D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBoxIntroductionCaption,
            this.introductionDataTextBox,
            this.htmlTextBoxSODPara1});
            this.detail.Name = "detail";
            // 
            // textBoxIntroductionCaption
            // 
            formattingRule1.Filters.AddRange(new Telerik.Reporting.Filter[] {
            new Telerik.Reporting.Filter("= Len(Fields.Introduction)", Telerik.Reporting.FilterOperator.LessOrEqual, "0")});
            formattingRule1.Style.Visible = false;
            this.textBoxIntroductionCaption.ConditionalFormatting.AddRange(new Telerik.Reporting.Drawing.FormattingRule[] {
            formattingRule1});
            this.textBoxIntroductionCaption.Name = "textBoxIntroductionCaption";
            this.textBoxIntroductionCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.9996776580810547D), Telerik.Reporting.Drawing.Unit.Inch(0.29996046423912048D));
            this.textBoxIntroductionCaption.Style.Font.Bold = true;
            this.textBoxIntroductionCaption.Style.Font.Size = Telerik.Reporting.Drawing.Unit.Point(14D);
            this.textBoxIntroductionCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBoxIntroductionCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxIntroductionCaption.Value = "Introduction:";
            // 
            // introductionDataTextBox
            // 
            this.introductionDataTextBox.KeepTogether = false;
            this.introductionDataTextBox.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.30003929138183594D));
            this.introductionDataTextBox.Name = "introductionDataTextBox";
            this.introductionDataTextBox.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0000004768371582D), Telerik.Reporting.Drawing.Unit.Inch(0.29984274506568909D));
            this.introductionDataTextBox.Style.Color = System.Drawing.Color.Black;
            this.introductionDataTextBox.StyleName = "Data";
            this.introductionDataTextBox.Value = "=Fields.Introduction";
            // 
            // htmlTextBoxSODPara1
            // 
            this.htmlTextBoxSODPara1.CanShrink = true;
            this.htmlTextBoxSODPara1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0D), Telerik.Reporting.Drawing.Unit.Inch(0.7000395655632019D));
            this.htmlTextBoxSODPara1.Name = "htmlTextBoxSODPara1";
            this.htmlTextBoxSODPara1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(7.0000004768371582D), Telerik.Reporting.Drawing.Unit.Inch(0.5D));
            this.htmlTextBoxSODPara1.Style.Visible = true;
            this.htmlTextBoxSODPara1.Value = "<p><strong><span style=\"font-size: 10pt\">Statement of Difference related fields</" +
    "span></strong></p><p>{Fields.ParagraphOneText}</p><p>{Fields.SODParagraph2}</p><" +
    "p>{Fields.ParagraphThreeText}</p>";
            // 
            // pdExpressDataSetTableAdapter1
            // 
            this.pdExpressDataSetTableAdapter1.ClearBeforeFill = true;
            // 
            // SODPDDocument
            // 
            this.DataSource = this.pDExpressDataSet;
            this.Filters.AddRange(new Telerik.Reporting.Filter[] {
            new Telerik.Reporting.Filter("=Fields.PositionDescriptionID", Telerik.Reporting.FilterOperator.Equal, "=Parameters.PositionDescriptionID")});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.pageFooter,
            this.reportHeader,
            this.detail});
            this.Name = "SODPDDocument";
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
            styleRule3.Style.Font.Name = "Tahoma";
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
            ((System.ComponentModel.ISupportInitialize)(this.pDExpressDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private PageFooterSection pageFooter;
        private Telerik.Reporting.TextBox currentTimeTextBox;
        private Telerik.Reporting.TextBox pageInfoTextBox;
        private ReportHeaderSection reportHeader;
        private DetailSection detail;
        private PDExpressDataSet pDExpressDataSet;
        private HCMS.Reports.PDExpressDataSetTableAdapters.PDExpressDataSetTableAdapter pdExpressDataSetTableAdapter1;
        private Telerik.Reporting.PictureBox pictureBox1;
        private Telerik.Reporting.TextBox textBoxPDHeader;
        private Table tablePDDetails;
        private Telerik.Reporting.TextBox textBoxPDNoCaption;
        private Telerik.Reporting.TextBox textBoxPDNoData;
        private Telerik.Reporting.TextBox textBoxPayPlanCaption;
        private Telerik.Reporting.TextBox textBoxPayPlanData;
        private Telerik.Reporting.TextBox textBoxDutyLocationCaption;
        private Telerik.Reporting.TextBox textBoxCertifiedByCaption;
        private Telerik.Reporting.TextBox textBoxClassifiedByCaption;
        private Telerik.Reporting.TextBox textBoxDutyLocationData;
        private Telerik.Reporting.TextBox textBoxClassifiedByData;
        private Telerik.Reporting.TextBox textBoxCertifiedByData;
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
        private Telerik.Reporting.TextBox textBoxIntroductionCaption;
        private Telerik.Reporting.TextBox introductionDataTextBox;
        private HtmlTextBox htmlTextBoxSODPara1;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox8;
        private Telerik.Reporting.TextBox textBoxEmpOffLocationCaption;
        private Telerik.Reporting.TextBox textBoxEmpOffLocation;
        private Telerik.Reporting.TextBox textBoxIsInterDiscCaption;
        private Telerik.Reporting.TextBox textBoxIsInterDisc;
        private Telerik.Reporting.TextBox textBoxAdditionalSeriesCaption;
        private Telerik.Reporting.TextBox textBoxAdditionalSeries;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox14;

    }
}
