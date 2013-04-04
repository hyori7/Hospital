<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Create.aspx.cs" Inherits="aspx_doctor_Test_Result_Create" MasterPageFile="~/master/subMain.master" %>
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
			var popupcalendar = new Epoch('cal', 'popup', document.getElementById('ctl00_cnt_DOT'), false);
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
		Test result<br />
		New Test result of &nbsp;<asp:Label ID="userNameLabel" runat="server" Text="Label"></asp:Label>
		<div id="doctor's surgery form" style="width: 600px">
		<br />Date of Test<br />
		<asp:TextBox ID="DOT" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" ></asp:TextBox><br />
			<br />
			Observation of Result<br />
			1. Skeleton and soft tissue<br />
			<asp:DropDownList ID="OR1" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" >
			<asp:ListItem Value="True" >Normal</asp:ListItem>
			<asp:ListItem Value="False" >Abnormal</asp:ListItem>
			</asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:TextBox ID="ORT1" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')"  ></asp:TextBox>
			<br />
			<br />
			2. Cardlac shadow<br />
			<asp:DropDownList ID="OR2" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" >
			<asp:ListItem Value="True" >Normal</asp:ListItem>
			<asp:ListItem Value="False" >Abnormal</asp:ListItem>
			</asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:TextBox ID="ORT2" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')"  ></asp:TextBox>
			<br />
			<br />
			3. Hilar and lymphatic glands<br />
			<asp:DropDownList ID="OR3" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" >
			<asp:ListItem Value="True" >Normal</asp:ListItem>
			<asp:ListItem Value="False" >Abnormal</asp:ListItem>
			</asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:TextBox ID="ORT3" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')"  ></asp:TextBox>
			<br />
			<br />
			4. Hemidlaphragms and costophrenic angles<br />
			<asp:DropDownList ID="OR4" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" >
			<asp:ListItem Value="True" >Normal</asp:ListItem>
			<asp:ListItem Value="False" >Abnormal</asp:ListItem>
			</asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:TextBox ID="ORT4" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')"  ></asp:TextBox>
			<br />
			<br />
			5. Lung fields<br />
			<asp:DropDownList ID="OR5" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" >
			<asp:ListItem Value="True" >Normal</asp:ListItem>
			<asp:ListItem Value="False" >Abnormal</asp:ListItem>
			</asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:TextBox ID="ORT5" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')"  ></asp:TextBox>
			<br />
			<br />
			6. Evidence of TB<br />
			<asp:DropDownList ID="OR6" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" >
			<asp:ListItem Value="True" >Normal</asp:ListItem>
			<asp:ListItem Value="False" >Abnormal</asp:ListItem>
			</asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;
			<asp:TextBox ID="ORT6" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')"  ></asp:TextBox>
			<br />
			<br />
			7. Details of other abnormalities<br />
			<asp:TextBox ID="other_abnormalities" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')"  Height="212px" 
				Width="382px" TextMode="MultiLine"></asp:TextBox>
			<br />
			<br />
			Memo<br />
			<asp:TextBox ID="Memo" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')"  Height="212px" 
				Width="382px" TextMode="MultiLine"></asp:TextBox>
			<br />

			X-ray<br />
			<asp:DropDownList ID="Xray" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" >
				<asp:ListItem Text="True" Value="True"></asp:ListItem>
				<asp:ListItem Text="False" Value="False"></asp:ListItem>
			</asp:DropDownList>
			<br />
			MRI<br />
			<asp:DropDownList ID="MRI" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" >
				<asp:ListItem Text="True" Value="True"></asp:ListItem>
				<asp:ListItem Text="False" Value="False"></asp:ListItem>
			</asp:DropDownList>
			<br />
			<asp:HiddenField ID="UserID" runat="server" />
	<asp:Button ID="subBtn" runat="server" Text="Submit" onclick="Submit" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" style="cursor:pointer;"/>
	<input type="button" value="Reset" onclick="form.reset()"  onfocus="changeColour(this, '#ccc')" style="cursor:pointer;" class="inputStyle"/>
    <input type="button" value="close" onclick="history.go(-1);"  onfocus="changeColour(this, '#ccc')" style="cursor:pointer;" class="inputStyle"/></div>

</asp:Content>
