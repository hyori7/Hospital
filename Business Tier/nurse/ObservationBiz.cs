using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace BusinessTier
{
	public class ObservationBiz
	{
		/// <summary>
		/// return list of patient in nurse view
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data view(Data data)
		{
			Observation observation = new Observation();

			return observation.view(data);
		}

		/// <summary>
		/// create data for observation form
		/// </summary>
		/// <param name="data"></param>
		public void create(Data data)
		{
			Observation observationNew = new Observation();

			observationNew.create(data);
		}
		/// <summary>
		/// update data from observation list
		/// </summary>
		/// <param name="data"></param>
		public void update(Data data)
		{
			Observation updatedata = new Observation();

			updatedata.update(data);
		}
		/// <summary>
		/// delete data from observation list
		/// </summary>
		/// <param name="data"></param>
		public void delete(Data data)
		{
			Observation deletedata = new Observation();

			deletedata.delete(data);
		}

	}
}
