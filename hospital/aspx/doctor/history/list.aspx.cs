using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessTier;
using DataTier;
public partial class aspx_doctor_history_list : BasePage
{

	protected override void Fire(object sender, EventArgs e)
	{
		if (!UserInfo.isDoctor(Session))
		{
			alertAndGoback("you are not a doctor. Please login");
			return;
		}

		Data data = new Data();
		data.add("doctorId", UserInfo.getId(Session));
		data.add("pID", Param.get("pId"));
        
		DoctorBiz doctor = new DoctorBiz();
		Data result = doctor.list(Param.getString("searchFiled"), Param.getString("searchValue"), data);

		pId.Value = data.getString("pID");
		DoctorID.Value = data.getString("doctorId");
		patienthistory.DataSource = result.Source;
		patienthistory.DataBind();
		userNameLabel.Text = result.getString("UserSurName") + "," + result.getString("UserFirstName") + ",ID:" + result.getString("UserID"); 
	}

	protected void NewOr(object sender, EventArgs e)
	{
		go("~/aspx/doctor/order/create.aspx?pId=" + pId.Value);
	}

	protected void NewSur(object sender, EventArgs e)
	{
		go("~/aspx/doctor/Surgery/create.aspx?pId=" + pId.Value);
	}

	protected void NewRes(object sender, EventArgs e)
	{
		go("~/aspx/doctor/Test Result/create.aspx?pId=" + pId.Value);
	}
	protected void Close(object sender, EventArgs e)
	{
		go("~/aspx/doctor/patients/list.aspx?doctorId=" + DoctorID.Value);
	}

	protected void onChange(object sender, EventArgs e)
	{
		Data data = new Data();
		data.add("doctorId", UserInfo.getId(Session));
		data.add("pID", Param.get("pId"));
		data.add("pre", pre.SelectedValue);
		DoctorBiz doctor = new DoctorBiz();
		Data result = doctor.list(Param.getString("searchFiled"), Param.getString("searchValue"), data);

		pId.Value = data.getString("pID");
		DoctorID.Value = data.getString("doctorId");
		int count = result.Count;
		for (int i = 0; i < count; i++)
		{
			result.add(i, "date", result.getString(i, "date").Substring(0, 10));
		}
		patienthistory.DataSource = result.Source;
		patienthistory.DataBind();
		userNameLabel.Text = result.getString("UserSurName") + "," + result.getString("UserFirstName") + ",ID:" + result.getString("UserID"); 
	}
}
