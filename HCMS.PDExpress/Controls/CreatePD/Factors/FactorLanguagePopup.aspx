<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FactorLanguagePopup.aspx.cs" Inherits="HCMS.PDExpress.Controls.CreatePD.Factors.FactorLanguagePopup" %>
<%@ Register Src="~/Controls/CreatePD/Factors/FactorLanguagePopupCtrl.ascx" TagPrefix="pde" TagName="FactorLanguagePopupCtrl" %>

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
        <pde:FactorLanguagePopupCtrl ID="ctrlFactorLanguagePopupCtrl" runat="server" />
    </form>
</body>
</html>

