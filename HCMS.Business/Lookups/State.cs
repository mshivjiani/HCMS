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
   public class State
    {
        public int StateID { get; set; }
        public string StateAbbreviation{get;set;}
        public string StateName {get;set;}

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

        public override  string ToString()
        {
            return "StateID:" + this.StateID.ToString();
        }

        #endregion

        #region CompareMethods

        public override  bool Equals(Object obj)
        {
            State stateobj = obj as State ;

            return (stateobj == null) ? false : (this.StateID == stateobj.StateID);
        }

        public override  int GetHashCode()
        {
            return this.StateID.GetHashCode();
        }

        #endregion               
       
    }
}
