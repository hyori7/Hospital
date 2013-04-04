using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace BusinessTier
{
	public class NurseBiz
	{
		/// <summary>
		/// return list of data from nursesform
		/// </summary>
		/// <param name="field"></param>
		/// <param name="value"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data list(String field, String value, Data data)
		{
           
          
			NurseData nurse = new NurseData();
			return nurse.list(field, value, data);
		}
	}
}
