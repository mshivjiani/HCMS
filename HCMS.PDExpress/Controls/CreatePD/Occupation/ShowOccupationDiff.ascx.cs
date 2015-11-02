using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

using HCMS.Business.Lookups;
using HCMS.Business.Lookups.Collections;
using HCMS.Business.PD;
using HCMS.Business.PD.Collections;
using HCMS.Business.Series.Collections;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;

using Telerik.Web.UI;

namespace HCMS.PDExpress.Controls.CreatePD.Occupation
{
    public partial class ShowOccupationDiff : CreatePDUserControlBase
    {
        #region [ Page Event Handlers ]

        protected override void OnLoad(EventArgs e)
        {
            if (base.CurrentPDID == NULLPDID)
            {
                base.HandleException("Current Position Description is not set.");
            }
            else
            {
                if (!IsPostBack)
                {
                    SetPageView();
                }
            }
            base.OnLoad(e);
        }
        #endregion

        #region [ Private Methods ]

        private void SetPageView()
        {
            if (blnActionbuttons)
            {
                radComboActionTop.Visible = true;
                btnSaveTop.Visible = true;

            }
            else
            {
                radComboActionTop.Visible = false;
                btnSaveTop.Visible = false;
                litAccRej.Text = string.Empty;
            }
        }

        private void SaveChanges()
        {
            try
            {
                if (radComboActionTop.SelectedValue == "acceptall")
                {
                    base.CurrentPD.AcceptAllOccupationDiffs();
                }
                else if (radComboActionTop.SelectedValue == "rejectall")
                {
                    base.CurrentPD.RejectAllOccupationDiffs();
                }
                else
                {
                    DoSelectiveUpdate();
                }
                base.ReloadCurrentPD(CurrentPD.PositionDescriptionID);
                base.GoToPDLink("~/CreatePD/Occupation.aspx");
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void SetDDLVisibility()
        {
            bool blnvisible = blnActionbuttons;
            if (this.radlstviewOccChanges.Items.Count > 0)
            {
                Telerik.Web.UI.RadListViewDataItem currentitem = this.radlstviewOccChanges.Items[0];
                DropDownList ddlJobSeriesSel = currentitem.FindControl("ddlJobSeriesSel") as DropDownList;
                DropDownList ddlGradeSel = currentitem.FindControl("ddlGradeSel") as DropDownList;
                DropDownList ddlOPMJobTitleSel = currentitem.FindControl("ddlOPMJobTitleSel") as DropDownList;
                DropDownList ddlFWSPositionTitleSel = currentitem.FindControl("ddlFWSPositionTitleSel") as DropDownList;
                DropDownList ddlPositionTypeSel = currentitem.FindControl("ddlPositionTypeSel") as DropDownList;
                DropDownList ddlOrganizationCodeSel = currentitem.FindControl("ddlOrganizationCodeSel") as DropDownList;
                DropDownList ddlIsInterdisciplinarySel = currentitem.FindControl("ddlIsInterdisciplinarySel") as DropDownList;

                if (blnvisible)
                {
                    DataTable dt = this.CurrentPD.GetPositionDescriptionLogReviewEdits();

                    if (dt.Rows.Count > 0)
                    {
                        DataRow dr = dt.Rows[0];

                        if (string.Compare(dr["RJobSeries"].ToString(), dr["DJobSeries"].ToString()) == 0)
                        {

                            ddlJobSeriesSel.Visible = false;
                        }
                        else
                        {
                            ddlJobSeriesSel.Visible = blnvisible;
                        }
                        if ((string.Compare(dr["RProposedGrade"].ToString(), dr["DProposedGrade"].ToString()) == 0)
                            && (string.Compare(dr["RProposedFPGrade"].ToString(), dr["DProposedFPGrade"].ToString()) == 0))
                        {
                            ddlGradeSel.Visible = false;
                        }
                        else
                        {
                            ddlGradeSel.Visible = blnvisible;
                        }
                        if (string.Compare(dr["ROPMJobTitle"].ToString(), dr["DOPMJobTitle"].ToString()) == 0)
                        {
                            ddlOPMJobTitleSel.Visible = false;
                        }
                        else
                        {
                            ddlOPMJobTitleSel.Visible = blnvisible;
                        }

                        if (string.Compare(dr["RAgencyPositionTitle"].ToString(), dr["DAgencyPositionTitle"].ToString()) == 0)
                        {
                            ddlFWSPositionTitleSel.Visible = false;
                        }
                        else
                        {
                            ddlFWSPositionTitleSel.Visible = blnvisible;
                        }
                        if (string.Compare(dr["RPositionType"].ToString(), dr["DPositionType"].ToString()) == 0)
                        {
                            ddlPositionTypeSel.Visible = false;
                        }
                        else
                        {
                            ddlPositionTypeSel.Visible = blnvisible;
                        }
                        if (string.Compare(dr["ROrganizationCodeID"].ToString(), dr["DOrganizationCodeID"].ToString()) == 0)
                        {
                            ddlOrganizationCodeSel.Visible = false;
                        }
                        else
                        {
                            ddlOrganizationCodeSel.Visible = blnvisible;
                        }
                        string strDisInterDisc = (string.Compare(dr["DIsInterdisciplinaryPD"].ToString(), "True") == 0 ? "Yes" : "No");
                        string strRisInterDisc = (string.Compare(dr["RIsInterdisciplinaryPD"].ToString(), "True") == 0 ? "Yes" : "No");
                        string strisInterDisc = base.DiffCompareStrings(strRisInterDisc, strDisInterDisc);
                        if ((string.Compare(strRisInterDisc, strDisInterDisc) == 0)
                            && (string.Compare(dr["RAdditionalSeries"].ToString(), dr["DAdditionalSeries"].ToString()) == 0))
                        {
                            ddlIsInterdisciplinarySel.Visible = false;
                        }
                        else
                        {
                            ddlIsInterdisciplinarySel.Visible = blnvisible;
                        }
                    }
                }
                else
                {
                    ddlJobSeriesSel.Visible = blnvisible;
                    ddlGradeSel.Visible = blnvisible;
                    ddlOPMJobTitleSel.Visible = blnvisible;
                    ddlFWSPositionTitleSel.Visible = blnvisible;
                    ddlPositionTypeSel.Visible = blnvisible;
                    ddlOrganizationCodeSel.Visible = blnvisible;
                    ddlIsInterdisciplinarySel.Visible = blnvisible;
                }
            }
        }

        private void DoSelectiveUpdate()
        {
            DataTable dt = this.CurrentPD.GetPositionDescriptionLogReviewEdits();

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                string finalJobSeries = dr["RJobSeries"].ToString();
                string finalPPGrade = dr["RProposedGrade"].ToString();
                string finalFPGrade = dr["RProposedFPGrade"].ToString();
                string finalOPMJobTitle = dr["ROPMJobTitle"].ToString();
                string finalFWSPoisitionTitle = dr["RAgencyPositionTitle"].ToString();
                string finalPositionType = dr["RPositionTypeID"].ToString();
                string finalOrganizationCode = dr["ROrganizationCodeID"].ToString();
                string finalIsInterDisc = dr["RIsInterdisciplinaryPD"].ToString();
                string finaladditionalSeries = dr["RAdditionalSeries"].ToString();
                if (this.radlstviewOccChanges.Items.Count > 0)
                {
                    Telerik.Web.UI.RadListViewDataItem currentitem = this.radlstviewOccChanges.Items[0];
                    DropDownList ddlJobSeriesSel = currentitem.FindControl("ddlJobSeriesSel") as DropDownList;
                    DropDownList ddlGradeSel = currentitem.FindControl("ddlGradeSel") as DropDownList;
                    DropDownList ddlOPMJobTitleSel = currentitem.FindControl("ddlOPMJobTitleSel") as DropDownList;
                    DropDownList ddlFWSPositionTitleSel = currentitem.FindControl("ddlFWSPositionTitleSel") as DropDownList;
                    DropDownList ddlPositionTypeSel = currentitem.FindControl("ddlPositionTypeSel") as DropDownList;
                    DropDownList ddlOrganizationCodeSel = currentitem.FindControl("ddlOrganizationCodeSel") as DropDownList;
                    DropDownList ddlIsInterdisciplinarySel = currentitem.FindControl("ddlIsInterdisciplinarySel") as DropDownList;
                    if ((ddlJobSeriesSel != null) && (ddlJobSeriesSel.SelectedValue == "0"))
                    {
                        finalJobSeries = dr["DJobSeries"].ToString();
                    }
                    if ((ddlGradeSel != null) && (ddlGradeSel.SelectedValue == "0"))
                    {
                        finalPPGrade = dr["DProposedGrade"].ToString();
                        finalFPGrade = dr["DProposedFPGrade"].ToString();
                    }
                    if ((ddlOPMJobTitleSel != null) && (ddlOPMJobTitleSel.SelectedValue == "0"))
                    {
                        finalOPMJobTitle = dr["DOPMJobTitle"].ToString();
                    }
                    if ((ddlFWSPositionTitleSel != null) && (ddlFWSPositionTitleSel.SelectedValue == "0"))
                    {
                        finalFWSPoisitionTitle = dr["DAgencyPositionTitle"].ToString();
                    }
                    if ((ddlPositionTypeSel != null) && (ddlPositionTypeSel.SelectedValue == "0"))
                    {
                        finalPositionType = dr["DPositionTypeID"].ToString();
                    }
                    if ((ddlOrganizationCodeSel != null) && (ddlOrganizationCodeSel.SelectedValue == "0"))
                    {
                        finalOrganizationCode = dr["DOrganizationCodeID"].ToString();
                    }
                    if ((ddlIsInterdisciplinarySel != null) && (ddlIsInterdisciplinarySel.SelectedValue == "0"))
                    {
                        finalIsInterDisc = dr["DIsInterdisciplinaryPD"].ToString();
                        finaladditionalSeries = dr["DAdditionalSeries"].ToString();
                    }


                    CurrentPD.JobSeries = int.Parse(finalJobSeries);
                    CurrentPD.ProposedGrade = int.Parse(finalPPGrade);
                    CurrentPD.ProposedFPGrade = int.Parse(finalFPGrade);
                    CurrentPD.OPMJobTitle = finalOPMJobTitle;
                    CurrentPD.AgencyPositionTitle = finalFWSPoisitionTitle;
                    CurrentPD.PositionTypeID = int.Parse(finalPositionType);
                    CurrentPD.OrganizationCodeID = int.Parse(finalOrganizationCode);
                    CurrentPD.IsInterdisciplinaryPD = bool.Parse(finalIsInterDisc);
                    CurrentPD.AdditionalSeries = finaladditionalSeries;
                    CurrentPD.IsOccupationReviewComplete = true;
                    CurrentPD.SelectiveUpdateOccupationDiffs();

                }


            }
        }

        #endregion

        #region [ Page button event handlers ]

        protected void GoBack(object sender, EventArgs e)
        {
            if (CurrentPD.IsOccupationReviewComplete)
            {
                SafeRedirect(String.Format("~/CreatePD/Occupation.aspx{0}", Request.UrlReferrer.Query));

            }
            else
            {
                if (this.GoBackURL.IndexOf("Factors.aspx") > 0 || this.GoBackURL.IndexOf("PositionCharacteristics.aspx") > 0)
                {
                    if (base.CurrentGoBackPDID > 0)
                    {
                        base.ClearCurrentPD();
                        base.ReloadCurrentPD(base.CurrentGoBackPDID);
                    }
                    SafeRedirect(string.Format("{0}{1}", this.GoBackURL, this.GoBackURLQS));
                }
                else
                {
                    SafeRedirect(string.Format("{0}{1}", this.GoBackURL, this.GoBackURLQS));
                }
            }
        }

        protected void btnSaveBtm_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SaveChanges();
                }
                catch (Exception ex)
                {
                    if (ex is System.Threading.ThreadAbortException)
                    {
                        // there's nothing you can do. Even if you handle this exception - it will be raised again.
                    }
                    else
                    {
                        base.HandleException(ex);
                    }
                }
            }
        }

        protected void btnSaveTop_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    SaveChanges();
                }
                catch (Exception ex)
                {
                    if (ex is System.Threading.ThreadAbortException)
                    {
                        // there's nothing you can do. Even if you handle this exception - it will be raised again.
                    }
                    else
                    {
                        base.HandleException(ex);
                    }
                }
            }
        }


        #endregion

        #region [ radlstviewOccChanges Events ]

        protected void radlstviewOccChanges_NeedDataSource(object sender, RadListViewNeedDataSourceEventArgs e)
        {
            DataTable dt = this.CurrentPD.GetPositionDescriptionLogReviewEdits();
            this.radlstviewOccChanges.DataSource = dt;


        }

        protected void radlstviewOccChanges_ItemDataBound(object sender, RadListViewItemEventArgs e)
        {
            System.Data.DataRowView dr = (DataRowView)((Telerik.Web.UI.RadListViewDataItem)(e.Item)).DataItem;
            if (dr != null)
            {
                Label lbljs = e.Item.FindControl("lblJobSeries") as Label;
                lbljs.Text = base.DiffCompareStrings(dr["RJobSeries"].ToString(), dr["DJobSeries"].ToString());
                Label lblpGrade = e.Item.FindControl("lblProposedGrade") as Label;
                lblpGrade.Text = base.DiffCompareStrings(dr["RProposedGrade"].ToString(), dr["DProposedGrade"].ToString());
                Label lblfpGrade = e.Item.FindControl("lblFPGrade") as Label;
                lblfpGrade.Text = base.DiffCompareStrings(dr["RProposedFPGrade"].ToString(), dr["DProposedFPGrade"].ToString());
                Label lblopmJobTitle = e.Item.FindControl("lblOPMJobTitle") as Label;
                lblopmJobTitle.Text = base.DiffCompareStrings(dr["ROPMJobTitle"].ToString(), dr["DOPMJobTitle"].ToString());
                Label lblfwsTitle = e.Item.FindControl("lblFWSPositionTitle") as Label;
                lblfwsTitle.Text = base.DiffCompareStrings(dr["RAgencyPositionTitle"].ToString(), dr["DAgencyPositionTitle"].ToString());
                Label lblptype = e.Item.FindControl("lblPositionType") as Label;
                lblptype.Text = base.DiffCompareStrings(dr["RPositionType"].ToString(), dr["DPositionType"].ToString());
                Label lblOrgcode = e.Item.FindControl("lblOrganizationCode") as Label;

                string DOldOrganizationCode = "N/A";
                if (dr["DOldOrganizationCode"]!=null)
                {
                    DOldOrganizationCode = dr["DOldOrganizationCode"].ToString();
                }

                string ROldOrganizationCode = "N/A";
                if (dr["ROldOrganizationCode"] != null)
                {
                    ROldOrganizationCode = dr["ROldOrganizationCode"].ToString();
                }
                string DOrg = string.Format("{0} | {1}", DOldOrganizationCode, dr["DOrganizationCode"].ToString());
                string ROrg = string.Format("{0} | {1}", ROldOrganizationCode, dr["ROrganizationCode"].ToString());
                lblOrgcode.Text = base.DiffCompareStrings(ROrg,DOrg);

                Label lblisInterDisc = e.Item.FindControl("lblIsInterdisciplinary") as Label;

                string strDisInterDisc = (string.Compare(dr["DIsInterdisciplinaryPD"].ToString(), "True") == 0 ? "Yes" : "No");
                string strRisInterDisc = (string.Compare(dr["RIsInterdisciplinaryPD"].ToString(), "True") == 0 ? "Yes" : "No");
                string strisInterDisc = base.DiffCompareStrings(strRisInterDisc, strDisInterDisc);
                lblisInterDisc.Text = strisInterDisc;
                Label lbladditionalseries = e.Item.FindControl("lblAdditionalSeries") as Label;
                lbladditionalseries.Text = base.DiffCompareStrings(dr["RAdditionalSeries"].ToString(), dr["DAdditionalSeries"].ToString());



                DropDownList ddlJobSeriesSel = e.Item.FindControl("ddlJobSeriesSel") as DropDownList;
                DropDownList ddlGradeSel = e.Item.FindControl("ddlGradeSel") as DropDownList;
                DropDownList ddlOPMJobTitleSel = e.Item.FindControl("ddlOPMJobTitleSel") as DropDownList;
                DropDownList ddlFWSPositionTitleSel = e.Item.FindControl("ddlFWSPositionTitleSel") as DropDownList;
                DropDownList ddlPositionTypeSel = e.Item.FindControl("ddlPositionTypeSel") as DropDownList;
                DropDownList ddlOrganizationCodeSel = e.Item.FindControl("ddlOrganizationCodeSel") as DropDownList;
                DropDownList ddlIsInterdisciplinarySel = e.Item.FindControl("ddlIsInterdisciplinarySel") as DropDownList;

                bool blnvisible = blnActionbuttons;
                if (blnvisible)
                {
                    if (string.Compare(dr["RJobSeries"].ToString(), dr["DJobSeries"].ToString()) == 0)
                    {

                        ddlJobSeriesSel.Visible = false;
                    }
                    if ((string.Compare(dr["RProposedGrade"].ToString(), dr["DProposedGrade"].ToString()) == 0)
                        && (string.Compare(dr["RProposedFPGrade"].ToString(), dr["DProposedFPGrade"].ToString()) == 0))
                    {
                        ddlGradeSel.Visible = false;
                    }
                    if (string.Compare(dr["ROPMJobTitle"].ToString(), dr["DOPMJobTitle"].ToString()) == 0)
                    {
                        ddlOPMJobTitleSel.Visible = false;
                    }

                    if (string.Compare(dr["RAgencyPositionTitle"].ToString(), dr["DAgencyPositionTitle"].ToString()) == 0)
                    {
                        ddlFWSPositionTitleSel.Visible = false;
                    }
                    if (string.Compare(dr["RPositionType"].ToString(), dr["DPositionType"].ToString()) == 0)
                    {
                        ddlPositionTypeSel.Visible = false;
                    }
                    if (string.Compare(dr["ROrganizationCodeID"].ToString(), dr["DOrganizationCodeID"].ToString()) == 0)
                    {
                        ddlOrganizationCodeSel.Visible = false;
                    }
                    if ((string.Compare(strRisInterDisc, strDisInterDisc) == 0)
                        && (string.Compare(dr["RAdditionalSeries"].ToString(), dr["DAdditionalSeries"].ToString()) == 0))
                    {
                        ddlIsInterdisciplinarySel.Visible = false;
                    }

                }
                else
                {
                    ddlJobSeriesSel.Visible = blnvisible;
                    ddlGradeSel.Visible = blnvisible;
                    ddlOPMJobTitleSel.Visible = blnvisible;
                    ddlFWSPositionTitleSel.Visible = blnvisible;
                    ddlPositionTypeSel.Visible = blnvisible;
                    ddlOrganizationCodeSel.Visible = blnvisible;
                    ddlIsInterdisciplinarySel.Visible = blnvisible;
                }


            }

        }

        #endregion

        #region [ radComboActionTop Events ]
        protected void radComboActionTop_SelectedIndexChanged(object o, RadComboBoxSelectedIndexChangedEventArgs e)
        {

            Telerik.Web.UI.RadListViewDataItem currentitem = this.radlstviewOccChanges.Items[0];
            DropDownList ddlJobSeriesSel = currentitem.FindControl("ddlJobSeriesSel") as DropDownList;
            DropDownList ddlGradeSel = currentitem.FindControl("ddlGradeSel") as DropDownList;
            DropDownList ddlOPMJobTitleSel = currentitem.FindControl("ddlOPMJobTitleSel") as DropDownList;
            DropDownList ddlFWSPositionTitleSel = currentitem.FindControl("ddlFWSPositionTitleSel") as DropDownList;
            DropDownList ddlPositionTypeSel = currentitem.FindControl("ddlPositionTypeSel") as DropDownList;
            DropDownList ddlOrganizationCodeSel = currentitem.FindControl("ddlOrganizationCodeSel") as DropDownList;
            DropDownList ddlIsInterdisciplinarySel = currentitem.FindControl("ddlIsInterdisciplinarySel") as DropDownList;

            if ((e.Value == "rejectall") || (e.Value == "acceptall"))
            {
                ddlJobSeriesSel.Visible = false;
                ddlGradeSel.Visible = false;
                ddlOPMJobTitleSel.Visible = false;
                ddlFWSPositionTitleSel.Visible = false;
                ddlPositionTypeSel.Visible = false;
                ddlOrganizationCodeSel.Visible = false;
                ddlIsInterdisciplinarySel.Visible = false;
            }
            else
            {
                SetDDLVisibility();
            }

            bool blnenable = (e.Value == "select");
            ddlJobSeriesSel.Enabled = blnenable;
            ddlGradeSel.Enabled = blnenable;
            ddlOPMJobTitleSel.Enabled = blnenable;
            ddlFWSPositionTitleSel.Enabled = blnenable;
            ddlPositionTypeSel.Enabled = blnenable;
            ddlOrganizationCodeSel.Enabled = blnenable;
            ddlIsInterdisciplinarySel.Enabled = blnenable;

        }

        #endregion

        #region [Public Properties]

        public string GoBackURL
        {
            get
            {
                if (ViewState["GoBackURL"] == null)
                    ViewState["GoBackURL"] = Request.UrlReferrer;

                return (string)ViewState["GoBackURL"];
            }

            set { ViewState["GoBackURL"] = value; }
        }

        public string GoBackURLQS
        {
            get
            {
                if (ViewState["GoBackURLQS"] == null)
                    ViewState["GoBackURLQS"] = Request.UrlReferrer.Query;

                return (string)ViewState["GoBackURLQS"];
            }

            set { ViewState["GoBackURLQS"] = value; }
        }

        public bool blnActionbuttons
        {
            get
            {
                PDAccessType accessPD = base.CurrentPDAccessType;
                if ((accessPD == PDAccessType.Write) && (!CurrentPD.IsOccupationReviewComplete))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion
    }

}
