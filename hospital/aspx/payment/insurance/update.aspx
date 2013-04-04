<%@ Page Language="C#" AutoEventWireup="true" CodeFile="update.aspx.cs" Inherits="aspx_payment_insurance_update" MasterPageFile="~/master/subMain.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript">
	function checkPost(obj) {
		if (obj.value.length > 4) {
			obj.value = obj.value.substring(0, 4);
		}
		obj.value = obj.value.replace(/[^0-9]/g, "");
		if (parseInt(obj.value) > 100) {
			obj.value = "100";
		} else if (parseInt(obj.value) < 1) {
			obj.value = "1";
		}
	}
</script>	
	<style type="text/css">
		.inputStyle 
		{
			background-color: #FFFFFF; color: #414141;
            font-family: Arial, Helvetica, sans-serif ; font-size: 11px ; border:1px solid #ccc ; padding: 7px ; overflow: hidden ;
		}
		</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cnt" runat="server">
	
	
    <div>
        
       Update Insurance <br />
        <asp:TextBox ID="insuranceId" runat="server" onfocus="changeColour(this, '#ccc')" cssclass="inputStyle"></asp:TextBox>
        <br />
       Insurance Name<br />
        <asp:TextBox ID="insuranceName" runat="server" onfocus="changeColour(this, '#ccc')" cssclass="inputStyle"></asp:TextBox><br />
        Rate <br />
        <asp:TextBox ID="rate" runat="server" onkeyup="checkPost(this)" onfocus="changeColour(this, '#ccc')" cssclass="inputStyle"></asp:TextBox><br /><br />
        
        <asp:Button ID="update" runat="server" Text="Update" OnClick="update_click" cssclass="inputStyle" style="cursor:pointer;" onfocus="changeColour(this, '#ccc')" />
        <asp:Button ID="delete" runat="server" Text="Delete" OnClick="delete_click" cssclass="inputStyle" style="cursor:pointer;" onfocus="changeColour(this, '#ccc')" />
   </div>
</asp:Content>