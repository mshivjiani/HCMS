using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.Lookups;
using HCMS.WebFramework.Site.Utilities;
using Telerik.Web.UI;
using System.Text.RegularExpressions;

namespace HCMS.Portal.Controls.Admin
{
    public partial class ctrlAdminSearchKSA : UserControlBase
    {
        #region Properties
        
        private List<KSAEntity> _ksalist;
        
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
        
        public List<KSAEntity> KSAList
        {
            get { return this._ksalist; }
            set { this._ksalist = value; }
        }
        
        #endregion

        #region Events Delegates
        public delegate void KSAAdminSearchCompletedHandler();
        public event KSAAdminSearchCompletedHandler KSAAdminSearchCompleted;

        public delegate void KSAAdminSearchCancelCompleteHandler();
        public event KSAAdminSearchCancelCompleteHandler KSAAdminSearchCancelCompleted;
        #endregion

        #region methods
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                Series series = new Series(SeriesID);
                string seriesText = string.Format("{0} | {1}", series.SeriesID, series.SeriesName).Trim();
                this.lblCurrentSeries.Text = seriesText;
                this.lblCurrentGrade.Text = CurrentGrade.ToString();

                List<Grade> grades = LookupManager.GetAllGrades();
                grades = grades.Where(p => (p.GradeName != "Other")).ToList();

                this.radKSAComboGrades.DataSource = grades;
                this.radKSAComboGrades.DataBind();
                //this.radKSAComboGrades.SelectedValue = CurrentGrade.ToString();
                //this.radKSAComboGrades.SelectedItem.Checked = true;

                setSearchControl();
                //this.pnlOtherKSA.Visible = false;

                SetKSAHeaderLabel();

            }

        }

        private void SetKSAHeaderLabel()
        {
            string KSAHeaderLabel = string.Empty;
            if (SeriesID > 0)
            {
                KSAHeaderLabel = "Remaining KSA's in Current Series: " + SeriesID;
            }
            
            List<int> selectedgrades = new List<int>();
            foreach (RadComboBoxItem item in radKSAComboGrades.CheckedItems)
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
                KSAHeaderLabel = KSAHeaderLabel + " And Grade(s): " + gradelist;
            }

            if (!String.IsNullOrEmpty(txtKSAKeyword.Text))
            {
                KSAHeaderLabel = KSAHeaderLabel + " And KSA Keyword: " + txtKSAKeyword.Text;
            }


            lblKSAHeader.Text = KSAHeaderLabel;
        }

        private void setSearchControl()
        {
            rgSearchKSA.DataSource = KSAList = GetKSAList().Where(p => (p.KSAText != UserControlBase.OTHERKSATEXT )).ToList();
            rgSearchKSA.DataBind();

        }

        private List<KSAEntity> GetKSAList()
        {
            List<KSAEntity> ksalist = new List<KSAEntity>();
            List<Grade> selectedgrades = new List<Grade>();
            foreach (RadComboBoxItem item in radKSAComboGrades.CheckedItems)
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

            ksalist = KSAEntityManager.GetUnAssociatedKSAEntityList(SeriesID, CurrentGrade, selectedgrades, this.txtKSAKeyword.Text);
            return ksalist;

        }
        #endregion

        #region rgSearchKSA
        protected void rgSearchKSA_InsertCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
        {
            GridEditFormInsertItem insertedItem = (GridEditFormInsertItem)e.Item;
        }
        
        protected void rgSearchKSA_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            rgSearchKSA.DataSource = KSAList = GetKSAList().Where(p => (p.KSAText != UserControlBase.OTHERKSATEXT )).ToList();            
        }

        protected void rgSearchKSA_ItemCommand(object source, GridCommandEventArgs e)
        {
            GridDataItem gridItem;
            int ksaId;
            RadWindowManagerSearchKSA.Windows.Clear();
            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
                    e.Canceled = true;
                    //pnlOtherKSA.Visible = true;

                    break;
                case RadGrid.EditCommandName:
                    e.Canceled = true;
                    gridItem = e.Item as GridDataItem;
                    ksaId = int.Parse(gridItem.GetDataKeyValue("KSAID").ToString());

                    Session["PreviousPage"] = "SearchKSA";
                    Session["KSAID"] = ksaId;
                    Session["SeriesID"] = SeriesID.ToString();
                    Session["CurrentGrade"] = CurrentGrade.ToString();

                    //GoToLink("~/Admin/SearchTaskStatement.aspx?SeriesID=" + SeriesID + "&CurrentGrade=" + CurrentGrade + "&KSAID=" + ksaId + "&PreviousPage=" + "SearchKSA");
                    GoToLink("~/Admin/SearchTaskStatement.aspx");
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region events
        protected void btnSelectTSForNetNewKSA_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNetNewKSADescription.Text))
            {
                string s = txtNetNewKSADescription.Text.Replace("'", "''");

                Session["KSADesc"] = s;
                Session["KSAID"] = "-1";
                Session["SeriesID"] = SeriesID.ToString();
                Session["CurrentGrade"] = CurrentGrade.ToString();

                //GoToLink("~/Admin/SearchTaskStatement.aspx?SeriesID=" + SeriesID + "&CurrentGrade=" + CurrentGrade + "&KSAID=" + -1 + "&KSAText=" + txtNetNewKSADescription.Text);

                GoToLink("~/Admin/SearchTaskStatement.aspx");
            }
            else
            {
                lblNewKSAMsg.Text = "Please enter KSA Description";
            }

        }
        
        protected void btnNetNewKSACancel_Click(object sender, EventArgs e)
        {
            this.txtNetNewKSADescription.Text = "";
            //this.pnlOtherKSA.Visible = false;
            //this.CollapsiblePanelExtender1.Collapsed = true;
            //this.CollapsiblePanelExtender1.ClientState = "true";
        }

        protected void btnSearchKSACancel_Click(object sender, EventArgs e)
        {

            Session["SeriesID"] = SeriesID.ToString();
            Session["CurrentGrade"] = CurrentGrade.ToString();

            //base.GoToLink("~/Admin/KSATaskStatementMaintenance.aspx?SeriesID=" + SeriesID + "&CurrentGrade=" + CurrentGrade);
            base.GoToLink("~/Admin/KSATaskStatementMaintenance.aspx");

        }

        protected void btnKSASearch_Click(object sender, EventArgs e)
        {
            rgSearchKSA.Rebind();

            SetKSAHeaderLabel();

            if (KSAAdminSearchCompleted != null)
                KSAAdminSearchCompleted();

        }

        protected void btnKSAClear_Click(object sender, EventArgs e)
        {
            KSAList = null;
            this.txtKSAKeyword.Text = String.Empty;
            this.radKSAComboGrades.ClearCheckedItems();
            rgSearchKSA.Rebind();
            SetKSAHeaderLabel();
        }
        #endregion
    }
}