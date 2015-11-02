<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreatePDWorkflowNote.ascx.cs" Inherits="HCMS.PDExpress.Controls.CreatePD.CreatePDWorkflowNote" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
<script type="text/javascript" language="javascript">
//    function ShowAddEditNotePopup(positionDescriptionID, isCheckedOut)
//    {
//        var oWnd = $find("<%=rwAddEditNotePopup.ClientID%>");
//        oWnd.setUrl("../Controls/WorkflowNotePopup/WorkflowNotePopup.aspx?PositionDescriptionID=" + positionDescriptionID + "&IsCheckedOut=" + isCheckedOut);
//        oWnd.show();
    //    }
    function ShowAddEditNotePopup(positionDescriptionID, isCheckedOut, CheckedOutByID) {
        var oWnd = $find("<%=rwAddEditNotePopup.ClientID%>");
        oWnd.setUrl("../Controls/WorkflowNotePopup/WorkflowNotePopup.aspx?PositionDescriptionID=" + positionDescriptionID + "&IsCheckedOut=" + isCheckedOut + "&CheckedOutByID=" + CheckedOutByID);
        oWnd.show();
    }
</script>
</telerik:RadCodeBlock>

<div id="addEditNotesDiv" runat="server">
    <asp:Image ID="imgAddEditNotes" runat="server" SkinID="editIcon"  Style="vertical-align: middle;" />
    <asp:LinkButton ID="lbAddEditNotes" runat="server"/>
</div>

<br />

<telerik:RadWindow ID="rwAddEditNotePopup" runat="server"
        ReloadOnShow="true" 
        Skin="WebBlue"
        Modal="True"
        Width="790px" Height="500px"
        Style="display:none;" VisibleOnPageLoad="false"
        Behaviors="None" InitialBehaviors="None"
        VisibleStatusbar="False">
</telerik:RadWindow>        
