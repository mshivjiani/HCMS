using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCMS.WebFramework.Controls.RadGrid
{
    public class NoRecordsTemplate : ITemplate
    {
        private string _message = string.Empty;

        public NoRecordsTemplate(string loadMessage)
        {
            this._message = loadMessage;
        }

        public void InstantiateIn(Control container)
        {
            Literal literalMessage = new Literal();

            literalMessage.ID = "literalNoRecordsMessage1";
            literalMessage.Text = this._message;
            container.Controls.Add(literalMessage);
        }
    }
}
