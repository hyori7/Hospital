using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
	public class MedicineData : BaseCommand
	{
		/// <summary>
		/// get a list of medicine items
		/// </summary>
		/// <param name="value"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data getItems(String value, Data data)
		{
			String query = "SELECT * FROM GeneralPayment WHERE Type = 'Pharmacy' <SEARCH> ORDER BY Item ASC";
			if ("".Equals(value))
			{
				query = query.Replace("<SEARCH>", "");
			}
			else 
			{
				query = query.Replace("<SEARCH>", "AND Item LIKE '%" + value + "%'");
			}
			return select(query, data);
		}

		/// <summary>
		/// get a medicine data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override Data view(Data data)
		{
			String query = @"SELECT * FROM Medicine M, GeneralPayment G 
								WHERE G.ID = M.ItemId
									AND historyId = @HistoryId AND STATE = 0 ";
			return select(query, data);
		}

		/// <summary>
		/// create a medicine data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool create(Data data)
		{
			String getId = "SELECT COUNT(*) + 1 AS NEW_ID FROM Medicine ";
			String query = @"INSERT INTO Medicine 
							(medicineId, UserID, historyId, Quantity, itemId) 
							VALUES (@medicineId, @UserID, @historyId, @Quantity, @itemId)";
			dbc = new DBC();
			dbc.open();
			Object id = dbc.select(getId, new Data()).get("NEW_ID");
			data.add("medicineId", id);
			dbc.update(query, data);
			dbc.close();
			return true;

		}

		public override bool update(Data data)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// delete a medicine data
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool delete(Data data)
		{
			String query = "UPDATE Medicine SET state = 9 WHERE medicineId = @medicineId";
			update(query, data);
			return true;
		}

		/// <summary>
		/// get a list of items
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
        public Data droplist(Data data)
        {
            String query = "SELECT * FROM GeneralPayment WHERE Type = 'Pharmacy'";
            return select(query, data);
        }
	}
}
