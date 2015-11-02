<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEditWorkflowGroup.aspx.cs" Inherits="HCMS.Portal.Admin.AddEditWorkflowGroup" %>
<%@ Register Src="~/Controls/Admin/ctrlAddEditWorkflowGroup.ascx" TagName="ctrlAddEditWorkflowGroup"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div>
        <uc1:ctrlAddEditWorkflowGroup ID="ctrlAddEditWorkflowGroup" runat="server" />
    </div>
</asp:Content>
