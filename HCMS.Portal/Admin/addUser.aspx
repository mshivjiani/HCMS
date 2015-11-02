<%@ Page Title="Add User" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="addUser.aspx.cs" Inherits="HCMS.Portal.Admin.addUser" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server" >
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
<asp:UpdatePanel ID="panelUpdate" runat="server" UpdateMode="Conditional">
<ContentTemplate>

<asp:ValidationSummary id="valSummary" ValidationGroup="Search" runat="server" CssClass="validationMessageBox" ShowSummary="true" HeaderText="<span class='systemMessage'>Validation Message</span><br>" DisplayMode="list" />
<asp:CustomValidator ID="customValSearchFields" ValidationGroup="Search" runat="server" ErrorMessage="You must enter data in at least one field before performing a search." Display="None" />
<div class="sectionContainer">
    <table width="100%">
        <colgroup>
            <col width="110px" />
            <col width="150px" />
            <col width="15px" />
            <col width="90px" />
            <col width="140px" />
            <tr>
                <td>
                    Last Name:</td>
                <td>
                    <asp:TextBox ID="textboxLastName" runat="server" Width="250" />
                </td>
                <td>
                </td>
                <td>
                    First Name:</td>
                <td>
                    <asp:TextBox ID="textboxFirstName" runat="server" Width="250" />
                </td>
            </tr>
            <tr>
                <td>
                    User Name (Email):</td>
                <td colspan="5">
                    <asp:TextBox ID="textboxEmail" runat="server" width="642" />
                    <asp:RegularExpressionValidator ID="regExEmailAddress" runat="server" 
                        ControlToValidate="textboxEmail" Display="dynamic" Enabled="false" 
                        ErrorMessage="The email address entered you entered is not valid." 
                        ValidationExpression="^[\w\.-]+@[\w-]+\.[\w\.-]+$" ValidationGroup="Search">*</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="buttonSearch" runat="server" CausesValidation="true" 
                        Text="Search" ValidationGroup="Search" />
                    &nbsp;<asp:Button ID="buttonReset" runat="server" CausesValidation="false" 
                        Text="Reset" Visible="false" />
                    <asp:TextBox ID="textboxCustomVal" runat="server" Text="1" Visible="false" />
                </td>
            </tr>
        </colgroup>
    </table>
</div>

<asp:UpdateProgress ID="progressSearch" runat="server">
<ProgressTemplate><br /><div align="center"><asp:Image ID="imageLoading" runat="server" SkinID="loadingIcon" /></div></ProgressTemplate>
</asp:UpdateProgress>

<asp:Panel ID="panelCount" runat="server" Visible="false">
<br />
<hr class="separator" /><div align="center" class="systemMessage"><asp:Literal ID="literalCount" runat="server" /></div>
</asp:Panel>

<asp:Panel ID="panelAdd" runat="server" Visible="false">
<br /><hr class="separator" /><div class="sectionTitle">Add User</div>
<div class="sectionContainer">
<asp:ValidationSummary id="ValidationSummary1"  ValidationGroup ="AddUservalGroup" runat="server" CssClass="validationMessageBox" ShowSummary="true" HeaderText="<span class='systemMessage'>Validation Message</span><br>" DisplayMode="list" />
    <table cellpadding="0" cellspacing="2" border="0">
    <col width="70px" />
    <col width="415px" />
    <tr>
        <td>User:</td>
        <td><telerik:RadComboBox ID="radComboUsers" runat="server" AutoPostBack="false" Width="400px" MarkFirstMatch="true" />&nbsp;<asp:RequiredFieldValidator ID="requiredUsers" runat="server" ControlToValidate="radComboUsers" ErrorMessage="You must select an account before it can be added to the system." ValidationGroup="AddUservalGroup">*</asp:RequiredFieldValidator></td>
        <td><asp:button ID="buttonAddUser" runat="server" Text="Add New User" CausesValidation="true"  ValidationGroup="AddUservalGroup"  /></td>
    </tr>
    <tr><td>Role:</td><td colspan="2"><telerik:RadComboBox ID="radComboRoles" runat="server" AutoPostBack="false" Width="200px" MarkFirstMatch="true" />&nbsp;<asp:RequiredFieldValidator ID="requiredRoles" runat="server" ControlToValidate="radComboRoles" ErrorMessage="You must select a role for the new account." ValidationGroup="AddUservalGroup">*</asp:RequiredFieldValidator></td></tr>
    <tr><td>Region:</td><td colspan="2"><telerik:RadComboBox ID="radComboRegions" runat="server" AutoPostBack="false" Width="200px" /><span class="highlight1"><asp:Literal ID="literalRegionName" runat="server" /></span>&nbsp;<asp:RequiredFieldValidator ID="requiredRegion" runat="server" ControlToValidate="radComboRegions" ErrorMessage="You must select a region for the new account." ValidationGroup="AddUservalGroup">*</asp:RequiredFieldValidator></td></tr>
    </table>
</div>

<asp:Panel ID="panelSystemMessage" runat="server" Visible="false">
<br /><hr class="separator" /><div align="center" class="systemMessage"><asp:Literal ID="literalSystem" runat="server" /></div>
</asp:Panel>
</asp:Panel>

<%--<br /><div align="center" class="sectionContainer"><asp:Button ID="buttonCancel" runat="server" Text="Admin Page" CausesValidation="false" /></div>
--%>
</ContentTemplate>
</asp:UpdatePanel>

<br />

</asp:Content>
