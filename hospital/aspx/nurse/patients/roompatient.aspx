<%@ Page Language="C#" AutoEventWireup="true" CodeFile="roompatient.aspx.cs" Inherits="aspx_nurse_patients_roompatient" MasterPageFile="~/master/subMain.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript">
		function view(pId, created) {
			if (created == 0) {
				document.location.href = "/hospital/aspx/nurse/observation/create.aspx?pId=" + pId;
			} else {
				document.location.href = "/hospital/aspx/nurse/observation/view.aspx?pId=" + pId;
			}
		}
	</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cnt" runat="server">
	
	
	<div>
        
		Patient's Room</div>
	<asp:TextBox ID="NurseID" runat="server" style="display:none;"></asp:TextBox>
	<asp:TextBox ID="RoomID" runat="server" style="display:none;"></asp:TextBox>
	<asp:Label ID="roomLabel" runat="server" Text="Label"></asp:Label>
	<asp:GridView ID="patientroom" runat="server" CellPadding="4" ForeColor="Black" 
		GridLines="Horizontal" Font-Names="Arial,Helvetica,sans-serif"
		Height="170px" Width="588px" AutoGenerateColumns="False" BackColor="White" 
		BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
		<Columns>
				<asp:BoundField HeaderText="PatientId" DataField="UserID" HtmlEncode="true"/>
				<asp:TemplateField HeaderText="name">
					<ItemTemplate>
						<%#"<a href=\"javascript:view('" + Eval("UserID") + "'," + Eval("Observation") + ");\">" + Eval("name") + "</a>"%>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:BoundField HeaderText="Patient's Phone" DataField="PhoneNumber"/>
				<asp:BoundField HeaderText="StartDate" DataField="StartDate"/>
				<asp:BoundField HeaderText="EndDate" DataField="EndDate"/>
				<asp:BoundField HeaderText="Observation" DataField="Observation"/>
		</Columns>
		<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
		<PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
		<SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
		<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
	</asp:GridView>
</asp:Content>