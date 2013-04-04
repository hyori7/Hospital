using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using DataTier;
using BusinessTier;

public partial class aspx_Login : System.Web.UI.Page
{
	private Data param = null;

	protected Data Param
	{
		get
		{
			return param == null ? param = RequestManager.Form(Request) : param;
		}
	}

	public void go(String url)
	{
		Response.Redirect(url);
	}

	protected void Page_Load(object sender, EventArgs e)
	{
		SetInfo();

	}

	protected void SetInfo()
	{
		if (XMLLoader.IsLoaded == false)
		{
			XMLLoader.Path = Server.MapPath("~/App_Data/config.xml");
			Paging.RowSize = int.Parse(XMLLoader.getValue("paging", "rowSize"));
			Paging.PageSize = int.Parse(XMLLoader.getValue("paging", "pageSize"));
			String source = XMLLoader.getValue("database", "dataSource");
			String initialCatalog = XMLLoader.getValue("database", "initialCatalog");
			String security = XMLLoader.getValue("database", "security");
			String path = XMLLoader.getText("database/path");
			DBC.setDBInfo(source, initialCatalog, security, path);


			Cryptograph.Passowrd = XMLLoader.getValue("security", "password");

		}
	}

	protected void alertAndGoback(String msg)
	{
		String url = "/hospital/aspx/util/goBack.aspx";
		url += "?msg=" + msg;
		Response.Redirect(url);
	}

	protected void alertAndGo(String msg, String url)
	{
		String urlString = "";
		urlString = "/hospital/aspx/util/go.aspx";
		urlString += "?msg=" + msg + "&url=" + url;
		Response.Redirect(urlString);
	}


	protected void onLogin(object sender, EventArgs e)
	{
		Data param = new Data();
		param.add("id", id.Text);
		param.add("pwd", pwd.Text);
		User user = new User();
		user.login(param, Session);
		if (!UserInfo.getLoginState(Session).Equals("OK"))
		{
			alertAndGoback(UserInfo.getLoginState(Session));
		}


		if (UserInfo.IsAdmin(Session))
		{
			go("/hospital/aspx/admin/user/list.aspx");
		}
		else if (UserInfo.isReceptionist(Session))
		{
			go("/hospital/aspx/receptionist/book/list.aspx");
		}
		else if (UserInfo.isXrayOperator(Session))
		{
			go("~/aspx/xray/patients/list.aspx");
		}
		else if (UserInfo.isPharmacist(Session))
		{
			go("/hospital/aspx/pharmacist/patients/list.aspx");
		}

		else if (UserInfo.isCheif(Session))
		{
			go("/hospital/aspx/nurse/patientroom/list.aspx");
		}
		else if (UserInfo.isMriOperator(Session))
		{
			go("~/aspx/MRI/patients/list.aspx");
		}
		else if (UserInfo.IsSysAdmin(Session))
		{
			go("~/aspx/payment/general/list.aspx");
		}
		else if (UserInfo.isDoctor(Session))
		{
			go("~/aspx/doctor/patients/list.aspx");
		}
		else if (UserInfo.isNurse(Session))
		{
			go("~/aspx/nurse/patients/list.aspx");
			
		}
	}


}
