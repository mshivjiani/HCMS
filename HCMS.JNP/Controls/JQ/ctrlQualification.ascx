<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlQualification.ascx.cs" Inherits="HCMS.JNP.Controls.JQ.ctrlQualification" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadCodeBlock ID="rcbCodeBlock" runat="server">
    <script type="text/javascript">

        function ShowDutyWindowClient(mode, id) {
            var navigateurl;
            var title;

            if (mode == "Insert") {
                navigateurl = "../JQ/AddEditQualification.aspx?mode=Insert&JQID=" + id;
                title = "Add Qualification";
            }
            else if (mode == "Edit") {
                navigateurl = "../JQ/AddEditQualification.aspx?mode=Edit&JQItemID=" + id;
                title = "Edit Qualification";
            }
            else {
                navigateurl = "../JQ/AddEditQualification.aspx?mode=View&JQItemID=" + id;
                title = "View Qualification";
            }
            var omanager = GetRadWindowManager();
            var ownd = omanager.getWindowByName('rwQualifications');
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

<telerik:RadWindowManager ID="RadWindowMangerQualifications" runat="server" Behaviors="Default"
   Skin="WebBlue" ReloadOnShow="false" >
    <Windows>
        <telerik:RadWindow ID="rwQualifications" runat="server" RegisterWithScriptManager="true"
            Skin="WebBlue" Height="600px" Width="800px" Behaviors="Close" VisibleStatusbar="false"
            Modal="true" ReloadOnShow="true" OnClientClose="OnPopupWindowClose">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="gridQualifications">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="gridQualifications" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>

<asp:ObjectDataSource ID="QualificationTypeObjSource" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAllNonKSAFactorTypes" TypeName="HCMS.Business.JQ.JQManager">
</asp:ObjectDataSource>

<telerik:RadGrid ID="gridQualifications" runat="server" 
    AllowPaging="true" 
    PageSize="10" 
    GridLines="None" 
    CellSpacing="0" 
    AutoGenerateColumns="False" 
    OnNeedDataSource="gridQualifications_NeedDataSource" 
    OnItemCommand="gridQualifications_ItemCommand"
    OnItemDataBound="gridQualifications_ItemDataBound"  >
    <MasterTableView DataKeyNames="ID" >
        <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
        <CommandItemSettings AddNewRecordText ="Add New Qualification" />
        <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
            <HeaderStyle Width="20px"></HeaderStyle>
        </RowIndicatorColumn>
        <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
            <HeaderStyle Width="20px"></HeaderStyle>
        </ExpandCollapseColumn>
        <EditFormSettings CaptionFormatString="Add Qualification">
            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
            </EditColumn>
            <PopUpSettings Height="600px" Width="300px" ScrollBars="Vertical" />
        </EditFormSettings>
        <Columns>
            <telerik:GridTemplateColumn UniqueName="EditCommandColumn">
                <ItemStyle VerticalAlign="Middle" Width="10" />
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButtonEdit" runat="server" 
                        ToolTip="Edit" 
                        CommandName="Edit"
                        skinID="editButton" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:ImageButton ID="ImageButtonUpdate" runat="server" 
                        ToolTip='<%# (Container is GridDataInsertItem) ? "Add Qualification" : "Save Qualification" %>'
                        skinID="updateButton" CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>' />
                    <asp:LinkButton ID="LinkButtonUpdate" runat="server" 
                        Text='<%# (Container is GridDataInsertItem) ? "Add Qualification" : "Save Qualification" %>'
                        CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>'>>Save Qualification</asp:LinkButton>
                    <asp:ImageButton ID="ImageButtonCancel" runat="server" 
                        ToolTip="Cancel" 
                        CommandName="Cancel" />
                    <asp:LinkButton ID="LinkButtonCancel" runat="server" 
                        CommandName="Cancel">
                        Cancel
                    </asp:LinkButton>
                </EditItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridButtonColumn 
                UniqueName="DeleteCommandColumn"
                ConfirmText="Deleting this KSA will delete associated Qualification Statements on the Job Questionnaire. Are you sure you want to continue?" 
                ConfirmDialogType="RadWindow"
                ConfirmTitle="Delete" 
                ButtonType="ImageButton" 
                CommandName="Delete" 
                Text="Delete">
                <ItemStyle VerticalAlign="Top" Width="10" />
            </telerik:GridButtonColumn>
            <telerik:GridTemplateColumn UniqueName="ViewCommandColumn">
                <ItemStyle VerticalAlign="Middle" Width="10" />
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButtonView" runat="server" ToolTip="View" CommandName="View"
                        SkinID ="viewButton" /></ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn HeaderText="Qualification Type" SortExpression="FactorTypeID"
                UniqueName="TemplateColumnFactorType" EditFormColumnIndex="0">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblFactorTypeID" Visible="false" Text='<%# Eval("FactorTypeID", "{0}") %>'></asp:Label>
                    <asp:Label runat="server" ID="blbFactorTypeName" Visible="true" Text='<%# Eval("FactorTypeName", "{0}") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:Label runat="server" ID="lblFactorTypeID" Visible="false" Text='<%# Eval("FactorTypeID", "{0}") %>'></asp:Label>
                    <asp:Label runat="server" ID="blbFactorTypeName" Visible="true" Text='<%# Eval("FactorTypeName", "{0}") %>'></asp:Label>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <telerik:RadComboBox ID="rcbFactorTypes" runat="server" 
                        AutoPostBack="true" 
                        NoWrap="false"
                        DropDownWidth="677px" 
                        Width="162px" 
                        DataValueField="ID" 
                        DataTextField="Name"
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
            <telerik:GridBoundColumn HeaderText="No.Of Associated Qualification Statements" DataField="CountOfFactorQuestions"></telerik:GridBoundColumn>
        </Columns>
        <EditFormSettings>
            <EditColumn FilterControlAltText="Filter EditCommandColumn column">
            </EditColumn>
        </EditFormSettings>
    </MasterTableView>
    <FilterMenu EnableImageSprites="False">
    </FilterMenu>
</telerik:RadGrid>

 <asp:Panel ID="pnlQual" runat="server" Visible="true" Width="100%">
  <div class="subTableHeader" width="100%">
  </div>
     <telerik:RadGrid ID="gridQuestions" runat="server" AutoGenerateColumns="False" 
         CellSpacing="0"  GridLines="None"  Width="100%" OnItemDataBound="gridQuestions_ItemDataBound">
         <MasterTableView DataKeyNames="ID" >
             <CommandItemSettings ExportToPdfText="Export to PDF" />
             <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" 
                 Visible="True">
                 <HeaderStyle Width="20px" />
             </RowIndicatorColumn>
             <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" 
                 Visible="True">
                 <HeaderStyle Width="20px" />
             </ExpandCollapseColumn>
             <Columns>
                   <telerik:GridBoundColumn DataField="ItemText" 
                     FilterControlAltText="Filter Question column" 
                     HeaderText="Question" SortExpression="ItemText" 
                     UniqueName="ItemText">
                 </telerik:GridBoundColumn>
                 <telerik:GridBoundColumn DataField="RatingScaleName" 
                     FilterControlAltText="Filter Rating Scale column" HeaderText="Rating Scale" 
                     SortExpression="RatingScaleName" UniqueName="RatingScaleName">
                 </telerik:GridBoundColumn>
             </Columns>
             <EditFormSettings>
                 <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                 </EditColumn>
             </EditFormSettings>
         </MasterTableView>
         <FilterMenu EnableImageSprites="False">
         </FilterMenu>
     </telerik:RadGrid>
 </asp:Panel>


<span class="spanAction">
<asp:Button ID="btnContinue" runat="server" CssClass="formBtn" Text="Continue"
            ToolTip="Continue" onclick="btnContinue_Click" />
</span>
