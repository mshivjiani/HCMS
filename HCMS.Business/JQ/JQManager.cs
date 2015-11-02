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
using HCMS.Business.JQ.Collections;
using HCMS.Lookups;
using HCMS.Business.Admin;

namespace HCMS.Business.JQ
{
    [System.ComponentModel.DataObject]
    public class JQManager : BusinessBase
    {
        #region General CRUD Methods

        #region Unused Functions
        public long Add(JobQuestionnaire jq)
        {
            long returnCode = -1;

            DbCommand commandWrapper = GetDbCommand("spr_AddJobQuestionnaire");

            try
            {
                SqlParameter returnParam = new SqlParameter("@newJQID", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;

                // get the new JQID of the record
                commandWrapper.Parameters.Add(returnParam);

                commandWrapper.Parameters.Add(new SqlParameter("@jQPayPlanID", jq.JQPayPlanID));
                commandWrapper.Parameters.Add(new SqlParameter("@jQSeriesID", jq.JQSeriesID));
                commandWrapper.Parameters.Add(new SqlParameter("@isInterdisciplinary", jq.IsInterdisciplinary));

                if (jq.AdditionalJQSeriesID == -1)
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@additionalJQSeriesID", DBNull.Value));
                }
                else
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@additionalJQSeriesID", jq.AdditionalJQSeriesID));
                    commandWrapper.Parameters.Add(new SqlParameter("@LowestAdvertisedGrade", jq.LowestAdvertisedGrade));
                    commandWrapper.Parameters.Add(new SqlParameter("@HighestAdvertisedGrade", jq.HighestAdvertisedGrade));
                    commandWrapper.Parameters.Add(new SqlParameter("@jQName", jq.JQName.Trim()));
                    commandWrapper.Parameters.Add(new SqlParameter("@jQPositionTitle", jq.JQPositionTitle.Trim()));
                    commandWrapper.Parameters.Add(new SqlParameter("@isStandardJQ", jq.IsStandardJQ));
                }

                if (jq.CreatedByID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@createdByID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@createdByID", jq.CreatedByID));

                //if (jq.CreateDate == DateTime.MinValue)
                //    commandWrapper.Parameters.Add(new SqlParameter("@createDate", DBNull.Value));
                //else
                //    commandWrapper.Parameters.Add(new SqlParameter("@createDate", jq.CreateDate));

                //if (jq.UpdatedByID == -1)
                //    commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", DBNull.Value));
                //else
                //    commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", jq.UpdatedByID));

                //if (jq.UpdateDate == DateTime.MinValue)
                //    commandWrapper.Parameters.Add(new SqlParameter("@updateDate", DBNull.Value));
                //else
                //    commandWrapper.Parameters.Add(new SqlParameter("@updateDate", jq.UpdateDate));

                ExecuteNonQuery(commandWrapper);

                returnCode = (long)returnParam.Value;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return returnCode;
        }

        public void Update(JobQuestionnaire jq)
        {
            Update(jq, null);
        }
        public void Update(JobQuestionnaire jq, TransactionManager currentTransaction)
        {
            if (base.ValidateKeyField(jq.JQID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateJobQuestionnaire");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@jQID", jq.JQID));
                    commandWrapper.Parameters.Add(new SqlParameter("@jQPayPlanID", jq.JQPayPlanID));
                    commandWrapper.Parameters.Add(new SqlParameter("@jQSeriesID", jq.JQSeriesID));
                    commandWrapper.Parameters.Add(new SqlParameter("@isInterdisciplinary", jq.IsInterdisciplinary));

                    if (jq.AdditionalJQSeriesID == -1)
                    {
                        commandWrapper.Parameters.Add(new SqlParameter("@additionalJQSeriesID", DBNull.Value));
                    }
                    else
                    {
                        commandWrapper.Parameters.Add(new SqlParameter("@additionalJQSeriesID", jq.AdditionalJQSeriesID));
                    }
                    commandWrapper.Parameters.Add(new SqlParameter("@LowestAdvertisedGrade", jq.LowestAdvertisedGrade));
                    commandWrapper.Parameters.Add(new SqlParameter("@HighestAdvertisedGrade", jq.HighestAdvertisedGrade));
                    commandWrapper.Parameters.Add(new SqlParameter("@jQName", jq.JQName.Trim()));
                    commandWrapper.Parameters.Add(new SqlParameter("@jQPositionTitle", jq.JQPositionTitle.Trim()));
                    commandWrapper.Parameters.Add(new SqlParameter("@isStandardJQ", jq.IsStandardJQ));
                    if (jq.UpdatedByID == -1)
                    {
                        commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", DBNull.Value));
                    }
                    else
                    {
                        commandWrapper.Parameters.Add(new SqlParameter("@updatedByID", jq.UpdatedByID));
                    }

                    if (currentTransaction == null)
                    { ExecuteNonQuery(commandWrapper); }
                    else
                    { ExecuteNonQuery(currentTransaction, commandWrapper); }
                }
                catch (Exception ex)
                {
                    if ((currentTransaction != null) && (currentTransaction.IsOpen))
                        currentTransaction.Rollback();
                    HandleException(ex);
                }
            }
        }

        public void Delete(long jqID)
        {
            if (base.ValidateKeyField(jqID))
            {
                try
                {
                    ExecuteNonQuery("spr_DeleteJobQuestionnaire", jqID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        public long CreateJQFromJA(long jaID, int createdbyID, long? jnpID = null)
        {
            long returnCode = -1;

            DbCommand commandWrapper = GetDbCommand("spr_CreateJQFromJA");

            SqlParameter returnParam = new SqlParameter("@newJQID", SqlDbType.BigInt);
            returnParam.Direction = ParameterDirection.Output;

            try
            {
                commandWrapper.Parameters.Add(returnParam);
                commandWrapper.Parameters.Add(new SqlParameter("@JAID", jaID));

                if (jnpID.HasValue)
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@JNPID", jnpID));
                }
                else
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@JNPID", DBNull.Value));
                }
                commandWrapper.Parameters.Add(new SqlParameter("@CreatedByID", createdbyID));

                ExecuteNonQuery(commandWrapper);

                returnCode = (long)returnParam.Value;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return returnCode;
        }
        #endregion

        private DataTable getOrderEntityTable()
        {
            DataTable orderTable = new DataTable();

            orderTable.Columns.Add("ID", typeof(long));
            orderTable.Columns.Add("OrderValue", typeof(int));

            return orderTable;
        }

        public void UpdateOrder(long JQID, JQFactorCollection factors, int userID)
        {
            //save current factor order
            this.updateFactorDataOrder(JQID, factors, null, null, userID);
            //save overall jq - re-assigning question numbers based on new sort
            this.updateFactorDataOrder(JQID, userID);
        }

        public void UpdateOrder(long JQID, JQFactorItemCollection factorItems, RatingScaleResponseCollection responses, int userID)
        {
            JQManager jm = new JQManager();
            JQFactorCollection listFactors = jm.GetJQFactorCollectionByJQID(JQID);
            //save a particular factor/factoritems/responses
            this.updateFactorDataOrder(JQID, listFactors, factorItems, responses, userID);
            //save overall jq - re-assigning question numbers based on new sort
            this.updateFactorDataOrder(JQID, userID);
        }

        private void updateFactorDataOrder(long JQID, JQFactorCollection factors, JQFactorItemCollection factorItems, RatingScaleResponseCollection responses, int userID)
        {
            if (base.ValidateKeyField(JQID))
            {
                try
                {
                    // create table variable parameters and pass to stored procedure
                    // TVP: OrderEntityType -- ID (long), OrderValue (int)
                    DbCommand commandWrapper = GetDbCommand("spr_UpdateJobQuestionnaireOrder");

                    DataTable factorTable = getOrderEntityTable();
                    DataTable factorItemTable = getOrderEntityTable();
                    DataTable ratingScaleResponseTable = getOrderEntityTable();

                    if (factors != null)
                    {
                        // add data to factors table
                        int factorCnt = 1;
                        int factorItemCnt = 1;

                        foreach (JQFactor factor in factors)
                        {
                            factor.JQFactorNo = factorCnt;
                            factorTable.Rows.Add(factor.JQFactorID, factor.JQFactorNo);
                            factorCnt++;

                            if (factorItems != null)
                            {
                                // add data to factor items table and set count
                                // note as specified in the business rule  -- item number is unique for the entire JQ
                                foreach (JQFactorItem factorItem in factorItems.FindByFactor(factor.JQFactorID))
                                {
                                    factorItem.JQItemNo = factorItemCnt;
                                    factorItemTable.Rows.Add(factorItem.JQFactorItemID, factorItem.JQItemNo);
                                    factorItemCnt++;
                                }
                            }

                        }
                    }

                    if (responses != null)
                    {
                        // add data to rating responses table
                        Dictionary<long, int> ratingScales = new Dictionary<long, int>();  // long: rating scale ID, int: numberCnt 

                        foreach (RatingScaleResponse item in responses)
                        {
                            // numbers are unique per scale only (not overall)
                            if (!ratingScales.ContainsKey(item.JQRatingScaleID))
                                ratingScales.Add(item.JQRatingScaleID, 1);

                            item.JQResponseNo = ratingScales[item.JQRatingScaleID];  // set the count
                            ratingScaleResponseTable.Rows.Add(item.JQResponseID, item.JQResponseNo);
                            ratingScales[item.JQRatingScaleID]++;  // increase the count
                        }
                    }

                    commandWrapper.Parameters.Add(new SqlParameter("@JQID", JQID));
                    commandWrapper.Parameters.Add(new SqlParameter("@FactorTable", factorTable));
                    commandWrapper.Parameters.Add(new SqlParameter("@FactorItemTable", factorItemTable));
                    commandWrapper.Parameters.Add(new SqlParameter("@RatingScaleResponseTable", ratingScaleResponseTable));
                    commandWrapper.Parameters.Add(new SqlParameter("@userID", userID));


                    // transaction called within stored procedure
                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        private void updateFactorDataOrder(long JQID, int userID)
        {
            if (base.ValidateKeyField(JQID))
            {
                try
                {
                    // create table variable parameters and pass to stored procedure
                    // TVP: OrderEntityType -- ID (long), OrderValue (int)
                    DbCommand commandWrapper = GetDbCommand("spr_UpdateJobQuestionnaireOrder");

                    DataTable factorTable = getOrderEntityTable();
                    DataTable factorItemTable = getOrderEntityTable();
                    DataTable ratingScaleResponseTable = getOrderEntityTable();
                    JQFactorCollection factors = GetJQFactorCollectionByJQID(JQID);

                    if (factors != null)
                    {
                        // add data to factors table
                        int factorCnt = 1;
                        int factorItemCnt = 1;

                        foreach (JQFactor factor in factors)
                        {
                            factor.JQFactorNo = factorCnt;
                            factorTable.Rows.Add(factor.JQFactorID, factor.JQFactorNo);
                            factorCnt++;

                            JQFactorItemCollection factorItems = GetJQFactorItemCollectionByFactorID(factor.JQFactorID);  // load factor items

                            // add data to factor items table and set count
                            // note as specified in the business rule  -- item number is unique for the entire JQ
                            foreach (JQFactorItem factorItem in factorItems)
                            {
                                factorItem.JQItemNo = factorItemCnt;
                                factorItemTable.Rows.Add(factorItem.JQFactorItemID, factorItem.JQItemNo);
                                factorItemCnt++;
                                RatingScaleResponseCollection responses = GetJQRatingScaleResponseCollectionByFactorItemID(factorItem.JQFactorItemID);
                                // add data to rating responses table
                                Dictionary<long, int> ratingScales = new Dictionary<long, int>();  // long: rating scale ID, int: numberCnt 

                                foreach (RatingScaleResponse item in responses)
                                {
                                    // numbers are unique per scale only (not overall)
                                    if (!ratingScales.ContainsKey(item.JQRatingScaleID))
                                        ratingScales.Add(item.JQRatingScaleID, 1);

                                    item.JQResponseNo = ratingScales[item.JQRatingScaleID];  // set the count
                                    ratingScaleResponseTable.Rows.Add(item.JQResponseID, item.JQResponseNo);
                                    ratingScales[item.JQRatingScaleID]++;  // increase the count
                                }
                            }


                        }
                    }

                    commandWrapper.Parameters.Add(new SqlParameter("@JQID", JQID));
                    commandWrapper.Parameters.Add(new SqlParameter("@FactorTable", factorTable));
                    commandWrapper.Parameters.Add(new SqlParameter("@FactorItemTable", factorItemTable));
                    commandWrapper.Parameters.Add(new SqlParameter("@RatingScaleResponseTable", ratingScaleResponseTable));
                    commandWrapper.Parameters.Add(new SqlParameter("@userID", userID));

                    // transaction called within stored procedure
                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }
        #endregion

        #region JQ Factor CRUD

        public JQFactorEntity FillJQFactorEntityFromRow(DataRow returnRow)
        {
            JQFactorEntity entity = new JQFactorEntity();

            entity.ID = (long)returnRow["JQFactorID"];
            entity.FactorTypeID = (int)returnRow["JQFactorTypeID"];
            entity.FactorTypeName = returnRow["FactorType"].ToString();
            if (returnRow["JQFactorNo"] != DBNull.Value)
            {
                entity.FactorNo = (int)returnRow["JQFactorNo"];
            }
            else
            {
                entity.FactorNo = -1;
            }
            entity.Title = returnRow["JQFactorTitle"].ToString();
            entity.Instruction = returnRow["JQFactorInstruction"].ToString();
            if (returnRow["IsSF"] != DBNull.Value)
            {
                entity.IsSF = (bool)returnRow["IsSF"];
            }
            else
            {
                entity.IsSF = false;
            }

            entity.JQID = (long)returnRow["JQID"];
            if (returnRow["KSAID"] != DBNull.Value)
            { entity.KSAID = (long)returnRow["KSAID"]; }
            else
            { entity.KSAID = -1; }

            if (returnRow["CreatedByID"] != DBNull.Value)
            {
                entity.CreatedByID = (int)returnRow["CreatedByID"];
            }
            else
            { returnRow["CreatedByID"] = -1; }

            entity.CreatedByName = returnRow["CreatedByName"].ToString();
            if (returnRow["CreateDate"] != DBNull.Value)
            {
                entity.CreateDate = DateTime.Parse(returnRow["CreateDate"].ToString());
            }
            else
            {
                entity.CreateDate = DateTime.MinValue;
            }
            if (returnRow["UpdatedByID"] != DBNull.Value)
            {
                entity.UpdatedByID = (int)returnRow["UpdatedByID"];
            }
            else
            { entity.UpdatedByID = -1; }

            if (returnRow["UpdatedByName"] != DBNull.Value)
            {
                entity.UpdatedByName = returnRow["UpdatedByName"].ToString();
            }
            if (returnRow["UpdateDate"] != DBNull.Value)
            {
                entity.UpdateDate = DateTime.Parse(returnRow["UpdateDate"].ToString());
            }
            else
            {
                entity.UpdateDate = DateTime.MinValue;
            }

            if (returnRow["CountOfFactorQuestions"] != DBNull.Value)
            {
                entity.CountOfFactorQuestions = (int)returnRow["CountOfFactorQuestions"];
            }
            else
            {
                entity.CountOfFactorQuestions = 0;
            }
            if (returnRow["JADutyKSAID"] != DBNull.Value)
            {
                entity.JADutyKSAID = (long)returnRow["JADutyKSAID"];
            }
            else
            {
                entity.JADutyKSAID = -1;
            }
            return entity;
        }
        public long AddJobQuestionnaireFactor(JQFactorEntity entity)
        {
            DbCommand commandWrapper = GetDbCommand("spr_AddJobQuestionnaireFactor");

            SqlParameter returnParam = new SqlParameter("@JQFactorID", SqlDbType.BigInt);
            returnParam.Direction = ParameterDirection.Output;

            try
            {
                // returns the new JQFactorID of the record
                commandWrapper.Parameters.Add(returnParam);

                if (entity.FactorTypeID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@JQFactorTypeID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@JQFactorTypeID", entity.FactorTypeID));

                if (string.IsNullOrWhiteSpace(entity.Title))
                    commandWrapper.Parameters.Add(new SqlParameter("@JQFactorTitle", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@JQFactorTitle", entity.Title.Trim()));

                if (string.IsNullOrWhiteSpace(entity.Instruction))
                    commandWrapper.Parameters.Add(new SqlParameter("@JQFactorInstruction", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@JQFactorInstruction", entity.Instruction.Trim()));

                commandWrapper.Parameters.Add(new SqlParameter("@IsSF", Convert.ToInt32(entity.IsSF)));

                if (entity.JQID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@JQID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@JQID", (entity.JQID)));

                if (entity.KSAID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@KSAID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@KSAID", entity.KSAID));


                if (entity.CreatedByID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@CreatedByID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("CreatedByID", entity.CreatedByID));

                ExecuteNonQuery(commandWrapper);

            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return (long)returnParam.Value;
        }

        public JQFactorEntity GetJQFactorByJQFactorID(long jqFactorID)
        {
            JQFactorEntity entity;

            DataTable dt = ExecuteDataTable("spr_GetJQFactorByID", jqFactorID);

            if (dt != null && dt.Rows.Count > 0)
            {
                entity = new JQFactorEntity();
                DataRow returnRow = dt.Rows[0];
                entity = FillJQFactorEntityFromRow(returnRow);

            }
            else
            {
                throw new Exception("You cannot create a JQFactorEntity from a null data table.");
            }


            return entity;
        }

        public void UpdateJobQuestionnaireFactor(JQFactorEntity entity)
        {
            if (base.ValidateKeyField(entity.ID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateJobQuestionnaireFactor");

                try
                {
                    if (entity.ID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@JQFactorID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@JQFactorID", entity.ID));

                    if (entity.FactorTypeID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@JQFactorTypeID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@JQFactorTypeID", entity.FactorTypeID));

                    if (string.IsNullOrWhiteSpace(entity.Title))
                        commandWrapper.Parameters.Add(new SqlParameter("@JQFactorTitle", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@JQFactorTitle", entity.Title.Trim()));

                    if (string.IsNullOrWhiteSpace(entity.Instruction))
                        commandWrapper.Parameters.Add(new SqlParameter("@JQFactorInstruction", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@JQFactorInstruction", entity.Instruction.Trim()));

                    commandWrapper.Parameters.Add(new SqlParameter("@IsSF", entity.IsSF));

                    commandWrapper.Parameters.Add(new SqlParameter("@UpdatedByID", entity.UpdatedByID));

                    commandWrapper.Parameters.Add(new SqlParameter("@JQID", entity.JQID));

                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        public void DeleteJQFactor(long jqFactorID, int userID)
        {
            if (base.ValidateKeyField(jqFactorID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_DeleteJQFactor");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@JQFactorID", jqFactorID));

                    commandWrapper.Parameters.Add(new SqlParameter("@userID", userID));

                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        public int GetCountOfQuestionsForAJQFactor(long jqFactorID)
        {
            int qct = 0;
            try
            {
                qct = (int)ExecuteScalar("spr_GetCountOfQuestionsByJQFactorID", jqFactorID);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
            return qct;
        }
        #endregion

        #region JQ FactorItem CRUD
        public JQFactorItemEntity FillJQFactorItemEntityFromRow(DataRow returnRow)
        {
            DataColumnCollection columns = returnRow.Table.Columns;
            JQFactorItemEntity entity = new JQFactorItemEntity();
            entity.ID = (long)returnRow["JQFactorItemID"];
            entity.FactorID = (long)returnRow["JQFactorID"];
            if (returnRow["JQParentItemID"] != DBNull.Value)
            {
                entity.ParentItemID = (long?)returnRow["JQParentItemID"];
            }
            entity.ItemTypeID = (int)returnRow["JQItemTypeID"];
            if (returnRow["JQItemNo"] != DBNull.Value)
            {
                entity.ItemNo = (int)returnRow["JQItemNo"];
            }
            if (returnRow["JQItemLetter"] != DBNull.Value)
            {
                entity.ItemLetter = returnRow["JQItemLetter"].ToString();
            }
            if (returnRow["JQItemText"] != DBNull.Value)
            {
                entity.ItemText = returnRow["JQItemText"].ToString();
            }
            if (returnRow["RatingScaleID"] != DBNull.Value)
            {
                entity.RatingScaleID = (long)returnRow["RatingScaleID"];
            }
            if (returnRow["RatingScaleTypeID"] != DBNull.Value)
            {
                entity.RatingScaleTypeID = (int)returnRow["RatingScaleTypeID"];
            }
            if (returnRow["RatingScaleName"] != DBNull.Value)
            {
                entity.RatingScaleName = returnRow["RatingScaleName"].ToString();
            }
            if (returnRow["TaskStatementID"] != DBNull.Value)
            {
                entity.TaskStatementID = (long)returnRow["TaskStatementID"];
            }
            else
            {
                entity.TaskStatementID = -1;
            }
            if (returnRow["IsDefault"] != DBNull.Value)
            {
                entity.IsDefault = (bool)returnRow["IsDefault"];
            }
            if (columns.Contains("RatingScaleInstruction"))
            {
                if (returnRow["RatingScaleInstruction"] != DBNull.Value)
                {
                    entity.RatingScaleInstruction = returnRow["RatingScaleInstruction"].ToString();
                }
            }

            if (columns.Contains("AEQuestionID"))
            {
                if (returnRow["AEQuestionID"] != DBNull.Value)
                {
                    entity.AEQuestionID = (int)returnRow["AEQuestionID"];
                }
            }

            return entity;
        }
        public long AddJQFactorItem(JQFactorItemEntity entity, int userID)
        {
            DbCommand commandWrapper = GetDbCommand("spr_AddJobQuestionnaireFactorItem");

            SqlParameter returnParam = new SqlParameter("@JQFactorItemID", SqlDbType.BigInt);
            returnParam.Direction = ParameterDirection.Output;

            try
            {
                // returns the new JQFactorItemID of the record
                commandWrapper.Parameters.Add(returnParam);

                if (entity.FactorID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@JQFactorID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@JQFactorID", entity.FactorID));

                if (entity.ParentItemID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@JQParentItemID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@JQParentItemID", entity.ParentItemID));

                if (entity.ItemTypeID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@JQItemTypeID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@JQItemTypeID", entity.ItemTypeID));

                if (string.IsNullOrWhiteSpace(entity.ItemLetter))
                    commandWrapper.Parameters.Add(new SqlParameter("@JQItemLetter", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@JQItemLetter", entity.ItemLetter));

                if (string.IsNullOrWhiteSpace(entity.ItemText))
                    commandWrapper.Parameters.Add(new SqlParameter("@JQItemText", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@JQItemText", entity.ItemText));

                if (entity.RatingScaleID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@ratingScaleID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@ratingScaleID", entity.RatingScaleID));

                if (entity.TaskStatementID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@taskStatementID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@taskStatementID", entity.TaskStatementID));

                commandWrapper.Parameters.Add(new SqlParameter("@userID", userID));

                if (entity.AEQuestionID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@AEQuestionID", DBNull.Value));
                else
                commandWrapper.Parameters.Add(new SqlParameter("@AEQuestionID", entity.AEQuestionID));

                ExecuteNonQuery(commandWrapper); 
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return (long)returnParam.Value;
        }
        public long AddQuestionWithRatingScale(JQFactorItemEntity entity, string ratingscaleInstruction, int userID)
        {
            DbCommand commandWrapper = GetDbCommand("spr_AddQuestionWithRatingScale");

            SqlParameter returnParam = new SqlParameter("@JQFactorItemID", SqlDbType.BigInt);
            returnParam.Direction = ParameterDirection.Output;

            try
            {
                // returns the new JQFactorItemID of the record
                commandWrapper.Parameters.Add(returnParam);

                if (entity.FactorID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@JQFactorID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@JQFactorID", entity.FactorID));

                if (entity.ParentItemID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@JQParentItemID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@JQParentItemID", entity.ParentItemID));

                if (entity.ItemTypeID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@JQItemTypeID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@JQItemTypeID", entity.ItemTypeID));

                if (string.IsNullOrWhiteSpace(entity.ItemLetter))
                    commandWrapper.Parameters.Add(new SqlParameter("@JQItemLetter", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@JQItemLetter", entity.ItemLetter));

                if (string.IsNullOrWhiteSpace(entity.ItemText))
                    commandWrapper.Parameters.Add(new SqlParameter("@JQItemText", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@JQItemText", entity.ItemText));


                if (entity.TaskStatementID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@taskStatementID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@taskStatementID", entity.TaskStatementID));

                if (string.IsNullOrEmpty(ratingscaleInstruction))
                    commandWrapper.Parameters.Add(new SqlParameter("@ratingscaleInstruction", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@ratingscaleInstruction", ratingscaleInstruction));

                commandWrapper.Parameters.Add(new SqlParameter("@ratingScaleTypeID", entity.RatingScaleTypeID));
                
                commandWrapper.Parameters.Add(new SqlParameter("@userID", userID));

                if (entity.AEQuestionID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@AEQuestionID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@AEQuestionID", entity.AEQuestionID));

                ExecuteNonQuery(commandWrapper);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return (long)returnParam.Value;
        }

        public JQFactorItemEntity GetJQFactorItemByID(long jqFactorItemID)
        {
            JQFactorItemEntity entity;

            DataTable dt = ExecuteDataTable("spr_GetJQFactorItemByID", jqFactorItemID);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow returnRow = dt.Rows[0];
                entity = FillJQFactorItemEntityFromRow(returnRow);

            }
            else
            {
                throw new Exception("You cannot create a JQFactorItemEntity from a null data table.");
            }

            return entity;
        }

        public void UpdateJQFactorItem(JQFactorItemEntity entity, int userID)
        {
            if (base.ValidateKeyField(entity.ID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateJobQuestionnaireFactorItem");

                try
                {
                    if (entity.ID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@JQFactorItemID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@JQFactorItemID", entity.ID));

                    if (string.IsNullOrWhiteSpace(entity.ItemText))
                        commandWrapper.Parameters.Add(new SqlParameter("@JQItemText", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@JQItemText", entity.ItemText));

                    if (entity.TaskStatementID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@TaskStatementID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@TaskStatementID", entity.TaskStatementID));

                    if (entity.AEQuestionID  == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@AEQuestionID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@AEQuestionID", entity.AEQuestionID ));

                    commandWrapper.Parameters.Add(new SqlParameter("@userID", userID));

                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        public void DeleteJQFactorItem(long jqFactorItemID, int userID)
        {
            if (base.ValidateKeyField(jqFactorItemID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_DeleteJQFactorItem");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@JQFactorItemID", jqFactorItemID));
                    commandWrapper.Parameters.Add(new SqlParameter("@userID", userID));

                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }
        #endregion

        #region Rating Scale
        public JQRatingScaleEntity GetJQRatingScaleByID(long ratingScaleID)
        {
            JQRatingScaleEntity entity = null;

            try
            {
                DataTable dt = ExecuteDataTable("spr_GetJQRatingScaleByID", ratingScaleID);

                if (dt != null && dt.Rows.Count > 0)
                {
                    entity = new JQRatingScaleEntity();
                    entity.ID = dt.Rows[0].Field<long>("RatingScaleID");
                    entity.RatingScaleTypeID = dt.Rows[0].Field<int>("RatingScaleTypeID");
                    entity.RatingScaleInstruction = dt.Rows[0].Field<string>("RatingScaleInstruction");
                    entity.IsDefault = dt.Rows[0].Field<bool>("IsDefault");
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return entity;
        }
        public enumRatingScaleType GetCorrespondingDefaultRatingScale(int ratingScaleTypeID)
        {
            if (ratingScaleTypeID == (int)enumRatingScaleType.CustomYN)
            {
                return enumRatingScaleType.DefaultYN;
            }
            else
            {
                return enumRatingScaleType.DefaultMultiChoice;
            }
        }
        public string GetDefaultJQRatingScaleInstructionByRatingScaleType(int ratingScaleTypeID)
        {
            string instructions = string.Empty;
            DbCommand commandWrapper = GetDbCommand("spr_GetDefaultRatingScaleInstructionByRatingScaleType");

            try
            {
                commandWrapper.Parameters.Add(new SqlParameter("@ratingScaleTypeID ", ratingScaleTypeID));


                instructions = (string)ExecuteScalar(commandWrapper);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return instructions;
        }
        public void UpdateJQRatingScaleInstruction(long ratingScaleID, string ratingScaleInstruction, int currentUserID)
        {
            if (base.ValidateKeyField(ratingScaleID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateJQRatingScaleInstruction");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@ratingScaleID ", ratingScaleID));

                    if (string.IsNullOrWhiteSpace(ratingScaleInstruction))
                    {
                        commandWrapper.Parameters.Add(new SqlParameter("@ratingScaleInstruction", DBNull.Value));
                    }
                    else
                    {
                        commandWrapper.Parameters.Add(new SqlParameter("@ratingScaleInstruction", ratingScaleInstruction));
                    }

                    commandWrapper.Parameters.Add(new SqlParameter("@UpdatedByID", currentUserID));
                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        #endregion

        #region Rating Scale Responses CRUD
        public long AddRatingScaleResponse(RatingScaleResponseEntity entity, int userID)
        {

            DbCommand commandWrapper = GetDbCommand("spr_AddRatingScaleResponse");
            SqlParameter returnParam = new SqlParameter("@ResponseID", SqlDbType.BigInt);
            returnParam.Direction = ParameterDirection.Output;

            try
            {
                // return the new JQResponseID of the record
                commandWrapper.Parameters.Add(returnParam);

                commandWrapper.Parameters.Add(new SqlParameter("@RatingScaleID", entity.RatingScaleID));
                commandWrapper.Parameters.Add(new SqlParameter("@ResponseLetter", entity.ResponseLetter));
                commandWrapper.Parameters.Add(new SqlParameter("@ResponseText", entity.ResponseText.Trim()));
                commandWrapper.Parameters.Add(new SqlParameter("@userID", userID));

                ExecuteNonQuery(commandWrapper);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return (long)returnParam.Value;

        }

        public void UpdateRatingScaleResponse(RatingScaleResponseEntity entity, int userID)
        {
            if (base.ValidateKeyField(entity.ID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateRatingScaleResponse");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@ResponseID", entity.ID));
                    commandWrapper.Parameters.Add(new SqlParameter("@ResponseLetter", entity.ResponseLetter));
                    commandWrapper.Parameters.Add(new SqlParameter("@ResponseText", entity.ResponseText.Trim()));

                    commandWrapper.Parameters.Add(new SqlParameter("@userID", userID));


                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        public void DeleteRatingScaleResponse(long jqResponseID)
        {
            if (base.ValidateKeyField(jqResponseID))
            {
                try
                {
                    ExecuteNonQuery("spr_DeleteRatingScaleResponse", jqResponseID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        public void DeleteAllRatingScaleResponses(long jqFactorItemID, int userID)
        {
            if (base.ValidateKeyField(jqFactorItemID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_DeleteRatingScaleAndResponses");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@JQFactorItemID", jqFactorItemID));
                    commandWrapper.Parameters.Add(new SqlParameter("@userID", userID));

                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

        }

        public long CopyResponsesFromRatingScaleType(long questionID, long sourceRatingScaleTypeID, long targetRatingScaleTypeID, int userID)
        {
            DbCommand commandWrapper = null;

            SqlParameter returnParam = new SqlParameter("@RatingScaleID", SqlDbType.BigInt);
            returnParam.Direction = ParameterDirection.Output;

            SqlParameter factorItemParm = new SqlParameter("@JQFactorItemID", questionID);

            try
            {
                //if ((targetRatingScaleTypeID != (long)enumRatingScaleType.DefaultYN) &&
                //    (targetRatingScaleTypeID != (long)enumRatingScaleType.DefaultMultiChoice))
                if ((targetRatingScaleTypeID != (long)enumRatingScaleType.DefaultYN) &&
                    (targetRatingScaleTypeID != (long)enumRatingScaleType.DefaultMultiChoice) && targetRatingScaleTypeID != (long)enumRatingScaleType.MultipleChoiceQual)
                {
                    // for copy purposes we need to map the custom rating scale to a default rating scale
                    // to properly copy the responses. Hence we are changing the sourceRatingScaleID variable
                    // accordingly.
                    if (targetRatingScaleTypeID == (long)enumRatingScaleType.CustomYN) 
                        sourceRatingScaleTypeID = (long)enumRatingScaleType.DefaultYN;
                    if (targetRatingScaleTypeID == (long)enumRatingScaleType.CustomMultiChoice) 
                        sourceRatingScaleTypeID = (long)enumRatingScaleType.DefaultMultiChoice;

                    if (targetRatingScaleTypeID == (long)enumRatingScaleType.CustomMultiChoiceQual)
                        sourceRatingScaleTypeID = (long)enumRatingScaleType.MultipleChoiceQual;

                    commandWrapper = GetDbCommand("spr_AddCustomRatingScaleAndResponses");
                    commandWrapper.Parameters.Add(new SqlParameter("@CustomRatingScaleTypeID", targetRatingScaleTypeID));
                    commandWrapper.Parameters.Add(new SqlParameter("@DefaultRatingScaleTypeID", sourceRatingScaleTypeID));
                }
                else
                {
                    commandWrapper = GetDbCommand("spr_AddDefaultRatingScaleAndResponses");
                    commandWrapper.Parameters.Add(new SqlParameter("@RatingScaleTypeID", targetRatingScaleTypeID));
                }

                commandWrapper.Parameters.Add(factorItemParm);

                commandWrapper.Parameters.Add(new SqlParameter("@userID", userID));
                commandWrapper.Parameters.Add(returnParam);

                ExecuteNonQuery(commandWrapper);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return (long)returnParam.Value;
        }
        #endregion

        #region Constructor Helper Methods
        public JobQuestionnaire GetJobQuestionnaire(long loadByID)
        {
            // Load Object by ID
            DataTable returnTable;
            try
            {
                returnTable = ExecuteDataTable("spr_GetJobQuestionnaireByID", loadByID);
                return loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return null;
        }

        public JobQuestionnaire GetJobQuestionnaire(DataRow singleRowData)
        {
            // Load Object by dataRow
            try
            {
                return FillObjectFromRowData(singleRowData);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return null;
        }

        private JobQuestionnaire loadData(DataTable returnTable)
        {
            if (returnTable.Rows.Count > 0)
            {
                DataRow returnRow = returnTable.Rows[0];

                return FillObjectFromRowData(returnRow);
            }

            return null;
        }

        protected virtual JobQuestionnaire FillObjectFromRowData(DataRow returnRow)
        {
            JobQuestionnaire jq = new JobQuestionnaire();

            jq.JQID = (long)returnRow["JQID"];
            jq.JQPayPlanID = (int)returnRow["JQPayPlanID"];
            jq.PayPlanName = returnRow["JQPayPlanAbbrev"].ToString();
            jq.JQSeriesID = (int)returnRow["JQSeriesID"];

            jq.SeriesName = returnRow["JQSeriesName"].ToString();

            if (returnRow["IsInterdisciplinary"] != DBNull.Value)
                jq.IsInterdisciplinary = (bool)returnRow["IsInterdisciplinary"];


            if (returnRow["AdditionalJQSeriesID"] != DBNull.Value)
                jq.AdditionalJQSeriesID = (int)returnRow["AdditionalJQSeriesID"];

            jq.AdditionalSeriesName = returnRow["AdditionalJQSeriesName"].ToString();

            jq.LowestAdvertisedGrade = (int)returnRow["LowestAdvertisedGrade"];
            jq.HighestAdvertisedGrade = (int)returnRow["HighestAdvertisedGrade"];
            jq.JQName = returnRow["JQName"].ToString();
            jq.JQPositionTitle = returnRow["JQPositionTitle"].ToString();

            if (returnRow["IsStandardJQ"] != DBNull.Value)
                jq.IsStandardJQ = (bool)returnRow["IsStandardJQ"];


            if (returnRow["CreatedByID"] != DBNull.Value)
                jq.CreatedByID = (int)returnRow["CreatedByID"];

            if (returnRow["CreateDate"] != DBNull.Value)
                jq.CreateDate = (DateTime)returnRow["CreateDate"];


            if (returnRow["UpdatedByID"] != DBNull.Value)
                jq.UpdatedByID = (int)returnRow["UpdatedByID"];


            if (returnRow["UpdateDate"] != DBNull.Value)
                jq.UpdateDate = (DateTime)returnRow["UpdateDate"];

            jq.CreatedByFullName = returnRow["CreatedByFullName"].ToString();
            jq.UpdatedByFullName = returnRow["UpdatedByFullName"].ToString();

            return jq;
        }
        #endregion

        #region Collection Helper Methods
        private List<JobQuestionnaire> GetCollection(DataTable dataItems)
        {
            List<JobQuestionnaire> listCollection = new List<JobQuestionnaire>();
            JobQuestionnaire current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = GetJobQuestionnaire(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
            {
                throw new Exception("You cannot create a JobQuestionnaire collection from a null data table.");
            }

            return listCollection;
        }
        #endregion

        #region Collection Methods

        public JQFactorCollection GetJQFactorCollectionByJQID(long JQID)
        {
            JQFactorCollection childDataCollection = null;

            if (base.ValidateKeyField(JQID))
            {
                try
                {
                    // fill collection list
                    childDataCollection = new JQFactorCollection(ExecuteDataTable("spr_GetJQFactorByJQID", JQID));
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        public JQFactorItemCollection GetJQFactorItemCollectionByFactorID(long JQFactorID)
        {
            JQFactorItemCollection childDataCollection = null;

            if (base.ValidateKeyField(JQFactorID))
            {
                try
                {
                    // fill collection list
                    childDataCollection = new JQFactorItemCollection(ExecuteDataTable("spr_GetJQFactorItemByJQFactorID", JQFactorID));
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        public RatingScaleResponseCollection GetJQRatingScaleResponseCollectionByFactorItemID(long JQFactorItemID)
        {
            RatingScaleResponseCollection childDataCollection = null;

            if (base.ValidateKeyField(JQFactorItemID))
            {
                try
                {
                    // fill collection list
                    childDataCollection = new RatingScaleResponseCollection(ExecuteDataTable("spr_GetJQRatingScaleResponses", JQFactorItemID));
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        public List<JQFactor> GetJQFactorByJQID(long jqID)
        {
            List<JQFactor> childDataCollection = null;
            if (base.ValidateKeyField(jqID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetJQFactorByJQID", jqID);

                    // fill collection list
                    childDataCollection = (List<JQFactor>)new JQFactorCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        public List<JQWorkflowStatus> GetJQWorkflowStatusByJQWorkflowRecID(long jqID)
        {
            List<JQWorkflowStatus> childDataCollection = null;
            if (base.ValidateKeyField(jqID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetJQWorkflowStatusByJQID", jqID);

                    // fill collection list
                    childDataCollection = JQWorkflowStatusManager.GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        public List<JQFactorTypeEntity> GetAllNonKSAFactorTypes()
        {
            List<JQFactorTypeEntity> listCollection = new List<JQFactorTypeEntity>();

            DataTable dataItems = ExecuteDataTable("spr_GetAllNonKSAFactorTypes", (long)enumJQFactorType.KSA);

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    JQFactorTypeEntity item = new JQFactorTypeEntity();

                    item.ID = dataItems.Rows[i].Field<int>("JQFactorTypeID");
                    item.Name = dataItems.Rows[i].Field<string>("FactorType");

                    listCollection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a JQFactorTypeEntity collection from a null data table.");
            }

            return listCollection;
        }

        public List<JQFactorEntity> GetJQFactorsByJQID(long jqID)
        {
            List<JQFactorEntity> listCollection = new List<JQFactorEntity>();

            DataTable dataItems = ExecuteDataTable("spr_GetJQFactorByJQID", jqID);

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    JQFactorEntity item = new JQFactorEntity();
                    DataRow returnRow = dataItems.Rows[i];
                    item = FillJQFactorEntityFromRow(returnRow);

                    listCollection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a JQFactorEntity collection from a null data table.");
            }

            return listCollection;
        }


        public List<JQFactorItemEntity> GetJQFactorItemsByJQFactorID(long jqFactorID)
        {
            List<JQFactorItemEntity> listCollection = new List<JQFactorItemEntity>();

            DataTable dataItems = ExecuteDataTable("spr_GetJQFactorItemByJQFactorID", jqFactorID);

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    JQFactorItemEntity item = new JQFactorItemEntity();
                    DataRow returnRow = dataItems.Rows[i];
                    item = FillJQFactorItemEntityFromRow(returnRow);

                    listCollection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a JQFactorItemEntity collection from a null data table.");
            }

            return listCollection;
        }

        public List<JQFactorEntity> GetJQKSAFactorsByJQID(long jqID)
        {
            List<JQFactorEntity> listCollection = new List<JQFactorEntity>();

            DataTable dataItems = ExecuteDataTable("spr_GetAllJQKSAByJQID", jqID, (long)enumJQFactorType.KSA);

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    JQFactorEntity item = new JQFactorEntity();

                    DataRow returnRow = dataItems.Rows[i];
                    item = FillJQFactorEntityFromRow(returnRow);
                    listCollection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a JQFactorEntity collection from a null data table.");
            }

            return listCollection;
        }

        public List<RatingScaleResponseEntity> GetDefaultReponsesForQuestionByRatingScaleID(long ratingScaleID)
        {
            List<RatingScaleResponseEntity> listCollection = new List<RatingScaleResponseEntity>();

            DataTable dataItems = ExecuteDataTable("spr_GetRatingScaleResponsesByRatingScaleID", ratingScaleID);

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    RatingScaleResponseEntity item = new RatingScaleResponseEntity();
                    item.ID = dataItems.Rows[i].Field<long>("JQResponseID");
                    item.ResponseNo = dataItems.Rows[i].Field<int>("JQResponseNo");
                    item.ResponseLetter = dataItems.Rows[i].Field<string>("JQResponseLetter");
                    item.ResponseText = dataItems.Rows[i].Field<string>("JQResponseText");
                    item.RatingScaleID = dataItems.Rows[i].Field<long>("JQRatingScaleID");
                    item.RatingScaleTypeID = dataItems.Rows[i].Field<int>("RatingScaleTypeID");
                    item.IsDefault = dataItems.Rows[i].Field<bool>("IsDefault");

                    listCollection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a RatingScaleResponseEntity collection from a null data table.");
            }

            return listCollection;
        }


        public List<KSAEntity> GetSeriesGradeKSA(int seriesID, int grade)
        {
            List<KSAEntity> listCollection = new List<KSAEntity>();

            DataTable dataItems = ExecuteDataTable("spr_GetAllKSABySeriesGrade", seriesID, grade);

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    KSAEntity item = new KSAEntity(dataItems.Rows[i]);
                  
                    listCollection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a KSAEntity collection from a null data table.");
            }

            return listCollection;
        }

        public List<KSAEntity> GetSeriesGradeKSAExceptJQ(int seriesID, int grade, long jqID)
        {
            List<KSAEntity> ksaList = GetSeriesGradeKSA(seriesID, grade);
            List<JQFactorEntity> ksaFactorList = GetJQKSAFactorsByJQID(jqID);

            var filteredKSA = (from c in ksaList where (!ksaFactorList.Any(p => p.KSAID == c.KSAID) || (c.KSAID == 0)) select c).ToList();

            return filteredKSA;
        }

        public List<TSEntity> GetTaskStatementsByKSAIDAndJQID(long ksaID, long jqID)
        {
            List<TSEntity> listCollection = new List<TSEntity>();

            DataTable dataItems = ExecuteDataTable("spr_GetTaskStatementsByKSAIDAndJQID", ksaID, jqID);

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    TSEntity  item = new TSEntity ();
                    if (dataItems.Rows[i].Field<long>("TaskStatementID") != -1 || dataItems.Rows[i].Field<long>("TaskStatementID") != null)
                        item.TaskStatementID  = dataItems.Rows[i].Field<long>("TaskStatementID");

                    item.TaskStatement  = dataItems.Rows[i].Field<string>("TaskStatement");
                    listCollection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a TSEntity collection from a null data table.");
            }

            return listCollection;
        }

        public List<TSEntity> GetTaskStatementsByJAXID(long JNPID)
        {
            List<TSEntity> listCollection = new List<TSEntity>();

            DataTable dataItems = ExecuteDataTable("spr_GetUnAddedTaskStatementsForJAX", JNPID);

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    TSEntity  item = new TSEntity ();
                    if (dataItems.Rows[i].Field<long>("TaskStatementID") != -1 || dataItems.Rows[i].Field<long>("TaskStatementID") != null)
                        item.TaskStatementID  = dataItems.Rows[i].Field<long>("TaskStatementID");

                    item.TaskStatement  = dataItems.Rows[i].Field<string>("TaskStatement");
                    listCollection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a TSEntity collection from a null data table.");
            }

            return listCollection;
        }

        

        #endregion

        #region JobQuestionnaire Report - UTF8
        public long GetJQIDFromJNPID(long JNPID)
        {
            long jqid = -1;

            if (JNPID > 0)
            {
                DataTable dt = BusinessBase.ExecuteDataTable("spr_GetJobQuestionnaireByJNPID", JNPID);

                if ((dt != null) && (dt.Rows.Count > 0))
                {
                    DataRow dr = dt.Rows[0];
                    jqid = (long)dr["JQID"];
                }
            }
            return jqid;
        }

        // MD 5/8: New method that accepts jQID
        public string CreateUTF8JobQuestionnaireReportByJQID(long JQID)
        {
            return CreateUTF8Report(JQID);
        }

        // MD 5/8: Original method footprint wrapping new private method below
        public string CreateUTF8JobQuestionnaireReport(long JNPID)
        {
            long JQID = GetJQIDFromJNPID(JNPID);
            return CreateUTF8Report(JQID);
        }
        /// <summary>
        /// This routine prints the Response Instruction for Factor type other than KSA -only once per each Qualification factor, 
        /// unless the current questions's response type is multiple choice.
        /// Again for the next question if the response type is multiple choice then it compares with previous and prints only if it is different than previous.
        /// It does not print response type instruction per question if it is default y/n or custom y/n. 
        /// For KSA - If  response type is multiple choice, then response instruction and responses are printed together. If response type is Y/N, then response instruction
        /// is printed before question but responses are printed after question.
        /// It does not repeat the instruction even for the next factor unless it hits new response type.        ///
        /// </summary>
        /// <param name="JQID"></param>
        /// <returns></returns>
        private string CreateUTF8ReportOld(long JQID)
        {
            string UTF8String = String.Empty;
            if (JQID > 0)
            {
                JQManager jm = new JQManager();
                JQFactorCollection listFactors = jm.GetJQFactorCollectionByJQID(JQID);
                long previousRatingScaleId = 0;
                int previousRatingScaleTypeId = 0;

                foreach (JQFactor factor in listFactors)
                {
                    UTF8String = UTF8String + "FACTOR: " + factor.JQFactorTitle.Replace("\r\n", " ") + " " + System.Environment.NewLine;

                    UTF8String = UTF8String + "INSTRUCTIONS: " + factor.JQFactorInstruction.Replace("\r\n", " ") + " " + System.Environment.NewLine;

                    JQFactorItemCollection listFactorItems = jm.GetJQFactorItemCollectionByFactorID(factor.JQFactorID);

                    foreach (JQFactorItem factorItem in listFactorItems)
                    {

                        JQRatingScaleEntity JQRatingScale = jm.GetJQRatingScaleByID(factorItem.RatingScaleID);
                        if (JQRatingScale.RatingScaleTypeID == (int)enumRatingScaleType.DefaultYN || JQRatingScale.RatingScaleTypeID == (int)enumRatingScaleType.CustomYN)
                        {

                            RatingScaleResponseCollection listResponses = jm.GetJQRatingScaleResponseCollectionByFactorItemID(factorItem.RatingScaleID);

                            //Issue 649: JQ: Response Instructions should print on for each Qualification (Factor) 
                            //Response instructions are priting after "Factor: Business Necessity" set, but they are not priting out after "Factor: Selective Factor" set. They should. 
                            if (((previousRatingScaleId != factorItem.RatingScaleID) && (previousRatingScaleTypeId != (int)enumRatingScaleType.DefaultYN && previousRatingScaleTypeId != (int)enumRatingScaleType.CustomYN))  ||
                                ((previousRatingScaleId == factorItem.RatingScaleID) && (factor.JQFactorTypeID != (int)enumJQFactorType.KSA)))                                 
                            {
                                
                                    UTF8String = UTF8String + System.Environment.NewLine;
                                    UTF8String = UTF8String + "INSTRUCTIONS: " + JQRatingScale.RatingScaleInstruction + System.Environment.NewLine;
                                    //Now Set the previous Rating Scale to current after printing
                                    previousRatingScaleId = factorItem.RatingScaleID;
                                    previousRatingScaleTypeId = JQRatingScale.RatingScaleTypeID;
                                
                            }

                            UTF8String = UTF8String + System.Environment.NewLine;
                            UTF8String = UTF8String + factorItem.JQItemNo.ToString() + ". " + factorItem.JQItemText + System.Environment.NewLine;

                            foreach (RatingScaleResponse ratingScaleResponse in listResponses)
                            {
                                UTF8String = UTF8String + ratingScaleResponse.JQResponseLetter + " " + ratingScaleResponse.JQResponseText + System.Environment.NewLine;
                            }


                        }
                        else
                        {
                            RatingScaleResponseCollection listResponses = jm.GetJQRatingScaleResponseCollectionByFactorItemID(factorItem.RatingScaleID);                      
                           
                                if (previousRatingScaleId != factorItem.RatingScaleID)
                                {
                                    if (previousRatingScaleId > 0)
                                    {
                                        UTF8String = UTF8String + System.Environment.NewLine;
                                    }

                                    UTF8String = UTF8String + "INSTRUCTIONS: " + JQRatingScale.RatingScaleInstruction + System.Environment.NewLine;

                                    UTF8String = UTF8String + System.Environment.NewLine;

                                    //Now Set the previous Rating Scale to current after printing
                                    previousRatingScaleId = factorItem.RatingScaleID;

                                    if (factor.JQFactorTypeID == (int)enumJQFactorType.KSA)
                                    {
                                        foreach (RatingScaleResponse ratingScaleResponse in listResponses)
                                        {
                                            UTF8String = UTF8String + ratingScaleResponse.JQResponseLetter + " " + ratingScaleResponse.JQResponseText + System.Environment.NewLine;
                                        }
                                    }

                                }
                                UTF8String = UTF8String + System.Environment.NewLine;
                                UTF8String = UTF8String + factorItem.JQItemNo.ToString() + ". " + factorItem.JQItemText;
                                if (factor.JQFactorTypeID != (int)enumJQFactorType.KSA)
                                {
                                    UTF8String = UTF8String + System.Environment.NewLine;
                                    foreach (RatingScaleResponse ratingScaleResponse in listResponses)
                                    {
                                        UTF8String = UTF8String + ratingScaleResponse.JQResponseLetter + " " + ratingScaleResponse.JQResponseText + System.Environment.NewLine;
                                    }
                                }
                            
                        }

                        UTF8String = UTF8String + System.Environment.NewLine;
                    }

                    UTF8String = UTF8String + System.Environment.NewLine;
                }
            }
            return UTF8String + Environment.NewLine;
        }
        /// <summary>
            ///1.	First question under first factor will always have Response Instruction. 
            ///2.	After the first question, Response instruction only appears if the previous question had different Response type then the current question’s response type.
            ///3.	Rule 1  and 2 are applicable to both type of factors – Qualification/KSA
            ///4.	Display/Location of responses differs based on Factor Type - Qualification/KSA
            ///a.	Qualification: Responses will always appear after question. 
            ///b.	KSA:  
            ///i.	For Multiple choices (default/custom) – Responses will appear with Response instruction – before question.
            ///ii.	For Y/N (default/Custom) –Responses will appear after the question.

        /// </summary>
        /// <param name="JQID"></param>
        /// <returns></returns>
        private string CreateUTF8Report(long JQID)
        {
            string UTF8String = String.Empty;
            if (JQID > 0)
            {
                JQManager jm = new JQManager();
                JQFactorCollection listFactors = jm.GetJQFactorCollectionByJQID(JQID);
                long previousRatingScaleId = 0;
                int previousRatingScaleTypeId = 0;

                foreach (JQFactor factor in listFactors)
                {
                    UTF8String = UTF8String + "FACTOR: " + factor.JQFactorTitle.Replace("\r\n", " ") + " " + System.Environment.NewLine;

                    UTF8String = UTF8String + "INSTRUCTIONS: " + factor.JQFactorInstruction.Replace("\r\n", " ") + " " + System.Environment.NewLine;

                    JQFactorItemCollection listFactorItems = jm.GetJQFactorItemCollectionByFactorID(factor.JQFactorID);

                    foreach (JQFactorItem factorItem in listFactorItems)
                    {

                        JQRatingScaleEntity JQRatingScale = jm.GetJQRatingScaleByID(factorItem.RatingScaleID);
                        if (JQRatingScale.RatingScaleTypeID == (int)enumRatingScaleType.DefaultYN || JQRatingScale.RatingScaleTypeID == (int)enumRatingScaleType.CustomYN)
                        {

                            RatingScaleResponseCollection listResponses = jm.GetJQRatingScaleResponseCollectionByFactorItemID(factorItem.RatingScaleID);

                         
                            if (previousRatingScaleTypeId != JQRatingScale.RatingScaleTypeID )                            
                            {
                                
                                    UTF8String = UTF8String + System.Environment.NewLine;
                                    UTF8String = UTF8String + "INSTRUCTIONS: " + JQRatingScale.RatingScaleInstruction + System.Environment.NewLine;
                                    //Now Set the previous Rating Scale to current after printing
                                    previousRatingScaleId = factorItem.RatingScaleID;
                                    previousRatingScaleTypeId = JQRatingScale.RatingScaleTypeID;
                                
                            }

                            UTF8String = UTF8String + System.Environment.NewLine;
                            UTF8String = UTF8String + factorItem.JQItemNo.ToString() + ". " + factorItem.JQItemText + System.Environment.NewLine;

                            foreach (RatingScaleResponse ratingScaleResponse in listResponses)
                            {
                                UTF8String = UTF8String + ratingScaleResponse.JQResponseLetter + " " + ratingScaleResponse.JQResponseText + System.Environment.NewLine;
                            }


                        }
                        else
                        {
                            RatingScaleResponseCollection listResponses = jm.GetJQRatingScaleResponseCollectionByFactorItemID(factorItem.RatingScaleID);                      
                           
                                if (previousRatingScaleTypeId  != JQRatingScale.RatingScaleTypeID)
                                {
                                    if (previousRatingScaleId > 0)
                                    {
                                        UTF8String = UTF8String + System.Environment.NewLine;
                                    }

                                    UTF8String = UTF8String + "INSTRUCTIONS: " + JQRatingScale.RatingScaleInstruction + System.Environment.NewLine;

                                    UTF8String = UTF8String + System.Environment.NewLine;

                                    //Now Set the previous Rating Scale to current after printing
                                    previousRatingScaleId = factorItem.RatingScaleID;
                                    previousRatingScaleTypeId = JQRatingScale.RatingScaleTypeID;

                                    if (factor.JQFactorTypeID == (int)enumJQFactorType.KSA)
                                    {
                                        foreach (RatingScaleResponse ratingScaleResponse in listResponses)
                                        {
                                            UTF8String = UTF8String + ratingScaleResponse.JQResponseLetter + " " + ratingScaleResponse.JQResponseText + System.Environment.NewLine;
                                        }
                                    }

                                }
                                UTF8String = UTF8String + System.Environment.NewLine;
                                UTF8String = UTF8String + factorItem.JQItemNo.ToString() + ". " + factorItem.JQItemText;
                                if (factor.JQFactorTypeID != (int)enumJQFactorType.KSA)
                                {
                                    UTF8String = UTF8String + System.Environment.NewLine;
                                    foreach (RatingScaleResponse ratingScaleResponse in listResponses)
                                    {
                                        UTF8String = UTF8String + ratingScaleResponse.JQResponseLetter + " " + ratingScaleResponse.JQResponseText + System.Environment.NewLine;
                                    }
                                }
                            
                        }

                        UTF8String = UTF8String + System.Environment.NewLine;
                    }

                    UTF8String = UTF8String + System.Environment.NewLine;
                }
            }
            return UTF8String + Environment.NewLine;
}

        #endregion

        #region AddToLibrary
        public static long AddKSAToLibrary(string KSAText, JQFactorEntity jqFactor)
        {
            return AddKSAToLibrary(KSAText, jqFactor, null);
        }

        public static long AddKSAToLibrary(string KSAText, JQFactorEntity jqFactor, TransactionManager currentTransaction)
        {
            long returnCode = -1;

            DbCommand commandWrapper = GetDbCommand("spr_AddKSAToLibrary");

            try
            {
                SqlParameter returnParam = new SqlParameter("@newKSAID", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;

                commandWrapper.Parameters.Add(returnParam);
                commandWrapper.Parameters.Add(new SqlParameter("@KSAText", KSAText));
                commandWrapper.Parameters.Add(new SqlParameter("@jQFactorID", jqFactor.ID));
                commandWrapper.Parameters.Add(new SqlParameter("@jQFactorTypeID", jqFactor.FactorTypeID));
                commandWrapper.Parameters.Add(new SqlParameter("@jQFactorNo", jqFactor.FactorNo));
                commandWrapper.Parameters.Add(new SqlParameter("@jQFactorTitle", jqFactor.Title));
                commandWrapper.Parameters.Add(new SqlParameter("@jQFactorInstruction", jqFactor.Instruction));
                commandWrapper.Parameters.Add(new SqlParameter("@isSF", jqFactor.IsSF));
                commandWrapper.Parameters.Add(new SqlParameter("@jQID", jqFactor.JQID));
                commandWrapper.Parameters.Add(new SqlParameter("@CreatedByID", jqFactor.CreatedByID));
                if (currentTransaction != null)
                {
                    ExecuteNonQuery(currentTransaction, commandWrapper);
                }
                else
                {
                    ExecuteNonQuery(commandWrapper);
                }

                returnCode = Convert.ToInt64(returnParam.Value);

            }
            catch (Exception ex)
            {
                if ((currentTransaction != null) && (currentTransaction.IsOpen))
                    currentTransaction.Rollback();

                HandleException(ex);
            }

            return returnCode;
        }

        public static long AddTaskStatementToLibrary(string taskStatement, JQFactorItemEntity jqFactorItem, int SeriesID, int Grade, long KSAID, int currentUserID)
        {
            return AddTaskStatementToLibrary(taskStatement, jqFactorItem, SeriesID, Grade, KSAID, null,currentUserID);
        }

        public static long AddTaskStatementToLibrary(string taskStatement, JQFactorItemEntity jqFactorItem, int SeriesID, int Grade, long KSAID, TransactionManager currentTransaction, int currentUserID)
        {
            long returnCode = -1;

            DbCommand commandWrapper = GetDbCommand("spr_AddTaskStatementToLibrary");

            try
            {
                SqlParameter returnParam = new SqlParameter("@newTaskStatementID", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;

                commandWrapper.Parameters.Add(returnParam);

                commandWrapper.Parameters.Add(new SqlParameter("@taskStatement", taskStatement));

                if (jqFactorItem.ID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@JQFactorItemID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@JQFactorItemID", jqFactorItem.ID));

                if (jqFactorItem.FactorID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@JQFactorID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@JQFactorID", jqFactorItem.FactorID));

                if (jqFactorItem.ParentItemID == null || jqFactorItem.ParentItemID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@JQParentItemID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@JQParentItemID", jqFactorItem.ParentItemID));

                if (jqFactorItem.ItemTypeID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@JQItemTypeID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@JQItemTypeID", jqFactorItem.ItemTypeID));

                if (jqFactorItem.ItemNo == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@JQItemNo", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@JQItemNo", jqFactorItem.ItemNo));

                if (string.IsNullOrWhiteSpace(jqFactorItem.ItemLetter))
                    commandWrapper.Parameters.Add(new SqlParameter("@JQItemLetter", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@JQItemLetter", jqFactorItem.ItemLetter));

                if (string.IsNullOrWhiteSpace(jqFactorItem.ItemText))
                    commandWrapper.Parameters.Add(new SqlParameter("@JQItemText", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@JQItemText", jqFactorItem.ItemText));

                if (jqFactorItem.RatingScaleID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@RatingScaleID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@RatingScaleID", jqFactorItem.RatingScaleID));

                if (jqFactorItem.TaskStatementID == -1)
                    commandWrapper.Parameters.Add(new SqlParameter("@TaskStatementID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@TaskStatementID", jqFactorItem.TaskStatementID));


                if(jqFactorItem.AEQuestionID ==-1)
                    commandWrapper.Parameters.Add(new SqlParameter("@AEQuestionID", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@AEQuestionID", jqFactorItem.AEQuestionID));


                commandWrapper.Parameters.Add(new SqlParameter("@SeriesID", SeriesID));
                commandWrapper.Parameters.Add(new SqlParameter("@Grade", Grade));
                commandWrapper.Parameters.Add(new SqlParameter("@KSAID", KSAID));
                commandWrapper.Parameters.Add(new SqlParameter("@CreatedByID", currentUserID));
                if (currentTransaction != null)
                {
                    ExecuteNonQuery(currentTransaction, commandWrapper);
                }
                else
                {
                    ExecuteNonQuery(commandWrapper);
                }

                returnCode = Convert.ToInt64(returnParam.Value);
            }
            catch (Exception ex)
            {
                if ((currentTransaction != null) && (currentTransaction.IsOpen))
                    currentTransaction.Rollback();

                HandleException(ex);
            }
            return returnCode;
        }

        public static long AddKSATaskStatementToLibrary(string KSAText, string taskStatement, JQFactorEntity jqFactor, JQFactorItemEntity jqFactorItem, int SeriesID, int Grade, int currentUserID)
        {
            long returnCode = -1;
            try
            {
                //Add KSA First
                AddKSAToLibrary(jqFactor.Title, jqFactor);

                //Get Values again after KSA ID is updated
                JQManager jqMgr = new JQManager();
                JQFactorEntity jqF = jqMgr.GetJQFactorByJQFactorID(jqFactor.ID);

                if (jqF.KSAID > 0)
                {
                    //Then add TaskStatement
                    returnCode = JQManager.AddTaskStatementToLibrary(jqFactorItem.ItemText, jqFactorItem, SeriesID, Grade, jqF.KSAID, currentUserID);
                }

            }
            catch (Exception ex)
            {

                throw new ApplicationException("Could not add KSA and TaskStatement to Library!");

            }

            return returnCode;

        }

        #endregion
    }
}
