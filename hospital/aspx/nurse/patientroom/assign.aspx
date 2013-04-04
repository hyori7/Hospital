<%@ Page Language="C#" AutoEventWireup="true" CodeFile="assign.aspx.cs" Inherits="aspx_nurse_patientroom_assign" MasterPageFile="~/master/subMain.master"%>
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
		function delPatient(pId, RoomID) {
			if (!confirm(pId + ": this patient is going to move out today?")) {
				return;
			}
			document.location.href = "/hospital/aspx/nurse/patientroom/assign.aspx?RoomID=" + RoomID+"&pId=" + pId;
			//return pId;
		}
	    
	</script>
	<script type="text/javascript">
		window.onload = function () {
			var popupcalendar = new Epoch('cal', 'popup', document.getElementById('ctl00_cnt_StartDate'), false);
			var popupcalendar2 = new Epoch('cal', 'popup', document.getElementById('ctl00_cnt_EndDate'), false);
			
		}
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cnt" runat="server">
<div id="page-wrap">

	 <asp:Label ID="roomLabel" runat="server" Text="Label"></asp:Label><br />
	 <asp:TextBox ID="Room" runat="server" style="display:none;"></asp:TextBox>
	  <h1>Room Assignment</h1>
	  Bed Number<br />
	<asp:TextBox ID="BedNumber" runat="server" CssClass="regText" onfocus="changeColour(this, '#ccc')"></asp:TextBox><br />
	 Level Number<br />
	 <asp:TextBox ID="Level" runat="server" CssClass="regText" onfocus="changeColour(this, '#ccc')"></asp:TextBox><br />
	 patient<br />
	<asp:DropDownList ID="historyId" runat="server" DataTextField="patientId" DataValueField="historyId" CssClass="regText" onfocus="changeColour(this, '#ccc')"></asp:DropDownList><br />
	 Department Name<br />
	<asp:TextBox ID="DeptName" runat="server" CssClass="regText" onfocus="changeColour(this, '#ccc')"></asp:TextBox><br />
	 Start Date<br />
	 <asp:TextBox ID="StartDate" runat="server" CssClass="regText" onfocus="changeColour(this, '#ccc')"></asp:TextBox><br />
	 End Date<br />
	 <asp:TextBox ID="EndDate" runat="server" CssClass="regText" onfocus="changeColour(this, '#ccc')"></asp:TextBox><br />
	<asp:Button ID="Submit" runat="server" Text="Submit" onclick="submit" style="cursor:pointer;" CssClass="regText" onfocus="changeColour(this, '#ccc')"/>
	<asp:Button ID="Cancel" runat="server" Text="Cancel" onclick="cancel" style="cursor:pointer;" CssClass="regText" onfocus="changeColour(this, '#ccc')"/>
	<br />
	Patient List<br />

	<br />
	<asp:GridView ID="PatientList" runat="server" CellPadding="4" ForeColor="Black" 
		GridLines="Horizontal" Font-Names="Arial,Helvetica,sans-serif"
		Height="170px" Width="588px" AutoGenerateColumns="False" BackColor="White" 
		 BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
		<Columns>
				<asp:BoundField HeaderText="PatientId" DataField="UserID" HtmlEncode="true"/>
				<asp:TemplateField HeaderText="name">
					<ItemTemplate>
						<%#"<a href=\"javascript:delPatient('" + Eval("UserID") + "', '" + Eval("Room") + "');\">" + Eval("name") + "</a>"%>
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
		
</div>
    
    
   
</asp:Content>


