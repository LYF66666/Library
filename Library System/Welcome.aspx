<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Welcome.aspx.cs" Inherits="Welcome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        欢迎页面<br />
        欢迎您：<asp:Label ID="lblUser" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Button ID="btnLibrary" runat="server" OnClick="btnLibrary_Click" Text="我的图书馆" />
        <asp:Button ID="btnID" runat="server" OnClick="btnID_Click" Text="管理个人信息" />
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="书目检索" />
        <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="注销" />
    
    </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
