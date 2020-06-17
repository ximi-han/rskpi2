<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPageDefault.master" CodeFile="OrganizaManaMain.aspx.cs" Inherits="Modules_OrganizaMana_OrganizaManaMain" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="sm" runat="server" />
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div id="titleimage">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/WebSite/OrganizaMana.gif" />
            </div>
            <div id="title">組織管理主頁面</div>
            <hr style="clear:both; margin-top:5px"/>
            <asp:Panel ID="Panel1" runat="server">
                <div class="fullwidth1">
                    <table>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Item/ba01.gif"/>
                                </td>
                                <td>
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Modules/OrganizaMana/EhrUserImport.aspx">EHR人員資料導入</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Item/ba01.gif"/>
                                </td>
                                <td>
                                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Modules/OrganizaMana/EhrDeptOrganizaImport.aspx">EHR部門組織導入</asp:HyperLink>
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
                                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Modules/OrganizaMana/AssessUserDeploy.aspx">考核人員調配</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/Item/ba01.gif"/>
                                </td>
                                <td>
                                    <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Modules/OrganizaMana/AssessUserDeployQuery.aspx">考核人員調配信息查詢</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Image ID="Image6" runat="server" ImageUrl="~/Images/Item/ba01.gif"/>
                                </td>
                                <td>
                                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Modules/OrganizaMana/AssessSupervisorDeployMana.aspx">考核組織主管調配</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Image ID="Image7" runat="server" ImageUrl="~/Images/Item/ba01.gif"/>
                                </td>
                                <td>
                                    <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Modules/OrganizaMana/AssessSupervisorDeployManaQuery.aspx">考核組織主管調配信息查詢</asp:HyperLink>
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
                                    <asp:Image ID="Image8" runat="server" ImageUrl="~/Images/Item/ba01.gif"/>
                                </td>
                                <td>
                                    <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Modules/OrganizaMana/AssessUserValidation.aspx">人員生效確認</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Image ID="Image9" runat="server" ImageUrl="~/Images/Item/ba01.gif"/>
                                </td>
                                <td>
                                    <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Modules/OrganizaMana/AssessOrganizaManaValidation.aspx">考核組織主管生效確認</asp:HyperLink>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


