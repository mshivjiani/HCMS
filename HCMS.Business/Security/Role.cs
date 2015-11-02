using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

using HCMS.Business.Base;
using HCMS.Business.Security.Collections;

namespace HCMS.Business.Security
{
    /// <summary>
    /// Role Business Object
    /// </summary>
    [Serializable]
    public class Role : BusinessBase, IRole
    {
        #region Private Members

        private int _roleID = -1;
        private string _roleName = string.Empty;
        private string _roleDescription = string.Empty;

        #endregion

        #region Properties

        public int RoleID
        {
            get
            {
                return this._roleID;
            }
            set
            {
                this._roleID = value;
            }
        }

        public string RoleName
        {
            get
            {
                return this._roleName;
            }
            set
            {
                this._roleName = value;
            }
        }

        public string RoleDescription
        {
            get
            {
                return this._roleDescription;
            }
            set
            {
                this._roleDescription = value;
            }
        }

        #endregion

        #region Constructors

        public Role()
        {
            // Empty Constructor
        }

        public Role(DataRow singleRowData)
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
            if (returnRow["RoleID"] != DBNull.Value)
                this._roleID = (int)returnRow["RoleID"];

            if (returnRow["RoleName"] != DBNull.Value)
                this._roleName = returnRow["RoleName"].ToString();

            if (returnRow["RoleDescription"] != DBNull.Value)
                this._roleDescription = returnRow["RoleDescription"].ToString();
        }

        #endregion

        #region ToString Method

        ///<summary>
        /// Returns a String that represents the current object.
        ///</summary>
        public override string ToString()
        {
        
            return this._roleID.ToString();
        }

        #endregion ToString Method

        #region CompareMethods
        /// <summary>
        /// Determines whether the specified System.Object is equal to the current object.
        /// </summary>
        /// <param name="obj">The System.Object to compare with the current object.</param>
        /// <returns>Returns true if the specified System.Object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(Object obj)
        {

            Role Roleobj = obj as Role;

            return (Roleobj == null) ? false : (this._roleID == Roleobj.RoleID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return this._roleID.GetHashCode();
        }

        #endregion
           
        #region Collection Helper Methods

        internal static RoleCollection GetCollection(DataTable dataItems)
        {
            RoleCollection listCollection = new RoleCollection();
            
            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                    listCollection.Add( new Role(dataItems.Rows[i]));
            }
            else
                throw new Exception("You cannot create a RoleCollection from a null data table.");

            return listCollection;
        }

        #endregion
    }
}

