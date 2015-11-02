using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HCMS.Business.Base;
using System.Xml.Serialization;
using System.IO;

namespace HCMS.Business.Lookups
{
    [Serializable]
    public class OrgChartType
    {
        #region Properties

        public int OrgChartTypeID { get; set; }
        public string OrgChartTypeDesc { get; set; }

        #endregion

        #region Constructors

        public OrgChartType()
        {
            this.OrgChartTypeID = -1;
            this.OrgChartTypeDesc = string.Empty;
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
            return "OrgChartTypeID:" + OrgChartTypeID.ToString();
        }

        #endregion ToString Method
    }
}
