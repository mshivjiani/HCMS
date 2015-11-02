namespace HCMS.Reports.Comments
{
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    partial class PDWorkflowComments
    {
        #region Component Designer generated code
        /// <summary>
        /// Required method for telerik Reporting designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.Reporting.ReportParameter reportParameter1 = new Telerik.Reporting.ReportParameter();
            Telerik.Reporting.Drawing.StyleRule styleRule1 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule2 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule3 = new Telerik.Reporting.Drawing.StyleRule();
            Telerik.Reporting.Drawing.StyleRule styleRule4 = new Telerik.Reporting.Drawing.StyleRule();
            this.textBox8 = new Telerik.Reporting.TextBox();
            this.detail = new Telerik.Reporting.DetailSection();
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
            this.textBox4 = new Telerik.Reporting.TextBox();
            this.textBox1 = new Telerik.Reporting.TextBox();
            this.pDWorkflowNotes = new HCMS.Reports.PDWorkflowNotes();
            this.pdWorkflowNotesTableAdapter1 = new HCMS.Reports.PDWorkflowNotesTableAdapters.PDWorkflowNotesTableAdapter();
            this.group1 = new Telerik.Reporting.Group();
            this.groupFooterSection1 = new Telerik.Reporting.GroupFooterSection();
            this.groupHeaderSection1 = new Telerik.Reporting.GroupHeaderSection();
            this.titleTextBoxGSSG = new Telerik.Reporting.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pDWorkflowNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // textBox8
            // 
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.98461520671844482, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.28999999165534973, Telerik.Reporting.Drawing.UnitType.Inch));
            // 
            // detail
            // 
            this.detail.Height = new Telerik.Reporting.Drawing.Unit(2.4208335876464844, Telerik.Reporting.Drawing.UnitType.Inch);
            this.detail.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
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
            this.detail.KeepTogether = false;
            this.detail.Name = "detail";
            // 
            // textBox2
            // 
            this.textBox2.Format = "{0:d}";
            this.textBox2.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(1.1000000238418579, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.32083335518836975, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(2, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.22075466811656952, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox2.Value = "=Fields.CreateDate.Date";
            // 
            // textBox3
            // 
            this.textBox3.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(4.4000000953674316, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.32083335518836975, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(2.5999600887298584, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.22075466811656952, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox3.Value = "=Fields.CreatedBy";
            // 
            // textBox5
            // 
            this.textBox5.Format = "{0:d}";
            this.textBox5.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(1.1000000238418579, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.62083339691162109, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(2, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.22075466811656952, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox5.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox5.Value = "=Fields.UpdateDate.Date";
            // 
            // textBox6
            // 
            this.textBox6.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(4.4000000953674316, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.62083339691162109, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(2.6000001430511475, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.22075466811656952, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox6.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox6.Value = "=Fields.UpdatedBy";
            // 
            // textBox7
            // 
            this.textBox7.CanShrink = true;
            this.textBox7.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(1.1000000238418579, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.92083340883255, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(5.8999614715576172, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.5, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox7.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox7.Value = "=Fields.Note";
            // 
            // textBox9
            // 
            this.textBox9.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(1.1000000238418579, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(1.5208333730697632, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(5.8999619483947754, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.34000000357627869, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox9.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox9.Value = "=Fields.UpdateNote";
            // 
            // textBox10
            // 
            this.textBox10.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(4.4000000953674316, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.022012710571289062, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(2.6000001430511475, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.22075466811656952, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox10.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox10.Value = "=Fields.WorkflowStatus";
            // 
            // textBox11
            // 
            this.textBox11.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(1.1000000238418579, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(2.0208334922790527, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.3999999761581421, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000012218952179, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox11.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox11.Value = "=Fields.NoteStatus";
            // 
            // textBoxFWSTitleCaption
            // 
            this.textBoxFWSTitleCaption.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.32083335518836975, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBoxFWSTitleCaption.Name = "textBoxFWSTitleCaption";
            this.textBoxFWSTitleCaption.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.0000001192092896, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.22075466811656952, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBoxFWSTitleCaption.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.textBoxFWSTitleCaption.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBoxFWSTitleCaption.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBoxFWSTitleCaption.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBoxFWSTitleCaption.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBoxFWSTitleCaption.Style.BorderWidth.Bottom = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBoxFWSTitleCaption.Style.BorderWidth.Default = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBoxFWSTitleCaption.Style.BorderWidth.Left = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBoxFWSTitleCaption.Style.BorderWidth.Top = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBoxFWSTitleCaption.Style.Font.Bold = true;
            this.textBoxFWSTitleCaption.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBoxFWSTitleCaption.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBoxFWSTitleCaption.Value = "Create Date:";
            // 
            // textBox12
            // 
            this.textBox12.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.62083339691162109, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.0000001192092896, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.22075466811656952, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox12.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox12.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox12.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox12.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox12.Style.BorderWidth.Bottom = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox12.Style.BorderWidth.Default = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox12.Style.BorderWidth.Left = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox12.Style.BorderWidth.Top = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox12.Style.Font.Bold = true;
            this.textBox12.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox12.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox12.Value = "Update Date:";
            // 
            // textBox13
            // 
            this.textBox13.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.3000001907348633, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.32083335518836975, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.22075466811656952, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox13.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox13.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox13.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox13.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox13.Style.BorderWidth.Bottom = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox13.Style.BorderWidth.Default = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox13.Style.BorderWidth.Left = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox13.Style.BorderWidth.Top = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox13.Style.Font.Bold = true;
            this.textBox13.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(2, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox13.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox13.Value = "Created By:";
            // 
            // textBox14
            // 
            this.textBox14.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.3000001907348633, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.62083339691162109, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.22075466811656952, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox14.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox14.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox14.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox14.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox14.Style.BorderWidth.Bottom = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox14.Style.BorderWidth.Default = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox14.Style.BorderWidth.Left = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox14.Style.BorderWidth.Top = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox14.Style.Font.Bold = true;
            this.textBox14.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(2, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox14.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox14.Value = "Updated By:";
            // 
            // textBox15
            // 
            this.textBox15.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.92083340883255, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.0000001192092896, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.22075466811656952, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox15.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox15.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox15.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox15.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox15.Style.BorderWidth.Bottom = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox15.Style.BorderWidth.Default = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox15.Style.BorderWidth.Left = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox15.Style.BorderWidth.Top = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox15.Style.Font.Bold = true;
            this.textBox15.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox15.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox15.Value = "Description:";
            // 
            // textBox16
            // 
            this.textBox16.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(1.5208333730697632, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.0000001192092896, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.22075466811656952, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox16.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox16.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox16.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox16.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox16.Style.BorderWidth.Bottom = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox16.Style.BorderWidth.Default = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox16.Style.BorderWidth.Left = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox16.Style.BorderWidth.Top = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox16.Style.Font.Bold = true;
            this.textBox16.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox16.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox16.Value = "Update Note:";
            // 
            // textBox17
            // 
            this.textBox17.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(2.0208332538604736, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.0000001192092896, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.20000012218952179, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox17.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox17.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox17.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox17.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox17.Style.BorderWidth.Bottom = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox17.Style.BorderWidth.Default = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox17.Style.BorderWidth.Left = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox17.Style.BorderWidth.Top = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox17.Style.Font.Bold = true;
            this.textBox17.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox17.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox17.Value = "Note Status:";
            // 
            // textBox18
            // 
            this.textBox18.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(3.3000001907348633, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.022012710571289062, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(0.99999982118606567, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.22075466811656952, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox18.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox18.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox18.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox18.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox18.Style.BorderWidth.Bottom = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox18.Style.BorderWidth.Default = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox18.Style.BorderWidth.Left = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox18.Style.BorderWidth.Top = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox18.Style.Font.Bold = true;
            this.textBox18.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(2, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox18.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox18.Value = "Status:";
            // 
            // shape1
            // 
            this.shape1.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(2.3208334445953369, Telerik.Reporting.Drawing.UnitType.Inch));
            this.shape1.Name = "shape1";
            this.shape1.ShapeType = new Telerik.Reporting.Drawing.Shapes.LineShape(Telerik.Reporting.Drawing.Shapes.LineDirection.EW);
            this.shape1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(7.0000004768371582, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.10000000149011612, Telerik.Reporting.Drawing.UnitType.Inch));
            // 
            // textBox20
            // 
            this.textBox20.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.022012710571289062, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(1.0000001192092896, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.22075466811656952, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox20.Style.BorderStyle.Bottom = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox20.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox20.Style.BorderStyle.Left = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox20.Style.BorderStyle.Right = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox20.Style.BorderStyle.Top = Telerik.Reporting.Drawing.BorderType.None;
            this.textBox20.Style.BorderWidth.Bottom = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox20.Style.BorderWidth.Default = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox20.Style.BorderWidth.Left = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox20.Style.BorderWidth.Top = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox20.Style.Font.Bold = true;
            this.textBox20.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.textBox20.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox20.Value = "Note ID:";
            // 
            // textBox21
            // 
            this.textBox21.Location = new Telerik.Reporting.Drawing.PointU(new Telerik.Reporting.Drawing.Unit(1.1000000238418579, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.022012710571289062, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(2, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.22075466811656952, Telerik.Reporting.Drawing.UnitType.Inch));
            this.textBox21.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.textBox21.Value = "=Fields.WorkflowNoteID";
            // 
            // textBox4
            // 
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(3, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.28999999165534973, Telerik.Reporting.Drawing.UnitType.Inch));
            // 
            // textBox1
            // 
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(2.9999802112579346, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Inch));
            // 
            // pDWorkflowNotes
            // 
            this.pDWorkflowNotes.DataSetName = "PDWorkflowNotes";
            this.pDWorkflowNotes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pdWorkflowNotesTableAdapter1
            // 
            this.pdWorkflowNotesTableAdapter1.ClearBeforeFill = true;
            // 
            // group1
            // 
            this.group1.Bookmark = null;
            this.group1.GroupFooter = this.groupFooterSection1;
            this.group1.GroupHeader = this.groupHeaderSection1;
            this.group1.Grouping.AddRange(new Telerik.Reporting.Data.Grouping[] {
            new Telerik.Reporting.Data.Grouping("=Fields.PositionDescriptionID")});
            // 
            // groupFooterSection1
            // 
            this.groupFooterSection1.Height = new Telerik.Reporting.Drawing.Unit(0, Telerik.Reporting.Drawing.UnitType.Inch);
            this.groupFooterSection1.Name = "groupFooterSection1";
            // 
            // groupHeaderSection1
            // 
            this.groupHeaderSection1.Height = new Telerik.Reporting.Drawing.Unit(0.40000000596046448, Telerik.Reporting.Drawing.UnitType.Inch);
            this.groupHeaderSection1.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.titleTextBoxGSSG});
            this.groupHeaderSection1.Name = "groupHeaderSection1";
            // 
            // titleTextBoxGSSG
            // 
            this.titleTextBoxGSSG.KeepTogether = false;
            this.titleTextBoxGSSG.Name = "titleTextBoxGSSG";
            this.titleTextBoxGSSG.Size = new Telerik.Reporting.Drawing.SizeU(new Telerik.Reporting.Drawing.Unit(6.9999618530273438, Telerik.Reporting.Drawing.UnitType.Inch), new Telerik.Reporting.Drawing.Unit(0.28740167617797852, Telerik.Reporting.Drawing.UnitType.Inch));
            this.titleTextBoxGSSG.Style.BackgroundColor = System.Drawing.Color.White;
            this.titleTextBoxGSSG.Style.BorderStyle.Default = Telerik.Reporting.Drawing.BorderType.Solid;
            this.titleTextBoxGSSG.Style.BorderWidth.Default = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.titleTextBoxGSSG.Style.Color = System.Drawing.Color.Black;
            this.titleTextBoxGSSG.Style.Font.Bold = true;
            this.titleTextBoxGSSG.Style.Font.Name = "Arial";
            this.titleTextBoxGSSG.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(12, Telerik.Reporting.Drawing.UnitType.Point);
            this.titleTextBoxGSSG.Style.Padding.Left = new Telerik.Reporting.Drawing.Unit(2, Telerik.Reporting.Drawing.UnitType.Pixel);
            this.titleTextBoxGSSG.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.titleTextBoxGSSG.StyleName = "Title";
            this.titleTextBoxGSSG.Value = "Workflow Notes:";
            // 
            // PDWorkflowComments
            // 
            this.Groups.AddRange(new Telerik.Reporting.Group[] {
            this.group1});
            this.Items.AddRange(new Telerik.Reporting.ReportItemBase[] {
            this.groupHeaderSection1,
            this.groupFooterSection1,
            this.detail});
            this.PageSettings.Landscape = false;
            this.PageSettings.Margins.Bottom = new Telerik.Reporting.Drawing.Unit(0.5, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Left = new Telerik.Reporting.Drawing.Unit(0.5, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Right = new Telerik.Reporting.Drawing.Unit(0.5, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.Margins.Top = new Telerik.Reporting.Drawing.Unit(0.5, Telerik.Reporting.Drawing.UnitType.Inch);
            this.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            reportParameter1.Name = "PDID";
            reportParameter1.Type = Telerik.Reporting.ReportParameterType.Float;
            reportParameter1.Visible = true;
            this.ReportParameters.Add(reportParameter1);
            this.Style.BackgroundColor = System.Drawing.Color.White;
            this.Style.BorderWidth.Default = new Telerik.Reporting.Drawing.Unit(1, Telerik.Reporting.Drawing.UnitType.Pixel);
            styleRule1.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Title")});
            styleRule1.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(222)))), ((int)(((byte)(201)))));
            styleRule1.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(39)))), ((int)(((byte)(28)))));
            styleRule1.Style.Font.Name = "Gill Sans MT";
            styleRule1.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(20, Telerik.Reporting.Drawing.UnitType.Point);
            styleRule2.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Caption")});
            styleRule2.Style.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(222)))), ((int)(((byte)(201)))));
            styleRule2.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(39)))), ((int)(((byte)(28)))));
            styleRule2.Style.Font.Name = "Gill Sans MT";
            styleRule2.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(10, Telerik.Reporting.Drawing.UnitType.Point);
            styleRule2.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule3.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("Data")});
            styleRule3.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(39)))), ((int)(((byte)(28)))));
            styleRule3.Style.Font.Name = "Gill Sans MT";
            styleRule3.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(10, Telerik.Reporting.Drawing.UnitType.Point);
            styleRule3.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            styleRule4.Selectors.AddRange(new Telerik.Reporting.Drawing.ISelector[] {
            new Telerik.Reporting.Drawing.StyleSelector("PageInfo")});
            styleRule4.Style.Color = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(141)))), ((int)(((byte)(105)))));
            styleRule4.Style.Font.Name = "Gill Sans MT";
            styleRule4.Style.Font.Size = new Telerik.Reporting.Drawing.Unit(9, Telerik.Reporting.Drawing.UnitType.Point);
            styleRule4.Style.VerticalAlign = Telerik.Reporting.Drawing.VerticalAlign.Middle;
            this.StyleSheet.AddRange(new Telerik.Reporting.Drawing.StyleRule[] {
            styleRule1,
            styleRule2,
            styleRule3,
            styleRule4});
            this.Width = new Telerik.Reporting.Drawing.Unit(7.3000001907348633, Telerik.Reporting.Drawing.UnitType.Inch);
            this.NeedDataSource += new System.EventHandler(this.PDWorkflowComments_NeedDataSource);
            ((System.ComponentModel.ISupportInitialize)(this.pDWorkflowNotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }
        #endregion

        private Telerik.Reporting.DetailSection detail;
        private Telerik.Reporting.TextBox textBox4;
        private Telerik.Reporting.TextBox textBox1;
        private Telerik.Reporting.TextBox textBox8;
        private PDWorkflowNotes pDWorkflowNotes;
        private HCMS.Reports.PDWorkflowNotesTableAdapters.PDWorkflowNotesTableAdapter pdWorkflowNotesTableAdapter1;
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
        private Shape shape1;
        private Telerik.Reporting.TextBox textBox20;
        private Telerik.Reporting.TextBox textBox21;
        private Group group1;
        private GroupFooterSection groupFooterSection1;
        private GroupHeaderSection groupHeaderSection1;
        private Telerik.Reporting.TextBox titleTextBoxGSSG;
    }
}
