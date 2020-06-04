<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPageDefault.master" CodeFile="HierarchyOrganiTaskSectionSet.aspx.cs" Inherits="Modules_AssessPara_HierarchyOrganiTaskSectionSet" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="im" runat="server"/>
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div id="titleimage">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/WebSite/Title.gif"/>
            </div>
            <div id="title">層級組織作業區間設定（BY課/部/處/中心/總經理）</div>
            <hr style="clear:both;margin-top:auto"/>
            <asp:Panel ID="Panel1" runat="server">
                <div class="fullwidth1">
                    <table>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="組織層級:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlOrgHiechy" runat="server" Width="150px" Height="18px"></asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="排成作業開始日:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSdate" runat="server" Width="150px" Height="18px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtSdate" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="排成作業結束日:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEdate" runat="server" Width="150px" Height="18px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtEdate" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                                </td>
                                <td>
                                    <asp:Button ID="Button1" runat="server" Text="設定" Width="100px" Height="20px" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server">
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>