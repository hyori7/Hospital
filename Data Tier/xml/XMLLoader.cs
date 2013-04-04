using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace DataTier
{
	public class XMLLoader
	{
		private static XmlDocument doc = null;
		private static String path = null;
		private static bool isLoaded = false;

		public static bool IsLoaded
		{
			get { return XMLLoader.isLoaded; }
			set { isLoaded = value; }
		}


		public static String Path
		{
			get 
			{
				return path; 
			}
			set { path = value; }
		}

		public static XmlDocument Doc
		{
			get
			{
				if (doc == null)
				{
					doc = new XmlDocument();
					doc.Load(Path);
				}
				return doc;
			}
		}
		//get a list of nodes
		public static XmlNodeList NodeList
		{
			get {
				return Doc.DocumentElement.ChildNodes;
			}
		}
		/// <summary>
		/// get a node count from xPath
		/// </summary>
		/// <param name="xPath"></param>
		/// <returns></returns>
		public static int getCount(String xPath)
		{
			return Doc.DocumentElement.SelectNodes(xPath).Count;
		}
        
		/// <summary>
		/// get a node list using xPath
		/// </summary>
		/// <param name="xPath"></param>
		/// <returns></returns>
		public static XmlNodeList getNodeList(String xPath)
		{
			return Doc.DocumentElement.SelectNodes(xPath);
		}

		/// <summary>
		/// get a node using xPath
		/// </summary>
		/// <param name="xPath"></param>
		/// <returns></returns>
		public static XmlNode getSingleNode(String xPath)
		{
			return Doc.DocumentElement.SelectSingleNode(xPath);
		}

		/// <summary>
		/// get a text from xPath
		/// </summary>
		/// <param name="xPath"></param>
		/// <returns></returns>
		public static String getText(String xPath)
		{
			return getSingleNode(xPath).InnerText;
		}

		/// <summary>
		/// get a text using xPath and index
		/// </summary>
		/// <param name="xPath"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public static String getText(String xPath, int index)
		{
			return getNodeList(xPath)[index].InnerText;
		}

		/// <summary>
		/// get a value of node using xPath and name
		/// </summary>
		/// <param name="xPath"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static String getValue(String xPath, String name)
		{
			return getSingleNode(xPath).Attributes[name].Value.ToString();
		}

		/// <summary>
		/// get a value of node using xPath, name and index
		/// </summary>
		/// <param name="xPath"></param>
		/// <param name="name"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public static String getValue(String xPath, String name, int index)
		{
			return getNodeList(xPath)[index].Attributes[name].Value.ToString();
		}
	}
}
