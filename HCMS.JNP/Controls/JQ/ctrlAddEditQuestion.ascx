<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlAddEditQuestion.ascx.cs" Inherits="HCMS.JNP.Controls.JQ.ctrlAddEditQuestion" %>
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
</script>
 <asp:ValidationSummary ID="valSummary" runat="server" DisplayMode="BulletList" CssClass="validationMessageBox" />

<table width="100%" class="blueTable" id="tblQuestion" runat="server">
       <tr>
        <td>
            <asp:Label ID="Label1" runat="server" AssociatedControlID="txtQuestion"
                Text="Qualification Statement" ToolTip="Qualification Statement Title"></asp:Label>&nbsp;<tooltip:ToolTip ID="ToolTip1" runat="server" ToolTipID="180" />
        </td>
        <td>
            <telerik:RadTextBox ID="txtQuestion" runat="server" Width="90%" Rows="5" TextMode="MultiLine" ></telerik:RadTextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                ControlToValidate="txtQuestion" ErrorMessage="Qualification Statement is required."
                Text="*" Display="Dynamic" />
        </td>
    </tr>

    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" AssociatedControlID="rcbRatingScaleType"
                Text="Response Type " ToolTip="Response Type"></asp:Label>&nbsp;<tooltip:ToolTip ID="ToolTip2" runat="server" ToolTipID="115" />
        </td>
        <td>
            <telerik:RadComboBox ID="rcbRatingScaleType" runat="server" AutoPostBack="true" NoWrap="false"
                Width="329px" onselectedindexchanged="rcbRatingScaleType_SelectedIndexChanged">
            </telerik:RadComboBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                ControlToValidate="rcbRatingScaleType" ErrorMessage="Rating Scale is required."
                Text="*" Display="Dynamic" />
        </td>
    </tr>

    <tr>
        <td>
            <asp:Label ID="Label3" runat="server" AssociatedControlID="txtInstruction"
                Text="Instructions" ToolTip="Instructions"></asp:Label>&nbsp;<tooltip:ToolTip ID="ToolTip3" runat="server" ToolTipID="116" />
        </td>
        <td>
            <telerik:RadTextBox ID="txtInstruction" runat="server" Enabled="true" ReadOnly="true" Width="90%" Rows="5" TextMode="MultiLine" ></telerik:RadTextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValtxtInstruction" runat ="server" ControlToValidate ="txtInstruction"
             ErrorMessage ="Instructions are required." Text ="*" Display ="Dynamic" ></asp:RequiredFieldValidator>
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
<div runat="server" id="questionDetail">
    <telerik:RadGrid ID= "gridResponses" runat="server" AllowPaging="true" CellSpacing="0"
        GridLines="None" OnNeedDataSource="gridResponses_NeedDataSource"   
        OnDeleteCommand="gridResponses_DeleteCommand"
        OnItemDataBound="gridResponses_ItemDataBound" 
        OnUpdateCommand="gridResponses_UpdateCommand" 
        onitemcommand="gridResponses_ItemCommand" >
        <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
            <Selecting AllowRowSelect="true" />
        </ClientSettings>
        <MasterTableView AutoGenerateColumns="False" DataKeyNames="ID" EditMode="InPlace"  CommandItemDisplay="Top" CommandItemSettings-AddNewRecordText="Add New Response" >
                  <EditFormSettings ColumnNumber="3" CaptionFormatString="Edit Response: {0}"
                CaptionDataField="ResponseLetter" EditColumn-Display="false"   >
                <FormTableItemStyle Wrap="False"></FormTableItemStyle>
                <FormCaptionStyle CssClass="EditFormHeader"></FormCaptionStyle>
                <FormMainTableStyle GridLines="None" CellSpacing="0" CellPadding="3" Width="100%">
                </FormMainTableStyle>
                <FormTableStyle GridLines="Horizontal" CellSpacing="0" CellPadding="2" CssClass="module"
                    Height="110px" Width="100%"></FormTableStyle>
                <FormTableAlternatingItemStyle Wrap="False"></FormTableAlternatingItemStyle>
                <FormStyle Width="100%" BackColor="#eef2ea"></FormStyle>
                <EditColumn Display="false"  Visible="false"></EditColumn>
            
            </EditFormSettings>       
            <Columns>
                <telerik:GridTemplateColumn >
                    <ItemStyle VerticalAlign="Top" Width="10" />
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButtonEdit" runat="server" ToolTip="Edit" CommandName="Edit"
                            SkinID="editButton" />
                    </ItemTemplate>
                    <EditItemTemplate>
                       <asp:ImageButton ID="ImageButtonUpdate" runat="server" ToolTip='<%# (Container is GridDataInsertItem) ? "Add Response" : "Save Response" %>'
                            skinID="updateButton" CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>' />
                        <asp:LinkButton ID="LinkButtonUpdate" runat="server" Text='<%# (Container is GridDataInsertItem) ? "Add Response" : "Save Response" %>'
                            CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>'>>Save Response</asp:LinkButton>
                        <asp:ImageButton ID="ImageButtonCancel" runat="server" ToolTip="Cancel" SkinID ="cancelButton"    CommandName="Cancel" />
                        <asp:LinkButton ID="LinkButtonCancel" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
  
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>               
                <telerik:GridButtonColumn  Text="Delete" 
                ButtonType="ImageButton"  CommandName="Delete" ConfirmText="Delete this response?" ConfirmDialogType="RadWindow"
                    ConfirmTitle="Delete" ImageUrl="~/App_Themes/JNP_Default/Images/Icons/icon_delete.gif" >
                    <ItemStyle HorizontalAlign="Center"  Width="30" />
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
                            Width="620" runat="server" Rows="5" TextMode ="MultiLine" >
                        </telerik:RadTextBox>
                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
      

        </MasterTableView>
    </telerik:RadGrid>
</div>
<span class="spanAction">
    <asp:Button ID="btnCancel" runat="server" Text="Close" ToolTip="Close" OnClick="btnCancel_Click"
        CausesValidation="false" />
</span>
<%--<div style="display: none">
    <asp:Button ID="btnRefresh" runat="server" OnClick="btnRefresh_Click" />
</div>
--%>
<%--<asp:ObjectDataSource ID="RatingScaleTypeObjSource" runat="server" OldValuesParameterFormatString="original_{0}"
    SelectMethod="GetAllRatingScaleTypes" TypeName="HCMS.Business.Lookups.LookupManager">
</asp:ObjectDataSource>
--%>