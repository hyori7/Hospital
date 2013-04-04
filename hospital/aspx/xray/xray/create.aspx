<%@ Page Language="C#" AutoEventWireup="true" CodeFile="create.aspx.cs" Inherits="aspx_xray_xray_create" MasterPageFile="~/master/subMain.master" %>
<asp:Content  ContentPlaceHolderID="head" runat="server">
	<link rel="stylesheet" type="text/css" href="../../../css/epoch_styles.css" />
	
	<script type="text/javascript" src="../../../script/epoch_classes.js"></script>
	<script type="text/javascript">
		window.onload = function() {
			var form = document.getElementsByTagName("FORM")[0];
		}
		function del(rId) {
			var url = document.location.href;
			if(url.indexOf("rId=") > -1 ) {
				var urlArray = url.split("&");
				urlArray[urlArray.length -1] = "&rId=" + rId;
				url = urlArray.join("&");
			} else {
				url = url +  "&rId=" + rId;
			}
			document.location.href = url;
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
<asp:Content  ContentPlaceHolderID="cnt" runat="server">
	Add X-ray file
	<asp:HiddenField ID="pId" runat="server" />
	<asp:HiddenField ID="testId" runat="server" />
	<asp:HiddenField ID="historyId" runat="server" /><br />
	XRAY NAME : <asp:TextBox ID="name" runat="server" onfocus="changeColour(this, '#ccc')" cssclass="inputStyle" ></asp:TextBox>
	XRAY FILE : <input type="file" id="xRay" runat="server"  onfocus="changeColour(this, '#ccc')" class="inputStyle" 
cssclass="inputStyle" style="cursor:pointer;" />
	<br />
	<asp:Button ID="upload" runat="server" Text="UPLOAD" OnClick="uploadXray" cssclass="inputStyle" style="cursor:pointer;"  onfocus="changeColour(this, '#ccc')"/>
	<asp:Button ID="BACK" runat="server" Text="GO BACK" OnClick="goBack" cssclass="inputStyle" style="cursor:pointer;" onfocus="changeColour(this, '#ccc')"/>
	<asp:Button ID="finish" runat="server" Text="complete" OnClick="onComplete" cssclass="inputStyle" style="cursor:pointer;" onfocus="changeColour(this, '#ccc')"/>
	<asp:GridView ID="xrayView" runat="server" AutoGenerateColumns="False" 
		DataKeyNames="XRayID" BackColor="White" BorderColor="#CCCCCC" 
		BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" 
		GridLines="Horizontal">
		<Columns>
			<asp:BoundField HeaderText="Name" DataField="name"/>
			<asp:ImageField HeaderText="image" DataImageUrlField="path"></asp:ImageField>
			<asp:TemplateField HeaderText="DELETE">
				<ItemTemplate>
					<%#"<a href=\"javascript:del('" + Eval("XRayID") + "');\">delete</a>"%>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
		<FooterStyle BackColor="#CCCC99" ForeColor="Black" />
		<PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
		<SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
		<HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
	</asp:GridView>
</asp:Content>
