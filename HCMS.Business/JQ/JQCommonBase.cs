using System;

using HCMS.Business.Base;

namespace HCMS.Business.JQ
{
    [Serializable]
    public class JQCommonBase : BusinessBase
    {
        #region Object Declarations

        private string _tagName = string.Empty;

        #endregion

        #region Properties

        public string TagName
        {
            get 
            {
                return this._tagName;
            }
            set
            {
                this._tagName = value;
            }
        }

        #endregion
    }
}
