<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlAddEditQualification.ascx.cs"
    Inherits="HCMS.JNP.Controls.JQ.ctrlAddEditQualification" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="tooltip" %>
<%@ Register Src="~/Controls/CR/ctrlMinimumQualifications.ascx" TagName="ctrlMinimumQualifications"
    TagPrefix="minimumQualifications" %>
<telerik:RadCodeBlock ID="radcodeblockEdiQualification" runat="server">
    <script type="text/javascript">


        function OnClientLoad(editor, args) {
            editor.removeShortCut("InsertTab");

        }

        function ShowQuestionWindowClient(mode, id) {
            var navigateurl;
            var title;

            if (mode == "Insert") {
                navigateurl = "../JQ/AddEditQuestion.aspx?mode=Insert&JQFactorID=" + id;
                title = "Add Qualification Statement";
            }
            else if (mode == "Edit") {
                navigateurl = "../JQ/AddEditQuestion.aspx?mode=Edit&JQFactorItemID=" + id;
                title = "Edit Qualification Statement";
            }
            else {
                navigateurl = "../JQ/AddEditQuestion.aspx?mode=View&JQFactorItemID=" + id;
                title = "View Qualification Statement";
            }
            var omanager = GetRadWindowManager();
            var ownd = omanager.getWindowByName('rwQ');
            ownd.setUrl(navigateurl);
            ownd.set_title(title);
            ownd.show();
        }

        function ShowMinimumQualificationsPopUp(SeriesId, TypeOfWorkID, GradeId, mode) {
            var omanager = GetRadWindowManager();
            var oWnd = $find("<%=rwMinimumQualifications.ClientID%>");
            if (mode == "Insert") {
                navigateurl = ("../CR/MinimumQualifications.aspx?Mode=Insert&SeriesId=" + SeriesId + "&TypeOfWorkID=" + TypeOfWorkID + "&GradeId=" + GradeId);
            }
            else if (mode == "Edit") {
                navigateurl = ("../CR/MinimumQualifications.aspx?Mode=Edit&SeriesId=" + SeriesId + "&TypeOfWorkID=" + TypeOfWorkID + "&GradeId=" + GradeId);
            }
            else {
                navigateurl = ("../CR/MinimumQualifications.aspx?Mode=View&SeriesId=" + SeriesId + "&TypeOfWorkID=" + TypeOfWorkID + "&GradeId=" + GradeId);
            }

            oWnd.set_title("Minimum Qualifications");
            oWnd.setUrl(navigateurl);
            oWnd.show();
        }

        function OnPopupMinQualWindowClose(oWnd, eventArgs) {
            var oWindow = GetRadWindow();
            if (oWindow != null)
                oWindow.close();
        }

        function OnPopupWindowClose(oWnd, eventArgs) {
            //using this instead of document.location.reload()
            // to avoid getting "resend" warning message
            if (eventArgs.get_argument() != null) {
                var arr = eventArgs.get_argument().split('|');
                var mode = arr[0];
                var id = arr[1];
                document.location.href = document.location.href;
            }
            else {
                document.location.href = document.location.href;
            }
            $get("<%=btnRefresh.ClientID%>").click();

        }

        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.radWindow;
            return oWindow;
        }

        function HoldValue() {

            var Inst;
            var editor = $find("<%=RadEditQualificationInstruction.ClientID%>");

            if (editor != null) {
                Inst = (editor.get_text());
                document.getElementById('<%=hdquains.ClientID %>').value = Inst;
            }

        }

        function EnableDisableButton(flag) {
            var butSave;
            var butIns;
            if (flag == 1) {
                butSave = document.getElementById('<%=btnSave.ClientID %>')
                butSave.disabled = true;

                butIns = document.getElementById('<%=btnShowQUalInst.ClientID %>')
                butIns.disabled = true;

                //alert(but.disabled);
                return false;
            }
            if (flag == 2) {
                butSave = document.getElementById('<%=btnSave.ClientID %>')
                //alert(but.disabled);
                butSave.disabled = false;

                butIns = document.getElementById('<%=btnShowQUalInst.ClientID %>')
                butIns.disabled = false;

                return false;
            }
        }

    </script>
</telerik:RadCodeBlock>
<telerik:RadWindowManager ID="RWM" runat="server" Skin="WebBlue">
    <Windows>
        <telerik:RadWindow ID="rwQ" runat="server" RegisterWithScriptManager="true" Skin="WebBlue"
            Height="600px" Width="990px" Behaviors="None" VisibleStatusbar="false" Modal="true"
            OnClientClose="OnPopupWindowClose">
        </telerik:RadWindow>
        <telerik:RadWindow ID="rwMinimumQualifications" runat="server" RegisterWithScriptManager="true"
            Skin="WebBlue" Height="260px" Width="560px" Behaviors="Close" VisibleStatusbar="false"
            Modal="true" ReloadOnShow="true" OnClientClose="OnPopupMinQualWindowClose">
        </telerik:RadWindow>
        <telerik:RadWindow ID="radwindowPopup" runat="server" VisibleOnPageLoad="false" Height="150px"
            Width="300px" Modal="true" BackColor="#DADADA" VisibleStatusbar="false" Behaviors="Close"
            Title="Unsaved changes pending">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>
<telerik:RadAjaxLoadingPanel ID="ajaxLoadingPanelSave" runat="server" />
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="ajaxLoadingPanelSave">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rcbFactorTypes">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="tblQualification" />
                <telerik:AjaxUpdatedControl ControlID="pnlQuestions" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnSave">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="tblQualification" />
                <telerik:AjaxUpdatedControl ControlID="pnlQuestions" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnShowQUalInst">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="tblQualification" />
                <telerik:AjaxUpdatedControl ControlID="pnlQuestions" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnRefresh">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="tblQualification" />
                <telerik:AjaxUpdatedControl ControlID="pnlQuestions" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="rcbRatingScaleType">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="gridQuestions" />
                <telerik:AjaxUpdatedControl ControlID="lblmsgQS" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="gridQuestions">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="gridQuestions" />
                <telerik:AjaxUpdatedControl ControlID="tblQuestion" />
                <telerik:AjaxUpdatedControl ControlID="btnCancel" />
                <telerik:AjaxUpdatedControl ControlID="btnSave" />
                <telerik:AjaxUpdatedControl ControlID="gridResponses" />
                <telerik:AjaxUpdatedControl ControlID="tblQualification" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="gridResponses">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="gridResponses" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<asp:ValidationSummary ID="valSummary" runat="server" ValidationGroup="TitleValidationGroup"
    DisplayMode="BulletList" CssClass="validationMessageBox" />
<table width="100%" class="blueTable" id="tblQualification" runat="server">
    <tr id="rcbFactorType_row" runat="server">
        <td class="toolTipleft">
            <asp:Label ID="Label2" runat="server" AssociatedControlID="rcbFactorTypes" Text="Qualification Type"
                ToolTip="Qualification Type"></asp:Label>&nbsp; <span class="required">*</span>&nbsp;
            <tooltip:ToolTip ID="ToolTip1" runat="server" ToolTipID="177" />
        </td>
        <td align="left">
            <telerik:RadComboBox ID="rcbFactorTypes" runat="server" AutoPostBack="true" NoWrap="false"
                CausesValidation="false" DropDownWidth="677px" Width="215px" OnSelectedIndexChanged="rcbFactorTypes_SelectedIndexChanged">
            </telerik:RadComboBox>
            <asp:RequiredFieldValidator ID="requiredFactorType" runat="server" ControlToValidate="rcbFactorTypes"
                Display="None" ErrorMessage="Qualification Type is required." InitialValue="[-- Select Qualification Type --]"
                ValidationGroup="TitleValidationGroup" />
        </td>
        <td align="right">
            <asp:HyperLink ID="hlMinimumQualifications" runat="server" NavigateUrl="" Target="_blank"
                Visible="false">
            Minimum Qualifications
            </asp:HyperLink>&nbsp&nbsp;
            <tooltip:ToolTip ID="ToolTipMinQual" runat="server" ToolTipID="112" Visible="false" />
        </td>
    </tr>
    <tr>
        <td class="toolTipleft">
            <asp:Label ID="Label1" runat="server" AssociatedControlID="txtTitle" Text="Qualification"
                ToolTip="Qualification Title"></asp:Label>&nbsp; <span class="required">*</span>&nbsp;
            <tooltip:ToolTip ID="ToolTip2" runat="server" ToolTipID="110" />
        </td>
        <td>
            <telerik:RadTextBox ID="txtTitle" runat="server" Width="500px">
            </telerik:RadTextBox>
        </td>
        <td align="right">
            <asp:HyperLink ID="hlMinimumQualifications2" runat="server" NavigateUrl="" Target="_blank"
                Visible="false">
            Minimum Qualifications
            </asp:HyperLink>
            <tooltip:ToolTip ID="ToolTipMinQual2" runat="server" ToolTipID="112" Visible="false" />
        </td>
    </tr>
    <tr  id="QInstButton" runat="server">
        <td colspan="2" class="toolTipleft">
            <asp:Button ID="btnShowQUalInst" runat="server" OnClick="btnShowQUalInst_Click" Text="Show Instruction" />&nbsp;<tooltip:ToolTip
                ID="ToolTipQualInstructions" runat="server" ToolTipID="178" />
        </td>
    </tr>
    <tr id="QInst" runat="server">
        <td colspan="3" class="toolTipleft">
            <asp:Label ID="lblQualificationInstruction" runat="server" AssociatedControlID="RadEditQualificationInstruction"
                Text="Qualification Instruction" ToolTip="Qualification Instruction"></asp:Label>&nbsp;
            <span class="required">*</span>&nbsp;
        </td>
    </tr>
    <tr id="QInstText" runat="server">
        <td colspan="4">
            <telerik:RadEditor ID="RadEditQualificationInstruction" runat="server" Width="95%"
                OnClientLoad="OnClientLoad" SkinID="shortRadEditor">
            </telerik:RadEditor>
            <asp:HiddenField ID="hdquains" runat="server" Value="" />
            <asp:RequiredFieldValidator ID="RequiredFieldValRadEditQualificationInstruction"
                runat="server" ControlToValidate="RadEditQualificationInstruction" ErrorMessage="Qualification Instruction is required."
                ValidationGroup="TitleValidationGroup" Display="None" />
        </td>
    </tr>
    <tr id="trQSave" runat="server" align="right">
        <td colspan="4">
            <asp:Label ID="lblmsg" runat="server" Font-Bold="true"></asp:Label>
            <asp:Button ID="btnSave" runat="server" Text="Save" ToolTip="Save" OnClick="btnSave_Click"
                OnClientClick="HoldValue()" ValidationGroup="TitleValidationGroup" />&nbsp;&nbsp;
        </td>
    </tr>
</table>
<asp:Panel ID="pnlQuestions" runat="server">
    <div runat="server" id="qualificationDetail">
        <div class="sectionTitle">
            Qualification Statements
        </div>
        <telerik:RadGrid ID="gridQuestions" runat="server" AutoGenerateColumns="False" CellSpacing="0"
            GridLines="None" OnItemCommand="gridQuestions_ItemCommand" OnNeedDataSource="gridQuestions_NeedDataSource"
            OnItemDataBound="gridQuestions_ItemDataBound" OnPreRender="gridQuestions_PreRender"
            OnItemCreated="gridQuestions_ItemCreated">
            <MasterTableView DataKeyNames="ID,RatingScaleID" TableLayout="Auto" CommandItemSettings-AddNewRecordText="Add New Qualification Statement">
                <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                    <HeaderStyle Width="20px"></HeaderStyle>
                </RowIndicatorColumn>
                <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                    <HeaderStyle Width="20px"></HeaderStyle>
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridTemplateColumn UniqueName="EditCommandColumn">
                        <ItemStyle VerticalAlign="Top" Width="10" />
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButtonEdit" runat="server" ToolTip="Edit" CommandName="Edit"
                                SkinID="editButton" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImageButtonUpdate" runat="server" ToolTip='<%# (Container is GridDataInsertItem) ? "Add Qualification Statement" : "Save Qualification Statement" %>'
                                SkinID="updateButton" CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>' />
                            <asp:LinkButton ID="LinkButtonUpdate" runat="server" Text='<%# (Container is GridDataInsertItem) ? "Add Qualification Statement" : "Save Qualification Statement" %>'
                                CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>'>>
                                Save Qualification Statement
                            
                            </asp:LinkButton>
                            <asp:ImageButton ID="ImageButtonCancel" runat="server" ToolTip="Cancel" CommandName="Cancel" />
                            <asp:LinkButton ID="LinkButtonCancel" runat="server" CommandName="Cancel">
                                Cancel
                            </asp:LinkButton>
                        </EditItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridButtonColumn ConfirmText="Delete this Qualification Statement?" ConfirmDialogType="RadWindow"
                        ConfirmTitle="Delete" ButtonType="ImageButton" CommandName="Delete" Text="Delete"
                        UniqueName="DeleteCommandColumn">
                        <ItemStyle VerticalAlign="Top" Width="10" />
                    </telerik:GridButtonColumn>
                    <telerik:GridTemplateColumn UniqueName="ViewCommandColumn">
                        <ItemStyle VerticalAlign="Top" Width="10" />
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButtonView" runat="server" ToolTip="View" CommandName="View"
                                SkinID="viewButton" /></ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Qualification Statement">
                        <ItemTemplate>
                            <asp:Label ID="lblFactorItemID" runat="server" Visible="false" Text='<%# Eval("ID", "{0}") %>'></asp:Label>
                            <asp:Label ID="lblQuestionText" runat="server" Text='<%# Eval("ItemText", "{0:s}") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Rating Scale">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblRatingScaleID" Visible="false" Text='<%# Eval("RatingScaleID", "{0}") %>'></asp:Label>
                            <asp:Label runat="server" ID="lblRatingScaleName" Text='<%# Eval("RatingScaleName", "{0:s}") %>'></asp:Label>
                            <asp:Label runat="server" ID="lblRatingScaleTypeID" Visible="false" Text='<%# Eval("RatingScaleTypeID", "{0}") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
                <EditFormSettings EditFormType="Template">
                    <FormTemplate>
                        <%--<asp:ObjectDataSource ID="odsRatingScaleType" runat="server" SelectMethod="GetAllRatingScaleTypes"
                            TypeName="HCMS.Business.Lookups.LookupManager"></asp:ObjectDataSource>--%>
                        <asp:ObjectDataSource ID="odsRatingScaleType" runat="server" SelectMethod="GetAllRatingScaleTypesForQual"
                            TypeName="HCMS.Business.Lookups.LookupManager"></asp:ObjectDataSource>
                        <asp:ValidationSummary ID="valSummary" runat="server" DisplayMode="BulletList" CssClass="validationMessageBox"
                            ValidationGroup="QSValGroup" />
                        <table width="100%" class="blueTable" id="tblQuestion" runat="server">
                            <tr id="ApptEligRow" runat="server" visible="false">
                                <td class="toolTipleft">
                                    <asp:Label ID="ApptElig1" AssociatedControlID="rcbApptEligQuestion" runat="server"
                                        Text="Qualification Statement"></asp:Label>&nbsp;<tooltip:ToolTip ID="ToolTip5" runat="server"
                                            ToolTipID="195" />
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcbApptEligQuestion" runat="server" AutoPostBack="true"
                                        NoWrap="false" CausesValidation="false" DropDownWidth="600px" Width="300px">
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldApptEligQuestion" runat="server" ControlToValidate="rcbApptEligQuestion"
                                        Display="Dynamic" Text="*" ErrorMessage="Appointment Eligibility Question is required."
                                        InitialValue="[-- Select Appt Eligibility Question --]" ValidationGroup="QSValGroup" />
                                </td>
                            </tr>
                            <tr>
                                <td class="toolTipleft">
                                    <asp:Label ID="Label1" runat="server" AssociatedControlID="txtQuestion" Text="Qualification Statement"
                                        ToolTip="Qualification Statement Title"></asp:Label>&nbsp;<tooltip:ToolTip ID="ToolTip1"
                                            runat="server" ToolTipID="180" />
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtQuestion" runat="server" Width="90%" Rows="10" TextMode="MultiLine"
                                        Text='<%# Bind("ItemText") %>'>
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorQuestion" runat="server" ControlToValidate="txtQuestion"
                                        ErrorMessage="Qualification Statement is required." Text="*" Display="Dynamic"
                                        ValidationGroup="QSValGroup" />
                                </td>
                            </tr>
                            <tr>
                                <td class="toolTipleft">
                                    <asp:Label ID="Label2" runat="server" AssociatedControlID="rcbRatingScaleType" Text="Response Type "
                                        ToolTip="Response Type"></asp:Label>&nbsp;<tooltip:ToolTip ID="ToolTip2" runat="server"
                                            ToolTipID="196" />
                                </td>
                                <td>
                                    <telerik:RadComboBox ID="rcbRatingScaleType" runat="server" AutoPostBack="true" NoWrap="false"
                                        CausesValidation="true" DataSourceID="odsRatingScaleType" DataValueField="ID"
                                        DataTextField="Name" Width="329px" ValidationGroup="QSValGroup">
                                    </telerik:RadComboBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rcbRatingScaleType"
                                        ErrorMessage="Rating Scale is required." Text="*" Display="Dynamic" ValidationGroup="QSValGroup" />
                                </td>
                            </tr>
                            <tr>
                                <td class="toolTipleft">
                                    <asp:Label ID="Label3" runat="server" AssociatedControlID="txtInstruction" Text="Instructions"
                                        ToolTip="Instructions"></asp:Label>&nbsp;<tooltip:ToolTip ID="ToolTip3" runat="server"
                                            ToolTipID="116" />
                                </td>
                                <td>
                                    <telerik:RadTextBox ID="txtInstruction" runat="server" Enabled="true" ReadOnly="false"
                                        Width="90%" Rows="5" TextMode="MultiLine">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValtxtInstruction" runat="server" ControlToValidate="txtInstruction"
                                        ValidationGroup="QSValGroup" ErrorMessage="Instructions are required." Text="*"
                                        Display="Dynamic"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2">
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblmsgQS" Text="" Visible="true" runat="server" Font-Bold="true"></asp:Label>
                                                <telerik:RadSpell ID="RadSpellQualifyingStatements" runat="server" AllowAddCustom="false"
                                                    ControlsToCheck="txtQuestion,txtInstruction" ButtonType="PushButton" ButtonText="Spell Check"
                                                    ToolTip="Spell Check" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnSaveQS" Text='<%# (Container is GridDataInsertItem) ? "Add Qualification Statement" : "Save Qualification Statement" %>'
                                                    ToolTip='<%# (Container is GridDataInsertItem) ? "Add Qualification Statement" : "Save Qualification Statement" %>'
                                                    CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>'
                                                    runat="server" ValidationGroup="QSValGroup" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnCancel" Text="Close" runat="server" CausesValidation="False" ToolTip="Close"
                                                    CommandName="Cancel"></asp:Button>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <telerik:RadGrid ID="gridResponses" runat="server" AllowPaging="true" CellSpacing="0"
                            GridLines="None">
                            <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                <Selecting AllowRowSelect="true" />
                            </ClientSettings>
                            <MasterTableView AutoGenerateColumns="False" DataKeyNames="ID" EditMode="InPlace"
                                CommandItemSettings-AddNewRecordText="Add New Response">
                                <CommandItemSettings ExportToPdfText="Export to PDF" ShowRefreshButton="False"></CommandItemSettings>
                                <EditFormSettings ColumnNumber="3" CaptionFormatString="Edit Response: {0}" CaptionDataField="ResponseLetter"
                                    EditColumn-Display="false">
                                    <FormTableItemStyle Wrap="False"></FormTableItemStyle>
                                    <FormCaptionStyle CssClass="EditFormHeader"></FormCaptionStyle>
                                    <FormMainTableStyle GridLines="None" CellSpacing="0" CellPadding="3" Width="100%">
                                    </FormMainTableStyle>
                                    <FormTableStyle GridLines="Horizontal" CellSpacing="0" CellPadding="2" CssClass="module"
                                        Height="110px" Width="100%"></FormTableStyle>
                                    <FormTableAlternatingItemStyle Wrap="False"></FormTableAlternatingItemStyle>
                                    <FormStyle Width="100%" BackColor="#eef2ea"></FormStyle>
                                    <EditColumn Display="false" Visible="false">
                                    </EditColumn>
                                </EditFormSettings>
                                <Columns>
                                    <telerik:GridTemplateColumn UniqueName="EditCommandColumn">
                                        <ItemStyle VerticalAlign="Top" Width="10" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButtonEdit" runat="server" ToolTip="Edit" CommandName="Edit"
                                                SkinID="editButton" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:ImageButton ID="ImageButtonUpdate" runat="server" ToolTip='<%# (Container is GridDataInsertItem) ? "Add Response" : "Save Response" %>'
                                                SkinID="updateButton" CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>' />
                                            <asp:LinkButton ID="LinkButtonUpdate" runat="server" Text='<%# (Container is GridDataInsertItem) ? "Add Response" : "Save Response" %>'
                                                CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>'>>Save Response</asp:LinkButton>
                                            <asp:ImageButton ID="ImageButtonCancel" runat="server" ToolTip="Cancel" SkinID="cancelButton"
                                                CommandName="Cancel" />
                                            <asp:LinkButton ID="LinkButtonCancel" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridButtonColumn Text="Delete" ButtonType="ImageButton" CommandName="Delete"
                                        UniqueName="DeleteCommandColumn" ConfirmText="Delete this response?" ConfirmDialogType="RadWindow"
                                        ConfirmTitle="Delete" ImageUrl="~/App_Themes/JNP_Default/Images/Icons/icon_delete.gif">
                                        <ItemStyle HorizontalAlign="Center" Width="30" />
                                    </telerik:GridButtonColumn>
                                    <telerik:GridTemplateColumn HeaderText="Letter" SortExpression="ResponseLetter" UniqueName="TemplateResponseLetter"
                                        EditFormColumnIndex="1">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblResponseID" Visible="false" Text='<%# Eval("ID", "{0}") %>'></asp:Label>
                                            <asp:Label runat="server" ID="lblRatingScaleTypeID" Visible="false" Text='<%# Eval("RatingScaleTypeID", "{0}") %>'></asp:Label>
                                            <asp:Label runat="server" ID="lblRatingScaleID" Visible="false" Text='<%# Eval("RatingScaleID", "{0}") %>'></asp:Label>
                                            <asp:Label runat="server" ID="lblResponseLetter" Text='<%# Eval("ResponseLetter", "{0:s}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label runat="server" ID="lblResponseID" Visible="false" Text='<%# Eval("ID", "{0}") %>'></asp:Label>
                                            <asp:Label runat="server" ID="lblRatingScaleTypeID" Visible="false" Text='<%# Eval("RatingScaleTypeID", "{0}") %>'></asp:Label>
                                            <asp:Label runat="server" ID="lblRatingScaleID" Visible="false" Text='<%# Eval("RatingScaleID", "{0}") %>'></asp:Label>
                                            <telerik:RadTextBox ID="txtResponseLetter" Text='<%# Eval("ResponseLetter", "{0:s}") %>'
                                                Width="40" runat="server">
                                            </telerik:RadTextBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn HeaderText="Text" SortExpression="ResponseText" UniqueName="TemplateResponseText"
                                        EditFormColumnIndex="2">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblResponseText" Text='<%# Eval("ResponseText", "{0:s}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <telerik:RadTextBox ID="txtResponseText" Text='<%# Eval("ResponseText", "{0:s}") %>'
                                                Width="620" runat="server" Rows="5" TextMode="MultiLine">
                                            </telerik:RadTextBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                        </telerik:RadGrid>
                    </FormTemplate>
                </EditFormSettings>
            </MasterTableView>
            <FilterMenu EnableImageSprites="False">
            </FilterMenu>
        </telerik:RadGrid>
    </div>
</asp:Panel>
<span class="spanAction">
    <asp:Button ID="btnCancel" runat="server" Text="Close" ToolTip="Close" OnClick="btnCancel_Click"
        Visible="false" CausesValidation="false" />
</span>
<!--re- added btnRefresh - because it is called in js function OnPopupWindowClose()-->
<div style="display: none">
    <asp:Button ID="btnRefresh" runat="server" />
</div>
