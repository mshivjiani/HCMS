<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlAddEditKSAQuestion.ascx.cs"
    Inherits="HCMS.JNP.Controls.JQ.ctrlAddEditKSAQuestion" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="tooltip" %>
<script type="text/javascript" language="javascript">
    function GetRadWindow() {
        var oWindow = null;
        if (window.radWindow)
            oWindow = window.radWindow;
        else if (window.frameElement.radWindow)
            oWindow = window.frameElement.radWindow;
        return oWindow;
    }
    function EditQuestionClose() {
        GetRadWindow().close();
    }
    function OnClientLoad(editor, args) {
        editor.removeShortCut("InsertTab");
    }

    function ShowAddToLibraryPopUp() {       
        var oWnd = $find("<%=rwAddToLibrary.ClientID%>");
        oWnd.setUrl("../JQ/ctrlAddEditKSAQuestion.ascx");
        oWnd.show();
    }
</script>
<telerik:RadWindowManager ID="RWM" runat="server" Skin="WebBlue">
    <Windows>
        <telerik:RadWindow ID="rwAddToLibrary" runat="server" VisibleOnPageLoad="false" Height="150px"
            RegisterWithScriptManager="true" Width="300px" VisibleStatusbar="false" Modal="true"
            ReloadOnShow="true" Behaviors="None" Title="Add To Library">
            <ContentTemplate>
                <table class="blueTable" id="Table1" runat="server" width="100%">
                    <tr>
                        <td colspan="3">
                            Are you sure you want to Add to Library?
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2">
                            <asp:Button ID="btnAddToLibraryOk" runat="server" Text="Yes" Width="50px" OnClick="btnAddToLibraryOk_Click" />
                        </td>
                        <td align="left">
                            &nbsp;&nbsp;&nbsp;<asp:Button ID="btnAddToLibraryCancel" runat="server" Text="No"
                                Width="50px" OnClick="btnAddToLibraryCancel_Click" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>
<asp:ValidationSummary ID="valSummary" runat="server" DisplayMode="BulletList" CssClass="validationMessageBox" />

<table width="100%" class="blueTable" id="tblQuestion" runat="server">
   
    <tr id="trTaskStatementSelection">
        <td>
            <asp:Label ID="Label3" runat="server" AssociatedControlID="rcbTaskStatements" Text="Task Statement"
                ToolTip="Task Statement"></asp:Label>&nbsp;<tooltip:ToolTip ID="ToolTip1" runat="server"
                    ToolTipID="121" />
        </td>
        <td>
            <telerik:RadComboBox ID="rcbTaskStatements" runat="server" AutoPostBack="true" NoWrap="false"
                CausesValidation="false" Width="448px" OnSelectedIndexChanged="rcbTaskStatements_SelectedIndexChanged">
            </telerik:RadComboBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTaskStatments" runat="server"
                InitialValue="Please Select..." ControlToValidate="rcbTaskStatements" ErrorMessage="Tasks Statement is required."
                Text="*" Display="Dynamic" />
            <asp:Button ID="btnAddToLibrary" runat="server" Text="Add To Library" Visible="false"
                OnClientClick="ShowAddToLibraryPopUp();return false;" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" AssociatedControlID="txtQuestion" Text="Task Statement"
                ToolTip="Task Statement"></asp:Label>&nbsp;<tooltip:ToolTip ID="ToolTip2" runat="server"
                    ToolTipID="181" />
        </td>
        <td>
            <telerik:RadTextBox ID="txtQuestion" runat="server" Width="90%" TextMode="MultiLine">
            </telerik:RadTextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorQuestion" runat="server" ControlToValidate="txtQuestion"
                ErrorMessage="Task Statement is required." Text="*" Display="Dynamic" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" AssociatedControlID="rcbRatingScaleType" Text="Response Type"
                ToolTip="Response Type"></asp:Label>&nbsp;<tooltip:ToolTip ID="ToolTip3" runat="server"
                    ToolTipID="115" />
        </td>
        <td>
            <telerik:RadComboBox ID="rcbRatingScaleType" runat="server" AutoPostBack="true" NoWrap="false"
                Width="329px" DataValueField="ID" DataTextField="Name" OnSelectedIndexChanged="rcbRatingScaleType_SelectedIndexChanged">
            </telerik:RadComboBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="rcbRatingScaleType"
                ErrorMessage="Response Type is required." Text="*" Display="Dynamic" />
        </td>
    </tr>



    <tr>
        <td>
            <asp:Button ID="btnShowInst" runat="server" 
                onclick="btnShowInst_Click" Text="Show Instruction" />
        </td>
    </tr>
    <tr ID="inst" runat="server">
        <td>
            <div style="width: 85px;">
                <asp:Label ID="Label4" runat="server" AssociatedControlID="txtInstruction" Text="Instructions"
                    ToolTip="Instructions"></asp:Label>&nbsp;<tooltip:ToolTip ID="ToolTip4" runat="server"
                        ToolTipID="116" />
            </div>
        </td>
    </tr>
    <tr ID="instText" runat="server">
        <td>
            <telerik:RadTextBox ID="txtInstruction" runat="server" Enabled="true" ReadOnly="true" Width="90%"
                Rows="5" TextMode="MultiLine">
            </telerik:RadTextBox>
        </td>
    </tr>

    
    
    
    <tr align="right">
        <td colspan="2">
            <asp:Label ID="lblmsg" runat="server" Font-Bold="true"></asp:Label><asp:Button ID="btnSave"
                Text="Save" ToolTip="Save" runat="server" OnClick="btnSave_Click" />&nbsp;&nbsp;
        </td>
    </tr>
</table>
<br />
<div id="divSection" class="sectionTitle" runat="server">
    Responses
</div>
<telerik:RadGrid ID="gridResponses" runat="server" AllowPaging="True" CellSpacing="0"
    GridLines="None" OnNeedDataSource="gridResponses_NeedDataSource" OnDeleteCommand="gridResponses_DeleteCommand"
    OnItemDataBound="gridResponses_ItemDataBound" OnUpdateCommand="gridResponses_UpdateCommand"
    OnItemCommand="gridResponses_ItemCommand" ShowDesignTimeSmartTagMessage="False">
    <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
        <Selecting AllowRowSelect="true" />
    </ClientSettings>
    <MasterTableView AutoGenerateColumns="False" DataKeyNames="ID" EnableLinqGrouping="False"
        EnableSplitHeaderText="False" EditMode="InPlace" CommandItemDisplay="Top" CommandItemSettings-AddNewRecordText="Add New Response">
        <CommandItemSettings ExportToPdfText="Export to PDF" ShowAddNewRecordButton="True"
            ShowRefreshButton="False"></CommandItemSettings>
        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
        </RowIndicatorColumn>
        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
        </ExpandCollapseColumn>
        <Columns>
            <telerik:GridTemplateColumn UniqueName="EditCommandColumn" EditFormHeaderTextFormat="">
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
            <telerik:GridButtonColumn UniqueName="DeleteCommandColumn" Text="Delete" ButtonType="ImageButton"
                CommandName="Delete" ConfirmText="Delete this response?" ConfirmDialogType="RadWindow"
                ConfirmTitle="Delete" ImageUrl="~/App_Themes/JNP_Default/Images/Icons/icon_delete.gif"
                EditFormHeaderTextFormat="">
                <ItemStyle HorizontalAlign="Center" CssClass="GridImageButton" Width="30" />
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
                        Width="620" runat="server" TextMode="MultiLine">
                    </telerik:RadTextBox>
                </EditItemTemplate>
            </telerik:GridTemplateColumn>
        </Columns>
        <EditFormSettings ColumnNumber="3" CaptionFormatString="Edit Response: {0}" CaptionDataField="ResponseLetter">
            <FormTableItemStyle Wrap="False"></FormTableItemStyle>
            <FormCaptionStyle CssClass="EditFormHeader"></FormCaptionStyle>
            <FormMainTableStyle GridLines="None" CellSpacing="0" CellPadding="3" Width="100%">
            </FormMainTableStyle>
            <FormTableStyle GridLines="Horizontal" CellSpacing="0" CellPadding="2" CssClass="module"
                Height="110px" Width="100%"></FormTableStyle>
            <FormTableAlternatingItemStyle Wrap="False"></FormTableAlternatingItemStyle>
            <EditColumn UniqueName="EditCommandColumn1" FilterControlAltText="Filter EditCommandColumn1 column">
            </EditColumn>
            <FormStyle Width="100%" BackColor="#eef2ea"></FormStyle>
            <FormTableButtonRowStyle HorizontalAlign="Left"></FormTableButtonRowStyle>
            <PopUpSettings ShowCaptionInEditForm="False" />
        </EditFormSettings>
    </MasterTableView>
    <FooterStyle BackColor="#FF33CC" BorderStyle="Dotted" BorderWidth="10px" />
    <FilterMenu EnableImageSprites="False">
    </FilterMenu>
</telerik:RadGrid>
<span class="spanAction">
    <asp:Button ID="btnCancel" runat="server" Text="Close" ToolTip="Close" OnClick="btnCancel_Click"
        CausesValidation="false" />
</span>