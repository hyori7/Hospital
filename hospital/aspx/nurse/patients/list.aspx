<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="aspx_nurse_patients_list" MasterPageFile="~/master/subMain.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript">
		function view(pId, created) {
			if (created == 0) {
				document.location.href = "/hospital/aspx/nurse/observation/create.aspx?pId=" + pId;
			} else {
				document.location.href = "/hospital/aspx/nurse/observation/view.aspx?pId=" + pId;
			}
		}
		 function viewRoom(RoomID) {
			document.location.href = "/hospital/aspx/nurse/patients/roompatient.aspx?RoomID=" + RoomID;
		}
	    
	</script>
</asp:Content>

<asp:Content ID="nurseContent" ContentPlaceHolderID="cnt" runat="server">
	<div>
        
		Patient List</div>
	<asp:GridView ID="Patientlist" runat="server" CellPadding="4" ForeColor="Black" 
		GridLines="Horizontal" Font-Names="Arial,Helvetica,sans-serif"
		Height="170px" Width="588px" AutoGenerateColumns="False" BackColor="White" 
		BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
		<Columns>
				<asp:BoundField HeaderText="PatientId" DataField="PatientID" HtmlEncode="true"/>
				<asp:BoundField HeaderText="Room" DataField="Room" HtmlEncode="true"/>
				<asp:TemplateField HeaderText="name">
					<ItemTemplate>
						<%#"<a href=\"javascript:view('" + Eval("PatientID") + "'," + Eval("Observation") + ");\">" + Eval("UserFirstName") + ", " + Eval("UserSurName") + "</a>"%>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:BoundField HeaderText="Patient's Phone" DataField="PhoneNumber"/>
				<asp:BoundField HeaderText="StartDate" DataField="StartDate" HtmlEncode="true"/>
				<asp:BoundField HeaderText="EndDate" DataField="EndDate" HtmlEncode="true"/>
				<asp:BoundField HeaderText="Observation" DataField="Observation"/>
		</Columns>
		<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
		<PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
		<SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
		<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
	</asp:GridView>
	<div>
	RoomList<br />
		<asp:GridView ID="RoomList" runat="server" CellPadding="4" ForeColor="Black" 
		GridLines="Horizontal" Font-Names="Arial,Helvetica,sans-serif"
		Height="170px" Width="588px" AutoGenerateColumns="False" BackColor="White" 
			BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
		<Columns>
				<asp:TemplateField HeaderText="RoomID">
					<ItemTemplate>
						<%#"<a href=\"javascript:viewRoom('" + Eval("RoomID") + "');\">" + Eval("RoomID") + "</a>"%>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:BoundField HeaderText="Patients" DataField="P_COUNT" />
				<asp:BoundField HeaderText="DeptID" DataField="DeptID" />
				<asp:BoundField HeaderText="LevelNum" DataField="LevelNumber"/>
		</Columns>
		<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
		<PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
		<SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
		<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
	</asp:GridView>
	</div>
</asp:Content>