using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using HCMS.Business.Base;
using HCMS.Business.Common;


namespace HCMS.Business.Factor
{
    [Serializable]
    public class PrimaryFESFactorLevelLanguage : BusinessBase
    {

        #region Private Members
        private int _levelID = -1;
        private int _point = -1;
        private int _factorID = -1;
        private string _factorLevelLanguage = string.Empty;

        #endregion

        #region Properties
        public enumFactorFormatType FactorFormatTypeID
        {
            get
            {
                return enumFactorFormatType.FES;
            }
           
        }

        public int LevelID
        {
            get
            {
                return this._levelID;
            }
            set
            {
                this._levelID = value;
            }
        }

        public string FactorLevelLanguage
        {
            get
            {
                return this._factorLevelLanguage;
            }
            set
            {
                this._factorLevelLanguage = value;
            }
        }



        public int Point
        {
            get
            {
                return this._point;
            }
            set
            {
                this._point = value;
            }
        }

        public int FactorID
        {
            get
            {
                return this._factorID;
            }
            set
            {
                this._factorID = value;
            }
        }

        #endregion

        #region Constructors
        public PrimaryFESFactorLevelLanguage()
        {
        }
        public PrimaryFESFactorLevelLanguage(int factorID,int levelID)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetFESPrimaryFactorByFactorIDLevelID", factorID,levelID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        #endregion
        #region Constructor Helper Methods

        private void loadData(DataTable returnTable)
        {
            if (returnTable.Rows.Count > 0)
            {
                DataRow returnRow = returnTable.Rows[0];

                this.FillObjectFromRowData(returnRow);
            }
        }

        protected virtual void FillObjectFromRowData(DataRow returnRow)
        {
            this._levelID = (int)returnRow["LevelID"];

            if (returnRow["FactorLevelLanguage"] != DBNull.Value)
                this._factorLevelLanguage = returnRow["FactorLevelLanguage"].ToString();


            DataColumnCollection columns = returnRow.Table.Columns;
            if (columns.Contains("Point"))
            {
                this._point = (int)returnRow["Point"];
            }
            if (columns.Contains("FactorID"))
            {
                this._factorID = (int)returnRow["FactorID"];
            }
        }

        #endregion


    }
}
