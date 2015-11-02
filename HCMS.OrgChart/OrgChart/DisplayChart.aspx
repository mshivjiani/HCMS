<%@ Page Language="C#" AutoEventWireup="false" CodeBehind="DisplayChart.aspx.cs" Inherits="HCMS.OrgChart.OrgChart.DisplayChart" %>
<%@ Register TagPrefix="custom" TagName="DisplayChart" Src="~/Controls/Common/ctrlDisplayOrgChartPopUp.ascx" %>

<!DOCTYPE html>

<html>
<head id="Head1" runat="server">
    <title>View Published Organization Chart</title>
    <meta http-equiv="X-UA-Compatible" content="IE=9,chrome=1" />
	<meta http-equiv="content-type" content="text/html; charset=windows-1250" />
    <meta http-equiv="cache-control" content="max-age=0" />
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="expires" content="0" />
    <meta http-equiv="expires" content="Tue, 01 Jan 1980 1:00:00 GMT" />
    <meta http-equiv="pragma" content="no-cache" />

    <script type="text/javascript" src="../src/jquery-1.11.1.js"></script>
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
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center;">
            <div id="divErrorMessage" runat="server" class="errorMessage" visible="false"><br /><asp:Literal ID="literalErrorMessage" runat="server" /></div>
        </div>

        <custom:DisplayChart id="customDisplayChart" runat="server" PreviewTitle="In-Process Organization Chart" visible="false" />
    </form>
</body>
</html>
