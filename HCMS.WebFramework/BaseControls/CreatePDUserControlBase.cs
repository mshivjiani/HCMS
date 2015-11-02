using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Threading;

using System.Security;
using System.Web.Security;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

using HCMS.Business.Security;
using HCMS.WebFramework.Site.Utilities;

using HCMS.Business.PD;
using HCMS.Business.PD.Collections;

using HCMS.Business.Lookups;

namespace HCMS.WebFramework.BaseControls
{
    public class CreatePDUserControlBase : UserControlBase
    {
        #region Methods

        public PDStatus GetNextPDStatus()
        {
            PDStatus nextPDStatus = PDStatus.Null;

            switch ((PDStatus)base.CurrentPDWorkflowStatus.WorkflowStatusID)
            {
                case PDStatus.Draft:
                    nextPDStatus = PDStatus.Review;
                    break;
                case PDStatus.Review:
                    nextPDStatus = PDStatus.Revise;
                    break;
                case PDStatus.Revise:
                    nextPDStatus = PDStatus.FinalReview;
                    break;
                case PDStatus.FinalReview:
                    nextPDStatus = PDStatus.Published;
                    break;
            }

            return nextPDStatus;
        }
        protected string GetValidationErros(ref bool hasErrors)
        {
            StringBuilder finalError = new StringBuilder();
            PDValidationErrorCollection errorList = new PDValidationErrorCollection();
            bool validateforfactorscreen = true;
            errorList = CurrentPD.GetValidationErrors(false, validateforfactorscreen);
            hasErrors = (errorList.Count > 0);
            if (hasErrors)
            {
                finalError = finalError.AppendFormat("The position description you are currently editing has the following outstanding actions:<br/><br/>");
                foreach (PDValidationError item in errorList)
                {
                    finalError.AppendFormat("<li><b>{0}</b></li><br />", item.ErrorMessage);

                }
            }
            return finalError.ToString();
        }
        protected string GetCareerLadderErrors(ref bool hasCareerLadderErrors)
        {
            StringBuilder finalError = new StringBuilder();
            StringBuilder clError = new StringBuilder();
            bool foundError = false;

            try
            {
                PositionDescriptionCollection ladders = base.CurrentPD.GetOtherCareerLadderPositionDescriptions();
                ladders = ladders.GetOtherLadderPDs(base.CurrentPDID);

                foreach (PositionDescription current in ladders)
                {
                    // validate each PD and get a high-level count of each
                    bool validateforfactorscreen = true;
                    PDValidationErrorCollection errorList = current.GetValidationErrors(false, validateforfactorscreen);

                    if (errorList.Count > 0)
                    {
                        foundError = true;
                        clError = clError.AppendFormat("<p>{0} Action(s) for Position Description : {1}<br /></p>", errorList.Count, current.PositionDescriptionID);
                        foreach (PDValidationError item in errorList)
                        {
                            clError = clError.AppendFormat("<li><b>{0}</b></li><br />", item.ErrorMessage);
                        }
                    }
                }

                if (foundError)
                {
                    string errorMessage = string.Format("<p>The following Position Description(s) have outstanding actions.<br /><br /></p>");
                    string editMessage = string.Format("<p>Click the <b>Edit</b> button next to the Associated CLPD table of the PD you want to edit.<br /></p>");
                    finalError.AppendFormat("{0}{1}<br />{2}<br />", errorMessage, clError, editMessage);

                }
                hasCareerLadderErrors = foundError;
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }

            return finalError.ToString();
        }
        public string ValidatePD(bool fastTrackToPublish)
        {
            return base.CurrentPD.Validate(fastTrackToPublish);
        }

        #endregion

        #region [ Check in / check out ]
        public bool CanCheckOut(long positionDescriptionID)
        {
            bool canCheckOut = false;

            try
            {
                PositionDescription thisPD = new PositionDescription(positionDescriptionID);
                PDAccessType access = base.GetPDAccessType(thisPD);

                PDStatus currentWFStatus = thisPD.GetCurrentPDStatus();
                //check if you can check out only when PDAccessType is not read-only - otherwise you can not check out.
                if (access != PDAccessType.ReadOnly)
                {

                    switch (currentWFStatus)
                    {
                        case PDStatus.Draft:
                        case PDStatus.Revise:
                            canCheckOut = true;
                            break;
                        case PDStatus.Review:
                        case PDStatus.FinalReview:
                            canCheckOut = base.HasPermission(enumPermission.CompleteHRCertification);
                            break;
                        default:
                            canCheckOut = false; //modified this from true to false as we don't know the status and so should not allow to checkout
                            break;

                    }

                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }

            return canCheckOut;
        }

        public bool CanContinueEdit(int checkedOutByID)
        {
            bool canContinueEdit = false;

            try
            {
                if (checkedOutByID == CurrentUser.UserID)
                {
                    canContinueEdit = true;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }

            return canContinueEdit;
        }

        public bool CanCheckIn(int checkedOutByID)
        {
            bool canCheckIn = false;

            try
            {
                if (base.HasPermission(enumPermission.CompleteHRCertification) ||
                    base.HasPermission(enumPermission.CompleteHRCertification15) ||
                    base.HasPermission(enumPermission.MaintainEvaluationStatements) ||
                    checkedOutByID == base.CurrentUser.UserID)
                {
                    canCheckIn = true;
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }

            return canCheckIn;
        }

        public void CheckOutPositionDescription(long positionDescriptionID, int checkedOutByID)
        {
            try
            {
                PositionDescription pd = new PositionDescription(positionDescriptionID);
                pd.CheckOut(checkedOutByID);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        public void CheckInPositionDescription(long positionDescriptionID, int checkedInByID)
        {
            try
            {
                PositionDescription pd = new PositionDescription(positionDescriptionID);
                pd.CheckIn(checkedInByID);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        #endregion
    }

}
