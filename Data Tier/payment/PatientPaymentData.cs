using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
	public class PatientPaymentData : BaseCommand
	{

		/// <summary>
		/// get a user data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data getUserInfo(Data data) {
			String query = "SELECT * FROM Users WHERE UserID = @USerID";
			return select(query, data);
		}

		/// <summary>
		/// get a list of all payment data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public List<Data> list(Data data)
		{
			
			String query = @"SELECT * FROM history H, GeneralPayment G
							WHERE G.ID = H.payId
								AND H.patientId = @patientId 
								AND H.payState = 0
								AND G.ID > 0
								ORDER BY H.date";
			String medicineQuery = @"SELECT *, (M.Quantity * G.Price) AS T_Price  FROM Medicine M, GeneralPayment G, history H 
								WHERE G.ID = M.ItemId 
									AND M.historyId = H.historyId
									AND H.patientId = @patientId
									AND M.state = 0
									ORDER BY H.date";
			String insuranceQuery = "SELECT * FROM Insurance I, Users U WHERE I.insuranceId = U.InsuranceId AND U.UserID = @patientId";
			List<Data> result = new List<Data>();
			dbc = new DBC();
			dbc.open();
			result.Add(dbc.select(query, data));
			result.Add(dbc.select(medicineQuery, data));
			result.Add(dbc.select(insuranceQuery, data));
			dbc.close();
			
			return result;
			
		}

		/// <summary>
		/// search a list of payment reports
		/// </summary>
		/// <param name="searchField"></param>
		/// <param name="searchValue"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data reportList(String searchField, String searchValue, Data data)
		{
			String query = @"SELECT * FROM PaymentReport P, Users U 
							WHERE U.UserID = P.UserID
								AND P.date >= CONVERT(datetime, @startDate, 103)
								AND P.date <= CONVERT(datetime, @endDate, 103)
								<SEARCH>
								ORDER BY date DESC";
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

			if ("none".Equals(searchField))
			{
				query = query.Replace("<SEARCH>", "");
			}
			else if ("UserID".Equals(searchField))
			{
				query = query.Replace("<SEARCH>", "AND P.UserID LIKE '%" + searchValue +"%'");
			}
			else if ("UserFirstName".Equals(searchField))
			{
				query = query.Replace("<SEARCH>", "AND U.UserFirstName LIKE '%" + searchValue + "%'");
			}
			else if ("UserSurName".Equals(searchField))
			{
				query = query.Replace("<SEARCH>", "AND U.UserSurName LIKE '%" + searchValue + "%'");
			}
			Data result = select(query, data);
			int count = result.Count;
			for (int i = 0; i < count; i++)
			{
				result.add(i, "date", result.getString(i, "date").Substring(0, 10));
			}
			return result;
		}

		/// <summary>
		/// create a report for payment
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool create(Data data)
		{
			String date = DateTime.Now.Date.ToString().Substring(0, 10);
			data.add("date", date);
			data.add("total", float.Parse(data.getString("total")));
			String getId = "SELECT COUNT(*) + 1 AS NEW_ID FROM PaymentReport";
			String query = "UPDATE history SET payState = 1 WHERE PatientID = @PatientID";
			String mQuery = "UPDATE Medicine SET state = 1 WHERE historyId in (SELECT historyId FROM history WHERE PatientID = @PatientID)";
			String createQuery = @"INSERT INTO PaymentReport 
									(PaymentReportID, UserID, reportFilePath, total, date) 
									VALUES (@PaymentReportID, @PatientID, @reportFilePath, @total, convert(datetime, @date, 103))";
			dbc = new DBC();
			dbc.open();
			Object id = dbc.select(getId, new Data()).get("NEW_ID");
			data.add("PaymentReportID", id);
			dbc.update(query, data);
			dbc.update(mQuery, data);
			dbc.update(createQuery, data);
			dbc.close();
			return true;
		}

		public override bool update(Data data)
		{
			throw new NotImplementedException();
		}

		public override bool delete(Data data)
		{
			throw new NotImplementedException();
		}

		public override Data view(Data data)
		{
			throw new NotImplementedException();
		}
	}
}
