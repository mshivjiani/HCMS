<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="Duties.ascx.cs" Inherits="HCMS.PDExpress.Controls.CreatePD.Duties.Duties" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="pde" %>
<%@ Register Src="~/Controls/Search/ctrlSearchKSA.ascx" TagPrefix="uc1" TagName="ctrlSearchKSA" %>
<script type="text/javascript">
    String.prototype.left = function (n) {
        return this.substring(0, n);
    }

    // Initialize the character counter display
    maxChars = 1500;
    $(document).ready(function () {
        $("#charCntr").css({ color: 'black' });
        $("#charCntr").text("Character count: 0 (Count cannot exceed " + maxChars + ")");
    });

    function radEditorQualDescription_OnClientLoad(editor, args) {
        OnClientLoad(editor, args);
        editor.attachEventHandler("onkeyup", function (e) {
            // Do not call counter function on arrow keys pressed
            if (e.keyCode < 37 || e.keyCode > 40) ShowCharCount(editor, e);
        });
        editor.attachEventHandler("onfocusout", function (e) {
            ShowCharCount(editor, e);
        });
        editor.attachEventHandler("oncontextmenu", function (e) {
            ShowCharCount(editor, e);
        });
        editor.attachEventHandler("onmouseup", function (e) {
            ShowCharCount(editor, e);
        });
    }

    function OnClientLoad(editor, args) {
        editor.removeShortCut("InsertTab");
    }

    function ShowCharCount(editor, e) {
        var content = editor.get_text();
        var charCnt = content.length;
        if (charCnt < maxChars) {
            $("#charCntr").css({ color: 'black' });
        } else {
            editor.set_html(content.left(maxChars));
            charCnt = maxChars;
            $("#charCntr").css({ color: 'red' });
        }
        $("#charCntr").text("Character count: " + charCnt + " (Count cannot exceed " + maxChars + ")");
    }
 
</script>
<style type="text/css">
    .borderlessRadListBox li.rlbItem
    {
        list-style-position: inside;
        list-style-type: square !important;
    }
    .char-counter
    {
        font-weight: bold;
    }
</style>
<telerik:RadWindowManager ID="radWindowManagerDuties" runat="server" Behavior="Default"
    Skin="WebBlue" ReloadOnShow="false">
    <Windows>
        <telerik:RadWindow ID="rwPDDuties" runat="server" RegisterWithScriptManager="true"
            Skin="WebBlue" Height="600px" Width="800px" Behaviors="Close" VisibleStatusbar="false"
            Modal="true" ReloadOnShow="true" OnClientClose="OnPopupWindowClose">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>
<telerik:RadCodeBlock ID="rcbCodeBlock" runat="server">
    <script type="text/javascript">
        function ShowDutyQualPopup(dutyID) {
            var oWnd = $find("<%=rwDutyQualPopup.ClientID%>");
            oWnd.setUrl("../Controls/CreatePD/Duties/DutyQualificationPopup.aspx?DutyID=" + dutyID);
            oWnd.show();
        }
        function ShowDutyDefinition(jobSeriesID) {
            var oWnd = $find("<%=rwDutyDefinition.ClientID%>");
            oWnd.setUrl("../Controls/CreatePD/Duties/DutyDefinitionPopup.aspx?jobSeriesID=" + jobSeriesID);
            oWnd.show();
        }


        function OnPopupWindowClose(oWnd, eventArgs) {
            //using this instead of document.location.reload()
            // to avoid getting "resend" warning message
            document.location.href = document.location.href;

        }
     
    </script>
</telerik:RadCodeBlock>
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID ="rlpDefault">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rgDuty">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgDuty"  />
                <telerik:AjaxUpdatedControl ControlID="pnlQual"/>
                <telerik:AjaxUpdatedControl ControlID="pnlValidationMessage" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="rgQual">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgQual"/>
                <telerik:AjaxUpdatedControl ControlID="rgDuty"  />
                <telerik:AjaxUpdatedControl ControlID ="btnContinue" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID ="btnContinue">
        <UpdatedControls><telerik:AjaxUpdatedControl ControlID="pnlValidationMessage" /></UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<div runat="server">
    <asp:Panel ID="pnlValidationMessage" runat="server" Visible="false">
        <div style="width: 100%; background-color: #FFF3A8; border: solid 1px black; margin-bottom: 10px;">
            <div style="margin: 10px;">
                <div style="font-size: larger; font-weight: bolder;">
                    Validation Message</div>
                <br />
                <br />
                <ul style="color: Red;">
                    <li>
                        <asp:Label ID="lblValidationMessage" runat="server" Style="color: Red; font-weight: bolder;" />
                    </li>
                </ul>
            </div>
        </div>
    </asp:Panel>
    <div class="subTableHeader" style="width: 100%">
        Duties
        <pde:ToolTip ID="ToolTip13" runat="server" ToolTipID="13" />
    </div>
    <br />
    <telerik:RadAjaxLoadingPanel ID="rlpDefault" runat="server" Skin="Web20" />
    <span style="margin-right: 10px;">
        <asp:HyperLink ID="hlShowExistingPDs" runat="server" Text="Show Existing PDs" NavigateUrl=""
            Target="_blank" /></span> <span style="margin-right: 10px;">
                <asp:LinkButton ID="lbDutyDefinition" runat="server" Text="Duty Definition" /></span>
    <span>
        <asp:HyperLink ID="hlShowDutyDiffs" runat="server" Text="Show Duty Differences(Draft-Review)"
            Visible="false" NavigateUrl="" /></span>
    <br />
    <br />
    <telerik:RadGrid ID="rgDuty" runat="server" SkinID="customRADGridView" Width="100%"
        AllowPaging="true" PageSize="5" PagerStyle-AlwaysVisible="false" OnNeedDataSource="rgDuty_NeedDataSource"
        OnItemDataBound="rgDuty_ItemDataBound" OnItemCommand="rgDuty_ItemCommand" OnPreRender="rgDuty_PreRender">
        <PagerStyle AlwaysVisible="False" />
        <ClientSettings>
        </ClientSettings>
        <MasterTableView CommandItemDisplay="Top" CommandItemSettings-AddNewRecordText="Add New duty"
            DataKeyNames="DutyID, PositionDescriptionID" HierarchyLoadMode="ServerBind" EditMode="EditForms">
            <EditFormSettings CaptionFormatString="Add Duty" EditFormType="Template">
                <FormTemplate>
                    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetObjects"
                        TypeName="HCMS.Business.Lookups.QualificationDataSourceBusinessObject"></asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetObjects"
                        TypeName="HCMS.Business.Lookups.QualificationTypeDataSourceBusinessObject"></asp:ObjectDataSource>
                    <table class="blueTable" width="100%">
                        <tr>
                            <td colspan="2">
                                <asp:ValidationSummary ValidationGroup="KSAValGroup" ID="valSummary" runat="server"
                                    DisplayMode="BulletList" CssClass="validationMessageBox" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="literalSearchmsg" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left;">
                                <div style="width: 60px;">
                                    KSA:<span class="required">*</span>&nbsp;<pde:ToolTip ID="ToolTip1" runat="server"
                                        ToolTipID="91" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td id="tdKSASearch" runat="server" class="style1" colspan="2">
                                <telerik:RadComboBox ID="radcomboKSA" runat="server" CssClass="float-left" AutoPostBack="true"
                                    DataTextField="KSAText" DataValueField="KSAID" MarkFirstMatch="True" DropDownWidth="677px"
                                    Width="325px" OnSelectedIndexChanged="radcomboKSA_SelectedIndexChanged" CausesValidation="false">
                                </telerik:RadComboBox>
                                &nbsp;
                                <uc1:ctrlSearchKSA ID="SearchKSA" runat="server" />
                                <asp:RequiredFieldValidator ValidationGroup="KSAValGroup" runat="server" ID="radcomboKSAReqVal"
                                    ControlToValidate="radcomboKSA" Display="None" ErrorMessage="Select KSA First"
                                    InitialValue="<<--Select KSA-->>"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left;">
                                <div style="width: 100px;">
                                    Description: <span class="required">*</span>&nbsp;
                                    <pde:ToolTip ID="ToolTip58" runat="server" ToolTipID="58" />
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1" colspan="2">
                                <telerik:RadEditor ID="radEditorQualDescription" runat="server" SkinID="limitedTextRadEditor"
                                    OnClientLoad="radEditorQualDescription_OnClientLoad">
                                </telerik:RadEditor>
                                <span id="charCntr" class="char-counter" runat="server">Character count: 0</span>
                                <asp:RequiredFieldValidator ValidationGroup="KSAValGroup" ID="radEditorQualDescriptionReqVal"
                                    runat="server" ControlToValidate="radEditorQualDescription" Display="Dynamic"
                                    InitialValue="" ErrorMessage="KSA Description is required." />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left; vertical-align: middle">
                                <div style="width: 100px; float: left;">
                                    Qualification: &nbsp;
                                    <pde:ToolTip ID="ToolTip17" runat="server" ToolTipID="17" />
                                </div>
                                &nbsp;&nbsp;
                                <telerik:RadComboBox ID="radComboQualID" runat="server" DataSourceID="odsQualification"
                                    DataValueField="QualificationID" DataTextField="QualificationName" Width="200px">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: left; vertical-align: middle">
                                <div style="width: 128px; float: left;">
                                    Qualification Type: &nbsp;
                                    <pde:ToolTip ID="ToolTip59" runat="server" ToolTipID="59" />
                                </div>
                                &nbsp;&nbsp;
                                <telerik:RadComboBox ID="radcomboQualificationTypeID" runat="server" DataSourceID="odsQualificationType"
                                    Width="200px" DataValueField="QualificationTypeID" DataTextField="QualificationTypeName"
                                    OnItemDataBound="radcomboQualificationTypeID_ItemDataBound">
                                </telerik:RadComboBox>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table width="100%">
                        <tr align="right">
                            <td>
                                <asp:Label ID="lblmsg" runat="server" Font-Bold="true"></asp:Label>
                                <asp:Button ID="btnUpdate" Text="Save and Close" runat="server" OnClick="btnUpdate_Click"
                                    ValidationGroup="KSAValGroup"></asp:Button>&nbsp;
                                <asp:Button ID="btnCancel" Text="Close" runat="server" OnClick="btnCancel_Click"
                                    CausesValidation="False" ToolTip="Close"></asp:Button>
                            </td>
                        </tr>
                    </table>
                </FormTemplate>
            </EditFormSettings>
            <GroupByExpressions>
                <telerik:GridGroupByExpression>
                    <SelectFields>
                        <telerik:GridGroupByField FieldName="DutyType" />
                        <telerik:GridGroupByField Aggregate="Sum" FieldName="PercentageOfTime"></telerik:GridGroupByField>
                    </SelectFields>
                    <GroupByFields>
                        <telerik:GridGroupByField FieldName="DutyType" FieldAlias="DutyType" />
                    </GroupByFields>
                </telerik:GridGroupByExpression>
            </GroupByExpressions>
            <RowIndicatorColumn>
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn>
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
            <Columns>
                <%--                  <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandColumn"  InsertText="Add" UpdateText ="Save Duty" >              
                    <ItemStyle VerticalAlign="Top" Width="10" />
                </telerik:GridEditCommandColumn>--%>
                <telerik:GridTemplateColumn>
                    <ItemStyle VerticalAlign="Top" Width="10" />
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButtonEdit" runat="server" ToolTip="Edit" CommandName="Edit"
                            SkinID="editButton" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:ImageButton ID="ImageButtonUpdate" runat="server" ToolTip='<%# (Container is GridDataInsertItem) ? "Add Duty" : "Save Duty" %>'
                            SkinID="updateButton" CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>' />
                        <asp:LinkButton ID="LinkButtonUpdate" runat="server" Text='<%# (Container is GridDataInsertItem) ? "Add Duty" : "Save Duty" %>'
                            CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>'>>Save Duty</asp:LinkButton>
                        <asp:ImageButton ID="ImageButtonCancel" runat="server" ToolTip="Cancel" CommandName="Cancel" />
                        <asp:LinkButton ID="LinkButtonCancel" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridButtonColumn ConfirmText="Delete this duty?" ConfirmDialogType="RadWindow"
                    ConfirmTitle="Delete" ButtonType="ImageButton" CommandName="Delete" Text="Delete"
                    UniqueName="DeleteCommandColumn">
                    <ItemStyle VerticalAlign="Top" Width="10" />
                </telerik:GridButtonColumn>
                <telerik:GridTemplateColumn>
                    <ItemStyle VerticalAlign="Top" Width="10" />
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButtonView" runat="server" ToolTip="View" CommandName="View"
                            SkinID="viewButton" /></ItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Duty" DataField="DutyDescription" UniqueName="DutyDescription">
                    <ItemStyle VerticalAlign="Top" Wrap="true" />
                    <ItemTemplate>
                        <asp:Label ID="lblDutyDescription" runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <span><span style="vertical-align: top;">
                            <asp:TextBox ID="tbDutyDescription" runat="server" CssClass="TelerikTextFont" TextMode="MultiLine"
                                Rows="10" Width="210px"></asp:TextBox>
                        </span><span style="vertical-align: top;">&nbsp; <span class="required">*</span> </span>
                            <asp:CustomValidator ID="tbDutyDescriptionCustVal" runat="server" ControlToValidate="tbDutyDescription"
                                Display="None" ValidateEmptyText="true" ErrorMessage="Duty Description is required."
                                OnServerValidate="tbDutyDescriptionCustVal_ServerValidate" />
                            <span style="vertical-align: top;">&nbsp;
                                <pde:ToolTip ID="ToolTip13" runat="server" ToolTipID="13" />
                            </span></span>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Duty Type" DataField="DutyTypeName" UniqueName="DutyTypeName">
                    <ItemStyle VerticalAlign="Top" Wrap="false" Width="50px" />
                    <ItemTemplate>
                        <asp:Label ID="lblDutyTypeName" runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <span><span style="vertical-align: top;">
                            <telerik:RadComboBox ID="rcbDutyTypeName" runat="server" DataSourceID="odsDutyType"
                                DataValueField="DutyTypeID" DataTextField="DutyTypeName" Width="80px" />
                        </span><span style="vertical-align: top;">&nbsp; </span><span style="vertical-align: top;">
                            <pde:ToolTip ID="ToolTip16" runat="server" ToolTipID="16" />
                        </span></span>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="% of Time" DataField="PercentageOfTime" UniqueName="PercentageOfTime">
                    <ItemStyle VerticalAlign="Top" Wrap="true" Width="40px" />
                    <ItemTemplate>
                        <asp:Label ID="lblPercentageOfTime" runat="server"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <span><span style="vertical-align: top;">
                            <telerik:RadComboBox ID="rcbPercentageOfTime" runat="server" DataSourceID="xmldsPercentageOfTime"
                                DataValueField="p" DataTextField="p" Width="35px" />
                        </span><span style="vertical-align: top;">&nbsp; </span><span style="vertical-align: top;">
                            <pde:ToolTip ID="ToolTip14" runat="server" ToolTipID="14" />
                        </span></span>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Qualifications">
                    <ItemStyle VerticalAlign="Top" Width="1px" />
                    <ItemTemplate>
                        <telerik:RadListBox ID="radListDutyQual" runat="server" DataTextField="QualificationName"
                            CssClass="borderlessRadListBox" DataValueField="QualificationName">
                        </telerik:RadListBox>
                        <asp:Button ID="btnAddEditDutyQualification" runat="server" CssClass="formBtn" Text="Add/Edit Qualifications"
                            Visible="false" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <span style="visibility: hidden;">
                            <asp:Button ID="btnAddEditDutyQualification" runat="server" CssClass="formBtn" Text="Add/Edit Qualifications"
                                Enabled="false" />
                        </span>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
    <asp:Panel ID="pnlQual" runat="server" Visible="false" Width="100%">
        <br />
        <div class="subTableHeader">
            Conditions of Employment &nbsp;
            <pde:ToolTip ID="ToolTip99" runat="server" ToolTipID="99" />
        </div>
        <br />
        <telerik:RadGrid ID="rgQual" runat="server" SkinID="customRADGridView" Width="100%"
            AllowPaging="true" PageSize="5" PagerStyle-AlwaysVisible="false" OnNeedDataSource="rgQual_NeedDataSource"
            OnItemDataBound="rgQual_ItemDataBound" OnItemCommand="rgQual_ItemCommand" OnPreRender="rgQual_PreRender">
            <PagerStyle AlwaysVisible="false" />
            <MasterTableView Width="100%" CommandItemDisplay="Top" HierarchyLoadMode="ServerBind" EnableNoRecordsTemplate="false" 
                CommandItemSettings-AddNewRecordText="Add New" EditMode="EditForms" DataKeyNames="CompetencyKSAID, PositionDescriptionID">
                <RowIndicatorColumn>
                    <HeaderStyle Width="20px"></HeaderStyle>
                </RowIndicatorColumn>
                <ExpandCollapseColumn>
                    <HeaderStyle Width="20px"></HeaderStyle>
                </ExpandCollapseColumn>
                <EditFormSettings CaptionFormatString="Add New" EditFormType="Template">
                    <FormTemplate>
                        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetObjects"
                            TypeName="HCMS.Business.Lookups.QualificationDataSourceBusinessObject"></asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetObjects"
                            TypeName="HCMS.Business.Lookups.QualificationTypeDataSourceBusinessObject"></asp:ObjectDataSource>
                        <table class="blueTable" width="100%">
                            <tr>
                                <td colspan="2">
                                    <asp:ValidationSummary ValidationGroup="KSAValGroup" ID="valSummary" runat="server"
                                        DisplayMode="BulletList" CssClass="validationMessageBox" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Label ID="literalSearchmsg" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <%--<tr>
                                <td colspan="2" style="text-align: left;">
                                    <div style="width: 60px;">
                                        KSA:<span class="required">*</span>&nbsp;<pde:ToolTip ID="ToolTip1" runat="server"
                                            ToolTipID="91" />
                                    </div>
                                </td>
                            </tr>--%>
                           <%-- <tr>
                                <td id="tdKSASearch" runat="server" class="style1" colspan="2">
                                    <telerik:RadComboBox ID="radcomboKSA" runat="server" CssClass="float-left" AutoPostBack="true"
                                        DataTextField="KSAText" DataValueField="KSAID" MarkFirstMatch="True" ExpandDirection="Down"
                                        DropDownWidth="677px" Width="325px" OnSelectedIndexChanged="radcomboKSA_SelectedIndexChanged"
                                        CausesValidation="false">
                                    </telerik:RadComboBox>
                                    &nbsp;
                                    <uc1:ctrlSearchKSA ID="SearchKSA" runat="server" />
                                    <asp:RequiredFieldValidator ValidationGroup="KSAValGroup" runat="server" ID="radcomboKSAReqVal"
                                        ControlToValidate="radcomboKSA" Display="None" ErrorMessage="Select KSA First"
                                        InitialValue="<<--Select KSA First-->>"></asp:RequiredFieldValidator>
                                </td>
                            </tr>--%>
                            <tr>
                                <td colspan="2" style="text-align: left;">
                                    <div style="width: 100px;">
                                        Description: <span class="required">*</span>&nbsp;
                                        <pde:ToolTip ID="ToolTip58" runat="server" ToolTipID="58" />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="style1" colspan="2">
                                    <telerik:RadEditor ID="radEditorQualDescription" runat="server" SkinID="limitedTextRadEditor"
                                        OnClientLoad="OnClientLoad">
                                    </telerik:RadEditor>
                                    <span id="charCntr" style="font-weight: bold"></span>
                                    <asp:RequiredFieldValidator ValidationGroup="KSAValGroup" ID="radEditorQualDescriptionReqVal"
                                        runat="server" ControlToValidate="radEditorQualDescription" Display="Dynamic"
                                        InitialValue="" ErrorMessage="KSA Description is required." />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: left; vertical-align: middle">
                                    <div style="width: 100px; float: left;">
                                        Qualification: &nbsp;
                                        <pde:ToolTip ID="ToolTip17" runat="server" ToolTipID="17" />
                                    </div>
                                    &nbsp;&nbsp;
                                    <telerik:RadComboBox ID="radComboQualID" runat="server" DataSourceID="odsQualification"
                                        DataValueField="QualificationID" DataTextField="QualificationName" Width="200px">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>
                            <%--  <tr>
                                <td colspan="2" style="text-align: left; vertical-align: middle">
                                    <div style="width: 128px; float: left;">
                                        Qualification Type: &nbsp;
                                        <pde:ToolTip ID="ToolTip59" runat="server" ToolTipID="59" />
                                    </div>
                                    &nbsp;&nbsp;
                                    <telerik:RadComboBox ID="radcomboQualificationTypeID" runat="server" DataSourceID="odsQualificationType"
                                        Width="200px" DataValueField="QualificationTypeID" DataTextField="QualificationTypeName"
                                        OnItemDataBound="radcomboQualificationTypeID_ItemDataBound">
                                    </telerik:RadComboBox>
                                </td>
                            </tr>--%>
                        </table>
                        <br />
                        <table width="100%">
                            <tr align="right">
                                <td>
                                    <asp:Label ID="lblmsg" runat="server" Font-Bold="true"></asp:Label>
                                    <asp:Button ID="btnUpdate" Text="Save and Close" runat="server" ValidationGroup="KSAValGroup">
                                    </asp:Button>&nbsp;
                                    <asp:Button ID="btnCancel" Text="Close" runat="server" OnClick="btnCancel_Click"
                                        CausesValidation="False"></asp:Button>
                                </td>
                            </tr>
                        </table>
                    </FormTemplate>
                </EditFormSettings>
                <Columns>
                    <%--                <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandColumn">
                    <ItemStyle VerticalAlign="Top" Width="10" />
                </telerik:GridEditCommandColumn>--%>
                    <telerik:GridTemplateColumn>
                        <ItemStyle VerticalAlign="Top" Width="10" />
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButtonEdit" runat="server" ToolTip="Edit" CommandName="Edit"
                                SkinID="editButton" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImageButtonUpdate" runat="server" ToolTip='<%# (Container is GridDataInsertItem) ? "Add Qualification" : "Save Qualification" %>'
                                SkinID="updateButton" CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>' />
                            <asp:LinkButton ID="LinkButtonUpdate" runat="server" Text='<%# (Container is GridDataInsertItem) ? "Add Qualification" : "Save Qualification" %>'
                                CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>'>>Save Qualification</asp:LinkButton>
                            <asp:ImageButton ID="ImageButtonCancel" runat="server" ToolTip="Cancel" SkinID="cancelButton"
                                CommandName="Cancel" />
                            <asp:LinkButton ID="LinkButtonCancel" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                        </EditItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridButtonColumn ConfirmText="Delete this KSA?" ConfirmDialogType="RadWindow"
                        ConfirmTitle="Delete" ButtonType="ImageButton" CommandName="Delete" Text="Delete"
                        UniqueName="DeleteCommandColumn">
                        <ItemStyle VerticalAlign="Top" Width="10" />
                    </telerik:GridButtonColumn>
                    <telerik:GridTemplateColumn HeaderText="Qualification" DataField="QualificationName"
                        UniqueName="QualificationName">
                        <ItemStyle VerticalAlign="Top" Wrap="false" />
                        <ItemTemplate>
                            <asp:Label ID="lblQualificationName" runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <span><span style="vertical-align: top;">
                                <telerik:RadComboBox ID="rcbQualificationName" runat="server" DataSourceID="odsQualification"
                                    DataValueField="QualificationID" DataTextField="QualificationName" Width="150px"
                                    DropDownWidth="300px" />
                            </span><span style="vertical-align: top;">&nbsp; </span><span style="vertical-align: top;">
                                <pde:ToolTip ID="ToolTip17" runat="server" ToolTipID="17" />
                            </span></span>
                        </EditItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Description" DataField="QualificationDescription"
                        UniqueName="QualificationDescription">
                        <ItemStyle VerticalAlign="Top" Wrap="true" />
                        <ItemTemplate>
                            <asp:Label ID="lblQualificationDescription" runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <span><span style="vertical-align: top;">
                                <asp:TextBox ID="tbQualificationDescription" runat="server" CssClass="TelerikTextFont"
                                    TextMode="MultiLine" Rows="10" Width="250px"></asp:TextBox>
                            </span><span style="vertical-align: top;">&nbsp; <span class="required">*</span> </span>
                                <asp:CustomValidator ID="tbQualificationDescriptionCustVal" runat="server" ControlToValidate="tbQualificationDescription"
                                    Display="None" ValidateEmptyText="true" ErrorMessage="KSA Description is required."
                                    OnServerValidate="tbQualificationDescriptionCustVal_ServerValidate" />
                                <span style="vertical-align: top;">&nbsp;
                                    <pde:ToolTip ID="ToolTip58" runat="server" ToolTipID="58" />
                                </span></span>
                        </EditItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Qualification Type" DataField="QualificationTypeName"
                        UniqueName="QualificationTypeName">
                        <ItemStyle VerticalAlign="Top" Wrap="false" />
                        <ItemTemplate>
                            <asp:Label ID="lblQualificationTypeName" runat="server"></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <span><span style="vertical-align: top;">
                                <telerik:RadComboBox ID="rcbQualificationTypeName" runat="server" DataSourceID="odsQualificationType"
                                    DataValueField="QualificationTypeID" DataTextField="QualificationTypeName" Width="150px"
                                    DropDownWidth="150px" />
                            </span><span style="vertical-align: top;">&nbsp; </span><span style="vertical-align: top;">
                                <pde:ToolTip ID="ToolTip59" runat="server" ToolTipID="59" />
                            </span></span>
                        </EditItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </asp:Panel>
    <asp:Panel ID="pnlOverallKSAs" runat="server" Visible="false" Width="100%">
        <br />
        <div class="subTableHeader">
            Overall KSA &nbsp;
            <pde:ToolTip ID="ToolTip2" runat="server" ToolTipID="18" />
        </div>
        <br />
        <telerik:RadGrid ID="rgOverAllKSAs" runat="server" SkinID="customRADGridView" Width="100%"
            AllowPaging="true" PageSize="5" PagerStyle-AlwaysVisible="false" OnNeedDataSource="rgOverAllKSAs_NeedDataSource">
            <PagerStyle AlwaysVisible="false" />
            <MasterTableView Width="100%" DataKeyNames="CompetencyKSAID, PositionDescriptionID">
                <RowIndicatorColumn>
                    <HeaderStyle Width="20px"></HeaderStyle>
                </RowIndicatorColumn>
                <ExpandCollapseColumn>
                    <HeaderStyle Width="20px"></HeaderStyle>
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridTemplateColumn HeaderText="Qualification" DataField="QualificationName"
                        UniqueName="QualificationName">
                        <ItemStyle VerticalAlign="Top" Wrap="false" />
                        <ItemTemplate>
                            <asp:Label ID="lblQualificationName" runat="server" Text='<%# Eval("QualificationName")%>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Description" DataField="QualificationDescription"
                        UniqueName="QualificationDescription">
                        <ItemStyle VerticalAlign="Top" Wrap="true" />
                        <ItemTemplate>
                            <asp:Label ID="lblQualificationDescription" runat="server" Text='<%# Eval("CompetencyKSA")%>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Qualification Type" DataField="QualificationTypeName"
                        UniqueName="QualificationTypeName">
                        <ItemStyle VerticalAlign="Top" Wrap="false" />
                        <ItemTemplate>
                            <asp:Label ID="lblQualificationTypeName" runat="server" Text='<%# Eval("QualificationTypeName")%>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </asp:Panel>
    <span class="spanAction">
        <asp:Button ID="btnContinue" runat="server" CssClass="formBtn" Text="Save and Continue"
            ToolTip="Save and Continue" />
    </span>
</div>
<telerik:RadWindow ID="rwDutyQualPopup" runat="server" ReloadOnShow="true" Skin="WebBlue"
    Modal="true" Width="800px" Height="532px" Style="display: none;" VisibleOnPageLoad="false"
    Behaviors="Close" InitialBehaviors="None" VisibleStatusbar="False">
</telerik:RadWindow>
<telerik:RadWindow ID="rwDutyDefinition" runat="server" ReloadOnShow="true" Skin="WebBlue"
    Modal="true" Width="600px" Height="300px" Style="display: none;" VisibleOnPageLoad="false"
    Behaviors="Close" InitialBehaviors="None" VisibleStatusbar="False">
</telerik:RadWindow>
<asp:XmlDataSource ID="xmldsPercentageOfTime" runat="server" DataFile="~/App_Data/DutyPercentage.xml"
    XPath="Percentages/percentage"></asp:XmlDataSource>
<asp:ObjectDataSource ID="odsDutyType" runat="server" SelectMethod="GetObjects" TypeName="HCMS.Business.Lookups.DutyTypeDataSourceBusinessObject">
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsQualification" runat="server" SelectMethod="GetObjects"
    TypeName="HCMS.Business.Lookups.QualificationDataSourceBusinessObject"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsQualificationType" runat="server" SelectMethod="GetObjects"
    TypeName="HCMS.Business.Lookups.QualificationTypeDataSourceBusinessObject"></asp:ObjectDataSource>
<asp:HiddenField ID="hfRGDutyEnabled" runat="server" Value="true" />
<asp:HiddenField ID="hrRGQualEnabled" runat="server" Value="true" />
