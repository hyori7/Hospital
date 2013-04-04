<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="aspx_xray_patient_list" MasterPageFile="~/master/subMain.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript">
		function view(pId, testId, historyId) 
		{
			document.location.href = "/hospital/aspx/xray/xray/create.aspx?pId=" + pId + "&testId="+ testId + "&historyId=" + historyId;
		}

		function done(hId) {
			var check = confirm("Have you done every test for this Patient?");
			if (!check) return;
			document.location.href = "/hospital/aspx/xray/patients/list.aspx?hId=" + hId;
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
			width: 174px;
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
	<select name="searchField" id="searchField" onfocus="changeColour(this, '#ccc')" class="inputStyle" >
		<option value="" <%if ("".Equals(Param.getString("searchField"))) Response.Write("selected='selected'");%>>NONE</option>
		<option value="UserID" <%if ("UserID".Equals(Param.getString("searchField"))) Response.Write("selected='selected'");%>>USER ID</option>
		<option value="firstName" <%if ("firstName".Equals(Param.getString("searchField"))) Response.Write("selected='selected'");%>>First Name</option>
		<option value="surName" <%if ("surName".Equals(Param.getString("searchField"))) Response.Write("selected='selected'");%>>Surname</option>
		<option value="memo" <%if ("memo".Equals(Param.getString("searchField"))) Response.Write("selected='selected'");%>>Surname</option>
	</select> 
	<input id="searchValue" name="searchValue" value="<%=Param.get("searchValue")%>" onfocus="changeColour(this, '#ccc')" class="inputStyle"  />
	 DATE : <asp:TextBox ID="date" runat="server"  onfocus="changeColour(this, '#ccc')" cssclass="inputStyle" ></asp:TextBox> 
	<asp:Button ID="search" runat="server" Text="SEARCH" OnClick="onSearch" cssclass="inputStyle" style="cursor:pointer;" onfocus="changeColour(this, '#ccc')"/>
	
	<br />
		<div>Patient List</div>
	<asp:GridView ID="Patientlist" runat="server" CellPadding="4" ForeColor="Black" 
		GridLines="Horizontal"
		Height="170px" Width="588px" AutoGenerateColumns="False" BackColor="White" 
		BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
		<Columns>
				<asp:BoundField HeaderText="date" DataField="date"/>
				<asp:BoundField HeaderText="PatientId" DataField="UserID" HtmlEncode="true"/>
				<asp:TemplateField HeaderText="Patient's Name">
					<ItemTemplate>
						<%#"<a href=\"javascript:view('" + Eval("UserID") + "', '"+Eval("cntId")+"', '"+Eval("historyId")+"');\">" + Eval("UserFirstName") + ", " + Eval("UserSurName") + "</a>"%>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:BoundField HeaderText="Patient's Phone" DataField="PhoneNumber"/>
				<asp:TemplateField HeaderText="DONE">
					<ItemTemplate>
						<%#"<a href = \"javascript:done('" + Eval("historyId") + "');\">complete</a>"%>
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