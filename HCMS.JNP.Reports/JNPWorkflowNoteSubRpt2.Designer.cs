namespace HCMS.JNP.Reports
{
    partial class JNPWorkflowNoteSubRpt2
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.TableGroup tableGroup1 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.TableGroup tableGroup2 = new Telerik.Reporting.TableGroup();
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            this.detail = new Telerik.Reporting.DetailSection();
            this.list1 = new Telerik.Reporting.List();
            this.panel1 = new Telerik.Reporting.Panel();
            this.textBox2 = new Telerik.Reporting.TextBox();
            this.textBox3 = new Telerik.Reporting.TextBox();
            this.textBox5 = new Telerik.Reporting.TextBox();
            this.textBox6 = new Telerik.Reporting.TextBox();
            this.textBox7 = new Telerik.Reporting.TextBox();
            this.textBox9 = new Telerik.Reporting.TextBox();
            this.textBox10 = new Telerik.Reporting.TextBox();
            this.textBox11 = new Telerik.Reporting.TextBox();
            this.textBoxFWSTitleCaption = new Telerik.Reporting.TextBox();
            this.textBox12 = new Telerik.Reporting.TextBox();
            this.textBox13 = new Telerik.Reporting.TextBox();
            this.textBox14 = new Telerik.Reporting.TextBox();
            this.textBox15 = new Telerik.Reporting.TextBox();
            this.textBox16 = new Telerik.Reporting.TextBox();
            this.textBox17 = new Telerik.Reporting.TextBox();
            this.textBox18 = new Telerik.Reporting.TextBox();
            this.shape1 = new Telerik.Reporting.Shape();
            this.textBox20 = new Telerik.Reporting.TextBox();
            this.textBox21 = new Telerik.Reporting.TextBox();
            this.objDataSourceGetJNPWorkflowNoteByJNPID = new Telerik.Reporting.ObjectDataSource();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // detail
            // 
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Inch(2.46875D);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.list1});
            this.detail.Name = "detail";
            // 
            // list1
            // 
            this.list1.Body.Columns.Add(new Telerik.Reporting.TableBodyColumn(Telerik.Reporting.Drawing.Unit.Inch(6.4166665077209473D)));
            this.list1.Body.Rows.Add(new Telerik.Reporting.TableBodyRow(Telerik.Reporting.Drawing.Unit.Inch(2.4479167461395264D)));
            this.list1.Body.SetCellContent(0, 0, this.panel1);
            tableGroup1.Name = "ColumnGroup";
            this.list1.ColumnGroups.Add(tableGroup1);
            this.list1.DataSource = this.objDataSourceGetJNPWorkflowNoteByJNPID;
            this.list1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.panel1});
            this.list1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D), Telerik.Reporting.Drawing.Unit.Inch(0.02083333395421505D));
            this.list1.Name = "list1";
            tableGroup2.Groupings.AddRange(new Telerik.Reporting.Grouping[] {
            new Telerik.Reporting.Grouping(null)});
            tableGroup2.Name = "DetailGroup";
            this.list1.RowGroups.Add(tableGroup2);
            this.list1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4166665077209473D), Telerik.Reporting.Drawing.Unit.Inch(2.4479167461395264D));
            // 
            // panel1
            // 
            this.panel1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.textBox2,
            this.textBox3,
            this.textBox5,
            this.textBox6,
            this.textBox7,
            this.textBox9,
            this.textBox10,
            this.textBox11,
            this.textBoxFWSTitleCaption,
            this.textBox12,
            this.textBox13,
            this.textBox14,
            this.textBox15,
            this.textBox16,
            this.textBox17,
            this.textBox18,
            this.shape1,
            this.textBox20,
            this.textBox21});
            this.panel1.Name = "panel1";
            this.panel1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.4166665077209473D), Telerik.Reporting.Drawing.Unit.Inch(2.4479167461395264D));
            // 
            // textBox2
            // 
            this.textBox2.Format = "{0:d}";
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.1458333730697632D), Telerik.Reporting.Drawing.Unit.Inch(0.34375D));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.46875D), Telerik.Reporting.Drawing.Unit.Inch(0.22075466811656952D));
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox2.Value = "= Fields.CreateDate";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.78125D), Telerik.Reporting.Drawing.Unit.Inch(0.3229166567325592D));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.5999600887298584D), Telerik.Reporting.Drawing.Unit.Inch(0.22075466811656952D));
            this.textBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox3.Value = "= Fields.CreatedBy";
            // 
            // textBox5
            // 
            this.textBox5.Format = "{0:d}";
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.1458333730697632D), Telerik.Reporting.Drawing.Unit.Inch(0.64583331346511841D));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.46875D), Telerik.Reporting.Drawing.Unit.Inch(0.22075466811656952D));
            this.textBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox5.Value = "= Fields.UpdateDate";
            // 
            // textBox6
            // 
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.78125D), Telerik.Reporting.Drawing.Unit.Inch(0.625D));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.6000001430511475D), Telerik.Reporting.Drawing.Unit.Inch(0.22075466811656952D));
            this.textBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox6.Value = "= Fields.UpdatedBy";
            // 
            // textBox7
            // 
            this.textBox7.CanShrink = true;
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.1458333730697632D), Telerik.Reporting.Drawing.Unit.Inch(0.9375D));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.2437114715576172D), Telerik.Reporting.Drawing.Unit.Inch(0.5D));
            this.textBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox7.Value = "= Fields.Note";
            // 
            // textBox9
            // 
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.1458333730697632D), Telerik.Reporting.Drawing.Unit.Inch(1.5520833730697632D));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(5.2437119483947754D), Telerik.Reporting.Drawing.Unit.Inch(0.34000000357627869D));
            this.textBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox9.Value = "= Fields.UpdateNote";
            // 
            // textBox10
            // 
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(3.78125D), Telerik.Reporting.Drawing.Unit.Inch(0.03125D));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(2.6000001430511475D), Telerik.Reporting.Drawing.Unit.Inch(0.22075466811656952D));
            this.textBox10.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox10.Value = "= Fields.JNPWorkflowStatus";
            // 
            // textBox11
            // 
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.1458333730697632D), Telerik.Reporting.Drawing.Unit.Inch(2.0520832538604736D));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.3999999761581421D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.textBox11.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox11.Value = "= Fields.JNPWorkflowNoteStatus";
            // 
            // textBoxFWSTitleCaption
            // 
            this.textBoxFWSTitleCaption.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D), Telerik.Reporting.Drawing.Unit.Inch(0.34375D));
            this.textBoxFWSTitleCaption.Name = "textBoxFWSTitleCaption";
            this.textBoxFWSTitleCaption.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0000001192092896D), Telerik.Reporting.Drawing.Unit.Inch(0.22075466811656952D));
            this.textBoxFWSTitleCaption.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.textBoxFWSTitleCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBoxFWSTitleCaption.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBoxFWSTitleCaption.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBoxFWSTitleCaption.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBoxFWSTitleCaption.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxFWSTitleCaption.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxFWSTitleCaption.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxFWSTitleCaption.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBoxFWSTitleCaption.Style.Font.Bold = true;
            this.textBoxFWSTitleCaption.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(0D);
            this.textBoxFWSTitleCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxFWSTitleCaption.Value = "Create Date:";
            // 
            // textBox12
            // 
            this.textBox12.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D), Telerik.Reporting.Drawing.Unit.Inch(0.64583331346511841D));
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0000001192092896D), Telerik.Reporting.Drawing.Unit.Inch(0.22075466811656952D));
            this.textBox12.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox12.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox12.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox12.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox12.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox12.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox12.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox12.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox12.Style.Font.Bold = true;
            this.textBox12.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(0D);
            this.textBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox12.Value = "Update Date:";
            // 
            // textBox13
            // 
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.7083332538604736D), Telerik.Reporting.Drawing.Unit.Inch(0.34375D));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.22075466811656952D));
            this.textBox13.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox13.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox13.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox13.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox13.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox13.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox13.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox13.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox13.Style.Font.Bold = true;
            this.textBox13.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox13.Value = "Created By:";
            // 
            // textBox14
            // 
            this.textBox14.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.7083332538604736D), Telerik.Reporting.Drawing.Unit.Inch(0.64583331346511841D));
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1D), Telerik.Reporting.Drawing.Unit.Inch(0.22075466811656952D));
            this.textBox14.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox14.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox14.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox14.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox14.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox14.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox14.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox14.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox14.Style.Font.Bold = true;
            this.textBox14.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox14.Value = "Updated By:";
            // 
            // textBox15
            // 
            this.textBox15.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D), Telerik.Reporting.Drawing.Unit.Inch(0.9375D));
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0000001192092896D), Telerik.Reporting.Drawing.Unit.Inch(0.22075466811656952D));
            this.textBox15.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox15.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox15.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox15.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox15.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox15.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox15.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox15.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox15.Style.Font.Bold = true;
            this.textBox15.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(0D);
            this.textBox15.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox15.Value = "Description:";
            // 
            // textBox16
            // 
            this.textBox16.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D), Telerik.Reporting.Drawing.Unit.Inch(1.5520833730697632D));
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0000001192092896D), Telerik.Reporting.Drawing.Unit.Inch(0.22075466811656952D));
            this.textBox16.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox16.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox16.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox16.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox16.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox16.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox16.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox16.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox16.Style.Font.Bold = true;
            this.textBox16.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(0D);
            this.textBox16.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox16.Value = "Update Note:";
            // 
            // textBox17
            // 
            this.textBox17.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D), Telerik.Reporting.Drawing.Unit.Inch(2.0416667461395264D));
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0000001192092896D), Telerik.Reporting.Drawing.Unit.Inch(0.20000012218952179D));
            this.textBox17.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox17.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox17.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox17.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox17.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox17.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox17.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox17.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox17.Style.Font.Bold = true;
            this.textBox17.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(0D);
            this.textBox17.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox17.Value = "Note Status:";
            // 
            // textBox18
            // 
            this.textBox18.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(2.7083332538604736D), Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D));
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(0.99999982118606567D), Telerik.Reporting.Drawing.Unit.Inch(0.22075466811656952D));
            this.textBox18.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox18.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox18.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox18.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox18.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox18.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox18.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox18.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox18.Style.Font.Bold = true;
            this.textBox18.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(2D);
            this.textBox18.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox18.Value = "Status:";
            // 
            // shape1
            // 
            this.shape1.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D), Telerik.Reporting.Drawing.Unit.Inch(2.3333332538604736D));
            this.shape1.Name = "shape1";
            this.shape1.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.shape1.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(6.3541674613952637D), Telerik.Reporting.Drawing.Unit.Inch(0.10000000149011612D));
            // 
            // textBox20
            // 
            this.textBox20.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D), Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D));
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.0000001192092896D), Telerik.Reporting.Drawing.Unit.Inch(0.22075466811656952D));
            this.textBox20.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox20.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox20.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox20.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox20.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox20.Style.BorderWidth.Bottom = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox20.Style.BorderWidth.Default = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox20.Style.BorderWidth.Left = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox20.Style.BorderWidth.Top = Telerik.Reporting.Drawing.Unit.Pixel(1D);
            this.textBox20.Style.Font.Bold = true;
            this.textBox20.Style.Padding.Left = Telerik.Reporting.Drawing.Unit.Pixel(0D);
            this.textBox20.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox20.Value = "Note ID:";
            // 
            // textBox21
            // 
            this.textBox21.Location = new Telerik.Reporting.Drawing.PointU(Telerik.Reporting.Drawing.Unit.Inch(1.1458333730697632D), Telerik.Reporting.Drawing.Unit.Inch(0.0520833320915699D));
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new Telerik.Reporting.Drawing.SizeU(Telerik.Reporting.Drawing.Unit.Inch(1.46875D), Telerik.Reporting.Drawing.Unit.Inch(0.22075466811656952D));
            this.textBox21.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox21.Value = "= Fields.JNPWorkflowNoteID";
            // 
            // objDataSourceGetJNPWorkflowNoteByJNPID
            // 
            this.objDataSourceGetJNPWorkflowNoteByJNPID.DataMember = "GetData";
            this.objDataSourceGetJNPWorkflowNoteByJNPID.DataSource = typeof(HCMS.JNP.Reports.JNPDataSetTableAdapters.spr_GetJNPWorkflowNoteByJNPIDTableAdapter);
            this.objDataSourceGetJNPWorkflowNoteByJNPID.Name = "objDataSourceGetJNPWorkflowNoteByJNPID";
            this.objDataSourceGetJNPWorkflowNoteByJNPID.Parameters.AddRange(new Telerik.Reporting.ObjectDataSourceParameter[] {
            new Telerik.Reporting.ObjectDataSourceParameter("JNPID", typeof(System.Nullable<long>), "=Parameters.jNPID.Value")});
            // 
            // JNPWorkflowNoteSubRpt2
            // 
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.detail});
            this.Name = "JNPWorkflowNoteSubRpt2";
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
            this.Width = Telerik.Reporting.Drawing.Unit.Inch(6.4583334922790527D);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.ObjectDataSource objDataSourceGetJNPWorkflowNoteByJNPID;
        private Telerik.Reporting.List list1;
        private Telerik.Reporting.Panel panel1;
        private Telerik.Reporting.TextBox textBox2;
        private Telerik.Reporting.TextBox textBox3;
        private Telerik.Reporting.TextBox textBox5;
        private Telerik.Reporting.TextBox textBox6;
        private Telerik.Reporting.TextBox textBox7;
        private Telerik.Reporting.TextBox textBox9;
        private Telerik.Reporting.TextBox textBox10;
        private Telerik.Reporting.TextBox textBox11;
        private Telerik.Reporting.TextBox textBoxFWSTitleCaption;
        private Telerik.Reporting.TextBox textBox12;
        private Telerik.Reporting.TextBox textBox13;
        private Telerik.Reporting.TextBox textBox14;
        private Telerik.Reporting.TextBox textBox15;
        private Telerik.Reporting.TextBox textBox16;
        private Telerik.Reporting.TextBox textBox17;
        private Telerik.Reporting.TextBox textBox18;
        private Telerik.Reporting.Shape shape1;
        private Telerik.Reporting.TextBox textBox20;
        private Telerik.Reporting.TextBox textBox21;
    }
}