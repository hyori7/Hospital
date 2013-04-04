using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace BusinessTier
{
	public class RoomBiz
	{
		/// <summary>
		/// get an information of a room
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data view(Data data)
		{
			RoomData doctor = new RoomData();
			return doctor.view(data);
		}

		/// <summary>
		/// update a room
		/// </summary>
		/// <param name="data"></param>
		public void update(Data data)
		{
			RoomData roomupdate = new RoomData();
			roomupdate.update(data);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data droplist(Data data)
		{
			RoomData droplist = new RoomData();
			return droplist.droplist(data);
		}

		/// <summary>
		/// get a list of rooms
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data list(Data data)
		{
			RoomData doctor = new RoomData();
			return doctor.list(data);
		}

		/// <summary>
		/// get a list of department
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data Deptlist(Data data)
		{
			RoomData doctor = new RoomData();
			return doctor.Deptlist(data);
		}

	}
}
