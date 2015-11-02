using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

using HCMS.Business.Base;
namespace HCMS.Business.PD
{
    [Serializable]
    public class PositionGradePoint : BusinessBase
    {
        #region Private Members
        private int _totalPoints = -1;
        private int _minPoint = -1;
        private int _maxPoint = -1;
        private int _grade = -1;
        private long _positionDescriptionID = -1;
        private int _factorFormatTypeID = -1;
        #endregion
        #region Properties
        public int TotalPoints
        {
            get
            {
                return this._totalPoints;
            }
            set
            {
                this._totalPoints = value;
            }
        }
        public int MinPoint
        {
            get
            {
                return this._minPoint;
            }
            set
            {
                this._minPoint = value;
            }
        }
        public int MaxPoint
        {
            get
            {
                return this._maxPoint;
            }
            set
            {
                this._maxPoint = value;
            }
        }
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
        public long PositionDescriptionID
        {
            get
            {
                return this._positionDescriptionID;
            }
            set
            {
                this._positionDescriptionID = value;
            }
        }
        public int FactorFormatTypeID
        {
            get
            {
                return this._factorFormatTypeID;
            }
            set
            {
                this._factorFormatTypeID = value;
            }
        }
        #endregion
        #region Constructors
        public PositionGradePoint()
        {
        }
        public PositionGradePoint(long positionDescriptionID)
        {
            DataTable returnTable;

            try
            {// Load by PositionDescriptionID
                returnTable = ExecuteDataTable("spr_GetPositionGrade", positionDescriptionID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        public PositionGradePoint(long positionDescriptionID, int factorFormatTypeID)
        {
            DataTable returnTable;

            try
            {
                // Load by PositionDescriptionID and factorFormatTypeID

                object[] parameters = new object[]
                {
                    positionDescriptionID,
                    factorFormatTypeID
                };

                returnTable = ExecuteDataTable("spr_GetPositionGradeByFactorFormatTypeID", parameters);
                loadData(returnTable);
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
            DataColumnCollection columns = returnRow.Table.Columns;

            this.TotalPoints = (int)returnRow["TotalPoints"];
            this.MinPoint = (int)returnRow["MinPoint"];
            this.MaxPoint = (int)returnRow["MaxPoint"];
            this.Grade = (int)returnRow["Grade"];
            this.PositionDescriptionID = (long)returnRow["PositionDescriptionID"];

            if (columns.Contains("FactorFormatTypeID"))
            {
                if (returnRow["FactorFormatTypeID"] != DBNull.Value)
                    this._factorFormatTypeID = (int)returnRow["FactorFormatTypeID"];
            }
        }
        #endregion
        #region ToXML Method

        ///<summary>
        /// Returns an XML String that represents the current object.
        ///</summary>
        public string ToXML()
        {
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            using (StreamReader sr = new StreamReader(new MemoryStream()))
            {
                serializer.Serialize(sr.BaseStream, this);
                sr.BaseStream.Position = 0;
                return sr.ReadToEnd();
            }
        }

        #endregion ToXML Method
        #region ToString Method

        ///<summary>
        /// Returns a String that represents the current object.
        ///</summary>
        public override string ToString()
        {
            string retval = string.Empty;
            retval = string.Format("Position Description ID:{0}, Total Points:{1}, Grade: GS-{2}", PositionDescriptionID.ToString(), TotalPoints.ToString(), Grade.ToString());
            return retval;
        }

        #endregion ToString Method
    }
}
