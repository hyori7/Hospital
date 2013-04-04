using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace BusinessTier
{
	public class MedicineBiz
	{
		
		protected MedicineData dataTier = new MedicineData();

		/// <summary>
		/// get a list of items
		/// </summary>
		/// <param name="value"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data getItems(String value, Data data)
		{
			return dataTier.getItems(value, data);
		}

		/// <summary>
		/// get an information of a medicine
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data view(Data data)
		{
			return dataTier.view(data);
		}

		/// <summary>
		/// create a new medicine information
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public bool create(Data data)
		{
			return dataTier.create(data);
		}

		/// <summary>
		/// delete a medicine information
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public bool delete(Data data)
		{
			return dataTier.delete(data);
		}
	}
}
