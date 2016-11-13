<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminAdd.aspx.cs" Inherits="AdminAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        用户名：<asp:TextBox ID="tbUsername" runat="server"></asp:TextBox>
        <br />
        姓名：<asp:TextBox ID="tbName" runat="server"></asp:TextBox>
        <br />
        性别：<asp:RadioButton ID="rbMan" runat="server" GroupName="admin" Text="男" />
        <asp:RadioButton ID="rbWoman" runat="server" GroupName="admin" Text="女" />
        <br />
        电子邮箱：<asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
        <br />
        密码：<asp:TextBox ID="tbPass" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="添加" OnClick="btnAdd_Click" />
        <asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click" />
    
    </div>
    </form>
</body>
</html>
