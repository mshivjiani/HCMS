<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Approvals.ascx.cs" Inherits="HCMS.PDExpress.Controls.CreatePD.Approvals.Approvals" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="pde" %>
<script type="text/javascript">
    function validateHighGradeReview(source, args) {
        var chk = document.getElementById('<%=chkHigherGradeApproval.ClientID %>');
        if (chk) {
            args.IsValid = chk.checked;
        }
    }

</script>
<telerik:RadAjaxLoadingPanel ID="ajaxLoadingPanelSave" runat="server" />
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="ajaxLoadingPanelSave">
    <AjaxSettings>
        <%--<telerik:AjaxSetting AjaxControlID="btnCheckPublish">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="btnCheckPublish" />
                <telerik:AjaxUpdatedControl ControlID="txtClassOrgTitle" />
                <telerik:AjaxUpdatedControl ControlID="txtClassPwd" />
                <telerik:AjaxUpdatedControl ControlID="btnSupervisorSign" />
            </UpdatedControls>
        </telerik:AjaxSetting>--%>
    </AjaxSettings>
</telerik:RadAjaxManager>
<asp:UpdatePanel ID="updtpnlValidationMessage" runat="server" UpdateMode="Always">
    <ContentTemplate>
        <asp:ValidationSummary ID="vsApproval" runat="server" CssClass="validationMessageBox"
            ShowSummary="true" HeaderText="<span class='systemMessage'>Validation Message</span><br>"
            DisplayMode="BulletList" />
        <asp:Panel ID="pnlValidationMessage" runat="server" Visible="false">
            <div style="width: 100%; background-color: #FFF3A8; border: solid 1px black; margin-bottom: 10px;">
                <div style="margin: 10px;">
                    <div style="font-size: larger; font-weight: bolder;">
                        Validation Message</div>
                    <br />
                    <ul style="color: Red;">
                        <li>
                            <asp:Label ID="lblValidationMessage" runat="server" Style="color: Red; font-weight: bolder;" />
                        </li>
                    </ul>
                </div>
            </div>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<table id="tblmsg" runat="server" width="100%" class="blueTable">
    <tr>
        <td style="font-weight: bold">
            <asp:Literal ID="litwarning" runat="server" Text="Warning: Certifying a PD with false or misleading statements can result in penalties that range from cautionary guidance to removal."></asp:Literal>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblSupSignWarning" runat="server" Visible="false" Text="This Position Description requires at least one Supervisor signature, verify information entered, unlock this Position Description and contact Supervisor for approval."> </asp:Label>
        </td>
    </tr>
</table>
<asp:Table ID="tblSupApprovals" runat="server" Width="100%" CssClass="blueTable">
    <asp:TableHeaderRow>
        <asp:TableHeaderCell HorizontalAlign="Left">Supervisory Certification</asp:TableHeaderCell>
    </asp:TableHeaderRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
            <asp:Literal ID="litSupText" runat="server" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableHeaderCell ColumnSpan="2" HorizontalAlign="Left">
        </asp:TableHeaderCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableHeaderCell ColumnSpan="2" HorizontalAlign="Left">
        </asp:TableHeaderCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2"></asp:TableCell>
    </asp:TableRow>
    <asp:TableRow ID="trSignAs" runat="server">
        <asp:TableCell Width="25%">
            <asp:Label ID="lblSignAs" runat="server" Text="Sign As:"></asp:Label>
            &nbsp; <span class="required">*</span> &nbsp;
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButtonList ID="rblSupSignType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text="Supervisor" Value="1"></asp:ListItem>
                <asp:ListItem Text="Approving Official" Value="2"></asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="rblSupSignTypereqval" runat="server" Display="Dynamic"
                Text="*" ErrorMessage="Please select Supervisor Sign As." ControlToValidate="rblSupSignType"
                ValidationGroup="SupCertValGroup"></asp:RequiredFieldValidator>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow ID="trOrgTitle" runat="server">
        <asp:TableCell Width="25%">
            <asp:Label ID="lblSupOrgTitle" runat="server" Text="Enter Organization Title:"></asp:Label>
            &nbsp; <span class="required">*</span> &nbsp;
            <pde:ToolTip ID="ToolTip66" runat="server" ToolTipID="66" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="txtSupOrgTitle" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtSupOrgTitlereqval" runat="server" Display="Dynamic"
                Text="*" ErrorMessage="Please provide your organization title." ControlToValidate="txtSupOrgTitle"
                InitialValue="" ValidationGroup="SupCertValGroup"></asp:RequiredFieldValidator>
        </asp:TableCell></asp:TableRow>
    <asp:TableRow ID="trSupPwd" runat="server">
        <asp:TableCell Width="25%">
            <asp:Label ID="lblSupervisorPwd" runat="server" Text="Enter Password:"></asp:Label>
            &nbsp; <span class="required">*</span> &nbsp;
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="txtSupervisorPwd" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtSupPwdreqval" runat="server" Display="Dynamic"
                Text="*" ErrorMessage="Please sign using your password." ControlToValidate="txtSupervisorPwd"
                InitialValue="" ValidationGroup="SupCertValGroup"></asp:RequiredFieldValidator>
            &nbsp;&nbsp;
            <asp:Button ID="btnSupervisorSign" runat="server" Text="Sign" ValidationGroup="SupCertValGroup"
                OnClientClick="SetValidationGroup('SupCertValGroup');" />
        </asp:TableCell></asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
            <asp:Literal ID="litSupmsg" runat="server"></asp:Literal>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableFooterRow>
        <asp:TableCell ColumnSpan="2" HorizontalAlign="Right">
            <br />
        </asp:TableCell>
    </asp:TableFooterRow>
</asp:Table>
<asp:Panel ID="panelMessage" Visible="false" runat="server" CssClass="highlight1">
    <br />
    <asp:Literal ID="litmsg" runat="server"></asp:Literal></asp:Panel>
<asp:Table ID="tblClasifierApprovals" runat="server" Width="100%" CssClass="blueTable">
    <asp:TableRow>
        <asp:TableHeaderCell><br /></asp:TableHeaderCell>
    </asp:TableRow>
    <asp:TableHeaderRow>
        <asp:TableHeaderCell HorizontalAlign="Left">Classifier Certification</asp:TableHeaderCell></asp:TableHeaderRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
            <asp:Literal ID="litClassifierText" runat="server" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableHeaderCell ColumnSpan="2" HorizontalAlign="Left">
        </asp:TableHeaderCell>
    </asp:TableRow>
    <asp:TableRow ID="trClassSignAs">
        <asp:TableCell Width="20%">
            <asp:Label ID="lblClassSignAs" runat="server" Text="Sign As"></asp:Label>
            &nbsp;<span class="required">*</span>&nbsp;
        </asp:TableCell>
        <asp:TableCell>
            <asp:RadioButtonList ID="rblClassSignAs" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text="Evaluator" Value="3"></asp:ListItem>
                <asp:ListItem Text="Classifier" Value="4"></asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="rblClassSignAsreqval" runat="server" Display="Dynamic"
                Text="*" ErrorMessage="Please select Sign As." ControlToValidate="rblClassSignAs"
                ValidationGroup="ClassCertValGroup"></asp:RequiredFieldValidator>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow ID="trClassOrgTitle">
        <asp:TableCell Width="20%">
            <asp:Label ID="Label1" runat="server" Text="Enter Organization Title:"></asp:Label>
            &nbsp; <span class="required">*</span> &nbsp;<pde:ToolTip ID="ToolTip66A" runat="server"
                ToolTipID="66" />
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="txtClassOrgTitle" runat="server" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtClassOrgTitlereqval" runat="server" Display="Dynamic"
                Text="*" ErrorMessage="Please provide your organization title." ControlToValidate="txtClassOrgTitle"
                InitialValue="" ValidationGroup="ClassCertValGroup"></asp:RequiredFieldValidator>
        </asp:TableCell></asp:TableRow>
    <asp:TableRow ID="trClassPwd">
        <asp:TableCell Width="20%">
            <asp:Label ID="lblClassPwd" runat="server" Text="Enter Password:"></asp:Label>
            &nbsp; <span class="required">*</span> &nbsp;
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="txtClassPwd" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="txtClassPwdreqval" runat="server" Display="Dynamic"
                Text="*" ErrorMessage="Please sign using your password." ControlToValidate="txtClassPwd"
                InitialValue="" ValidationGroup="ClassCertValGroup"></asp:RequiredFieldValidator>
            &nbsp;&nbsp;<asp:Button ID="btnClassifierSign" runat="server" Text="Sign" ValidationGroup="ClassCertValGroup"
                OnClientClick="SetValidationGroup('ClassCertValGroup');" />
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow ID="trHighGradeReview">
        <asp:TableCell>
            <asp:Label ID="lblHigherApproval" runat="server" Text="High Grade Review?"></asp:Label>
            &nbsp;<pde:ToolTip ID="pdeToolTip69" runat="server" ToolTipID="69" />
        </asp:TableCell>
        <asp:TableCell>
            <%--<asp:UpdatePanel ID="updtpnlHigherGradeApproval" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnHigherApprovalSave" />
                    <asp:AsyncPostBackTrigger ControlID="chkHigherGradeApproval" />
                </Triggers>
                <ContentTemplate>--%>
            <asp:CheckBox ID="chkHigherGradeApproval" runat="server" AutoPostBack="false" />
            <asp:CustomValidator ID="chkHigherGradeApprovalcustomval" runat="server" EnableClientScript="true"
                ClientValidationFunction="validateHighGradeReview" ValidationGroup="HigherGradeApprovalGroup"
                Display="Dynamic" Text="*" ErrorMessage="Please check to indicate High Grade Review."></asp:CustomValidator>
            <asp:Button ID="btnHigherApprovalSave" runat="server" Text="Save" ValidationGroup="HigherGradeApprovalGroup"
                OnClientClick="SetValidationGroup('HigherGradeApprovalGroup');" />
            <%--</ContentTemplate>
            </asp:UpdatePanel>--%>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell ColumnSpan="2">
            <asp:Literal ID="litClassmsg" runat="server"></asp:Literal>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<br />
<asp:UpdatePanel ID="updtpnlHCO" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnHigherApprovalSave" />
    </Triggers>
    <ContentTemplate>
        <asp:Table ID="tblHCOApproval" runat="server" Width="100%" CssClass="blueTable" Visible="false">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell HorizontalAlign="Left" ColumnSpan="2">Human Capital Officer Certification</asp:TableHeaderCell></asp:TableHeaderRow>
            <asp:TableRow ID="trHCOSignAs">
                <asp:TableCell ColumnSpan="2">
                    <asp:Label ID="lblHCOSignature" runat="server" Text="Please Sign as Human Capital Officer"></asp:Label></asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="trHCOOrgTitle">
                <asp:TableCell Width="20%">
                    <asp:Label ID="lblHCOOrgTitle" runat="server" Text="Enter Organization Title:"></asp:Label>
                    &nbsp; <span class="required">*</span> &nbsp;<pde:ToolTip ID="ToolTip66B" runat="server"
                        ToolTipID="66" />
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtHCOOrgTitle" runat="server" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="txtHCOOrgTitlereqval" runat="server" Display="Dynamic"
                        Text="*" ErrorMessage="Please provide your organization title." ControlToValidate="txtHCOOrgTitle"
                        InitialValue="" ValidationGroup="HCOCertValGroup"></asp:RequiredFieldValidator>
                </asp:TableCell></asp:TableRow>
            <asp:TableRow ID="trHCOPwd">
                <asp:TableCell Width="20%">
                    <asp:Label ID="lblHCOPwd" Text="Enter Password:" runat="server"></asp:Label>&nbsp;
                    <span class="required">*</span> &nbsp;</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="txtHCOPwd" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="txtHCOPwdreqval" runat="server" Display="Dynamic"
                        Text="*" ErrorMessage="Please sign using your password." ControlToValidate="txtHCOPwd"
                        InitialValue="" ValidationGroup="HCOCertValGroup"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;<asp:Button ID="btnHCOSign" runat="server" Text="Sign" ValidationGroup="HCOCertValGroup"
                        OnClientClick="SetValidationGroup('HCOCertValGroup');" />
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<table id="tblSignDetail" runat="server" width="100%" class="blueTable">
    <tr>
        <td>
            <asp:Label ID="lblStandardPDMsg" runat="server" Visible="false" Font-Bold="true"
                ForeColor="Red" Text="NOTE: SPDs do not require Supervisor Approval, validate information and Submit for Review."></asp:Label>
        </td>
    </tr>
    <tr>
        <th align="left">
            <asp:Label ID="lblSignedSup" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lblAdditionalSignedSup" runat="server" Text=""></asp:Label>
        </th>
    </tr>
    <tr>
        <th align="left">
            <asp:Label ID="lblsignedEvalauator" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lblsignedClassifier" runat="server" Text=""></asp:Label><br />
            <asp:UpdatePanel ID="updtpnlHCOWarning" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnHigherApprovalSave" />
                    <asp:AsyncPostBackTrigger ControlID="btnHCOSign" />
                </Triggers>
                <ContentTemplate>
                    <asp:Label ID="lblHighGradeApprWarning" runat="server" Visible="false" Text="This Position Description requires High Grade Review."></asp:Label><br />
                    <asp:Label ID="lblHCOSignWarning" runat="server" Visible="false" Font-Bold="true"
                        Text="This Position Description requires Human Capital Officer Signature."></asp:Label>
                    <asp:Label ID="lblsignedHCO" runat="server" Text=""></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </th>
    </tr>
</table>
<br />
<div id="divSubmitAction" runat="server" class="blueTable" align="right" style="padding-top: 15px;
    padding-left: 10px; padding-right: 10px;">
    <div class="highlight1" id="divFastrackMessage" runat="server" align="left">
        Please note that if you choose to "Check and Publish" at this point, you will bypass
        the Revise and Final Review stages of the workflow.<br />
        <br />
    </div>
    <div>
        <table>
            <tr>
                <td>
                    <asp:Button ID="buttonSubmitNextStatus" runat="server" Text="Submit Next Status" />
                </td>
                <td>
                    <asp:Button ID="btnCheckPublish" runat="server" Text="Check And Publish" />
                </td>
            </tr>
        </table>
    </div>
</div>
<br />
