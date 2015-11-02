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
using HCMS.Business.Lookups.Collections;

namespace HCMS.Business.Lookups
{
    /// <summary>
    /// OrganizationCode Business Object
    /// </summary>
    [Serializable]
    public class OrganizationCode : BusinessBase
    {
        #region Private Members

        private int _organizationCodeID = -1;
        private string _organizationCode = string.Empty;
        private string _oldOrganizationCode = "N/A";
        private string _organizationName = string.Empty;
        private int _regionID = -1;
        private string _introduction = string.Empty;
        private int _reportingorganizationCode = -1;
        private string _reportingOrganizationCodeValue = string.Empty;
        private int _levelID = -1;
        private string _orgNameAbbr = string.Empty;
        private string _program = string.Empty;
        private string _progAcro = string.Empty;
        private string _mailAdd1 = string.Empty;
        private string _mailAdd2 = string.Empty;
        private string _mailCity = string.Empty;
        private string _mailStateAbbr = string.Empty;
        private string _mailZip = string.Empty;
        private string _mailZip4 = string.Empty;
        private string _physAdd1 = string.Empty;
        private string _physAdd2 = string.Empty;
        private string _physCity = string.Empty;
        private string _physStateAbbr = string.Empty;
        private string _physZip = string.Empty;
        private string _physZip4 = string.Empty;
        private string _region = string.Empty;
        #endregion

        #region Properties

        public int OrganizationCodeID
        {
            get
            {
                return this._organizationCodeID;
            }
            set
            {
                this._organizationCodeID = value;
            }
        }

        public string OrganizationCodeValue
        {
            get { return _organizationCode; }
            set { _organizationCode = value; }
        }


        public string OldOrganizationCode
        {
            get { return _oldOrganizationCode; }
            set { _oldOrganizationCode = value; }
        }

        public string OrganizationName
        {
            get
            {
                return this._organizationName;
            }
            set
            {
                this._organizationName = value;
            }
        }

        public string DetailLine
        {
            get
            {
                return string.Format("{0} | {1}", this._organizationCode, this._organizationName).Trim();
            }
        }
        //old first then new
        public string DetailLineLegacy
        {
            get
            {
                return string.Format("{0} | {1} | {2}", this._oldOrganizationCode, this._organizationCode, this._organizationName).Trim();
            }
        }
        public string DetailLineLegacyWithLevel
        {
            get
            {
                if (this._levelID > -1)
                {
                    return string.Format("{0} | {1} | {2} |Level - {3}", this._oldOrganizationCode, this._organizationCode, this._organizationName, this._levelID).Trim();
                }
                else
                {
                    return string.Format("{0} | {1} | {2} | {3}", this._oldOrganizationCode, this._organizationCode, this._organizationName, "Level UnDefined").Trim();
                }
            }
        }

        public int RegionID
        {
            get
            {
                return this._regionID;
            }
            set
            {
                this._regionID = value;
            }
        }

        public string Region
        {
            get
            {

                string region = string.Empty;
                if (this._regionID > 0)
                {
                    if (this._regionID == 9)
                    {
                        region = "HQ";
                    }
                    else
                    {
                        region = this._regionID.ToString();
                    }

                }
                return region;
            }


        }
        public string Introduction
        {
            get
            {
                return _introduction;
            }
            set
            {
                _introduction = value;
            }
        }

        public int ReportingOrganizationCode
        {
            get
            {
                return this._reportingorganizationCode;
            }
            set
            {
                this._reportingorganizationCode = value;
            }
        }

        public string ReportingOrganizationCodeValue
        {
            get
            {
                return this._reportingOrganizationCodeValue;
            }
            set
            {
                this._reportingOrganizationCodeValue = value;
            }
        }

        public int LevelID
        {
            get { return this._levelID; }
            set { this._levelID = value; }
        }

        public string NewOrgCodeLine
        {
            get { return string.Format("{0} | {1} | {2}", this._organizationCode,this._oldOrganizationCode , this._organizationName); }
        }

        public string NewOrgCodeLineWithLevel
        {
            get {
                if (this._levelID > -1)
                {
                    return string.Format("{0} | {1} | {2}|Level - {3}", this._organizationCode, this._oldOrganizationCode, this._organizationName, this._levelID);
                }
                else
                {
                    return string.Format("{0} | {1} | {2}| {3}", this._organizationCode, this._oldOrganizationCode, this._organizationName, "Level UnDefined");
                }
            }
        }
        public string OldOrgCodeLine
        {
            get { return string.Format("{0} | {1} | {2}", this._oldOrganizationCode, this._organizationCode ,this._organizationName); }
        }

        /// <summary>
        /// Shows Old Organization Code(New Organization Code)
        /// Does not show the organization name - used mainly in search results/tracker grid
        /// </summary>
        public string OrganizationCodeLegacy
        {
            get
            {
                return string.Format("{0} ({1})", this._organizationCode, this._oldOrganizationCode);
            }
        }

        public string OrgNameAbbr { get { return this._orgNameAbbr; } set { this._orgNameAbbr = value; } }
        public string Program { get { return this._program; } set { this._program = value; } }
        public string ProgAcro { get { return this._progAcro; } set { this._progAcro = value; } }
        public string MailAdd1 { get { return this._mailAdd1; } set { this._mailAdd1 = value; } }
        public string MailAdd2 { get { return this._mailAdd2; } set { this._mailAdd2 = value; } }
        public string MailCity { get { return this._mailCity; } set { this._mailCity = value; } }
        public string MailStateAbbr { get { return this._mailStateAbbr; } set { this._mailStateAbbr = value; } }
        public string MailZip { get { return this._mailZip; } set { this._mailZip = value; } }
        public string MailZip4 { get { return this._mailZip4; } set { this._mailZip4 = value; } }
        public string PhysAdd1 { get { return this._physAdd1; } set { this._physAdd1 = value; } }
        public string PhysAdd2 { get { return this._physAdd2; } set { this._physAdd2 = value; } }
        public string PhysCity { get { return this._physCity; } set { this._physCity = value; } }
        public string PhysStateAbbr { get { return this._physStateAbbr; } set { this._physStateAbbr = value; } }
        public string PhysZip { get { return this._physZip; } set { this._physZip = value; } }
        public string PhysZip4 { get { return this._physZip4; } set { this._physZip4 = value; } }
        #endregion

        #region Constructors
        public OrganizationCode() { }
        public OrganizationCode(DataRow singleRowData)
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
        public OrganizationCode(int loadByID)
        {
            // Load Object by ID
            DataTable returnTable;

            try
            {
                returnTable = ExecuteDataTable("spr_GetOrganizationCodeByID", loadByID);
                loadData(returnTable);
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        #endregion

        #region Constructor Helper Methods

        private void loadData(DataTable returnTable)
        {
            if (returnTable.Rows.Count > 0)
            {
                DataRow returnRow = returnTable.Rows[0];

                this.FillObjectFromRowData(returnRow);
            }
        }

        protected virtual void FillObjectFromRowData(DataRow returnRow)
        {
            DataColumnCollection columns = returnRow.Table.Columns;
            this._organizationCodeID = (int)returnRow["OrganizationCodeID"];
            if (returnRow["OldOrganizationCode"] != DBNull.Value)
                this._oldOrganizationCode = returnRow["OldOrganizationCode"].ToString();
            this._organizationCode = returnRow["OrganizationCode"].ToString();
            this._organizationName = returnRow["OrganizationName"].ToString();
            this._regionID = (int)returnRow["RegionID"];
            this._introduction = returnRow["Introduction"].ToString();
            if (returnRow["ReportingOrganizationCode"] != DBNull.Value)
                this._reportingorganizationCode = (int)returnRow["ReportingOrganizationCode"];
            if (returnRow["ReportingOrganizationCodeValue"] != DBNull.Value)
                this._reportingOrganizationCodeValue = returnRow["ReportingOrganizationCodeValue"].ToString();
            if (returnRow["LevelID"] != DBNull.Value)
                this._levelID = (int)returnRow["LevelID"];

            if (columns.Contains("OrgNameAbbr"))
            {
                if (returnRow["OrgNameAbbr"] != DBNull.Value)
                    this._orgNameAbbr = returnRow["OrgNameAbbr"].ToString();
            }
            if (columns.Contains("Program"))
            {
                if (returnRow["Program"] != DBNull.Value)
                    this._program = returnRow["Program"].ToString();
            }
            if (columns.Contains("ProgAcro"))
            {
                if (returnRow["ProgAcro"] != DBNull.Value)
                    this._progAcro = returnRow["ProgAcro"].ToString();
            }
            if (columns.Contains("MailAdd1"))
            {
                if (returnRow["MailAdd1"] != DBNull.Value)
                    this._mailAdd1 = returnRow["MailAdd1"].ToString();
            }
            if (columns.Contains("MailAdd2"))
            {
                if (returnRow["MailAdd2"] != DBNull.Value)
                    this._mailAdd2 = returnRow["MailAdd2"].ToString();
            }
            if (columns.Contains("MailCity"))
            {
                if (returnRow["MailCity"] != DBNull.Value)
                    this._mailCity = returnRow["MailCity"].ToString();
            }
            if (columns.Contains("MailStateAbbr"))
            {
                if (returnRow["MailStateAbbr"] != DBNull.Value)
                    this._mailStateAbbr = returnRow["MailStateAbbr"].ToString();
            }
            if (columns.Contains("MailZip"))
            {
                if (returnRow["MailZip"] != DBNull.Value)
                    this._mailZip = returnRow["MailZip"].ToString();
            }
            if (columns.Contains("MailZip4"))
            {
                if (returnRow["MailZip4"] != DBNull.Value)
                    this._mailZip4 = returnRow["MailZip4"].ToString();
            }
            if (columns.Contains("PhysAdd1"))
            {
                if (returnRow["PhysAdd1"] != DBNull.Value)
                    this._physAdd1 = returnRow["PhysAdd1"].ToString();
            }
            if (columns.Contains("PhysAdd2"))
            {
                if (returnRow["PhysAdd2"] != DBNull.Value)
                    this._physAdd2 = returnRow["PhysAdd2"].ToString();
            }
            if (columns.Contains("PhysCity"))
            {
                if (returnRow["PhysCity"] != DBNull.Value)
                    this._physCity = returnRow["PhysCity"].ToString();
            }
            if (columns.Contains("PhysStateAbbr"))
            {
                if (returnRow["PhysStateAbbr"] != DBNull.Value)
                    this._physStateAbbr = returnRow["PhysStateAbbr"].ToString();
            }

            if (columns.Contains("PhysZip"))
            {
                if (returnRow["PhysZip"] != DBNull.Value)
                    this._physZip = returnRow["PhysZip"].ToString();
            }
            if (columns.Contains("PhysZip4"))
            {
                if (returnRow["PhysZip4"] != DBNull.Value)
                    this._physZip4 = returnRow["PhysZip4"].ToString();
            }

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
            return "OrganizationCode:" + OrganizationCodeValue.ToString();
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
            OrganizationCode OrganizationCodeobj = obj as OrganizationCode;

            return (OrganizationCodeobj == null) ? false : (this.OrganizationCodeID == OrganizationCodeobj.OrganizationCodeID);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. GetHashCode() is suitable
        /// for use in hashing algorithms and data structures like a hash table.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode()
        {
            return OrganizationCodeID.GetHashCode();
        }
        #endregion

        public void Update()
        {
            if (base.ValidateKeyField(this._organizationCodeID))
            {
                DbCommand commandWrapper = GetDbCommand("spr_UpdateOrganizationCode");

                try
                {
                    commandWrapper.Parameters.Add(new SqlParameter("@OrganizationCodeID", this._organizationCodeID));
                    commandWrapper.Parameters.Add(new SqlParameter("@OrganizationCode", this._organizationCode));
                    commandWrapper.Parameters.Add(new SqlParameter("@OrganizationName", this._organizationName));
                    commandWrapper.Parameters.Add(new SqlParameter("@RegionID", this._regionID));
                    commandWrapper.Parameters.Add(new SqlParameter("@Introduction", this._introduction));
                    if (this._reportingorganizationCode > 0)
                    {
                        commandWrapper.Parameters.Add(new SqlParameter("@ReportingOrganizationCode", this._reportingorganizationCode));
                    }
                    else
                    {
                        commandWrapper.Parameters.Add(new SqlParameter("@ReportingOrganizationCode", System.DBNull.Value));

                    }
                    ExecuteNonQuery(commandWrapper);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }
        }

        #region Collection Methods
        public OrganizationCodeCollection GetChildrenOrganizations()
        {
            OrganizationCodeCollection childDataCollection = null;
            if (base.ValidateKeyField(this._organizationCodeID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetOrganizationCodeChildren", this._organizationCodeID);

                    // fill collection list
                    childDataCollection = GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }

        public OrganizationCodeCollection GetChildrenOrganizationsSortedByLevel()
        {
            OrganizationCodeCollection childDataCollection = null;
            if (base.ValidateKeyField(this._organizationCodeID))
            {
                try
                {
                    DataTable dt = ExecuteDataTable("spr_GetOrganizationCodeChildrenSortedByLevel", this._organizationCodeID);

                    // fill collection list
                    childDataCollection = GetCollection(dt);
                }
                catch (Exception ex)
                {
                    HandleException(ex);
                }
            }

            return childDataCollection;
        }
        #endregion
        #region Collection Helper Methods
        public static OrganizationCodeCollection GetChildrenOrganizations(int OrganizationCodeID)
        {
            return OrganizationCode.GetCollection(ExecuteDataTable("spr_GetOrganizationCodeChildren", OrganizationCodeID));
        }

        public static OrganizationCodeCollection GetChildrenOrganizationsSortedByLevel(int OrganizationCodeID)
        {
            return OrganizationCode.GetCollection(ExecuteDataTable("spr_GetOrganizationCodeChildrenSortedByLevel", OrganizationCodeID));
        }
        internal static OrganizationCodeCollection GetCollection(DataTable dataItems)
        {
            OrganizationCodeCollection listCollection = new OrganizationCodeCollection();
            OrganizationCode current = null;

            if (dataItems != null)
            {
                for (int i = 0; i < dataItems.Rows.Count; i++)
                {
                    current = new OrganizationCode(dataItems.Rows[i]);
                    listCollection.Add(current);
                }
            }
            else
                throw new Exception("You cannot create a OrganizationCode collection from a null data table.");

            return listCollection;
        }

        #endregion

    }
}

