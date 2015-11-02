<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlJNPTracker.ascx.cs" Inherits="HCMS.JNP.Controls.Package.ctrlJNPTracker" %>
<!-- this css is to hide expand/collapse column that appears because of the nestedview-->
 <style type="text/css"> 
        .rgExpandCol 
        { 
            display:none !important; 
        } 
 </style> 
<div style="border: 1px solid black;">
<telerik:RadGrid ID="jnpTrackerGrid" runat="server"  SkinID="SearchRADGridView"
                 AutoGenerateColumns="False" 
                 AllowSorting="true"
                 AllowPaging= "true" 
                 CellSpacing="0" 
                 GridLines="None"
                 PagerStyle-Position="TopAndBottom"
                 onneeddatasource="jnpTrackerGrid_NeedDataSource"
                 onprerender="jnpTrackerGrid_PreRender" 
                 onitemcreated="jnpTrackerGrid_ItemCreated" 
                 onitemdatabound="jnpTrackerGrid_ItemDataBound"  >
    <MasterTableView DataKeyNames="JNPID" AllowNaturalSort="false" >
        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
        <NoRecordsTemplate><div>There are no Job Announcement Packages to track.</div></NoRecordsTemplate>
        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
            <HeaderStyle Width="20px"></HeaderStyle>
        </RowIndicatorColumn>

        <Columns>
            <telerik:GridTemplateColumn UniqueName="ActionColumn" 
                                        HeaderText="Action"
                                        FilterControlAltText="Filter Action column"
                                        HeaderStyle-Width="55px"
                                        ItemStyle-Width="55px">
                <ItemTemplate>
                    <telerik:RadMenu ID="jnpTrackerMenu" runat="server" OnItemClick="jnpTrackerMenu_ItemClick" EnableImageSprites="true">
                        <Items>
                            <telerik:RadMenuItem CssClass ="ddicon" Width="30px" Height="24px">
                                <Items>
                                    <telerik:RadMenuItem Text="View" Value="View" />
                                    <telerik:RadMenuItem Text="Edit" Value="Edit" />
                                    <telerik:RadMenuItem Text="Continue Edit" Value="ContinueEdit" />
                                    <telerik:RadMenuItem Text="Finish Edit" Value="FinishEdit" />
                                </Items>
                            </telerik:RadMenuItem>
                        </Items>
                    </telerik:RadMenu>
                    &nbsp;
                    <asp:Image ID="imgJNPCheckedOutStatus" CssClass="checked" Visible="false" runat="server" />
                </ItemTemplate>
            </telerik:GridTemplateColumn>

            <telerik:GridBoundColumn UniqueName="JNPID"
                                     DataField="JNPID"
                                     HeaderText="JAX ID"
                                     FilterControlAltText="Filter JAX ID column">
                                     <HeaderStyle Width="34" />
            </telerik:GridBoundColumn>

            <telerik:GridBoundColumn UniqueName="Grade" 
                                     DataField="Grade"
                                     HeaderText="Grade"  AllowSorting="false" 
                                     FilterControlAltText="Filter Grade column">
            </telerik:GridBoundColumn>
            
            <telerik:GridBoundColumn UniqueName="JNPTitle"
                                     DataField="JNPTitleCombined"
                                     HeaderText="Title"
                                     AllowSorting="true"
                                     ShowSortIcon="true"
                                     FilterControlAltText="Filter JAX Title column">
            </telerik:GridBoundColumn>
            
            <telerik:GridBoundColumn HeaderText="Org Code New (Old)" DataField="OrganizationCodeLegacy" UniqueName="OrganizationCodeLegacy"
                                     AllowSorting="true" 
                                     ShowSortIcon="true"       >
            </telerik:GridBoundColumn>

            <telerik:GridBoundColumn UniqueName="CreateDateShort"
                                     DataField="CreateDateShort"
                                     HeaderText="Created"
                                     AllowSorting="true" 
                                     ShowSortIcon="true"
                                     sortexpression="CreateDateShort"
                                     DataType="System.DateTime" DataFormatString="{0:MM/dd/yyyy}"
                                     FilterControlAltText="Filter Created column">
            </telerik:GridBoundColumn>
            
            <telerik:GridBoundColumn UniqueName="CreatedBy"
                                     DataField="CreatedBy"
                                     HeaderText="Created By"
                                     AllowSorting="true" 
                                     ShowSortIcon="true"
                                     FilterControlAltText="Filter Created By column">
            </telerik:GridBoundColumn>

            <telerik:GridBoundColumn UniqueName="UpdateDateShort"
                                     DataField="UpdateDateShort"
                                     HeaderText="Updated"
                                     AllowSorting="true" 
                                     ShowSortIcon="true" sortexpression="UpdateDateShort"
                                     DataType="System.DateTime" DataFormatString="{0:MM/dd/yyyy}" 
                                     FilterControlAltText="Filter Updated column">
            </telerik:GridBoundColumn>
            
            <telerik:GridBoundColumn UniqueName="UpdatedBy"
                                     DataField="UpdatedBy"
                                     HeaderText="Updated By"
                                     AllowSorting="true" 
                                     ShowSortIcon="true"
                                     FilterControlAltText="Filter Updated By column">
            </telerik:GridBoundColumn>

            <telerik:GridBoundColumn UniqueName="Status"
                                     DataField="JNPWorkflowStatus"
                                     HeaderText="Workflow Status"
                                     AllowSorting="true" 
                                     ShowSortIcon="true"
                                     FilterControlAltText="Filter Status column">
            </telerik:GridBoundColumn>
            <telerik:GridTemplateColumn HeaderText="Schedule Status" UniqueName="ScheduleStatus"
            SortExpression="JNPScheduleStatus" ItemStyle-Width="100px">
              <ItemStyle Wrap="false" />
            <ItemTemplate>
              <div>
                    <asp:Image ID="imgScheduleStatus" runat="server" Style="vertical-align: middle;" />
                    &nbsp;
                    <asp:Label ID="lblScheduleStatus" runat="server" Style="vertical-align: middle;" />
             </div>
            </ItemTemplate>
            </telerik:GridTemplateColumn>
           
        </Columns>

        <EditFormSettings>
            <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
        </EditFormSettings>

       <%-- <NestedViewTemplate>
        
            <asp:Panel ID="NestedViewPanel" runat="server">
                <div ID="divStatus" runat="server" style="border: 0px solid black; padding-bottom: 25px;">
                </div>
            </asp:Panel>
        </NestedViewTemplate>--%>

    </MasterTableView>

    <FilterMenu EnableImageSprites="False"></FilterMenu>
</telerik:RadGrid>
</div>

