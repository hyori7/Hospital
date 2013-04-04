using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace BusinessTier
{
	public class OrderBiz
	{
		/// <summary>
		/// view the doctor's order
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data view(Data data)
		{
			DoctorOrder plist = new DoctorOrder();
             
			return plist.view(data);
		}

		/// <summary>
		/// create a new order
		/// </summary>
		/// <param name="data"></param>
		public void create(Data data)
		{
			DoctorOrder OrderData = new DoctorOrder();

			OrderData.create(data);
		}

		/// <summary>
		/// update a order
		/// </summary>
		/// <param name="data"></param>
		public void update(Data data)
		{
			DoctorOrder updatedata = new DoctorOrder();

			updatedata.update(data);
		}

		/// <summary>
		/// delete a order
		/// </summary>
		/// <param name="data"></param>
		public void delete(Data data)
		{
			DoctorOrder deletedata = new DoctorOrder();

			deletedata.delete(data);
		}

	}
}
