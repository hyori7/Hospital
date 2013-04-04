using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessTier;
using DataTier;

public partial class aspx_Payment_list : BasePage
{
	protected override void Fire(object sender, EventArgs e)
	{
		if (!UserInfo.IsSysAdmin(Session))
		{
			alertAndGoback("you are not a system administrator. Please login");
			return;
		}
		String ID = Param.getString("itemID");
		Data data = new Data();
		GeneralPaymentBiz biz = new GeneralPaymentBiz();
		if (!"".Equals(ID))
		{
			data.add("ID", ID);
			biz.delete(data);
		}
		Data result = biz.view(data);
		Data droplist = biz.droplist(data);


		for (int i = 0; i < result.Count; i++)
		{
			String state = "covered";
			if ("1".Equals(result.getString(i, "insuranceState")))
			{
				state = "not covered";
			}
			result.add(i, "insuranceState", state);
		}


		general_payment_items.DataSource = result.Source;
		general_payment_items.DataBind();

		Type.DataSource = droplist.Source;
		Type.DataBind();
		TypeDropDownList.DataSource = droplist.Source;
		TypeDropDownList.DataBind();
	}

	protected void onSearch(object sender, EventArgs e)
	{
		GeneralPaymentBiz biz = new GeneralPaymentBiz();
		Data data = Param;
		data.add("Type", Param.getString("Type"));
		Type.SelectedValue = Param.getString("Type");
		Data list = biz.list(Param.getString("searchValue"), data);
		for (int i = 0; i < list.Count; i++)
		{
			String state = "true";
			if ("1".Equals(list.getString(i, "insuranceState")))
			{
				state = "false";
			}
			list.add(i, "insuranceState", state);
		}
		general_payment_items.DataSource = list.Source;
		general_payment_items.DataBind();
	}

	protected void OnCreate(object sender, EventArgs e)
	{
		Data data = Param;
		GeneralPaymentBiz biz = new GeneralPaymentBiz();
		biz.create(data);
		go("~/aspx/Payment/general/list.aspx");
	}

}
