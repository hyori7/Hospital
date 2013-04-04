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

public partial class aspx_Pharmarcist_View : BasePage
{

	protected override void Fire(object sender, EventArgs e)
	{
		if (!UserInfo.isPharmacist(Session))
		{
			alertAndGoback("you are not a Pharmacist. Please login");
			return;
		}
		Data result = new Data();
		Data data = new Data();
		MedicineBiz bizz = new MedicineBiz();
		data.add("doctorId", UserInfo.getId(Session));
		data.add("historyId", Param.get("historyId"));
		historyId.Value = Param.getString("historyId");
		String rId = Param.getString("rId");
		if (!"".Equals(rId))
		{
			data.add("medicineId", rId);
			bizz.delete(data);
		}
		PharmacistBiz biz = new PharmacistBiz();
		result = biz.view(data); 
		userNameLabel.Text = result.getString("UserSurName") + "," + result.getString("UserFirstName") + ",ID:" + result.getString("UserID");
		Usermed.Text = result.getString("UserOD");
		Memo.Text = result.getString("Memo");
		UserID.Text = result.getString("UserID");
		OrderID.Text = result.getString("historyId");

		
		Data itemReslt = bizz.getItems("", data);
		Data medicineResult = bizz.view(data);

		MedicineDroplist.DataSource = itemReslt.Source;
		MedicineDroplist.DataBind();

		Medicinelist.DataSource = medicineResult.Source;
		Medicinelist.DataBind();

	}

	protected void Add_Click(object sender, EventArgs e)
	{
		DBC dbc = new DBC();
		Data data = Param;
		data.add("historyId", historyId.Value);
		data.add("UserID", UserInfo.getId(Session));
		data.add("Quantity", Quantity.Text);
		data.add("itemId", Param.getString("MedicineDroplist"));
		MedicineBiz biz = new MedicineBiz();
		biz.create(data);
		Data medicineResult = biz.view(data);
		Medicinelist.DataSource = medicineResult.Source;
		Medicinelist.DataBind();
		//go("~/aspx/Pharmarcist/View.aspx?pId=" + Param.getString("UserID"));
	}

	protected void onSearch(object sender, EventArgs e)
	{
		
		MedicineBiz biz = new MedicineBiz();
		Data result = biz.getItems(searchValue.Text, new Data());
		MedicineDroplist.DataSource = result.Source;
		MedicineDroplist.DataBind();
	}

	protected void goBack(object sender, EventArgs e)
	{
		go("~/aspx/Pharmacist/patients/list.aspx");
	}

	protected void onComplete(object sender, EventArgs e)
	{
		Data data = new Data();
		DoctorPatientsBiz dBiz = new DoctorPatientsBiz();
		data.add("hId", Param.getString("historyId"));
		dBiz.done(data);
		go("~/aspx/Pharmacist/patients/list.aspx");
	}

}
