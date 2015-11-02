<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="editUser.aspx.cs"
    Inherits="HCMS.Portal.Admin.editUser" Title="Edit User Details" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Skin="WebBlue">
    </telerik:RadWindowManager>
    <telerik:RadCodeBlock ID="rcbCodeBlock" runat="server">
        <script type="text/javascript">
        function confirmation()
            {
            
                radconfirm('Updates may affect Organization Code assignments. <br/> <br/>Click OK to save changes.', CallBackFn,'','','','Save Changes?');
            }

        function CallBackFn(arg)
            {
                if(arg)
                    {
                        <%= Page.GetPostBackEventReference(buttonSave) %>
                    }
            }
        </script>
    </telerik:RadCodeBlock>
    <asp:UpdatePanel ID="panelUpdate" runat="server">
        <ContentTemplate>
            <asp:ValidationSummary ID="valSummary" ValidationGroup="EditUser" runat="server"
                CssClass="validationMessageBox" ShowSummary="true" HeaderText="<span class='systemMessage'>Validation Message</span><br>"
                DisplayMode="list" />
            <div class="sectionContainer">
                <table width="100%">
                    <col width="100px" />
                    <col width="100px" />
                    <col width="5px" />
                    <col width="100px" />
                    <col width="*" />
                    <tr>
                        <td>
                            Last Name:
                        </td>
                        <td class="highlight1">
                            <asp:Literal ID="literalLastName" runat="server" />
                        </td>
                        <td>
                        </td>
                        <td>
                            First Name:
                        </td>
                        <td class="highlight1">
                            <asp:Literal ID="literalFirstName" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Email Address:
                        </td>
                        <td colspan="4" class="highlight1">
                            <asp:Literal ID="literalEmail" runat="server" />
                        </td>
                    </tr>
                    <tr id="rowSupStatus" runat="server">
                        <td>
                            Supervisor Status ID:
                        </td>
                        <td colspan="4" valign="top" class="highlight1">
                            <asp:Literal ID="literalSupStatusID" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Assigned Role:
                        </td>
                        <td colspan="4" valign="top" class="highlight1">
                            <asp:Literal ID="literalRoleName" runat="server" /><telerik:RadComboBox ID="radComboRoles"
                                runat="server" AutoPostBack="true" Width="200px" CausesValidation="false" />
                            &nbsp;<asp:RequiredFieldValidator ID="requiredRole" runat="server" ControlToValidate="radComboRoles"
                                ValidationGroup="EditUser" ErrorMessage="You must select a role before this account can be modified.">*</asp:RequiredFieldValidator><div
                                    class="highlight2">
                                    <asp:Literal ID="literalRole" runat="server" /></div>
                        </td>
                    </tr>
                    <tr id="rowRegion" runat="server">
                        <td>
                            Region:
                        </td>
                        <td colspan="4" class="highlight1">
                            <asp:Literal ID="literalRegionName" runat="server" /><telerik:RadComboBox CausesValidation="false"
                                ID="radComboRegions" runat="server" AutoPostBack="false" Width="200px" />
                            &nbsp;<asp:RequiredFieldValidator ID="requiredRegion" runat="server" ControlToValidate="radComboRegions"
                                ValidationGroup="EditUser" ErrorMessage="You must select a region for this account.">*</asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Status:
                        </td>
                        <td colspan="4" valign="top" class="noBorder">
                            <asp:RadioButtonList ID="radioButtonListStatus" runat="server" RepeatColumns="2">
                                <asp:ListItem Text="Active" Value="1" />
                                <asp:ListItem Text="Inactive" Value="0" />
                            </asp:RadioButtonList>
                            <div class="highlight2">
                                <asp:Literal ID="literalPDStatus" runat="server" />
                                <asp:Literal ID="literalJNPStatus" runat="server" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td colspan="4">
                            <asp:Button ID="buttonSave" runat="server" OnClientClick="confirmation(); return false;"
                                ValidationGroup="EditUser" Text="Save User" CausesValidation="true" Enabled="false" />&nbsp;<asp:Button
                                    ID="buttonDelegatePD" runat="server" Text="Delegate PD" CausesValidation="false" />
                            &nbsp;<asp:Button ID="buttonDelegateJNP" runat="server" Text="Delegate JAX" CausesValidation="false" />
                            &nbsp;<asp:Button ID="buttonDelegateOrgChart" runat ="server" Text="Delegate OrgChart" CausesValidation ="false" />
                        </td>
                    </tr>
                </table>
            </div>
            <asp:Panel ID="panelSystem" runat="server" Visible="false" HorizontalAlign="Center">
                <br />
                <hr class="separator" />
                <div class="systemMessage" style="width: 575px" align="center">
                    <asp:Literal ID="literalSystem" runat="server" /></div>
                <br />
            </asp:Panel>
            <asp:Panel ID="pnlOrdCodeAssignment" runat="server">
                <br />
                <hr class="separator" />
                <div class="sectionTitle">
                    Organization Code Assignment</div>
                <div class="sectionContainer">
                    <table width="100%">
                        <col width="85px" />
                        <tr id="rowRegion2" runat="server">
                            <td>
                                Region:
                            </td>
                            <td colspan="2">
                                <telerik:RadComboBox ID="radComboRegions2" runat="server" AutoPostBack="true" CausesValidation="false"
                                    Width="300px" />
                                &nbsp;<asp:RequiredFieldValidator ID="requiredRegion2" runat="server" ControlToValidate="radComboRegions2"
                                    ErrorMessage="You must select a region to filter the organization codes.">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" width="225px">
                                <asp:RadioButtonList ID="rdOrgCode" runat="server" Width="225px" RepeatDirection="Horizontal"
                                    AutoPostBack="true" OnSelectedIndexChanged="rdOrgCode_Changed">
                                    <asp:ListItem Text="Old Org Code" Value="o" Selected="True" />
                                    <asp:ListItem Text="New Org Code" Value="n" />
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <telerik:RadComboBox ID="radComboOrgCodes" runat="server" AutoPostBack="false" CausesValidation="false"
                                    Width="325px" MarkFirstMatch="true" />
                                &nbsp;<asp:RequiredFieldValidator ID="requiredOrgCodes" runat="server" ControlToValidate="radComboOrgCodes"
                                    ValidationGroup="OrgCodeVal" ErrorMessage="You must select an organization code before it can be added to this account.">*</asp:RequiredFieldValidator>
                                <asp:CheckBox ID="ChkAssignChildren" runat="server" Text="Assign Children" />
                            </td>
                            <td align="right">
                                <asp:Button ID="buttonAssignOrgCode" runat="server" Text="Assign" CausesValidation="true"
                                    ValidationGroup="OrgCodeVal" />
                            </td>
                    </table>
                </div>
            </asp:Panel>
            <asp:Panel ID="panelOrgCodes" runat="server">
                <br />
                <asp:UpdatePanel ID="updtPanelOrgcodes" runat="server" UpdateMode="Conditional">
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="buttonAssignOrgCode" />
                    </Triggers>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="buttonSave" />
                    </Triggers>
                    <ContentTemplate>
                        <asp:GridView ID="gridViewOrgCodes" SkinID="adminGridView" runat="server" Width="100%"
                            AllowSorting="false" AllowPaging="true" PageSize="10" AutoGenerateColumns="false"
                            DataKeyNames="organizationCodeID">
                            <RowStyle Width="250px" />
                            <EmptyDataTemplate>
                                <div align="center" class="systemMessage">
                                    There are no organizational codes currently assigned to this user.</div>
                            </EmptyDataTemplate>
                            <Columns>
                                <asp:TemplateField HeaderText="Action" ItemStyle-Width="65px" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <asp:ImageButton SkinID="deleteIcon" ID="imageButtonDelete" CommandName="Delete"
                                            runat="server" AlternateText="Delete this Organization Code?" CausesValidation="false" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--   
            //Issue Id: 50
            //Author: Deepali Anuje
            //Date Fixed: 1/29/2012
            //Description:  Display old 5 digit org codes on Admin and Create screens
                                --%>
                                <asp:BoundField DataField="DetailLineLegacy" HeaderText="Organization Code" />
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
</asp:Content>
