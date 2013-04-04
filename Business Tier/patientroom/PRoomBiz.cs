using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace BusinessTier
{
	public class PRoomBiz
	{
		/// <summary>
		/// List of data from patients
		/// </summary>
		/// <param name="field"></param>
		/// <param name="value"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data list(String field, String value, Data data)
		{
			Room room = new Room();
			return room.list(data);
		}
		/// <summary>
		/// get a list of new patients
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data newPatientsList(Data data)
		{
			Room room1 = new Room();
			return room1.newPatientsList(data);
		}
	}
}
