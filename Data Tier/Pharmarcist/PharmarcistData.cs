using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
	public class PharmacistData : BaseCommand
	{
		/// <summary>
		/// get a patients data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override Data view(Data data)
		{
			string getCntId = ("SELECT cntId FROM history WHERE historyId = @historyId");
			string query = "SELECT * FROM DoctorsOrder A, Users B WHERE A.UserID = B.UserID AND A.orderId = @cntId";
			dbc = new DBC();
			dbc.open();
			
			string cntId = dbc.select(getCntId, data).getString("cntId");
			data.add("cntId", cntId);
			Data result = dbc.select(query, data);
			dbc.close();
			return result;
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

		/// <summary>
		/// get a patients list
		/// </summary>
		/// <param name="field"></param>
		/// <param name="value"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data list(String field, String value, Data data)
		{
			//String query = "Select * From Users U WHERE JobCode = 0 and UserID in (SELECT patientId FROM history WHERE staffId = @doctorId AND state = 0 <DATE>) <SEARCH> ORDER BY UserID DESC";
			String query = @"Select * From Users U, history H
							WHERE U.UserID = H.patientId
								AND U.JobCode = 0
								AND H.status = 0
								AND H.staffId = @doctorId
								<DATE>
								<SEARCH> ORDER BY U.UserID DESC";
			//searcing
			if (field.Equals(""))
			{
				query = query.Replace("<SEARCH>", "");
			}
			else if (field.Equals("memo"))
			{
				query = query.Replace("<SEARCH>", "AND H.memo LIKE '%" + value + "%'");
			}
			else if (field.Equals("UserID"))
			{
				query = query.Replace("<SEARCH>", "AND U.UserID LIKE '%" + value + "%'");
			}
			else if (field.Equals("firstName"))
			{
				query = query.Replace("<SEARCH>", "AND U.firstName LIKE '%" + value + "%'");
			}
			else if (field.Equals("surName"))
			{
				query = query.Replace("<SEARCH>", "AND U.surName LIKE '%" + value + "%'");
			}

			if (!"".Equals(data.getString("date")))
			{
				query = query.Replace("<DATE>", "AND H.date = CONVERT(datetime, @date, 103)");
			}
			else
			{
				query = query.Replace("<DATE>", "");
			}
			return select(query, data);
		}
	}
}
