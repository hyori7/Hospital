using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
	public class NewRoom : BaseCommand
	{
		/// <summary>
		/// Select nurse form base on current user ID
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override Data view(Data data)
		{
			return select("SELECT * FROM Room WHERE RoomID = @RoomID", data);
		}

		/// <summary>
		/// get a pateints' list in a room
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data getPatients(Data data)
		{
			String today = DateTime.Now.Date.ToString().Substring(0,10);
			data.add("today", today);

			String query = @"SELECT U.UserID, U.UserFirstName +' ' + U.UserSurName + '(' + U.UserID + ')' AS name, U.PhoneNumber, P.StartDate, P.EndDate, P.Room,
								(SELECT COUNT(*) FROM NursesForm N 
								WHERE N.UserID = P.PatientID
									AND N.date = convert(datetime, @today, 103)
								)AS Observation 
								FROM Users U, PatientRoom P 
								WHERE U.UserID = P.PatientID
								AND P.StartDate <= convert(datetime, @today, 103) 
								AND P.EndDate >= convert(datetime, @today, 103)
								AND P.Room = @RoomID";
			Data patients = select(query, data);
			for (int i = 0; i < patients.Count; i++)
			{
				patients.add(i, "StartDate", patients.getString(i, "StartDate").Substring(0, 10));
				patients.add(i, "EndDate", patients.getString(i, "EndDate").Substring(0, 10));
			}
			return patients;
		}
    
		/// <summary>
		/// create a relationship between patient and room
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool create(Data data)
		{
			String getPId = "SELECT patientId FROM history WHERE historyId = @historyId";
			DBC dbc = new DBC();

			dbc.open();
			String pateintId = dbc.select(getPId, data).getString("patientId");
			data.add("PatientID", pateintId);
			dbc.update(@"INSERT INTO PatientRoom
				(PatientID, Room, BedNumber, Level, DeptName, StartDate, EndDate)
				 VALUES   (@PatientID, @Room, @BedNumber, @Level, @DeptName, convert(datetime, @StartDate, 103), convert(datetime, @EndDate, 103))", data);
			dbc.update(@"UPDATE history 
						SET status = 1 WHERE historyId = @historyId" , data);
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
//       
			DBC dbc = new DBC();
			dbc.open();
			dbc.update(@"UPDATE PatientRoom
						SET      Room = @RoomID, BedNumber = @BedNumber, Level = @Level, BedNumber = @BedNumber, SratDate = @StratDate, EndDate = @EndDate WHERE  PatientID = @PatientID", data);
			dbc.close();
			return true;
		}
      
		/// <summary>
		/// delete a patient from a room
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool delete(Data data)
		{
			String today = DateTime.Now.Date.ToString().Substring(0, 10);
			data.add("today", today);
			String query = "UPDATE PatientRoom SET EndDate = convert(datetime, @today, 103) WHERE Room = @RoomID AND PatientID = @PatientID";
			DBC dbc = new DBC();
			dbc.open();
			dbc.update(query, data);
			//dbc.update(@"DELETE From PatientRoom WHERE PatientID = @PatientID", data);
			dbc.close();
			return true;
		}
        
   
		/// <summary>
		/// get a list of new patients
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data patientlist(Data data)
		{
			//return select("Select * From Users WHERE JobCode = 0 ORDER BY UserID DESC", data);
			String query = @"SELECT H.historyId, H.patientId
							FROM history H, Users U 
							WHERE U.UserID = H.staffId
								AND H.status = 0
								AND H.staffId = @CaptID
							ORDER BY H.patientId ASC";
			return select(query, data);
		}
   
	}
}
