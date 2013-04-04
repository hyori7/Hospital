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

public partial class aspx_nurse_observation_create : BasePage
{
	protected override void Fire(object sender, EventArgs e)
	{
		if (!UserInfo.isNurse(Session))
		{
			alertAndGoback("you are not a nurse. Please login");
			return;
		}
		Data data = new Data();
		data.add("nurseId", UserInfo.getId(Session));
		nurseID.Text = UserInfo.getId(Session);
		data.add("pID", Param.getString("pId"));
		UserID.Text = Param.getString("pId");
		userNameLabel.Text = Param.getString("pId");

	}

 
	protected void submit_Click(object sender, EventArgs e)
	{

		Data data = Param;
		data.add("nurseID", UserInfo.getId(Session));
		ObservationBiz nurse = new ObservationBiz();
		nurse.create(data);
		go("~/aspx/nurse/patients/list.aspx");
	}

	protected void oncancel(object sender, EventArgs e)
	{
		go("~/aspx/nurse/patients/list.aspx");
	}
}
