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
    public class JNPApprovalManager : BusinessBase
    {
        #region General CRUD Methods
        public long Add(JNPApproval entity, SignatureType signaturetypeID)
        {
            return Add(entity, null, signaturetypeID);
        }

        public long Add(JNPApproval entity, TransactionManager currentTransaction, SignatureType signaturetypeID)
        {
            long returnCode = -1;

            DbCommand commandWrapper = GetDbCommand("spr_AddJNPApproval");

            try
            {
                SqlParameter returnParam = new SqlParameter("@newApprovalID", SqlDbType.BigInt);
                returnParam.Direction = ParameterDirection.Output;

                // get the new ApprovalID of the record
                commandWrapper.Parameters.Add(returnParam);

                if (entity.SupervisorID <= 0)
                    commandWrapper.Parameters.Add(new SqlParameter("@supervisorID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@supervisorID", entity.SupervisorID));

                if (string.IsNullOrEmpty(entity.SupervisorFullName))
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@supervisorFullName", DBNull.Value));
                }
                else
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@supervisorFullName", entity.SupervisorFullName));
                }

                if (string.IsNullOrEmpty(entity.SupervisorOrgTitle))
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@supervisorOrgTitle", DBNull.Value));
                }
                else
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@supervisorOrgTitle", entity.SupervisorOrgTitle));
                }

                if (!entity.SupervisorSignDate.HasValue)
                    commandWrapper.Parameters.Add(new SqlParameter("@supervisorSignDate", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@supervisorSignDate", entity.SupervisorSignDate));

                if (entity.HRPersonnelID <= 0)
                    commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelID", entity.HRPersonnelID));

                if (string.IsNullOrEmpty(entity.HRPersonnelFullName))
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelFullName", DBNull.Value));
                }
                else
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelFullName", entity.HRPersonnelFullName));
                }

                if (string.IsNullOrEmpty(entity.HRPersonnelOrgTitle))
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelOrgTitle", DBNull.Value));
                }
                else
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelOrgTitle", entity.HRPersonnelOrgTitle));
                }

                if (!entity.HRPersonnelSignDate.HasValue)
                    commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelSignDate", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelSignDate", entity.HRPersonnelSignDate));

                if (entity.JNPID <= 0)
                    commandWrapper.Parameters.Add(new SqlParameter("@jNPID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@jNPID", entity.JNPID));

                if (entity.JAID <= 0)
                    commandWrapper.Parameters.Add(new SqlParameter("@jAID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@jAID", entity.JAID));

                if (entity.CRID <= 0)
                    commandWrapper.Parameters.Add(new SqlParameter("@cRID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@cRID", entity.CRID));

                if (entity.JQID <= 0)
                    commandWrapper.Parameters.Add(new SqlParameter("@jQID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@jQID", entity.JQID));

               
                commandWrapper.Parameters.Add(new SqlParameter("@signatureTypeID", (int)signaturetypeID));

                if (currentTransaction != null)
                {
                    DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);
                }
                else
                {
                    ExecuteNonQuery(commandWrapper);
                }

                returnCode = (long) returnParam.Value;
            }
            catch (Exception ex)
            {
                currentTransaction.Rollback();
                HandleException(ex);
            }

            return returnCode;
        }

        public JNPApproval GetJNPApprovalByID(long approvalID)
        {
            JNPApproval entity;

            DataTable dt = ExecuteDataTable("spr_GetJNPApprovalByID", approvalID);

            if (dt != null && dt.Rows.Count > 0)
            {
                entity = new JNPApproval();

                entity.ID = dt.Rows[0].Field<long>("ApprovalID");
                entity.SupervisorID = dt.Rows[0].Field<int>("SupervisorID");
                entity.SupervisorFullName = dt.Rows[0].Field<string>("SupervisorFullName");
                entity.SupervisorOrgTitle = dt.Rows[0].Field<string>("SupervisorOrgTitle");
                entity.SupervisorSignDate = dt.Rows[0].Field<DateTime?>("SupervisorSignDate");
                entity.HRPersonnelID = dt.Rows[0].Field<int>("HRPersonnelID");
                entity.HRPersonnelFullName = dt.Rows[0].Field<string>("HRPersonnelFullName");
                entity.HRPersonnelOrgTitle = dt.Rows[0].Field<string>("HRPersonnelOrgTitle");
                entity.HRPersonnelSignDate = dt.Rows[0].Field<DateTime?>("HRPersonnelSignDate");
                entity.JNPID = dt.Rows[0].Field<long>("JNPID");
                entity.JAID = dt.Rows[0].Field<long>("JAID");
                entity.CRID = dt.Rows[0].Field<long>("CRID");
                entity.JQID = dt.Rows[0].Field<long>("JQID");
            }
            else
            {
                throw new Exception("You cannot create a JNPApproval object from a null data table.");
            }

            return entity;
        }

        public JNPApproval GetJNPApprovalByStaffingObjectID(long staffingObjectID, enumStaffingObjectType staffingObjectTypeID )
        {
            JNPApproval entity = new JNPApproval();
            entity.ID = -1;
            entity.SupervisorID = -1;
            entity.HRPersonnelID = -1;

            DataTable dt = ExecuteDataTable("spr_GetJNPApprovalByStaffingObjectID", staffingObjectID, (int) staffingObjectTypeID); 

            if (dt != null && dt.Rows.Count > 0)
            {
                entity.ID = dt.Rows[0].Field<long>("ApprovalID");
                entity.SupervisorID = dt.Rows[0].IsNull("SupervisorID") ? -1 : dt.Rows[0].Field<int>("SupervisorID");
                entity.SupervisorFullName = dt.Rows[0].IsNull("SupervisorFullName") ? string.Empty : dt.Rows[0].Field<string>("SupervisorFullName");
                entity.SupervisorOrgTitle = dt.Rows[0].IsNull("SupervisorOrgTitle") ? string.Empty : dt.Rows[0].Field<string>("SupervisorOrgTitle");
                entity.SupervisorSignDate = dt.Rows[0].Field<DateTime?>("SupervisorSignDate");
                entity.HRPersonnelID = dt.Rows[0].IsNull("HRPersonnelID") ? -1 : dt.Rows[0].Field<int>("HRPersonnelID");
                entity.HRPersonnelFullName = dt.Rows[0].IsNull("HRPersonnelFullName") ? string.Empty : dt.Rows[0].Field<string>("HRPersonnelFullName");
                entity.HRPersonnelOrgTitle = dt.Rows[0].IsNull("HRPersonnelOrgTitle") ? string.Empty : dt.Rows[0].Field<string>("HRPersonnelOrgTitle");
                entity.HRPersonnelSignDate = dt.Rows[0].Field<DateTime?>("HRPersonnelSignDate");
                entity.JNPID = dt.Rows[0].Field<long>("JNPID");
                entity.JAID = dt.Rows[0].Field<long>("JAID");
                entity.CRID = dt.Rows[0].IsNull("CRID") ? -1 : dt.Rows[0].Field<long>("CRID");
                entity.JQID = dt.Rows[0].Field<long>("JQID");
            }

            return entity;
        }

        public void Update(JNPApproval entity, SignatureType signaturetypeID)
        {
            Update(entity, null, signaturetypeID);
        }

        public void Update(JNPApproval entity, TransactionManager currentTransaction, SignatureType signaturetypeID)
        {
            if (base.ValidateKeyField(entity.ID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateJNPApproval");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@approvalID", entity.ID));

                    if (entity.SupervisorID <= 0)
                        commandWrapper.Parameters.Add(new SqlParameter("@supervisorID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@supervisorID", entity.SupervisorID));

                    if (string.IsNullOrEmpty(entity.SupervisorFullName))
                    {
                        commandWrapper.Parameters.Add(new SqlParameter("@supervisorFullName", DBNull.Value));
                    }
                    else
                    {
                        commandWrapper.Parameters.Add(new SqlParameter("@supervisorFullName", entity.SupervisorFullName));
                    }

                    if (string.IsNullOrEmpty(entity.SupervisorOrgTitle))
                    {
                        commandWrapper.Parameters.Add(new SqlParameter("@supervisorOrgTitle", DBNull.Value));
                    }
                    else
                    {
                        commandWrapper.Parameters.Add(new SqlParameter("@supervisorOrgTitle", entity.SupervisorOrgTitle));
                    }

                    if (!entity.SupervisorSignDate.HasValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@supervisorSignDate", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@supervisorSignDate", entity.SupervisorSignDate));

                    if (entity.HRPersonnelID <= 0)
                        commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelID", entity.HRPersonnelID));

                    if (string.IsNullOrEmpty(entity.HRPersonnelFullName))
                    {
                        commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelFullName", DBNull.Value));
                    }
                    else
                    {
                        commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelFullName", entity.HRPersonnelFullName));
                    }

                    if (string.IsNullOrEmpty(entity.HRPersonnelOrgTitle))
                    {
                        commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelOrgTitle", DBNull.Value));
                    }
                    else
                    {
                        commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelOrgTitle", entity.HRPersonnelOrgTitle));
                    }

                    if (!entity.HRPersonnelSignDate.HasValue)
                        commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelSignDate", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelSignDate", entity.HRPersonnelSignDate));

                    if (entity.JNPID <= 0)
                        commandWrapper.Parameters.Add(new SqlParameter("@jNPID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@jNPID", entity.JNPID));

                    if (entity.JAID <= 0)
                        commandWrapper.Parameters.Add(new SqlParameter("@jAID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@jAID", entity.JAID));

                    if (entity.CRID <= 0)
                        commandWrapper.Parameters.Add(new SqlParameter("@cRID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@cRID", entity.CRID));

                    if (entity.JQID <= 0)
                        commandWrapper.Parameters.Add(new SqlParameter("@jQID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@jQID", entity.JQID));


                    commandWrapper.Parameters.Add(new SqlParameter("@signatureTypeID", (int) signaturetypeID));


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

        public void Delete(long approvalID)
        {
            if (base.ValidateKeyField(approvalID))
            {
                try
                {
                    ExecuteNonQuery("spr_DeleteJNPApproval", approvalID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }
        #endregion
    }
}
