<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ctrlNewFPPSPositions.ascx.cs" Inherits="HCMS.OrgChart.Controls.Positions.ctrlNewFPPSPositions" %>
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
<custom:OrgChartDetailInformation id="customOrgChartDetails" runat="server" RedirectSuffix="newfpps" ShowNewFPPSPositionsLink="false" />

<br />
<div><hr class="separator" /></div><br /> 
<div class="highlight1">New FPPS Positions for Organization Chart</div>
<br />

<div>* - The following lists all of the newly encumbered FPPS Positions for this organization chart's primary organization.  Please note that you 
will only be able to exclude positions that have no subordinates.</div><br />

<div class="highlight1">ToolTip Legend:</div><br />
<table>
    <tr>
        <td width="25"><custom:ToolTip ID="toolTipExclude" runat="server" ToolTipID="222" /></td>
        <td>Exclude Column</td>
        <td align="center" width="25">-</td>

        <td width="25"><custom:ToolTip ID="toolTipInclude" runat="server" ToolTipID="228" /></td>
        <td>Include Column</td>
    </tr>

</table>
<br />

<a name="positionlist"></a>
<custom:ErrorMessage id="customPositionsErrorMessage" runat="server" />
<telerik:RadGrid ID="gridPositions" runat="server" AutoGenerateColumns="False" AllowSorting="true" AllowPaging="true" 
        CellSpacing="0" GridLines="None" PagerStyle-Position="Bottom">
        <HeaderStyle HorizontalAlign="Center" />
        <MasterTableView DataKeyNames="WFPPositionID">            
            <NoRecordsTemplate>There are no new FPPS positions currently associated with this organization chart.</NoRecordsTemplate>
            <Columns>
                <telerik:GridTemplateColumn UniqueName="ExcludeColumn" HeaderText="Exclude" ItemStyle-HorizontalAlign="Center" Headerstyle-Width="25px" Itemstyle-Width="25px">
                <ItemTemplate>
                    <asp:Literal id="literalNoExclude" runat="server" text="N/A" />
                    <asp:ImageButton ID="imageButtonExclude" runat="server" CommandName="Exclude" SkinID="minusIconButton" AlternateText="Exclude this Position from the Organization Chart" ToolTip="Exclude this Position from the Organization Chart" />
                </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn UniqueName="IncludeColumn" HeaderText="Include" ItemStyle-HorizontalAlign="Center" Headerstyle-Width="25px" Itemstyle-Width="25px">
                <ItemTemplate>
                    <asp:HyperLink id="linkInclude" runat="server"><asp:Image id="imageInclude" runat="server" SkinID="greenCheckIcon" AlternateText="Include Positions under this Selected Position" ToolTip="Include Positions under this Selected Position" /></asp:HyperLink>
                </ItemTemplate>
                </telerik:GridTemplateColumn>
                
                <telerik:GridBoundColumn visible="false" headertext="ID" datafield="WFPPositionID" Headerstyle-Width="30px" Itemstyle-Width="30px" />

                <telerik:GridTemplateColumn HeaderText="Employee Name (Last, First)" ItemStyle-HorizontalAlign="Left" Headerstyle-Width="220px" Itemstyle-Width="220px">
                <ItemTemplate>
                    <div class="highlight1"><asp:Literal ID="literalEmployeeName" runat="server" /></div>                    
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
                
                <telerik:GridTemplateColumn HeaderText="Series" ItemStyle-HorizontalAlign="Center" Headerstyle-Width="85px" Itemstyle-Width="85px">
                <ItemTemplate>
                    <asp:Literal id="literalSeriesNumber" runat="server" />
                </ItemTemplate>
                </telerik:GridTemplateColumn>

                <telerik:GridTemplateColumn HeaderText="Subord. Count" ItemStyle-HorizontalAlign="Center" Headerstyle-Width="85px" Itemstyle-Width="85px">
                <ItemTemplate>
                    <div class="highlight3"><asp:Literal id="literalDirectChildCount" runat="server" /></div>
                </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>

    <br />
    <div>
        <asp:Button ID="buttonChartPositions" runat="server" Text="Chart Positions" CssClass="button" CausesValidation="false" Width="175px" />
        <asp:Button ID="buttonOrganizationChartDetails" runat="server" Text="Organization Chart Manager" CssClass="button" CausesValidation="false" Width="225px" />
    </div>
</asp:Panel><br /><br />