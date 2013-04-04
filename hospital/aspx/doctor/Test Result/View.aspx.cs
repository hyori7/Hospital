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

public partial class aspx_doctor_Test_Result_View : BasePage
{
	protected override void Fire(object sender, EventArgs e)
	{
		if (!UserInfo.isDoctor(Session))
		{
			alertAndGoback("you are not a doctor. Please login");
			return;
		}
		Data result = new Data();
		DBC dbc = new DBC();
		Data data = new Data();
		data.add("doctorId", UserInfo.getId(Session));
		data.add("testresultId", Param.get("testresultId"));
		/*dbc.open();
		result = dbc.select("SELECT * FROM DoctorsTestResult A, Users B WHERE A.UserID = B.UserID AND A.TestResultID = @testresultId", data);
		dbc.close();*/
		TestResultBiz biz = new TestResultBiz();
		result = biz.view(data);
		userNameLabel.Text = result.getString("UserSurName") + "，" + result.getString("UserFirstName") + ",ID:" + result.getString("UserID");
		DOT.Text = result.getString("DOT");
		OR1.SelectedValue = result.getString("UserOR1");
		OR2.SelectedValue = result.getString("UserOR2");
		OR3.SelectedValue = result.getString("UserOR3");
		OR4.SelectedValue = result.getString("UserOR4");
		OR5.SelectedValue = result.getString("UserOR5");
		OR6.SelectedValue = result.getString("UserOR6");
		ORT1.Text = result.getString("UserORT1");
		ORT2.Text = result.getString("UserORT2");
		ORT3.Text = result.getString("UserORT3");
		ORT4.Text = result.getString("UserORT4");
		ORT5.Text = result.getString("UserORT5");
		ORT6.Text = result.getString("UserORT6");
		other_abnormalities.Text = result.getString("other_abnormalities");
		Memo.Text = result.getString("Memo");
		UserID.Text = result.getString("UserID");
		TestResultID.Text = result.getString("TestResultID");
		XrayBiz xBiz = new XrayBiz();
		Data xData = new Data();
		xData.add("TestResultID", Param.get("testresultId"));
		Data xrayData = xBiz.view(xData);
		xrayView.DataSource = xrayData.Source;
		xrayView.DataBind();

		MRIBiz mBiz = new MRIBiz();
		Data MriData = mBiz.view(xData);
		MRIView.DataSource = MriData.Source;
		MRIView.DataBind();
	}

	protected void Update(Object sender, EventArgs e)
	{
		DBC dbc = new DBC();
		Data data = Param;
		TestResultBiz biz = new TestResultBiz();
		biz.update(data);
		go("~/aspx/doctor/history/list.aspx?pId=" + Param.getString("UserID"));
	}
	protected void Delete(Object sender, EventArgs e)
	{
		DBC dbc = new DBC();
		Data data = Param;
		TestResultBiz biz = new TestResultBiz();
		biz.delete(data);
		go("~/aspx/doctor/history/list.aspx?pId=" + Param.getString("UserID"));
	}
}
