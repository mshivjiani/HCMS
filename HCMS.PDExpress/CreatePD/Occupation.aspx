<%@ Page Title="Occupation" Language="C#" MasterPageFile="~/PDMaster.Master" AutoEventWireup="false" CodeBehind="Occupation.aspx.cs" Inherits="HCMS.PDExpress.CreatePD.Occupation" %>
<%@ Register Src="~/Controls/CreatePD/Occupation/Occupation.ascx" TagName="Occupation" TagPrefix="CreatePD" %>
<%@ Register Src="~/Controls/CreatePD/CreatePDMapStatusProgress.ascx" TagName="CreatePDMapStatusProgress" TagPrefix="CreatePD" %>


<asp:Content ID="Content2" ContentPlaceHolderID="PDMasterMainContent" runat="server">
    <CreatePD:CreatePDMapStatusProgress ID="ctrlCreatePDMapStatusProgress" runat="server" PercentComplete="20.00" />
    <CreatePD:Occupation ID="ctrlOccupation" runat="server" />
</asp:Content>
