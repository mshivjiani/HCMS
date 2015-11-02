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
	/// RatingScaleType Business Object
	/// </summary>
	[Serializable]
	public class RatingScaleType : BusinessBase
	{
	#region Private Members
	
		private int _ratingScaleTypeID  = -1;
		private string _ratingScaleName  = string.Empty;
		private string _ratingScaleDescription  = string.Empty;
			
		#endregion
	
	#region Properties
	
	public int RatingScaleTypeID
	{
		get
		{
			return this._ratingScaleTypeID;
		}
		set
		{
			this._ratingScaleTypeID = value;
		}
	}
	
	public string RatingScaleName
	{
		get
		{
			return this._ratingScaleName;
		}
		set
		{
			this._ratingScaleName = value;
		}
	}
	
	public string RatingScaleDescription
	{
		get
		{
			return this._ratingScaleDescription;
		}
		set
		{
			this._ratingScaleDescription = value;
		}
	}
	
		#endregion
	
	#region Constructors
	
	public RatingScaleType (DataRow singleRowData)
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
					this._ratingScaleTypeID = (int) returnRow["RatingScaleTypeID"];
					this._ratingScaleName = returnRow["RatingScaleName"].ToString();
				
				if (returnRow["RatingScaleDescription"] != DBNull.Value)
					this._ratingScaleDescription = returnRow["RatingScaleDescription"].ToString();
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
            return "RatingScaleTypeID:" + RatingScaleTypeID.ToString();
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
           RatingScaleType RatingScaleTypeobj = obj as RatingScaleType ;
			
            return (RatingScaleTypeobj == null) ? false : (this.RatingScaleTypeID==RatingScaleTypeobj.RatingScaleTypeID );
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
			return RatingScaleTypeID.GetHashCode();
        }
	#endregion
	
	#region Collection Helper Methods
	
	internal static List<RatingScaleType> GetCollection (DataTable dataItems)
	{
		List<RatingScaleType> listCollection = new List<RatingScaleType>();
		RatingScaleType current = null;
		
		if (dataItems != null)
		{
			for (int i = 0; i < dataItems.Rows.Count; i++)
			{
				current = new RatingScaleType (dataItems.Rows[i]);
				listCollection.Add(current);
			}
		}
		else
			throw new Exception("You cannot create a RatingScaleType collection from a null data table.");

		return listCollection;
	}
		
	#endregion
	
	}
    [Serializable]
    public class RatingScaleTypeEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public RatingScaleTypeEntity()
        {
        }

        public RatingScaleTypeEntity(int id, string name, string desc)
        {
            this.ID = id;
            this.Name = name;
            this.Description = desc;
        }
    }
}

