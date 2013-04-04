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

public partial class aspx_nurse_observation_view : BasePage
{
	protected override void Fire(object sender, EventArgs e)
	{
		bool isOkay = false;
		if (UserInfo.isNurse(Session) || UserInfo.isDoctor(Session))
		{
			isOkay = true;
		}

		if (!isOkay)
		{
			alertAndGoback("you are not a nurse. Please login");
			return;
		}
		Data data = new Data();
		data.add("nurseId", UserInfo.getId(Session));
		if (!"".Equals(Param.getString("pId")))
		{
			data.add("pID", Param.get("pId"));
		}
		else
		{
			data.add("cntId", Param.get("cntId"));
		}
		
		
		
		ObservationBiz updateview = new ObservationBiz();
		Data result = updateview.view(data);
		userNameLabel.Text = result.getString("UserID");
		head.SelectedValue = result.getString("head");
		ear.SelectedValue = result.getString("ear");
		drum.SelectedValue = result.getString("drum");
		nose.SelectedValue = result.getString("nose");
		sinus.SelectedValue = result.getString("sinus");
		mouth.SelectedValue = result.getString("mouth");
		eye.SelectedValue = result.getString("eye");
		opthal.SelectedValue = result.getString("opthal");
		pupil.SelectedValue = result.getString("pupil");
		ocular.SelectedValue = result.getString("ocular");
		lung.SelectedValue = result.getString("lung");
		heart.SelectedValue = result.getString("heart");
		vascular.SelectedValue = result.getString("vascular");
		abdomen.SelectedValue = result.getString("abdomen");
		memo.Text = result.getString("memo");
		UserID.Text = result.getString("UserID");
		ObservationID.Text = result.getString("id");
		date.Text = result.getString("date");
	}
	/// <summary>
	/// Update patient's data
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Update(Object sender, EventArgs e)
	{
		Data data = Param;
    
		ObservationBiz nurse = new ObservationBiz();
		nurse.update(data);
		go("~/aspx/nurse/patients/list.aspx");
	}
	/// <summary>
	/// delete patient's data
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Delete(Object sender, EventArgs e)
	{
		Data data = Param;
		DBC dbc = new DBC();
		ObservationBiz nurse = new ObservationBiz();
		nurse.delete(data);
		go("~/aspx/nurse/patients/list.aspx");
	}
	/// <summary>
	/// Cancel will direct user to history page
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Cancel(object sender, EventArgs e)
	{
		go("~/aspx/nurse/patients/list.aspx");
	}
}
