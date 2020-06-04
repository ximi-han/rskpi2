<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPageDefault.master" CodeFile="AssessStart.aspx.cs" Inherits="Modules_AssessPara_AssessStart" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="im" runat="server"/>
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div id="titleimage">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/WebSite/Title.gif"/>
            </div>
            <div id="title">考核啟動</div>
            <hr style="clear:both;margin-top:auto"/>
            <asp:Panel ID="Panel1" runat="server">
                <div class="fullwidth1">
                    <table>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="考核層級:" Width="70px"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownList1" runat="server" Width="150px" Height="20px"></asp:DropDownList>
                                </td>
                                <td colspan="10"></td>
                                <td>
                                    <asp:Button ID="Button1" runat="server" Text="預覽" Width="120px" Height="20px" />
                                </td>
                                <td colspan="10"></td>
                                <td>
                                    <asp:Button ID="Button2" runat="server" Text="啟動考核" Width="120px" Height="20px" />
                                </td>
                                <td colspan="10"></td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="課/部/處/中心" Width="100px"></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server">
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            </asp:Panel>
            <div class="message">相關信息:
                <asp:Label ID="Label3" runat="server"></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
