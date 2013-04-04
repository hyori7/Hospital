using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
	public class InsuranceData : BaseCommand
	{
		/// <summary>
		/// get a insurance list data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data list(Data data)
		{
			String query = "SELECT * FROM Insurance WHERE state = 0 ORDER BY insuranceName ASC";
			return select(query, new Data());
		}

		/// <summary>
		/// get an insurance data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override Data view(Data data)
		{
			String query = "SELECT * FROM Insurance WHERE insuranceId = @insuranceId";
			return select(query, data);
		}

		/// <summary>
		/// create a new insurance data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool create(Data data)
		{
			String getId = "SELECT MAX(insuranceId) + 1 AS NEW_ID FROM Insurance";
			String query = @"INSERT INTO Insurance 
							(insuranceId, insuranceName, rate, state) 
							VALUES (@insuranceId, @insuranceName, @rate, 0)";
			dbc = new DBC();
			dbc.open();
			Object id = dbc.select(getId, new Data()).get("NEW_ID");
			data.add("insuranceId", id);
			dbc.update(query, data);
			dbc.close();
			return true;
		}

		/// <summary>
		/// update an insurance data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool update(Data data)
		{
			String query = "UPDATE Insurance SET insuranceName = @insuranceName, rate = @rate WHERE insuranceId = @insuranceId";
			return update(query, data);
		}

		/// <summary>
		/// delete an insurance data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool delete(Data data)
		{
			String query = "UPDATE Insurance SET state = 9 WHERE insuranceId = @insuranceId";
			return update(query, data);
		}
	}
}
