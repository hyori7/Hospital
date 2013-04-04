<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="aspx_patientroom_list" MasterPageFile="~/master/subMain.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript">
		function view(RoomID) {
			document.location.href = "/hospital/aspx/nurse/patientroom/assign.aspx?RoomID=" + RoomID;
		}
	    
	</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cnt" runat="server">
	
	
	<div>
        
		Room List</div>
	<asp:GridView ID="Roomlist" runat="server" CellPadding="4" ForeColor="Black" 
		GridLines="Horizontal" Font-Names="Arial,Helvetica,sans-serif"
		Height="170px" Width="588px" AutoGenerateColumns="False" BackColor="White" 
		BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
		<Columns>
				<asp:TemplateField HeaderText="RoomID">
					<ItemTemplate>
						<%#"<a href=\"javascript:view('" + Eval("RoomID") + "');\">" + Eval("RoomID") + "</a>"%>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:BoundField HeaderText="NurseID" DataField="UserId"/>
				<asp:BoundField HeaderText="Beds" DataField="Beds" />
				<asp:BoundField HeaderText="patients" DataField="P_COUNT" />
				<asp:BoundField HeaderText="DeptID" DataField="DeptID" />
				<asp:BoundField HeaderText="LevelNum" DataField="LevelNumber"/>
		</Columns>
		<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
		<PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
		<SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
		<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
	</asp:GridView>
	Patients<br />
	 <asp:GridView ID="doctorOrder" runat="server" CellPadding="4" ForeColor="Black" 
		GridLines="Horizontal" Font-Names="Arial,Helvetica,sans-serif"
		Height="170px" Width="588px" AutoGenerateColumns="False" BackColor="White" 
		BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
		<Columns>

				<asp:BoundField HeaderText="patientId" DataField="patientId" />
				<asp:BoundField HeaderText="memo" DataField="memo"/>
		</Columns>
		<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
		<PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
		<SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
		<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
	</asp:GridView>
</asp:Content>