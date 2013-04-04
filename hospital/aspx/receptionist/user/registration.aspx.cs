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

public partial class aspx_user_registration : BasePage
{
	protected override void Fire(object sender, EventArgs e)
	{
		if (!UserInfo.isReceptionist(Session))
		{
			alertAndGoback("Please, LOGIN!!");
			return;
		}

		User user = new User();
		List<Data> list = user.getDefaultInfo();
		Occupation.DataSource = list[0].Source;
		Occupation.DataBind();

		MaritalID.DataSource = list[1].Source;
		MaritalID.DataBind();
		/*
		JobCode.DataSource = list[2].Source;
		JobCode.DataBind();

		JobCode.SelectedIndex = 1;
		JobCode.Enabled = false;
		*/
		Nationality.DataSource = list[3].Source;
		Nationality.DataBind();

		TitleID.DataSource = list[4].Source;
		TitleID.DataBind();

		GenderID.DataSource = list[5].Source;
		GenderID.DataBind();

		StateCode.DataSource = list[6].Source;
		StateCode.DataBind();

		insuranceId.DataSource = list[7].Source;
		insuranceId.DataBind();
	}

	protected void onRegBtn(object sender, EventArgs e)
	{

		User user = new User();
		Data data = Param;
		data.add("JobCode", 0);
		String result = user.registratePatient(data);
		if (result.Equals("OK"))
		{
			alertAndGo("Congratulations!", "/hospital/aspx/receptionist/book/list.aspx");
			//alertAndGoback("Congratulations!");
		}
		else
		{
			alertAndGoback(result);
		}
	}
}
