using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

using HCMS.Business.Common;
using HCMS.Business.Base;
using System.Data.SqlClient;
using HCMS.Business.Lookups;
using HCMS.Lookups;
using HCMS.Business.Admin;

namespace HCMS.Business.JNP
{
    [System.ComponentModel.DataObject]
    public class JNPManager : BusinessBase
    {
        //For report purpose
        public static long jnpid = 0;

        public List<JNPSearchResult> GetNonPublishedJNPsByUserID(int userID)
        {
            List<JNPSearchResult> listCollection = new List<JNPSearchResult>();

            DataTable dataItems = ExecuteDataTable("spr_GetNonPublishedJNPsByUserID", userID);

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    JNPSearchResult item = new JNPSearchResult();
                    jnpid = dataItems.Rows[i].Field<long>("JNPID");
                    item.JNPID = dataItems.Rows[i].Field<long>("JNPID");
                    item.SeriesID =  dataItems.Rows[i].Field<int>("SeriesID");
                    item.SeriesName = dataItems.Rows[i].Field<string>("SeriesName");
                    item.RegionID = dataItems.Rows[i].Field<int>("RegionID");
                    item.RegionName = dataItems.Rows[i].Field<string>("RegionName");
                    item.OrganizationCodeID = dataItems.Rows[i].Field<int>("OrganizationCodeID");
                    item.OldOrganizationCode = dataItems.Rows[i].Field<int>("OldOrganizationCode");
                    item.OrganizationCode = dataItems.Rows[i].Field<string>("OrganizationCode");
                    item.OrganizationName = dataItems.Rows[i].Field<string>("OrganizationName");
                    item.JNPWorkflowStatusID = dataItems.Rows[i].Field<int>("JNPWorkflowStatusID");
                    item.JNPWorkflowStatus = dataItems.Rows[i].Field<string>("JNPWorkflowStatus");

                    listCollection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a JNPSearchResult collection from a null data table.");
            }

            return listCollection;
        }

        public void ChangeJNPOwner(long jnpID, int newOwnerUserID, int currentUserID)
        {
            ChangeJNPOwner(jnpID, newOwnerUserID, currentUserID, null);
        }

        public void ChangeJNPOwner(long jnpID, int newOwnerUserID, int currentUserID, TransactionManager currentTransaction)
        {
            if (base.ValidateKeyField(jnpID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_ChangeJNPOwner");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@JNPID", jnpID));
                    commandWrapper.Parameters.Add(new SqlParameter("@NewOwnerUserID", newOwnerUserID));
                    commandWrapper.Parameters.Add(new SqlParameter("@CheckInByUserID", currentUserID));

                    if (currentTransaction != null)
                    {
                        DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);
                    }
                    else
                    {
                        ExecuteNonQuery(commandWrapper);
                    }

                }
                catch (Exception ex)
                {
                    currentTransaction.Rollback();
                    HandleException(ex);
                }
            }
        }

        public List<JNPSearchResult> SearchJNPAdmin(long? jnpID = null, int? orgCodeID = null, int? userID = null)
        {
            List<JNPSearchResult> listCollection = new List<JNPSearchResult>();

            DataTable dataItems = ExecuteDataTable("spr_SearchJNPAdmin", jnpID, orgCodeID, userID);

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    JNPSearchResult item = new JNPSearchResult();

                    item.JNPID = dataItems.Rows[i].Field<long>("JNPID");
                    item.JNPTitle = dataItems.Rows[i].Field<string>("JNPTitle");
                    item.SeriesID = dataItems.Rows[i].Field<int>("SeriesID");
                    item.SeriesName = dataItems.Rows[i].Field<string>("SeriesName");
                    item.RegionID = dataItems.Rows[i].Field<int>("RegionID");
                    item.RegionName = dataItems.Rows[i].Field<string>("RegionName");
                    item.OrganizationCodeID = dataItems.Rows[i].Field<int>("OrganizationCodeID");
                    item.OrganizationCode = dataItems.Rows[i].Field<string>("OrganizationCode");
                    item.OrganizationName = dataItems.Rows[i].Field<string>("OrganizationName");
                    item.JNPWorkflowStatusID = dataItems.Rows[i].Field<int>("JNPWorkflowStatusID");
                    item.JNPWorkflowStatus = dataItems.Rows[i].Field<string>("JNPWorkflowStatus");

                    listCollection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a JNPSearchResult collection from a null data table.");
            }

            return listCollection;
        }

        public void ReactivateJNP(long jnpID, int userID)
        {
            ChangeJNPActivation(jnpID, true, userID);
        }

        public void DeactivateJNP(long jnpID, int userID)
        {
            ChangeJNPActivation(jnpID, false, userID);
        }

        private void ChangeJNPActivation(long jnpID, bool reActivate, int userID)
        {
            try
            {
                DbCommand commandWrapper = GetDbCommand("spr_ChangeJNPActivation");

                commandWrapper.Parameters.Add(new SqlParameter("@JNPIDLoad", jnpID));
                commandWrapper.Parameters.Add(new SqlParameter("@reActivate", reActivate));
                commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", userID));

                ExecuteNonQuery(commandWrapper);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
    }
}
