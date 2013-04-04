using System.Collections.Generic;
using System;
using System.Data;

namespace DataTier
{
	public class Data
	{
		protected Dictionary<Int64, Dictionary<String, Object>> list = new Dictionary<Int64, Dictionary<String, Object>>();
		protected Dictionary<Int64, Dictionary<String, Object>> sizeList = new Dictionary<Int64, Dictionary<String, Object>>();
		protected Dictionary<Int64, Dictionary<String, SqlDbType>> typeList = new Dictionary<Int64, Dictionary<String, SqlDbType>>();

		protected int rowCount = 0;
		protected int now = 0;
		protected String paging = null;

		private String errorMessage = null;

		

		public String Paging {
			get { return paging; }
			set { paging = value; }
		}

		//return the total row count
		public int RowCount
		{
			get { return rowCount; }
			set
			{
				rowCount = value;
			}
		}

		public int Now
		{
			get { return now; }
			set { now = value; }
		}

		public String ErrorMessage
		{
			get { return errorMessage; }
			set { errorMessage = value; }
		}

		//add value into Data using key
		public void add(String key, Object value)
		{
			add(0, key, value, -1);
		}

		//add value into Data using key
		public void add(String key, String value)
		{
			add(0, key, value, -1);
		}

		//add value into Data using index and key
		public void add(int index, String key, Object value)
		{
			add(index, key, value, -1);
		}

		//add value into Data using index, key and size
		public void add(int index, String key, Object value, int size)
		{
			//get parameters' information such as size and type
			//and add parameter into Data
			if (list.Count <= index)
			{
				index = list.Count;
				list.Add(index, new Dictionary<String, Object>());
				sizeList.Add(index, new Dictionary<String, Object>());
				typeList.Add(index, new Dictionary<String, SqlDbType>());
			}

			//remove previous data
			if (list[index].ContainsKey(key))
			{
				list[index].Remove(key);
				sizeList[index].Remove(key);
				typeList[index].Remove(key);
			}
			list[index].Add(key, value);

			sizeList[index].Add(key, size);

			typeList[index].Add(key, typeIs(value));

		}

		//get type information of parameters
		public SqlDbType typeIs(Object value)
		{
			if (value is String)
			{
				if (value.ToString().Length > 256)
				{
					return SqlDbType.NText;
				}
				else
				{
					return SqlDbType.NVarChar;
				}

			}
			else if (value is int)
			{
				return SqlDbType.Int;
			}
			else if (value is float)
			{
				return SqlDbType.Float;
			}
			else if (value is double)
			{
				return SqlDbType.Real;
			}
			else if (value is DateTime)
			{
				return SqlDbType.DateTime2;
			}

			return SqlDbType.NVarChar;
		}

		//translate Dictionary to DataTable 
		public DataTable Source
		{
			get
			{
				DataTable result = new DataTable();

				Object[] keys = this.getKeys();
				if (keys == null)
				{
					return result;
				}
				if (keys.Length == 0)
				{
					return result;
				}
				int length = keys.Length;
				for (int i = 0; i < length; i++)
				{
					result.Columns.Add(keys[i].ToString(), typeof(String));
				}
				int count = list.Count;
				
				for (int i = 0; i < count; i++)
				{
					DataRow row = result.NewRow();
					

					for (int j = 0; j < length; j++)
					{
						row[keys[j].ToString()] = get(i, j).ToString();
					}
					result.Rows.Add(row);
					
				}

				return result;

			}
		}
		//get a string value using index and key
		public String getString(Object key)
		{
			Object value = get(0, key);
			if (value == null)
			{
				return "";
			}
			return value.ToString();
		}

		//get a string value using index and key
		public String getString(String key)
		{
			Object value = get(0, key);
			if (value == null)
			{
				return "";
			}
			return value.ToString();
		}

		//get a boolean balue using index and key 
		public bool getBool(int index, Object key)
		{
			return "True".Equals(getString(index, key)) ? true : false;
		}

		//get a boolean balue using key 
		public bool getBool(Object key)
		{
			return getBool(0, key);
		}
		//get a string value using index and key
		public String getString(int index, Object key)
		{
			Object value = get(index, key);
			if (value == null)
			{
				return "";
			}
			return value.ToString();
		}
		//get a string value using index and key
		public String getString(int index, String key)
		{
			Object value = get(index, key);
			if (value == null)
			{
				return "";
			}
			return value.ToString(); 
		}


		//get a value using index and key
		public Object get(Object key)
		{
			return get(0, key);
		}


		//get the first value using key
		public Object get(String key)
		{
			return get(0, key);
		}

		//get a value using index and key(int)
		public Object get(int index, int key)
		{
			return get(index, getKeys(index)[key].ToString());
		}

		//get a value using index and key(Object)
		public Object get(int index, Object key)
		{
			return get(index, key.ToString());
		}

		//get a value using index and key(String)
		public Object get(int index, String key)
		{
			if (!list.ContainsKey(index)) return null;
			Dictionary<String, Object> dummy = list[index];
			if (!dummy.ContainsKey(key)) return null;
			dummy = list[index];
			return dummy[key];
		}

		//get a size of vlaue using key
		public int getSize(Object key)
		{
			return getSize(0, key);
		}

		//get a size of value using key
		public int getSize(String key)
		{
			return getSize(0, key);
		}

		//get a size of value using key
		public int getSize(int index, int key)
		{
			return getSize(index, getKeys()[key].ToString());
		}

		//get a size of value using key
		public int getSize(int index, Object key)
		{
			return getSize(index, key.ToString());
		}

		//get a size of value using key
		public int getSize(int index, String key)
		{
			if (!sizeList.ContainsKey(index)) return -1;
			Dictionary<String, Object> dummy = sizeList[index];
			if (!dummy.ContainsKey(key)) return -1;
			dummy = sizeList[index];
			return int.Parse(dummy[key].ToString());
		}

		//get a type of value using key
		public SqlDbType getType(String key)
		{
			return getType(0, key);
		}

		//get a type of value using key
		public SqlDbType getType(Object key)
		{
			return getType(0, key.ToString());
		}

		//get a type of value using key
		public SqlDbType getType(int index, int key)
		{
			return getType(index, getKeys()[key].ToString());
		}

		//get a type of value using key
		public SqlDbType getType(int index, Object key)
		{
			return getType(index, key.ToString());
		}

		//get a type of value using key
		public SqlDbType getType(int index, String key)
		{
			if (!typeList.ContainsKey(index)) return SqlDbType.NVarChar;
			Dictionary<String, SqlDbType> dummy = typeList[index];
			if (!dummy.ContainsKey(key)) return SqlDbType.NVarChar;
			dummy = typeList[index];
			return dummy[key];

		}

		public void remove(Int64 key)
		{
			list.Remove(key);
		}

		//remove a value using key
		public void remove(Object key)
		{
			remove(0, key.ToString());
		}

		//remove a value using key
		public void remove(String key)
		{
			remove(0, key);
		}

		//remove a value using index and key
		public void remove(int index, Object key)
		{
			remove(index, key.ToString());
		}

		//remove a value using index and key
		public void remove(int index, String key)
		{
			list[index].Remove(key);
		}

		//get a count
		public int Count
		{
			get
			{
				return list.Count;
			}
		}



		//get keys
		public Object[] getKeys()
		{
			return getKeys(0);
		}



		//get keys using index
		public Object[] getKeys(int index)
		{

			if (!list.ContainsKey(index)) return null;
			Dictionary<String, Object> dummy = list[index];
			int count = list[index].Count;
			Object[] keys = new Object[count];
			int now = 0;
			foreach (var key in dummy)
			{
				keys[now] = key.Key;
				++now;
			}
			return keys;
		}
	}
}
