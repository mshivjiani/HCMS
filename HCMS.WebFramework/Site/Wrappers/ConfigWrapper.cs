using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web.Configuration;
using System.DirectoryServices;
using System.Web.Security;
namespace HCMS.WebFramework.Site.Wrappers
{
    public abstract class ConfigWrapper
    {
        public static string CurrentADMembershipConnString
        {
            get { return ConfigurationManager.AppSettings["MembershipConnString"]; }
        }

        public static string CurrentADProviderName
        {
            get
            {
                string currentProviderName = ConfigurationManager.AppSettings["MembershipProvider"];

                return currentProviderName;
            }
        }
        public static int FormsAuthTimeout
        {
            get
            {
                int formsauthtimeout = -1;
                try
                {
                    formsauthtimeout = int.Parse(ConfigurationManager.AppSettings["FormsAuthTimeout"]);
                }
                catch
                {
                    formsauthtimeout = 40;
                }
                return formsauthtimeout;
            }
        }
        public static bool PersistAuthCookie
        {
            get
            {
                return ConfigurationManager.AppSettings["PersistAuthCookie"].ToLower() == "true";
            }
        }
        public static string EEOText
        {

            get
            {
                string eeotxt = String.Empty;
                try
                {

                    eeotxt = ConfigurationManager.AppSettings["EEOText"];
                }
                catch
                {
                    eeotxt = string.Empty;
                }
                return eeotxt;

            }
        }

        public static int JumpLoginID
        {
            get
            {
                int jumploginid = -1;
                try
                {
                    jumploginid = int.Parse(ConfigurationManager.AppSettings["JumpLoginID"]);
                }
                catch
                {
                    jumploginid = -1;
                }
                return jumploginid;
            }
        }

        public static bool JumpLogin
        {
            get
            {
                bool blnjump = false;

                bool.TryParse(ConfigurationManager.AppSettings["JumpLogin"].ToString(), out blnjump);

                return blnjump;

            }
        }

        public static string OrgChartTemplateFilePath
        {
            get
            {
                return ConfigurationManager.AppSettings["OrgChartTemplateFilePath"];
            }
        }

        public static int SystemImportUserID
        {
            get
            {
                int importUserID = -1;
                bool isOK = int.TryParse(ConfigurationManager.AppSettings["SystemImportUserID"], out importUserID);

                if (!isOK)
                    importUserID = -1;

                return importUserID;
            }
        }
    }
}
