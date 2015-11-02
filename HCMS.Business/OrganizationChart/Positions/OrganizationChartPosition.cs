using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SqlClient;
using System.Xml.Serialization;
using System.IO;

using HCMS.Business.Base;
using HCMS.Business.Common;
using HCMS.Business.Lookups;

namespace HCMS.Business.OrganizationChart.Positions
{
    [Serializable]
    public class OrganizationChartPosition : WorkforcePlanningPosition, IChartPosition
    {
        #region Properties

        public int OrganizationChartID { get; set; }
        public enumOrgPositionGroupType PositionGroupType { get; set; }
        public string PositionGroupTypeName { get; set; }
        public enumOrgPositionPlacementType PositionPlacementType { get; set; }
        public string PositionPlacementTypeName { get; set;  }
        public bool IsIncluded { get; set; }        
        public bool IsInChartHierarchy { get; set; }
        public bool IsParentInChartHierarchy { get; set; }
        public int ChartChildCount { get; set; }
        
        public enumChartPositionType ChartPositionType
        {
            get
            {
                return (string.IsNullOrWhiteSpace(base.PositionNumberBase) &&
                    string.IsNullOrWhiteSpace(base.PositionNumberSuffix)) ? enumChartPositionType.WFP : enumChartPositionType.FPPS;
            }
        }
        
       #endregion

       #region Constructors

       public OrganizationChartPosition() : base()
       {
            // setting the default values on auto-implemented properties
            this.OrganizationChartID = -1;
         
            this.PositionGroupType = enumOrgPositionGroupType.Undefined;
            this.PositionGroupTypeName = string.Empty;

            this.PositionPlacementType = enumOrgPositionPlacementType.Undefined;
            this.PositionPlacementTypeName = string.Empty;

            this.IsIncluded = false;
            this.IsInChartHierarchy = false;
            this.IsParentInChartHierarchy = false;
            this.ChartChildCount = 0;
       }

       #endregion

       #region ToXML Method

       ///<summary>
            /// Returns an XML String that represents the current object.
            ///</summary>
            public string ToXML()
            {
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                using (StreamReader sr = new StreamReader(new MemoryStream()))
                {
                    serializer.Serialize(sr.BaseStream, this);
                    sr.BaseStream.Position = 0;
                    return sr.ReadToEnd();
                }
            }

            #endregion ToXML Method

       #region ToString Method

        ///<summary>
        /// Returns a String that represents the current object.
        ///</summary>
        public override string ToString()
        {
            return string.Format("OrganizationChartID: {0} - WFPPositionID: {1}", this.OrganizationChartID, base.WFPPositionID);
        }

        #endregion ToString Method
    }
}
