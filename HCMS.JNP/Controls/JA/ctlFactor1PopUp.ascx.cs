using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.PD;

namespace HCMS.JNP.Controls.JA
{
    public partial class ctlFactor1PopUp : JNPUserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string firstFactor = PositionDescription.GetFirstPositionFactorLanguage(base.CurrentJNPID);

            FactorOneText.Text = firstFactor;

            FactorOneText.ReadOnly = true;

        }
    }
}