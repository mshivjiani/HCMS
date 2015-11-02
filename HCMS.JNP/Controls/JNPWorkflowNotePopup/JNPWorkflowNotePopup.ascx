<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="JNPWorkflowNotePopup.ascx.cs"
    Inherits="HCMS.JNP.Controls.JNPWorkflowNotePopup.JNPWorkflowNotePopup" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadCodeBlock ID="rcbCodeBlock" runat="server">
    <script type="text/javascript">

        function sleep(milliseconds) {
            setTimeout(function () {
                return false; ///or do any thing else
            }, milliseconds);
        } 
        function ShowEditJNPWorkflowNotePopup(url, jnpID, IsInEdit, jnpWorkflowNoteID) {
            var oWnd = $find("<%=rwEditJNPWorkflowNotePopup.ClientID%>");
            oWnd.setUrl(url + "?JNPID=" + jnpID + "&IsInEdit=" + IsInEdit + "&JNPWorkflowNoteID=" + jnpWorkflowNoteID);
            if (IsInEdit == "True") {
                oWnd.set_title("Edit Workflow Note");
            }
            else {
                oWnd.set_title("View Workflow Note");
            }
            oWnd.show();
        }


        function OnClientShow(oWnd, eventArgs) {
            // not used at this time
        }

        function OnClientClose(oWnd, eventArgs) {
            //added the setTimeout to allow db update to happen before refershgrid is called
            //This is to fix the JA issue id 924 :Updating and Changing Status of Notes not appearing to work 
            setTimeout(function () {
               RefreshGrid()
            }, 3000);
       
            
        }

        function RefreshGrid() {
            var masterTable = $find("<%= rgJNPWorkflowNote.ClientID %>").get_masterTableView();
            var rgWN = $find("<%= rgJNPWorkflowNote.ClientID %>");

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

        function JNPWorkflowNotePopupCtrlClose() {
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
                <asp:TextBox ID="txtJNPWorkflowNote" runat="server" TextMode="MultiLine" Width="100%"
                    Rows="4" />
            </td>
            <td align="right" style="vertical-align: bottom;">
                &nbsp;<asp:Button ID="btnAddJNPWorkflowNote" runat="server" Text="&nbsp;Add Note&nbsp;"
                    CssClass="formBtn" OnClick="btnAddJNPWorkflowNote_Click" />
            </td>
        </tr>
    </table>
</asp:Panel>
<telerik:RadAjaxManager ID="radAjaxMgrWorkflowNote" runat="server" EnableAJAX="true">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rwEditJNPWorkflowNotePopup">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgJNPWorkflowNote" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<br />
<div class="sectionTitle">
Revision Note Description:
</div>
<telerik:RadGrid ID="rgJNPWorkflowNote" runat="server" Width="100%" 
    AllowPaging="true" PageSize="5" PagerStyle-AlwaysVisible="false" OnItemDataBound="rgJNPWorkflowNote_ItemDataBound"
    OnNeedDataSource="rgJNPWorkflowNote_NeedDataSource" OnItemCommand="rgJNPWorkflowNote_ItemCommand"
    OnPageIndexChanged="rgJNPWorkflowNote_PageIndexChanged">
    <PagerStyle AlwaysVisible="False" />
    <ItemStyle HorizontalAlign="Center" />
    <AlternatingItemStyle HorizontalAlign="Center" />
    <HeaderStyle HorizontalAlign="Center" />
    <MasterTableView GridLines="Both" Width="100%" DataKeyNames="JNPWorkflowNoteID">
     <NoRecordsTemplate><div>No Revision Notes.</div></NoRecordsTemplate>
        <RowIndicatorColumn>
            <HeaderStyle Width="20px" />
        </RowIndicatorColumn>
        <ExpandCollapseColumn>
            <HeaderStyle Width="20px" />
        </ExpandCollapseColumn>
        <Columns>
            <telerik:GridTemplateColumn UniqueName="Edit" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditJNPWorkflowNote" runat="server"  SkinID="editButton"/>
                </ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridButtonColumn ButtonType="ImageButton" ImageUrl="~/App_Themes/JNP_Default/Images/Icons/icon_delete.gif"
                CommandName="DeleteButtonClicked" CommandArgument="none" UniqueName="gbcDelete"
                Visible="false" />
            <telerik:GridTemplateColumn>
                <ItemStyle VerticalAlign="Top" Width="10" />
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButtonView" runat="server" ToolTip="View" CommandName="View"
                        SkinID="viewButton" /></ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridBoundColumn HeaderText="Workflow Status" UniqueName="JNPWorkflowStatus"
                DataField="JNPWorkflowStatus" DataType="System.String" />
            <telerik:GridBoundColumn HeaderText="Created Date" UniqueName="JNPWorkflowNoteCreateDate"
                DataField="CreateDate" DataFormatString="{0:MM/dd/yyyy}" DataType="System.DateTime" />
            <telerik:GridBoundColumn HeaderText="Created By" UniqueName="JNPWorkflowNoteCreatedBy"
                DataField="CreatedBy" DataType="System.String" />
            <telerik:GridBoundColumn HeaderText="Updated By" UniqueName="JNPWorkflowNoteUpdatedBy"
                DataField="UpdatedBy" DataType="System.String" />
            <telerik:GridBoundColumn HeaderText="Updated Date" UniqueName="JNPWorkflowNoteUpdateDate"
                DataField="UpdateDate" DataFormatString="{0:MM/dd/yyyy}" DataType="System.DateTime" />
            <telerik:GridBoundColumn HeaderText="Note Status" UniqueName="JNPWorkflowNoteStatus"
                DataField="JNPWorkflowNoteStatus" DataType="System.String" />
        </Columns>
    </MasterTableView>
</telerik:RadGrid>
<br />
<span style="visibility: visible; float: right;">
    <asp:Button ID="btnRefreshGrid" runat="server" Visible="false" Text="&nbsp;Refresh&nbsp;"
        ToolTip="Refresh" CssClass="formBtn" OnClick="btnRefreshGrid_Click" />
    <asp:Button ID="btnCloseWorkflowNote" runat="server" Text="&nbsp;Close&nbsp;" ToolTip="Close"
        CssClass="formBtn" OnClientClick="JNPWorkflowNotePopupCtrlClose(); return false;" />
    &nbsp; </span>
<telerik:RadWindow ID="rwEditJNPWorkflowNotePopup" runat="server" ReloadOnShow="true"
    Skin="WebBlue" Modal="True" Width="710px" Height="318px" Style="display: none;"
    VisibleOnPageLoad="false" Behaviors="None" InitialBehaviors="None" VisibleStatusbar="False"
    OnClientShow="OnClientShow" OnClientClose="OnClientClose">
</telerik:RadWindow>
