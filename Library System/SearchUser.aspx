<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchUser.aspx.cs" Inherits="SearchUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        用户名：<asp:TextBox ID="tbSearch" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="搜索" />
        <asp:Repeater ID="rptUser" runat="server"  OnItemCommand="rptUser_ItemCommand" >
            <HeaderTemplate> 
                <table>
                    <tr>
                        <th>用户名</th>
                        <th>姓名</th>
                        <th>性别</th>
                        <th>电子邮箱</th>
                        <th>账户状态</th>
                        <th>账户类型</th>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td><%# Eval("username")%></td>
                    <td><%# Eval("name")%></td>
                    <td><%# Eval("sex")%></td>
                    <td><%# Eval("email")%></td>
                    <td><%# Eval("status")%></td>
                    <td><%# Eval("classification")%></td>
                    <td><asp:LinkButton ID="lbtDelete" runat="server" Text="删除" CommandName="Delete" CommandArgument='<%#Eval("id") %>' ></asp:LinkButton></td>
                    <td><asp:LinkButton ID="lbtClose" runat="server" Text="查封" CommandName="Close" CommandArgument='<%#Eval("username") %>' ></asp:LinkButton></td>
                    <td><asp:LinkButton ID="lbtOpen" runat="server" Text="解封" CommandName="Open" CommandArgument='<%#Eval("username") %>' ></asp:LinkButton></td>
                    <td><asp:LinkButton ID="lbtEditor" runat="server" Text="修改密码" PostBackUrl='<%#"UserEditor.aspx?id="+Eval("id") %>'></asp:LinkButton></td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
               </table>

            </FooterTemplate>
     

        </asp:Repeater>

        <asp:Button ID="btnUp" runat="server" Text="上一页" OnClick="btnUp_Click" />
        <asp:Button ID="btnDrow" runat="server" Text="下一页"  OnClick="btnDrow_Click"/>
        <asp:Button ID="btnFirst" runat="server" Text="首页" OnClick="btnFirst_Click" />
        <asp:Button ID="btnLast" runat="server" Text="尾页"  OnClick="btnLast_Click"/>
        页次：<asp:Label ID="lbNow" runat="server" Text="1"></asp:Label>
        /<asp:Label ID="lbTotal" runat="server" Text="1"></asp:Label>

        转<asp:TextBox ID="txtJump" Text="1" runat="server" Width="25px"></asp:TextBox>
        <asp:Button ID="btnJump" runat="server" Text="Go"  OnClick="btnJump_Click"/>
    
        <br />
        <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="添加管理员" />
        <asp:Button ID="btnLogoff" runat="server" OnClick="btnLogoff_Click" Text="注销" />
        <asp:Button ID="btnReturn" runat="server" OnClick="btnReturn_Click" Text="返回" />
    
    </div>
    </form>
</body>
</html>
