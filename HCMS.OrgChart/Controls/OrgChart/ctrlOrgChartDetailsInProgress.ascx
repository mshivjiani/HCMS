<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ctrlOrgChartDetailsInProgress.ascx.cs" Inherits="HCMS.OrgChart.Controls.OrgChart.ctrlOrgChartDetailsInProgress" %>
<%@ Register TagPrefix="custom" TagName="ReadOnlyLabel" Src="~/Controls/Common/readOnlyLabel.ascx" %>
<%@ Register TagPrefix="custom" TagName="OrgChartDetailInformation" Src="~/Controls/OrgChart/Common/orgChartDetailInformation.ascx" %>

<telerik:RadAjaxManagerProxy id="radAjaxManagerProxyMainControl" runat="server">
    <ajaxsettings>
        <telerik:AjaxSetting AjaxControlID="checkboxReplaceRoot">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="panelMain" LoadingPanelID="ajaxLoadingReplaceRoot" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="checkboxSignAs">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="panelMain" LoadingPanelID="ajaxLoadingSignAs" />
            </UpdatedControls>
        </telerik:AjaxSetting> 
        <telerik:AjaxSetting AjaxControlID="checkboxSignAsImport">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="panelMain" LoadingPanelID="ajaxLoadingSignAsImport" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="buttonSaveNewRoot">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="panelMain" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="buttonCancelNewRoot">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="panelMain" LoadingPanelID="ajaxLoadingReplaceRoot" />
            </UpdatedControls>
        </telerik:AjaxSetting>        
        <telerik:AjaxSetting AjaxControlID="buttonDeleteOrgChart">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="panelMain" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="buttonSubmitToDraft">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="panelMain" />
            </UpdatedControls>
        </telerik:AjaxSetting>  
        <telerik:AjaxSetting AjaxControlID="buttonSubmitToReview">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="panelMain" />
            </UpdatedControls>
        </telerik:AjaxSetting>  
        <telerik:AjaxSetting AjaxControlID="buttonSubmitToApprove">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="panelMain" />
            </UpdatedControls>
        </telerik:AjaxSetting>   
        <telerik:AjaxSetting AjaxControlID="buttonSignAndPublish">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="panelMain" />
            </UpdatedControls>
        </telerik:AjaxSetting> 
    </ajaxsettings>
</telerik:RadAjaxManagerProxy>

<asp:Panel ID="panelMain" runat="server">
<custom:ReadOnlyLabel id="customReadOnlyLabel" runat="server" LabelText="In Process Chart -- Read-Only View" />
<custom:OrgChartDetailInformation id="customOrgChartDetails" runat="server" ShowTopLevelPosition="false" />

<br />
<div><hr class="separator" /></div><br /> 
<div class="highlight1">Additional Organizaton Chart Information</div>
<br />

    <table class="blueTable" width="100%">    
    <tr>
        <td width="185" class="highlight3">Top Level Position:<custom:ToolTip ID="toolTipTopLevelPosition" runat="server" ToolTipID="205" /></td>
        <td class="highlight3"><asp:Literal ID="literalTopLevelPosition" runat="server" /></td>
    </tr>

    <tr id="rowReplaceRoot" runat="server">
        <td></td>
        <td>
            <div class="highlight3"><asp:CheckBox ID="checkboxReplaceRoot" runat="server" Text="Replace Top Level Position" AutoPostBack="true" />
                <div class="ajaxLoaderIcon" style="right: 580px;">
                    <telerik:RadAjaxLoadingPanel ID="ajaxLoadingReplaceRoot" runat="server" SkinID="ajaxLoaderIcon">
                    <asp:Image ID="imageLoaderReplaceRoot" runat="server" SkinID="ajaxLoaderBlue" />
                    </telerik:RadAjaxLoadingPanel>
                </div>
            </div>

            <asp:Panel ID="panelReplaceRootOuter" runat="server">
            <asp:Panel ID="panelReplaceRoot" runat="server" Visible="false">
                <br />

                <asp:ValidationSummary ID="valSummary" runat="server" CssClass="validationMessageBox"
                            ShowSummary="true" HeaderText="<span class='errorMessage'>Validation Message</span><br>"
                            DisplayMode="BulletList" ValidationGroup="ReplaceRoot" />

                <table class="noBorderInnerTable">
                    <tr>
                        <td width="150">New Top Level Position:<custom:ToolTip ID="toolTipNewTopLevelPosition" runat="server" ToolTipID="206" /></td>
                        <td><telerik:radcombobox id="dropDownPositions" runat="server" width="400px" />
                        
                                <asp:RequiredFieldValidator ID="requiredPosition" runat="server" 
                                    ControlToValidate="dropDownPositions" InitialValue="<<-- Select New Top Level Position -->>" ErrorMessage="You must select the new top level position to replace the current one for the selected organization chart."
                                    Display="None" ValidationGroup="ReplaceRoot" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td class="cellAdjustment">
                            <asp:Button ID="buttonSaveNewRoot" runat="server" OnClientClick="customConfirmWithValidation(this, 'Are you sure you want to save the newly selected top level position?', 'Confirm Top Position Replacement', null, 'ReplaceRoot'); return false;" Text="Save New Top Position" CssClass="button" CausesValidation="true" Width="175px" ValidationGroup="ReplaceRoot" />
                            <asp:Button ID="buttonCancelNewRoot" runat="server" Text="Cancel" CssClass="button" CausesValidation="false" Width="125px" ValidationGroup="ReplaceRoot" /></td>
                    </tr>
                </table>
            </asp:Panel>
            </asp:Panel>
        </td>
    </tr>    
    <tr>
        <td>Primary Org Code Location:<custom:ToolTip ID="toolTipOrgCodeLocation" runat="server" ToolTipID="207" /></td>
        <td><asp:Literal ID="literalOrgCodeLocation" runat="server" /></td>
    </tr>
    
    <tr>
        <td>Current Workflow Status:<custom:ToolTip ID="toolTipWorkflowStatus" runat="server" ToolTipID="208" /></td>
        <td class="highlightText"><asp:Literal ID="literalWorkflowStatus" runat="server" /></td>
    </tr>
    <tr id="rowCheckedOut" runat="server" visible="false">
        <td>Currently Checked Out By:<custom:ToolTip ID="toolTipCheckedOutBy" runat="server" ToolTipID="209" /></td>
        <td><asp:Literal ID="literalCheckedOutBy" runat="server" /></td>
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

    <tr id="rowPublish" runat="server">
        <td class="highlight3">Sign & Publish</td>
        <td>
        
        <asp:ValidationSummary ID="valSummarySignAndPublish" runat="server" CssClass="validationMessageBox"
                    ShowSummary="true" HeaderText="<span class='errorMessage'>Validation Message</span><br>"
                    DisplayMode="BulletList" ValidationGroup="SignAndPublish" />
            <table border="0">
                <tr>
                    <td colspan="3">
                        <div class="highlight3"><asp:CheckBox ID="checkboxSignAs" runat="server" Text="Sign As/For Another" AutoPostBack="true" />
                        <div class="ajaxLoaderIcon" style="right: 165px;">
                            <telerik:RadAjaxLoadingPanel ID="ajaxLoadingSignAs" runat="server" SkinID="ajaxLoaderIcon">
                                <asp:Image ID="image1" runat="server" SkinID="ajaxLoaderBlue" />
                            </telerik:RadAjaxLoadingPanel>
                        </div>
                    </div>
                    </td>
                </tr>
                <tr id="rowSignAsSystemImport" runat="server" visible="false">
                    <td></td>
                    <td></td>
                    <td>
                    <asp:CheckBox ID="checkboxSignAsImport" runat="server" Text="Sign As System Import" AutoPostBack="true" />

                    <div class="ajaxLoaderIcon" style="right: 35px;">
                            <telerik:RadAjaxLoadingPanel ID="ajaxLoadingSignAsImport" runat="server" SkinID="ajaxLoaderIcon">
                                <asp:Image ID="image2" runat="server" SkinID="ajaxLoaderBlue" />            
                            </telerik:RadAjaxLoadingPanel>
                        </div>
                    </td>
                </tr>                
                <tr id="rowSignAsFor" runat="server" visible="false">
                    <td width="15"></td>
                    <td width="130">Signing As/For:<custom:ToolTip ID="toolTipSigningFor" runat="server" ToolTipID="214" /></td>
                    <td ><asp:TextBox ID="textboxSigningAsFor" runat="server" Width="200px" />
                    <asp:RequiredFieldValidator ID="requiredSignAsFor" runat="server" ControlToValidate="textboxSigningAsFor" 
                        ValidationGroup="SignAndPublish" ErrorMessage="The 'Signing As/For' name is a required field." Display="None" />
                    </td>
                </tr>                
                <tr>
                    <td width="15"></td>
                    <td width="130" style="border-bottom-style: none;">Enter Password:<custom:ToolTip ID="toolTipSignPassword" runat="server" ToolTipID="215" /></td>
                    <td style="border-bottom-style: none;">
                    <asp:TextBox ID="textboxPassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="requiredPassword" runat="server" ValidationGroup="SignAndPublish"
                        ControlToValidate="textboxPassword" ErrorMessage="You must enter your Active Directory password to digitally sign this organization chart."
                        Display="None" />
                    <asp:CustomValidator ID="customValPassword" runat="server" ValidationGroup="SignAndPublish" ControlToValidate="textboxPassword" 
                        ErrorMessage="The password you entered is not correct.  You cannot publish this organization chart until you have confirmed your identity with a valid password."
                        Display="None" />
                    </td>
                </tr>
            </table>
        
        </td>
    </tr>
    </table>

    <br />
    <asp:Button ID="buttonChartPositions" runat="server" Text="Chart Positions" CssClass="button" CausesValidation="false" Width="175px" />

    <span ID="spanActionButtons" runat="server">
        <asp:Button ID="buttonDeleteOrgChart" runat="server" OnClientClick="customConfirm(this, 'Are you sure you want to delete this organization chart?', 'Confirm Chart Deletion', 125, null); return false;" Text="Delete Chart" CssClass="button" CausesValidation="false" Width="175px" />
        <asp:Button ID="buttonSubmitToDraft" runat="server" OnClientClick="customConfirm(this, 'Are you sure you want to change the status of this organization chart to Draft?', 'Confirm Change to Draft', null, null); return false;" Text="Submit to Draft" CssClass="button" CausesValidation="false" Width="175px" Visible="false" />

        <span id="spanSubmitActionButtons" runat="server">
        <asp:Button ID="buttonSubmitToReview" runat="server" OnClientClick="customConfirm(this, 'Are you sure you want to submit this organization chart for Review?', 'Confirm Submit for Review', null, null); return false;" Text="Submit to HR Review (Optional)" CssClass="button" CausesValidation="false" Width="225px" Visible="false" />
        <asp:Button ID="buttonSubmitToApprove" runat="server" OnClientClick="customConfirm(this, 'Are you sure you want to submit this organization chart for Approval?', 'Confirm Submit for Approval', null, null); return false;" Text="Submit for Approval" CssClass="button" CausesValidation="false" Width="175px" Visible="false" />
        <asp:Button ID="buttonSignAndPublish" runat="server" OnClientClick="customConfirmWithValidation(this, 'Are you sure you want to publish this chart as an official organization chart?', 'Confirm Publish', null, 'SignAndPublish'); return false;" Text="Sign and Publish" CssClass="button" CausesValidation="true" Width="175px" ValidationGroup="SignAndPublish" Visible="false" />
        </span>
    </span>
    <br /><br />

    </asp:Panel>





