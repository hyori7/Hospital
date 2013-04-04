using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessTier;
using DataTier;

public partial class aspx_xray_xray_create : BasePage
{
	protected XrayBiz biz = new XrayBiz();
	protected override void Fire(object sender, EventArgs e)
	{
		if (!UserInfo.isXrayOperator(Session))
		{
			alertAndGoback("you are not a X-ray operator. Please login");
			return;
		}
		if (!"".Equals(Param.getString("rId")))
		{
			Data dData = new Data();
			dData.add("XRayID", Param.getString("rId"));
			biz.delete(dData);
		}
		pId.Value = Param.getString("pId");
		historyId.Value = Param.getString("historyId");
		testId.Value = Param.getString("testId");
		Data data = new Data();
		data.add("TestResultID", testId.Value);
		Data result = biz.view(data);
		xrayView.DataSource = result.Source;
		xrayView.DataBind();
		
	}

	protected void uploadXray(object sender, EventArgs e)
	{
		if ("".Equals(name.Text))
		{
			alertAndGoback("Pleas, input a name of X-ray");
			return;
		}
		if( "".Equals(xRay.Value))
		{
			alertAndGoback("Pleas, input a file of X-ray");
			return;
		}
		if (xRay.Value.IndexOf(".asp") > -1 || 
			xRay.Value.IndexOf(".jsp") > -1 ||
			xRay.Value.IndexOf(".html") > -1)
		{
			alertAndGoback("Pleas, it is a wrong file");
			return;
		}

		Data data = new Data();
		data.add("pId", pId.Value);
		data.add("historyId", historyId.Value);
		data.add("TestResultID", testId.Value);
		data.add("path", WriteFile(xRay, testId.Value));
		data.add("name", name.Text);
		biz.create(data);
		Data result = biz.view(data);
		xrayView.DataSource = result.Source;
		xrayView.DataBind();

	}

	protected void goBack(object sender, EventArgs e)
	{
		go("~/aspx/xray/patients/list.aspx");
	}

	protected void onComplete(object sender, EventArgs e)
	{
		Data data = new Data();
		DoctorPatientsBiz dBiz = new DoctorPatientsBiz();
		data.add("hId", Param.getString("historyId"));
		dBiz.done(data);
		go("~/aspx/xray/patients/list.aspx");
	}

}
