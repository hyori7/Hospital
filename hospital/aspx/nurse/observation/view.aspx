<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view.aspx.cs" Inherits="aspx_nurse_observation_view" MasterPageFile="~/master/subMain.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link rel="stylesheet" type="text/css" href="../../../css/epoch_styles.css" />
	<script type="text/javascript" src="../../../script/epoch_classes.js"></script>
	<style type="text/css">
		.regText 
		{
				background-color: #FFFFFF; color: #414141; 
				font-family: Arial, Helvetica, sans-serif ; font-size: 11px ; border:1px solid #ccc ; padding: 7px ; overflow: hidden ;
		}
	</style>
	<script type="text/javascript">
		window.onload = function () {
			var popupcalendar = new Epoch('cal','popup',document.getElementById('ctl00_cnt_DOB'),false);
		}

		function checkPost(obj) {
			if (obj.value.length > 4) {
				obj.value = obj.value.substring(0,4);
			}
			obj.value = obj.value.replace(/[^0-9]/g, "");
		}
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cnt" runat="server">
<div class="navwrap2" id="updateForm">
      <asp:TextBox ID="UserID" runat="server" style="display:none;"></asp:TextBox>
      <asp:TextBox ID="ObservationID" runat="server" style="display:none;"></asp:TextBox>
		<asp:TextBox ID="date" runat="server" style="display:none;"></asp:TextBox>
    <asp:TextBox ID="id" runat="server" style="display:none;"></asp:TextBox>
     <h1>Nurses Update Observation : <asp:Label ID="userNameLabel" runat="server" Text="Label"></asp:Label><div class="break"></div></h1>

      <table class="contacts" cellspacing="0" summary="Contacts template">
<tr>
<td class="contactDept" colspan="1">OBSERVATIONS</td>
<td class="contactDept" colspan="1">Status</td>
</tr>
 
<tr>
<td class ="contact" width="30%">A.HEAD, FACE, NECK AND SCALP</td>
<td class ="contact" width="30"><asp:DropDownList ID="head" runat="server" class="regText" onfocus="changeColour(this, '#ccc')">
         <asp:ListItem Value="True" Text="Normal"></asp:ListItem>
         <asp:ListItem Value="False" Text="Abnormal"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>

<tr>
<td class="contact" width="30%"> B. EARS - GENERAL (INTERNAL CANALS)</td>
<td class="contact" width="30%"><asp:DropDownList ID="ear" runat="server" class="regText" onfocus="changeColour(this, '#ccc')">
         <asp:ListItem Value="True" Text="Normal"></asp:ListItem>
         <asp:ListItem Value="False" Text="Abnormal"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>

<tr>
<td class="contact" width="30%">C. DRUMS (Perforation)</td>
<td class="contact" width="30%"><asp:DropDownList ID="drum" runat="server" class="regText" onfocus="changeColour(this, '#ccc')">
         <asp:ListItem Value="True" Text="Normal"></asp:ListItem>
         <asp:ListItem Value="False" Text="Abnormal"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>

<tr>
<td class="contact" width="30%">D. NOSE</td>
<td class="contact" width="30%"><asp:DropDownList ID="nose" runat="server" class="regText" onfocus="changeColour(this, '#ccc')">
         <asp:ListItem Value="True" Text="Normal"></asp:ListItem>
         <asp:ListItem Value="False" Text="Abnormal"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>

<tr>
<td class="contact" width="30%">E. SINUSES</td>
<td class="contact" width="30%"><asp:DropDownList ID="sinus" runat="server" class="regText" onfocus="changeColour(this, '#ccc')">
         <asp:ListItem Value="True" Text="Normal"></asp:ListItem>
         <asp:ListItem Value="False" Text="Abnormal"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>

<tr>
<td class="contact" width="30%">F. MOUTH AND THROAT</td>
<td class="contact" width="30%"><asp:DropDownList ID="mouth" runat="server" class="regText" onfocus="changeColour(this, '#ccc')">
         <asp:ListItem Value="True" Text="Normal"></asp:ListItem>
         <asp:ListItem Value="False" Text="Abnormal"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>

<tr>
<td class="contact" width="30%">G. EYES - GENERAL</td>
<td class="contact" width="30%"><asp:DropDownList ID="eye" runat="server" class="regText" onfocus="changeColour(this, '#ccc')">
         <asp:ListItem Value="True" Text="Normal"></asp:ListItem>
         <asp:ListItem Value="False" Text="Abnormal"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>

<tr>
<td class="contact" width="30%">H. OPTHALMOSCOPIC</td>
<td class="contact" width="30%"><asp:DropDownList ID="opthal" runat="server" class="regText" onfocus="changeColour(this, '#ccc')">
         <asp:ListItem Value="True" Text="Normal"></asp:ListItem>
         <asp:ListItem Value="False" Text="Abnormal"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>

<tr>
<td class="contact" width="30%">I. PUPILS</td>
<td class="contact" width="30%"><asp:DropDownList ID="pupil" runat="server" class="regText" onfocus="changeColour(this, '#ccc')">
         <asp:ListItem Value="True" Text="Normal"></asp:ListItem>
         <asp:ListItem Value="False" Text="Abnormal"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>

<tr>
<td class="contact" width="30%">J. OCULAR MOTILITY</td>
<td class="contact" width="30%"><asp:DropDownList ID="ocular" runat="server" class="regText" onfocus="changeColour(this, '#ccc')">
         <asp:ListItem Value="True" Text="Normal"></asp:ListItem>
         <asp:ListItem Value="False" Text="Abnormal"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>

<tr>
<td class="contact" width="30%">K. LUNGS AND CHEST</td>
<td class="contact" width="30%"><asp:DropDownList ID="lung" runat="server" class="regText" onfocus="changeColour(this, '#ccc')">
         <asp:ListItem Value="True" Text="Normal"></asp:ListItem>
         <asp:ListItem Value="False" Text="Abnormal"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>

<tr>
<td class="contact" width="30%">L. HEART</td>
<td class="contact" width="30%"><asp:DropDownList ID="heart" runat="server" class="regText" onfocus="changeColour(this, '#ccc')">
         <asp:ListItem Value="True" Text="Normal"></asp:ListItem>
         <asp:ListItem Value="False" Text="Abnormal"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>

<tr>
<td class="contact" width="30%">M. VASCULAR SYSTEM</td>
<td class="contact" width="30%"><asp:DropDownList ID="vascular" runat="server" class="regText" onfocus="changeColour(this, '#ccc')">
         <asp:ListItem Value="True" Text="Normal"></asp:ListItem>
         <asp:ListItem Value="False" Text="Abnormal"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>

<tr>
<td class="contact" width="30%">N. ABDOMEN AND VISCERA</td>
<td class="contact" width="30%"><asp:DropDownList ID="abdomen" runat="server" class="regText" onfocus="changeColour(this, '#ccc')">
         <asp:ListItem Value="True" Text="Normal"></asp:ListItem>
         <asp:ListItem Value="False" Text="Abnormal"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
     
     Memo:
    <asp:TextBox ID="memo" runat="server" TextMode="MultiLine" Height="101px" Width="667px"  onfocus="changeColour(this, '#ccc')"  cssclass="inputStyle" ></asp:TextBox><br /><br />
    <% if( DataTier.UserInfo.isNurse(Session) ) {%>
     <asp:Button ID="update" runat="server" Text="Update" onclick="Update" Class="regText" style="cursor:pointer;" onfocus="changeColour(this, '#ccc')"/>
     &nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Button ID="delete" runat="server" Text="Delete" onclick="Delete" Class="regText" style="cursor:pointer;" onfocus="changeColour(this, '#ccc')"/>
     &nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Button ID="cancel" runat="server" Text="Cancel" OnClick="Cancel" Class="regText" style="cursor:pointer;" onfocus="changeColour(this, '#ccc')"/>
     <%} %>
	
    </div>
    
    
    

</asp:Content>


