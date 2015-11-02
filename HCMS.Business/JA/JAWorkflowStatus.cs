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
	/// JAWorkflowStatus Business Object
	/// </summary>
	[Serializable]
	public class JAWorkflowStatus 
	{
	#region Private Members
	
		private long _jAWorkflowRecID  = -1;
		private long _jAID  = -1;
		private int _jAWorkflowStatusID  = -1;
		private bool _isCurrent  = false;
		private int _createdByID  = -1;
		private DateTime _createDate  = DateTime.MinValue;
			
		#endregion
	
	#region Properties
	
	public long JAWorkflowRecID
	{
		get
		{
			return this._jAWorkflowRecID;
		}
		set
		{
			this._jAWorkflowRecID = value;
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
	
	public int JAWorkflowStatusID
	{
		get
		{
			return this._jAWorkflowStatusID;
		}
		set
		{
			this._jAWorkflowStatusID = value;
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
	
	public JAWorkflowStatus ()
	{
		// Empty Constructor
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
            return "JAWorkflowRecID:" + JAWorkflowRecID.ToString();
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
           JAWorkflowStatus JAWorkflowStatusobj = obj as JAWorkflowStatus ;
			
            return (JAWorkflowStatusobj == null) ? false : (this.JAWorkflowRecID==JAWorkflowStatusobj.JAWorkflowRecID );
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
			return JAWorkflowRecID.GetHashCode();
        }
	#endregion
	
	
		
	}
}

