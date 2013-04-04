using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
	public class SurgeryData : BaseCommand
	{
		/// <summary>
		/// get a surgery data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override Data view(Data data)
		{
			Data result = select("SELECT * FROM DoctorsSurgery A, Users B WHERE A.UserID = B.UserID AND A.SurgeryID = @surgeryId", data);
			int count = result.Count;
			for (int i = 0; i < count; i++)
			{
                result.add(i, "UserDOS", result.getString(i, "UserDOS").Substring(0, 10));
			}
			return result;
		}

		/// <summary>
		/// create a new surgery data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool create(Data data)
		{
			dbc = new DBC();
			dbc.open();
			Object SurgeryID = dbc.select("SELECT COUNT(SurgeryID) + 1 AS MAX_ID FROM DoctorsSurgery", data).get("MAX_ID");
			data.add("SurgeryID", SurgeryID);
			dbc.update(@"INSERT INTO DoctorsSurgery
					(DoctorID, SurgeryID, type, UserID, UserDOS, UserROS, UserSD, UserSSE, Memo, state)
					VALUES  (@DoctorID, @SurgeryID, @type, @UserID, convert(datetime, @DOS, 103), @ROS, @surgery_description, @surgeryse, @Memo, 0)", data);
			data.add("historyId", dbc.select(@"SELECT MAX(historyId) +1 AS MAX_ID FROM history", data).get("MAX_ID"));
			// based on the type, patient's payment price will be decided.
			dbc.update(@"INSERT INTO history
				(patientId, historyId, staffId, memo, type, cntId, date, payId)
				 VALUES   (@UserID, @historyId, @DoctorID, @Memo, 2, @SurgeryID, CONVERT(datetime, @DOS, 103), @type)", data);
			dbc.close();
			return true;
		}

		/// <summary>
		/// update a sergery data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool update(Data data)
		{
			dbc = new DBC();
			dbc.open();
			dbc.update(@"UPDATE DoctorsSurgery
						SET        UserDOS = convert(datetime, @DOS, 103), Memo = @Memo, UserROS = @ROS, UserSD = @surgery_description, UserSSE = @surgeryse WHERE SurgeryID = @SurgeryID", data);
			dbc.update(@"UPDATE history
						SET        Memo = @Memo WHERE type = 2 AND cntId = @SurgeryID", data);
			dbc.close();
			return true;
		}

		/// <summary>
		/// delete a surgery data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool delete(Data data)
		{
			dbc = new DBC();
			dbc.open();
			dbc.update(@"UPDATE DoctorsOrder
						SET        state = '9' WHERE SurgeryID = @SurgeryID", data);
			dbc.update(@"UPDATE history SET status = '9' WHERE type = 2 AND cntId = @SurgeryID", data);				
			dbc.close();
			
			return true;
		}

		/// <summary>
		/// get a list of surgery type
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data getType(Data data)
		{
			return select("SELECT * FROM GeneralPayment WHERE Type = 'surgery'", data);
		}
	}
}
