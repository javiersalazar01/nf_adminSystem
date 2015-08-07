<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="nf_adminSystem.Login" %>

<!DOCTYPE HTML>
<html>
<head>
<title>Member Login Form Flat Responsive Widget Template | Home :: w3layouts</title>
<!-- Custom Theme files -->
<link href="assets/css/login.css" rel="stylesheet" type="text/css" media="all"/>
<!-- Custom Theme files -->
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" /> 
<meta name="keywords" content="Member Login Form Responsive, Login form web template, Sign up Web Templates, Flat Web Templates, Login signup Responsive web template, Smartphone Compatible web template, free webdesigns for Nokia, Samsung, LG, SonyErricsson, Motorola web design" />
<!--Google Fonts-->
<link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800' rel='stylesheet' type='text/css'>
<!--Google Fonts-->
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="login">
	            <div class="login-box2 box effect6">
		            <div class="login-top top2">
				            <h2>Inicio de Sesion</h2>
			            <div class="user">
				            <img src="assets/images/user.png" alt="">
			            </div>
		               <div class="clear"> </div>
		            </div>
		            <div class="login-bottom bott-green">
                        <asp:TextBox ID="userName" runat="server" value="Nombre de Usuarios" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Nombre de Usuarios';}" ></asp:TextBox>
                        <asp:TextBox ID="password" runat="server" value="Contraseña" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Contraseña';}"></asp:TextBox>
			            <%--<input type="text" value="User Name" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'User Name';}"/>--%>
			            <%--<input type="password" value="Password" onfocus="this.value = '';" onblur="if (this.value == '') {this.value = 'Password';}"/>--%>
			            <div class="greenbox-send">
				            <%--<div class="now"> <input type="submit" value="Iniciar"> </div>--%>
                            <asp:Button ID="Button1" runat="server" Text="Iniciar" CssClass="now" OnClick="Button1_Click"/>
			            </div>
		            </div>
	            </div>
            </div>
        </div>
    </form>
</body>
</html>
        <%--<asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" PasswordLabelText="Contraseña:" RememberMeText="Recordarme La Proxima vez" UserNameLabelText="Usuario:"></asp:Login>--%>
