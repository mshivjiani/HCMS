<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ToolTipAdmin.aspx.cs" Inherits="HCMS.Portal.Admin.ToolTipAdmin" %>
<%@ Register src="../Controls/Admin/ctrlToolTipAdmin.ascx" tagname="ctrlToolTipAdmin" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <uc1:ctrlToolTipAdmin ID="ctrlToolTipAdmin1" runat="server" />
</asp:Content>
