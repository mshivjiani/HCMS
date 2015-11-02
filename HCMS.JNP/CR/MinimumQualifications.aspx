<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MinimumQualifications.aspx.cs"
    Inherits="HCMS.JNP.CR.MinimumQualifications" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="~/Controls/CR/ctrlMinimumQualifications.ascx" TagPrefix="uc1" TagName="ctrlMinimumQualifications" %>
<html>
<head id="Head1" runat="server">
    <title>Minimum Qualifications</title>
</head>
<body class="bodyWhite">
    <form id="form1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server" />
    <uc1:ctrlMinimumQualifications ID="ctrlMinimumQualifications" runat="server" />
    </form>
</body>
</html>
