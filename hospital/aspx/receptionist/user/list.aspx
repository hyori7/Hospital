<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="aspx_admin_user_list" MasterPageFile="~/master/subMain.master" %>
<asp:Content ContentPlaceHolderID="head" runat="server">
	<script type="text/javascript">
		function view(userId) {
			document.location.href = "/hospital/aspx/receptionist/user/update.aspx?userId=" + userId;
		}

		function search() {
			var field = document.getElementById("searchField").value;
			var value = document.getElementById("searchValue").value;
			document.location.href = "/hospital/aspx/receptionist/user/list.aspx?searchField=" + field + "&searchValue="+ value;
		}
	</script>
</asp:Content>
<asp:Content ContentPlaceHolderID="cnt" runat="server">
	USER LIST 
	<select name="searchField" id="searchField">
		<option value="userId" <%if ("userId".Equals(Param.getString("userId"))) Response.Write("selected='selected'");%>>USER ID</option>
		<option value="firstName" <%if ("firstName".Equals(Param.getString("firstName"))) Response.Write("selected='selected'");%>>First Name</option>
		<option value="surName" <%if ("surName".Equals(Param.getString("surName"))) Response.Write("selected='selected'");%>>Surname</option>
	</select> 
	<input id="searchValue" name="searchValue" value="<%=Param.get("searchValue")%>" /> 
	<input type="button" value="SEARCH" onclick="search()" />
	
	<br />
	<asp:GridView ID="userList" runat="server" CellPadding="4" ForeColor="#333333" 
		GridLines="None" AutoGenerateColumns="false" Width="416px">
		<Columns>
				<asp:BoundField HeaderText="userId" DataField="userID" HtmlEncode="true"/>
				<asp:TemplateField HeaderText="name">
					<ItemTemplate>
						<%#"<a href=\"javascript:view('" + Eval("userID") + "');\">" + Eval("UserFirstName") + ", " + Eval("UserSurName") + "</a>"%>
					</ItemTemplate>
				</asp:TemplateField>
				<asp:BoundField HeaderText="Email" DataField="Email"/>
			</Columns>
		<RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
		<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
		<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
		<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
		<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
		<EditRowStyle BackColor="#999999" />
		<AlternatingRowStyle BackColor="White" ForeColor="#284775" />
	</asp:GridView>
</asp:Content>
