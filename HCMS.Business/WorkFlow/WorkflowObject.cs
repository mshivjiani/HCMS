using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using HCMS.Business.Common ;
namespace HCMS.Business.PD
{
    [Serializable]
    public class WorkflowObject
    {
        #region Private Properties
        private long _staffingObjectID =-1;
        private enumStaffingObjectType _staffingObjectTypeID = enumStaffingObjectType.Unknown;
        private int _userid = -1;
        private long _parentObjectID = -1;
        private enumStaffingObjectType _parentObjectTypeID = enumStaffingObjectType.Unknown;
        private enumActionType _actionTypeID = enumActionType.Unknown;
        private DateTime _actionDate = DateTime.MinValue;
        
        #endregion

        #region Public Properties
        public long StaffingObjectID
        { get { return _staffingObjectID; } set { _staffingObjectID = value; } }
        public enumStaffingObjectType StaffingObjectTypeID
        { get { return _staffingObjectTypeID; } set { _staffingObjectTypeID = value; } }
        public int UserID
        { get { return _userid; } set { _userid = value; } }
        public long ParentObjectID
        { get { return _parentObjectID; } set { _parentObjectID = value; } }
        public enumStaffingObjectType ParentObjetTypeID
        { get { return _parentObjectTypeID; } set { _parentObjectTypeID = value; } }
        public enumActionType ActionTypeID
        { get { return _actionTypeID; } set { _actionTypeID = value; } }
        public DateTime ActionDate
        { get { return _actionDate; } set { _actionDate = value; } }

        #endregion
    }
}
