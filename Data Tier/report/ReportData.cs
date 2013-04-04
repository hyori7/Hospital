using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
	public class ReportData :BaseCommand
	{
		/// <summary>
		/// get a report for items
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data getItemReport(Data data) {
			String startDate = data.getString("startDate");
			String endDate = data.getString("endDate");
			String today = DateTime.Now.Date.ToString().Substring(0,10);
			if ("".Equals(startDate))
			{
				data.add("startDate",today);
			}
			if ("".Equals(startDate))
			{
				data.add("endDate", today);
			}
			String query = @"SELECT G.Item, G.Price, COUNT(M.ItemId) AS How_many_times, SUM(G.Price) AS Total
							FROM Medicine M, GeneralPayment G, history H
							WHERE H.historyId = M.historyId
								AND M.ItemId = G.ID
								AND M.state < 9
								AND H.date >= CONVERT(datetime, @startDate, 103)
								AND H.date <= CONVERT(datetime, @endDate, 103)
							GROUP BY G.Item, G.price
							ORDER BY G.Item ASC";

			return select(query, data);
		}

		/// <summary>
		/// get a report for patients number
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data getPatientReport(Data data) {
			String startDate = data.getString("startDate");
			String endDate = data.getString("endDate");
			String today = DateTime.Now.Date.ToString().Substring(0, 10);
			if ("".Equals(startDate))
			{
				data.add("startDate", today);
			}
			if ("".Equals(startDate))
			{
				data.add("endDate", today);
			}

			String query = @"SELECT staffId, R.JobName, R.GroupName, COUNT(*) AS how_many_times 
							FROM history H, Users U, Roles R
							WHERE U.UserID = H.staffId 
								AND R.JobCode = U.JobCode
								AND H.date >= CONVERT(datetime, @startDate, 103)
								AND H.date <= CONVERT(datetime, @endDate, 103)
							GROUP BY H.staffId, R.JobName, R.GroupName
							ORDER BY H.staffId ASC";

			Data result = select(query, data);
			return result;
		}
		/// <summary>
		/// get a payment report
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data getPaymentReport(Data data)
		{
			String startDate = data.getString("startDate");
			String endDate = data.getString("endDate");
			String today = DateTime.Now.Date.ToString().Substring(0, 10);
			if ("".Equals(startDate))
			{
				data.add("startDate", today);
			}
			if ("".Equals(startDate))
			{
				data.add("endDate", today);
			}
			String query = @"SELECT P.UserID, U.UserFirstName, U.UserSurName, I.insuranceName, SUM(total) AS Total_payed, AVG(total) AS Average_Payment
							FROM PaymentReport P, Users U, Insurance I
							WHERE U.UserID = P.UserID
								AND I.insuranceId = U.InsuranceId
								AND P.date >= CONVERT(datetime, @startDate, 103)
								AND P.date <= CONVERT(datetime, @endDate, 103)
							GROUP BY P.UserID, U.UserFirstName, U.UserSurName, I.insuranceName
							ORDER BY P.UserID ASC";
			Data result = select(query, data);
			int count = result.Count;
			for (int i = 0; i < count; i++)
			{
				float price = float.Parse(result.getString(i, "Average_Payment"));
				price = (price - price % (float)0.01);
				result.add(i, "Average_Payment", price);
			}
			return result;
		}

		/// <summary>
		/// get a patient payment report
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data getPatientPaymentReport(Data data)
		{
			String startDate = data.getString("startDate");
			String endDate = data.getString("endDate");
			String today = DateTime.Now.Date.ToString().Substring(0, 10);
			if ("".Equals(startDate))
			{
				data.add("startDate", today);
			}
			if ("".Equals(startDate))
			{
				data.add("endDate", today);
			}

			String query = @"SELECT P.UserID, U.UserFirstName, U.UserSurName, I.insuranceName, 
								P.total * (100 - I.rate) / 100 AS Patient_Fee, 
								P.total * (100 - I.rate) / 100 AS Insurance_Fee, 
								P.total
							FROM PaymentReport P, Users U, Insurance I
							WHERE U.UserID = P.UserID
								AND I.insuranceId = U.InsuranceId
								AND P.date >= CONVERT(datetime, @startDate, 103)
								AND P.date <= CONVERT(datetime, @endDate, 103)
							GROUP BY P.UserID, U.UserFirstName, U.UserSurName, I.insuranceName, P.total, I.rate
							ORDER BY P.UserID ASC";
			Data result = select(query, data);
			return result;
		}

		public Data getPatientAndService(Data data)
		{
			String startDate = data.getString("startDate");
			String endDate = data.getString("endDate");
			String today = DateTime.Now.Date.ToString().Substring(0, 10);
			if ("".Equals(startDate))
			{
				data.add("startDate", today);
			}
			if ("".Equals(startDate))
			{
				data.add("endDate", today);
			}

			String query = @"SELECT H.patientId, G.Item AS Type, 
								G.Price, 
								G.Price * (100 - I.rate) / 100 AS Patient_Fee, 
								G.Price * I.rate / 100 AS Insurance_Fee,
								I.InsuranceName, I.rate,
								H.date
							FROM GeneralPayment G, history H, Users U, Insurance I
							WHERE G.ID = H.PayId
								AND U.UserID = H.patientId
								AND I.insuranceId = U.InsuranceId
								AND H.payId > 0
								AND H.date >= CONVERT(datetime, @startDate, 103)
								AND H.date <= CONVERT(datetime, @endDate, 103)
							GROUP BY H.patientId, G.Item, G.Price, I.InsuranceName, I.rate, H.date
							ORDER BY Date DESC";
			Data result = select(query, data);
			int count = result.Count;
			for (int i = 0; i < count; i++)
			{
				result.add(i, "date", result.getString(i, "date").Substring(0, 10));
			}
			return result;
		}

		public override Data view(Data data)
		{
			throw new NotImplementedException();
		}

		public override bool create(Data data)
		{
			throw new NotImplementedException();
		}

		public override bool update(Data data)
		{
			throw new NotImplementedException();
		}

		public override bool delete(Data data)
		{
			throw new NotImplementedException();
		}
	}
}
