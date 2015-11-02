<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlOrgChartTracker.ascx.cs"
    Inherits="HCMS.OrgChart.Controls.Tracker.ctrlOrgChartTracker" %>
<telerik:RadCodeBlock ID="rcbCodeBlock" runat="server">
 <script type="text/javascript">
        //following script is to confirm OrgChart deletion
        var clickCalledAfterRadconfirm = false;
        var lastClickedItem = null;
        function OnOrgChartActionMenuClick(sender, eventArgs) {
            if (!clickCalledAfterRadconfirm) {
                lastClickedItem = eventArgs.get_item();
                if (lastClickedItem.get_text() == "Delete") {
                    eventArgs.set_cancel(true);
                    radconfirm("Deleting this Organization chart will permanently delete it.<br/>  Are you sure you want to proceed with this action?", confirmCallbackFunction, 330, 180, null, 'Delete?');
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

        //end 
            </script>
</telerik:RadCodeBlock>
<style type="text/css">
    .rgExpandCol
    {
        display: none !important;
    }
</style>
<div>
    <telerik:RadGrid ID="OrgChartTrackerGrid" runat="server" 
        AutoGenerateColumns="False" AllowSorting="true" AllowPaging="true" CellSpacing="0"
        GridLines="None" PagerStyle-Position="TopAndBottom" OnNeedDataSource="OrgChartTrackerGrid_NeedDataSource"
        OnItemCreated="OrgChartTrackerGrid_ItemCreated" OnItemDataBound="OrgChartTrackerGrid_ItemDataBound">
        <MasterTableView DataKeyNames="OrganizationChartID">
            <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
            <NoRecordsTemplate>
                <div>
                    There are no Organization Charts to track.</div>
            </NoRecordsTemplate>
            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="25px"></HeaderStyle>
            </RowIndicatorColumn>
            <Columns>
                <telerik:GridTemplateColumn UniqueName="ActionColumn" HeaderText="Action" FilterControlAltText="Filter Action column"
                    HeaderStyle-Width="55px" ItemStyle-Width="55px">
                    <ItemTemplate>
                        <telerik:RadMenu ID="OrgChartTrackerMenu" runat="server" OnItemClick="OrgChartTrackerMenu_ItemClick" 
                        OnClientItemClicking="OnOrgChartActionMenuClick"
                            EnableImageSprites="true">
                            <Items>
                                <telerik:RadMenuItem CssClass="ddicon" Width="30px" Height="24px">
                                    <Items>
                                        <telerik:RadMenuItem Text="View" Value="View" />
                                        <telerik:RadMenuItem Text="Edit" Value="Edit" />
                                        <telerik:RadMenuItem Text="Continue Edit" Value="ContinueEdit" />
                                        <telerik:RadMenuItem Text="Finish Edit" Value="FinishEdit" />
                                        <telerik:RadMenuItem Text="Delete" Value="Delete" Visible="false" />
                                    </Items>
                                </telerik:RadMenuItem>
                            </Items>
                        </telerik:RadMenu>
                        &nbsp;
                        <asp:Image ID="imgOrgChartCheckedOutStatus" CssClass="checked" Visible="false" runat="server" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn UniqueName="OrganizationChartID" DataField="OrganizationChartID"
                    HeaderText="Org Chart ID">
                    <HeaderStyle Width="100" />
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="Region" HeaderText="Region" DataField="Region">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Org Code New (Old)" DataField="ChartOrganizationCode.OrganizationCodeLegacy"
                    UniqueName="OrganizationCodeLegacy">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="ChartType" DataField="OrganizationChartType"
                    HeaderText="Org Chart Type">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="CreatedBy" DataField="CreatedBy.FullNameReverse"
                    HeaderText="Created By">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="CreatedBy.ActionDate" HeaderText="Create Date"
                    DataFormatString="{0:MM/dd/yyyy}">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="UpdatedBy" DataField="UpdatedBy.FullNameReverse"
                    HeaderText="Updated By">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="UpdateDate" DataField="UpdatedBy.ActionDate"
                    HeaderText="Update Date" DataFormatString="{0:MM/dd/yyyy}">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="Status" DataField="eOrgWorkflowStatus" HeaderText="Status">
                </telerik:GridBoundColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
</div>
