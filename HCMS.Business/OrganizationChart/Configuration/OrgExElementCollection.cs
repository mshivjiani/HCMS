using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace HCMS.Business.OrganizationChart.Configuration
{
    [ConfigurationCollection(typeof(OrgExElement))]
    public class OrgExElementCollection : ConfigurationElementCollection
    {
        public OrgExElementCollection()
        {
            OrgExElement myElement = (OrgExElement)CreateNewElement();
            Add(myElement);
        }
        public void Add(OrgExElement orgexelement)
        {
            BaseAdd(orgexelement);
        }

        protected override void BaseAdd(ConfigurationElement element)
        {
            base.BaseAdd(element, false);
        }
        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.AddRemoveClearMap; }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new OrgExElement();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((OrgExElement)element).RegionID;
        }

        public OrgExElement this[int Index]
        {
            get { return (OrgExElement)BaseGet(Index); }
            set
            {
                if (BaseGet(Index) != null)
                { BaseRemoveAt(Index); }
                BaseAdd(Index, value);
            }
        }

        public OrgExElement GetOrgExElementByID(int RegionID)
        {


            OrgExElement currentelement = new OrgExElement();
            currentelement.RegionID = RegionID;
            return (OrgExElement)this.BaseGet(currentelement);

        }

        public int indexof(OrgExElement element)
        {
            return BaseIndexOf(element);
        }
        public void Remove(OrgExElement element)
        {
            if (BaseIndexOf(element) >= 0)
                BaseRemove(element.RegionID);

        }
        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }
        public void RemoveByRegionID(int RegionID)
        {
            BaseRemove(RegionID);
        }
        public void Clear()
        {
            BaseClear();
        }
    }
}
