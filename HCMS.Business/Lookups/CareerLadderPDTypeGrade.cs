using System;
using System.Collections.Generic;
using System.Data;

using HCMS.Business.Base;
using HCMS.Business.Lookups.Collections;

namespace HCMS.Business.Lookups
{
    /// <summary>
    /// CareerLadderPDTypeGrade Business Object
    /// </summary>
    [Serializable]
    public class CareerLadderPDTypeGrade : CareerLadderPDType
    {
        #region Private Members

        private int _grade = -1;

        #endregion

        #region Properties

        public int Grade
        {
            get
            {
                return this._grade;
            }
            set
            {
                this._grade = value;
            }
        }

        #endregion

        #region Constructors

        public CareerLadderPDTypeGrade(DataRow singleRowData) : base(singleRowData)
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
            if (returnRow["grade"] != DBNull.Value)
                this._grade = (int) returnRow["grade"];

            base.FillObjectFromRowData(returnRow);
        }

        #endregion

        #region Collection Helper Methods

        internal static CareerLadderPDTypeGradeCollection GetCollection(DataTable dataItems)
        {
            CareerLadderPDTypeGradeCollection listCollection = new CareerLadderPDTypeGradeCollection();

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                    listCollection.Add(new CareerLadderPDTypeGrade(dataItems.Rows[i]));
            }
            else
                throw new Exception("You cannot create a CareerLadderPDTypeGrade collection from a null data table.");

            return listCollection;
        }

        #endregion

    }
}

