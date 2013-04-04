using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
	public class Patient : BaseCommand
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
		/// select patient
		/// </summary>
		/// <param name="field"></param>
		/// <param name="value"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data list(Data data)
		{
			String today = DateTime.Now.Date.ToString().Substring(0, 10);
			data.add("today", today);
			String query = @"SELECT *, 
								(SELECT COUNT(*) FROM NursesForm N 
								WHERE N.UserID = P.PatientID
									AND N.state = 0
									AND N.date = convert(datetime, @today, 103)

								)AS Observation 
							FROM Room R, patientRoom P, Users U
							WHERE P.Room = R.RoomID 
								AND R.UserId = @NurseID
								AND U.UserID = P.PatientID
								AND P.StartDate <= convert(datetime, @today, 103) 
								AND P.EndDate >= convert(datetime, @today, 103)
								ORDER BY P.PatientID ASC";
			Data result = select(query, data);
			int count = result.Count;
			for (int i = 0; i < count; i++)
			{
				result.add(i, "StartDate", result.getString(i, "StartDate").Substring(0,10));
				result.add(i, "EndDate", result.getString(i, "EndDate").Substring(0, 10));
			}
			return result;
		}
		//public Data list(Data data)
		//{
		//    return select("Select * From Users WHERE JobCode = 0 ORDER BY UserID DESC", data);
		//}
		public Data roomlist(Data data)
		{
			//return select("Select * From Room WHERE UserId = @NurseID", data);
			//return select("Select * From Room", data);
			String today = DateTime.Now.Date.ToString().Substring(0, 10);
			data.add("today", today);
			String query = @"Select R.*, 
							(SELECT COUNT(*) FROM PatientRoom 
								WHERE Room = R.RoomID 
									AND StartDate <= convert(datetime, @today, 103) 
									AND EndDate >= convert(datetime, @today, 103)) AS P_COUNT 
							FROM Room R 
							WHERE R.UserId = @NurseID
							ORDER BY RoomID DESC";
			return select(query, data);
		}

		/// <summary>
		/// get a patients' list in a room
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data patientroomlist(Data data)
		{
			//return select("Select * From PatientRoom A, Room B WHERE A.Room = B.RoomID AND B.UserId = @NurseID", data);
			return select("Select * From PatientRoom WHERE Room = @RoomID", data);
		}
      
	}

}
