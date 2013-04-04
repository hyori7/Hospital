using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
	public class UserData : BaseCommand
	{
		/// <summary>
		/// get a user data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override Data view(Data data)
		{
			return select("SELECT * FROM Users WHERE userID = @userId", data);
		}

		/// <summary>
		/// create a new user
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool create(Data data)
		{
			int result = 0;
			String query = "INSERT INTO Users (UserID, UserFirstName, UserMiddleName, UserSurName, TitleID, GenderID, Occupation, MaritalID, ";
			query += "Address, DOB, StateCode, PostCode, Nationality, PhoneNumber, Email, JobCode)";
			query += "VALUES  (@UserID, @UserFirstName, @UserMiddleName, @UserSurName, @TitleID, @GenderID, @Occupation, @MaritalID,@Address, @DOB, @StateCode, @PostCode, @Nationality, @PhoneNumber, @Email, @JobCode)";
			dbc = new DBC();
			dbc.open();
			result = dbc.update(query, data);
			if (result < 0)
			{
				dbc.close();
				dbc = null;
				return false;
			}
			result= dbc.update("INSERT INTO UsersLogIn (UserID, Password) VALUES (@UserID, @Password)", data);
			dbc.close();
			dbc = null;
			return result != 0 ? true : false;
		}

		/// <summary>
		/// create a new patient
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public bool createPatient(Data data)
		{
			int result = 0;
			String query = @"INSERT INTO Users (UserID, UserFirstName, UserMiddleName, UserSurName, TitleID, GenderID, Occupation, MaritalID,
							Address, DOB, StateCode, PostCode, Nationality, PhoneNumber, 
							Email, JobCode, 
							PatientMotherLastName, PatientMotherFirstName, 
							PatientFatherLastName, PatientFatherFirstName,
							insuranceId)
							VALUES	(@UserID, @UserFirstName, @UserMiddleName, @UserSurName, 
									@TitleID, @GenderID, @Occupation, @MaritalID, @Address, 
									@DOB, @StateCode, @PostCode, @Nationality, @PhoneNumber, 
									@Email, @JobCode, 
									@PatientMotherLastName, @PatientMotherFirstName, 
									@PatientFatherLastName, @PatientFatherFirstName,
									@insuranceId)";
			dbc = new DBC();
			dbc.open();
			result = dbc.update(query, data);

			result = dbc.update("INSERT INTO UsersLogIn (UserID, Password) VALUES (@UserID, @Password)", data);
			dbc.close();
			dbc = null;
			return result != 0 ? true : false;
		}

		/// <summary>
		/// update a user data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool update(Data data)
		{
			String query = @"UPDATE Users
							SET	UserFirstName = @UserFirstName, UserMiddleName = @UserMiddleName , UserSurName = @UserSurName, 
							TitleID = @TitleID, GenderID = @GenderID, Occupation = @Occupation, MaritalID = @MaritalID, 
							JobCode = @JobCode, DOB = convert(datetime, @DOB, 103), StateCode = @StateCode, PostCode = @PostCode, Nationality = @Nationality, 
							PhoneNumber = @PhoneNumber, Email = @Email, Address = @Address 
							WHERE UserID = @UserID";
			//String queryPwd = @"UPDATE UsersLogIn SET Password = @Password WHERE UserID = @UserID" ;
			dbc = new DBC();
			dbc.open();
			dbc.update(query, data);
			//dbc.update(queryPwd, data);
			dbc.close();
			dbc = null;
			return true;
		}

		/// <summary>
		/// update a patient data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public bool updatePatient(Data data)
		{
			String query = @"UPDATE Users
							SET	UserFirstName = @UserFirstName, UserMiddleName = @UserMiddleName , UserSurName = @UserSurName, 
							TitleID = @TitleID, GenderID = @GenderID, Occupation = @Occupation, MaritalID = @MaritalID, 
							JobCode = @JobCode, DOB = convert(datetime, @DOB), StateCode = @StateCode, PostCode = @PostCode, Nationality = @Nationality, 
							PhoneNumber = @PhoneNumber, Email = @Email, Address = @Address, 
							PatientMotherLastName = @PatientMotherLastName, PatientMotherFirstName = @PatientMotherFirstName, 
							PatientFatherLastName = @PatientFatherLastName, PatientFatherFirstName = @PatientFatherFirstName,
							insuranceId = @insuranceId
							WHERE UserID = @UserID";
			//String queryPwd = @"UPDATE UsersLogIn SET Password = @Password WHERE UserID = @UserID";
			dbc = new DBC();
			dbc.open();
			dbc.update(query, data);
			//dbc.update(queryPwd, data);
			dbc.close();
			dbc = null;
			return true;
		}

		/// <summary>
		/// delete a uesr data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool delete(Data data)
		{
			String query = @"UPDATE Users SET state = 9 WHERE UserID = @UserID";
			return update(query, data);
		}

		/// <summary>
		/// get a list of users
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data list(Data data)
		{
			return pageSP("userList", "userCount", data);
		}

		/// <summary>
		/// get a default data to create a new user
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public List<Data> defaultData(Data data)
		{
			DBC dbc = new DBC();
			List<Data> list = new List<Data>();
			dbc.open();
			list.Add(dbc.select("SELECT * FROM Occupation", data));
			list.Add(dbc.select("SELECT * FROM Marital", data));
			list.Add(dbc.select("SELECT * FROM Roles", data));
			list.Add(dbc.select("SELECT * FROM Countries", data));
			list.Add(dbc.select("SELECT * FROM Title", data));
			list.Add(dbc.select("SELECT * FROM Gender", data));
			list.Add(dbc.select("SELECT * FROM AusState", data));
            list.Add(dbc.select("SELECT * FROM insurance", data));
			dbc.close();
			return list;
		}

		/// <summary>
		/// check a user id
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data checkId(Data data)
		{
			return select("SELECT * FROM Users WHERE UserID = @UserID ", data);
		}

		/// <summary>
		/// login 
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data logIn(Data data)
		{
			String query = "SELECT  Users.UserID, Users.UserFirstName, Users.UserMiddleName, Users.UserSurName, Users.TitleID, " +
							"Users.GenderID, Users.JobCode, Users.Occupation, Roles.GroupName, Roles.JobName, Users.DOB, Users.state " +
							"FROM     Users INNER JOIN " +
							"UsersLogIn ON Users.UserID = UsersLogIn.UserID INNER JOIN " +
							"Roles ON Users.JobCode = Roles.JobCode " +
							"WHERE Users.UserID = @id AND UsersLogIn.Password = @pwd";
			return select(query, data);
		}

		/// <summary>
		/// get a user list for receptionist
		/// </summary>
		/// <param name="param"></param>
		/// <returns></returns>
		public Data rList(Data param)
		{
			return pageSP("rUserList", "rUserCount", param);
		}
	}
}
