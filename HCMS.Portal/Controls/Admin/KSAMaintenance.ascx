<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KSAMaintenance.ascx.cs"
    Inherits="HCMS.Portal.Controls.Admin.KSAMaintenance" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<br />
<telerik:RadCodeBlock ID="rcbCodeBlock" runat="server">
    <script type="text/javascript">
        function ClearExistingKSASearchTextbox() {
            document.getElementById('<%= txtExistingKSAID.ClientID %>').value = '';
        }      
    </script>
</telerik:RadCodeBlock>
<asp:ValidationSummary ID="valSummary" runat="server" CssClass="validationMessageBox"
    ShowSummary="true" HeaderText="<span class='systemMessage'>Validation Message</span><br>"
    DisplayMode="BulletList" ValidationGroup="internalValidation" />
<br />
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdatePanelsRenderMode="Inline">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btnExistingKSASearch">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="txtExistingKSAID" />
                <telerik:AjaxUpdatedControl ControlID="rgKSA" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnExistingKSAClear">
            <UpdatedControls> 
                <telerik:AjaxUpdatedControl ControlID="txtExistingKSAID" />
                <telerik:AjaxUpdatedControl ControlID="rgKSA" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="validationMessageBox"
    ShowSummary="true" HeaderText="<span class='systemMessage'>Validation Message</span><br>"
    ValidationGroup="ClientValidation" />
<table style="width: 780px">
    <tr>
        <td>
            <div id="Div1" class="subTableHeader" runat="server">
                <asp:Label ID="lblExistingKSASearch" runat="server" Text="KSA Search"></asp:Label>
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
                                        KSA ID:
                                    </td>
                                    <td>
                                        <telerik:RadTextBox ID="txtExistingKSAID" runat="server" Width="250px">
                                        </telerik:RadTextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldTSID" runat="server" ControlToValidate="txtExistingKSAID"
                                            Display="None" ErrorMessage="KSA ID is required." ValidationGroup="ClientValidation" />
                                        <asp:CompareValidator ID="NumericFieldKSAID" runat="server" ControlToValidate="txtExistingKSAID"
                                            Type="Integer" Operator="DataTypeCheck" ErrorMessage="KSA ID should be numeric."
                                            Display="None" ValidationGroup="ClientValidation" />
                                        &nbsp; &nbsp;
                                        <asp:Button ID="btnExistingKSASearch" runat="server" Text="Search" OnClick="btnExistingKSASearch_Click"
                                            CausesValidation="true" ValidationGroup="ClientValidation" />&nbsp; &nbsp;
                                        <asp:Button ID="btnExistingKSAClear" runat="server" Text="Clear" OnClick="btnExistingKSAClear_Click"
                                            OnClientClick="ClearExistingKSASearchTextbox();" />
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
            KSA
            <telerik:RadGrid ID="rgKSA" GridLines="None" runat="server" ValidationSettings-EnableValidation="true"
                ValidationSettings-ValidationGroup="internalValidation" AllowPaging="True" OnItemCommand="rgKSA_ItemCommand"
                AutoGenerateColumns="False" OnNeedDataSource="rgKSA_NeedDataSource" OnItemDataBound="rgKSA_ItemDataBound"
                CellSpacing="0" PageSize="10">
                <MasterTableView Width="100%" DataKeyNames="KSAID">
                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridTemplateColumn>
                            <ItemStyle VerticalAlign="Top" Width="10" />
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButtonEdit" runat="server" ToolTip="Edit" CommandName="Edit"
                                    SkinID="editButton" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="ID" UniqueName="KSAID" SortExpression="KSAID">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblKSAID" Text='<%# Eval("KSAID") %>'></asp:Label>
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Text" SortExpression="KSAText" UniqueName="KSAText">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblKSAText" Text='<%# Eval("KSAText") %>'></asp:Label>
                            </ItemTemplate>
                            <%-- <EditItemTemplate>
                                        <telerik:RadTextBox runat="server" ID="rtbKSAText" Width="500px" TextMode="MultiLine"
                                            Text='<%#Eval("KSAText") %>' Rows="2">
                                        </telerik:RadTextBox>
                                    </EditItemTemplate>--%>
                        </telerik:GridTemplateColumn>
                        <telerik:GridTemplateColumn HeaderText="Active" SortExpression="Active" UniqueName="Active">
                            <ItemTemplate>
                                <asp:CheckBox ID="lblActive" runat="server" Checked='<%# Eval("Active") %>' Enabled="false">
                                </asp:CheckBox>
                            </ItemTemplate>
                            <%-- <EditItemTemplate>
                                        <asp:CheckBox ID="chkActive" runat="server" Checked='<%#Eval("Active") %>'></asp:CheckBox>
                                    </EditItemTemplate>--%>
                        </telerik:GridTemplateColumn>
                    </Columns>
                    <EditFormSettings EditFormType="Template">
                        <FormTemplate>
                            <table id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td width="560px">
                                        <asp:Label runat="server" Text="Text"></asp:Label>
                                        <telerik:RadTextBox runat="server" ID="rtbKSAText" Width="500px" TextMode="MultiLine"
                                            Text='<%#Eval("KSAText") %>' Rows="2">
                                        </telerik:RadTextBox>
                                    </td>
                                    <td>
                                        <asp:Label runat="server" Text="Active"></asp:Label>
                                        <asp:CheckBox ID="chkActive" runat="server" Checked='<%#Eval("Active") %>'></asp:CheckBox>
                                        &nbsp;&nbsp;&nbsp;
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
                <ClientSettings>
                </ClientSettings>
                <FilterMenu EnableImageSprites="False">
                </FilterMenu>
            </telerik:RadGrid>
        </td>
    </tr>
</table>
<asp:ObjectDataSource ID="KSAObjectDataSource" runat="server" TypeName="HCMS.Business.Lookups.KSA"
    SelectMethod="GetKSAPaged" SelectCountMethod="KSATotalCount" EnablePaging="True"
    OldValuesParameterFormatString="original_{0}">
    <SelectParameters>
        <asp:Parameter Name="startRowIndex" Type="Int32" />
        <asp:Parameter Name="maximumRows" Type="Int32" />
        <asp:Parameter Name="active" Type="Boolean" ConvertEmptyStringToNull="true" />
    </SelectParameters>
</asp:ObjectDataSource>
<telerik:RadWindowManager ID="RadWindowManager1" runat="server" Skin="WebBlue">
    <Windows>
        <telerik:RadWindow runat="server">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>
