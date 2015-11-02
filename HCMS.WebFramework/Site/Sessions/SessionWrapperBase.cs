using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMS.WebFramework.Site.Sessions
{
    public abstract class SessionWrapperBase<T>
        where T : new()
    {
        #region Object Declarations

        private static readonly Lazy<T> _instance = new Lazy<T>(() => new T());

        #endregion

        #region Singleton Property

        public static T Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        #endregion
    }
}
