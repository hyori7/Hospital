using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessTier;
using DataTier;

public partial class aspx_doctor_patients_list : BasePage
{


	protected override void Fire(object sender, EventArgs e)
	{
		if (!UserInfo.isDoctor(Session))
		{
			alertAndGoback("you are not a doctor. Please login");
			return;
		}
		//DBC dbc = new DBC();
		//dbc.open();
		String hId = Param.getString("hId");
		Data data = new Data();
		data.add("doctorId", UserInfo.getId(Session));
		
		//Data result = dbc.select("Select * From Users WHERE JobCode = 0 and UserID in (SELECT patientId FROM history WHERE staffId = @doctorId)", data);
		//dbc.close();
		DoctorPatientsBiz biz = new DoctorPatientsBiz();

		if (!"".Equals(hId))
		{
			data.add("hId", hId);
			biz.done(data);
		}
		Data result = biz.list(Param.getString("searchField"), Param.getString("searchValue"), data);
		Patientlist.DataSource = result.Source;
		Patientlist.DataBind();
		//error.Text = result.ErrorMessage;
	}

	protected void onSearch(object sender, EventArgs e)
	{
		DoctorPatientsBiz biz = new DoctorPatientsBiz();
		Data data = Param;
		data.add("doctorId", UserInfo.getId(Session));
		Data list = biz.list(Param.getString("searchField"), Param.getString("searchValue"), data);
		
		for (int i = 0; i < list.Count; i++)
		{
			list.add(i, "date", list.getString(i, "date").Substring(0, 10));
		}
		
		Patientlist.DataSource = list.Source;
		Patientlist.DataBind();
	}
}
