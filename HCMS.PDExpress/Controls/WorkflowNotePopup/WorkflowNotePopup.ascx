<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="WorkflowNotePopup.ascx.cs"
    Inherits="HCMS.PDExpress.Controls.WorkflowNotePopup.WorkflowNotePopup" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadCodeBlock ID="rcbCodeBlock" runat="server">

    <script type="text/javascript">
//        function ShowEditWorkflowNotePopup(positionDescriptionID, isCheckedOut, workflowNoteID) {
//            var oWnd = $find("<%=rwEditWorkflowNotePopup.ClientID%>");
//            oWnd.setUrl("./EditWorkflowNotePopup.aspx?PositionDescriptionID=" + positionDescriptionID + "&IsCheckedOut=" + isCheckedOut + "&WorkflowNoteID=" + workflowNoteID);
//            oWnd.show();
//        }

        //Added CheckedOutByID
        function ShowEditWorkflowNotePopup(positionDescriptionID, isCheckedOut, workflowNoteID, CheckedOutByID) {
            var oWnd = $find("<%=rwEditWorkflowNotePopup.ClientID%>");
            oWnd.setUrl("./EditWorkflowNotePopup.aspx?PositionDescriptionID=" + positionDescriptionID + "&IsCheckedOut=" + isCheckedOut + "&WorkflowNoteID=" + workflowNoteID + "&CheckedOutByID=" + CheckedOutByID);
            oWnd.show();
        }

        
        function OnClientShow(oWnd, eventArgs) {
            // not used at this time
        }

        function OnClientClose(oWnd, eventArgs) {
            
            RefreshGrid();

        }
        function RefreshGrid() {

            var masterTable = $find("<%= rgWorkflowNote.ClientID %>").get_masterTableView();
            var rgWN = $find("<%= rgWorkflowNote.ClientID %>");

            if (masterTable) {

                masterTable.rebind();


            }

        }
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.radWindow;
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow;
            return oWindow;
        }
        function WorkflowNotePopupCtrlClose() {
            GetRadWindow().close();
        }
    </script>

</telerik:RadCodeBlock>
<asp:Panel ID="panelAdd" runat="server" Style="border-bottom: solid 1px #9cb6c5;">
    <table class="popupTable" width="100%">
        <col width="90%" />
        <tr>
            <td colspan="2">
                <div class="sectionTitle">
                    Add New Revision Note Description
                </div>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: bottom;">
                <asp:TextBox ID="txtWorkflowNote" runat="server" TextMode="MultiLine" Width="100%"
                    Rows="4" />
            </td>
            <td align="right" style="vertical-align: bottom;">
                &nbsp;<asp:Button ID="btnAddWorkflowNote" runat="server" Text="&nbsp;Add Note&nbsp;"
                    CssClass="formBtn" OnClick="btnAddWorkflowNote_Click" />
            </td>
        </tr>
    </table>
</asp:Panel>
<telerik:RadAjaxManager ID="radAjaxMgrWorkflowNote" runat="server" EnableAJAX="true">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rwEditWorkflowNotePopup">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgWorkflowNote" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<br />
<div class="sectionTitle">
    Update Revision Note Description:
</div>
<telerik:RadGrid ID="rgWorkflowNote" runat="server" SkinID="customRADGridView" Width="100%"
    Height="266px" AllowPaging="true" PageSize="5" PagerStyle-AlwaysVisible="false"
    OnItemDataBound="rgWorkflowNote_ItemDataBound"
    OnNeedDataSource="rgWorkflowNote_NeedDataSource" OnItemCommand="rgWorkflowNote_ItemCommand"
    OnPageIndexChanged="rgWorkflowNote_PageIndexChanged">
    <PagerStyle AlwaysVisible="False" />
    <ItemStyle HorizontalAlign="Center" />
    <AlternatingItemStyle HorizontalAlign="Center" />
    <HeaderStyle HorizontalAlign="Center" />
    <MasterTableView GridLines="Both" Width="100%" DataKeyNames="WorkflowNoteID">
        <RowIndicatorColumn>
            <HeaderStyle Width="20px" />
        </RowIndicatorColumn>
        <ExpandCollapseColumn>
            <HeaderStyle Width="20px" />
        </ExpandCollapseColumn>
        <Columns>
            <telerik:GridTemplateColumn UniqueName="Edit" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditWorkflowNote" runat="server" SkinID ="editButton"  />
                </ItemTemplate>
            </telerik:GridTemplateColumn>
     
            <telerik:GridBoundColumn HeaderText="Workflow Status" UniqueName="WorkflowStatus"
                DataField="WorkflowStatus" DataType="System.String" />
            <telerik:GridBoundColumn HeaderText="Created Date" UniqueName="WorkflowNoteCreateDate"
                DataField="CreateDate" DataFormatString="{0:MM/dd/yyyy}" DataType="System.DateTime" />
            <telerik:GridBoundColumn HeaderText="Created By" UniqueName="WorkflowNoteCreatedBy"
                DataField="CreatedBy" DataType="System.String" />
            <telerik:GridBoundColumn HeaderText="Updated By" UniqueName="WorkflowNoteUpdatedBy"
                DataField="UpdatedBy" DataType="System.String" />
            <telerik:GridBoundColumn HeaderText="Updated Date" UniqueName="WorkflowNoteUpdateDate"
                DataField="UpdateDate" DataFormatString="{0:MM/dd/yyyy}" DataType="System.DateTime" />
            <telerik:GridBoundColumn HeaderText="Note Status" UniqueName="WorkflowNoteStatus"
                DataField="NoteStatus" DataType="System.String" />
        </Columns>
    </MasterTableView>
</telerik:RadGrid>
<br />
<span style="visibility: visible; float: right;">
    <asp:Button ID="btnRefreshGrid" runat="server" Visible="false" Text="&nbsp;Refresh&nbsp;"
        ToolTip="Refresh" CssClass="formBtn" OnClick="btnRefreshGrid_Click" />
    <asp:Button ID="btnCloseWorkflowNote" runat="server" Text="&nbsp;Close&nbsp;" ToolTip="Close"
        CssClass="formBtn" OnClientClick="WorkflowNotePopupCtrlClose(); return false;" />
    &nbsp; </span>
<telerik:RadWindow ID="rwEditWorkflowNotePopup" runat="server" ReloadOnShow="true"
    Skin="WebBlue" Modal="True" Width="710px" Height="318px" Style="display: none;"
    VisibleOnPageLoad="false" Behaviors="None" InitialBehaviors="None" VisibleStatusbar="False"
    OnClientShow="OnClientShow" OnClientClose="OnClientClose">
</telerik:RadWindow>
