using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.ComponentModel;
//using HCMS.WebFramework.Site.ConfigClasses;

namespace HCMS.WebFramework.Site.ConfigClasses
{
    public class ConfigMessagesSection : ConfigurationSection
    {


        private static ConfigMessagesSection janpmessagessection = ConfigurationManager.GetSection("JNPMessagesSection") as ConfigMessagesSection;
        private static ConfigMessagesSection pdxmessagessection = ConfigurationManager.GetSection("PDXMessagesSection") as ConfigMessagesSection;

        public static ConfigMessagesSection PDXMessagesSection
        {
            get
            { return pdxmessagessection; }
        }
        ConfigMessage message;
        ConfigMessage jnpmessage;
        public ConfigMessagesSection()
        {
            jnpmessage = new ConfigMessage();
            message = new ConfigMessage();
           
        }

        [ConfigurationProperty("pdxmessages")]
        public ConfigMessages PDXMessages
        {
            get { return this["pdxmessages"] as ConfigMessages; }
        }


        //JAnP
        public static ConfigMessagesSection JAnPMessagesSection
        {
            get
            { return janpmessagessection; }
        }


        [ConfigurationProperty("janpmessages")]
        public ConfigMessages JAnPMessages
        {
            get { return this["janpmessages"] as ConfigMessages; }
        }

    }
}
