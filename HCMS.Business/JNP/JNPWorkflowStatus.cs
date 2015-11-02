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
using HCMS.Business.Common;

namespace HCMS.Business.JNP
{
	/// <summary>
	/// JNP Workflow Status Business Object
	/// </summary>
	[Serializable]
	public class JNPWorkflowStatus : BusinessBase
	{
        #region [ Constructors ]
        public JNPWorkflowStatus()
        {
        }
        public JNPWorkflowStatus(DataRow dataRow)
        {
            FillObjectFromRowData(dataRow);
        }
        #endregion

        #region [ Constructor Helper Methods ]
        protected virtual void FillObjectFromRowData(DataRow dataRow)
        {
            JNPWorkflowRecID = (long)dataRow["JNPWorkflowRecID"];
            JNPWorkflowStatusID = (int)dataRow["JNPWorkflowStatusID"];
            JNPID = (long)dataRow["JNPID"];
            IsCurrent = (bool)dataRow["IsCurrent"];
            CreatedByID = (int)dataRow["CreatedByID"];
            CreateDate = (DateTime)dataRow["CreateDate"];
            //
            if (DBNull.Value.Equals(dataRow["JNPWorkflowStatus"]) == false) JNPWorkflowStatusName = (string)dataRow["JNPWorkflowStatus"];
            if (DBNull.Value.Equals(dataRow["CreatedBy"]) == false) CreatedBy = (string)dataRow["CreatedBy"];
        }
        #endregion

        #region [ Static Helper Methods ]
        public static JNPWorkflowStatus GetByID(long jnpWorkflowRecID)
        {
            JNPWorkflowStatus item = null;

            try
            {
                DataTable dataTable = ExecuteDataTable("spr_GetJNPWorkflowStatusByID", jnpWorkflowRecID);

                if (dataTable.Rows.Count == 1)
                {
                    DataRow dataRow = dataTable.Rows[0];

                    if (dataRow != null)
                    {
                        item = new JNPWorkflowStatus(dataRow);
                    }
                }

            }
            catch (Exception ex)
            {
                item = null;
                ExceptionBase.HandleException(ex);
            }

            return item;
        }
        public static JNPWorkflowStatus GetCurrentJNPWorkflowStatus(long jnpID)
        {
            JNPWorkflowStatus item = null;

            try
            {
                DataTable dataTable = ExecuteDataTable("spr_GetJNPWorkflowStatusByJNPID", jnpID);

                if (dataTable.Rows.Count == 1)
                {
                    DataRow dataRow = dataTable.Rows[0];

                    if (dataRow != null)
                    {
                        item = new JNPWorkflowStatus(dataRow);
                    }
                }

            }
            catch (Exception ex)
            {
                item = null;
                ExceptionBase.HandleException(ex);
            }

            return item;

        }
        public static JNPWorkflowStatusCollection GetCollection(long jnpID)
        {
            JNPWorkflowStatusCollection collection = null;

            try
            {
                DataTable dataTable = ExecuteDataTable("spr_GetJNPWorkflowStatuses", jnpID);
                collection = GetCollection(dataTable);
            }
            catch (Exception ex)
            {
                ExceptionBase.HandleException(ex);
            }

            return collection;
        }
        #endregion

        #region [ Collection Helper Methods ]
       
        protected static JNPWorkflowStatusCollection GetCollection(DataTable dataItems)
        {
            JNPWorkflowStatusCollection collection = new JNPWorkflowStatusCollection();

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    JNPWorkflowStatus item = new JNPWorkflowStatus(dataItems.Rows[i]);
                    collection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a JNPWorkflowStatus collection from a null data table.");
            }

            return collection;
        }

        #endregion

        #region [ General Methods ]
        public void Add()
        {
            JNPWorkflowRecID = (long)ExecuteScalar("spr_AddJNPWorkflowStatus", JNPWorkflowStatusID, JNPID, IsCurrent, CreatedByID, CreateDate);
        }
        public void Update()
        {
            ExecuteNonQuery("spr_UpdateJNPWorkflowStatus", JNPWorkflowRecID, JNPWorkflowStatusID, JNPID, IsCurrent, CreatedByID, CreateDate);
        }

        // NOTE MD 6/11: This is not called anywhere in app. Should be deleted at some point...
        public void Delete()
        {
            ExecuteNonQuery("spr_DeleteJNPWorkflowNote", JNPWorkflowRecID);
        }
        #endregion

        #region [ Properties ]
        public long JNPWorkflowRecID { get; set; } // PK
        public int JNPWorkflowStatusID { get; set; }
        public long JNPID { get; set; }
        public bool IsCurrent { get; set; }
        public int CreatedByID { get; set; }
        public DateTime CreateDate { get; set; }
        //
        public string JNPWorkflowStatusName { get; set; }
        public string CreatedBy { get; set; }
        #endregion

        #region [ Manisha's code ]

        /*


	#region Private Members
	
		private long _jNPWorkflowRecID  = -1;
		private int _jNPWorkflowStatusID  = -1;
		private long _jNPID  = -1;
		private bool _isCurrent  = false;
		private int _createdByID  = -1;
		private DateTime _createDate  = DateTime.MinValue;
			
		#endregion
	
	#region Properties
	
	public long JNPWorkflowRecID
	{
		get
		{
			return this._jNPWorkflowRecID;
		}
		set
		{
			this._jNPWorkflowRecID = value;
		}
	}
	
	public int JNPWorkflowStatusID
	{
		get
		{
			return this._jNPWorkflowStatusID;
		}
		set
		{
			this._jNPWorkflowStatusID = value;
		}
	}
	
	public long JNPID
	{
		get
		{
			return this._jNPID;
		}
		set
		{
			this._jNPID = value;
		}
	}
	
	public bool IsCurrent
	{
		get
		{
			return this._isCurrent;
		}
		set
		{
			this._isCurrent = value;
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
	
		#endregion
	
	#region Constructors
	
	public JNPWorkflowStatus ()
	{
		// Empty Constructor
	}
		
	public JNPWorkflowStatus (int loadByID)
	{
		// Load Object by ID
		DataTable returnTable;
		try
        {
            returnTable = ExecuteDataTable("spr_GetJNPWorkflowStatuByID", loadByID);
			loadData(returnTable);
		}
        catch (Exception ex)
        {
            HandleException(ex);
         }
	}	
	
	public JNPWorkflowStatus (DataRow singleRowData)
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
					this._jNPWorkflowRecID = (long) returnRow["JNPWorkflowRecID"];
				
				if (returnRow["JNPWorkflowStatusID"] != DBNull.Value)
					this._jNPWorkflowStatusID = (int) returnRow["JNPWorkflowStatusID"];
				
				
				if (returnRow["JNPID"] != DBNull.Value)
					this._jNPID = (long) returnRow["JNPID"];
				
				
				if (returnRow["IsCurrent"] != DBNull.Value)
					this._isCurrent = (bool) returnRow["IsCurrent"];
				
				
				if (returnRow["CreatedByID"] != DBNull.Value)
					this._createdByID = (int) returnRow["CreatedByID"];
				
				
				if (returnRow["CreateDate"] != DBNull.Value)
					this._createDate = (DateTime) returnRow["CreateDate"];
				
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
            return "JNPWorkflowRecID:" + JNPWorkflowRecID.ToString();
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
           JNPWorkflowStatus JNPWorkflowStatusobj = obj as JNPWorkflowStatus ;
			
            return (JNPWorkflowStatusobj == null) ? false : (this.JNPWorkflowRecID==JNPWorkflowStatusobj.JNPWorkflowRecID );
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
			return JNPWorkflowRecID.GetHashCode();
        }
	#endregion
	
	#region General Methods
	
	public void Add()
	{
    
	
		DbCommand commandWrapper = GetDbCommand("spr_AddJNPWorkflowStatu");
		
        try
        {
			SqlParameter returnParam = new SqlParameter("@newJNPWorkflowRecID", SqlDbType.Int);
			returnParam.Direction = ParameterDirection.Output;

			// get the new JNPWorkflowRecID of the record
			commandWrapper.Parameters.Add(returnParam);
			

if (this._jNPWorkflowStatusID == -1)
commandWrapper.Parameters.Add(new SqlParameter("@jNPWorkflowStatusID", DBNull.Value));
else
commandWrapper.Parameters.Add(new SqlParameter("@jNPWorkflowStatusID", this._jNPWorkflowStatusID));

if (this._jNPID == -1)
commandWrapper.Parameters.Add(new SqlParameter("@jNPID", DBNull.Value));
else
commandWrapper.Parameters.Add(new SqlParameter("@jNPID", this._jNPID));
commandWrapper.Parameters.Add(new SqlParameter("@isCurrent", this._isCurrent));

if (this._createdByID == -1)
commandWrapper.Parameters.Add(new SqlParameter("@createdByID", DBNull.Value));
else
commandWrapper.Parameters.Add(new SqlParameter("@createdByID", this._createdByID));

if (this._createDate == DateTime.MinValue)
commandWrapper.Parameters.Add(new SqlParameter("@createDate", DBNull.Value));
else
commandWrapper.Parameters.Add(new SqlParameter("@createDate", this._createDate));

            ExecuteNonQuery(commandWrapper);
           
			this._jNPWorkflowRecID  = (int) returnParam.Value;
          }
        catch (Exception ex)
        {
            HandleException(ex);
         }
	}
	
	public void Update()
	{
    
		if (base.ValidateKeyField(this._jNPWorkflowRecID))
		{
			DbCommand commandWrapper = GetDbCommand("spr_UpdateJNPWorkflowStatu");
			
			try
			{
commandWrapper.Parameters.Add(new SqlParameter("@jNPWorkflowRecID", this._jNPWorkflowRecID));

if (this._jNPWorkflowStatusID == -1)
commandWrapper.Parameters.Add(new SqlParameter("@jNPWorkflowStatusID", DBNull.Value));
else
commandWrapper.Parameters.Add(new SqlParameter("@jNPWorkflowStatusID", this._jNPWorkflowStatusID));

if (this._jNPID == -1)
commandWrapper.Parameters.Add(new SqlParameter("@jNPID", DBNull.Value));
else
commandWrapper.Parameters.Add(new SqlParameter("@jNPID", this._jNPID));
commandWrapper.Parameters.Add(new SqlParameter("@isCurrent", this._isCurrent));

if (this._createdByID == -1)
commandWrapper.Parameters.Add(new SqlParameter("@createdByID", DBNull.Value));
else
commandWrapper.Parameters.Add(new SqlParameter("@createdByID", this._createdByID));

if (this._createDate == DateTime.MinValue)
commandWrapper.Parameters.Add(new SqlParameter("@createDate", DBNull.Value));
else
commandWrapper.Parameters.Add(new SqlParameter("@createDate", this._createDate));

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
		if (base.ValidateKeyField(this._jNPWorkflowRecID))
		{
			try
			{
				ExecuteNonQuery("spr_DeleteJNPWorkflowStatu", this._jNPWorkflowRecID);
			}
			catch (Exception ex)
			{
				HandleException(ex);
			}
		}
	}
		
	#endregion
	
	#region Collection Helper Methods
	
	internal static List<JNPWorkflowStatus> GetCollection (DataTable dataItems)
	{
		List<JNPWorkflowStatus> listCollection = new List<JNPWorkflowStatus>();
		JNPWorkflowStatus current = null;
		
		if (dataItems != null)
		{
			for (int i = 0; i < dataItems.Rows.Count; i++)
			{
				current = new JNPWorkflowStatus (dataItems.Rows[i]);
				listCollection.Add(current);
			}
		}
		else
			throw new Exception("You cannot create a JNPWorkflowStatus collection from a null data table.");

		return listCollection;
	}
		
	#endregion
	
	#region Collection Methods
		
		#endregion
 */
        #endregion
    }
}

