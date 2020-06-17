<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPageDefault.master" CodeFile="AssessSupervisorDeployMana.aspx.cs" Inherits="Modules_OrganizaMana_AssessSupervisorDeployMana" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1"%>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="im" runat="server"/>
    <asp:UpdatePanel ID="up" runat="server">
        <triggers>
            <asp:PostBackTrigger ControlID="Button6" />
        </triggers>
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
                                    <asp:Label ID="Label1" runat="server" Text="廠區:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownList1" runat="server" Width="120px" Height="20px" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                                <td colspan=5></td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="部門:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownList2" runat="server" Width="120px" Height="20px"></asp:DropDownList>
                                </td>
                                <td colspan=10></td>
                                <td>
                                    <asp:Button ID="Button1" runat="server" Text="查詢" Height="20px" Width="70px" OnClick="Button1_Click" />
                                </td>
                                <td colspan="10"></td>
                                <td>
                                    <asp:Button ID="Button6" runat="server" Text="Excel匯出" Height="20px" Width="70px" OnClick="Button6_Click"/>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server">
                <asp:GridView ID="GridView1" runat="server" Width="95%" GridLines="Horizontal" AutoGenerateColumns="False" AllowPaging="True" PageSize="15"  OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="調配">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/WebPartIcon/edit.gif" CommandArgument='<%# Eval("ManagerID")+","+ Eval("DeptID")+","+ Eval("GroupID")%>' CommandName="ManaDeploy" ToolTip="調配"/>
                            </ItemTemplate>
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                        </asp:TemplateField>
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
                        <asp:BoundField DataField="TitleName" HeaderText="主管職稱">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="GroupID" HeaderText="廠區ID">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FactoryName" HeaderText="廠區">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                    </Columns>
                    <RowStyle CssClass="gvr" HorizontalAlign="Center" Height="22px"></RowStyle>
                    <HeaderStyle CssClass="gvh" HorizontalAlign="Center" Height="22px" Font-Bold="true" ForeColor="White"></HeaderStyle>
                    <AlternatingRowStyle CssClass="gvar"></AlternatingRowStyle>
                </asp:GridView>
            </asp:Panel>
            <%--彈出調配--%>
            <cc1:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="Button2" PopupControlID="Panel3" BackgroundCssClass="modalbg"></cc1:ModalPopupExtender>
            <asp:Button ID="Button2" runat="server" Text="Show" Style="display:none"/>
            <asp:Panel ID="Panel3" runat="server" Width="490px" CssClass="popup">
                <div style="color:white; margin-top:-6px; text-align:center">主管信息調配</div>
                <table>
                    <tbody>
                        <tr>
                            <td colspan="50">主管工號:</td>
                            <td colspan="140" style="border-bottom:solid 1px #CECEDA;">
                                <asp:TextBox ID="TextBox1" runat="server" Height="20px" Width="200px" Enabled="false"></asp:TextBox>
                                <span style="color:red">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="50">主管姓名:</td>
                            <td colspan="140" style="border-bottom:solid 1px #CECEDA;">
                                <asp:TextBox ID="TextBox2" runat="server" Height="20px" Width="200px" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="50">部門ID</td>
                            <td colspan="140" style="border-bottom:solid 1px #CECEDA">
                                <asp:TextBox ID="TextBox3" runat="server"  Height="20px" Width="200px" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="50">部門名稱:</td>
                            <td colspan="140" style="border-bottom:solid 1px #CECEDA">
                                <asp:TextBox ID="TextBox4" runat="server" Height="20px" Width="200px" Style="line-height:20px" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="50">調配后主管ID:</td>
                            <td colspan="140" style="border-bottom:solid 1px #CECEDA">
                                <asp:TextBox ID="TextBox5" runat="server" Height="20px" Width="200px"></asp:TextBox>
                                <asp:Button ID="Button3" runat="server" Text="檢索主管姓名" Width="80px" Height="21px" OnClick="Button3_Click"/>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="50">調配后主管姓名:</td>
                            <td colspan="140" style="border-bottom:solid 1px #CECEDA">
                                <asp:TextBox ID="TextBox6" runat="server" Height="20px" Width="200px" Style="line-height:20px" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <hr class="hr"/>
                <table border="0" style="margin-left:auto;margin-right:auto">
                    <tbody>
                        <tr>
                            <td>
                                <asp:Button ID="Button4" runat="server" Text="調配" CssClass="btn_mouseout" OnClick="Button4_Click"></asp:Button>
                            </td>
                            <td>
                                <asp:Button ID="Button5" runat="server" Text="關閉" CssClass="btn_mouseout"></asp:Button>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <hr class="hr"/>
                <div class="message">相關信息
                    <asp:Label ID="LabMsg1" runat="server"></asp:Label>
                </div>
            </asp:Panel>
            <div class="message">
                相關信息:
                <asp:Label ID="LabMsg" runat="server"></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>