<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPageDefault.master" CodeFile="AttendanceIndicatorsMain.aspx.cs" Inherits="Modules_AttendanceIndicators_AttendanceIndicatorsMain" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="im" runat="server"/>
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div id="titleimage">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/WebSite/SystemSet.gif"/>
            </div>
            <div id="title">考勤指標主界面</div>
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
                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Modules/AttendanceIndicators/EmployeeLeaveImport.aspx">員工假勤導入(HR)</asp:HyperLink>
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
                                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Modules/AttendanceIndicators/EmployeeRewardAndPunishmentImport.aspx">員工獎懲導入(HR)</asp:HyperLink>
                            </td>
                        </tr>
                    </tbody>
                </table>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>