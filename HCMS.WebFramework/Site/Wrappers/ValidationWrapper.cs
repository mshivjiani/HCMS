using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized ;
using System.Configuration ;

using HCMS.Business.PD;
using HCMS.Business.Common;
using Microsoft.Practices.EnterpriseLibrary.Validation;
using Microsoft.Practices.EnterpriseLibrary.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Microsoft.Practices.EnterpriseLibrary.Validation.Integration.AspNet;
using Microsoft.Practices.EnterpriseLibrary.Validation.Configuration;


namespace HCMS.WebFramework.Site.Wrappers
{
    public static class ValidationWrapper
    {
        public static bool IsPDvalid(PositionDescription currentPD, PDChoiceType currentPDChoiceType, PDStatus currentPDStatus, enumRole currentRole, ref string errormsg)
        {
            bool isvalid = false;

            string currentRuleSetName = string.Empty;

            switch (currentPDChoiceType )
            {
                case PDChoiceType.NewPD:
                    isvalid = ValidateCreateNewPD(currentPD, currentPDStatus, currentRole, ref errormsg);
                  break;


            }


            return isvalid;
            
           
        }

        private static bool ValidateCreateNewPD(PositionDescription currentPD, PDStatus currentPDStatus, enumRole currentRole, ref string errormsg)
        {
            bool isvalid = false;
            StringCollection rulesetnames = new StringCollection();
            string msg = string.Empty;
            switch (currentPDStatus)
            {
                case PDStatus.Draft :
                    
                     rulesetnames = GetRulesetNames("Draft");
                   
                    foreach (string rulesetname in rulesetnames)
                    {
                        string currentmsg=ValidatePD(currentPD, rulesetname);
                        if (currentmsg.Length > 0)
                        {
                            string.Concat(msg, currentmsg);
                        }
                    }
                    break;
            }
            isvalid =(msg.Length==0)?true :false;
            return isvalid;

        }

        private static StringCollection  GetRulesetNames(string rulesetnamestartstring)
        {
            
            ValidationSettings validationSettings = ConfigurationManager.GetSection("validation") as ValidationSettings ;
            
            StringCollection rulesetnames= new StringCollection ();
            ValidationRulesetDataCollection rulesets=validationSettings.Types.Get("PositionDescription").Rulesets ;
            foreach (ValidationRulesetData ruleset in rulesets)
            {
                if (ruleset.Name.StartsWith(rulesetnamestartstring))
                {
                    rulesetnames.Add(ruleset.Name);
                }
            }
            return rulesetnames ;
        }

        private static string ValidatePD(PositionDescription currentPD, string currentRuleSetName)
        {
            ValidationResults results;

            results = Validation.Validate<PositionDescription>(currentPD,currentRuleSetName );
            bool isvalid = results.IsValid;
            string errormsg = string.Empty;
            if (!results.IsValid)
            {
                isvalid = false;
                StringBuilder builder = new StringBuilder(string.Format ("{0}: Errors",currentRuleSetName));
                foreach (ValidationResult result in results)
                {
                    builder.AppendFormat("<br/>Error-{0}:{1}", result.Tag, result.Message);
                }
                errormsg = builder.ToString();
            }
            return errormsg  ;
        }
    }
}
