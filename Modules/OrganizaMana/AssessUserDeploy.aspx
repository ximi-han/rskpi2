<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPageDefault.master" CodeFile="AssessUserDeploy.aspx.cs" Inherits="Modules_OrganizaMana_AssessUserDeploy" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1"%>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="im" runat="server"/>
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress2" runat="server" AssociatedUpdatePanelID="up" DisplayAfter="0" DynamicLayout="False">
                <ProgressTemplate>
                    <iframe id="helpcover" class="IframStyle" frameborder="0"></iframe>
                    <div class="WaitBackground">
                        <div class="LoadingBack">        
                    <img alt="" src="../../App_Themes/Default/Images/loading2.gif"></div></div>     
                </ProgressTemplate>
            </asp:UpdateProgress>
            <div id="titleimage">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/WebSite/Title.gif"/>
            </div>
            <div id="title">考核人員調配</div>
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
                                    <asp:DropDownList ID="DropDownList1" runat="server" Height="18px" Width="110px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </td>
                                <td colspan="5"></td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="部門ID:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownList2" runat="server" Height="18px" Width="110px"></asp:DropDownList>
                                </td>
                                <td colspan="5"></td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="工號:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmpID" runat="server" Height="18px" Width="110px"></asp:TextBox>
                                </td>
                                <td colspan=10></td>
                                <td>
                                    <asp:Button ID="btnQuery" runat="server" Text="查詢" Height="20px" Width="70px" OnClick="btnQuery_Click" />
                                </td>
                                <td colspan=5></td>
                                <td>
                                    <%--<asp:Button ID="txtDeploy" runat="server" Text="調配" Height="20px" Width="70px" OnClick="txtDeploy_Click"/>--%>
                                    <asp:Button ID="btnExcel" runat="server" Text="Excel匯出" Height="20px" Width="70px" OnClick="btnExcel_Click" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="700px" AllowPaging="True" GridLines="Horizontal" PageSize="15" OnPageIndexChanging="GridView1_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText="調配">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/WebPartIcon/edit.gif" CommandName="UserDeploy" CommandArgument='<%# Eval("EmpID")%>' ToolTip="調配" OnClientClick="return confirm('請確認是否要進行人員調配？');"/>
                            </ItemTemplate>
                            <HeaderStyle Wrap="False" />
                            <ItemStyle Wrap="False" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="EmpID" HeaderText="工號">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EmpName" HeaderText="姓名">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DomainAccount" HeaderText="賬號">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
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
                        <asp:BoundField DataField="TitleName" HeaderText="職稱">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                    </Columns>
                    <RowStyle Height="22px" HorizontalAlign="Center" CssClass="gvr"></RowStyle>
                    <HeaderStyle Height="22px" ForeColor="White" CssClass="gvh" HorizontalAlign="Center" Font-Bold="false"></HeaderStyle>
                    <AlternatingRowStyle CssClass="gvar"></AlternatingRowStyle>
                </asp:GridView>
            </asp:Panel>
           <%--彈出框--%>
            <cc1:ModalPopupExtender ID="MPEShow" runat="server" TargetControlID="btnMPEShow" PopupControlID="pnlMPEShow" BackgroundCssClass="modalbg"></cc1:ModalPopupExtender>
            <asp:Button   ID="btnMPEShow" runat="server" Text="Show" Style="display: none" />
            <asp:Panel    ID="pnlMPEShow" runat="server" CssClass="popup" Width="320px" Height="232px">
                <div style="color:white; margin-top :-6px; text-align:center">人員調配</div>
                <asp:Panel ID="Panel3" runat="server">
                    <div class="fullwidth2">
                        <table class="popuptable">
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text="工號:" Width="70px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox1" runat="server" Width="150px" Height="18px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text="姓名:" Width="70px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox2" runat="server" Width="150px" Height="18px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text="考核主管:" Width="70px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBox3" runat="server" Width="150px" Height="18px"></asp:TextBox>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <br/>
                        <br/>
                        <table>
                            <table>
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:Button ID="Button1" runat="server" Text="確認" Width="100px" Height="20px"/>
                                        </td>
                                        <td colspan="10"></td>
                                        <td>
                                        <asp:Button ID="Button2" runat="server" Text="取消" Width="100px" Height="20px"/>
                                    </td>
                                    </tr>
                                </tbody>
                            </table>
                        </table>
                    </div>
                </asp:Panel>
            </asp:Panel>
            <div class="message">
                相關信息:
                <asp:Label ID="LabMsg" runat="server"></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>