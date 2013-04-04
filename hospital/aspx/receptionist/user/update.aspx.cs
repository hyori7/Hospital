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

public partial class aspx_user_registration : BasePage
{
	protected override void Fire(object sender, EventArgs e)
	{
		if (!UserInfo.isReceptionist(Session))
		{
			alertAndGoback("Please, LOGIN!!");
			return;
		}

		User user = new User();
		List<Data> list = user.getDefaultInfo();
		Data userInfo = user.view(Param);
		UserID.Text = userInfo.getString("UserID");
		UserFirstName.Text = userInfo.getString("UserFirstName");
		UserMiddleName.Text = userInfo.getString("UserMiddleName");
		UserSurName.Text = userInfo.getString("UserSurName");
		Occupation.DataSource = list[0].Source;
		Occupation.DataBind();

		MaritalID.DataSource = list[1].Source;
		MaritalID.DataBind();
		MaritalID.SelectedValue = userInfo.getString("MaritalID");
		
		JobCode.DataSource = list[2].Source;
		JobCode.DataBind();

		JobCode.SelectedValue = userInfo.getString("JobCode");

		Nationality.DataSource = list[3].Source;
		Nationality.DataBind();

		Nationality.SelectedValue = userInfo.getString("Nationality");

		TitleID.DataSource = list[4].Source;
		TitleID.DataBind();
		TitleID.SelectedValue = userInfo.getString("TitleID");
		GenderID.DataSource = list[5].Source;
		GenderID.DataBind();
		GenderID.SelectedValue = userInfo.getString("GenderID");

		StateCode.DataSource = list[6].Source;
		StateCode.DataBind();
		StateCode.SelectedValue = userInfo.getString("StateCode");
		DOB.Text = userInfo.getString("DOB").Substring(0, 10);
		Address.Text = userInfo.getString("Address");
		PostCode.Text = userInfo.getString("PostCode");
		PhoneNumber.Text = userInfo.getString("PhoneNumber");
		Email.Text = userInfo.getString("Email");

		PatientFatherFirstName.Text = userInfo.getString("PatientFatherFirstName");
		PatientFatherLastName.Text = userInfo.getString("PatientFatherLastName");
		PatientMotherFirstName.Text = userInfo.getString("PatientMotherFirstName");
		PatientMotherLastName.Text = userInfo.getString("PatientMotherLastName");

	}

	protected void onUpdateBtn(object sender, EventArgs e)
	{

		User user = new User();
		user.updatePatient(Param);
		alertAndGoback("Updated!");
		return;
	}
}