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
using HCMS.Business.JQ.Collections;

namespace HCMS.Business.JQ
{
	/// <summary>
	/// JQRatingScale Business Object
	/// </summary>
	[Serializable]
	public class JQRatingScale : JQCommonBase
	{
	    #region Private Members
	
		private long _ratingScaleID  = -1;
		private int _ratingScaleTypeID  = -1;
		private string _ratingScaleInstruction  = string.Empty;
		private bool _isDefault  = false;
			
		#endregion
	
	    #region Properties
	
	    public long RatingScaleID
	    {
		    get
		    {
			    return this._ratingScaleID;
		    }
		    set
		    {
			    this._ratingScaleID = value;
		    }
	    }
	
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
	
	    public string RatingScaleInstruction
	    {
		    get
		    {
			    return this._ratingScaleInstruction;
		    }
		    set
		    {
			    this._ratingScaleInstruction = value;
		    }
	    }
	
	    public bool IsDefault
	    {
		    get
		    {
			    return this._isDefault;
		    }
		    set
		    {
			    this._isDefault = value;
		    }
	    }
	
		#endregion
	
	    #region Constructors
	
	    public JQRatingScale ()
	    {
		    // Empty Constructor
	    }
		
	    public JQRatingScale (int loadByID)
	    {
		    // Load Object by ID
		    DataTable returnTable;
		    try
            {
                returnTable = ExecuteDataTable("spr_GetJQRatingScaleByID", loadByID);
			    loadData(returnTable);
		    }
            catch (Exception ex)
            {
                HandleException(ex);
             }
	    }	
	
	    public JQRatingScale (DataRow singleRowData)
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
            if (returnRow["RatingScaleID"] != DBNull.Value)
			    this._ratingScaleID = (long) returnRow["RatingScaleID"];

            if (returnRow["RatingScaleTypeID"] != DBNull.Value)
			    this._ratingScaleTypeID = (int) returnRow["RatingScaleTypeID"];
				
		    if (returnRow["RatingScaleInstruction"] != DBNull.Value)
			    this._ratingScaleInstruction = returnRow["RatingScaleInstruction"].ToString();
				
		    if (returnRow["IsDefault"] != DBNull.Value)
			    this._isDefault = (bool) returnRow["IsDefault"];
				
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
            return "RatingScaleID:" + RatingScaleID.ToString();
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
           JQRatingScale JQRatingScaleobj = obj as JQRatingScale ;
			
            return (JQRatingScaleobj == null) ? false : (this.RatingScaleID==JQRatingScaleobj.RatingScaleID );
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
			return RatingScaleID.GetHashCode();
        }

	    #endregion
	
	    #region Collection Methods
		
		public JQFactorItemCollection GetJQFactorItemByJQFactorItemID()
		{
            JQFactorItemCollection childDataCollection = null;
			if (base.ValidateKeyField(this._ratingScaleID))
			{
				try
				{
					DataTable dt = ExecuteDataTable("spr_GetJQFactorItemByRatingScaleID", this._ratingScaleID);
						
					// fill collection list
                    childDataCollection = new JQFactorItemCollection(dt);
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

    public class JQRatingScaleEntity
    {
        public long ID { get; set; }
        public int RatingScaleTypeID { get; set; }
        public string RatingScaleInstruction { get; set; }
        public bool IsDefault { get; set; }
    }
}

