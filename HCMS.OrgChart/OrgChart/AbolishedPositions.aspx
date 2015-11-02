<%@ Page Title="" Language="C#" MasterPageFile="~/OrgChartMaster.Master" AutoEventWireup="false" CodeBehind="AbolishedPositions.aspx.cs" Inherits="HCMS.OrgChart.OrgChart.AbolishedPositions" %>
<%@ Register TagPrefix="custom" TagName="AbolishedPositions" Src="~/Controls/Positions/ctrlAbolishedPositions.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
    <script type="text/javascript" src="../Src/windowDialogFunctions.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <custom:AbolishedPositions id="customAbolishedPositions" runat="server" />
</asp:Content>
