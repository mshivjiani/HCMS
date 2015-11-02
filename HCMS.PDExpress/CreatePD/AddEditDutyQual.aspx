<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddEditDutyQual.aspx.cs"
    Inherits="HCMS.PDExpress.CreatePD.AddEditDutyQual" %>

<%@ Register Src="../Controls/CreatePD/Duties/AddEditDutyQual.ascx" TagName="AddEditDutyQual"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Src/JsRelatedTocss/jquery-1.8.3.min.js" type="text/javascript"></script>
</head>
<body class="bodyWhite">
    <form id="form1" runat="server">
    <div>
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server" />
    </div>
    <table width="100%" >
        <tr>
            <td width="100%">
                <uc1:AddEditDutyQual ID="AddEditDutyQual1" runat="server" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
