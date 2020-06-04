<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPageDefault.master" CodeFile="EhrUserImport.aspx.cs" Inherits="Modules_OrganizaMana_EhrUserImport" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="im" runat="server"/>
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div id="titleimage">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/WebSite/Title.gif"/>
            </div>
            <div id="title">EHR人員資料導入</div>
            <hr style="clear:both;margin-top:auto"/>
            <asp:Panel ID="Panel1" runat="server">
                <div class="fullwidth1">
                    <table>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Sign/import.gif"/>
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Width="40px"></asp:Label>
                                </td>
                                <td>
                                    <asp:Button ID="Button1" runat="server" Text="日騰(RT)導入" Height="25px" Width="80px" />
                                </td>
                                <td>
                                    <span style="height :25px;width:20px" >>></span>
                                </td>
                                <td>
                                    <asp:Button ID="Button3" runat="server" Text="日沛(RP)導入" Height="25px" Width="80px" />
                                </td>
                                <td>
                                    <span style="height :25px;width:20px" >>></span>
                                </td>
                                <td>
                                    <asp:Button ID="Button4" runat="server" Text="日銘(RM)導入" Height="25px" Width="80px" />
                                </td>
                                <td>
                                    <span style="height :25px;width:20px" >>></span>
                                </td>
                                <td>
                                    <asp:Button ID="Button5" runat="server" Text="日鎧(RK)導入" Height="25px" Width="80px" />
                                </td>
                                <td>
                                    <span style="height :25px;width:20px" >>></span>
                                </td>
                                <td>
                                    <asp:Button ID="Button6" runat="server" Text="日善(RS)導入" Height="25px" Width="80px" />
                                </td>
                                <td>
                                    <span style="height :25px;width:20px" >>></span>
                                </td>
                                <td>
                                    <asp:Button ID="Button7" runat="server" Text="勝瑞(SR)導入" Height="25px" Width="80px" />
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
                                    <asp:Label ID="Label2" runat="server" Text="公司簡碼:" Width="70px"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropFactory" runat="server" Height="18px" Width="120px"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="部門編碼:" Width="70px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox3" runat="server" Height="18px" Width="120px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="工號:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox2" runat="server" Height="18px" Width="120px"></asp:TextBox>
                                </td>
                                <td colspan="10"></td>
                                <td>
                                    <asp:Button ID="Button2" runat="server" Text="查詢" Width="70px" Height="22px" />
                                </td>
                                                                <td colspan="10"></td>
                                <td>
                                    <asp:Button ID="Button8" runat="server" Text="Excel匯出" Width="70px" Height="22px" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server">
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            </asp:Panel>
            <div class="message">
                相關信息:
                <asp:Label ID="LabMsg" runat="server"></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
