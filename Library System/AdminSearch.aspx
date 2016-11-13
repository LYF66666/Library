<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminSearch.aspx.cs" Inherits="AdminSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="tbSearch" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" style="height: 27px" Text="搜索" />
        <br />
        <asp:RadioButton ID="rbBookname" runat="server" Checked="True" GroupName="search" OnCheckedChanged="rbBookname_CheckedChanged" Text="书名" />
        <asp:RadioButton ID="rbAuthor" runat="server" GroupName="search" OnCheckedChanged="rbAuthor_CheckedChanged" Text="作者" />
        <asp:RadioButton ID="rbType" runat="server" GroupName="search" OnCheckedChanged="rbType_CheckedChanged" Text="类型" />
        <asp:RadioButton ID="rbISBN" runat="server" GroupName="search" OnCheckedChanged="rbISBN_CheckedChanged" Text="ISBN" />

        <asp:Repeater ID="rptBook" runat="server"  OnItemCommand="rptBook_ItemCommand" >
            <HeaderTemplate> 
                <table>
                    <tr>
                        <th>ISBN</th>
                        <th>书名</th>
                        <th>类型</th>
                        <th>作者</th>
                        <th>现存量</th>
                        <th>总库存量</th>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td><%# Eval("ISBN")%></td>
                    <td><%# Eval("bookname")%></td>
                    <td><%# Eval("type")%></td>
                    <td><%# Eval("author")%></td>
                    <td><%# Eval("storage")%></td>
                    <td><%# Eval("totalstorage")%></td>
                    <td><asp:LinkButton ID="lbtDelete" runat="server" Text="删除" CommandName="Delete" CommandArgument='<%#Eval("ISBN") %>' ></asp:LinkButton></td>
                    <td><asp:LinkButton ID="lbtEditor" runat="server" Text="修改" PostBackUrl='<%#"Editor.aspx?ISBN="+Eval("ISBN") %>'></asp:LinkButton></td>
                    <td><asp:LinkButton ID="lbtRecord" runat="server" Text="查看借阅信息" PostBackUrl='<%#"Record.aspx?ISBN="+Eval("ISBN") %>'></asp:LinkButton></asp:LinkButton></td>
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
         <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="添加图书" />
    
        <asp:Button ID="btnLogoff" runat="server" OnClick="btnLogoff_Click" Text="注销" />
    
        <asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click" />
    
    </div>
    </form>
</body>
</html>
