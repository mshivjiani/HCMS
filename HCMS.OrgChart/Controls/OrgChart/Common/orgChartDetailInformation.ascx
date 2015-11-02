<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="orgChartDetailInformation.ascx.cs" Inherits="HCMS.OrgChart.Controls.OrgChart.Common.orgChartDetailInformation" %>
<%@ Register TagPrefix="custom" TagName="OrgChartValidations" Src="~/Controls/OrgChart/Common/orgChartValidations.ascx" %>

<div class="highlight1">Organization Chart Details</div>
<br />

<table class="blueTable" width="100%">
    <tr>
    <td colspan="2" class="highlight3">
        <div style="display: inline-block; float: left;">
        <asp:HyperLink ID="linkViewOrganizationChart" runat="server" Text="View this Organization Chart in Current State" /> 
        
        <span id="spanViewPublishedChart" runat="server">| 
            <asp:hyperlink id="linkViewPublishedChart" runat="server" Text="View the Current Published Version of this Organization" Visible="false" />
            <span class="highlightText"><asp:Literal ID="literalNoPublishedChartOnRecord" runat="server" Text="* No published chart on record for this organization *" /></span>
        </span>
        </div>

       <div id="divResolutions" runat="server" style="display: inline-block; float: right;">
      <div style="float:left"> Resolutions: &nbsp;&nbsp; <custom:ToolTip ID="toolTipResolutions" runat="server" ToolTipID="227"  /> </div>&nbsp; (
        <span id="spanAbolishedPositions" runat="server"><asp:hyperlink ID="linkAbolishedPositions" runat="server" Text="Abolished Positions" />: <asp:Literal ID="literalAbolishedCount" runat="server" Text="0" /></span>
        <span id="spanDivider" runat="server"> | </span> 
        <span id="spanNewFPPSPositions" runat="server"><asp:hyperlink ID="linkNewFPPSPositions" runat="server" Text="New FPPS Positions" />: <asp:Literal ID="literalNewFPPSCount" runat="server" Text="0" /></span>
        )
        </div>
    </td>
    </tr>
</table>
<br />

<table class="blueTable" width="100%">
    <tr>
        <td colspan="2" style="height: 0px;"><custom:OrgChartValidations id="customOrgChartValidations" runat="server" /></td>
    </tr>

    <tr>
        <td width="185" class="highlight3">Chart ID:<custom:ToolTip ID="toolTipChartID" runat="server" ToolTipID="203" /></td>
        <td class="highlight3"><asp:Literal ID="literalOrganizationChartID" runat="server" /></td>
    </tr>
    
    <tr>
        <td width="185" class="highlight3">Chart Type:<custom:ToolTip ID="toolTipOrganizationCode" runat="server" ToolTipID="220" /></td>
        <td class="highlight3"><asp:Literal ID="literalChartType" runat="server" /></td>
    </tr>
    <tr>
        <td class="highlight3">Organization Code/Name:<custom:ToolTip ID="toolTipOrganizationName" runat="server" ToolTipID="204" /></td>
        <td class="highlight3"><asp:Literal ID="literalOrganizationNameLineItem" runat="server" /></td>
    </tr>
    <tr id="rowTopLevelPosition" runat="server">
        <td class="highlight3">Top Level Position:<custom:ToolTip ID="toolTipTopLevelPosition" runat="server" ToolTipID="205" /></td>
        <td class="highlight3"><asp:Literal ID="literalTopLevelPosition" runat="server" /></td>
    </tr>
    </table>