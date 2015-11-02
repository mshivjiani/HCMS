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
	/// JobAnalysisDutyQualification Business Object
	/// </summary>
	[Serializable]
	public class JobAnalysisDutyQualification : BusinessBase
	{
	#region Private Members
	
		private long _jADutyQualID  = -1;
		private long _jADutyID  = -1;
		private string _jAQualDescription  = string.Empty;
		private int _jAQualificationTypeID  = -1;
		private int _jAQualificationID  = -1;
        private string _qualificationName = string.Empty;
        private string _qualificationTypeName = string.Empty;
        private int _createdByID = -1;
        private DateTime _createDate = DateTime.MinValue;
        private int _updatedByID = -1;
        private DateTime _updateDate = DateTime.MinValue;
		#endregion
	
	#region Properties
	
	public long JADutyQualID
	{
		get
		{
			return this._jADutyQualID;
		}
		set
		{
			this._jADutyQualID = value;
		}
	}
	
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
	
	public string JAQualDescription
	{
		get
		{
			return this._jAQualDescription;
		}
		set
		{
			this._jAQualDescription = value;
		}
	}
	
	public int JAQualificationTypeID
	{
		get
		{
			return this._jAQualificationTypeID;
		}
		set
		{
			this._jAQualificationTypeID = value;
		}
	}
	
	public int JAQualificationID
	{
		get
		{
			return this._jAQualificationID;
		}
		set
		{
			this._jAQualificationID = value;
		}
	}

    public string QualificationName
    {
        get { return this._qualificationName; }
        set { this._qualificationName = value; }
    }

    public string QualificationTypeName
    {
        get { return this._qualificationTypeName; }
        set { this._qualificationTypeName = value; }
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
	
	public JobAnalysisDutyQualification ()
	{
		// Empty Constructor
	}
		
	public JobAnalysisDutyQualification (int loadByID)
	{
		// Load Object by ID
		DataTable returnTable;
		try
        {
            returnTable = ExecuteDataTable("spr_GetJobAnalysisDutyQualificationByID", loadByID);
			loadData(returnTable);
		}
        catch (Exception ex)
        {
            HandleException(ex);
         }
	}	
	
	public JobAnalysisDutyQualification (DataRow singleRowData)
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
					this._jADutyQualID = (long) returnRow["JADutyQualID"];
					this._jADutyID = (long) returnRow["JADutyID"];
					this._jAQualDescription = returnRow["JAQualDescription"].ToString();
					this._jAQualificationTypeID = (int) returnRow["JAQualificationTypeID"];
					this._jAQualificationID = (int) returnRow["JAQualificationID"];
                    if (returnRow["QualificationName"] != DBNull.Value )
                        this._qualificationName = returnRow["QualificationName"].ToString();
                    if (returnRow["QualificationTypeName"] != DBNull.Value)
                        this._qualificationTypeName = returnRow["QualificationTypeName"].ToString();

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
            return "JADutyQualID:" + JADutyQualID.ToString();
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
           JobAnalysisDutyQualification JobAnalysisDutyQualificationobj = obj as JobAnalysisDutyQualification ;
			
            return (JobAnalysisDutyQualificationobj == null) ? false : (this.JADutyQualID==JobAnalysisDutyQualificationobj.JADutyQualID );
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
			return JADutyQualID.GetHashCode();
        }
	#endregion
	
	#region General Methods
	
	public void Add()
	{
    
	
		DbCommand commandWrapper = GetDbCommand("spr_AddJobAnalysisDutyQualification");
		
        try
        {
			SqlParameter returnParam = new SqlParameter("@newJADutyQualID", SqlDbType.Int);
			returnParam.Direction = ParameterDirection.Output;

			// get the new JADutyQualID of the record
			commandWrapper.Parameters.Add(returnParam);
			
commandWrapper.Parameters.Add(new SqlParameter("@jADutyID", this._jADutyID));
commandWrapper.Parameters.Add(new SqlParameter("@jAQualDescription", this._jAQualDescription.Trim()));
commandWrapper.Parameters.Add(new SqlParameter("@jAQualificationTypeID", this._jAQualificationTypeID));
commandWrapper.Parameters.Add(new SqlParameter("@jAQualificationID", this._jAQualificationID));
commandWrapper.Parameters.Add(new SqlParameter("@userID", this._createdByID));

            ExecuteNonQuery(commandWrapper);
           
			this._jADutyQualID  = (int) returnParam.Value;
          }
        catch (Exception ex)
        {
            HandleException(ex);
         }
	}
	
	public void Update()
	{
    
		if (base.ValidateKeyField(this._jADutyQualID))
		{
			DbCommand commandWrapper = GetDbCommand("spr_UpdateJobAnalysisDutyQualification");
			
			try
			{
commandWrapper.Parameters.Add(new SqlParameter("@jADutyQualID", this._jADutyQualID));
commandWrapper.Parameters.Add(new SqlParameter("@jADutyID", this._jADutyID));
commandWrapper.Parameters.Add(new SqlParameter("@jAQualDescription", this._jAQualDescription.Trim()));
commandWrapper.Parameters.Add(new SqlParameter("@jAQualificationTypeID", this._jAQualificationTypeID));
commandWrapper.Parameters.Add(new SqlParameter("@jAQualificationID", this._jAQualificationID));
commandWrapper.Parameters.Add(new SqlParameter("@userID", this._updatedByID ));

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
		if (base.ValidateKeyField(this._jADutyQualID))
		{
			try
			{
				ExecuteNonQuery("spr_DeleteJobAnalysisDutyQualification", this._jADutyQualID,this._updatedByID );
			}
			catch (Exception ex)
			{
				HandleException(ex);
			}
		}
	}
		
	#endregion
	
	#region Collection Helper Methods
	
	internal static List<JobAnalysisDutyQualification> GetCollection (DataTable dataItems)
	{
		List<JobAnalysisDutyQualification> listCollection = new List<JobAnalysisDutyQualification>();
		JobAnalysisDutyQualification current = null;
		
		if (dataItems != null)
		{
			for (int i = 0; i < dataItems.Rows.Count; i++)
			{
				current = new JobAnalysisDutyQualification (dataItems.Rows[i]);
				listCollection.Add(current);
			}
		}
		else
			throw new Exception("You cannot create a JobAnalysisDutyQualification collection from a null data table.");

		return listCollection;
	}
		
	#endregion
	
	#region Collection Methods
		
		#endregion
		
	}
}

