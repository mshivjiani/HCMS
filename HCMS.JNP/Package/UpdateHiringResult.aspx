<%@ Page Title="" Language="C#"  AutoEventWireup="true"
    CodeBehind="UpdateHiringResult.aspx.cs" Inherits="HCMS.JNP.Package.UpdateHiringResult" %>

<%@ Register Src="~/Controls/Package/ctrlJNPUpdateHiringResult.ascx" TagPrefix="JNPUpdateHiringResult"
    TagName="ctrlJNPUpdateHiringResult" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <style type="text/css">
    </style>
    <title>Update Hiring Result</title>
</head>

<body class="bodyWhite">
    <form id="form1" runat="server">
        <JNPUpdateHiringResult:ctrlJNPUpdateHiringResult ID="ctrlJNPUpdateHiringResult" runat="server" />
    </form>
</body>
</html>

