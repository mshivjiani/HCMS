using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BaseControls;

namespace HCMS.OrgChart.Controls.Common
{
    public partial class readOnlyLabel : UserControlBase
    {
        #region Object Declarations

        private string _labelText = string.Empty;

        #endregion

        #region Properties

        public string LabelText
        {
            get
            {
                return this._labelText;
            }
            set
            {
                this._labelText = value;
            }
        }

        #endregion

        protected override void OnPreRender(EventArgs e)
        {
            this.customNoteBox.LabelText = this._labelText;
            base.OnPreRender(e);
        }
    }
}