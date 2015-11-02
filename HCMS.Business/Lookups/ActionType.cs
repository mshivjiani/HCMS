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
    public class ActionType : BusinessBase
    {
        #region Private Members

        private long _ActionTypeID = -1;
        private string _ActionTypeName = string.Empty;

        #endregion

        #region Properties

        public long ActionTypeID
        {
            get
            {
                return this._ActionTypeID;
            }
            set
            {
                this._ActionTypeID = value;
            }
        }
        public string ActionTypeName
        {
            get
            {
                return this._ActionTypeName;
            }
            set
            {
                this._ActionTypeName = value;
            }
        }

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
            return "ActionTypeID:" + this.ActionTypeID.ToString();
        }

        #endregion

        #region CompareMethods

        public bool Equals(Object obj)
        {
            ActionType actionTypeObj = obj as ActionType;

            return (actionTypeObj == null) ? false : (this.ActionTypeID == actionTypeObj.ActionTypeID);
        }

        public int GetHashCode()
        {
            return this.ActionTypeID.GetHashCode();
        }

        #endregion               
       
    }
}
