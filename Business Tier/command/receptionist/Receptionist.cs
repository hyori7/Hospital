using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace BusinessTier
{
	public class Receptionist
	{
		//data tier of receptionist
		private ReceptionistData recData = new ReceptionistData();
		/// <summary>
		/// get a list of pateints
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data getPatient(Data data)
		{
			return recData.getPatient(data.getString("searchField"), data.getString("searchValue"));
		}

		/// <summary>
		/// get a staff list 
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data getStaff(Data data)
		{
			return recData.getStaff();
		}
		/// <summary>
		/// get a book list
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data list(Data data)
		{
			return recData.list(data);
		}

		/// <summary>
		/// update book information
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public bool update(Data data)
		{
			return recData.update(data);
		}

		/// <summary>
		/// delete a book 
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public bool delete(Data data)
		{
			return recData.delete(data);
		}

		/// <summary>
		/// create a new book information
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public bool create(Data data)
		{
			return recData.create(data);
		}

		/// <summary>
		/// view the book information
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data view(Data data)
		{
			Data param = new Data();
			param.add("historyId", data.get("historyId"));
			return recData.view(param);
		}
	}
}
