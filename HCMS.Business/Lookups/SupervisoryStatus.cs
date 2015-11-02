using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HCMS.Business.Base;
using System.Xml.Serialization;
using System.IO;
namespace HCMS.Business.Lookups
{[Serializable]
    public class SupervisoryStatus:BusinessBase
    {

        #region Properties
        public int SupervisorStatusID{get;set;}
        public string Title {get;set;}
        public string SupervisorStatusDescription { get; set; }
        public enumSupervisorStatus eSupervisorStatus { get; set; }
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
            return "SupervisorStatusID:" + SupervisorStatusID.ToString();
        }

        #endregion ToString Method

        #region CompareMethods

        /// <summary>
        /// Determines whether the specified System.Object is equal to the current object.
        /// </summary>
        /// <param name="obj">The System.Object to compare with the current object.</param>
        /// <returns>Returns true if the specified System.Object is equal to the current object; otherwise, false.</returns>
        public override bool Equals(Object obj)
        {
            SupervisoryStatus  sObj= obj as SupervisoryStatus ;

            return (sObj == null) ? false : (this.SupervisorStatusID == sObj.SupervisorStatusID );
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return SupervisorStatusID.GetHashCode();
        }
        #endregion

    }
}
