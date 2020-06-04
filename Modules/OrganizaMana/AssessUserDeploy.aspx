<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPageDefault.master" CodeFile="AssessUserDeploy.aspx.cs" Inherits="Modules_OrganizaMana_AssessUserDeploy" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1"%>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="im" runat="server"/>
    <asp:UpdatePanel ID="up" runat="server">
        <triggers>
            <asp:PostBackTrigger ControlID="btnExcel" />
        </triggers>
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
                                    <asp:Button ID="btnExcel" runat="server" Text="Excel匯出" Height="20px" Width="70px" OnClick="btnExcel_Click" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="700px" AllowPaging="True" GridLines="Horizontal" PageSize="15" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand" >
                    <Columns>
                        <asp:TemplateField HeaderText="調配">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/WebPartIcon/edit.gif" CommandName="UserDeploy" CommandArgument='<%# Eval("EmpID")%>' ToolTip="調配"/>
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
            <%--彈出調配--%>
            <cc1:ModalPopupExtender ID="ModalPopupExtenderDeploy" runat="server" TargetControlID="Button1" BackgroundCssClass="modalbg" PopupControlID="Panel3" ></cc1:ModalPopupExtender>
            <asp:Button  ID="Button1" runat="server" Text="Show" Style="display:none"/>
            <asp:Panel  ID="Panel3" runat="server" Width="490px" CssClass="popup">
                <div style="color:white;margin-top:-6px; text-align:center">人員信息調配</div>
                <table>
                    <tbody>
                        <tr>
                            <td colspan="50">工號:</td>
                            <td colspan="140" style="border-bottom:solid 1px #CECEDA;">
                                <asp:TextBox ID="TextBox1" runat="server" MaxLength="50" Height="20px"  Width="200px" Enabled="false"></asp:TextBox>
                                <span style="color:red">*</span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="50">姓名:</td>
                            <td colspan="140" style="border-bottom:solid 1px #CECEDA;">
                                <asp:TextBox ID="TextBox2" runat="server"  Height="20px" Width="200px" Style="line-height:20px" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="50">部門ID:</td>
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
                            <td colspan="50">調配后部門ID:</td>
                            <td colspan="140" style="border-bottom:solid 1px #CECEDA">
                                <asp:TextBox ID="TextBox5" runat="server" Height="20px" Width="200px"></asp:TextBox>
                                <asp:Button ID="Button2" runat="server" Text="檢索部門名稱" Width="80px" Height="21px" OnClick="Button2_Click"/>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="50">調配后部門名稱:</td>
                            <td colspan="140" style="border-bottom:solid 1px #CECEDA">
                                <asp:TextBox ID="TextBox6" runat="server" Height="20px" Width="200px" Style="line-height:20px" Enabled="false"></asp:TextBox>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <hr class="hr"/>
                <table border="0" style="margin-left:auto; margin-right:auto">
                    <tbody>
                        <tr>
                            <td>
                                <asp:Button ID="Button3" runat="server" Text="調配" onmouseover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'" CssClass="btn_mouseout" OnClick="Button3_Click"/>
                            </td>
                            <td>
                                <asp:Button ID="Button4" runat="server" Text="關閉" onmoueover="this.className='btn_mouseover'" onmouseout="this.className='btn_mouseout'" CssClass="btn_mouseout"/>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <hr class="hr"/>
                <div class="message">
                    相關信息:<asp:Label ID="LabMsg1" runat="server"></asp:Label>
                </div>
            </asp:Panel>
            <div class="message">
                相關信息:
                <asp:Label ID="LabMsg" runat="server"></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>