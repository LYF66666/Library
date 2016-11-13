<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PassEditor.aspx.cs" Inherits="PassEditor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        原密码：<asp:TextBox ID="tbPass" runat="server"></asp:TextBox>
        <br />
        新密码：<asp:TextBox ID="tbNewpass" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="提交" />
        <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="返回" />
    
    </div>
    </form>
</body>
</html>
