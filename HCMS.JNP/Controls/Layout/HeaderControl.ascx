<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HeaderControl.ascx.cs"
    Inherits="HCMS.JNP.Controls.Layout.HeaderControl" %>
<table width="100%">
    <tr>
        <td>
        </td>
    </tr>
    <tr align="right">
        <td>
            <asp:Literal ID="literalPipe" runat="server" />
           <%--
            //Issue Id: 29
            //Author: Deepali Anuje
            //Date Fixed: 1/23/2012
            //Description: Remove Login and Home button from top-right corner of login screen..
            //both take user this screen   
            --%>
            <span id="spanLogin" runat="server">
                <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutAction="RedirectToLoginPage"
                    OnLoggingOut="LoginStatus1_LoggingOut" />
                | <a runat="server" id="linkHome" title="Home">Home</a> </span>
        </td>
    </tr>
</table>
