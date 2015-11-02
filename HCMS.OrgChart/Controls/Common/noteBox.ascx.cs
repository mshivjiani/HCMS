using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BaseControls;

namespace HCMS.OrgChart.Controls.Common
{
    public partial class noteBox : UserControlBase
    {
        public enum NoteBoxTypes : int
        {
            Information = 1,
            Warning = 2,
            Exclamation = 3
        }

        #region Object Declarations

        private string _labelText = string.Empty;
        private string _align = "Left";
        private NoteBoxTypes _noteType = NoteBoxTypes.Information;

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

        public string Align
        {
            get
            {
                return this._align;
            }
            set
            {
                this._align = value;
            }
        }

        public NoteBoxTypes NoteType
        {
            get
            {
                return this._noteType;
            }
            set
            {
                this._noteType = value;
            }
        }

        #endregion

        protected override void OnPreRender(EventArgs e)
        {
            this.literalMessage.Text = this._labelText;
            string noteBoxClass = string.Empty;

            if (this._noteType == NoteBoxTypes.Exclamation)
                noteBoxClass = "exclamationBox";
            else if (this._noteType == NoteBoxTypes.Warning)
                noteBoxClass = "warningBox";
            else
                noteBoxClass = "informationBox";

            noteBoxClass += (string.Compare(this._align, "right", true) == 0) ? "Right" : "Left";

            this.divBox.Attributes["class"] = noteBoxClass;
            this.divBox.Visible = !string.IsNullOrWhiteSpace(this._labelText);

            base.OnPreRender(e);
        }
    }
}