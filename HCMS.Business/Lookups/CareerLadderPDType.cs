using System;
using System.Collections.Generic;
using System.Data;

using HCMS.Business.Base;
using HCMS.Business.Lookups.Collections;

namespace HCMS.Business.Lookups
{
    /// <summary>
    /// CareerLadderPDType Business Object
    /// </summary>
    [Serializable]
    public class CareerLadderPDType : BusinessBase
    {
        #region Private Members

        private int _careerLadderPDTypeID = -1;
        private string _ladderTypeName = string.Empty;

        #endregion

        #region Properties

        public int CareerLadderPDTypeID
        {
            get
            {
                return this._careerLadderPDTypeID;
            }
            set
            {
                this._careerLadderPDTypeID = value;
            }
        }

        public string LadderTypeName
        {
            get
            {
                return this._ladderTypeName;
            }
            set
            {
                this._ladderTypeName = value;
            }
        }

        #endregion

        #region Constructors

        public CareerLadderPDType(DataRow singleRowData)
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
            if (returnRow["CareerLadderPDTypeID"] != DBNull.Value)
                this._careerLadderPDTypeID = (int)returnRow["CareerLadderPDTypeID"];

            if (returnRow["CareerLadderPDType"] != DBNull.Value)
                this._ladderTypeName = returnRow["CareerLadderPDType"].ToString();
        }

        #endregion

        #region Collection Helper Methods

        internal static CareerLadderPDTypeCollection GetCollection(DataTable dataItems)
        {
            CareerLadderPDTypeCollection listCollection = new CareerLadderPDTypeCollection();

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                    listCollection.Add(new CareerLadderPDType(dataItems.Rows[i]));
            }
            else
                throw new Exception("You cannot create a CareerLadderPDType collection from a null data table.");

            return listCollection;
        }

        #endregion
    }
}

