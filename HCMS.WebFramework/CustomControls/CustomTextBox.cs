using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using Telerik.Web.UI.Editor.Diff;
using System.ComponentModel;
using System.Web.UI;


namespace HCMS.WebFramework.CustomControls
{
   
        [ToolboxData("<{0}:customtext runat=\"server\"> </{0}:customtext>")]
        public class CustomTextBox : TextBox
        {
            private string _oldValue = string.Empty;
            private string _diffcontent = string.Empty;
            public CustomTextBox()
            {
                _oldValue = this.Text;
            }

            public string OldValue
            {
                get
                {
                    if (ViewState["OldValue"] != null)
                    {
                        _oldValue = ViewState["OldValue"].ToString();
                    }
                    return _oldValue;

                }
                set { ViewState["OldValue"] = value; }
            }

            public string DiffContent
            {
                get
                {
                    if (ViewState["DiffContent"] != null)
                    {
                        _diffcontent = ViewState["DiffContent"].ToString();
                    }
                    return _diffcontent;
                }
                set { ViewState["DiffContent"] = value; }
            }


            public void Compare()
            {
                DiffEngine diff = new DiffEngine();
                DiffContent = diff.GetDiffs(this.Text, this.OldValue);

            }



        }

    
}
