using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HCMS.Business.Base;
namespace HCMS.Business.Series
{
    [Serializable]
    public class SeriesGradeKSATaskStatement
    {
        #region Private Members
        private int _seriesID = -1;
        private int _grade = -1;
        private long _ksaID = -1;
        private long _taskStatementID = -1;

        #endregion

        #region Public properties
        public int SeriesID
        {
            get { return this._seriesID; }
            set { this._seriesID = value; }
        }

        public int Grade
        {
            get { return this._grade; }
            set { this._grade = value; }
        }

        public long KSAID
        {
            get { return this._ksaID; }
            set { this._ksaID = value; }
        }

        public long TaskStatementID
        {
            get { return this._taskStatementID; }
            set { this._taskStatementID = value; }
        }

        #endregion

        #region Constructors

        public SeriesGradeKSATaskStatement()
        {
            // Empty Constructor
        }
        public SeriesGradeKSATaskStatement(DataRow singleRowData)
        {
            // Load Object by dataRow
            try
            {
                this.FillObjectFromRowData(singleRowData);
            }
            catch (Exception ex)
            {
                ExceptionBase.HandleException(ex);
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
            this._seriesID = (int)returnRow["SeriesID"];
            this._grade = (int)returnRow["Grade"];
            this._ksaID = (long)returnRow["KSAID"];
            this._taskStatementID = (long)returnRow["TaskStatementID"];
        }

        #endregion

     
    }
}
