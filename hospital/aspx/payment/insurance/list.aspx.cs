using System;

/// <summary>
/// Summary description for list
/// </summary>
using BusinessTier;
using DataTier;

public partial class aspx_payment_insurance_list : BasePage
{

    protected override void Fire(object sender, EventArgs e)
    {
		if (!UserInfo.IsSysAdmin(Session))
		{
			alertAndGoback("you are not a system administrator. Please login");
			return;
		}
        DBC dbc = new DBC();
        Data data = new Data();
        data.add("insuranceId", Param.get("insuranceId"));
        InsuranceBiz inBiz = new InsuranceBiz();
        Data result = inBiz.list(data);
        insurance.DataSource = result.Source;
        insurance.DataBind();


    }

    public void Create(object sender, EventArgs e)
    {
        Data data = Param;
        go("~/aspx/payment/insurance/create.aspx?insuranceId=" + Param.getString("insuranceId"));

    }

}