<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="aspx_Payment_View" MasterPageFile="~/master/subMain.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link rel="stylesheet" type="text/css" href="../../../css/epoch_styles.css" />
	<script type="text/javascript" src="../../../script/epoch_classes.js"></script>
	<style type="text/css">
		.inputStyle 
		{
			background-color: #FFFFFF; color: #414141;" 
            font-family: Arial, Helvetica, sans-serif ; font-size: 11px ; border:1px solid #ccc ; padding: 7px ; overflow: hidden ;
		}
		
		
	</style>
	<script type="text/javascript">
		function checkPost(obj) {
			if (obj.value.length > 6) {
				obj.value = obj.value.substring(0, 6);
			}
			obj.value = obj.value.replace(/[^0-9]/g, "");
		}
	</script>
	
</asp:Content>

<asp:Content ID="Contents" ContentPlaceHolderID="cnt" runat="server">
	General Payment Items<br />
	<asp:TextBox ID="ItemID" runat="server" style="display:none;" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')"></asp:TextBox>
	Item:
	<asp:TextBox ID="ItemTextBox" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" ></asp:TextBox>
		<br />
		<asp:Label ID="TypLabel" runat="server" Text="Type:" CssClass="inputStyle" style="border:none;"></asp:Label>
	<asp:DropDownList ID="TypeDropDownList" runat="server" CssClass="inputStyle" DataTextField="Type" DataValueField="Type" onfocus="changeColour(this, '#ccc')">
	</asp:DropDownList>
		<br />
		<asp:Label ID="PriceLabel" runat="server" Text="Price:" CssClass="inputStyle" style="border:none;"></asp:Label>
	<asp:TextBox ID="PriceTextBox" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" onkeyup="checkPost(this)"></asp:TextBox>
		<br />
		<asp:Label ID="InsuranceStateLabel" runat="server" Text="InsuranceState:" CssClass="inputStyle" style="border:none;"></asp:Label>
	
	<asp:DropDownList ID="InsuranceStateTextBox" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')">
		<asp:ListItem Value="0" Text="covered"></asp:ListItem>
		<asp:ListItem Value="1" Text="not covered"></asp:ListItem>
	</asp:DropDownList>
	<br />
	<asp:Button ID="Update" runat="server" Text="Update" onclick="OnUpdate" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" style="cursor:pointer;"/>
	<asp:Button ID="Cancel" runat="server" Text="Cancel" onclick="OnCancel" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" style="cursor:pointer;"/>
	<br />
    
</asp:Content>