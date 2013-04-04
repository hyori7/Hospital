using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
	public class Observation : BaseCommand
	{
		/// <summary>
		/// Select nurse form base on current user ID
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override Data view(Data data)
		{
			String today = DateTime.Now.Date.ToString().Substring(0, 10);
			data.add("today", today);
			String query = "SELECT * FROM NursesForm WHERE <SEARCH>";
			if (!"".Equals(data.getString("pID")))
			{
				query = query.Replace("<SEARCH>", "UserID = @pID AND date = CONVERT(datetime, @today, 103)");
			}
			else
			{
				query = query.Replace("<SEARCH>", "id = @cntId");
			}
			Data result = select(query, data);
			int count = result.Count;
			for(int i =0; i < count; i++) {
				result.add(i, "date", result.getString(i, "date").Substring(0,10));
			}
			return result;
			
		}
		/// <summary>
		/// create new data for nurse form and update patient history
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool create(Data data)
		{
			String today = DateTime.Now.Date.ToString().Substring(0, 10);
			data.add("today", today);
            dbc = new DBC();
			dbc.open();
            Object ID = dbc.select("SELECT COUNT(id) + 1 AS MAX_ID FROM NursesForm", data).get("MAX_ID");
            data.add("id", ID);
			dbc.update(@"INSERT INTO NursesForm
				(UserID, id, head, ear, drum, nose, sinus, mouth, eye, opthal, pupil, ocular, lung, heart, vascular, abdomen, memo, date, state)
				 VALUES   (@UserID, @id, @head, @ear, @drum, @nose, @sinus, @mouth, @eye, @opthal, @pupil, @ocular, @lung, @heart, @vascular, @abdomen, @memo, convert(datetime, @today, 103), 0)", data);
			data.add("historyId", dbc.select(@"SELECT MAX(historyId) +1 AS MAX_ID FROM history", data).get("MAX_ID"));
			dbc.update(@"INSERT INTO history
				(patientId, historyId, staffId, memo, type, cntId, date, payId)
				 VALUES   (@UserID, @historyId, @nurseID, @memo, 3, @id, getDate(), 14)", data);
			dbc.close();
			return true;

		}
		/// <summary>
		/// update nurse form
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool update(Data data)
		{
			dbc = new DBC();
			dbc.open();
			dbc.update(@"UPDATE NursesForm
						SET        head = @head, ear = @ear, drum = @drum, nose = @nose, sinus = @sinus, mouth = @mouth, eye = @eye,
								   opthal = @opthal, pupil = @pupil, ocular = @ocular, lung = @lung, heart = @heart, vascular = @vascular, abdomen = @abdomen ,memo = @memo WHERE id = @ObservationID", data);
			dbc.update(@"UPDATE history
						SET        memo = @memo WHERE type = 3 AND cntId = @ObservationID", data);
			dbc.close();
			return true;
		}
		/// <summary>
		/// delete data from nurse form
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool delete(Data data)
		{
			dbc = new DBC();
			dbc.open();
			dbc.update(@"UPDATE history
						SET        status = '9' WHERE cntId = @ObservationID AND type = 3", data);
			//dbc.update("UPDATE NursesForm SET state = '9' WHERE id = @ObservationID", data);
			dbc.update("UPDATE NursesForm SET state = '9' WHERE date = convert(datetime, @date, 103) AND UserID = @UserID", data);
			dbc.close();
			
			return true;
		}

		public Data list(Data data)
		{
			throw new NotImplementedException();
		}
	}
}

