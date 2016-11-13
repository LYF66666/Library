<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IDinformation.aspx.cs" Inherits="IDinformation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater ID="rptID" runat="server"  OnItemCommand="rptID_ItemCommand" >
            <HeaderTemplate> 
                <table>
                    <tr>
                        <th>用户名</th>
                        <th>姓名</th>
                        <th>性别</th>
                        <th>电子邮箱</th>
                        <th>账户状态</th>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td><%# Eval("username")%></td>
                    <td><%# Eval("name")%></td>
                    <td><%# Eval("sex")%></td>
                    <td><%# Eval("email")%></td>
                    <td><%# Eval("status")%></td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
               </table>

            </FooterTemplate>
     

        </asp:Repeater>
    
        <br />
        <asp:Button ID="btnReset" runat="server" OnClick="btnReset_Click" Text="重置密码" />
        <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="返回" />
    
    </div>
    </form>
</body>
</html>
