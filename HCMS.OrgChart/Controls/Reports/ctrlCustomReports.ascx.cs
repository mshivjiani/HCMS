using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.Business.Lookups.Collections;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.Lookups;
using Telerik.Web.UI;
using System.Data;
using HCMS.Business.OrganizationChart;
using HCMS.WebFramework.Site.Utilities;
using HCMS.Business.OrganizationChart.Positions;
using HCMS.Business.OrganizationChart.Positions.Collections;
using HCMS.Business.Admin.Workforce;
using System.Web.UI.HtmlControls;
namespace HCMS.OrgChart.Controls.Reports
{
    public partial class ctrlCustomReports : OrgChartUserControlBase 
    {
        private enum enumOrgFormat : int
        {
            Null = -1,
            Old = 1,
            New = 2
        }
        private OrganizationCodeCollection OrgList
        {
            get
            {
                if (ViewState["OrgList"] == null)
                    ViewState["OrgList"] = new OrganizationCodeCollection ();

                return (OrganizationCodeCollection )ViewState["OrgList"];
            }
            set { ViewState["OrgList"] = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

            toggleReportsWithPhoneNumbers();
            if (!IsPostBack)
            {
                LoadOrganizationCode();
                
            }
        }
        protected void rdOrgCode_Changed(object sender, EventArgs e)
        {

            LoadOrganizationCode();

        }
       

        private void LoadOrganizationCode()
        {
            rcbOrganizationCode.Items.Clear();
            OrganizationCodeCollection orgCodeColl = CurrentUser.GetAssignedActiveOrganizationCodes();
            enumOrgFormat format = enumOrgFormat.New;
            if (rdOrgCode.SelectedIndex > -1)
            {
                string strformat = rdOrgCode.SelectedValue;
                Enum.TryParse<enumOrgFormat>(strformat, true, out format);
            }
            if (format == enumOrgFormat.New)
            {
                ControlUtility.BindRadComboBoxControl(rcbOrganizationCode, orgCodeColl, null, "NewOrgCodeLine", "OrganizationCodeID", "<<--Select Organization -->>");
            }
            else
            {
                ControlUtility.BindRadComboBoxControl(rcbOrganizationCode, orgCodeColl, null, "OldOrgCodeLine", "OrganizationCodeID", "<<--Select Organization -->>");
            }
            
      
        }
       

        private void toggleReportsWithPhoneNumbers()
        {
            if (base.CanViewReportsWithPhoneNumber(false))
            {
                trExecPh.Visible = true;
                trRegionalPh.Visible = true;
            }
            else
            {
                trExecPh.Visible = false;
                trRegionalPh.Visible = false;
            }
        }
    
        private void ResetchkDataElements()
        {
            foreach (ListItem item in chkDataElements.Items)
            {
                bool skipitem=false;
                skipitem = (string.Compare(item.Value, "FirstName", true) == 0 || string.Compare(item.Value, "LastName", true) == 0
                    || string.Compare(item.Value, "OrganizationCode", true) == 0);

                if (!skipitem)
                {
                    item.Selected = false;
                }
                
            }
        }
        private void ResetchkChildOrgCode()
        {
            chkChilldOrgCode.Checked = false;
            chkChilldOrgCode.Enabled = false;
        }
      

        protected void rcbOrganizationCode_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            int OrgCodeID = int.Parse(rcbOrganizationCode.SelectedValue);
            if (OrgCodeID > 0)
            {
                chkChilldOrgCode.Enabled = true;

            }
            else
            {
                chkChilldOrgCode.Enabled = false;
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {

            try
            {
                //Export to excel from this dtPositions table.
                DataTable dtPositions = new DataTable();
                if (rcbOrganizationCode.SelectedIndex > 0)
                {
                    int OrgCodeID = int.Parse(rcbOrganizationCode.SelectedValue);
                    bool includechildorgpositions = chkChilldOrgCode.Checked;
                    bool includevacantpositions = chkIncludeVacant.Checked;
                    ListItemCollection selecteditemlist = new ListItemCollection();
                    foreach (ListItem item in chkDataElements.Items )
                    {
                        if (item.Selected)
                        {
                            selecteditemlist.Add(item);
                        }
                    }
                    WorkforcePlanningPositionCollection listPositions = WorkforcePlanningPositionManager.Instance.GetPositionsByOrganizationCode(OrgCodeID, includechildorgpositions, includevacantpositions);
                    dtPositions = ControlUtility.ConvertToDataTable<WorkforcePlanningPosition>(listPositions);
                    //Issue: 3562: Custom Report: FPL Grade shows as -1 for vacancies 
                    if (dtPositions.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtPositions.Rows)
                        {
                            int fpl = int.Parse (dr["FPLGrade"].ToString());
                            if (fpl < 0)
                            {
                                dr["FPLGrade"] = System.DBNull.Value ;
                            }

                        }
                    }
                    DataTable dtFinal = new DataTable();
                    dtFinal = dtPositions.Copy();
                    foreach (DataColumn dc in dtPositions.Columns  )
                    {

                        string colname = dc.ColumnName;
                        ListItem item = selecteditemlist.FindByValue(colname);
                        if (item ==null)
                        {
                            dtFinal.Columns.Remove(colname);
                            dtFinal.AcceptChanges();
                        }
                        
                    }
               
                    Session["OrgPositions"] = dtFinal;
                    Session["CustomReportsOrg"] = rcbOrganizationCode.Text;
                    base.SafeRedirect("~/Reports/OrgChartCustomReportExport.aspx");
                    
                }
            }
            catch (Exception ex)
            {
                base.PrintErrorMessage(ex.Message,true );
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            rdOrgCode.SelectedIndex = 0;
            LoadOrganizationCode();
            ResetchkChildOrgCode();
            ResetchkDataElements();
            chkIncludeVacant.Checked = false;
            chkAll.Checked = false;

        }
        
    }
}