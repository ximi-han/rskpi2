<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPageDefault.master" CodeFile="AnnualEvaluationIntervalSet.aspx.cs" Inherits="Modules_AssessPara_AnnualEvaluationIntervalSet" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="im" runat="server"/>
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div id="titleimage">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/WebSite/Title.gif"/>
            </div>
            <div id="title">年度考評區間設定</div>
            <hr style="clear:both;margin-top:auto"/>
            <asp:Panel ID="Panel1" runat="server">
                <div class="fullwidth1">
                    <table>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="年度："></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtYear" runat="server" Width="150px" Height="18px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtYear" Format="yyyy"></cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="考評季度："></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlQuarter" runat="server" Width="150px" Height="18px">
                                        <asp:ListItem Value="1" Text="一季度"></asp:ListItem>
                                        <asp:ListItem Value="2" Text="二季度"></asp:ListItem>
                                        <asp:ListItem Value="3" Text="三季度"></asp:ListItem>
                                        <asp:ListItem Value="4" Text="四季度"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="週期開始日期："></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSdate" runat="server" Width="150px" Height="18px"></asp:TextBox>
                                    <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtSdate"  Format="yyyy-MM-dd"></cc1:CalendarExtender>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="週期結束日期："></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEdate" runat="server" Width="150px" Height="18px"></asp:TextBox>
                                </td>
                                <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtEdate" Format="yyyy-MM-dd"></cc1:CalendarExtender>
                                <td>
                                    <asp:Button ID="btnSet" runat="server" Text="設定" Width="100px" Height="20px" OnClick="btnSet_Click"/>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server">
                <asp:GridView ID="GridView1" runat="server">

                </asp:GridView>
            </asp:Panel>
            <div class="message">
                相關信息:
                <asp:Label ID="labMsg" runat="server" ></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>