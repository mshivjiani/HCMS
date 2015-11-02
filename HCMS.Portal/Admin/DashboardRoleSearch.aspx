<%@ Page Title="Dashboard Role Search" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="DashboardRoleSearch.aspx.cs" Inherits="HCMS.Portal.Admin.DashboardRoleSearch" %>
<%@ Register Src="~/Controls/Admin/ctlDashboardRoleSearch.ascx" TagPrefix="hcms" TagName="DashboardRoleSearch" %>

<asp:Content ID="Content3" ContentPlaceHolderID="headContent" runat="server" >
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="mainContent" runat="server">
    <hcms:DashboardRoleSearch ID="DashboardRole1" runat="server" />
</asp:Content>
