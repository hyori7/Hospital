<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="aspx_Payment_list" MasterPageFile="~/master/subMain.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link rel="stylesheet" type="text/css" href="../../../css/epoch_styles.css" />
		<script type="text/javascript">
			function view(ID) {
				document.location.href = "/hospital/aspx/Payment/general/View.aspx?itemID=" + ID;
			}

			function deleteitem(ID) {
				var check = confirm("Really?");
				if (!check) return;
				document.location.href = "/hospital/aspx/Payment/general/list.aspx?itemID=" + ID;
			}
			function checkPost(obj) {
				if (obj.value.length > 6) {
					obj.value = obj.value.substring(0, 6);
				}
				obj.value = obj.value.replace(/[^0-9]/g, "");
			}
	</script>
	<script type="text/javascript" src="../../../script/epoch_classes.js"></script>
	<style type="text/css">
		.inputStyle 
		{
			background-color: #FFFFFF; color: #414141;" 
            font-family: Arial, Helvetica, sans-serif ; font-size: 11px ; border:1px solid #ccc ; padding: 7px ; overflow: hidden ;
		}
		
		
	</style>
	
</asp:Content>

<asp:Content ID="Contents" ContentPlaceHolderID="cnt" runat="server">
Type:
	<asp:DropDownList ID="Type" runat="server" DataValueField ="Type" DataTextField="Type" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')">
    </asp:DropDownList>
    	&nbsp;Item: <input id="searchValue" name="searchValue" value="<%=Param.get("searchValue")%>" Class="inputStyle" onfocus="changeColour(this, '#ccc')"/>
	<asp:Button ID="search" runat="server" Text="SEARCH" OnClick="onSearch" CssClass="inputStyle" style="cursor:pointer;"  onfocus="changeColour(this, '#ccc')"/>
	<br />
	General Payment Items
	<asp:GridView ID="general_payment_items"  runat="server" CellPadding="4" ForeColor="Black" 
			GridLines="Horizontal"
		Height="170px" Width="588px" AutoGenerateColumns="False" BackColor="White" 
		BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
		>
		<Columns>
				<asp:TemplateField HeaderText="ID">
					<ItemTemplate>
						<%#"<a href = \"javascript:view('" + Eval("ID") + "');\">" + Eval("ID") + "</a>"%>
					</ItemTemplate>
		        </asp:TemplateField>
				<asp:BoundField HeaderText="Item" DataField="Item" HtmlEncode="true"/>
				<asp:BoundField HeaderText="Type" DataField="Type" HtmlEncode="true"/>
				<asp:BoundField HeaderText="Price" DataField="Price" HtmlEncode="true"/>
				<asp:BoundField HeaderText="InsuranceState" DataField="insuranceState" HtmlEncode="true"/>
				<asp:TemplateField HeaderText="DELETE">
					<ItemTemplate>
						<%#"<a href = \"javascript:deleteitem('" + Eval("ID") + "');\">Delete</a>"%>
					</ItemTemplate>
		        </asp:TemplateField>
		</Columns>
		<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
		<PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
		<SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
		<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
	</asp:GridView>    
    <asp:Label ID="ItemLabel" runat="server" Text="Item:" CssClass="inputStyle"></asp:Label>
    <asp:TextBox ID="ItemTextBox" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')"></asp:TextBox>
            <asp:Label ID="TypeDropDownListLabel" runat="server" Text="Type:" CssClass="inputStyle"></asp:Label>
	<asp:DropDownList onfocus="changeColour(this, '#ccc')" ID="TypeDropDownList" runat="server" DataValueField ="Type" DataTextField="Type" CssClass="inputStyle">
    </asp:DropDownList>
        <asp:Label ID="PriceLabel" runat="server" Text="Price:" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')"></asp:Label>
    <asp:TextBox ID="PriceTextBox" runat="server" onkeyup="checkPost(this)" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')"></asp:TextBox>
    <asp:Button ID="Create" runat="server" Text="Create" onclick="OnCreate" style="cursor:pointer;"  CssClass="inputStyle"  onfocus="changeColour(this, '#ccc')"/>
    <br />
    
    
</asp:Content>
