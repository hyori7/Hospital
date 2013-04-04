<%@ Page Language="C#" AutoEventWireup="true" CodeFile="registration.aspx.cs" Inherits="aspx_user_registration" MasterPageFile="~/master/subMain.master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link rel="stylesheet" type="text/css" href="../../../css/epoch_styles.css" />
	
	<script type="text/javascript" src="../../../script/epoch_classes.js"></script>

<style type="text/css">
		.inputStyle 
		{
			background-color: #FFFFFF; color: #414141; 
			font-family: Arial, Helvetica, sans-serif ; font-size: 11px ; border:1px solid #ccc ; padding: 7px ; overflow: hidden ;
		}
	</style>
	
	<script type="text/javascript">
		window.onload = function () {
			var popupcalendar = new Epoch('cal','popup',document.getElementById('ctl00_cnt_DOB'),false);
		}

		function checkPost(obj) {
			if (obj.value.length > 4) {
				obj.value = obj.value.substring(0,4);
			}
			obj.value = obj.value.replace(/[^0-9]/g, "");
		}
		function checkPhone(obj) {
			if (obj.value.length > 10) {
				obj.value = obj.value.substring(0, 10);
			}
			obj.value = obj.value.replace(/[^0-9]/g, "");

		}

	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cnt" runat="server">
	<h1>Contact<div class="break"></div></h1><br />
	<h2>Registration Form</h2>
	<div id="registration">
		<br /><br />USER ID<br /><br />
		<asp:TextBox ID="UserID" runat="server"  onfocus="changeColour(this, '#ccc')" cssclass="inputStyle"></asp:TextBox><br />
		<br /><br />PASSWORD<br /><br />
		<asp:TextBox ID="Password" TextMode="Password" runat="server"  onfocus="changeColour(this, '#ccc')" cssclass="inputStyle"></asp:TextBox><br />
		<br /><br />CONFIRM PASSWORD<br /><br />
		<asp:TextBox ID="CPassword" TextMode="Password" runat="server"  onfocus="changeColour(this, '#ccc')" cssclass="inputStyle"></asp:TextBox><br />
		<br /><br />FIRST NAME<br /><br />
		<asp:TextBox ID="UserFirstName" runat="server"  onfocus="changeColour(this, '#ccc')" cssclass="inputStyle"></asp:TextBox><br />
		<br /><br />MIDDLE NAME<br /><br />
		<asp:TextBox ID="UserMiddleName" runat="server"  onfocus="changeColour(this, '#ccc')" cssclass="inputStyle"></asp:TextBox><br />
		<br /><br />SURNAME<br /><br />
		<asp:TextBox ID="UserSurName" runat="server"  onfocus="changeColour(this, '#ccc')" cssclass="inputStyle"></asp:TextBox><br />

		<br /><br />PatientFatherFirstName<br /><br />
		<asp:TextBox ID="PatientFatherFirstName" runat="server"  onfocus="changeColour(this, '#ccc')" cssclass="inputStyle"></asp:TextBox><br />
		<br /><br />PatientFatherLastName<br /><br />
		<asp:TextBox ID="PatientFatherLastName" runat="server"  onfocus="changeColour(this, '#ccc')" cssclass="inputStyle"></asp:TextBox><br />
		<br /><br />PatientMotherFirstName<br /><br />
		<asp:TextBox ID="PatientMotherFirstName" runat="server"  onfocus="changeColour(this, '#ccc')" cssclass="inputStyle"></asp:TextBox><br />
		<br /><br />PatientMotherLastName<br /><br />
		<asp:TextBox ID="PatientMotherLastName" runat="server"  onfocus="changeColour(this, '#ccc')" cssclass="inputStyle"></asp:TextBox><br />

		<br /><br />TITLE<br /><br />
		<asp:DropDownList ID="TitleID" runat="server"  onfocus="changeColour(this, '#ccc')" cssclass="inputStyle" DataTextField="TitleName" DataValueField="TitleID" ></asp:DropDownList><br />
		<br /><br />GENDER<br /><br />
		<asp:DropDownList ID="GenderID" runat="server"  onfocus="changeColour(this, '#ccc')" cssclass="inputStyle" DataTextField="GenderName" DataValueField="GenderID"></asp:DropDownList><br />
		<br /><br />OCCUPATION<br /><br />
		<asp:DropDownList ID="Occupation" runat="server"  onfocus="changeColour(this, '#ccc')" cssclass="inputStyle" DataTextField="OccupationName" DataValueField="OccupationID"></asp:DropDownList><br />
		<br /><br />MARTIAL STATUS<br /><br />
		<asp:DropDownList ID="MaritalID" runat="server"  onfocus="changeColour(this, '#ccc')" cssclass="inputStyle" DataTextField="MaritalStatus" DataValueField="MaritalID"></asp:DropDownList><br />
		<asp:HiddenField ID="JobCode" Value="0" runat="server"/>
		<br /><br />DATE OF BIRTH<br /><br />
		<asp:TextBox ID="DOB" runat="server"  onfocus="changeColour(this, '#ccc')" cssclass="inputStyle"></asp:TextBox><br />
		<br /><br />ADDRESS<br /><br />
		<asp:TextBox ID="Address" runat="server"  onfocus="changeColour(this, '#ccc')" cssclass="inputStyle"></asp:TextBox><br />
		<br /><br />POST CODE<br /><br />
		<asp:TextBox ID="PostCode" runat="server"  onfocus="changeColour(this, '#ccc')" cssclass="inputStyle" onkeyup="checkPost(this)"></asp:TextBox><br />
		<br /><br />NATIONALITY<br /><br />
		<asp:DropDownList ID="Nationality" runat="server" DataTextField="CountryName" DataValueField="CountryCode" onfocus="changeColour(this, '#ccc')" cssclass="inputStyle"></asp:DropDownList><br />
		<br /><br />STATE CODE<br /><br />
		<asp:DropDownList ID="StateCode" runat="server" DataTextField="StateName" DataValueField="StateCode" onfocus="changeColour(this, '#ccc')" cssclass="inputStyle"></asp:DropDownList><br />
		<br /><br />PHONE NUMBER<br /><br />
		<asp:TextBox ID="PhoneNumber" runat="server"  onfocus="changeColour(this, '#ccc')" cssclass="inputStyle" onkeyup="checkPhone(this)"></asp:TextBox><br />
		<br /><br />EMAIL<br /><br />
		<asp:TextBox ID="Email" runat="server"  onfocus="changeColour(this, '#ccc')" cssclass="inputStyle"></asp:TextBox><br />
		<br /><br />Insurance company<br /><br />
		<asp:DropDownList ID="insuranceId" runat="server" DataTextField="insuranceName" DataValueField="insuranceId" onfocus="changeColour(this, '#ccc')" cssclass="inputStyle"></asp:DropDownList><br />
		<br /><br />Insurance Number<br /><br />
		<asp:TextBox ID="insuranceNumber" runat="server"  onfocus="changeColour(this, '#ccc')" cssclass="inputStyle" onkeyup="if(this.value.length > 9) this.value = this.value.substring(0,9);"></asp:TextBox><br />
		<br />
		
		<asp:Button ID="regBtn" runat="server" Text="Register"  OnClick="onRegBtn"  cssclass="inputStyle" style="cursor:pointer;"  onfocus="changeColour(this, '#ccc')"/>

	</div>
</asp:Content>