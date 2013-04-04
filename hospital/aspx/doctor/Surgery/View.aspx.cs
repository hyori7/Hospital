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

public partial class aspx_doctor_Surgery_View : BasePage
{
	protected override void Fire(object sender, EventArgs e)
	{
		if (!UserInfo.isDoctor(Session))
		{
			alertAndGoback("you are not a doctor. Please login");
			return;
		}
		DBC dbc = new DBC();
		Data data = new Data();
		data.add("doctorId", UserInfo.getId(Session));
		data.add("surgeryId", Param.get("surgeryId"));
		/*dbc.open();
		result = dbc.select("SELECT * FROM DoctorsSurgery A, Users B WHERE A.UserID = B.UserID AND A.SurgeryID = @surgeryId", data);
		dbc.close();*/
		SurgeryBiz biz = new SurgeryBiz();
		Data result = biz.view(data);
		type.DataSource = biz.getType(data).Source;
		type.DataBind();
		userNameLabel.Text = result.getString("UserSurName") + "，" + result.getString("UserFirstName") + ",ID:" + result.getString("UserID"); 
		ROS.Text = result.getString("UserROS");
		DOS.Text = result.getString("UserDOS");
		surgery_description.Text = result.getString("UserSD");
		surgeryse.Text = result.getString("UserSSE");
		Memo.Text = result.getString("Memo");
		UserID.Text = result.getString("UserID");
		SurgeryID.Text = result.getString("SurgeryID");
		type.SelectedValue = result.getString("type");
		ROS.SelectedValue = result.getString("ROS");
	}

	protected void Update(Object sender, EventArgs e)
	{
		DBC dbc = new DBC();
		Data data = Param;
		SurgeryBiz biz = new SurgeryBiz();
		biz.update(data);
		go("~/aspx/doctor/history/list.aspx?pId=" + Param.getString("UserID"));
	}
	protected void Delete(Object sender, EventArgs e)
	{
		DBC dbc = new DBC();
		Data data = Param;
		/*dbc.open();
		dbc.update(@"UPDATE history
						SET        status = '9' WHERE cntId = @SurgeryID",Param);
		dbc.close();*/
		SurgeryBiz biz = new SurgeryBiz();
		biz.delete(data);
		go("~/aspx/doctor/history/list.aspx?pId=" + Param.getString("UserID"));
	}

}
