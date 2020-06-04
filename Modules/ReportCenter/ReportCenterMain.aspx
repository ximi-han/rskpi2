<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPageDefault.master" CodeFile="ReportCenterMain.aspx.cs" Inherits="Modules_ReportCenter_ReportCenterMain" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="im" runat="server"/>
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div id="titleimage">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/WebSite/ReportCenter.gif" />
            </div>
            <div id="title">報表中心頁面</div>
            <hr style="clear:both;margin-top:5px"/>
            <asp:Panel ID="Panel1" runat="server">
                <div class="fullwidth1">
                    <table>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Item/ba01.gif" />
                                </td>
                                <td>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Modules/ReportCenter/UserQuery.aspx">考核明細查詢(BY 員工)</asp:HyperLink>
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
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Item/ba01.gif" />
                                </td>
                                <td>
                                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Modules/ReportCenter/DeptManaQuery.aspx">考核明細查詢(BY 部門主管)</asp:HyperLink>
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
                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/Item/ba01.gif" />
                                </td>
                                <td>
                                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Modules/ReportCenter/HRQuery.aspx">考核明細查詢(BY HR)</asp:HyperLink>
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
                                    <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/Item/ba01.gif" />
                                </td>
                                <td>
                                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Modules/ReportCenter/AssessDistribute.aspx">考核分佈</asp:HyperLink>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

