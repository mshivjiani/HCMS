<%@ Page Title="Factors" Language="C#" MasterPageFile="~/PDMaster.Master" AutoEventWireup="false" CodeBehind="Factors.aspx.cs" Inherits="HCMS.PDExpress.CreatePD.Factors" %>
<%@ Register Src="~/Controls/CreatePD/Factors/Factors.ascx" TagName="Factors" TagPrefix="CreatePD" %>
<%@ Register Src="~/Controls/CreatePD/CreatePDMapStatusProgress.ascx" TagName="CreatePDMapStatusProgress" TagPrefix="CreatePD" %>
<%@ Register Src="~/Controls/CreatePD/CreatePDWorkflowNote.ascx" TagName="CreatePDWorkflowNote" TagPrefix="CreatePD" %>


<asp:Content ID="Content2" ContentPlaceHolderID="PDMasterMainContent" runat="server">
    <CreatePD:CreatePDMapStatusProgress ID="ctrlCreatePDMapStatusProgress" runat="server" PercentComplete="80.00" />
    <CreatePD:CreatePDWorkflowNote ID="ctrlCreatePDWorkflowNote" runat="server" />
    <CreatePD:Factors ID="ctrlFactors" runat="server" />
</asp:Content>
