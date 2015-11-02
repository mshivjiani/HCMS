using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace HCMS.WebFramework.Site.ConfigClasses
{
    public class ConfigMessages : ConfigurationElementCollection
    {
        public ConfigMessages()
        {
            ConfigMessage msg = (ConfigMessage)CreateNewElement();
            Add(msg);
        }

        public ConfigMessage this[int index]
        {
            get
            {
                return base.BaseGet(index) as ConfigMessage;
            }
            set
            {
                if (base.BaseGet(index) != null)
                {
                    base.BaseRemoveAt(index);
                }
                this.BaseAdd(index, value);
            }
        }

        new public ConfigMessage this[string ID]
        {
            get { return (ConfigMessage)BaseGet(ID); }
        }


        protected override ConfigurationElement CreateNewElement()
        {
            return new ConfigMessage();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ConfigMessage)element).ID;

        }
        public int IndexOf(ConfigMessage configmsg)
        {
            return BaseIndexOf(configmsg);
        }

        public void Add(ConfigMessage configmsg)
        {
            BaseAdd(configmsg);
        }

        public void Remove(ConfigMessage configmsg)
        {
            if (BaseIndexOf(configmsg) > 0)
            {
                BaseRemove(configmsg.ID);
            }
        }
        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        public void Remove(int ID)
        {
            BaseRemove(ID);
        }
        public void Clear()
        {
            BaseClear();
        }



    }
}
