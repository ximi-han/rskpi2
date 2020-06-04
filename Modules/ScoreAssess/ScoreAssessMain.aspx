<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPageDefault.master" CodeFile="ScoreAssessMain.aspx.cs" Inherits="Modules_ScoreAssess_ScoreAssessMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager id="im" runat="server"/>
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div id="titleimage">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/WebSite/ScoreAssess.gif"/>
            </div>
            <div id="title">考核評分主頁面</div>
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
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Modules/ScoreAssess/SelfAssessofEmployeAbove6.aspx">員工自評（6職以上）</asp:HyperLink>
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
                                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Modules/ScoreAssess/SupervisorEvaluation2positions.aspx">主管考評（2職）</asp:HyperLink>
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
                                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Modules/ScoreAssess/SupervisorEvaluation3to5positions.aspx">主管考評（3~5職）</asp:HyperLink>
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
                                    <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/Item/ba01.gif"/>
                                </td>
                                <td>
                                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Modules/ScoreAssess/SupervisorEvaluationAbove6positions.aspx">主管考評（6職以上）</asp:HyperLink>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

