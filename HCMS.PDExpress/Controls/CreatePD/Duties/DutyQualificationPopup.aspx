<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DutyQualificationPopup.aspx.cs" Inherits="HCMS.PDExpress.Controls.CreatePD.Duties.DutyQualificationPopup" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/Controls/CreatePD/Duties/DutyQualificationListing.ascx" TagPrefix="custom" TagName="DutyQualifications" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Add/Edit Qualifications For Duty</title>
</head>
<!-- override the background color set for body element in main.css -->
<body class="bodyWhite">
    <form id="form1" runat="server">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server" />
        <custom:DutyQualifications ID="dutyQualificationListing" runat="server" />
    </form>
</body>
</html>


