<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderControl.ascx.cs" Inherits="HCMS.OrgChart.Controls.Layout.HeaderControl" %>
<table width="100%">
    <tr>
        <td>
        </td>
    </tr>
    <tr align="right">
        <td>
            <asp:Literal ID="literalPipe" runat="server" />
             <span id="spanLogin" runat="server">
                <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutAction="RedirectToLoginPage"
                    OnLoggingOut="LoginStatus1_LoggingOut" />
                | <a runat="server" id="linkHome" title="Home">Home</a> </span>
        </td>
    </tr>
</table>