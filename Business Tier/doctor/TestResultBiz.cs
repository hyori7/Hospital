using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTier;

namespace BusinessTier
{
	public class TestResultBiz
	{
		/// <summary>
		/// view a test result
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data view(Data data)
		{
			TestResult result = new TestResult();

			return result.view(data);
		}
		/// <summary>
		/// create a new test result
		/// </summary>
		/// <param name="data"></param>
		public void create(Data data)
		{
			TestResult testData = new TestResult();

			testData.create(data);
		}
		/// <summary>
		/// update a test result
		/// </summary>
		/// <param name="data"></param>
		public void update(Data data)
		{
			TestResult updatedata = new TestResult();

			updatedata.update(data);
		}
		/// <summary>
		/// delete a test result
		/// </summary>
		/// <param name="data"></param>
		public void delete(Data data)
		{
			TestResult deletedata = new TestResult();

			deletedata.delete(data);
		}
	}
}
