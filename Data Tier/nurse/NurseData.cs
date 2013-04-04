using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{

	public class NurseData : BaseCommand
	{
        
		public override Data view(Data data)
		{
			throw new NotImplementedException();
		}

		public override bool create(Data data)
		{
			throw new NotImplementedException();
		}

		public override bool update(Data data)
		{
			throw new NotImplementedException();
		}

		public override bool delete(Data data)
		{
			throw new NotImplementedException();
		}
		/// <summary>
		/// set query to select patient ID and nurse ID. Search for patient.
		/// </summary>
		/// <param name="field"></param>
		/// <param name="value"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		public Data list(String field, String value,Data data)
		{
            String query = "Select * From history A, Users B WHERE A.patientId = B.UserID AND A.patientId = @pId AND A.staffId = @NurseID AND status = '0' <SEARCH> <DATE> ORDER BY historyId DESC";
            String date = data.getString("date");
            if (field.Equals(""))
            {
                query = query.Replace("<SEARCH>", "");
            }
            else if (field.Equals("memo"))
            {
                query = query.Replace("<SEARCH>", "AND memo LIKE '%" + value + "%'");
            }
            else if (field.Equals("patientId"))
            {
                query = query.Replace("<SEARCH>", "AND patientId LIKE '%" + value + "%'");
            }

            if (date.Equals(""))
            {
                query = query.Replace("<DATE>", "");
            }
            else
            {
                query = query.Replace("<DATE>", "AND CONVERT(VARCHAR(10), A.date, 103) = '<DATE>'".Replace("<DATE>", date));
            }

            return select(query, data);
		}
	}
}
