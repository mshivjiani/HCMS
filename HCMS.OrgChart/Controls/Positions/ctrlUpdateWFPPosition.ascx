<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ctrlUpdateWFPPosition.ascx.cs" Inherits="HCMS.OrgChart.Controls.Positions.ctrlUpdateWFPPosition" %>
<%@ Register TagPrefix="custom" TagName="ReadOnlyLabel" Src="~/Controls/Common/readOnlyLabel.ascx" %>
<%@ Register TagPrefix="custom" TagName="OrgChartDetailInformation" Src="~/Controls/OrgChart/Common/orgChartDetailInformation.ascx" %>
<%@ Register TagPrefix="custom" TagName="ErrorMessage" Src="~/Controls/Common/errorMessage.ascx" %>

<telerik:RadAjaxManagerProxy id="radAjaxManagerProxyMain" runat="server">
    <ajaxsettings>
        <telerik:AjaxSetting AjaxControlID="checkboxIsEncumbered">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="valSummary" />
                <telerik:AjaxUpdatedControl ControlID="panelPositionName" LoadingPanelID="ajaxLoadingEncumberedPosition" />
            </UpdatedControls>
        </telerik:AjaxSetting>   
        <telerik:AjaxSetting AjaxControlID="dropDownPayPlan">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="valSummary" />
                <telerik:AjaxUpdatedControl ControlID="panelPayPlan" LoadingPanelID="ajaxLoadingPayPlan" />
            </UpdatedControls>
        </telerik:AjaxSetting>   
        <telerik:AjaxSetting AjaxControlID="dropDownDutyStationCountries">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="panelMain" LoadingPanelID="ajaxLoadingDutyStation" />
            </UpdatedControls>
        </telerik:AjaxSetting>   
        <telerik:AjaxSetting AjaxControlID="buttonSave">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="panelMain" />
            </UpdatedControls>
        </telerik:AjaxSetting>   
    </ajaxsettings>
</telerik:RadAjaxManagerProxy>

<asp:panel ID="panelMain" runat="server">
<asp:panel ID="panelMainInner" runat="server" Visible="false">
<custom:ReadOnlyLabel id="customReadOnlyLabel" runat="server" LabelText="In Process Chart -- Read-Only View" />
<custom:OrgChartDetailInformation id="customOrgChartDetails" runat="server" RedirectSuffix="posupdate" />

<br />
<div><hr class="separator" /></div><br /> 
<div class="highlight1">WFP Position Information</div>
<br />

<custom:ErrorMessage id="customErrorMessage" runat="server" />
<asp:ValidationSummary ID="valSummary" runat="server" CssClass="validationMessageBox"
                            ShowSummary="true" HeaderText="<span class='errorMessage'>Validation Message</span><br>"
                            DisplayMode="BulletList" ValidationGroup="UpdatePosition" />

<table class="blueTable" width="100%">
    <tr id="rowSingleOrgCode" runat="server">
        <td align="right">
            <asp:Label ID="labelSingleOrgCode" runat="server" ToolTip="Org Code:" Text="Org Code:" AssociatedControlID="literalSingleOrgCode" />
            &nbsp;<custom:tooltip ID="tooltipSingleOrgCode" runat="server" ToolTipID="251" />
        </td>
        <td><asp:Literal ID="literalSingleOrgCode" runat="server" /></td>
    </tr>

    <tr id="rowMultipleOrgCodes" runat="server" visible="false">
        <td align="right">
            <asp:Label ID="labelMultipleOrgCodes" runat="server" ToolTip="Org Code:" Text="Org Code:" AssociatedControlID="dropDownMultipleOrgCodes" />
            <span class="required">*</span> &nbsp;<custom:tooltip ID="tooltipMultipleOrgCodes" runat="server" ToolTipID="252" />
        </td>
        <td>
        <telerik:RadComboBox ID="dropDownMultipleOrgCodes" runat="server" Width="600px" />
            <asp:RequiredFieldValidator ID="requiredMultipleOrgCodes" runat="server" ControlToValidate="dropDownMultipleOrgCodes" 
                InitialValue="<<-- Select Organization Code -->>" ErrorMessage="The 'Organization Code' is a required field."
                Display="None" ValidationGroup="UpdatePosition" />
        </td>
    </tr>

    <tr>
        <td width="200" align="right">
            <asp:Label ID="labelPositionTitle" runat="server" ToolTip="Position Title:" Text="Position Title:" AssociatedControlID="textboxPositionTitle" />
            <span class="required">*</span> &nbsp;<custom:tooltip ID="tooltipPositionTitle" runat="server" ToolTipID="253" />
        </td>
        <td>
            <asp:TextBox ID="textboxPositionTitle" runat="server" MaxLength="255" Width="400px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="requiredPositionTitle" runat="server" ControlToValidate="textboxPositionTitle" 
                ErrorMessage="The 'Position Title' is a required field." Display="None" ValidationGroup="UpdatePosition" />
        </td>
    </tr>

    <tr>
        <td></td>
        <td>
        <div class="highlight1">
            <asp:CheckBox ID="checkboxIsEncumbered" runat="server" AutoPostBack="true" Text="This is an 'Encumbered' Position" />
            <div class="ajaxLoaderIcon" style="right: 520px;">
                    <telerik:RadAjaxLoadingPanel ID="ajaxLoadingEncumberedPosition" runat="server" SkinID="ajaxLoaderIcon">
                    <asp:Image ID="imageLoaderEncumbered" runat="server" SkinID="ajaxLoaderBlue" />
                    </telerik:RadAjaxLoadingPanel>
                </div>
        </div>

        <asp:Panel ID="panelPositionName" runat="server">
        <asp:Panel ID="panelPositionNameInner" runat="server" Visible="false">
        <br />
        <table class="noBorderInnerTable" width="100%">
            <tr>
            <td width="95">
                <asp:Label ID="labelFirstName" runat="server" ToolTip="First Name:" Text="First Name:" AssociatedControlID="textboxFirstName" />
                <span class="required">*</span> &nbsp;<custom:tooltip ID="tooltipFirstName" runat="server" ToolTipID="254" />
            </td>
            <td width="140">
                <asp:TextBox ID="textboxFirstName" runat="server" MaxLength="255" Width="125px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="requiredFirstName" runat="server" ControlToValidate="textboxFirstName" 
                    ErrorMessage="The 'First Name' is a required field." Display="None" ValidationGroup="UpdatePosition" />
            </td>
            <td width="95">
                <asp:Label ID="labelMiddleName" runat="server" ToolTip="Middle Name:" Text="Middle Name:" AssociatedControlID="textboxMiddleName" />
                &nbsp;<custom:tooltip ID="tooltipMiddleName" runat="server" ToolTipID="255" />
            </td>
            <td width="115"><asp:TextBox ID="textboxMiddleName" runat="server" MaxLength="125" Width="95px" /></td>
            <td width="95">
                <asp:Label ID="labelLastName" runat="server" ToolTip="Last Name:" Text="Last Name:" AssociatedControlID="textboxLastName" />
                <span class="required">*</span> &nbsp;<custom:tooltip ID="tooltipLastName" runat="server" ToolTipID="256" />
            </td>
            <td>
                <asp:TextBox ID="textboxLastName" runat="server" MaxLength="255" Width="125px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="requiredLastName" runat="server" ControlToValidate="textboxLastName" 
                    ErrorMessage="The 'Last Name' is a required field." Display="None" ValidationGroup="UpdatePosition" />
            </td>
            </tr>
        </table>
        </asp:Panel>
        </asp:Panel>
        </td>
    </tr>

    <tr>
        <td align="right">
            <asp:Label ID="labelPNBPNS" runat="server" ToolTip="Position Number Base/Suffix:" Text="Position Number Base/Suffix:" AssociatedControlID="literalPNBPNS" />
            &nbsp;<custom:tooltip ID="tooltipPNBPNS" runat="server" ToolTipID="257" />
        </td>
        <td><asp:Literal ID="literalPNBPNS" runat="server" Text="* N/A *" /></td>
    </tr>

    <tr>
        <td align="right">
            <asp:Label ID="labelPayPlan" runat="server" ToolTip="Pay Plan:" Text="Pay Plan:" AssociatedControlID="dropDownPayPlan"></asp:Label>
            <span class="required">*</span> &nbsp;<custom:tooltip ID="tooltipPayPlan" runat="server" ToolTipID="258" />
        </td>
        <td class="cellAdjustment">
            <asp:Panel ID="panelPayPlan" runat="server">
                <table class="noBorderInnerTable" cellpadding="0" cellspacing="0" width="720">
                    <tr>
                        <td width="210">
                        <telerik:RadComboBox ID="dropDownPayPlan" runat="server" Width="170px" autopostback="true" />
                        <asp:RequiredFieldValidator ID="requiredPayPlan" runat="server" ControlToValidate="dropDownPayPlan" 
                            InitialValue="<<-- Select Pay Plan -->>" ErrorMessage="The 'Pay Plan' is a required field."
                            Display="None" ValidationGroup="UpdatePosition" />

                            <div class="ajaxLoaderIcon" style="right: 10px;">
                                <telerik:RadAjaxLoadingPanel ID="ajaxLoadingPayPlan" runat="server" SkinID="ajaxLoaderIcon">
                                <asp:Image ID="imageLoaderPayPlan" runat="server" SkinID="ajaxLoaderBlue" />
                                </telerik:RadAjaxLoadingPanel>
                            </div>
                        </td>
                        <td id="tdSeriesLabel" runat="server" width="125" align="right" visible="false">
                            <asp:Label ID="labelSeries" runat="server" ToolTip="Series:" Text="Series:" AssociatedControlID="dropDownSeries"></asp:Label>
                            <span class="required">*</span> &nbsp;<custom:tooltip ID="tooltipSeries" runat="server" ToolTipID="259" />
                        </td>
                        <td id="tdSeries" runat="server" width="350" visible="false">
                        <telerik:RadComboBox ID="dropDownSeries" runat="server" width="340px" />
                        <asp:RequiredFieldValidator ID="requiredSeries" runat="server" ControlToValidate="dropDownSeries" 
                            InitialValue="<<-- Select Series -->>" ErrorMessage="The 'Series' is a required field."
                            Display="None" ValidationGroup="UpdatePosition" />
                        </td>
                        <td></td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>

    <tr>
        <td align="right">
            <asp:Label ID="labelFPLGrade" runat="server" ToolTip="FPL:" Text="FPL:" AssociatedControlID="dropDownFPLGrades"></asp:Label>
            <span class="required">*</span> &nbsp;<custom:tooltip ID="tooltipFPLGrades" runat="server" ToolTipID="260" />
        </td>
        <td class="cellAdjustment">
                <table class="noBorderInnerTable" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td width="210">
                        <telerik:RadComboBox ID="dropDownFPLGrades" runat="server" Width="170px" />
                        <asp:RequiredFieldValidator ID="required" runat="server" ControlToValidate="dropDownFPLGrades" 
                            InitialValue="<<-- Select FPL -->>" ErrorMessage="The 'FPL' is a required field."
                            Display="None" ValidationGroup="UpdatePosition" />
                        <asp:CompareValidator ID="compareFPLAndCurrentGrade" runat="server" ControlToValidate="dropDownFPLGrades" 
                            ControlToCompare="dropDownCurrentGrades" ErrorMessage="The 'FPL' cannot be less than the 'Current Grade'." 
                            Operator="GreaterThanEqual" Type="Integer"  Display="None" ValidationGroup="UpdatePosition" />
                        </td>
                        <td width="125" align="right">
                            <asp:Label ID="labelCurrentGrade" runat="server" ToolTip="Current Grade:" Text="Current Grade:" AssociatedControlID="dropDownCurrentGrades"></asp:Label>
                            <span class="required">*</span> &nbsp;<custom:tooltip ID="tooltipCurrentGrades" runat="server" ToolTipID="261" />
                        </td>
                        <td>
                        <telerik:RadComboBox ID="dropDownCurrentGrades" runat="server" width="200" />
                        <asp:RequiredFieldValidator ID="requiredCurrentGrades" runat="server" ControlToValidate="dropDownCurrentGrades" 
                            InitialValue="<<-- Select Current Grade -->>" ErrorMessage="The 'Current Grade' is a required field."
                            Display="None" ValidationGroup="UpdatePosition" />
                        </td>
                    </tr>
                </table>
        </td>
    </tr>

    <tr>
        <td align="right">
            <asp:Label ID="labelDutyStationCountry" runat="server" ToolTip="Duty Station Country:" Text="Duty Station Country:" AssociatedControlID="dropDownDutyStationCountries" />
            <span class="required">*</span> &nbsp;<custom:tooltip ID="tooltipDutyStationCountry" runat="server" ToolTipID="262" />
        </td>
        <td>
        <telerik:RadComboBox ID="dropDownDutyStationCountries" runat="server" Width="500px" autopostback="true" />
            <asp:RequiredFieldValidator ID="requiredDutyStationCountry" runat="server" ControlToValidate="dropDownDutyStationCountries" 
                InitialValue="<<-- Select Duty Station Country -->>" ErrorMessage="The 'Duty Station Country' is a required field."
                Display="None" ValidationGroup="UpdatePosition" />

                <div class="ajaxLoaderIcon" style="right: 240px;">
                    <telerik:RadAjaxLoadingPanel ID="ajaxLoadingDutyStation" runat="server" SkinID="ajaxLoaderIcon">
                    <asp:Image ID="imageLoaderDutyStation" runat="server" SkinID="ajaxLoaderBlue" />
                    </telerik:RadAjaxLoadingPanel>
                </div>
        </td>
    </tr>

    <tr id="rowDutyStationState" runat="server" visible="false">
        <td align="right">
            <asp:Label ID="labelDutyStationState" runat="server" ToolTip="Duty Station State:" Text="Duty Station State:" AssociatedControlID="dropDownDutyStationStates" />
            <span class="required">*</span> &nbsp;<custom:tooltip ID="tooltipDutyStationState" runat="server" ToolTipID="263" />
        </td>
        <td>
        <telerik:RadComboBox ID="dropDownDutyStationStates" runat="server" Width="250px" />
            <asp:RequiredFieldValidator ID="requiredDutyStationState" runat="server" ControlToValidate="dropDownDutyStationStates" 
                InitialValue="<<-- Select Duty Station State -->>" ErrorMessage="The 'Duty Station State' is a required field."
                Display="None" ValidationGroup="UpdatePosition" />
        </td>
    </tr>

    <tr>
        <td align="right">
            <asp:Label ID="labelDutyStationCity" runat="server" ToolTip="Duty Station City:" Text="Duty Station City:" AssociatedControlID="textboxDutyStationCity" />
            <span class="required">*</span> &nbsp;<custom:tooltip ID="tooltipDutyStationCity" runat="server" ToolTipID="264" />
        </td>
        <td>
            <asp:TextBox ID="textboxDutyStationCity" runat="server" MaxLength="255" Width="300px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="requiredDutyStationCity" runat="server" ControlToValidate="textboxDutyStationCity" 
                ErrorMessage="The 'Duty Station City' is a required field." Display="None" ValidationGroup="UpdatePosition" />
        </td>
    </tr>

    <tr>
        <td align="right">
            <asp:Label ID="labelPositionType" runat="server" ToolTip="Position Type:" Text="Position Type:" AssociatedControlID="dropDownPositionTypesSupervisoryStatuses" />
            <span class="required">*</span> &nbsp;<custom:tooltip ID="tooltipPositionTypesSupervisoryStatus" runat="server" ToolTipID="265" />
        </td>
        <td>
        <telerik:RadComboBox ID="dropDownPositionTypesSupervisoryStatuses" runat="server" Width="300px" />
            <asp:RequiredFieldValidator ID="requiredPositionTypes" runat="server" ControlToValidate="dropDownPositionTypesSupervisoryStatuses" 
                InitialValue="<<-- Select Position Type -->>" ErrorMessage="The 'Position Type' is a required field."
                Display="None" ValidationGroup="UpdatePosition" />
        </td>
    </tr>

    <tr>
        <td align="right">
            <asp:Label ID="labelOrganizationPositionType" runat="server" ToolTip="Organization Position Type:" Text="Organization Position Type:" AssociatedControlID="dropDownOrganizationPositionTypes" />
            <span class="required">*</span> &nbsp;<custom:tooltip ID="tooltipOrganizationPositionTypes" runat="server" ToolTipID="266" />
        </td>
        <td>
        <telerik:RadComboBox ID="dropDownOrganizationPositionTypes" runat="server" Width="300px" />
            <asp:RequiredFieldValidator ID="requiredOrganizationPositionTypes" runat="server" ControlToValidate="dropDownOrganizationPositionTypes" 
                InitialValue="<<-- Select Organization Position Type -->>" ErrorMessage="The 'Organization Position Type' is a required field."
                Display="None" ValidationGroup="UpdatePosition" />
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
            <span id="spanPositionRequired" runat="server" class="required">*</span> &nbsp;<custom:tooltip ID="tooltipReportsToPosition" runat="server" ToolTipID="267" />
        </td>
        <td>
            <telerik:RadComboBox ID="dropDownParentPositions" runat="server" Width="500px" />
            <asp:RequiredFieldValidator ID="requiredParentPosition" runat="server" ControlToValidate="dropDownParentPositions" InitialValue="<<-- Select Reports To Position -->>" 
                ErrorMessage="The 'Reports to Position' field is a required field." Display="None" ValidationGroup="UpdatePosition" />
        </td>
    </tr>

    <tr id="rowReportsToPositionRoot" runat="server">
        <td width="200" align="right">
            <asp:Label ID="labelReportsToPositionView" runat="server" ToolTip="Reports To:" Text="Reports To:" AssociatedControlID="literalReportsToPosition" />
            &nbsp;<custom:tooltip ID="tooltipReportsToPositionView" runat="server" ToolTipID="270" />
        </td>
        <td class="boldText"><span class="boldText"><asp:Literal ID="literalReportsToPosition" runat="server" Text="* Top Level Position *" /></span></td>
    </tr>


    <tr id="rowPlacementType" runat="server">
        <td align="right">
            <asp:Label ID="labelPositionPlacement" runat="server" ToolTip="Position Box Placement:" Text="Position Box Placement:" AssociatedControlID="dropDownPositionPlacements" />
            &nbsp;<custom:tooltip ID="tooltipPositionPlacement" runat="server" ToolTipID="268" />
        </td>
        <td>
            <telerik:RadComboBox ID="dropDownPositionPlacements" runat="server" Width="210px" />
        </td>
    </tr>

    <tr id="rowLocationGroupType" runat="server">
        <td align="right">
            <asp:Label ID="labelPositionLocationGroupType" runat="server" ToolTip="Position Box Location:" Text="Position Box Location:" AssociatedControlID="dropDownPositionLocationGroupTypes" />
            &nbsp;<custom:tooltip ID="tooltipPositionLocationGroupType" runat="server" ToolTipID="269" />
        </td>
        <td>
            <telerik:RadComboBox ID="dropDownPositionLocationGroupTypes" runat="server" Width="210px" />
        </td>
    </tr>

    <tr>
        <td></td>
        <td class="cellAdjustment">
        <asp:Button ID="buttonSave" runat="server" Text="Update WFP Position" CssClass="button" CausesValidation="true" ValidationGroup="UpdatePosition" Width="175px" />&nbsp;
        <asp:Button ID="buttonCancel" runat="server" Text="Cancel" CssClass="button" CausesValidation="false" Width="125px" />
        </td>
    </tr>
</table>

<br />
<asp:Button ID="buttonChartPositions" runat="server" Text="Chart Positions" CssClass="button" CausesValidation="false" Width="175px" />
<asp:Button ID="buttonOrganizationChartDetails" runat="server" Text="Organization Chart Manager" CssClass="button" CausesValidation="false" Width="225px" />
<asp:Button ID="buttonDeletePosition" runat="server" Text="Delete Position" OnClientClick="customConfirm(this, 'Are you sure you want to delete this WFP and revert all linked organization charts to the \'DRAFT\' phase?', 'Confirm WFP Deletion', 135, null); return false;" CssClass="button" CausesValidation="false" Width="175px" />
<br /><br />

</asp:panel>
</asp:panel>