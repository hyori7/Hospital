<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view.aspx.cs" Inherits="aspx_admin_Room_view" MasterPageFile="~/master/subMain.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link rel="stylesheet" type="text/css" href="../../../css/epoch_styles.css" />
	<script type="text/javascript" src= "../../../script/epoch_classes.js"></script>
	<style type="text/css">
		.inputStyle 
		{
			background-color: #ffffff; color: #414141; 
			border: 1px solid #ccc;
			cursor: pointer;
			font-family: Arial, Helvetica, sans-serif ; font-size: 11px ; padding: 7px ; overflow: hidden ;
		}
	</style>
	<script type="text/javascript">
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cnt" runat="server">

		<asp:HiddenField ID="DeptName" runat="server" />
		Status of Room  &nbsp;<asp:Label ID="RoomLabel" runat="server" Text="Label"></asp:Label>
			<asp:HiddenField ID="RoomID" runat="server" />
		<div id="Room status form">
			RoomType:
		<asp:TextBox ID="RoomType" runat="server" cols="60" rows="1"  style="background-color: #FFFFFF; color: #414141; 
			font-family: Arial, Helvetica, sans-serif ; font-size: 11px ; border:1px solid #ccc ; padding: 7px ; overflow: hidden ; " onfocus="changeColour(this, '#DBDADB')" ></asp:TextBox>
			<br />
			<br />
			Room Owner:
			<asp:DropDownList ID="RoomOwner" runat="server" style="background-color: #FFFFFF; color: #414141; 
				font-family: Arial, Helvetica, sans-serif ; font-size: 11px ; border:1px solid #ccc ; padding: 7px ; overflow: hidden ; " onfocus="changeColour(this, '#DBDADB')" DataTextField="UserID" DataValueField="UserID" >
			</asp:DropDownList>
			<br />
			<br />
			Beds
			<asp:DropDownList ID="Beds" runat="server" style="background-color: #FFFFFF; color: #414141; 
				font-family: Arial, Helvetica, sans-serif ; font-size: 11px ; border:1px solid #ccc ; padding: 7px ; overflow: hidden ; " onfocus="changeColour(this, '#DBDADB')">
			<asp:ListItem Value="2" Text="2"></asp:ListItem>
			<asp:ListItem Value="4" Text="4"></asp:ListItem>
			<asp:ListItem Value="8" Text="8"></asp:ListItem>
			</asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;<br />
			<br />
			&nbsp;<asp:Button ID="updateBtn" runat="server" Text="Update" onclick="Update" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" /><input type="button" value="Cancel" onclick="form.reset();" class="inputStyle" onfocus="changeColour(this, '#ccc')"/><input type="button" value="close" onclick="history.go(-1);" class="inputStyle" onfocus="changeColour(this, '#ccc')"/></div>


</asp:Content>
