<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>集团KPI登录页面</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id ="box">
        
        <div id="header">  
        </div>
        <div id="center">
            <div id="left">
            </div>
            <div id ="right">
            <div id="lmain">
            <table>
                <tbody>
                    <tr>
                        <td>
                            <asp:Label runat="server">账号：</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" Width="150px" Height="20px" ID="txtEmpID"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server">密码：</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" Width="150px" Height="20px" ID="txtPwd" TextMode="Password" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" Width="35px" Height="25"></asp:Label>
                        </td>
                        <td>
                            <asp:Button runat="server" Text="登  录" Width="153px" Height="25px" ID="Button1" OnClick="btnLogin_Click"></asp:Button>
                        </td>
                    </tr>
                </tbody>
            </table>              
            <table id="changepwd">
                <tbody>
                    <tr>
                        <td>
                            <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="true" ForeColor="#D4780B" NavigateUrl="./ChangePwd.aspx">修改密码</asp:HyperLink>
                        </td>
                    </tr>
                </tbody>
            </table>
            </div>
            </div>
        </div>
        <div id="footer">
            <asp:Label runat="server" ID="message" >操作提示：</asp:Label>
            <asp:Label runat="server" ID="lblMsg" Text="賬號/密码可輸入工號（初始密碼12345）或者域賬號（密码）"></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
