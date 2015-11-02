using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.JA;

namespace HCMS.JNP.Controls.JA
{
    public partial class ctrlDutyDescription : JNPUserControlBase
    {
        public long JADutyID
        {
            get
            {
                if (ViewState["JADutyID"] == null)
                {
                    if (Request.QueryString["JADutyID"] != null)
                    {
                        ViewState["JADutyID"] = Convert.ToInt32(Request.QueryString["JADutyID"]);
                    }
                    else
                    {
                        ViewState["JADutyID"] = -1;
                    }
                }
                return Convert.ToInt64(ViewState["JADutyID"]);
            }
            set
            {
                ViewState["JADutyID"] = value;
            }
        }

        public long DutyNumber
        {
            get
            {
                if (ViewState["DutyNumber"] == null)
                {
                    if (Request.QueryString["DutyNumber"] != null)
                    {
                        ViewState["DutyNumber"] = Convert.ToInt32(Request.QueryString["DutyNumber"]);
                    }
                    else
                    {
                        ViewState["DutyNumber"] = -1;
                    }
                }
                return Convert.ToInt64(ViewState["DutyNumber"]);
            }
            set
            {
                ViewState["DutyNumber"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (JADutyID > 0)
            {
                JobAnalysisDuty jaDuty = new JobAnalysisDuty(JADutyID);
                this.lblDutyNumber.Text = "Duty " + DutyNumber;
                txtDutyDescription.Text = jaDuty.JADutyDescription;
            }


        }

        public void LoadData(long jaDutyID, long dutyNumber)
        {
            this.JADutyID = jaDutyID;
            this.DutyNumber = dutyNumber;
        }


    }
}