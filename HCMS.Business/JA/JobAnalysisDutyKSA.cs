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

namespace HCMS.Business.JA
{
	/// <summary>
	/// JobAnalysisDutyKSA Business Object
	/// </summary>
	[Serializable]
	public class JobAnalysisDutyKSA : BusinessBase
	{
	    #region Private Members
	
		private long _JADutyKSAID  = -1;
		private long _JADutyID  = -1;
		private long _KSAID  = -1;
		private string _JAKSADescription  = string.Empty;
        private int _percentageOfTime = -1;
		private int _qualificationID  = -1;
        private string _qualificationName = string.Empty;
		private int _qualificationTypeID  = -1;
        private string _qualificationTypeName = string.Empty;
        private enumImportanceScale _importanceID = enumImportanceScale.None;
        private string _importanceName = string.Empty;
        private enumNeedAtEntryScale _needAtEntryID = enumNeedAtEntryScale.None;
        private string _needAtEntryName = string.Empty;
        private enumDistinguishingValueScale _distinguishingValueScaleID = enumDistinguishingValueScale.None;
        private string _distinguishingValueScaleName = string.Empty;
		private bool _isFinalKSA  = false;
        private int _totalScore = 0;
        private int _createdByID = -1;
        private DateTime _createDate = DateTime.MinValue;
        private int _updatedByID = -1;
        private DateTime _updateDate = DateTime.MinValue;

		#endregion
	
	    #region Properties
	
	    public long JADutyKSAID
	    {
		    get
		    {
			    return this._JADutyKSAID;
		    }
		    set
		    {
			    this._JADutyKSAID = value;
		    }
	    }
	
	    public long JADutyID
	    {
		    get
		    {
			    return this._JADutyID;
		    }
		    set
		    {
			    this._JADutyID = value;
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
	
	    public string JAKSADescription
	    {
		    get
		    {
			    return this._JAKSADescription;
		    }
		    set
		    {
			    this._JAKSADescription = value;
		    }
	    }

        public int PercentageOfTime
        {
            get
            {
                return this._percentageOfTime;
            }
        }
	
	    public int QualificationID
	    {
		    get
		    {
			    return this._qualificationID;
		    }
		    set
		    {
			    this._qualificationID = value;
		    }
	    }

        public string QualificationName
        {
            get
            {
                return this._qualificationName;
            }
        }
	
	    public int QualificationTypeID
	    {
		    get
		    {
			    return this._qualificationTypeID;
		    }
		    set
		    {
			    this._qualificationTypeID = value;
		    }
	    }

        public string QualificationTypeName
        {
            get
            {
                return this._qualificationTypeName;
            }
        }

        public enumImportanceScale ImportanceID
        {
            get
            {
                return this._importanceID;
            }
            set
            {
                this._importanceID = value;
            }
        }

        public string ImportanceName
        {
            get
            {
                return this._importanceName;
            }
        }

        public enumNeedAtEntryScale NeedAtEntryID
        {
            get
            {
                return this._needAtEntryID;
            }
            set
            {
                this._needAtEntryID = value;
            }
        }

        public string NeedAtEntryName
        {
            get
            {
                return this._needAtEntryName;
            }
        }

        public enumDistinguishingValueScale DistinguishingValueScaleID
        {
            get
            {
                return this._distinguishingValueScaleID;
            }
            set
            {
                this._distinguishingValueScaleID = value;
            }
        }

        public string DistinguishingValueScaleName
        {
            get
            {
                return this._distinguishingValueScaleName;
            }
        }

	    public bool IsFinalKSA
	    {
		    get
		    {
			    return this._isFinalKSA;
		    }
		    set
		    {
			    this._isFinalKSA = value;
		    }
	    }

        public int TotalScore
        {
            get
            {
                return this._totalScore;
            }
        }


        public int CreatedByID
        {
            get
            {
                return this._createdByID;
            }
            set
            {
                this._createdByID = value;
            }
        }

        public DateTime CreateDate
        {
            get
            {
                return this._createDate;
            }
            set
            {
                this._createDate = value;
            }
        }

        public int UpdatedByID
        {
            get
            {
                return this._updatedByID;
            }
            set
            {
                this._updatedByID = value;
            }
        }

        public DateTime UpdateDate
        {
            get
            {
                return this._updateDate;
            }
            set
            {
                this._updateDate = value;
            }
        }

	    #endregion
	
        #region Constructors
	
	    public JobAnalysisDutyKSA ()
	    {
		    // Empty Constructor
	    }
		
	    public JobAnalysisDutyKSA (long loadByID)
	    {
		    // Load Object by ID
		    DataTable returnTable;
		    try
            {
                returnTable = ExecuteDataTable("spr_GetJobAnalysisDutyKSAByID", loadByID);
			    loadData(returnTable);
		    }
            catch (Exception ex)
            {
                HandleException(ex);
             }
	    }	
	
	    public JobAnalysisDutyKSA (DataRow singleRowData)
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
            if (returnRow["JADutyKSAID"] != DBNull.Value)
			    this._JADutyKSAID = (long) returnRow["JADutyKSAID"];

            if (returnRow["JADutyID"] != DBNull.Value)
			    this._JADutyID = (long) returnRow["JADutyID"];

            if (returnRow["KSAID"] != DBNull.Value)
			    this._KSAID = (long) returnRow["KSAID"];

            if (returnRow["JAKSADescription"] != DBNull.Value)
			    this._JAKSADescription = returnRow["JAKSADescription"].ToString();

            if (columns.Contains("JAPercentageOfTime"))
            {
                if (returnRow["JAPercentageOfTime"] != DBNull.Value)
                    this._percentageOfTime = (int)returnRow["JAPercentageOfTime"];
            }

            if (returnRow["QualificationID"] != DBNull.Value)
			    this._qualificationID = (int) returnRow["QualificationID"];
            if (columns.Contains("QualificationName"))
            {
                if (returnRow["QualificationName"] != DBNull.Value)
                    this._qualificationName = returnRow["QualificationName"].ToString();
            }

            if (returnRow["QualificationTypeID"] != DBNull.Value)
			    this._qualificationTypeID = (int) returnRow["QualificationTypeID"];
            if (columns.Contains("QualificationTypeName"))
            {
                if (returnRow["QualificationTypeName"] != DBNull.Value)
                    this._qualificationTypeName = returnRow["QualificationTypeName"].ToString();
            }

            if (returnRow["ImportanceID"] != DBNull.Value)
            {
                int tempValue = (int)returnRow["ImportanceID"];

                if (Enum.IsDefined(typeof(enumImportanceScale), tempValue))
                    this._importanceID = (enumImportanceScale) tempValue;

                if (returnRow["ImportanceName"] != DBNull.Value)
                    this._importanceName = returnRow["ImportanceName"].ToString();    
            }

            if (returnRow["NeedAtEntryID"] != DBNull.Value)
            {
                int tempValue = (int)returnRow["NeedAtEntryID"];

                if (Enum.IsDefined(typeof(enumNeedAtEntryScale), tempValue))
                    this._needAtEntryID = (enumNeedAtEntryScale)tempValue;

                if (returnRow["NeedAtEntryName"] != DBNull.Value)
                    this._needAtEntryName = returnRow["NeedAtEntryName"].ToString();    
            }

            if (returnRow["DistinguishingValueScaleID"] != DBNull.Value)
            {
                int tempValue = (int)returnRow["DistinguishingValueScaleID"];

                if (Enum.IsDefined(typeof(enumDistinguishingValueScale), tempValue))
                    this._distinguishingValueScaleID = (enumDistinguishingValueScale)tempValue;

                if (returnRow["DistinguishingValueScaleName"] != DBNull.Value)
                    this._distinguishingValueScaleName = returnRow["DistinguishingValueScaleName"].ToString();    
            }

		    if (returnRow["IsFinalKSA"] != DBNull.Value)
			    this._isFinalKSA = (bool) returnRow["IsFinalKSA"];

            if (returnRow["TotalScore"] != DBNull.Value)
                this._totalScore = (int) returnRow["TotalScore"];
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
            return "JADutyKSAID:" + JADutyKSAID.ToString();
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
           JobAnalysisDutyKSA JobAnalysisDutyKSAobj = obj as JobAnalysisDutyKSA ;
			
            return (JobAnalysisDutyKSAobj == null) ? false : (this.JADutyKSAID==JobAnalysisDutyKSAobj.JADutyKSAID );
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
			return JADutyKSAID.GetHashCode();
        }
	    
        #endregion
	
	    #region General Methods
	
	    public void Add()
	    {
		    DbCommand commandWrapper = GetDbCommand("spr_AddJobAnalysisDutyKSA");
		
            try
            {
			    SqlParameter returnParam = new SqlParameter("@newJADutyKSAID", SqlDbType.Int);
			    returnParam.Direction = ParameterDirection.Output;

			    // get the new JADutyKSAID of the record
			    commandWrapper.Parameters.Add(returnParam);
			
                commandWrapper.Parameters.Add(new SqlParameter("@JADutyID", this._JADutyID));
                commandWrapper.Parameters.Add(new SqlParameter("@KSAID", this._KSAID));
                commandWrapper.Parameters.Add(new SqlParameter("@JAKSADescription", this._JAKSADescription.Trim()));
                commandWrapper.Parameters.Add(new SqlParameter("@qualificationID", this._qualificationID));
                commandWrapper.Parameters.Add(new SqlParameter("@qualificationTypeID", this._qualificationTypeID));

                if (this._importanceID == enumImportanceScale.None)
                    commandWrapper.Parameters.Add(new SqlParameter("@ImportanceID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@ImportanceID", (int) this._importanceID));

                if (this._needAtEntryID == enumNeedAtEntryScale.None)
                    commandWrapper.Parameters.Add(new SqlParameter("@NeedAtEntryID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@NeedAtEntryID", (int) this._needAtEntryID));

                if (this._distinguishingValueScaleID == enumDistinguishingValueScale.None)
                    commandWrapper.Parameters.Add(new SqlParameter("@DistinguishingValueScaleID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@DistinguishingValueScaleID", (int) this._distinguishingValueScaleID));

                commandWrapper.Parameters.Add(new SqlParameter("@isFinalKSA", this._isFinalKSA));

                
                commandWrapper.Parameters.Add(new SqlParameter("@userID", this.CreatedByID));

                ExecuteNonQuery(commandWrapper);
           
			    this._JADutyKSAID  = (int) returnParam.Value;
              }
            catch (Exception ex)
            {
                HandleException(ex);
             }
	    }
	
	    public void Update()
	    {
		    if (base.ValidateKeyField(this._JADutyKSAID))
		    {
			    DbCommand commandWrapper = GetDbCommand("spr_UpdateJobAnalysisDutyKSA");
			
			    try
			    {
                    commandWrapper.Parameters.Add(new SqlParameter("@JADutyKSAID", this._JADutyKSAID));
                    commandWrapper.Parameters.Add(new SqlParameter("@JADutyID", this._JADutyID));
                    commandWrapper.Parameters.Add(new SqlParameter("@KSAID", this._KSAID));
                    commandWrapper.Parameters.Add(new SqlParameter("@JAKSADescription", this._JAKSADescription.Trim()));
                    commandWrapper.Parameters.Add(new SqlParameter("@qualificationID", this._qualificationID));
                    commandWrapper.Parameters.Add(new SqlParameter("@qualificationTypeID", this._qualificationTypeID));

                    if (this._importanceID == enumImportanceScale.None)
                        commandWrapper.Parameters.Add(new SqlParameter("@ImportanceID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@ImportanceID", (int)this._importanceID));

                    if (this._needAtEntryID == enumNeedAtEntryScale.None)
                        commandWrapper.Parameters.Add(new SqlParameter("@NeedAtEntryID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@NeedAtEntryID", (int)this._needAtEntryID));

                    if (this._distinguishingValueScaleID == enumDistinguishingValueScale.None)
                        commandWrapper.Parameters.Add(new SqlParameter("@DistinguishingValueScaleID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@DistinguishingValueScaleID", (int)this._distinguishingValueScaleID));

                    commandWrapper.Parameters.Add(new SqlParameter("@isFinalKSA", this._isFinalKSA));
                    commandWrapper.Parameters.Add(new SqlParameter("@userID", this.UpdatedByID));

				    ExecuteNonQuery(commandWrapper);
			    }
			    catch (Exception ex)
			    {
				    HandleException(ex);
			    }
		    }
	    }

        public void UpdateScaleAndFinalInformation()
        {
            if (base.ValidateKeyField(this._JADutyKSAID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateJADutyKSAFinalFlag");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@JADutyKSAID", this._JADutyKSAID));
                    
                    if (this._importanceID == enumImportanceScale.None)
                        commandWrapper.Parameters.Add(new SqlParameter("@ImportanceID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@ImportanceID", (int)this._importanceID));

                    if (this._needAtEntryID == enumNeedAtEntryScale.None)
                        commandWrapper.Parameters.Add(new SqlParameter("@NeedAtEntryID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@NeedAtEntryID", (int)this._needAtEntryID));

                    if (this._distinguishingValueScaleID == enumDistinguishingValueScale.None)
                        commandWrapper.Parameters.Add(new SqlParameter("@DistinguishingValueScaleID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@DistinguishingValueScaleID", (int)this._distinguishingValueScaleID));

                    commandWrapper.Parameters.Add(new SqlParameter("@isFinalKSA", this._isFinalKSA));
                    commandWrapper.Parameters.Add(new SqlParameter("@userID", this.UpdatedByID));

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
		    if (base.ValidateKeyField(this._JADutyKSAID))
		    {
			    try
			    {
				    ExecuteNonQuery("spr_DeleteJobAnalysisDutyKSA", this._JADutyKSAID,this.UpdatedByID );
			    }
			    catch (Exception ex)
			    {
				    HandleException(ex);
			    }
		    }
	    }
		
	    #endregion
	
	    #region Collection Helper Methods
	
	    internal static List<JobAnalysisDutyKSA> GetCollection (DataTable dataItems)
	    {
		    List<JobAnalysisDutyKSA> listCollection = new List<JobAnalysisDutyKSA>();
		    JobAnalysisDutyKSA current = null;
		
		    if (dataItems != null)
		    {
			    for (int i = 0; i < dataItems.Rows.Count; i++)
			    {
				    current = new JobAnalysisDutyKSA (dataItems.Rows[i]);
				    listCollection.Add(current);
			    }
		    }
		    else
			    throw new Exception("You cannot create a JobAnalysisDutyKSA collection from a null data table.");

		    return listCollection;
	    }
		
	    #endregion
	}
}

