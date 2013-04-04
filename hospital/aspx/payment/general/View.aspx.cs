using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessTier;
using DataTier;

public partial class aspx_Payment_View : BasePage
{
	protected override void Fire(object sender, EventArgs e)
	{
		if (!UserInfo.IsSysAdmin(Session))
		{
			alertAndGoback("you are not a system administrator. Please login");
			return;
		}
		Data data = new Data();
		data.add("ID", Param.get("itemID"));
		GeneralPaymentBiz biz = new GeneralPaymentBiz();
		Data result = biz.viewdetail(data);
		Data droplist = biz.droplist(data);
		TypeDropDownList.DataSource = droplist.Source;
		TypeDropDownList.DataBind();
		TypeDropDownList.SelectedValue = result.getString("Type");
		ItemTextBox.Text = result.getString("Item");
		PriceTextBox.Text = result.getString("Price");
		InsuranceStateTextBox.SelectedValue = result.getString("insuranceState");
		ItemID.Text = result.getString("ID");
	}

	protected void OnUpdate(object sender, EventArgs e)
	{
		Data data = Param;
		GeneralPaymentBiz biz = new GeneralPaymentBiz();
		biz.update(data);
		alertAndGo("Updated!", "/hospital/aspx/Payment/general/list.aspx");
	}

	protected void OnCancel(object sender, EventArgs e)
	{
		alertAndGo("Canceled", "/hospital/aspx/Payment/general/list.aspx");
	}
}
