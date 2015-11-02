<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="WorkflowActionAdministration.aspx.cs" Inherits="HCMS.Portal.Admin.WorkflowActionAdministration" %>

<%@ Register Src="~/Controls/Admin/ctrlAddEditWorkflowAction.ascx" TagName="ctrlAddEditWorkflowAction"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div>
        <uc1:ctrlAddEditWorkflowAction ID="ctrlAddEditWorkflowAction" runat="server" />
    </div>
</asp:Content>
