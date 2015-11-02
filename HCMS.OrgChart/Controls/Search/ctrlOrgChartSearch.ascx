<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlOrgChartSearch.ascx.cs"
    Inherits="HCMS.OrgChart.Controls.Search.ctrlOrgChartSearch" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="tooltip" %>

<telerik:RadCodeBlock ID="rcbCodeBlock" runat="server">
    <script type="text/javascript">
        var currentLoadingPanel = null;
        var currentUpdatedControl = null;

        function RequestStart(sender, args) {
            currentLoadingPanel = $find("<%= ajaxLoadingPanelSave.ClientID %>");
            currentUpdatedControl = "<%= accSearch.ClientID %>";
            currentLoadingPanel.show(currentUpdatedControl);
        }
        function ResponseEnd() {
            if (currentLoadingPanel != null)
                currentLoadingPanel.hide(currentUpdatedControl);

            currentUpdatedControl = null;
            currentLoadingPanel = null;

        }


        function OnPopupWindowClose(oWnd, eventArgs) {
            var oWindow = GetRadWindow();
            if (oWindow != null)
                oWindow.close();
        }

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.radWindow;
            return oWindow;
        }

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
     
    </script>
</telerik:RadCodeBlock>
<telerik:RadAjaxLoadingPanel ID="ajaxLoadingPanelSave" runat="server" SkinID="radAJAXLoadingPanel" >
<%--<asp:Image ID="imgloading" runat ="server" ImageUrl ="~/App_Themes/OrgChart_Default/Images/Icons/loading.gif" />
--%></telerik:RadAjaxLoadingPanel>
<telerik:RadAjaxManagerProxy ID="radAjaxmgrReports" runat="server" >
    <AjaxSettings>

        <telerik:AjaxSetting AjaxControlID="btnSearchByID">
            <UpdatedControls>
               
             <telerik:AjaxUpdatedControl ControlID="pnlAdvSearch"  />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnSearch2">
            <UpdatedControls>
            <telerik:AjaxUpdatedControl ControlID="pnlAdvSearch"  />       
                
            </UpdatedControls>
        </telerik:AjaxSetting>
       
    

        <telerik:AjaxSetting AjaxControlID="rdOrgCode">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rcbOrganizationCode" />
            </UpdatedControls>
        </telerik:AjaxSetting>

        <telerik:AjaxSetting AjaxControlID ="rcbChartStatus">
        <UpdatedControls>
        <telerik:AjaxUpdatedControl ControlID ="trPublishedYear" />
        <telerik:AjaxUpdatedControl ControlID ="trApprover" />
        </UpdatedControls>
            
        </telerik:AjaxSetting>
    </AjaxSettings>
    <%--<ClientEvents OnRequestStart="RequestStart" OnResponseEnd="ResponseEnd" />--%>
</telerik:RadAjaxManagerProxy>

<div>
    <cc1:Accordion ID="accSearch" runat="server" AutoSize="None" RequireOpenedPane="true"
        SelectedIndex="0" HeaderCssClass="blueAccordionHeader" HeaderSelectedCssClass="blueAccordionHeaderSelected">
        <Panes>
            <cc1:AccordionPane ID="accPanelSearchByID" runat="server">
                <Header>
                    Search By Chart ID</Header>
                <Content>
                <asp:Panel ID="pnlSearchByID" runat ="server" DefaultButton ="btnSearchByID">
                    <table class="blueTable" width="100%" border="0">
                        <tr>
                            <td align="right" width="25%">
                                <asp:Label ID="lblSearchByID" runat="server" Text="Enter Organization Chart ID:"></asp:Label><span
                                    class="required">*</span>
                            </td>
                            <td align="left" colspan="2">
                                <asp:TextBox ID="txtOrganizationChartID" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="requireOrgChartID" runat="server" ControlToValidate="txtOrganizationChartID"
                                    ValidationGroup="SearchByID" InitialValue="" ErrorMessage="Organization Chart ID is required."
                                    Display="None">
                                </asp:RequiredFieldValidator>
                                 <asp:RegularExpressionValidator ID="txtSearchNumberRegExpVal" runat="server" ValidationGroup="SearchByID"
                                        ControlToValidate="txtOrganizationChartID" ValidationExpression="\d*" ErrorMessage="Organization Chart ID should be numeric"
                                        Display="None"  />
                            </td>
                            <td align="right" colspan="3">
                                <asp:Button ID="btnSearchByID" runat="server" Text="Search" CssClass="formBtn" OnClick="btnSearchByID_Click"
                                    ValidationGroup="SearchByID" OnClientClick="SetValidationGroup('SearchByID');" />
                            </td>
                        </tr>
                    </table>
                    </asp:Panel>
                </Content>
            </cc1:AccordionPane>
            <cc1:AccordionPane ID="accPanelAdvancedSearch" runat="server">
                <Header>
                    Advanced Search</Header>
                <Content>
                    <asp:Panel ID="pnlSearch2" runat="server" DefaultButton="btnSearch2">
                        <table class="blueTable" width="100%" border="0">
                            <tr>
                                <td align="right" width="25%">
                                    <asp:Label ID="lblRegion" runat="server" AssociatedControlID="rcbRegion" Text="Region:"
                                        ToolTip="Region:" />
                                    
                                </td>
                                <td align="left" colspan="2">
                                    <telerik:RadComboBox ID="rcbRegion" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcbRegion_SelectedIndexChanged"
                                        DropDownWidth="400px" Height="160px" MarkFirstMatch="true" Width="400px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:RadioButtonList ID="rdOrgCode" runat="server" RepeatDirection="Horizontal" AutoPostBack="true"
                                        OnSelectedIndexChanged="rdOrgCode_Changed">
                                        <asp:ListItem Text="Old Org Code" Value="Old" Selected="True" />
                                        <asp:ListItem Text="New Org Code" Value="New" />
                                    </asp:RadioButtonList>
                                   
                                    <td>
                                        <telerik:RadComboBox ID="rcbOrganizationCode" runat="server" AutoPostBack="false"
                                            DropDownWidth="400px" Height="160px" MarkFirstMatch="true" Width="400px" />
                                    </td>
                                    <td>
                                    </td>
                            </tr>
                            <tr>
                                <td align="right" width="25%">
                                    <asp:Label ID="Label2" runat="server" Text="Organization Chart Type:"></asp:Label>
                                   
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcbOrgChartType" runat="server" AutoPostBack="false" DataTextField="OrgChartTypeDesc"
                                        Width="400px" DataValueField="OrgChartTypeID" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblChartStatus" runat="server" Text="Chart Status:" /><tooltip:ToolTip
                                       
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcbChartStatus" runat="server" AutoPostBack="true" DataTextField="WorkflowStatus" OnSelectedIndexChanged ="rcbChartStatus_OnSelectedIndexChange"
                                        Width="400px" DataValueField="WorkflowStatusID" />
                                </td>
                            </tr>
                           
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblChartSeries" runat="server" Text="Series:" />
                                   
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcbJobSeries" runat="server" AutoPostBack="false" MarkFirstMatch="true"
                                        Width="400px" DropDownWidth="450px" Height="160px" DataTextField="SeriesName"
                                        DataValueField="SeriesID" />
                                </td>
                            </tr>

                             <tr id="trPublishedYear" runat="server" visible ="false" >
                                <td align="right">
                                    <asp:Label ID="lblYear" runat="server" Text="Published Year:" />
                                    
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcbPublishedYear" runat="server" AutoPostBack="false" MarkFirstMatch="true"
                                        Width="400px" Height="160px" />
                                </td>
                            </tr>
                             <tr id="trApprover" runat="server" visible="false" >
                                <td align="right">
                                    <asp:Label ID="lblChartApprover" runat="server" Text="Approver:
                                    (Last, First)" />
                                   
                                </td>
                                <td>
                                    <asp:TextBox ID="txtChartApprover" runat="server" Width="200px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblChartCreator" runat="server" Text="Author:
                                    (Last, First)" />
                                   
                                </td>
                                <td>
                                    <asp:TextBox ID="txtChartCreator" runat="server" Width="200px" />
                                </td>
                            </tr>
                           
                            <tr>
                                <td align="right">
                                    <asp:Label ID="lblEmployeeName" runat="server" Text="Employee Name:
                                    (Last, First)" />
                                   
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEmployeeName" runat="server" Width="200px" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="right">
                                    <asp:Button ID="btnSearch2" runat="server" CssClass="formBtn" Text="Search" ToolTip="Search"
                                        ValidationGroup="Search2" OnClick="btnSearch2_Click" OnClientClick="SetValidationGroup('Search2');" />
                                    <asp:Button ID="btnReset" runat="server" Text="Reset" ToolTip="Reset" CausesValidation="false"
                                        OnClick="btnReset_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </Content>
            </cc1:AccordionPane>
        </Panes>
    </cc1:Accordion>
    <asp:Panel ID="pnlAdvSearch" runat ="server">
    <br /><br />
    &nbsp;<div id="divOrgCodemsg" runat="server" visible="false" class="requiredField">
        <h2 id="h2Caption" runat="server">
            &nbsp;Search Results</h2>
    </div>
    <telerik:RadGrid ID="rgSearchResults" runat="server" Visible="false" Width="100%"
        OnNeedDataSource="rgSearchResults_NeedDataSource" AutoGenerateColumns="false"
        AllowPaging="true" PageSize="5" PagerStyle-AlwaysVisible="false" PagerStyle-Position="Bottom"
        OnItemDataBound="rgSearchResults_ItemDataBound" AllowSorting="true" OnSortCommand="rgSearchResults_SortCommand">
        <MasterTableView GridLines="Both" ItemStyle-VerticalAlign="Top" AlternatingItemStyle-VerticalAlign="Top" 
            ShowFooter="false" Width="100%" TableLayout="Auto" ItemStyle-Wrap="true" AllowNaturalSort ="false" 
            AllowCustomSorting="true">
            <Columns>
                <telerik:GridTemplateColumn UniqueName="ActionColumn" HeaderText="Action" HeaderStyle-Width="55px"
                    ItemStyle-Width="55px">
                    <ItemTemplate>
                        <telerik:RadMenu ID="rmOrgChartMenuAction" runat="server" OnItemClick="rgSearchResults_ItemClick"
                            OnClientItemClicking="OnOrgChartActionMenuClick" EnableImageSprites="true">
                            <Items>
                                <telerik:RadMenuItem CssClass="ddicon" Width="30px" Height="24px">
                                    <Items>
                                        <telerik:RadMenuItem Text="View" Value="View" />
                                        <telerik:RadMenuItem Text="View" Value ="ViewPublished" />
                                        <telerik:RadMenuItem Text="Edit" Value="Edit" />
                                        <telerik:RadMenuItem Text="Continue Edit" Value="ContinueEdit" />
                                        <telerik:RadMenuItem Text="Finish Edit" Value="FinishEdit" />
                                        <telerik:RadMenuItem Text="Delete" Value="Delete" Visible="false" />
                                    </Items>
                                </telerik:RadMenuItem>
                            </Items>
                        </telerik:RadMenu>
                        <asp:Image ID="imgOrgChartCheckedOutStatus" CssClass="checked" Visible="false" runat="server" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Chart ID" SortExpression="OrganizationChartID"
                    ShowSortIcon="true">
                    <ItemTemplate>
                        <%# (Container.DataItem as HCMS.Business.OrganizationChart.OrgChartSearchResult).ChartEntity.OrganizationChartID%>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Region" SortExpression="Region">
                    <ItemTemplate>
                        <%# (Container.DataItem as HCMS.Business.OrganizationChart.OrgChartSearchResult).ChartEntity.OrgCode.Region%>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Org Code New(Old)" SortExpression="OrganizationCode">
                    <ItemTemplate>
                        <%# (Container.DataItem as HCMS.Business.OrganizationChart.OrgChartSearchResult).ChartEntity.OrgCode.OrganizationCodeLegacy%>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText ="Chart Type" SortExpression="ChartType">
                <ItemTemplate>
                <%#(Container.DataItem as HCMS.Business.OrganizationChart.OrgChartSearchResult).ChartEntity.OrganizationChartTypeName  %>
                </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Created By" SortExpression="CreatedByFNR">
                    <ItemTemplate>
                        <%# (Container.DataItem as HCMS.Business.OrganizationChart.OrgChartSearchResult).ChartEntity.CreatedBy.FullNameReverse%>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Create Date" SortExpression="CreateDate">
                    <ItemTemplate>
                        <%# string.Format ("{0:MM/dd/yyyy}",(Container.DataItem as HCMS.Business.OrganizationChart.OrgChartSearchResult).ChartEntity.CreatedBy.ActionDate) %>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Updated By" SortExpression="UpdatedByFNR">
                    <ItemTemplate>
                        <%# (Container.DataItem as HCMS.Business.OrganizationChart.OrgChartSearchResult).ChartEntity.UpdatedBy.FullNameReverse%>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Update Date" SortExpression="UpdateDate">
                    <ItemTemplate>
                        <%# string.Format ("{0:MM/dd/yyyy}",(Container.DataItem as HCMS.Business.OrganizationChart.OrgChartSearchResult).ChartEntity.UpdatedBy.ActionDate) %>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Status" SortExpression="StatusID" ShowSortIcon="true" UniqueName ="StatusID">
                    <ItemTemplate>

                        <%# (Container.DataItem as HCMS.Business.OrganizationChart.OrgChartSearchResult).ChartEntity.OrgWorkflowStatusName%>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Document" UniqueName="Document">
                    <ItemTemplate>
                        <telerik:RadMenu ID="rmDocument" runat="server" OnItemClick="rmDocument_ItemClick"
                            EnableImageSprites="true">
                            <Items>
                                <telerik:RadMenuItem CssClass="ddicon" ToolTip="Select Document" Width="30px" Height="24px">
                                    <Items>
                                        <telerik:RadMenuItem Text="Print PDF" Value="1" />
                                        <telerik:RadMenuItem Text="Print PDF" Value="2" />
                                        <telerik:RadMenuItem Text ="Export To Excel" Value ="3" />
                                    </Items>
                                </telerik:RadMenuItem>
                            </Items>
                        </telerik:RadMenu>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
        <ClientSettings>
            <Selecting AllowRowSelect="false" />
        </ClientSettings>
    </telerik:RadGrid>
</div>
</asp:Panel>