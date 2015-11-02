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
    /// EvalCriteria Business Object
    /// </summary>
    [Serializable]
    public class EvalCriteria : BusinessBase
    {
        #region Private Members

        private int _evalCriteriaID = -1;
        private string _evalCriteriaDescription = string.Empty;

        #endregion

        #region Properties

        public int EvalCriteriaID
        {
            get
            {
                return this._evalCriteriaID;
            }
            set
            {
                this._evalCriteriaID = value;
            }
        }

        public string EvalCriteriaDescription
        {
            get
            {
                return this._evalCriteriaDescription;
            }
            set
            {
                this._evalCriteriaDescription = value;
            }
        }

        #endregion

        #region Constructors

        public EvalCriteria(DataRow singleRowData)
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
            this._evalCriteriaID = (int)returnRow["EvalCriteriaID"];

            if (returnRow["EvalCriteria"] != DBNull.Value)
                this._evalCriteriaDescription = returnRow["EvalCriteria"].ToString();
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
            return "EvalCriteriaID:" + EvalCriteriaID.ToString();
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
            EvalCriteria EvalCriteriaobj = obj as EvalCriteria;

            return (EvalCriteriaobj == null) ? false : (this.EvalCriteriaID == EvalCriteriaobj.EvalCriteriaID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return EvalCriteriaID.GetHashCode();
        }
        #endregion

        #region Collection Helper Methods

        internal static List<EvalCriteria> GetCollection(DataTable dataItems)
        {
            List<EvalCriteria> listCollection = new List<EvalCriteria>();
            EvalCriteria current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new EvalCriteria(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a EvalCriteria collection from a null data table.");

            return listCollection;
        }

        #endregion

    }
}

