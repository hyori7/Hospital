<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="aspx_payment_insurance_list" MasterPageFile="~/master/subMain.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript">
	   function view(insuranceId) {
	        document.location.href = "/hospital/aspx/payment/insurance/update.aspx?insuranceId=" + insuranceId;
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
        
       Insurance List
    <asp:GridView ID="insurance" runat="server" CellPadding="4" ForeColor="Black" 
        GridLines="Horizontal" Font-Names="Arial,Helvetica,sans-serif"
        Height="170px" Width="588px" AutoGenerateColumns="False" BackColor="White" 
			BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
        <Columns>
				<asp:TemplateField HeaderText="InsuranceID">
					<ItemTemplate>
						<%#"<a href=\"javascript:view('" + Eval("insuranceId") + "');\">" + Eval("insuranceId") + "</a>"%>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:BoundField HeaderText="Insurance Name" DataField="insuranceName"/>
				<asp:BoundField HeaderText="Rate" DataField="rate" /> 
	    </Columns>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
        <asp:Button ID="create" runat="server" Text="New Insurance" onclick="Create" cssclass="inputStyle" style="cursor:pointer;" onfocus="changeColour(this, '#ccc')" />
   </div>
</asp:Content>