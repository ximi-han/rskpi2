<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPageDefault.master" CodeFile="SystemSetMain.aspx.cs" Inherits="Modules_SystemSet_SystemSetMain" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="im" runat="server"/>
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div id="titleimage">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/WebSite/SystemSet.gif"/>
            </div>
            <div id="title">系統設定主頁面</div>
            <hr style="clear:both;margin-top:5px"/>
            <asp:Panel ID="Panel1" runat="server">
                <div class="fullwidth1">
                <table>
                    <tbody>
                        <tr>
                            <td>
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Item/ba01.gif"/>
                            </td>
                            <td>
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Modules/SystemSet/AccountMana.aspx">日善用戶賬戶修改</asp:HyperLink>
                            </td>
                        </tr>
                    </tbody>
                </table>
                </div>
                <div class="fullwidth1">
                <table>
                    <tbody>
                        <tr>
                            <td>
                                <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Item/ba01.gif"/>
                            </td>
                            <td>
                                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Modules/SystemSet/UserRoleSet.aspx">日善用戶角色設定</asp:HyperLink>
                            </td>
                        </tr>
                    </tbody>
                </table>
                </div>
                <div class="fullwidth1">
                <table>
                    <tbody>
                        <tr>
                            <td>
                                <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/Item/ba01.gif"/>
                            </td>
                            <td>
                                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Modules/SystemSet/PwdInitialization.aspx">日善用戶密碼初始化</asp:HyperLink>
                            </td>
                        </tr>
                    </tbody>
                </table>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
