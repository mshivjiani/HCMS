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

namespace HCMS.Business.NarrativeFactor
{
    /// <summary>
    /// NarrativeFactor Business Object
    /// </summary>
    [Serializable]
    public class NarrativeFactor : BusinessBase,INarrativeFactor
    {
        #region Private Members

        private int _factorID = -1;
        private string _factorTitle = string.Empty;
        private string _factorDescription = string.Empty;
        private enumFactorFormatType _factorformattypeID = enumFactorFormatType.None;

        #endregion

        #region Properties

        public int FactorID
        {
            get
            {
                return this._factorID;
            }
            set
            {
                this._factorID = value;
            }
        }

        public string FactorTitle
        {
            get
            {
                return this._factorTitle;
            }
            set
            {
                this._factorTitle = value;
            }
        }

        public string FactorDescription
        {
            get
            {
                return this._factorDescription;
            }
            set
            {
                this._factorDescription = value;
            }
        }
        public enumFactorFormatType FactorFormatTypeID
        {
            get
            {
                return this._factorformattypeID;
            }
            set
            {
                this._factorformattypeID = value;
            }
        }
        #endregion

        #region Constructors

        public NarrativeFactor(DataRow singleRowData)
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
        public NarrativeFactor(enumFactorFormatType factorformattypeid)
        {

            // Load Object by ID
            DataTable returnTable;

            try
            {
                if ((factorformattypeid == enumFactorFormatType.Narrative) || (factorformattypeid == enumFactorFormatType.NarrativeSupervisory))
                {
                    returnTable = ExecuteDataTable("spr_GetNarrativeFactorLanguageByFactorFormatType", (int)factorformattypeid);
                    loadData(returnTable);
                }
                else
                {
                    throw new ApplicationException("NarrativeFactor object supports Narrative Factor Format types.");
                }
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
            this._factorID = (int)returnRow["FactorID"];
            this._factorTitle = returnRow["FactorTitle"].ToString();

            if (returnRow["FactorDescription"] != DBNull.Value)
                this._factorDescription = returnRow["FactorDescription"].ToString();
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
            return "NarrativeFactorID:" + FactorID.ToString();
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
            NarrativeFactor NarrativeFactorobj = obj as NarrativeFactor;

            return (NarrativeFactorobj == null) ? false : (this.FactorID == NarrativeFactorobj.FactorID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return FactorID.GetHashCode();
        }
        #endregion

        #region Collection Helper Methods

        internal static List<NarrativeFactor> GetCollection(DataTable dataItems)
        {
            List<NarrativeFactor> listCollection = new List<NarrativeFactor>();
            NarrativeFactor current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new NarrativeFactor(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a NarrativeFactor collection from a null data table.");

            return listCollection;
        }

        #endregion

    }
}

