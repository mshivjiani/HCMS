using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;

namespace HCMS.WebFramework.Common
{
    public sealed class CachedDataHandler
    {
        #region Private Members

        private static HttpContext current = HttpContext.Current;
        private string _assemblyName = string.Empty;
        private string _fullQualifiedObjectName = string.Empty;

        #endregion

        #region Properties

        public string FullQualifiedObjectName
        {
            get
            {
                return this._fullQualifiedObjectName;
            }
        }

        public string AssemblyName
        {
            get
            {
                return this._assemblyName;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor for the CachedDataHandler
        /// </summary>
        /// <param name="assemblyName">The assembly name to be used for the data handler</param>
        /// <param name="fullyQualifiedObjectName">The fully qualified object name</param>
        public CachedDataHandler(string assemblyName, string fullyQualifiedObjectName)
        {
            this._assemblyName = assemblyName;
            this._fullQualifiedObjectName = fullyQualifiedObjectName;
        }

        #endregion

        #region Cache Handler

        public List<T> GetCachedData<T>(bool reload, string dataMethod, string keyName)
        {
            return GetCachedData<T>(reload, dataMethod, keyName, new object[] { });
        }

        public List<T> GetCachedData<T>(bool reload, string dataMethod, string keyName, params object[] argumentList)
        {
            try
            {
                if (current.Cache[keyName] == null || reload)
                {
                    Assembly bizLibrary = Assembly.Load(this._assemblyName);
                    Type lookupManagerType = bizLibrary.GetType(this._fullQualifiedObjectName);

                    int argumentItemCount = argumentList.GetUpperBound(0);
                    Type[] parameterTypes = new Type[argumentItemCount + 1];

                    for (int i = 0; i <= argumentItemCount; i++)
                        parameterTypes[i] = argumentList[i].GetType();

                    current.Cache[keyName] = lookupManagerType.GetMethod(dataMethod, parameterTypes).Invoke(null, argumentList);
                }
            }
            catch (Exception ex)
            {
                string message = string.Format("Could not create a cached data object for {0}. {1}", dataMethod, ex.Message);

                if (ex.InnerException != null)
                    message += string.Concat(" ", ex.InnerException.Message);

                throw new Exception(message);
            }

            return (List<T>)current.Cache[keyName];
        }

        #endregion
    }

}
