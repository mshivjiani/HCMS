<%@ Page Title="" Language="C#"  AutoEventWireup="true"
    CodeBehind="AddSeriesGradeKSATaskStatement.aspx.cs" Inherits="HCMS.Portal.Admin.AddSeriesGradeKSATaskStatement" %>

<%@ Register Src="~/Controls/Admin/ctrlAddSeriesGradeKSATaskStatement.ascx" TagName="ctrlAddSeriesGradeKSATaskStatement"
    TagPrefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <style type="text/css">
    </style>
    <title>Add Series Grade KSA Task Statement</title>
</head>

<body class="bodyWhite">
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat ="server"></telerik:RadScriptManager>
         <uc1:ctrlAddSeriesGradeKSATaskStatement ID="ctrlAddSeriesGradeKSATaskStatement" runat="server" />
    </form>
</body>
</html>
