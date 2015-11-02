<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="WorkflowRuleAdministration.aspx.cs" Inherits="HCMS.Portal.Admin.WorkflowRuleAdministration" %>

<%@ Register Src="~/Controls/Admin/ctrlAddEditWorkflowRule.ascx" TagName="ctrlAddEditWorkflowRule"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div>
        <uc1:ctrlAddEditWorkflowRule ID="ctrlAddEditWorkflowRule" runat="server" />
    </div>
</asp:Content>
