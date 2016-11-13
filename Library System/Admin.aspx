<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        管理员页面<br />
        <asp:Button ID="btnUser" runat="server" Text="管理用户信息" OnClick="btnUser_Click" />
        <asp:Button ID="btnBook" runat="server" Text="管理图书信息" OnClick="btnBook_Click" />
    
        <asp:Button ID="btnLogout" runat="server" Text="注销" OnClick="btnLogout_Click" style="height: 27px" />
    
    </div>
    </form>
</body>
</html>
