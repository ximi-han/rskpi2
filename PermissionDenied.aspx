<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPageDefault.master" CodeFile="PermissionDenied.aspx.cs" Inherits="PermissionDenied_aspx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contentbox">
        <div style="font-size:large; font-weight:bold">
            <asp:Image ID="ImgApplicationMappingError" runat="server" ImageUrl="~/Images/WebSite/error.gif" />
            <asp:Label ID="lblPermissionDenied" runat="server" Text="Permission Denied" Font-Bold="true" Font-Size="Larger"></asp:Label>
        </div>
        <div class="contentbox">
            <p>You do not have enough permission to access this web or use this function!!!</p>
        </div>
    </div>
</asp:Content>