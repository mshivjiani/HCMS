using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.ComponentModel;
using HCMS.Business.Base;



namespace HCMS.Business.Lookups
{
    /// <summary>
    /// KSA Business Object
    /// </summary>
    [Serializable]
    [DataObject]
    public class KSA : BusinessBase
    {
        #region Private Members

        private long _kSAID = -1;
        private string _kSAText = string.Empty;
        private bool? _active = null;

        #endregion

        #region Properties

        public long KSAID
        {
            get
            {
                return this._kSAID;
            }
            set
            {
                this._kSAID = value;
            }
        }

        public string KSAText
        {
            get
            {
                return this._kSAText;
            }
            set
            {
                this._kSAText = value;
            }
        }

        public bool? Active
        {
            get
            { return this._active; }
            set { this._active = value; }
        }
        #endregion

        #region Constructors

        public KSA()
        {
        }

        public KSA(DataRow singleRowData)
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

        public KSA(long loadByID)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetKSAByKSAID", loadByID);
                loadData(returnTable);
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
            DataColumnCollection columns = returnRow.Table.Columns;
            this._kSAID = (long)returnRow["KSAID"];
            this._kSAText = returnRow["KSAText"].ToString();

            if (columns.Contains("Active"))
            {
                if (returnRow["Active"] != DBNull.Value)
                {
                    this._active = (bool)returnRow["Active"];
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
            return "KSAID:" + KSAID.ToString();
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
            KSA KSAobj = obj as KSA;

            return (KSAobj == null) ? false : (this.KSAID == KSAobj.KSAID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return KSAID.GetHashCode();
        }
        #endregion

        #region Collection Helper Methods

        internal static List<KSA> GetCollection(DataTable dataItems)
        {
            List<KSA> listCollection = new List<KSA>();
            KSA current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new KSA(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a KSA collection from a null data table.");

            return listCollection;
        }

        #endregion

        #region General Methods
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public void Add()
        {
            DbCommand commandWrapper = GetDbCommand("spr_AddKSA");
            try
            {
                SqlParameter returnParam = new SqlParameter("@KSAID", SqlDbType.BigInt);
                returnParam.Direction = ParameterDirection.Output;
                commandWrapper.Parameters.Add(returnParam);

                commandWrapper.Parameters.Add(new SqlParameter("@KSAText", this._kSAText));
                commandWrapper.Parameters.Add(new SqlParameter("@Active", this._active));
                ExecuteNonQuery(commandWrapper);

                this._kSAID = (long)returnParam.Value;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        [DataObjectMethod(DataObjectMethodType.Update)]
        public void UpdateKSA()
        {
            DbCommand commandWrapper = GetDbCommand("spr_UpdateKSA");
            try
            {
                commandWrapper.Parameters.Add(new SqlParameter("@KSAID", this._kSAID));
                commandWrapper.Parameters.Add(new SqlParameter("@KSAText", this._kSAText));
                commandWrapper.Parameters.Add(new SqlParameter("@Active", this._active));
                ExecuteNonQuery(commandWrapper);
            }
            catch (Exception ex)
            {

                HandleException(ex);
            }
        }
        #endregion


        #region Static Methods
        public static DataTable staticKSA = null;
        public static DataTable dtStaticKSAdv = null;
        /// <summary>
        /// Gets subset of KSAs based on maximumrows
        /// </summary>
        /// <param name="startRowIndex">first row index</param>
        /// <param name="maximumRows">maximum number of rows to fetch</param>
        /// <param name="active">If passed null- ignores value in active field</param>
        /// <returns>List of KSAs</returns>
        /// 
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static DataTable GetKSAPaged(int startRowIndex, int maximumRows, bool? active)
        {
            DataTable dt = null;
            //List<KSA> pagedKSA = new List<KSA>();
            DbCommand commandWrapper = GetDbCommand("spr_GetKSAsPaged");
            try
            {
                commandWrapper.Parameters.Add(new SqlParameter("@startRowIndex", startRowIndex));
                commandWrapper.Parameters.Add(new SqlParameter("@maximumRows", maximumRows));
                if (active != null)
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@active", active));
                }

                dt = ExecuteDataTable(commandWrapper);
                //pagedKSA = GetCollection(dt);
                staticKSA = dt;
            }
            catch (Exception ex)
            {

                HandleException(ex);

            }

            return dt;

        }
        public static int KSATotalCount(int startRowIndex, int maximumRows, bool? active)
        {
            object[] parameterValues = new object[] { active };

            int count = (int)ExecuteScalar("spr_GetKSAsTotalCount", parameterValues);
            return count;
        }
        [DataObjectMethod(DataObjectMethodType.Update)]
        public static void UpdateKSA(long ksaID, string ksaText, bool? active)
        {
            KSA currentKSA = new KSA(ksaID);
            currentKSA.KSAText = ksaText;
            currentKSA.Active = active;
            currentKSA.UpdateKSA();
        }

        //Issue Id: 105
        //Author: Deepali Anuje
        //Date Fixed: 1/31/2012
        //Description: Admin: Inactivate a KSA didn't seem to work 
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static void AddKSA(long ksaID, string ksaText, bool? active)
        {
            KSA currentKSA = new KSA();
            currentKSA.KSAID = -1;
            currentKSA.KSAText = ksaText;
            currentKSA.Active = active;
            currentKSA.Add();
        }

       
        public static DataTable SearchKSAByAdmin(long? KSAID = null, int? SeriesID = null, int? GradeID = null, string Keyword = null)
        {
            DbCommand commandWrapper = GetDbCommand("spr_SearchKSAByAdmin");
            DataTable dt = new DataTable();

            try
            {
                const int defaultValue = -1;
                SetParameter<long>(commandWrapper, "@KSAID", KSAID, defaultValue);
                SetParameter<int>(commandWrapper, "@SeriesID", SeriesID, defaultValue);
                SetParameter<int>(commandWrapper, "@GradeID", GradeID, defaultValue);
                SetParameter<string>(commandWrapper, "@Keyword", Keyword, string.Empty);

                dt = ExecuteDataTable(commandWrapper);
                dtStaticKSAdv = dt;
                
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return dt;
        }
        

        public static int SelectKSATotalCount(int startRowIndex, int maximumRows)
        {

            int count = (int)ExecuteScalar("spr_GetKSATotalCount");
            return count;
        }

        #endregion
    }

}

