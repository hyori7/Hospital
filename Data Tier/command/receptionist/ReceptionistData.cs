using System;

namespace DataTier
{
	public class ReceptionistData : BaseCommand
	{
		/// <summary>
		/// get a patient data
		/// </summary>
		/// <param name="searchField"></param>
		/// <param name="searchValue"></param>
		/// <returns></returns>
		public Data getPatient(String searchField, String searchValue)
		{
			String query = @"SELECT UserFirstName + ' ' + UserSurName +' (' + UserID + ')' AS name, UserID
							FROM Users WHERE <SEARCH>  AND state = 0  AND JobCode = 0 ORDER BY UserID";
			if ("UserID".Equals(searchField))
			{ 
				query = query.Replace("<SEARCH>", "UserID LIKE '%" + searchValue + "%'");
			}
			else if ("UserFirstName".Equals(searchField))
			{
				query = query.Replace("<SEARCH>", "UserFirstName LIKE '%" + searchValue + "%'");
			}
			else if ("UserSurName".Equals(searchField))
			{
				query = query.Replace("<SEARCH>", "UserSurName LIKE '%" + searchValue + "%'");
			}
			else if ("Email".Equals(searchField))
			{
				query = query.Replace("<SEARCH>", "Email LIKE '%" + searchValue + "%'");
			}

			return select(query, new Data());

		}
		/// <summary>
		/// get a staff data
		/// </summary>
		/// <returns></returns>
		public Data getStaff()
		{
			String query = @"SELECT UserFirstName + ' ' + UserSurName + '(' + B.JobName + ': ' + UserID + ')' AS name, UserID
							FROM users A, roles B 
							WHERE A.JobCode = B.JobCode AND B.GroupName = 'Doctors' AND A.state = 0 
							ORDER BY UserID";
			return select(query, new Data());
		}

		/// <summary>
		/// get a history data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override Data view(Data data)
		{
			String query = @"SELECT * FROM history A, users B 
							WHERE A.patientId = B.UserID AND A.historyId = @historyId AND status = 0";

			return select(query, data);
		}
		/// <summary>
		/// create a new book
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool create(Data data)
		{
			String getNewId = "SELECT COUNT(historyId)  + 1 AS MAX_ID FROM history";
			String query = @"INSERT INTO history 
								(historyId, patientId, staffId, memo, type, cntId,date) 
								VALUES(@historyId, @patientId, @staffId, @memo, -1, -1, CONVERT(datetime, @date, 103))";
			dbc = new DBC();
			dbc.open();
			Object id = dbc.select(getNewId, new Data()).get("MAX_ID");
			
			data.add("historyId", id);
			dbc.update(query, data);
			dbc.close();
			dbc.open();
			return true;
		}

		/// <summary>
		/// update a book data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool update(Data data)
		{
			string query = @"UPDATE history
							SET staffId = @staffId, memo = @memo, updateTime = getDate(), date = CONVERT(datetime, @date, 103)
							WHERE historyId = @historyId";

			update(query, data);
			return true;
		}
		/// <summary>
		/// delete a book data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool delete(Data data)
		{
			string query = "UPDATE history set status = 9 WHERE historyId = @historyId";
			update(query, data);
			return true;
		}

		/// <summary>
		/// get a list of patients' books
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data list(Data data)
		{
			String patientId = data.getString("patientId");
			String date = data.getString("date");
			String searchField = data.getString("searchField");
			String searchValue = data.getString("searchValue");
			String query = @"SELECT * FROM history A, users B WHERE A.patientId = B.UserID AND A.status in (0,1) <SEARCH> <DATE> ORDER BY payState ASC, historyId DESC";

			///searching
			if ("".Equals(searchField))
			{
				query = query.Replace("<SEARCH>", "");
			}
			else if ("UserID".Equals(searchField))
			{
				query = query.Replace("<SEARCH>", "AND B.UserID LIKE '%" + searchValue + "%'");
			}
			else if ("UserFirstName".Equals(searchField))
			{
				query = query.Replace("<SEARCH>", "AND B.UserFirstName LIKE '%" + searchValue + "%'");
			}
			else if ("UserSurName".Equals(searchField))
			{
				query = query.Replace("<SEARCH>", "AND B.UserSurName LIKE '%" + searchValue + "%'");
			}
			else if ("Email".Equals(searchField))
			{
				query = query.Replace("<SEARCH>", "AND B.Email LIKE '%" + searchValue + "%'");
			}
			if (date.Equals(""))
			{
				query = query.Replace("<DATE>", "");
			}
			else
			{
				query = query.Replace("<DATE>", "AND CONVERT(VARCHAR(10), A.date, 103) = '<DATE>'".Replace("<DATE>", date));
			}
			

			return select(query, data);
			
		}
	}
}
