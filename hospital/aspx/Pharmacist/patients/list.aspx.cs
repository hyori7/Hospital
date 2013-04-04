using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessTier;
using DataTier;

public partial class aspx_doctor_patients_list : BasePage
{


	protected override void Fire(object sender, EventArgs e)
	{
		if (!UserInfo.isPharmacist(Session))
		{
            alertAndGoback("you are not a Pharmacist. Please login");
			return;
		}
		String hId = Param.getString("hId");
		Data data = new Data();
		data.add("doctorId", UserInfo.getId(Session));

        PharmacistBiz biz = new PharmacistBiz();

		if (!"".Equals(hId))
		{
			data.add("hId", hId);
			biz.done(data);
		}
		Data result = biz.list(Param.getString("searchField"), Param.getString("searchValue"), data);
		Patientlist.DataSource = result.Source;
		Patientlist.DataBind();
	}

	protected void onSearch(object sender, EventArgs e)
	{
        PharmacistBiz biz = new PharmacistBiz();
		Data data = Param;
		data.add("doctorId", UserInfo.getId(Session));
		Data list = biz.list(Param.getString("searchField"), Param.getString("searchValue"), data);
		for (int i = 0; i < list.Count; i++)
		{
			list.add(i, "date", list.getString(i, "date").Substring(0, 10));
		}
		Patientlist.DataSource = list.Source;
		Patientlist.DataBind();
	}
}
