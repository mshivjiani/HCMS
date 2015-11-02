using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.Lookups;
using Telerik.Web.UI;
using HCMS.Business.JQ;


namespace HCMS.Portal.Controls.Admin
{
    public partial class ctrlAdminSearchTaskStatement : UserControlBase
    {
        #region Properties
        
        private List<TSEntity> _taskStatementlist;
        
        public List<TSEntity> TaskStatementList
        {
            get { return this._taskStatementlist; }
            set { this._taskStatementlist = value; }
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
                }

                //if (ViewState["SeriesID"] == null)
                //{
                //    if (Request.QueryString["SeriesID"] != null)
                //    {
                //        ViewState["SeriesID"] = Convert.ToInt32(Request.QueryString["SeriesID"]);
                //    }
                //    else
                //    {
                //        ViewState["SeriesID"] = -1;
                //    }
                //}

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
        
        public long KSAID
        {
            get
            {
                if (ViewState["KSAID"] == null)
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

        public string KSAText
        {
            get
            {
                if (ViewState["KSAText"] == null)
                {
                    if (Session["KSADesc"] != null)
                    {
                        ViewState["KSAText"] = Session["KSADesc"].ToString();
                        Session["KSADesc"] = null;
                    }
                    else
                    {
                        ViewState["KSAText"] = "";
                    }

                    //if (Request.QueryString["KSAText"] != null)
                    //{
                    //    ViewState["KSAText"] = Request.QueryString["KSAText"].ToString();
                    //}
                    //else
                    //{
                    //    ViewState["KSAText"] = "";
                    //}
                }
                return ViewState["KSAText"].ToString();
            }
            set
            {
                ViewState["KSAText"] = value;
            }
        }

        public string PreviousPage
        {
            get
            {
                if (ViewState["PreviousPage"] == null)
                {
                    if (Session["PreviousPage"] != null)
                    {
                        ViewState["PreviousPage"] = Session["PreviousPage"].ToString();
                        Session["PreviousPage"] = null;
                    }
                    else
                    {
                        ViewState["PreviousPage"] = "";
                    }

                    //if (Request.QueryString["PreviousPage"] != null)
                    //{
                    //    ViewState["PreviousPage"] = Request.QueryString["PreviousPage"].ToString();
                    //}
                    //else
                    //{
                    //    ViewState["PreviousPage"] = "";
                    //}
                }
                return ViewState["PreviousPage"].ToString();
            }
            set
            {
                ViewState["PreviousPage"] = value;
            }
        }

        private List<long> lstSelectedTS = new List<long>();

        #endregion

        #region Events Delegates
        public delegate void TaskStatementAdminSearchCompletedHandler();
        public event TaskStatementAdminSearchCompletedHandler TaskStatementAdminSearchCompleted;
        public delegate void TaskStatementAdminSearchCancelCompleteHandler();
        public event TaskStatementAdminSearchCancelCompleteHandler TaskStatementAdminSearchCancelCompleted;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Series series = new Series(SeriesID);
                string seriesText = string.Format("{0} | {1}", series.SeriesID, series.SeriesName).Trim();

                if (KSAID > 0)
                {
                    trCurrentKSA.Visible = true;
                    KSA ksa = new KSA(KSAID);
                    string ksaText = string.Format("{0} | {1}", ksa.KSAID, ksa.KSAText).Trim();
                    this.lblCurrentKSA.Text = ksaText;
                }
                else
                {
                    trCurrentKSA.Visible = false;
                }
                this.lblCurrentSeries.Text = seriesText;
                this.lblCurrentGrade.Text = CurrentGrade.ToString();


                List<Grade> grades = LookupManager.GetAllGrades();
                grades = grades.Where(p => (p.GradeName != "Other")).ToList();
                this.radTSComboGrades.DataSource = grades;
                this.radTSComboGrades.DataBind();
                //this.radTSComboGrades.SelectedValue = CurrentGrade.ToString();
                //this.radTSComboGrades.SelectedItem.Checked = true;

                rgSearchTS.Rebind();
                SetTSHeaderLabel();

                //pnlOtherTaskStatement.Visible = false;
            }
        }

        public void LoadData(int seriesID, int ksaID)
        {
            this.SeriesID = seriesID;
            this.KSAID = ksaID;

            rgSearchTS.Rebind();

            if (TaskStatementAdminSearchCompleted != null)
                TaskStatementAdminSearchCompleted();

        }

        private void SetTSHeaderLabel()
        {
            string TSHeaderLabel = string.Empty;
            if (SeriesID > 0)
            {
                TSHeaderLabel = "TaskStatements Associated With Current Series: " + SeriesID;
            }

            List<int> selectedgrades = new List<int>();
            foreach (RadComboBoxItem item in radTSComboGrades.CheckedItems)
            {
                if (int.Parse(item.Value) != CurrentGrade)
                {
                    selectedgrades.Add(int.Parse(item.Value));
                }
            }

            if (CurrentGrade > 0)
            {
                selectedgrades.Add(CurrentGrade);
            }

            selectedgrades.Sort();

            string gradelist = string.Join(",", selectedgrades);

            if (gradelist != "")
            {
                TSHeaderLabel = TSHeaderLabel + " And Grade(s): " + gradelist;
            }

            if (KSAID > 0)
            {
                TSHeaderLabel = TSHeaderLabel + " And Selected KSA: " + KSAID;
            }

            if (!String.IsNullOrEmpty(txtTSKeyword.Text))
            {
                TSHeaderLabel = TSHeaderLabel + "  And TaskStatement Keyword: " + txtTSKeyword.Text;
            }


            lblTSHeader.Text = TSHeaderLabel;
        }

        private List<TSEntity> GetTaskStatementList()
        {
            List<TSEntity> taskStatementlist = new List<TSEntity>();
            List<Grade> selectedgrades = new List<Grade>();

            bool filterbySeries = rbFilterBySeries.Checked == true ? true : false;

            foreach (RadComboBoxItem item in radTSComboGrades.CheckedItems)
            {
                //filtering out currently selected grade
                if (int.Parse(item.Value) != CurrentGrade)
                {
                    Grade currentgrade = new Grade();
                    currentgrade.GradeID = int.Parse(item.Value);
                    currentgrade.GradeName = item.Text;
                    selectedgrades.Add(currentgrade);
                }
            }

            taskStatementlist = TaskStatementEntityManager.GetTaskStatementEntityList(SeriesID, CurrentGrade, selectedgrades, filterbySeries, this.txtTSKeyword.Text, KSAID);

            return taskStatementlist;

        }

        private void GetSelectedTaskStatements()
        {
            foreach (GridEditableItem row in rgSearchTS.Items)
            {
                CheckBox chkBx = (CheckBox)row.FindControl("chkBxSelect");

                if (chkBx != null && chkBx.Checked)
                {
                    lstSelectedTS.Add(Convert.ToInt64(row.GetDataKeyValue("TaskStatementID")));
                }
            }
        }

        private void AddNewKSA()
        {
            KSA ksa = new KSA();
            ksa.KSAID = -1;
            ksa.KSAText = this.KSAText;
            ksa.Active = true;
            ksa.Add();

            KSAID = ksa.KSAID;
        }

        private void AddNewTaskStatement(string TaskStatementDescription)
        {
            TaskStatement taskStatement = new TaskStatement();
            taskStatement.TaskStatementID = -1;
            taskStatement.TaskStatementText = TaskStatementDescription;

            taskStatement.Add();

            lstSelectedTS.Add(Convert.ToInt64(taskStatement.TaskStatementID));
        }

        private void AddNewSeriesGradeKSATaskStatement()
        {
            if (KSAID > 0)
            {
                GetSelectedTaskStatements();

                for (int i = 0; i < this.lstSelectedTS.Count; i++)
                {
                    SeriesGradeKSATaskStatement seriesGradeKSATaskStatement = new SeriesGradeKSATaskStatement();
                    seriesGradeKSATaskStatement.SeriesID = this.SeriesID;
                    seriesGradeKSATaskStatement.Grade = this.CurrentGrade;
                    seriesGradeKSATaskStatement.KSAID = this.KSAID;
                    seriesGradeKSATaskStatement.TaskStatementID = lstSelectedTS[i];
                    seriesGradeKSATaskStatement.AddSeriesGradeKSATaskStatement();
                }

                rgSearchTS.Rebind();

                lblmsg.Text = "Task Statement Added Successfully.";
            }
        }

        private void AddTaskStatement()
        {
            try
            {
                if (KSAID == -1)
                {
                    if (!String.IsNullOrEmpty(this.KSAText))
                    {
                        AddNewKSA();
                    }
                    else
                    {
                        lblmsg.Text = "Please select a valid KSA";
                        return;
                    }                   

                    AddNewSeriesGradeKSATaskStatement();
                }
                else
                {                        

                    AddNewSeriesGradeKSATaskStatement();
                }
            }
            catch (Exception ex)
            {
                lblmsg.Text = "Task Statement insertion failed.";
            }
        } 

        protected void rgSearchTS_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgSearchTS.DataSource = TaskStatementList = GetTaskStatementList().Where(p => (p.TaskStatement != UserControlBase.OTHERTASKSTATEMENTTEXT )).ToList();
        }

        protected void rgSearchTS_RowCreated(object source, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow && (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate))
                {
                    CheckBox chkBxSelect = (CheckBox)e.Row.Cells[1].FindControl("chkBxSelect");
                    CheckBox chkBxHeader = (CheckBox)this.rgSearchTS.HeaderContextMenu.FindControl("chkBxHeader");
                    chkBxSelect.Attributes["onclick"] = string.Format("javascript:ChildClick(this,'{0}');", chkBxHeader.ClientID);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void rgSearchTS_ItemCommand(object source, GridCommandEventArgs e)
        {
            //RadWindowManagerSearchTS.Windows.Clear();
            GridItem gridItem = e.Item;
            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                    btnAddTaskStatement.Visible = false;
                    rgSearchTS.MasterTableView.ShowHeader = false;
                    break;
                case RadGrid.PerformInsertCommandName:                    

                    TextBox tbOtherTaskStatementDescription = gridItem.FindControl("txtOtherTaskStatementDescription") as TextBox;

                    if (!String.IsNullOrEmpty(tbOtherTaskStatementDescription.Text))
                    {
                        if (KSAID == -1)
                        {
                            if (!String.IsNullOrEmpty(this.KSAText))
                            {
                                AddNewKSA();
                            }
                        }
                        AddNewTaskStatement(tbOtherTaskStatementDescription.Text);
                        AddNewSeriesGradeKSATaskStatement();

                        Session["SeriesID"] = SeriesID;
                        Session["CurrentGrade"] = CurrentGrade;
                        Session["KSAID"] = KSAID;

                        base.GoToLink("~/Admin/KSATaskStatementMaintenance.aspx");
                        //base.GoToLink("~/Admin/KSATaskStatementMaintenance.aspx?SeriesID=" + SeriesID + "&CurrentGrade=" + CurrentGrade + "&KSAID=" + KSAID);


                    }
                    break;
                default:
                    rgSearchTS.MasterTableView.ShowHeader = true;
                    btnAddTaskStatement.Visible = true;
                    break;
            }
        }

        protected void chkTaskStatement_CheckedChange(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnTSSearch_Click(object sender, EventArgs e)
        {
            rgSearchTS.Rebind();
            SetTSHeaderLabel();
            if (TaskStatementAdminSearchCompleted != null)
                TaskStatementAdminSearchCompleted();

        }

        protected void btnTSClear_Click(object sender, EventArgs e)
        {
            TaskStatementList = null;
            this.radTSComboGrades.ClearCheckedItems();
            this.txtTSKeyword.Text = "";

            rgSearchTS.Rebind();
            SetTSHeaderLabel();
        }

        protected void btnTSCancel_Click(object sender, EventArgs e)
        {
            if (TaskStatementAdminSearchCancelCompleted != null)
                TaskStatementAdminSearchCancelCompleted();
        }

        protected void btnAddTaskStatement_Click(object source, EventArgs e)
        {
            AddTaskStatement();

            Session["SeriesID"] = SeriesID;
            Session["CurrentGrade"] = CurrentGrade;
            Session["KSAID"] = KSAID;

            base.GoToLink("~/Admin/KSATaskStatementMaintenance.aspx");
            //base.GoToLink("~/Admin/KSATaskStatementMaintenance.aspx?SeriesID=" + SeriesID + "&CurrentGrade=" + CurrentGrade + "&KSAID=" + KSAID);
        }

        protected void btnTaskStatementCancel_Click(object sender, EventArgs e)
        {
            if (PreviousPage == "SearchKSA")
            {
                Session["SeriesID"] = SeriesID;
                Session["CurrentGrade"] = CurrentGrade;

                base.GoToLink("~/Admin/SearchKSA.aspx");
                //base.GoToLink("~/Admin/SearchKSA.aspx?SeriesID=" + SeriesID + "&CurrentGrade=" + CurrentGrade);
            }
            else
            {
                Session["SeriesID"] = SeriesID;
                Session["CurrentGrade"] = CurrentGrade;

                base.GoToLink("~/Admin/KSATaskStatementMaintenance.aspx?SeriesID=" + SeriesID + "&CurrentGrade=" + CurrentGrade);
                //base.GoToLink("~/Admin/KSATaskStatementMaintenance.aspx?SeriesID=" + SeriesID + "&CurrentGrade=" + CurrentGrade);
            }
        }

    }
}