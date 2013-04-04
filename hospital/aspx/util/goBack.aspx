<%@ Page Language="C#" AutoEventWireup="true" CodeFile="goBack.aspx.cs" Inherits="aspx_util_goback" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>MESSAGE</title>
</head>
<body>
	<script type="text/javascript">
		alert("<%=Request.Params.GetValues(0)[0]%>");
		history.go(-1);
	</script>
</body>
</html>
