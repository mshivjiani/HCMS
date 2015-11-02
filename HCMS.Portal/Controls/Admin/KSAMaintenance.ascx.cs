using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;
using HCMS.Business.Lookups;
using HCMS.WebFramework.BaseControls;
using System.Data;

namespace HCMS.Portal.Controls.Admin
{
    public partial class KSAMaintenance : UserControlBase
    {

        private enum enumSearchType
        {
            Default = 0,
            ByID = 1,
            Advanced = 2

        } 

        private enumSearchType CurrentSearchType
        {
            get
            {
                enumSearchType _currentSearchType = enumSearchType.Default;
                if (ViewState["CurrentSearchType"] != null)
                {
                    _currentSearchType = (enumSearchType)ViewState["CurrentSearchType"];
                }

                return _currentSearchType;
            }
            set
            {
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
                    long KSAID = Convert.ToInt64(txtExistingKSAID.Text);
                    //DataTable dt2 = HCMS.Business.Lookups.KSA.SearchKSAByAdmin(KSAID, null, null, "");
                    //rgKSA.DataSource = dt2.Select(null, "KSAID ASC");

                    //KSA is pulled from static data table from KSA.cs instead of from db everytime it pulls for search by KSA ID.
                    DataTable dt2;
                    dt2 = HCMS.Business.Lookups.KSA.staticKSA;
                    rgKSA.DataSource = dt2 != null ? dt2.Select("KSAID=" + KSAID) : HCMS.Business.Lookups.KSA.SearchKSAByAdmin(KSAID, null, null, "").Select("KSAID=" + KSAID);
                     
                    break;
                case enumSearchType.Advanced:
                    int seriesid = Convert.ToInt32(rcbSeries.SelectedValue);
                    int gradeid = Convert.ToInt32(rcbGrade.SelectedValue);
                    string keyword = this.txtKeyword.Text;
                    
                    //DataTable dtAdvanced = HCMS.Business.Lookups.KSA.SearchKSAByAdmin(null, seriesid, gradeid, keyword);
                    //rgKSA.DataSource = dtAdvanced;

                    if (HCMS.Business.Lookups.KSA.dtStaticKSAdv == null)
                        HCMS.Business.Lookups.KSA.SearchKSAByAdmin(null, null, null, "");

                    if ((seriesid == -1) && (gradeid == -1))
                        rgKSA.DataSource = HCMS.Business.Lookups.KSA.dtStaticKSAdv.Select("KSAText like '%" + keyword + "%'");
                    else if (seriesid == -1)
                        rgKSA.DataSource = HCMS.Business.Lookups.KSA.dtStaticKSAdv.Select("Grade=" + gradeid + " AND KSAText like '%" + keyword + "%'");
                    else if (gradeid == -1)
                        rgKSA.DataSource = HCMS.Business.Lookups.KSA.dtStaticKSAdv.Select("SeriesID=" + seriesid + " AND KSAText like '%" + keyword + "%'");
                    else
                        rgKSA.DataSource = HCMS.Business.Lookups.KSA.dtStaticKSAdv.Select("SeriesID=" + seriesid + " AND Grade=" + gradeid + " AND KSAText like '%" + keyword + "%'");

                    break;
                case enumSearchType.Default:
                default:
                    int start = 0;
                    int max = HCMS.Business.Lookups.KSA.SelectKSATotalCount(start, -1);

                    //DataTable dt = HCMS.Business.Lookups.KSA.GetKSAPaged(start, max,true);
                    //rgKSA.DataSource = dt.Select(null, "KSAID ASC");

                    DataTable staticKS = HCMS.Business.Lookups.KSA.staticKSA;
                    rgKSA.DataSource = staticKS != null ? staticKS.Select(null, "KSAID ASC") : HCMS.Business.Lookups.KSA.GetKSAPaged(start, max, true).Select(null, "KSAID ASC");
                    
                    break;
            }
        }

        private void AddKSA(object source, GridCommandEventArgs e)
        {
            GridEditableItem gridItem = e.Item as GridEditableItem;
            RadTextBox ts = gridItem.FindControl("rtbKSAText") as RadTextBox;
            CheckBox chk = gridItem.FindControl("chkActive") as CheckBox;

            KSA.AddKSA(-1, ts.Text, Convert.ToBoolean(chk.Checked));

            //Added to hold in static KS table and reload
            int start = 0;
            int max = HCMS.Business.Lookups.KSA.SelectKSATotalCount(start, -1);
            HCMS.Business.Lookups.KSA.GetKSAPaged(start, max, true);

            this.rgKSA.Rebind();
        }

        private void UpdateKSA(object source, GridCommandEventArgs e)
        {
            GridEditableItem gridItem = e.Item as GridEditableItem;
            RadTextBox ts = gridItem.FindControl("rtbKSAText") as RadTextBox;
            CheckBox chk = gridItem.FindControl("chkActive") as CheckBox;

            long ksaID = long.Parse(gridItem.GetDataKeyValue("KSAID").ToString());

            KSA.UpdateKSA(ksaID, ts.Text, chk.Checked);

            //Added to hold in static KS table and reload
            int start = 0;
            int max = HCMS.Business.Lookups.KSA.SelectKSATotalCount(start, -1);
            HCMS.Business.Lookups.KSA.GetKSAPaged(start, max, true);

            this.rgKSA.Rebind();
        }
        protected void rgKSA_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {

            LoadData();
         
        }
        protected void rgKSA_ItemCommand(object sender, GridCommandEventArgs e)
        {
            RadWindowManager1.Windows.Clear();
            RadGrid rgAction = sender as RadGrid;
       

            switch (e.CommandName)
            {
                case RadGrid.InitInsertCommandName:
       
                    break;
                case RadGrid.EditCommandName:
                    break;
                case RadGrid.PerformInsertCommandName:
                    AddKSA(sender, e);
                    break;
                case RadGrid.UpdateCommandName:
                    UpdateKSA(sender, e); 
                    break;

                default:
                    rgKSA.ShowHeader = true;
                    break;
            }
        }     
       
        protected void rgKSA_ItemDataBound(object sender, GridItemEventArgs e)
        {

            KSA ksa = e.Item.DataItem as KSA;
            CheckBox chk = e.Item.FindControl("chkActive") as CheckBox;
            if (e.Item is GridDataItem)
            {          
                if (chk != null)
                {
                    chk.Checked = Convert.ToBoolean(ksa.Active);
                    chk.Enabled = false;
                }
            }
            else if (e.Item is GridEditableItem && e.Item.IsInEditMode)
            {
                if (chk != null && ksa !=null)
                {
                    chk.Checked = Convert.ToBoolean(ksa.Active);
                }
            }
        }

       
        protected void btnExistingKSASearch_Click(object source, EventArgs e)
        {
            //rgKSA.Rebind();

            CurrentSearchType = enumSearchType.ByID;
            rgKSA.Rebind();
           
        }

        protected void btnExistingKSAClear_Click(object source, EventArgs e)
        {
            //this.txtExistingKSAID.Text = "";
            //rgKSA.Rebind();

            this.txtExistingKSAID.Text = "";
            CurrentSearchType = enumSearchType.Default;
            rgKSA.Rebind();
        }

        protected void btnAdvancedSearch_Click(object sender, EventArgs e)
        {
            CurrentSearchType = enumSearchType.Advanced;
            rgKSA.Rebind();
        }

    }
}