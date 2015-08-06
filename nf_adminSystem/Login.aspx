<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="nf_adminSystem.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form method="post" runat="server">
        <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" PasswordLabelText="Contraseña:" RememberMeText="Recordarme La Proxima vez" UserNameLabelText="Usuario:"></asp:Login>
    </form>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
</body>
</html>
