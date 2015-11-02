<%@ Page Title="Job Announcement Administration" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="JNPAdmin.aspx.cs" Inherits="HCMS.Portal.Admin.JNPAdmin" %>
<%@ Register src="~/Controls/Admin/ctrlJNPAdmin.ascx" tagname="ctrlJNPAdmin" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <uc1:ctrlJNPAdmin ID="jnpAdmin" runat="server" />
</asp:Content>
