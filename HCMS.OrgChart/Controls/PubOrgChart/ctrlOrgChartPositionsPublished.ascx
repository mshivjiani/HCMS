<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ctrlOrgChartPositionsPublished.ascx.cs" Inherits="HCMS.OrgChart.Controls.PubOrgChart.ctrlOrgChartPositionsPublished" %>
<%@ Register TagPrefix="custom" TagName="ReadOnlyLabel" Src="~/Controls/Common/readOnlyLabel.ascx" %>
<%@ Register TagPrefix="custom" TagName="PubOrgChartDetails" Src="~/Controls/PubOrgChart/Common/pubOrgChartDetailInformation.ascx" %>

<telerik:RadAjaxManagerProxy id="radAjaxManagerProxyMain" runat="server">
    <ajaxsettings>
        <telerik:AjaxSetting AjaxControlID="gridPositions">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="panelMain" />
            </UpdatedControls>
        </telerik:AjaxSetting>   
    </ajaxsettings>
</telerik:RadAjaxManagerProxy>

<asp:Panel ID="panelMain" runat="server">
<custom:ReadOnlyLabel id="customReadOnlyLabel" runat="server" LabelText="Published Chart -- Read-Only View" />

<div class="highlight1">Published Organization Chart Details</div><br />
<custom:PubOrgChartDetails id="customPubOrgChartDetails" runat="server" /><br />

<br />
<div><hr class="separator" /></div><br /> 
<div class="highlight1">Associated Published Organization Chart Positions</div>
<br />

<div>* - Direct subordinate counts that are prefixed with a '*' and can be drilled down into by clicking on the number.  Please note 
that you will only be able to drill down into positions that have subordinates.</div><br />

<div class="highlight1">ToolTip Legend:</div><br />
<table>
    <tr>
        <td width="25"><custom:ToolTip ID="toolTipInHierarchy" runat="server" ToolTipID="224" /></td>
        <td>In Hierarchy</td>
        <td align="center" width="25">-</td>

        <td width="25"><custom:ToolTip ID="toolTipParentInHierarchy" runat="server" ToolTipID="225" /></td>
        <td>Parent In Hierarchy Column</td>
    </tr>
</table>
<br />

<asp:Panel ID="panelDrillUp" runat="server" Visible="false">
<div class="highlight1">Currently viewing subordinate positions directly reporting to: <span class="highlightText"><asp:Literal ID="literalDrillPositionDetails" runat="server" /></span></div><br />
<table class="blueTable" width="100%">
    <tr>
        <td width="25"><asp:HyperLink ID="linkDrillToTopArrow" runat="server" NavigateUrl="~/PubOrgChart/OrgChartPositions.aspx#positionlist"><asp:Image ID="imageDrillTop" runat="server" SkinID="upArrowIcon" /></asp:HyperLink></td>
        <td width="225"><span class="highlight1"><asp:HyperLink ID="linkDrillToTop" runat="server" Text="Return to the Top Level [All Positions]" NavigateUrl="~/PubOrgChart/OrgChartPositions.aspx#positionlist" /></span></td>
        <td id="tdDrillUpOneLevelArrow" runat="server" visible="false" width="25"><asp:HyperLink ID="linkDrillUpOneLevelArrow" runat="server"><asp:Image ID="imageDrillUpOne" runat="server" SkinID="leftArrowIcon" /></asp:HyperLink></td>        
        <td id="tdDrillUpOneLevel" runat="server" visible="false" width="160" class="highlight1"><span class="highlight1"><asp:HyperLink ID="linkDrillUpOneLevel" runat="server" Text="Drill Up One Level" /></span></td>
        <td id="tdDrillUpOneLevelArrowDisabled" runat="server" visible="false"><asp:Image id="imageDrillDownPositionNotInHierarchy" runat="server" skinID="alertIconYellow" alternatetext="Selected Position is NOT in Chart Hierarchy" title="Selected Position is NOT in Chart Hierarchy" /></td>
        <td id="tdDrillUpOneLevelDisabled" runat="server" visible="false">The ability to drill up one level has been disabled because the selected position is not in the current organization chart's hierarchy.</td>
        <td></td>
    </tr>
</table><br />
</asp:Panel>

<a name="positionlist"></a>
<telerik:RadGrid ID="gridPositions" runat="server" AutoGenerateColumns="False" AllowSorting="true" AllowPaging="true" 
        CellSpacing="0" GridLines="None" PagerStyle-Position="Bottom">
        <HeaderStyle HorizontalAlign="Center" />
        <MasterTableView DataKeyNames="WFPPositionID">            
            <NoRecordsTemplate>There are no positions currently associated with this published organization chart.</NoRecordsTemplate>
            <Columns>
                <telerik:GridTemplateColumn HeaderText="Employee Name (Last, First)" ItemStyle-HorizontalAlign="Left" Headerstyle-Width="240px" Itemstyle-Width="240px">
                <ItemTemplate>
                    <div class="highlight1"><asp:Literal ID="literalEmployeeName" runat="server" /></div>
                    <div id="divTopLevelPosition" runat="server" visible="false" class="highlightText">* Top Level Position for this Chart *</div>
                </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn HeaderText="OPM Position Title" ItemStyle-HorizontalAlign="Left">
                <ItemTemplate>
                        <asp:HyperLink ID="linkPositionTitle" runat="server" />
                        <div><asp:Literal ID="literalPositionNumberBaseSuffix" runat="server" /></div>
                </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn HeaderText="Pay Plan/Grade" ItemStyle-HorizontalAlign="Center" Headerstyle-Width="100px" Itemstyle-Width="100px">
                <ItemTemplate>
                    <asp:Literal ID="literalPayPlanGrade" runat="server" />
                </ItemTemplate>
                </telerik:GridTemplateColumn>
                
                <telerik:GridTemplateColumn HeaderText="Series" ItemStyle-HorizontalAlign="Center" Headerstyle-Width="35px" Itemstyle-Width="35px">
                <ItemTemplate>
                    <asp:Literal id="literalSeriesNumber" runat="server" />
                </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn HeaderText="Subord. Count" ItemStyle-HorizontalAlign="Center" Headerstyle-Width="85px" Itemstyle-Width="85px">
                <ItemTemplate>
                    <span class="highlight1">
                    <asp:Literal ID="literalStarForChildCount" runat="server" Text="*" Visible="false" />
                    <asp:HyperLink ID="linkChildCount" runat="server" visible="false" />
                    <asp:Literal ID="literalChildCount" runat="server" text="0" />
                    </span>
                </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn HeaderText="In Hierarchy" ItemStyle-HorizontalAlign="Center" Headerstyle-Width="70px" Itemstyle-Width="70px">
                <ItemTemplate>
                   <asp:Image id="imageInHierarchy" runat="server" skinID="checkMarkIconBlack" alternatetext="Position is in Chart Hierarchy" title="Position is in Chart Hierarchy" />
                   <asp:Image id="imageNotInHierarchy" runat="server" skinID="alertIconYellow" alternatetext="Position is NOT in Chart Hierarchy" title="Position is NOT in Chart Hierarchy" />
                </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn HeaderText="Parent In Hierarchy" ItemStyle-HorizontalAlign="Center" Headerstyle-Width="50px" Itemstyle-Width="50px">
                <ItemTemplate>
                   <asp:Literal id="literalRootParentInHierarchy" runat="server" text="N/A" visible="false" />
                   <asp:Image id="imageParentInHierarchy" runat="server" skinID="checkMarkIconBlack" alternatetext="Position Parent is in Chart Hierarchy" title="Position Parent is in Chart Hierarchy" />
                   <asp:Image id="imageParentNotInHierarchy" runat="server" skinID="alertIconYellow" alternatetext="Position Parent is NOT in Chart Hierarchy" title="Position Parent is NOT in Chart Hierarchy" />
                </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>

    <br />
    <div>        
        <asp:Button ID="buttonOrganizationChartDetails" runat="server" Text="Organization Chart Manager" CssClass="button" CausesValidation="false" Width="225px" />
    </div>
</asp:Panel><br /><br />