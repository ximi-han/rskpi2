<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPageDefault.master" CodeFile="PwdInitialization.aspx.cs" Inherits="Modules_SystemSet_PwdInitialization" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="im" runat="server"/>
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div id="titleimage">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/WebSite/Title.gif"/>
            </div>
            <div id="title">用戶密碼初始化</div>
            <hr style="clear:both;margin-top:auto"/>
            <asp:Panel ID="Panel1" runat="server">
                <tabel>
                    <tbody>
                        <tr>
                            <td>
                                工号：
                            </td>
                            <td>
                                <asp:TextBox ID="txtEmpID" runat="server" Height="17px" Width="100px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnQuery" runat="server" Text="查询" Height="20px" Width="50px" OnClick="btnQuery_Click"></asp:Button>
                            </td>
                        </tr>
                    </tbody>
                </tabel>
            </asp:Panel>
            <hr style="clear:both;margin-top:5px"/>
            <asp:Panel ID="Panel2" runat="server">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="650px" AllowPaging="True" AllowSorting="True" PageSize="6" GridLines="Horizontal" OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ibEdit" runat="server" ImageUrl="~/Images/WebPartIcon/edit.gif" CommandName="EditUserPwd" CommandArgument='<%# Eval("EmpID")+","+Eval("GroupID") %>' ToolTip="初始密碼" OnClientClick="return confirm('確定要初始化用戶密碼嗎？')"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="EmpID" HeaderText="工号">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EmpName" HeaderText="姓名">
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
                        <asp:BoundField DataField="GroupID" HeaderText="廠區">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                    </Columns>
                    <RowStyle Height="22px" CssClass="gvr" HorizontalAlign="Center"></RowStyle>
                    <HeaderStyle Height="22px" CssClass="gvh" HorizontalAlign="Center" Font-Bold="true" ForeColor="White"></HeaderStyle>
                    <AlternatingRowStyle CssClass="gvar"></AlternatingRowStyle>
                </asp:GridView>
            </asp:Panel>
            <asp:Panel ID="Panel3" runat="server">
                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="650px" AllowPaging="True" AllowSorting="True" PageSize="6" GridLines="Horizontal" OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ibEdit" runat="server" ImageUrl="~/Images/WebPartIcon/delete.gif" CommandName="EditUserPwd" CommandArgument='<%# Eval("EmpID")+","+Eval("GroupID") %>' ToolTip="初始密碼" OnClientClick="return confirm('確定要初始化用戶密碼嗎？')"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="EmpID" HeaderText="工号">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="EmpName" HeaderText="姓名">
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
                        <asp:BoundField DataField="GroupID" HeaderText="廠區">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Pwd1" HeaderText="初始密碼">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                    </Columns>
                    <RowStyle Height="22px" CssClass="gvr" HorizontalAlign="Center"></RowStyle>
                    <HeaderStyle Height="22px" CssClass="gvh" HorizontalAlign="Center" Font-Bold="true" ForeColor="White"></HeaderStyle>
                    <AlternatingRowStyle CssClass="gvar"></AlternatingRowStyle>
                </asp:GridView>
            </asp:Panel>
            <div class="message">
                相關信息：
                <asp:Label ID="labMsg" runat="server"></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


