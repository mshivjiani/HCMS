<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlCopyJNP.ascx.cs"
    Inherits="HCMS.JNP.Controls.Package.ctrlCopyJNP" %>
<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="tooltip" %>
<asp:ValidationSummary ID="valSummary" runat="server" CssClass="validationMessageBox"
    ShowSummary="true" HeaderText="<span class='systemMessage'>Validation Message</span><br>"
    DisplayMode="BulletList" ValidationGroup="internalValidation" />
<telerik:RadAjaxManager ID="mainAJAXManager" runat="server" DefaultLoadingPanelID="ajaxLoadingPanelSave">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="dropdownRegion">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="panelMain" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="dropdownOrganizationCode">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="panelMain" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="checkboxIsInterdisciplinary">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="panelMain" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<telerik:RadAjaxLoadingPanel ID="ajaxLoadingPanelSave" runat="server">
</telerik:RadAjaxLoadingPanel>
<asp:Panel ID="panelMain" runat="server">
    <telerik:RadCodeBlock ID="RadCodeBlockClientFns" runat="server">
        <script type="text/javascript">

            function ValidateRecruitmentOptions(sender, eventArgs) {

                var chkDEU = document.getElementById("<%=checkboxDEU.ClientID %>");
                var chkMeritPromotion = document.getElementById("<%= checkboxMP.ClientID %>");
                var chkExpectedService = document.getElementById("<%= checkboxException.ClientID %>");

                eventArgs.IsValid = true;

                if (!chkDEU.checked && !chkMeritPromotion.checked && !chkExpectedService.checked) {

                    eventArgs.IsValid = false;

                }
            }

            function CheckMP(DEU) {

                if (DEU.checked) {
                    document.getElementById("<%= checkboxMP.ClientID %>").checked = true;
                }
                return false;
            }
        </script>
    </telerik:RadCodeBlock>
    <table class="blueTable" border="0" width="100%">
        <!--Template JNP info-->
        <tr>
            <td>
                Copy From Package:&nbsp;<tooltip:ToolTip ID="ToolTip6" runat="server" ToolTipID="156" />
            </td>
            <td colspan="3">
                <asp:Literal ID="literalExistingJNPID" runat="server"></asp:Literal>
            </td>
        </tr>
        <!-- Pay Plan -->
        <tr>
            <td>
                Pay Plan:&nbsp;<tooltip:ToolTip ID="ToolTip1" runat="server" ToolTipID="2" />
            </td>
            <td colspan="3">
                <asp:Literal ID="literalPayPlan" runat="server" />
            </td>
        </tr>
        <!-- series -->
        <tr>
            <td>
                Series:&nbsp;<tooltip:ToolTip ID="ToolTip3" runat="server" ToolTipID="4" />
            </td>
            <td colspan="3">
                <asp:Literal ID="literalSeries" runat="server" />
            </td>
        </tr>
        <!-- one grade/two grade Package-->
        <tr>
            <td>
                JAX Grade Level:&nbsp;<tooltip:ToolTip ID="ToolTip7" runat="server" ToolTipID="184" />
            </td>
            <td colspan="3">
                <asp:Literal ID="literalTwoGrade" runat="server" />
            </td>
        </tr>
        <!--Grades-->
        <tr>
            <td nowrap="nowrap" valign="top">
                Advertised Grade:&nbsp;<tooltip:ToolTip ID="ToolTip8" runat="server" ToolTipID="185" />
            </td>
            <td>
                Highest Advertised Grade:
                <asp:Literal ID="literalHighGrade" runat="server" />
            </td>
            <td colspan="2">
                <span id="spanLowestAdvertisedGrade" runat="server" visible="false">Lowest Advertised
                    Grade:
                    <asp:Literal ID="literalLowGrade" runat="server" />
                </span>
            </td>
        </tr>
        <!-- InterDisciplinary and Additional Series -->
        <tr>
            <td valign="top">
                Interdisciplinary: &nbsp;&nbsp;<tooltip:ToolTip ID="ToolTip2" runat="server" ToolTipID="78" />
            </td>
            <td colspan="3" nowrap="nowrap">
                <div style="width: 100%; text-align: left;">
                    <asp:CheckBox ID="checkboxIsInterdisciplinary" runat="server" AutoPostBack="true"
                        Text="Is this JNP Interdisciplinary?" />
                </div>
                <span id="spanAdditionalSeries" runat="server" visible="false">
                    <br />
                    <span style="padding-right: 10px;">Additional Series:</span>
                    <telerik:RadComboBox ID="dropdownAdditionalSeries" runat="server" CausesValidation="false"
                        MarkFirstMatch="true" Width="450px" />
                    <asp:RequiredFieldValidator ID="requiredAdditionalSeriesEmpty" runat="server" ControlToValidate="dropdownAdditionalSeries"
                        Display="None" ErrorMessage="Additional Series is required." InitialValue="[-- Select Pay Plan First --]"
                        ValidationGroup="internalValidation" />
                    <asp:RequiredFieldValidator ID="requiredAdditionalSeriesFull" runat="server" ControlToValidate="dropdownAdditionalSeries"
                        Display="None" ErrorMessage="Additional Series is required." InitialValue="[-- Select Additional Series --]"
                        ValidationGroup="internalValidation" />
                </span>
            </td>
        </tr>
        <!--Region-->
        <tr>
            <td>
                <asp:Label ID="lblRegion" runat="server" AssociatedControlID="dropdownRegion" Text="Region: "
                    ToolTip="Region" /><span class="required">*</span> &nbsp; &nbsp;&nbsp;<tooltip:ToolTip
                        ID="ToolTip75" runat="server" ToolTipID="75" />
            </td>
            <td colspan="3">
                <asp:Literal ID="literalRegion" runat="server" />
                <telerik:RadComboBox ID="dropdownRegion" runat="server" CausesValidation="false"
                    AutoPostBack="true" MarkFirstMatch="true" Width="200px" />
                <asp:RequiredFieldValidator ID="requiredRegion" runat="server" ControlToValidate="dropdownRegion"
                    Display="None" ErrorMessage="Region is required." InitialValue="[-- Select Region --]"
                    ValidationGroup="internalValidation" />
            </td>
        </tr>
        <!-- Organization Code -->
        <tr>
            <td>
                <asp:Label ID="lblOrganizationCode" runat="server" AssociatedControlID="dropdownOrganizationCode"
                    Text="Organization:" ToolTip="Organization"></asp:Label><span class="required">*</span>
                &nbsp;<tooltip:ToolTip ID="ToolTip4" runat="server" ToolTipID="57" />
            </td>
            <td colspan="3" valign="middle">
                <span id="spanOrganizationCode" runat="server"><span style="width: 460px; display: inline-block;">
                    <asp:Literal ID="literalOrgCodeStandardJNP" runat="server" />
                    <span id="spanOrganizationCodeDropdown" runat="server">
                        <telerik:RadComboBox ID="dropdownOrganizationCode" runat="server" AutoPostBack="true"
                            MarkFirstMatch="true" Width="450px" />
                        <asp:RequiredFieldValidator ID="requiredOrganizationCodeEmpty" runat="server" ControlToValidate="dropdownOrganizationCode"
                            Display="None" ErrorMessage="Organization Code is required -- select Region first."
                            InitialValue="[-- Select Region First --]" ValidationGroup="internalValidation" />
                        <asp:RequiredFieldValidator ID="requiredOrganizationCodeFull" runat="server" ControlToValidate="dropdownOrganizationCode"
                            Display="None" ErrorMessage="Organization Code is required." InitialValue="[-- Select Organization Code --]"
                            ValidationGroup="internalValidation" />
                    </span>
                    <!-- end of spanOrganizationCode-->
                </span><span style="display: none">
                    <asp:CheckBox ID="checkboxStandardJNP" runat="server" AutoPostBack="true" Text="Standard JNP" />
                </span></span>
                <!-- end of spanRegionChange-->
            </td>
        </tr>
        <!-- Full PD /Additional PD-->
        <tr>
            <td valign="top" style="white-space: nowrap">
                Position Description(s): <span class="required">*</span> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<tooltip:ToolTip
                    ID="ToolTip10" runat="server" ToolTipID="82" />
            </td>
            <td colspan="3" style="white-space: nowrap">
                <span id="spanPD" runat="server"><span style="margin-right: 10px">Full:</span>
                    <telerik:RadComboBox ID="dropdownFullPD" runat="server" AutoPostBack="true" HighlightTemplatedItems="true"
                        Skin="Office2010Silver" Width="530px">
                        <HeaderTemplate>
                            <table style="width: 100%;">
                                <tr>
                                    <td align="center" style="width: 80px;">
                                        PD ID
                                    </td>
                                    <td align="center">
                                        Title
                                    </td>
                                    <td align="center" style="width: 75px;">
                                        Grade
                                    </td>
                                    <td align="center" style="width: 80px;">
                                        Organization
                                    </td>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table style="width: 100%; text-align: left">
                                <tr>
                                    <td align="center" style="width: 80px;">
                                        <%# Eval( "PositionDescriptionID") %>
                                    </td>
                                    <td>
                                        <%#Eval("OPMJobTitle") %>
                                    </td>
                                    <td align="center" style="width: 75px;">
                                        <%#Eval("ProposedGrade").ToString() != "" ? Eval("ProposedGrade").ToString() + "/" : "" %>
                                        <%# Eval("ProposedFPGrade").ToString() != "" ? Eval("ProposedFPGrade") : "" %>
                                    </td>
                                    <td align="center" style="width: 80px;">
                                        <%#Eval("OrganizationCode") %>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </telerik:RadComboBox>
                    <asp:RequiredFieldValidator ID="requiredFullPDEmpty" runat="server" ControlToValidate="dropdownFullPD"
                        Display="None" ErrorMessage="Full Position Description is required -- select Series, High Grade and Organization Code first."
                        InitialValue="[-- Select Series, High Grade and Organization Code --]" ValidationGroup="internalValidation" />
                    <asp:RequiredFieldValidator ID="requiredFullPDNoMatch" runat="server" ControlToValidate="dropdownFullPD"
                        Display="None" ErrorMessage="Full Position Description is required" InitialValue="[-- No Matching Position Descriptions were found --]"
                        ValidationGroup="internalValidation" />
                    <asp:RequiredFieldValidator ID="requiredFullPD" runat="server" ControlToValidate="dropdownFullPD"
                        Display="None" ErrorMessage="Full Position Description is required" InitialValue="[-- Select Full Position Description --]"
                        ValidationGroup="internalValidation" />
                    <div id="divAdditionalPD" runat="server" visible="false">
                        <br />
                        <span style="margin-right: 10px">Additional:</span>
                        <telerik:RadComboBox ID="dropdownAdditionalPD" runat="server" DataTextField="PositionDescriptionID"
                            DataValueField="PositionDescriptionID" HighlightTemplatedItems="true" Skin="Office2010Silver"
                            Width="530px">
                            <HeaderTemplate>
                                <table style="width: 100%;">
                                    <tr>
                                        <td align="center" style="width: 80px;">
                                            PD ID
                                        </td>
                                        <td align="center">
                                            Title
                                        </td>
                                        <td align="center" style="width: 75px;">
                                            Grade
                                        </td>
                                        <td align="center" style="width: 80px;">
                                            Organization
                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table style="width: 100%; text-align: left">
                                    <tr>
                                        <td align="center" style="width: 80px;">
                                            <%# Eval( "PositionDescriptionID") %>
                                        </td>
                                        <td>
                                            <%#Eval("OPMJobTitle") %>
                                        </td>
                                        <td align="center" style="width: 75px;">
                                            <%#Eval("ProposedGrade").ToString() != "" ? Eval("ProposedGrade").ToString() + "/" : "" %>
                                            <%# Eval("ProposedFPGrade").ToString() != "" ? Eval("ProposedFPGrade") : "" %>
                                        </td>
                                        <td align="center" style="width: 80px;">
                                            <%#Eval("OrganizationCode") %>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </telerik:RadComboBox>
                        <asp:RequiredFieldValidator ID="requiredAdditionalPDEmpty" runat="server" ControlToValidate="dropdownAdditionalPD"
                            Display="None" ErrorMessage="Additional Position Description is required -- select Series, Low Grade and Organization Code first."
                            InitialValue="[-- Select Series, Low Grade and Organization Code --]" ValidationGroup="internalValidation" />
                        <asp:RequiredFieldValidator ID="requiredAdditionalPDNoMatch" runat="server" ControlToValidate="dropdownAdditionalPD"
                            Display="None" ErrorMessage="Additional Position Description is required" InitialValue="[-- No Matching Position Descriptions were found --]"
                            ValidationGroup="internalValidation" />
                        <asp:RequiredFieldValidator ID="requiredAdditionalPD" runat="server" ControlToValidate="dropdownAdditionalPD"
                            Display="None" ErrorMessage="Additional Position Description is required" InitialValue="[-- Select Additional Position Description --]"
                            ValidationGroup="internalValidation" />
                    </div>
                </span>
                <!--end spanPD -->
            </td>
        </tr>
        <!--OPM Title -->
        <tr>
            <td>
                <asp:Label ID="labelJNPTitle" runat="server" Text="OPM Job Title:" ToolTip="OPM Job Title" />&nbsp;<tooltip:ToolTip
                    ID="ToolTip9" runat="server" ToolTipID="7" />
            </td>
            <td colspan="3">
                <asp:Literal ID="literalJNPTitle" runat="server" />
            </td>
        </tr>
        <!-- Duty Location -->
        <tr>
            <td valign="top">
                Duty Location: <span class="required">*</span> &nbsp;<tooltip:ToolTip ID="ToolTip11"
                    runat="server" ToolTipID="40" />
            </td>
            <td colspan="3">
                <telerik:RadTextBox ID="textboxDutyLocation" runat="server" Width="100%" />
                <asp:RequiredFieldValidator ID="requiredDutyLocation" runat="server" ControlToValidate="textboxDutyLocation"
                    Display="None" ErrorMessage="Duty Location is required" ValidationGroup="internalValidation"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <!-- Recruitment Options -->
        <tr>
            <td>
                <asp:Label ID="lblDEU" runat="server" Text="Recruitment Options:" ToolTip="All Sources (DEU only) / Merit Promotion / Excepted Service" />&nbsp;<tooltip:ToolTip
                    ID="ToolTip12" runat="server" ToolTipID="86" />
            </td>
            <td colspan="3">
                <table cellpadding="0" cellspacing="0" class="blueSubTable" width="100%">
                    <colgroup>
                        <col width="25%" />
                        <col width="25%" />
                        <col width="25%" />
                        <tr>
                            <td>
                                <asp:CheckBox ID="checkboxDEU" runat="server" Text="All Sources(DEU only)" onClick="javascript:CheckMP(this);" />
                            </td>
                            <td>
                                <asp:CheckBox ID="checkboxMP" runat="server" Text="Merit Promotion" />
                            </td>
                            <td>
                                <asp:CheckBox ID="checkboxException" runat="server" Text="Excepted Service" />
                            </td>
                            <asp:CustomValidator ID="ValidateRecruitmentOptions" runat="server" Text="*" Display="None"
                                ErrorMessage="Recruitment Option is required." ValidateEmptyText="true" EnableClientScript="true"
                                ClientValidationFunction="ValidateRecruitmentOptions" ValidationGroup="internalValidation"></asp:CustomValidator>
                        </tr>
                    </colgroup>
                </table>
            </td>
        </tr>
    </table>
</asp:Panel>
<br />
<div style="float: right;">
    <asp:Button runat="server" ID="buttonSave" CssClass="button" Text="Save and Continue"
        ToolTip="Save and Continue" CausesValidation="true" ValidationGroup="internalValidation" />
    <asp:Button runat="server" ID="buttonReset" CssClass="button" Text="Reset" ToolTip="Reset"
        CausesValidation="false" />
</div>
<br />
<br />
