using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace BusinessTier
{
	public class XrayBiz
	{
		protected XrayData dataTier = new XrayData();
		/// <summary>
		/// get an information of X-ray
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data view(Data data)
		{
			return dataTier.view(data);
		}
		/// <summary>
		/// create an information of X-ray
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public bool create(Data data)
		{
			return dataTier.create(data);
		}

		/// <summary>
		/// update an information of X-ray
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public bool update(Data data)
		{
			return dataTier.update(data);
		}
		/// <summary>
		/// delete an information of X-ray
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public bool delete(Data data)
		{
			return dataTier.delete(data);
		}
	}
}
