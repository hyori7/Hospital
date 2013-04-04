<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="aspx_admin_user_list" MasterPageFile="~/master/subMain.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

	<script type="text/javascript">
		function view(userId) {
			document.location.href = "/hospital/aspx/admin/user/update.aspx?userId=" + userId;
		}

		function search() {
			var field = document.getElementById("searchField").value;
			var value = document.getElementById("searchValue").value;
			document.location.href = "/hospital/aspx/admin/user/list.aspx?searchField=" + field + "&searchValue="+ value;
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

	USER LIST 
	<select name="searchField" id="searchField"  onfocus="changeColour(this, '#ccc')" class="inputStyle" > 
		<option value="userId" <%if ("userId".Equals(Param.getString("userId"))) Response.Write("selected='selected'");%>>
            USER ID</option>
		<option value="firstName" <%if ("firstName".Equals(Param.getString("firstName"))) Response.Write("selected='selected'");%>>
            First Name</option>
		<option value="surName" <%if ("surName".Equals(Param.getString("surName"))) Response.Write("selected='selected'");%>>
            Surname</option>
	</select> 
	<input id="searchValue" name="searchValue" value="<%=Param.get("searchValue")%>" style="background-color: #FFFFFF; color: #414141; 
font-family: Arial, Helvetica, sans-serif ; font-size: 11px ; border:1px solid #ccc ; padding: 7px ; overflow: hidden ; " onfocus="changeColour(this, '#DBDADB')" /> 
	<input type="button" value="SEARCH" onclick="search()" style="background-color: #FFFFFF; color: #414141; 
font-family: Arial, Helvetica, sans-serif ; font-size: 11px ; border:1px solid #ccc ; padding: 7px ; overflow: hidden ;cursor:pointer;" " onfocus="changeColour(this, '#DBDADB')"/>
	
	<br />
	<asp:GridView ID="userList" runat="server" CellPadding="4" ForeColor="Black" 
		GridLines="Horizontal" AutoGenerateColumns="False" Width="416px" BackColor="White" 
        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px">
		<Columns>
				<asp:BoundField HeaderText="userId" DataField="userID" HtmlEncode="true"/>
				<asp:TemplateField HeaderText="name">
					<ItemTemplate>
						<%#"<a href=\"javascript:view('" + Eval("userID") + "');\">" + Eval("UserFirstName") + ", " + Eval("UserSurName") + "</a>"%>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:BoundField HeaderText="Job" DataField="Job"/>
				<asp:BoundField HeaderText="Email" DataField="Email"/>
			</Columns>
		<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
		<PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
		<SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
		<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
	</asp:GridView>
	
</asp:Content>
