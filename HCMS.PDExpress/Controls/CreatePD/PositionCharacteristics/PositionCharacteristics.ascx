<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PositionCharacteristics.ascx.cs" Inherits="HCMS.PDExpress.Controls.CreatePD.PositionCharacteristics.PositionCharacteristics" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="pde" %>
<%@ Register Src="~/Controls/CreatePD/CareerLadderBundle.ascx" TagName="CareerLadderBundle"
    TagPrefix="CL" %>

<script type="text/javascript" language="javascript">
</script>

<asp:ValidationSummary ID="CharacteristicsValSumm" runat="server" CssClass="validationMessageBox" ShowSummary="true" HeaderText="<span class='systemMessage'>Validation Message</span><br>" DisplayMode="BulletList" />

<table id="characteristicsTable" width="100%" class="blueTable">
<col width="26%" valign="top" />
<col width="26%" />
<col width="24%" valign="top" />
<col width="24%" />
    <tr>
        <td>
            Department/Agency or Establishment :  <pde:ToolTip ID="ToolTip33" runat="server" ToolTipID="33"/> 
        </td>
        <td>
            <asp:Label ID="lblEstablishment" runat="server" />
        </td>
        <td>
            Third Subdivision :  <pde:ToolTip ID="ToolTip36" runat="server" ToolTipID="36"/>
        </td>
        <td>
            <asp:Label ID="lblThirdSubdivision" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            First Subdivision :  <pde:ToolTip ID="ToolTip34" runat="server" ToolTipID="34"/>
        </td>
        <td>
            <asp:Label ID="lblFirstSubdivision" runat="server" />
        </td>
        <td>
            Fourth Subdivision :  <pde:ToolTip ID="ToolTip37" runat="server" ToolTipID="37"/>
        </td>
        <td>
            <asp:TextBox ID="txtFourthSubdivision" runat="server" Width="180" />
        </td>
    </tr>
    <tr>
        <td>
            Second Subdivision :  
            &nbsp;
            <span id="spnStarSecondSubdivision" runat="server" class="required">*</span>
            <pde:ToolTip ID="ToolTip35" runat="server" ToolTipID="35"/>
        </td>
        <td>
            <asp:TextBox ID="txtSecondSubdivision" runat="server" Width="180" />
            <asp:RequiredFieldValidator ID="txtSecondSubdivisionReqVal" runat="server" ControlToValidate="txtSecondSubdivision" Display="None" InitialValue="" ErrorMessage="Second Subdivision is required" />
        </td>
        <td>
            Fifth Subdivision :  <pde:ToolTip ID="ToolTip38" runat="server" ToolTipID="38"/>
        </td>
        <td>
            <asp:TextBox ID="txtFifthSubdivision" runat="server" Width="180" />
        </td>
    </tr>
    <tr>
        <td>
            Employing Office Location :  
            &nbsp;
            <span id="spnStarEmpOfficeLocation" runat="server" class="required">*</span>
            <pde:ToolTip ID="ToolTip39" runat="server" ToolTipID="39"/>
        </td>
        <td>
            <asp:TextBox ID="txtEmpOfficeLocation" runat="server" Width="180" />
            <asp:RequiredFieldValidator ID="txtEmpOfficeLocationReqVal" runat="server" ControlToValidate="txtEmpOfficeLocation" Display="None" InitialValue="" ErrorMessage="Employee Office Location is required" />
        </td>
        <td>
            Duty Location :  
            &nbsp;
            <span id="spnStarDutyLocation" runat="server" class="required">*</span>
            <pde:ToolTip ID="ToolTip40" runat="server" ToolTipID="40"/>
        </td>
        <td>
            <asp:TextBox ID="txtDutyLocation" runat="server" Width="180" />
            <asp:RequiredFieldValidator ID="txtDutyLocationReqVal" runat="server" ControlToValidate="txtDutyLocation" Display="None" InitialValue="" ErrorMessage="Duty Location is required" />
        </td>
    </tr>
    <tr>
        <td>
            Subject to IA Action :  
            &nbsp;
            <span class="required">*</span>
            <pde:ToolTip ID="ToolTip28" runat="server" ToolTipID="28"/>
        </td>
        <td class="noBorder">
            <asp:RadioButtonList ID="rblSubjectToIAAction" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text="Yes" Value="Y" />
                <asp:ListItem Text="No" Value="N" />
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="rblSubjectToIAActionReqVal" runat="server" ControlToValidate="rblSubjectToIAAction" Display="None" InitialValue="" ErrorMessage="Subject to IA action is required" />
        </td>
        <td>
            Reason For Submission :  
            &nbsp;
            <span class="required">*</span>
            <pde:ToolTip ID="ToolTip30" runat="server" ToolTipID="30"/>
        </td>
        <td>
            <telerik:RadComboBox ID="ddlReasonForSubmission" runat="server" Width="185" />    
            <asp:RequiredFieldValidator ID="ddlReasonForSubmissionReqVal" runat="server" ControlToValidate="ddlReasonForSubmission" Display="None" InitialValue="" ErrorMessage="Reason For Submission is required"  />
        </td>
    </tr>
</table>

<br />
<asp:Panel ID="forHRPanel" runat="server" Visible="false">
<br />
<div class="sectionTitle">For HR Purposes Only</div>

<table id="forHRTable" class="blueTable" width="100%">
<col width="26%" valign="top" />
<col width="26%" />
<col width="24%" valign="top" />
<col width="24%" />
    <tr>
        <!-- row #6 -->
        <td>
            Bargaining Unit Status:
            <span class="required" style="display:inline;" id="spnBargaininigUnitStatus" runat="server"></span>
            <pde:ToolTip ID="ToolTip29" runat="server" ToolTipID="29"/>
        </td>
        <td>
            <asp:TextBox ID="txtBargaininigUnitStatus" runat="server" Width="180"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtBargaininigUnitStatusReqVal" runat="server" ControlToValidate="txtBargaininigUnitStatus" Display="None" InitialValue="" ErrorMessage="Bargaininig Unit Status is required" />
        </td>
        <td>
            Service :  
            <span class="required" style="display:inline;" id="spnService" runat="server"></span>
            <pde:ToolTip ID="ToolTip31" runat="server" ToolTipID="31"/>
        </td>
        <td>
            <telerik:RadComboBox ID="ddlService" runat="server" Width="185" />
            <asp:RequiredFieldValidator ID="ddlServiceReqVal" runat="server" ControlToValidate="ddlService" Display="None" InitialValue="" ErrorMessage="Service is required" />
        </td>
    </tr>
    <tr>
        <!-- row #7 -->
        <td>
            Fair Labor Standards Act :  
            <span class="required" style="display:inline;" id="spnFairLaborStandardsAct" runat="server"></span>
            <pde:ToolTip ID="ToolTip24" runat="server" ToolTipID="24"/>
        </td>
        <td class="noBorder" valign="top">
            <asp:RadioButtonList ID="rblFairLaborStandardsAct" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text="Exempt" Value="1" />
                <asp:ListItem Text="Non-Exempt" Value="2" />
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="rblFairLaborStandardsActReqVal" runat="server" ControlToValidate="rblFairLaborStandardsAct" Display="None" InitialValue="" ErrorMessage="Fair Labor Standards Act is required" />
        </td>
        <td>
            Financial Statements<br />Required? :  
            <span class="required" style="display:inline;" id="spnFinancialStatementsRequired" runat="server"></span>
            <pde:ToolTip ID="ToolTip25" runat="server" ToolTipID="25"/>
        </td>
        <td class="noBorder" valign="top">
            <asp:RadioButtonList ID="rblFinancialStatementsRequired" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text="Yes" Value="1" />
                <asp:ListItem Text="No" Value="0" />
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="rblFinancialStatementsRequiredReqVal" runat="server" ControlToValidate="rblFinancialStatementsRequired" Display="None" InitialValue="" ErrorMessage="Financial Statement is required" />
        </td>
    </tr>
    <!-- row #8 -->
    <!-- row #9 -->
    <tr>
        <td>
            Position Status :
            <span class="required" style="display:inline;" id="spnPositionStatus" runat="server"></span>
            <pde:ToolTip ID="ToolTip22" runat="server" ToolTipID="22" />
        </td>
        <td>
            <telerik:RadComboBox ID="ddlPositionStatus" runat="server" Width="185" />
            <asp:RequiredFieldValidator ID="ddlPositionStatusReqVal" runat="server" ControlToValidate="ddlPositionStatus" Display="None" InitialValue="" ErrorMessage="Position Status is required" />
        </td>
        <td>
            Position Status Remarks:
            <pde:ToolTip ID="ToolTip23" runat="server" ToolTipID="23" />
        </td>
        <td>
            <asp:TextBox ID="txtPositionStatusRemarks" runat="server" Rows="2" TextMode="MultiLine" Width="180" />
        </td>
        </tr>
        <tr>
            <!-- row #10 -->
            <td>
                Competitive Level Code :
                <pde:ToolTip ID="ToolTip32" runat="server" ToolTipID="32" />
            </td>
            <td>
                <asp:TextBox ID="txtCompetitiveLevelCode" runat="server" Width="180" />
                <asp:RequiredFieldValidator ID="txtCompetitiveLevelCodeReqVal" runat="server"  Enabled="false" ControlToValidate="txtCompetitiveLevelCode" Display="None" InitialValue="" ErrorMessage="Competitive Level Code is required" />
            </td>
            <td>
                Position Sensitivity :
                <span class="required" style="display:inline;" id="spnPositionSensitivity" runat="server"></span>
                <pde:ToolTip ID="ToolTip21" runat="server" ToolTipID="21" />
            </td>
            <td>
                <asp:HyperLink ID="hlOPMSensitivityTool" runat ="server" Target="_blank" NavigateUrl="http://www.opm.gov/investigate/resources/position/Introduction.aspx" Text="OPM Position Designation Tool"></asp:HyperLink>
                <telerik:RadComboBox ID="ddlPositionSensitivity" runat="server" Width="185" />
                <asp:RequiredFieldValidator ID="ddlPositionSensitivityReqVal" runat="server" ControlToValidate="ddlPositionSensitivity" Display="None" InitialValue="" ErrorMessage="Position Sensitivity is required" />
            </td>
        </tr>
        <tr>
            <!-- row #11 -->
            <td>
                Drug Testing Required :
                <span class="required" style="display:inline;" id="spnDrugTestingRequired" runat="server"></span>
                <pde:ToolTip ID="ToolTip27" runat="server" ToolTipID="27" />
            </td>
        <td class="noBorder" valign="top">
                <asp:RadioButtonList ID="rblDrugTestingRequired" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Text="Yes" Value="1" />
                    <asp:ListItem Text="No" Value="0" />
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="rblDrugTestingRequiredReqVal" runat="server" ControlToValidate="rblDrugTestingRequired" Display="None" InitialValue="" ErrorMessage="Drug Testing is required" />
            </td>
            <td>
                Physical Examination<br />Required :
                <span class="required" style="display:inline;" id="spnPhysicalExaminationRequired" runat="server"></span>
                <pde:ToolTip ID="ToolTip26" runat="server" ToolTipID="26" />
            </td>
        <td class="noBorder" valign="top">
                <asp:RadioButtonList ID="rblPhysicalExaminationRequired" runat="server" 
                    RepeatDirection="Horizontal">
                    <asp:ListItem Text="Yes" Value="1" />
                    <asp:ListItem Text="No" Value="0" />
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="rblPhysicalExaminationRequiredReqVal" runat="server" ControlToValidate="rblPhysicalExaminationRequired" Display="None" InitialValue="" ErrorMessage="Physical Examination is required"  />
            </td>
        </tr>
         <!-- row #12 -->
        <tr>
            <td>
                Remarks :
                <pde:ToolTip ID="ToolTip41" runat="server" ToolTipID="41" />
            </td>
            <td colspan="3">
                <asp:TextBox ID="txtRemarks" runat="server" Width="420" CssClass="TelerikTextFont" TextMode="MultiLine" />
            </td>
        </tr>
</table>
</asp:Panel>

<asp:UpdatePanel ID="updatePanelActionValidate" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSaveAndContinue" />
    </Triggers>
    <ContentTemplate>
        <CL:CareerLadderBundle id="ctrlCareerLadderBundle" runat="server" Visible="false"></CL:CareerLadderBundle>
    </ContentTemplate>
</asp:UpdatePanel>

<span class="spanAction">
    <asp:Button ID="btnSaveAndContinue" runat="server" Text="Save and Continue" onClick="btnSaveAndContinue_Click" />
    <asp:Button ID="btnReset" runat="server" Text="Reset" onClick="btnReset_Click" OnClientClick ="Page_ValidationActive=false;" CausesValidation ="false" ValidationGroup ="" />
</span>
