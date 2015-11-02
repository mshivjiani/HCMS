<%@ Page Title="" Language="C#"  AutoEventWireup="true"
    CodeBehind="AddSeriesOPMTitle.aspx.cs" Inherits="HCMS.Portal.Admin.AddSeriesOPMTitle" %>

<%@ Register Src="~/Controls/Admin/ctrlAddSeriesOPMTitle.ascx" TagName="ctrlAddSeriesOPMTitle"
    TagPrefix="uc1" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <style type="text/css">
    </style>
    <title>Add/Edit Series OPM Title</title>
</head>

<body class="bodyWhite">
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat ="server"></telerik:RadScriptManager>
         <uc1:ctrlAddSeriesOPMTitle ID="ctrlAddSeriesOPMTitle" runat="server" />
    </form>
</body>
</html>
