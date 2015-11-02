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
	/// JQFactorType Business Object
	/// </summary>
	[Serializable]
	public class JQFactorType : BusinessBase
	{
	#region Private Members
	
		private int _jQFactorTypeID  = -1;
		private string _factorType  = string.Empty;
			
		#endregion
	
	#region Properties
	
	public int JQFactorTypeID
	{
		get
		{
			return this._jQFactorTypeID;
		}
		set
		{
			this._jQFactorTypeID = value;
		}
	}
	
	public string FactorType
	{
		get
		{
			return this._factorType;
		}
		set
		{
			this._factorType = value;
		}
	}
	
		#endregion
	
	#region Constructors
	
	public JQFactorType (DataRow singleRowData)
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
					this._jQFactorTypeID = (int) returnRow["JQFactorTypeID"];
					this._factorType = returnRow["FactorType"].ToString();
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
            return "JQFactorTypeID:" + JQFactorTypeID.ToString();
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
           JQFactorType JQFactorTypeobj = obj as JQFactorType ;
			
            return (JQFactorTypeobj == null) ? false : (this.JQFactorTypeID==JQFactorTypeobj.JQFactorTypeID );
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
			return JQFactorTypeID.GetHashCode();
        }
	#endregion
	
	#region Collection Helper Methods
	
	internal static List<JQFactorType> GetCollection (DataTable dataItems)
	{
		List<JQFactorType> listCollection = new List<JQFactorType>();
		JQFactorType current = null;
		
		if (dataItems != null)
		{
			for (int i = 0; i < dataItems.Rows.Count; i++)
			{
				current = new JQFactorType (dataItems.Rows[i]);
				listCollection.Add(current);
			}
		}
		else
			throw new Exception("You cannot create a JQFactorType collection from a null data table.");

		return listCollection;
	}
		
	#endregion
	
	}

    public class JQFactorTypeEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}

