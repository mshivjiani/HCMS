<%@ Page Title="Duties" Language="C#" MasterPageFile="~/PDMaster.Master" AutoEventWireup="false" CodeBehind="Duties.aspx.cs" Inherits="HCMS.PDExpress.CreatePD.Duties" %>
<%@ Register Src="~/Controls/CreatePD/Duties/Duties.ascx" TagName="Duties" TagPrefix="CreatePD" %>
<%@ Register Src="~/Controls/CreatePD/CreatePDMapStatusProgress.ascx" TagName="CreatePDMapStatusProgress" TagPrefix="CreatePD" %>
<%@ Register Src="~/Controls/CreatePD/CreatePDWorkflowNote.ascx" TagName="CreatePDWorkflowNote" TagPrefix="CreatePD" %>


<asp:Content ID="Content2" ContentPlaceHolderID="PDMasterMainContent" runat="server">
    <CreatePD:CreatePDMapStatusProgress ID="ctrlCreatePDMapStatusProgress" runat="server" PercentComplete="40.00" />
    <CreatePD:CreatePDWorkflowNote ID="ctrlCreatePDWorkflowNote" runat="server" />
    <CreatePD:Duties ID="ctrlDuties" runat="server" />
</asp:Content>
