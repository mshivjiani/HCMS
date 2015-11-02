<%@ Page Title="Delegate Job Announcement" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DelegateJNP.aspx.cs" Inherits="HCMS.Portal.Admin.DelegateJNP" %>
<%@ Register src="~/Controls/Admin/ctrlDelegateJNP.ascx" tagname="ctrlDelegateJNP" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <uc1:ctrlDelegateJNP ID="delegateJNP" runat="server" />
</asp:Content>
