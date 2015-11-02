<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="pubOrgChartDetailInformation.ascx.cs" Inherits="HCMS.OrgChart.Controls.PubOrgChart.Common.pubOrgChartDetailInformation" %>

<asp:Panel id="panelHeaderLinks" runat="server">
<table class="blueTable" width="100%">
<tr>
<td colspan="2" class="highlight3">
    <div style="display: inline-block; float: left;">
    <asp:hyperlink id="linkViewPublishedChart" runat="server" NavigateUrl="~/PubOrgChart/ViewChart.aspx" Text="View the Current Published Version of this Organization" />
    </div>
</td>
</tr>
</table>

<br />
</asp:Panel>

<table class="blueTable" width="100%">
<%--<tr>
    <td width="185" class="highlight3">Published Chart ID:<custom:ToolTip ID="tooltipPublishedChartID" runat="server" ToolTipID="0" /></td>
    <td class="highlight3"><asp:Literal ID="literalChartOrganizationLogID" runat="server" /></td>
</tr>--%>
<tr>
    <td width="185" class="highlight3">Chart ID:<custom:ToolTip ID="toolTipChartID" runat="server" ToolTipID="203" /></td>
    <td class="highlight3"><asp:Literal ID="literalOrganizationChartID" runat="server" /></td>
</tr>
    
<tr>
    <td width="185" class="highlight3">Chart Type:<custom:ToolTip ID="toolTipOrganizationCode" runat="server" ToolTipID="220" /></td>
    <td class="highlight3"><asp:Literal ID="literalChartType" runat="server" /></td>
</tr>
<tr>
    <td class="highlight3">Organization Name/Code:<custom:ToolTip ID="toolTipOrganizationName" runat="server" ToolTipID="204" /></td>
    <td class="highlight3"><asp:Literal ID="literalOrganizationName" runat="server" /></td>
</tr>
<tr>
    <td class="highlight3">Top Level Position:<custom:ToolTip ID="toolTipTopLevelPosition" runat="server" ToolTipID="205" /></td>
    <td class="highlight3"><asp:Literal ID="literalTopLevelPosition" runat="server" /></td>
</tr>
<tr>
    <td>Primary Org Code Location:<custom:ToolTip ID="toolTipOrgCodeLocation" runat="server" ToolTipID="207" /></td>
    <td><asp:Literal ID="literalOrgCodeLocation" runat="server" /></td>
</tr>
    
<tr>
    <td>Current Workflow Status:<custom:ToolTip ID="toolTipWorkflowStatus" runat="server" ToolTipID="208" /></td>
    <td class="highlightText"><asp:Literal ID="literalWorkflowStatus" runat="server" /></td>
</tr>
<tr id="rowCreatedOn" runat="server" visible="false">
    <td>Created On:<custom:ToolTip ID="toolTipCreatedOn" runat="server" ToolTipID="210" /></td>
    <td><asp:Literal ID="literalCreatedDate" runat="server" /></td>
</tr>
<tr id="rowCreatedBy" runat="server" visible="false">
    <td>Created By:<custom:ToolTip ID="toolTipCreatedBy" runat="server" ToolTipID="211" /></td>
    <td><asp:Literal ID="literalCreatedByFullName" runat="server" /></td>
</tr>
<tr id="rowUpdatedOn" runat="server" visible="false">
    <td>Last Updated On:<custom:ToolTip ID="toolTipLastUpdatedOn" runat="server" ToolTipID="212" /></td>
    <td><asp:Literal ID="literalLastUpdated" runat="server" /></td>
</tr>
<tr id="rowUpdatedBy" runat="server" visible="false">
    <td>Last Updated By:<custom:ToolTip ID="toolTipLastUpdatedBy" runat="server" ToolTipID="213" /></td>
    <td><asp:Literal ID="literalLastUpdatedBy" runat="server" /></td>
</tr>
</table>

