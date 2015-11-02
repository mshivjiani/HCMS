<%@ Page Title="Organization Code Administration" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="OrgCodeAdmin.aspx.cs" Inherits="HCMS.Portal.Admin.OrgCodeAdmin" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <asp:ValidationSummary ID="valSummary" ValidationGroup="saveOrg" runat="server" CssClass="validationMessageBox"
        ShowSummary="true" HeaderText="<span class='systemMessage'>Validation Message</span><br>"
        DisplayMode="list" />
    <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server" Height="200px" Width="300px">
        <asp:Panel class="sectionContainer" ID="divOrgCodeAdmin" runat="server">
            <table border="0" cellpadding="2" cellspacing="1" width="95%">
                <tr>
                    <td>
                        Region:
                    </td>
                    <td>
                        <telerik:RadComboBox ID="radComboRegions" CausesValidation="false" runat="server"
                            AutoPostBack="true" Width="300px" ValidationGroup="RegValGroup" />
                        <span class="highlight1">
                            <asp:Literal ID="literalRegionName" runat="server" /></span>&nbsp;<asp:RequiredFieldValidator
                                ID="requiredRegion" runat="server" ControlToValidate="radComboRegions" ValidationGroup="RegValGroup"
                                ErrorMessage="You must select a region.">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%--                        Organization Code:--%>
                        <asp:RadioButtonList ID="rdOrgCode" runat="server" Width="220px" RepeatDirection="Horizontal"
                            AutoPostBack="true" OnSelectedIndexChanged="rdOrgCode_Changed">
                            <asp:ListItem Text="Old Org Code" Value="o" Selected="True" />
                            <asp:ListItem Text="New Org Code" Value="n" />
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        <telerik:RadComboBox ID="radComboOrgCodes" runat="server" AutoPostBack="true" Width="450px"
                            MarkFirstMatch="true" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Reporting Organization Code:
                    </td>
                    <td>
                        <asp:Label ID="lblReportingOrganizationCode" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        Introduction:
                    </td>
                    <td>
                        <asp:TextBox ID="txtIntroduction" runat="server" TextMode="MultiLine" Width="85%"
                            Rows="6"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="reqvalIntroduction" runat="server" Display="Dynamic"
                            ErrorMessage="You must enter Introduction text for Organization Code." ControlToValidate="txtIntroduction"
                            ValidationGroup="saveOrg">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="saveOrg" Enabled="false" />
                    </td>
                </tr>
            </table>
            <asp:Panel ID="panelSystemMessage" runat="server" Visible="false">
                <br />
                <hr class="separator" />
                <div align="center" class="systemMessage">
                    <asp:Literal ID="literalSystem" runat="server" /></div>
            </asp:Panel>
        </asp:Panel>
    </telerik:RadAjaxPanel>
    <br />
</asp:Content>
