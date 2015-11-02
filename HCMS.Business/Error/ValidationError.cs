using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HCMS.Business.Error
{
    public class ValidationError
    {
        public int ErrorID { get; set; }
        public string ErrorMessage { get; set; }

        public  static List<ValidationError> GetCollection(DataTable dataItems)
        {
            List<ValidationError> listCollection = new List <ValidationError> ();

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    DataRow returnRow = dataItems.Rows[i];
                    ValidationError currentError = new ValidationError();

                    if (returnRow["ErrorID"] != DBNull.Value)
                        currentError.ErrorID  = (int)returnRow["ErrorID"];

                    if (returnRow["ErrorMessage"] != DBNull.Value)
                        currentError.ErrorMessage = returnRow["ErrorMessage"].ToString();

                    listCollection.Add(currentError);
                }
            }
            else
                throw new Exception("You cannot create a ValidationError collection from a null data table.");

            return listCollection;
        }
    }
}
