using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using System.Data;


namespace DataTier
{
	public abstract class BaseCommand
	{
		protected DBC dbc = null;
		protected Data result;
		
		public abstract Data view(Data data);

		public abstract bool create(Data data);

		public abstract bool update(Data data);

		public abstract bool delete(Data data);

		/// <summary>
		/// get data from database
		/// </summary>
		/// <param name="query"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		protected Data select(String query, Data data) 
		{
			dbc = new DBC();
			dbc.open();
			result = dbc.select(query, data);
			dbc.close();
			dbc = null;
			return result;
		}

		/// <summary>
		/// select data from database using stored procedure
		/// </summary>
		/// <param name="spName"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		protected Data selectSP(String spName, Data data) {
			dbc = new DBC();
			dbc.open();
			result = dbc.selectSP(spName, data);
			dbc.close();
			dbc = null;
			return result;
		}

		/// <summary>
		/// update data at database
		/// </summary>
		/// <param name="query"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		protected bool update(String query, Data data)
		{
			int result;
			dbc = new DBC();
			dbc.open();
			result = dbc.update(query, data);
			dbc.close();
			dbc = null;
			return result > 0 ? true : false;
		}

		/// <summary>
		/// update data at database using stored procedure
		/// </summary>
		/// <param name="spName"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		protected bool updateSP(String spName, Data data)
		{
			int result;
			dbc = new DBC();
			dbc.open();
			result = dbc.updateSP(spName, data);
			dbc.close();
			dbc = null;
			return result > 0 ? true : false;
		}

		/// <summary>
		/// get data with paging
		/// </summary>
		/// <param name="query"></param>
		/// <param name="data"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		protected Data page(String query, Data data, String index)
		{
			dbc = new DBC();
			dbc.open();
			result = dbc.page(query, data, index);
			dbc.close();
			dbc = null;
			return result;
		}

		/// <summary>
		/// get data with paging using stored procedure
		/// </summary>
		/// <param name="query"></param>
		/// <param name="data"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		protected Data pageSP(String spName, String spCount, Data data)
		{
			dbc = new DBC();
			dbc.open();
			result = dbc.pageSP(spName, spCount, data);
			dbc.close();
			dbc = null;
			return result;
		}

		
	}
}
