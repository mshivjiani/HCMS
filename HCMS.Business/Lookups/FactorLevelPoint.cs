using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

using HCMS.Business.Base;


using HCMS.Business.Common;

namespace HCMS.Business.Lookups
{
    [Serializable]
    public class FactorLevelPoint : BusinessBase, IFactorLevelPoint 
    {       
        #region Private Members

        private int _factorLevelID = -1;
        private int _factorID = -1;
        private int _levelID = -1;
        private int _point = -1;

        #endregion

      
        #region IFactorLevelPoint Members

        public int FactorID
        {
            get
            {
               return this._factorID;
            }
            set
            {
                this._factorID = value;
            }
        }

        public int FactorLevelID
        {
            get
            {
                return this._factorLevelID;
            }
            set
            {
                this._factorLevelID = value;
            }
        }

        public int LevelID
        {
            get
            {
                return this._levelID;
            }
            set
            {
                this._levelID = value;
            }
        }

        public int Point
        {
            get
            {
                return this._point;
            }
            set
            {
                this._point = value;
            }
        }
        
        #endregion
                #region Constructors

        public FactorLevelPoint(DataRow singleRowData)
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
        public FactorLevelPoint( int factorlevelid, enumFactorFormatType factorformattypeid)
        {

            try
            {
                if (factorformattypeid == enumFactorFormatType.FES)
                {
                    FesFactorLevelPoints  fesfactorlevelpoints = new FesFactorLevelPoints (factorlevelid);
                    FillObject(fesfactorlevelpoints, factorformattypeid);
                }
                else if (factorformattypeid == enumFactorFormatType.GSSG)
                {
                    GSSGFactorLevelPoints  gssgfactorlevelpoints = new GSSGFactorLevelPoints (factorlevelid);
                    FillObject(gssgfactorlevelpoints, factorformattypeid);
                }
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        #endregion

        #region Constructor Helper Methods
        protected virtual void FillObject(IFactorLevelPoint factorlevelpointobj, enumFactorFormatType factoformatypeid)
        {
            this._factorID = factorlevelpointobj.FactorID;
            this._factorLevelID = factorlevelpointobj.FactorLevelID;
            this._levelID = factorlevelpointobj.LevelID;
            this._point = factorlevelpointobj.Point;
        }
        protected virtual void FillObjectFromRowData(DataRow returnRow)
        {
            this._factorLevelID = (int)returnRow["FactorLevelID"];

            if (returnRow["FactorID"] != DBNull.Value)
                this._factorID = (int)returnRow["FactorID"];

            this._levelID = (int)returnRow["LevelID"];
            this._point = (int)returnRow["Point"];

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
            return  "FactorLevelID:" + FactorLevelID.ToString();
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
            FactorLevelPoint  FactorLevelPointobj = obj as FactorLevelPoint ;

            return (FactorLevelPointobj == null) ? false : ((this.FactorLevelID == FactorLevelPointobj.FactorLevelID));
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return  FactorLevelID.GetHashCode();
        }
        #endregion
        #region other Methods
        public static List<IFactorLevelPoint> GetFactorLevelPointsByFactorID(IFactorLevelPoint currentFactorLevelPointobj,int factorid)
        {
            List<IFactorLevelPoint> factorlevelpoints = new List<IFactorLevelPoint>();
            if (currentFactorLevelPointobj is FesFactorLevelPoints )
            {
                factorlevelpoints = FesFactorLevelPoints.GetFesFactorLevelPointsByFactorID(factorid).ConvertAll <IFactorLevelPoint>(
                    delegate(FesFactorLevelPoints factorlevelpointsobj)
                    { return factorlevelpointsobj; });

            }
            else if(currentFactorLevelPointobj is GSSGFactorLevelPoints )
            {
                factorlevelpoints = GSSGFactorLevelPoints.GetGSSGFactorLevelPointsByFactorID(factorid).ConvertAll<IFactorLevelPoint>(
                    delegate(GSSGFactorLevelPoints factorlevelpointsobj)
                    { return factorlevelpointsobj; });
            }
            return factorlevelpoints ;
        }
        #endregion
        #region Collection Helper Methods
        internal static List<IFactorLevelPoint > GetCollection(DataTable dataItems, enumFactorFormatType factorformattypeid)
        {
            List<IFactorLevelPoint> listCollection = new List<IFactorLevelPoint>();
            IFactorLevelPoint current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    if (factorformattypeid == enumFactorFormatType.FES)
                    {
                        current = new FesFactorLevelPoints(dataItems.Rows[i]);

                    }
                    else if (factorformattypeid == enumFactorFormatType.GSSG)
                    {
                        current = new GSSGFactorLevelPoints(dataItems.Rows[i]);
                    }




                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a FactorLevelPoint collection from a null data table.");

            return listCollection;
        }
        #endregion


    }
}
