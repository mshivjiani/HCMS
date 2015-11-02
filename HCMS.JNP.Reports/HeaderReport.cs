namespace HCMS.JNP.Reports
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for Report1.
    /// </summary>
    public partial class HeaderReport : Telerik.Reporting.Report
    {
        public HeaderReport()
        {               
            InitializeComponent();            
        }
      
        private void detail_ItemDataBinding(object sender, EventArgs e)
        {
           

            //if (this.ReportParameters["staffingObjectTypeId"].ToString() == "3")
            //{
            //    lblEmployeeOfficeLocation.Visible = true;
            //    txtEmployeeOfficeLocation.Visible = true;
            //    lblEmployeeOfficeLocation.CanShrink = false;
            //    txtEmployeeOfficeLocation.CanShrink = false;
            //}
            //else
            //{
            //    lblEmployeeOfficeLocation.Visible = false;
            //    txtEmployeeOfficeLocation.Visible = false;
            //    lblEmployeeOfficeLocation.CanShrink = true;
            //    txtEmployeeOfficeLocation.CanShrink = true;
            //}

         
        }
    }
}