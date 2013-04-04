using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
	public class RoomData : BaseCommand
	{
		/// <summary>
		/// get a room data
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

		/// <summary>
		/// update a room data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool update(Data data)
		{
			DBC dbc = new DBC();
			dbc.open();
			dbc.update(@"UPDATE Room
						SET        Type = @RoomType, UserId = @RoomOwner, Beds = @Beds WHERE RoomID = @RoomID", data);
			dbc.close();
			return true;
		}

		public override bool delete(Data data)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// get a list of rooms
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data list(Data data)
		{
			return select("Select * From Room Where DeptID = @DeptName", data);
		}

		/// <summary>
		/// get a list of rooms 
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data droplist(Data data)
		{
			return select("SELECT UserID FROM Users A, Roles B WHERE A.JobCode = B.JobCode AND B.GroupName in ('Doctors','nurse','administrator')", data);
		}

		/// <summary>
		/// get a list of depatments
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data Deptlist(Data data)
		{
			return select("Select * From DeptBeds", data);
		}
	}
}
