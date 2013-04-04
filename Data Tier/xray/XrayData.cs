using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
	public class XrayData : BaseCommand
	{
		/// <summary>
		/// get a X-ray data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override Data view(Data data)
		{
			String query = "SELECT * FROM XRay WHERE TestResultID = @TestResultID AND state = 0";
			return select(query, data);
		}

		/// <summary>
		/// create a new X-ray data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool create(Data data)
		{
			String getId = "SELECT COUNT(*) + 1 AS NEW_ID FROM XRay";
			String query = "INSERT INTO XRay (XRayID, TestResultID, name, path) VALUES (@XRayID, @TestResultID, @name, @path)";
			dbc = new DBC();
			dbc.open();
			String id = dbc.select(getId, new Data()).getString("NEW_ID");
			data.add("XRayID", id);
			dbc.update(query, data);
			dbc.close();
			return true;
		}
		/// <summary>
		/// update a X-ray data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool update(Data data)
		{
			String query = "UPDATE XRay SET name = @name, path = @path WHERE XRayID = @XRayID";
			return update(query, data);
		}

		/// <summary>
		/// delete a X-ray data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool delete(Data data)
		{
			String query = "UPDATE XRay SET state = 9 WHERE XRayID = @XRayID";
			return update(query, data);
		}
	}
}
