<%@ Page Language="C#" AutoEventWireup="true" CodeFile="create.aspx.cs" Inherits="aspx_doctor_order_create" MasterPageFile="~/master/subMain.master"%>
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
			background-color: #FFFFFF; color: #414141; 
            font-family: Arial, Helvetica, sans-serif ; font-size: 11px ; border:1px solid #ccc ; padding: 7px ; overflow: hidden ;
		}
	</style>

	<script type="text/javascript" src="../../../script/epoch_classes.js"></script>

	
	<script type="text/javascript">
		window.onload = function() {
			var popupcalendar = new Epoch('cal', 'popup', document.getElementById('ctl00_cnt_date'), false);
		}


	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cnt" runat="server">
		ORDER<br />
		New Order For  &nbsp;<asp:Label ID="userNameLabel" runat="server" Text="Label"></asp:Label>
		<div id="doctor's order form">
		
			<asp:TextBox ID="UserID" runat="server" style="display:none;"></asp:TextBox>
		<asp:TextBox ID="UserOD" runat="server" CssClass="inputStyle" Height="212px" 
				Width="382px" TextMode="MultiLine" onfocus="changeColour(this, '#ccc')" ></asp:TextBox><br /><br />
			Need Medication?
			<asp:DropDownList ID="UsermedCheck" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')">
			<asp:ListItem Value="False" Text="No"></asp:ListItem>
			<asp:ListItem Value="True" Text="Yes"></asp:ListItem>
			</asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
			<br />Medication<br />
		<asp:TextBox ID="Usermed" runat="server" CssClass="inputStyle" Height="212px" 
				Width="382px" TextMode="MultiLine" onfocus="changeColour(this, '#ccc')" ></asp:TextBox><br /><br />
			Is it needed during school hours?
			<asp:DropDownList ID="Usernas" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')">
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
			<asp:DropDownList ID="UserNAA" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')">
			<asp:ListItem Value="False" Text="No"></asp:ListItem>
			<asp:ListItem Value="True" Text="Yes"></asp:ListItem>
			</asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
			
			<br />
			DATE<br />
			<asp:TextBox ID="date" runat="server" onfocus="changeColour(this, '#ccc')"></asp:TextBox><br />
			<br />
			stay in Hospital
			<asp:DropDownList ID="UserStay" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')">
			<asp:ListItem Value="False" Text="No"></asp:ListItem>
			<asp:ListItem Value="True" Text="Yes"></asp:ListItem>
			</asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
			<br />
			<br />
			Memo<br />
		<asp:TextBox ID="Memo" runat="server" CssClass="inputStyle" Height="212px" 
				Width="382px" TextMode="MultiLine" onfocus="changeColour(this, '#ccc')" ></asp:TextBox><br /><br />
			


	<asp:Button ID="subBtn" runat="server" Text="Submit" onclick="Submit" CssClass="inputStyle" style="cursor:pointer;"/>&nbsp;
	<input type="button" value="Reset" onclick="form.reset(); "style="background-color: #FFFFFF; color: #ccc; 
			font-family: Arial, Helvetica, sans-serif ; font-size: 11px ; border:1px solid #ccc ; padding: 7px ; overflow: hidden ; " onfocus="changeColour(this, '#DBDADB')" style="cursor:pointer;" onfocus="changeColour(this, '#DBDADB')"/>
	<input type="button" value="Close" onclick="history.go(-1);"style="background-color: #FFFFFF; color: #ccc; 
			font-family: Arial, Helvetica, sans-serif ; font-size: 11px ; border:1px solid #ccc ; padding: 7px ; overflow: hidden ; " onfocus="changeColour(this, '#DBDADB')" style="cursor:pointer;" onfocus="changeColour(this, '#DBDADB')"/></div>
</asp:Content>
