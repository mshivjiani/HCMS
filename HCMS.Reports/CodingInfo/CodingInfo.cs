namespace HCMS.Reports.CodingInfo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;
    using Telerik.Reporting.Processing;

    /// <summary>
    /// Summary description for CodingInfo.
    /// </summary>
    public partial class CodingInfo : Telerik.Reporting.Report
    {
        public CodingInfo()
        {
            /// <summary>
            /// Required for telerik Reporting designer support
            /// </summary>
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //

            // TODO: This line of code loads data into the 'pDExpressDataSetCodingInfo.PDExpressDataSetCodingInfoTable' table. You can move, or remove it, as needed.
            try
            {
                this.pdExpressDataSetCodingInfoTableAdapter1.Fill(this.pDExpressDataSetCodingInfo.PDExpressDataSetCodingInfoTable);
            }
            catch (System.Exception ex)
            {
                // An error has occurred while filling the data set. Please check the exception for more information.
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        
        //private void detail_ItemDataBinding(object sender, EventArgs e)
        //{
        //    //// Get the detail section object from sender
        //    //Telerik.Reporting.Processing.DetailSection section = (Telerik.Reporting.Processing.DetailSection)sender;
        //    //// From the section object get the current DataRow
        //    //Telerik.Reporting.Processing.IDataObject dataObject = (Telerik.Reporting.Processing.IDataObject)section.DataObject;
        //    //object rowdata = (object)section.DataObject.RawData;
        //    //if ((dataObject["EEODStatement"] == null) || (dataObject["EEODStatement"].ToString().Length == 0))
        //    //{
        //    //    Telerik.Reporting.Processing.Table table1 = (Telerik.Reporting.Processing.Table)section.ChildElements.Find("table1", true)[0];
        //    //    textBox62.Visible = false;
        //    //    textBox63.Visible = false; 
        //    //}

        //}
    }
}