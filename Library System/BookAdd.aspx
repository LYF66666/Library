<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BookAdd.aspx.cs" Inherits="BookAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        ISBN：<asp:TextBox ID="tbISBN" runat="server"></asp:TextBox>
        <br />
        书名：<asp:TextBox ID="tbBookname" runat="server"></asp:TextBox>
        <br />
        类型：<asp:TextBox ID="tbType" runat="server"></asp:TextBox>
        <br />
        作者：<asp:TextBox ID="tbAuthor" runat="server"></asp:TextBox>
        <br />
        总库存量：<asp:TextBox ID="tbTotal" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="提交" />
        <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="返回" />
    
    </div>
    </form>
</body>
</html>
