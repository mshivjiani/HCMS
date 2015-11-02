using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.WebFramework.BaseControls;
using HCMS.Business.PD.Collections;
using HCMS.Business.PD;

namespace HCMS.PDExpress.Controls.CreatePD
{
    public partial class CareerLadderErrors : UserControlBase
    {
        //QueryString Parameter
        private long PDIDQS
        {
            get
            {
                long positionDescriptionID = -1;

                if (String.IsNullOrEmpty(Page.Request.QueryString["PDID"]) == false)
                {
                    positionDescriptionID = int.Parse(Page.Request.QueryString["PDID"]);
                }

                return positionDescriptionID;
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadErrors();
        }

        private void LoadErrors()
        {
            try
            {
                if (this.PDIDQS != -1)
                {
                    PositionDescription currentPD = new PositionDescription(this.PDIDQS);
                    //Pass True for Validate For Factor Screen to skip signatures for FPL PD.
                    PDValidationErrorCollection errorList = currentPD.GetValidationErrors(false, true);

                    gridViewErrors.DataSource = errorList;
                    gridViewErrors.DataBind();
                }
            }
            catch (Exception x)
            {
                base.HandleException(x);
            }
        }
    }
}
