using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessTier;

public partial class _Default : BasePage
{

	protected override void Fire(object sender, EventArgs e)
	{
		go("~/aspx/default.aspx");
	}
}
