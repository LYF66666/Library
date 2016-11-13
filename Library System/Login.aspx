<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;登录页面<br />
        用户名： <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br />
        密码：&nbsp; 
         <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" Height="23px"></asp:TextBox>
        <br />
        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="用户登录" />
        <asp:Button ID="btnRegister" runat="server" OnClick="btnRegister_Click" Text="注册" />
    
        <asp:Button ID="btnAdminLogin" runat="server" Text="管理员登录" OnClick="btnAdminLogin_Click" />
    
    </div>
    </form>
</body>
</html>
