<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        注册页面<br />
        用户名：<asp:TextBox ID="tbUsername" runat="server"></asp:TextBox>
        <br />
        姓名：&nbsp; <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
        <br />
        性别：<asp:RadioButton ID="rbMan" runat="server" GroupName="Users" OnCheckedChanged="rbMan_CheckedChanged" Text="男" />
        <asp:RadioButton ID="rbWoman" runat="server" GroupName="Users" OnCheckedChanged="rbWoman_CheckedChanged" Text="女" />
        <br />
        电子邮箱：<asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
        <br />
        密码：&nbsp;  <asp:TextBox ID="tbPass" runat="server" TextMode="Password" Height="23px"></asp:TextBox>
        <br />
        <asp:Button ID="btnRegister" runat="server" Text="注册" OnClick="btnRegister_Click" />
        <asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click" />
    </form>
</body>
</html>
