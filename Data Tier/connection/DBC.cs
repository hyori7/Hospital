using System;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace DataTier
{
	public class DBC
	{
		
		//Data Source=LAB-GPS515-11\SQLEXPRESS;Initial Catalog=ChatDB;Integrated Security=True;Pooling=False
		protected static String dataSource = ".";
		protected static String initialCatalog = "ChatDB";
		protected static String security = "SSPI";
		protected static String path = "";

		protected SqlConnection conn = null;
		protected SqlTransaction tran = null;
		protected SqlDataReader rdr = null;
		protected SqlCommand cmd = null;


		//set a database information
		public static void setDBInfo(String dataSource, String initialCatalog, String security)
		{
			DBC.dataSource = dataSource;
			DBC.initialCatalog = initialCatalog;
			DBC.security = security;
			DBC.path = "";
		}

		//set a database information
		public static void setDBInfo(String dataSource, String initialCatalog, String security, String path)
		{
			DBC.dataSource = dataSource;
			DBC.initialCatalog = initialCatalog;
			DBC.security = security;
			DBC.path = path;
		}

		//open the database
		public void open()
		{
			try
			{
				// Open 

				//Data Source=.\SQLEXPRESS;AttachDbFilename="F:\group44\n7000049\Presentation Tier\App_Data\ChatDB.mdf";Integrated Security=True;User Instance=True
				String connString = "Data Source=" + dataSource + "\\SQLEXPRESS;Pooling=True;Initial Catalog=" + initialCatalog + ";Integrated Security=" + security;
				if (!path.Equals(""))
				{
					connString += ";AttachDbFilename=" + path +";User Instance=True;";
				}
				

				conn = new SqlConnection(connString);
				conn.Open();
				
			}
			catch (SqlException ex)
			{
				Console.WriteLine(ex.ToString());
				conn.Close();
			}

		}

		//close the databse
		public void close()
		{
			// Close the connection
			if (conn != null)
			{
				
				conn.Close();
				conn = null;
			}
		}


		//select data as paging Form
		public Data page(String query, Data data, String index)
		{
			int from = data.Now * Paging.RowSize;
			int size = Paging.RowSize;
			//pageing query
			String pQuery = "SELECT E_PAGING.* FROM (SELECT  TOP (" + size + ") M_PAGING.* "
							+ "FROM     (SELECT  TOP (" + (size + from) + ") PAGE_TABLE.* FROM ("
							+ query
							+ ") AS PAGE_TABLE ORDER BY <INDEX> ASC"
							+ ") AS M_PAGING ORDER BY <INDEX> DESC ) AS E_PAGING";

			//total count
			String cQuery = "SELECT COUNT(*) AS MAX_COUNT FROM (" + query + " ) AS COUNTING";
			pQuery = pQuery.Replace("<INDEX>", index).Replace("\n", "");
			cQuery = cQuery.Replace("\\n\\r", "");

			Data result = select(pQuery, data);
			result.RowCount = (int)select(cQuery, data).get("MAX_COUNT");
			result.Now = data.Now;
			result.Paging = Paging.make(result);
			return result;
		}

		public Data pageSP(String spName, String spCount, Data data) {
			data.add("from", data.Now * Paging.RowSize);
			data.add("size", Paging.RowSize);
			Data result = selectSP(spName, data);
			data.remove("from");
			data.remove("size");
			result.RowCount = (int)selectSP(spCount, data).get("MAX_COUNT");
			result.Now = data.Now;
			result.Paging = Paging.make(result);
			return result;
		}

		//select data from database using query string
		public Data select(String query, Data data)
		{
			cmd = null;
			Data result = new Data();
			try
			{
				cmd = new SqlCommand(query, conn);

				String key = null;

				SqlDbType sType = SqlDbType.NVarChar;
				int size = -1;
				Object[] keys = data.getKeys();
				Object value = null;
				int now = 0;
				//add parameters using keys
				if (keys != null)
				{
					int length = keys.Length;


					for (int i = 0; i < length; i++)
					{
						key = "@" + keys[i].ToString();
						value = data.get(keys[i]);
						size = data.getSize(key);
						sType = data.getType(key);

						if (size > 0)
						{
							cmd.Parameters.Add(key, sType);
						}
						else
						{
							cmd.Parameters.Add(key, sType, size);
						}

						cmd.Parameters[key].Value = value;

					}
				}
				// get query results
				rdr = cmd.ExecuteReader();

				//save result into Data
				while (rdr.Read())
				{
					int fCount = rdr.FieldCount;
					for (int i = 0; i < fCount; i++)
					{
						result.add(now, rdr.GetName(i), rdr.GetValue(i));
					}
					++now;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				result.ErrorMessage = e.Message;

			}
			finally
			{
				if (cmd != null)
				{
					cmd.Parameters.Clear();
				}
				// close the reader
				if (rdr != null)
				{
					rdr.Close();
				}
			}
			return result;
		}

		//select data from database using stored procedure 
		public Data selectSP(String spName, Data data)
		{
			cmd = null;
			Data result = new Data();
			try
			{
				cmd = new SqlCommand();
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = spName;
				cmd.Connection = conn;

				String key = null;

				SqlDbType sType = SqlDbType.NVarChar;
				int size = -1;
				Object[] keys = data.getKeys();
				Object value = null;
				int now = 0;
				//add parameters using keys
				if (keys != null)
				{
					int length = keys.Length;


					for (int i = 0; i < length; i++)
					{
						key = "@" + keys[i].ToString();
						value = data.get(keys[i]);
						size = data.getSize(key);
						sType = data.getType(key);

						if (size > 0)
						{
							cmd.Parameters.Add(key, sType);
						}
						else
						{
							cmd.Parameters.Add(key, sType, size);
						}

						cmd.Parameters[key].Value = value;

					}
				}
				// get query results
				rdr = cmd.ExecuteReader();

				//save result into Data
				while (rdr.Read())
				{
					int fCount = rdr.FieldCount;
					for (int i = 0; i < fCount; i++)
					{
						result.add(now, rdr.GetName(i), rdr.GetValue(i));
					}
					++now;
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				result.ErrorMessage = e.Message;

			}
			finally
			{
				if (cmd != null)
				{
					cmd.Parameters.Clear();
				}
				// close the reader
				if (rdr != null)
				{
					rdr.Close();
				}
			}
			return result;
		}
			

		//update, insert and delete data in database using query string
		public int update(String query, Data data)
		{
			cmd = null;
			int result = 0;
			try
			{
				tran = conn.BeginTransaction();
				cmd = new SqlCommand(query, conn);
				cmd.Transaction = tran;
				String key = null;

				SqlDbType sType = SqlDbType.NVarChar;
				int size = -1;
				Object[] keys = data.getKeys();
				Object value = null;
				int length = keys.Length;
				//add parameters using keys
				if (keys != null)
				{
					for (int i = 0; i < length; i++)
					{
						key = "@" + keys[i].ToString();
						value = data.get(keys[i]);
						size = data.getSize(key);
						sType = data.getType(key);

						if (size > 0)
						{
							cmd.Parameters.Add(key, sType);
						}
						else
						{
							cmd.Parameters.Add(key, sType, size);
						}

						cmd.Parameters[key].Value = value;

					}
				}
				result = cmd.ExecuteNonQuery();
				tran.Commit();

			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				//Trace. (e.Message);
				result = -1;
				tran.Rollback();
				
			}
			finally
			{
				if (cmd != null)
				{
					cmd.Parameters.Clear();
				}
				

			}
			return result;
		}
		//update, insert and delete data in database using stored procedure
		public int updateSP(String spName, Data data)
		{
			cmd = null;
			int result = 0;
			try
			{
				tran = conn.BeginTransaction();
				cmd = new SqlCommand();
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = spName;
				cmd.Connection = conn;
				cmd.Transaction = tran;
				String key = null;

				SqlDbType sType = SqlDbType.NVarChar;
				int size = -1;
				Object[] keys = data.getKeys();
				Object value = null;
				int length = keys.Length;
				//add parameters using keys
				if (keys != null)
				{
					for (int i = 0; i < length; i++)
					{
						key = "@" + keys[i].ToString();
						value = data.get(keys[i]);
						size = data.getSize(key);
						sType = data.getType(key);

						if (size > 0)
						{
							cmd.Parameters.Add(key, sType);
						}
						else
						{
							cmd.Parameters.Add(key, sType, size);
						}

						cmd.Parameters[key].Value = value;

					}
				}
				result = cmd.ExecuteNonQuery();
				tran.Commit();

			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				
				//Trace. (e.Message);
				tran.Rollback();

			}
			finally
			{
				if (cmd != null)
				{
					cmd.Parameters.Clear();
				}


			}
			return result;
		}
	}

	
}
