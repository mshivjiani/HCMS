<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlDutyKSA.ascx.cs"
    Inherits="HCMS.JNP.Controls.JA.ctrlDutyKSA" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="pde" %>
<%@ Register Src="~/Controls/Search/ctrlSearchKSA.ascx" TagPrefix="uc1" TagName="ctrlSearchKSA" %>
<style type="text/css">
    .borderlessRadListBox li.rlbItem
    {
        list-style-position: inside;
        list-style-type: square !important;
    }
</style>
<telerik:RadCodeBlock ID="rcbCodeBlock" runat="server">
    <script type="text/javascript">
        maxChars = 1500;
        function ShowDutyWindowClient(mode, id) {
            var navigateurl;
            var title;

            if (mode == "Insert") {
                navigateurl = "/JA/AddEditJADuty.aspx?mode=Insert&JAID=" + id;
                title = "Add Duty";
            }
            else if (mode == "Edit") {
                navigateurl = "/JA/AddEditJADuty.aspx?mode=Edit&JADutyID=" + id;
                title = "Edit Duty";
            }
            else {
                navigateurl = "/JA/AddEditJADuty.aspx?mode=View&JADutyID=" + id;
                title = "View Duty";
            }
            var omanager = GetRadWindowManager();
            var ownd = omanager.getWindowByName('rwJADuties');
            ownd.setUrl(navigateurl);
            ownd.set_title(title);
            ownd.show();
        }

        function callConfirm(button) {
            var msg;

            if (button.defaultValue == "Add KSA") {
                msg = "Adding this change will add a new Condition of Employment both on this screen and in the Published PD.  Please click OK to apply this change or Cancel to discard this change.";

            }
            else if (button.defaultValue == "Save KSA") {
                msg = "Saving this change will update this Condition of Employment both on this screen and in the Published PD.  Please click OK to apply this change or Cancel to discard this change.";

            }

            function confirmCallBackFn(arg) {
                if (arg) {
                    __doPostBack(button.name, "");
                }
            }
            radconfirm(msg, confirmCallBackFn);

        }


        function OnWindowClose(oWnd, eventArgs) {
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
        function OnPopupWindowClose(oWnd, eventArgs) {
            //using this instead of document.location.reload()
            // to avoid getting "resend" warning message
            document.location.href = document.location.href;

        }
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

        function scrolltoTopDuty() {
            //$('[id$=valSummary]').focus();
            $('html, body').animate({ scrollTop: '0px' }, 800);
        }

        function ShowFirstFactorLanguagePopup() {
            var oWnd = $find("<%=rwFirstFactorLanguagePopup.ClientID%>");
            oWnd.setUrl("../JA/Factor1PopUp.aspx");
            oWnd.show();
        }

    </script>
</telerik:RadCodeBlock>
<telerik:RadWindowManager ID="RadWindowMangerDuties" runat="server" Behaviors="Default"
    Skin="WebBlue" ReloadOnShow="false">
    <Windows>
        <telerik:RadWindow ID="rwJADuties" runat="server" RegisterWithScriptManager="true"
            Skin="WebBlue" Height="600px" Width="800px" Behaviors="Close" VisibleStatusbar="false"
            Modal="true" ReloadOnShow="true" OnClientClose="OnPopupWindowClose">
        </telerik:RadWindow>
        <telerik:RadWindow ID="rwConfirmWindow" runat="server" RegisterWithScriptManager="true"
            Skin="WebBlue" Height="600px" Width="800px" Behaviors="Close" VisibleStatusbar="false"
            Modal="true" ReloadOnShow="true" OnClientClose="OnWindowClose">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rgJADuty">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgJADuty" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="rgQual">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgQual" LoadingPanelID="pnlQual" />
                <telerik:AjaxUpdatedControl ControlID="rgJADuty" LoadingPanelID="pnlQual" />
                <telerik:AjaxUpdatedControl ControlID="btnContinue" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<br />
<%--<asp:LinkButton ID="lnkShowPDDutyKSAReport" runat="server" OnClick="lnkShowPDDutyKSAReport_Click">Show PD Duty KSA</asp:LinkButton>
 <br />--%>
<asp:ValidationSummary ID="valSummary" runat="server" CssClass="validationMessageBox"
    ShowSummary="true" HeaderText="<span class='systemMessage'>Validation Message</span><br>"
    DisplayMode="BulletList" ValidationGroup="internalValidation" />
<asp:CustomValidator ID="customValTotalPercTime" runat="server" OnServerValidate="customValTotalPercTime_ServerValidate"
    Text="" Display="None"></asp:CustomValidator>
<asp:CustomValidator ID="customValEachMajorDutyHasAtLeastOneDutyKSA" runat="server"
    OnServerValidate="customValEachMajorDutyHasAtLeastOneDutyKSA_ServerValidate"
    Text="" Display="None"></asp:CustomValidator>
<asp:HyperLink ID="hlFactor1" runat="server" NavigateUrl="" Target="_blank">Factor One Language</asp:HyperLink>
<br />&nbsp;
<telerik:RadGrid ID="rgJADuty" runat="server" CellSpacing="0" GridLines="None" OnItemCommand="rgJADuty_ItemCommand"
    AutoGenerateColumns="False" OnNeedDataSource="rgJADuty_NeedDataSource" OnItemDataBound="rgJADuty_ItemDataBound"
    OnPreRender="rgJADuty_PreRender">
    <MasterTableView HierarchyLoadMode="ServerBind" DataKeyNames="JADutyID" EditMode="PopUp"
        CommandItemDisplay="Top" CommandItemSettings-AddNewRecordText="Add New Duty">
        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
            <HeaderStyle Width="20px"></HeaderStyle>
        </RowIndicatorColumn>
        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
            <HeaderStyle Width="20px"></HeaderStyle>
        </ExpandCollapseColumn>
        <EditFormSettings CaptionFormatString="Add Duty">
            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
            </EditColumn>
            <PopUpSettings Height="600px" Width="300px" ScrollBars="Vertical" />
        </EditFormSettings>
        <Columns>
            <telerik:GridTemplateColumn UniqueName="EditCommandColumn">
                <ItemStyle VerticalAlign="Top" Width="10" />
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButtonEdit" runat="server" ToolTip="Edit" CommandName="Edit"
                        SkinID="editButton" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:ImageButton ID="ImageButtonUpdate" runat="server" ToolTip='<%# (Container is GridDataInsertItem) ? "Add Duty" : "Save Duty" %>'
                        SkinID="updateButton" CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>' />
                    <asp:LinkButton ID="LinkButtonUpdate" runat="server" Text='<%# (Container is GridDataInsertItem) ? "Add Duty" : "Save Duty" %>'
                        CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>'>
                    Save Duty
                    </asp:LinkButton>
                    <asp:ImageButton ID="ImageButtonCancel" runat="server" ToolTip="Cancel" CommandName="Cancel" />
                    <asp:LinkButton ID="LinkButtonCancel" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                </EditItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridButtonColumn ConfirmText="Deleting this duty will delete any associated KSAs and Task Statements.  Select OK to continue or Cancel to discard this change."
                ConfirmDialogType="RadWindow" ConfirmTitle="Delete" ButtonType="ImageButton"
                CommandName="Delete" Text="Delete" UniqueName="DeleteCommandColumn">
                <ItemStyle VerticalAlign="Top" Width="10" />
            </telerik:GridButtonColumn>
            <telerik:GridTemplateColumn UniqueName="ViewCommandColumn">
                <ItemStyle VerticalAlign="Top" Width="10" />
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButtonView" runat="server" ToolTip="View" CommandName="View"
                        SkinID="viewButton" /></ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn HeaderText="Duty Description" DataField="JADutyDescription"
                UniqueName="JADutyDescription">
                <ItemTemplate>
                    <asp:TextBox ID="txtDutyDescription" runat="server" CssClass="TelerikTextFont" Text='<%# Eval("JADutyDescription")%>'
                        Rows="10" TextMode="MultiLine" Width="700px" ReadOnly="true"></asp:TextBox>
                </ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridBoundColumn DataField="JAPercentageOfTime" DataType="System.Int32" FilterControlAltText="Filter JAPercentageOfTime column"
                HeaderText="% Of Time" SortExpression="JAPercentageOfTime" UniqueName="JAPercentageOfTime">
            </telerik:GridBoundColumn>
            <%-- 
                //Issue Id: 28
                //Author: Deepali Anuje
                //Date Fixed: 1/29/2012
                //Description: Duty/KSA Screen of JA: Display Duty KSAs on This Screen 
            --%>
            <telerik:GridTemplateColumn HeaderText="Qualifications">
                <ItemStyle VerticalAlign="Top" Width="1px" />
                <ItemTemplate>
                    <telerik:RadListBox ID="radListDutyQual" runat="server" DataTextField="QualificationName"
                        CssClass="borderlessRadListBox" DataValueField="QualificationName">
                    </telerik:RadListBox>
                </ItemTemplate>
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
<asp:Panel ID="pnlQual" runat="server" Visible="true" Width="100%">
    <div class="subTableHeader" width="100%">
        Conditions Of Employment&nbsp;
        <pde:ToolTip ID="ToolTip99" runat="server" ToolTipID="194" />
    </div>
    <telerik:RadGrid ID="rgQual" runat="server" AutoGenerateColumns="False" CellSpacing="0"
        GridLines="None" Width="100%" OnItemDataBound="rgQual_ItemDataBound" OnNeedDataSource="rgQual_NeedDataSource"
        OnItemCommand="rgQual_ItemCommand" OnPreRender="rgQual_PreRender">
        <MasterTableView Width="100%" CommandItemDisplay="Top" HierarchyLoadMode="ServerBind"
            CommandItemSettings-AddNewRecordText="Add New" EditMode="EditForms" DataKeyNames="CompetencyKSAID, PositionDescriptionID">
            <CommandItemSettings ExportToPdfText="Export to PDF" />
            <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                <HeaderStyle Width="20px" />
            </RowIndicatorColumn>
            <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                <HeaderStyle Width="20px" />
            </ExpandCollapseColumn>
            <Columns>
                <telerik:GridTemplateColumn UniqueName="EditCommandColumn">
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
                <telerik:GridButtonColumn ConfirmText="Deleting this KSA will delete any associated Task Statements.  Select OK to continue or Cancel to discard this change."
                    ConfirmDialogType="RadWindow" ConfirmTitle="Delete" ButtonType="ImageButton"
                    CommandName="Delete" Text="Delete" UniqueName="DeleteCommandColumn">
                    <ItemStyle VerticalAlign="Top" Width="10" />
                </telerik:GridButtonColumn>
                <telerik:GridTemplateColumn HeaderText="Qualification" DataField="QualificationName"
                    UniqueName="QualificationName">
                    <ItemStyle VerticalAlign="Top" Wrap="false" />
                    <ItemTemplate>
                        <asp:Label ID="lblQualificationName" runat="server" Text='<%# Eval("QualificationName")%>'></asp:Label>
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
                        <asp:Label ID="lblQualificationDescription" runat="server" Text='<%# Eval("CompetencyKSA")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <span><span style="vertical-align: top;">
                            <asp:TextBox ID="tbQualificationDescription" runat="server" CssClass="TelerikTextFont"
                                TextMode="MultiLine" Rows="10" Width="250px"></asp:TextBox>
                        </span><span style="vertical-align: top;">&nbsp; <span class="required">*</span> </span>
                            <span style="vertical-align: top;">&nbsp;
                                <pde:ToolTip ID="ToolTip58" runat="server" ToolTipID="58" />
                            </span></span>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
                <telerik:GridTemplateColumn HeaderText="Qualification Type" DataField="QualificationTypeName"
                    UniqueName="QualificationTypeName">
                    <ItemStyle VerticalAlign="Top" Wrap="false" />
                    <ItemTemplate>
                        <asp:Label ID="lblQualificationTypeName" runat="server" Text='<%# Eval("QualificationTypeName")%>'></asp:Label>
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
            <%-- <EditFormSettings>
                <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                </EditColumn>
            </EditFormSettings>--%>
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
                        </tr>
                        <tr>
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
                                    OnClientLoad="radEditorQualDescription_OnClientLoad">
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
                                <asp:Button ID="btnUpdate" Text="Save and Close" runat="server" ValidationGroup="KSAValGroup"
                                    OnClientClick="if ( !callConfirm(this))return false;" CausesValidation="false">
                                </asp:Button>&nbsp;
                                <asp:Button ID="btnCancel" Text="Close" runat="server" OnClick="btnCancel_Click"
                                    CausesValidation="False"></asp:Button>
                            </td>
                        </tr>
                    </table>
                </FormTemplate>
            </EditFormSettings>
        </MasterTableView>
        <FilterMenu EnableImageSprites="False">
        </FilterMenu> 
    </telerik:RadGrid>
</asp:Panel>
<span class="spanAction">
    <asp:Button ID="btnContinue" runat="server" CssClass="formBtn" Text="Continue" ToolTip="Continue"
        OnClick="btnContinue_Click" />
</span>
<asp:ObjectDataSource ID="odsQualification" runat="server" SelectMethod="GetObjects"
    TypeName="HCMS.Business.Lookups.QualificationDataSourceBusinessObject"></asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsQualificationType" runat="server" SelectMethod="GetObjects"
    TypeName="HCMS.Business.Lookups.QualificationTypeDataSourceBusinessObject"></asp:ObjectDataSource>
<telerik:RadWindow ID="rwFirstFactorLanguagePopup" runat="server" ReloadOnShow="true"
    Skin="WebBlue" Modal="true" Width="600px" Height="400px" Style="display: none;"
    VisibleOnPageLoad="false" Behaviors="None" InitialBehaviors="None" VisibleStatusbar="False"
    OnClientClose="OnPopupWindowClose">
</telerik:RadWindow>
