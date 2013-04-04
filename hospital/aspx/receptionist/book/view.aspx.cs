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

public partial class aspx_receptionist_book_create : BasePage
{

	protected override void Fire(object sender, EventArgs e)
	{
		if (!UserInfo.isReceptionist(Session))
		{
			alertAndGoback("PLEASE, LOGIN");
			return;
		}
		if (Text.isEmpty(Param.getString("historyId")))
		{
			alertAndGoback("please, select a history id");
		}
		Receptionist rec = new Receptionist();
		Data result = rec.view(Param);
		Data pParam = new Data();
		pParam.add("searchValue", result.get("UserID"));
		pParam.add("searchField", "UserID");
		Data patient = rec.getPatient(pParam);
		Data staffList = rec.getStaff(Param);

		patientId.DataSource = patient.Source;
		patientId.DataBind();

		staffId.DataSource = staffList.Source;
		staffId.DataBind();

		historyId.Text = result.getString("historyId");
		memo.Text = result.getString("memo");
		patientId.SelectedValue = result.getString("patientId");
		staffId.SelectedValue = result.getString("staffId");
		date.Text = result.getString("date").Substring(0, 10);

	}

	protected void onSearch(object sender, EventArgs e)
	{
		if (Text.isEmpty(searchValue.Text))
		{
			return;
		}
		Receptionist rec = new Receptionist();
		Data patient = rec.getPatient(Param);
		Data staffList = rec.getStaff(Param);
		patientId.DataSource = patient.Source;
		patientId.DataBind();

		staffId.DataSource = staffList.Source;
		staffId.DataBind();
	}

	protected void onUpdate(object sender, EventArgs e)
	{
		//Param.add("staffId", UserInfo.getId(Session));
		Receptionist rec = new Receptionist();
		rec.update(Param);
		alertAndGo("it is updated!", "/hospital/aspx/receptionist/book/list.aspx");
	}

	protected void onDelete(object sender, EventArgs e)
	{
		//Param.add("staffId", UserInfo.getId(Session));
		Receptionist rec = new Receptionist();
		rec.delete(Param);
		alertAndGo("it is deleted!", "/hospital/aspx/receptionist/book/list.aspx");
	}

	protected void onCancel(object sender, EventArgs e)
	{
		go("/hospital/aspx/receptionist/book/list.aspx");
		//alertAndGo("Canceled", "/hospital/aspx/receptionist/book/list.aspx");
	}
}
