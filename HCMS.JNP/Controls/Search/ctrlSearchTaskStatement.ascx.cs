using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

using HCMS.Business.Base;
using HCMS.Business.Common;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Utilities;
using HCMS.Business.Lookups;
using System.Data;

namespace HCMS.JNP.Controls.Search
{
    public partial class ctrlSearchTaskStatement : UserControlBase
    {
        #region Properties

        private RadListBox _taskListBox;

        //private RadComboBox _taskComboBox;
        private Label _searchMssgLabel;
        private List<TSEntity> _taskStatementlist;

        public List<TSEntity> TaskStatementList
        { 
            get { return this._taskStatementlist; }
            set { this._taskStatementlist = value; }
        }

        public string KeywordSearched
        {
            get { return txtTSKeyword.Text; }
        }

        public bool ShowAllGradesChecked
        {
            get { return chkAllGrades.Checked; }
        }

        public long KSAID
        {
            get
            {
                if (ViewState["KSAID"] == null)
                {
                    ViewState["KSAID"] = -1;
                }
                return Convert.ToInt32(ViewState["KSAID"]);
            }
            set
            {
                ViewState["KSAID"] = value;
            }
        } 

        //public RadComboBox TaskComboBox
        //{
        //    get { return this._taskComboBox; }
        //    set { this._taskComboBox = value; }
        //}
        public RadListBox TaskListBox
        {
            get { return this._taskListBox; }
            set { this._taskListBox = value; }
        }

        public Label SearchMessageLabel
        {
            get { return this._searchMssgLabel; }
            set { this._searchMssgLabel = value; }
        }

        public int SeriesID
        {
            get
            {
                if (ViewState["SeriesID"] == null)
                    ViewState["SeriesID"] = -1;

                return (int)ViewState["SeriesID"];
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
                    ViewState["CurrentGrade"] = 0;

                }
                return (int)ViewState["CurrentGrade"];
            }
            set { ViewState["CurrentGrade"] = value; }
        }

        #endregion

        #region Events Delegates

        public delegate void TSSearchCompletedHandler(object sender, EventArgs e);
        public event TSSearchCompletedHandler TSSearchCompleted;
        public delegate void TSSearchCancelCompleteHandler(object sender, EventArgs e);
        public event TSSearchCancelCompleteHandler TSSearchCancelCompleted;
        public delegate void TSSearchClearCompleteHandler(object sender, EventArgs e);
        public event TSSearchClearCompleteHandler TSSearchClearCompleted;
        public delegate void TSSearchObjectNotSetHandler();
        public event TSSearchObjectNotSetHandler TSSearchObjectNotSet;

        public delegate void TSSearchUnckeckedHandler(object sender, EventArgs e);
        public event TSSearchUnckeckedHandler TSSearchUnckecked;

        public delegate void TSSearchClickGlassHandler(object sender, EventArgs e);
        public event TSSearchClickGlassHandler TSSearchClickGlass;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
        }

        public string SetSearchResultMessage()
        {
            string mssg = "";
            var keywordSearch = "";
            if (txtTSKeyword.Text.Length > 0) keywordSearch = ". Searched on keyword: " + txtTSKeyword.Text;
            if (chkAllGrades.Checked)
                mssg = string.Format("Search Task in Series:{0}" + keywordSearch, SeriesID.ToString());
            else
                mssg = string.Format("Search Task in Series:{0} - Grade:{1}" + keywordSearch, SeriesID.ToString(), CurrentGrade.ToString());
            return mssg;
        }

        protected void chkAllGrades_OnCheckedChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
            if (!chkAllGrades.Checked && TSSearchUnckecked != null) TSSearchUnckecked(sender, e);
        }
         
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            RunSearchFillTaskList();

            if (TSSearchCompleted != null) TSSearchCompleted(sender, e);
            // If a link to a search status/message label was provided, show search message
            if (SearchMessageLabel != null) SearchMessageLabel.Text = SetSearchResultMessage();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtTSKeyword.Text = string.Empty;
            RunSearchFillTaskList();
            if (TSSearchClearCompleted != null) TSSearchClearCompleted(sender, e);
            if (SearchMessageLabel != null) SearchMessageLabel.Text = "";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            spanright.Visible = false;
            if (TSSearchCancelCompleted != null) TSSearchCancelCompleted(sender, e);
            if (SearchMessageLabel != null) SearchMessageLabel.Text = "";
        }

        private void RunSearchFillTaskList()
        {
            var items = GetTaskList();
            //AddTaskItemsToComboBox(items);
            AddTaskStatementsToListbox(items);
        }

        private List<TSEntity> GetTaskList()
        {
            
            List<Grade> selectedgrades = new List<Grade>();
            bool selectallgrades = chkAllGrades.Checked;
            if (selectallgrades)
            {
                selectedgrades = LookupManager.GetAllGrades();
            }
            else
            {
                selectedgrades.Add(new Grade() { GradeID = CurrentGrade });
            }

            List<TSEntity> dt = new List<TSEntity>();

            if (!chkAllGrades.Checked)
            {
                if (Session["InitialTaskList"] != null)
                {
                    dt = (List<TSEntity>)Session["InitialTaskList"];

                    if (txtTSKeyword.Text.Trim() != "")
                    {
                        var result = dt.Where(t => t.TaskStatement.ToLower().Contains(txtTSKeyword.Text.ToLower()));

                        var taskList = result;
                        var orderedList = taskList.OrderBy(o => o.TaskStatement).ToList();
                        return orderedList;
                    }
                }
            }
            else
            {
                List<TSEntity> taskList = TaskStatementEntityManager.GetTaskStatementEntityList(SeriesID, CurrentGrade, selectedgrades, true, txtTSKeyword.Text, KSAID);
                List<TSEntity> orderedList = taskList.OrderBy(o => o.TaskStatement).ToList();
                
                if (Session["JQFactorID"] != null)
                {
                    if (Session["JQFactorID"].ToString() != String.Empty)
                    {
                        DataTable dtAdded = TaskStatementEntityManager.GetAllAddedTaskStatements(Convert.ToInt32(Session["JQFactorID"]));

                        if (dtAdded.Rows.Count > 0)
                        {
                            for (int i = 0; i < dtAdded.Rows.Count; i++)
                            {
                                orderedList.RemoveAll(o => o.TaskStatementID == Convert.ToInt32(dtAdded.Rows[i]["TaskStatementID"]));
                            }
                        }

                        Session["JQFactorID"] = null;
                    }
                }
                orderedList.RemoveAll(m => m.TaskStatement == UserControlBase.JUSTOTHER);
                orderedList.RemoveAll(m => m.TaskStatement == UserControlBase.OTHERTASKSTATEMENTTEXT);
                
                //Removed Create New in Listbox
                //orderedList.Insert(0, new TSEntity() { TaskStatementID = 0, TaskStatement = UserControlBase.OTHERTASKSTATEMENTTEXT });
                return orderedList;

            }
            return null;
        }

        //private void AddTaskItemsToComboBox(List<TSEntity> items)
        //{
        //    List<TSEntity> orderedItems = new List<TSEntity>();

        //    if (items != null)
        //    {
        //        items.RemoveAll(m => m.TaskStatement == UserControlBase.JUSTOTHER);
        //        items.RemoveAll(m => m.TaskStatement == UserControlBase.OTHERTASKSTATEMENTTEXT);

        //        orderedItems = items.OrderBy(o => o.TaskStatement).ToList();
        //    }

        //    orderedItems.Insert(0, new TSEntity() { TaskStatementID = 0, TaskStatement = UserControlBase.OTHERTASKSTATEMENTTEXT });

        //    // Set Task list property for external use
        //    TaskStatementList = orderedItems;

        //    // If search has linked KSA combo box, go ahead and fill it
        //    if (TaskComboBox != null)
        //    {
        //        TaskComboBox.Items.Clear();
        //        ControlUtility.BindRadComboBoxControlWithBackground(TaskComboBox, TaskStatementList, null, "TaskStatement", "TaskStatementID", "<<-- Select Task Statement -->>");
        //    }            
        //}
        private void AddTaskStatementsToListbox(List<TSEntity> items)
        {
            List<TSEntity> orderedItems = new List<TSEntity>();

            if (items != null)
            {
                items.RemoveAll(m => m.TaskStatement == UserControlBase.JUSTOTHER);
                items.RemoveAll(m => m.TaskStatement == UserControlBase.OTHERTASKSTATEMENTTEXT);

                orderedItems = items.OrderBy(o => o.TaskStatement).ToList();
            }

            //orderedItems.Insert(0, new TSEntity() { TaskStatementID = 0, TaskStatement = UserControlBase.OTHERTASKSTATEMENTTEXT });

            // Set Task list property for external use
            TaskStatementList = orderedItems;

            if (TaskListBox != null)
            {
                TaskListBox.Items.Clear();

                ControlUtility.BindRadListBoxControlWithBackground(TaskListBox, TaskStatementList, null, "TaskStatement", "TaskStatementID", "<<-- Select Task Statement -->>");
            }

        }

        protected void imgsrchBttn_Click(object sender, ImageClickEventArgs e)
        {
            bool blnvisible = spanright.Visible;
            spanright.Visible = !blnvisible;

            if (TSSearchClickGlass != null) TSSearchClickGlass(sender, e);
        }

    }

}
