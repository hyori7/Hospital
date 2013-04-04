using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace BusinessTier
{
	public class ReportBiz
	{
		public ReportData dataTier = new ReportData();

		/// <summary>
		/// get an item report
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data getItemReport(Data data)
		{
			return dataTier.getItemReport(data);
		}

		/// <summary>
		/// get a patient report
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data getPatientReport(Data data)
		{
			return dataTier.getPatientReport(data);
		}

		/// <summary>
		/// get a payment report
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data getPaymentReport(Data data)
		{
			return dataTier.getPaymentReport(data);
		}

		/// <summary>
		/// get a patient payment report
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data getPatientPaymentReport(Data data)
		{
			return dataTier.getPatientPaymentReport(data);
		}

		/// <summary>
		/// get a patinet and service report
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data getPatientAndServiceReport(Data data)
		{
			return dataTier.getPatientAndService(data);
		}
	}
}
