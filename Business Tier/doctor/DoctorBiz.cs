using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace BusinessTier
{
	public class DoctorBiz
	{
		/// <summary>
		/// make a list of patients' history
		/// </summary>
		/// <param name="field"></param>
		/// <param name="value"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data list(String field, String value, Data data)
		{

			//String field = data.getString("searchFiled");
			DoctorData doctor = new DoctorData();
			return doctor.list(field, value, data);
		}
	}
}
