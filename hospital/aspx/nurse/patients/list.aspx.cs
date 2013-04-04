using System;
using BusinessTier;
using DataTier;

public partial class aspx_nurse_patients_list : BasePage
{
	protected override void Fire(object sender, EventArgs e)
	{

		if (!UserInfo.isNurse(Session))
		{
			alertAndGoback("you are not a nurse. Please login");
			return;
		}
		DBC dbc = new DBC();
	   // dbc.open();
	  //  Data param = new Data();
		Data data = new Data();
		data.add("nurseId", UserInfo.getId(Session));
		PatientBiz nurse = new PatientBiz();
		Data result = nurse.list(data);
		Patientlist.DataSource = result.Source;
		Patientlist.DataBind();

		Data roomResult = nurse.roomlist(data);
		RoomList.DataSource = roomResult.Source;
		RoomList.DataBind();
      
       
	}
}