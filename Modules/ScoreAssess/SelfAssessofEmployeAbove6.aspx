<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPageDefault.master" CodeFile="SelfAssessofEmployeAbove6.aspx.cs" Inherits="Modules_ScoreAssess_SelfAssessofEmployeAbove6" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="im" runat="server"/>
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div id="titleimage">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/WebSite/Title.gif"/>
            </div>
            <div id="title">員工自評（6職以上）</div>
            <hr style="clear:both;margin-top:auto"/>
            <asp:Panel ID="Panel1" runat="server">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Width="600px">

                    <AlternatingRowStyle BackColor="#DCDCDC" />
                    <Columns>
                        <asp:BoundField HeaderText="工號" DataField="EmpID">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="姓名" DataField="EmpName">
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
                        <asp:BoundField DataField="rsDutyRank" HeaderText="職等">
                        <HeaderStyle Wrap="False" />
                        <ItemStyle Wrap="False" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="自評操作">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtn_selfassess" runat="server" Font-Underline="true" ForeColor="Blue" CommandName="selfassess" OnClick="lbtn_selfassess_Click">自評</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="確認操作">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtn_sendsign" runat="server" Font-Underline="true" ForeColor="Blue" CommandName="sendsign">送簽</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" Height="20px" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" Height="20px" HorizontalAlign="Center"/>
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />
                </asp:GridView>
            </asp:Panel>
            <%--彈跳窗--%>
            <cc1:ModalPopupExtender ID="MPEShow" runat="server" TargetControlID="btnMPEShow" PopupControlID="pnlMPEShow" BackgroundCssClass="modalbg"></cc1:ModalPopupExtender>
            <asp:Button ID="btnMPEShow" runat="server" Text="Show" Style="display: none"/>        
            <asp:Panel ID="pnlMPEShow" runat="server" CssClass="popup" Width="780px" Height="630px">
                <div style="color:white; margin-top :-6px; text-align:center">自評操作</div>
                <asp:Panel ID="Panel2" runat="server">
                    <div class="fullwidth3">
                        <table>
                            <tbody>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text="部門ID:"></asp:Label>
                                    </td>
                                    <td colspan="2"></td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Width="140px" Height="14px" ForeColor="#EE4683"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text="部門名稱:"></asp:Label>
                                    </td>
                                    <td colspan="2"></td>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Width="140px" Height="13px" ForeColor="#EE4683"></asp:Label>
                                    </td>
                                </tr>                                  
                            </tbody>
                        </table>
                    </div>
                </asp:Panel>
                <asp:Panel ID="Panel3" runat="server">
                   <div class="fullwidth4">
                       <asp:Table id="Table1" BorderWidth="0px" GridLines="Both" runat="server"  Width="589px" Font-Bold="True">
                           <asp:TableRow runat="server">
                               <asp:TableCell runat="server"><asp:Label ID="Label6" runat="server" Text="項次" Width="80px" Height="25px"></asp:Label></asp:TableCell>
                               <asp:TableCell runat="server"><asp:Label ID="Label7" runat="server" Text="項目評分" Width="220px" Height="25px"></asp:Label></asp:TableCell>
                               <asp:TableCell runat="server"><asp:Label ID="Label8" runat="server" Text="權重" Width="135px" Height="25px"></asp:Label></asp:TableCell>
                               <asp:TableCell runat="server"><asp:Label ID="Label9" runat="server" Text="評分" Width="145px" Height="22px"></asp:Label></asp:TableCell>
                           </asp:TableRow>
                           <asp:TableRow runat="server">
                               <asp:TableCell runat="server"><asp:Label ID="Label10" runat="server" Text="1" Width="80px" Height="25px"></asp:Label></asp:TableCell>
                               <asp:TableCell runat="server"><asp:Label ID="Label11" runat="server" Text="目標達成（0~100分）" Width="220px" Height="25px"></asp:Label></asp:TableCell>
                               <asp:TableCell runat="server"><asp:Label ID="Label12" runat="server" Text="60%" Width="135px" Height="25px"></asp:Label></asp:TableCell>
                               <asp:TableCell runat="server"><asp:TextBox ID="TextBox1" runat="server" Width="145px" Height="20px"></asp:TextBox></asp:TableCell>
                           </asp:TableRow>
                           <asp:TableRow runat="server">
                               <asp:TableCell runat="server"><asp:Label ID="Label13" runat="server" Text="2" Width="80px" Height="25px"></asp:Label></asp:TableCell>
                               <asp:TableCell runat="server"><asp:Label ID="Label14" runat="server" Text="協調合作（0~100分）" Width="220px" Height="25px"></asp:Label></asp:TableCell>
                               <asp:TableCell runat="server"><asp:Label ID="Label15" runat="server" Text="10%" Width="135px" Height="25px"></asp:Label></asp:TableCell>
                               <asp:TableCell runat="server"><asp:TextBox ID="TextBox2" runat="server" Width="145px" Height="20px"></asp:TextBox></asp:TableCell>
                           </asp:TableRow>
                           <asp:TableRow runat="server">
                               <asp:TableCell runat="server"><asp:Label ID="Label16" runat="server" Text="3" Width="80px" Height="25px"></asp:Label></asp:TableCell>
                               <asp:TableCell runat="server"><asp:Label ID="Label17" runat="server" Text="創新改善（0~100分）" Width="220px" Height="25px"></asp:Label></asp:TableCell>
                               <asp:TableCell runat="server"><asp:Label ID="Label18" runat="server" Text="10%" Width="135px" Height="25px"></asp:Label></asp:TableCell>
                               <asp:TableCell runat="server"><asp:TextBox ID="TextBox4" runat="server" Width="145px" Height="20px"></asp:TextBox></asp:TableCell>
                           </asp:TableRow>
                           <asp:TableRow runat="server">
                               <asp:TableCell runat="server"><asp:Label ID="Label19" runat="server" Text="4" Width="80px" Height="25px"></asp:Label></asp:TableCell>
                               <asp:TableCell runat="server"><asp:Label ID="Label20" runat="server" Text="問題分析與解決（0~100分）" Width="220px" Height="25px"></asp:Label></asp:TableCell>
                               <asp:TableCell runat="server"><asp:Label ID="Label21" runat="server" Text="10%" Width="135px" Height="25px"></asp:Label></asp:TableCell>
                               <asp:TableCell runat="server"><asp:TextBox ID="TextBox5" runat="server" Width="145px" Height="20px"></asp:TextBox></asp:TableCell>
                           </asp:TableRow>
                           <asp:TableRow runat="server">
                               <asp:TableCell runat="server"><asp:Label ID="Label22" runat="server" Text="5" Width="80px" Height="25px"></asp:Label></asp:TableCell>
                               <asp:TableCell runat="server"><asp:Label ID="Label23" runat="server" Text="持續發展（0~100分）" Width="220px" Height="25px"></asp:Label></asp:TableCell>
                               <asp:TableCell runat="server"><asp:Label ID="Label24" runat="server" Text="10%" Width="135px" Height="25px"></asp:Label></asp:TableCell>
                               <asp:TableCell runat="server"><asp:TextBox ID="TextBox6" runat="server" Width="145px" Height="20px"></asp:TextBox></asp:TableCell>
                           </asp:TableRow>
                       </asp:Table>
                       <hr style="clear:both;height:2px"/>
                    <table>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="自我評價(2000字以內):"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="TextBox3" runat="server" Width="590px" Height="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button1" runat="server" Text="保存" Width="70px" Height="20px" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                   </div>
                </asp:Panel>
            </asp:Panel>   
             <div class="message">相關信息:
                <asp:Label ID="LabMsg" runat="server"></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>