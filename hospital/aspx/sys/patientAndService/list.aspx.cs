using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessTier;
using DataTier;

public partial class aspx_sys_itemReport_list : BasePage
{
	protected ReportBiz biz = new ReportBiz();

	protected override void Fire(object sender, EventArgs e)
	{
		if (!UserInfo.IsSysAdmin(Session))
		{
			alertAndGoback("you are not a system administrator. Please login");
			return;
		}
		String today = DateTime.Now.Date.ToString().Substring(0, 10);
		startDate.Text = today;
		endDate.Text = today;
	}

	protected void onSearch(object sender, EventArgs e)
	{
		startDate.Text = Param.getString("startDate");
		endDate.Text = Param.getString("endDate");
		Data result = biz.getPatientAndServiceReport(Param);
		itemReportView.DataSource = result.Source;
		itemReportView.DataBind();
		title.Text = "Patient and service report from [" + startDate.Text + "] to [" + endDate.Text + "]";
		print.Visible = true;
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
