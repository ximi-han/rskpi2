<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPageDefault.master" CodeFile="AssessOrganizaManaValidation.aspx.cs" Inherits="Modules_OrganizaMana_AssessOrganizaManaValidation" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="im" runat="server"/>
    <asp:UpdatePanel ID="up" runat="server">
        <triggers>
            <asp:PostBackTrigger ControlID="btnexcel"/>
        </triggers>
        <ContentTemplate>
            <div id="titleimage">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/WebSite/Title.gif"/>
            </div>
            <div id="title">考核組織主管生效確認</div>
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
                                    <asp:Button ID="btnValConfigdept" runat="server" Text="主管生效確認" Height="25px" Width="120px" OnClick="btnValConfigdept_Click"/>
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
                                    <asp:Label ID="Label2" runat="server" Text="公司簡碼:" Width="60px"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlFactory" runat="server" Height="20px" Width="100px" AutoPostBack="true" OnSelectedIndexChanged="ddlFactory_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                                <td colspan=5></td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="中心層級:" Width="60px"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlDeptIDList1" runat="server" Height="20px" Width="120px"></asp:DropDownList>
                                </td>
                                <td colspan=5></td>
                                <td>
                                    <asp:Button ID="btnquery" runat="server" Text="查詢" Height="20px" Width="70px" OnClick="btnquery_Click" />
                                </td>
                                <td colspan=5></td>
                                <td>
                                    <asp:Button ID="btnexcel" runat="server" Text="匯出" Height="20px" Width="70px" OnClick="btnexcel_Click"/>
                                </td>
                                <td colspan=5></td>
                                <td style="width: 268435456px">
                                    <asp:Button ID="btnsock" runat="server" Text="鎖定" Height="20px" Width="70px" OnClick="btnsock_Click"/>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" ScrollBars="Horizontal" Width="750px">
                <asp:GridView ID="gvFormView" runat="server" Width="1000px" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" OnPageIndexChanging="GridView1_PageIndexChanging" GridLines="Horizontal">
                    <Columns>
                        <asp:BoundField DataField="GroupID" HeaderText="廠區ID">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FactoryName" HeaderText="廠區名稱">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DeptID" HeaderText="部門ID">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DeptName" HeaderText="部門名稱">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ManagerID" HeaderText="主管工號">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ManagerName" HeaderText="主管姓名">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TitleName" HeaderText="職稱">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ParentDeptID" HeaderText="Parent部門ID">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PDeptName" HeaderText="Parent部門名稱">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CUser" HeaderText="創建者工號">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CDate" HeaderText="創建日期">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                    </Columns>
                    <RowStyle CssClass="gvr" Height="22px" HorizontalAlign="Center"></RowStyle>
                    <HeaderStyle Height="22px" ForeColor="White" CssClass="gvh" HorizontalAlign="Center" Font-Bold="false"></HeaderStyle>
                    <AlternatingRowStyle CssClass="gvar"></AlternatingRowStyle>
                </asp:GridView>
            </asp:Panel>
            <div class="message">
                相關信息:
                <asp:Label ID="LabMsg" runat="server"></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
