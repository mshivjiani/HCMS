<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ctrlCreateOrgChartNew.ascx.cs" Inherits="HCMS.OrgChart.Controls.OrgChart.ctrlCreateOrgChartNew" %>

<telerik:RadAjaxManagerProxy ID="radAjaxManagerMain" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="dropDownChartTypes">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="panelMain" LoadingPanelID="ajaxLoadingChartTypes" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="radioListOrgCode">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="panelOrgCode" LoadingPanelID="ajaxLoadingPanelOrgCodes" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="dropDownOrganizationCodes">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="panelOrgCode" LoadingPanelID="ajaxLoadingPanelOrgCodes" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="radioListRootNode">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="panelOrgCode" LoadingPanelID="ajaxLoadingRootNode" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManagerProxy>

<telerik:RadAjaxLoadingPanel ID="ajaxLoadingPanelSave" runat="server" />

<asp:Panel ID="panelMain" runat="server">
    <table class="blueTable" width="100%">
    <tr>
            <td align="right" width="225">
                <asp:Label ID="labelChartTypes" runat="server" AssociatedControlID="dropDownChartTypes"
                    Text="Chart Type:" ToolTip="Chart Type:" />
                <span class="required">*</span> &nbsp;<custom:ToolTip ID="toolTipOrganizationChartType"
                    runat="server" ToolTipID="201" />
            </td>
            <td>
                <telerik:RadComboBox ID="dropDownChartTypes" runat="server" Width="300px" AutoPostBack="true" CausesValidation="false"  />
                
                <div class="ajaxLoaderIcon" style="right: 405px;">
                    <telerik:RadAjaxLoadingPanel ID="ajaxLoadingChartTypes" runat="server" SkinID="ajaxLoaderIcon">
                        <asp:Image ID="image1" runat="server" SkinID="ajaxLoaderBlue" />
                    </telerik:RadAjaxLoadingPanel>
                </div>
                                        
                <asp:RequiredFieldValidator ID="requiredChartTypes" runat="server" ControlToValidate="dropDownChartTypes"
                    InitialValue="<<-- Select Organization Chart Type -->>" ErrorMessage="The 'Organization Chart Type' is a required field."
                    Display="None" />
            </td>
        </tr>

        <tr>
            <td align="right">
                <asp:Label ID="labelOrganizationCodes" runat="server" AssociatedControlID="dropDownOrganizationCodes" Text="Primary Organization Code:" ToolTip="Primary Organization Code:" />
                <span class="required">*</span> &nbsp;<custom:ToolTip ID="toolTipOrganizationCode" runat="server"
                    ToolTipID="200" />              
            </td>
            <td>
                <span class="boldText"><asp:Literal ID="literalOrgCodeListMessage" runat="server" Visible="true">Please select a chart type from the list above.</asp:Literal></span>

                <asp:panel ID="panelOrgCode" runat="server">
                <asp:panel ID="panelOrgCodeInner" runat="server" Visible="false">

                    <asp:RadioButtonList ID="radioListOrgCode" runat="server" RepeatDirection="Horizontal" AutoPostBack="true">
                        <asp:ListItem Text="Old Org Code" Value="1" Selected="True" />
                        <asp:ListItem Text="New Org Code" Value="2" />
                    </asp:RadioButtonList>

                    <telerik:RadComboBox ID="dropDownOrganizationCodes" runat="server" Width="650px" AutoPostBack="true" CausesValidation="false" />
                    <div class="ajaxLoaderIcon" style="right: 50px;">
                        <telerik:RadAjaxLoadingPanel ID="ajaxLoadingPanelOrgCodes" runat="server" SkinID="ajaxLoaderIcon">
                            <asp:Image ID="imageChartTypeLoader" runat="server" SkinID="ajaxLoaderBlue" />
                        </telerik:RadAjaxLoadingPanel>
                    </div>

                    <asp:RequiredFieldValidator ID="requiredOrganizationCode" runat="server" ControlToValidate="dropDownOrganizationCodes"
                        InitialValue="<<-- Select Organization Code -->>" ErrorMessage="The 'Organization Code' is a required field."
                        Display="None" />

                        <asp:Panel ID="panelInProcessChart" runat="server" Visible="false">
                            <br />
                            <div class="boldText">An Org Chart is already in-progress for this Org Code and selected chart type.  You can either continue editing the existing Org Chart or delete this and create a new one.  Use the links below to view this organization chart.</div><br />
                            <div class="boldText"><asp:HyperLink ID="linkTracker" runat="server" Text="My Tracker" NavigateUrl="~/Tracker/OrgChartTracker.aspx" /> | <asp:HyperLink ID="linkChartSearch" runat="server" Text="Organization Chart Search" NavigateUrl="~/" /></div>
                        </asp:Panel>

                        <asp:Panel ID="panelPublishedChart" runat="server" Visible="false">
                            <br />
                            <div class="boldText">The organization chart you selected has a published version of this chart already on record.   Click the 
                            'Create New Chart' button below to create a new organization chart based on the existing published chart.</div>
                        </asp:Panel>

                        <asp:Panel ID="panelNoInProcessNoPublished" runat="server" Visible="false">
                            <br />
                            <div class="boldText">
                            There is no existing organization chart of this type for this organization code.  To continue and create a new 
                            organization chart, please select the root node from the list of existing positions or select the option to create a default 
                            workforce planning position as a top level position (if you choose this option, you will be redirected to immediately update the information for
                            the new root node position).
                            </div><br />

                            <table class="noBorderInnerTable" width="100%">
                            <tr>
                            <td width="545" valign="top">
                                <asp:RadioButtonList ID="radioListRootNode" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" Width="540">
                                    <asp:ListItem Text="Select Root Node from the List Below" Value="1" Selected="True" />
                                    <asp:ListItem Text="Create a New [Default] WFP Position as Root Node" Value="2" />
                                </asp:RadioButtonList>                            
                            </td>
                            <td align="left">
                                <div class="ajaxLoaderIcon" style="right: 165px;">
                                    <telerik:RadAjaxLoadingPanel ID="ajaxLoadingRootNode" runat="server" SkinID="ajaxLoaderIcon">
                                        <asp:Image ID="image2" runat="server" SkinID="ajaxLoaderBlue" />            
                                    </telerik:RadAjaxLoadingPanel>
                                </div>
                            </td>
                            </tr>
                            </table>

                            <asp:Panel ID="panelRootNodeSelection" runat="server">
                            <table class="noBorderInnerTable" width="100%">
                            <tr>
                                <td align="left" width="145">Top Level Position:<span class="required">*</span> &nbsp;<custom:ToolTip ID="toolTipTopLevelPosition" runat="server" ToolTipID="205" /></td>
                                <td>
                                <telerik:RadComboBox ID="dropDownRootPositions" runat="server" Width="500px" />

                                <asp:RequiredFieldValidator ID="requiredRootPosition" runat="server" 
                                    ControlToValidate="dropDownRootPositions" InitialValue="<<-- Select Top Level Position -->>" ErrorMessage="You must select the top level position for this organization chart."
                                    Display="None" />
                                </td>
                            </tr>
                            </table>
                            </asp:Panel>

                            <asp:Panel ID="panelRootNodeCreateWFP" runat="server" visible="false">
                            <div class="boldText"><div class="highlightText">You will be required to acknowledge the newly created WFP position by confirming the position information on the details screen.  You will not be able to submit
                            this organization chart to the next status or publish it until the position information is confirmed.</div></div>
                            </asp:Panel>
                        </asp:Panel>
                </asp:panel>
                </asp:panel>
            </td>
        </tr>
        
        <tr>
            <td colspan="2">
                &nbsp;
                <br />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="buttonSave" runat="server" Text="Create New Chart" CssClass="button"
                    CausesValidation="true" Enabled="false" Width="175px" />&nbsp;
                <asp:Button ID="buttonCancel" runat="server" Text="Cancel" CssClass="button" CausesValidation="false"
                    Width="125px" />
            </td>
        </tr>
    </table>
</asp:Panel>
