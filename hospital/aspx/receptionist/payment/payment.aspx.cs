using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessTier;
using DataTier;

public partial class aspx_receptionist_payment_payment : BasePage
{
	protected PatientPaymentBiz biz = new PatientPaymentBiz();

	protected override void Fire(object sender, EventArgs e)
	{
		if (!UserInfo.isReceptionist(Session))
		{
			alertAndGoback("PLEASE, LOGIN");
			return;
		}
		float rate;
		Data data = new Data();
		pId.Value = Param.getString("pId");
		data.add("patientId", Param.getString("pId"));
		List<Data> result = biz.view(data);
		
		rate = float.Parse(result[2].getString("rate"));
		rate = 100 - rate;
		int count = result[0].Count;
		float total = 0;
		for (int i = 0; i < count; i++)
		{
			float price = float.Parse(result[0].getString(i,"Price"));
			if ("0".Equals(result[0].getString(i, "insuranceState")))
			{
				price = (price * rate) / 100;
			}
			price = (price - price % (float)0.01);
			result[0].add(i, "afterPrice", price);
			result[0].add(i, "date", result[0].getString(i, "date").Substring(0, 10));
			total += price;
		}
		count = result[1].Count;
		for (int i = 0; i < count; i++)
		{
			float price = float.Parse(result[1].getString(i, "T_Price"));
			if ("0".Equals(result[1].getString(i, "insuranceState")))
			{
				price = (price * rate) / 100;
			}
			price = (price - price % (float)0.01);
			result[1].add(i, "afterPrice", price);
			result[1].add(i, "date", result[1].getString(i, "date").Substring(0, 10));
			total += price;
		}

		historyView.DataSource = result[0].Source;
		historyView.DataBind();
		medicineView.DataSource = result[1].Source;
		medicineView.DataBind();
		User userBiz = new User();
		data.add("userId", pId.Value );
		Data pData = userBiz.view(data);
		userInfo.Text = pData.getString("UserID") + " [" + pData.getString("UserFirstName") + ", " + pData.getString("UserSurName") + "]";
		totalPrice.Text = total.ToString();
		USEREMAIL.Text = pData.getString("Email");
		INSURANNUMBER.Text = pData.getString("InsuranceNumber");
		CREATEDDATE.Text = DateTime.Now.Date.ToString().Substring(0, 10);
		
		
	}

	protected void onPrint(object sender, EventArgs e)
	{	
		String today = DateTime.Now.Date.ToString().Substring(0, 10).Replace("/","");
		String guid = Guid.NewGuid().ToString();
		String urlPath = "~/payPDF/";
		String rootPath = Server.MapPath(urlPath);
		
		string path = rootPath + today + "_" + guid + ".pdf";
		
		toPDF(Text.decodeUri(html.Value), path );
		go(urlPath + today + "_" + guid + ".pdf");
		//return urlPath + today + "_" + guid + ".pdf";
	}

	protected void onCreate(object sender, EventArgs e)
	{
		String today = DateTime.Now.Date.ToString().Substring(0, 10).Replace("/", "");
		String guid = Guid.NewGuid().ToString();
		String urlPath = "~/payPDF/";
		String rootPath = Server.MapPath(urlPath);

		string path = rootPath + today + "_" + guid + ".pdf";

		toPDF(Text.decodeUri(html.Value), path);
		//go(urlPath + today + "_" + guid + ".pdf");
		//return urlPath + today + "_" + guid + ".pdf";
		//PatientID,reportFilePath, total
		Data data = new Data();
		data.add("PatientID", pId.Value );

		data.add("reportFilePath", urlPath + today + "_" + guid + ".pdf");
		data.add("total", totalPrice.Text);
		biz.create(data);
		go(urlPath + today + "_" + guid + ".pdf");
	}
}
