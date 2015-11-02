<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WorkflowGroupAdministration.aspx.cs" Inherits="HCMS.Portal.Admin.WorkflowGroupAdministration" %>
<%@ Register src="~/Controls/Admin/ctrlWorkflowGroup.ascx" tagname="ctrlWorkflowGroup" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
  <div><uc1:ctrlWorkflowGroup ID="ctrlWorkflowGroup" runat="server" /></div>
</asp:Content>
