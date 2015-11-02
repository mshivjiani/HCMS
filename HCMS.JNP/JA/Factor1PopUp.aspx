
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Factor1PopUp.aspx.cs" Inherits="HCMS.JNP.JA.Factor1PopUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="~/Controls/JA/ctlFactor1PopUp.ascx" TagPrefix="uc1" TagName="ctrlFactor1PopUp" %>
<html>
<head id="Head1" runat="server">
    <title>Factor One Language</title>
</head>
<body class="bodyWhite">
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server" />
    <uc1:ctrlFactor1PopUp ID="ctrlFactor1PopUp" runat="server" />
    </form>
</body>
</html> 