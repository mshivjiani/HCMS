<%@ Page Title="Organization Chart Administration" Language="C#" MasterPageFile="~/OrgChartMaster.Master" AutoEventWireup="false"
    CodeBehind="OrgChartDetails.aspx.cs" Inherits="HCMS.OrgChart.OrgChart.OrgChartDetails" %>

<%@ Register TagPrefix="custom" TagName="OrgChartDetailsInProgress" Src="~/Controls/OrgChart/ctrlOrgChartDetailsInProgress.ascx"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
    <script type="text/javascript" src="../Src/windowDialogFunctions.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <custom:OrgChartDetailsInProgress ID="ctrlOrgChartDetailsInProgress" runat="server" />
</asp:Content>
