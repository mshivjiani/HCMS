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
    /// SODParagraphOptions Business Object
    /// </summary>
    [Serializable]
    public class SODParagraphOptions : BusinessBase
    {
        #region Private Members

        private int _sODParagraphOptionID = -1;
        private string _sODParagraphOptionName = string.Empty;
        private string _sODParagraphOptionText = string.Empty;

        #endregion

        #region Properties

        public int SODParagraphOptionID
        {
            get
            {
                return this._sODParagraphOptionID;
            }
            set
            {
                this._sODParagraphOptionID = value;
            }
        }

        public string SODParagraphOptionName
        {
            get
            {
                return this._sODParagraphOptionName;
            }
            set
            {
                this._sODParagraphOptionName = value;
            }
        }

        public string SODParagraphOptionText
        {
            get
            {
                return this._sODParagraphOptionText;
            }
            set
            {
                this._sODParagraphOptionText = value;
            }
        }

        #endregion

        #region Constructors

        public SODParagraphOptions(DataRow singleRowData)
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
            this._sODParagraphOptionID = (int)returnRow["SODParagraphOptionID"];
            this._sODParagraphOptionName = returnRow["SODParagraphOptionName"].ToString();
            this._sODParagraphOptionText = returnRow["SODParagraphOptionText"].ToString();
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
            return "SODParagraphOptionID:" + SODParagraphOptionID.ToString();
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
            SODParagraphOptions SODParagraphOptionsobj = obj as SODParagraphOptions;

            return (SODParagraphOptionsobj == null) ? false : (this.SODParagraphOptionID == SODParagraphOptionsobj.SODParagraphOptionID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return SODParagraphOptionID.GetHashCode();
        }
        #endregion

        #region Collection Helper Methods

        internal static List<SODParagraphOptions> GetCollection(DataTable dataItems)
        {
            List<SODParagraphOptions> listCollection = new List<SODParagraphOptions>();
            SODParagraphOptions current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new SODParagraphOptions(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a SODParagraphOptions collection from a null data table.");

            return listCollection;
        }

        #endregion

    }
}

