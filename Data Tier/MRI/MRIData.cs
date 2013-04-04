using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
	public class MRIData : BaseCommand
	{
		/// <summary>
		/// get a MRI data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override Data view(Data data)
		{
			String query = "SELECT * FROM MRI WHERE TestResultID = @TestResultID AND state = 0";
			return select(query, data);
		}

		/// <summary>
		/// create a new MRI data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool create(Data data)
		{
			String getId = "SELECT COUNT(*) + 1 AS NEW_ID FROM MRI";
			String query = "INSERT INTO MRI (MRIID, TestResultID, name, path) VALUES (@MRIID, @TestResultID, @name, @path)";
			dbc = new DBC();
			dbc.open();
			String id = dbc.select(getId, new Data()).getString("NEW_ID");
			data.add("MRIID", id);
			dbc.update(query, data);
			dbc.close();
			return true;
		}
		/// <summary>
		/// update a MRI data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool update(Data data)
		{
			String query = "UPDATE MRI SET name = @name, path = @path WHERE MRIID = @MRIID";
			return update(query, data);
		}

		/// <summary>
		/// delete a MRI data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool delete(Data data)
		{
			String query = "UPDATE MRI SET state = 9 WHERE MRIID = @MRIID";
			return update(query, data);
		}
	}
}
