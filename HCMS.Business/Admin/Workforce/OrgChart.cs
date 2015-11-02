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
    public class OrgCodeChart : BusinessBase
    {
        public int ServiceLevel { get; set; }
        public int RegionalLevel { get; set; }
        public int RDLevel { get; set; }

        public string Admin { get; set; }
        public string HCO { get; set; }
        public string Director { get; set; }

        public int Region { get; set; }

        public int RegionalDir { get; set; }

        public string OrgCode { get; set; }

        public int Level { get; set; }


        public OrgCodeChart()
        {

        }

        public OrgCodeChart(DataRow singleRowData)
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
            ServiceLevel = (int)returnRow["ServiceLevel"];
            RegionalLevel = (int)returnRow["RegionalLevel"];
           
        }

        internal static List<OrgCodeChart> GetCollection(DataTable dataItems)
        {
            List<OrgCodeChart> listCollection = new List<OrgCodeChart>();
            OrgCodeChart OC = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    OC = new OrgCodeChart(dataItems.Rows[i]);
                    listCollection.Add(OC);
                }
            }
            else
                throw new Exception("You cannot create a DashboardRole collection from a null data table.");

            return listCollection;
        }
    }



}
