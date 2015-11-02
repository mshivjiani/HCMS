using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using HCMS.Business.Base;
using System.Data;

namespace HCMS.Business.Lookups
{
	/// <summary>
	/// JNPOptionType Business Object
	/// </summary>
	[Serializable]
	public class JNPOptionType
	{
        public int JNPOptionTypeID { get; set; }
        public string JNPOptionTypeName { get; set; }
        public bool IsVisible { get; set; }
        public int SortOrder { get; set; }                 // future use

	    #region Constructor Helper Methods

        public JNPOptionType()
        {
            // empty constructor
        }

        public JNPOptionType(int id, string name)
	    {		
	        this.JNPOptionTypeID = id;
	        this.JNPOptionTypeName = name;
	    }

        public JNPOptionType(DataRow datarow)
        {
            this.JNPOptionTypeID = (int)datarow["JNPOptionTypeID"];
            this.JNPOptionTypeName = datarow["JNPOptionType"].ToString();
            this.IsVisible = ((datarow["IsVisible"] != DBNull.Value) ? (bool) datarow["IsVisible"] : false);
        }
	
	    #endregion
	}
}

