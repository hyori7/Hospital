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
public partial class master_main : System.Web.UI.MasterPage
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


}
