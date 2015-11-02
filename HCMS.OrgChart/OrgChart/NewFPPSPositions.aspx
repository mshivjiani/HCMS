<%@ Page Title="" Language="C#" MasterPageFile="~/OrgChartMaster.Master" AutoEventWireup="false" CodeBehind="NewFPPSPositions.aspx.cs" Inherits="HCMS.OrgChart.OrgChart.NewFPPSPositions" %>
<%@ Register TagPrefix="custom" TagName="NewFPPSPositions" Src="~/Controls/Positions/ctrlNewFPPSPositions.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
    <script type="text/javascript" src="../Src/windowDialogFunctions.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <custom:NewFPPSPositions id="customNewFPPSPositions" runat="server" />
</asp:Content>
