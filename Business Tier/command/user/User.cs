using System;
using System.Data;
using System.Web.SessionState;
using DataTier;
using System.Collections.Generic;
namespace BusinessTier
{
	public class User : BaseCommand
	{
		/// <summary>
		/// get a user information using user id
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override DataTable select(Data data)
		{

			Data param = new Data();
			param.add("userId", data.getString("userId"));
			UserData ud = new UserData();

			//result.add("question", Cryptograph.Decrypt( result.getString("question") ));
			//result.add("answer", Cryptograph.Decrypt(result.getString("answer")));
			return ud.view(param).Source;
		}

		/// <summary>
		/// get a user information using user id
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data view(Data data) 
		{
			Data param = new Data();
			if (Text.isEmpty(data.getString("userId")))
			{
				param.add("userId", data.getString("UserID"));
			}
			else
			{
				param.add("userId", data.getString("userId"));
			}
			
			
			UserData ud = new UserData();

			//result.add("question", Cryptograph.Decrypt( result.getString("question") ));
			//result.add("answer", Cryptograph.Decrypt(result.getString("answer")));
			return ud.view(param);
		}

		/// <summary>
		/// update uesr information
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool update(Data data)
		{
			UserData ud = new UserData();
			return ud.update(data);
		}

		/// <summary>
		/// update patient information
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public bool updatePatient(Data data)
		{
			UserData ud = new UserData();
			return ud.updatePatient(data);
		}

		/// <summary>
		/// delete user information
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool delete(Data data)
		{
			UserData ud = new UserData();
			return ud.delete(data);
		}

		/// <summary>
		/// it will be deleted
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool insert(Data data)
		{
			/*
			if (!Text.isAble(data.getString("UserName"), 32))
			{
				return false;
			}
			if (!Text.isAble(data.getString("FirstName"), 32))
			{
				return false;
			}
			if (!Text.isAble(data.getString("SurName"), 32))
			{
				return false;
			}
			if (!Text.isAble(data.getString("Email"), 256))
			{
				return false;
			}
			Data param = new Data();
			param.add("UserId", data.get("UserName"));
			param.add("FirstName", data.get("FirstName"));
			param.add("SurName", data.get("SurName"));
			param.add("MiddleName", data.get("MiddleName"));
			//param.add("DOB", data.get("DOB"));
			param.add("Email", data.get("Email"));
			
			updateSP("registration", data);
			return true;
			 */
			return true;

		}

		/// <summary>
		/// logout function
		/// </summary>
		/// <param name="session"></param>
		public void logout(HttpSessionState session)
		{
			UserInfo.setInfo(session, null);
		}

		/// <summary>
		/// login using id and password
		/// </summary>
		/// <param name="data"></param>
		/// <param name="session"></param>
		/// <returns></returns>
		public HttpSessionState login(Data data, HttpSessionState session)
		{
			

			Data result = new Data();
			Data param = new Data();
			//check the id
			if (!Text.isAble(data.getString("id"), 32))
			{
				result.add(UserInfo.loginState, "Please, check your ID.");
				session = UserInfo.setInfo(session, result);
				return session;
			}
			// check the password
			else if (!Text.isAble(data.getString("pwd"), 32))
			{
				result.add(UserInfo.loginState, "Forgot your password?");
				session = UserInfo.setInfo(session, result);
				return session;
			}
			
			param.add("id", data.getString("id"));
			param.add("pwd", Cryptograph.Encrypt(data.getString("pwd")));

			UserData ud = new UserData();

			result = ud.logIn(param);

			if( result.Count == 0) {
				result.add(UserInfo.loginState, "Forgot your password or ID?");
				session = UserInfo.setInfo(session, result);
				return session;
			}
			result.add(UserInfo.loginState, "OK");
			return UserInfo.setInfo(session, result);
		}

		// it will be deleted
		public bool checkId(Data data)
		{
			if (!Text.isAble(data.getString("UserID"), 32))
			{
				return false;
			}
			Data param = new Data();
			param.add("UserID", data.get("UserID"));
			Data result = new Data();
			UserData ud = new UserData();
			result = ud.checkId(param);

			if (result.Count == 0)
			{
				return true;
			}

			return false;
		}

		// it will be deleted
		public override Data list(Data data)
		{
			Data param = new Data();
			UserData ud = new UserData();
			param.add("searchField", Text.ifEmpty(data.get("searchField"), ""));
			param.add("searchValue", Text.ifEmpty(data.get("searchValue"), ""));
			param.Now = data.Now;

			return ud.list(param);

		}

		// it will be deleted
		public Data rList(Data data)
		{
			Data param = new Data();
			UserData ud = new UserData();
			param.add("searchField", Text.ifEmpty(data.get("searchField"), ""));
			param.add("searchValue", Text.ifEmpty(data.get("searchValue"), ""));
			param.Now = data.Now;

			return ud.rList(param);
		}

		/// <summary>
		/// get a list of default information including state, sex, job and etc
		/// </summary>
		/// <returns></returns>
		public List<Data> getDefaultInfo()
		{
			UserData ud = new UserData();
			return ud.defaultData(new Data());
		}

		/// <summary>
		/// create a new user
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public String registration(Data data)
		{
			if (!checkId(data))
			{
				return "Please, choose another ID";
			}

			
			if (data.getString("CPassword").Equals(data.getString("Password")))
			{
				String pwd = Cryptograph.Encrypt(data.getString("Password"));
				data.add("Password", pwd);
				UserData ud = new UserData();
				ud.create(data);
			}

			return "OK";
		}

		/// <summary>
		/// create a new patient
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public String registratePatient(Data data)
		{

			if (!checkId(data))
			{
				return "Please, choose another ID";
			}


			if (data.getString("CPassword").Equals(data.getString("Password")))
			{
				String pwd = Cryptograph.Encrypt(data.getString("Password"));
				data.add("Password", pwd);
				UserData ud = new UserData();
				ud.createPatient(data);
			}

			return "OK";
		}

	}
}
