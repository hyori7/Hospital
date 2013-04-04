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

public partial class aspx_receptionist_book_list : BasePage
{
	protected override void Fire(object sender, EventArgs e)
	{
		if (!UserInfo.isReceptionist(Session))
		{
			alertAndGoback("PLEASE, LOGIN");
			return;
		}
		//date.Text = DateTime.Now.Date.ToString().Substring(0, 10);

	}

	protected void onSearch(object sender, EventArgs e)
	{
		Receptionist rec = new Receptionist();
		Data list = rec.list(Param);
		for (int i = 0; i < list.Count; i++)
		{
			list.add(i, "date", list.getString(i, "date").Substring(0, 10));
		}
			bookList.DataSource = list.Source;
		bookList.DataBind();
	}

	protected void onCreate(object sender, EventArgs e)
	{
		go("/hospital/aspx/receptionist/book/create.aspx");
	}
}
