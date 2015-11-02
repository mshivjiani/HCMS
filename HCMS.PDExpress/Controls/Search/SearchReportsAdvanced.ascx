<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchReportsAdvanced.ascx.cs"
    Inherits="HCMS.PDExpress.Controls.Search.SearchReportsAdvanced" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<telerik:RadCodeBlock ID="rcbCodeBlock" runat="server">
    <script type="text/javascript">
        var currentLoadingPanel = null;
        var currentUpdatedControl = null;

        function RequestStart(sender, args) {
            currentLoadingPanel = $find("<%= rlpDefault.ClientID %>");
            currentUpdatedControl = "<%= tblAdvancedSearch.ClientID %>";

            currentLoadingPanel.show(currentUpdatedControl);
        }
        function ResponseEnd() {
            if (currentLoadingPanel != null)
                currentLoadingPanel.hide(currentUpdatedControl);
            currentUpdatedControl = null;
            currentLoadingPanel = null;

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
    </script>
    <telerik:RadWindowManager ID="DefaultRadWindowManager" runat="server" ReloadOnShow="true"
        Skin="WebBlue">
    </telerik:RadWindowManager>
</telerik:RadCodeBlock>
<telerik:RadAjaxManager ID="radAjaxmgrReports" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rgPositionDescription">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgPositionDescription" />
                <telerik:AjaxUpdatedControl ControlID="hfSearchType" />
                <telerik:AjaxUpdatedControl ControlID="divOrgCodemsg" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btnSearch3">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgPositionDescription" />
                <telerik:AjaxUpdatedControl ControlID="hfSearchType" />
                <telerik:AjaxUpdatedControl ControlID="divOrgCodemsg" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
    <%-- <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rdOrgCode">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rcbOrganizationCode" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>--%>
    <ClientEvents OnRequestStart="RequestStart" OnResponseEnd="ResponseEnd" />
</telerik:RadAjaxManager>
<telerik:RadAjaxLoadingPanel ID="rlpDefault" runat="server" Skin="Web20" />
<div>
    <asp:ValidationSummary ID="Search3ValSumm" runat="server" ValidationGroup="Search3"
        CssClass="validationMessageBox" ShowSummary="true" HeaderText="<span class='systemMessage'>Validation Message</span><br>"
        DisplayMode="list" />
    <asp:ValidationSummary ID="Search5ValSumm" runat="server" ValidationGroup="Search5"
        CssClass="validationMessageBox" ShowSummary="true" HeaderText="<span class='systemMessage'>Validation Message</span><br>"
        DisplayMode="list" />
    <table class="blueTable" width="100%">
        <tr>
            <td align="right">
                <asp:Button ID="btnCancelAdvancedSearch" runat="server" CssClass="formBtn" Text="Cancel Advanced Search"
                    ToolTip="Cancel Advanced Search" OnClick="btnCancelAdvancedSearch_Click" />
            </td>
        </tr>
    </table>
    <br />
    <asp:UpdatePanel ID="updtPanelSearch" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSearch3" />
        </Triggers>
        <ContentTemplate>
            <table class="blueTable" width="100%">
                <colgroup>
                    <col width="20%" />
                    <col width="38%" />
                    <col align="right" width="42%" />
                    <tr>
                        <td>
                            <asp:CheckBox ID="chkKeyWord" runat="server" Text="Keyword Search" AutoPostBack="true" />
                        </td>
                        <td>
                            <div id="divKeyword" runat="server" visible="false">
                                <asp:TextBox ID="txtKeyWord" runat="server" MaxLength="255" Width="250px" Enabled="false"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="txtKeyWordReqVal" runat="server" ControlToValidate="txtKeyWord"
                                    InitialValue="" ErrorMessage="Please enter the key word." Display="None" Enabled="false"
                                    ValidationGroup="Search3"></asp:RequiredFieldValidator></div>
                        </td>
                    </tr>
                </colgroup>
            </table>
            <br />
            <table class="blueTable" width="100%" runat="server" id="tblAdvancedSearch">
                <tr>
                    <td class="noBorder">
                        <asp:RequiredFieldValidator ID="rblTypeReqVal" runat="server" ControlToValidate="rblType"
                            ValidationGroup="Search3" InitialValue="" ErrorMessage="Type is required" Display="None" />
                        <asp:RadioButtonList ID="rblType" runat="server" ValidationGroup="Search2" Width="86">
                            <asp:ListItem Text="Standard<span class=required>*</span>" Value="y" />
                            <asp:ListItem Text="Other<span class=required>*</span>" Value="n" />
                            <asp:ListItem Text="All<span class=required>*</span>" Value="a" Selected="True" />
                        </asp:RadioButtonList>
                    </td>
                    <td class="noBorder" style="vertical-align: top;">
                        <asp:RadioButtonList ID="rblPDType" runat="server" Width="116px" AutoPostBack="true">
                            <asp:ListItem Text="SOD" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Career Ladder" Value="4"></asp:ListItem>
                            <asp:ListItem Text="All" Value="-1"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td style="vertical-align: top;">
                        <table class="blueSubTable">
                            <tr>
                                <td>
                                    <asp:Label ID="lblJobSeries" runat="server" Text="Job Series:" />
                                    <!--<span class="required">*</span>-->
                                    <telerik:RadComboBox ID="rcbJobSeries" runat="server" AutoPostBack="false" Width="320px"
                                        DropDownWidth="420px" Height="160px" DataTextField="SeriesName" DataValueField="SeriesID"
                                        MarkFirstMatch="true" />
                                    <asp:RequiredFieldValidator ID="rcbJobSeriesReqVal" runat="server" ValidationGroup=""
                                        Enabled="false" ControlToValidate="rcbJobSeries" InitialValue="" ErrorMessage="Job Series is required"
                                        Display="None" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPDStatus" runat="server" Text="PD Status:" /><span class="required">*</span>&nbsp;
                                    <telerik:RadComboBox ID="rcbPDStatus" runat="server" AutoPostBack="false" Width="90px"
                                        DataTextField="WorkflowStatusName" DataValueField="WorkflowStatusID" />
                                    <asp:RequiredFieldValidator ID="rcbPDStatusReqVal" runat="server" ValidationGroup="Search3"
                                        ControlToValidate="rcbPDStatus" InitialValue="" ErrorMessage="PD Status is required"
                                        Display="None" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td align="right" style="vertical-align: top;">
                        <asp:Button ID="btnSearch3" runat="server" CssClass="formBtn" Text="Search" ToolTip="Search"
                            OnClick="btnSearch3_Click" ValidationGroup="Search3" />
                    </td>
                </tr>
            </table>
            <table class="blueTable" width="100%">
<%--                <colgroup>
                    <col width="20%" />
                    <col width="38%" />
                    <col align="right" width="42%" />--%>
                    <tr>
                        <td>
                            <asp:Label ID="lblGrade" runat="server" Text="Grade:" />
                            <telerik:RadComboBox ID="rcbGrade" runat="server" AutoPostBack="false" DataTextField="GradeName"
                                DataValueField="GradeID" DropDownWidth="100px" Height="160px" Width="105px" />
                        </td>
                        <td align>
                            <asp:Label ID="lblOpmPositionTitle" runat="server" Text="Position Title:" />
                            <asp:TextBox ID="txtOpmPositionTitle" runat="server" Width="250px" />
                        </td>
                        <td>
                            <asp:Label ID="lblAgencyPositionTitle" runat="server" Text="FWS Position Title:" />
                            <asp:TextBox ID="txtAgencyPositionTitle" runat="server" Width="150px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblRegion" runat="server" Text="Region:"></asp:Label>
                            <telerik:RadComboBox ID="rcbRegion" runat="server" DataTextField="RegionName" DataValueField="RegionID"
                                AutoPostBack="true" OnSelectedIndexChanged="rcbRegion_SelectedIndexChanged" Width="100px">
                            </telerik:RadComboBox>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:RadioButtonList ID="rdOrgCode" runat="server" Width="210px" RepeatDirection="Horizontal"
                                            AutoPostBack="true" OnSelectedIndexChanged="rdOrgCode_Changed">
                                            <asp:ListItem Text="Old Org Code" Value="o" Selected="True" />
                                            <asp:ListItem Text="New Org Code" Value="n" />
                                        </asp:RadioButtonList>
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="rcbOrganizationCode" runat="server" AutoPostBack="false"
                                            DataTextField="OrganizationName" DataValueField="OrganizationCodeID" DropDownWidth="350px"
                                            Height="160px" MarkFirstMatch="true" Width="200px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <asp:Label ID="PDCreator" runat="server" Text="PD Author:" />
                            <asp:TextBox ID="txtPDCreatorID" runat="server" Width="150px" />
                        </td>
                    </tr>
<%--                </colgroup>--%>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="divOrgCodemsg" runat="server" visible="false" class="requiredField">
        Position classification depends on complexity/scope of duties within an organization;
        be advised grades may differ per organization.</div>
    <h2 id="h2Caption" runat="server" visible="false">
        Reports</h2>
    <telerik:RadGrid ID="rgPositionDescription" runat="server" Visible="false" SkinID="SearchcustomRADGridView"
        Width="100%" OnNeedDataSource="rgPositionDescription_NeedDataSource" AllowPaging="true"
        PageSize="5" PagerStyle-AlwaysVisible="false" PagerStyle-Position="Bottom" AllowSorting="true"
        OnItemDataBound="rgPositionDescription_ItemDataBound">
        <MasterTableView GridLines="Both" ItemStyle-VerticalAlign="Top" AlternatingItemStyle-VerticalAlign="Top"
            ShowFooter="false" Width="100%" TableLayout="Auto" ItemStyle-Wrap="true" DataKeyNames="PositionDescriptionID, AssociatedFullPD"
            AllowNaturalSort="false" ClientDataKeyNames="PositionDescriptionID, AssociatedFullPD">
            <NoRecordsTemplate>
                <span style="font-weight: bold;">No PDs are found for the selected search criteria.
                    Please search again.</span>
            </NoRecordsTemplate>
            <Columns>
                <telerik:GridTemplateColumn HeaderText="PD Action" UniqueName="PDAction" Visible="true"
                    ItemStyle-Width="14%">
                    <ItemTemplate>
                        <telerik:RadMenu ID="rmPDAction" runat="server" OnItemClick="rmPDAction_ItemClick"
                            OnClientItemClicking="OnPDActionMenuClick" EnableImageSprites="true">
                            <Items>
                                <telerik:RadMenuItem Width="30px" Height="24px" CssClass="ddicon">
                                    <Items>
                                        <telerik:RadMenuItem Text="View" Value="View" />
                                        <telerik:RadMenuItem Text="Edit" Value="Edit" />
                                        <telerik:RadMenuItem Text="Continue Edit" Value="ContinueEdit" />
                                        <telerik:RadMenuItem Text="Finish Edit" Value="FinishEdit" />
                                        <telerik:RadMenuItem Text="Copy & Start New" Value="CSN" />
                                        <telerik:RadMenuItem Text="Create SOD" Value="SOD" />
                                        <telerik:RadMenuItem Text="Delete" Value="Delete" />
                                    </Items>
                                </telerik:RadMenuItem>
                            </Items>
                        </telerik:RadMenu>
                        &nbsp;
                        <asp:Image ID="imgPDCheckedOutStatus" Visible="false" runat="server" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <%-- <telerik:GridTemplateColumn HeaderText="PD No." UniqueName="PositionDescriptionID"
                    ItemStyle-Width="8%">
                    <ItemTemplate>
                        <asp:Label ID="lblPDNumber" runat="server" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>--%>
                <telerik:GridBoundColumn HeaderText="PD No." DataField="PDNo" UniqueName="PDNo" AllowSorting="true"
                    DataType="System.String" ItemStyle-Width="9%" />
                <telerik:GridBoundColumn HeaderText="FPPS PD No." UniqueName="FPPSPDID" DataField="FPPSPDID"
                    AllowSorting="false" ItemStyle-Width="8%">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn UniqueName="PDTypeID" DataField="PositionDescriptionTypeID"
                    Visible="false" ItemStyle-Width="9%">
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn HeaderText="PDType" UniqueName="PDType">
                    <ItemTemplate>
                        <asp:Label ID="lblPDType" runat="server" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn HeaderText="Is Std?" UniqueName="IsStandard" DataField="IsStandardPDDisp"
                    AllowSorting="true" ItemStyle-Width="8%">
                </telerik:GridBoundColumn>
                <%-- <telerik:GridTemplateColumn HeaderText="Org Code New (Old)" ItemStyle-Width="11%"
                    UniqueName="OrgCode">
                    <ItemTemplate> 
                        <asp:Label ID="lblOrgCode" runat="server" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>--%>
                <telerik:GridBoundColumn HeaderText="Org Code New (Old)" DataField="OrganizationCodeLegacy"
                    UniqueName="OrganizationCodeLegacy" AllowSorting="true" DataType="System.String"
                    ItemStyle-Width="11%" />
                <telerik:GridBoundColumn HeaderText="Series" UniqueName="JobSeriesID" DataField="JobSeriesID"
                    AllowSorting="true" ItemStyle-Width="6%">
                </telerik:GridBoundColumn>
                <%-- <telerik:GridTemplateColumn HeaderText="Grade" UniqueName="JobGrade" ItemStyle-Width="6%">
                    <ItemTemplate>
                        <asp:Label ID="lblGrade" runat="server" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>--%>
                <telerik:GridBoundColumn HeaderText="Grade" DataField="Grade" UniqueName="Grade"
                    AllowSorting="false" DataType="System.String" ItemStyle-Width="6%" />
                <telerik:GridBoundColumn HeaderText="OPM Title" ItemStyle-Font-Size="Smaller" UniqueName="OPMPositionTitle"
                    DataField="OPMPositionTitle" AllowSorting="true" ItemStyle-Width="10%">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="FWS Position Title" ItemStyle-Font-Size="Smaller"
                    UniqueName="FWSPositionTitle" DataField="FWSPositionTitle" AllowSorting="true"
                    ItemStyle-Width="9%">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn ItemStyle-Font-Size="Smaller" HeaderText="Created By" UniqueName="CreatedBy"
                    DataField="CreatedBy" AllowSorting="true" ItemStyle-Width="9%">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Updated" UniqueName="UpdateDate" DataField="UpdateDate"
                    DataFormatString="{0:MM/dd/yyyy}" AllowSorting="true" ItemStyle-Width="5%">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Status" UniqueName="WorkflowStatusName" DataField="WorkflowStatusName"
                    ItemStyle-Width="8%">
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn HeaderText="Document" UniqueName="Document" ItemStyle-Width="9%">
                    <ItemTemplate>
                        <telerik:RadMenu ID="rmDocument" runat="server" OnItemClick="rmDocument_ItemClick"
                            EnableImageSprites="true">
                            <Items>
                                <telerik:RadMenuItem CssClass="ddicon" Width="30px" Height="24px">
                                    <Items>
                                        <telerik:RadMenuItem Text="Position Description" Value="1" />
                                        <telerik:RadMenuItem Text="Job Analysis" Value="2" />
                                        <%-- <telerik:RadMenuItem Text="Coding Information" Value="3" />--%>
                                        <telerik:RadMenuItem Text="Evaluation Statement" Value="4" />
                                        <telerik:RadMenuItem Text="Comments" Value="5" />
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
    <telerik:RadGrid ID="rgHidden" runat="server" SkinID="customRADGridView" Width="100%"
        Visible="false" AllowPaging="true" PageSize="10" PagerStyle-AlwaysVisible="false"
        PagerStyle-Position="TopAndBottom" AllowSorting="true" AllowMultiRowSelection="true">
        <MasterTableView Width="100%" GridLines="Both" DataKeyNames="PositionDescriptionID, AssociatedFullPD">
            <Columns>
                <telerik:GridBoundColumn DataField="PositionDescriptionID" />
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
    <br />
</div>
<asp:HiddenField ID="hfSearchType" runat="server" Value="0" />
<input type="hidden" id="radGridClickedRowIndex" name="radGridClickedRowIndex" />
<input type="hidden" id="radGridClickedRowPositionDescriptionID" name="radGridClickedRowPositionDescriptionID" />
