<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlJQKSA.ascx.cs" Inherits="HCMS.JNP.Controls.JQ.ctrlJQKSA" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadCodeBlock ID="rcbCodeBlock" runat="server">
    <script type="text/javascript">

        function ShowDutyWindowClient(mode, id) {
            var navigateurl;
            var title;

            if (mode == "Insert") {
                navigateurl = "/JQ/AddEditJQKSA.aspx?mode=Insert&JQID=" + id;
                title = "Add Qualification";
            }
            else if (mode == "Edit") {
                navigateurl = "/JQ/AddEditJQKSA.aspx?mode=Edit&JQItemID=" + id;
                title = "Edit Qualification";
            }
            else {
                navigateurl = "/JQ//AddEditJQKSA.aspx?mode=View&JQItemID=" + id;
                title = "View Qualification";
            }
            var omanager = GetRadWindowManager();
            var ownd = omanager.getWindowByName('rwKSA');
            ownd.setUrl(navigateurl);
            ownd.set_title(title);
            ownd.show();
        }

        function OnPopupWindowClose(oWnd, eventArgs) {
            //using this instead of document.location.reload()
            // to avoid getting "resend" warning message
            document.location.href = document.location.href;

        }
    </script>
</telerik:RadCodeBlock>

<telerik:RadWindowManager ID="RadWindowMangerKSA" runat="server" Behaviors="Default"
   Skin="WebBlue" ReloadOnShow="false">
    <Windows>
        <telerik:RadWindow ID="rwKSA" runat="server" RegisterWithScriptManager="true"
            Skin="WebBlue" Height="600px" Width="800px" Behaviors="Close" VisibleStatusbar="false"
            Modal="true" ReloadOnShow="true" OnClientClose="OnPopupWindowClose">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="gridKSA">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="gridKSA" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>

<asp:ObjectDataSource ID="QualificationTypeObjSource" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAllNonKSAFactorTypes" TypeName="HCMS.Business.JQ.JQManager">
</asp:ObjectDataSource>

<telerik:RadGrid ID="gridKSA" runat="server" AllowPaging="true" PageSize="10" GridLines="None" CellSpacing="0" AutoGenerateColumns="False" 
    OnNeedDataSource="gridKSA_NeedDataSource" OnItemCommand="gridKSA_ItemCommand"
    OnItemDataBound="gridKSA_ItemDataBound">
    <MasterTableView DataKeyNames="ID"  EditMode="PopUp"
         >
        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
            <HeaderStyle Width="20px"></HeaderStyle>
        </RowIndicatorColumn>
        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
            <HeaderStyle Width="20px"></HeaderStyle>
        </ExpandCollapseColumn>
        <EditFormSettings CaptionFormatString="Add KSA">
            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
            </EditColumn>
            <PopUpSettings Height="600px" Width="300px" ScrollBars="Vertical" />
        </EditFormSettings>
        <Columns>
            <telerik:GridTemplateColumn UniqueName="EditCommandColumn">
                <ItemStyle VerticalAlign="Top" Width="10" />
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButtonEdit" runat="server" ToolTip="Edit" CommandName="Edit"
                        skinID="editButton" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:ImageButton ID="ImageButtonUpdate" runat="server" ToolTip='<%# (Container is GridDataInsertItem) ? "Add KSA" : "Save KSA" %>'
                        skinID="updateButton" CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>' />
                    <asp:LinkButton ID="LinkButtonUpdate" runat="server" Text='<%# (Container is GridDataInsertItem) ? "Add KSA" : "Save KSA" %>'
                        CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>'>>Save Qualification</asp:LinkButton>
                    <asp:ImageButton ID="ImageButtonCancel" runat="server" ToolTip="Cancel" CommandName="Cancel" />
                    <asp:LinkButton ID="LinkButtonCancel" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                </EditItemTemplate>
            </telerik:GridTemplateColumn>
          <%--  <telerik:GridButtonColumn ConfirmText="Deleting this KSA will also result in the deletion of the associated Task Statements.</br></br>Are you sure?" ConfirmDialogType="RadWindow"
                ConfirmTitle="Delete" 
                ButtonType="ImageButton" CommandName="Delete" Text="Delete" UniqueName="DeleteCommandColumn">
                <ItemStyle VerticalAlign="Top" Width="10" />
            </telerik:GridButtonColumn>--%>
            <telerik:GridTemplateColumn UniqueName="ViewCommandColumn">
                <ItemStyle VerticalAlign="Top" Width="10" />
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButtonView" runat="server" ToolTip="View" CommandName="View"
                        SkinID ="viewButton" /></ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn HeaderText="Qualification Type" SortExpression="FactorTypeID"
                UniqueName="TemplateColumnFactorType" EditFormColumnIndex="0" Visible="false">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblFactorTypeID" Visible="false" Text='<%# Eval("FactorTypeID", "{0}") %>'></asp:Label>
                    <asp:Label runat="server" ID="blbFactorTypeName" Visible="true" Text='<%# Eval("FactorTypeName", "{0}") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label runat="server" ID="lblFactorTypeID" Visible="false" Text='<%# Eval("FactorTypeID", "{0}") %>'></asp:Label>
                    <asp:Label runat="server" ID="blbFactorTypeName" Visible="true" Text='<%# Eval("FactorTypeName", "{0}") %>'></asp:Label>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <telerik:RadComboBox ID="rcbFactorTypes" runat="server" AutoPostBack="true" NoWrap="false"
                        DropDownWidth="677px" Width="162px" DataValueField="ID" DataTextField="Name"
                        DataSourceID="QualificationTypeObjSource">
                    </telerik:RadComboBox>
                </InsertItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn HeaderText="Title" SortExpression="Title" UniqueName="TemplateColumnTitle"
                EditFormColumnIndex="0">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblQualificationTitle" Text='<%# Eval("Title", "{0:s}") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <telerik:RadTextBox ID="txtTitle" Text='<%# Eval("Title", "{0:s}") %>' Width="480"
                        runat="server">
                    </telerik:RadTextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <telerik:RadTextBox ID="txtTitle" Text="" Width="480" runat="server">
                    </telerik:RadTextBox>
                </InsertItemTemplate>
            </telerik:GridTemplateColumn>
<%--            <telerik:GridTemplateColumn HeaderText="Instruction" SortExpression="Instruction"
                UniqueName="TemplateColumnInstruction" EditFormColumnIndex="0">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblQualificationInstruction" Text='<%# Eval("Instruction", "{0:s}") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <telerik:RadEditor ID="radEditorQualificationDesc" runat="server" SkinID="shortRadEditor"
                        OnClientLoad="OnClientLoad">
                    </telerik:RadEditor>
                    <asp:RequiredFieldValidator ID="radEditorQualificationDescReqVal" runat="server"
                        ControlToValidate="radEditorQualificationDesc" Display="Dynamic" InitialValue=""
                        ErrorMessage="Instruction is required." />
                    <telerik:RadTextBox ID="txtInstruction" Text='<%# Eval("Instruction", "{0:s}") %>'
                        Width="480" runat="server">
                    </telerik:RadTextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <telerik:RadTextBox ID="txtInstruction" Text="" Width="480" runat="server">
                    </telerik:RadTextBox>
                </InsertItemTemplate>
            </telerik:GridTemplateColumn>--%>
            <telerik:GridBoundColumn HeaderText="No.Of Associated Task Statements" DataField="CountOfFactorQuestions"></telerik:GridBoundColumn>
        </Columns>
        <EditFormSettings>
            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
            </EditColumn>
        </EditFormSettings>
    </MasterTableView>
    <FilterMenu EnableImageSprites="False">
    </FilterMenu>
</telerik:RadGrid>

<span class="spanAction">
<asp:Button ID="btnContinue" runat="server" CssClass="formBtn" Text="Continue"
            ToolTip="Continue" onclick="btnContinue_Click" />
</span>

