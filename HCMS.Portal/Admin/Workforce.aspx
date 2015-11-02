<%@ Page Title="Workforce" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Workforce.aspx.cs" Inherits="HCMS.Portal.Admin.Workforce" %>

<%@ Register Src="~/Controls/Admin/ctrlWorkforce.ascx" TagName="ctrlWorkforce" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <uc1:ctrlWorkforce ID="workforce" runat="server" />
</asp:Content>
