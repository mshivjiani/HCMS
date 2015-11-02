<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditWorkflowNotePopup.aspx.cs" Inherits="HCMS.PDExpress.Controls.WorkflowNotePopup.EditWorkflowNotePopup" %>
<%@ Register Src="~/Controls/WorkflowNotePopup/EditWorkflowNotePopup.ascx" TagName="EditWorkflowNotePopup" TagPrefix="pde" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Edit Revision Note</title>
</head>
<body class="bodyWhite">
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server" />
        <pde:EditWorkflowNotePopup ID="ctrlWorkflowNotePopup" runat="server" />
    </form>
</body>
</html>
