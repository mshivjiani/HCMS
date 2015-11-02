using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using HCMS.Business.Admin;
using HCMS.Business.Lookups;
using HCMS.Business.Lookups.Collections;
using System.Data;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Utilities;

namespace HCMS.Portal.Controls.Admin
{
    public partial class KSATaskStatementMaintenance : UserControlBase
    {
        #region Properties

        private enumNavigationMode _navMode;

        public enumNavigationMode CurrentNavigationMode
        {
            get { return _navMode; }
            set { this._navMode = value; }

        }

        private List<long> lstSelectedTaskstatementsToDelete = new List<long>();

        private int GetGradeID()
        {
            if (!String.IsNullOrEmpty(rcbGrades.SelectedValue))
                return Convert.ToInt32(rcbGrades.SelectedValue);
            else
                return -1;
        }

        private long _ksaId;

        public long KSAID
        {
            get
            {
                if (ViewState["KSAID"] == null || Convert.ToInt64(ViewState["KSAID"]) <= 0)
                {
                    if (Session["KSAID"] != null)
                    {
                        ViewState["KSAID"] = Convert.ToInt32(Session["KSAID"]);
                        Session["KSAID"] = null;
                    }
                    else
                    {
                        ViewState["KSAID"] = -1;
                    }

                    //if (Request.QueryString["KSAID"] != null)
                    //{
                    //    ViewState["KSAID"] = Convert.ToInt32(Request.QueryString["KSAID"]);
                    //}
                    //else
                    //{
                    //    ViewState["KSAID"] = -1;
                    //}
                }
                return Convert.ToInt32(ViewState["KSAID"]);
            }
            set
            {
                ViewState["KSAID"] = value;
            }
        }

        public int SeriesID
        {
            get
            {
                if (ViewState["SeriesID"] == null)
                {
                    if (Session["SeriesID"] != null)
                    {
                        ViewState["SeriesID"] = Convert.ToInt32(Session["SeriesID"]);
                        Session["SeriesID"] = null;
                    }
                    else
                    {
                        ViewState["SeriesID"] = -1;
                    }

                    //if (Request.QueryString["SeriesID"] != null)
                    //{
                    //    ViewState["SeriesID"] = Convert.ToInt32(Request.QueryString["SeriesID"]);
                    //}
                    //else
                    //{
                    //    ViewState["SeriesID"] = -1;
                    //}
                }
                return Convert.ToInt32(ViewState["SeriesID"]);
            }
            set
            {
                ViewState["SeriesID"] = value;
            }
        }

        public int CurrentGrade
        {
            get
            {
                if (ViewState["CurrentGrade"] == null)
                {
                    if (Session["CurrentGrade"] != null)
                    {
                        ViewState["CurrentGrade"] = Convert.ToInt32(Session["CurrentGrade"]);
                        Session["CurrentGrade"] = null;
                    }
                    else
                    {
                        ViewState["CurrentGrade"] = -1;
                    }

                    //if (Request.QueryString["CurrentGrade"] != null)
                    //{
                    //    ViewState["CurrentGrade"] = Convert.ToInt32(Request.QueryString["CurrentGrade"]);
                    //}
                    //else
                    //{
                    //    ViewState["CurrentGrade"] = -1;
                    //}
                }
                return Convert.ToInt32(ViewState["CurrentGrade"]);
            }
            set
            {
                ViewState["CurrentGrade"] = value;
            }
        }

        #endregion

        #region Methods

        protected override void OnInit(EventArgs e)
        {
            this.rcbSeries.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(rcbSeries_SelectedIndexChanged);
            this.rcbGrades.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(rcbGrades_SelectedIndexChanged);
            base.OnInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    InitControls();
                    SetPageView();
                }

                base.OnLoad(e);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }



        private void GetAllSeries()
        {
            SeriesCollection seriesCollection = LookupManager.GetAllSeries();
            rcbSeries.DataSource = seriesCollection;
            rcbSeries.DataTextField = "DetailLine";
            rcbSeries.DataValueField = "SeriesID";
            rcbSeries.DataBind();
            rcbSeries.Items.Insert(0, new RadComboBoxItem("[-- Select Series --]", "-1"));


            if (SeriesID > 0)
            {
                rcbSeries.SelectedValue = SeriesID.ToString();
            }
            else
            {
                rcbSeries.SelectedIndex = 0;
            }

            //init Grades            
            this.rcbSeries.MarkFirstMatch = true;
            this.rcbSeries.AllowCustomText = true;
        }

        private void GetAllGrades()
        {
            if (SeriesID > 0)
            {
                //Series series = new Series(SeriesID);
                //GradeCollection grades = series.GetGrades();
                GradeCollection grades = LookupManager.GetAllGrades();
                rcbGrades.DataSource = grades.Where(p => (p.GradeName != "Other")).ToList(); ;
                rcbGrades.DataBind();
            }

            rcbGrades.Items.Insert(0, new RadComboBoxItem("[-- Select Grade --]", "-1"));


            if (CurrentGrade > 0)
            {
                rcbGrades.SelectedValue = CurrentGrade.ToString();
            }
            else
            {
                rcbGrades.SelectedIndex = 0;
            }

        }

        private void InitControls()
        {
            GetAllSeries();

            GetAllGrades();

        }

        protected void SetPageView()
        {
            bool isInEditMode = base.IsInEdit;
            bool isInViewMode = (base.CurrentNavMode == enumNavigationMode.Insert);

            isInEditMode = true;
            isInViewMode = true;

            //this.lblKSAHeader.Text = "Currently Associated KSAs With Series: " + rcbSeries.SelectedValue + " And Grade: " + rcbGrades.SelectedValue;
            //lblTaskStatementsHeader.Text = "Currently Associated TaskStatements With Series: " + rcbSeries.SelectedValue + " Grade: " + rcbGrades.SelectedValue;
            if (this.CurrentGrade > 0)
            {
                lnkSearchKSA.Visible = true;
            
            }
            else
            {
                lnkSearchKSA.Visible = false;
              
            }
        }

        private void SetKSAID()
        {
            if (KSAID <= 0)
            {
                rgKSA.SelectedIndexes.Add(0);
                KSAID = Convert.ToInt64(rgKSA.SelectedValue);
            }
        }

        private void ShowHideTaskStatementLink(bool showhide)
        {
            lnkSearchTaskStatement.Visible = showhide;
        }

        private void HideRefreshButton(GridItemEventArgs e)
        {
            GridItem gridItem = e.Item;
            //hide the refresh button Telerik.Web.UI.GridLinkButton
            if (gridItem is GridCommandItem)
            {
                gridItem.FindControl("RebindGridButton").Visible = false;

            }
        }

        private void GetAllTaskStatementsForSelectedKSAID()
        {
            foreach (GridEditableItem row in rgTaskStatements.Items)
            {
                CheckBox chkBx = (CheckBox)row.FindControl("chkBxSelect");
                lstSelectedTaskstatementsToDelete.Add(Convert.ToInt64(row.GetDataKeyValue("TaskStatementID")));
            }
        }

        private void GetSelectedTaskStatements()
        {
            foreach (GridEditableItem row in rgTaskStatements.Items)
            {
                CheckBox chkBx = (CheckBox)row.FindControl("chkBxSelect");

                if (chkBx != null && chkBx.Checked)
                {
                    lstSelectedTaskstatementsToDelete.Add(Convert.ToInt64(row.GetDataKeyValue("TaskStatementID")));
                }
            }
        }

        private void DeleteTaskStatements()
        {
            KSAID = Convert.ToInt64(rgKSA.SelectedValue);
            for (int i = 0; i < this.lstSelectedTaskstatementsToDelete.Count; i++)
            {
                HCMS.Business.JQ.SeriesGradeKSATaskStatement seriesGradeKSATaskStatement = new HCMS.Business.JQ.SeriesGradeKSATaskStatement();
                seriesGradeKSATaskStatement.SeriesID = Convert.ToInt32(rcbSeries.SelectedValue);
                seriesGradeKSATaskStatement.Grade = Convert.ToInt32(rcbGrades.SelectedValue);
                seriesGradeKSATaskStatement.KSAID = this.KSAID;
                seriesGradeKSATaskStatement.TaskStatementID = lstSelectedTaskstatementsToDelete[i];
                seriesGradeKSATaskStatement.Delete(this.CurrentUserID);
            }

            rgKSA.Rebind();

            rgTaskStatements.Rebind();

            lblmsg.Text = "Task Statements Deleted Successfully.";
        }

        private void UpdateKSA(object source, GridCommandEventArgs e)
        {
            GridEditableItem gridItem = e.Item as GridEditableItem;
            RadTextBox newKSAText = gridItem.FindControl("rtbEditKSAText") as RadTextBox;

            long ksaID = long.Parse(gridItem.GetDataKeyValue("KSAID").ToString());

            KSA ksa = new KSA(ksaID);
            KSA.UpdateKSA(ksaID, newKSAText.Text, ksa.Active);

            this.rgKSA.Rebind();
        }

        private void UpdateTaskStatement(object source, GridCommandEventArgs e)
        {
            GridEditableItem gridItem = e.Item as GridEditableItem;
            RadTextBox ts = gridItem.FindControl("rtbEditTaskStatementText") as RadTextBox;

            long taskStatementID = long.Parse(gridItem.GetDataKeyValue("TaskStatementID").ToString());
            HCMS.Business.Lookups.TaskStatement taskStatement = new HCMS.Business.Lookups.TaskStatement(taskStatementID);
            taskStatement.UpdateTaskStatement(taskStatementID, ts.Text);
        }

        #endregion

        #region [ RadGrid rgKSA event handlers ]


        protected void rgKSA_PreRender(object sender, EventArgs e)
        {

            if (KSAID > 0)
            {
                //GridDataItem item;

                rgKSA.AllowPaging = false;
                for (int page = 0; page < rgKSA.MasterTableView.PageCount; page++)
                {
                    rgKSA.CurrentPageIndex = page + 1;
                    rgKSA.MasterTableView.CurrentPageIndex = rgKSA.CurrentPageIndex;

                    foreach (GridDataItem item in rgKSA.MasterTableView.Items)
                    {
                        if (item is GridDataItem)
                        {
                            GridDataItem dataItem = (GridDataItem)item;

                            if (dataItem.OwnerTableView.DataKeyValues[dataItem.ItemIndex]["KSAID"].ToString() == KSAID.ToString())
                            {
                                dataItem.Selected = true;
                                // rgKSA.CurrentPageIndex = rgKSA.MasterTableView.VirtualItemCount / rgKSA.PageSize;
                            }

                        }
                    }
                    
                }



                lnkSearchTaskStatement.Visible = true;
            }
            else
            {
                if (rgKSA.MasterTableView.Items.Count > 0)
                {
                    SetKSAID();
                }
                lnkSearchTaskStatement.Visible = false;
            }

            rgKSA.AllowPaging = true;
            rgTaskStatements.Rebind();

            if (this.lblmsg.Text != "")
            {
                this.lblmsg.Text = "";
            }

        }

        protected void rgKSA_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
           
                int start = 0;
                
                int max = HCMS.Business.Admin.SeriesGradeKSA.SelectSeriesGradeKSATotalCount(Convert.ToInt32(this.rcbSeries.SelectedValue) > 0 ? Convert.ToInt32(this.rcbSeries.SelectedValue) : 0, CurrentGrade > 0 ? CurrentGrade : 0);

                if (String.IsNullOrEmpty(txtExistingKSAKeyword.Text))
                {
                    rgKSA.DataSource = HCMS.Business.Admin.SeriesGradeKSA.SelectSeriesGradeKSA(start, max, Convert.ToInt32(rcbSeries.SelectedValue), Convert.ToInt32(rcbGrades.SelectedValue)).Select(null, "KSAID ASC");
                    rgKSA.MasterTableView.VirtualItemCount = HCMS.Business.Admin.SeriesGradeKSA.SelectSeriesGradeKSA(start, max, Convert.ToInt32(rcbSeries.SelectedValue), Convert.ToInt32(rcbGrades.SelectedValue)).Select(null, "KSAID ASC").Count();

                }
                else
                {
                    DataTable dt = HCMS.Business.Admin.SeriesGradeKSA.SelectSeriesGradeKSA(start, max, Convert.ToInt32(rcbSeries.SelectedValue), Convert.ToInt32(rcbGrades.SelectedValue));
                    DataRow[] dr2 = dt.Select("KSAText Like '%" + txtExistingKSAKeyword.Text + "%'");
                    DataTable dt2;
                    if (dr2.Count() > 0)
                    {
                        dt2 = dr2.CopyToDataTable();
                    }
                    else
                    {
                        dt2 = dt.Clone();
                    }

                    rgKSA.DataSource = dt2.Select(null, "KSAID ASC");
                    rgKSA.MasterTableView.VirtualItemCount = dt2.Select(null, "KSAID ASC").Count();
                }


            
            if (this.lblmsg.Text != "")
                this.lblmsg.Text = "";
        }


        protected void rgKSA_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {



            HideRefreshButton(e);
            if (this.lblmsg.Text != "")
                this.lblmsg.Text = "";

        }



        protected void rgKSA_ItemCommand(object sender, GridCommandEventArgs e)
        {
            RadWindowManager1.Windows.Clear();
            RadGrid rgAction = sender as RadGrid;
            GridDataItem gridItem;

            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                    break;
                case RadGrid.EditCommandName:
                    break;
                case RadGrid.UpdateCommandName:
                    UpdateKSA(sender, e);
                    break;
                case RadGrid.DeleteCommandName:
                    gridItem = e.Item as GridDataItem;
                    GetAllTaskStatementsForSelectedKSAID();
                    DeleteTaskStatements();
                    break;

                default:
                    this.KSAID = Convert.ToInt32(this.rgKSA.SelectedValue);

                    if (this.KSAID > 0)
                    {
                        rgTaskStatements.Rebind();
                    }

                    if (this.lblmsg.Text != "")
                        this.lblmsg.Text = "";
                    break;
            }
        }

        #endregion

        #region [RadGrid rgTaskStatements handlers]

        protected void rgTaskStatements_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            int start = 0;
            int max = HCMS.Business.Admin.SeriesGradeKSATaskStatement.SelectSeriesGradeKSATaskStatementsTotalCount(Convert.ToInt32(this.rcbSeries.SelectedValue) > 0 ? Convert.ToInt32(this.rcbSeries.SelectedValue) : 0, CurrentGrade > 0 ? CurrentGrade : 0, KSAID);

            if (KSAID > 0)
            {
                if (!String.IsNullOrEmpty(txtExistingTaskStatementKeyword.Text))
                {
                    DataTable dt = HCMS.Business.Admin.SeriesGradeKSATaskStatement.SelectSeriesGradeKSATaskStatements(start, max, Convert.ToInt32(rcbSeries.SelectedValue), CurrentGrade, KSAID);
                    DataRow[] dr2 = dt.Select("TaskStatement Like '%" + txtExistingTaskStatementKeyword.Text + "%'");
                    DataTable dt2;
                    if (dr2.Count() > 0)
                    {
                        dt2 = dr2.CopyToDataTable();
                    }
                    else
                    {
                        dt2 = dt.Clone();
                    }
                    rgTaskStatements.DataSource = dt2.Select(null, "TaskStatementID ASC");
                }
                else
                {
                    rgTaskStatements.DataSource = HCMS.Business.Admin.SeriesGradeKSATaskStatement.SelectSeriesGradeKSATaskStatements(start, max, Convert.ToInt32(rcbSeries.SelectedValue), Convert.ToInt32(rcbGrades.SelectedValue), KSAID).Select(null, "TaskStatementID ASC"); ;
                }
            }
            else
            {
                rgTaskStatements.DataSource = HCMS.Business.Admin.SeriesGradeKSATaskStatement.SelectSeriesGradeKSATaskStatements(start, max, Convert.ToInt32(rcbSeries.SelectedValue), Convert.ToInt32(rcbGrades.SelectedValue), KSAID).Select(null, "TaskStatementID ASC"); ;
            }
            if (this.lblmsg.Text != "")
                this.lblmsg.Text = "";


        }

        protected void rgTaskStatements_ItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            HideRefreshButton(e);
            if (this.lblmsg.Text != "")
                this.lblmsg.Text = "";

        }

        protected void rgTaskStatements_ItemCommand(object sender, GridCommandEventArgs e)
        {
            GridDataItem gridItem = e.Item as GridDataItem;

            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                    break;
                case RadGrid.EditCommandName:
                    break;
                case RadGrid.UpdateCommandName:
                    UpdateTaskStatement(sender, e);
                    break;
                case RadGrid.DeleteCommandName:
                    break;
                case RadGrid.PerformInsertCommandName:
                    break;
                default:
                    break;
            }
            if (this.lblmsg.Text != "")
                this.lblmsg.Text = "";
        }

        protected void rgTaskStatements_RowCreated(object source, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
                {
                    CheckBox chkBxSelect = (CheckBox)e.Row.Cells[1].FindControl("chkBxSelect");
                    CheckBox chkBxHeader = (CheckBox)this.rgTaskStatements.HeaderContextMenu.FindControl("chkBxHeader");
                    chkBxSelect.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chkBxHeader.ClientID);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnDeleteAllTaskStatements_Click(object sender, EventArgs e)
        {
            GetSelectedTaskStatements();
            DeleteTaskStatements();
        }

        #endregion

        #region Events

        #region [ RadComboBox rcbSeries event handlers ]

        protected void rcbSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SeriesID = Convert.ToInt32(rcbSeries.SelectedValue);

            GetAllGrades();
            if (CurrentGrade != -1)
            {
                if (ViewState["KSAID"] == null || Convert.ToInt64(ViewState["KSAID"]) <= 0)
                {
                    if (Session["KSAID"] != null)
                    {
                        KSAID = Convert.ToInt32(Session["KSAID"]);
                        Session["KSAID"] = null;
                    }
                }
                else
                {
                    KSAID = Convert.ToInt64(ViewState["KSAID"]);

                }

                //if (Request.QueryString["KSAID"] != null)
                //{
                //    KSAID = Convert.ToInt64(Request.QueryString["KSAID"]);
                //}
                //else
                //{
                //    KSAID = -1;
                //}
            }
            rgKSA.Rebind();
            rgTaskStatements.Rebind();

        }

        protected void rcbSeries_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
        {
            e.Item.Text = string.Concat(e.Item.Text);

        }

        #endregion

        #region [ RadComboBox rcbGrades event handlers ]

        protected void rcbGrades_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            KSAID = -1;
            CurrentGrade = Int32.Parse(rcbGrades.SelectedValue);
            if (CurrentGrade > 0)
            {
                lnkSearchKSA.Visible = true;
                lnkSearchTaskStatement.Visible = true;
            }
            else
            {
                lnkSearchKSA.Visible = false;
                lnkSearchTaskStatement.Visible = false;
            }

            rgKSA.Rebind();
            
            if (CurrentGrade != -1)
            {

                if (ViewState["KSAID"] == null)
                {
                    if (Session["KSAID"] != null)
                    {
                        KSAID = Convert.ToInt32(Session["KSAID"]);
                        Session["KSAID"] = null;
                    }
                }
                else if (ViewState["KSAID"] == null)
                {
                    KSAID = Convert.ToInt32(ViewState["KSAID"]);
                }
                else
                {
                    //    KSAID = -1;
                    SetKSAID();
                }

                //if (Request.QueryString["KSAID"] != null)
                //{
                //    KSAID = Convert.ToInt64(Request.QueryString["KSAID"]);
                //}
                //else
                //{
                ////    KSAID = -1;
                //    SetKSAID();
                //}
            }

           
            rgTaskStatements.Rebind();


        }

        #endregion

        protected void lnkSearchKSA_Click(object source, EventArgs e)
        {

            Session["SeriesID"] = rcbSeries.SelectedValue;
            Session["CurrentGrade"] = rcbGrades.SelectedValue;

            //string urlhlSearchKSA = string.Format("~/Admin/SearchKSA.aspx?SeriesID=" + Convert.ToInt32(rcbSeries.SelectedValue) + "&CurrentGrade=" + Convert.ToInt32(rcbGrades.SelectedValue));
            string urlhlSearchKSA = string.Format("~/Admin/SearchKSA.aspx");
            base.GoToLink(urlhlSearchKSA);
        }

        protected void lnkSearchTaskStatement_Click(object source, EventArgs e)
        {
            KSAID = Convert.ToInt64(rgKSA.SelectedValue);

            Session["PreviousPage"] = "KSATaskStatementMaintenance";
            Session["KSAID"] = KSAID;
            Session["SeriesID"] = rcbSeries.SelectedValue;
            Session["CurrentGrade"] = rcbGrades.SelectedValue;

            //string urlhlSearchTS = string.Format("~/Admin/SearchTaskStatement.aspx?SeriesID=" + Convert.ToInt32(rcbSeries.SelectedValue) + "&CurrentGrade=" + Convert.ToInt32(rcbGrades.SelectedValue) + "&KSAID=" + KSAID + "&PreviousPage=" + "KSATaskStatementMaintenance");
            string urlhlSearchTS = string.Format("~/Admin/SearchTaskStatement.aspx");
            base.GoToLink(urlhlSearchTS);
        }

        protected void btnExistingKSASearch_Click(object source, EventArgs e)
        {
            rgKSA.Rebind();
            rgTaskStatements.Rebind();
        }

        protected void btnExistingKSAClear_Click(object source, EventArgs e)
        {
            txtExistingKSAKeyword.Text = "";
            rgKSA.Rebind();
            rgTaskStatements.Rebind();
        }

        protected void btnExistingTaskStatementSearch_Click(object source, EventArgs e)
        {
            rgTaskStatements.Rebind();
        }

        protected void btnExistingTaskStatementClear_Click(object source, EventArgs e)
        {
            txtExistingTaskStatementKeyword.Text = "";
            rgTaskStatements.Rebind();
        }

        #endregion

    }
}