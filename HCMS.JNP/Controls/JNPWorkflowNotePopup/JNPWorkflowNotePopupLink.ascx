<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JNPWorkflowNotePopupLink.ascx.cs" Inherits="HCMS.JNP.Controls.JNPWorkflowNotePopup.JNPWorkflowNotePopupLink" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
<script type="text/javascript" language="javascript">
    function ShowAddEditNotePopup(JNPID, IsInEdit) 
    {
        var oWnd = $find("<%=rwAddEditNotePopup.ClientID%>");
        oWnd.setUrl("../JNPWorkflowNotePopup/JNPWorkflowNotePopup.aspx?JNPID=" + JNPID + "&IsInEdit=" + IsInEdit);
        if (IsInEdit == "True") {
            oWnd.set_title("Edit Workflow Note");
        }
        else {
            oWnd.set_title("View Workflow Note");
        }
        oWnd.show();
    }
</script>
</telerik:RadCodeBlock>

<div id="addEditNotesDiv" runat="server">
    <asp:Image ID="imgAddEditNotes" runat="server" ImageUrl="~/App_Themes/JNP_Default/Images/Icons/icon_edit.gif" Style="vertical-align: middle;" />
    <asp:LinkButton ID="lbAddEditNotes" runat="server"/>
</div>

<br />

<telerik:RadWindow ID="rwAddEditNotePopup" runat="server"
        ReloadOnShow="true" 
        Skin="WebBlue"
        Modal="True"
        Width="790px" Height="300px"
        Style="display:none;" VisibleOnPageLoad="false"
        Behaviors="None" InitialBehaviors="None"
        VisibleStatusbar="False">
</telerik:RadWindow>        
