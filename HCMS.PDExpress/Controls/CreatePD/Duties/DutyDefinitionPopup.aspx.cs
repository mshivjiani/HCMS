using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.Business.Lookups;
using HCMS.WebFramework.Site.Utilities;

namespace HCMS.PDExpress.Controls.CreatePD.Duties
{
    public partial class DutyDefinitionPopup : System.Web.UI.Page
    {
        #region [ Page Event Handlers ]
        protected void Page_Load(object sender, EventArgs e)
        {
            Series series = new Series(JobSeriesID);

            lblJobSeriesName.Text = series.SeriesName;
            ControlUtility.SafeTextBoxAssign(tbDefinition, series.SeriesOccupationalInformation);
        }
        #endregion

        #region [ Private Properties ]
        private int JobSeriesID
        {
            get
            {
                string JobSeriesIDParam = Request.QueryString["jobSeriesID"];

                if (String.IsNullOrEmpty(JobSeriesIDParam))
                    return 0;
                else
                    return int.Parse(JobSeriesIDParam);
            }
        }
        #endregion
    }
}
