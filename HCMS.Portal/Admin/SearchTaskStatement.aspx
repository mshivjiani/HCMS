<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchTaskStatement.aspx.cs" Inherits="HCMS.Portal.Admin.SearchTaskStatement" %>
<%@ Register Src="~/Controls/Admin/ctrlAdminSearchTaskStatement.ascx" TagName="ctrlAdminSearchTaskStatement"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div>
        <uc1:ctrlAdminSearchTaskStatement ID="ctrlAdminSearchTaskStatement" runat="server" />
    </div>
</asp:Content>
