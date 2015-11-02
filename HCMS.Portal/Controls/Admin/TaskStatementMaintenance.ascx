<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TaskStatementMaintenance.ascx.cs"
    Inherits="HCMS.Portal.Controls.Admin.TaskStatementMaintenance" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<br />
<telerik:RadCodeBlock ID="rcbCodeBlock" runat="server">
    <script type="text/javascript">
        function ClearExistingTSSearchTextbox() {
            document.getElementById('<%= txtExistingTSID.ClientID %>').value = '';
        }     
    </script>
</telerik:RadCodeBlock>
<asp:ValidationSummary ID="valSummary" runat="server" CssClass="validationMessageBox"
    ShowSummary="true" HeaderText="<span class='systemMessage'>Validation Message</span><br>"
    DisplayMode="BulletList" ValidationGroup="internalValidation" />
<br />
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdatePanelsRenderMode="Inline">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btnExistingTSSearch">
            <UpdatedControls>
      <telerik:AjaxUpdatedControl ControlID ="divTSSearch" />
                <telerik:AjaxUpdatedControl ControlID="txtExistingTSID" />
                <telerik:AjaxUpdatedControl ControlID="rgTaskStatements" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnExistingTSClear">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="txtExistingTSID" />
                <telerik:AjaxUpdatedControl ControlID="rgTaskStatements" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>

<div id="divTSSearch" runat ="server">
<div class="errorMessage"><asp:Literal ID="literalmsg" runat ="server"  ></asp:Literal></div>                                
<asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validationMessageBox"
    ShowSummary="true" HeaderText="<span class='systemMessage'>Validation Message</span><br>"
    ValidationGroup="ClientValidation" />
<table style="width: 780px">
    <tr>
        <td>
            <div id="Div1" class="subTableHeader" runat="server">
                <asp:Label ID="lblExistingTSSearch" runat="server" Text="Task Statement Search"></asp:Label>
            </div>
            <cc1:Accordion ID="accordianKeyword" runat="server" HeaderCssClass="blueAccordionHeader"
                SelectedIndex="0">
                <Panes>
                    <cc1:AccordionPane ID="accPanelBasicSearch" runat="server">
                        <Header>
                            Search By ID</Header>
                        <Content>
                            <table class="blueTable" width="100%">
                                <tr>
                                    <td>
                                        Task Statement ID:
                                    </td>
                                    <td> 
                                        <telerik:RadTextBox ID="txtExistingTSID" runat="server" Width="250px">
                                        </telerik:RadTextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldTSID" runat="server" ControlToValidate="txtExistingTSID"
                                            Display="None" ErrorMessage="Task Statement ID is required." ValidationGroup="ClientValidation" />
                                        <asp:CompareValidator ID="NumericFieldTSID" runat="server" ControlToValidate="txtExistingTSID"
                                            Type="Integer" Operator="DataTypeCheck" ErrorMessage="Task Statement ID should be numeric."
                                            Display="None" ValidationGroup="ClientValidation" />
                                        &nbsp; &nbsp;
                                        <asp:Button ID="btnExistingTSSearch" runat="server" Text="Search" OnClick="btnExistingTSSearch_Click"
                                            CausesValidation="true" ValidationGroup="ClientValidation" />&nbsp; &nbsp;
                                        <asp:Button ID="btnExistingTSClear" runat="server" Text="Clear" OnClick="btnExistingTSClear_Click"
                                            OnClientClick="ClearExistingTSSearchTextbox();" />
                                    </td>
                                </tr>
                            </table>
                        </Content>
                    </cc1:AccordionPane>
                    <cc1:AccordionPane ID="accPanelAdvancedSearch" runat="server">
                        <Header>
                            Advanced Search</Header>
                        <Content>
                            <table class="blueTable" width="100%">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblSeries" runat="server" Text="Select Series:" ToolTip="Select Series"
                                            AssociatedControlID="rcbSeries"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="rcbSeries" runat="server" DataValueField="SeriesID" DataTextField="DetailLine"
                                            MarkFirstMatch="true" Width="500px">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblGrade" runat="server" Text="Select Grade:" ToolTip="Select Grade"
                                            AssociatedControlID="rcbGrade"></asp:Label>
                                    </td>
                                    <td>
                                        <telerik:RadComboBox ID="rcbGrade" runat="server" DataValueField="GradeID" DataTextField="GradeName"
                                            MarkFirstMatch="true">
                                        </telerik:RadComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblKeyword" runat="server" Text="Enter Keyword:" ToolTip="Enter Keyword"
                                            AssociatedControlID="txtKeyword" Width="400px"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtKeyword" runat="server" Width="500px"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" align="right">
                                        <asp:Button ID="btnAdvancedSearch" runat="server" Text="Search" ToolTip="Advanced  Search"
                                            OnClick="btnAdvancedSearch_Click" />
                                    </td>
                                </tr>
                            </table>
                        </Content>
                    </cc1:AccordionPane>
                </Panes>
            </cc1:Accordion>

            Task Statements
            <telerik:RadGrid ID="rgTaskStatements" runat="server" ValidationSettings-EnableValidation="true"
                ValidationSettings-ValidationGroup="internalValidation" AllowPaging="True" OnItemCommand="rgTaskStatements_ItemCommand"
                AutoGenerateColumns="False" OnNeedDataSource="rgTaskStatements_NeedDataSource"
                CellSpacing="0" GridLines="None" PageSize="10">
                <MasterTableView Width="100%" DataKeyNames="TaskStatementID" EditMode="EditForms"
                    CommandItemSettings-ShowRefreshButton="false">
                    <CommandItemSettings ExportToPdfText="Export to PDF" ShowRefreshButton="False"></CommandItemSettings>
                    <RowIndicatorColumn Visible="false" FilterControlAltText="Filter RowIndicator column">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridTemplateColumn>
                            <ItemStyle VerticalAlign="Top" Width="10" />
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButtonEdit" runat="server" ToolTip="Edit" CommandName="Edit"
                                    SkinID="editButton" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridButtonColumn ConfirmText="Delete this taskStatement?" ConfirmDialogType="RadWindow"
                            ConfirmTitle="Delete" ButtonType="ImageButton" CommandName="Delete" Text="Delete"
                            UniqueName="DeleteCommandColumn">
                            <ItemStyle VerticalAlign="Top" Width="10" />
                        </telerik:GridButtonColumn>
                        <telerik:GridTemplateColumn HeaderText="ID" UniqueName="TaskStatementID" SortExpression="KSAID">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblTaskStatementID" Text='<%# Eval("TaskStatementID") %>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Text" SortExpression="TaskStatementText"
                            UniqueName="TaskStatementText" DataField="TaskStatementID">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblTaskStatementText" Text='<%# Eval("TaskStatement") %>'></asp:Label>
                            </ItemTemplate>
                       
                        </telerik:GridTemplateColumn>
                    </Columns>
                    <EditFormSettings EditFormType="Template">
                        <FormTemplate>
                            <table id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td width="560px">
                                        <asp:Label ID="Label1" runat="server" Text="Text"></asp:Label>
                                        <telerik:RadTextBox runat="server" ID="rtbTaskStatementText" Width="500px" TextMode="MultiLine"
                                            Text='<%#Bind("TaskStatement") %>' Rows="2">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Update" ToolTip="Update"
                                            ImageAlign="AbsMiddle" ImageUrl="~/App_Themes/HCMS_Default/Images/RAD/Grid/Update.gif">
                                        </asp:ImageButton>&nbsp;&nbsp;&nbsp;
                                        <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Cancel" ToolTip="Cancel"
                                            ImageAlign="AbsMiddle" ImageUrl="~/App_Themes/HCMS_Default/Images/RAD/Grid/Cancel.gif">
                                        </asp:ImageButton>
                                    </td>
                                </tr>
                            </table>
                        </FormTemplate>
                    </EditFormSettings>
                    <EditFormSettings>
                        <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                        </EditColumn>
                    </EditFormSettings>
                </MasterTableView>
                <ValidationSettings ValidationGroup="internalValidation"></ValidationSettings>
                <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="false">
                    <Selecting AllowRowSelect="true" />
                </ClientSettings>
                <FilterMenu EnableImageSprites="False">
                </FilterMenu>
            </telerik:RadGrid>
           
        </td>
    </tr>
</table>

</div>
<asp:ObjectDataSource ID="TaskStatementsObjectDataSource" runat="server" TypeName="HCMS.Business.Lookups.TaskStatement"
    SelectMethod="SelectTaskStatement" SelectCountMethod="SelectTaskStatementTotalCount"
    EnablePaging="True" OldValuesParameterFormatString="original_{0}">
    <SelectParameters>
        <asp:Parameter Name="startRowIndex" Type="Int32" />
        <asp:Parameter Name="maximumRows" Type="Int32" />
    </SelectParameters>
</asp:ObjectDataSource>
