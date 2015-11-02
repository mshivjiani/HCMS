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

namespace HCMS.Business.JQ
{
	/// <summary>
	/// JQFactor Business Object
	/// </summary>
	[Serializable]
    public class JQFactor : JQCommonBase
	{
	    #region Private Members
	
		private long _JQFactorID  = -1;
		private int _JQFactorTypeID  = -1;
        private string _JQFactorTypeName = string.Empty;
		private int _JQFactorNo  = -1;
		private string _JQFactorTitle  = string.Empty;
		private string _JQFactorInstruction  = string.Empty;
		private bool _isSF  = false;
		private long _JQID  = -1;
		private long _KSAID  = -1;
        private long _JADutyKSAID = -1;
        private int _QualificationID = -1;
        private int _QualificationTypeID = -1;
        private bool _IsFinalKSA = false;
        private int? _ImportanceID;
        private int? _NeedAtEntryID;
        private int? _DistinguishingValueScaleID;
        private string _QualificationName = string.Empty;
        private string _QualificationTypeName = string.Empty;
        private string _ImportanceName = string.Empty;
        private string _NeedAtEntryName = string.Empty;
        private string _DistinguishingValueScaleName = string.Empty;
        private int? _TotalScore;
        private long _JAID=-1;
        private string _KSAText = string.Empty;

			
		#endregion
	
	    #region Properties
	
	    public long JQFactorID
	    {
		    get
		    {
			    return this._JQFactorID;
		    }
		    set
		    {
			    this._JQFactorID = value;
		    }
	    }
	
	    public int JQFactorTypeID
	    {
		    get
		    {
			    return this._JQFactorTypeID;
		    }
		    set
		    {
			    this._JQFactorTypeID = value;
		    }
	    }

        public string JQFactorTypeName
        {
            get
            {
                return this._JQFactorTypeName;
            }
        }

	    public int JQFactorNo
	    {
		    get
		    {
			    return this._JQFactorNo;
		    }
		    set
		    {
			    this._JQFactorNo = value;
		    }
	    }
	
	    public string JQFactorTitle
	    {
		    get
		    {
			    return this._JQFactorTitle;
		    }
		    set
		    {
			    this._JQFactorTitle = value;
		    }
	    }
	
	    public string JQFactorInstruction
	    {
		    get
		    {
			    return this._JQFactorInstruction;
		    }
		    set
		    {
			    this._JQFactorInstruction = value;
		    }
	    }
	
	    public bool IsSF
	    {
		    get
		    {
			    return this._isSF;
		    }
		    set
		    {
			    this._isSF = value;
		    }
	    }
	
	    public long JQID
	    {
		    get
		    {
			    return this._JQID;
		    }
		    set
		    {
			    this._JQID = value;
		    }
	    }
	
	    public long KSAID
	    {
		    get
		    {
			    return this._KSAID;
		    }
		    set
		    {
			    this._KSAID = value;
		    }
	    }

        public long JADutyKSAID
        {
            get { return _JADutyKSAID; }
            set { _JADutyKSAID = value; }
        }
        // added these properties to keep in-synch with JQFactorEntity class below and JQManager methods
        public int CreatedByID { get; set; }
        public string CreatedByName { get; set; }
        public DateTime? CreateDate { get; set; }
        public int UpdatedByID { get; set; }
        public string UpdatedByName { get; set; }
        public DateTime? UpdateDate { get; set; }


        public int QualificationID { get {return this._QualificationID  ;} set { this._QualificationID =value;} }
        public int QualificationTypeID { get { return this._QualificationTypeID; } set { this._QualificationTypeID = value; } }
        public bool IsFinalKSA { get { return this._IsFinalKSA; } set { this._IsFinalKSA = value; } }
        public int? ImportanceID { get { return this._ImportanceID; } set { this._ImportanceID = value; } }
        public int? NeedAtEntryID { get { return this._NeedAtEntryID; } set { this._NeedAtEntryID = value; } }
        public int? DistinguishingValueScaleID { get { return this._DistinguishingValueScaleID; } set { this._DistinguishingValueScaleID = value; } }
        public string QualificationName { get { return this._QualificationName; } set { this._QualificationName = value; } }
        public string QualificationTypeName { get { return this._QualificationTypeName; } set { this._QualificationTypeName = value; } }
        public string ImportanceName { get { return this._ImportanceName; } set { this._ImportanceName = value; } }
        public string NeedAtEntryName { get { return this._NeedAtEntryName; } set { this._NeedAtEntryName = value; } }
        public string DistinguishingValueScaleName { get { return this._DistinguishingValueScaleName; } set { this._DistinguishingValueScaleName = value; } }
        public int? TotalScore { get { return this._TotalScore; } set { this._TotalScore = value; } }
        public long JAID { get { return this._JAID; } set { this._JAID = value; } }
        public string KSAText { get { return this._KSAText; } set { this._KSAText = value; } }
	
		#endregion
	
	    #region Constructors
	
	    public JQFactor ()
	    {
		    // Empty Constructor
	    }

        public JQFactor(JQFactorEntity loadByEntity)
        {
            try
            {
                // allows conversion from JQFactorEntity to JQFactor
                this._JQFactorID = loadByEntity.ID;
                this._JQFactorTypeID = loadByEntity.FactorTypeID;
                this._JQFactorNo = loadByEntity.FactorNo;
                this._JQFactorTitle = loadByEntity.Title;
                this._JQFactorInstruction = loadByEntity.Instruction;
                this._isSF = loadByEntity.IsSF;
                this._JQID = loadByEntity.JQID;
                this._KSAID = loadByEntity.KSAID;
                this.CreatedByID = loadByEntity.CreatedByID;
                this.CreatedByName = loadByEntity.CreatedByName;
                this.CreateDate = loadByEntity.CreateDate;
                this.UpdatedByID = loadByEntity.UpdatedByID;
                this.UpdatedByName = loadByEntity.UpdatedByName;
                this.UpdateDate = loadByEntity.UpdateDate;
                this.JADutyKSAID = loadByEntity.JADutyKSAID;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
		
	    public JQFactor (int loadByID)
	    {
		    // Load Object by ID
		    DataTable returnTable;
		    try
            {
                returnTable = ExecuteDataTable("spr_GetJQFactorByID", loadByID);
			    loadData(returnTable);
		    }
            catch (Exception ex)
            {
                HandleException(ex);
             }
	    }	
	
	    public JQFactor (DataRow singleRowData)
	    {
		    // Load Object by dataRow
		    try
            {
                this.FillObjectFromRowData (singleRowData);
		    }
            catch (Exception ex)
            {
                HandleException(ex);
             }
	    }	
	
	    #endregion
	
	    #region Constructor Helper Methods
	
	    private void loadData (DataTable returnTable)
	    {
		    if (returnTable.Rows.Count > 0) 
		    {
			    DataRow returnRow = returnTable.Rows[0];
			    this.FillObjectFromRowData(returnRow);
		    }
	    }
	
	    protected virtual void FillObjectFromRowData (DataRow returnRow)
	    {
            DataColumnCollection columns = returnRow.Table.Columns;
            if (returnRow["JQFactorID"] != DBNull.Value)
			    this._JQFactorID = (long) returnRow["JQFactorID"];

            if (returnRow["JQFactorTypeID"] != DBNull.Value)
            {
                this._JQFactorTypeID = (int)returnRow["JQFactorTypeID"];

                if (returnRow["FactorType"] != DBNull.Value)
                    this._JQFactorTypeName = returnRow["FactorType"].ToString();
            }

            if (returnRow["JQFactorNo"] != DBNull.Value)
			    this._JQFactorNo = (int) returnRow["JQFactorNo"];

            if (returnRow["JQFactorTitle"] != DBNull.Value)
			    this._JQFactorTitle = returnRow["JQFactorTitle"].ToString();

            if (returnRow["JQFactorInstruction"] != DBNull.Value)
			    this._JQFactorInstruction = returnRow["JQFactorInstruction"].ToString();
				
		    if (returnRow["IsSF"] != DBNull.Value)
			    this._isSF = (bool) returnRow["IsSF"];

            if (returnRow["JQID"] != DBNull.Value)
			    this._JQID = (long) returnRow["JQID"];
				
		    if (returnRow["KSAID"] != DBNull.Value)
			    this._KSAID = (long) returnRow["KSAID"];

            if (returnRow["JADutyKSAID"] != DBNull.Value)
                this._JADutyKSAID = (long)returnRow["JADutyKSAID"];

            if (returnRow["CreatedByID"] != DBNull.Value)
                this.CreatedByID = (int)returnRow["CreatedByID"];

            if (returnRow["CreatedByName"] != DBNull.Value)
                this.CreatedByName = returnRow["CreatedByName"].ToString();

            if (returnRow["CreateDate"] != DBNull.Value)
                this.CreateDate =  DateTime.Parse(returnRow["CreateDate"].ToString());

            if (returnRow["UpdatedByID"] != DBNull.Value)
                this.UpdatedByID = (int)returnRow["UpdatedByID"];

            if (returnRow["UpdatedByName"] != DBNull.Value)
                this.UpdatedByName = returnRow["UpdatedByName"].ToString();

            if (returnRow["UpdateDate"] != DBNull.Value)
                this.UpdateDate =  DateTime.Parse(returnRow["UpdateDate"].ToString());


            if (columns.Contains("QualificationID"))
            {
                if (returnRow["QualificationID"] != DBNull.Value)
                    this._QualificationID = (int)returnRow["QualificationID"];
            }

            if (columns.Contains("QualificationName"))
            {
                if (returnRow["QualificationName"] != DBNull.Value)
                    this._QualificationName = (string)returnRow["QualificationName"];
            }

            if (columns.Contains("QualificationTypeID"))
            {
                if (returnRow["QualificationTypeID"] != DBNull.Value)
                    this._QualificationTypeID = (int)returnRow["QualificationTypeID"];
            }
            if (columns.Contains("QualificationTypeName"))
            {
                if (returnRow["QualificationTypeName"] != DBNull.Value)
                    this._QualificationTypeName = (string)returnRow["QualificationTypeName"];
            }

            if (columns.Contains("ImportanceName"))
            {
                if (returnRow["ImportanceName"] != DBNull.Value)
                    this._ImportanceName  = (string)returnRow["ImportanceName"];
            }

            if (columns.Contains("NeedAtEntryName"))
            {
                if (returnRow["NeedAtEntryName"] != DBNull.Value)
                    this._NeedAtEntryName = (string)returnRow["NeedAtEntryName"];
            }

            if (columns.Contains("DistinguishingValueScaleName"))
            {
                if (returnRow["DistinguishingValueScaleName"] != DBNull.Value)
                    this._DistinguishingValueScaleName = (string)returnRow["DistinguishingValueScaleName"];
            }

            if (columns.Contains("DistinguishingValueScaleName"))
            {
                if (returnRow["DistinguishingValueScaleName"] != DBNull.Value)
                    this._DistinguishingValueScaleName = (string)returnRow["DistinguishingValueScaleName"];
            }


            if (columns.Contains("ImportanceID"))
            {
                if (returnRow["ImportanceID"] != DBNull.Value)
                    this._ImportanceID = (int)returnRow["ImportanceID"];
            }

            if (columns.Contains("NeedAtEntryID"))
            {
                if (returnRow["NeedAtEntryID"] != DBNull.Value)
                    this._NeedAtEntryID = (int)returnRow["NeedAtEntryID"];
            }

            if (columns.Contains("DistinguishingValueScaleID"))
            {
                if (returnRow["DistinguishingValueScaleID"] != DBNull.Value)
                    this._DistinguishingValueScaleID = (int)returnRow["DistinguishingValueScaleID"];
            }
            if (columns.Contains("TotalScore"))
            {
                if (returnRow["TotalScore"] != DBNull.Value)
                    this._TotalScore = (int)returnRow["TotalScore"];
            }

            if (columns.Contains("JAID"))
            {
                if (returnRow["JAID"] != DBNull.Value)
                    this._JAID  = (long)returnRow["JAID"];
            }

            if (columns.Contains("KSAText"))
            {
                if (returnRow["KSAText"] != DBNull.Value)
                    this._KSAText = (string)returnRow["KSAText"];
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
            return "JQFactorID:" + JQFactorID.ToString();
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
           JQFactor JQFactorobj = obj as JQFactor ;
			
            return (JQFactorobj == null) ? false : (this.JQFactorID==JQFactorobj.JQFactorID );
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
			return JQFactorID.GetHashCode();
        }

	    #endregion
	
	    #region General Methods

        // disabled this method since is not being used anywhere in the system and it adds more overhead to this object
        //public void Add()
        //{
        //    DbCommand commandWrapper = GetDbCommand("spr_AddJobQuestionnaireFactor");

        //    try
        //    {
        //        SqlParameter returnParam = new SqlParameter("@JQFactorID", SqlDbType.Int);
        //        returnParam.Direction = ParameterDirection.Output;

        //        // get the new JQFactorID of the record
        //        commandWrapper.Parameters.Add(returnParam);

        //        if (this._JQFactorTypeID == -1)
        //            commandWrapper.Parameters.Add(new SqlParameter("@JQFactorTypeID", DBNull.Value));
        //        else
        //            commandWrapper.Parameters.Add(new SqlParameter("@JQFactorTypeID", this._JQFactorTypeID));

        //        if (string.IsNullOrWhiteSpace(this._JQFactorTitle))
        //            commandWrapper.Parameters.Add(new SqlParameter("@JQFactorTitle", DBNull.Value));
        //        else
        //            commandWrapper.Parameters.Add(new SqlParameter("@JQFactorTitle", this._JQFactorTitle.Trim()));

        //        if (string.IsNullOrWhiteSpace(this._JQFactorInstruction))
        //            commandWrapper.Parameters.Add(new SqlParameter("@JQFactorInstruction", DBNull.Value));
        //        else
        //            commandWrapper.Parameters.Add(new SqlParameter("@JQFactorInstruction", this._JQFactorInstruction.Trim()));

        //        commandWrapper.Parameters.Add(new SqlParameter("@IsSF", this._isSF));

        //        if (this._JQID == -1)
        //            commandWrapper.Parameters.Add(new SqlParameter("@JQID", DBNull.Value));
        //        else
        //            commandWrapper.Parameters.Add(new SqlParameter("@JQID", this._JQID));

        //        if (this._KSAID == -1)
        //            commandWrapper.Parameters.Add(new SqlParameter("@KSAID", DBNull.Value));
        //        else
        //            commandWrapper.Parameters.Add(new SqlParameter("@KSAID", this._KSAID));

        //        if (this.CreatedByID == -1)
        //            commandWrapper.Parameters.Add(new SqlParameter("@CreatedByID", DBNull.Value));
        //        else
        //            commandWrapper.Parameters.Add(new SqlParameter("CreatedByID", this.CreatedByID));

        //        ExecuteNonQuery(commandWrapper);

        //        this._JQFactorID = (long)returnParam.Value;
        //    }
        //    catch (Exception ex)
        //    {
        //        HandleException(ex);
        //    }
        //}

        // disabled this method since is not being used anywhere in the system and it adds more overhead to this object
        //public void Update()
        //{

        //    if (base.ValidateKeyField(this._JQFactorID))
        //    {
        //        DbCommand commandWrapper = GetDbCommand("spr_UpdateJobQuestionnaireFactor");

        //        try
        //        {
        //            if (this._JQFactorID == -1)
        //                commandWrapper.Parameters.Add(new SqlParameter("@JQFactorID", DBNull.Value));
        //            else
        //                commandWrapper.Parameters.Add(new SqlParameter("@JQFactorID", this._JQFactorID));

        //            if (this._JQFactorTypeID == -1)
        //                commandWrapper.Parameters.Add(new SqlParameter("@JQFactorTypeID", DBNull.Value));
        //            else
        //                commandWrapper.Parameters.Add(new SqlParameter("@JQFactorTypeID", this._JQFactorTypeID));

        //            if (string.IsNullOrWhiteSpace(this._JQFactorTitle))
        //                commandWrapper.Parameters.Add(new SqlParameter("@JQFactorTitle", DBNull.Value));
        //            else
        //                commandWrapper.Parameters.Add(new SqlParameter("@JQFactorTitle", this._JQFactorTitle.Trim()));

        //            if (string.IsNullOrWhiteSpace(this._JQFactorInstruction))
        //                commandWrapper.Parameters.Add(new SqlParameter("@JQFactorInstruction", DBNull.Value));
        //            else
        //                commandWrapper.Parameters.Add(new SqlParameter("@JQFactorInstruction", this._JQFactorInstruction.Trim()));

        //            commandWrapper.Parameters.Add(new SqlParameter("@IsSF", this._isSF));

        //            commandWrapper.Parameters.Add(new SqlParameter("@UpdatedByID", this.UpdatedByID));

        //            ExecuteNonQuery(commandWrapper);
        //        }
        //        catch (Exception ex)
        //        {
        //            HandleException(ex);
        //        }
        //    }
        //}

        // disabled this method since is not being used anywhere in the system and it adds more overhead to this object
        //public void Delete()
        //{
        //    if (base.ValidateKeyField(this._JQFactorID))
        //    {
        //        try
        //        {
        //            ExecuteNonQuery("spr_DeleteJQFactor", this._JQFactorID);
        //        }
        //        catch (Exception ex)
        //        {
        //            HandleException(ex);
        //        }
        //    }
        //}
		
	    #endregion
	                                                                                   
        #region Collection Methods

        internal static List<JQFactor> GetCollection(DataTable dataItems)
        {
            List<JQFactor> listCollection = new List<JQFactor>();
            JQFactor current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new JQFactor(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a JQFactor collection from a null data table.");

            return listCollection;
        }
		
            //public List<JQFactorItem> GetJQFactorItemByJQFactorItemID()
            //{
            //    List <JQFactorItem> childDataCollection = null;
            //    if (base.ValidateKeyField(this._JQFactorID))
            //    {
            //        try
            //        {
            //            DataTable dt = ExecuteDataTable("spr_GetJQFactorItemByJQFactorID", this._JQFactorID);
						
            //            // fill collection list
            //            childDataCollection = JQFactorItem.GetCollection(dt);
            //        }
            //        catch (Exception ex)
            //        {
            //            HandleException(ex);
            //        }
            //    }
				
            //    return childDataCollection;
            //}		
			
		#endregion
		
	    }

        public class JQFactorEntity
        {
            public long ID { get; set; }
            public int FactorTypeID { get; set; }
            public string FactorTypeName { get; set; }
            public int FactorNo { get; set; }
            public string Title { get; set; }
            public string Instruction { get; set; }
            public bool IsSF { get; set; }
            public long JQID { get; set; }
            public long KSAID { get; set; }
            public int CreatedByID { get; set; }
            public string CreatedByName { get; set; }
            public DateTime? CreateDate { get; set; }
            public int UpdatedByID { get; set; }
            public string UpdatedByName { get; set; }
            public DateTime? UpdateDate { get; set; }
            public int CountOfFactorQuestions { get; set; }
            public long JADutyKSAID { get; set; }
        }
}

