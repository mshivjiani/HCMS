<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SOD.ascx.cs" Inherits="HCMS.PDExpress.Controls.CreatePD.SOD.SOD" %>
<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="pde" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/Controls/CreatePD/CreatePDMapStatusProgress.ascx" TagName="CreatePDMapStatusProgress" TagPrefix="CreatePD" %>
<%@ Register Src="~/Controls/CreatePD/CreatePDWorkflowNote.ascx" TagName="CreatePDWorkflowNote" TagPrefix="CreatePD" %>

<CreatePD:CreatePDMapStatusProgress ID="ctrlCreatePDMapStatusProgress" runat="server" IsReadOnly="true" PercentComplete="20.00" />
<CreatePD:CreatePDWorkflowNote ID="ctrlCreatePDWorkflowNote" runat="server" Visible="false" />

<asp:ValidationSummary ID="SODValSummary" runat="server" ValidationGroup="CreateSOD" CssClass="validationMessageBox" ShowSummary="true" HeaderText="<span class='systemMessage'>Validation Message</span><br>" DisplayMode="BulletList" />

<table id="tblSOD" runat="server" class="blueDutiesTable" style="width: 100%;">
    <tr>
        <td colspan="2" class="highlight1">
            <asp:Label ID="lblSODHeader" runat="server" />
        </td>
    </tr>
    <tr>
        <td valign="top" width="30%">
            <asp:Label ID="lblText1" runat="server" Text="Paragraph1:<span class='required'>*</span>" />
        </td>
        <td width="70%">
            <asp:TextBox ID="txtText1" runat="server" TextMode="MultiLine" Width="99%" Rows="4" />
            <asp:RequiredFieldValidator ID="rvText1" runat="server" ControlToValidate="txtText1" ValidationGroup="CreateSOD" Display="None" InitialValue="" ErrorMessage="Your must enter Paragraph 1 text to create statement of difference." />
        </td>
    </tr>
    <tr>
        <td valign="top">
            <asp:Label ID="lblText2" runat="server" Text="Paragraph2 (Please choose the most appropriate option for your one grade lower than full performance Position):<span class='required'>*</span>" />
        </td>
        <td class="noBorder" style="text-align: left;">
            <asp:RadioButtonList runat="server" ID="rblText2Options" AutoPostBack="false" RepeatLayout="Table" Width="98%" RepeatDirection="Vertical"/>
            <asp:CustomValidator ID="cvSODOptions" runat="server" ValidationGroup="CreateSOD" OnServerValidate="cvSODOptions_ServerValidate" Display="None" />
        </td>
    </tr>
    <tr>
        <td valign="top">
            <asp:Label ID="lblText3" runat="server" Text="Paragraph3 (additional modifications) (optional):" />
        </td>
        <td>
            <asp:TextBox ID="txtText3" runat="server" TextMode="MultiLine" Width="99%" Rows="4" />
        </td>
    </tr>
</table>

<span class="spanAction">
    <asp:Button ID="btnSubmit" runat="server" ValidationGroup="CreateSOD" OnClick="btnSubmit_Click" CssClass="formBtn" Visible="false" Text="Save and Continue" ToolTip="Save and Continue" />
    <asp:Button ID="btnCreateSOD" runat="server" ValidationGroup="CreateSOD" OnClick="btnCreateSOD_Click" CssClass="formBtn" Text="Create SOD" ToolTip="Create SOD" />
    &nbsp;
    <asp:Button ID="btnCancel" runat="server" CssClass="formBtn" OnClick="btnCancel_Click" Text="Close" ToolTip="Close" />
</span>
