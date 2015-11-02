using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml.Serialization;
using System.IO;

using HCMS.Business.Base;
using HCMS.Business.Common;


 
namespace HCMS.Business.Admin.Workforce
{
    [Serializable]
    public class DashboardRole : BusinessBase
    {
        public int DashboardRoleID { get; set; }
        public int DashboardRoleTypeID { get; set; }
        public enumDashboardRoleType eDashboardRoleType { get; set; }
        public int OrganizationCodeID { get; set; }
        
        
        public bool IsStructuralRole { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        
        
        public string DashboardRoleType { get; set; }
        public string OrganizationCode { get; set; }
        public string OldOrganizationCode { get; set; }
        public string OrganizationName { get; set; } 
        public string DetailLineLegacy { get; set; }
        public string DashboardRoleLabel { get; set; }
        public int RegionID { get; set; }
        public string Region { get; set; }

        public DashboardRole()
        {

        }
        public DashboardRole(DataRow singleRowData)
        {
            // Load Object by dataRow
            try
            {
                FillObjectFromRowData(singleRowData);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        protected virtual void FillObjectFromRowData(DataRow returnRow)
        {
            DashboardRoleID = (int)returnRow["DashboardRoleID"];
            DashboardRoleTypeID = (int)returnRow["DashboardRoleTypeID"];
            eDashboardRoleType =(enumDashboardRoleType) DashboardRoleTypeID;
            DashboardRoleType = returnRow["DashboardRoleType"].ToString();
            OrganizationCodeID = (int)returnRow["OrganizationCodeID"];
            OrganizationCode = returnRow["OrganizationCode"].ToString();
            OldOrganizationCode = returnRow["OldOrganizationCode"].ToString();
            OrganizationName = returnRow["OrganizationName"].ToString();
            DetailLineLegacy = returnRow ["DetailLineLegacy"].ToString ();
            DashboardRoleType = returnRow["DashboardRoleType"].ToString();
            RegionID = (int)returnRow["RegionID"];
            Region = returnRow["Region"].ToString();
            IsStructuralRole = (bool)returnRow["IsStructuralRole"];
            DashboardRoleLabel = returnRow["DashboardRoleLabel"].ToString();
            UserID = (int)returnRow["UserID"];
            UserName = returnRow["UserName"].ToString();
    
        }


        internal static List<DashboardRole> GetCollection(DataTable dataItems)
        {
            List<DashboardRole> listCollection = new List<DashboardRole>();
            DashboardRole current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new DashboardRole(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a DashboardRole collection from a null data table.");

            return listCollection;
        }
    }
}
