using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BaseControls;

namespace HCMS.OrgChart.Controls.Common
{
    public partial class errorMessage : UserControlBase
    {
        private string _errorMessage = string.Empty;

        /// <summary>
        /// This control does not use view state -- intentionally
        /// </summary>
        public string ErrorMessage
        {
            get
            {
                return this._errorMessage;
            }
            set
            {
                this._errorMessage = value;
            }
        }

        protected override void OnPreRender(EventArgs e)
        {
            try
            {
                this.divMessage.Visible = !string.IsNullOrWhiteSpace(this.ErrorMessage);
                this.literalSystemMessage.Text = this.ErrorMessage;
            }
            catch (Exception ex)
            {
                this.divMessage.Visible = false;
                base.HandleException(ex);
            }
            base.OnPreRender(e);
        }
    }
}