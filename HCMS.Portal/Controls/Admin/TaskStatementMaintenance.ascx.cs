using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using HCMS.Business.Lookups;
using System.Data;
using HCMS.WebFramework.BaseControls;

namespace HCMS.Portal.Controls.Admin
{
    public partial class TaskStatementMaintenance : UserControlBase
    {

        private enum enumSearchType
        {
            Default=0,
            ByID=1,
            Advanced=2

        }


        private enumSearchType CurrentSearchType
        {
            get {
                
                 enumSearchType _currentSearchType = enumSearchType.Default;
                if (ViewState["CurrentSearchType"] != null)
                {
                    _currentSearchType = (enumSearchType)ViewState["CurrentSearchType"];
                }

                return _currentSearchType;
            }
            set {
                ViewState["CurrentSearchType"] = value;
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            if (!IsPostBack)
            {
                InitControls();
                CurrentSearchType = enumSearchType.Default;
       

            }
            base.OnLoad(e);
        }

        private void InitControls()
        {
            rcbSeries.DataSource = LookupManager.GetAllSeries();
            rcbSeries.DataBind();
            rcbSeries.Items.Insert(0, new RadComboBoxItem("[-- Select Series --]", "-1"));

            rcbGrade.DataSource = LookupManager.GetAllGrades();
            rcbGrade.DataBind();
            rcbGrade.Items.Insert(0, new RadComboBoxItem("[-- Select Grade --]", "-1"));
        }

        private void LoadData()
        {
            switch (CurrentSearchType)
            {
                case enumSearchType.ByID:
                    long taskstatementid=Convert.ToInt64 (txtExistingTSID.Text);
                    //DataTable dt2 =HCMS.Business.Lookups.TaskStatement.SearchTaskStatement(taskstatementid , null, null, "");                        
                    //rgTaskStatements.DataSource = dt2.Select(null, "TaskStatementID ASC");

                    //TS is pulled from static data table from TaskStatement.cs instead of from db everytime it pulls for search by TS ID.
                    DataTable dt2;
                    dt2 = HCMS.Business.Lookups.TaskStatement.dtTS;
                    rgTaskStatements.DataSource = dt2 != null ? dt2.Select("TaskStatementID=" + taskstatementid) : HCMS.Business.Lookups.KSA.SearchKSAByAdmin(taskstatementid, null, null, "").Select("TaskStatementID=" + taskstatementid);
                    break;
                case enumSearchType.Advanced:
                    int seriesid=Convert.ToInt32 (rcbSeries.SelectedValue);
                    int gradeid=Convert.ToInt32 (rcbGrade.SelectedValue) ;
                    string keyword=this.txtKeyword.Text;
                    //DataTable dtAdvanced = HCMS.Business.Lookups.TaskStatement.SearchTaskStatement(null, seriesid, gradeid, keyword);
                    //rgTaskStatements.DataSource = dtAdvanced;

                    if (HCMS.Business.Lookups.TaskStatement.dtTSAdv == null)
                        HCMS.Business.Lookups.TaskStatement.SearchTaskStatement(null, null, null, "");

                    if((seriesid == -1) && (gradeid == -1))
                        rgTaskStatements.DataSource = HCMS.Business.Lookups.TaskStatement.dtTSAdv.Select("TaskStatement like '%" + keyword + "%'");
                    else if (seriesid == -1)
                        rgTaskStatements.DataSource = HCMS.Business.Lookups.TaskStatement.dtTSAdv.Select("Grade=" + gradeid + " AND TaskStatement like '%" + keyword + "%'");
                    else if (gradeid == -1)
                        rgTaskStatements.DataSource = HCMS.Business.Lookups.TaskStatement.dtTSAdv.Select("SeriesID=" + seriesid + " AND TaskStatement like '%" + keyword + "%'");
                    else
                        rgTaskStatements.DataSource = HCMS.Business.Lookups.TaskStatement.dtTSAdv.Select("SeriesID=" + seriesid + " AND Grade=" + gradeid + " AND TaskStatement like '%" + keyword + "%'");

                    break;
                case enumSearchType.Default:
                default :
                    int start = rgTaskStatements.CurrentPageIndex ;
                    int max =  HCMS.Business.Lookups.TaskStatement.SelectTaskStatementTotalCount(start, -1);           
                
                    //DataTable dt = HCMS.Business.Lookups.TaskStatement.GetTSPaged(start, max);
                    //rgTaskStatements.DataSource = dt.Select(null, "TaskStatementID ASC");

                    DataTable staticTS = HCMS.Business.Lookups.TaskStatement.dtTS;
                    rgTaskStatements.DataSource = staticTS != null ? staticTS.Select(null, "TaskStatementID ASC") : HCMS.Business.Lookups.TaskStatement.GetTSPaged(start, max).Select(null, "TaskStatementID ASC");
                    
                    
                    break;              
            }
        }

        private void UpdateTaskStatement(object source, GridCommandEventArgs e)
        {
            try
            {
                GridEditableItem gridItem = e.Item as GridEditableItem;
                RadTextBox ts = gridItem.FindControl("rtbTaskStatementText") as RadTextBox;
                long taskStatementID = long.Parse(gridItem.GetDataKeyValue("TaskStatementID").ToString());
                TaskStatement taskStatement = new TaskStatement(taskStatementID);
                taskStatement.UpdateTaskStatement(taskStatementID, ts.Text);

                //Added to hold in static TS table and reload
                int start = rgTaskStatements.CurrentPageIndex;
                int max = HCMS.Business.Lookups.TaskStatement.SelectTaskStatementTotalCount(start, -1);

                HCMS.Business.Lookups.TaskStatement.GetTSPaged(start, max);

                this.rgTaskStatements.Rebind();
            }
            catch (Exception ex)
            {
                this.literalmsg.Text = ex.Message;
            }
        }
        
        private void DeleteTaskStatement(object source, GridCommandEventArgs e)
        {
            try
            {
                GridDataItem gridItem = e.Item as GridDataItem;
                long taskStatementID = long.Parse(gridItem.GetDataKeyValue("TaskStatementID").ToString());
                TaskStatement taskStatement = new TaskStatement(taskStatementID);
                taskStatement.DeleteTaskStatement(taskStatementID);

                //Added to hold in static TS table and reload
                int start = rgTaskStatements.CurrentPageIndex;
                int max = HCMS.Business.Lookups.TaskStatement.SelectTaskStatementTotalCount(start, -1);

                HCMS.Business.Lookups.TaskStatement.GetTSPaged(start, max);

                this.rgTaskStatements.Rebind();

            }
            catch (Exception ex)
            {
                this.literalmsg.Text = ex.Message;
            }
        }
        protected void rgTaskStatements_ItemCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                
                case RadGrid.UpdateCommandName:
                    UpdateTaskStatement(sender, e);
                    break;
                case RadGrid.DeleteCommandName:
                    DeleteTaskStatement(sender, e);
                    break;
                default:
                    break;
            }
        }

        protected void rgTaskStatements_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            try
            {
                LoadData();
            }
            catch (Exception ex)
            {
                this.literalmsg.Text = ex.Message;
            }
        }

        protected void btnExistingTSSearch_Click(object source, EventArgs e)
        {
            CurrentSearchType = enumSearchType.ByID;
            rgTaskStatements.Rebind();

        }

        protected void btnExistingTSClear_Click(object source, EventArgs e)
        {
            this.txtExistingTSID.Text = "";
            CurrentSearchType = enumSearchType.Default;
            rgTaskStatements.Rebind();
        }

        protected void btnAdvancedSearch_Click(object sender, EventArgs e)
        {
            CurrentSearchType = enumSearchType.Advanced;
            rgTaskStatements.Rebind();
        }


    }
}