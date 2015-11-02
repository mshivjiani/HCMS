using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.JNP;

namespace HCMS.JNP.Controls.Package
{
    public partial class ctrlJNPUpdateHiringResult : JNPUserControlBase
    {
       
        private long JNPID
        {
            get
            {
                long id = -1;

                if (Page.Request.QueryString["JNPID"] != null)
                {
                    id = long.Parse(Page.Request.QueryString["JNPID"]);
                }

                return id;
            }
        }

        private string _vacancyID = string.Empty;
        private bool _isSuccessfulHiring = false;

        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (JNPID > 0)
                this.lblJNPIDValue.Text = JNPID.ToString();

            if (!IsPostBack)
            {
                lblmsg.Text = "";
                GetJNPHiringInformation();
                SetPageView();
            }
        }

        private void SetPageView()
        {
            if (_isSuccessfulHiring == false || _vacancyID == "")
            {
                btnUpdateHiringResult.Visible = true;
                dropWasSuccessfulHiring.Enabled = true;
                txtVacancyID.Enabled = true;
            }
            else
            {
                dropWasSuccessfulHiring.Enabled = false;
                txtVacancyID.Enabled = false;
                btnUpdateHiringResult.Visible = false;
            }
        }

        private void GetJNPHiringInformation() 
        {
            JNPackage thisPackage = new JNPackage(this.JNPID);
            _isSuccessfulHiring = thisPackage.ResultedInSuccessfulHiring;
            _vacancyID = thisPackage.VacancyID;

            dropWasSuccessfulHiring.SelectedValue = _isSuccessfulHiring.ToString();
            txtVacancyID.Text = _vacancyID;
            
        }

        protected void btnUpdateHiringResult_Click(object sender, EventArgs e)
        {           
            bool isSuccess = UpdateHiringResult();
         
            if (isSuccess)
            {                   
                lblmsg.Text = "Hiring Result updated successfully.";
            }
            else 
            {
                lblmsg.Text = "Hiring Result could not be updated.";
            }

            GetJNPHiringInformation();
            SetPageView();

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string script = string.Empty;
            script = string.Format("UpdateHiringResultClose();");
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
        }

        private bool UpdateHiringResult()
        {
            bool isSuccessful = false;
            try
            {
                JNPackage thisPackage = new JNPackage(base.CurrentJNPID);

                thisPackage.ResultedInSuccessfulHiring = Convert.ToBoolean(dropWasSuccessfulHiring.SelectedValue);
                thisPackage.VacancyID = txtVacancyID.Text;

                thisPackage.Update();                 
                isSuccessful = true;
            }
            catch 
            {
               
                isSuccessful = false;
            }

            return isSuccessful;
        }
    }
}