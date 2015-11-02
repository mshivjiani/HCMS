using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.Business.Common;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;

namespace HCMS.PDExpress.Controls.CreatePD
{
    public partial class CreatePDChoice : CreatePDUserControlBase
    {
        protected override void OnInit(EventArgs e)
        {
            this.btnContinue.Click += new EventHandler(btnContinue_Click);
            base.OnInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.ClearCurrentPD();
            base.OnLoad(e);
        }
        protected override void OnPreRender(EventArgs e)
        {
            rbCreateNewStandardPD.Enabled = base.HasPermission(enumPermission.CreateStandardPD);


            base.OnPreRender(e);
        }
        protected void btnContinue_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    PDChoiceType currentChoice = GetCurrentChoice();
                    base.CurrentPDChoice = currentChoice;

                    switch (currentChoice)
                    {
                        case PDChoiceType.FromExistingPD:
                            Response.Redirect("~/Search/SearchReports.aspx");
                            break;
                        case PDChoiceType.FromExistingStandardPD:
                            Response.Redirect("~/Search/SearchReports.aspx?StandardPDOnly=true");
                            break;
                        case PDChoiceType.StatementOfDifferencePD:
                            Response.Redirect("~/Search/SearchReports.aspx?SOD=true");
                            break;
                        case PDChoiceType.CareerLadderPD:
                            Response.Redirect(string.Format("{0}", IsNewCL ? "~/CreatePD/Occupation.aspx?type=cl" : "~/Search/SearchReports.aspx"));
                            break;
                        case PDChoiceType.NewPD:
                        case PDChoiceType.NewStandardPD:
                            Response.Redirect("~/CreatePD/Occupation.aspx");
                            break;
                    }
                }
                catch (Exception X)
                {
                    base.HandleException(X);
                }
            }
        }

        protected PDChoiceType GetCurrentChoice()
        {
            int choiceType = 1; // default choice

            if (rbCreateUsingExisting.Checked)
                choiceType = 1;
            else if (rbCreateUsingStandard.Checked)
                choiceType = 2;
            else if (rbCreateSOD.Checked)
                choiceType = 3;
            else if (rbCreateLadder.Checked)
            {
                choiceType = 4;
                IsNewCL = true;
            }
            else if (rbCreateUsingCL.Checked)
            {
                choiceType = 4;
                IsNewCL = false;
            }
            else if (rbCreateNewPD.Checked)
                choiceType = 5;
            else if (rbCreateNewStandardPD.Checked)
                choiceType = 6;
            else
                throw new Exception("Invalid PD Choice");

            PDChoiceType enmChoiceType = (PDChoiceType)choiceType;
            return enmChoiceType;
        }

        //Property to find out if the option selected is for New CL or Copy from existing
        private bool _isNewCL = false;
        private bool IsNewCL
        {
            get
            {
                return _isNewCL;
            }
            set
            {
                _isNewCL = value;
            }
        }
    }
}
