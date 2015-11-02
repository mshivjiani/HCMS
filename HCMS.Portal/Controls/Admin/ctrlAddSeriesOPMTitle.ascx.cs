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
using HCMS.Business.Series;

namespace HCMS.Portal.Controls.Admin
{
    public partial class ctrlAddSeriesOPMTitle : UserControlBase
    {
        SeriesManager seriesMgr = new SeriesManager();

        #region Events/Delegates

        public delegate void AddSeriesGradeKSATaskStatementHandler();
        public event AddSeriesGradeKSATaskStatementHandler AddSeriesGradeKSATaskStatementClick;

        #endregion
        
        #region Properties

        private int CurrentSeriesID
        {
            get
            {
                if (ViewState["CurrentSeriesID"] == null)
                {
                    string SeriesIDParam = Request.QueryString["SeriesId"];

                    if (String.IsNullOrEmpty(SeriesIDParam))
                        ViewState["CurrentSeriesID"] = -1;
                    else
                        ViewState["CurrentSeriesID"] = int.Parse(SeriesIDParam);
                }
                return (int)ViewState["CurrentSeriesID"];
            }
            set
            {
                ViewState["CurrentSeriesID"] = value;
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
            SeriesEntity seriesEntity = seriesMgr.GetSeriesBySeriesID(this.CurrentSeriesID);
            lblSeriesGradeKSATSHeader.Text = "Add New KSA OPM Title for Series: " + seriesEntity.SeriesName;
        }            
        
        public void BindData(int seriesId, int gradeId)
        {
            this.CurrentSeriesID = seriesId;
            this.GradeID = gradeId;
        }
        
        protected void AddSeriesGradeKSATaskStatement(SeriesOPMTitleEntity seriesOPMTitleEntity)
        {

            bool success = seriesMgr.AddOPMTitle(seriesOPMTitleEntity);

            if (success == true)
            {
                lblmsg.Text = "Series OPM Title added successfully.";
            }
            else
            {
                lblmsg.Text = "Series OPM Title insertion failed. Duplicate OPM Titles are not allowed for the same Series";
            }
        }
        #endregion

        #region Events
        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtOPMTitle.Text))
                {

                    SeriesOPMTitleEntity seriesOPMTitleEntity = new SeriesOPMTitleEntity();
                    seriesOPMTitleEntity.SeriesID = this.CurrentSeriesID;
                    seriesOPMTitleEntity.OPMTitle = txtOPMTitle.Text;

                    AddSeriesGradeKSATaskStatement(seriesOPMTitleEntity);

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
            //string script = string.Empty;
            //script = string.Format("AddSeriesOPMTitleClose();");
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);



            string script = string.Empty;
            script = string.Format("AddSeriesOPMTitleClose();");
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);
            if (AddSeriesGradeKSATaskStatementClick != null)
                AddSeriesGradeKSATaskStatementClick();
        }
        #endregion
    }
}