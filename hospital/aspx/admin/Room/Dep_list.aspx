<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dep_list.aspx.cs" Inherits="aspx_admin_Room_Dep_list" MasterPageFile="~/master/subMain.master"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript">
		function view(DeptName) {
			document.location.href = "/hospital/aspx/admin/Room/list.aspx?DeptName=" + DeptName;
		}
	    
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cnt" runat="server">
	Department LIST	
	<br />
	<asp:GridView ID="RoomList" runat="server" CellPadding="4" ForeColor="Black" 
		GridLines="Horizontal" AutoGenerateColumns="False" Width="416px" 
		BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
		<Columns>
				<asp:TemplateField HeaderText="Deparment">
					<ItemTemplate>
						<%#"<a href=\"javascript:view('" + Eval("DeptName") + "');\">" + Eval("DeptName") + "</a>"%>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:BoundField HeaderText="Level" DataField="LevelNumber"/>
			</Columns>
		<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
		<PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
		<SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
		<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
	</asp:GridView>
</asp:Content>
