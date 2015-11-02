<%@ Page Title="" Language="C#" MasterPageFile="~/OrgChartMaster.Master" AutoEventWireup="false" CodeBehind="ViewChart.aspx.cs" Inherits="HCMS.OrgChart.OrgChart.ViewChart" %>
<%@ Register TagPrefix="custom" TagName="ViewChart" Src="~/Controls/OrgChart/ctrlViewOrgChart.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
    <meta http-equiv="cache-control" content="max-age=0" />
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="expires" content="0" />
    <meta http-equiv="expires" content="Tue, 01 Jan 1980 1:00:00 GMT" />
    <meta http-equiv="pragma" content="no-cache" />

    <script type="text/javascript" src="../src/chartrender/js/jquery/jquery-ui-1.10.2.custom.min.js"></script>
    <script type="text/javascript" src="../src/chartrender/js/primitives.min.js"></script>
    <script type="text/javascript" src="../src/chartrender/html2canvas.js"></script>
    <script type="text/javascript" src="../src/canvas/canvasOperations.js"></script>
    <script type="text/javascript" src="../src/chartRender/bpCustomFunctions.js"></script>
    <script type="text/javascript" src="../src/spin/spin.min.js"></script>
    <script type="text/javascript" src="../src/chartrender/html2canvasCustom.js"></script>

    <link rel="stylesheet" href="../src/chartrender/js/jquery/ui-lightness/jquery-ui-1.10.2.custom.css" />
    <link href="../src/chartrender/css/primitives.latest.css?v=1" media="screen" rel="stylesheet" type="text/css" />
    <link href="../src/chartrender/css/primitiveCustomizations.css?v=1" media="screen" rel="stylesheet" type="text/css" />
    <link href="../src/chartrender/css/customChartStyles.css?v=1.2" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <custom:ViewChart id="customViewChart" runat="server" />
</asp:Content>
