<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ctrlJAFinalKSA.ascx.cs"
    Inherits="HCMS.JNP.Controls.JA.ctrlJAFinalKSA" %>
<%@ Register Src="../Workflow/ctrlWorkflowActionManager.ascx" TagName="ctrlWorkflowActionManager"
    TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="tooltip" %>
<%@ Register Src="~/Controls/JA/ctrlDutyDescription.ascx" TagName="DutyDescription"
    TagPrefix="uc1" %>

    <asp:CustomValidator ID="customValOneFinalKSA" runat="server" OnServerValidate="customValOneFinalKSA_ServerValidate"
    Text="" Display="None" ValidationGroup="internalValidation"></asp:CustomValidator>

      <asp:CustomValidator ID="customValMaxFinalKSA" runat="server" OnServerValidate="customValMaxFinalKSA_ServerValidate"
    Text="" Display="None" ValidationGroup="internalValidation"></asp:CustomValidator>
<telerik:RadCodeBlock ID="rcbCodeBlock" runat="server">
    <script type="text/javascript">
        function GetKSACheckedCount() {
            fixFocus();
            alert("You have reached the maximum number of finalized Duty KSA's. You cannot set this line item as a final KSA.");
            return;
        }

        function fixFocus() {
            if ($telerik.isIE) {
                var focusedElement = document.activeElement;
                if (focusedElement && focusedElement.tagName.toLowerCase() != "body") focusedElement.blur();
            }
        }

        function OnClientResponseError(sender, args) {
            args.set_cancelErrorAlert(true);
        } 

 
    </script>
</telerik:RadCodeBlock>
<telerik:RadAjaxManager ID="mainAJAXManager" runat="server" UpdatePanelsRenderMode="Inline">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="buttonSaveAndContinue">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="panelMain" LoadingPanelID="ajaxLoadingPanelSave" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="gridDutyKSA">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="panelMain" LoadingPanelID="ajaxLoadingPanelSave" />
                <telerik:AjaxUpdatedControl ControlID="dropdownImportance" />
                <telerik:AjaxUpdatedControl ControlID="dropdownNeedAtEntry" />
                <telerik:AjaxUpdatedControl ControlID="dropdownDistinguishingValue" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<telerik:RadAjaxLoadingPanel ID="ajaxLoadingPanelSave" SkinID="JNP" runat="server"
    Transparency="0" IsSticky="true" Width="100%" Height="40px" />
<%--<telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" SkinID="JNP" runat="server"
    Transparency="0" IsSticky="true" Width="100%" Height="40px" />--%>
<br />
<asp:Panel ID="panelMain" runat="server">
    <div>
        <asp:Label ID="lblConditionOfEmpHeader" CssClass="lblHeader" runat="server" Text="Conditions of Employment"></asp:Label>
    </div>
    <%--//Issue Id: 14
    //Author: Deepali Anuje
    //Date Fixed: 1/24/2012
    //Description: Conditions of employment should show up at the bottom of final 
    ksa screen and should not be assessed.  --%>
    <telerik:RadGrid ID="gridDutyKSAEmploymentConditions" runat="server" CellSpacing="0"
        GridLines="None" AutoGenerateColumns="False" OnNeedDataSource="gridDutyKSAEmploymentConditions_NeedDataSource"
        OnItemDataBound="gridDutyKSAEmploymentConditions_ItemDataBound">
        <MasterTableView>
            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridTemplateColumn HeaderText="KSA Description" DataField="JQFactorTitle"
                    UniqueName="JQFactorTitle">
                    <ItemTemplate>
                        <asp:Label ID="lblJAKSADescription" runat="server" Text='<%# Eval("JQFactorTitle")%>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Qualification Type" DataField="QualificationTypeName"
                    UniqueName="QualificationTypeName">
                    <ItemTemplate>
                        <asp:Label ID="lblQualificationTypeName" runat="server" Text='<%# Eval("QualificationTypeName")%>'></asp:Label>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
        <FilterMenu EnableImageSprites="False">
        </FilterMenu>
    </telerik:RadGrid>
    <br />
    <asp:ValidationSummary ID="valSummary" runat="server" CssClass="validationMessageBox"
        ShowSummary="true" HeaderText="<span class='systemMessage'>Validation Message</span><br>"
        DisplayMode="BulletList" ValidationGroup="internalValidation" />
    <br />
     <div>
        <asp:Label ID="lblKSA" CssClass="lblHeader" runat="server" Text="KSAs"></asp:Label>
    </div>
    <div class="instruction">
        <asp:Literal ID="litMinFinalKSA" Text="Use the “Is Final” checkbox (at the far right of this screen) to select at least one KSA as final and no more than 8.<br />" runat="server"></asp:Literal>
          
        <asp:Literal ID="litNoScalesSelected" Text="Select the 3 Scale dropdown options before checking the 'Is final' checkbox.<br />" runat="server" Visible="false"></asp:Literal>     
    </div>
    <asp:HyperLink ID="hlKSAScaleExample" runat="server" NavigateUrl="~/Common/KSAScaleTable.pdf"
        Target="_blank">KSA Scale</asp:HyperLink>
    <br />
    <br />
    <telerik:RadGrid ID="gridDutyKSA" runat="server" CellSpacing="0" GridLines="None"
        AutoGenerateColumns="false" ValidationSettings-EnableValidation="true" ValidationSettings-ValidationGroup="internalValidation">
        <HeaderStyle HorizontalAlign="Center" />
        <ItemStyle HorizontalAlign="Center" />
        <EditItemStyle HorizontalAlign="Center" />
        <AlternatingItemStyle HorizontalAlign="Center" />
        <SortingSettings SortedBackColor="Azure" EnableSkinSortStyles="false" />
        <MasterTableView DataKeyNames="JQFactorID,JADutyID" AllowSorting="true" AllowNaturalSort="false"
            EditMode="EditForms" EditFormSettings-EditFormType="AutoGenerated">
            <NoRecordsTemplate>
                <div>
                    There are no Duty KSAs to finalize.</div>
            </NoRecordsTemplate>
            <Columns>
                <telerik:GridTemplateColumn HeaderText="KSA Description" ReadOnly="true">
                    <ItemTemplate>
                        <asp:Literal ID="literalKSADescription" runat="server" />
                    </ItemTemplate>
                    <ItemStyle Width="350px" />
                </telerik:GridTemplateColumn>
                <telerik:GridBoundColumn DataField="QualificationTypeID" UniqueName ="QualificationTypeID" Visible="false"></telerik:GridBoundColumn>
                <telerik:GridTemplateColumn HeaderText="Qualification Type" ReadOnly="true">
                    <ItemTemplate>
                        <asp:Literal ID="literalQualificationTypeName" runat="server" />
                    </ItemTemplate>
                    <ItemStyle Width="350px" />
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Duty Number" SortExpression="" HeaderStyle-Width="50px">
                    <ItemTemplate>
                        <asp:TextBox ID="txtDutyNumber" CssClass="TelerikTextFont" runat="server" BackColor="Transparent"
                            BorderStyle="None" Width="50px" ReadOnly="true"></asp:TextBox>
                    </ItemTemplate>
                    <EditItemTemplate>
                        --
                    </EditItemTemplate>
                    <ItemStyle Width="50px" />
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Scale">
                    <ItemTemplate>
                        <asp:Table ID="tblSupApprovals" runat="server" CssClass="whiteTable" Width="100%">
                            <asp:TableRow>
                                <asp:TableCell>
                                    Importance:
                                </asp:TableCell>
                                <asp:TableCell CssClass="dropdownTD">
                                    <telerik:RadComboBox ID="dropdownImportance" Width="250px" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="dropdownImportance_SelectedIndexChanged" />
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    Need At Entry:
                                </asp:TableCell>
                                <asp:TableCell CssClass="dropdownTD">
                                    <telerik:RadComboBox ID="dropdownNeedAtEntry" Width="250px" runat="server" AutoPostBack="true"
                                        OnSelectedIndexChanged="dropdownNeedAtEntry_SelectedIndexChanged" />
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    Distinguishing Value:
                                </asp:TableCell>
                                <asp:TableCell CssClass="dropdownTD">
                                    <telerik:RadComboBox ID="dropdownDistinguishingValue" Width="250px" runat="server"
                                        AutoPostBack="true" OnSelectedIndexChanged="dropdownDistinguishingValue_SelectedIndexChanged" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Score" ReadOnly="true" SortExpression="TotalScore">
                    <ItemTemplate>
                        <asp:Literal ID="literalTotalScore" runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        --
                    </EditItemTemplate>
                    <ItemStyle Width="50px" />
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Is Final" SortExpression="IsFinalKSA">
                    <ItemTemplate>
                        <asp:CheckBox ID="checkboxIsFinalKSA1" runat="server" AutoPostBack="true" OnCheckedChanged="checkboxIsFinalKSA1_CheckedChange" />
                    </ItemTemplate>
                    <ItemStyle Width="80px" />
                </telerik:GridTemplateColumn>
            </Columns>
            <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                </EditColumn>
            </EditFormSettings>
        </MasterTableView>
        <FilterMenu EnableImageSprites="False">
        </FilterMenu>
    </telerik:RadGrid>
    <br />
     <asp:ValidationSummary ID="valSummaryBottom" runat="server" CssClass="validationMessageBox"
        ShowSummary="true" HeaderText="<span class='systemMessage'>Validation Message</span><br>"
        DisplayMode="BulletList" ValidationGroup="internalValidation" />
    <br />
    <span style="clear: both"></span><span id="spanContinue" runat="server" class="spanAction">
        <asp:Button ID="btnContinue" runat="server" Text="Continue" ToolTip="Continue" OnClick="btnContinue_Click" ValidationGroup="internalValidation" />
    </span>
   
</asp:Panel>
<telerik:RadToolTipManager runat="server" AnimationDuration="300" EnableEmbeddedSkins="false"
    MouseTrailing="true" HideEvent="LeaveTargetAndToolTip" AutoCloseDelay="6000"
    ShowCallout="true" ManualClose="false" ID="RadToolTipManager1" Width="550" Height="250"
    RelativeTo="Element" Animation="Slide" Position="MiddleRight" OnAjaxUpdate="OnAjaxUpdate"
    AutoTooltipify="true" RenderInPageRoot="true">
</telerik:RadToolTipManager>
