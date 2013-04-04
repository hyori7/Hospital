using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
	public class Room : BaseCommand
	{
		/// <summary>
		/// get a room list
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override Data view(Data data)
		{
			return select("SELECT * FROM Room WHERE RoomID = @RoomID", data);
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
			string today = DateTime.Now.Date.ToString().Substring(0, 10);
			data.add("today", today);
			String query = @"Select R.*, 
							(SELECT COUNT(*) FROM PatientRoom 
								WHERE Room = R.RoomID 
									AND StartDate <= convert(datetime, @today, 103) 
									AND EndDate >= convert(datetime, @today, 103)) AS P_COUNT 
							FROM Room R 
							WHERE DeptID = 'Oncology' 
							ORDER BY RoomID DESC";
			return select(query, data);
		}

		/// <summary>
		/// get a list of new patients
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data newPatientsList(Data data)
		{
			//return select("Select UserID, Memo From DoctorsOrder WHERE UserStay = 'True'", data);
			String query = @"SELECT H.historyId, H.patientId, H.memo
							FROM history H, Users U 
							WHERE U.UserID = H.staffId
								AND H.status = 0
								AND H.staffId = @nurseId
							ORDER BY H.patientId ASC";
			return select(query, data);
		}
	}
}
