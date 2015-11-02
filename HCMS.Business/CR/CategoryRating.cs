using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Serialization;
using System.IO;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using HCMS.Business.Base;
using HCMS.Business.Common;
using HCMS.Business.JNP;

namespace HCMS.Business.CR
{[Serializable]
    public class CategoryRating : BusinessBase
    {
        #region [ Constructors ]
        public CategoryRating()
        {
        }
        
        #endregion
           
        #region [ Public Properties ]
        public long CRID { get; set; }  // PK
        public long JAID { get; set; }  // FK
        public int PayPlanID { get; set; }
        public int SeriesID { get; set; }
        public int LowestAdvertisedGrade { get; set; }
        public int HighestAdvertisedGrade { get; set; }
        public bool? IsStandardCR { get; set; }
        public int? CreatedByID { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? UpdatedByID { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool? IsActive { get; set; }
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
            return "CRID:" + CRID.ToString();
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
            CategoryRating CategoryRatingobj = obj as CategoryRating;

            return (CategoryRatingobj == null) ? false : (this.CRID == CategoryRatingobj.CRID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return CRID.GetHashCode();
        }
        #endregion
    }
}
