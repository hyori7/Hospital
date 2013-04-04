<%@ Page Language="C#" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="aspx_sys_itemReport_list" MasterPageFile="~/master/subMain.master"%>

<asp:Content ContentPlaceHolderID="head" runat="server">
	<link rel="stylesheet" type="text/css" href="../../../css/epoch_styles.css" />
	
	<script type="text/javascript" src="../../../script/epoch_classes.js"></script>
	<script type="text/javascript" src="../../../script/chart.js"></script>
	<script type="text/javascript">

		//<div style="position:relative;width:50%;height:20px;background-color:#009CFF;">


		window.onload = function() {
			var popupcalendar = new Epoch('cal', 'popup', document.getElementById('ctl00_cnt_startDate'), false);
			var popupcalendar2 = new Epoch('cal', 'popup', document.getElementById('ctl00_cnt_endDate'), false);
			try {
				var chart = new Chart();
				chart.fire("ctl00_cnt_itemReportView", 2);
			} catch (e) { }
		}

		function saveHtml() {
			try {
				var html = document.getElementById("printingPlace").innerHTML;
				document.getElementById("ctl00_cnt_html").value = encodeURI(html);
			} catch (e) { }

			return true;
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
<asp:Content ContentPlaceHolderID="cnt" runat="server">
Start date : <asp:TextBox ID="startDate" runat="server" onfocus="changeColour(this, '#ccc')" cssclass="inputStyle" ></asp:TextBox>	
end date : <asp:TextBox ID="endDate" runat="server" onfocus="changeColour(this, '#ccc')" cssclass="inputStyle" ></asp:TextBox>	
<asp:Button ID="search" runat="server" Text="search" OnClick="onSearch" cssclass="inputStyle" style="cursor:pointer;" onfocus="changeColour(this, '#ccc')"/>
<asp:Button ID="print" runat="server" Text="print" OnClick="onPrint" OnClientClick="saveHtml()" Visible="false" cssclass="inputStyle" style="cursor:pointer;" onfocus="changeColour(this, '#ccc')"/>
<asp:HiddenField ID="html" runat="server" />
<div id="printingPlace">
	<br />
	<asp:Label ID="title" runat="server" Text="Item report"></asp:Label>
	<br /><br />
	<asp:GridView ID="itemReportView" runat="server">
	</asp:GridView>
</div>
</asp:Content>
