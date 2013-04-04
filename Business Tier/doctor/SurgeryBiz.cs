using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace BusinessTier
{
	public class SurgeryBiz
	{
		/// <summary>
		/// create a new surgery information
		/// </summary>
		/// <param name="data"></param>
		public void create(Data data)
		{
			SurgeryData surgeryData = new SurgeryData();

			surgeryData.create(data);
		}

		/// <summary>
		/// update a surgery information
		/// </summary>
		/// <param name="data"></param>
		public void update(Data data)
		{
			SurgeryData surgeryupdate = new SurgeryData();

			surgeryupdate.update(data);
		}

		/// <summary>
		/// dlete a surgery information
		/// </summary>
		/// <param name="data"></param>
		public void delete(Data data)
		{
			SurgeryData surgeryDelete = new SurgeryData();

			surgeryDelete.delete(data);
		}

		/// <summary>
		/// view a surgery information
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data view(Data data)
		{
			SurgeryData surgeryData = new SurgeryData();

			return surgeryData.view(data);
		}

		/// <summary>
		/// get a list of surgery types
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data getType(Data data)
		{
			SurgeryData surgeryData = new SurgeryData();

			return surgeryData.getType(data);
		}
	}
}
