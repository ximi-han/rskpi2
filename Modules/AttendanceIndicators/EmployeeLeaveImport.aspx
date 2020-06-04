<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPageDefault.master" CodeFile="EmployeeLeaveImport.aspx.cs" Inherits="Modules_AttendanceIndicators_EmployeeLeaveImport" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="im" runat="server"/>
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div id="titleimage">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/WebSite/Title.gif"/>
            </div>
            <div id="title">員工假勤導入(HR)</div>
            <hr style="clear:both;margin-top:auto"/>
            <asp:Panel ID="Panel1" runat="server">
                <table>
                    <tbody>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="考核季度:" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="150px"></asp:DropDownList>
                            </td>
                            <td colspan="10"></td>
                            <td>
                                <asp:Button ID="Button1" runat="server" Text="假勤導入" Height="20px" Width="100px" />
                            </td>
                            <td colspan="10"></td>
                            <td>
                                <asp:Button ID="Button2" runat="server" Text="預覽" Height="20px" Width="100px"  />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server">
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            </asp:Panel>
            <div class="message">相關信息:
                <asp:Label ID="Label2" runat="server"></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>