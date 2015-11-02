<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DashboardRole.ascx.cs"
    Inherits="HCMS.Portal.Controls.DashboardRole" %>
<telerik:radajaxloadingpanel id="ajaxLoadingPanelSave" runat="server" />
<telerik:radajaxmanager id="RadAjaxManager1" runat="server" defaultloadingpanelid="ajaxLoadingPanelSave">
    <ajaxsettings>
        <telerik:AjaxSetting AjaxControlID="buttonSearch">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="txtLastName" />
                <telerik:AjaxUpdatedControl ControlID="txtFirstName" />
                <telerik:AjaxUpdatedControl ControlID="tblDashboardRole" />
                <telerik:AjaxUpdatedControl ControlID="lblSearch" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnClear">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="txtLastName" />
                <telerik:AjaxUpdatedControl ControlID="txtFirstName" />
                <telerik:AjaxUpdatedControl ControlID="tblDashboardRole" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnCancel">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="txtLastName" />
                <telerik:AjaxUpdatedControl ControlID="txtFirstName" />
                <telerik:AjaxUpdatedControl ControlID="tblDashboardRole" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnSave">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="valSummary" />
                <telerik:AjaxUpdatedControl ControlID="DashboardGrid" />
                <telerik:AjaxUpdatedControl ControlID="tblDashboardRole" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="DashboardGrid">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="DashboardGrid" />
            </UpdatedControls>
        
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID ="btnRecreateAllSSASRoles">
        <UpdatedControls>
        <telerik:AjaxUpdatedControl ControlID ="pnlRecreateAllSSASRoles" />
        </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID ="btnDeleteAllSSASRoles">
        <UpdatedControls>
        <telerik:AjaxUpdatedControl ControlID ="pnlRecreateAllSSASRoles" />
        </UpdatedControls>
        </telerik:AjaxSetting>

    </ajaxsettings>
</telerik:radajaxmanager>
<asp:ValidationSummary ID="valSummary" runat="server" ValidationGroup="DGroup" DisplayMode="BulletList"
    CssClass="validationMessageBox" />
<asp:Panel ID="panelMoreFields" runat="server" DefaultButton="buttonSearch">
    <br />
    <hr class="separator" />
    <div class="sectionTitle">
        Search User</div>
    <div class="sectionContainer">
        <table width="100%">
            <tr>
                <td>
                    Last Name:<asp:TextBox ID="txtLastName" runat="server" Width="180" />
                </td>
                <td>
                    First Name:<asp:TextBox ID="txtFirstName" runat="server" Width="180" />
                </td>
                <td align="right">
                    <asp:Button ID="buttonSearch" runat="server" Text="Search" Width="80" />
                    <asp:Button ID="btnClear" runat="server" Text="Clear" Width="80" />
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    <br />
                    <asp:Label ID="lblSearch" Font-Bold="true" runat="server" Text="Search Completed. Please select a user from below."
                        Visible="false"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>
<br />
<hr class="separator" />
<asp:Panel ID="panelMain" runat="server">
    <div class="sectionTitle">
        Select User</div>
    <div class="sectionContainer">
        <table id="tblDashboardRole" runat="server">
            <tr>
                <td>
                    Select User:
                </td>
                <td>
                    <telerik:radcombobox id="rdUsers" runat="server" width="420" autopostback="true"
                        allowcustomtext="True" markfirstmatch="True">
                    </telerik:radcombobox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="None"
                        ErrorMessage="User is required." ControlToValidate="rdUsers" ValidationGroup="DGroup"
                        InitialValue="<<--Select User-->>"></asp:RequiredFieldValidator>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    Role Type:
                </td>
                <td align="left">
                    <telerik:radcombobox id="rcbRoleType" runat="server" width="420" autopostback="true"
                        markfirstmatch="true">
                    </telerik:radcombobox>
                    <asp:RequiredFieldValidator ID="rcbRoleTypereqval" runat="server" Display="None"
                        ErrorMessage="Role Type is required." ControlToValidate="rcbRoleType" ValidationGroup="DGroup"
                        InitialValue="<<--Select Role Type-->>"></asp:RequiredFieldValidator>
                </td>
                <td align="left">
                </td>
            </tr>
            <tr>
                <td>
                    Role Description:
                </td>
                <td>
                    <telerik:radtextbox id="txtRoleLabel" runat="server" width="420">
                    </telerik:radtextbox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="None"
                        ErrorMessage="Role Description is required." ControlToValidate="txtRoleLabel"
                        ValidationGroup="DGroup"></asp:RequiredFieldValidator>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    Region:
                </td>
                <td>
                    <telerik:radcombobox id="rcbRegion" runat="server" width="220" autopostback="true"
                        markfirstmatch="true">
                    </telerik:radcombobox>
                    <asp:RequiredFieldValidator ID="rcbRegionreqval" runat="server" Display="None" ErrorMessage="Region is required."
                        ControlToValidate="rcbRegion" ValidationGroup="DGroup" InitialValue="<<--Select Region-->>"></asp:RequiredFieldValidator>
                </td>
                <td>
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
                    <telerik:radcombobox id="rcbOrganization" runat="server" width="100%" autopostback="true"
                        markfirstmatch="true">
                    </telerik:radcombobox>
                    <asp:RequiredFieldValidator ID="rcbOrgreqval" runat="server" Display="None" ErrorMessage="Organization is required."
                        ControlToValidate="rcbOrganization" ValidationGroup="DGroup" InitialValue="<<--Select Organization-->>"></asp:RequiredFieldValidator>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right" colspan="3">
                    <asp:Button ID="btnSave" runat="server" Text="Save" Width="80" ValidationGroup="DGroup" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="80" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <asp:Label ID="lblSave" runat="server" Text="Role has been saved successfully." Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <div style="border: 1px solid black;">
                        <telerik:radgrid id="DashboardGrid" visible="false" runat="server" skinid="SearchRADGridView"
                            autogeneratecolumns="False" allowsorting="true" allowpaging="true" cellspacing="0"
                            gridlines="None" pagerstyle-position="TopAndBottom" ondeletecommand="DashboardGrid_DeleteCommand">
                            <mastertableview datakeynames="DashboardRoleID" allownaturalsort="false">
                                <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column"
                                    HeaderText="Delete">
                                    <HeaderStyle Width="20px"></HeaderStyle>
                                </RowIndicatorColumn>
                                <Columns>
                                    <telerik:GridButtonColumn Text="Delete" ButtonType="ImageButton" CommandName="Delete"
                                        ConfirmText="Delete this Role Type?" ConfirmDialogType="RadWindow" ConfirmTitle="Delete"
                                        ImageUrl="~/App_Themes/JNP_Default/Images/Icons/icon_delete.gif">
                                        <ItemStyle HorizontalAlign="Center" Width="30" />
                                    </telerik:GridButtonColumn>
                                    <telerik:GridBoundColumn UniqueName="DRegion" DataField="Region" HeaderText="Region"
                                        FilterControlAltText="Filter RegionID ID column">
                                        <HeaderStyle Width="34" />
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="DetailLineLegacy" DataField="DetailLineLegacy"
                                        HeaderText="Organization" AllowSorting="false" FilterControlAltText="Filter Organization column">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn UniqueName="RoleType" DataField="DashboardRoleType" HeaderText="Role Type"
                                        AllowSorting="true" ShowSortIcon="true" FilterControlAltText="Filter Role Type column">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn HeaderText="User" DataField="UserName" UniqueName="UID"
                                        AllowSorting="true" ShowSortIcon="true">
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
                            </mastertableview>
                            <filtermenu enableimagesprites="False">
                            </filtermenu>
                        </telerik:radgrid>
                    </div>
                </td>
            </tr>
        </table>
    </div>
</asp:Panel>
<asp:Panel ID="pnlRecreateAllSSASRoles" runat="server" Visible="false" >
<asp:Button ID="btnDeleteAllSSASRoles" runat ="server" Text ="Delete All SSAS Roles" OnClick= "btnDeleteAllSSASRoles_Click" />
    <asp:Button ID="btnRecreateAllSSASRoles" runat="server" Text="Recreate All SSAS Roles"
        OnClick="btnRecreateAllSSASRoles_Click" />
</asp:Panel>
