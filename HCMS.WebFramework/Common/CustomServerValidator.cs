using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace HCMS.WebFramework.Common
{
    public class CustomServerValidator : IValidator
    {
        private string errorMessage;

        public CustomServerValidator(string errorMessage)
        {
            this.errorMessage = errorMessage;
        }

        #region IValidator Members
        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
            set
            {
                throw new NotSupportedException();
            }
        }
        public bool IsValid
        {
            get
            {
                return false;
            }
            set
            {
                throw new NotSupportedException();
            }
        }
        public void Validate()
        {
        }
        #endregion
    }
}
