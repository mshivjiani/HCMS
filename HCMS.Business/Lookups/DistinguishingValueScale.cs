using System;
using System.Collections.Generic;
using System.Data;

using HCMS.Business.Base;
using HCMS.Business.Lookups.Collections;

namespace HCMS.Business.Lookups
{
    public class DistinguishingValueScale : BusinessBase
    {
        #region Object Declarations

        private int _scaleID = -1;
        private string _scaleName = string.Empty;
        private int _pointValue = -1;

        #endregion

        #region Properties

        public int ScaleID
        {
            get
            {
                return this._scaleID;
            }
            set
            {
                this._scaleID = value;
            }
        }

        public string ScaleName
        {
            get
            {
                return this._scaleName;
            }
            set
            {
                this._scaleName = value;
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

        public DistinguishingValueScale()
        {
            // Empty Constructor
        }

        public DistinguishingValueScale(DataRow singleRowData)
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
                if (returnRow["ScaleID"] != DBNull.Value)
                    this._scaleID = (int)returnRow["ScaleID"];

                if (returnRow["ScaleName"] != DBNull.Value)
                    this._scaleName = returnRow["ScaleName"].ToString();

                if (returnRow["PointValue"] != DBNull.Value)
                    this._pointValue = (int)returnRow["PointValue"];
            }
        }

        #endregion
    }
}