using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using HCMS.Business.Base;

namespace HCMS.Business.Lookups
{
    public class OrgPositionPlacementType
    {
        #region Object Declarations

        private int _placementTypeID = -1;
        private string _placementTypeName = string.Empty;

        #endregion

        #region Properties

        public int PlacementTypeID
        {
            get
            {
                return this._placementTypeID;
            }
            set
            {
                this._placementTypeID = value;
            }
        }

        public string PlacementTypeName
        {
            get
            {
                return this._placementTypeName;
            }
            set
            {
                this._placementTypeName = value;
            }
        }

        #endregion

        #region Constructors

        public OrgPositionPlacementType()
        {
            // Empty Constructor
        }

        #endregion
    }
}