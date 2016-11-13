<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MyLibrary.aspx.cs" Inherits="MyLibrary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Repeater ID="rptLibrary" runat="server"  OnItemCommand="rptLibrary_ItemCommand" >
            <HeaderTemplate> 
                <table>
                    <tr>
                        <th>书名</th>
                        <th>ISBN</th>
                        <th>图书编码</th>
                        <th>类型</th>
                        <th>借阅时间</th>
                        <th>应还时间</th>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                <tr>
                    <td><%# Eval("bookname")%></td>
                    <td><%# Eval("ISBN")%></td>
                    <td><%# Eval("bookid")%></td>
                    <td><%# Eval("type")%></td>
                    <td><%# Eval("time")%></td>
                    <td><%# Eval("deadline")%></td>
                    <td><asp:LinkButton ID="lbtReturn" runat="server" Text="归还" CommandName="Return" CommandArgument='<%#Eval("bookid") %>' ></asp:LinkButton></td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
               </table>

            </FooterTemplate>
     

        </asp:Repeater>
    
        <br />
        <asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click" />
    
    </div>
    </form>
</body>
</html>
