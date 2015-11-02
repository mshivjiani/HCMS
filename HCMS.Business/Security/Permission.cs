using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using HCMS.Business.Base;
using HCMS.Business.Security.Collections;

namespace HCMS.Business.Security
{
    /// <summary>
    /// Permission Business Object
    /// </summary>
    [Serializable]
    public class Permission : BusinessBase, IPermission 
    {
        #region Private Members

        private int _permissionID = -1;
        private string _permissionName = string.Empty;

        #endregion

        #region Properties

        public int PermissionID
        {
            get
            {
                return this._permissionID;
            }
            set
            {
                this._permissionID = value;
            }
        }

        public string PermissionName
        {
            get
            {
                return this._permissionName;
            }
            set
            {
                this._permissionName = value;
            }
        }

        #endregion

        #region Constructors

        public Permission()
        {
            // Empty Constructor
        }

        public Permission(DataRow singleRowData)
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
            if (returnRow["PermissionID"] != DBNull.Value)
                this._permissionID = (int)returnRow["PermissionID"];

            if (returnRow["PermissionName"] != DBNull.Value)
                this._permissionName = returnRow["PermissionName"].ToString();
        }

        #endregion

        #region Collection Helper Methods

        internal static PermissionCollection GetCollection(DataTable dataItems)
        {
            PermissionCollection listCollection = new PermissionCollection();
            Permission current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new Permission(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a Permission collection from a null data table.");

            return listCollection;
        }

        #endregion
    }
}

