<%@ Page Title="Workflow" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Workflow.aspx.cs" Inherits="HCMS.Portal.Admin.Workflow" %>

<%@ Register Src="~/Controls/Admin/ctrlWorkflow.ascx" TagName="ctrlWorkflow" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <uc1:ctrlWorkflow ID="workflow" runat="server" />
</asp:Content>
