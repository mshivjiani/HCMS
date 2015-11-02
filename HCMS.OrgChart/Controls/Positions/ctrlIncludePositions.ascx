<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ctrlIncludePositions.ascx.cs" Inherits="HCMS.OrgChart.Controls.Positions.ctrlIncludePositions" %>
<%@ Register TagPrefix="custom" TagName="ReadOnlyLabel" Src="~/Controls/Common/readOnlyLabel.ascx" %>
<%@ Register TagPrefix="custom" TagName="OrgChartDetailInformation" Src="~/Controls/OrgChart/Common/orgChartDetailInformation.ascx" %>
<%@ Register TagPrefix="custom" TagName="ErrorMessage" Src="~/Controls/Common/errorMessage.ascx" %>

<telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
    <script type="text/javascript">
        function customValAtLeastOneSelected(source, args) 
        {
            var listbox = $find('<%= listboxPositions.ClientID %>');
            args.IsValid = listbox.get_checkedItems().length > 0;  
        }
    </script>
</telerik:RadScriptBlock>

<telerik:RadAjaxManagerProxy id="radAjaxManagerProxyMain" runat="server">
    <ajaxsettings>
    <telerik:AjaxSetting AjaxControlID="dropDownChildOrgCodes">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="panelMain" LoadingPanelID="ajaxLoadingChildOrgCodes" />
            </UpdatedControls>
        </telerik:AjaxSetting> 
        <telerik:AjaxSetting AjaxControlID="buttonInclude">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="panelMain" />
            </UpdatedControls>
        </telerik:AjaxSetting>   
    </ajaxsettings>
</telerik:RadAjaxManagerProxy>

<asp:panel ID="panelMain" runat="server">
<custom:ReadOnlyLabel id="customReadOnlyLabel" runat="server" LabelText="In Process Chart -- Read-Only View" />
<custom:OrgChartDetailInformation id="customOrgChartDetails" runat="server" RedirectSuffix="posincl" />

<br />
<div><hr class="separator" /></div><br /> 
<div class="highlight1">Include Existing Positions</div>
<br />

<custom:ErrorMessage id="customErrorMessage" runat="server" />
<asp:ValidationSummary ID="valSummary" runat="server" CssClass="validationMessageBox"
                            ShowSummary="true" HeaderText="<span class='errorMessage'>Validation Message</span><br>"
                            DisplayMode="BulletList" ValidationGroup="IncludePositions" />

<table class="blueTable" width="100%">
    <tr>
        <td class="highlight3" align="right" width="185"><asp:Label ID="labelReportsToPosition" runat="server" ToolTip="Reports to Position:" Text="Reports to Position:" AssociatedControlID="literalReportsToPositionTitleLineItem" />
            &nbsp;<custom:tooltip ID="tooltipReportsToPosition" runat="server" ToolTipID="246" /></td>
        <td class="highlight3"><asp:Literal ID="literalReportsToPositionTitleLineItem" runat="server" /></td>
    </tr>
    <tr>
        <td class="highlight3" align="right"><asp:Label ID="labelPrimaryOrgCode" runat="server" ToolTip="Primary Org Code:" Text="Primary Org Code:" AssociatedControlID="literalPrimaryOrgCode" />
            &nbsp;<custom:tooltip ID="tooltipPrimaryOrgCode" runat="server" ToolTipID="247" /></td>
        <td class="highlight3"><asp:Literal ID="literalPrimaryOrgCode" runat="server" /></td>
    </tr>
    <tr id="rowChildOrgCodes" runat="server">
        <td width="200" align="right">
            <asp:Label ID="labelChildOrgCodes" runat="server" ToolTip="Child Org Codes:" Text="Child Org Codes:" AssociatedControlID="dropDownChildOrgCodes" />
            &nbsp;<custom:tooltip ID="tooltipChildOrgCodes" runat="server" ToolTipID="248" />
        </td>
        <td>
            <telerik:RadComboBox ID="dropDownChildOrgCodes" runat="server" Width="575px" autopostback="true" />

            <div class="ajaxLoaderIcon" style="right: 165px;">
                <telerik:RadAjaxLoadingPanel ID="ajaxLoadingChildOrgCodes" runat="server" SkinID="ajaxLoaderIcon">
                <asp:Image ID="imageLoaderChildOrgCodes" runat="server" SkinID="ajaxLoaderBlue" />
                </telerik:RadAjaxLoadingPanel>
            </div>
        
        </td>
    </tr>
    <tr>
        <td align="right">
        <asp:Label ID="labelAvailablePositions" runat="server" ToolTip="Available Positions:" Text="Available Positions:" AssociatedControlID="listBoxPositions" />
            <span class="required">*</span> &nbsp;<custom:tooltip ID="tooltipSelectedPositions" runat="server" ToolTipID="249" />
            </td>
        <td>Select the positions to be included into the organization chart by checking the desired selections below.</td>
    </tr>
    <tr>
        <td></td>
        <td>
            <asp:Panel ID="panelNoPositions" runat="server" visible="false">
            <div class="highlight3"><span class="highlightText"><asp:Literal ID="literalNoPositionsMessage" runat="server" /></span></div>
            </asp:Panel>
             <telerik:RadListBox ID="listboxPositions" runat="server" CheckBoxes="true" Width="725" Height="350px" />
             <asp:CustomValidator ID="customValSelectedPositions" runat="server" ErrorMessage="You must select at least one position from the list." 
                    EnableClientScript="true" ClientValidationFunction="customValAtLeastOneSelected" ValidateEmptyText="true" 
                    ValidationGroup="IncludePositions" Display="None" />
        </td>
    </tr>    
    <tr>
        <td></td>
        <td class="cellAdjustment">
        <asp:Button ID="buttonInclude" runat="server" Text="Include Selected Positions" CssClass="button" CausesValidation="true" ValidationGroup="IncludePositions" Width="225px" />&nbsp;
        <asp:Button ID="buttonCancel" runat="server" Text="Cancel" CssClass="button" CausesValidation="false" Width="125px" />
        </td>
    </tr>
</table>

<br />
<asp:Button ID="buttonChartPositions" runat="server" Text="Chart Positions" CssClass="button" CausesValidation="false" Width="175px" />
<asp:Button ID="buttonOrganizationChartDetails" runat="server" Text="Organization Chart Manager" CssClass="button" CausesValidation="false" Width="225px" />
<br /><br />

</asp:panel>
