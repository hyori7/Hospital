using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace BusinessTier
{
	public class PatientPaymentBiz
	{
		protected PatientPaymentData dataTier = new PatientPaymentData();

		/// <summary>
		/// get an information of a patient
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data getUserInfo(Data data)
		{
			return dataTier.getUserInfo(data);

		}

		/// <summary>
		/// get an information of all payment items
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public List<Data> view(Data data)
		{
			return dataTier.list(data);
		}

		/// <summary>
		/// create a report of the payment
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public bool create(Data data)
		{
			return dataTier.create(data);
		}

		public Data reportList(String searchField, String searchValue, Data data)
		{
			return dataTier.reportList(searchField, searchValue, data);
		}
	}
}
