using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.JNP;
using HCMS.Business.JNPTracker;
using HCMS.Business.Common;
namespace HCMS.JNP.Controls.Layout
{
    public partial class InformationPanel : JNPUserControlBase 
    {
        protected override void OnLoad(EventArgs e)
        {
            string information = string.Empty;
            if (base.CurrentJNPID > 0)
            {
                string space = "&nbsp;";
                string series = string.Format("{0} | {1}", CurrentJNP.SeriesID, CurrentJNP.SeriesName).Trim();
                string highestgrade = CurrentJNP.HighestAdvertisedGradeName;
                int lowestgrade = CurrentJNP.LowestAdvertisedGrade;
                string orgcode = CurrentJNP.OrganizationName;
                long copiedfromJNP = CurrentJNP.CopyFromJNPID;
                eJNPOptionType jnpTypeID = CurrentJNP.JNPOptionTypeID;
                enumJNPType jnpTypeId = CurrentJNP.JNPTypeID;

                information = "Series: " + series +
                              "    Grade: " + (jnpTypeId == enumJNPType.TwoGrade ? highestgrade + "/" + lowestgrade : highestgrade) +
                              (jnpTypeID == eJNPOptionType.CreateFromExisting ? "\nCopied From JAX ID: " + copiedfromJNP.ToString() : "");
                              //+ "<br/>" +                  
                              //"Current Status: " + EnumHelper<enumJNPWorkflowStatus>.GetEnumDescription(base.CurrentJNPWS.ToString()).ToString();
                space = Server.HtmlDecode(space);
                information = information.Replace(" ", space);

                this.literalInfo.Text = information;
            }
            base.OnLoad(e);
        }
    }
}