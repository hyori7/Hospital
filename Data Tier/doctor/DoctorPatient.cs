using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
	public class DoctorPatient : BaseCommand
	{
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
		/// <summary>
		/// get a list of patient
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
								AND H.type = -1
								AND H.staffId = @doctorId
								<DATE>
								<SEARCH> ORDER BY U.UserID DESC";
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
			Data result = select(query, data);
			int count = result.Count;
			for (int i = 0; i < count; i++)
			{
				String type = "";
				if ("-1".Equals(result.getString(i, "type")))
				{
					type = "BOOK";
				}
				else if ("0".Equals(result.getString(i, "type")))
				{
					type = "ORDER";
				}
				else if ("1".Equals(result.getString(i, "type")))
				{
					type = "TEST";
				}
				else if ("2".Equals(result.getString(i, "type")))
				{
					type = "SURGERY";
				}
				else if ("3".Equals(result.getString(i, "type")))
				{
					type = "OBSERVATION";
				}
				result.add(i, "type", type);
				result.add(i, "date", result.getString(i, "date").Substring(0, 10));
			}
			return result;
		}
		
		//String doctorId, String pId
		/// <summary>
		/// delete a patient from the history list
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public bool done(Data data)
		{
			String query = "UPDATE history set status = 1 WHERE historyId = @hId";
			return update(query, data);
		}
	}
}
