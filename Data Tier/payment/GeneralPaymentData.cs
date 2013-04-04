using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
	public class GeneralPaymentData: BaseCommand
	{
		/// <summary>
		/// get a list of payment items
		/// </summary>
		/// <param name="value"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data list(String value, Data data)
		{
			String query = "SELECT * FROM GeneralPayment WHERE Type = @Type <SEARCH> ORDER BY Item ASC";
			if (value.Equals(""))
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
		/// create a new item
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool create(Data data)
		{
            String getId = "SELECT MAX(ID) + 1 AS NEW_ID FROM GeneralPayment";
            String query = @"INSERT INTO GeneralPayment 
								(ID, Item, Type, Price) 
								VALUES (@NEW_ID, @ItemTextBox, @TypeDropDownList, @PriceTextBox)";
			dbc = new DBC();
			dbc.open();
			Object id = dbc.select(getId, new Data()).get("NEW_ID");
            data.add("NEW_ID", id);
			dbc.update(query, data);
			dbc.close();
			return true;
		}

		/// <summary>
		/// update an item
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool update(Data data)
		{
            dbc = new DBC();
            dbc.open();
            dbc.update(@"UPDATE GeneralPayment 
							SET Item = @ItemTextBox, Type = @TypeDropDownList, Price = @PriceTextBox, insuranceState = @InsuranceStateTextBox
							WHERE ID = @itemID", data);
            dbc.close();
			return true;
		}

		/// <summary>
		/// delte an item
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public override bool delete(Data data)
		{
			String query = "DELETE From GeneralPayment WHERE ID = @ID";
			update(query, data);
			return true;
		}

		//get an item list data
        public override Data view(Data data)
        {
            String query = "SELECT * FROM GeneralPayment ORDER BY Item ASC";
            return select(query, data);
        }

		//get an item data
        public Data viewdetail(Data data)
        {
            String query = "SELECT * FROM GeneralPayment WHERE ID = @ID";
            return select(query, data);
        }

		/// <summary>
		/// get a type list
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
        public Data droplist(Data data)
        {
            String query = "SELECT Type FROM GeneralPayment GROUP BY Type";
            return select(query, data);
        }
    }
}
