using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMS.Business.Security
{
    [Serializable]
    public class ActionUser
    {
        #region Properties

        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public string FullName
        {   get
            {
                string fullname = string.Empty;
                if (this.FirstName.Trim().Length == 0 && this.LastName.Trim().Length == 0)
                {
                    return fullname ;
                }
                else
                {
                    fullname  = string.Format("{0} {1}", this.FirstName.Trim(), this.LastName.Trim());
                    return fullname;
                }
            }
            
        }

        public string FullNameReverse
        {
            get
            {
                string fullnamereverse = string.Empty;
                if (this.FirstName.Trim().Length == 0 && this.LastName.Trim().Length == 0)
                {
                    return fullnamereverse;
                }
                else
                {
                    fullnamereverse = string.Format("{1}, {0}", this.FirstName.Trim(), this.LastName.Trim());
                    return fullnamereverse;
                }
              
               
            }
        }

        public DateTime? ActionDate { get; set; }

        #endregion

        #region Constructors

        private void setDefaults()
        {
            this.UserID = -1;
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.ActionDate = null;
        }

        public ActionUser()
        {
            setDefaults();  
        }

        public ActionUser(int loadUserID)
        {
            setDefaults();  
            this.UserID = loadUserID;
        }

        public ActionUser(int loadUserID, string loadFirstName, string loadLastName)
        {
            setDefaults();  
            this.UserID = loadUserID;
            this.FirstName = loadFirstName;
            this.LastName = loadLastName;
        }

        public ActionUser(int loadUserID, string loadFirstName, string loadLastName, DateTime loadActionDate)
        {
            this.UserID = loadUserID;
            this.FirstName = loadFirstName;
            this.LastName = loadLastName;
            this.ActionDate = loadActionDate;
        }

        #endregion
    }
}
