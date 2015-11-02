<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ctrlFPPSPositionInformation.ascx.cs" Inherits="HCMS.OrgChart.Controls.Common.ctrlFPPSPositionInformation" %>

<table class="blueTable" width="100%">
    <tr>
        <td align="right">
            <asp:Label ID="labelOrgCode" runat="server" ToolTip="Org Code:" Text="Org Code:" AssociatedControlID="literalOrgCode" />
            &nbsp;<custom:tooltip ID="tooltipOrgCode" runat="server" ToolTipID="229" />
        </td>
        <td colspan="3"><asp:Literal ID="literalOrgCode" runat="server" /></td>
    </tr>

    <tr>
        <td width="200" align="right">
            <asp:Label ID="labelPositionTitle" runat="server" ToolTip="Position Title:" Text="Position Title:" AssociatedControlID="literalPositionTitle" />
            &nbsp;<custom:tooltip ID="tooltipPositionTitle" runat="server" ToolTipID="230" />
        </td>
        <td colspan="3"><asp:Literal ID="literalPositionTitle" runat="server" /></td>
    </tr>

    <tr>
        <td align="right">
            <asp:Label ID="labelPNBPNS" runat="server" ToolTip="Position Number Base/Suffix:" Text="Position Number Base/Suffix:" AssociatedControlID="literalPNBPNS" />
            &nbsp;<custom:tooltip ID="tooltipPNBPNS" runat="server" ToolTipID="231" />
        </td>
        <td colspan="3"><asp:Literal ID="literalPNBPNS" runat="server" /></td>
    </tr>

     <tr>
        <td align="right"><asp:Label ID="labelPositionStatus" runat="server" ToolTip="Position Status:" Text="Position Status:" AssociatedControlID="literalPositionStatus"></asp:Label>
            &nbsp;<custom:tooltip ID="tooltipPositionStatus" runat="server" ToolTipID="232" /></td>
        <td colspan="3"><asp:Literal ID="literalPositionStatus" runat="server" /></td>
    </tr>

    <tr id="rowFullName" runat="server">
        <td align="right"><asp:Label ID="labelFullName" runat="server" ToolTip="Name:" Text="Name:" AssociatedControlID="literalFullName"></asp:Label>
            &nbsp;<custom:tooltip ID="tooltipFullName" runat="server" ToolTipID="233" /></td>
        <td colspan="3"><asp:Literal ID="literalFullName" runat="server" /></td>
    </tr>

    <tr id="rowEmploymentStatus" runat="server">
        <td align="right"><asp:Label ID="labelEmploymentStatus" runat="server" ToolTip="Employment Status:" Text="Employment Status:" AssociatedControlID="literalEmploymentStatus"></asp:Label>
            &nbsp;<custom:tooltip ID="tooltipEmploymentStatus" runat="server" ToolTipID="250" /></td>
        <td colspan="3"><asp:Literal ID="literalEmploymentStatus" runat="server" /></td>
    </tr>

    <tr>
        <td align="right"><asp:Label ID="labelPayPlan" runat="server" ToolTip="Pay Plan:" Text="Pay Plan:" AssociatedControlID="literalPayPlan"></asp:Label>
            &nbsp;<custom:tooltip ID="tooltipPayPlan" runat="server" ToolTipID="234" /></td>
        <td><asp:Literal ID="literalPayPlan" runat="server" /></td>
        <td align="right"><asp:Label ID="labelSeries" runat="server" ToolTip="Series:" Text="Series:" AssociatedControlID="literalSeries"></asp:Label>
            &nbsp;<custom:tooltip ID="tooltipSeries" runat="server" ToolTipID="240" /></td>
        <td><asp:Literal ID="literalSeries" runat="server" /></td>
    </tr>

    <tr>
        <td align="right">
            <asp:Label ID="labelFPLGrade" runat="server" ToolTip="FPL:" Text="FPL:" AssociatedControlID="literalFPLGrade"></asp:Label>
            &nbsp;<custom:tooltip ID="tooltipFPLGrade" runat="server" ToolTipID="235" />
        </td>
        <td><asp:Literal ID="literalFPLGrade" runat="server" /></td>
        <td width="200" align="right">
            <asp:Label ID="labelCurrentGrade" runat="server" ToolTip="Current Grade:" Text="Current Grade:" AssociatedControlID="literalCurrentGrade"></asp:Label>
            &nbsp;<custom:tooltip ID="tooltipCurrentGrade" runat="server" ToolTipID="241" />
        </td>
        <td width="350"><asp:Literal ID="literalCurrentGrade" runat="server" /></td>
    </tr>

    <tr>
        <td align="right">
            <asp:Label ID="labelDutyStationCountry" runat="server" ToolTip="Duty Station Country:" Text="Duty Station Country:" AssociatedControlID="literalDutyStationCountry" />
            &nbsp;<custom:tooltip ID="tooltipDutyStationCountry" runat="server" ToolTipID="236" />
        </td>
        <td colspan="3"><asp:Literal ID="literalDutyStationCountry" runat="server" /></td>
    </tr>

    <tr id="rowDutyStationState" runat="server" visible="false">
        <td align="right">
            <asp:Label ID="labelDutyStationState" runat="server" ToolTip="Duty Station State:" Text="Duty Station State:" AssociatedControlID="literalDutyStationState" />
            &nbsp;<custom:tooltip ID="tooltipDutyStationState" runat="server" ToolTipID="237" />
        </td>
        <td colspan="3"><asp:Literal ID="literalDutyStationState" runat="server" /></td>
    </tr>

    <tr>
        <td align="right">
            <asp:Label ID="labelDutyStationCity" runat="server" ToolTip="Duty Station City:" Text="Duty Station City:" AssociatedControlID="literalDutyStationCity" />
            &nbsp;<custom:tooltip ID="tooltipDutyStationCity" runat="server" ToolTipID="238" />
        </td>
        <td colspan="3"><asp:Literal ID="literalDutyStationCity" runat="server" /></td>
    </tr>

    <tr>
        <td align="right">
            <asp:Label ID="labelPositionType" runat="server" ToolTip="Position Type:" Text="Position Type:" AssociatedControlID="literalPositionTypesSupervisoryStatus" />
            &nbsp;<custom:tooltip ID="tooltipPositionTypesSupervisoryStatus" runat="server" ToolTipID="239" />
        </td>
        <td colspan="3"><asp:Literal ID="literalPositionTypesSupervisoryStatus" runat="server" /></td>
    </tr>
    
    <tr id="rowReportsToPosition" runat="server">
        <td align="right">
            <asp:Label ID="labelCurrentlyReportsTo" runat="server" ToolTip="Currently Reports To:" Text="Currently Reports To:" AssociatedControlID="literalCurrentlyReportsToName" />
            &nbsp;<custom:tooltip ID="tooltipCurrentlyReportsTo" runat="server" ToolTipID="0" />
        </td>
        <td colspan="3"><asp:Literal ID="literalCurrentlyReportsToName" runat="server" /></td>
    </tr>
    
    <tr id="rowOrganizationPositionType" runat="server">
        <td align="right">
            <asp:Label ID="labelOrganizationPositionType" runat="server" ToolTip="Organization Position Type:" Text="Organization Position Type:" AssociatedControlID="literalOrganizationPositionType" />
            &nbsp;<custom:tooltip ID="tooltipOrganizationPositionType" runat="server" ToolTipID="242" />
        </td>
        <td colspan="3"><asp:Literal ID="literalOrganizationPositionType" runat="server" /></td>
    </tr>
</table>
