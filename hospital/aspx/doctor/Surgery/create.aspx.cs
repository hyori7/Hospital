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

public partial class aspx_doctor_Surgery_create : BasePage
{
	protected override void Fire(object sender, EventArgs e)
	{
		if (!UserInfo.isDoctor(Session))
		{
			alertAndGoback("you are not a doctor. Please login");
			return;
		}

		String today = DateTime.Now.Date.ToString().Substring(0, 10);
		DOS.Text = today;
		UserID.Text = Param.getString("pId");
		Data result = new Data();
		DBC dbc = new DBC();

		Data data = new Data();
		/*dbc.open();
		data.add("pID", Param.get("pId"));
		result = dbc.select("SELECT * FROM Users WHERE UserID = @pId", data);
		dbc.close();*/
		SurgeryBiz biz = new SurgeryBiz();
		biz.view(data);
		userNameLabel.Text = Param.getString("pId");
		type.DataSource = biz.getType(data).Source;
		type.DataBind();
	}

	protected void onSubmit(object sender, EventArgs e)
	{
		DBC dbc = new DBC();
		Data data = Param;
		data.add("DoctorID", UserInfo.getId(Session));
		SurgeryBiz biz = new SurgeryBiz();
		biz.create(data);
		go("~/aspx/doctor/history/list.aspx?pId=" + Param.getString("UserID"));
	}

}
