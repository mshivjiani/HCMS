<%@ Page Title="Position Characteristics" Language="C#" MasterPageFile="~/PDMaster.Master" AutoEventWireup="false" CodeBehind="PositionCharacteristics.aspx.cs" Inherits="HCMS.PDExpress.CreatePD.PositionCharacteristics" %>
<%@ Register Src="~/Controls/CreatePD/PositionCharacteristics/PositionCharacteristics.ascx" TagName="PositionCharacteristics" TagPrefix="CreatePD" %>
<%@ Register Src="~/Controls/CreatePD/CreatePDMapStatusProgress.ascx" TagName="CreatePDMapStatusProgress" TagPrefix="CreatePD" %>
<%@ Register Src="~/Controls/CreatePD/CreatePDWorkflowNote.ascx" TagName="CreatePDWorkflowNote" TagPrefix="CreatePD" %>


<asp:Content ID="Content2" ContentPlaceHolderID="PDMasterMainContent" runat="server">
    <CreatePD:CreatePDMapStatusProgress ID="ctrlCreatePDMapStatusProgress" runat="server" PercentComplete="60.00" />
    <CreatePD:CreatePDWorkflowNote ID="ctrlCreatePDWorkflowNote" runat="server" />
    <CreatePD:PositionCharacteristics ID="ctrlPositionCharacteristics" runat="server" />
</asp:Content>
