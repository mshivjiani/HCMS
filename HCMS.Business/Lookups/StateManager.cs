using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HCMS.Business.Base;
using HCMS.Business.Common;
using HCMS.Business.Lookups;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace HCMS.Business.Lookups 
{
    [System.ComponentModel.DataObject]
    public class StateManager : BusinessBase
    {
        #region [Get Methods]
        public static State GetStateByID(int StateID)
        {
            State item = null;

            try
            {
                DataTable returnTable = ExecuteDataTable("spr_GetStateByID", StateID);
                item = loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return item;
        }
        public static State GetState(DataRow singleRowData)
        {
            // Load Object by dataRow
            State item = null;
            try
            {
                item = FillObjectFromRowData(singleRowData);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return item;
        }

        #endregion

        #region [Private Methods]
        private static State loadData(DataTable returnTable)
        {
            if (returnTable.Rows.Count > 0)
            {
                DataRow returnRow = returnTable.Rows[0];

                return FillObjectFromRowData(returnRow);
            }

            return null;
        }
        private static State FillObjectFromRowData(DataRow returnRow)
        {
            State state = new State();
            if (returnRow["StateID"] != DBNull.Value)
            { state.StateID = (int)returnRow["StateID"]; }

            if (returnRow["StateAbbreviation"] != DBNull.Value)
            {
                state.StateAbbreviation = returnRow["StateAbbreviation"].ToString ();
               
            }
            if (returnRow["StateName"] != DBNull.Value)
            {
               state.StateName  = returnRow["StateName"].ToString();
            }
           
            return state;
        }
        #endregion

      

        #region [Collection Methods]
        private static List<State> GetCollection(DataTable table)
        {
            List<State> list = new List<State>();
            try
            {
                if (table != null)
                {
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        State item = FillObjectFromRowData(table.Rows[i]);
                        list.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return list;
        }

        public static List<State> GetAllStates()
        {
            List<State> list = null;

            try
            {
                DataTable table = ExecuteDataTable("spr_GetAllStates");

                // fill a list
                list = GetCollection(table);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return list;
        }
 

        #endregion
    }
}
