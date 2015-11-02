using System;
using System.ComponentModel;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using HCMS.Business.PD;
using HCMS.Business.Base;
using HCMS.Business.Common;
using HCMS.Business.Search;
using HCMS.Business.Security;
using HCMS.Business.Lookups;

using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;
using HCMS.WebFramework.Common;
using HCMS.WebFramework.Security;

namespace HCMS.PDExpress.Controls.CreatePD
{
    public partial class CreatePDMapStatusProgress : CreatePDUserControlBase
    {
        #region [ Page Event Handlers ]
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateStatusBar();


                if (base.CurrentPDChoice == PDChoiceType.StatementOfDifferencePD)
                {
                    this.SiteMapPath1.SiteMapProvider = "SODSiteMap";
                }
                else if (base.CurrentPDChoice == PDChoiceType.CLStatementOfDifferencePD)
                {
                    this.SiteMapPath1.SiteMapProvider = "CLSODSiteMap";
                }
                else
                {
                    this.SiteMapPath1.SiteMapProvider = "defaultSiteMap";
                }
            }

            PopulateProgressBar();
        }
        #endregion

        #region [ Private Methods ]
        private void PopulateStatusBar()
        {
            if (base.CurrentPD.PositionDescriptionID != NULLPDID)
            {
                if (base.IsPDReadOnly)
                {
                    SetPDReadOnly(0, "the parameter value does ot matter");
                }

                SetPDNumber(base.IsPDReadOnly ? 10 : 0, base.CurrentPD.PositionDescriptionID.ToString());

                //if (base.CurrentPD.PublishedID != -1)
                //{
                //    SetPublishedPDNumber(10, base.CurrentPD.PublishedID.ToString());
                //}

                Series series = new Series(base.CurrentPD.JobSeries);
                SetPayplanSeriesGrade(10, base.CurrentPD.PayPlanAbbrev, series.PaddedSeriesID, series.SeriesName, base.CurrentPD.ProposedGrade.ToString());

                if (base.CurrentPD.IsStandardPD == "Y")
                {
                    SetStandard(10, "Yes");
                }

                if (base.CurrentPD.CopyFromPDID != -1)
                {
                    SetCopiedFrom(10, base.CurrentPD.CopyFromPDID.ToString());
                }

                if (base.CurrentPD.AssociatedFullPD != -1 && base.CurrentPD.AssociatedFullPD != 0)
                {
                    SetFullPerformance(10, base.CurrentPD.AssociatedFullPD.ToString());
                }

                PositionWorkflowStatus status = base.CurrentPD.GetCurrentPositionWorkflowStatus();
                SetStatus(10, status != null ? status.WorkflowStatusName : "Unknown");
            }
            else
            {
                SetPDNumber(0, "Unknown");
            }
        }
        private void PopulateProgressBar()
        {
            ctrlProgressBar.PercentComplete = this.PercentComplete;
        }

        private void SetPDReadOnly(int marginLeft, string text)
        {
            if (String.IsNullOrEmpty(text) == false)
            {
                string innerSpanHtml = String.Format("<span style=\"font-weight:normal;\">{0}</span>", "Read Only");
                string outerSpanHtml = String.Format("<span style=\"margin-left:{0}px; font-family:'segoe ui',arial,sans-serif; font-size:0.95em; font-weight:bolder; color:red;\">{1}</span>", marginLeft, innerSpanHtml);
                spnReadOnly.InnerHtml = outerSpanHtml;
            }
        }
        private void SetPDNumber(int marginLeft, string text)
        {
            if (String.IsNullOrEmpty(text) == false)
            {
                string innerSpanHtml = String.Format("<span style=\"font-weight:normal;\">{0}</span>", text);
                string outerSpanHtml = String.Format("<span style=\"margin-left:{0}px; font-family:'segoe ui',arial,sans-serif; font-size:0.95em; font-weight:bolder;\">PD No. : {1}</span>", marginLeft, innerSpanHtml);
                spnPDNumber.InnerHtml = outerSpanHtml;
            }
        }
        //private void SetPublishedPDNumber(int marginLeft, string text)
        //{
        //    if (String.IsNullOrEmpty(text) == false)
        //    {
        //        string innerSpanHtml = String.Format("<span style=\"font-weight:normal;\">{0}</span>", text);
        //        string outerSpanHtml = String.Format("<span style=\"margin-left:{0}px; font-family:'segoe ui',arial,sans-serif; font-size:0.95em; font-weight:bolder;\">Published PD Number : {1}</span>", marginLeft, innerSpanHtml);
        //        spnPublishedPDNumber.InnerHtml = outerSpanHtml;
        //    }
        //}
        private void SetPayplanSeriesGrade(int marginLeft, string payplan, string series, string seriesName, string grade)
        {
            if (String.IsNullOrEmpty(payplan) == false && String.IsNullOrEmpty(series) == false && String.IsNullOrEmpty(seriesName) == false && String.IsNullOrEmpty(grade) == false)
            {
                string innerSpanHtml = String.Format("<span style=\"font-weight:normal;\">{0}-{1}:{2}-{3}</span>", payplan, series, seriesName, grade);
                string outerSpanHtml = String.Format("<span style=\"margin-left:{0}px; font-family:'segoe ui',arial,sans-serif; font-size:0.95em; font-weight:bolder;\">{1}</span>", marginLeft, innerSpanHtml);
                spnPayplanSeriesGrade.InnerHtml = outerSpanHtml;
            }
        }
        private void SetStatus(int marginLeft, string text)
        {
            if (String.IsNullOrEmpty(text) == false)
            {
                string innerSpanHtml = String.Format("<span style=\"font-weight:normal;\">{0}</span>", text);
                string outerSpanHtml = String.Format("<span style=\"margin-left:{0}px; font-family:'segoe ui',arial,sans-serif; font-size:0.95em; font-weight:bolder;\">Status : {1}</span>", marginLeft, innerSpanHtml);
                spnStatus.InnerHtml = outerSpanHtml;
            }
        }
        private void SetStandard(int marginLeft, string text)
        {
            if (String.IsNullOrEmpty(text) == false)
            {
                string innerSpanHtml = String.Format("<span style=\"font-weight:normal;\">{0}</span>", text);
                string outerSpanHtml = String.Format("<span style=\"margin-left:{0}px; font-family:'segoe ui',arial,sans-serif; font-size:0.95em; font-weight:bolder;\">Is Standard : {1}</span>", marginLeft, innerSpanHtml);
                spnStandard.InnerHtml = outerSpanHtml;
            }
        }
        private void SetCopiedFrom(int marginLeft, string text)
        {
            if (String.IsNullOrEmpty(text) == false)
            {
                string innerSpanHtml = String.Format("<span style=\"font-weight:normal;\">{0}</span>", text);
                string outerSpanHtml = String.Format("<span style=\"margin-left:{0}px; font-family:'segoe ui',arial,sans-serif; font-size:0.95em; font-weight:bolder;\">PD Copied From : {1}</span>", marginLeft, innerSpanHtml);
                spnCopiedFrom.InnerHtml = outerSpanHtml;
            }
        }
        private void SetFullPerformance(int marginLeft, string text)
        {
            if (String.IsNullOrEmpty(text) == false)
            {
                string innerSpanHtml = String.Format("<span style=\"font-weight:normal;\">{0}</span>", text);
                string outerSpanHtml = String.Format("<span style=\"margin-left:{0}px; font-family:'segoe ui',arial,sans-serif; font-size:0.95em; font-weight:bolder;\">Associated Full Performance PD No. : {1}</span>", marginLeft, innerSpanHtml);
                spnFullPerformance.InnerHtml = outerSpanHtml;
            }
        }
        #endregion

        #region [ Public Properties ]
        [
           Bindable(false),
           Category("Appearance"),
           Description("Percent Complete."),
           DefaultValue(""),
           Localizable(true)
        ]
        public Single PercentComplete
        {
            get;
            set;
        }

        //Created this property to be able to set the width for DutyDiff Page with no leftnav bar
        public short ProgressBarWidth
        {
            get
            {
                return this.ctrlProgressBar.BarWidth;
            }
            set
            {
                this.ctrlProgressBar.BarWidth = value;
            }
        }

        public HCMS.PDExpress.Controls.ProgressBar.ProgressBar ProgressBar
        {
            get { return this.ctrlProgressBar; }
        }


        #endregion
    }
}
