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
	/// JobAnalysisDuty Business Object
	/// </summary>
	[Serializable]
	public class JobAnalysisDuty : BusinessBase
	{
	#region Private Members
	
		private long _jADutyID  = -1;
		private long _jAID  = -1;
		private string _jADutyDescription  = string.Empty;
		private int _jAPercentageOfTime  = -1;
		private int _createdByID  = -1;
		private DateTime _createDate  = DateTime.MinValue;
		private int _updatedByID  = -1;
		private DateTime _updateDate  = DateTime.MinValue;
			
		#endregion
	
	#region Properties
	
	public long JADutyID
	{
		get
		{
			return this._jADutyID;
		}
		set
		{
			this._jADutyID = value;
		}
	}
	
	public long JAID
	{
		get
		{
			return this._jAID;
		}
		set
		{
			this._jAID = value;
		}
	}
	
	public string JADutyDescription
	{
		get
		{
			return this._jADutyDescription;
		}
		set
		{
			this._jADutyDescription = value;
		}
	}
	
	public int JAPercentageOfTime
	{
		get
		{
			return this._jAPercentageOfTime;
		}
		set
		{
			this._jAPercentageOfTime = value;
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
	
	public JobAnalysisDuty ()
	{
		// Empty Constructor
	}
		
	public JobAnalysisDuty (long loadByID)
	{
		// Load Object by ID
		DataTable returnTable;
		try
        {
            returnTable = ExecuteDataTable("spr_GetJobAnalysisDutyByID", loadByID);
			loadData(returnTable);
		}
        catch (Exception ex)
        {
            HandleException(ex);
         }
	}	
	
	public JobAnalysisDuty (DataRow singleRowData)
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
					this._jADutyID = (long) returnRow["JADutyID"];
					this._jAID = (long) returnRow["JAID"];
					this._jADutyDescription = returnRow["JADutyDescription"].ToString();
					this._jAPercentageOfTime = (int) returnRow["JAPercentageOfTime"];
					this._createdByID = (int) returnRow["CreatedByID"];
					this._createDate = (DateTime) returnRow["CreateDate"];
					this._updatedByID = (int) returnRow["UpdatedByID"];
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
            return "JADutyID:" + JADutyID.ToString();
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
           JobAnalysisDuty JobAnalysisDutyobj = obj as JobAnalysisDuty ;
			
            return (JobAnalysisDutyobj == null) ? false : (this.JADutyID==JobAnalysisDutyobj.JADutyID );
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
			return JADutyID.GetHashCode();
        }
	#endregion
	
	#region General Methods
	
	public void Add()
	{
    
	
		DbCommand commandWrapper = GetDbCommand("spr_AddJobAnalysisDuty");
		
        try
        {
			SqlParameter returnParam = new SqlParameter("@newJADutyID", SqlDbType.Int);
			returnParam.Direction = ParameterDirection.Output;

			// get the new JADutyID of the record
			commandWrapper.Parameters.Add(returnParam);
			
commandWrapper.Parameters.Add(new SqlParameter("@jAID", this._jAID));
commandWrapper.Parameters.Add(new SqlParameter("@jADutyDescription", this._jADutyDescription.Trim()));
commandWrapper.Parameters.Add(new SqlParameter("@jAPercentageOfTime", this._jAPercentageOfTime));
commandWrapper.Parameters.Add(new SqlParameter("@createdByID", this._createdByID));
commandWrapper.Parameters.Add(new SqlParameter("@createDate", this._createDate));
commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", this._updatedByID));
commandWrapper.Parameters.Add(new SqlParameter("@updateDate", this._updateDate));

            ExecuteNonQuery(commandWrapper);
           
			this._jADutyID  = (int) returnParam.Value;
          }
        catch (Exception ex)
        {
            HandleException(ex);
         }
	}
	
	public void Update()
	{
    
		if (base.ValidateKeyField(this._jADutyID))
		{
			DbCommand commandWrapper = GetDbCommand("spr_UpdateJobAnalysisDuty");
			
			try
			{
commandWrapper.Parameters.Add(new SqlParameter("@jADutyID", this._jADutyID));
commandWrapper.Parameters.Add(new SqlParameter("@jAID", this._jAID));
commandWrapper.Parameters.Add(new SqlParameter("@jADutyDescription", this._jADutyDescription.Trim()));
commandWrapper.Parameters.Add(new SqlParameter("@jAPercentageOfTime", this._jAPercentageOfTime));
commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", this._updatedByID));
commandWrapper.Parameters.Add(new SqlParameter("@updateDate", this._updateDate));

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
		if (base.ValidateKeyField(this._jADutyID))
		{
            DbCommand commandWrapper = GetDbCommand("spr_DeleteJobAnalysisDuty");

			try
			{
                commandWrapper.Parameters.Add(new SqlParameter("@JADutyID", this._jADutyID));
                commandWrapper.Parameters.Add(new SqlParameter("@JAID", this._jAID));
                commandWrapper.Parameters.Add(new SqlParameter("@userID", this._updatedByID));

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
	
	internal static List<JobAnalysisDuty> GetCollection (DataTable dataItems)
	{
		List<JobAnalysisDuty> listCollection = new List<JobAnalysisDuty>();
		JobAnalysisDuty current = null;
		
		if (dataItems != null)
		{
			for (int i = 0; i < dataItems.Rows.Count; i++)
			{
				current = new JobAnalysisDuty (dataItems.Rows[i]);
				listCollection.Add(current);
			}
		}
		else
			throw new Exception("You cannot create a JobAnalysisDuty collection from a null data table.");

		return listCollection;
	}
		
	#endregion
	
	#region Collection Methods
		
			public List<JobAnalysisDutyKSA> GetJobAnalysisDutyKSAByJADutyID()
			{
				List <JobAnalysisDutyKSA> childDataCollection = null;
				if (base.ValidateKeyField(this._jADutyID))
				{
					try
					{
						DataTable dt = ExecuteDataTable("spr_GetJobAnalysisDutyKSAByJADutyID", this._jADutyID);
						
						// fill collection list
						childDataCollection = JobAnalysisDutyKSA.GetCollection(dt);
					}
					catch (Exception ex)
					{
						HandleException(ex);
					}
				}
				
				return childDataCollection;
			}

            public List<JobAnalysisDutyKSAFactor> GetJobAnalysisDutyKSAFactorByJADutyID()
            {
                List<JobAnalysisDutyKSAFactor> childDataCollection = null;
                if (base.ValidateKeyField(this._jADutyID))
                {
                    try
                    {
                        DataTable dt = ExecuteDataTable("spr_GetJobAnalysisDutyKSAFactorByJADutyID", this._jADutyID);

                        // fill collection list
                        childDataCollection = JobAnalysisDutyKSAFactor.GetCollection(dt);
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex);
                    }
                }

                return childDataCollection;
            }		
			
			public List<JobAnalysisDutyQualification> GetJobAnalysisDutyQualificationByJADutyID()
			{
				List <JobAnalysisDutyQualification> childDataCollection = null;
				if (base.ValidateKeyField(this._jADutyID))
				{
					try
					{
						DataTable dt = ExecuteDataTable("spr_GetJobAnalysisDutyQualificationByJADutyID", this._jADutyID);
						
						// fill collection list
						childDataCollection = JobAnalysisDutyQualification.GetCollection(dt);
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

