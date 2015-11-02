<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="HCMS.Portal.Controls.Login" %>
<asp:Panel ID="pnlLogin" runat="server">
    <div align="center" style="height: auto; margin-bottom: 50px;">
        <table border="1" class="loginTable" cellspacing="0" align="center" style="border-collapse: collapse;
            border-color: #213547">
            <tr>
                <td>
                    <div align="center">
                        <asp:Login ID="Loginctrl" runat="server" OnLoginError="Loginctrl_LoginError" OnAuthenticate="Loginctrl_Authenticate">
                            <LayoutTemplate>
                                <table>
                                    <tr>
                                        <td colspan="2" style="text-align: left;">
                                            <h1>
                                                Login</h1>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left" colspan="2">
                                            <asp:ValidationSummary ID="vsLogin" runat="server" DisplayMode="BulletList" HeaderText=""
                                                ValidationGroup="Login" ValidateEmptyText="true" Visible="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <b>
                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Username:</asp:Label></b><span
                                                    class="required">*</span>&nbsp;
                                        </td>
                                        <td align="left" nowrap>
                                            <asp:TextBox ID="UserName" runat="server" Width="170px"></asp:TextBox>
                                            <asp:CustomValidator ID="cvUserName" runat="server" Display="none" OnServerValidate="cvPassword_ServerValidate"
                                                ValidationGroup="Login" ControlToValidate="UserName">
                                            </asp:CustomValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <b>
                                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label></b><span
                                                    class="required">*</span>&nbsp;
                                        </td>
                                        <td align="left" nowrap>
                                            <asp:TextBox ID="Password" runat="server" TextMode="Password" Width="170px">admin</asp:TextBox>
                                            <asp:CustomValidator ID="cvPassword" runat="server" Display="none" OnServerValidate="cvPassword_ServerValidate"
                                                ValidationGroup="Login" ControlToValidate="Password">
                                            </asp:CustomValidator>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="color: red" align="left">
                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="height: 26px">
                                            &nbsp;
                                        </td>
                                        <td align="left" style="height: 26px">
                                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Login" CssClass="formBtn"
                                                ValidationGroup="Login" />
                                        </td>
                                    </tr>
                                </table>
                            </LayoutTemplate>
                        </asp:Login>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>
<div style="text-align: center; font-weight: bold">
    To access online training course modules on DOI Learn,
    <asp:HyperLink ID="DOITrainingLink" runat="server" Text="click here " NavigateUrl="https://gm2.geolearning.com/geonext/doi/login.geo"
        Target="_blank"></asp:HyperLink>
    and search the catalog for 'PD Express'.</div>
