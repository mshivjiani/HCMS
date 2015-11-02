<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchReports.ascx.cs"
    Inherits="HCMS.JNP.Controls.Search.SearchReports" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Package/ctrlJNPUpdateHiringResult.ascx" TagPrefix="JNPUpdateHiringResult"
    TagName="ctrlJNPUpdateHiringResult" %>
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


        function ShowJNPUpdateHiringResultPopUp(jnpID) {
            var omanager = GetRadWindowManager();
            var oWnd = omanager.getWindowByName('rwJNPUpdateHiringResult');
            var navigateurl = "../Package/UpdateHiringResult.aspx?JNPID=" + jnpID;
            oWnd.setUrl(navigateurl);
            oWnd.show();
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
     
    </script>
</telerik:RadCodeBlock>
<telerik:RadAjaxManager ID="radAjaxmgrReports" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rblSearchNumberType">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rblSearchNumberType" LoadingPanelID="ajaxLoadingPanelSave" />
                <telerik:AjaxUpdatedControl ControlID="lblSearchNumber" LoadingPanelID="ajaxLoadingPanelSave" />
                <telerik:AjaxUpdatedControl ControlID="txtSearchNumberRegExpVal" LoadingPanelID="ajaxLoadingPanelSave" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="rgSearchResults">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgSearchResults" LoadingPanelID="ajaxLoadingPanelSave" />
                <telerik:AjaxUpdatedControl ControlID="hfSearchType" LoadingPanelID="ajaxLoadingPanelSave" />
                <telerik:AjaxUpdatedControl ControlID="divOrgCodemsg" LoadingPanelID="ajaxLoadingPanelSave" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnSearch1">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgSearchResults" LoadingPanelID="ajaxLoadingPanelSave" />
                <telerik:AjaxUpdatedControl ControlID="hfSearchType" LoadingPanelID="ajaxLoadingPanelSave" />
                <telerik:AjaxUpdatedControl ControlID="divOrgCodemsg" LoadingPanelID="ajaxLoadingPanelSave" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnSearch2">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgSearchResults" LoadingPanelID="ajaxLoadingPanelSave" />
                <telerik:AjaxUpdatedControl ControlID="hfSearchType" LoadingPanelID="ajaxLoadingPanelSave" />
                <telerik:AjaxUpdatedControl ControlID="divOrgCodemsg" LoadingPanelID="ajaxLoadingPanelSave" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnSearch3">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgSearchResults" LoadingPanelID="ajaxLoadingPanelSave" />
                <telerik:AjaxUpdatedControl ControlID="hfSearchType" LoadingPanelID="ajaxLoadingPanelSave" />
                <telerik:AjaxUpdatedControl ControlID="divOrgCodemsg" LoadingPanelID="ajaxLoadingPanelSave" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnSearch4">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgSearchResults" LoadingPanelID="ajaxLoadingPanelSave" />
                <telerik:AjaxUpdatedControl ControlID="hfSearchType" LoadingPanelID="ajaxLoadingPanelSave" />
                <telerik:AjaxUpdatedControl ControlID="divOrgCodemsg" LoadingPanelID="ajaxLoadingPanelSave" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnSearchAdvanced">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgSearchResults" LoadingPanelID="ajaxLoadingPanelSave" />
                <telerik:AjaxUpdatedControl ControlID="hfSearchType" LoadingPanelID="ajaxLoadingPanelSave" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="rcbRegion">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rcbOrganizationCode" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <%--
        <telerik:AjaxSetting AjaxControlID="rdOrgCode">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rcbOrganizationCode" />
            </UpdatedControls>
        </telerik:AjaxSetting>--%>
    </AjaxSettings>
    <ClientEvents OnRequestStart="RequestStart" OnResponseEnd="ResponseEnd" />
</telerik:RadAjaxManager>
<telerik:RadAjaxLoadingPanel ID="ajaxLoadingPanelSave" runat="server" />
<div>
    <cc1:Accordion ID="accSearch" runat="server" AutoSize="None" RequireOpenedPane="false"
        SelectedIndex="0" HeaderCssClass="blueAccordionHeader" HeaderSelectedCssClass="blueAccordionHeaderSelected">
        <Panes>
            <cc1:AccordionPane ID="accPanelBasicSearch" runat="server">
                <Header>
                    Basic Search</Header>
                <Content>
                    <asp:Panel ID="pnlSearch1" runat="server" DefaultButton="btnSearch1">
                        <table class="blueTable" width="100%">
                            <tr>
                                <td class="noBorder">
                                    <asp:RadioButtonList ID="rblSearchNumberType" runat="server" ValidationGroup="Search1"
                                        AutoPostBack="true" RepeatDirection="Vertical" OnSelectedIndexChanged="rblSearchNumberType_SelectedIndexChanged">
                                        <asp:ListItem Text="JAX ID" Value="1" Selected="True"></asp:ListItem>
                                        <asp:ListItem Text="PDExpress PD No" Value="2"></asp:ListItem>
                                        <asp:ListItem Text="FPPS PD No" Value="3"></asp:ListItem>
                                        <asp:ListItem Text="Vacancy ID" Value="4"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td style="vertical-align: middle;">
                                    <asp:Label ID="lblSearchNumber" runat="server" Text="Enter JAX ID: " /><span class="required">*</span>
                                    <asp:TextBox ID="txtSearchNumber" runat="server" Text="" />
                                    <asp:RequiredFieldValidator ID="txtSearchNumberReqVal" runat="server" ValidationGroup="Search1"
                                        ControlToValidate="txtSearchNumber" InitialValue="" ErrorMessage="Number/ID is required"
                                        Display="None" />
                                    <asp:RegularExpressionValidator ID="txtSearchNumberRegExpVal" runat="server" ValidationGroup="Search1"
                                        ControlToValidate="txtSearchNumber" ValidationExpression="\d*" ErrorMessage="Number/ID should be numeric"
                                        Display="None" Enabled="false" />
                                </td>
                                <td align="right">
                                    <asp:Button ID="btnSearch1" runat="server" CssClass="formBtn" Text="Search" ToolTip="Search by Number"
                                        OnClientClick="SetValidationGroup('Search1');" ValidationGroup="Search1" OnClick="btnSearch1_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </Content>
            </cc1:AccordionPane>
            <cc1:AccordionPane ID="accPanelKeywordSearch" runat="server">
                <Header>
                    Keyword Search</Header>
                <Content>
                    <table class="blueTable" width="100%">
                        <colgroup>
                            <col width="20%" />
                            <col width="38%" />
                            <col align="right" width="42%" />
                            <tr>
                                <td class="noBorder">
                                    <div id="divKeyword" runat="server" visible="true">
                                        <asp:Label ID="lblKeyword" runat="server" Text="Keyword to Search for: "></asp:Label><span
                                            class="required">*</span>
                                        <asp:TextBox ID="txtKeyword" runat="server" MaxLength="255" Width="250px" Enabled="true"
                                            ValidationGroup="Search2"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="txtKeyWordReqVal" runat="server" ControlToValidate="txtKeyword"
                                            InitialValue="" ErrorMessage="Please enter a keyword to search for." Display="None"
                                            ValidationGroup="Search2">
                                        </asp:RequiredFieldValidator>
                                    </div>
                                    <div>
                                        <asp:Label ID="lblDocumentType" runat="server" Text="Type of Document to Search on: "></asp:Label><span
                                            class="required">*</span>
                                        <telerik:RadComboBox ID="rcbDocumentType" runat="server" AutoPostBack="false" DataTextField="StaffingObjectTypeDesc"
                                            DataValueField="StaffingObjectTypeID" Width="200px" />
                                        <asp:RequiredFieldValidator ID="rcbDocumentTypeReqVal" runat="server" ValidationGroup="Search2"
                                            ControlToValidate="rcbDocumentType" InitialValue="" ErrorMessage="Document Type is required."
                                            Display="None" />
                                    </div>
                                </td>
                                <td style="vertical-align: middle;">
                                </td>
                                <td align="right">
                                    <asp:Button ID="btnSearch3" runat="server" CssClass="formBtn" Text="Search" ToolTip="Search by Keyword"
                                        ValidationGroup="Search2" OnClick="btnSearch3_Click" OnClientClick="SetValidationGroup('Search2');" />
                                </td>
                            </tr>
                        </colgroup>
                    </table>
                </Content>
            </cc1:AccordionPane>
            <cc1:AccordionPane ID="accPanelAdvancedSearch" runat="server">
                <Header>
                    Advanced Search</Header>
                <Content>
                    <asp:Panel ID="pnlSearch2" runat="server" DefaultButton="btnSearch4">
                        <table class="blueTable" width="100%">
                            <tr>
                                <%--<td class="noBorder">
                                    <asp:RadioButtonList ID="rblType" runat="server" ValidationGroup="Search3" Width="86"
                                        AutoPostBack="false">
                                        <asp:ListItem Text="Standard" Value="1" />
                                        <asp:ListItem Text="Other" Value="2" />
                                        <asp:ListItem Text="All" Value="3" Selected="True" />
                                    </asp:RadioButtonList>
                                </td>
                                <td class="noBorder" style="vertical-align: top;">
                                </td>--%>
                                <td style="vertical-align: top;">
                                    <table class="blueSubTable">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblJobSeries" runat="server" Text="Job Series:" /><%--<span class="required">*</span>--%>
                                                <telerik:RadComboBox ID="rcbJobSeries" runat="server" AutoPostBack="false" Width="480px"
                                                    MarkFirstMatch="true" DropDownWidth="450px" Height="160px" DataTextField="SeriesName"
                                                    DataValueField="SeriesID" />
                                                <%--<asp:RequiredFieldValidator ID="rcbJobSeriesReqVal" runat="server" ValidationGroup="Search3"
                                                    ControlToValidate="rcbJobSeries" InitialValue="" ErrorMessage="Job Series is required"
                                                    Display="None" />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblJNPStatus" runat="server" Text="JAX Status:" /><span class="required">*</span>&nbsp;
                                                <telerik:RadComboBox ID="rcbJNPStatus" runat="server" AutoPostBack="false" Width="100px"
                                                    DataTextField="WorkflowStatusName" DataValueField="WorkflowStatusID" />
                                                <asp:RequiredFieldValidator ID="rcbJNPStatusReqVal" runat="server" ValidationGroup="Search3"
                                                    ControlToValidate="rcbJNPStatus" InitialValue="" ErrorMessage="JAX Status is required"
                                                    Display="None" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <table class="blueTable" width="100%">
                            <colgroup>
                                <col width="20%" />
                                <col width="38%" />
                                <col align="right" width="42%" />
                                <tr>
                                    <td>
                                        <asp:Label ID="lblGrade" runat="server" Text="Grade:" />
                                        <telerik:RadComboBox ID="rcbGrade" runat="server" AutoPostBack="false" DataTextField="GradeName"
                                            DataValueField="GradeID" DropDownWidth="100px" Height="160px" Width="100px" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblOpmPositionTitle" runat="server" Text="OPM Title:" />
                                        <asp:TextBox ID="txtOpmPositionTitle" runat="server" Width="200px" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblRegion" runat="server" Text="Region:" />
                                        <telerik:RadComboBox ID="rcbRegion" runat="server" AutoPostBack="true" OnSelectedIndexChanged="rcbRegion_SelectedIndexChanged"
                                            DataTextField="RegionName" DataValueField="RegionID" DropDownWidth="100px" Height="160px"
                                            Width="100px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:RadioButtonList ID="rdOrgCode" runat="server" Width="200px" RepeatDirection="Horizontal"
                                            AutoPostBack="true" OnSelectedIndexChanged="rdOrgCode_Changed">
                                            <asp:ListItem Text="Old Org Code" Value="o" Selected="True" />
                                            <asp:ListItem Text="New Org Code" Value="n" />
                                        </asp:RadioButtonList>
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="rcbOrganizationCode" runat="server" AutoPostBack="false"
                                            DataTextField="OrganizationName" DataValueField="OrganizationCodeID" DropDownWidth="400px"
                                            Height="160px" MarkFirstMatch="true" Width="254px" />
                                    </td>
                                    <td>
                                        <asp:Label ID="lblJNPCreator" runat="server" Text="Author:" />
                                        <asp:TextBox ID="txtJNPCreator" runat="server" Width="200px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="lblPackageSuccessRate" runat="server" Visible="true" Text="Package Success Rate:" />
                                        <asp:RadioButtonList ID="rblPackageSuccessRate" runat="server" ValidationGroup="Search3"
                                            RepeatDirection="Horizontal" AutoPostBack="false">
                                            <asp:ListItem Text="Successful" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Unsuccessful" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="All" Value="3" Selected="True"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                    <td style="vertical-align: middle;">
                                    </td>
                                    <td align="right">
                                        <asp:Button ID="btnSearch4" runat="server" CssClass="formBtn" Text="Search" ToolTip="Search"
                                            ValidationGroup="Search3" OnClick="btnSearch4_Click" OnClientClick="SetValidationGroup('Search3');" />
                                    </td>
                                </tr>
                            </colgroup>
                        </table>
                    </asp:Panel>
                </Content>
            </cc1:AccordionPane>
        </Panes>
    </cc1:Accordion>
    <div id="divOrgCodemsg" runat="server" visible="false" class="requiredField">
        <h2 id="h2Caption" runat="server">
            Search Results</h2>
    </div>
    <telerik:RadGrid ID="rgSearchResults" runat="server" Visible="false" Width="100%"
        SkinID="SearchRADGridView" OnNeedDataSource="rgSearchResults_NeedDataSource"
        AllowPaging="true" PageSize="5" PagerStyle-AlwaysVisible="false" PagerStyle-Position="Bottom"
        OnItemDataBound="rgSearchResults_ItemDataBound" AllowSorting="true">
        <MasterTableView GridLines="Both" ItemStyle-VerticalAlign="Top" AlternatingItemStyle-VerticalAlign="Top"
            ShowFooter="false" Width="100%" TableLayout="Auto" ItemStyle-Wrap="true" DataKeyNames="JNPID"
            ClientDataKeyNames="JNPID">
            <Columns>
                <telerik:GridTemplateColumn HeaderText="Action" Visible="true" HeaderStyle-Width="55px"
                    ItemStyle-Width="55px">
                    <ItemTemplate>
                        <telerik:RadMenu ID="rmJNPAction" runat="server" OnItemClick="rmJNPAction_ItemClick"
                            EnableImageSprites="true">
                            <Items>
                                <telerik:RadMenuItem CssClass="ddicon" ToolTip="Select Action" Width="30px" Height="24px">
                                    <Items>
                                        <telerik:RadMenuItem Text="View" Value="View" Visible="false" />
                                        <telerik:RadMenuItem Text="Edit" Value="Edit" Visible="false" />
                                        <telerik:RadMenuItem Text="Continue Edit" Value="ContinueEdit" Visible="false" />
                                        <telerik:RadMenuItem Text="Finish Edit" Value="FinishEdit" Visible="false" />
                                        <telerik:RadMenuItem Text="Copy and Start New" Value="CSN" Visible="false" />
                                        <telerik:RadMenuItem Text="Update Hiring Result" Value="UpdateHiringResult" Visible="false" />
                                    </Items>
                                </telerik:RadMenuItem>
                            </Items>
                        </telerik:RadMenu>
                        &nbsp;
                        <asp:Image ID="imgJNPCheckedOutStatus" CssClass="checked" Visible="false" runat="server" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn HeaderText="JAX ID" UniqueName="JNPID" DataField="JNPID"
                    AllowSorting="true">
                </telerik:GridBoundColumn>
                <%--<telerik:GridTemplateColumn HeaderText="JAX ID" UniqueName="JNPID">
                    <ItemTemplate>
                        <asp:Label ID="lblJNPID" runat="server" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>--%>
                <telerik:GridBoundColumn UniqueName="JNPTypeID" DataField="JNPTypeID" Visible="false">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Org Code" UniqueName="OrganizationDetailLineLegacy"
                    DataField="OrganizationDetailLineLegacy" AllowSorting="true">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Series" UniqueName="SeriesID" DataField="SeriesID"
                    AllowSorting="true">
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn HeaderText="Grade" UniqueName="Grade">
                    <ItemTemplate>
                        <asp:Label ID="lblGrade" runat="server" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn ItemStyle-Font-Size="Smaller" ItemStyle-Width="10px" HeaderText="OPM Title"
                    UniqueName="JNPTitle" DataField="JNPTitle" AllowSorting="true">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Updated" UniqueName="UpdateDate" DataField="UpdateDate"
                    DataFormatString="{0:MM/dd/yyyy}" AllowSorting="true">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Status" UniqueName="JNPWorkflowStatus" DataField="JNPWorkflowStatus"
                    AllowSorting="true">
                </telerik:GridBoundColumn>
                <telerik:GridTemplateColumn HeaderText="Document" UniqueName="Document">
                    <ItemTemplate>
                        <telerik:RadMenu ID="rmDocument" runat="server" OnItemClick="rmDocument_ItemClick"
                            EnableImageSprites="true">
                            <Items>
                                <telerik:RadMenuItem CssClass="ddicon" ToolTip="Select Document" Width="30px" Height="24px">
                                    <Items>
                                        <%--<telerik:RadMenuItem Text="Job Analysis(PDF)" Value="1" />
                                        <telerik:RadMenuItem Text="Job Analysis(DOC)" Value="11" />
                                        <telerik:RadMenuItem Text="Category Rating(PDF)" Value="2" />
                                        <telerik:RadMenuItem Text="Category Rating(DOC)" Value="22" />
                                        <telerik:RadMenuItem Text="Job Questionnaire(PDF)" Value="3" />
                                        <telerik:RadMenuItem Text="Job Questionnaire(DOC)" Value="33" />
                                        <telerik:RadMenuItem Text="Job Questionnaire-UTF8" Value="5" />
                                        <telerik:RadMenuItem Text="Comments(PDF)" Value="4" />
                                        <telerik:RadMenuItem Text="Comments(DOC)" Value="44" />
                                        <telerik:RadMenuItem Text="All(PDF)" Value="6" />
                                        <telerik:RadMenuItem Text="All(DOC)" Value="66" />--%>
                                        <telerik:RadMenuItem Text="Job Analysis" Value="1" />
                                        <telerik:RadMenuItem Text="Category Rating" Value="2" />
                                        <telerik:RadMenuItem Text="Job Questionnaire" Value="3" />
                                        <telerik:RadMenuItem Text="Job Questionnaire-UTF8" Value="5" />
                                        <telerik:RadMenuItem Text="Comments" Value="4" />
                                        <telerik:RadMenuItem Text="All" Value="6" />
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
    <telerik:RadGrid ID="rgHidden" runat="server" Width="100%" Visible="false" AllowPaging="true"
        PageSize="10" PagerStyle-AlwaysVisible="false" PagerStyle-Position="TopAndBottom"
        AllowSorting="true" AllowMultiRowSelection="true">
        <MasterTableView Width="100%" GridLines="Both" DataKeyNames="JNPID">
            <Columns>
                <telerik:GridBoundColumn DataField="JNPID" />
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
    <br />
</div>
<asp:HiddenField ID="hfSearchType" runat="server" Value="0" />
<input type="hidden" id="radGridClickedRowIndex" name="radGridClickedRowIndex" />
<input type="hidden" id="radGridClickedRowPositionDescriptionID" name="radGridClickedRowPositionDescriptionID" />
<div>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Skin="WebBlue">
        <Windows>
            <telerik:RadWindow ID="rwJNPUpdateHiringResult" runat="server" RegisterWithScriptManager="true"
                Skin="WebBlue" Height="220px" Width="510px" Behaviors="Close" VisibleStatusbar="false"
                Modal="true" ReloadOnShow="true" OnClientClose="OnPopupWindowClose">
            </telerik:RadWindow>
        </Windows>
    </telerik:RadWindowManager>
</div>
