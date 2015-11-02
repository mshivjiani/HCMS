<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlAddEditKSA.ascx.cs"
    Inherits="HCMS.JNP.Controls.JQ.ctrlAddEditKSA" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="tooltip" %>
<%@ Register Src="../Search/ctrlSearchKSA.ascx" TagName="ctrlSearchKSA" TagPrefix="uc1" %>
<%@ Register Src="../Search/ctrlSearchTaskStatement.ascx" TagName="ctrlSearchTaskStatement"
    TagPrefix="uc2" %>
<telerik:RadCodeBlock ID="radcodeblockEdiKSA" runat="server">
    <script type="text/javascript">

        function OnClientLoad(editor, args) {
            editor.removeShortCut("InsertTab");
        }

        function ShowQuestionWindowClient(mode, id) {
            var navigateurl;
            var title;

            if (mode == "Insert") {
                navigateurl = "../JQ/AddEditKSAQuestion.aspx?mode=Insert&JQFactorID=" + id;
                title = "Add Task Statement";
            }
            else if (mode == "Edit") {
                navigateurl = "../JQ/AddEditKSAQuestion.aspx?mode=Edit&JQFactorItemID=" + id;
                title = "Edit Task Statement";
            }
            else {
                navigateurl = "../JQ/AddEditKSAQuestion.aspx?mode=View&JQFactorItemID=" + id;
                title = "View Task Statement";
            }
            var omanager = GetRadWindowManager();
            var ownd = omanager.getWindowByName('rwQ');
            ownd.setUrl(navigateurl);
            ownd.set_title(title);
            ownd.show();
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
        function validatelimit(obj, maxchar) {

            if (this.id) obj = this;

            var remaningChar = maxchar - obj.value.length;


            if (remaningChar <= 0) {
                obj.value = obj.value.substring(maxchar, 0);
                radalert('KSA Title cannot exceed 255 characters.', 300, 100, 'KSA Title Character Limit');
                return false;
            }
            else
            { return true; }
        }

        function ConfirmAddToLibrary(button) {

            function aspButtonCallbackFn(arg) {

                if (arg) {
                    __doPostBack(button.name, "");
                }


            }

            radconfirm("Are you sure you want to add to library?", aspButtonCallbackFn, 330, 180, null, "Add To Library");

        }

        function HoldValue() {

            var Inst;
            var editor = $find("<%=RadEditKSAInstruction.ClientID%>");

            if (editor != null) {
                Inst = (editor.get_text());
                document.getElementById('<%=hdksains.ClientID %>').value = Inst;
            }
        }


        var listbox;
        var lsLength = 0;

        function OnClientLoadHandler(sender, args) {
            listbox = sender;
            lsLength = listbox.get_checkedItems().length;

            if (lsLength.length > 0) {

                args.IsValid = true
            }
            else {

                args.IsValid = false;

            }

            //            if (rlbTSList.get_checkedItems().length > 0) {

            //            }
            //            if (rlbTSList.get_checkedItems().length == 0) {

            //            }
        }

        //        function OnClientHandler(sender, args) {
        //            listbox = sender;
        //            lsLength = listbox.get_checkedItems().length;

        //            if (lsLength.length > 0) {

        //                args.IsValid = true
        //            }
        //            else {

        //                args.IsValid = false;

        //            }
        //        }

        function ValidationCriteria(source, args) {
            args.IsValid = lsLength > 0;
        }

        var txtQuestion;
        function GettxtQuestion(sender, args) {
            txtQuestion = sender;
        }

        var rlbTSList;
        function GetrlbTSList(sender, args) {
            rlbTSList = sender;

        }

        var rcbRatingScaleType;

        function GetrcbRatingScaleType(sender, args) {
            rcbRatingScaleType = sender;
        }

    </script>
</telerik:RadCodeBlock>
<telerik:RadWindowManager ID="RWM" runat="server" Skin="WebBlue">
    <Windows>
        <telerik:RadWindow ID="rwQ" runat="server" RegisterWithScriptManager="true" Skin="WebBlue"
            Height="600px" Width="990px" Behaviors="None" VisibleStatusbar="false" Modal="true">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>
<telerik:RadAjaxLoadingPanel ID="ajaxLoadingPanelSave" runat="server" />
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="ajaxLoadingPanelSave">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rcbFinalKSA">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="tblKSA" />
                <telerik:AjaxUpdatedControl ControlID="pnlQuestions" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnSave">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="tblKSA" />
                <telerik:AjaxUpdatedControl ControlID="pnlQuestions" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnShowKSAInst">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="tblKSA" />
                <telerik:AjaxUpdatedControl ControlID="pnlQuestions" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnRefresh">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="tblKSA" />
                <telerik:AjaxUpdatedControl ControlID="pnlQuestions" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="gridQuestions">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="gridQuestions" />
                <telerik:AjaxUpdatedControl ControlID="btnCancel" />
                <telerik:AjaxUpdatedControl ControlID="gridResponses" />
                <telerik:AjaxUpdatedControl ControlID="btnSave" />
                <telerik:AjaxUpdatedControl ControlID="tblKSA" />
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
<table width="100%" class="blueTable" id="tblKSA" runat="server">
    <tr id="trKSASearch">
        <td colspan="2">
            <br />
            <asp:Label ID="literalSearchmsg" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="text-align: left; width: 100px" class="toolTipleft">
            <asp:Label ID="Label2" runat="server" AssociatedControlID="rcbFinalKSA" Text="KSA"
                ToolTip="KSA"></asp:Label>&nbsp; <span class="required">*</span>&nbsp;
            <tooltip:ToolTip ID="ToolTip3" runat="server" ToolTipID="190" />
        </td>
        <td style="text-align: left;">
            <asp:Label ID="lblTitle" runat="server"></asp:Label>
        </td>
    </tr>
    <!-- keshab - this tr below is no longer required for current business design. So associated code behind should be removed. -->
    <tr id="trKSASelection">
        <td class="style1" colspan="2">
            <telerik:RadComboBox ID="rcbFinalKSA" runat="server" CssClass="float-left" AutoPostBack="true"
                NoWrap="false" ExpandDirection="Down" CausesValidation="false" DropDownWidth="677px"
                Width="325px" OnSelectedIndexChanged="rcbFinalKSA_SelectedIndexChanged">
            </telerik:RadComboBox>
            &nbsp;<uc1:ctrlSearchKSA ID="SearchKSA" runat="server" />
            <asp:RequiredFieldValidator ID="requiredKSA" runat="server" ControlToValidate="rcbFinalKSA"
                Display="Dynamic" ErrorMessage="KSA is required." InitialValue="<<-- Select KSA -->>"
                Text="*" ValidationGroup="TitleValidationGroup" />
        </td>
    </tr>
    <tr id="trbtnShowKSAInst" runat="server">
        <td colspan="2" class="toolTipleft">
            <asp:Button ID="btnShowKSAInst" runat="server" OnClick="btnShowKSAInst_Click" Text="Show Instruction" />&nbsp;<tooltip:ToolTip
                ID="ToolTipKSAInstructions" runat="server" ToolTipID="179" />
        </td>
    </tr>
    <tr id="ksaInst" runat="server">
        <td colspan="2">
            <div style="width: 140px;">
                <asp:Label ID="lblKSAInstruction" runat="server" AssociatedControlID="RadEditKSAInstruction"
                    Text="KSA Instruction" ToolTip="KSA Instruction"></asp:Label>&nbsp; <span class="required">
                        *</span>&nbsp;
            </div>
        </td>
    </tr>
    <tr id="ksaInstText" runat="server">
        <td colspan="2">
            <telerik:RadEditor ID="RadEditKSAInstruction" runat="server" OnClientLoad="OnClientLoad"
                SkinID="shortRadEditor">
            </telerik:RadEditor>
            <asp:HiddenField ID="hdksains" runat="server" Value="" />
            <asp:RequiredFieldValidator ID="RequiredFieldValRadEditKSAInstruction" runat="server"
                ValidationGroup="TitleValidationGroup" ControlToValidate="RadEditKSAInstruction"
                ErrorMessage="KSA Instruction is required." Text="*" Display="Dynamic" />
        </td>
    </tr>
    <tr align="right">
        <td colspan="2">
            <asp:Label ID="lblmsg" runat="server" Font-Bold="true"></asp:Label><asp:Button ID="btnSave"
                CausesValidation="true" Text="Save" ToolTip="Save" runat="server" OnClick="btnSave_Click"
                OnClientClick="HoldValue()" ValidationGroup="TitleValidationGroup" />&nbsp;&nbsp;
        </td>
    </tr>
</table>
<asp:Panel ID="pnlQuestions" runat="server">
    <div runat="server" id="ksaDetail">
        <div class="sectionTitle">
            Task Statements
        </div>
        <div style="color: #FF0000">
            Recommendation to add 4-5 Tasks Statements per KSA
        </div>
        <%--        <div>
            <asp:Label ID="lblSavedMsg" runat="server" Font-Bold="true" Text="Task Statement updated successfully."
                ForeColor="Green" Visible="false" />
        </div>--%>
        <telerik:RadGrid ID="gridQuestions" runat="server" AutoGenerateColumns="False" CellSpacing="0"
            GridLines="None" OnItemCommand="gridQuestions_ItemCommand" OnNeedDataSource="gridQuestions_NeedDataSource"
            OnItemDataBound="gridQuestions_ItemDataBound" OnItemCreated="gridQuestion_ItemCreated"
            OnPreRender="gridQuestions_PreRender">
            <MasterTableView DataKeyNames="ID,RatingScaleID" CommandItemDisplay="Top" CommandItemSettings-AddNewRecordText="Add New Statement">
                <CommandItemSettings AddNewRecordText="Add New Task Statement" ExportToPdfText="Export to PDF">
                </CommandItemSettings>
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
                    </telerik:GridTemplateColumn>
                    <telerik:GridButtonColumn ConfirmText="Delete this TaskStatement?" ConfirmDialogType="RadWindow"
                        ImageUrl="~/App_Themes/JNP_Default/Images/Icons/icon_delete.gif" ConfirmTitle="Delete"
                        ButtonType="ImageButton" CommandName="Delete" Text="Delete" UniqueName="DeleteCommandColumn">
                        <ItemStyle VerticalAlign="Top" Width="10" />
                    </telerik:GridButtonColumn>
                    <telerik:GridTemplateColumn UniqueName="ViewCommandColumn">
                        <ItemStyle VerticalAlign="Top" Width="10" />
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButtonView" runat="server" ToolTip="View" CommandName="View"
                                SkinID="viewButton" /></ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Task Statement">
                        <ItemTemplate>
                            <asp:Label ID="lblFactorItemID" runat="server" Visible="false" Text='<%# Eval("ID", "{0}") %>'></asp:Label>
                            <asp:Label ID="lblQuestionText" runat="server" Text='<%# Eval("ItemText", "{0:s}") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Response Type">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblRatingScaleID" Visible="false" Text='<%# Eval("RatingScaleID", "{0}") %>'></asp:Label>
                            <asp:Label runat="server" ID="lblRatingScaleName" Text='<%# Eval("RatingScaleName", "{0:s}") %>'></asp:Label>
                            <asp:Label runat="server" ID="lblRatingScaleTypeID" Visible="false" Text='<%# Eval("RatingScaleTypeID", "{0}") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
                <EditFormSettings EditFormType="Template">
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                    </EditColumn>
                    <FormTemplate>
                        <%--<asp:ObjectDataSource ID="odsRatingScaleType" runat="server" SelectMethod="GetAllRatingScaleTypes"
                            TypeName="HCMS.Business.Lookups.LookupManager"></asp:ObjectDataSource>--%>
                            <asp:ObjectDataSource ID="odsRatingScaleType" runat="server" SelectMethod="GetAllRatingScaleTypesForKSA"
                            TypeName="HCMS.Business.Lookups.LookupManager"></asp:ObjectDataSource>
                        <asp:ValidationSummary ID="valSummary" runat="server" CssClass="validationMessageBox"
                            DisplayMode="BulletList" ValidationGroup="TSValGroup" />
                        <table id="tblQuestion" runat="server" class="blueTable" width="100%">
                            <tr id="trTaskStatementSelection1" runat="server">
                                <td style="text-align: left;" class="toolTipleft" colspan="2">
                                    <div style="width: 115px;">
                                        <asp:Label ID="Label3" runat="server" Text="Task Statement" ToolTip="Task Statement"></asp:Label>
                                        &nbsp; <span class="required">*</span>&nbsp;
                                        <tooltip:ToolTip ID="ToolTip5" runat="server" ToolTipID="121" />
                                    </div>
                                </td>
                            </tr>
                            <tr id="trRadio" runat="server">
                                <td>
                                    <table>
                                        <tr>
                                            <td width="50%">
                                                <telerik:RadButton ID="radSelect" runat="server" ToggleType="Radio" ButtonType="ToggleButton"
                                                    Text="Please select Task Statement(s) from the list below. If you don't see any Task Statements,
                                    expand your search by selecting the 'Search in all Grades' option to the right." GroupName="StandardButton"
                                                    Checked="true" OnClick="radio_Checked">
                                                </telerik:RadButton>
                                            </td>
                                            <td id="rSearch" runat="server" visible="true" width="50%">
                                                <uc2:ctrlSearchTaskStatement ID="TSSearch" runat="server" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <telerik:RadButton ID="radCreate" runat="server" ToggleType="Radio" Checked="false"
                                                    Text="Create New" GroupName="StandardButton" ButtonType="ToggleButton" OnClick="radio_Checked">
                                                </telerik:RadButton>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr id="tsLabel" runat="server" visible="false">
                                <td style="text-align: left;" class="toolTipleft" colspan="2">
                                    <div style="width: 100px;">
                                        <asp:Label ID="Label1" runat="server" AssociatedControlID="txtQuestion" Text="Task Statement"
                                            ToolTip="Task Statement"></asp:Label>
                                        &nbsp;<tooltip:ToolTip ID="ToolTip2" runat="server" ToolTipID="191" />
                                    </div>
                                </td>
                            </tr>
                            <tr id="tsText" runat="server" visible="true">
                                <td colspan="2">
                                    <telerik:RadTextBox ID="txtQuestion" runat="server" Rows="4" TextMode="MultiLine"
                                        Width="70%" OnClientLoad="GettxtQuestion">
                                    </telerik:RadTextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorQuestion" runat="server" ControlToValidate="txtQuestion"
                                        Display="Dynamic" ErrorMessage="Task Statement is required." Text="*" ValidationGroup="TSValGroup" />
                                    <asp:Button ID="btnAddToLibrary" runat="server" OnClientClick="if ( !ConfirmAddToLibrary(this))return false;"
                                        Text="Add To Library" Visible="false" CausesValidation="true" ValidationGroup="TSValGroup" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Literal ID="literalSearchTSmsg" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr id="lbTaskStatement" runat="server" visible="true">
                                <td colspan="2">
                                    <telerik:RadListBox ID="rlbTSList" runat="server" Width="600px" Height="200px" CheckBoxes="true"
                                        OnClientItemChecked="OnClientLoadHandler" OnClientLoad="GetrlbTSList">
                                        <Items>
                                        </Items>
                                    </telerik:RadListBox>
                                    <%--  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rlbTSList"
                                        Display="Dynamic" ErrorMessage="Select Task Statement from list." InitialValue="test"
                                        Text=" " ValidationGroup="TSValGroup" />--%>
                                    <asp:CustomValidator ID="CustomValidator1" runat="server" ClientValidationFunction="ValidationCriteria"
                                        ValidationGroup="TSValGroup" ErrorMessage="Select Task Statement from List."
                                        Text="*">
                                    </asp:CustomValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <div style="width: 100px;" class="toolTipleft">
                                        <asp:Label ID="Label2" runat="server" AssociatedControlID="rcbRatingScaleType" Text="Response Type"
                                            ToolTip="Response Type"></asp:Label>
                                        &nbsp;<tooltip:ToolTip ID="ToolTip3" runat="server" ToolTipID="115" />
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <telerik:RadComboBox ID="rcbRatingScaleType" runat="server" AutoPostBack="true" DataSourceID="odsRatingScaleType"
                                        DataTextField="Name" DataValueField="ID" NoWrap="false" Width="329px" CausesValidation="true"
                                        ValidationGroup="TSValGroup" OnClientLoad="GetrcbRatingScaleType">
                                    </telerik:RadComboBox>
                                    <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rcbRatingScaleType"
                                        Display="Dynamic" ErrorMessage="Response Type is required." Text="*" ValidationGroup="TSValGroup" />--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="toolTipleft" colspan="2">
                                    <asp:Button ID="btnShowInst" runat="server" OnClick="btnShowInst_Click" Text="Show Instruction" />&nbsp;<tooltip:ToolTip
                                        ID="ToolTip4" runat="server" ToolTipID="116" />
                                </td>
                            </tr>
                            <tr id="inst" runat="server">
                                <td colspan="2">
                                    <div style="width: 85px;">
                                        <asp:Label ID="Label4" runat="server" AssociatedControlID="txtInstruction" Text="Instructions"
                                            ToolTip="Instructions"></asp:Label>
                                    </div>
                                </td>
                            </tr>
                            <tr id="instText" runat="server">
                                <td colspan="2">
                                    <telerik:RadTextBox ID="txtInstruction" runat="server" Enabled="true" ReadOnly="false"
                                        Rows="5" TextMode="MultiLine" Width="90%">
                                    </telerik:RadTextBox>
                                </td>
                            </tr>
                            <tr align="right">
                                <td colspan="2">
                                    <table>
                                        <tr>
                                            <td id="tdRadSpell" runat="server">
                                                <%--<asp:Label ID="lblmsgTS" Text="Successfully Added Task Statement" Visible="false"
                                                    runat="server" Font-Bold="true"></asp:Label>--%>
                                                <telerik:RadSpell ID="RadSpellTaskStatements" runat="server" AllowAddCustom="false"
                                                    ControlsToCheck="txtQuestion" ButtonType="PushButton" ButtonText="Spell Check"
                                                    ToolTip="Spell Check" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnSaveTS" runat="server" CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>'
                                                    Text="Save Task Statement" ToolTip="Save Task Statement" CausesValidation="true"
                                                    Enabled="true" ValidationGroup="TSValGroup" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnCancel" runat="server" CausesValidation="False" CommandName="Cancel"
                                                    Text="Close" ToolTip="Close" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <telerik:RadGrid ID="gridResponses" runat="server" AllowPaging="True" CellSpacing="0"
                            GridLines="None">
                            <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                                <Selecting AllowRowSelect="true" />
                            </ClientSettings>
                            <MasterTableView AutoGenerateColumns="False" CommandItemSettings-AddNewRecordText="Add New Response"
                                DataKeyNames="ID" EditMode="InPlace" EnableLinqGrouping="False" EnableSplitHeaderText="False">
                                <CommandItemSettings ExportToPdfText="Export to PDF" ShowRefreshButton="False" />
                                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                </RowIndicatorColumn>
                                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                </ExpandCollapseColumn>
                                <Columns>
                                    <telerik:GridTemplateColumn EditFormHeaderTextFormat="" UniqueName="EditCommandColumn">
                                        <ItemStyle VerticalAlign="Top" Width="10" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButtonEdit" runat="server" CommandName="Edit" SkinID="editButton"
                                                ToolTip="Edit" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:ImageButton ID="ImageButtonUpdate" runat="server" CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>'
                                                SkinID="updateButton" ToolTip='<%# (Container is GridDataInsertItem) ? "Add Response" : "Save Response" %>' />
                                            <asp:LinkButton ID="LinkButtonUpdate" runat="server" CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>'
                                                Text='<%# (Container is GridDataInsertItem) ? "Add Response" : "Save Response" %>'>&gt;Save Response</asp:LinkButton>
                                            <asp:ImageButton ID="ImageButtonCancel" runat="server" CommandName="Cancel" SkinID="cancelButton"
                                                ToolTip="Cancel" />
                                            <asp:LinkButton ID="LinkButtonCancel" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridButtonColumn ButtonType="ImageButton" CommandName="Delete" ConfirmDialogType="RadWindow"
                                        ConfirmText="Delete this response?" ConfirmTitle="Delete" EditFormHeaderTextFormat=""
                                        ImageUrl="~/App_Themes/JNP_Default/Images/Icons/icon_delete.gif" Text="Delete"
                                        UniqueName="DeleteCommandColumn">
                                        <ItemStyle CssClass="GridImageButton" HorizontalAlign="Center" Width="30" />
                                    </telerik:GridButtonColumn>
                                    <telerik:GridTemplateColumn EditFormColumnIndex="1" HeaderText="Letter" SortExpression="ResponseLetter"
                                        UniqueName="TemplateResponseLetter">
                                        <ItemTemplate>
                                            <asp:Label ID="lblResponseID" runat="server" Text='<%# Eval("ID", "{0}") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblRatingScaleTypeID" runat="server" Text='<%# Eval("RatingScaleTypeID", "{0}") %>'
                                                Visible="false"></asp:Label>
                                            <asp:Label ID="lblRatingScaleID" runat="server" Text='<%# Eval("RatingScaleID", "{0}") %>'
                                                Visible="false"></asp:Label>
                                            <asp:Label ID="lblResponseLetter" runat="server" Text='<%# Eval("ResponseLetter", "{0:s}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblResponseID" runat="server" Text='<%# Eval("ID", "{0}") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblRatingScaleTypeID" runat="server" Text='<%# Eval("RatingScaleTypeID", "{0}") %>'
                                                Visible="false"></asp:Label>
                                            <asp:Label ID="lblRatingScaleID" runat="server" Text='<%# Eval("RatingScaleID", "{0}") %>'
                                                Visible="false"></asp:Label>
                                            <telerik:RadTextBox ID="txtResponseLetter" runat="server" Text='<%# Eval("ResponseLetter", "{0:s}") %>'
                                                Width="40">
                                            </telerik:RadTextBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                    <telerik:GridTemplateColumn EditFormColumnIndex="2" HeaderText="Text" SortExpression="ResponseText"
                                        UniqueName="TemplateResponseText">
                                        <ItemTemplate>
                                            <asp:Label ID="lblResponseText" runat="server" Text='<%# Eval("ResponseText", "{0:s}") %>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <telerik:RadTextBox ID="txtResponseText" runat="server" Text='<%# Eval("ResponseText", "{0:s}") %>'
                                                TextMode="MultiLine" Width="620">
                                            </telerik:RadTextBox>
                                        </EditItemTemplate>
                                    </telerik:GridTemplateColumn>
                                </Columns>
                            </MasterTableView>
                            <FooterStyle BackColor="#FF33CC" BorderStyle="Dotted" BorderWidth="10px" />
                            <FilterMenu EnableImageSprites="False">
                            </FilterMenu>
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
        CausesValidation="false" Visible="false" />
</span>
<div style="display: none">
    <asp:Button ID="btnRefresh" runat="server" OnClick="btnRefresh_Click" />
</div>
