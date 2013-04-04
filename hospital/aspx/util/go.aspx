<%@ Page Language="C#" AutoEventWireup="true" CodeFile="go.aspx.cs" Inherits="aspx_util_msg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>MESSAGE</title>
</head>
<body>
	<script type="text/javascript">
		alert("<%=Request.Params.GetValues(0)[0]%>");
		//alert("<%=Request.Params.GetValues(1)[0]%>");
		document.location.href = "<%=Request.Params.GetValues(1)[0]%>";
		document.URL= "<%=Request.Params.GetValues(1)[0]%>";
		
	</script>
</body>
</html>
