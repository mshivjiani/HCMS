using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Serialization;
using System.IO;
using System.Data;
using HCMS.Business.Base;
using HCMS.Business.Common;

namespace HCMS.Business.CR
{
    [Serializable]
    public class CategoryRatingGroup 
    {
        #region [ Constructors ]
        public CategoryRatingGroup()
        {
        }
       
        #endregion           

        #region [ Public Properties ]
        public long CategoryRatingGroupID { get; set; } // PK
        public long CRID { get; set; }  // FK
        public int ScoringRangeGroupTypeID { get; set; }
        public string ScoringRangeGroupTypeName { get; set; }
        public int RangeMin { get; set; }
        public int RangeMax { get; set; }
        public string QualifyingStatements { get; set; } // nullable
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
            return "CategoryRatingGroupID:" + CategoryRatingGroupID.ToString();
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
            CategoryRatingGroup CategoryRatingGroupobj = obj as CategoryRatingGroup;

            return (CategoryRatingGroupobj == null) ? false : (this.CategoryRatingGroupID == CategoryRatingGroupobj.CategoryRatingGroupID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return CategoryRatingGroupID.GetHashCode();
        }
        #endregion
   

       

     

    

        
    }
}
