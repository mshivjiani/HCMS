<%@ Page Title="" Language="C#" MasterPageFile="~/OrgChartMaster.Master" AutoEventWireup="false" CodeBehind="OrgChartPositions.aspx.cs" Inherits="HCMS.OrgChart.OrgChart.OrgChartPositions" %>
<%@ Register TagPrefix="custom" TagName="OrgChartPositions" Src="~/Controls/Positions/ctrlOrgChartPositions.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
    <script type="text/javascript" src="../Src/windowDialogFunctions.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <custom:OrgChartPositions ID="ctrlOrgChartPositions" runat="server" />
</asp:Content>

