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
using System.Collections.Generic;
using DataTier;

public partial class aspx_payment_insurance_create : BasePage
{
    protected override void Fire(object sender, EventArgs e)
    {
		if (!UserInfo.IsSysAdmin(Session))
		{
			alertAndGoback("you are not a system administrator. Please login");
			return;
		}
        Data data = new Data();
        data.add("insuranceId", Param.get("insuranceId"));
    }

    public void submit_click(object sender, EventArgs e)
    {
       
        Data data = Param;
        InsuranceBiz inBiz = new InsuranceBiz();
        data.add("insuranceId", Param.get("insuranceId"));
        inBiz.create(data);
        go("~/aspx/payment/insurance/list.aspx");
        
      
        
       
    }
}
