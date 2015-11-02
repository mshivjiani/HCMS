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

namespace HCMS.Business.JNP
{
	/// <summary>
	/// JNPCheck Business Object
	/// </summary>
	[Serializable]
	public class JNPCheck : BusinessBase
	{
	#region Private Members
	
		private long _checkID  = -1;
		private long _checkStaffingObjectID  = -1;
        private enumStaffingObjectType _checkStaffingObjectTypeID = enumStaffingObjectType.Unknown;
        private int _checkActionTypeID = -1;
        private int _checkUserID = -1;
        private DateTime _checkDate = DateTime.MinValue;

			
		#endregion
	
	#region Properties
	
	public long CheckID
	{
		get
		{
			return this._checkID;
		}
		set
		{
			this._checkID = value;
		}
	}
	
	public long  CheckStaffingObjectID
	{
		get
		{
			return this._checkStaffingObjectID;
		}
		set
		{
			this._checkStaffingObjectID = value;
		}
	}
    public enumStaffingObjectType CheckStaffingObjectTypeID
    {
        get { return this._checkStaffingObjectTypeID; }
        set { this._checkStaffingObjectTypeID = value; }
    }

    public int CheckActionTypeID
    {
        get { return this._checkActionTypeID; }
        set { this._checkActionTypeID = value; }
    }

	public DateTime CheckDate
	{
		get
		{
			return this._checkDate;
		}
		set
		{
			this._checkDate  = value;
		}
	}
	
	public int CheckUserID
	{
		get
		{
            return this._checkUserID;
		}
		set
		{
			this._checkUserID  = value;
		}
	}
	
	
	
	
	
	
	
	
	
	
		#endregion
	
	#region Constructors
	
	public JNPCheck ()
	{
		// Empty Constructor
	}
		
	public JNPCheck (int loadByID)
	{
		// Load Object by ID
		DataTable returnTable;
		try
        {
            returnTable = ExecuteDataTable("spr_GetJNPCheckByID", loadByID);
			loadData(returnTable);
		}
        catch (Exception ex)
        {
            HandleException(ex);
         }
	}	
	
	public JNPCheck (DataRow singleRowData)
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
				this._checkID = (long) returnRow["CheckID"];

                if (returnRow["CheckStaffingObjectID"] != DBNull.Value)
                    this._checkStaffingObjectID = (long)returnRow["CheckStaffingObjectID"];
                if (returnRow["CheckStaffingObjectTypeID"] != DBNull.Value)
                    this._checkStaffingObjectTypeID = (enumStaffingObjectType)returnRow["CheckStaffingObjectTypeID"];
                if (returnRow["CheckActionTypeID"] != DBNull.Value)
                    this._checkActionTypeID = (int)returnRow["CheckActionTypeID"];
				if (returnRow["CheckUserID"] != DBNull.Value)
					this._checkUserID  = (int) returnRow["CheckUserID"];				
				if (returnRow["CheckDate"] != DBNull.Value)
					this._checkDate = (DateTime) returnRow["CheckDate"];
				
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
            return "CheckID:" + CheckID.ToString();
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
           JNPCheck JNPCheckobj = obj as JNPCheck ;
			
            return (JNPCheckobj == null) ? false : (this.CheckID==JNPCheckobj.CheckID );
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
			return CheckID.GetHashCode();
        }
	#endregion
	
	
		
	}
}

