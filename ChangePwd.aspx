<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePwd.aspx.cs" Inherits="ChangePwd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
    <title>密碼修改</title>
    <style type="text/css">
        #tabelchanpwd1 {
            width: 402px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="box2">
            <div id="header2">  
            </div>
            <div id="nav2">

            </div>
            <div id="center2">
                <div id="main2">
                    <table id="tabelchanpwd1">
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Label runat="server">廠區名：</asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList runat="server" Width="153px" Height="22px" ID="ddlFactory">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server">員工號：</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" Width="150px" Height="20px" ID="txtEmpID"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server">舊密碼：</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" Width="150px" Height="20px" ID="txtOPwd"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server">新密碼：</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" Width="150px" Height="20px" ID="txtNPwd"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server">確認新密碼：</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" Width="150px" Height="20px" ID="txtRNPwd"></asp:TextBox>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <table id="tabelchanpwd2">
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Button runat="server" Text="確  認" Height="25px" Width="60px" ID="btnPwd" OnClick="btnPwd_Click"></asp:Button>
                                </td>
                                <td>
                                    <asp:Label runat="server" Width="30px" Height="25"></asp:Label>
                                </td>
                                <td>
                                    <asp:Button runat="server" Text="取  消" Height="25px" Width="60px" ID="btnCancelPwd"></asp:Button>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div id="footer2">
                <asp:Label runat="server" ID="message" Text="操作提示："></asp:Label>
                <asp:Label runat="server" ID="lblMsg"></asp:Label>
            </div>
        </div>
    <div>
    
    </div>
    </form>
</body>
</html>
