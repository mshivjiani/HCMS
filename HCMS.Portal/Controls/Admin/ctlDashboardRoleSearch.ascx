<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctlDashboardRoleSearch.ascx.cs"
    Inherits="HCMS.Portal.Controls.Admin.ctlDashboardRoleSearch" %>
<telerik:RadAjaxLoadingPanel ID="ajaxLoadingPanelSave" runat="server" />
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="ajaxLoadingPanelSave">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="buttonSearch">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="tblSearchByRegion" />
                <telerik:AjaxUpdatedControl ControlID="tblResults" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnClearSearch">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="tblResults" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="rcbRegion">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="tblSearchByRegion" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnSearchUser">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rcbUserSearch" />
                <telerik:AjaxUpdatedControl ControlID="tblResults" />
                <telerik:AjaxUpdatedControl ControlID="DashboardGrid" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="rcbUserSearch">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="tblResults" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnClearUserSearch">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="txtLastName" />
                <telerik:AjaxUpdatedControl ControlID="txtFirstName" />
                <telerik:AjaxUpdatedControl ControlID="rcbUserSearch" />
                <telerik:AjaxUpdatedControl ControlID="tblResults" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="rblSearchByRegion">
            <UpdatedControls>
                <%--<telerik:AjaxUpdatedControl ControlID="tblSearchByRegion" />
                <telerik:AjaxUpdatedControl ControlID="tblSearchByUser" />
                <telerik:AjaxUpdatedControl ControlID="rblSearchByRegion" />
                <telerik:AjaxUpdatedControl ControlID="rblSearchByUser" />
                <telerik:AjaxUpdatedControl ControlID="DashboardGrid" />--%>
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="rblSearchByUser">
            <UpdatedControls>
                <%--<telerik:AjaxUpdatedControl ControlID="tblSearchByRegion" />
                <telerik:AjaxUpdatedControl ControlID="tblSearchByUser" />
                <telerik:AjaxUpdatedControl ControlID="rblSearchByRegion" />
                <telerik:AjaxUpdatedControl ControlID="rblSearchByUser" />
                <telerik:AjaxUpdatedControl ControlID="DashboardGrid" />--%>
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="DashboardGrid">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="DashboardGrid" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<asp:ValidationSummary ID="valSummary" runat="server" ValidationGroup="DGroup" DisplayMode="BulletList"
    CssClass="validationMessageBox" />
<br />
<hr class="separator" />
<div class="sectionTitle">
    Dashboard Role Search</div>
<div class="sectionContainer">
    <table id="tblSearchBy" runat="server">
        <tr>
            <td colspan="2">
                <b>Search By:</b>
            </td>
        </tr>
        <tr>
            <td width="100">
                <asp:RadioButton runat="server" ID="rblSearchByRegion" GroupName="ByRegionUser" Text="By Region"
                    AutoPostBack="True" OnCheckedChanged="By_Region" Checked="True" />
            </td>
            <td>
                <asp:RadioButton runat="server" ID="rblSearchByUser" GroupName="ByRegionUser" Text="By User"
                    AutoPostBack="True" OnCheckedChanged="By_User" />
            </td>
        </tr>
    </table>
    <table id="tblSearchByRegion" runat="server">
        <tr>
            <td colspan="2">
                <b>Search By Region</b>
            </td>
        </tr>
        <tr>
            <td width="15%">
                Region:
            </td>
            <td>
                <telerik:RadComboBox ID="rcbRegion" runat="server" Width="220" AutoPostBack="true">
                </telerik:RadComboBox>
                <asp:RequiredFieldValidator ID="rcbRegionreqval" runat="server" Display="None" ErrorMessage="Region is required."
                    ControlToValidate="rcbRegion" ValidationGroup="DGroup" InitialValue="<<--Select Region-->>"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                Organization:
                <asp:RadioButtonList ID="rdOrgCode" runat="server" Width="220px" RepeatDirection="Horizontal"
                    AutoPostBack="true" OnSelectedIndexChanged="rdOrgCode_Changed">
                    <asp:ListItem Text="Old Org Code" Value="o" Selected="True" />
                    <asp:ListItem Text="New Org Code" Value="n" />
                </asp:RadioButtonList>
            </td>
            <td>
                <telerik:RadComboBox ID="rcbOrganization" runat="server" Width="100%" AutoPostBack="true">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td>
                Select User:
            </td>
            <td>
                <telerik:RadComboBox ID="rdUsers" runat="server" Width="420" AutoPostBack="true"
                    EnableLoadOnDemand="True" AllowCustomText="True">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td>
                Role Type:
            </td>
            <td>
                <telerik:RadComboBox ID="rcbRoleType" runat="server" Width="420" AutoPostBack="false">
                </telerik:RadComboBox>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <asp:Button ID="buttonSearch" runat="server" Text="Search" Width="80" ValidationGroup="DGroup" />
                <asp:Button ID="btnClearSearch" runat="server" Text="Clear" Width="80" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <br />
            </td>
        </tr>
    </table>
    <asp:Panel ID="panelMain" runat="server" DefaultButton="btnSearchUser">
        <table id="tblSearchByUser" runat="server">
            <tr>
                <td colspan="3">
                    <b>Search By User</b>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td>
                    Last Name:<asp:TextBox ID="txtLastName" runat="server" Width="180" />
                </td>
                <td>
                    First Name:<asp:TextBox ID="txtFirstName" runat="server" Width="180" />
                </td>
                <td align="right">
                    <asp:Button ID="btnSearchUser" runat="server" Text="Search" Width="80" />
                    <asp:Button ID="btnClearUserSearch" runat="server" Text="Clear" Width="80" />
                </td>
            </tr>
            <tr>
                <td colspan="3" runat="server" id="USearch" visible="true">
                    Select User:<telerik:RadComboBox ID="rcbUserSearch" runat="server" Width="420" Visible="true"
                        AutoPostBack="true">
                    </telerik:RadComboBox>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <table id="tblResults" runat="server">
        <tr>
            <td>
                <div style="border: 1px solid black;">
                    <telerik:RadGrid ID="DashboardGrid" Visible="true" runat="server" SkinID="SearchRADGridView"
                        AutoGenerateColumns="False" AllowSorting="true" AllowPaging="true" CellSpacing="0"
                        GridLines="None" PagerStyle-Position="TopAndBottom" OnNeedDataSource="DashboardGrid_NeedDataSource"
                        OnDeleteCommand="DashboardGrid_DeleteCommand">
                        <MasterTableView DataKeyNames="DashboardRoleID" AllowNaturalSort="false">
                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"
                                HeaderText="Delete">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>
                            <Columns>
                                <telerik:GridButtonColumn Text="Delete" ButtonType="ImageButton" CommandName="Delete"
                                    ConfirmText="Delete this Role Type?" ConfirmDialogType="RadWindow" ConfirmTitle="Delete"
                                    ImageUrl="~/App_Themes/JNP_Default/Images/Icons/icon_delete.gif">
                                    <ItemStyle HorizontalAlign="Center" Width="25" />
                                </telerik:GridButtonColumn>
                                <telerik:GridBoundColumn UniqueName="DRegion" DataField="Region" HeaderText="Region"
                                    FilterControlAltText="Filter RegionID ID column">
                                    <HeaderStyle Width="42" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="DetailLineLegacy" DataField="DetailLineLegacy"
                                    HeaderText="Organization" AllowSorting="false" FilterControlAltText="Filter Organization column">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="User" DataField="UserName" UniqueName="UID"
                                    AllowSorting="true" ShowSortIcon="true">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="RoleType" DataField="DashboardRoleType" HeaderText="Role Type"
                                    AllowSorting="true" ShowSortIcon="true" FilterControlAltText="Filter Role Type column">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn HeaderText="UserID" DataField="UserID" UniqueName="UserID"
                                    Visible="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="OrganizationCode" DataField="OrganizationCode"
                                    Visible="false" HeaderText="Organization" AllowSorting="false" FilterControlAltText="Filter Organization column">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="DashboardRoleTypeID" DataField="DashboardRoleTypeID"
                                    Visible="false" HeaderText="DashboardRoleTypeID">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="RegionID" DataField="RegionID" Visible="false"
                                    HeaderText="RegionID">
                                </telerik:GridBoundColumn>
                            </Columns>
                        </MasterTableView>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                    </telerik:RadGrid>
                </div>
            </td>
        </tr>
    </table>
</div>
