using System;
using System.Configuration;

namespace HCMS.WebFramework.Site.Utilities
{
	public abstract class ValidationUtility
	{
		public static bool IsValidDate(string testValue)
		{
			bool isValid = true;
			
			try
			{
				DateTime currentDate = DateTime.Parse(testValue);	
			}
			catch
			{
				isValid = false;
			}

			return isValid;
		}

		public static bool IsValidInteger(string testValue)
		{
			bool isValid = true;

			try
			{
				int tempInt = int.Parse(testValue);
			}
			catch
			{
				isValid = false;
			}

			return isValid;
		}

		public static bool IsValidDecimal(string testValue)
		{
			bool isValid = true;

			try
			{
				decimal tempDecimal = decimal.Parse(testValue);
			}
			catch
			{
				isValid = false;
			}

			return isValid;
		}

		public static bool IsValidHex(string hexValue)
		{
			string hex = "0123456789ABCDEF";
			string tempHexValue = hexValue.Trim().ToUpper();
			if (tempHexValue.Length != 6)
				return false;

			for (int i = 0; i < 6; i++)
				if (hex.IndexOf(tempHexValue.Substring(i, 1)) == -1)
					return false;

			return true;
		}

		public static bool IsValidGUID(string testGuidValue)
		{
			bool isValid = true;

			try
			{
				Guid newGuidValue = new Guid(testGuidValue);
			}
			catch
			{
				isValid = false;
			}

			return isValid;
		}
	}
}
