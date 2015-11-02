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
	/// RatingScaleResponse Business Object
	/// </summary>
	[Serializable]
    public class RatingScaleResponse : JQCommonBase
	{
	#region Private Members
	
		private long _JQResponseID  = -1;
		private int _JQResponseNo  = -1;
		private string _JQResponseLetter  = string.Empty;
		private string _JQResponseText  = string.Empty;
		private long _JQRatingScaleID  = -1;
			
		#endregion
	
	#region Properties
	
	public long JQResponseID
	{
		get
		{
			return this._JQResponseID;
		}
		set
		{
			this._JQResponseID = value;
		}
	}
	
	public int JQResponseNo
	{
		get
		{
			return this._JQResponseNo;
		}
		set
		{
			this._JQResponseNo = value;
		}
	}
	
	public string JQResponseLetter
	{
		get
		{
			return this._JQResponseLetter;
		}
		set
		{
			this._JQResponseLetter = value;
		}
	}
	
	public string JQResponseText
	{
		get
		{
			return this._JQResponseText;
		}
		set
		{
			this._JQResponseText = value;
		}
	}
	
	public long JQRatingScaleID
	{
		get
		{
			return this._JQRatingScaleID;
		}
		set
		{
			this._JQRatingScaleID = value;
		}
	}
	
		#endregion
	
	#region Constructors
	
	public RatingScaleResponse ()
	{
		// Empty Constructor
	}

    public RatingScaleResponse(RatingScaleResponseEntity loadByEntity)
    {
        try
        {
            // allows conversion from JQFactorItemEntity to JQFactorItem
            this._JQResponseID = loadByEntity.ID;
            this._JQResponseNo = loadByEntity.ResponseNo;
            this._JQResponseLetter = loadByEntity.ResponseLetter;
            this._JQResponseText = loadByEntity.ResponseText;
            this._JQRatingScaleID = loadByEntity.RatingScaleID;
        }
        catch (Exception ex)
        {
            HandleException(ex);
        }
    }

		
	public RatingScaleResponse (int loadByID)
	{
		// Load Object by ID
		DataTable returnTable;
		try
        {
            returnTable = ExecuteDataTable("spr_GetRatingScaleResponseByID", loadByID);
			loadData(returnTable);
		}
        catch (Exception ex)
        {
            HandleException(ex);
         }
	}	
	
	public RatingScaleResponse (DataRow singleRowData)
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
        if (returnRow["JQResponseID"] != DBNull.Value)
		    this._JQResponseID = (long) returnRow["JQResponseID"];

        if (returnRow["JQResponseNo"] != DBNull.Value)
            this._JQResponseNo = (int) returnRow["JQResponseNo"];
				
		if (returnRow["JQResponseLetter"] != DBNull.Value)
			this._JQResponseLetter = returnRow["JQResponseLetter"].ToString();

        if (returnRow["JQResponseText"] != DBNull.Value)
			this._JQResponseText = returnRow["JQResponseText"].ToString();

        if (returnRow["JQRatingScaleID"] != DBNull.Value)
            this._JQRatingScaleID = (long) returnRow["JQRatingScaleID"];
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
            return "JQResponseID:" + JQResponseID.ToString();
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
           RatingScaleResponse RatingScaleResponseobj = obj as RatingScaleResponse ;
			
            return (RatingScaleResponseobj == null) ? false : (this.JQResponseID==RatingScaleResponseobj.JQResponseID );
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
			return JQResponseID.GetHashCode();
        }
	#endregion
	
	#region General Methods

    // disabled this method since is not being used anywhere in the system and it adds more overhead to this object
//    public void Add()
//    {
    
	
//        DbCommand commandWrapper = GetDbCommand("spr_AddRatingScaleResponse");
		
//        try
//        {
//            SqlParameter returnParam = new SqlParameter("@newJQResponseID", SqlDbType.Int);
//            returnParam.Direction = ParameterDirection.Output;

//            // get the new JQResponseID of the record
//            commandWrapper.Parameters.Add(returnParam);
			
//commandWrapper.Parameters.Add(new SqlParameter("@jQResponseNo", this._JQResponseNo));
//commandWrapper.Parameters.Add(new SqlParameter("@jQResponseLetter", this._JQResponseLetter));
//commandWrapper.Parameters.Add(new SqlParameter("@jQResponseText", this._JQResponseText.Trim()));
//commandWrapper.Parameters.Add(new SqlParameter("@jQRatingScaleID", this._JQRatingScaleID));

//            ExecuteNonQuery(commandWrapper);
           
//            this._JQResponseID  = (int) returnParam.Value;
//          }
//        catch (Exception ex)
//        {
//            HandleException(ex);
//         }
//    }

    // disabled this method since is not being used anywhere in the system and it adds more overhead to this object
//    public void Update()
//    {
    
//        if (base.ValidateKeyField(this._JQResponseID))
//        {
//            DbCommand commandWrapper = GetDbCommand("spr_UpdateRatingScaleResponse");
			
//            try
//            {
//commandWrapper.Parameters.Add(new SqlParameter("@jQResponseID", this._JQResponseID));
//commandWrapper.Parameters.Add(new SqlParameter("@jQResponseNo", this._JQResponseNo));
//commandWrapper.Parameters.Add(new SqlParameter("@jQResponseLetter", this._JQResponseLetter));
//commandWrapper.Parameters.Add(new SqlParameter("@jQResponseText", this._JQResponseText.Trim()));
//commandWrapper.Parameters.Add(new SqlParameter("@jQRatingScaleID", this._JQRatingScaleID));

//                ExecuteNonQuery(commandWrapper);
//            }
//            catch (Exception ex)
//            {
//                HandleException(ex);
//            }
//        }
//    }		
	
//    public void Delete()
//    {
//        if (base.ValidateKeyField(this._JQResponseID))
//        {
//            try
//            {
//                ExecuteNonQuery("spr_DeleteRatingScaleResponse", this._JQResponseID);
//            }
//            catch (Exception ex)
//            {
//                HandleException(ex);
//            }
//        }
//    }
		
	#endregion
	
	#region Collection Helper Methods
	
	internal static List<RatingScaleResponse> GetCollection (DataTable dataItems)
	{
		List<RatingScaleResponse> listCollection = new List<RatingScaleResponse>();
		RatingScaleResponse current = null;
		
		if (dataItems != null)
		{
			for (int i = 0; i < dataItems.Rows.Count; i++)
			{
				current = new RatingScaleResponse (dataItems.Rows[i]);
				listCollection.Add(current);
			}
		}
		else
			throw new Exception("You cannot create a RatingScaleResponse collection from a null data table.");

		return listCollection;
	}
		
	#endregion
	
	#region Collection Methods
		
		#endregion
		
	}

    public class RatingScaleResponseEntity
    {
        public long ID { get; set; }
        public int ResponseNo { get; set; }
        public string ResponseLetter { get; set; }
        public string ResponseText { get; set; }
        public long RatingScaleID { get; set; }
        public int RatingScaleTypeID { get; set; }
        public bool IsDefault { get; set; }
    }
}

