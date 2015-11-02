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

namespace HCMS.Lookups
{
	/// <summary>
	/// JNPWorkflowStatus Business Object
	/// </summary>
	[Serializable]
	public class JNPWorkflowStatus : BusinessBase
	{
	#region Private Members
	
		private int _jNPWorkflowStatusID  = -1;
		private string _jNPWorkflowStatus  = string.Empty;
		private string _jNPWorkflowStatusDescription  = string.Empty;
			
		#endregion
	
	#region Properties
	
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
	
	public string JNPWorkflowStatusName
	{
		get
		{
			return this._jNPWorkflowStatus;
		}
		set
		{
			this._jNPWorkflowStatus = value;
		}
	}
	
	public string JNPWorkflowStatusDescription
	{
		get
		{
			return this._jNPWorkflowStatusDescription;
		}
		set
		{
			this._jNPWorkflowStatusDescription = value;
		}
	}
	
		#endregion
	
	#region Constructors
	
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
	
	protected virtual void FillObjectFromRowData (DataRow returnRow)
	{		
					this._jNPWorkflowStatusID = (int) returnRow["JNPWorkflowStatusID"];
					this._jNPWorkflowStatus = returnRow["JNPWorkflowStatus"].ToString();
				
				if (returnRow["JNPWorkflowStatusDescription"] != DBNull.Value)
					this._jNPWorkflowStatusDescription = returnRow["JNPWorkflowStatusDescription"].ToString();
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
            return "JNPWorkflowStatusID:" + JNPWorkflowStatusID.ToString();
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
			
            return (JNPWorkflowStatusobj == null) ? false : (this.JNPWorkflowStatusID==JNPWorkflowStatusobj.JNPWorkflowStatusID );
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
			return JNPWorkflowStatusID.GetHashCode();
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
	
	}
}

