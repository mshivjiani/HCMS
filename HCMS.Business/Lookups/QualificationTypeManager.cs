using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

using HCMS.Business.Common;
using HCMS.Business.Base;
using System.Data.SqlClient;

namespace HCMS.Business.Lookups
{
    [System.ComponentModel.DataObject]
    public class QualificationTypeManager : BusinessBase
    {
        public QualificationTypeEntity GetQualificationType(DataRow singleRowData)
        {
            try
            {
                return FillObjectFromRowData(singleRowData);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }

            return null;
        }

        protected virtual QualificationTypeEntity FillObjectFromRowData(DataRow returnRow)
        {
            QualificationTypeEntity qt = new QualificationTypeEntity();

            qt.ID = (int)returnRow["QualificationTypeID"];
            qt.Name = returnRow["QualificationTypeName"].ToString();

            return qt;
        }

        #region Collection Helper Methods
        public List<QualificationTypeEntity> GetAllQualificationTypes()
        {
            List<QualificationTypeEntity> listCollection = new List<QualificationTypeEntity>();

            DataTable dataItems = ExecuteDataTable("spr_GetAllQualificationTypes");

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    listCollection.Add(GetQualificationType(dataItems.Rows[i]));
                }
            }
            else
            {
                throw new Exception("You cannot create a QualificationType collection from a null data table.");
            }

            return listCollection;
        }
        #endregion
    }
}
