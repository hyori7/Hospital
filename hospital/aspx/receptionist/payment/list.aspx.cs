using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessTier;
using DataTier;
public partial class aspx_receptionist_payment_list : BasePage
{
	protected PatientPaymentBiz biz = new PatientPaymentBiz();

	protected override void Fire(object sender, EventArgs e)
	{
		/*
		if (!UserInfo.isReceptionist(Session))
		{
			alertAndGoback("you are not a receptionist. Please login");
			return;
		}
		*/
		String today = DateTime.Now.Date.ToString().Substring(0, 10);
		startDate.Text = today;
		endDate.Text = today;

	}

	protected void onSearch(object sender, EventArgs e)
	{
		startDate.Text = Param.getString("startDate");
		endDate.Text = Param.getString("endDate");
		Data result = biz.reportList(searchField.SelectedValue, searchValue.Text, Param);
		reportView.DataSource = result.Source;
		reportView.DataBind();
		title.Text = "Item report from [" + startDate.Text + "] to [" + endDate.Text + "]";
	}

	protected void onPrint(object sender, EventArgs e)
	{
		String today = DateTime.Now.Date.ToString().Substring(0, 10).Replace("/", "");
		String guid = Guid.NewGuid().ToString();
		String urlPath = "~/reportPDF/";
		String rootPath = Server.MapPath(urlPath);

		string path = rootPath + today + "_" + guid + ".pdf";

		toPDF(Text.decodeUri(html.Value), path);
		go(urlPath + today + "_" + guid + ".pdf");

		//return urlPath + today + "_" + guid + ".pdf";
	}
}
