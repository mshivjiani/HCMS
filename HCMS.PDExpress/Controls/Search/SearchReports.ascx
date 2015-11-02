<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchReports.ascx.cs"
    Inherits="HCMS.PDExpress.Controls.Search.SearchReports" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<telerik:RadCodeBlock ID="rcbCodeBlock" runat="server">
    <script type="text/javascript">
        var currentLoadingPanel = null;
        var currentUpdatedControl = null;

        function RequestStart(sender, args) {
            currentLoadingPanel = $find("<%= rlpDefault.ClientID %>");
            currentUpdatedControl = "<%= pnlSearch2.ClientID %>";

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
</telerik:RadCodeBlock>
<telerik:RadWindowManager ID="DefaultRadWindowManager" runat="server" ReloadOnShow="true"
    Skin="WebBlue">
</telerik:RadWindowManager>
<telerik:RadAjaxManager ID="radAjaxmgrReports" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rgPositionDescription">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgPositionDescription" />
                <telerik:AjaxUpdatedControl ControlID="hfSearchType" />
                <telerik:AjaxUpdatedControl ControlID="divOrgCodemsg" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnSearch1">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgPositionDescription" />
                <telerik:AjaxUpdatedControl ControlID="hfSearchType" />
                <telerik:AjaxUpdatedControl ControlID="divOrgCodemsg" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnSearch2">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgPositionDescription" />
                <telerik:AjaxUpdatedControl ControlID="hfSearchType" />
                <telerik:AjaxUpdatedControl ControlID="divOrgCodemsg" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnSearchAdvanced">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgPositionDescription" LoadingPanelID="rlpDefault" />
                <telerik:AjaxUpdatedControl ControlID="hfSearchType" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
    <ClientEvents OnRequestStart="RequestStart" OnResponseEnd="ResponseEnd" />
</telerik:RadAjaxManager>
<telerik:RadAjaxLoadingPanel ID="rlpDefault" runat="server" Skin="Web20" />
<div>
    <asp:UpdatePanel ID="updtPanelSearch1" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSearch2" />
        </Triggers>
        <ContentTemplate>
            <asp:ValidationSummary ID="Search1ValSumm" runat="server" ValidationGroup="Search1"
                CssClass="validationMessageBox" ShowSummary="true" HeaderText="<span class='systemMessage'>Validation Message</span><br>"
                DisplayMode="list" />
            <asp:ValidationSummary ID="Search2ValSumm" runat="server" ValidationGroup="Search2"
                CssClass="validationMessageBox" ShowSummary="true" HeaderText="<span class='systemMessage'>Validation Message</span><br>"
                DisplayMode="list" />
            <asp:Panel ID="pnlSearch1" runat="server" DefaultButton="btnSearch1">
                <table class="blueTable" width="100%">
                    <tr>
                        <td class="noBorder">
                            <asp:RadioButtonList ID="rblPDNumberType" runat="server" ValidationGroup="Search1"
                                RepeatDirection="Vertical" AutoPostBack="true" OnSelectedIndexChanged="rblPDNumberType_SelectedIndexChanged">
                                <asp:ListItem Text="PDExpress PD No" Value="1" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="FPPS PD No" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td style="vertical-align: middle;">
                            <asp:Label ID="lblPDNumber" runat="server" Text="PD No.:&nbsp;" />
                            <asp:TextBox ID="txtPDNumber" runat="server" Text="" />
                            <asp:RequiredFieldValidator ID="txtPDNumberReqVal" runat="server" ValidationGroup="Search1"
                                ControlToValidate="txtPDNumber" InitialValue="" ErrorMessage="PD Number is required"
                                Display="None" />
                            <asp:RegularExpressionValidator ID="txtPDNumberRegExpVal" runat="server" ValidationGroup="Search1"
                                ControlToValidate="txtPDNumber" ValidationExpression="^([0-9]\s*){1,16}$" ErrorMessage="PDExpress PD No. should be numeric"
                                Display="None" Enabled="false" />
                        </td>
                        <td align="right">
                            <asp:Button ID="btnSearch1" runat="server" CssClass="formBtn" Text="Search" ToolTip="Search by PD Number"
                                ValidationGroup="Search1" OnClick="btnSearch1_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
    <asp:UpdatePanel ID="updtPanelSearch2" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSearch1" />
        </Triggers>
        <ContentTemplate>
            <asp:Panel ID="pnlSearch2" runat="server" DefaultButton="btnSearch2">
                <table class="blueTable" width="100%">
                    <tr>
                        <td class="noBorder">
                            <asp:RequiredFieldValidator ID="rblTypeReqVal" runat="server" ControlToValidate="rblType"
                                ValidationGroup="Search2" InitialValue="" ErrorMessage="Type is required" Display="None" />
                            <asp:RadioButtonList ID="rblType" runat="server" ValidationGroup="Search2" Width="86"
                                AutoPostBack="true">
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
                                        <asp:Label ID="lblJobSeries" runat="server" Text="Job Series:" /><%--<span class="required">*</span>--%>
                                        <telerik:RadComboBox ID="rcbJobSeries" runat="server" AutoPostBack="false" Width="320px"
                                            MarkFirstMatch="true" DropDownWidth="420px" Height="160px" DataTextField="SeriesName"
                                            DataValueField="SeriesID" />
                                       <%-- <asp:RequiredFieldValidator ID="rcbJobSeriesReqVal" runat="server" ValidationGroup="Search2"
                                            ControlToValidate="rcbJobSeries" InitialValue="" ErrorMessage="Job Series is required"
                                            Display="None" />--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblPDStatus" runat="server" Text="PD Status:" /><span class="required">*</span>&nbsp;
                                        <telerik:RadComboBox ID="rcbPDStatus" runat="server" AutoPostBack="false" Width="100px"
                                            DataTextField="WorkflowStatusName" DataValueField="WorkflowStatusID" />
                                        <asp:RequiredFieldValidator ID="rcbPDStatusReqVal" runat="server" ValidationGroup="Search2"
                                            ControlToValidate="rcbPDStatus" InitialValue="" ErrorMessage="PD Status is required"
                                            Display="None" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td align="right" style="vertical-align: top;">
                            <asp:Button ID="btnSearch2" runat="server" CssClass="formBtn" Text="Search" ToolTip="Search"
                                OnClick="btnSearch2_Click" ValidationGroup="Search2" />
                            <br />
                            <br />
                            <asp:Button ID="btnSearchAdvanced" runat="server" CssClass="formBtn" Text="Advanced Search"
                                ToolTip="Advanced Search" OnClick="btnSearchAdvanced_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div id="divOrgCodemsg" runat="server" visible="false" class="requiredField">
        Position classification depends on complexity/scope of duties within an organization;
        be advised grades may differ per organization.</div>
    <h2 id="h2Caption" runat="server" visible="false">
        Reports</h2>
    <telerik:RadGrid ID="rgPositionDescription" runat="server" Visible="false" SkinID="SearchcustomRADGridView"
        Width="100%" OnNeedDataSource="rgPositionDescription_NeedDataSource" AllowPaging="true"
        AllowSorting="true" PageSize="5" PagerStyle-AlwaysVisible="false" PagerStyle-Position="Bottom"
        OnItemDataBound="rgPositionDescription_ItemDataBound">
        <MasterTableView GridLines="Both" ItemStyle-VerticalAlign="Top" AlternatingItemStyle-VerticalAlign="Top"
            ShowFooter="false" Width="100%" TableLayout="Auto" ItemStyle-Wrap="true" DataKeyNames="PositionDescriptionID, AssociatedFullPD"
            AllowNaturalSort="false" ClientDataKeyNames="PositionDescriptionID, AssociatedFullPD">
            <NoRecordsTemplate>
                <span style="font-weight: bold;">No PDs are found for the selected search criteria.
                    Please search again.</span>
            </NoRecordsTemplate>
            <Columns>
                <telerik:GridTemplateColumn HeaderText="PD Action" Visible="true" ItemStyle-Width="12%">
                    <ItemTemplate>
                        <telerik:RadMenu ID="rmPDAction" runat="server" OnItemClick="rmPDAction_ItemClick"
                            OnClientItemClicking="OnPDActionMenuClick" EnableImageSprites="true">
                            <Items>
                                <telerik:RadMenuItem CssClass="ddicon" Width="30px" Height="24px">
                                    <Items>
                                        <telerik:RadMenuItem Text="View" Value="View" />
                                        <telerik:RadMenuItem Text="Edit" Value="Edit" />
                                        <telerik:RadMenuItem Text="Continue Edit" Value="ContinueEdit" />
                                        <telerik:RadMenuItem Text="Finish Edit" Value="FinishEdit" />
                                        <telerik:RadMenuItem Text="Copy and Start New" Value="CSN" />
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
                <%--<telerik:GridTemplateColumn HeaderText="PD No." UniqueName="PositionDescriptionID" ItemStyle-Width="9%">
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
                    Visible="false">
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn HeaderText="PD Type" UniqueName="PDType" ItemStyle-Width="9%">
                    <ItemTemplate>
                        <asp:Label ID="lblPDType" runat="server" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn HeaderText="Is Std?" UniqueName="IsStandard" DataField="IsStandardPDDisp"
                    AllowSorting="true" ItemStyle-Width="9%">
                </telerik:GridBoundColumn>
                <%-- <telerik:GridTemplateColumn HeaderText="Org Code New (Old)" ItemStyle-Width="9%"
                    UniqueName="OrgCode">
                    <ItemTemplate>
                        <asp:Label ID="lblOrgCode" runat="server" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>--%>
                <telerik:GridBoundColumn HeaderText="Org Code New (Old)" DataField="OrganizationCodeLegacy"
                    UniqueName="OrganizationCodeLegacy" AllowSorting="true" DataType="System.String"
                    ItemStyle-Width="9%" />
                <telerik:GridBoundColumn HeaderText="Series" UniqueName="JobSeriesID" DataField="JobSeriesID"
                    AllowSorting="true" ItemStyle-Width="9%">
                </telerik:GridBoundColumn>
                <%-- <telerik:GridTemplateColumn HeaderText="Grade" UniqueName="JobGrade" ItemStyle-Width="6%">
                    <ItemTemplate>
                        <asp:Label ID="lblGrade" runat="server" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>--%>
                <telerik:GridBoundColumn HeaderText="Grade" DataField="Grade" UniqueName="Grade"
                    AllowSorting="false" DataType="System.String" ItemStyle-Width="6%" />
                <telerik:GridBoundColumn ItemStyle-Font-Size="Smaller" ItemStyle-Width="9%" HeaderText="OPM Title"
                    UniqueName="OPMPositionTitle" DataField="OPMPositionTitle" AllowSorting="true">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn ItemStyle-Font-Size="Smaller" HeaderText="FWS Position Title"
                    UniqueName="FWSPositionTitle" DataField="FWSPositionTitle" AllowSorting="true"
                    ItemStyle-Width="9%">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn ItemStyle-Font-Size="Smaller" HeaderText="Created By" UniqueName="CreatedBy"
                    DataField="CreatedBy" AllowSorting="true" ItemStyle-Width="9%">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Updated" UniqueName="UpdateDate" DataField="UpdateDate"
                    DataFormatString="{0:MM/dd/yyyy}" AllowSorting="true" ItemStyle-Width="9%">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Status" UniqueName="WorkflowStatusName" DataField="WorkflowStatusName"
                    AllowSorting="true" ItemStyle-Width="9%">
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
                                        <%-- <telerik:RadMenuItem Text="Coding Information(OF-8)" Value="3" />--%>
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
