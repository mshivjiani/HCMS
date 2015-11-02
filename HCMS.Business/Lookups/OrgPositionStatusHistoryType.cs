using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using HCMS.Business.Base;
using System.Xml.Serialization;
using System.IO;

namespace HCMS.Business.Lookups
{
    [Serializable]
    public class OrgPositionStatusHistoryType : BusinessBase
    {
        #region Properties
        public int OrgPositionStatusHistoryTypeID { get; set; }
        public string OrgPositionStatusHistoryTypeCode { get; set; }
        public string OrgPositionStatusHistoryTypeDesc { get; set; }
        public enumOrgPositionStatusHistoryType eOrgPositionStatusHistoryType { get; set; }
        #endregion

        #region Constructor
        public OrgPositionStatusHistoryType() { }
        #endregion

        #region ToXML Method

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

        public string ToString()
        {
            return "OrgPositionStatusHistoryTypeID:" + this.OrgPositionStatusHistoryTypeID.ToString();
        }

        #endregion

        #region CompareMethods

        public bool Equals(Object obj)
        {
            OrgPositionStatusHistoryType TypeObj = obj as OrgPositionStatusHistoryType;

            return (TypeObj == null) ? false : (this.OrgPositionStatusHistoryTypeID == TypeObj.OrgPositionStatusHistoryTypeID);
        }

        public int GetHashCode()
        {
            return this.OrgPositionStatusHistoryTypeID.GetHashCode();
        }

        #endregion
    }
}
