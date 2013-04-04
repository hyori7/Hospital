<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="aspx_Login"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	
	<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-2" />
	<title>GROUP 44</title>
	<link id="Link1" type="text/css" href="~/css/style.css" rel="Stylesheet" runat="server"/>
	
	<script type="text/javascript">
		function changeLoginBtn(id, type) {
			if (type) {
				document.getElementById(id).src = document.getElementById(id).src.replace("out", "over");
			} else {
				document.getElementById(id).src = document.getElementById(id).src.replace("over", "out");
			}
		}

		function changeColour(obj, colour) {

			var textboxes = document.getElementsByTagName("TEXTAREA");
			for (var i = 0; i < textboxes.length; i++) {
				textboxes[i].style.backgroundColor = "#FFF";
			}
			var inputs = document.getElementsByTagName("INPUT");
			for (var i = 0; i < inputs.length; i++) {
				inputs[i].style.backgroundColor = "#FFF";
			}
			var selects = document.getElementsByTagName("SELECT");
			for (var i = 0; i < selects.length; i++) {
				selects[i].style.backgroundColor = "#FFF";
			}
			obj.style.backgroundColor = colour;
		}
	</script>
</head>
 
<body>
	
    
 
    <form id="form1" runat="server">
	
    
 
<div id="shadow-container">
		<div class="shadow1">
			<div class="shadow2">
				<div class="shadow3">
					<div class="container">
                    <div class="break3"></div><br />
      <div><asp:Image ID="LoginLogo" ImageUrl="~/images/logo.png" runat="server" alt="" width="76" height="69" /></div>
      <div class="break3"></div><br />
						
<p>Username</p>
<asp:TextBox ID="id" runat="server" style="background-color: #FFFFFF; color: #414141; 
font-family: Arial, Helvetica, sans-serif ; font-size: 11px ; border:1px solid #ccc ; width: 200px ; padding: 7px ; overflow: hidden ; " onfocus="changeColour(this, '#DBDADB')"></asp:TextBox>
<br /><br />                   
<p>Password</p>
<asp:TextBox ID="pwd" textmode="Password" runat="server" style="background-color: #FFFFFF; color: #414141; 
font-family: Arial, Helvetica, sans-serif ; font-size: 11px ; border:1px solid #ccc ; width: 200px ; padding: 7px ; overflow: hidden ; " onfocus="changeColour(this, '#DBDADB')"></asp:TextBox>
<br />
<br />
                   
                            <asp:Button ID="Button1" runat="server" OnClick="onLogin" BackColor="White" BorderColor="White" 
                                BorderStyle="None" BorderWidth="0px" Text="Login"/>
                            
					</div>
				</div>
			</div>
  </div>
</div>
 
 
 
    
</form>
 
 
 
    
</body>
</html>
