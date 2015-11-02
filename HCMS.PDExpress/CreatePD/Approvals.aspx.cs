using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BasePages;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;
namespace HCMS.PDExpress.CreatePD
{
    public partial class Approvals : CreatePDPageBase
    {
        protected override void OnLoad(EventArgs e)
    // JA issue ID 824: modified: to check if HR user has complete JNP Certification permissiion then only send them to approval otherwise save and unlock -
                //This was to fix the error - staffing manager/staffing specialist was  having -- 
                //added conditon -completeJNPCertification to the list to allow user to access approval page
                //this is to support Staffing Specialist/Staffing Manager Role to allow them to sign as evaluator
              
        {if(base.isPDCreatorSupervisor(false) || base.HasPermission (enumPermission.CompleteSupervisoryCertification)||base.HasPermission (enumPermission.CompleteHRCertification )||base.HasPermission(enumPermission.CompleteJNPCertification))
        {
            
            base.OnLoad(e);
        }
        else
        {                 
                base.GoToAccessDeniedPage();
        }
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.PDControlName = PDControlType.Approvals;
            base.ShowRequiredFieldMessage = true;
            base.OnPreRender(e);
        }
    }
}
