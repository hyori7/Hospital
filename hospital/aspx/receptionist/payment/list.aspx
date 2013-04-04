<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="aspx_receptionist_payment_list" MasterPageFile="~/master/subMain.master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link rel="stylesheet" type="text/css" href="../../../css/epoch_styles.css" />
	
	<script type="text/javascript" src="../../../script/epoch_classes.js"></script>
	<script type="text/javascript">
		window.onload = function () {
			var popupcalendar = new Epoch('cal', 'popup', document.getElementById('ctl00_cnt_startDate'), false);
			var popupcalendar2 = new Epoch('cal', 'popup', document.getElementById('ctl00_cnt_endDate'), false);
		}

		function saveHtml() {
			var html = document.getElementById("printingPlace").innerHTML;
			document.getElementById("ctl00_cnt_html").value = encodeURI(html);

			return true;
		}
	</script>
	
	<style type="text/css">
		.inputStyle 
		{
			background-color: #FFFFFF; color: #414141; 
			font-family: Arial, Helvetica, sans-serif ; font-size: 11px ; border:1px solid #ccc ; padding: 7px ; overflow: hidden ;
		}
	</style>
	
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cnt" runat="server">
Start date : <asp:TextBox ID="startDate" runat="server" onfocus="changeColour(this, '#ccc')" cssclass="inputStyle"></asp:TextBox>	
end date : <asp:TextBox ID="endDate" runat="server" onfocus="changeColour(this, '#ccc')" cssclass="inputStyle"></asp:TextBox>	<br />
<asp:DropDownList ID="searchField" runat="server" onfocus="changeColour(this, '#ccc')" cssclass="inputStyle">
	<asp:ListItem Value="none" Text="no search"></asp:ListItem>
	<asp:ListItem Value="UserID" Text="user id"></asp:ListItem>
	<asp:ListItem Value="UserFirstName" Text="first name"></asp:ListItem>
	<asp:ListItem Value="UserSurName" Text="sur name"></asp:ListItem>
</asp:DropDownList>
<asp:TextBox ID="searchValue" runat="server" onfocus="changeColour(this, '#ccc')" cssclass="inputStyle"></asp:TextBox>
<asp:Button ID="search" runat="server" Text="search" OnClick="onSearch" cssclass="inputStyle" style="cursor:pointer;" onfocus="changeColour(this, '#ccc')"/>
<asp:Button ID="print" runat="server" Text="print" OnClick="onPrint" OnClientClick="saveHtml()" cssclass="inputStyle" style="cursor:pointer;" onfocus="changeColour(this, '#ccc')"/>

<asp:HiddenField ID="html" runat="server" />
<div id="printingPlace">
	<asp:Label ID="title" runat="server" Text="payment report"></asp:Label>
	
	<asp:GridView ID="reportView" runat="server" AutoGenerateColumns="False" 
		BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
		CellPadding="4" ForeColor="Black" GridLines="Horizontal">
		<Columns>
			<asp:BoundField HeaderText="user id" DataField="UserID"/>
			<asp:BoundField HeaderText="first name" DataField="UserFirstName"/>	
			<asp:BoundField HeaderText="sur name" DataField="UserSurName"/>	
			<asp:HyperLinkField HeaderText="total" DataNavigateUrlFields="reportFilePath" DataTextField="total"/>
			<asp:BoundField HeaderText="date" DataField="date"/>	
		</Columns>
		<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
		<PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
		<SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
		<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
	</asp:GridView>
</div>
</asp:Content>