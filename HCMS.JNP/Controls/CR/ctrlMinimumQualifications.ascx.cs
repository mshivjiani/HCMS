using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.Lookups;
using HCMS.Business.CR;

namespace HCMS.JNP.Controls.CR
{
    public partial class ctrlMinimumQualifications : JNPUserControlBase
    {        
        
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
        private int TypeOfWorkID
        {
            get
            {
                if (ViewState["TypeOfWorkID"] == null)
                {
                    string TypeOfWorkIDParam = Request.QueryString["TypeOfWorkID"];

                    if (String.IsNullOrEmpty(TypeOfWorkIDParam))
                        ViewState["TypeOfWorkID"] = -1;
                    else
                        ViewState["TypeOfWorkID"] = int.Parse(TypeOfWorkIDParam);
                }
                return (int)ViewState["TypeOfWorkID"];
            }
            set
            {
                ViewState["TypeOfWorkID"] = value;
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
        private eMode CurrentMode
        {
            get
            {
                if (ViewState["CurrentMode"] == null)
                {
                    string currentMode = Request.QueryString["Mode"];
                    if (string.IsNullOrEmpty(currentMode) || currentMode.Equals("View"))
                    {
                        ViewState["CurrentMode"] = eMode.View;
                    }
                    else
                    {
                        if (currentMode.Equals("Insert"))
                        {
                            ViewState["CurrentMode"] = eMode.Insert;
                        }
                        else
                        {
                            ViewState["CurrentMode"] = eMode.Edit;
                        }

                    }
                }
                return (eMode)ViewState["CurrentMode"];
            }
            set { ViewState["CurrentMode"] = value; }
        }
        #endregion

        #region Methods


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
        protected void btnCancel_Click(object sender, EventArgs e)
        {


            switch (this.CurrentMode)
            {
                case eMode.None:
                    break;
                case eMode.Edit:
                    base.CurrentNavMode = enumNavigationMode.Edit;
                    break;
                case eMode.Insert:
                    base.CurrentNavMode = enumNavigationMode.Insert;
                    break;

                default:
                    break;
            }

            string script = string.Empty;
            script = string.Format("MinimumQualificationClose();");
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", script, true);

        }

        private void LoadData()
        {
            switch (this.CurrentMode)
            {
                case eMode.None:
                    break;
                case eMode.View:
                    base.CurrentNavMode = enumNavigationMode.View;
                    break;
                case eMode.Edit:
                    base.CurrentNavMode = enumNavigationMode.Edit;
                    break;
                case eMode.Insert:
                    base.CurrentNavMode = enumNavigationMode.Insert;
                    break;         
                default:
                    break;
            }
            Series series = new Series(SeriesID);
            lblHeader.Text = "Series: " + series.DetailLine + "   Grade:" + GradeID;           
            lMinQualText.Text = GetMinimumQualification();
            lMinQualText.ReadOnly = true;
           
        }
        private string GetMinimumQualification()
        {
            return CategoryRatingManager.GetMinimumQualification(TypeOfWorkID, GradeID);
        }

        #endregion

       
    }
}