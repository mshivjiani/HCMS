<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ctrlOrgChartPositions.ascx.cs" Inherits="HCMS.OrgChart.Controls.Positions.ctrlOrgChartPositions" %>
<%@ Register TagPrefix="custom" TagName="ReadOnlyLabel" Src="~/Controls/Common/readOnlyLabel.ascx" %>
<%@ Register TagPrefix="custom" TagName="OrgChartDetailInformation" Src="~/Controls/OrgChart/Common/orgChartDetailInformation.ascx" %>
<%@ Register TagPrefix="custom" TagName="ErrorMessage" Src="~/Controls/Common/errorMessage.ascx" %>

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
<custom:ReadOnlyLabel id="customReadOnlyLabel" runat="server" LabelText="In Process Chart -- Read-Only View" />
<custom:OrgChartDetailInformation id="customOrgChartDetails" runat="server" RedirectSuffix="pos" />

<br />
<div><hr class="separator" /></div><br /> 
<div class="highlight1">Associated Organization Chart Positions</div>
<br />

<div>* - Direct subordinate counts that are prefixed with a '*' and can be drilled down into by clicking on the number.  Please note 
that you will only be able to drill down into positions that have subordinates.</div><br />

<div class="highlight1">ToolTip Legend:</div><br />
<table>
    <tr>
        <td width="25"><custom:ToolTip ID="toolTipExclude" runat="server" ToolTipID="222" /></td>
        <td>Exclude Column</td>
        <td align="center" width="25">-</td>

        <td width="25"><custom:ToolTip ID="toolTipAssociateStaff" runat="server" ToolTipID="223" /></td>
        <td>Associate Staff Column</td>
        <td align="center" width="25">-</td>

        <td width="25"><custom:ToolTip ID="toolTipInHierarchy" runat="server" ToolTipID="224" /></td>
        <td>In Hierarchy</td>
        <td align="center" width="25">-</td>
       

        <td width="25"><custom:ToolTip ID="toolTipChildCount" runat="server" ToolTipID="226" /></td>
        <td>Subordinate Count</td>
        <td align="center" width="25">-</td>

        <td width="25"><custom:ToolTip ID="toolTipParentInHierarchy" runat="server" ToolTipID="225" /></td>
        <td>Parent In Hierarchy Column</td>
         <td align="center" width="25">-</td>

        
    </tr>
</table>
<br />

<asp:Panel ID="panelDrillUp" runat="server" Visible="false">
<div class="highlight1">Currently viewing subordinate positions directly reporting to: <span class="highlightText"><asp:Literal ID="literalDrillPositionDetails" runat="server" /></span></div><br />
<table class="blueTable" width="100%">
    <tr>
        <td width="25"><asp:HyperLink ID="linkDrillToTopArrow" runat="server" NavigateUrl="~/OrgChart/OrgChartPositions.aspx#positionlist"><asp:Image ID="imageDrillTop" runat="server" SkinID="upArrowIcon" /></asp:HyperLink></td>
        <td width="225"><span class="highlight1"><asp:HyperLink ID="linkDrillToTop" runat="server" Text="Return to the Top Level [All Positions]" NavigateUrl="~/OrgChart/OrgChartPositions.aspx#positionlist" /></span></td>
        <td id="tdDrillUpOneLevelArrow" runat="server" visible="false" width="25"><asp:HyperLink ID="linkDrillUpOneLevelArrow" runat="server"><asp:Image ID="imageDrillUpOne" runat="server" SkinID="leftArrowIcon" /></asp:HyperLink></td>        
        <td id="tdDrillUpOneLevel" runat="server" visible="false" width="160" class="highlight1"><span class="highlight1"><asp:HyperLink ID="linkDrillUpOneLevel" runat="server" Text="Drill Up One Level" /></span></td>
        <td id="tdDrillUpOneLevelArrowDisabled" runat="server" visible="false"><asp:Image id="imageDrillDownPositionNotInHierarchy" runat="server" skinID="alertIconYellow" alternatetext="Selected Position is NOT in Chart Hierarchy" title="Selected Position is NOT in Chart Hierarchy" /></td>
        <td id="tdDrillUpOneLevelDisabled" runat="server" visible="false">The ability to drill up one level has been disabled because the selected position is not in the current organization chart's hierarchy.</td>
        <td></td>
    </tr>
</table><br />
</asp:Panel>

<a name="positionlist"></a>
<custom:ErrorMessage id="customPositionsErrorMessage" runat="server" />
<telerik:RadGrid ID="gridPositions" runat="server" AutoGenerateColumns="False" AllowSorting="true" AllowPaging="true" 
        CellSpacing="0" GridLines="None" PagerStyle-Position="Bottom">
        <HeaderStyle HorizontalAlign="Center" />
        <MasterTableView DataKeyNames="WFPPositionID">            
            <NoRecordsTemplate>There are no positions currently associated with this organization chart.</NoRecordsTemplate>
            <Columns>
                <telerik:GridTemplateColumn UniqueName="ExcludeColumn" HeaderText="Exclude" ItemStyle-HorizontalAlign="Center" Headerstyle-Width="25px" Itemstyle-Width="25px">
                <ItemTemplate>
                    <asp:Literal id="literalNoExclude" runat="server" text="N/A" />
                    <asp:ImageButton ID="imageButtonExclude" runat="server" CommandName="Exclude" SkinID="minusIconButton" AlternateText="Exclude this Position from the Organization Chart" ToolTip="Exclude this Position from the Organization Chart" Visible="true" />
                </ItemTemplate>
                </telerik:GridTemplateColumn>
                
                <telerik:GridTemplateColumn UniqueName="IncludeColumn" HeaderText="Associate Staff" ItemStyle-HorizontalAlign="Center" Headerstyle-Width="35px" Itemstyle-Width="35px">
                <ItemTemplate>
                    <asp:HyperLink id="linkInclude" runat="server"><asp:Image id="imageInclude" runat="server" SkinID="greenCheckIcon" AlternateText="Associate Staff Positions under this Selected Position" ToolTip="Associate Staff Positions under this Selected Position" /></asp:HyperLink>
                </ItemTemplate>
                </telerik:GridTemplateColumn>
                
                <telerik:GridBoundColumn visible="false" headertext="ID" datafield="WFPPositionID" Headerstyle-Width="30px" Itemstyle-Width="30px" />
                <telerik:GridBoundColumn UniqueName="OrganizationChartID" DataField="OrganizationChartID" HeaderText="Org Chart ID" visible="false" />

                <telerik:GridTemplateColumn HeaderText="Employee Name (Last, First)" ItemStyle-HorizontalAlign="Left" Headerstyle-Width="220px" Itemstyle-Width="220px">
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

                <telerik:GridTemplateColumn HeaderText="Pay Plan/Grade" ItemStyle-HorizontalAlign="Center" Headerstyle-Width="50px" Itemstyle-Width="50px">
                <ItemTemplate>
                    <asp:Literal ID="literalPayPlanGrade" runat="server" />
                </ItemTemplate>
                </telerik:GridTemplateColumn>
                
                <telerik:GridTemplateColumn HeaderText="Series" ItemStyle-HorizontalAlign="Center" Headerstyle-Width="35px" Itemstyle-Width="35px">
                <ItemTemplate>
                    <asp:Literal id="literalSeriesNumber" runat="server" />
                </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn HeaderText="Subord. Count" ItemStyle-HorizontalAlign="Center" Headerstyle-Width="80px" Itemstyle-Width="80px">
                <ItemTemplate>
                    <span class="highlight1">
                    <asp:Literal ID="literalStarForChildCount" runat="server" Text="*" Visible="false" />
                    <asp:HyperLink ID="linkChildCount" runat="server" visible="false" />
                    <asp:Literal ID="literalChildCount" runat="server" text="0" />
                    </span>
                </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn HeaderText="In Hierarchy" ItemStyle-HorizontalAlign="Center" Headerstyle-Width="50px" Itemstyle-Width="50px">
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
        <asp:Button ID="buttonAddNewWFP" runat="server" Text="Add New WFP Position" CssClass="button" CausesValidation="false" Width="175px" />
    </div>
</asp:Panel><br /><br />