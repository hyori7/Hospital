<%@ Page Language="C#" AutoEventWireup="true" CodeFile="payment.aspx.cs" Inherits="aspx_receptionist_payment_payment" MasterPageFile="~/master/subMain.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript">
		function saveHtml() {
			try {
				var html = document.getElementById("printingPlace").innerHTML;
				document.getElementById("ctl00_cnt_html").value = encodeURI(html);
			} catch (e) { }

			return true;
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
    &nbsp;<asp:HiddenField id="pId" runat="server"/>
	<asp:HiddenField ID="html" runat="server" />
	<div id="printingPlace" >
	Payment Invoice
    <div class="break2"></div>
    Customer Details
    <div class="break2"></div>
	NAME : 
	    <br />
	<asp:Label ID="userInfo" runat="server" Text=""></asp:Label>
	    <br /><br />
        E-MAIL:<br />
    <asp:Label ID="USEREMAIL" runat="server" Text="Label"></asp:Label><br />  <br />  
        INSURANCE#:<br />
    <asp:Label ID="INSURANNUMBER" runat="server" Text="Label"></asp:Label><br />  <br />  
        CREATED:<br />
    <asp:Label ID="CREATEDDATE" runat="server" Text="Label"></asp:Label><br />  <br />  
        GENERAL
        <div class="break2"></div>
        <asp:GridView ID="historyView" runat="server" 
            AutoGenerateColumns="False">
		<Columns>
			<asp:BoundField HeaderText="STAFF" DataField="staffId"/>
			<asp:BoundField HeaderText="type" DataField="Item"/>
			<asp:BoundField HeaderText="date" DataField="date"/>
			<asp:BoundField HeaderText="price" DataField="Price" 
				ItemStyle-HorizontalAlign="Right">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
			</asp:BoundField>
			<asp:BoundField HeaderText="Price (After Insurance)" DataField="afterPrice" 
				ItemStyle-HorizontalAlign="Right">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
			</asp:BoundField>
		</Columns>
	</asp:GridView>
		<br />
	    MEDICINE
	    <div class="break2"></div>
	    <asp:GridView ID="medicineView" runat="server" AutoGenerateColumns="False">
			<Columns>
				<asp:BoundField HeaderText="staff" DataField="staffId"/>
				<asp:BoundField HeaderText="Item" DataField="Item"/>
				<asp:BoundField HeaderText="Price" DataField="Price" 
					ItemStyle-HorizontalAlign="Right">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
				</asp:BoundField>
				<asp:BoundField HeaderText="Qty" DataField="Quantity"/>
				<asp:BoundField HeaderText="Total" DataField="T_Price" 
					ItemStyle-HorizontalAlign="Right">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
				</asp:BoundField>
				<asp:BoundField HeaderText="Price (After Insurance)" DataField="afterPrice" 
					ItemStyle-HorizontalAlign="Right">
<ItemStyle HorizontalAlign="Right"></ItemStyle>
				</asp:BoundField>
			</Columns>
	</asp:GridView>
	<div class="break2"></div><br />
	TOTAL: $
	<asp:Label ID="totalPrice" runat="server" Text="Label"></asp:Label><br />
	<br />
	<asp:Button ID="print" runat="server" Text="PRINT" OnClick="onPrint" OnClientClick="return saveHtml()" CssClass="inputStyle" style="cursor:pointer;" onfocus="changeColour(this, '#ccc')"/>
	<asp:Button ID="pay" runat="server" Text="PAY" OnClick="onCreate" OnClientClick="return saveHtml()" CssClass="inputStyle" style="cursor:pointer;" onfocus="changeColour(this, '#ccc')"/>
	</div>
</asp:Content>