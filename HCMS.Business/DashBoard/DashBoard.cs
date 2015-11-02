using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Xml.Serialization;
using System.IO;

using HCMS.Business.Base;
using HCMS.Business.Common;
using HCMS.Business.DashBoard.Collections;

namespace HCMS.Business.DashBoard
{
    ///<summary>
    ///DashBoard Business Object
    /// </summary>
    [Serializable]
    public class DashBoard : BusinessBase
    {
        #region [ Constructors ]
        //public DashBoard()
        //{ 
        //}

        ///// <summary>
        ///// This constructor loads dash board for 
        ///// logged in user based on user role 
        ///// and organization code that user 
        ///// is assigned to.
        ///// </summary>
        ///// <param name="userID"></param>
        //public DashBoard(int userID)
        //{
        //    DataTable returnTable;

        //    try
        //    {
        //        returnTable = ExecuteDataTable("spr_GetUserPositionDescriptionCurrentStatusInfo", userID);
        //        loadData(returnTable);
        //    }
        //    catch (Exception ex)
        //    {
        //        HandleException(ex);
        //    }
        //}
        private DashBoard(DataRow singleRowData)
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
        //public DashBoard(DataTable returnTable)
        //{
        //    loadData(returnTable);
        //}
        #endregion

        #region [ Constructor Helper Methods ]
        
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
            this._positionDescriptionID = (long)returnRow["PositionDescriptionID"];
            if (returnRow["AssociatedFullPD"] != DBNull.Value)
                this._associatedFullPD = (long)returnRow["AssociatedFullPD"];
            this._isStandardPD = returnRow["IsStandardPD"].ToString();
            this._positionDescriptionTypeID = (int)returnRow["PositionDescriptionTypeID"];
            this._positionDescriptionType = returnRow["PositionDescriptionType"].ToString();

            this._pdCreatorID = (int)returnRow["PDCreatorID"];
            this._createDate = (DateTime)returnRow["CreateDate"];
            this._createdBy = returnRow["CreatedBy"].ToString();

            this._createdRoleID = (int)returnRow["PDCreatorRoleID"];
            this._createdRoleName = returnRow["PDCreatorRoleName"].ToString();

            this._updatedByID = (int)returnRow["UpdatedByID"];
            this._updateDate = (DateTime)returnRow["UpdateDate"];
            this._updatedBy = returnRow["UpdatedBy"].ToString();

            // "UpdatedRoleID" does not exist in RowSet
            //this._updatedRoleID = (int)returnRow["UpdatedRoleID"];
            this._updatedRoleName = returnRow["UpdatedByRoleName"].ToString();

            this._workflowStatusID = (int)returnRow["WorkflowStatusID"];
            this._isCurrent = (bool)returnRow["IsCurrent"];
            this._workflowStatus = returnRow["WorkflowStatus"].ToString();
            this._workflowStatusDescription = returnRow["WorkflowStatusDescription"].ToString();

            this._scheduleStatusID = (int)returnRow["ScheduleStatusID"];

            this._agencyPositionTitle = returnRow["AgencyPositionTitle"].ToString();

            if (returnRow["OrganizationCodeID"] != DBNull.Value)
                this._organizationCodeID = (int)returnRow["OrganizationCodeID"];
            if (returnRow["OrganizationCode"] != DBNull.Value)
                this._organizationCode = returnRow["OrganizationCode"].ToString();
            if (returnRow["OldOrganizationCode"] != DBNull.Value)
                this._oldOrganizationCode = returnRow["OldOrganizationCode"].ToString();
            if (returnRow["OrganizationName"] != DBNull.Value)
                this._organizationName = returnRow["OrganizationName"].ToString();

            if (returnRow["RegionID"] != DBNull.Value)
                this._regionID = (int)returnRow["RegionID"];
            if (returnRow["Region"] != DBNull.Value)
                this._regionName = returnRow["Region"].ToString();

            if (returnRow["CheckedOutByID"] != DBNull.Value)
                this._checkedOutByID = (int)returnRow["CheckedOutByID"];
            if (returnRow["CheckOutDate"] != DBNull.Value)
                this._checkOutDate = (DateTime)returnRow["CheckOutDate"];
            if (returnRow["CheckedOutBy"] != DBNull.Value)
                this._checkedOutBy = returnRow["CheckedOutBy"].ToString();

            if (returnRow["CheckedInByID"] != DBNull.Value)
                this._checkedInByID = (int)returnRow["CheckedInByID"];
            if (returnRow["CheckInDate"] != DBNull.Value)
                this._checkInDate = (DateTime)returnRow["CheckInDate"];
            if (returnRow["CheckedInBy"] != DBNull.Value)
                this._checkedInBy = returnRow["CheckedInBy"].ToString();

            _positionDescriptionWorkflowNoteCount = (int)returnRow["PositionDescriptionWorkflowNoteCount"];
            if (returnRow["NextStatusInfo"] != DBNull.Value)
                this._nextStatusInfo = returnRow["NextStatusInfo"].ToString();

            //added PDCreateDate
            this._pdCreateDate = (DateTime)returnRow["PDCreateDate"];
            this._proposedFPGrade = (int)returnRow["ProposedFPGrade"];
            this._proposedGrade = (int)returnRow["ProposedGrade"];
            this._jobseries = (int)returnRow["JobSeries"];
            this._payPlanID = (int)returnRow["PayPlanID"];
            this._payPlanAbbrev = returnRow["PayPlanAbbrev"].ToString();

        }
        #endregion

        #region [ Collection Helper Methods ]

        public static DashboardCollection GetDashBoardPDs(int userID)
        {
            DashboardCollection childDataCollection = null;
            try
            {
                DataTable dataItems = new DataTable();
                dataItems = ExecuteDataTable("spr_GetUserPositionDescriptionCurrentStatusInfo", userID);

                // fill collection list
                childDataCollection = DashBoard.GetCollection(dataItems);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return childDataCollection;
        }

        private static DashboardCollection GetCollection(DataTable dataItems)
        {
            DashboardCollection listCollection = new DashboardCollection();

            try
            {
                DashBoard current = null;

                if (dataItems != null)
                {
                    for (int i = 0; i < dataItems.Rows.Count; i++)
                    {
                        current = new DashBoard(dataItems.Rows[i]);
                        listCollection.Add(current);
                    }
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return listCollection;

        }
        #endregion

        #region [ ToXML Method ]
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

        #region [ Public Properties ]

        public long PositionDescriptionID
        {
            get { return this._positionDescriptionID; }
            set { this._positionDescriptionID = value; }
        }

        public long AssociatedFullPD
        {
            get { return this._associatedFullPD; }
            set { this._associatedFullPD = value; }
        }

        public string PositionDescriptionIDValue
        {
            get
            {
                string displayValue = PositionDescriptionID.ToString();

                // 3 == SOD, 4 = Ladder
                //commented if condition because function now returns postiondescriptiontype as interdisciplinary
                // if (PositionDescriptionTypeID == 3 || PositionDescriptionTypeID == 4)
                // {
                if (!String.IsNullOrEmpty(PositionDescriptionType))
                {
                    displayValue += String.Format("<br/>[{0}]</span>", PositionDescriptionType);
                }
                //}

                return displayValue;
            }
        }

        public string IsStandardPD
        {
            get { return this._isStandardPD; }
            set { this._isStandardPD = value; }
        }

        public int PositionDescriptionTypeID
        {
            get { return this._positionDescriptionTypeID; }
        }

        private string PositionDescriptionType
        {
            get { return this._positionDescriptionType; }
        }

        public int PDCreatorID
        {
            get { return this._pdCreatorID; }
            set { this._pdCreatorID = value; }
        }
        /// <summary>
        /// This date refers to workflow create date and not pdcreate date
        /// </summary>

        public DateTime CreateDate
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
        public string CreatedBy
        {
            get { return this._createdBy; }
            set { this._createdBy = value; }
        }

        public int CreatedByRoleID
        {
            get
            {
                return this._createdRoleID;
            }
            set
            {
                this._createdRoleID = value;
            }
        }
        public string CreatedRoleName
        {
            get { return this._createdRoleName; }
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
        public DateTime UpdateDate
        {
            get { return this._updateDate; }
            set { this._updateDate = value; }
        }
        public string UpdatedBy
        {
            get
            {
                return this._updatedBy;
            }
            set
            {
                this._updatedBy = value;
            }
        }

        //public int UpdatedByRoleID
        //{
        //    get { return this._updatedRoleID; }
        //    set { this._updatedRoleID = value; }
        //}
        public string UpdatedRoleName
        {
            get { return this._updatedRoleName; }
        }

        public int WorkflowStatusID
        {
            get { return this._workflowStatusID; }
        }
        public bool IsCurrent
        {
            get { return this._isCurrent; }
        }
        public string WorkflowStatus
        {
            get { return this._workflowStatus; }
        }
        public string WorkflowStatusDescription
        {
            get { return this._workflowStatusDescription; }
        }

        public int ScheduleStatusID
        {
            get { return this._scheduleStatusID; }
        }
        public string ScheduleStatus
        {
            get
            {
                string scheduleStatus = String.Empty;

                if (ScheduleStatusID == 0)
                    scheduleStatus = "On Track";
                else if (ScheduleStatusID == 1)
                    scheduleStatus = "Warning";
                else if (ScheduleStatusID == 2)
                    scheduleStatus = "Escalated";
                else
                    scheduleStatus = "Inactive";

                return scheduleStatus;
            }
        }
        //public string ScheduleStatusIconURL
        //{
        //    get
        //    {
        //        string url = string.Empty;

        //        if ((enumScheduleStatus)ScheduleStatusID == enumScheduleStatus.OnTrack)
        //            url = string.Format ("~/App_Themes/{0}/Images/Icons/icon_ontrack.gif",Page.Theme);
        //        else if ((enumScheduleStatus)ScheduleStatusID == enumScheduleStatus.Warning)
        //            url = "~/App_Themes/PDExpress/Images/Icons/icon_warning.gif";
        //        else if ((enumScheduleStatus)ScheduleStatusID == enumScheduleStatus.Escalated)
        //            url = "~/App_Themes/PDExpress/Images/Icons/icon_escalated.gif";
        //        else if ((enumScheduleStatus)ScheduleStatusID == enumScheduleStatus.Inactive)
        //            url = "~/App_Themes/PDExpress/Images/Icons/icon_Inactive.gif";

        //        return url;
        //    }
        //}

        public string AgencyPositionTitle
        {
            get { return this._agencyPositionTitle; }
            set { this._agencyPositionTitle = value; }
        }

        public string OrganizationCode
        {
            get
            {
                return this._organizationCode;
            }
            set
            {
                this._organizationCode = value;
            }
        }

        public string OrganizationCodeLegacy
        {
            get
            {
                return string.Format("{0} ({1})", this._organizationCode, this._oldOrganizationCode);
            }
        }

        public int OrganizationCodeID
        {
            get
            {
                return this._organizationCodeID;
            }
            set
            {
                this._organizationCodeID = value;
            }
        }
        
        public string OrganizationCodeDisp
        {
            get
            {
                string orgCode = String.Empty;

                if (OrganizationCode.Length > 0)
                {
                    orgCode = OrganizationCode.ToString();
                }

                return orgCode;
            }
        }

        public string OrganizationName
        {
            get
            {
                return this._organizationName;
            }
            set
            {
                this._organizationName = value;
            }
        }

        public int RegionID
        {
            get
            {
                return this._regionID;
            }
            set
            {
                this._regionID = value;
            }
        }
        public string RegionName
        {
            get
            {
                return this._regionName;
            }
            set
            {
                this._regionName = value;
            }
        }

        public int CheckedOutByID
        {
            get { return _checkedOutByID; }
            set { _checkedOutByID = value; }
        }
        public DateTime CheckOutDate
        {
            get { return _checkOutDate; }
            set { _checkOutDate = value; }
        }
        public string CheckedOutBy
        {
            get { return _checkedOutBy; }
            set { _checkedOutBy = value; }
        }

        public int CheckedInByID
        {
            get { return _checkedInByID; }
            set { _checkedInByID = value; }
        }
        public DateTime CheckInDate
        {
            get { return _checkInDate; }
            set { _checkInDate = value; }
        }
        public string CheckedInBy
        {
            get { return _checkedInBy; }
            set { _checkedInBy = value; }
        }
        public int PositionDescriptionWorkflowNoteCount
        {
            get { return _positionDescriptionWorkflowNoteCount; }
            set { _positionDescriptionWorkflowNoteCount = value; }
        }


        public bool IsCheckedOut
        {
            get { return CheckedOutByID != -1; }
        }

        public string NextStatusInfo
        {
            get { return this._nextStatusInfo; }

        }

        public DateTime PDCreateDate
        {
            get { return this._pdCreateDate; }

        }

        public int JobSeries
        {
            get { return this._jobseries; }
        }
        public int ProposedGrade
        {
            get { return this._proposedGrade; }
        }

        public int ProposedFPGrade
        {
            get { return this._proposedFPGrade; }
        }
        public string PaddedSeries
        {
            get
            {
                string seriesWorkPad = string.Format("0000{0}", this._jobseries);
                this._paddedSeries = seriesWorkPad.Substring(seriesWorkPad.Length - 4);
                return this._paddedSeries;
            }
        }
        public int PayPlanID
        {
            get
            {
                return this._payPlanID;
            }
        }
        public string PayPlanAbbrev
        {
            get
            {
                return this._payPlanAbbrev;
            }

        }

        #endregion

        #region [ Private Members ]

        private long _positionDescriptionID = -1;
        private long _associatedFullPD = -1;
        private string _isStandardPD = string.Empty;
        private int _positionDescriptionTypeID = -1;
        private string _positionDescriptionType = String.Empty;

        private int _pdCreatorID = -1;
        //this date refers to workflow create date and not pdcreate date
        private DateTime _createDate = DateTime.MaxValue;
        private string _createdBy = string.Empty;

        private int _createdRoleID = -1;
        private string _createdRoleName = string.Empty;

        private int _updatedByID = -1;
        private DateTime _updateDate = DateTime.MaxValue;
        private string _updatedBy = string.Empty;

        //private int _updatedRoleID = -1; // [add property and] read from recordset
        private string _updatedRoleName = string.Empty;

        private int _workflowStatusID = -1;
        private bool _isCurrent = false;
        private string _workflowStatus = string.Empty;
        private string _workflowStatusDescription = string.Empty;

        private int _scheduleStatusID = -1;

        private string _agencyPositionTitle = string.Empty;

        private int _organizationCodeID = -1;
        private string _organizationCode = string.Empty;
        private string _oldOrganizationCode = "N/A";
        private string _organizationName = string.Empty;

        private int _regionID = -1;
        private string _regionName = string.Empty;

        private int _checkedOutByID = -1;
        private DateTime _checkOutDate = DateTime.MinValue;
        private string _checkedOutBy = String.Empty;

        private int _checkedInByID = -1;
        private DateTime _checkInDate = DateTime.MinValue;
        private string _checkedInBy = String.Empty;

        private int _positionDescriptionWorkflowNoteCount = 0;
        private string _nextStatusInfo = string.Empty;
        private DateTime _pdCreateDate = DateTime.MinValue;
        private int _jobseries = -1;
        private int _proposedGrade = -1;
        private int _proposedFPGrade = -1;
        private string _paddedSeries = string.Empty;
        private int _payPlanID = -1;
        private string _payPlanAbbrev = string.Empty;

        #endregion
    }
}
