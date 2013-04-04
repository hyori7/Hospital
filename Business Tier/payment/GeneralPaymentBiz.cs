using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace BusinessTier
{
	public class GeneralPaymentBiz
	{
		// data tier of general payment items
		public GeneralPaymentData dataTier = new GeneralPaymentData();

		/// <summary>
		/// get a list of items
		/// </summary>
		/// <param name="value"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data list(String value, Data data)
		{
            return dataTier.list(value, data);
		}

		/// <summary>
		/// create a new item
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public bool create(Data data)
		{
			return dataTier.create(data);
		}
		/// <summary>
		/// update a item
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public bool update(Data data)
		{
			return dataTier.update(data);
		}
		/// <summary>
		/// delete a item
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public bool delete(Data data)
		{
			return dataTier.delete(data);
		}
		/// <summary>
		/// get a information of item
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
        public Data view(Data data)
        {
            return dataTier.view(data);
        }

		/// <summary>
		/// get a list of types
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
        public Data droplist(Data data)
        {
            return dataTier.droplist(data);
        }

		/// <summary>
		/// get a information of item
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
        public Data viewdetail(Data data)
        {
            return dataTier.viewdetail(data);
        }
	}
}
