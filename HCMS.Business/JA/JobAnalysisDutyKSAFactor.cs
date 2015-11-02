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
    [Serializable]
    public class JobAnalysisDutyKSAFactor : BusinessBase
    {
       #region Private Members
        private enumImportanceScale _importanceID = enumImportanceScale.None;
        private string _importanceName = string.Empty;
        private enumNeedAtEntryScale _needAtEntryID = enumNeedAtEntryScale.None;
        private string _needAtEntryName = string.Empty;
        private enumDistinguishingValueScale _distinguishingValueScaleID = enumDistinguishingValueScale.None;
        private string _distinguishingValueScaleName = string.Empty;
       #endregion

        #region Properties

        public long JQFactorID { get; set; }
        public int JQFactorTypeID { get; set; }

        public int JQFactorNo { get; set; }
        public string JQFactorTitle { get; set; }
        public string JQFactorInstruction { get; set; }
        public bool IsSF { get; set; }

        public long JQID { get; set; }
        public long KSAID { get; set; }
        public long JADutyID { get; set; }
        public int QualificationID { get; set; }
        public int QualificationTypeID { get; set; }
        public bool IsFinalKSA { get; set; }
        public int PercentageOfTime { get; set; }       
        public string QualificationName { get; set; }
        public string QualificationTypeName { get; set; }      
        public int TotalScore { get; set; }
        public int CreatedByID { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdatedByID { get; set; }
        public DateTime UpdateDate { get; set; }

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

        public string ImportanceName { get; set; }
        public string NeedAtEntryName { get; set; }
        public string DistinguishingValueScaleName { get; set; }

	    #endregion
	
        #region Constructors
	
	    public JobAnalysisDutyKSAFactor ()
	    {
		    // Empty Constructor
	    }
		
	    public JobAnalysisDutyKSAFactor (long loadByID)
	    {
		    // Load Object by ID
		    DataTable returnTable;
		    try
            {
                returnTable = ExecuteDataTable("spr_GetJobAnalysisDutyKSAFactorByID", loadByID);
			    loadData(returnTable);
		    }
            catch (Exception ex)
            {
                HandleException(ex);
             }
	    }

        public JobAnalysisDutyKSAFactor(DataRow singleRowData)
	    {
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
                this.JQFactorID = (long)returnRow["JQFactorID"];

            //Coming from View. Actual field is JQFactorTypeID and alias is QualificationTypeID in [vw_JobAnalysisDutyKSAFactor]
            if (returnRow["QualificationTypeID"] != DBNull.Value)
                this.QualificationTypeID = (int)returnRow["QualificationTypeID"];

            if (returnRow["JQFactorTypeID"] != DBNull.Value)
                this.JQFactorTypeID = (int)returnRow["JQFactorTypeID"];

            if (returnRow["QualificationTypeName"] != DBNull.Value)
                this.QualificationTypeName = returnRow["QualificationTypeName"].ToString();

            if (returnRow["JQFactorNo"] != DBNull.Value)
                this.JQFactorNo = (int)returnRow["JQFactorNo"];

            //Coming from View. Actual field is JQFactorTitle and alias is JAKSADescription in [vw_JobAnalysisDutyKSAFactor]
            if (returnRow["JAKSADescription"] != DBNull.Value)
                this.JQFactorTitle = (string)returnRow["JAKSADescription"];

            if (returnRow["JQFactorInstruction"] != DBNull.Value)
                this.JQFactorInstruction = (string)returnRow["JQFactorInstruction"];

            if (returnRow["IsSF"] != DBNull.Value)
                this.IsSF = (bool)returnRow["IsSF"];

            if (returnRow["JQID"] != DBNull.Value)
			    this.@JQID = (long) returnRow["JQID"];

            if (returnRow["KSAID"] != DBNull.Value)
			    this.KSAID = (long) returnRow["KSAID"];

            if (returnRow["JADutyID"] != DBNull.Value)
                this.JADutyID = (long) returnRow["JADutyID"];

            if (returnRow["QualificationID"] != DBNull.Value)
                this.QualificationID = (int)returnRow["QualificationID"];

             if (returnRow["IsFinalKSA"] != DBNull.Value)
                this.IsFinalKSA = (bool)returnRow["IsFinalKSA"];

            if (columns.Contains("JAPercentageOfTime"))
            {
                if (returnRow["JAPercentageOfTime"] != DBNull.Value)
                    this.PercentageOfTime = (int)returnRow["JAPercentageOfTime"];
            }

            if (columns.Contains("QualificationName"))
            {
                if (returnRow["QualificationName"] != DBNull.Value)
                    this.QualificationName = returnRow["QualificationName"].ToString();
            }

            //Coming from View. Actual field is JQFactorTypeID and alias is QualificationTypeID in [vw_JobAnalysisDutyKSAFactor]
            if (returnRow["QualificationTypeID"] != DBNull.Value)
			   this.JQFactorTypeID = (int) returnRow["QualificationTypeID"];

            if (columns.Contains("QualificationTypeName")) 
            {
                if (returnRow["QualificationTypeName"] != DBNull.Value)
                    this.QualificationTypeName = returnRow["QualificationTypeName"].ToString();
            }
            
            if (returnRow["ImportanceID"] != DBNull.Value)
            {
                int tempValue = (int)returnRow["ImportanceID"];

                if (Enum.IsDefined(typeof(enumImportanceScale), tempValue))
                    this.ImportanceID = (enumImportanceScale) tempValue;

                if (returnRow["ImportanceName"] != DBNull.Value)
                    this.ImportanceName = returnRow["ImportanceName"].ToString();    
            }

            if (returnRow["NeedAtEntryID"] != DBNull.Value)
            {
                int tempValue = (int)returnRow["NeedAtEntryID"];

                if (Enum.IsDefined(typeof(enumNeedAtEntryScale), tempValue))
                    this.NeedAtEntryID = (enumNeedAtEntryScale)tempValue;

                if (returnRow["NeedAtEntryName"] != DBNull.Value)
                    this.NeedAtEntryName = returnRow["NeedAtEntryName"].ToString();    
            }

            if (returnRow["DistinguishingValueScaleID"] != DBNull.Value)
            {
                int tempValue = (int)returnRow["DistinguishingValueScaleID"];

                if (Enum.IsDefined(typeof(enumDistinguishingValueScale), tempValue))
                    this.DistinguishingValueScaleID = (enumDistinguishingValueScale)tempValue;

                if (returnRow["DistinguishingValueScaleName"] != DBNull.Value)
                    this.DistinguishingValueScaleName = returnRow["DistinguishingValueScaleName"].ToString();    
            }

		    if (returnRow["IsFinalKSA"] != DBNull.Value)
                this.IsFinalKSA = (bool)returnRow["IsFinalKSA"];

            if (returnRow["TotalScore"] != DBNull.Value)
                this.TotalScore = (int)returnRow["TotalScore"];

            if (returnRow["CreatedByID"] != DBNull.Value)
                this.CreatedByID = (int)returnRow["CreatedByID"];


            if (returnRow["CreateDate"] != DBNull.Value)
                this.CreateDate = (DateTime)returnRow["CreateDate"];


            if (returnRow["UpdatedByID"] != DBNull.Value)
                this.UpdatedByID = (int)returnRow["UpdatedByID"];


            if (returnRow["UpdateDate"] != DBNull.Value)
                this.UpdateDate = (DateTime)returnRow["UpdateDate"];
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
            JobAnalysisDutyKSAFactor JobAnalysisDutyKSFactorAobj = obj as JobAnalysisDutyKSAFactor;

            return (JobAnalysisDutyKSFactorAobj == null) ? false : (this.JQFactorID == JobAnalysisDutyKSFactorAobj.JQFactorID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
			//return JADutyKSAID.GetHashCode();
            return JQFactorID.GetHashCode();
        }
	    
        #endregion
	
	    #region General Methods
	
	    public void Add()
	    {
            DbCommand commandWrapper = GetDbCommand("spr_AddJobAnalysisDutyKSAFactor");
		
            try
            {
			    //SqlParameter returnParam = new SqlParameter("@newJADutyKSAID", SqlDbType.Int);
                SqlParameter returnParam = new SqlParameter("@newJQFactorID", SqlDbType.Int);
			    returnParam.Direction = ParameterDirection.Output;

                // get the new JQFactorID of the record
			    commandWrapper.Parameters.Add(returnParam);

                commandWrapper.Parameters.Add(new SqlParameter("@JQFactorTypeID", this.JQFactorTypeID));
                commandWrapper.Parameters.Add(new SqlParameter("@QualificationTypeID", this.QualificationTypeID));
                commandWrapper.Parameters.Add(new SqlParameter("@JQFactorTitle", this.JQFactorTitle));
                commandWrapper.Parameters.Add(new SqlParameter("@IsSF", this.IsSF));
                commandWrapper.Parameters.Add(new SqlParameter("@JQID", this.JQID));
                commandWrapper.Parameters.Add(new SqlParameter("@KSAID", this.KSAID));
                commandWrapper.Parameters.Add(new SqlParameter("@JADutyID", this.JADutyID));
                commandWrapper.Parameters.Add(new SqlParameter("@QualificationID", this.QualificationID));
                commandWrapper.Parameters.Add(new SqlParameter("@IsFinalKSA", this.IsFinalKSA));

                
                    commandWrapper.Parameters.Add(new SqlParameter("@ImportanceID", DBNull.Value));
             

                    commandWrapper.Parameters.Add(new SqlParameter("@NeedAtEntryID", DBNull.Value));
     

                    commandWrapper.Parameters.Add(new SqlParameter("@DistinguishingValueScaleID", DBNull.Value));
            

                commandWrapper.Parameters.Add(new SqlParameter("@CreatedByID", this.CreatedByID));
                commandWrapper.Parameters.Add(new SqlParameter("@CreateDate", DateTime.Now.ToShortDateString()));

                commandWrapper.Parameters.Add(new SqlParameter("@UpdatedByID", this.UpdatedByID));
                commandWrapper.Parameters.Add(new SqlParameter("@UpdateDate", DateTime.Now.ToShortDateString()));

                //commandWrapper.Parameters.Add(new SqlParameter("@userID", this.UpdatedByID));

                ExecuteNonQuery(commandWrapper);
           
			    this.JQFactorID  = (int) returnParam.Value;
              }
            catch (Exception ex)
            {
                HandleException(ex);
             }
	    }
	
	    public void Update()
	    {
            if (base.ValidateKeyField(this.JQFactorID))
		    {
			    DbCommand commandWrapper = GetDbCommand("spr_UpdateJobAnalysisDutyKSAFactor");              

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@JQFactorID", this.JQFactorID));
                    commandWrapper.Parameters.Add(new SqlParameter("@JQFactorNo", this.JQFactorNo));
                    commandWrapper.Parameters.Add(new SqlParameter("@JQFactorInstruction", this.JQFactorInstruction));
                    commandWrapper.Parameters.Add(new SqlParameter("@JQFactorTypeID", this.JQFactorTypeID));
                    commandWrapper.Parameters.Add(new SqlParameter("@QualificationTypeID", this.QualificationTypeID));
                    commandWrapper.Parameters.Add(new SqlParameter("@JQFactorTitle", this.JQFactorTitle));
                    commandWrapper.Parameters.Add(new SqlParameter("@IsSF", this.IsSF));
                    commandWrapper.Parameters.Add(new SqlParameter("@JQID", this.JQID));
                    commandWrapper.Parameters.Add(new SqlParameter("@KSAID", this.KSAID));
                    commandWrapper.Parameters.Add(new SqlParameter("@JADutyID", this.JADutyID));
                    commandWrapper.Parameters.Add(new SqlParameter("@QualificationID", this.QualificationID));
                    commandWrapper.Parameters.Add(new SqlParameter("@IsFinalKSA", this.IsFinalKSA));

                    if (this.ImportanceID == enumImportanceScale.None)
                        commandWrapper.Parameters.Add(new SqlParameter("@ImportanceID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@ImportanceID", (int)this._importanceID));

                    if (this.NeedAtEntryID == enumNeedAtEntryScale.None)
                        commandWrapper.Parameters.Add(new SqlParameter("@NeedAtEntryID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@NeedAtEntryID", (int)this._needAtEntryID));

                    if (this.DistinguishingValueScaleID == enumDistinguishingValueScale.None)
                        commandWrapper.Parameters.Add(new SqlParameter("@DistinguishingValueScaleID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@DistinguishingValueScaleID", (int)this._distinguishingValueScaleID));

                    commandWrapper.Parameters.Add(new SqlParameter("@CreatedByID", this.CreatedByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@CreateDate", this.CreateDate));

                    commandWrapper.Parameters.Add(new SqlParameter("@UpdatedByID", this.UpdatedByID));
                    commandWrapper.Parameters.Add(new SqlParameter("@UpdateDate", DateTime.Now.ToShortDateString()));
                                        

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
            if (base.ValidateKeyField(this.JQFactorID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateJADutyKSAFactorFinalFlag");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@JQFactorID", this.JQFactorID));

                    if (this.ImportanceID == enumImportanceScale.None)
                        commandWrapper.Parameters.Add(new SqlParameter("@ImportanceID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@ImportanceID", (int)this.ImportanceID));

                    if (this.NeedAtEntryID == enumNeedAtEntryScale.None)
                        commandWrapper.Parameters.Add(new SqlParameter("@NeedAtEntryID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@NeedAtEntryID", (int)this.NeedAtEntryID));

                    if (this.DistinguishingValueScaleID == enumDistinguishingValueScale.None)
                        commandWrapper.Parameters.Add(new SqlParameter("@DistinguishingValueScaleID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@DistinguishingValueScaleID", (int)this.DistinguishingValueScaleID));

                    commandWrapper.Parameters.Add(new SqlParameter("@IsFinalKSA", this.IsFinalKSA));
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
		    if (base.ValidateKeyField(this.JQFactorID))
		    {
			    try
			    {
                    ExecuteNonQuery("spr_DeleteJobAnalysisDutyKSAFactor", this.JQFactorID, this.UpdatedByID);
			    }
			    catch (Exception ex)
			    {
				    HandleException(ex);
			    }
		    }
	    }
		
	    #endregion
	
	    #region Collection Helper Methods
	
        internal static List<JobAnalysisDutyKSAFactor> GetCollection(DataTable dataItems)
        {
            List<JobAnalysisDutyKSAFactor> listCollection = new List<JobAnalysisDutyKSAFactor>();
            JobAnalysisDutyKSAFactor current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new JobAnalysisDutyKSAFactor(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("Failed to create Duty KSA.");

            return listCollection;
        }
		
	    #endregion
    }
}
