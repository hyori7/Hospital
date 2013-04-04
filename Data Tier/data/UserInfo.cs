using System;
using System.Web.SessionState;
using DataTier;
using System.ComponentModel;

namespace DataTier
{
	public class UserInfo
	{
		private static String sName = "userInfo";
		public static String loginState = "loginState";
		public static String admin = "administrator";
		public static String sysAdmin = "sysAdmin";
		public static String user = "user";
		public static String XRay = "Xray";
		public static String MRI = "MRI";
		public static String CN = "18";
		public static String captain = "captain";
		public static int exist = 0;
		public static int deleted = 1;

		public UserInfo()
		{
		}
		/// <summary>
		/// set a user data
		/// </summary>
		/// <param name="session"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		public static HttpSessionState setInfo(HttpSessionState session, Data data)
		{
			session.Add(sName, data);
			return session;
		}
		
		/// <summary>
		/// get information of user
		/// </summary>
		/// <param name="session"></param>
		/// <param name="key"></param>
		/// <returns></returns>
		public static String get(HttpSessionState session, String key)
		{
			Data user = (Data)session[sName];

			if (user == null)
			{
				return "";
			}
			if (user.get(key) == null)
			{
				return "";
			}
			return user.get(key).ToString();
		}

		/// <summary>
		/// get a user id
		/// </summary>
		/// <param name="session"></param>
		/// <returns></returns>
		public static String getId(HttpSessionState session)
		{
			return get(session, "UserID");
		}
		/// <summary>
		/// get a user firnst name
		/// </summary>
		/// <param name="session"></param>
		/// <returns></returns>
		public static String getFirstName(HttpSessionState session)
		{
			return get(session, "UserFirstName");
		}

		/// <summary>
		/// get a user sur name
		/// </summary>
		/// <param name="session"></param>
		/// <returns></returns>
		public static String Surname(HttpSessionState session)
		{
			return get(session, "UserSurName");
		}

		/// <summary>
		/// get a user middle name
		/// </summary>
		/// <param name="session"></param>
		/// <returns></returns>
		public static String getMiddleName(HttpSessionState session)
		{
			return get(session, "UserMiddleName");
		}

		/// <summary>
		/// get a user job code
		/// </summary>
		/// <param name="session"></param>
		/// <returns></returns>
		public static String getJobCode(HttpSessionState session)
		{
			return get(session, "JobCode");
		}

		/// <summary>
		/// get a user group name
		/// </summary>
		/// <param name="session"></param>
		/// <returns></returns>
		public static String getGroupName(HttpSessionState session)
		{
			return get(session, "GroupName");
		}

		/// <summary>
		/// check a user role 
		/// </summary>
		/// <param name="session"></param>
		/// <returns></returns>
		public static bool isDoctor(HttpSessionState session) 
		{
			if ("Doctors".Equals(getGroupName(session)))
			{
				return true;
			}
			else if (int.Parse(Text.ifEmpty(get(session, "state"), "1")) == deleted)
			{
				return false;
			}
			else
			{
				return false;
			}

		}
		/// <summary>
		/// check a user role 
		/// </summary>
		/// <param name="session"></param>
		/// <returns></returns>
		public static bool isNurse(HttpSessionState session)
		{
			if ("nurse".Equals(getGroupName(session)))
			{
				return true;
			}
			else if (int.Parse(Text.ifEmpty(get(session, "state"), "1")) == deleted)
			{
				return false;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// check a user role 
		/// </summary>
		/// <param name="session"></param>
		/// <returns></returns>
		public static bool isReceptionist(HttpSessionState session)
		{
			if ("receptionist".Equals(getGroupName(session)))
			{
				return true;
			}
			else if (int.Parse(Text.ifEmpty(get(session, "state"), "1")) == deleted)
			{
				return false;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// check a user role 
		/// </summary>
		/// <param name="session"></param>
		/// <returns></returns>
		public static bool isPharmacist(HttpSessionState session)
		{
			if ("pharmacist".Equals(getGroupName(session)))
			{
				return true;
			}
			else if (int.Parse(Text.ifEmpty(get(session, "state"), "1")) == deleted)
			{
				return false;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// check a user role 
		/// </summary>
		/// <param name="session"></param>
		/// <returns></returns>
		public static bool IsAdmin(HttpSessionState session)
		{
			if (session[sName] == null)
			{
				return false;
			}
			else if ( int.Parse( Text.ifEmpty( get(session, "state"), "1")) == deleted)
			{
				return false;
			}
			else if ( getGroupName(session).Equals(admin)) {
				return true;
			}
			return false;
		}

		/// <summary>
		/// check a user role 
		/// </summary>
		/// <param name="session"></param>
		/// <returns></returns>
		public static bool IsSysAdmin(HttpSessionState session)
		{
			if (session[sName] == null)
			{
				return false;
			}
			else if (int.Parse(Text.ifEmpty(get(session, "state"), "1")) == deleted)
			{
				return false;
			}
			else if (getGroupName(session).Equals(sysAdmin))
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// check a user role 
		/// </summary>
		/// <param name="session"></param>
		/// <returns></returns>
		public static bool isXrayOperator(HttpSessionState session)
		{
			if (session[sName] == null)
			{
				return false;
			}
			else if (int.Parse(Text.ifEmpty(get(session, "state"), "1")) == deleted)
			{
				return false;
			}
			else if (getGroupName(session).Equals(XRay))
			{
				return true;
			}
			return false;
		}
		/// <summary>
		/// check a user role 
		/// </summary>
		/// <param name="session"></param>
		/// <returns></returns>
		public static bool isMriOperator(HttpSessionState session)
		{
			if (session[sName] == null)
			{
				return false;
			}
			else if (int.Parse(Text.ifEmpty(get(session, "state"), "1")) == deleted)
			{
				return false;
			}
			else if (getGroupName(session).Equals(MRI))
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// check a user role 
		/// </summary>
		/// <param name="session"></param>
		/// <returns></returns>
		public static bool isCheif(HttpSessionState session)
		{
			if (session[sName] == null)
			{
				return false;
			}
			else if (int.Parse(Text.ifEmpty(get(session, "state"), "1")) == deleted)
			{
				return false;
			}
			else if (getGroupName(session).Equals(captain))
			{
				return true;
			}
			return false;
		}

		

		// it will be deleted
		public static bool IsLogin(HttpSessionState session)
		{
			if (session[sName] == null)
			{
				return false;
			}
			else if (int.Parse(Text.ifEmpty(get(session, "state"), "1")) == deleted)
			{
				return false;

			}
			else
			{
				return true;
			}
		}

		// it will be deleted
		public static String getLoginState(HttpSessionState session)
		{
			return get(session, loginState);
		}
		// it will be deleted
		public static String getState(HttpSessionState session)
		{
			return get(session, "state");
		}
	}
}
