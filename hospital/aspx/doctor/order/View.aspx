<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="aspx_doctor_order_View" MasterPageFile="~/master/subMain.master"%>
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

		.inputStyle 
		{
			background-color: #FFFFFF; color: #414141; 
			font-family: Arial, Helvetica, sans-serif ; font-size: 11px ; border:1px solid #ccc ; padding: 7px ; overflow: hidden ;
		}
	</style>
	<script type="text/javascript">
		window.onload = function() {
			var popupcalendar = new Epoch('cal', 'popup', document.getElementById('ctl00_cnt_DOB'), false);
		}

	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cnt" runat="server">
		ORDER<br />
		Order For  &nbsp;<asp:Label ID="userNameLabel" runat="server" Text=""></asp:Label>
		<div id="doctor's order form">
		
			<asp:TextBox ID="UserID" runat="server" style="display:none;"></asp:TextBox>
			<asp:TextBox ID="OrderID" runat="server" style="display:none;"></asp:TextBox>
		<asp:TextBox ID="UserOD" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')"  Height="212px" 
				Width="382px" TextMode="MultiLine"></asp:TextBox><br /><br />
			Need Medication?
			<asp:DropDownList ID="UsermedCheck" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" >
			<asp:ListItem Value="False" Text="No"></asp:ListItem>			
			<asp:ListItem Value="True" Text="Yes"></asp:ListItem>
			</asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
			<br />Medication<br />
		<asp:TextBox ID="Usermed" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')"  Height="212px" 
				Width="382px" TextMode="MultiLine"></asp:TextBox><br /><br />
			Is it needed during school hours?
			<asp:DropDownList ID="Usernas" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" >
			<asp:ListItem Value="False" Text="No"></asp:ListItem>
			<asp:ListItem Value="True" Text="Yes"></asp:ListItem>
			</asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
			<br />Dosage and route of administration:<br />
		<asp:TextBox ID="Userdosage" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" ></asp:TextBox>
			<br />
			<br />Possiable side effects:<br />
		<asp:TextBox ID="Userside" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" ></asp:TextBox>
			<br />
			<br />
			Need another appointment
			<asp:DropDownList ID="UserNAA" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" >
			<asp:ListItem Value="False" Text="No"></asp:ListItem>
			<asp:ListItem Value="True" Text="Yes"></asp:ListItem>
			</asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
			<br />
			<br />
			Memo<br />
		<asp:TextBox ID="Memo" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')"  Height="212px" 
				Width="382px" TextMode="MultiLine"></asp:TextBox><br /><br />
		    


	<asp:Button ID="updBtn" runat="server" Text="Update" onclick="Update" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" style="cursor:pointer;"/>
	<asp:Button ID="delBtn" runat="server" Text="Delete" onclick="Delete" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" style="cursor:pointer;"/>
	<input type="button" value="close" onclick="history.go(-1);"  onfocus="changeColour(this, '#ccc')" style="cursor:pointer;" Class="inputStyle"/></div>
</asp:Content>
