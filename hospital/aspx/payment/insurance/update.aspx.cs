using System;
using BusinessTier;
using DataTier;

public partial class aspx_payment_insurance_update : BasePage
{
    Data data = new Data();
    InsuranceBiz insurance = new InsuranceBiz();
    protected override void Fire(object sender, EventArgs e)
    {
		if (!UserInfo.IsSysAdmin(Session))
		{
			alertAndGoback("you are not a system administrator. Please login");
			return;
		}
        DBC dbc = new DBC();
        data.add("insuranceId", Param.get("insuranceId"));
        Data result = insurance.view(data);
        insuranceName.Text = result.getString("insuranceName");
        rate.Text = result.getString("rate");
        insuranceId.Text = result.getString("insuranceId");

    }

    public void update_click(object sender, EventArgs e)
    {

        Data data = Param;
        data.add("insuranceId", Param.get("insuranceId"));
        insurance.update(data);
        go("~/aspx/payment/insurance/list.aspx");
    }

    public void delete_click(object sender, EventArgs e)
    {
        Data data = Param;
        data.add("insuranceId", Param.get("insuranceId"));
        insurance.delete(data);
        go("~/aspx/payment/insurance/list.aspx");
    }
}
