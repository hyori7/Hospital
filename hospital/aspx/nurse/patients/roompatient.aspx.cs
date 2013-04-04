using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System;
using BusinessTier;
using DataTier;

public partial class aspx_nurse_patients_roompatient : BasePage
{
	protected override void Fire(object sender, EventArgs e)
	{
		if (!UserInfo.isNurse(Session))
		{
			alertAndGoback("you are not a nurse. Please login");
			return;
		}
		Data data = new Data();
		roomLabel.Text = Param.getString("Room");
		data.add("nurseId", UserInfo.getId(Session));
		data.add("RoomID", Param.get("RoomID"));
		NurseID.Text = Param.getString("nurseId");
		AssignBiz assign = new AssignBiz();

		Data patients = assign.getPatients(data);
		
		patientroom.DataSource = patients.Source;
		patientroom.DataBind();
	}
}
