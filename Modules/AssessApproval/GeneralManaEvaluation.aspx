﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPageDefault.master" CodeFile="GeneralManaEvaluation.aspx.cs" Inherits="Modules_ScoreAssess_GeneralManaEvaluation" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <asp:ScriptManager ID="im" runat="server"/>
    <asp:UpdatePanel ID="up" runat="server">
        <ContentTemplate>
            <div id="titleimage">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/WebSite/Title.gif"/>
            </div>
            <div id="title">總經理考評</div>
            <hr style="clear:both;margin-top:auto"/>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
