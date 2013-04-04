using System;
using BusinessTier;
using DataTier;

public partial class aspx_patientroom_list : BasePage
{
	protected override void Fire(object sender, EventArgs e)
	{
		if (!UserInfo.isCheif(Session))
		{
			alertAndGoback("you are not a cheif nurse. Please login");
			return;
		}
		Data data = new Data();
		data.add("nurseId", UserInfo.getId(Session));
		PRoomBiz room = new PRoomBiz();
		Data result = room.list(Param.getString("searchFiled"), Param.getString("searchValue"), data);

		Roomlist.DataSource = result.Source;
		Roomlist.DataBind();

		//Doctor's Order
		Data patients = room.newPatientsList(data);
		doctorOrder.DataSource = patients.Source;
		doctorOrder.DataBind();
	}
}