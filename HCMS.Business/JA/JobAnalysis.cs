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
using HCMS.Business.JA.Collections;
using HCMS.Business.JQ;

namespace HCMS.Business.JA
{
	/// <summary>
	/// JobAnalysis Business Object
	/// </summary>
	[Serializable]
	public class JobAnalysis : BusinessBase
	{
	#region Private Members
	
		private long _JAID  = -1;
		private int _payPlanID  = -1;
		private int _seriesID  = -1;
		private bool _isInterDisciplinary  = false;
		private int _additionalSeriesID  = -1;
		private int _lowestAdvertisedGrade  = -1;
		private int _highestAdvertisedGrade  = -1;
		private string _JATitle  = string.Empty;
		private string _dutyLocation  = string.Empty;
		private string _FPPSPDID  = string.Empty;
		private bool _isStandardJA  = false;
		private int _createdByID  = -1;
		private DateTime _createDate  = DateTime.MinValue;
		private int _updatedByID  = -1;
		private DateTime _updateDate  = DateTime.MinValue;
			
		#endregion
	
	#region Properties
	
	public long JAID
	{
		get
		{
			return this._JAID;
		}
		set
		{
			this._JAID = value;
		}
	}
	
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
	
	public int SeriesID
	{
		get
		{
			return this._seriesID;
		}
		set
		{
			this._seriesID = value;
		}
	}
	
	public bool IsInterDisciplinary
	{
		get
		{
			return this._isInterDisciplinary;
		}
		set
		{
			this._isInterDisciplinary = value;
		}
	}
	
	public int AdditionalSeriesID
	{
		get
		{
			return this._additionalSeriesID;
		}
		set
		{
			this._additionalSeriesID = value;
		}
	}
	
	public int LowestAdvertisedGrade
	{
		get
		{
			return this._lowestAdvertisedGrade;
		}
		set
		{
			this._lowestAdvertisedGrade = value;
		}
	}
	
	public int HighestAdvertisedGrade
	{
		get
		{
			return this._highestAdvertisedGrade;
		}
		set
		{
			this._highestAdvertisedGrade = value;
		}
	}
	
	public string JATitle
	{
		get
		{
			return this._JATitle;
		}
		set
		{
			this._JATitle = value;
		}
	}
	
	public string DutyLocation
	{
		get
		{
			return this._dutyLocation;
		}
		set
		{
			this._dutyLocation = value;
		}
	}
	
	public string FPPSPDID
	{
		get
		{
			return this._FPPSPDID;
		}
		set
		{
			this._FPPSPDID = value;
		}
	}
	
	public bool IsStandardJA
	{
		get
		{
			return this._isStandardJA;
		}
		set
		{
			this._isStandardJA = value;
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
	
	public JobAnalysis ()
	{
		// Empty Constructor
	}
		
	public JobAnalysis (long loadByID)
	{
		// Load Object by ID
		DataTable returnTable;
		try
        {
            returnTable = ExecuteDataTable("spr_GetJobAnalysisByID", loadByID);
			loadData(returnTable);
		}
        catch (Exception ex)
        {
            HandleException(ex);
         }
	}	
	
	public JobAnalysis (DataRow singleRowData)
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
					this._JAID = (long) returnRow["JAID"];
					this._payPlanID = (int) returnRow["PayPlanID"];
					this._seriesID = (int) returnRow["SeriesID"];
				
				if (returnRow["IsInterDisciplinary"] != DBNull.Value)
					this._isInterDisciplinary = (bool) returnRow["IsInterDisciplinary"];
				
				
				if (returnRow["AdditionalSeriesID"] != DBNull.Value)
					this._additionalSeriesID = (int) returnRow["AdditionalSeriesID"];
				
					this._lowestAdvertisedGrade = (int) returnRow["LowestAdvertisedGrade"];
					this._highestAdvertisedGrade = (int) returnRow["HighestAdvertisedGrade"];
					this._JATitle = returnRow["JATitle"].ToString();
				
				if (returnRow["DutyLocation"] != DBNull.Value)
					this._dutyLocation = returnRow["DutyLocation"].ToString();
				
				if (returnRow["FPPSPDID"] != DBNull.Value)
					this._FPPSPDID = returnRow["FPPSPDID"].ToString();
				
				if (returnRow["IsStandardJA"] != DBNull.Value)
					this._isStandardJA = (bool) returnRow["IsStandardJA"];
				
				
				if (returnRow["CreatedByID"] != DBNull.Value)
					this._createdByID = (int) returnRow["CreatedByID"];
				
				
				if (returnRow["CreateDate"] != DBNull.Value)
					this._createDate = (DateTime) returnRow["CreateDate"];
				
				
				if (returnRow["UpdatedByID"] != DBNull.Value)
					this._updatedByID = (int) returnRow["UpdatedByID"];
				
				
				if (returnRow["UpdateDate"] != DBNull.Value)
					this._updateDate = (DateTime) returnRow["UpdateDate"];
				
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
            return "JAID:" + JAID.ToString();
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
           JobAnalysis JobAnalysisobj = obj as JobAnalysis ;
			
            return (JobAnalysisobj == null) ? false : (this.JAID==JobAnalysisobj.JAID );
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
			return JAID.GetHashCode();
        }
	#endregion
	
	#region General Methods
	
	public void Add()
	{
    
	
		DbCommand commandWrapper = GetDbCommand("spr_AddJobAnalysis");
		
        try
        {
			SqlParameter returnParam = new SqlParameter("@newJAID", SqlDbType.Int);
			returnParam.Direction = ParameterDirection.Output;

			// get the new JAID of the record
			commandWrapper.Parameters.Add(returnParam);
			
commandWrapper.Parameters.Add(new SqlParameter("@payPlanID", this._payPlanID));
commandWrapper.Parameters.Add(new SqlParameter("@seriesID", this._seriesID));
commandWrapper.Parameters.Add(new SqlParameter("@isInterDisciplinary", this._isInterDisciplinary));

if (this._additionalSeriesID == -1)
commandWrapper.Parameters.Add(new SqlParameter("@additionalSeriesID", DBNull.Value));
else
commandWrapper.Parameters.Add(new SqlParameter("@additionalSeriesID", this._additionalSeriesID));
commandWrapper.Parameters.Add(new SqlParameter("@LowestAdvertisedGrade", this._lowestAdvertisedGrade));
commandWrapper.Parameters.Add(new SqlParameter("@HighestAdvertisedGrade", this._highestAdvertisedGrade));
commandWrapper.Parameters.Add(new SqlParameter("@jATitle", this._JATitle.Trim()));
commandWrapper.Parameters.Add(new SqlParameter("@dutyLocation", this._dutyLocation));
commandWrapper.Parameters.Add(new SqlParameter("@fPPSPDID", this._FPPSPDID));
commandWrapper.Parameters.Add(new SqlParameter("@isStandardJA", this._isStandardJA));

if (this._createdByID == -1)
commandWrapper.Parameters.Add(new SqlParameter("@createdByID", DBNull.Value));
else
commandWrapper.Parameters.Add(new SqlParameter("@createdByID", this._createdByID));

if (this._createDate == DateTime.MinValue)
commandWrapper.Parameters.Add(new SqlParameter("@createDate", DBNull.Value));
else
commandWrapper.Parameters.Add(new SqlParameter("@createDate", this._createDate));

if (this._updatedByID == -1)
commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", DBNull.Value));
else
commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", this._updatedByID));

if (this._updateDate == DateTime.MinValue)
commandWrapper.Parameters.Add(new SqlParameter("@updateDate", DBNull.Value));
else
commandWrapper.Parameters.Add(new SqlParameter("@updateDate", this._updateDate));

            ExecuteNonQuery(commandWrapper);
           
			this._JAID  = (int) returnParam.Value;
          }
        catch (Exception ex)
        {
            HandleException(ex);
         }
	}
	
	public void Update()
	{
    
		if (base.ValidateKeyField(this._JAID))
		{
			DbCommand commandWrapper = GetDbCommand("spr_UpdateJobAnalysis");
			
			try
			{
commandWrapper.Parameters.Add(new SqlParameter("@jAID", this._JAID));
commandWrapper.Parameters.Add(new SqlParameter("@payPlanID", this._payPlanID));
commandWrapper.Parameters.Add(new SqlParameter("@seriesID", this._seriesID));
commandWrapper.Parameters.Add(new SqlParameter("@isInterDisciplinary", this._isInterDisciplinary));

if (this._additionalSeriesID == -1)
commandWrapper.Parameters.Add(new SqlParameter("@additionalSeriesID", DBNull.Value));
else
commandWrapper.Parameters.Add(new SqlParameter("@additionalSeriesID", this._additionalSeriesID));
commandWrapper.Parameters.Add(new SqlParameter("@LowestAdvertisedGrade", this._lowestAdvertisedGrade));
commandWrapper.Parameters.Add(new SqlParameter("@HighestAdvertisedGrade", this._highestAdvertisedGrade));
commandWrapper.Parameters.Add(new SqlParameter("@jATitle", this._JATitle.Trim()));
commandWrapper.Parameters.Add(new SqlParameter("@dutyLocation", this._dutyLocation));
commandWrapper.Parameters.Add(new SqlParameter("@fPPSPDID", this._FPPSPDID));
commandWrapper.Parameters.Add(new SqlParameter("@isStandardJA", this._isStandardJA));

if (this._createdByID == -1)
commandWrapper.Parameters.Add(new SqlParameter("@createdByID", DBNull.Value));
else
commandWrapper.Parameters.Add(new SqlParameter("@createdByID", this._createdByID));

if (this._createDate == DateTime.MinValue)
commandWrapper.Parameters.Add(new SqlParameter("@createDate", DBNull.Value));
else
commandWrapper.Parameters.Add(new SqlParameter("@createDate", this._createDate));

if (this._updatedByID == -1)
commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", DBNull.Value));
else
commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", this._updatedByID));

if (this._updateDate == DateTime.MinValue)
commandWrapper.Parameters.Add(new SqlParameter("@updateDate", DBNull.Value));
else
commandWrapper.Parameters.Add(new SqlParameter("@updateDate", this._updateDate));

				ExecuteNonQuery(commandWrapper);
			}
			catch (Exception ex)
			{
				HandleException(ex);
			}
		}
	}		
	
	public void Delete(int userID)
	{
		if (base.ValidateKeyField(this._JAID))
		{
			try
			{
                DbCommand commandWrapper = GetDbCommand("spr_DeleteJobAnalysis");

                commandWrapper.Parameters.Add(new SqlParameter("@jAID", this._JAID));
                commandWrapper.Parameters.Add(new SqlParameter("@userID", userID));

                ExecuteNonQuery(commandWrapper);
			}
			catch (Exception ex)
			{
				HandleException(ex);
			}
		}
	}
		
	#endregion
	
	#region Collection Helper Methods
	
	internal static List<JobAnalysis> GetCollection (DataTable dataItems)
	{
		List<JobAnalysis> listCollection = new List<JobAnalysis>();
		JobAnalysis current = null;
		
		if (dataItems != null)
		{
			for (int i = 0; i < dataItems.Rows.Count; i++)
			{
				current = new JobAnalysis (dataItems.Rows[i]);
				listCollection.Add(current);
			}
		}
		else
			throw new Exception("You cannot create a JobAnalysis collection from a null data table.");

		return listCollection;
	}
		
	#endregion
	
	#region Collection Methods
						
		public List<JobAnalysisDuty> GetJobAnalysisDuty()
		{
			List <JobAnalysisDuty> childDataCollection = null;
			if (base.ValidateKeyField(this._JAID))
			{
				try
				{
					DataTable dt = ExecuteDataTable("spr_GetJobAnalysisDutyByJAID", this._JAID);
						
					// fill collection list
					childDataCollection = JobAnalysisDuty.GetCollection(dt);
				}
				catch (Exception ex)
				{
					HandleException(ex);
				}
			}
				
			return childDataCollection;
		}

        public JobAnalysisDutyKSACollection GetJobAnalysisDutyKSA()
        {
            JobAnalysisDutyKSACollection listKSA = new JobAnalysisDutyKSACollection();

            if (base.ValidateKeyField(this._JAID))
            {
                try
                {
                    listKSA = new JobAnalysisDutyKSACollection(ExecuteDataTable("spr_GetJAKSA", this._JAID));
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return listKSA;
        }

        public List<JQFactor> GetJAKSAFactor()
        {
           List<JQFactor> listKSA = null;

            if (base.ValidateKeyField(this._JAID))
            {
                try
                {
                    DataTable dt=ExecuteDataTable("spr_GetAllJQFactorsByJAID", this._JAID);
                    listKSA = JQFactor.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return listKSA;
        }

        public JobAnalysisDutyKSAFactorCollection GetJobAnalysisDutyKSAFactor()
        {
            JobAnalysisDutyKSAFactorCollection listKSA = new JobAnalysisDutyKSAFactorCollection();

            if (base.ValidateKeyField(this._JAID))
            {
                try
                {
                    listKSA = new JobAnalysisDutyKSAFactorCollection(ExecuteDataTable("spr_GetJobAnalysisDutyKSAFactorByJAID", this._JAID));
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return listKSA;
        }
      
        public DataTable GetJobAnalysisDutyKSASelectiveFactorAndConditionsOfEmployment(long pdid)
        {
            DataTable dataItems = new DataTable();

            if (base.ValidateKeyField(this._JAID) && pdid > 0)
            {
                try
                {
                    dataItems = ExecuteDataTable("spr_ConditionsOfEmploymentandSelectiveFactorJAKSA", this._JAID, pdid);                    
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return dataItems;
        }

      
		#endregion
		
	}
}

