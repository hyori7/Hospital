<%@ Page Language="C#" AutoEventWireup="true" CodeFile="update.aspx.cs" Inherits="aspx_user_registration" MasterPageFile="~/master/subMain.master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link rel="stylesheet" type="text/css" href="../../../css/epoch_styles.css" />
	
	<script type="text/javascript" src="../../../script/epoch_classes.js"></script>

	<style type="text/css">
		.regText 
		{
			background-color: #cccccc ; 
			color:  #FFFFFF; 
			font-family: Arial, Helvetica, sans-serif ; 
			font-size: 11px ; 
			border:none ;  
			padding: 7px ;
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

		function goBack() {
			history.go(-1);
		}
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cnt" runat="server">
	<h1>Contact<div class="break"></div></h1><br />
	<h2>Update Form</h2>
	<div id="registration">
		<br /><br />USER ID<br /><br />
		<asp:TextBox ID="UserID" runat="server" CssClass="regText" ReadOnly="true"></asp:TextBox><br />
		<br /><br />FIRST NAME<br /><br />
		<asp:TextBox ID="UserFirstName" runat="server" CssClass="regText"></asp:TextBox><br />
		<br /><br />MIDDLE NAME<br /><br />
		<asp:TextBox ID="UserMiddleName" runat="server" CssClass="regText"></asp:TextBox><br />
		<br /><br />SURNAME<br /><br />
		<asp:TextBox ID="UserSurName" runat="server" CssClass="regText"></asp:TextBox><br />

		<br /><br />PatientFatherFirstName<br /><br />
		<asp:TextBox ID="PatientFatherFirstName" runat="server" CssClass="regText"></asp:TextBox><br />
		<br /><br />PatientFatherLastName<br /><br />
		<asp:TextBox ID="PatientFatherLastName" runat="server" CssClass="regText"></asp:TextBox><br />
		<br /><br />PatientMotherFirstName<br /><br />
		<asp:TextBox ID="PatientMotherFirstName" runat="server" CssClass="regText"></asp:TextBox><br />
		<br /><br />PatientMotherLastName<br /><br />
		<asp:TextBox ID="PatientMotherLastName" runat="server" CssClass="regText"></asp:TextBox><br />


		<br /><br />TITLE<br /><br />
		<asp:DropDownList ID="TitleID" runat="server" CssClass="regText" DataTextField="TitleName" DataValueField="TitleID"></asp:DropDownList><br />
		<br /><br />GENDER<br /><br />
		<asp:DropDownList ID="GenderID" runat="server" CssClass="regText" DataTextField="GenderName" DataValueField="GenderID"></asp:DropDownList><br />
		<br /><br />OCCUPATION<br /><br />
		<asp:DropDownList ID="Occupation" runat="server" CssClass="regText" DataTextField="OccupationName" DataValueField="OccupationID"></asp:DropDownList><br />
		<br /><br />MARTIAL STATUS<br /><br />
		<asp:DropDownList ID="MaritalID" runat="server" CssClass="regText" DataTextField="MaritalStatus" DataValueField="MaritalID"></asp:DropDownList><br />
		
		<br /><br />JOB<br /><br />
		<asp:DropDownList ID="JobCode" runat="server" DataTextField="JobName" DataValueField="JobCode"></asp:DropDownList><br />
		
		<br /><br />DATE OF BIRTH<br /><br />
		<asp:TextBox ID="DOB" runat="server" CssClass="regText"></asp:TextBox><br />
		<br /><br />ADDRESS<br /><br />
		<asp:TextBox ID="Address" runat="server" CssClass="regText"></asp:TextBox><br />
		<br /><br />POST CODE<br /><br />
		<asp:TextBox ID="PostCode" runat="server" CssClass="regText" onkeyup="checkPost(this)"></asp:TextBox><br />
		<br /><br />NATIONALITY<br /><br />
		<asp:DropDownList ID="Nationality" runat="server" DataTextField="CountryName" DataValueField="CountryCode"></asp:DropDownList><br />
		<br /><br />STATE CODE<br /><br />
		<asp:DropDownList ID="StateCode" runat="server" DataTextField="StateName" DataValueField="StateCode"></asp:DropDownList><br />
		<br /><br />PHONE NUMBER<br /><br />
		<asp:TextBox ID="PhoneNumber" runat="server" CssClass="regText"></asp:TextBox><br />
		<br /><br />EMAIL<br /><br />
		<asp:TextBox ID="Email" runat="server" CssClass="regText"></asp:TextBox><br />

		<asp:LinkButton ID="updateBtn" runat="server" OnClick="onUpdateBtn">
			<asp:Image ID="regBtnImg" runat="server" ImageUrl="~/images/register_out.png" onmouseover="changeLoginBtn(this.id, true)" onmouseout="changeLoginBtn(this.id, false)"/>
		</asp:LinkButton>
		 <input type="button" value="Close" onclick="goBack()" />

	</div>
</asp:Content>