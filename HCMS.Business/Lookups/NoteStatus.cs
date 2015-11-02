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
    /// NoteStatus Business Object
    /// </summary>
    [Serializable]
    public class NoteStatus : BusinessBase
    {
        #region Private Members

        private int _noteStatusID = -1;
        private string _noteStatus = string.Empty;

        #endregion

        #region Properties

        public int NoteStatusID
        {
            get
            {
                return this._noteStatusID;
            }
            set
            {
                this._noteStatusID = value;
            }
        }

        public string NoteStatusName
        {
            get
            {
                return this._noteStatus;
            }
            set
            {
                this._noteStatus = value;
            }
        }

        #endregion

        #region Constructors

        public NoteStatus(DataRow singleRowData)
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
            this._noteStatusID = (int)returnRow["NoteStatusID"];
            this._noteStatus = returnRow["NoteStatus"].ToString();
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
            return "NoteStatusID:" + NoteStatusID.ToString();
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
            NoteStatus NoteStatusobj = obj as NoteStatus;

            return (NoteStatusobj == null) ? false : (this.NoteStatusID == NoteStatusobj.NoteStatusID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return NoteStatusID.GetHashCode();
        }
        #endregion

        #region Collection Helper Methods

        internal static List<NoteStatus> GetCollection(DataTable dataItems)
        {
            List<NoteStatus> listCollection = new List<NoteStatus>();
            NoteStatus current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new NoteStatus(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a NoteStatus collection from a null data table.");

            return listCollection;
        }

        #endregion

    }
}

