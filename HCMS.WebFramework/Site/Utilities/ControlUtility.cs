using System;
using System.Web;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections;

using TWeb = Telerik.Web.UI;
using TReports = Telerik.Reporting;
using TRProcessing = Telerik.Reporting.Processing;
using HCMS.Business.Common;
using System.IO;
using System.Diagnostics;
using System.Data;
using System.ComponentModel;
using OfficeOpenXml;
using System.Globalization;


namespace HCMS.WebFramework.Site.Utilities
{
    public abstract class ControlUtility
    {

        public delegate bool ListControlBindFilter(ListItem listItem);
        public delegate bool RadComboBoxItemFilter(TWeb.RadComboBoxItem listItem);

        public static void ClearControls(string defaultValue, params Control[] UIControls)
        {
            try
            {
                for (int i = 0; i <= UIControls.Length - 1; i++)
                {
                    if (UIControls[i] is TextBox)
                        ((TextBox)(UIControls[i])).Text = defaultValue;
                    else if (UIControls[i] is HtmlInputText)
                        ((HtmlInputText)(UIControls[i])).Value = defaultValue;
                    else if (UIControls[i] is Literal)
                        ((Literal)(UIControls[i])).Text = defaultValue;
                    else if (UIControls[i] is HtmlTableCell)
                        ((HtmlTableCell)(UIControls[i])).InnerText = defaultValue;
                    else if (UIControls[i] is CheckBox)
                        ((CheckBox)(UIControls[i])).Checked = false;
                    else if (UIControls[i] is DropDownList)
                        ((DropDownList)(UIControls[i])).SelectedIndex = -1;
                    else if (UIControls[i] is Label)
                        ((Label)(UIControls[i])).Text = defaultValue;
                    else if (UIControls[i] is RadioButtonList)
                    {
                        for (int j = 0; j <= ((RadioButtonList)(UIControls[i])).Items.Count - 1; j++)
                        {
                            ((RadioButtonList)(UIControls[i])).Items[j].Selected = false;
                        }
                        ((RadioButtonList)(UIControls[i])).Items[0].Selected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region [ Bind List Control ]
        public static void BindListControl(ListControl inputControl, object source, ListControlBindFilter filter, string textField, string valueField)
        {
            BindListControl(inputControl, source, filter, textField, valueField, string.Empty, string.Empty);
        }

        public static void BindListControl(ListControl inputControl, object source, ListControlBindFilter filter, string textField, string valueField, string topOption)
        {
            BindListControl(inputControl, source, filter, textField, valueField, topOption, string.Empty);
        }

        public static void BindListControl(ListControl inputControl, object source, ListControlBindFilter filter, string textField, string valueField, string topOption, string preselectedValue)
        {
            inputControl.DataSource = source;
            inputControl.DataTextField = textField;
            inputControl.DataValueField = valueField;
            inputControl.DataBind();

            // if the consumer provided the filter - apply it to the list items
            if (filter != null && inputControl.Items.Count > 0)
            {
                for (int index = inputControl.Items.Count - 1; index >= 0; index--)
                {
                    ListItem listItem = inputControl.Items[index];
                    if (filter(listItem))
                    {
                        inputControl.Items.Remove(listItem);
                    }
                }
            }

            if (topOption != null && topOption.Length > 0)
                inputControl.Items.Insert(0, new ListItem(topOption, "-1"));

            if (preselectedValue != null && preselectedValue.Length > 0)
                SafeListControlSelect(inputControl, preselectedValue);
        }
        #endregion

        #region [ Bind RadComboBox List Control ]

        public static void BindRadComboBoxControl(TWeb.RadComboBox inputControl, object source, RadComboBoxItemFilter filter, string textField, string valueField)
        {
            BindRadComboBoxControl(inputControl, source, filter, textField, valueField, string.Empty, string.Empty);
        }

        public static void BindRadComboBoxControl(TWeb.RadComboBox inputControl, object source, RadComboBoxItemFilter filter, string textField, string valueField, string topOption)
        {
            BindRadComboBoxControl(inputControl, source, filter, textField, valueField, topOption, string.Empty);
        }

        public static void BindRadComboBoxControlWithBackground(TWeb.RadComboBox inputControl, object source, RadComboBoxItemFilter filter, string textField, string valueField)
        {
            BindRadComboBoxControlWithBackground(inputControl, source, filter, textField, valueField, string.Empty, string.Empty);
        }

        public static void BindRadComboBoxControlWithBackground(TWeb.RadComboBox inputControl, object source, RadComboBoxItemFilter filter, string textField, string valueField, string topOption)
        {
            BindRadComboBoxControlWithBackground(inputControl, source, filter, textField, valueField, topOption, string.Empty);
        }
        public static void BindRadListBoxControlWithBackground(TWeb.RadListBox inputControl, object source, string textField, string valueField, string topOption)
        {
            BindRadListBoxControlWithBackground(inputControl, source, textField, valueField, topOption, string.Empty);
        }
        /// <summary>
        /// Binds provided RadComboBox control with provided datasource.
        /// Filters data items based on provided RadComboBoxItemFilter
        /// Sets the DatatTextField and DataValueField
        /// Allows to set first item in the list by way of "topOption"
        /// Allows to set pre-selected value by way of "preselectedValue"
        /// </summary>
        /// <param name="inputControl"> RadComboBox to populate</param>
        /// <param name="source">Datasource of RadCombobox</param>
        /// <param name="filter">Filter to be applied when filling up RadCombobox</param>
        /// <param name="textField">DataTextField</param>
        /// <param name="valueField">DataValueField</param>
        /// <param name="topOption">string value to be inserted as first item (index set to 0)in the RadComboBox list</param>
        /// <param name="preselectedValue">sets this as currently selected item</param>
        public static void BindRadComboBoxControl(TWeb.RadComboBox inputControl, object source, RadComboBoxItemFilter filter, string textField, string valueField, string topOption, string preselectedValue)
        {
            inputControl.DataSource = source;
            inputControl.DataTextField = textField;
            inputControl.DataValueField = valueField;
            inputControl.DataBind();

            // if the consumer provided the filter - apply it to the list items
            if (filter != null && inputControl.Items.Count > 0)
            {
                for (int index = inputControl.Items.Count - 1; index >= 0; index--)
                {
                    TWeb.RadComboBoxItem listItem = inputControl.Items[index];
                    if (filter(listItem))
                    {
                        if (inputControl.Items.Contains(listItem))
                        {
                            inputControl.Items.Remove(listItem);
                        }
                    }
                }
            }

            if (topOption != null && topOption.Length > 0)
                inputControl.Items.Insert(0, new TWeb.RadComboBoxItem(topOption, "-1"));

            if (preselectedValue != null && preselectedValue.Length > 0)
                SafeListControlSelect(inputControl, preselectedValue);

        }

        public static void BindRadComboBoxControlWithBackground(TWeb.RadComboBox inputControl, object source, RadComboBoxItemFilter filter, string textField, string valueField, string topOption, string preselectedValue)
        {
            inputControl.DataSource = source;
            inputControl.DataTextField = textField;
            inputControl.DataValueField = valueField;
            inputControl.DataBind();

            // if the consumer provided the filter - apply it to the list items
            if (filter != null && inputControl.Items.Count > 0)
            {
                for (int index = inputControl.Items.Count - 1; index >= 0; index--)
                {
                    TWeb.RadComboBoxItem listItem = inputControl.Items[index];
                    if (filter(listItem))
                    {
                        if (inputControl.Items.Contains(listItem))
                        {
                            inputControl.Items.Remove(listItem);
                        }
                    }
                }
            }

            if (topOption != null && topOption.Length > 0)
                inputControl.Items.Insert(0, new TWeb.RadComboBoxItem(topOption, "-1"));

            if (preselectedValue != null && preselectedValue.Length > 0)
                SafeListControlSelect(inputControl, preselectedValue);

            SetDropdownListItemsBackground(inputControl);

        }

        public static void BindRadListBoxControlWithBackground(TWeb.RadListBox inputControl, object source, string textField, string valueField, string topOption, string preselectedValue)
        {
            inputControl.DataSource = source;
            inputControl.DataTextField = textField;
            inputControl.DataValueField = valueField;
            inputControl.DataBind();

            // if the consumer provided the filter - apply it to the list items
            //if (inputControl.Items.Count > 0)
            //{
            //    for (int index = inputControl.Items.Count - 1; index >= 0; index--)
            //    {
            //        TWeb.RadListBoxItem listItem = inputControl.Items[index];

            //            if (inputControl.Items.Contains(listItem))
            //            {
            //                inputControl.Items.Remove(listItem);
            //            }
            //    }
            //}

            //if (topOption != null && topOption.Length > 0)
            //    inputControl.Items.Insert(0, new TWeb.RadListBoxItem(topOption, "-1"));

            if (preselectedValue != null && preselectedValue.Length > 0)
                SafeLisBoxtControlSelect(inputControl, preselectedValue);

            SetListItemsBackground(inputControl);

        }
        public static void SafeLisBoxtControlSelect(TWeb.RadListBox inputControl, object preselectedValue)
        {
            //string newValue = preselectedValue.ToString();

            //if (inputControl.Items.IndexOf(inputControl.Items[newValue) != -1)
            //{
            //    inputControl.ClearSelection();
            //    inputControl.SelectedValue = newValue;
            //}
            //else
            //{
            //    inputControl.ClearSelection();
            //}
        }
        public static void SetListItemsBackground(TWeb.RadListBox inputControl)
        {
            for (int i = 0; i < inputControl.Items.Count; i++)
            {
                if ((i % 2) == 0)
                {
                    //inputControl.Items[i].Attributes.Add("style", "background:lightblue");
                    inputControl.Items[i].Attributes.Add("style", "background:#C8C8C8");
                }
            }
        }
        public static void BindASPListBoxControlWithBackground(ListBox inputControl, object source, string textField, string valueField, string topOption, string preselectedValue)
        {
            inputControl.DataSource = source;
            inputControl.DataTextField = textField;
            inputControl.DataValueField = valueField;
            inputControl.DataBind();


            SetASPListItemsBackground(inputControl);

        }
        public static void SetASPListItemsBackground(ListBox inputControl)
        {
            for (int i = 0; i < inputControl.Items.Count; i++)
            {
                if ((i % 2) == 0)
                {
                    //inputControl.Items[i].Attributes.Add("style", "background:lightblue");
                    inputControl.Items[i].Attributes.Add("style", "background:#C8C8C8");
                }
            }
        }
        public static void SetDropdownListItemsBackground(TWeb.RadComboBox inputControl)
        {
            for (int i = 0; i < inputControl.Items.Count; i++)
            {
                if ((i % 2) == 0)
                {
                    //inputControl.Items[i].Attributes.Add("style", "background:lightblue");
                    inputControl.Items[i].Attributes.Add("style", "background:#C8C8C8");
                }
            }
        }

        public static void SafeListControlSelect(TWeb.RadComboBox inputControl, object preselectedValue)
        {
            string newValue = preselectedValue.ToString();

            if (inputControl.Items.IndexOf(inputControl.Items.FindItemByValue(newValue)) != -1)
            {
                inputControl.ClearSelection();
                inputControl.SelectedValue = newValue;
            }
            else
            {
                inputControl.ClearSelection();
            }
        }

        #endregion


        #region [ List Control ]
        public static int GetDropdownValue(DropDownList dropdown)
        {
            return GetDropdownValue(dropdown, "-1");
        }

        public static int GetDropdownValue(DropDownList dropdown, string defaultValue)
        {
            return int.Parse(dropdown.SelectedValue == defaultValue ? defaultValue : dropdown.SelectedValue);
        }
        #endregion

        #region [ RadComboBox ]
        public static int GetDropdownValue(TWeb.RadComboBox dropdown)
        {
            return GetDropdownValue(dropdown, "-1");
        }

        public static int GetDropdownValue(TWeb.RadComboBox dropdown, string defaultValue)
        {
            return int.Parse(dropdown.SelectedValue == defaultValue ? defaultValue : dropdown.SelectedValue);
        }
        #endregion

        public static void SafeListControlSelect(ListControl inputControl, object preselectedValue)
        {
            string newValue = preselectedValue.ToString();

            if (inputControl.Items.IndexOf(inputControl.Items.FindByValue(newValue)) != -1)
                inputControl.SelectedValue = newValue;
            else
                inputControl.ClearSelection();
        }

        public static void SafeTextBoxAssign(TextBox inputTextBox, string value)
        {
            string newValue = string.Empty;

            //Encoding the text entered into Textbox to prevent Cross Site Scripting
            if (!string.IsNullOrEmpty(value))
            {
                //newValue = System.Web.HttpUtility.HtmlEncode(value);
                newValue = value;

            }
            else
            {
                newValue = string.Empty;
            }
            inputTextBox.Text = newValue;
        }

        public static bool CheckForSQLInjection(string textToCheck)
        {
            bool returnValue;
            if (DatabaseUtility.DetectSqlInjection(textToCheck))
                returnValue = true;
            else
                returnValue = false;

            return returnValue;
        }

        #region Export Telerik Reports to PDF & UTF8 Formats

        public static void ExportToPDF(string fileName, TReports.Report reportToExport)
        {
            TRProcessing.ReportProcessor reportProcessor = new TRProcessing.ReportProcessor();
            Hashtable deviceInfo = new Hashtable();
            deviceInfo["FontEmbedding"] = "Subset";
            TRProcessing.RenderingResult result = reportProcessor.RenderReport("PDF", reportToExport, deviceInfo);

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = result.MimeType;
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.Private);
            HttpContext.Current.Response.Expires = -1;
            HttpContext.Current.Response.Buffer = true;

            HttpContext.Current.Response.AddHeader("Content-Disposition",
                               string.Format("{0};FileName=\"{1}\"",
                                             "attachment",
                                             fileName));

            HttpContext.Current.Response.BinaryWrite(result.DocumentBytes);
            HttpContext.Current.Response.End();
        }
        public static void ExportToDoc(string fileName, TReports.Report reportToExport)
        {
            TRProcessing.ReportProcessor reportProcessor = new TRProcessing.ReportProcessor();
            Hashtable deviceInfo = new Hashtable();
            deviceInfo["FontEmbedding"] = "Subset";
            TRProcessing.RenderingResult result = reportProcessor.RenderReport("DOCX", reportToExport, deviceInfo);

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = result.MimeType;
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.Private);
            HttpContext.Current.Response.Expires = -1;
            HttpContext.Current.Response.Buffer = true;

            HttpContext.Current.Response.AddHeader("Content-Disposition",
                               string.Format("{0};FileName=\"{1}\"",
                                             "attachment",
                                             fileName));

            HttpContext.Current.Response.BinaryWrite(result.DocumentBytes);
            HttpContext.Current.Response.End();
        }

        public static void ExportToUTF8(string fileName, string UTF8String)
        {    //rolled back to 7

            byte[] encodedText = Encoding.UTF8.GetBytes(UTF8String);

            byte[] buffer; 

            using (var memoryStream = new System.IO.MemoryStream())
            {
                //buffer = Encoding.Default.GetBytes(UTF8String);
                buffer = Encoding.UTF8.GetBytes(UTF8String); 

                memoryStream.Write(buffer, 0, buffer.Length);
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + fileName); 
                HttpContext.Current.Response.AddHeader("Content-Length", memoryStream.Length.ToString());
                
                //HttpContext.Current.Response.ContentType = "text/plain";
               
                HttpContext.Current.Response.ContentType = "text/html; charset=utf-8";
                HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;

                HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.Private);
                HttpContext.Current.Response.Expires = -1;
                HttpContext.Current.Response.Buffer = true;

                HttpContext.Current.Response.AddHeader("Content-Disposition",
                                   string.Format("{0};FileName=\"{1}\"",
                                                 "attachment",
                                                 fileName));

                memoryStream.WriteTo(HttpContext.Current.Response.OutputStream); 
            }
            HttpContext.Current.Response.End();
            Process.Start("notepad.exe", fileName);  
        }
            
        #endregion


        #region Export from Datatable to Excel
        public static void ExportDataTableToExcelEPP(DataTable dt, string fileName,string sheetname)
        {
            
            string strfn = string.Format("attachment; filename={0}", fileName);

            using (ExcelPackage package = new ExcelPackage())
            {
                if (string.IsNullOrEmpty(sheetname))
                {
                    sheetname = "Sheet1";
                }
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                worksheet.Cells["A1"].LoadFromDataTable(dt, true);

                for (int i = 1; i <= dt.Columns.Count; i++)
                {
                    worksheet.Column(i).AutoFit();

                    if (dt.Columns[i - 1].DataType == System.Type.GetType("System.DateTime"))
                    {
                        worksheet.Column(i).Style.Numberformat.Format = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                    }
                }
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                HttpContext.Current.Response.AddHeader("Content-Disposition", strfn);
                
                HttpContext.Current.Response.BinaryWrite(package.GetAsByteArray());
                HttpContext.Current.Response.End();
               
               
            }

        }

        public static void ExportDataTableToExcel(DataTable DT, string fileName)
        {
            HttpContext.Current.Response.Clear();
            string strfn = string.Format("attachment;filename={0}", fileName);
            HttpContext.Current.Response.AddHeader("content-disposition", strfn);
            HttpContext.Current.Response.Charset = "";


           
            HttpContext.Current.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
           

            string tab = "";
            foreach (DataColumn dc in DT.Columns)
            {
                HttpContext.Current.Response.Write(tab + dc.ColumnName.Replace("\n", "").Replace("\t", ""));
                tab = "\t";
            }
            HttpContext.Current.Response.Write("\n");

            foreach (DataRow dr in DT.Rows)
            {
                tab = "";
                for (int i = 0; i < DT.Columns.Count; i++)
                {
                    HttpContext.Current.Response.Write(tab + dr[i].ToString().Replace("\n", "").Replace("\t", ""));
                    tab = "\t";
                }
                HttpContext.Current.Response.Write("\n");
            }
            HttpContext.Current.Response.Flush ();
            HttpContext.Current.Response.Close ();
        }
        public static void ExportDataTableToText(DataTable DT, string fileName)
        {
            HttpContext.Current.Response.Clear();

            HttpContext.Current.Response.ContentType = "application/vnd.text";

            HttpContext.Current.Response.AddHeader("Content-Disposition",
                               string.Format("{0};FileName=\"{1}\"",
                                             "attachment",
                                             fileName));
            string tab = "";
            foreach (DataColumn dc in DT.Columns)
            {
                HttpContext.Current.Response.Write(tab + dc.ColumnName.Replace("\n", "").Replace(",", " "));
                tab = ",";
            }
            HttpContext.Current.Response.Write("\n");

            foreach (DataRow dr in DT.Rows)
            {
                tab = "";
                for (int i = 0; i < DT.Columns.Count; i++)
                {
                    HttpContext.Current.Response.Write(tab + dr[i].ToString().Replace("\n", "").Replace(",", " "));
                    tab = ",";
                }
                HttpContext.Current.Response.Write("\n");
            }
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.Close();
        }
       #endregion

        #region ConverList To DataTable
        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable();

            foreach (PropertyDescriptor prop in properties)

                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            foreach (T item in data)
            {

                DataRow row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)

                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;

                table.Rows.Add(row);

            }

            return table;

        }

        #endregion
    }
}
