<%@ Page Title="" Language="C#" MasterPageFile="~/Other.Master" AutoEventWireup="true" CodeBehind="WarningPage.aspx.cs" Inherits="HCMS.Portal.Common.WarningPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table ID="tblWelcome" class="tblIntro" runat="server">
        <tr>
            <td align ="center">
                <asp:Label ID="lblWarningTitle" CssClass="lblHeader" runat="server">
                    <h2>WARNING TO USERS OF THE HUMAN CAPITAL MANAGEMENT SYSTEM <br /> THIS IS A NOTICE OF MONITORING</h2>
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <p>
                    <asp:Literal ID="LitWarningText2" runat ="server">
                    This tool, including all related equipment, networks and network devices (including Internet access), is provided by the Department of the Interior (DOI) in accordance with the agency policy for official use and limited personal use.
                    All agency computer tools may be monitored for all lawful purposes, including but not limited to, ensuring that use is authorized, for management of the tool, to facilitate protection against unauthorized access, and to verify security procedures, survivability and operational security.
                    All information, including personal information, placed or sent over this tool may be monitored, and users of this tool are reminded that such monitoring does occur.  Therefore, there should be no expectation of privacy with respect to use of this tool.
                    By logging into this agency computer tool, you acknowledge and consent to the monitoring of this tool.  Evidence of your use, authorized or unauthorized, collected during monitoring may be used for civil criminal, administrative, or other adverse action.  Unauthorized or illegal use may subject you to prosecution.
                    </asp:Literal>
                </p>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnLogin" runat="server" CssClass="formBtn" Text="Accept" onclick="btnLogin_Click" />&nbsp;
                <asp:Button ID="btnCancel" runat="server" CssClass="formBtn" Text="Decline" onclick="btnCancel_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
