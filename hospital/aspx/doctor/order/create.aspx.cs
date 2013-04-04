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

public partial class aspx_doctor_order_create : BasePage
{
	protected override void Fire(object sender, EventArgs e)
	{
		if (!UserInfo.isDoctor(Session))
		{
			alertAndGoback("you are not a doctor. Please login");
			return;
		}
		UserID.Text = Param.getString("pId");
		//Data result = new Data();
		//DBC dbc = new DBC();
		//dbc.open();
		Data data = new Data();
		data.add("pId", Param.get("pId"));
		//result = dbc.select("SELECT * FROM Users WHERE UserID = @pId", data);
		//dbc.close();
		OrderBiz doctor = new OrderBiz();
		Data result = doctor.view(data);
		userNameLabel.Text = Param.getString("pId"); 
	}

	protected void Submit(object sender, EventArgs e)
	{
		DBC dbc = new DBC();
		Data data = Param;
		data.add("DoctorID", UserInfo.getId(Session));
		data.add("JobCode", UserInfo.getJobCode(Session));
		OrderBiz biz = new OrderBiz();
		biz.create(data);
		go("~/aspx/doctor/history/list.aspx?pId=" + Param.getString("UserID"));
	}
}
