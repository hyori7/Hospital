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

public partial class aspx_doctor_Test_Result_Create : BasePage
{
	protected override void Fire(object sender, EventArgs e)
	{

		if (!UserInfo.isDoctor(Session))
		{
			alertAndGoback("you are not a doctor. Please login");
			return;
		}

		DateTime xToday = DateTime.Now.Date;
		DOT.Text = xToday.ToString().Substring(0, 10);
		//UserID.Text = Param.getString("pId");
		Data result = new Data();
		DBC dbc = new DBC();
		Data data = new Data();
		data.add("pID", Param.get("pId"));
		UserID.Value = Param.getString("pId");

		TestResultBiz biz = new TestResultBiz();
		result = biz.view(data);
		userNameLabel.Text = result.getString("UserSurName") + "," + result.getString("UserFirstName") + ",ID:" + result.getString("UserID");
	}

	protected void Submit(object sender, EventArgs e)
	{
		DBC dbc = new DBC();
		Data data = Param;
		data.add("DoctorID", UserInfo.getId(Session));

		TestResultBiz biz = new TestResultBiz();
		biz.create(data);
		go("~/aspx/doctor/history/list.aspx?pId=" + Param.getString("UserID"));
	}
}
