<%@ Page Title="Dashboard Role" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="DashboardRole.aspx.cs" Inherits="HCMS.Portal.Admin.DashboardRole" %>
<%@ Register Src="~/Controls/Admin/DashboardRole.ascx" TagPrefix="hcms" TagName="DashboardRole" %>

<asp:Content ID="Content3" ContentPlaceHolderID="headContent" runat="server" >
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="mainContent" runat="server">
    <hcms:DashboardRole ID="DashboardRole1" runat="server" />
</asp:Content>
