using System;
using System.ComponentModel;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using HCMS.Business.Lookups;

namespace HCMS.PDExpress.Controls.ToolTip
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
            HCMS.Business.Lookups.ToolTip toolTip = formView.DataItem as HCMS.Business.Lookups.ToolTip;

            if (toolTip != null)
            {
                RadToolTip1.Title = toolTip.ToolTipCaption;
                RadToolTip1.Text = toolTip.ToolTipDescription;
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