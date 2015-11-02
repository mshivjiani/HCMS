<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkflowNotePopup.aspx.cs" Inherits="HCMS.PDExpress.Controls.WorkflowNotePopup.WorkflowNotePopup1" %>
<%@ Register Src="~/Controls/WorkflowNotePopup/WorkflowNotePopup.ascx" TagName="WorkflowNotePopup" TagPrefix="pde" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Add/Edit Notes</title>
</head>

<body class="bodyWhite">
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server" />
        <pde:WorkflowNotePopup ID="ctrlWorkflowNotePopup" runat="server" />
    </form>
</body>
</html>
