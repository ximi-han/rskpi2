<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPageDefault.master" CodeFile="AccountMana.aspx.cs" Inherits="Modules_SystemSet_AccountMana" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="im" runat="server"/>
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div id="titleimage">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/WebSite/Title.gif"/>
            </div>
            <div id="title">賬號管理</div>
            <hr style="clear:both;margin-top:5px"/>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
