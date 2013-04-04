<%@ Page Language="C#" AutoEventWireup="true" CodeFile="create.aspx.cs" Inherits="aspx_nurse_observation_create" MasterPageFile="~/master/subMain.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link rel="stylesheet" type="text/css" href="../../../css/epoch_styles.css" />
	<script type="text/javascript" src= "../../../script/epoch_classes.js"></script>
	<style type="text/css">
		.regText 
		{
			background-color: #FFFFFF; color: #414141; 
font-family: Arial, Helvetica, sans-serif ; font-size: 11px ; border:1px solid #ccc ; padding: 7px ; overflow: hidden ;
		}
	   
	</style>
	<script type="text/javascript">
		window.onload = function() {
			var popupcalendar = new Epoch('cal', 'popup', document.getElementById('ctl00_cnt_DOB'), false);
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
<div id="page-wrap">

     <asp:Label ID="userNameLabel" runat="server" Text="Label"></asp:Label><br />
      <asp:TextBox ID="UserID" runat="server" style="display:none;"></asp:TextBox>
    <asp:TextBox ID="nurseID" runat="server" style="display:none;"></asp:TextBox>
      <h1>Nurses Observations<div class="break"></div></h1>

      <table class="contacts" cellspacing="0" summary="Contacts template">
<tr>
<td class="contactDept" colspan="1">OBSERVATIONS</td>
<td class="contactDept" colspan="1">Status</td>
</tr>
 
<tr>
<td class ="contact" width="30%"><a>A.HEAD, FACE, NECK AND SCALP</a></td>
<td class ="contact" width="30"><asp:DropDownList ID="head" runat="server" class="regText" onfocus="changeColour(this, '#ccc')">
         <asp:ListItem Value="True" Text="Normal"></asp:ListItem>
         <asp:ListItem Value="False" Text="Abnormal"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>

<tr>
<td class="contact" width="30%"><a>B. EARS - GENERAL (INTERNAL CANALS)</a></td>
<td class="contact" width="30%"><asp:DropDownList ID="ear" runat="server" class="regText" onfocus="changeColour(this, '#ccc')">
         <asp:ListItem Value="True" Text="Normal"></asp:ListItem>
         <asp:ListItem Value="False" Text="Abnormal"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>

<tr>
<td class="contact" width="30%"><a>C. DRUMS (Perforation)</a></td>
<td class="contact" width="30%"><asp:DropDownList ID="drum" runat="server" class="regText" onfocus="changeColour(this, '#ccc')">
         <asp:ListItem Value="True" Text="Normal"></asp:ListItem>
         <asp:ListItem Value="False" Text="Abnormal"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>

<tr>
<td class="contact" width="30%"><a>D. NOSE</a></td>
<td class="contact" width="30%"><asp:DropDownList ID="nose" runat="server" class="regText" onfocus="changeColour(this, '#ccc')">
         <asp:ListItem Value="True" Text="Normal"></asp:ListItem>
         <asp:ListItem Value="False" Text="Abnormal"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>

<tr>
<td class="contact" width="30%"><a>E. SINUSES</a></td>
<td class="contact" width="30%"><asp:DropDownList ID="sinus" runat="server" class="regText" onfocus="changeColour(this, '#ccc')">
         <asp:ListItem Value="True" Text="Normal"></asp:ListItem>
         <asp:ListItem Value="False" Text="Abnormal"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>

<tr>
<td class="contact" width="30%"><a>F. MOUTH AND THROAT</a></td>
<td class="contact" width="30%"><asp:DropDownList ID="mouth" runat="server" class="regText" onfocus="changeColour(this, '#ccc')">
         <asp:ListItem Value="True" Text="Normal"></asp:ListItem>
         <asp:ListItem Value="False" Text="Abnormal"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>

<tr>
<td class="contact" width="30%"><a>G. EYES - GENERAL</a></td>
<td class="contact" width="30%"><asp:DropDownList ID="eye" runat="server" class="regText" onfocus="changeColour(this, '#ccc')">
         <asp:ListItem Value="True" Text="Normal"></asp:ListItem>
         <asp:ListItem Value="False" Text="Abnormal"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>

<tr>
<td class="contact" width="30%"><a>H. OPTHALMOSCOPIC</a></td>
<td class="contact" width="30%"><asp:DropDownList ID="opthal" runat="server" class="regText" onfocus="changeColour(this, '#ccc')">
         <asp:ListItem Value="True" Text="Normal"></asp:ListItem>
         <asp:ListItem Value="False" Text="Abnormal"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>

<tr>
<td class="contact" width="30%"><a>I. PUPILS</a></td>
<td class="contact" width="30%"><asp:DropDownList ID="pupil" runat="server" class="regText" onfocus="changeColour(this, '#ccc')">
         <asp:ListItem Value="True" Text="Normal"></asp:ListItem>
         <asp:ListItem Value="False" Text="Abnormal"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>

<tr>
<td class="contact" width="30%"><a>J. OCULAR MOTILITY</a></td>
<td class="contact" width="30%"><asp:DropDownList ID="ocular" runat="server" class="regText" onfocus="changeColour(this, '#ccc')">
         <asp:ListItem Value="True" Text="Normal"></asp:ListItem>
         <asp:ListItem Value="False" Text="Abnormal"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>

<tr>
<td class="contact" width="30%"><a>K. LUNGS AND CHEST</a></td>
<td class="contact" width="30%"><asp:DropDownList ID="lung" runat="server" class="regText" onfocus="changeColour(this, '#ccc')">
         <asp:ListItem Value="True" Text="Normal"></asp:ListItem>
         <asp:ListItem Value="False" Text="Abnormal"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>

<tr>
<td class="contact" width="30%"><a>L. HEART</a></td>
<td class="contact" width="30%"><asp:DropDownList ID="heart" runat="server" class="regText" onfocus="changeColour(this, '#ccc')">
         <asp:ListItem Value="True" Text="Normal"></asp:ListItem>
         <asp:ListItem Value="False" Text="Abnormal"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>

<tr>
<td class="contact" width="30%"><a>M. VASCULAR SYSTEM</a></td>
<td class="contact" width="30%"><asp:DropDownList ID="vascular" runat="server" class="regText" onfocus="changeColour(this, '#ccc')">
         <asp:ListItem Value="True" Text="Normal"></asp:ListItem>
         <asp:ListItem Value="False" Text="Abnormal"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>

<tr>
<td class="contact" width="30%"><a>N. ABDOMEN AND VISCERA</a></td>
<td class="contact" width="30%"><asp:DropDownList ID="abdomen" runat="server" class="regText" onfocus="changeColour(this, '#ccc')">
         <asp:ListItem Value="True" Text="Normal"></asp:ListItem>
         <asp:ListItem Value="False" Text="Abnormal"></asp:ListItem>
</asp:DropDownList>
</td>
</tr>
</table>
     
     Memo:
    <asp:TextBox ID="memo" runat="server" TextMode="MultiLine" Height="80px" Width="667px"  onfocus="changeColour(this, '#ccc')"  cssclass="inputStyle" ></asp:TextBox><br /><br />
    

     <asp:Button ID="submit" runat="server" Text="Submit" CssClass="regText" style="cursor:pointer;" OnClick="submit_Click" onfocus="changeColour(this, '#ccc')"/>
     &nbsp;&nbsp;&nbsp;&nbsp;
     <asp:Button ID="cancel" runat="server" Text="Cancel" CssClass="regText" style="cursor:pointer;" OnClick="oncancel" onfocus="changeColour(this, '#ccc')"/>
    </div>

</asp:Content>


