<%@ Page Language="C#" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="aspx_doctor_Surgery_View" MasterPageFile="~/master/subMain.master"%>
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
	<script type="text/javascript">
		window.onload = function() {
			var popupcalendar = new Epoch('cal', 'popup', document.getElementById('ctl00_cnt_DOS'), false);
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
Surgery<br />
New Surgery For  &nbsp;<asp:Label ID="userNameLabel" runat="server" Text="Label"></asp:Label>
		<div id="doctor's surgery form">
		<asp:TextBox ID="UserID" runat="server" style="display:none;"></asp:TextBox>
		<asp:TextBox ID="SurgeryID" runat="server" style="display:none;"></asp:TextBox>
		<br />Type of Surgery<br />
		<asp:DropDownList ID="type" runat="server" DataTextField="Item" DataValueField="ID" CssClass="inputStyle">
		</asp:DropDownList>
		<br />Date of Surgery<br />
		<asp:TextBox ID="DOS" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" ></asp:TextBox><br />
             <br />Room of Surgery<br />
			<asp:DropDownList ID="ROS" runat="server" CssClass="inputStyle">
				<asp:ListItem Value="421" Text="Surgery Room 1"></asp:ListItem>
				<asp:ListItem Value="422" Text="Surgery Room 2"></asp:ListItem>
				<asp:ListItem Value="423" Text="Surgery Room 3"></asp:ListItem>
				<asp:ListItem Value="424" Text="Surgery Room 4"></asp:ListItem>
			</asp:DropDownList>
		    <br />Brief description of the surgery<br />
		<asp:TextBox ID="surgery_description" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')"  Height="212px" 
                Width="382px" TextMode="MultiLine"></asp:TextBox><br />
            <br />Possiable side effects:<br />
		<asp:TextBox ID="surgeryse" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" ></asp:TextBox>
            <br />
            <br />
            Memo<br />
		    		<asp:TextBox ID="Memo" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')"  Height="212px" 
                Width="382px" TextMode="MultiLine"></asp:TextBox>
            <br />
            <br />
		    


	<asp:Button ID="updBtn" runat="server" Text="Update" onclick="Update" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" style="cursor:pointer;"/>
	<asp:Button ID="delBtn" runat="server" Text="Delete" onclick="Delete" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" style="cursor:pointer;"/><input type="button" value="close" onclick="history.go(-1);"  onfocus="changeColour(this, '#ccc')" style="cursor:pointer;" Class="inputStyle"/>
	</div>

</asp:Content>
