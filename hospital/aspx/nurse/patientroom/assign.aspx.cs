using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using BusinessTier;
using System.Collections.Generic;
using DataTier;

public partial class aspx_nurse_patientroom_assign : BasePage
{
	protected override void Fire(object sender, EventArgs e)
	{
		if (!UserInfo.isCheif(Session))
		{
			alertAndGoback("you are not a cheif nurse. Please login");
			return;
		}

		if( !"".Equals(Param.getString("pId"))) {
			delete(Param.getString("pId"), Param.getString("RoomID"));
			return;
		}
		String today = DateTime.Now.Date.ToString().Substring(0, 10);
		DBC dbc = new DBC();
		Data data = new Data();
		data.add("RoomID", Param.get("RoomID"));
		data.add("CaptID", UserInfo.getId(Session));
		//data.add("PatientID", Param.get("PatientID"));
		AssignBiz assign = new AssignBiz();
		Data result = assign.view(data);
		Data patients = assign.getPatients(data);
		roomLabel.Text = result.getString("RoomID");
		Room.Text = result.getString("RoomID");
		BedNumber.Text = result.getString("Beds");
		Level.Text = result.getString("LevelNumber");
		DeptName.Text = result.getString("DeptID");
		Data newPatient = assign.patientlist(data);
		for (int i = 0; i < patients.Count; i++)
		{
			patients.add(i, "StartDate", patients.getString(i, "StartDate").Substring(0, 10));
			patients.add(i, "EndDate", patients.getString(i, "EndDate").Substring(0, 10));
		}
		PatientList.DataSource = patients.Source;
		PatientList.DataBind();
		historyId.DataSource = newPatient.Source;
		historyId.DataBind();
		StartDate.Text = today;
	}

 
	protected void submit(object sender, EventArgs e)
	{
		if ("".Equals(Param.getString("EndDate")))
		{
			alertAndGoback("Please, insert the end date");
		}

		DBC dbc = new DBC();
		Data data = Param;
		data.add("CaptID", UserInfo.getId(Session));
		AssignBiz assign = new AssignBiz();
		assign.create(data);
		go("~/aspx/nurse/patientroom/list.aspx");
	}

	protected void cancel(object sender, EventArgs e)
	{
		go("~/aspx/nurse/patientroom/list.aspx");
	}

	protected void delete(string pId, string roomId)
	{
		Data data = new Data();
		data.add("PatientID", pId);
		data.add("RoomID", roomId);
		AssignBiz assign = new AssignBiz();
		assign.delete(data);
		go("/hospital/aspx/nurse/patientroom/assign.aspx?RoomID=" + roomId);
	}
}

