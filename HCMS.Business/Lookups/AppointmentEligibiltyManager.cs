using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Base;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace HCMS.Business.Lookups.Collections
{
    [System.ComponentModel.DataObject]
    public class AppointmentEligibiltyManager : BusinessBase
    {
        #region General CRUD Methods

        public int Add(AppointmentEligibilty ApptEligibility)
        {
            int returnID = -1;
            DbCommand commandWrapper = GetDbCommand("spr_AddApptEligibiltyQuestion");

            try
            {
                SqlParameter returnParam = new SqlParameter("@NewAEQuestionID", SqlDbType.Int);
                returnParam.Direction = ParameterDirection.Output;

                commandWrapper.Parameters.Add(returnParam);

                if (string.IsNullOrWhiteSpace(ApptEligibility.AEQuestion))
                    commandWrapper.Parameters.Add(new SqlParameter("@AEQuestion", DBNull.Value));
                else
                    commandWrapper.Parameters.Add(new SqlParameter("@AEQuestion", ApptEligibility.AEQuestion.Trim()));

                commandWrapper.Parameters.Add(new SqlParameter("@Active", ApptEligibility.Active));

                ExecuteNonQuery(commandWrapper);

                ApptEligibility.AEQuestionID = (int)returnParam.Value;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return returnID;
        }

        public void Update(AppointmentEligibilty ApptEligibility)
        {

            if (base.ValidateKeyField(ApptEligibility.AEQuestionID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateApptEligibiltyQuestion");

                try
                {
                    if (ApptEligibility.AEQuestionID == -1)
                        commandWrapper.Parameters.Add(new SqlParameter("@AEQuestionID", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@AEQuestionID", ApptEligibility.AEQuestionID));

                    if (string.IsNullOrWhiteSpace(ApptEligibility.AEQuestion))
                        commandWrapper.Parameters.Add(new SqlParameter("@AEQuestion", DBNull.Value));
                    else
                        commandWrapper.Parameters.Add(new SqlParameter("@AEQuestion", ApptEligibility.AEQuestion.Trim()));


                    commandWrapper.Parameters.Add(new SqlParameter("@Active", ApptEligibility.Active));

                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        public void Delete(AppointmentEligibilty ApptEligibility)
        {
            if (base.ValidateKeyField(ApptEligibility.AEQuestionID))
            {
                try
                {
                    ExecuteNonQuery("spr_DeleteApptEligibiltyQuestion", ApptEligibility.AEQuestionID);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        #endregion

        #region Constructor Helper Methods

        public AppointmentEligibilty GetAppointmentEligibiltyQuestion(long loadByID)
        {
            // Load Object by ID
            DataTable returnTable;
            try
            {
                returnTable = ExecuteDataTable("spr_GetApptEligibiltyQuestionByID", loadByID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return null;
        }

        public AppointmentEligibilty GetAppointmentEligibiltyQuestion(DataRow singleRowData)
        {
            // Load Object by dataRow
            try
            {
                this.FillObjectFromRowData(singleRowData);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return null;
        }

        private AppointmentEligibilty loadData(DataTable returnTable)
        {
            if (returnTable.Rows.Count > 0)
            {
                DataRow returnRow = returnTable.Rows[0];

                return FillObjectFromRowData(returnRow);
            }

            return null;
        }

        protected virtual AppointmentEligibilty FillObjectFromRowData(DataRow returnRow)
        {
            AppointmentEligibilty AppotEligibilty = new AppointmentEligibilty();
            if (returnRow["AEQuestionID"] != DBNull.Value)
                AppotEligibilty.AEQuestionID = (int)returnRow["AEQuestionID"];

            if (returnRow["AEQuestion"] != DBNull.Value)
                AppotEligibilty.AEQuestion = returnRow["AEQuestion"].ToString();

            if (returnRow["Active"] != DBNull.Value)
                AppotEligibilty.Active = (bool)returnRow["Active"];

            return AppotEligibilty;

        }

        #endregion

        #region Collection Methods

        public List<AppointmentEligibilty> GetAllAppointmentEligibiltyQuestion()
        {
            List<AppointmentEligibilty> listCollection = new List<AppointmentEligibilty>();

            DataTable dataItems = ExecuteDataTable("spr_GetAllApptEligibiltyQuestion");

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    AppointmentEligibilty item = new AppointmentEligibilty();

                    item.AEQuestionID = dataItems.Rows[i].Field<int>("AEQuestionID");
                    item.AEQuestion = dataItems.Rows[i].Field<string>("AEQuestion");
                    //item.Active = dataItems.Rows[i].Field<bool>("Active");

                    listCollection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a Appointment Eligibility collection from a null data table.");
            }

            return listCollection;
        }

        public List<AppointmentEligibilty> GetAllActiveAppointmentEligibiltyQuestion()
        {
            List<AppointmentEligibilty> listCollection = new List<AppointmentEligibilty>();

            DataTable dataItems = ExecuteDataTable("spr_GetAllActiveApptEligibiltyQuestion");

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    AppointmentEligibilty item = new AppointmentEligibilty();

                    item.AEQuestionID = dataItems.Rows[i].Field<int>("AEQuestionID");
                    item.AEQuestion = dataItems.Rows[i].Field<string>("AEQuestion");
                    item.Active = dataItems.Rows[i].Field<bool>("Active");

                    listCollection.Add(item);
                }
            }
            else
            {
                throw new Exception("You cannot create a Appointment Eligibility collection from a null data table.");
            }

            return listCollection;
        }

        /// <summary>
        /// Takes a full Appointment Eligibility question list and filters those duplicated or added ones.
        /// </summary>
        /// <param name="ApptEligNew"></param>
        /// <param name="FacItemFilter"></param>
        /// <returns></returns>
        public List<AppointmentEligibilty> FilterAddedApptEligibilityQuestions(List<AppointmentEligibilty> ApptEligNew, List<HCMS.Business.JQ.JQFactorItemEntity> FacItemFilter)
        {
            for (int i = 0; i < FacItemFilter.Count; i++)
            {
                for (int j = 0; j < ApptEligNew.Count; j++)
                {
                    //Exclude Create New i.e. ID = 0
                    if (FacItemFilter[i].AEQuestionID != 0 && ApptEligNew[j].AEQuestionID != 0)
                    {
                        if (FacItemFilter[i].AEQuestionID == ApptEligNew[j].AEQuestionID)
                        {
                            ApptEligNew.Remove(ApptEligNew[j]);
                        }
                    }
                }
            }

            return ApptEligNew;

        }

        #endregion

    }
}
