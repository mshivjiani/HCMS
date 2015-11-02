<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchKSA.aspx.cs" Inherits="HCMS.Portal.Admin.SearchKSA" %>
<%@ Register Src="~/Controls/Admin/ctrlAdminSearchKSA.ascx" TagName="ctrlAdminSearchKSA"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div>
        <uc1:ctrlAdminSearchKSA ID="ctrlAdminSearchKSA" runat="server" />
    </div>
</asp:Content>