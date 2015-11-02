using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using HCMS.Business.Base;

namespace HCMS.Business.OrganizationChart.Processing
{
    public class TemporaryDocumentDataAdapter : IEntityDataAdapter<TemporaryDocument>
    {
        public virtual void Fill(DataRow dataItem, TemporaryDocument objectItem)
        {
            if (dataItem != null)
            {
                if (dataItem["DocumentID"] != DBNull.Value)
                    objectItem.DocumentID = (Guid) dataItem["DocumentID"];

                if (dataItem["UserID"] != DBNull.Value)
                    objectItem.UserID = (int) dataItem["UserID"];

                if (dataItem["DocumentData"] != DBNull.Value)
                    objectItem.DocumentData = (byte[]) dataItem["DocumentData"];

                if (dataItem["UploadDate"] != DBNull.Value)
                    objectItem.UploadDate = (DateTime) dataItem["UploadDate"];

                if (dataItem["SizeInBytes"] != DBNull.Value)
                    objectItem.SizeInBytes = (long) dataItem["SizeInBytes"];

                if (dataItem["AttributeData"] != DBNull.Value)
                    objectItem.AttributeData = dataItem["AttributeData"].ToString();
            }
        }
    }
}
