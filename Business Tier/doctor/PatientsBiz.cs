using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace BusinessTier
{
	public class DoctorPatientsBiz
	{
		/// <summary>
		/// get a list of patients using staff id
		/// </summary>
		/// <param name="field"></param>
		/// <param name="value"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data list(String field, String value, Data data)
		{
			DoctorPatient doctor = new DoctorPatient();
			return doctor.list(field, value, data);
		}

		/// <summary>
		/// delete a patient from the list
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public bool done(Data data)
		{
			DoctorPatient doctor = new DoctorPatient();
			return doctor.done(data);
		}
	}
}
