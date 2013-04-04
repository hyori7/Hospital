using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace BusinessTier
{
	public class PharmacistBiz
	{
		/// <summary>
		/// get a list of patients for pharmacist
		/// </summary>
		/// <param name="field"></param>
		/// <param name="value"></param>
		/// <param name="data"></param>
		/// <returns></returns>
        public Data list(String field, String value, Data data)
		{
			PharmacistData Data = new PharmacistData();
            return Data.list(field, value, data);
		}

		/// <summary>
		/// get an information for patient
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data view(Data data)
		{
			PharmacistData pData = new PharmacistData();
			return pData.view(data);
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
