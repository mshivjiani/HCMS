<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PDTracker.ascx.cs" Inherits="HCMS.PDExpress.Controls.PDExpress.PDTracker" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" EnableAJAX="true">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rgDashBoard">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgDashBoard" LoadingPanelID="rlpDefault" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<telerik:RadAjaxLoadingPanel ID="rlpDefault" runat="server" Skin="Web20" />
<telerik:RadWindowManager ID="DefaultRadWindowManager" runat="server" ReloadOnShow="true"
    Skin="WebBlue">
    <Windows>
        <telerik:RadWindow ID="rwAddEditNotePopup" runat="server" ReloadOnShow="true" Skin="WebBlue"
            Modal="True" Width="790px" Height="500px" Style="z-index: 7500; display: none;"
            VisibleOnPageLoad="false" Behaviors="None" InitialBehaviors="None" VisibleStatusbar="False" />
    </Windows>
</telerik:RadWindowManager> 
<telerik:RadCodeBlock ID="rcbCodeBlock" runat="server">
    <script type="text/javascript">
        //                function ShowAddEditNotePopup(positionDescriptionID, isCheckedOut) {
        //                    var oWnd = radopen("./Controls/WorkflowNotePopup/WorkflowNotePopup.aspx?PositionDescriptionID=" + positionDescriptionID + "&IsCheckedOut=" + isCheckedOut, "rwAddEditNotePopup");
        //                }

        //Added CheckedOutByID
        function ShowAddEditNotePopup(positionDescriptionID, isCheckedOut, CheckedOutByID) {
            var oWnd = radopen("./Controls/WorkflowNotePopup/WorkflowNotePopup.aspx?PositionDescriptionID=" + positionDescriptionID + "&IsCheckedOut=" + isCheckedOut + "&CheckedOutByID=" + CheckedOutByID, "rwAddEditNotePopup");
        }

        //following script is to confirm PD deletion
        var clickCalledAfterRadconfirm = false;
        var lastClickedItem = null;
        function OnPDActionMenuClick(sender, eventArgs) {
            if (!clickCalledAfterRadconfirm) {
                lastClickedItem = eventArgs.get_item();
                if (lastClickedItem.get_text() == "Delete") {
                    eventArgs.set_cancel(true);
                    radconfirm("Deleting this PD will permanently remove this PD from the PD Express database.<br/>  Are you sure you want to proceed with this action?", confirmCallbackFunction, 330, 180, null, 'Delete?');
                }

            }
            clickCalledAfterRadconfirm = false;
        }
        function confirmCallbackFunction(args) {
            if (args) {
                clickCalledAfterRadconfirm = true;

                lastClickedItem.click();
            }
            else
                clickCalledAfterRadconfirm = false;

            lastClickedItem = null;
        }

        //end confirm delete script
    </script>
</telerik:RadCodeBlock>
<!--
        Note: I'm changing the z-index of the RadWindow so that popup windows (rwAddEditNotePopup
        and rwEditWorkflowNotePopup from WorkflowNotePopup.ascx) appear in front of the RadMenu that is
        in the grid. 
        
        For more information read the folloring article:
        http://www.telerik.com/help/aspnet-ajax/controlling-absolute-positioning-with-zindex.html
        
        By default the z-index of RadMenu is 7000 and RadWindow is 3000. Bellow I'm changing the z-index
        of the window to 7500
        -->
<div class="requiredField">
    <asp:Literal ID="litReviewNotesmsg" runat="server" Text="If you see a <img src= '~/App_Themes/PDExpress_Default/Images/Icons/icon_edit.gif' />  icon in the Status column, review notes & factors of your PD for HR recommended updates."></asp:Literal>
</div>
<telerik:RadGrid ID="rgDashBoard" runat="server" SkinID="SearchcustomRADGridView" Width="100%"
    AllowPaging="true" PageSize="10" PagerStyle-AlwaysVisible="false" PagerStyle-Position="TopAndBottom"
    AllowSorting="true" AllowMultiRowSelection="true" OnNeedDataSource="rgDashBoard_NeedDataSource"
    OnItemDataBound="rgDashBoard_ItemDataBound" OnItemCommand="rgDashBoard_ItemCommand">
    <MasterTableView Width="100%" GridLines="Both" DataKeyNames="PositionDescriptionID, AssociatedFullPD" AllowNaturalSort="false">
        <RowIndicatorColumn>
            <HeaderStyle Width="20px"></HeaderStyle>
        </RowIndicatorColumn>
        <ExpandCollapseColumn>
            <HeaderStyle Width="20px"></HeaderStyle>
        </ExpandCollapseColumn>
        <Columns>
            <telerik:GridTemplateColumn HeaderText="PD Action" Visible="true" ItemStyle-Width="12%">
                <ItemTemplate>
                    <telerik:RadMenu ID="rmPDAction" runat="server" OnItemClick="rmPDAction_ItemClick"
                        OnClientItemClicking="OnPDActionMenuClick" EnableImageSprites="true">
                        <Items>
                            <telerik:RadMenuItem Width="30px" CssClass="ddicon" Height="24px">
                                <Items>
                                    <telerik:RadMenuItem Text="View" Value="View" />
                                    <telerik:RadMenuItem Text="Edit" Value="Edit" />
                                    <telerik:RadMenuItem Text="Continue Edit" Value="ContinueEdit" />
                                    <telerik:RadMenuItem Text="Finish Edit" Value="FinishEdit" />
                                    <telerik:RadMenuItem Text="Delete" Value="Delete" />
                                     
                                </Items>
                            </telerik:RadMenuItem>
                        </Items>
                    </telerik:RadMenu>
                    &nbsp;
                    <asp:Image ID="imgPDCheckedOutStatus" Visible="false" runat="server" />
                </ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn HeaderText="PD No." DataField="PositionDescriptionIDValue"
                UniqueName="PositionDescriptionID" ItemStyle-HorizontalAlign="Center" DataType="System.Int64"
                ItemStyle-Width="12%">
                <ItemTemplate>
                    <asp:Label ID="lblPDNumber" runat="server" />
                </ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn HeaderText="Grade" ItemStyle-HorizontalAlign="Center"
                UniqueName="JobGrade" ItemStyle-Width="6%">
                <ItemTemplate>
                    <asp:Label ID="lblGrade" runat="server" />
                </ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn HeaderText="Title" DataField="AgencyPositionTitle" UniqueName="AgencyPositionTitle"
                SortExpression="AgencyPositionTitle" ItemStyle-Width="14%">
                <ItemTemplate>
                    <asp:Label ID="lblAgencyPositionTitle" runat="server" Text='<%#Eval("AgencyPositionTitle") %>'></asp:Label></ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridBoundColumn HeaderText="Org Code New (Old)" DataField="OrganizationCodeLegacy"
                UniqueName="OrganizationCodeLegacy" AllowSorting="true" DataType="System.String"
                ItemStyle-Width="11%" />
            <telerik:GridDateTimeColumn HeaderText="Created" DataField="PDCreateDate" UniqueName="PDCreateDate"
                DataFormatString="{0:MM/dd/yyyy}" AllowSorting="true" DataType="System.DateTime"
                ItemStyle-Width="9%" />
            <telerik:GridBoundColumn HeaderText="Created By" DataField="CreatedBy" UniqueName="CreatedBy"
                AllowSorting="true" DataType="System.String" ItemStyle-Width="10%" />
            <telerik:GridDateTimeColumn HeaderText="Updated" DataField="UpdateDate" UniqueName="UpdateDate"
                DataFormatString="{0:MM/dd/yyyy}" AllowSorting="true" DataType="System.DateTime"
                ItemStyle-Width="9%" />
            <telerik:GridBoundColumn HeaderText="Updated By" DataField="UpdatedBy" UniqueName="UpdatedBy"
                AllowSorting="true" DataType="System.String" ItemStyle-Width="9%" />
            <telerik:GridTemplateColumn HeaderText="Status" DataField="WorkflowStatus" UniqueName="WorkflowStatus"
                SortExpression="WorkflowStatus" HeaderStyle-Width="85px" ItemStyle-Width="11%">
                <ItemStyle Wrap="false" />
                <ItemTemplate>
                    <div>
                        <asp:Label ID="lblWorkflowStatus" runat="server" Style="vertical-align: middle;" />&nbsp;
                        <asp:ImageButton ID="btnWorkflowNote" runat="server" Style="vertical-align: middle;"
                            Visible="false" ToolTip="Add/Edit Notes" />
                    </div>
                </ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn HeaderText="Schedule" UniqueName="ScheduleStatus" SortExpression="ScheduleStatus"
                ItemStyle-Width="11%">
                <ItemStyle Wrap="false" />
                <ItemTemplate>
                    <div>
                        <asp:Image ID="imgScheduleStatus" runat="server" Style="vertical-align: middle;" />
                        &nbsp;
                        <asp:Label ID="lblScheduleStatus" runat="server" Style="vertical-align: middle;" />
                    </div>
                    <asp:Label ID="lblNextStatus" runat="server" Style="vertical-align: middle;"></asp:Label>
                </ItemTemplate>
            </telerik:GridTemplateColumn>
        </Columns>
    </MasterTableView>
</telerik:RadGrid>
<br />
<telerik:RadGrid ID="rgHidden" runat="server" SkinID="customRADGridView" Width="100%"
    Visible="false" AllowPaging="true" PageSize="10" PagerStyle-AlwaysVisible="false"
    PagerStyle-Position="TopAndBottom" AllowSorting="true" AllowMultiRowSelection="true">
    <MasterTableView Width="100%" GridLines="Both" DataKeyNames="PositionDescriptionID, AssociatedFullPD">
        <Columns>
            <telerik:GridBoundColumn DataField="PositionDescriptionID" />
        </Columns>
    </MasterTableView>
</telerik:RadGrid>
