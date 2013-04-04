<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="aspx_receptionist_book_list" MasterPageFile="~/master/subMain.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link rel="stylesheet" type="text/css" href="../../../css/epoch_styles.css" />
	
	<style type="text/css">
		.inputStyle 
		{
			background-color: #FFFFFF; color: #414141; 
			font-family: Arial, Helvetica, sans-serif ; font-size: 11px ; border:1px solid #ccc ; padding: 7px ; overflow: hidden ;
		}
	</style>
	
	<script type="text/javascript" src="../../../script/epoch_classes.js"></script>
	<script type="text/javascript">
		window.onload = function () {
			var popupcalendar = new Epoch('cal','popup',document.getElementById('ctl00_cnt_date'),false);
		}
	</script>
	<script type="text/javascript">
		function view(historyId) {
			document.location.href = "/hospital/aspx/receptionist/book/view.aspx?historyId="+ historyId;
		}
		function del() {
		}

		function pay(pId) {
			document.location.href = "/hospital/aspx/receptionist/payment/payment.aspx?pId=" + pId;
		}
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cnt" runat="server">
	BOOK<br />
	<asp:DropDownList ID="searchField" runat="server"  onfocus="changeColour(this, '#ccc')" cssclass="inputStyle" >
		<asp:ListItem Value="UserID" Text="user id"></asp:ListItem>
		<asp:ListItem Value="UserFirstName" Text="first name"></asp:ListItem>
		<asp:ListItem Value="UserSurName" Text="surname"></asp:ListItem>
		<asp:ListItem Value="Email" Text="e-mail"></asp:ListItem>
	</asp:DropDownList>
	DATE : <asp:TextBox ID="date" runat="server"  onfocus="changeColour(this, '#ccc')" cssclass="inputStyle" ></asp:TextBox>
	<asp:TextBox ID="searchValue" runat="server"  onfocus="changeColour(this, '#ccc')" cssclass="inputStyle" ></asp:TextBox>

	<asp:Button ID="search" runat="server" Text="SEARCH" OnClick="onSearch"  cssclass="inputStyle" style="cursor:pointer;" onfocus="changeColour(this, '#ccc')" />
	<br />
	<asp:GridView ID="bookList" runat="server" AutoGenerateColumns="False" 
		BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
		CellPadding="4" ForeColor="Black" GridLines="Horizontal">
		<Columns>
			<asp:BoundField HeaderText="patient" DataField="patientId" HtmlEncode="true"/>
			<asp:TemplateField HeaderText="name">
				<ItemTemplate>
					<%#"<a href=\"javascript:view('" + Eval("historyId") + "');\">" + Eval("UserFirstName") + ", " + Eval("UserSurName") + "</a>"%>
				</ItemTemplate>
			</asp:TemplateField>
			<asp:BoundField HeaderText="memo" DataField="memo"/>
			<asp:BoundField HeaderText="Email" DataField="Email"/>
			<asp:BoundField HeaderText="date" DataField="date" />
			<asp:TemplateField HeaderText="PAY">
				<ItemTemplate>
					<%#"<a href=\"javascript:pay('" + Eval("UserID") + "');\">PAY</a>"%>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
		<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
		<PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
		<SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
		<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
	</asp:GridView>
	<asp:Button ID="create" runat="server" Text="NEW BOOKING" OnClick="onCreate"  cssclass="inputStyle" style="cursor:pointer;" onfocus="changeColour(this, '#ccc')"/>
</asp:Content>