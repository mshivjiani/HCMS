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
	/// JQWorkflowStatus Business Object
	/// </summary>
	[Serializable]
	public class JQWorkflowStatus : BusinessBase
	{
	#region Private Members
	
		private long _jQWorkflowRecID  = -1;
		private long _jQID  = -1;
		private int _jQWorkflowStatusID  = -1;
		private bool _isCurrent  = false;
		private int _createdByID  = -1;
		private DateTime _createDate  = DateTime.MinValue;
			
		#endregion
	
	#region Properties
	
	public long JQWorkflowRecID
	{
		get
		{
			return this._jQWorkflowRecID;
		}
		set
		{
			this._jQWorkflowRecID = value;
		}
	}
	
	public long JQID
	{
		get
		{
			return this._jQID;
		}
		set
		{
			this._jQID = value;
		}
	}
	
	public int JQWorkflowStatusID
	{
		get
		{
			return this._jQWorkflowStatusID;
		}
		set
		{
			this._jQWorkflowStatusID = value;
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
	
	#region Constructor
	
	public JQWorkflowStatus ()
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
            return "JQWorkflowRecID:" + JQWorkflowRecID.ToString();
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
           JQWorkflowStatus JQWorkflowStatusobj = obj as JQWorkflowStatus ;
			
            return (JQWorkflowStatusobj == null) ? false : (this.JQWorkflowRecID==JQWorkflowStatusobj.JQWorkflowRecID );
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
			return JQWorkflowRecID.GetHashCode();
        }
	#endregion

     
	}
}

