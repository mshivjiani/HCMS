using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HCMS.Business.Base;
using System.Xml.Serialization;
using System.IO;

namespace HCMS.Business.PhoneNumber
{[Serializable]
   public class UserPhoneNumber:BusinessBase
   {
       #region Properties
        public int PhoneNumberID { get; set; }
        public int UserID { get; set; }
        public int PhoneNumberTypeID { get; set; }
        public string PhoneNumberType { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsPublic { get; set; }
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
            return "PhoneNumberID:" + PhoneNumberID.ToString();
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
            UserPhoneNumber  Obj = obj as UserPhoneNumber ;

            return (Obj == null) ? false : (this.PhoneNumberID == Obj.PhoneNumberID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return PhoneNumberID.GetHashCode();
        }
        #endregion
    }
}
