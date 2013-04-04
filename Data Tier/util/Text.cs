using System;

namespace DataTier
{
	public class Text
	{
		//check the string is empty or not
		public static bool isEmpty(Object o)
		{
			return isEmpty(o.ToString());
		}

		//check the string is empty or not
		public static bool isEmpty(String s)
		{
			if (s == null)
			{
				return true;
			}
			if (s.Length == 0)
			{
				return true;
			}
			return false;
		}
		// check the length of text
		public static bool isLonger(String s, int size)
		{
			if (s.Length > size)
			{
				return true;
			}
			return false;
		}
        
		//check text can be used
		public static bool isAble(String s, int size) {
			if (isEmpty(s))
			{
				return false;
			}
			if (isLonger(s, size))
			{
				return false;
			}

			return true;
		}
		//if the text is empty will return null vlaue (nv)
		public static String ifEmpty(Object s, String nv)
		{
			if (s == null)
			{
				return nv;
			}
			return ifEmpty(s.ToString(), nv);
		}
		//if the text is empty will return null vlaue (nv)
		public static String ifEmpty(String s, String nv)
		{
			return isEmpty(s) ? nv : s;
		}
		//decode uri from javascript
		public static String decodeUri(String s) {
			return Microsoft.JScript.GlobalObject.decodeURI(s);
		}
		//encode uri from javascript
		public static String encodeUri(String s)
		{
			return Microsoft.JScript.GlobalObject.encodeURI(s);
		}
	}
}
