<%@ Page Title="Statement of Difference" Language="C#" MasterPageFile="~/PDMaster.Master" AutoEventWireup="true" CodeBehind="SOD.aspx.cs" Inherits="HCMS.PDExpress.CreatePD.SOD" %>
<%@ Register Src="~/Controls/CreatePD/SOD/SOD.ascx" TagName="SOD" TagPrefix="CreatePD" %>


<asp:Content ID="Content2" ContentPlaceHolderID="PDMasterMainContent" runat="server">
    <CreatePD:SOD ID="ctrlSOD" runat="server" />
</asp:Content>
