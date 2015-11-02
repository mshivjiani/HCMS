using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml.Serialization;
using System.IO;

using HCMS.Business.Base;

namespace HCMS.Business.Lookups
{
    [Serializable]
    public class DashboardRoleType : BusinessBase
    {

        #region Properties

        public int DashboardRoleTypeID { get; set; }
        public string DashboardRoleType1 { get; set; }
        public string DashboardRoleTypeAcronym { get; set; }
        
        #endregion

        #region Constructors

        public DashboardRoleType()
        {

        }
        public DashboardRoleType(DataRow singleRowData)
        {
            // Load Object by dataRow
            try
            {
                this.FillObjectFromRowData(singleRowData);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        #endregion

        #region Constructor Helper Methods

        protected virtual void FillObjectFromRowData(DataRow returnRow)
        {
            DashboardRoleTypeID = (int)returnRow["DashboardRoleTypeID"];
            DashboardRoleType1 = returnRow["DashboardRoleType"].ToString();
            DashboardRoleTypeAcronym = returnRow["DashboardRoleTypeAcronym"].ToString();
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
            return "DashboardRoleTypeID:" + DashboardRoleTypeID.ToString();
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
            DashboardRoleType DashboardRoleTypeobj = obj as DashboardRoleType;

            return (DashboardRoleTypeobj == null) ? false : (this.DashboardRoleTypeID == DashboardRoleTypeobj.DashboardRoleTypeID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return DashboardRoleTypeID.GetHashCode();
        }
        #endregion

        #region Collection Helper Methods

        //internal static List<DashboardRoleType> GetCollection(DataTable dataItems)
        //{
        //    List<DashboardRoleType> listCollection = new List<DashboardRoleType>();
        //    DashboardRoleType current = null;

        //    if (dataItems != null)
        //    {
        //        for (int i = 0; i < dataItems.Rows.Count; i++)
        //        {
        //            current = new DashboardRoleType(dataItems.Rows[i]);
        //            listCollection.Add(current);
        //        }
        //    }
        //    else
        //        throw new Exception("You cannot create a DashboardRoleType collection from a null data table.");

        //    return listCollection;
        //}

        #endregion

    }
}
