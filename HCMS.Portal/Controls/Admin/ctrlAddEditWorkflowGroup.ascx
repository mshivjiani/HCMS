<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlAddEditWorkflowGroup.ascx.cs"
    Inherits="HCMS.Portal.Controls.Admin.ctrlAddEditWorkflowGroup" %>
<%@ Register Assembly="Microsoft.Practices.EnterpriseLibrary.Validation.Integration.AspNet"
    Namespace="Microsoft.Practices.EnterpriseLibrary.Validation.Integration.AspNet"
    TagPrefix="EntLibVal" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="pde" %>
<%@ Register Src="~/Controls/Message/Message.ascx" TagName="Message" TagPrefix="AddEditGroup" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Admin/ctrlAddEditWorkflowRule.ascx" TagName="ctrlAddEditWorkflowRule"
    TagPrefix="uc1" %>
<telerik:RadWindowManager ID="RadWindowManagerPermissions" runat="server" Behaviors="Default"
    Skin="WebBlue" ReloadOnShow="false">
    <Windows>
        <telerik:RadWindow ID="rwrgWorkflowPermissions" runat="server" RegisterWithScriptManager="true"
            Skin="WebBlue" Height="600px" Width="800px" Behaviors="Close" VisibleStatusbar="false"
            Modal="true" ReloadOnShow="true">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>
<telerik:RadWindowManager ID="RadWindowManagerRules" runat="server" Behaviors="Default"
    Skin="WebBlue" ReloadOnShow="false">
    <Windows>
        <telerik:RadWindow ID="rwrgWorkflowRules" runat="server" RegisterWithScriptManager="true"
            Skin="WebBlue" Height="600px" Width="800px" Behaviors="Close" VisibleStatusbar="false"
            Modal="true" ReloadOnShow="true">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>
<div class="subTableHeader" id="divWorkflowGroups" runat="server">
    <asp:Label ID="lblAddEditHeader" runat="server"></asp:Label>
</div>
<cc1:Accordion ID="accGroup" runat="server" AutoSize="None" RequireOpenedPane="false"
    SelectedIndex="-1" HeaderCssClass="blueAccordionHeader" HeaderSelectedCssClass="blueAccordionHeaderSelected">
    <Panes>
        <cc1:AccordionPane ID="accPanelGroupPermissions" runat="server">
            <Header>
            <asp:Label ID="lblHeaderPermissionGroup" runat="server"></asp:Label>
            </Header>
            <Content>
                <asp:Panel ID="pnlPermission" runat="server" Width="100%">                   
                    <telerik:RadGrid ID="rgPermission" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                        GridLines="None" SkinID="customRADGridView" Width="100%" OnNeedDataSource="rgPermission_NeedDataSource"
                        OnItemCommand="rgPermission_ItemCommand">
                        <MasterTableView DataKeyNames="WorkflowGroupRecID" EditMode="PopUp" CommandItemDisplay="Top"
                            CommandItemSettings-AddNewRecordText="Add New Workflow Permission">
                            <CommandItemSettings ExportToPdfText="Export to PDF" />
                            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                <HeaderStyle Width="20px" />
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                <HeaderStyle Width="20px" />
                            </ExpandCollapseColumn>
                            <EditFormSettings CaptionFormatString="Add Workflow Permission">
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                                <PopUpSettings Height="600px" Width="300px" ScrollBars="Vertical" />
                            </EditFormSettings>
                            <Columns>
                                <telerik:GridTemplateColumn>
                                    <ItemStyle VerticalAlign="Top" Width="10" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButtonEdit" runat="server" ToolTip="Edit" CommandName="Edit"
                                            SkinID="editButton" />
                                    </ItemTemplate>
                                    <%--<EditItemTemplate>
                                        <asp:ImageButton ID="ImageButtonUpdate" runat="server" ToolTip='<%# (Container is GridDataInsertItem) ? "Add Workflow Rule" : "Save Workflow Rule" %>'
                                            SkinID="updateButton" CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>' />
                                        <asp:LinkButton ID="LinkButtonUpdate" runat="server" Text='<%# (Container is GridDataInsertItem) ? "Add Workflow Rule" : "Save Workflow Rule" %>'
                                            CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>'>Save Workflow Rule</asp:LinkButton>
                                        <asp:ImageButton ID="ImageButtonCancel" runat="server" ToolTip="Cancel" CommandName="Cancel" />
                                        <asp:LinkButton ID="LinkButtonCancel" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                                    </EditItemTemplate>--%>
                                </telerik:GridTemplateColumn>
                                <telerik:GridButtonColumn ConfirmText="Delete this rule?" ConfirmDialogType="RadWindow"
                                    ConfirmTitle="Delete" ButtonType="ImageButton" CommandName="Delete" Text="Delete"
                                    UniqueName="DeleteCommandColumn">
                                    <ItemStyle VerticalAlign="Top" Width="10" />
                                </telerik:GridButtonColumn>
                               
                                <telerik:GridBoundColumn DataField="PermissionName" FilterControlAltText="Filter column column"
                                    HeaderText="PermissionName" SortExpression="PermissionName" UniqueName="PermissionName">
                                </telerik:GridBoundColumn>
                            </Columns>
                            <EditFormSettings>
                                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                </EditColumn>
                            </EditFormSettings>
                        </MasterTableView>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                    </telerik:RadGrid>
                </asp:Panel>
            </Content>
        </cc1:AccordionPane>
        <cc1:AccordionPane ID="accPanelGroupRules" runat="server">
            <Header>
                <asp:Label ID="lblHeaderRulesGroup" runat="server"></asp:Label>
            </Header>
            <Content>
                <asp:Panel ID="pnlRule" runat="server" Width="100%">
                    <asp:Table ID="tableWorkflowRules" runat="server" CssClass="blueTable" Width="100%">
                        <asp:TableRow runat="server">
                            <asp:TableCell Width="20%">
                                <asp:Label ID="lblStaffingObjectType" runat="server" Text="Staffing Object:"></asp:Label>
                                &nbsp; <span class="required">*</span> &nbsp;
                            </asp:TableCell>
                            <asp:TableCell>
                                <telerik:RadComboBox ID="ddlStaffingObjectType" Width="300px" runat="server" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlStaffingObjectType_SelectedIndexChanged" />
                                <asp:RequiredFieldValidator ID="ddlStaffingObjectTypereqval" runat="server" Display="None"
                                    ErrorMessage="Staffing Object Type is required." ControlToValidate="ddlStaffingObjectType"
                                    InitialValue="<<- Select Staffing Object Type ->>" ValidationGroup="Group2"></asp:RequiredFieldValidator>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <br />                          
                    <asp:UpdatePanel ID="updatePanelrgRule" runat="server" UpdateMode="Conditional">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlStaffingObjectType" />
                        </Triggers>
                        <ContentTemplate>
                            <telerik:RadGrid ID="rgRule" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                                GridLines="None" SkinID="customRADGridView" Width="100%" OnNeedDataSource="rgRule_NeedDataSource"
                                OnItemCommand="rgRule_ItemCommand" OnItemDataBound="rgRule_ItemDataBound">
                                <MasterTableView DataKeyNames="WorkflowRuleID" EditMode="PopUp" CommandItemDisplay="Top"
                                    CommandItemSettings-AddNewRecordText="Add New Workflow Rule">
                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>
                                    <EditFormSettings CaptionFormatString="Add Workflow Rule">
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                        </EditColumn>
                                        <PopUpSettings Height="600px" Width="300px" ScrollBars="Vertical" />
                                    </EditFormSettings>
                                    <Columns>
                                        <telerik:GridTemplateColumn>
                                            <ItemStyle VerticalAlign="Top" Width="10" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButtonEdit" runat="server" ToolTip="Edit" CommandName="Edit"
                                                    SkinID="editButton" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="ImageButtonUpdate" runat="server" ToolTip='<%# (Container is GridDataInsertItem) ? "Add Workflow Rule" : "Save Workflow Rule" %>'
                                                    SkinID="updateButton" CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>' />
                                                <asp:LinkButton ID="LinkButtonUpdate" runat="server" Text='<%# (Container is GridDataInsertItem) ? "Add Workflow Rule" : "Save Workflow Rule" %>'
                                                    CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>'>Save Workflow Rule</asp:LinkButton>
                                                <asp:ImageButton ID="ImageButtonCancel" runat="server" ToolTip="Cancel" CommandName="Cancel" />
                                                <asp:LinkButton ID="LinkButtonCancel" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                                            </EditItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridButtonColumn ConfirmText="Delete this rule?" ConfirmDialogType="RadWindow"
                                            ConfirmTitle="Delete" ButtonType="ImageButton" CommandName="Delete" Text="Delete"
                                            UniqueName="DeleteCommandColumn">
                                            <ItemStyle VerticalAlign="Top" Width="10" />
                                        </telerik:GridButtonColumn>
                                       <%-- <telerik:GridTemplateColumn Visible="false">
                                            <ItemStyle VerticalAlign="Top" Width="10" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButtonView" runat="server" ToolTip="View" CommandName="View"
                                                    SkinID="viewButton" /></ItemTemplate>
                                        </telerik:GridTemplateColumn>--%>
                                        <telerik:GridBoundColumn DataField="StaffingObjectTypeName" FilterControlAltText="Filter column column"
                                            HeaderText="StaffingObjectTypeName" SortExpression="StaffingObjectTypeName" UniqueName="StaffingObjectTypeName">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="StaffingObjectCurrentStatusName" FilterControlAltText="Filter column column"
                                            HeaderText="StaffingObjectCurrentStatusName" SortExpression="StaffingObjectCurrentStatusName"
                                            UniqueName="StaffingObjectCurrentStatusName">
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                    <EditFormSettings>
                                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                                        </EditColumn>
                                    </EditFormSettings>
                                </MasterTableView>
                                <FilterMenu EnableImageSprites="False">
                                </FilterMenu>
                            </telerik:RadGrid>
                            <br />
                            <div id="divAddEditWorkflowRule" runat="server">
                                <uc1:ctrlAddEditWorkflowRule ID="ctrlAddEditWorkflowRule" runat="server" CurrentNavigationMode="Insert" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </Content>
        </cc1:AccordionPane>
    </Panes>
</cc1:Accordion>
