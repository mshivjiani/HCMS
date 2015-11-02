using System;
using System.Collections.Generic;
using System.Data;

using HCMS.Business.Base;
using HCMS.Business.PD.Collections;

namespace HCMS.Business.PD
{
    /// <summary>
    /// CareerLadderPDType Business Object
    /// </summary>
    [Serializable]
    public class PDValidationError : BusinessBase
    {
        #region Private Members

        private int _errorID = -1;
        private string _errorMessage = string.Empty;

        #endregion

        #region Properties

        public int ErrorID
        {
            get
            {
                return this._errorID;
            }
            set
            {
                this._errorID = value;
            }
        }

        public string ErrorMessage
        {
            get
            {
                return this._errorMessage;
            }
            set
            {
                this._errorMessage = value;
            }
        }

        #endregion

        #region Constructors

        public PDValidationError(DataRow singleRowData)
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

        protected virtual void FillObjectFromRowData(DataRow returnRow)
        {
            if (returnRow["ErrorID"] != DBNull.Value)
                this._errorID = (int)returnRow["ErrorID"];

            if (returnRow["ErrorMessage"] != DBNull.Value)
                this._errorMessage = returnRow["ErrorMessage"].ToString();
        }

        #endregion

        #region Collection Helper Methods

        internal static PDValidationErrorCollection GetCollection(DataTable dataItems)
        {
            PDValidationErrorCollection listCollection = new PDValidationErrorCollection();

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                    listCollection.Add(new PDValidationError(dataItems.Rows[i]));
            }
            else
                throw new Exception("You cannot create a PDValidationError collection from a null data table.");

            return listCollection;
        }

        #endregion
    }
}


