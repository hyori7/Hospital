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


public partial class aspx_admin_Room_list : BasePage
{
    protected override void Fire(object sender, EventArgs e)
    {
        Data data = new Data();
		data.add("DeptName", Param.get("DeptName"));
        RoomBiz biz = new RoomBiz();
        Data result = biz.list(data);
        RoomList.DataSource = result.Source;
        RoomList.DataBind();
    }
}