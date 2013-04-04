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
	protected MRIBiz biz = new MRIBiz();
	protected override void Fire(object sender, EventArgs e)
	{
		if (!UserInfo.isMriOperator(Session))
		{
			alertAndGoback("you are not a MRI operator. Please login");
			return;
		}
		if (!"".Equals(Param.getString("rId")))
		{
			Data dData = new Data();
			dData.add("MRIID", Param.getString("rId"));
			biz.delete(dData);
		}
		pId.Value = Param.getString("pId");
		historyId.Value = Param.getString("historyId");
		testId.Value = Param.getString("testId");
		Data data = new Data();
		data.add("TestResultID", testId.Value);
		Data result = biz.view(data);
		mriView.DataSource = result.Source;
		mriView.DataBind();
		
	}

	protected void uploadMRI(object sender, EventArgs e)
	{
		if ("".Equals(name.Text))
		{
			alertAndGoback("Pleas, input a name of MRI");
			return;
		}
		if ("".Equals(MRI.Value))
		{
			alertAndGoback("Pleas, input a file of MRI");
			return;
		}
		if (MRI.Value.IndexOf(".asp") > -1 ||
			MRI.Value.IndexOf(".jsp") > -1 ||
			MRI.Value.IndexOf(".html") > -1)
		{
			alertAndGoback("Pleas, it is a wrong file");
			return;
		}
		Data data = new Data();
		data.add("pId", pId.Value);
		data.add("historyId", historyId.Value);
		data.add("TestResultID", testId.Value);
		data.add("path", WriteFile(MRI, testId.Value));
		data.add("name", name.Text);
		biz.create(data);
		Data result = biz.view(data);
		mriView.DataSource = result.Source;
		mriView.DataBind();

	}

	protected void goBack(object sender, EventArgs e)
	{
		go("~/aspx/MRI/patients/list.aspx");
	}

	protected void onComplete(object sender, EventArgs e)
	{
		Data data = new Data();
		DoctorPatientsBiz dBiz = new DoctorPatientsBiz();
		data.add("hId", Param.getString("historyId"));
		dBiz.done(data);
		go("~/aspx/MRI/patients/list.aspx");
	}

}
