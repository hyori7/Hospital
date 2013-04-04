<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="aspx_doctor_patients_list" MasterPageFile="~/master/subMain.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript">
		function view(pId) 
		{
			document.location.href = "/hospital/aspx/doctor/history/list.aspx?pId=" + pId;
		}

		function done(hId) {
			var check = confirm("Have you done every test for this Patient?");
			if (!check) return;
			document.location.href = "/hospital/aspx/doctor/patients/list.aspx?hId=" + hId;
		}
	    
	</script>
	
	<style type="text/css">
		.inputStyle 
		{
		    background-color: #FFFFFF; color: #414141; 
            font-family: Arial, Helvetica, sans-serif ; font-size: 11px ; border:1px solid #ccc ; padding: 7px ; overflow: hidden ; 
		}
		#searchField
		{
			background-color: #FFFFFF; color: #414141; 
            font-family: Arial, Helvetica, sans-serif ; font-size: 11px ; border:1px solid #ccc ; padding: 7px ; overflow: hidden ;
		}
	</style>
	<link rel="stylesheet" type="text/css" href="../../../css/epoch_styles.css" />
	
	<script type="text/javascript" src="../../../script/epoch_classes.js"></script>
	<script type="text/javascript">
		window.onload = function() {
			var popupcalendar = new Epoch('cal', 'popup', document.getElementById('ctl00_cnt_date'), false);
		}
	</script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cnt" runat="server">
	<div>Patient List</div><br />
	<select name="searchField" id="searchField" onfocus="changeColour(this, '#DBDADB')">
		<option value="" <%if ("".Equals(Param.getString("searchField"))) Response.Write("selected='selected'");%>>NONE</option>
		<option value="UserID" <%if ("UserID".Equals(Param.getString("searchField"))) Response.Write("selected='selected'");%>>USER ID</option>
		<option value="firstName" <%if ("firstName".Equals(Param.getString("searchField"))) Response.Write("selected='selected'");%>>First Name</option>
		<option value="surName" <%if ("surName".Equals(Param.getString("searchField"))) Response.Write("selected='selected'");%>>Surname</option>
		<option value="memo" <%if ("memo".Equals(Param.getString("searchField"))) Response.Write("selected='selected'");%>>Surname</option>
	</select> 
	<input id="searchValue" name="searchValue" value="<%=Param.get("searchValue")%>" style="background-color: #FFFFFF; color: #414141; 
font-family: Arial, Helvetica, sans-serif ; font-size: 11px ; border:1px solid #ccc ; padding: 7px ; overflow: hidden ; " onfocus="changeColour(this, '#DBDADB')" />
	 DATE : <asp:TextBox ID="date" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')"></asp:TextBox> 
	<asp:Button ID="search" runat="server" Text="SEARCH" OnClick="onSearch" CssClass="inputStyle" style="cursor:pointer;" onfocus="changeColour(this, '#ccc')"/>
	
	<br />
		
	<asp:GridView ID="Patientlist" runat="server" CellPadding="4" ForeColor="Black" 
		GridLines="Horizontal"
		Height="170px" Width="588px" AutoGenerateColumns="False" BackColor="White" 
        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
		<Columns>
				<asp:BoundField HeaderText="date" DataField="date" HeaderStyle-Width="140px"/>
				<asp:BoundField HeaderText="PatientId" DataField="UserID" HtmlEncode="true" />
				<asp:TemplateField HeaderText="Patient's Name">
					<ItemTemplate>
						<%#"<a href=\"javascript:view('" + Eval("UserID") + "');\">" + Eval("UserFirstName") + ", " + Eval("UserSurName") + "</a>"%>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:BoundField HeaderText="Patient's Phone" DataField="PhoneNumber"/>
				<asp:TemplateField HeaderText="DONE">
					<ItemTemplate>
						<%#"<a href = \"javascript:done('" + Eval("historyId") + "');\">finish</a>"%>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:BoundField HeaderText="memo" DataField="memo"/>
		</Columns>
		<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
		<PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
		<SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
		<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
	</asp:GridView>
</asp:Content>