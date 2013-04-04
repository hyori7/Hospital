using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace BusinessTier
{
	public class MRIBiz
	{
		//data tier of MRI
		protected MRIData dataTier = new MRIData();
		/// <summary>
		/// view MRI
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data view(Data data)
		{
			return dataTier.view(data);
		}
		/// <summary>
		/// create MRI
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public bool create(Data data)
		{
			return dataTier.create(data);
		}

		/// <summary>
		/// update MRI
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public bool update(Data data)
		{
			return dataTier.update(data);
		}
		/// <summary>
		/// delete MRI
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public bool delete(Data data)
		{
			return dataTier.delete(data);
		}
	}
}
