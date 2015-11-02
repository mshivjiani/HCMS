using System;
using System.ComponentModel;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace HCMS.PDExpress.Controls.ProgressBar
{
    public partial class ProgressBar : System.Web.UI.UserControl
    //public partial class ProgressBar : System.Web.UI.WebControls.WebControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string strProgressBarHtml = String.Empty;

            switch (BarStyle.ToLower())
            {
                case "html":
                    strProgressBarHtml = BuildProgressBarHtmlTable();
                    break;
                case "ie":
                case "classic":
                    strProgressBarHtml = BuildProgressBarChunked();
                    break;
                default:
                    strProgressBarHtml = BuildProgressBarSmooth();
                    break;
            }

            litProgressBar.Text = strProgressBarHtml;
        }

        private string BuildProgressBarHtmlTable()
        {
            int intBarLength;
            StringBuilder sbDisplayHtml = new StringBuilder();

            if (0 <= PercentComplete && PercentComplete <= 100)
            {
                intBarLength = BarWidth - 4;

			    sbDisplayHtml.Append("<table border=\"1\" cellspacing=\"0\" cellpadding=\"0\"><tr><td>");
			    sbDisplayHtml.Append("<table width=\"" + intBarLength.ToString() + "\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
                sbDisplayHtml.Append("<tr><td width=\"" + System.Math.Round(PercentComplete * intBarLength / 100).ToString() + "\" style=\"background-color:#0000FF\">&nbsp;</td><td>&nbsp;</td></tr>");
			    sbDisplayHtml.Append("</table>");
			    sbDisplayHtml.Append("</td></tr></table>");
            }

            return sbDisplayHtml.ToString();
        }
        private string BuildProgressBarChunked()
        {
            throw new NotImplementedException();
        }
        private string BuildProgressBarSmooth()
        {
            // UserControl does not have this property
            //Unit www = this.Width;

            string strImageBaseName = Page.ResolveUrl("~/Controls/ProgressBar/images/");
		    short intImageHeight;
		    short intImageLeftWidth;
		    short intImageRightWidth;
		    int intBarLength;
		    StringBuilder sbDisplayHtml = new StringBuilder();

            switch (BarStyle.ToLower())
            {
                case "bluegrey":
				    
                    strImageBaseName += "progress_bluegrey_";                  

				    intImageHeight = 16;
				    intImageLeftWidth = 3;
				    intImageRightWidth = 3;
                    break;
                default: //"ieesque"
                   
                    strImageBaseName += "progress_ie7_";
                    
                    intImageHeight = 17;
				    intImageLeftWidth = 4;
				    intImageRightWidth = 4;
                    break;
            }

            if (0 <= PercentComplete && PercentComplete <= 100)
            {
                // Compensate for the width of the two end images
                intBarLength = BarWidth - (intImageLeftWidth + intImageRightWidth);

			    sbDisplayHtml.Append("<img src=\"" + strImageBaseName + "left.gif\"  border=\"0\" height=\"" + intImageHeight + "\" width=\"" + intImageLeftWidth + "\" />");
                sbDisplayHtml.Append("<img src=\"" + strImageBaseName + "full.gif\"  border=\"0\" height=\"" + intImageHeight + "\" width=\"" + System.Math.Round(PercentComplete * intBarLength / 100) + "\" alt=\"" + PercentComplete + "%\" />");
                sbDisplayHtml.Append("<img src=\"" + strImageBaseName + "empty.gif\" border=\"0\" height=\"" + intImageHeight + "\" width=\"" + (intBarLength - System.Math.Round(PercentComplete * intBarLength / 100)) + "\" alt=\"" + (100 - PercentComplete) + "%\" />");
                sbDisplayHtml.Append("<img src=\"" + strImageBaseName + "right.gif\" border=\"0\" height=\"" + intImageHeight + "\" width=\"" + intImageRightWidth + "\" />");
            }

		    return sbDisplayHtml.ToString();
        }

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

        [
           Bindable(false),
           Category("Appearance"),
           Description("Progress bar style."),
           DefaultValue(""),
           Localizable(true)
        ]
        public string BarStyle
        {
            get;
            set;
        }

        [
           Bindable(false),
           Category("Appearance"),
           Description("Progress bar width."),
           DefaultValue(""),
           Localizable(true)
        ]
        public short BarWidth
        {
            get;
            set;
        }
        #endregion
    }
}