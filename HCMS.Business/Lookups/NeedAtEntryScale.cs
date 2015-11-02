using System;
using System.Collections.Generic;
using System.Data;

using HCMS.Business.Base;
using HCMS.Business.Lookups.Collections;

namespace HCMS.Business.Lookups
{
    public class NeedAtEntry : BusinessBase
    {
        #region Object Declarations

        private int _needAtEntryID = -1;
        private string _needAtEntryName = string.Empty;
        private int _pointValue = -1;

        #endregion

        #region Properties

        public int NeedAtEntryID
        {
            get
            {
                return this._needAtEntryID;
            }
            set
            {
                this._needAtEntryID = value;
            }
        }

        public string NeedAtEntryName
        {
            get
            {
                return this._needAtEntryName;
            }
            set
            {
                this._needAtEntryName = value;
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

        public NeedAtEntry()
        {
            // Empty Constructor
        }

        public NeedAtEntry(DataRow singleRowData)
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
                if (returnRow["NeedAtEntryID"] != DBNull.Value)
                    this._needAtEntryID = (int)returnRow["NeedAtEntryID"];

                if (returnRow["NeedAtEntryName"] != DBNull.Value)
                    this._needAtEntryName = returnRow["NeedAtEntryName"].ToString();

                if (returnRow["PointValue"] != DBNull.Value)
                    this._pointValue = (int)returnRow["PointValue"];
            }
        }

        #endregion
    }
}
