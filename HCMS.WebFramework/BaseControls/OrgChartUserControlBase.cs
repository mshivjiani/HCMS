using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using HCMS.Business.OrganizationChart;
using HCMS.WebFramework.Site.Utilities;
using HCMS.Business.OrganizationChart.Positions;
using HCMS.WebFramework.Site.Sessions;
using HCMS.Business.OrganizationChart.Published;

namespace HCMS.WebFramework.BaseControls
{
    public abstract class OrgChartUserControlBase : UserControlBase
    {
        const string CURRENTORGCHARTID = "CurrentOrgChartID";
        private const string CURRENTORGCHARTNAVMODE = "CurrentOrgChartNavMode";
        protected const string CURRENTORGCHART = "CurrentOrgChart";

        #region Organization Chart Log Methods

        protected OrganizationChartLog CurrentOrgChartLog
        {
            get
            {
                return OrganizationChartLogSessionWrapper.CurrentOrgChartLog;
            }
        }

        protected int CurrentOrgChartLogID
        {
            get
            {
                return OrganizationChartLogSessionWrapper.CurrentOrgChartLogID;
            }
        }

        protected void ClearCurrentOrgChartLog()
        {
            OrganizationChartLogSessionWrapper.ClearCurrentOrgChartLog();
        }

        protected void ResetCurrentOrgChartLog(int organizationChartLogID)
        {
            OrganizationChartLogSessionWrapper.ResetCurrentOrgChartLog(organizationChartLogID);
        }

        public void RefreshOrgChartLogDataOnly()
        {
            OrganizationChartLogSessionWrapper.RefreshOrgChartLogDataOnly();
        }

        #endregion

        #region Organization Chart Methods

        protected OrganizationChart CurrentOrgChart
        {
            get
            {
                return SiteUtility.CurrentOrgChart;
            }
        }

        protected int CurrentOrgChartID
        {
            get
            {
                int orgchartid = -1;

                if (Session[CURRENTORGCHARTID] != null)
                {
                    orgchartid = (int)Session[CURRENTORGCHARTID];
                }

                return orgchartid;
            }
            set
            {
                Session[CURRENTORGCHARTID] = value;

            }
        }

        protected void FinishEditOrgChart(int OrganizationChartID, int UserID)
        {
            ClearCurrentOrgChart();
            OrganizationChartManager.Instance.Check(OrganizationChartID, UserID, enumActionType.CheckIn);
        }

        protected void DeleteOrgChart(int OrganizationChartID)
        {
            ClearCurrentOrgChart();
            OrganizationChartManager.Instance.Delete(OrganizationChartID);
        }

        protected void ExportToExcel(int OrganizationChartID)
        {
            ClearCurrentOrgChart();

            DataTable dt = new DataTable();

            dt = OrganizationChartPositionManager.Instance.GetOrganizationChartPositionsData(OrganizationChartID);

            Session["OrgChartPositions"] = dt;
            Session["xlOrgChartID"] = OrganizationChartID;
            base.SafeRedirect("~/Search/OrgChartExport.aspx");
        }

        protected enumNavigationMode CurrentOrgChartNavMode
        {
            get
            {
                enumNavigationMode currentNavMode = enumNavigationMode.None;
                if (Session[CURRENTORGCHARTNAVMODE] == null)
                {
                    Session[CURRENTORGCHARTNAVMODE] = enumNavigationMode.View;
                }
                currentNavMode = (enumNavigationMode)Session[CURRENTORGCHARTNAVMODE];
                return currentNavMode;
            }
            set
            {
                if (value == enumNavigationMode.None)
                {
                    Session[CURRENTORGCHARTNAVMODE] = null;
                }
                else
                {
                    Session[CURRENTORGCHARTNAVMODE] = value;
                }
            }
        }

        protected void ClearCurrentOrgChart()
        {
            Session[CURRENTORGCHARTID] = null;
            Session[CURRENTORGCHARTNAVMODE] = null;
            Session[CURRENTORGCHART] = null;
        }

        protected void ResetCurrentOrgChart(int OrganizationChartID)
        {
            ClearCurrentOrgChart();
            CurrentOrgChartID = OrganizationChartID;
        }

        protected void RefreshOrgChartDataOnly()
        {
            int tempChartID = this.CurrentOrgChartID;
            Session[CURRENTORGCHART] = OrganizationChartManager.Instance.GetByID(tempChartID);
        }

        #endregion

        #region Redirect Links

        protected void GoToOrgChartLink(string newLink, enumNavigationMode currentMode)
        {
            CurrentOrgChartNavMode = currentMode;

            this.SafeRedirect(newLink);
        }
        
        protected void GoToOrgChartTracker()
        {
            base.SafeRedirect("~/Tracker/OrgChartTracker.aspx");
        }

        #endregion
    }
}
