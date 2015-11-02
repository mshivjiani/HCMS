using System;
using System.Collections.Generic;
using System.Data;

using HCMS.Business.Base;
using HCMS.Business.Lookups.Collections;

namespace HCMS.Business.Lookups
{
    public class ImportanceScale : BusinessBase
    {
        #region Object Declarations

        private int _importanceID = -1;
        private string _importanceName = string.Empty;
        private int _pointValue = -1;

        #endregion

        #region Properties

        public int ImportanceID
        {
            get
            {
                return this._importanceID;
            }
            set
            {
                this._importanceID = value;
            }
        }

        public string ImportanceName
        {
            get
            {
                return this._importanceName;
            }
            set
            {
                this._importanceName = value;
            }
        }

        public int PointValue
        {
            get
            {
                return this._pointValue;
            }
            set
            {
                this._pointValue = value;
            }
        }

        #endregion

        #region Constructors

        public ImportanceScale()
        {
            // Empty Constructor
        }

        public ImportanceScale(DataRow singleRowData)
        {
            // Load Object by dataRow
            try
            {
                this.Fill(singleRowData);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        #endregion

        #region Constructor Helper Methods

        private void Fill(DataRow returnRow)
        {
            if (returnRow != null)
            {
                if (returnRow["ImportanceID"] != DBNull.Value)
                    this._importanceID = (int)returnRow["ImportanceID"];

                if (returnRow["ImportanceName"] != DBNull.Value)
                    this._importanceName = returnRow["ImportanceName"].ToString();

                if (returnRow["PointValue"] != DBNull.Value)
                    this._pointValue = (int)returnRow["PointValue"];
            }
        }

        #endregion
    }
}