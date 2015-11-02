using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using HCMS.Business.Base;

namespace HCMS.Business.Lookups
{
    public class Country
    {
        #region Object Declarations

        private int _countryID = -1;
        private string _countryCode = string.Empty;
        private string _countryName = string.Empty;

        #endregion

        #region Properties

        public int CountryID
        {
            get
            {
                return this._countryID;
            }
            set
            {
                this._countryID = value;
            }
        }

        public string CountryCode
        {
            get
            {
                return this._countryCode;
            }
            set
            {
                this._countryCode = value;
            }
        }

        public string CountryName
        {
            get
            {
                return this._countryName;
            }
            set
            {
                this._countryName = value;
            }
        }

        #endregion

        #region Constructors

        public Country()
        {
            // Empty Constructor
        }

        #endregion
    }
}