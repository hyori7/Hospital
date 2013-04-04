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

public partial class aspx_admin_user_list : BasePage
{

	protected override void Fire(object sender, EventArgs e)
	{
		if (!UserInfo.IsAdmin(Session))
		{
			alertAndGoback("Please, LOGIN!!");
			return;
		}
		User user = new User();
		Data data = user.list(Param);
		userList.DataSource = data.Source;
		userList.DataBind();
	}
}
