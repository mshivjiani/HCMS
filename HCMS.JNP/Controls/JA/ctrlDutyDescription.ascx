<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlDutyDescription.ascx.cs"
    Inherits="HCMS.JNP.Controls.JA.ctrlDutyDescription" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table class="blueTable" width="100%">
    <tr>
        <td>
            <asp:Label ID="lblDutyNumber" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:TextBox TextMode="MultiLine" ID="txtDutyDescription" runat="server" ReadOnly="true"
                BorderStyle="None" Rows="20" Width="500px"></asp:TextBox>
        </td>
    </tr>
</table>
