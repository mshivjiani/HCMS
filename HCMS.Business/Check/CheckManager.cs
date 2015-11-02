using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Base;

namespace HCMS.Business.Check
{
    public class CheckManager : BusinessBase
    {
        public static long Check(long CheckStaffingObjectID, enumStaffingObjectType staffingObjectType, enumActionType actionType, int CheckUserID, DateTime CheckDate)
        {
            long checkID = -1;

            try
            {
                int CheckStaffingObjectTypeID = (int)staffingObjectType;
                int CheckActionTypeID = (int)actionType;

                checkID = (long)ExecuteScalar("spr_JNPCheck", CheckStaffingObjectID, CheckStaffingObjectTypeID, CheckActionTypeID, CheckUserID, CheckDate);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return checkID;
        }
    }
}
