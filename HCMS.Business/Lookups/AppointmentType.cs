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
    public class AppointmentType : BusinessBase
    {
        public int AppointmentTypeID { get; set; }
        public string AppointmentTypeDesc { get; set; }
        public string AppointmentCode { get; set; }
        public bool IsActive { get; set; }
        public string DisplayAs { get; set; }

         
        #region Constructors

        public AppointmentType()
        {

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
            return "AppointmentTypeID:" + AppointmentTypeID.ToString();
        }

        #endregion ToString Method
    }
}
