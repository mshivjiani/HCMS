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

namespace HCMS.Business.JQ
{
	/// <summary>
	/// JQFactorItem Business Object
	/// </summary>
    [Serializable]
    public class JQFactorItem : JQCommonBase
    {
        #region Private Members

        private long _JQFactorItemID = -1;
        private long _JQFactorID = -1;
        private long _JQParentItemID = -1;
        private int _JQItemTypeID = -1;
        private int _JQItemNo = -1;
        private string _JQItemLetter = string.Empty;
        private string _JQItemText = string.Empty;
        private long _ratingScaleID = -1;
        private long _taskStatementID = -1;
        private int _AEQuestionID = -1;

        #endregion

        #region Properties

        public long JQFactorItemID
        {
            get
            {
                return this._JQFactorItemID;
            }
            set
            {
                this._JQFactorItemID = value;
            }
        }

        public long JQFactorID
        {
            get
            {
                return this._JQFactorID;
            }
            set
            {
                this._JQFactorID = value;
            }
        }

        public long JQParentItemID
        {
            get
            {
                return this._JQParentItemID;
            }
            set
            {
                this._JQParentItemID = value;
            }
        }

        public int JQItemTypeID
        {
            get
            {
                return this._JQItemTypeID;
            }
            set
            {
                this._JQItemTypeID = value;
            }
        }

        public int JQItemNo
        {
            get
            {
                return this._JQItemNo;
            }
            set
            {
                this._JQItemNo = value;
            }
        }

        public string JQItemLetter
        {
            get
            {
                return this._JQItemLetter;
            }
            set
            {
                this._JQItemLetter = value;
            }
        }

        public string JQItemText
        {
            get
            {
                return this._JQItemText;
            }
            set
            {
                this._JQItemText = value;
            }
        }

        public long RatingScaleID
        {
            get
            {
                return this._ratingScaleID;
            }
            set
            {
                this._ratingScaleID = value;
            }
        }

        public long TaskStatementID
        {
            get
            {
                return this._taskStatementID;
            }
            set
            {
                this._taskStatementID = value;
            }
        }
        public int AEQuestionID
        {
            get
            {
                return this._AEQuestionID;
            }
            set
            {
                this._AEQuestionID = value;
            }
        }
        #endregion

        #region Constructors

        public JQFactorItem()
        {
            // Empty Constructor
        }

        public JQFactorItem(JQFactorItemEntity loadByEntity)
        {
            try
            {
                // allows conversion from JQFactorItemEntity to JQFactorItem
                this._JQFactorID = loadByEntity.ID;
                this._JQFactorID = loadByEntity.FactorID;
                this._JQParentItemID = loadByEntity.ParentItemID.HasValue ? loadByEntity.ParentItemID.Value : -1;
                this._JQItemTypeID = loadByEntity.ItemTypeID;
                this._JQItemNo = loadByEntity.ItemNo;
                this._JQItemLetter = loadByEntity.ItemLetter;
                this._JQItemText = loadByEntity.ItemText;
                this._ratingScaleID = loadByEntity.RatingScaleID;
                this._taskStatementID = loadByEntity.TaskStatementID;
                this._AEQuestionID = loadByEntity.AEQuestionID;
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public JQFactorItem(int loadByID)
        {
            // Load Object by ID
            DataTable returnTable;
            try
            {
                returnTable = ExecuteDataTable("spr_GetJQFactorItemByID", loadByID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        public JQFactorItem(DataRow singleRowData)
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
            if (returnRow["JQFactorItemID"] != DBNull.Value)
                this._JQFactorItemID = (long)returnRow["JQFactorItemID"];

            if (returnRow["JQFactorID"] != DBNull.Value)
                this._JQFactorID = (long)returnRow["JQFactorID"];

            if (returnRow["JQParentItemID"] != DBNull.Value)
                this._JQParentItemID = (long)returnRow["JQParentItemID"];

            if (returnRow["JQItemTypeID"] != DBNull.Value)
                this._JQItemTypeID = (int)returnRow["JQItemTypeID"];

            if (returnRow["JQItemNo"] != DBNull.Value)
                this._JQItemNo = (int)returnRow["JQItemNo"];

            if (returnRow["JQItemLetter"] != DBNull.Value)
                this._JQItemLetter = returnRow["JQItemLetter"].ToString();

            if (returnRow["JQItemText"] != DBNull.Value)
                this._JQItemText = returnRow["JQItemText"].ToString();

            if (returnRow["RatingScaleID"] != DBNull.Value)
                this._ratingScaleID = (long)returnRow["RatingScaleID"];

            if (returnRow["TaskStatementID"] != DBNull.Value)
                this._taskStatementID = (long)returnRow["TaskStatementID"];

            if (returnRow["AEQuestionID"] != DBNull.Value)
                this._AEQuestionID = (int)returnRow["AEQuestionID"];
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
            return "JQFactorItemID:" + JQFactorItemID.ToString();
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
            JQFactorItem JQFactorItemobj = obj as JQFactorItem;

            return (JQFactorItemobj == null) ? false : (this.JQFactorItemID == JQFactorItemobj.JQFactorItemID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return JQFactorItemID.GetHashCode();
        }
         
        #endregion

        #region General Methods


        #endregion
    }
    
    public class JQFactorItemEntity
    {
        private long _taskStatementID = -1;
        public int _AEQuestionID = -1;
        

        public long ID { get; set; }
        public long FactorID { get; set; }
        public long? ParentItemID { get; set; }
        public int ItemTypeID { get; set; }
        public int ItemNo { get; set; }
        public string ItemLetter { get; set; }
        public string ItemText { get; set; }
        public long RatingScaleID { get; set; }
        public int RatingScaleTypeID {get; set;}
        public string RatingScaleName { get; set; }


        public long TaskStatementID
        {
            get
            {
                return this._taskStatementID;
            }
            set
            {
                this._taskStatementID = value;
            }
        }

        public int AEQuestionID
        {
            get { return this._AEQuestionID; }
            set { this._AEQuestionID = value; }
        }


        private long _QualificationStatementID = -1;
        public long QualificationStatementID
        {
            get
            {
                return this._QualificationStatementID;
            }
            set
            {
                this._QualificationStatementID = value;
            }
        }

        public bool IsDefault { get; set; }
        public string RatingScaleInstruction { get; set; }
    }
}

