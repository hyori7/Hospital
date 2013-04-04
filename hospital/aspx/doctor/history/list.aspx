<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="aspx_doctor_history_list" MasterPageFile="~/master/subMain.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	
	<script type="text/javascript">
		function view(cntId, type) {
			if (type == 0) {
				document.location.href = "/hospital/aspx/doctor/order/view.aspx?orderId=" + cntId;
			} else if (type == 1) {
				document.location.href = "/hospital/aspx/doctor/Test Result/view.aspx?testresultId=" + cntId;
			} else if (type == 2) {
				document.location.href = "/hospital/aspx/doctor/Surgery/view.aspx?surgeryId=" + cntId;
			} else if (type == 3) {
				document.location.href = "/hospital/aspx/nurse/observation/view.aspx?cntId=" + cntId;
			}
		}

		function search() {
			var field = document.getElementById("searchField").value;
			var value = document.getElementById("searchValue").value;
			document.location.href = "/hospital/aspx/doctor/history/list.aspx?searchField=" + field + "&searchValue=" + value;
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
	Patient History of 
	<asp:Label ID="userNameLabel" runat="server" Text="Label"></asp:Label>
	<asp:DropDownList ID="pre" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')">
		<asp:ListItem Text="view present" Value="False"></asp:ListItem>
		<asp:ListItem Text="view all" Value="True"></asp:ListItem>
	</asp:DropDownList>
	<asp:Button ID="view" runat="server" Text="view" OnClick="onChange" CssClass="inputStyle"  onfocus="changeColour(this, '#ccc')" style="cursor:pointer;"/>
	<asp:HiddenField ID="pId" runat="server"/>
	<asp:HiddenField ID="DoctorID" runat="server" />
	<asp:GridView ID="patienthistory"  runat="server" CellPadding="4" ForeColor="Black" 
			GridLines="Horizontal"
		Height="170px" Width="588px" AutoGenerateColumns="False" BackColor="White" 
        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
		>
		<Columns>
				<asp:BoundField HeaderText="Date" DataField="Date" HtmlEncode="true"/>
				<asp:TemplateField HeaderText="Memo">
					<ItemTemplate>
						<%#"<a href=\"javascript:view('" + Eval("cntId") + "','" + Eval("type") + "');\">" + Eval("Memo") + "</a>"%>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:BoundField HeaderText="Type" DataField="typeText" HtmlEncode="true" />
		</Columns>
		<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
		<PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
		<SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
		<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
	</asp:GridView>    
	<asp:Button ID="newOrder" runat="server" onclick="NewOr" Text="New Order" CssClass="inputStyle"  onfocus="changeColour(this, '#ccc')" style="cursor:pointer;" />
	<asp:Button ID="newSurgery" runat="server" onclick="NewSur" Text="New Surgery" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" style="cursor:pointer;" />
	<asp:Button ID="newTest" runat="server" onclick="NewRes" Text="New Test" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" style="cursor:pointer;"/>
	<asp:Button ID="close" runat="server" onclick="Close" Text="Close" CssClass="inputStyle"  onfocus="changeColour(this, '#ccc')" style="cursor:pointer;"/>
    
</asp:Content>