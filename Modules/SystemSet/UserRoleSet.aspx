<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPageDefault.master" CodeFile="UserRoleSet.aspx.cs" Inherits="Modules_SystemSet_UserRoleSet" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="im" runat="server"/>
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div id="titleimage">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/WebSite/Title.gif"/>
            </div>
            <div id="title">用戶角色維護</div>      
            <hr style="clear:both;margin-top:5px"/>  
            <asp:Panel ID="Panel1" runat="server">
                <tabel>
                    <tbody>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Site："></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropSite" runat="server"  Width="110px" AutoPostBack="True" OnSelectedIndexChanged="DropSite_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="角色群組："></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="DropRoles" runat="server" Width="150px" Height="20px" AutoPostBack="True" OnSelectedIndexChanged="DropRoles_OnSelectedIndexChanged"></asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="btnQuery" runat="server" Text="查詢" Height="20px" Width="35px" OnClick="btnQuery_Click"></asp:Button>
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text=" <<<<<<<加入新成員" ></asp:Label>
                            <td>
                            <td>
                                <asp:TextBox ID="txtEmpID" runat="server" Height="18px" Width="150px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnAdd" runat="server" Text="新增" Height="20px" Width="35px" OnClick="btnAdd_Click"></asp:Button>
                            </td>
                        </tr>
                    </tbody>
                </tabel>
            </asp:Panel>  
            <hr/>
            <br/>
            <asp:Label ID="LabRoleName" runat="server" ></asp:Label>
            <asp:Panel ID="Panel2" runat="server">
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" GridLines="Horizontal" PageSize="6" Width="650px" OnRowCommand="GridView1_RowCommand">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="ibDel" runat="server" ImageUrl="~/Images/WebPartIcon/delete.gif" CommandName="DelEmpRoleActive" CommandArgument='<%# Eval("UID")+","+Eval("GroupName") %>' ToolTip="刪除" OnClientClick="return confirm('確定要刪除該人員這條角色權限記錄嗎？');"/>
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
                        <asp:BoundField DataField="RoleName" HeaderText="角色">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DomainAccount" HeaderText="賬戶">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Email" HeaderText="Email">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField DataField="GroupName" HeaderText="廠區">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                    </Columns>
                    <RowStyle Height="22px" CssClass="gvr" HorizontalAlign="Center"></RowStyle>
                    <HeaderStyle Height="22px" CssClass="gvh" HorizontalAlign="Center" Font-Bold="false" ForeColor="White"></HeaderStyle>
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


