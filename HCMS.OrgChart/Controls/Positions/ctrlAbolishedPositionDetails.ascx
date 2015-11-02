<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ctrlAbolishedPositionDetails.ascx.cs" Inherits="HCMS.OrgChart.Controls.Positions.ctrlAbolishedPositionDetails" %>
<%@ Register TagPrefix="custom" TagName="ReadOnlyLabel" Src="~/Controls/Common/readOnlyLabel.ascx" %>
<%@ Register TagPrefix="custom" TagName="OrgChartDetailInformation" Src="~/Controls/OrgChart/Common/orgChartDetailInformation.ascx" %>
<%@ Register TagPrefix="custom" TagName="ErrorMessage" Src="~/Controls/Common/errorMessage.ascx" %>
<%@ Register TagPrefix="custom" TagName="FPPSPositionInformation" Src="~/Controls/Common/ctrlFPPSPositionInformation.ascx" %>

<telerik:RadAjaxManagerProxy id="radAjaxManagerProxyMain" runat="server">
    <ajaxsettings>
        <telerik:AjaxSetting AjaxControlID="buttonMapNewParents">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="panelMain" />
            </UpdatedControls>
        </telerik:AjaxSetting>   
    </ajaxsettings>
</telerik:RadAjaxManagerProxy>

<asp:Panel ID="panelMain" runat="server">
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

    <custom:FPPSPositionInformation id="customFPPSPositionInformation" runat="server" ShowOrganizationPositionType="true" />

    <asp:Panel ID="panelMapParents" runat="server">
    <br /><div><hr class="separator" /></div>
    <div class="highlight1">New Reporting Parent Section/Abolished Position Resolutions</div>
    <br />
    
   <table class="blueTable" width="100%">
   <tr id="rowReportsToPositionSetCount" runat="server">
        <td></td>
        <td class="highlight3">Use the following drop down list to set the new "reporting to" position of all direct subordinates (Total Direct Subordinates: <span class="highlightText"><asp:Literal ID="literalDirectChildCount" runat="server" Text="0" /></span>).</td>
   </tr>
    <tr id="rowReportsToPositionSet" runat="server">
        <td width="200" align="right">
            <asp:Label ID="labelReportsToPosition" runat="server" ToolTip="Reports To Position:" Text="Reports To Position:" AssociatedControlID="dropDownParentPositions" />
            <span class="required">*</span> &nbsp;<custom:tooltip ID="tooltipReportsToPosition" runat="server" ToolTipID="271" />
        </td>
        <td colspan="3">            
            <telerik:RadComboBox ID="dropDownParentPositions" runat="server" Width="500px" />
            <asp:RequiredFieldValidator ID="requiredParentPosition" runat="server" ControlToValidate="dropDownParentPositions" InitialValue="<<-- Select New Reports To Position -->>" 
                ErrorMessage="The 'Reports to Position' field is a required field." Display="None" ValidationGroup="PositionDetails" />
        </td>
    </tr>

    <tr id="rowActions" runat="server">
        <td align="right"><asp:Label ID="labelFinalActions" runat="server" ToolTip="Final Actions:" Text="Final Actions:" AssociatedControlID="radioListActions" />
          <span class="required">*</span> &nbsp;<custom:tooltip ID="tooltipFinalActions" runat="server" ToolTipID="272" /></td>
        <td>
            <div>After mapping parents, what action would you like to take concerning this position?</div><br />

            <asp:RadioButtonList ID="radioListActions" runat="server" RepeatColumns="1" RepeatLayout="Table">
                <asp:ListItem Text="Take No Action (Position will still be Abolished)" Value="-1" Selected="True" />
                <asp:ListItem Text="Exclude this Position from the Organization Chart" Value="1" />
                <asp:ListItem Text="Delete this Position from the Database" Value="2" />
            </asp:RadioButtonList>
        </td>
    </tr>

    <tr>
        <td></td>
        <td  colspan="3" class="cellAdjustment">
        <asp:Button ID="buttonMapNewParents" runat="server" Text="Associate with New Parent" OnClientClick="customConfirmWithValidation(this, 'Are you sure you want to remap the subordinates for this position and commit the selected action against this abolished position?', 'Confirm Action', 145, 'PositionDetails'); return false;" CssClass="button" CausesValidation="true" ValidationGroup="PositionDetails" Width="225px" />
        <asp:Button ID="buttonCancel" runat="server" Text="Cancel" CssClass="button" CausesValidation="false" Width="125px" />
        </td>
    </tr>
</table>
</asp:Panel>

<br />
<asp:Button ID="buttonChartPositions" runat="server" Text="Chart Positions" CssClass="button" CausesValidation="false" Width="175px" />
<asp:Button ID="buttonOrganizationChartDetails" runat="server" Text="Organization Chart Manager" CssClass="button" CausesValidation="false" Width="225px" />
<asp:Button ID="buttonCancelReadOnly" runat="server" Text="Cancel" CssClass="button" CausesValidation="false" Width="125px" />
<br /><br />
</asp:Panel>
