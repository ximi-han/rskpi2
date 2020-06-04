<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPageDefault.master" CodeFile="AssessSupervisorDeployMana.aspx.cs" Inherits="Modules_OrganizaMana_AssessSupervisorDeployMana" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="im" runat="server"/>
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div id="titleimage">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/WebSite/Title.gif"/>
            </div>
            <div id="title">考核組織主管調配</div>
            <hr style="clear:both;margin-top:auto"/>
            <asp:Panel ID="Panel1" runat="server">
                <div class="fullwidth1">
                    <table>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="部門ID:" Width="80px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox1" runat="server" Height="18px" Width="120px"></asp:TextBox>
                                </td>
                                <td colspan=10></td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="部門名稱:" Width="80px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox2" runat="server" Height="18px" Width="120px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="EHR主管ID:" Width="80px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox3" runat="server" Height="18px" Width="120px"></asp:TextBox>
                                </td>
                                <td colspan=10></td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="EHR主管姓名:" Width="80px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox4" runat="server" Height="18px" Width="120px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="考核主管ID:" Width="80px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox5" runat="server" Height="18px" Width="120px"></asp:TextBox>
                                </td>
                                <td colspan=10></td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="考核主管姓名:" Width="80px"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox6" runat="server" Height="18px" Width="120px"></asp:TextBox>
                                </td>
                                <td colspan=5></td>
                                <td>
                                    <asp:Button ID="Button1" runat="server" Text="查詢" Height="20px" Width="70px" />
                                </td>
                                <td colspan=5></td>
                                <td>
                                    <asp:Button ID="Button3" runat="server" Text="變更" Height="20px" Width="70px"/>
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