<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DutyDefinitionPopup.aspx.cs" Inherits="HCMS.PDExpress.Controls.CreatePD.Duties.DutyDefinitionPopup" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Duty Definition</title>
</head>
<!-- override the background color set for body element in main.css -->
<body class="bodyWhite">
    <form id="form1" runat="server" style="border-bottom:solid 1px #9cb6c5;">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server" />
        <table width="100%" class="blueTable">
            <tr>
                <td>
                    <div class="sectionTitle"><asp:Label ID="lblJobSeriesName" runat="server" Text="" /></div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbDefinition" runat="server" CssClass="TelerikTextFont" TextMode="MultiLine" Width="99%" Rows="10" ReadOnly="true" Text="" />
                </td>
            </tr>
        </table>    
    </form>
</body>
</html>
