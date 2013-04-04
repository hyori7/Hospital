using System;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DataTier;
using System.Web;

namespace BusinessTier
{
	public class RequestManager
	{
		public RequestManager()
		{
		}
		/// <summary>
		/// get the parameters from a request
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public static Data Param(HttpRequest request)
		{
			Data parameters = new Data();
			int count = request.Params.Count;

			int pCount = 0;
			String key = null;
			String[] values = null;
			for (int i = 0; i < count; i++)
			{
				// get a list of keys
				key = request.Params.GetKey(i);
				if (key == null)
				{
					continue;
				}
				if (key.IndexOf("__") == 0)
				{
					continue;
				}
				int keyIndex = key.LastIndexOf("$") + 1;
				if (keyIndex > 0)
				{
					key = key.Substring(keyIndex, key.Length - keyIndex);
				}
				if (key.Length < 1)
				{
					continue;
				}

				//get a value using keys
				values = request.Params.GetValues(i);
				pCount = values.Length;

				if (values != null)
				{
					if (key.Equals("now"))
					{
						parameters.Now = int.Parse(values[0]);
					}
					else
					{

						for (int j = 0; j < pCount; j++)
						{
							parameters.add(j, key, values[j]);
						}
					}
				}
			}
			return parameters;
		}
		/// <summary>
		/// get a form vlaues from the request
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		public static Data Form(HttpRequest request)
		{
			Data parameters = new Data();
			int count = request.Form.Count;
			
			int pCount = 0;
			String key = null;
			String[] values = null;
			for (int i = 0; i < count; i++)
			{
				// get a list of keys
				key = request.Form.GetKey(i);
				if (key == null)
				{
					continue;
				}
				if (key.IndexOf("__") == 0)
				{
					continue;
				}
				int keyIndex = key.LastIndexOf("$") + 1;
				if (keyIndex > 0)
				{
					key = key.Substring(keyIndex, key.Length - keyIndex);
				}
				if (key.Length < 1)
				{
					continue;
				}
				//get a value using keys
				values = request.Form.GetValues(i);
				pCount = values.Length;
				
				if (values != null)
				{
					if (key.Equals("now"))
					{
						parameters.Now = int.Parse(values[0]);
					} else {

						for (int j = 0; j < pCount; j++)
						{
							parameters.add(j, key, values[j]);
						}
					}
				}
			}
			return parameters;
		}
	}
}
