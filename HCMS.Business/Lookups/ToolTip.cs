using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

using HCMS.Business.Base;

namespace HCMS.Business.Lookups
{
    /// <summary>
    /// ToolTip Business Object
    /// </summary>
    [Serializable]
    public class ToolTip : BusinessBase
    {
        #region Private Members

        private long _toolTipID = -1;
        private string _toolTipCaption = string.Empty;
        private string _toolTipDescription = string.Empty;
        private string _toolTipScreen = string.Empty;

        #endregion

        #region Properties

        public long ToolTipID
        {
            get
            {
                return this._toolTipID;
            }
            set
            {
                this._toolTipID = value;
            }
        }

        public string ToolTipCaption
        {
            get
            {
                return this._toolTipCaption;
            }
            set
            {
                this._toolTipCaption = value;
            }
        }

        public string ToolTipDescription
        {
            get
            {
                return this._toolTipDescription;
            }
            set
            {
                this._toolTipDescription = value;
            }
        }

        public string ToolTipScreen
        {
            get { return this._toolTipScreen; }
            set { this._toolTipScreen = value; }
        }
        #endregion

        #region Constructors

        public ToolTip()
        {
            // Empty Constructor
        }

        public ToolTip(long loadByID)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetToolTipByID", loadByID); 
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public ToolTip(DataRow singleRowData)
        {
            // Load Object by dataRow
            try
            {
                this.FillObjectFromRowData(singleRowData);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        #endregion

        #region Constructor Helper Methods

        private void loadData(DataTable returnTable)
        {
            if (returnTable.Rows.Count > 0)
            {
                DataRow returnRow = returnTable.Rows[0];

                this.FillObjectFromRowData(returnRow);
            }
        }

        protected virtual void FillObjectFromRowData(DataRow returnRow)
        {
            this._toolTipID = (long)returnRow["ToolTipID"];
            this._toolTipCaption = returnRow["ToolTipCaption"].ToString();
            this._toolTipDescription = returnRow["ToolTipDescription"].ToString();
            this._toolTipScreen = returnRow["ToolTipScreen"].ToString();
        }

        #endregion

        #region ToXML Method

        ///<summary>
        /// Returns an XML String that represents the current object.
        ///</summary>
        public string ToXML()
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            using (StreamReader sr = new StreamReader(new MemoryStream()))
            {
                serializer.Serialize(sr.BaseStream, this);
                sr.BaseStream.Position = 0;
                return sr.ReadToEnd();
            }
        }

        #endregion ToXML Method

        #region ToString Method

        ///<summary>
        /// Returns a String that represents the current object.
        ///</summary>
        public override string ToString()
        {
            return "ToolTipID:" + ToolTipID.ToString();
        }

        #endregion ToString Method

        #region CompareMethods

        /// <summary>
        /// Determines whether the specified System.Object is equal to the current object.
        /// </summary>
        /// <param name="obj">The System.Object to compare with the current object.</param>
        /// <returns>Returns true if the specified System.Object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(Object obj)
        {
            ToolTip ToolTipobj = obj as ToolTip;

            return (ToolTipobj == null) ? false : (this.ToolTipID == ToolTipobj.ToolTipID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return ToolTipID.GetHashCode();
        }
        #endregion

        #region General Methods

        public void Add()
        {
            DbCommand commandWrapper = GetDbCommand("spr_AddToolTip");

            try
            {
                SqlParameter returnParam = new SqlParameter("@newToolTipID", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;

                // get the new ToolTipID of the record
                commandWrapper.Parameters.Add(returnParam);

                commandWrapper.Parameters.Add(new SqlParameter("@toolTipCaption", this._toolTipCaption.Trim()));
                commandWrapper.Parameters.Add(new SqlParameter("@toolTipDescription", this._toolTipDescription.Trim()));
                commandWrapper.Parameters.Add(new SqlParameter("@toolTipScreen", this._toolTipScreen.Trim()));
                ExecuteNonQuery(commandWrapper);

                this._toolTipID = (int)returnParam.Value;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public void Update()
        {
            if (base.ValidateKeyField(this._toolTipID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateToolTip");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@toolTipID", this._toolTipID));
                    commandWrapper.Parameters.Add(new SqlParameter("@toolTipCaption", this._toolTipCaption.Trim()));
                    commandWrapper.Parameters.Add(new SqlParameter("@toolTipDescription", this._toolTipDescription.Trim()));
                    commandWrapper.Parameters.Add(new SqlParameter("@toolTipScreen", this._toolTipScreen.Trim()));

                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        public void Delete()
        {
            if (base.ValidateKeyField(this._toolTipID))
            {
                try
                {
                    ExecuteNonQuery("spr_DeleteToolTip", this._toolTipID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        #endregion

        #region Collection Helper Methods

        internal static List<ToolTip> GetCollection(DataTable dataItems)
        {
            List<ToolTip> listCollection = new List<ToolTip>();
            ToolTip current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new ToolTip(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a ToolTip collection from a null data table.");

            return listCollection;
        }

        #endregion

        #region Collection Methods

        #endregion

    }

    [System.ComponentModel.DataObject]
    public class ToolTipDataSource
    {
        public List<ToolTip> GetObjects()
        {
            return LookupManager.GetAllToolTips();
        }
        public ToolTip GetByID(long toolTipID)
        {
            ToolTip toolTip = new ToolTip(toolTipID);
            return toolTip;
        }
    }
}

