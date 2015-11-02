<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NarrativeFactorLanguagePopup.aspx.cs" Inherits="HCMS.PDExpress.Controls.CreatePD.Factors.NarrativeFactorLanguagePopup" %>
<%@ Register Src="~/Controls/CreatePD/Factors/NarrativeFactorLanguagePopupCtrl.ascx" TagPrefix="pde" TagName="NarrativeFactorLanguagePopupCtrl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <style type="text/css">
    </style>
    <title>Factor Language</title>
</head>
<!-- override the background color set for body element in main.css -->
<body class="bodyWhite">
    <form id="form1" runat="server">
        <pde:NarrativeFactorLanguagePopupCtrl ID="ctrlNarrativeFactorLanguagePopupCtrl" runat="server" />
    </form>
</body>
</html>
