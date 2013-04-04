<%@ Page Language="C#" AutoEventWireup="true" CodeFile="create.aspx.cs" Inherits="aspx_xray_xray_create" MasterPageFile="~/master/subMain.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link rel="stylesheet" type="text/css" href="../../../css/epoch_styles.css" />
	
	<script type="text/javascript" src="../../../script/epoch_classes.js"></script>
	<script type="text/javascript">
		window.onload = function() {
			var form = document.getElementsByTagName("FORM")[0];
		}
		function del(rId) {
			var url = document.location.href;
			if (url.indexOf("rId=") > -1) {
				var urlArray = url.split("&");
				urlArray[urlArray.length - 1] = "&rId=" + rId;
				url = urlArray.join("&");
			} else {
				url = url + "&rId=" + rId;
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
<asp:Content ID="Content2" ContentPlaceHolderID="cnt" runat="server">
	Add MRI file<br />
	<asp:HiddenField ID="pId" runat="server" />
	<asp:HiddenField ID="testId" runat="server" />
	<asp:HiddenField ID="historyId" runat="server" />
	MRI NAME : <asp:TextBox ID="name" runat="server" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" ></asp:TextBox>
	MRI FILE : <input type="file" id="MRI" runat="server" Class="inputStyle" onfocus="changeColour(this, '#ccc')" style="cursor:pointer;"/>
	<br />
	<asp:Button ID="upload" runat="server" Text="UPLOAD" OnClick="uploadMRI" CssClass="inputStyle"  onfocus="changeColour(this, '#ccc')" style="cursor:pointer;"/>
	<asp:Button ID="BACK" runat="server" Text="GO BACK" OnClick="goBack" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" style="cursor:pointer;"/>
	<asp:Button ID="finish" runat="server" Text="complete" OnClick="onComplete" CssClass="inputStyle" onfocus="changeColour(this, '#ccc')" style="cursor:pointer;"/>
	<asp:GridView ID="mriView" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="MRIID" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" 
        BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
		<Columns>
			<asp:BoundField HeaderText="Name" DataField="name"/>
			<asp:ImageField HeaderText="image" DataImageUrlField="path"></asp:ImageField>
			<asp:TemplateField HeaderText="DELETE">
				<ItemTemplate>
					<%#"<a href=\"javascript:del('" + Eval("MRIID") + "');\">delete</a>"%>
				</ItemTemplate>
			</asp:TemplateField>
		</Columns>
	    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
	</asp:GridView>
</asp:Content>
