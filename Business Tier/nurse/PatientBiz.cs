using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace BusinessTier
{
	public class PatientBiz
	{
		/// <summary>
		/// List of data from patients
		/// </summary>
		/// <param name="field"></param>
		/// <param name="value"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		
		public Data list(Data data)
		{
			Patient nurse = new Patient();
			return nurse.list(data);

		}
		/// <summary>
		/// get a list of room
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data roomlist(Data data)
		{
			Patient room = new Patient();
			return room.roomlist(data);
		}
		/// <summary>
		/// get a patient list in a room
		/// </summary>
		/// <param name="field"></param>
		/// <param name="value"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data patientroomlist(String field, String value, Data data)
		{
			Patient roomplist = new Patient();
			return roomplist.patientroomlist(data);
		}
	}
}
