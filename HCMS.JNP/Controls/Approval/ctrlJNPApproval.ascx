<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="ctrlJNPApproval.ascx.cs"
    Inherits="HCMS.JNP.Controls.Approval.ctrlJNPApproval" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="tooltip" %>
<%@ Register Src="~/Controls/Workflow/ctrlWorkflowActionManager.ascx" TagName="wflowmgr"
    TagPrefix="wmgr" %>
<table id="tblmsg" runat="server" width="100%" class="blueTable">
    <%--<tr>
        <td>
            <asp:LinkButton ID="lnkPrintJNP" runat="server" OnClick="lnkPrintJNP_Click">Print JNP Report</asp:LinkButton>
        </td>
    </tr>--%>
    <tr>
        <td>
            <asp:Label ID="lblSupSignWarning" runat="server" Visible="False" Text="This Job Announcement requires at least one Supervisor signature, verify information entered, unlock this Package and contact Supervisor for approval."></asp:Label>
        </td>
    </tr>
</table>

<asp:CustomValidator ID="customValidator" runat ="server" 
    Display ="None" 
    OnServerValidate ="customValidator_ServerValidate">
</asp:CustomValidator>

<asp:Panel ID="pnlApprovals" runat="server">
    <asp:Table ID="tblSupApprovals" runat="server" Width="100%" CssClass="blueTable">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell HorizontalAlign="Left">Supervisory Certification</asp:TableHeaderCell>
        </asp:TableHeaderRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Literal ID="litSupText" runat="server" />
            </asp:TableCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableHeaderCell ColumnSpan="2" HorizontalAlign="Left">
            </asp:TableHeaderCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableHeaderCell ColumnSpan="2" HorizontalAlign="Left">
            </asp:TableHeaderCell></asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2"></asp:TableCell></asp:TableRow>
        <asp:TableRow ID="trSignAs">
            <asp:TableCell Width="25%">
                <asp:Label ID="lblSignAs" runat="server" Text="Sign As:"></asp:Label>
                &nbsp; <span class="required">*</span>
            </asp:TableCell><asp:TableCell>
                <asp:RadioButtonList ID="rblSupSignType" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Text="Supervisor" Value="1" Enabled="false"></asp:ListItem>
                    <asp:ListItem Text="HR Personnel" Value="4" Enabled="false"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="rblSupSignTypereqval" runat="server" Display="Dynamic"
                    Text="*" ErrorMessage="Please select Supervisor or HR Personnel Sign As." ControlToValidate="rblSupSignType"
                    ValidationGroup="SupCertValGroup"></asp:RequiredFieldValidator>
            </asp:TableCell></asp:TableRow>
        <asp:TableRow ID="trOrgTitle">
            <asp:TableCell Width="25%"  class="toolTipleft">
                <asp:Label ID="lblSupOrgTitle" runat="server" Text="Enter Organization Title:"></asp:Label>
                &nbsp; <span class="required">*</span> &nbsp;&nbsp;<tooltip:ToolTip ID="ToolTip2"
                    runat="server" ToolTipID="66" />
            </asp:TableCell><asp:TableCell>
                <asp:TextBox ID="txtSupOrgTitle" runat="server" Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="txtSupOrgTitlereqval" runat="server" Display="Dynamic"
                    Text="*" ErrorMessage="Please provide your organization title." ControlToValidate="txtSupOrgTitle"
                    InitialValue="" ValidationGroup="SupCertValGroup"></asp:RequiredFieldValidator>
            </asp:TableCell></asp:TableRow>
        <asp:TableRow ID="trSupPwd">
            <asp:TableCell Width="25%" class="toolTipleft">
                <asp:Label ID="lblSupervisorPwd" runat="server" Text="Enter Password:"></asp:Label>
                &nbsp; <span class="required">*</span> &nbsp;&nbsp;<tooltip:ToolTip ID="ToolTip1"
                    runat="server" ToolTipID="189" />
            </asp:TableCell><asp:TableCell>
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
            </asp:TableCell></asp:TableRow>
        <asp:TableFooterRow>
            <asp:TableCell ColumnSpan="2" HorizontalAlign="Right">
            <br />
            </asp:TableCell></asp:TableFooterRow>
    </asp:Table>
    <asp:Panel ID="panelMessage" Visible="false" runat="server" CssClass="highlight1">
    </asp:Panel>
    <br />
    <asp:Literal ID="litmsg" runat="server"></asp:Literal></asp:Panel>
<br />
<table id="tblMessageBeforSigning" runat="server" width="100%" class="blueTable" visible="false">
    <tr>
        <td>
            <asp:Label ID="lblMessageBeforSigning" runat="server" Visible="true" Font-Bold="True"
                ForeColor="blue"></asp:Label>
        </td>
    </tr>
</table>
<table id="tblSignDetail" runat="server" width="100%" class="blueTable">
    <tr>
        <td>
            <asp:Label ID="lblStandardPDMsg" runat="server" Visible="False" Font-Bold="True"
                ForeColor="Red"></asp:Label>
        </td>
    </tr>
    <tr>
        <th align="left">
            <asp:Label ID="lblSignedSup" runat="server" Text=""></asp:Label><br />
        </th>
    </tr>
    <tr>
        <th align="left">
            <asp:Label ID="lblsignedHR" runat="server" Text=""></asp:Label><br />
        </th>
    </tr>
</table>
<br />
<span id="spanWorkflowManager" runat="server" class="spanAction">
    <wmgr:wflowmgr ID="ctrlworkflowManager" runat="server" />
</span>
<br />
