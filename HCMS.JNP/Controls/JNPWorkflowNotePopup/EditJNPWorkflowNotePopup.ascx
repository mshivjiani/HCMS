<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditJNPWorkflowNotePopup.ascx.cs" Inherits="HCMS.JNP.Controls.JNPWorkflowNotePopup.EditJNPWorkflowNotePopup" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadCodeBlock ID="rcbCodeBlock" runat="server">
    <script type="text/javascript">
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.radWindow;
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow;
            return oWindow;
        }

        function EditJNPWorkflowNotePopupCtrlClose() {
            GetRadWindow().close();
        }
    </script>
</telerik:RadCodeBlock>

<div style="border-bottom:solid 1px #9cb6c5;"> 
    <table class="popupTable" width="100%">
    <col width="100px" />
    <col width="210px" />
    <col width="100px" />
    <col width="210px" />
        <tr>
            <td>Created Date:</td>
            <td><asp:TextBox ID="txtCreatedDate" runat="server" Text="" Width="200" ReadOnly="true" /></td>
            <td>Created By:</td>
            <td><asp:TextBox ID="txtCreatedBy" runat="server" Text="" Width="200" ReadOnly="true" /></td>
        </tr>
        <tr>
            <td>Updated Date:</td>
            <td><asp:TextBox ID="txtUpdatedDate" runat="server" Text="" Width="200" ReadOnly="true" /></td>
            <td>Updated By:</td>
            <td><asp:TextBox ID="txtUpdatedBy" runat="server" Text="" Width="200" ReadOnly="true" /></td>
        </tr>
        <tr>
            <td>Description:</td>
            <td colspan="3"><asp:TextBox ID="txtDescription" runat="server" Text="" TextMode="MultiLine" Width="580" Rows="3" /></td>
        </tr>
        <tr>
            <td>Update Note:</td>
            <td colspan="3"><asp:TextBox ID="txtUpdateNote" runat="server" Text="" TextMode="MultiLine" Width="580" Rows="3" /></td>
        </tr>
        <tr>
            <td>Status</td>
            <td colspan="3"><telerik:RadComboBox ID="ddlStatus" runat="server" DataTextField="JNPWorkflowNoteStatusName" DataValueField="JNPWorkflowNoteStatusID" /></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="3" align="right">
                <asp:Button ID="btnSaveEditWorkflowNote" runat="server" Text="&nbsp;Save and Close&nbsp;" ToolTip="Save and Close" OnClientClick="EditJNPWorkflowNotePopupCtrlClose();" OnClick="btnSaveEditJNPWorkflowNote_Click" />
                <asp:Button ID="btnCloseEditWorkflowNote" runat="server" Text="&nbsp;Close&nbsp;" ToolTip="Close" OnClientClick="EditJNPWorkflowNotePopupCtrlClose(); return false;" />
            </td>
        </tr>
    </table>
</div>
