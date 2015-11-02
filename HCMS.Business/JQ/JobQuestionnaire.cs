using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace HCMS.Business.JQ
{
    /// <summary>
    /// JobQuestionnaire Business Object
    /// </summary>
    [Serializable]
    public class JobQuestionnaire
    {
        #region Private Members

        private long _JQID = -1;
        private int _JQPayPlanID = -1;
        private int _JQSeriesID = -1;
        private bool _isInterdisciplinary = false;
        private int _additionalJQSeriesID = -1;
        private int _lowestAdvertisedGrade = -1;
        private int _highestAdvertisedGrade = -1;
        private string _JQName = string.Empty;
        private string _JQPositionTitle = string.Empty;
        private bool _isStandardJQ = false;
        private int _createdByID = -1;
        private DateTime? _createDate;
        private int _updatedByID = -1;
        private DateTime? _updateDate;

        public string CreatedByFullName { get; set; }
        public string UpdatedByFullName {get; set;}
        public string PayPlanName { get; set; }
        public string SeriesName { get; set; }
        public string AdditionalSeriesName { get; set; }
        public string LowestAdvertisedGradeName { get; set; }
        public string HighestAdvertisedGradeName { get; set; }

        #endregion

        #region Properties

        public long JQID
        {
            get
            {
                return this._JQID;
            }
            set
            {
                this._JQID = value;
            }
        }

        public int JQPayPlanID
        {
            get
            {
                return this._JQPayPlanID;
            }
            set
            {
                this._JQPayPlanID = value;
            }
        }

        public int JQSeriesID
        {
            get
            {
                return this._JQSeriesID;
            }
            set
            {
                this._JQSeriesID = value;
            }
        }

        public bool IsInterdisciplinary
        {
            get
            {
                return this._isInterdisciplinary;
            }
            set
            {
                this._isInterdisciplinary = value;
            }
        }

        public int AdditionalJQSeriesID
        {
            get
            {
                return this._additionalJQSeriesID;
            }
            set
            {
                this._additionalJQSeriesID = value;
            }
        }

        public int LowestAdvertisedGrade
        {
            get
            {
                return this._lowestAdvertisedGrade;
            }
            set
            {
                this._lowestAdvertisedGrade = value;
            }
        }

        public int HighestAdvertisedGrade
        {
            get
            {
                return this._highestAdvertisedGrade;
            }
            set
            {
                this._highestAdvertisedGrade = value;
            }
        }

        public string JQName
        {
            get
            {
                return this._JQName;
            }
            set
            {
                this._JQName = value;
            }
        }

        public string JQPositionTitle
        {
            get
            {
                return this._JQPositionTitle;
            }
            set
            {
                this._JQPositionTitle = value;
            }
        }

        public bool IsStandardJQ
        {
            get
            {
                return this._isStandardJQ;
            }
            set
            {
                this._isStandardJQ = value;
            }
        }

        public int CreatedByID
        {
            get
            {
                return this._createdByID;
            }
            set
            {
                this._createdByID = value;
            }
        }

        public DateTime? CreateDate
        {
            get
            {
                return this._createDate;
            }
            set
            {
                this._createDate = value;
            }
        }

        public int UpdatedByID
        {
            get
            {
                return this._updatedByID;
            }
            set
            {
                this._updatedByID = value;
            }
        }

        public DateTime? UpdateDate
        {
            get
            {
                return this._updateDate;
            }
            set
            {
                this._updateDate = value;
            }
        }
        #endregion
    }
}

