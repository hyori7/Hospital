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
	using DataTier;


	public partial class aspx_admin_Room_view : BasePage
	{
		protected override void Fire(object sender, EventArgs e)
		{
			DBC dbc = new DBC();
			//dbc.open();
			//dbc.select("SELECT UserID FROM Users A, Roles B WHERE A.JobCode = B.JobCode AND B.GroupName in ('Doctors','nurse','administrator')", Param);
			//Data result = dbc.select("SELECT * FROM Room WHERE RoomID = @roomID", Param);
			Data data = new Data();
			data.add("RoomID", Param.get("RoomID"));
			RoomBiz doctor = new RoomBiz();
			Data result = doctor.view(data);
			Data owners = doctor.droplist(data);
			RoomType.Text = result.getString("Type");
			Beds.SelectedValue = result.getString("Beds");
			RoomOwner.DataSource = owners.Source;
			RoomOwner.DataBind();
			RoomOwner.SelectedValue = result.getString("UserId");
			RoomLabel.Text = result.getString("RoomID");
			RoomID.Value = result.getString("RoomID");
			DeptName.Value = Param.getString("DeptName");
		}

		protected void Update(Object sender, EventArgs e)
		{
			//DBC dbc = new DBC();
			Data data = Param;
			data.add("RoomID", RoomID.Value);
			RoomBiz biz = new RoomBiz();
			biz.update(data);
			alertAndGo("changed!", "/hospital/aspx/admin/Room/list.aspx?DeptName=" + DeptName.Value);

			//go("~/aspx/admin/Room/list.aspx?");
		}
	}
