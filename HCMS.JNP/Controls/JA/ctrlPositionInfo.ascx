<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ctrlPositionInfo.ascx.cs"
    Inherits="HCMS.JNP.Controls.JA.ctrlPositionInfo" %>
<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="tooltip" %>
<telerik:RadAjaxManager ID="mainAJAXManager" runat="server" UpdatePanelsRenderMode="Inline">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="checkboxIsInterdisciplinary">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="panelMain" LoadingPanelID="ajaxLoadingPanelSave" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="buttonReset">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="panelMain" LoadingPanelID="ajaxLoadingPanelSave" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<asp:ValidationSummary ID="valSummary" runat="server" CssClass="validationMessageBox"
    ShowSummary="true" HeaderText="<span class='systemMessage'>Validation Message</span><br>"
    DisplayMode="BulletList" ValidationGroup="internalValidation" />
<div id="createJNPMsg" runat="server" class="highlight1bold">
    Job Announcement created successfully.</div>
<br />
<asp:Panel ID="panelMain" runat="server">
    <telerik:RadCodeBlock ID="RadCodeBlockClientFns" runat="server">
        <script type="text/javascript">
            function ValidateDutyLocation(sender, eventArgs) {

                var lblStandard = document.getElementById("<%=lblIsStandardJNP.ClientID %>");
                var txtdutyloc = document.getElementById("<%= textboxDutyLocation.ClientID %>");
                eventArgs.IsValid = true;

                if (lblStandard.innerText != "Standard") {
                    if (txtdutyloc.value == "") {
                        eventArgs.IsValid = false;
                    }

                }


            }

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
        <colgroup>
            <col width="20%" />
            <col width="280px" />
            <col width="*" />
            <col width="225px" />
        </colgroup>
        <tr>
            <td>
                Pay Plan:&nbsp;<tooltip:ToolTip ID="ToolTip1" runat="server" ToolTipID="2" />
            </td>
            <td colspan="2">
                <asp:Literal ID="literalPayPlan" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Series:&nbsp;<tooltip:ToolTip ID="ToolTip3" runat="server" ToolTipID="4" />
            </td>
            <td colspan="2">
                <asp:Literal ID="literalSeries" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Region: &nbsp;<tooltip:ToolTip ID="ToolTip2" runat="server" ToolTipID="75" />
            </td>
            <td colspan="2">
                <asp:Literal ID="literalRegion" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Organization Code:&nbsp;<tooltip:ToolTip ID="ToolTip4" runat="server" ToolTipID="57" />
            </td>
            <td colspan="2">
                <asp:Literal ID="literalOrganizationCode" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                Package Type:&nbsp;<tooltip:ToolTip ID="ToolTip5" runat="server" ToolTipID="77" />
            </td>
            <td colspan="2">
                <asp:Label ID="lblIsStandardJNP" runat="server" />
            </td>
        </tr>
        <tr>
            <td valign="top">
                Interdisciplinary:&nbsp;<tooltip:ToolTip ID="ToolTip6" runat="server" ToolTipID="78" />
            </td>
            <td colspan="2" nowrap="nowrap">
                <div style="width: 100%; text-align: left;">
                    <asp:CheckBox ID="checkboxIsInterdisciplinary" runat="server" AutoPostBack="true"
                        Text="Is this announcement Interdisciplinary?" />
                    <asp:Literal ID="literalIsInterdisciplinary" runat="server" />
                </div>
                <span id="spanAdditionalSeries" runat="server" visible="false">
                    <br />
                    <span style="text-align: right; width: 100px; display: inline-block; padding-right: 10px;">
                        Additional Series:</span>
                    <telerik:RadComboBox ID="dropdownAdditionalSeries" runat="server" CausesValidation="false"
                        MarkFirstMatch="true" Width="450px" />
                    <asp:Literal ID="literalAdditionalSeries" runat="server" />
                    <asp:RequiredFieldValidator ID="requiredAdditionalSeriesEmpty" runat="server" ControlToValidate="dropdownAdditionalSeries"
                        Display="None" ErrorMessage="Additional Series is required -- select Pay Plan first."
                        InitialValue="[-- Select Pay Plan First --]" ValidationGroup="internalValidation" />
                    <asp:RequiredFieldValidator ID="requiredAdditionalSeriesFull" runat="server" ControlToValidate="dropdownAdditionalSeries"
                        Display="None" ErrorMessage="Additional Series is required." InitialValue="[-- Select Additional Series --]"
                        ValidationGroup="internalValidation" />
                </span>
            </td>
        </tr>
        <tr>
            <td>
                JAX Grade Level:&nbsp;<tooltip:ToolTip ID="ToolTip7" runat="server" ToolTipID="184" />
            </td>
            <td colspan="2">
                <asp:Literal ID="literalTwoGrade" runat="server" />
            </td>
        </tr>
        <tr>
            <td nowrap="nowrap" valign="top">
                Advertised Grade:&nbsp;<tooltip:ToolTip ID="ToolTip8" runat="server" ToolTipID="185" />
            </td>
            <td>
                Highest Advertised Grade:
                <asp:Literal ID="literalHighGrade" runat="server" />
            </td>
            <td>
                <span id="spanLowestAdvertisedGrade" runat="server" visible="false">Lowest Advertised
                    Grade:
                    <asp:Literal ID="literalLowGrade" runat="server" />
                </span>
            </td>
        </tr>
        <tr>
            <td>
                Position Description(s):<tooltip:ToolTip ID="ToolTip9" runat="server" ToolTipID="82" />
            </td>
            <td colspan="2" nowrap="nowrap">
                <span style="text-align: right; width: 70px; display: inline-block; padding-right: 10px;">
                    Full:</span>
                <asp:Literal ID="literalFullPD" runat="server" />
                <div id="divAdditionalPD" runat="server" visible="false">
                    <br />
                    <span style="text-align: right; width: 70px; display: inline-block; padding-right: 20px;">
                        Additional:<span style="position: absolute; margin-right: 10px;"><tooltip:ToolTip
                    ID="ToolTip14" runat="server" ToolTipID="83" /></span></span>
                    <asp:Literal ID="literalAdditionalPD" runat="server" />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                OPM Job Title &nbsp;<tooltip:ToolTip ID="ToolTip10" runat="server" ToolTipID="7" />
            </td>
            <td colspan="2">
                <asp:Literal ID="literalJNPTitle" runat="server" />
            </td>
        </tr>
        <tr>
            <td valign="top">
                FPPSPDID:<span id="spanFPPSPDID" runat="server" class="required">*</span>&nbsp;<tooltip:ToolTip
                    ID="ToolTip11" runat="server" ToolTipID="12" />
            </td>
            <td colspan="2">
                <telerik:RadTextBox ID="textBoxFPPSPDID" runat="server" MaxLength="15" Width="100%" />
                <asp:Literal ID="literalFPPSPDID" runat="server" />
                <asp:RequiredFieldValidator ID="requiredFieldFPPSPDID" runat="server" ControlToValidate="textboxFPPSPDID"
                    Display="None" ErrorMessage="FPPSPDID is required." ValidationGroup="internalValidation" />
            </td>
        </tr>
        <tr>
            <td valign="top">
                Duty Location:<span id="spanDutyLocation" runat="server" class="required">*</span>&nbsp;<tooltip:ToolTip
                    ID="ToolTip12" runat="server" ToolTipID="40" />
            </td>
            <td colspan="2">
                <telerik:RadTextBox ID="textboxDutyLocation" runat="server" Width="100%" />
                <asp:Literal ID="literalDutyLocation" runat="server" />
                <asp:CustomValidator ID="customValtextboxDutyLocation" runat="server" ClientValidationFunction="ValidateDutyLocation"
                    ControlToValidate="textboxDutyLocation" Display="None" EnableClientScript="true"
                    ErrorMessage="Duty Location is required." Text="*" ValidateEmptyText="true" ValidationGroup="internalValidation"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDEU" runat="server" Text="Recruitment Options:" ToolTip="All Sources (DEU only) / Merit Promotion / Excepted Service" />
                <span id="spanRecruitmentOptions" runat="server" class="required">*</span>&nbsp;<tooltip:ToolTip
                    ID="ToolTip13" runat="server" ToolTipID="86" />
            </td>
            <td colspan="2">
                <div id="divAttributes" runat="server">
                    <table cellpadding="0" cellspacing="0" class="blueSubTable" width="100%">
                        <colgroup>
                            <col width="25%" />
                            <col width="25%" />
                            <col width="25%" />
                            <tr>
                                <td>
                                    <asp:CheckBox ID="checkboxDEU" runat="server" Text="All Sources (DEU only)" OnCheckedChanged="checkboxDEU_checkChanged" onClick="javascript:CheckMP(this);" />
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
                </div>
                <div id="divAttributesReadOnly" runat="server">
                    <table cellpadding="0" cellspacing="0" class="blueSubTable" width="100%">
                        <colgroup>
                            <col width="25%" />
                            <col width="25%" />
                            <col width="25%" />
                            <tr>
                                <td>
                                    Is DEU:
                                    <asp:Literal ID="literalIsDeu" runat="server" />
                                </td>
                                <td>
                                    Is MP:
                                    <asp:Literal ID="literalIsMP" runat="server" />
                                </td>
                                <td>
                                    Is Excepted:
                                    <asp:Literal ID="literalIsException" runat="server" />
                                </td>
                               
                            </tr>
                        </colgroup>
                    </table>
                </div>
            </td>
        </tr>
    </table>
</asp:Panel>
<br />
<div style="float: right;">
    <asp:Button ID="buttonSaveAndContinue" runat="server" Text="Save and Continue" ToolTip="Save and Continue"
        CssClass="button" CausesValidation="true" ValidationGroup="internalValidation" />
    <asp:Button runat="server" ID="buttonReset" CssClass="button" Text="Reset" ToolTip="Reset"
        CausesValidation="false" />
</div>
<br />
<br />
<style type="text/css">
    .confirmDeleteCR
    {
        display: block;
        background-color: White;
        text-align: left;
        width: 300px;
        height: 150px;
        padding: 10px 10px 10px 10px;
    }
</style>
<telerik:RadWindowManager ID="RadWindowManager1" runat="server">
</telerik:RadWindowManager>
<telerik:RadWindow ID="rwConfirmDeleteCR" Skin="WebBlue" runat="server" VisibleOnPageLoad="false"
    VisibleTitlebar="True" VisibleStatusbar="false" Modal="true" Width="340" Height="190" Title ="Delete Category Rating?"  Behaviors ="Close" 
    Left="100" Top="100">
    <ContentTemplate>
        <div runat="server" id="divConfirmDeleteCR">
        <br />
            Category Rating is now optional. Do you want to delete the Category Rating?<br />
            <br />
            Select OK to delete this document or Cancel to keep it.<br />
            <br />
            <div style="text-align: center;">
                <asp:Button ID="btnConfirmDeleteCR_OK" OnClick="btnConfirmDeleteCR_OK_Click" runat="server"
                    Text="OK" />&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnConfirmDeleteCR_Cancel" OnClick="btnConfirmDeleteCR_Cancel_Click"
                    runat="server" Text="Cancel" />
            </div>
        </div>
    </ContentTemplate>
</telerik:RadWindow>
