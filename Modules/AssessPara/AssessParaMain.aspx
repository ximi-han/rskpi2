<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPageDefault.master" CodeFile="AssessParaMain.aspx.cs" Inherits="Modules_AssessPara_AssessParaMain" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="sm" runat="server"/>
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div id="titleimage">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/WebSite/AssessIndex.gif"/>
            </div>
            <div id="title">考核指標主頁面</div>
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
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Modules/AssessPara/AnnualEvaluationIntervalSet.aspx">年度考評區間設定</asp:HyperLink>
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
                                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Modules/AssessPara/HierarchyOrganiTaskSectionSet.aspx">層級組織作業區間設定(BY課/部/處/中心/總經理)</asp:HyperLink>
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
                                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Modules/AssessPara/AssessStart.aspx">考核啟動</asp:HyperLink>
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
                                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Modules/AssessPara/AssessFile.aspx">考核歸檔</asp:HyperLink>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

