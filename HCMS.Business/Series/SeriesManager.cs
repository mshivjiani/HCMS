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
using HCMS.Business.Admin;

namespace HCMS.Business.Series
{
    [System.ComponentModel.DataObject]
    public class SeriesManager : BusinessBase
    {
        #region General CRUD Methods
        public bool AddOPMTitle(SeriesOPMTitleEntity entity)
        {
            return AddOPMTitle(entity, null);
        }

        public bool AddOPMTitle(SeriesOPMTitleEntity entity, TransactionManager currentTransaction)
        {
            bool isSuccessfullyInserted = false;
            int retcode = -1;

            DbCommand commandWrapper = GetDbCommand("spr_AddSeriesOPMTitle");

            try
            {
                if (entity.SeriesID <= 0)
                    commandWrapper.Parameters.Add(new SqlParameter("@Series", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@Series", entity.SeriesID));

                if (string.IsNullOrEmpty(entity.OPMTitle))
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@SeriesOPMTitle", DBNull.Value));
                }
                else
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@SeriesOPMTitle", entity.OPMTitle));
                }

                if (string.IsNullOrEmpty(entity.OPMDescription))
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@SeriesOPMTitleDescription", DBNull.Value));
                }
                else
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@SeriesOPMTitleDescription", entity.OPMDescription));
                }

                if (currentTransaction != null)
                {
                    retcode = (int) DatabaseUtility.ExecuteScalar(currentTransaction, commandWrapper);
                }
                else
                {
                    retcode = (int) ExecuteScalar(commandWrapper);
                }
            }
            catch (Exception ex)
            {
                currentTransaction.Rollback();
                HandleException(ex);
            }

            if (retcode > 0)
            {
                isSuccessfullyInserted = true;
            }

            return isSuccessfullyInserted;
        }

        public void Update(SeriesOPMTitleEntity entity)
        {
            Update(entity, null);
        }

        public void Update(SeriesOPMTitleEntity entity, TransactionManager currentTransaction)
        {
            if (base.ValidateKeyField(entity.SeriesID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateSeriesOPMTitle");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@series", entity.SeriesID));

                    if (string.IsNullOrEmpty(entity.OPMTitle))
                    {
                        commandWrapper.Parameters.Add(new SqlParameter("@seriesOPMTitle", DBNull.Value));
                    }
                    else
                    {
                        commandWrapper.Parameters.Add(new SqlParameter("@seriesOPMTitle", entity.OPMTitle));
                    }

                    if (string.IsNullOrEmpty(entity.OPMDescription))
                    {
                        commandWrapper.Parameters.Add(new SqlParameter("@SeriesOPMTitleDescription", DBNull.Value));
                    }
                    else
                    {
                        commandWrapper.Parameters.Add(new SqlParameter("@SeriesOPMTitleDescription", entity.OPMDescription));
                    }

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

        public List<SeriesOPMTitleEntity> GetSeriesOPMTitlesBySeriesID(int seriesID)
        {
            List<SeriesOPMTitleEntity> listCollection = new List<SeriesOPMTitleEntity>();

            DataTable dataItems = ExecuteDataTable("spr_GetSeriesOPMTitlesBySeriesID", seriesID);

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    SeriesOPMTitleEntity item = new SeriesOPMTitleEntity();

                    item.SeriesID = dataItems.Rows[i].Field<int>("Series");
                    item.OPMTitle = dataItems.Rows[i].Field<string>("SeriesOPMTitle");
                    item.OPMDescription = dataItems.Rows[i].Field<string>("SeriesOPMTitleDescription");

                    listCollection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a SeriesOPMTitleEntity collection from a null data table.");
            }

            return listCollection.OrderBy(t => t.OPMTitle).ToList();
        }

        public SeriesOPMTitleEntity GetSeriesOPMTitlesByID(int seriesID, string ompTitle)
        {
            SeriesOPMTitleEntity entity;

            DataTable dt = ExecuteDataTable("spr_GetSeriesOPMTitleByID", seriesID, ompTitle);

            if (dt != null && dt.Rows.Count > 0)
            {
                entity = new SeriesOPMTitleEntity();

                entity.SeriesID = dt.Rows[0].Field<int>("Series");
                entity.OPMTitle = dt.Rows[0].Field<string>("SeriesOPMTitle");
                entity.OPMDescription = dt.Rows[0].Field<string>("SeriesOPMTitleDescription");
            }
            else
            {
                throw new Exception("You cannot create a SeriesOPMTitleEntity object from a null data table.");
            }

            return entity;
        }

        public SeriesEntity GetSeriesBySeriesID(int seriesID)
        {
            SeriesEntity entity;

            DataTable dt = ExecuteDataTable("spr_GetSeriesBySeriesID", seriesID);

            if (dt != null && dt.Rows.Count > 0)
            {
                entity = new SeriesEntity();

                entity.ID = dt.Rows[0].Field<int>("SeriesID");
                entity.SeriesName = dt.Rows[0].Field<string>("SeriesName");
                entity.SeriesDefinition = dt.Rows[0].Field<string>("SeriesDefinition");
                entity.OccupationalInformation = dt.Rows[0].Field<string>("SeriesOccupationalInformation");
                entity.PayPlanID = dt.Rows[0].Field<int>("PayPlanID");
                entity.TypeOfWorkID = dt.Rows[0].IsNull("TypeOfWorkID") ? -1 : dt.Rows[0].Field<int>("TypeOfWorkID");
            }
            else
            {
                throw new Exception("You cannot create a SeriesEntity object from a null data table.");
            }

            return entity;
        }

        public List<SeriesEntity> GetAllSeries()
        {
            List<SeriesEntity> listCollection = new List<SeriesEntity>();

            DataTable dataItems = ExecuteDataTable("spr_GetAllSeries");

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    SeriesEntity item = new SeriesEntity();

                    item.ID = dataItems.Rows[i].Field<int>("SeriesID");
                    item.SeriesName = dataItems.Rows[i].Field<string>("SeriesName");
                    item.SeriesDefinition = dataItems.Rows[i].Field<string>("SeriesDefinition");
                    item.OccupationalInformation = dataItems.Rows[i].Field<string>("SeriesOccupationalInformation");
                    item.PayPlanID = dataItems.Rows[i].Field<int>("PayPlanID");
                    item.TypeOfWorkID = dataItems.Rows[i].IsNull("TypeOfWorkID") ? -1 : dataItems.Rows[i].Field<int>("TypeOfWorkID");

                    listCollection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a SeriesEntity collection from a null data table.");
            }

            return listCollection;
        }


        //public SeriesEntity GetSeriesEntityByID(long seriesID)
        //{
        //    JNPApproval entity;

        //    DataTable dt = ExecuteDataTable("spr_GetJNPApprovalByID", approvalID);

        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        entity = new JNPApproval();

        //        entity.ID = dt.Rows[0].Field<long>("ApprovalID");
        //        entity.SupervisorID = dt.Rows[0].Field<int>("SupervisorID");
        //        entity.SupervisorFullName = dt.Rows[0].Field<string>("SupervisorFullName");
        //        entity.SupervisorOrgTitle = dt.Rows[0].Field<string>("SupervisorOrgTitle");
        //        entity.SupervisorSignDate = dt.Rows[0].Field<DateTime?>("SupervisorSignDate");
        //        entity.HRPersonnelID = dt.Rows[0].Field<int>("HRPersonnelID");
        //        entity.HRPersonnelFullName = dt.Rows[0].Field<string>("HRPersonnelFullName");
        //        entity.HRPersonnelOrgTitle = dt.Rows[0].Field<string>("HRPersonnelOrgTitle");
        //        entity.HRPersonnelSignDate = dt.Rows[0].Field<DateTime?>("HRPersonnelSignDate");
        //        entity.JNPID = dt.Rows[0].Field<long>("JNPID");
        //        entity.JAID = dt.Rows[0].Field<long>("JAID");
        //        entity.CRID = dt.Rows[0].Field<long>("CRID");
        //        entity.JQID = dt.Rows[0].Field<long>("JQID");
        //    }
        //    else
        //    {
        //        throw new Exception("You cannot create a JNPApproval object from a null data table.");
        //    }

        //    return entity;
        //}

        //public JNPApproval GetJNPApprovalByStaffingObjectID(long staffingObjectID, enumStaffingObjectType staffingObjectTypeID )
        //{
        //    JNPApproval entity = new JNPApproval();
        //    entity.ID = -1;
        //    entity.SupervisorID = -1;
        //    entity.HRPersonnelID = -1;

        //    DataTable dt = ExecuteDataTable("spr_GetJNPApprovalByStaffingObjectID", staffingObjectID, (int) staffingObjectTypeID); 

        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        entity.ID = dt.Rows[0].Field<long>("ApprovalID");
        //        entity.SupervisorID = dt.Rows[0].IsNull("SupervisorID") ? -1 : dt.Rows[0].Field<int>("SupervisorID");
        //        entity.SupervisorFullName = dt.Rows[0].IsNull("SupervisorFullName") ? string.Empty : dt.Rows[0].Field<string>("SupervisorFullName");
        //        entity.SupervisorOrgTitle = dt.Rows[0].IsNull("SupervisorOrgTitle") ? string.Empty : dt.Rows[0].Field<string>("SupervisorOrgTitle");
        //        entity.SupervisorSignDate = dt.Rows[0].Field<DateTime?>("SupervisorSignDate");
        //        entity.HRPersonnelID = dt.Rows[0].IsNull("HRPersonnelID") ? -1 : dt.Rows[0].Field<int>("HRPersonnelID");
        //        entity.HRPersonnelFullName = dt.Rows[0].IsNull("HRPersonnelFullName") ? string.Empty : dt.Rows[0].Field<string>("HRPersonnelFullName");
        //        entity.HRPersonnelOrgTitle = dt.Rows[0].IsNull("HRPersonnelOrgTitle") ? string.Empty : dt.Rows[0].Field<string>("HRPersonnelOrgTitle");
        //        entity.HRPersonnelSignDate = dt.Rows[0].Field<DateTime?>("HRPersonnelSignDate");
        //        entity.JNPID = dt.Rows[0].Field<long>("JNPID");
        //        entity.JAID = dt.Rows[0].Field<long>("JAID");
        //        entity.CRID = dt.Rows[0].IsNull("CRID") ? -1 : dt.Rows[0].Field<long>("CRID");
        //        entity.JQID = dt.Rows[0].Field<long>("JQID");
        //    }

        //    return entity;
        //}

        //public void Update(JNPApproval entity)
        //{
        //    Update(entity, null);
        //}

        //public void Update(JNPApproval entity, TransactionManager currentTransaction)
        //{
        //    if (base.ValidateKeyField(entity.ID))
        //    {
        //        DbCommand commandWrapper = GetDbCommand("spr_UpdateJNPApproval");

        //        try
        //        {
        //            commandWrapper.Parameters.Add(new SqlParameter("@approvalID", entity.ID));

        //            if (entity.SupervisorID <= 0)
        //                commandWrapper.Parameters.Add(new SqlParameter("@supervisorID", DBNull.Value));
        //            else
        //                commandWrapper.Parameters.Add(new SqlParameter("@supervisorID", entity.SupervisorID));

        //            if (string.IsNullOrEmpty(entity.SupervisorFullName))
        //            {
        //                commandWrapper.Parameters.Add(new SqlParameter("@supervisorFullName", DBNull.Value));
        //            }
        //            else
        //            {
        //                commandWrapper.Parameters.Add(new SqlParameter("@supervisorFullName", entity.SupervisorFullName));
        //            }

        //            if (string.IsNullOrEmpty(entity.SupervisorOrgTitle))
        //            {
        //                commandWrapper.Parameters.Add(new SqlParameter("@supervisorOrgTitle", DBNull.Value));
        //            }
        //            else
        //            {
        //                commandWrapper.Parameters.Add(new SqlParameter("@supervisorOrgTitle", entity.SupervisorOrgTitle));
        //            }

        //            if (!entity.SupervisorSignDate.HasValue)
        //                commandWrapper.Parameters.Add(new SqlParameter("@supervisorSignDate", DBNull.Value));
        //            else
        //                commandWrapper.Parameters.Add(new SqlParameter("@supervisorSignDate", entity.SupervisorSignDate));

        //            if (entity.HRPersonnelID <= 0)
        //                commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelID", DBNull.Value));
        //            else
        //                commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelID", entity.HRPersonnelID));

        //            if (string.IsNullOrEmpty(entity.HRPersonnelFullName))
        //            {
        //                commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelFullName", DBNull.Value));
        //            }
        //            else
        //            {
        //                commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelFullName", entity.HRPersonnelFullName));
        //            }

        //            if (string.IsNullOrEmpty(entity.HRPersonnelOrgTitle))
        //            {
        //                commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelOrgTitle", DBNull.Value));
        //            }
        //            else
        //            {
        //                commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelOrgTitle", entity.HRPersonnelOrgTitle));
        //            }

        //            if (!entity.HRPersonnelSignDate.HasValue)
        //                commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelSignDate", DBNull.Value));
        //            else
        //                commandWrapper.Parameters.Add(new SqlParameter("@hRPersonnelSignDate", entity.HRPersonnelSignDate));

        //            if (entity.JNPID <= 0)
        //                commandWrapper.Parameters.Add(new SqlParameter("@jNPID", DBNull.Value));
        //            else
        //                commandWrapper.Parameters.Add(new SqlParameter("@jNPID", entity.JNPID));

        //            if (entity.JAID <= 0)
        //                commandWrapper.Parameters.Add(new SqlParameter("@jAID", DBNull.Value));
        //            else
        //                commandWrapper.Parameters.Add(new SqlParameter("@jAID", entity.JAID));

        //            if (entity.CRID <= 0)
        //                commandWrapper.Parameters.Add(new SqlParameter("@cRID", DBNull.Value));
        //            else
        //                commandWrapper.Parameters.Add(new SqlParameter("@cRID", entity.CRID));

        //            if (entity.JQID <= 0)
        //                commandWrapper.Parameters.Add(new SqlParameter("@jQID", DBNull.Value));
        //            else
        //                commandWrapper.Parameters.Add(new SqlParameter("@jQID", entity.JQID));

        //            if (currentTransaction != null)
        //            {
        //                DatabaseUtility.ExecuteNonQuery(currentTransaction, commandWrapper);
        //            }
        //            else
        //            {
        //                ExecuteNonQuery(commandWrapper);
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            currentTransaction.Rollback();
        //            HandleException(ex);
        //        }
        //    }
        //}

        //public void Delete(long approvalID)
        //{
        //    if (base.ValidateKeyField(approvalID))
        //    {
        //        try
        //        {
        //            ExecuteNonQuery("spr_DeleteJNPApproval", approvalID);
        //        }
        //        catch (Exception ex)
        //        {
        //            HandleException(ex);
        //        }
        //    }
        //}
        #endregion
    }
}
