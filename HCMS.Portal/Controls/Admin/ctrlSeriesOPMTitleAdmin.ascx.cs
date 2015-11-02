using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.Site.Utilities;
using HCMS.Business.Series;
using Telerik.Web.UI;

namespace HCMS.Portal.Controls.Admin
{
    public partial class CtrlSeriesOPMTitleAdmin : System.Web.UI.UserControl
    {
        SeriesManager seriesMgr = new SeriesManager();

        private int CurrentSeriesID
        {
            get
            {

                if (ViewState["CurrentSeriesID"] == null)
                {

                    ViewState["CurrentSeriesID"] = -1;

                }
                return (int)ViewState["CurrentSeriesID"];

            }
            set
            {
                ViewState["CurrentSeriesID"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                InitSeries();
            }
        }

        private void InitSeries()
        {
            rcbSeries.Items.Clear();
            ControlUtility.BindRadComboBoxControl(this.rcbSeries, seriesMgr.GetAllSeries(), null, "DetailLine", "ID", "[-- Select Series --]");

            if (this.CurrentSeriesID != -1)
            {
                this.rcbSeries.SelectedValue = this.CurrentSeriesID.ToString();
            }
        }

        private void BindData()
        {
            if (this.CurrentSeriesID != 1)
            {
                gridOPMTitles.Rebind();
            }
        }

        protected void rcbSeries_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            this.CurrentSeriesID = int.Parse(e.Value);
            BindData();
        }

        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    //JQFactorEntity entity = new JQFactorEntity();
        //    //AssignValues(entity);

        //    //try
        //    //{
        //    //    if (base.CurrentJQID > 0)
        //    //    {
        //    //        if (CurrentMode == enumNavigationMode.Insert)
        //    //        {
        //    //            base.CurrentJQFactorID = JQFactorID = jqm.AddJobQuestionnaireFactor(entity);
        //    //            lblmsg.Text = "KSA added successfully.";
        //    //            CurrentMode = enumNavigationMode.Edit;
        //    //            BindData();
        //    //            this.ksaDetail.Visible = true;
        //    //        }
        //    //        else if (CurrentMode == enumNavigationMode.Edit)
        //    //        {
        //    //            jqm.UpdateJobQuestionnaireFactor(entity);
        //    //            lblmsg.Text = "KSA updated successfully.";
        //    //        }
        //    //    }

        //    //    else
        //    //    {
        //    //        base.PrintErrorMessage("Current Job Questionnaire is not set", false);
        //    //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    base.HandleException(ex);
        //    //}
        //}

        //protected void btnRefresh_Click(object sender, EventArgs e)
        //{
        //    BindData();
        //}

        #region [OPMTitles Related]
        protected void gridOPMTitles_NeedDataSource(object sender, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            this.gridOPMTitles.DataSource = null;
            this.gridOPMTitles.DataSource = seriesMgr.GetSeriesOPMTitlesBySeriesID(this.CurrentSeriesID);
        }

        protected void gridOPMTitles_ItemCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                    ShowOPMTitle(sender, e);
                    break;
                case RadGrid.EditCommandName:
                    //ShowOPMTitle(sender, e);
                    break;
                case RadGrid.DeleteCommandName:
                    //DeleteOPMTitle(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void ShowOPMTitle(object source, GridCommandEventArgs e)
        {
            RWM.Windows.Clear();
            GridDataItem gridItem;
            string script = string.Empty;

            string navigateurl = string.Empty;
            lblmsg.Text = string.Empty;
            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                    e.Canceled = true;
                    script = string.Format("ShowSeriesOPMTitleWindowClient('{0}','{1}');", "Insert", this.CurrentSeriesID);
                    break;
                case RadGrid.EditCommandName:
                    e.Canceled = true;
                    gridItem = e.Item as GridDataItem;
                    //int seriesID = int.Parse(gridItem.GetDataKeyValue("SeriesID").ToString());
                    //script = string.Format("ShowSeriesOPMTitleWindowClient('{0}','{1}');", "Edit", seriesID);
                    break;
                default:
                    break;

            }

            RWM.Windows.Add(rwQ);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowSeriesOPMTitleWindowClient", script, true);
        }
        #endregion
    }
}