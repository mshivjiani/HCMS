using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

using HCMS.Business.Base;
using HCMS.Business.Common;

namespace HCMS.Business.JNPWorkflowNote
{
    /// <summary>
    /// JNP Workflow Note Business Object
    /// </summary>
    [Serializable]
    public class JNPWorkflowNoteStatus : BusinessBase
    {
        #region [ Constructors ]
        public JNPWorkflowNoteStatus()
        {
        }
        private JNPWorkflowNoteStatus(DataRow dataRow)
        {
            FillObjectFromRowData(dataRow);
        }
        #endregion

        #region [ Constructor Helper Methods ]
        protected virtual void FillObjectFromRowData(DataRow dataRow)
        {
            JNPWorkflowNoteStatusID = (int)dataRow["JNPWorkflowNoteStatusID"];
            JNPWorkflowNoteStatusName = (string)dataRow["JNPWorkflowNoteStatus"];
        }
        #endregion

        #region [ Static Helper Methods ]
        public static List<JNPWorkflowNoteStatus> GetAll()
        {
            List<JNPWorkflowNoteStatus> list = new List<JNPWorkflowNoteStatus>();

            try
            {
                DataTable dataTable = ExecuteDataTable("spr_GetAllJNPWorkflowNoteStatus");

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        JNPWorkflowNoteStatus item = new JNPWorkflowNoteStatus();
                        item.FillObjectFromRowData(dataRow);

                        list.Add(item);
                    }
                }

            }
            catch (Exception ex)
            {
                ExceptionBase.HandleException(ex);
            }

            return list;
        }
        #endregion

        #region [ Properties ]
        public int JNPWorkflowNoteStatusID { get; set; } // PK
        public string JNPWorkflowNoteStatusName { get; set; }
        #endregion
    }
}
