<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlAddEditWorkflowRule.ascx.cs"
    Inherits="HCMS.Portal.Controls.Admin.ctrlAddEditWorkflowRule" %>
<%@ Register Assembly="Microsoft.Practices.EnterpriseLibrary.Validation.Integration.AspNet"
    Namespace="Microsoft.Practices.EnterpriseLibrary.Validation.Integration.AspNet"
    TagPrefix="EntLibVal" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="pde" %>
<%@ Register Src="~/Controls/Message/Message.ascx" TagName="Message" TagPrefix="CreateRule" %>
<%@ Register Src="~/Controls/Admin/ctrlAddEditWorkflowAction.ascx" TagName="ctrlAddEditWorkflowAction"
    TagPrefix="uc1" %>
<telerik:radwindowmanager id="RadWindowManagerRules" runat="server" behaviors="Default"
    skin="WebBlue" reloadonshow="false">
    <windows>
        <telerik:RadWindow ID="rwrgWorkflowRules" runat="server" RegisterWithScriptManager="true"
            Skin="WebBlue" Height="600px" Width="800px" Behaviors="Close" VisibleStatusbar="false"
            Modal="true" ReloadOnShow="true">
        </telerik:RadWindow>
    </windows>
</telerik:radwindowmanager>
<div id="divActions" class="subTableHeader" runat="server" style="display: none;">
    Actions associated With Current Rule
</div>
<%--<div class="subTableHeader" id="divWorkflowRuleInfo" runat="server">
    Current Rule
</div>--%>
<asp:Table ID="tableWorkflowRuleInfo" runat="server" CssClass="blueTable" Width="100%">
    <asp:TableRow ID="TableRow2" runat="server">
        <asp:TableCell>
            <asp:Label ID="lblWorkflowGroupNameValue" runat="server"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label ID="lblStaffingObjectNameValue" runat="server"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label ID="lblCurrentStatusValue" runat="server"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
<asp:UpdatePanel ID="updatePanel1" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="ctrlAddEditWorkflowAction" />
    </Triggers>
    <ContentTemplate>
        <telerik:radgrid id="rgAction" runat="server" autogeneratecolumns="False" cellspacing="0"
            gridlines="None" skinid="customRADGridView" width="100%" onitemcommand="rgAction_ItemCommand"
            onneeddatasource="rgAction_NeedDataSource" onitemdatabound="rgAction_ItemDataBound">
            <mastertableview datakeynames="WorkflowActionRecID" editmode="PopUp" commanditemdisplay="Top"
                commanditemsettings-addnewrecordtext="Add New Workflow Action">
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <EditFormSettings CaptionFormatString="Add Workflow Action" EditColumn-AutoPostBackOnFilter="false">
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                    </EditColumn>
                    <PopUpSettings Height="600px" Width="300px" ScrollBars="Vertical" />
                </EditFormSettings>
                <Columns>
                    <telerik:GridButtonColumn ConfirmText="Delete this action?" ConfirmDialogType="RadWindow"
                        ConfirmTitle="Delete" ButtonType="ImageButton" CommandName="Delete" Text="Delete"
                        UniqueName="DeleteCommandColumn">
                         <ItemStyle VerticalAlign="Top" Width="10" />
                    </telerik:GridButtonColumn>
                    <telerik:GridBoundColumn DataField="ActionTypeName" FilterControlAltText="Filter column column"
                        HeaderText="ActionTypeName" SortExpression="ActionTypeName" UniqueName="ActionTypeName">
                    </telerik:GridBoundColumn>
                </Columns>
            </mastertableview>
        </telerik:radgrid>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="updatePanelrgAction" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="rgAction" />
    </Triggers>
    <ContentTemplate>
        <div id="divAddEditWorkflowAction" runat="server">
            <%--<uc1:ctrlAddEditWorkflowAction ID="ctrlAddEditWorkflowAction" runat="server" CurrentNavigationMode="Insert" />--%>
            <uc1:ctrlAddEditWorkflowAction ID="ctrlAddEditWorkflowAction" runat="server" />
        </div>
    </ContentTemplate>
</asp:UpdatePanel>

<%------------- Add Rule ------------%>

<div class="subTableHeader" id="divWorkflowRules" runat="server"><br/>
    <asp:Label ID="lblAddEditHeader" runat="server"></asp:Label>
</div>
<asp:Table ID="tableWorkflowRules" runat="server" CssClass="blueTable" Width="100%">
    <asp:TableRow>
        <asp:TableCell Width="20%">
            <asp:Label ID="lblGroup" runat="server" Text="Group:"></asp:Label>
            &nbsp; <span class="required">*</span> &nbsp;                 
        </asp:TableCell>
        <asp:TableCell>
            <telerik:radcombobox id="ddlGroup" autopostback="true" width="300px" runat="server"
                markfirstmatch="true" />
            <asp:RequiredFieldValidator ID="ddlGroupreqval" runat="server" Display="None" ErrorMessage="Group is required."
                ControlToValidate="ddlGroup" InitialValue="<<- Select Group ->>" ValidationGroup="Group1">
            </asp:RequiredFieldValidator>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server" ID="trStaffingObjectType">
        <asp:TableCell Width="20%">
            <asp:Label ID="lblStaffingObjectType" runat="server" Text="Staffing Object:"></asp:Label>
            &nbsp; <span class="required">*</span> &nbsp;                 
        </asp:TableCell>
        <asp:TableCell>
            <asp:UpdatePanel ID="updatePanelStaffingObjectType" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlGroup" />
                </Triggers>
                <ContentTemplate>
                    <telerik:radcombobox id="ddlStaffingObjectType" autopostback="true" width="300px"
                        runat="server" markfirstmatch="true" />
                    <asp:RequiredFieldValidator ID="ddlStaffingObjectTypereqval" runat="server" Display="None"
                        ErrorMessage="Staffing Object Type is required." ControlToValidate="ddlStaffingObjectType"
                        InitialValue="<<- Select Staffing Object Type ->>" ValidationGroup="Group2"></asp:RequiredFieldValidator>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server" ID="trWorkflowStatus">
        <asp:TableCell Width="20%">
            <asp:Label ID="lblWorkflowStatus" runat="server" Text="Status:"></asp:Label>
            &nbsp; <span class="required">*</span> &nbsp;                     
        </asp:TableCell>
        <asp:TableCell>
            <asp:UpdatePanel ID="updatePanelWorkflowStatus" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlStaffingObjectType" />
                </Triggers>
                <ContentTemplate>
                    <telerik:radcombobox id="ddlWorkflowStatus" autopostback="true" width="300px" runat="server"
                        markfirstmatch="true" />
                    <asp:RequiredFieldValidator ID="ddlWorkflowStatusreqval" runat="server" Display="None"
                        ErrorMessage="Workflow Status is required." ControlToValidate="ddlWorkflowStatus"
                        InitialValue="<<- Select Workflow Status ->>" ValidationGroup="Group3"></asp:RequiredFieldValidator>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server">
        <asp:TableCell>
            <asp:UpdatePanel ID="updatePanellblmsg" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlStaffingObjectType" />
                </Triggers>
                <ContentTemplate>
                    <asp:Label ID="lblmsg" runat="server" Font-Bold="true"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:TableCell>
        <asp:TableCell CssClass="Action">
            <asp:Button ID="btnContinue" runat="server" Text="Save and Continue" ToolTip="Save and Continue"
                CssClass="formBtn" ValidationGroup="Group4" />&nbsp;
                 <asp:Button ID="btnCancel" runat="server" Text="Cancel" ToolTip="Cancel"
                CssClass="formBtn" ValidationGroup="Group4" /> 
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
