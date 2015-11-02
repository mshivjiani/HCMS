<%@ Page Title="Approvals" Language="C#" MasterPageFile="~/PDMaster.Master" AutoEventWireup="false" CodeBehind="Approvals.aspx.cs" Inherits="HCMS.PDExpress.CreatePD.Approvals" %>
<%@ Register Src="~/Controls/CreatePD/Approvals/Approvals.ascx" TagName="Approvals" TagPrefix="CreatePD" %>
<%@ Register Src="~/Controls/CreatePD/CreatePDMapStatusProgress.ascx" TagName="CreatePDMapStatusProgress" TagPrefix="CreatePD" %>
<%@ Register Src="~/Controls/CreatePD/CreatePDWorkflowNote.ascx" TagName="CreatePDWorkflowNote" TagPrefix="CreatePD" %>


<asp:Content ID="Content2" ContentPlaceHolderID="PDMasterMainContent" runat="server">
    <CreatePD:CreatePDMapStatusProgress ID="ctrlCreatePDMapStatusProgress" runat="server" PercentComplete="100.00" />
    <CreatePD:CreatePDWorkflowNote ID="ctrlCreatePDWorkflowNote" runat="server" />
    <CreatePD:Approvals ID="ctrlApprovals" runat="server" />
</asp:Content>
