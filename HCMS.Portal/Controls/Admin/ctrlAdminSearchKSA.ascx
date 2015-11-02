<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlAdminSearchKSA.ascx.cs"
    Inherits="HCMS.Portal.Controls.Admin.ctrlAdminSearchKSA" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Admin/ctrlAdminSearchTaskStatement.ascx" TagName="ctrlAdminSearchTaskStatement"
    TagPrefix="uc2" %>
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdatePanelsRenderMode="Inline">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btnKSASearch">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="txtKSAKeyword" />
                <telerik:AjaxUpdatedControl ControlID="lblKSAHeader" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btnKSAClear">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="txtKSAKeyword" />
                <telerik:AjaxUpdatedControl ControlID="radKSAComboGrades" />
                <telerik:AjaxUpdatedControl ControlID="lblKSAHeader" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<telerik:RadCodeBlock ID="rcbCodeBlock" runat="server">
    <script type="text/javascript">

        // Initialize the character counter display
        maxChars = 1500;
        $(document).ready(function () {
            $(".char-counter").css({ color: 'black' });
            $(".char-counter").text("Character count: 0 (Count cannot exceed " + maxChars + ")");

        });

        var charLength = 0;
        function radEditorQualDescription_OnClientLoad(editor, args) {

            editor.attachEventHandler("onkeyup", function (e) {
                // Do not call counter function on arrow keys pressed
                if (e.keyCode < 37 || e.keyCode > 40) ShowCharCount(editor, e);
            });
//            editor.attachEventHandler("onfocusout", function (e) {
//                ShowCharCount(editor, e);
//            });
//            editor.attachEventHandler("oncontextmenu", function (e) {
//                ShowCharCount(editor, e);
//            });
//            editor.attachEventHandler("onmouseup", function (e) {
//                ShowCharCount(editor, e);
//            });

           
        }

        function ShowCharCount(editor, e) {
            var content = editor.get_text();
            var charCnt = content.length;
            if (charCnt < maxChars) {
                $("#charCntr").css({ color: 'black' });
            } else {
                //editor.set_html(content.left(maxChars));
                charCnt = maxChars;
                $("#charCntr").css({ color: 'red' });
            }
            $(".char-counter").text("Character count: " + charCnt + " (Count cannot exceed " + maxChars + ")");

            if (charCnt >= maxChars) {

                alert("Characters exceeded 1500 chars. Please make is short.");

                return false;
            }
        }

        function ClearExistingKSASearchTextbox() {
            document.getElementById('ctl00_mainContent_ctrlAdminSearchKSA_txtKSAKeyword').value = '';
        }

    </script>
</telerik:RadCodeBlock>
<div class="subTableHeader" id="divWorkflowRuleInfo" runat="server">
    Search KSA
</div>
<table class="blueTable" width="100%">
    <tr>
        <td>
            Current Series :
        </td>
        <td>
            <asp:Label ID="lblCurrentSeries" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            Current Grade:
        </td>
        <td>
            <asp:Label ID="lblCurrentGrade" runat="server"></asp:Label>
        </td>
    </tr>
</table>
<br />
<asp:Panel ID="pnlSearchExistingKSA" runat="server" DefaultButton="btnKSASearch">
    <table class="blueTable" width="100%">
        <tr>
            <td>
                KSA Keyword:
            </td>
            <td>
                <telerik:RadTextBox ID="txtKSAKeyword" runat="server" Width="250px">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>
                Select Grade(s):
            </td>
            <td>
                <telerik:RadComboBox ID="radKSAComboGrades" CheckBoxes="true" EnableCheckAllItemsCheckBox="true"
                    runat="server" DataTextField="GradeName" DataValueField="GradeID">
                </telerik:RadComboBox>
                &nbsp; &nbsp;
                <asp:Button ID="btnKSASearch" runat="server" Text="Search" OnClick="btnKSASearch_Click" />&nbsp;
                &nbsp;
                <asp:Button ID="btnKSAClear" runat="server" Text="Clear" OnClick="btnKSAClear_Click"
                    OnClientClick="ClearExistingKSASearchTextbox" />
            </td>
        </tr>
    </table>
</asp:Panel>
<br />
<br />
<cc1:Accordion ID="accKSA" runat="server" AutoSize="None" RequireOpenedPane="false"
    SelectedIndex="1" HeaderCssClass="blueAccordionHeader" HeaderSelectedCssClass="blueAccordionHeaderSelected">
    <Panes>
        <cc1:AccordionPane ID="accPanelNetNewKSA" runat="server">
            <Header>
                <asp:Label ID="lblHeaderNetNewKSA" runat="server">Add Net New KSA</asp:Label>
            </Header>
            <Content>
                <asp:Panel runat="server" ID="pnlNetNewKSA">
                    <table class="blueTable" width="100%">
                        <tr>
                            <td>
                                KSA Text
                            </td>
                            <td>
                                <telerik:RadEditor ID="txtNetNewKSADescription" runat="server" SkinID="limitedTextRadEditor"
                                    OnClientLoad="radEditorQualDescription_OnClientLoad">
                                </telerik:RadEditor>
                                <span id="charCntr" class="char-counter" runat="server">Character count: 0</span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:Label ID="lblNewKSAMsg" runat="server" Font-Bold="true"></asp:Label>
                                <asp:Button ID="Button1" runat="server" Text="Select Task Statements" OnClick="btnSelectTSForNetNewKSA_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </Content>
        </cc1:AccordionPane>
        <cc1:AccordionPane ID="accPanelKSA" runat="server">
            <Header>
                <asp:Label ID="lblHeaderKSA" runat="server">Associate Existing KSA with TaskStatements</asp:Label>
            </Header>
            <Content>
                <asp:Panel runat="server" ID="pnlKSA" Width="99%">
                    <div>
                        <br />
                        <asp:Label ID="lblKSAHeader" runat="server" class="subTableHeader"></asp:Label>
                    </div>
                    <asp:UpdatePanel ID="updatePanelrgKSA" runat="server" UpdateMode="Conditional">
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnKSASearch" />
                            <asp:AsyncPostBackTrigger ControlID="btnKSAClear" />
                        </Triggers>
                        <ContentTemplate>
                            <telerik:RadGrid ID="rgSearchKSA" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                                AllowPaging="true" GridLines="None" Width="99%" OnItemCommand="rgSearchKSA_ItemCommand"
                                OnInsertCommand="rgSearchKSA_InsertCommand" OnNeedDataSource="rgSearchKSA_NeedDataSource">
                                <MasterTableView DataKeyNames="KSAID">
                                    <CommandItemSettings ExportToPdfText="Export to PDF" />
                                    <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                                        <HeaderStyle Width="20px" />
                                    </RowIndicatorColumn>
                                    <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                                        <HeaderStyle Width="20px" />
                                    </ExpandCollapseColumn>
                                    <Columns>
                                        <telerik:GridTemplateColumn HeaderText="Click To Select Task Statements" HeaderStyle-HorizontalAlign="Center"
                                            ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle" HeaderStyle-VerticalAlign="Middle">
                                            <ItemStyle VerticalAlign="Top" Width="10" />
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButtonEdit" runat="server" ToolTip="Add TaskStatements"
                                                    CommandName="Edit" SkinID="addButton" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:ImageButton ID="ImageButtonUpdate" runat="server" ToolTip='<%# (Container is GridDataInsertItem) ? "Add KSA" : "Save KSA" %>'
                                                    SkinID="updateButton" CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>' />
                                                <asp:LinkButton ID="LinkButtonUpdate" runat="server" Text='<%# (Container is GridDataInsertItem) ? "Add KSA" : "Save KSA" %>'
                                                    CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>'>Save KSA</asp:LinkButton>
                                                <asp:ImageButton ID="ImageButtonCancel" runat="server" ToolTip="Cancel" CommandName="Cancel" />
                                                <asp:LinkButton ID="LinkButtonCancel" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                                            </EditItemTemplate>
                                        </telerik:GridTemplateColumn>
                                        <telerik:GridBoundColumn DataField="KSAID" FilterControlAltText="Filter column column"
                                            HeaderText="KSAID" SortExpression="KSAID" UniqueName="KSAID">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="KSAText" FilterControlAltText="Filter column column"
                                            HeaderText="KSAText" SortExpression="KSAText" UniqueName="KSAText">
                                        </telerik:GridBoundColumn>
                                    </Columns>
                                </MasterTableView>
                                <FilterMenu EnableImageSprites="False">
                                </FilterMenu>
                            </telerik:RadGrid>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <div style="float: right">
                        <br />
                        <asp:Label ID="lblmsg" runat="server" Font-Bold="true"></asp:Label>
                    </div>
                </asp:Panel>
            </Content>
        </cc1:AccordionPane>
    </Panes>
</cc1:Accordion>
<br />
<div style="float: right">
    <asp:Button ID="btnSearchKSACancel" runat="server" Text="Cancel" OnClick="btnSearchKSACancel_Click" />
</div>
<telerik:RadWindowManager ID="RadWindowManagerSearchKSA" runat="server" Behaviors="Default"
    Skin="WebBlue" ReloadOnShow="false">
    <Windows>
        <telerik:RadWindow ID="rwrgSearchKSA" runat="server" RegisterWithScriptManager="true"
            Skin="WebBlue" Height="600px" Width="800px" Behaviors="Close" VisibleStatusbar="false"
            Modal="true" ReloadOnShow="true">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>
