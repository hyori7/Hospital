using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
	public class DoctorOrder : BaseCommand
	{
		/// <summary>
		/// get an order data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override Data view(Data data)
		{
			return select("SELECT * FROM DoctorsOrder A, Users B WHERE A.UserID = B.UserID AND A.orderId = @orderId", data);
		}

		/// <summary>
		/// create a new order data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool create(Data data)
		{
			String medication = data.getString("UsermedCheck");
			String UserNAA = data.getString("UserNAA");
			String UserStay = data.getString("UserStay");
			
			String doctorType = data.getString("JobCode");
			String payId = "11";
			DateTime xToday = DateTime.Now.Date;
			if ("19".Equals(doctorType))
			{
				payId = "15";
			}
			else if ("20".Equals(doctorType))
			{
				payId = "16";
			}
			data.add("PDate", xToday.ToString().Substring(0, 10));
			dbc = new DBC();
			dbc.open();
			Object orderId = dbc.select("SELECT COUNT(orderId) + 1 AS MAX_ID FROM DoctorsOrder", data).get("MAX_ID");
			data.add("orderId", orderId);
			dbc.update(@"INSERT INTO DoctorsOrder
				(DoctorID, UserID, orderId, UserOD, UsermedCheck, Usermed, Usernas, Userdosage, Userside, UserNAA, Memo, state)
				 VALUES   (@DoctorID, @UserID, @orderId, @UserOD, @UsermedCheck, @Usermed,
				 @Usernas, @Userdosage, @Userside, @UserNAA, @Memo, 0)", data);
			data.add("historyId", dbc.select(@"SELECT MAX(historyId) +1 AS MAX_ID FROM history", data).get("MAX_ID"));
			data.add("PDate", xToday.ToString().Substring(0, 10));
			dbc.update(@"INSERT INTO history
				(patientId, historyId, staffId, memo, type, cntId, date, payId)
				 VALUES   (@UserID, @historyId, @DoctorID, @Memo, 0, @orderId, CONVERT(datetime, @PDate, 103), " + payId + ")", data);
			// create a new appointment
			if ("True".Equals(UserNAA))
			{
				data.add("historyId", int.Parse(data.getString("historyId")) + 1);
				dbc.update(@"INSERT INTO history
				(patientId, historyId, staffId, memo, type, cntId, date)
				 VALUES   (@UserID, @historyId, @DoctorID, @Memo, -1, @orderId, CONVERT(datetime, @date, 103))", data);
			}
			// order medicine
			if ("True".Equals(medication))
			{
				
				String getPharmarcist = "SELECT UserID FROM Users WHERE JobCode = 16";
				String pharmacist = dbc.select(getPharmarcist, data).getString("UserID");
				data.add("staffID", pharmacist);
				data.add("historyId", int.Parse(data.getString("historyId")) + 1);
				dbc.update(@"INSERT INTO history
				(patientId, historyId, staffId, memo, type, cntId, date)
				 VALUES   (@UserID, @historyId, @staffID, @Usermed, -1, @orderId, CONVERT(datetime, @PDate, 103))", data);
			}
			// order user to stay hospital for a while
			if ("True".Equals(UserStay))
			{
				
				String getNurse = "SELECT UserID FROM Users WHERE JobCode = 18";
				String nurse = dbc.select(getNurse, data).getString("UserID");
				data.add("staffID", nurse);
				data.add("historyId", int.Parse(data.getString("historyId")) + 1);
				dbc.update(@"INSERT INTO history
				(patientId, historyId, staffId, memo, type, cntId, date)
				 VALUES   (@UserID, @historyId, @staffID, @Memo, -1, @orderId, CONVERT(datetime, @PDate, 103))", data);
			}
			dbc.close();
			return true;
		}
		/// <summary>
		/// update an order data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool update(Data data)
		{
			dbc = new DBC();
			dbc.open();
			dbc.update(@"UPDATE DoctorsOrder
						SET        UserOD = @UserOD, UsermedCheck = @UsermedCheck, Usermed = @Usermed,
								   Usernas = @Usernas, Userdosage = @Userdosage, Userside = @Userside, UserNAA = @UserNAA, Memo = @Memo WHERE orderId = @orderId", data);
			dbc.update(@"UPDATE history
						SET        Memo = @Memo WHERE cntId = @orderId", data);
			dbc.close();
			return true;
		}

		/// <summary>
		/// delete an order data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool delete(Data data)
		{
			dbc = new DBC();
			dbc.open();
			dbc.update(@"UPDATE DoctorsOrder
						SET        state = '9' WHERE orderId = @OrderID", data);
			dbc.update(@"UPDATE history
						SET        status = '9' WHERE type = 0 AND cntId = @OrderID", data);
			dbc.close();
			
			return true;
		}

		public Data list(Data data)
		{
			throw new NotImplementedException();
		}
	}
}
