<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ctrlUpdateFPPSPosition.ascx.cs" Inherits="HCMS.OrgChart.Controls.Positions.ctrlUpdateFPPSPosition" %>
<%@ Register TagPrefix="custom" TagName="ReadOnlyLabel" Src="~/Controls/Common/readOnlyLabel.ascx" %>
<%@ Register TagPrefix="custom" TagName="OrgChartDetailInformation" Src="~/Controls/OrgChart/Common/orgChartDetailInformation.ascx" %>
<%@ Register TagPrefix="custom" TagName="ErrorMessage" Src="~/Controls/Common/errorMessage.ascx" %>
<%@ Register TagPrefix="custom" TagName="FPPSPositionInformation" Src="~/Controls/Common/ctrlFPPSPositionInformation.ascx" %>

<telerik:RadAjaxManagerProxy id="radAjaxManagerProxyMain" runat="server">
    <ajaxsettings>
        <telerik:AjaxSetting AjaxControlID="buttonIncludePosition">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="panelMain" />
            </UpdatedControls>
        </telerik:AjaxSetting> 
        <telerik:AjaxSetting AjaxControlID="buttonUpdatePosition">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="panelMain" />
            </UpdatedControls>
        </telerik:AjaxSetting>   
    </ajaxsettings>
</telerik:RadAjaxManagerProxy>

<asp:Panel ID="panelMain" runat="server">
<asp:Panel ID="panelMainInner" runat="server" Visible="false">
<custom:ReadOnlyLabel id="customReadOnlyLabel" runat="server" LabelText="In Process Chart -- Read-Only View" />
<custom:OrgChartDetailInformation id="customOrgChartDetails" runat="server" />

<br />
<div><hr class="separator" /></div><br /> 
<div class="highlight1">FPPS Position Information</div>
<br />

 <custom:ErrorMessage id="customErrorMessage" runat="server" />
    <asp:ValidationSummary ID="valSummary" runat="server" CssClass="validationMessageBox"
                                ShowSummary="true" HeaderText="<span class='errorMessage'>Validation Message</span><br>"
                                DisplayMode="BulletList" ValidationGroup="PositionDetails" />

    <custom:FPPSPositionInformation id="customFPPSPositionInformation" runat="server" ShowReportsToPosition="false" ShowOrganizationPositionType="false" />

    <br /><div><hr class="separator" /></div>
    <div class="highlight1">Additional FPPS Position Information</div>
    <br />

    <table class="blueTable" width="100%">
    <tr>
        <td width="200" align="right">
            <asp:Label ID="labelOrganizationPositionType" runat="server" ToolTip="Organization Position Type:" Text="Organization Position Type:" AssociatedControlID="dropDownOrganizationPositionTypes" />
            <span class="required">*</span> &nbsp;<custom:tooltip ID="tooltipOrganizationPositionTypes" runat="server" ToolTipID="242" />
        </td>
        <td>
        <telerik:RadComboBox ID="dropDownOrganizationPositionTypes" runat="server" Width="300px" />
            <asp:RequiredFieldValidator ID="requiredOrganizationPositionTypes" runat="server" ControlToValidate="dropDownOrganizationPositionTypes" 
                InitialValue="<<-- Select Organization Position Type -->>" ErrorMessage="The 'Organization Position Type' is a required field."
                Display="None" ValidationGroup="PositionDetails" />
        </td>
    </tr>
    </table>

    <br /><div><hr class="separator" /></div>
    <div class="highlight1">Organization Chart Position Placement Information</div>
    <br />
    
   <table class="blueTable" width="100%">
    <tr id="rowReportsToPositionUpdate" runat="server">
        <td width="200" align="right">
            <asp:Label ID="labelReportsToPosition" runat="server" ToolTip="Reports To:" Text="Reports To:" AssociatedControlID="dropDownParentPositions" />
            <span id="spanPositionRequired" runat="server" class="required">*</span> &nbsp;<custom:tooltip ID="tooltipReportsToPosition" runat="server" ToolTipID="243" />
        </td>
        <td colspan="3">
            <telerik:RadComboBox ID="dropDownParentPositions" runat="server" Width="500px" />
            <asp:RequiredFieldValidator ID="requiredParentPosition" runat="server" ControlToValidate="dropDownParentPositions" InitialValue="<<-- Select Reports To Position -->>" 
                ErrorMessage="The 'Reports to Position' field is a required field." Display="None" ValidationGroup="PositionDetails" />
        </td>
    </tr>

    <tr id="rowReportsToPositionRoot" runat="server">
        <td width="200" align="right">
            <asp:Label ID="labelReportsToPositionView" runat="server" ToolTip="Reports To:" Text="Reports To:" AssociatedControlID="literalReportsToPosition" />
            &nbsp;<custom:tooltip ID="tooltipReportsToPositionView" runat="server" ToolTipID="205" />
        </td>
        <td class="boldText" colspan="3"><span class="boldText"><asp:Literal ID="literalReportsToPosition" runat="server" Text="* Top Level Position *" /></span></td>
    </tr>

    <tr id="rowPlacementType" runat="server">
        <td align="right">
            <asp:Label ID="labelPositionPlacement" runat="server" ToolTip="Position Box Placement:" Text="Position Box Placement:" AssociatedControlID="dropDownPositionPlacements" />
            &nbsp;<custom:tooltip ID="tooltipPositionPlacement" runat="server" ToolTipID="244" />
        </td>
        <td colspan="3">
            <telerik:RadComboBox ID="dropDownPositionPlacements" runat="server" Width="210px" />
        </td>
    </tr>

    <tr id="rowLocationGroupType" runat="server">
        <td align="right">
            <asp:Label ID="labelPositionLocationGroupType" runat="server" ToolTip="Position Box Location:" Text="Position Box Location:" AssociatedControlID="dropDownPositionLocationGroupTypes" />
            &nbsp;<custom:tooltip ID="tooltipPositionLocationGroupType" runat="server" ToolTipID="245" />
        </td>
        <td colspan="3">
            <telerik:RadComboBox ID="dropDownPositionLocationGroupTypes" runat="server" Width="210px" />
        </td>
    </tr>

    <tr>
        <td></td>
        <td  colspan="3" class="cellAdjustment">
        <asp:Button ID="buttonIncludePosition" runat="server" Text="Add to Organization Chart" CssClass="button" CausesValidation="true" ValidationGroup="PositionDetails" Width="225px" Visible="false" />
        <asp:Button ID="buttonUpdatePosition" runat="server" Text="Update FPPS Position" CssClass="button" CausesValidation="true" ValidationGroup="PositionDetails" Width="175px" Visible="false" />
        <asp:Button ID="buttonCancel" runat="server" Text="Cancel" CssClass="button" CausesValidation="false" Width="125px" />
        </td>
    </tr>
</table>

<br />
<asp:Button ID="buttonChartPositions" runat="server" Text="Chart Positions" CssClass="button" CausesValidation="false" Width="175px" />
<asp:Button ID="buttonOrganizationChartDetails" runat="server" Text="Organization Chart Manager" CssClass="button" CausesValidation="false" Width="225px" />
<br /><br />
</asp:Panel>
</asp:Panel>
