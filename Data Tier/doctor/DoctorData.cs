using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
	public class DoctorData : BaseCommand
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
		/// get a history list of patients
		/// </summary>
		/// <param name="field"></param>
		/// <param name="value"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data list(String field, String value, Data data)
		{
			String query = @"Select * From history A, Users B 
							WHERE A.patientId = B.UserID 
								AND A.patientId = @pId 
								AND A.status < 9
								<PRE>
								<SEARCH> 
								<DATE> 
								ORDER BY date DESC, historyId DESC";//ORDER BY historyId DESC";
			String date = data.getString("date");
			string pre = data.getString("pre");
			if (field.Equals(""))
			{
				query = query.Replace("<SEARCH>", "");
			}
			else if (field.Equals("memo")) 
			{
				query = query.Replace("<SEARCH>", "AND memo LIKE '%" + value + "%'");
			}
			else if (field.Equals("patientId"))
			{
				query = query.Replace("<SEARCH>", "AND patientId LIKE '%" + value + "%'");
			}

			if ("True".Equals(pre))
			{
				query = query.Replace("<PRE>", "");
			}
			else
			{
				query = query.Replace("<PRE>", "AND A.payState = '0' ");
				
			}

			if (date.Equals(""))
			{
				query = query.Replace("<DATE>", "");
			}
			else
			{
				query = query.Replace("<DATE>", "AND CONVERT(VARCHAR(10), A.date, 103) = '<DATE>'".Replace("<DATE>", date));
			}

			Data result = select(query, data);
			int count = result.Count;
			// check a type of content
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
				result.add(i, "typeText", type);
				result.add(i, "date", result.getString(i, "date").Substring(0, 10));
			}
			return result;
		}
	}
}
