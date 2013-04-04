<%@ Page Language="C#" AutoEventWireup="true" CodeFile="registration.aspx.cs" Inherits="aspx_user_registration" MasterPageFile="~/master/subMain.master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link rel="stylesheet" type="text/css" href="../../../css/epoch_styles.css" />
	
	<script type="text/javascript" src="../../../script/epoch_classes.js"></script>

	<style type="text/css">
		.regText 
		{
			background-color:#FFFFFF; color: #414141;
			font-family: Arial, Helvetica, sans-serif ; font-size: 11px ; border:1px solid #ccc ; padding: 7px ; overflow: hidden ;
		}
	</style>
	<script type="text/javascript">
		window.onload = function() {
			var popupcalendar = new Epoch('cal', 'popup', document.getElementById('ctl00_cnt_DOB'), false);
		}

		function checkPost(obj) {
			if (obj.value.length > 4) {
				obj.value = obj.value.substring(0, 4);
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
		<asp:TextBox ID="UserID" runat="server" CssClass="regText" onfocus="changeColour(this, '#DBDADB')"></asp:TextBox><br />
		<br /><br />PASSWORD<br /><br />
		<asp:TextBox ID="Password" TextMode="Password" runat="server" CssClass="regText" onfocus="changeColour(this, '#DBDADB')"></asp:TextBox><br />
		<br /><br />CONFIRM PASSWORD<br /><br />
		<asp:TextBox ID="CPassword" TextMode="Password" runat="server" CssClass="regText" onfocus="changeColour(this, '#DBDADB')"></asp:TextBox><br />
		<br /><br />FIRST NAME<br /><br />
		<asp:TextBox ID="UserFirstName" runat="server" CssClass="regText" onfocus="changeColour(this, '#DBDADB')"></asp:TextBox><br />
		<br /><br />MIDDLE NAME<br /><br />
		<asp:TextBox ID="UserMiddleName" runat="server" CssClass="regText" onfocus="changeColour(this, '#DBDADB')"></asp:TextBox><br />
		<br /><br />SURNAME<br /><br />
		<asp:TextBox ID="UserSurName" runat="server" CssClass="regText" onfocus="changeColour(this, '#DBDADB')"></asp:TextBox><br />
		<br /><br />TITLE<br /><br />
		<asp:DropDownList ID="TitleID" runat="server" CssClass="regText" DataTextField="TitleName" DataValueField="TitleID" onfocus="changeColour(this, '#DBDADB')"></asp:DropDownList><br />
		<br /><br />GENDER<br /><br />
		<asp:DropDownList ID="GenderID" runat="server" CssClass="regText" DataTextField="GenderName" DataValueField="GenderID" onfocus="changeColour(this, '#DBDADB')"></asp:DropDownList><br />
		<br /><br />OCCUPATION<br /><br />
		<asp:DropDownList ID="Occupation" runat="server" CssClass="regText" DataTextField="OccupationName" DataValueField="OccupationID" onfocus="changeColour(this, '#DBDADB')"></asp:DropDownList><br />
		<br /><br />MARTIAL STATUS<br /><br />
		<asp:DropDownList ID="MaritalID" runat="server" CssClass="regText" DataTextField="MaritalStatus" DataValueField="MaritalID" onfocus="changeColour(this, '#DBDADB')"></asp:DropDownList><br />
		
		<br /><br />JOB<br /><br />
		<asp:DropDownList ID="JobCode" runat="server" DataTextField="JobName" DataValueField="JobCode" CssClass="regText" onfocus="changeColour(this, '#DBDADB')"></asp:DropDownList><br />
		
		<br /><br />DATE OF BIRTH<br /><br />
		<asp:TextBox ID="DOB" runat="server" CssClass="regText" onfocus="changeColour(this, '#DBDADB')"></asp:TextBox><br />
		<br /><br />ADDRESS<br /><br />
		<asp:TextBox ID="Address" runat="server" CssClass="regText" onfocus="changeColour(this, '#DBDADB')"></asp:TextBox><br />
		<br /><br />POST CODE<br /><br />
		<asp:TextBox ID="PostCode" runat="server" CssClass="regText" onkeyup="checkPost(this)"  onfocus="changeColour(this, '#DBDADB')"></asp:TextBox><br />
		<br /><br />NATIONALITY<br /><br />
		<asp:DropDownList ID="Nationality" runat="server" DataTextField="CountryName" DataValueField="CountryCode" CssClass="regText" onfocus="changeColour(this, '#DBDADB')"></asp:DropDownList><br />
		<br /><br />STATE CODE<br /><br />
		<asp:DropDownList ID="StateCode" runat="server" DataTextField="StateName" DataValueField="StateCode" CssClass="regText" onfocus="changeColour(this, '#DBDADB')"></asp:DropDownList><br />
		<br /><br />PHONE NUMBER<br /><br />
		<asp:TextBox ID="PhoneNumber" runat="server" CssClass="regText" onkeyup="checkPhone(this)"  onfocus="changeColour(this, '#DBDADB')"></asp:TextBox><br />
		<br /><br />EMAIL<br /><br />
		<asp:TextBox ID="Email" runat="server" CssClass="regText" onfocus="changeColour(this, '#DBDADB')"></asp:TextBox><br />

<%--		<asp:LinkButton ID="regBtn" runat="server" OnClick="onRegBtn">
			<asp:Image ID="regBtnImg" runat="server" ImageUrl="~/images/register_out.png" onmouseover="changeLoginBtn(this.id, true)" onmouseout="changeLoginBtn(this.id, false)"/>
		</asp:LinkButton>--%>
		
       <br /> <asp:Button ID="regBtn" runat="server" Text="Register" OnClick="onRegBtn" CssClass="regText" style="cursor:pointer;" onfocus="changeColour(this, '#ccc')"/>
	</div>

</asp:Content>