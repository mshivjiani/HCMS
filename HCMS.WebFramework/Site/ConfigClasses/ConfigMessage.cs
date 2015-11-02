using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Configuration;
using System.Configuration;

namespace HCMS.WebFramework.Site.ConfigClasses
{
    public class ConfigMessage : ConfigurationElement
    {
        [ConfigurationProperty("id", IsRequired = true)]
        public string ID
        {
            get { return this["id"] as string; }
        }
        [ConfigurationProperty("name")]
        public string Name
        {
            get { return this["name"] as string; }
        }
        [ConfigurationProperty("text")]
        public string Text
        {
            get { return this["text"] as string; }
        }
    }
}
