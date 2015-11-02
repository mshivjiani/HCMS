<%@ Page Title="" Language="C#" MasterPageFile="~/OrgChartMaster.Master" AutoEventWireup="false" CodeBehind="AbolishedPositionDetails.aspx.cs" Inherits="HCMS.OrgChart.OrgChart.AbolishedPositionDetails" %>
<%@ Register TagPrefix="custom" TagName="AbolishedPositionDetails" Src="~/Controls/Positions/ctrlAbolishedPositionDetails.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
    <script type="text/javascript" src="../Src/windowDialogFunctions.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <custom:AbolishedPositionDetails id="customAbolishedPositionDetails" runat="server" />
</asp:Content>