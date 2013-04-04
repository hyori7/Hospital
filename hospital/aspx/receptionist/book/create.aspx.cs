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

	protected void onCreate(object sender, EventArgs e)
	{
		//Param.add("staffId", UserInfo.getId(Session));
		Receptionist rec = new Receptionist();
		rec.create(Param);
		alertAndGo("it is booked!", "/hospital/aspx/receptionist/book/list.aspx");
	}

	protected void onCancel(object sender, EventArgs e)
	{
		alertAndGoback("Canceled");
	}
}
