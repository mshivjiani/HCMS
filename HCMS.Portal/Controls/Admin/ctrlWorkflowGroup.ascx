<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlWorkflowGroup.ascx.cs"
    Inherits="HCMS.Portal.Controls.Admin.ctrlWorkflowGroup" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadWindowManager ID="RadWindowManagerGroups" runat="server" Behaviors="Default"
    Skin="WebBlue" ReloadOnShow="false">
    <Windows>
        <telerik:RadWindow ID="rwrgWorkflowGroups" runat="server" RegisterWithScriptManager="true"
            Skin="WebBlue" Height="600px" Width="800px" Behaviors="Close" VisibleStatusbar="false"
            Modal="true" ReloadOnShow="true">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>
<%--<telerik:RadWindowManager ID="RadWindowManagerPermissions" runat="server" Behaviors="Default"
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
</telerik:RadWindowManager>--%>
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rgWorkflowGroup">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgPermission" />
            </UpdatedControls>
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgRule" />
            </UpdatedControls>
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgAction" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<%--<asp:ValidationSummary ID="valSummary" runat="server" CssClass="validationMessageBox"
    ShowSummary="true" HeaderText="<span class='systemMessage'>Validation Message</span><br>"
    DisplayMode="BulletList" ValidationGroup="internalValidation" />--%>
<div class="subTableHeader">
    List of Groups
</div>
<telerik:RadGrid ID="rgWorkflowGroup" runat="server" CellSpacing="0" GridLines="None"
    SkinID="customRADGridView" OnItemCommand="rgWorkflowGroup_ItemCommand" AutoGenerateColumns="False"
    OnItemDataBound="rgWorkflowGroup_ItemDataBound">
    <MasterTableView DataKeyNames="WorkflowGroupID" CommandItemDisplay="Top" CommandItemSettings-AddNewRecordText="Add New Workflow Group">
        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
            <HeaderStyle Width="20px"></HeaderStyle>
        </RowIndicatorColumn>
        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
            <HeaderStyle Width="20px"></HeaderStyle>
        </ExpandCollapseColumn>
        <EditFormSettings CaptionFormatString="Add Workflow Group">
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
                    <asp:ImageButton ID="ImageButtonUpdate" runat="server" ToolTip='<%# (Container is GridDataInsertItem) ? "Add Workflow Group" : "Save Workflow Group" %>'
                        SkinID="updateButton" CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>' />
                    <asp:LinkButton ID="LinkButtonUpdate" runat="server" Text='<%# (Container is GridDataInsertItem) ? "Add Workflow Group" : "Save Workflow Group" %>'
                        CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>'>Save Workflow Group</asp:LinkButton>
                    <asp:ImageButton ID="ImageButtonCancel" runat="server" ToolTip="Cancel" CommandName="Cancel" />
                    <asp:LinkButton ID="LinkButtonCancel" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                </EditItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridButtonColumn ConfirmText="Delete this group?" ConfirmDialogType="RadWindow"
                ConfirmTitle="Delete" ButtonType="ImageButton" CommandName="Delete" Text="Delete"
                Visible="false" UniqueName="DeleteCommandColumn">
                <ItemStyle VerticalAlign="Top" Width="10" />
            </telerik:GridButtonColumn>
            <%-- <telerik:GridTemplateColumn>
                <ItemStyle VerticalAlign="Top" Width="10" />
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButtonView" runat="server" ToolTip="View" CommandName="View"
                        SkinID="viewButton" /></ItemTemplate>
            </telerik:GridTemplateColumn>--%>
            <telerik:GridTemplateColumn HeaderText="Workflow Group Name" DataField="WorkflowGroupName"
                UniqueName="WorkflowGroupName">
                <ItemTemplate>
                    <asp:Label ID="lblWorkflowGroupName" runat="server" Text='<%# Eval("WorkflowGroupName")%>'></asp:Label>
                </ItemTemplate>
            </telerik:GridTemplateColumn>
        </Columns>
        <EditFormSettings>
            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
            </EditColumn>
        </EditFormSettings>
    </MasterTableView>
    <FilterMenu EnableImageSprites="False">
    </FilterMenu>
</telerik:RadGrid>
<%--<asp:Panel ID="pnlPermission" runat="server" Width="100%">
    <div class="subTableHeader">
        List of Permissions
    </div>
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
                <telerik:GridTemplateColumn>
                    <ItemStyle VerticalAlign="Top" Width="10" />
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButtonView" runat="server" ToolTip="View" CommandName="View"
                            SkinID="viewButton" /></ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="WorkflowGroupName" FilterControlAltText="Filter column column"
                    HeaderText="WorkflowGroupName" SortExpression="WorkflowGroupName" UniqueName="WorkflowGroupName">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="PermissionName" FilterControlAltText="Filter column column"
                    HeaderText="PermissionName" SortExpression="PermissionName" UniqueName="PermissionName">
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn HeaderText="Add/Remove Permission" UniqueName="AddRemovePermission">
                    <ItemTemplate>
                        <asp:CheckBox ID="chkAddRemovePermission" runat="server" OnCheckedChanged="chkAddRemovePermission_Change" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
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
<asp:Panel ID="pnlRule" runat="server" Width="100%">
    <div class="subTableHeader">
        List of Rules
    </div>
    <telerik:RadGrid ID="rgRule" runat="server" AutoGenerateColumns="False" CellSpacing="0"
        GridLines="None" SkinID="customRADGridView" Width="100%" OnNeedDataSource="rgRule_NeedDataSource"
        OnItemCommand="rgRule_ItemCommand">
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
                <telerik:GridTemplateColumn>
                    <ItemStyle VerticalAlign="Top" Width="10" />
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButtonView" runat="server" ToolTip="View" CommandName="View"
                            SkinID="viewButton" /></ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="WorkflowGroupName" FilterControlAltText="Filter column column"
                    HeaderText="WorkflowGroupName" SortExpression="WorkflowGroupName" UniqueName="WorkflowGroupName">
                </telerik:GridBoundColumn>
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
</asp:Panel>--%>
