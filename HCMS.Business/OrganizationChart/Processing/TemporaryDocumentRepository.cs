using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HCMS.Business.Base;
using HCMS.Business.Common;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace HCMS.Business.OrganizationChart.Processing
{
    public class TemporaryDocumentRepository : RepositoryBase<TemporaryDocumentRepository, TemporaryDocument, TemporaryDocumentDataAdapter>
    {
        public TemporaryDocument GetByID(Guid loadByID, int userID)
        {
            return base.GetItem("spr_GetTemporaryDocumentByID", loadByID, userID);
        }

        public Guid Save(TemporaryDocument newDocument)
        {
            Guid finalValue = Guid.Empty;

            if (newDocument == null)
                throw new BusinessException("Cannot save a null document");
            else if (base.ValidateKeyField(newDocument.UserID))
            {
                if (newDocument.DocumentData != null && newDocument.DocumentData.Length > 0)
                {
                    try
                    {
                        DbCommand commandWrapper = GetDbCommand("spr_AddTemporaryDocument");

                        SqlParameter returnParam = new SqlParameter("@newID", SqlDbType.UniqueIdentifier);
                        returnParam.Direction = ParameterDirection.Output;

                        commandWrapper.Parameters.Add(returnParam);

                        commandWrapper.Parameters.Add(new SqlParameter("@UserID", newDocument.UserID));
                        commandWrapper.Parameters.Add(new SqlParameter("@DocumentData", newDocument.DocumentData));
                        commandWrapper.Parameters.Add(new SqlParameter("@SizeInBytes", newDocument.DocumentData.Length));

                        if (string.IsNullOrWhiteSpace(newDocument.AttributeData))
                            commandWrapper.Parameters.Add(new SqlParameter("@AttributeData", DBNull.Value));
                        else
                            commandWrapper.Parameters.Add(new SqlParameter("@AttributeData", newDocument.AttributeData.Trim()));

                        ExecuteNonQuery(commandWrapper);
                                                
                        finalValue = (Guid) returnParam.Value;
                        newDocument.DocumentID = finalValue;
                    }
                    catch (Exception ex)
                    {
                        HandleException(ex);
                    }
                }
            }

            return finalValue;
        }

        public void Delete(Guid documentID, int userID)
        {
            if (base.ValidateKeyField(documentID) && base.ValidateKeyField(userID))
            {
                try
                {
                    ExecuteNonQuery("spr_DeleteTemporaryDocument", documentID, userID);
                }
                catch (Exception ex)
                {	
                    HandleException(ex);
                }
            }
        }
    }
}
