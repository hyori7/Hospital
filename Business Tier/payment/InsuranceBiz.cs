using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace BusinessTier
{
	public class InsuranceBiz
	{
		protected InsuranceData dataTier = new InsuranceData();
		/// <summary>
		/// get a list of insurance companies
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data list(Data data)
		{
			return dataTier.list(data);
		}

		/// <summary>
		///  get an insurance information
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data view(Data data)
		{
			return dataTier.view(data);
		}

		/// <summary>
		/// create a new insurance information
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public bool create(Data data)
		{
			return dataTier.create(data);
		}

		/// <summary>
		/// update an insurance information
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public bool update(Data data)
		{
			return dataTier.update(data);
		}

		/// <summary>
		/// delete an insurance information
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public bool delete(Data data)
		{
			return dataTier.delete(data);
		}
	}
}
