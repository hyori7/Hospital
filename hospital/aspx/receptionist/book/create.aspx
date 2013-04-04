<%@ Page Language="C#" AutoEventWireup="true" CodeFile="create.aspx.cs" Inherits="aspx_receptionist_book_create" MasterPageFile="~/master/subMain.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<style type="text/css">
		.inputStyle 
		{
			background-color: #FFFFFF; color: #414141; 
			font-family: Arial, Helvetica, sans-serif ; font-size: 11px ; border:1px solid #ccc ; padding: 7px ; overflow: hidden ;
		}
	</style>
	<script type="text/javascript">

		function checkNum(obj) {
			obj.value = obj.value.replace(/[^0-9]/g, "");
		}

		function changeImg(obj) {
			if (obj.src.indexOf("_down") > -1) {
				obj.src = obj.src.replace("_down", "_up");
			} else {
				obj.src = obj.src.replace("_up", "_down");
			}
		}

		function changeColour(obj, colour) {

			var textboxes = document.getElementsByTagName("TEXTAREA");
			for (var i = 0; i < textboxes.length; i++) {
				textboxes[i].style.backgroundColor = "#ccc";
			}
			obj.style.backgroundColor = colour;
		}
	</script>
	<link rel="stylesheet" type="text/css" href="../../../css/epoch_styles.css" />
	
	<script type="text/javascript" src="../../../script/epoch_classes.js"></script>
	<script type="text/javascript">
		window.onload = function() {
			var popupcalendar = new Epoch('cal', 'popup', document.getElementById('ctl00_cnt_date'), false);
		}
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cnt" runat="server">
	BOOK<br />
	<asp:DropDownList ID="searchField" runat="server" onfocus="changeColour(this, '#ccc')" cssclass="inputStyle">
		<asp:ListItem Value="UserID" Text="user id"></asp:ListItem>
		<asp:ListItem Value="UserFirstName" Text="first name"></asp:ListItem>
		<asp:ListItem Value="UserSurName" Text="surname"></asp:ListItem>
		<asp:ListItem Value="Email" Text="e-mail"></asp:ListItem>
	</asp:DropDownList>
	<asp:TextBox ID="searchValue" runat="server" onfocus="changeColour(this, '#ccc')" cssclass="inputStyle"></asp:TextBox>
	<asp:Button ID="search" runat="server" Text="SEARCH" OnClick="onSearch" onfocus="changeColour(this, '#ccc')" style="cursor:pointer;" cssclass="inputStyle"/>
	<br />
	<asp:TextBox ID="historyId" runat="server" style="display:none;" CssClass="inputStyle" onfocus="changeColour(this, '#414141')"></asp:TextBox><br />
	Patient ID : <asp:DropDownList ID="patientId" runat="server" DataTextField="Name" DataValueField="UserID" onfocus="changeColour(this, '#ccc')" cssclass="inputStyle">
	</asp:DropDownList><br />
	Doctor ID : <asp:DropDownList ID="staffId" runat="server" DataTextField="Name" DataValueField="UserID" onfocus="changeColour(this, '#ccc')" cssclass="inputStyle">
	</asp:DropDownList><br />
	MEMO : <asp:TextBox ID="memo" runat="server" TextMode="MultiLine" onfocus="changeColour(this, '#ccc')" cssclass="inputStyle"></asp:TextBox><br />
	DATE : <asp:TextBox ID="date" runat="server" onfocus="changeColour(this, '#ccc')" cssclass="inputStyle"></asp:TextBox><br />
	<asp:Button ID="create" runat="server" Text="SUBMIT" OnClick="onCreate" cssclass="inputStyle" style="cursor:pointer;"  onfocus="changeColour(this, '#ccc')"/>
	<asp:Button ID="cancel" runat="server" Text="CANCEL" OnClick="onCancel" cssclass="inputStyle" style="cursor:pointer;" onfocus="changeColour(this, '#ccc')"/>
</asp:Content>
