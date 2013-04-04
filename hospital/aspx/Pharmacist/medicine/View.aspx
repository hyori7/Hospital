<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="aspx_Pharmarcist_View" MasterPageFile="~/master/subMain.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link rel="stylesheet" type="text/css" href="../../../css/epoch_styles.css" />
	<script type="text/javascript" src= "../../../script/epoch_classes.js"></script>
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
	
	<style type="text/css">
		.inputStyle 
		{
			background-color: #FFFFFF; color: #414141;" 
            font-family: Arial, Helvetica, sans-serif ; font-size: 11px ; border:1px solid #ccc ; padding: 7px ; overflow: hidden ;
		}
	</style>
	<script type="text/javascript">
		window.onload = function() {
			var popupcalendar = new Epoch('cal', 'popup', document.getElementById('ctl00_cnt_DOB'), false);
		}

		function del(rId) {
			var url = document.location.href;
			if (url.indexOf("rId=") > -1) {
				var urlArray = url.split("&");
				urlArray[urlArray.length - 1] = "&rId=" + rId;
				url = urlArray.join("&");
			} else {
				url = url + "&rId=" + rId;
			}
			document.location.href = url;
		}

		function checkPost(obj) {
			if (obj.value.length > 4) {
				obj.value = obj.value.substring(0, 4);
			}
			obj.value = obj.value.replace(/[^0-9]/g, "");
		}
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cnt" runat="server">
		Medication For  &nbsp;<asp:Label ID="userNameLabel" runat="server" Text="Label" CssClass="inputStyle"></asp:Label>
		<div id="doctor's order form">
		<asp:TextBox ID="UserID" runat="server" style="display:none;" CssClass="inputStyle"></asp:TextBox>
		<asp:HiddenField ID="historyId" runat="server" />
		<asp:TextBox ID="OrderID" runat="server" style="display:none;" CssClass="inputStyle"></asp:TextBox>
			Order from Doctor<br />Medication<br />
		<asp:TextBox ID="Usermed" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')"  Height="212px" 
		 Width="382px" TextMode="MultiLine"></asp:TextBox><br />
		 <br />Memo<br />
		<asp:TextBox ID="Memo" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')"  Height="212px" 
				Width="382px" TextMode="MultiLine"></asp:TextBox>
			<br />
			<br />
			Medicine From Pharmarcist<br />
			<br />
			Medicine: 
			<asp:TextBox ID="searchValue" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" ></asp:TextBox>
			<asp:Button ID="search" runat="server" Text="SEARCH" OnClick="onSearch" CssClass="inputStyle" style="cursor:pointer;" onfocus="changeColour(this, '#ccc')" />
			<asp:Button ID="BACK" runat="server" Text="GO BACK" OnClick="goBack" CssClass="inputStyle" style="cursor:pointer;"  onfocus="changeColour(this, '#ccc')"/>
			<asp:Button ID="finish" runat="server" Text="complete" OnClick="onComplete" CssClass="inputStyle" style="cursor:pointer;" onfocus="changeColour(this, '#ccc')"/>
			<br />
			<asp:DropDownList ID="MedicineDroplist" runat="server"  onfocus="changeColour(this, '#ccc')" DataTextField="Item" DataValueField="ID" CssClass="inputStyle">
			</asp:DropDownList>
			&nbsp;Quantity:
			<asp:TextBox ID="Quantity" runat="server" Height="28px" Width="44px" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" ></asp:TextBox>
&nbsp;&nbsp;
			<asp:Button ID="create" runat="server" Height="28px" onclick="Add_Click" CssClass="inputStyle"
				Text="Add to List" style="cursor:pointer;" onfocus="changeColour(this, '#ccc')"/>
			<br />
			<br /><br />
		    
		<asp:GridView ID="Medicinelist"  runat="server" CellPadding="4" ForeColor="Black" 
		GridLines="Horizontal"
		Height="170px" Width="588px" AutoGenerateColumns="False" BackColor="White" 
				BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
		>
		<Columns>
				<asp:BoundField HeaderText="ID" DataField="medicineId" HtmlEncode="true"/>
				<asp:BoundField HeaderText="Name" DataField="Item" HtmlEncode="true"/>
				<asp:BoundField HeaderText="Quantity" DataField="Quantity" HtmlEncode="true"/>
				<asp:TemplateField HeaderText="DEL">
				<ItemTemplate>
					<%#"<a href=\"javascript:del('" + Eval("medicineId") + "');\">delete</a>"%>
				</ItemTemplate>
				</asp:TemplateField>
		</Columns>
		<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
		<PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
		<SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
		<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
	</asp:GridView>  


	</div>
</asp:Content>
