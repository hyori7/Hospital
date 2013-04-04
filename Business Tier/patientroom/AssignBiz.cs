using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace BusinessTier
{
	public class AssignBiz
	{
		/// <summary>
		/// return list of patient in nurse view
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data view(Data data)
		{
			NewRoom room = new NewRoom();

			return room.view(data);
		}
		/// <summary>
		/// get a patients in a room
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data getPatients(Data data)
		{
			NewRoom room = new NewRoom();
			return room.getPatients(data);
		}

		/// <summary>
		/// create data for observation form
		/// </summary>
		/// <param name="data"></param>
		public void create(Data data)
		{
			NewRoom roomNew = new NewRoom();

			roomNew.create(data);
		}
		/// <summary>
		/// update data from observation list
		/// </summary>
		/// <param name="data"></param>
		public void update(Data data)
		{
			NewRoom updatedata = new NewRoom();

			updatedata.update(data);
		}
		/// <summary>
		/// delete data from observation list
		/// </summary>
		/// <param name="data"></param>
		public void delete(Data data)
		{
			NewRoom deletedata = new NewRoom();

			deletedata.delete(data);
		}

		/// <summary>
		/// get a list of patients
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data patientlist(Data data)
		{
			NewRoom patient = new NewRoom();
			return patient.patientlist(data);

		}
     
     
	}
}
