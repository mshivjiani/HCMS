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
	/// JNPApproval Business Object
	/// </summary>
	[Serializable]
	public class JNPApproval : BusinessBase
	{
        #region Properties
        public long ID { get; set; }
        public int SupervisorID {get; set;}
        public string SupervisorFullName {get; set;}
        public string SupervisorOrgTitle {get; set;}
        public DateTime? SupervisorSignDate {get; set;}
        public int HRPersonnelID {get; set;}
        public string HRPersonnelFullName {get; set;}
        public string HRPersonnelOrgTitle {get; set;}
        public DateTime? HRPersonnelSignDate {get; set;}
        public long JNPID {get; set;}
        public long JAID {get; set;}
        public long CRID {get; set;}
        public long JQID {get; set;}
        #endregion
	
    //#region Constructors
	
    //public JNPApproval ()
    //{
    //    // Empty Constructor
    //}
		
    //public JNPApproval (int loadByID)
    //{
    //    // Load Object by ID
    //    DataTable returnTable;
    //    try
    //    {
    //        returnTable = ExecuteDataTable("spr_GetJNPApprovalByID", loadByID);
    //        loadData(returnTable);
    //    }
    //    catch (Exception ex)
    //    {
    //        HandleException(ex);
    //     }
    //}	
	
    //public JNPApproval (DataRow singleRowData)
    //{
    //    // Load Object by dataRow
    //    try
    //    {
    //        this.FillObjectFromRowData (singleRowData);
    //    }
    //    catch (Exception ex)
    //    {
    //        HandleException(ex);
    //     }
    //}	
	
    //#endregion
	
    //#region Constructor Helper Methods
	
    //private void loadData (DataTable returnTable)
    //{
    //    if (returnTable.Rows.Count > 0) 
    //    {
    //        DataRow returnRow = returnTable.Rows[0];
			
    //        this.FillObjectFromRowData(returnRow);
    //    }
    //}
	
    //protected virtual void FillObjectFromRowData (DataRow returnRow)
    //{		
    //                this._approvalID = (long) returnRow["ApprovalID"];
				
    //            if (returnRow["SupervisorID"] != DBNull.Value)
    //                this._supervisorID = (int) returnRow["SupervisorID"];
				
				
    //            if (returnRow["SupervisorFullName"] != DBNull.Value)
    //                this._supervisorFullName = returnRow["SupervisorFullName"].ToString();
				
    //            if (returnRow["SupervisorOrgTitle"] != DBNull.Value)
    //                this._supervisorOrgTitle = returnRow["SupervisorOrgTitle"].ToString();
				
    //            if (returnRow["SupervisorSignDate"] != DBNull.Value)
    //                this._supervisorSignDate = (DateTime) returnRow["SupervisorSignDate"];
				
				
    //            if (returnRow["HRPersonnelID"] != DBNull.Value)
    //                this._hRPersonnelID = (int) returnRow["HRPersonnelID"];
				
				
    //            if (returnRow["HRPersonnelFullName"] != DBNull.Value)
    //                this._hRPersonnelFullName = returnRow["HRPersonnelFullName"].ToString();
				
    //            if (returnRow["HRPersonnelOrgTitle"] != DBNull.Value)
    //                this._hRPersonnelOrgTitle = returnRow["HRPersonnelOrgTitle"].ToString();
				
    //            if (returnRow["HRPersonnelSignDate"] != DBNull.Value)
    //                this._hRPersonnelSignDate = (DateTime) returnRow["HRPersonnelSignDate"];
				
				
    //            if (returnRow["JNPID"] != DBNull.Value)
    //                this._jNPID = (long) returnRow["JNPID"];
				
				
    //            if (returnRow["JAID"] != DBNull.Value)
    //                this._jAID = (long) returnRow["JAID"];
				
				
    //            if (returnRow["CRID"] != DBNull.Value)
    //                this._cRID = (long) returnRow["CRID"];
				
				
    //            if (returnRow["JQID"] != DBNull.Value)
    //                this._jQID = (long) returnRow["JQID"];
				
    //}
	
    //#endregion
	
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
            return "ApprovalID:" + ID.ToString();
        }

    #endregion ToString Method

    /// <summary>
    /// Serves as a hash function for a particular type. GetHashCode() is suitable
    /// for use in hashing algorithms and data structures like a hash table.
    /// </summary>
    /// <returns>A hash code for the current object.</returns>
    public override int GetHashCode()
    {
		return ID.GetHashCode();
    }
	
//	#region General Methods
	
//    public void Add()
//    {
    
	
//        DbCommand commandWrapper = GetDbCommand("spr_AddJNPApproval");
		
//        try
//        {
//            SqlParameter returnParam = new SqlParameter("@newApprovalID", SqlDbType.Int);
//            returnParam.Direction = ParameterDirection.Output;

//            // get the new ApprovalID of the record
//            commandWrapper.Parameters.Add(returnParam);
			

//if (this._supervisorID == -1)
//commandWrapper.Parameters.Add(new SqlParameter("@supervisorID", DBNull.Value));
//else
//commandWrapper.Parameters.Add(new SqlParameter("@supervisorID", this._supervisorID));
//commandWrapper.Parameters.Add(new SqlParameter("@supervisorFullName", this._supervisorFullName));
//commandWrapper.Parameters.Add(new SqlParameter("@supervisorOrgTitle", this._supervisorOrgTitle));

//if (this._supervisorSignDate == DateTime.MinValue)
//commandWrapper.Parameters.Add(new SqlParameter("@supervisorSignDate", DBNull.Value));
//else
//commandWrapper.Parameters.Add(new SqlParameter("@supervisorSignDate", this._supervisorSignDate));

//if (this._hRPersonnelID == -1)
//commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelID", DBNull.Value));
//else
//commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelID", this._hRPersonnelID));
//commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelFullName", this._hRPersonnelFullName));
//commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelOrgTitle", this._hRPersonnelOrgTitle));

//if (this._hRPersonnelSignDate == DateTime.MinValue)
//commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelSignDate", DBNull.Value));
//else
//commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelSignDate", this._hRPersonnelSignDate));

//if (this._jNPID == -1)
//commandWrapper.Parameters.Add(new SqlParameter("@jNPID", DBNull.Value));
//else
//commandWrapper.Parameters.Add(new SqlParameter("@jNPID", this._jNPID));

//if (this._jAID == -1)
//commandWrapper.Parameters.Add(new SqlParameter("@jAID", DBNull.Value));
//else
//commandWrapper.Parameters.Add(new SqlParameter("@jAID", this._jAID));

//if (this._cRID == -1)
//commandWrapper.Parameters.Add(new SqlParameter("@cRID", DBNull.Value));
//else
//commandWrapper.Parameters.Add(new SqlParameter("@cRID", this._cRID));

//if (this._jQID == -1)
//commandWrapper.Parameters.Add(new SqlParameter("@jQID", DBNull.Value));
//else
//commandWrapper.Parameters.Add(new SqlParameter("@jQID", this._jQID));

//            ExecuteNonQuery(commandWrapper);
           
//            this._approvalID  = (int) returnParam.Value;
//          }
//        catch (Exception ex)
//        {
//            HandleException(ex);
//         }
//    }
	
//    public void Update()
//    {
    
//        if (base.ValidateKeyField(this._approvalID))
//        {
//            DbCommand commandWrapper = GetDbCommand("spr_UpdateJNPApproval");
			
//            try
//            {
//commandWrapper.Parameters.Add(new SqlParameter("@approvalID", this._approvalID));

//if (this._supervisorID == -1)
//commandWrapper.Parameters.Add(new SqlParameter("@supervisorID", DBNull.Value));
//else
//commandWrapper.Parameters.Add(new SqlParameter("@supervisorID", this._supervisorID));
//commandWrapper.Parameters.Add(new SqlParameter("@supervisorFullName", this._supervisorFullName));
//commandWrapper.Parameters.Add(new SqlParameter("@supervisorOrgTitle", this._supervisorOrgTitle));

//if (this._supervisorSignDate == DateTime.MinValue)
//commandWrapper.Parameters.Add(new SqlParameter("@supervisorSignDate", DBNull.Value));
//else
//commandWrapper.Parameters.Add(new SqlParameter("@supervisorSignDate", this._supervisorSignDate));

//if (this._hRPersonnelID == -1)
//commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelID", DBNull.Value));
//else
//commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelID", this._hRPersonnelID));
//commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelFullName", this._hRPersonnelFullName));
//commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelOrgTitle", this._hRPersonnelOrgTitle));

//if (this._hRPersonnelSignDate == DateTime.MinValue)
//commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelSignDate", DBNull.Value));
//else
//commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelSignDate", this._hRPersonnelSignDate));

//if (this._jNPID == -1)
//commandWrapper.Parameters.Add(new SqlParameter("@jNPID", DBNull.Value));
//else
//commandWrapper.Parameters.Add(new SqlParameter("@jNPID", this._jNPID));

//if (this._jAID == -1)
//commandWrapper.Parameters.Add(new SqlParameter("@jAID", DBNull.Value));
//else
//commandWrapper.Parameters.Add(new SqlParameter("@jAID", this._jAID));

//if (this._cRID == -1)
//commandWrapper.Parameters.Add(new SqlParameter("@cRID", DBNull.Value));
//else
//commandWrapper.Parameters.Add(new SqlParameter("@cRID", this._cRID));

//if (this._jQID == -1)
//commandWrapper.Parameters.Add(new SqlParameter("@jQID", DBNull.Value));
//else
//commandWrapper.Parameters.Add(new SqlParameter("@jQID", this._jQID));

//                ExecuteNonQuery(commandWrapper);
//            }
//            catch (Exception ex)
//            {
//                HandleException(ex);
//            }
//        }
//    }		
	
    //public void Delete()
    //{
    //    if (base.ValidateKeyField(this._approvalID))
    //    {
    //        try
    //        {
    //            ExecuteNonQuery("spr_DeleteJNPApproval", this._approvalID);
    //        }
    //        catch (Exception ex)
    //        {
    //            HandleException(ex);
    //        }
    //    }
    //}
		
//	#endregion
	
    //#region Collection Helper Methods
	
    //internal static List<JNPApproval> GetCollection (DataTable dataItems)
    //{
    //    List<JNPApproval> listCollection = new List<JNPApproval>();
    //    JNPApproval current = null;
		
    //    if (dataItems != null)
    //    {
    //        for (int i = 0; i < dataItems.Rows.Count; i++)
    //        {
    //            current = new JNPApproval (dataItems.Rows[i]);
    //            listCollection.Add(current);
    //        }
    //    }
    //    else
    //        throw new Exception("You cannot create a JNPApproval collection from a null data table.");

    //    return listCollection;
    //}
		
    //#endregion
	
    //#region Collection Methods
		
    //    #endregion
		
	}
}

