using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCMS.PDExpress.Controls.Message
{
    public partial class Message : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void SetMessage()
        {
            SetMessage(String.Empty, String.Empty);
        }
        public void SetMessage(string title, string message)
        {
            if (!String.IsNullOrEmpty(title) && !String.IsNullOrEmpty(message))
            {
                divMessage.Attributes.Add("class", "visibleMessage");

                lblTitle.Text = title;
                lblMessage.Text = message;
            }
            else
            {
                divMessage.Attributes.Add("class", "hiddenMessage");
            }

            updtpnlMessage.Update();
        }
    }
}