<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view.aspx.cs" Inherits="aspx_receptionist_book_create" MasterPageFile="~/master/subMain.master" %>
<asp:Content ContentPlaceHolderID="head" runat="server">
	<link rel="stylesheet" type="text/css" href="../../../css/epoch_styles.css" />
	
	<script type="text/javascript" src="../../../script/epoch_classes.js"></script>
	<script type="text/javascript">
		window.onload = function () {
			var popupcalendar = new Epoch('cal','popup',document.getElementById('ctl00_cnt_date'),false);
		}
	</script>
</asp:Content>
<asp:Content ContentPlaceHolderID="cnt" runat="server">
	BOOK<br />
	<asp:DropDownList ID="searchField" runat="server">
		<asp:ListItem Value="UserID" Text="user id"></asp:ListItem>
		<asp:ListItem Value="UserFirstName" Text="first name"></asp:ListItem>
		<asp:ListItem Value="UserSurName" Text="surname"></asp:ListItem>
		<asp:ListItem Value="Email" Text="e-mail"></asp:ListItem>
	</asp:DropDownList>
	<asp:TextBox ID="searchValue" runat="server"></asp:TextBox>
	<asp:Button ID="search" runat="server" Text="SEARCH" OnClick="onSearch" />
	<br />
	<asp:TextBox ID="historyId" runat="server" style="display:none;"></asp:TextBox><br />
	Patient ID : <asp:DropDownList ID="patientId" runat="server" DataTextField="Name" DataValueField="UserID">
	</asp:DropDownList><br />
	Doctor ID : <asp:DropDownList ID="staffId" runat="server" DataTextField="Name" DataValueField="UserID">
	</asp:DropDownList><br />
	MEMO : <asp:TextBox ID="memo" runat="server" TextMode="MultiLine"></asp:TextBox><br />
	DATE : <asp:TextBox ID="date" runat="server"></asp:TextBox><br />
	<asp:Button ID="update" runat="server" Text="UPDATE" OnClick="onUpdate"/>
	<asp:Button ID="delete" runat="server" Text="DELETE" OnClick="onDelete"/>
	<asp:Button ID="cancel" runat="server" Text="GO BACK" OnClick="onCancel"/>
</asp:Content>