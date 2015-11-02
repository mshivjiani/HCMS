using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace HCMS.OrgChart.Controls.ToolTip
{
    public partial class ToolTip : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ToolTipIDParameter = ToolTipID;
        }

        private string ToolTipIDParameter
        {
            set
            {
                hdnToolTipID.Value = value.ToString();
            }
        }

        #region [ Public Properties ]
        [
           Bindable(false),
           Category("Data"),
           Description("ToolTip ID"),
           DefaultValue(""),
           Localizable(true)
        ]
        public string ToolTipID
        {
            get;
            set;
        }
        #endregion

        protected void ToolTipFormView_DataBound(object sender, EventArgs e)
        {
            FormView formView = sender as FormView;
            HCMS.Business.Lookups.ToolTipEntity toolTip = formView.DataItem as HCMS.Business.Lookups.ToolTipEntity;

            if (toolTip != null)
            {
                RadToolTip1.Title = toolTip.Caption;
                RadToolTip1.Text = toolTip.Description;
            }
        }

        #region public methods
        public void ReloadControl()
        {
            ToolTipIDParameter = ToolTipID;
        }
        #endregion
    }
}