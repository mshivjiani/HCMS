<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ctrlDisplayOrgChartPopUp.ascx.cs" Inherits="HCMS.OrgChart.Controls.Common.ctrlDisplayOrgChartPopUp" %>

<telerik:RadCodeBlock ID="scriptChartBlock" runat="server">
    <script type='text/javascript'> //<![CDATA[
        $(window).load(function () {
            var options = new primitives.orgdiagram.Config();
            var templates = [];

            templates.push(getBPGeneralTemplate("RootNode"));
            templates.push(getBPGeneralTemplate("FPPSNode"));
            templates.push(getBPGeneralTemplate("WFPNode"));

            options.items = getPositionJSON();
            options.cursorItem = 0;     // ID of the preselected node
            options.maximumColumnsInMatrix = 2;     // number of columns in matrix (side by side) format
            // options.pageFitMode = primitives.orgdiagram.PageFitMode.FitToPage;
            options.pageFitMode = primitives.orgdiagram.PageFitMode.None;
            options.hasSelectorCheckbox = primitives.common.Enabled.False;
            options.itemTitleFirstFontColor = primitives.common.Colors.White;
            options.itemTitleSecondFontColor = primitives.common.Colors.White;
            options.linesColor = primitives.common.Colors.Black;
            options.linesWidth = 3;
            options.linesType = primitives.common.LineType.Solid;
            options.normalItemsInterval = 50;
            options.normalLevelShift = 50;
            options.leavesPlacementType = primitives.common.ChildrenPlacementType.Matrix;
            options.templates = templates;
            options.selectionPathMode = primitives.common.SelectionPathMode.None;
            options.graphicsType = primitives.common.GraphicsType.Canvas;
            options.actualGraphicsType = primitives.common.GraphicsType.Canvas;
            options.horizontalAlignment = primitives.common.HorizontalAlignmentType.Center;

            options.onItemRender = onBPTemplateRender;
            options.onCursorChanging = onBPCursorChanging;
            options.onHighlightChanging = onBPHighlightChanging;

            $("#mainDiagramChartPopUp").orgDiagram(options);  // render on-screen
            $("#divDiagramFullSizeImage").orgDiagram(options);  // secondary full size render
            $("#linkExportPDF").click(convertCanvasAndUpload);

            $("#linkClose").click(function () {
                window.close();
            });

        });//]]>  
    </script>
</telerik:RadCodeBlock>

<div>
    <table class="blueTable" width="100%">
    <tr>
        <td valign="top" class="highlight3"><asp:Literal ID="literalPreviewTitle" runat="server" /></td>
        <td valign="top" width="275" align="right" class="highlight3">
            <a id="linkExportPDF" href="#" class="linkExportPopup">Export the Preview below to PDF</a>        
            <div id="divWaitMessage" class="highlightText">Please wait while we process your request...</div>
        </td>
    </tr>
    </table>
</div>

<!--
<div style="text-align: center;">
    <div class="errorMessage">Please wait while we generate the published organization chart... remember to close this window once generation is completed.</div><br />
    <a id="linkClose" style="cursor: pointer;">Close this Window</a>
</div>
-->
    
<div id="diagramChartContainerPopUp">
    <div id="mainDiagramChartPopUp"></div>
</div>

<div id="divDiagramFullSizeImage"></div>
<div id="divDiagramFullSizeCover"></div>

<br /><br />

