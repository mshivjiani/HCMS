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
using HCMS.Business.Lookups.Collections;

namespace HCMS.Business.Lookups
{
    /// <summary>
    /// PayPlan Business Object
    /// </summary>
    [Serializable]
    public class PayPlan : BusinessBase
    {
        #region Private Members

        private int _payPlanID = -1;
        private string _payPlanAbbrev = string.Empty;
        private string _payPlanTitle = string.Empty;
        private string _payPlanDescription = string.Empty;
        private bool? _inUse = null;

        #endregion

        #region Properties

        public int PayPlanID
        {
            get
            {
                return this._payPlanID;
            }
            set
            {
                this._payPlanID = value;
            }
        }

        public string PayPlanAbbrev
        {
            get
            {
                return this._payPlanAbbrev;
            }
            set
            {
                this._payPlanAbbrev = value;
            }
        }

        public string PayPlanTitle
        {
            get
            {
                return this._payPlanTitle;
            }
            set
            {
                this._payPlanTitle = value;
            }
        }

        public string PayPlanDescription
        {
            get
            {
                return this._payPlanDescription;
            }
            set
            {
                this._payPlanDescription = value;
            }
        }
        public bool? InUse
        {
            get { return this._inUse; }
            set { this._inUse = value; }
        }
        #endregion

        #region Constructors

        public PayPlan(DataRow singleRowData)
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

        protected virtual void FillObjectFromRowData(DataRow returnRow)
        {
            DataColumnCollection columns = returnRow.Table.Columns;
            this._payPlanID = (int)returnRow["PayPlanID"];
            this._payPlanAbbrev = returnRow["PayPlanAbbrev"].ToString();
            this._payPlanTitle = returnRow["PayPlanTitle"].ToString();

            if (returnRow["PayPlanDescription"] != DBNull.Value)
                this._payPlanDescription = returnRow["PayPlanDescription"].ToString();

            if (columns.Contains("InUse"))
            {
                if (returnRow["InUse"] != DBNull.Value)
                {
                    this._inUse  = (bool)returnRow["InUse"];
                }
            }
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
            return "PayPlanID:" + PayPlanID.ToString();
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
            PayPlan PayPlanobj = obj as PayPlan;

            return (PayPlanobj == null) ? false : (this.PayPlanID == PayPlanobj.PayPlanID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return PayPlanID.GetHashCode();
        }
        #endregion

        #region Collection Helper Methods

        internal static PayPlanCollection GetCollection(DataTable dataItems)
        {
            PayPlanCollection listCollection = new PayPlanCollection();
            PayPlan current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new PayPlan(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a PayPlan collection from a null data table.");

            return listCollection;
        }

        #endregion

        #region Collection Methods

        public SeriesCollection GetSeries()
        {
            SeriesCollection childDataCollection = null;

            if (base.ValidateKeyField(this._payPlanID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetSeriesByPayPlanID", this._payPlanID);

                    // fill collection list
                    childDataCollection = Series.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        #endregion
    }
}

