using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
	public class TestResult : BaseCommand
	{
		/// <summary>
		/// get a test data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override Data view(Data data)
		{
			Data result = select("SELECT * FROM DoctorsTestResult A, Users B WHERE A.UserID = B.UserID AND A.TestResultID = @testresultId", data);
			
			int count = result.Count;
			for (int i = 0; i < count; i++)
			{
				result.add(i, "DOT", result.getString(i, "DOT").Substring(0, 10));
			}

			return result;
		}

		/// <summary>
		/// create a new test
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool create(Data data)
		{
			dbc = new DBC();
			dbc.open();
			Object TestResultId = dbc.select("SELECT COUNT(TestResultID) + 1 AS MAX_ID FROM DoctorsTestResult", data).get("MAX_ID");
			String XrayMan = dbc.select("SELECT UserID FROM Users WHERE JobCOde = 17", new Data()).getString("UserID");
			String MRIMan = dbc.select("SELECT UserID FROM Users WHERE JobCOde = 21", new Data()).getString("UserID");
			data.add("TestResultID", TestResultId);
			data.add("XrayMan", XrayMan);
			data.add("MRIMan", MRIMan);
			dbc.update(@"INSERT INTO DoctorsTestResult
					(DoctorID, TestResultID, UserID, UserOR1, UserOR2, UserOR3, UserOR4, UserOR5, UserOR6,UserORT1,UserORT2,UserORT3,UserORT4,UserORT5,UserORT6,other_abnormalities, DOT, Memo, state)
					VALUES  (@DoctorID, @TestResultID, @UserID, @OR1, @OR2, @OR3, @OR4, @OR5, @OR6,@ORT1, @ORT2, @ORT3, @ORT4, @ORT5, @ORT6, @other_abnormalities, CONVERT(datetime, @DOT, 103), @Memo, 0)", data);
			data.add("historyId", dbc.select(@"SELECT   MAX(historyId) +1 AS MAX_ID FROM history", data).get("MAX_ID"));
			dbc.update(@"INSERT INTO history
				(patientId, historyId, staffId, memo, type, cntId, date, payId)
				 VALUES   (@UserID, @historyId, @DoctorID, @Memo, 1, @TestResultID, CONVERT(datetime, @DOT, 103), 12)", data);
			//order Xray
			if ("True".Equals(data.getString("Xray")))
			{
				String xRayMemo = "[" + data.getString("UserID") + "] FROM " + data.getString("DoctorID") + "\n" + data.getString("Memo");
				data.add("xRayMemo", xRayMemo);
				data.add("xHistoryId", int.Parse(data.getString("historyId")) + 1);
				dbc.update(@"INSERT INTO history
				(patientId, historyId, staffId, memo, type, cntId, date, payId)
				 VALUES   (@UserID, @xHistoryId, @XrayMan, @xRayMemo, -1, @TestResultID, CONVERT(datetime, @DOT, 103), 17)", data);
			}
			//order MRI
			if ("True".Equals(data.getString("MRI")))
			{
				String xRayMemo = "[" + data.getString("UserID") + "] FROM " + data.getString("DoctorID") + "\n" + data.getString("Memo");
				data.add("xRayMemo", xRayMemo);
				data.add("mHistoryId", int.Parse(data.getString("xHistoryId")) + 1);
				dbc.update(@"INSERT INTO history
				(patientId, historyId, staffId, memo, type, cntId, date, payId)
				 VALUES   (@UserID, @mHistoryId, @MRIMan, @xRayMemo, -1, @TestResultID, CONVERT(datetime, @DOT, 103), 18)", data);
			}
			dbc.close();
			return true;
		}
		/// <summary>
		/// update a test data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool update(Data data)
		{
			dbc = new DBC();
			dbc.open();
			dbc.update(@"UPDATE DoctorsTestResult
						SET        UserOR1 = @OR1, UserOR2 = @OR2, UserOR3 =@OR3, UserOR4 = @OR4, UserOR5 = @OR5, UserOR6 = @OR6, Memo = @Memo, DOT = CONVERT(datetime, @DOT, 103),
								   UserORT1 = @ORT1,UserORT2 = @ORT2, UserORT3 = @ORT3, UserORT4 = @ORT4, UserORT5 = @ORT5, UserORT6 = @ORT6,other_abnormalities = @other_abnormalities
								   WHERE TestResultID = @TestResultID", data);
			dbc.update(@"UPDATE history
						SET        Memo = @Memo WHERE type = 1 AND cntId = @TestResultID", data);
			dbc.close();
			return true;
		}

		/// <summary>
		/// delete a test
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool delete(Data data)
		{
			dbc = new DBC();
			dbc.open();
			dbc.update(@"UPDATE DoctorsOrder
						SET        state = '9' WHERE TestResultID = @TestResultID", data);
			dbc.update(@"UPDATE history
						SET        status = '9' WHERE type = 1 AND cntId = @TestResultID", data);
			dbc.close();

			return true;
		}
	}
}
