<%@ Page Title="Select Position Description Type" Language="C#" MasterPageFile="~/PDMaster.master" AutoEventWireup="false" CodeBehind="PDTypeChoice.aspx.cs" Inherits="HCMS.PDExpress.CreatePD.PDTypeChoice" %>
<%@ Register Src="~/Controls/CreatePD/CreatePDChoice.ascx" TagName="PDChoice" TagPrefix="CreatePD" %>


<asp:Content ID="Content2" ContentPlaceHolderID="PDMasterMainContent" runat="server">
    <CreatePD:PDChoice id="ctrlPDChoice" runat="server" />
</asp:Content>
