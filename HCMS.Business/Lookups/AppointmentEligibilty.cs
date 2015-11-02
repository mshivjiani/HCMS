using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HCMS.Business.Base;

namespace HCMS.Business.Lookups
{
     [Serializable]
    public class AppointmentEligibilty:BusinessBase
    {

        #region Private Members

         private int _AEQuestionID = -1;
         private string _AEQuestion = string.Empty;
         private bool _Active;

        #endregion

        #region Properties

         public int AEQuestionID
        {
            get
            {
                return this._AEQuestionID;
            }
            set
            {
                this._AEQuestionID = value;
            }
        }
        public string AEQuestion
        {
            get
            {
                return this._AEQuestion;
            }
            set
            {
                this._AEQuestion = value;
            }
        }
        public bool Active
        {
            get
            {
                return this._Active;
            }
            set
            {
                this._Active = value;
            }
        }

        #endregion    
         
   
         public bool Equals(Object obj)
         {
             AppointmentEligibilty ApptEligibiltyObj = obj as AppointmentEligibilty;

             return (ApptEligibiltyObj == null) ? false : (this.AEQuestionID == ApptEligibiltyObj.AEQuestionID);
         }

         public int GetHashCode()
         {
             return this.AEQuestionID.GetHashCode();
         }
    }
}
