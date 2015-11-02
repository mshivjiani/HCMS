using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BaseControls;
using Telerik.Web.UI;
using HCMS.Lookups;
using HCMS.Business.Lookups;
using HCMS.WebFramework.Site.Utilities;

namespace HCMS.Portal.Controls.Admin
{
    public partial class ctrlAddSeriesGradeKSATaskStatement : UserControlBase
    {
        #region Events/Delegates

        public delegate void AddSeriesGradeKSATaskStatementHandler();
        public event AddSeriesGradeKSATaskStatementHandler AddSeriesGradeKSATaskStatementClick;

        #endregion
        
        #region Properties
       
        private int SeriesID
        {
            get
            {
                if (ViewState["SeriesID"] == null)
                {
                    string SeriesIDParam = Request.QueryString["SeriesId"];

                    if (String.IsNullOrEmpty(SeriesIDParam))
                        ViewState["SeriesID"] = -1;
                    else
                        ViewState["SeriesID"] = int.Parse(SeriesIDParam);
                }
                return (int)ViewState["SeriesID"];
            }
            set
            {
                ViewState["SeriesID"] = value;
            }
        }  
        private int GradeID
        {
            get
            {
                if (ViewState["GradeID"] == null)
                {
                    string GradeIDParam = Request.QueryString["GradeId"];

                    if (String.IsNullOrEmpty(GradeIDParam))
                        ViewState["GradeID"] = -1;
                    else
                        ViewState["GradeID"] = int.Parse(GradeIDParam);
                }
                return (int)ViewState["GradeID"];
            }
            set
            {
                ViewState["GradeID"] = value;
            }
        }
        #endregion
        
        #region Methods
        protected override void OnInit(EventArgs e)
        {
            ddlKSAs.AllowCustomText = true;
            ddlKSAs.MarkFirstMatch = true;

            ddlTaskStatement.AllowCustomText = true;
            ddlTaskStatement.MarkFirstMatch = true;

            this.ddlKSAs.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(ddlKSAs_SelectedIndexChanged);
            this.btnSave.Click += new EventHandler(btnSave_Click);
            this.btnCancel.Click += new EventHandler(btnCancel_Click);
            base.OnInit(e);
        }   
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    LoadData();
                }

                base.OnLoad(e);

            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }   
        private void LoadData()
        {
            Series series = new Series(SeriesID);
            lblSeriesGradeKSATSHeader.Text = "Add New KSA Task Statement for Series: " + series.SeriesName + " And Grade: " + GradeID.ToString();
            LoadKSAs();
        }            
        public void BindData(int seriesId, int gradeId)
        {
            this.SeriesID = seriesId;
            this.GradeID = gradeId;
        }
        private void LoadKSAs()
        {
            List<KSA> lstKSAs = LookupManager.GetAllKSA();
            ControlUtility.BindRadComboBoxControl(ddlKSAs, lstKSAs, null, "KSAText", "KSAID", "");
        } 
        private void LoadTaskStatements()
        {

            List<TaskStatement> lstTaskStatements = LookupManager.GetAllTaskStatementsNotInSeriesGradeKSA(SeriesID, GradeID, Convert.ToInt32(ddlKSAs.SelectedValue));
            ControlUtility.BindRadComboBoxControl(ddlTaskStatement, lstTaskStatements, null, "TaskStatementText", "TaskStatementID", "");

        }
        protected void AddSeriesGradeKSATaskStatement(HCMS.Business.Series.SeriesGradeKSATaskStatement seriesGradeKSATaskStatement)
        {
            bool success = HCMS.Business.Admin.SeriesGradeKSATaskStatement.Add(seriesGradeKSATaskStatement);
            if (success == true)
            {
                lblmsg.Text = "Series Grade KSA Task Statement added successfully.";
                LoadTaskStatements();
            }
            else
            {
                base.PrintErrorMessage("Series Grade KSA Task Statement insertion failed.", false);
            }
        }
        #endregion

        #region Events
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                HCMS.Business.Series.SeriesGradeKSATaskStatement seriesGradeKSATaskStatement = new HCMS.Business.Series.SeriesGradeKSATaskStatement();

                if (SeriesID > 0)
                    seriesGradeKSATaskStatement.SeriesID = SeriesID;

                if (GradeID > 0)
                    seriesGradeKSATaskStatement.Grade = GradeID;
                
                if (!String.IsNullOrEmpty(ddlKSAs.SelectedValue))
                    seriesGradeKSATaskStatement.KSAID = Convert.ToInt32(ddlKSAs.SelectedValue);

                if (!String.IsNullOrEmpty(ddlTaskStatement.SelectedValue))
                    seriesGradeKSATaskStatement.TaskStatementID = Convert.ToInt32(ddlTaskStatement.SelectedValue);

                if (seriesGradeKSATaskStatement.SeriesID > 0
                           && seriesGradeKSATaskStatement.Grade > 0
                           && seriesGradeKSATaskStatement.KSAID > 0
                           && seriesGradeKSATaskStatement.TaskStatementID > 0)
                {
                    AddSeriesGradeKSATaskStatement(seriesGradeKSATaskStatement);

                    if (AddSeriesGradeKSATaskStatementClick != null)
                        AddSeriesGradeKSATaskStatementClick();
                }

            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string script = string.Empty;
            script = string.Format("AddSeriesGradeKSATSClose();");
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
            if (AddSeriesGradeKSATaskStatementClick != null)
                AddSeriesGradeKSATaskStatementClick();
        }
        protected void ddlKSAs_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTaskStatements();
        }
        protected void ddlKSAs_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
        {
            e.Item.Text = string.Concat(e.Item.Text);
        }       
        protected void ddlTaskStatement_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
        {
            e.Item.Text = string.Concat(e.Item.Text);
        }
        #endregion
    }
}