﻿using System;
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

public partial class aspx_doctor_order_View : BasePage
{
	protected override void Fire(object sender, EventArgs e)
	{
		if (!UserInfo.isDoctor(Session))
		{
			alertAndGoback("you are not a doctor. Please login");
			return;
		}
		DBC dbc = new DBC();
		//dbc.open();
		Data data = new Data();
		data.add("doctorId", UserInfo.getId(Session));
		data.add("orderId", Param.get("orderId"));
		OrderBiz doctor = new OrderBiz();
		Data result = doctor.view(data);
		//result = dbc.select("SELECT * FROM DoctorsOrder A, Users B WHERE A.UserID = B.UserID AND A.orderId = @orderId", data);
		//dbc.close();
		userNameLabel.Text = result.getString("UserID");
		UserOD.Text = result.getString("UserOD");
		UsermedCheck.SelectedValue = result.getString("UsermedCheck");
		Usermed.Text = result.getString("Usermed");
		Usernas.SelectedValue = result.getString("Usernas");
		Userdosage.Text = result.getString("Userdosage");
		Userside.Text = result.getString("Userside");
		UserNAA.SelectedValue = result.getString("UserNAA");
		Memo.Text = result.getString("Memo");
		UserID.Text = result.getString("UserID");
		OrderID.Text = result.getString("orderId");
	}

	protected void Update(Object sender, EventArgs e)
	{
		//DBC dbc = new DBC();
		Data data = Param;
		OrderBiz biz = new OrderBiz();
		biz.update(data);
		go("~/aspx/doctor/history/list.aspx?pId=" + Param.getString("UserID"));
	}
	protected void Delete(Object sender, EventArgs e)
	{
		Data data = Param;
		DBC dbc = new DBC();
		OrderBiz biz = new OrderBiz();
		biz.delete(data);
		go("~/aspx/doctor/history/list.aspx?pId=" + Param.getString("UserID"));
	}

}
