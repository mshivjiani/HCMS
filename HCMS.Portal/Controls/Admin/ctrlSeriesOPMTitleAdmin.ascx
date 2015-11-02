<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlSeriesOPMTitleAdmin.ascx.cs" Inherits="HCMS.Portal.Controls.Admin.CtrlSeriesOPMTitleAdmin" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="tooltip" %>

<telerik:RadCodeBlock ID="radcodeblockEdiOPMTitle" runat="server">
    <script type="text/javascript">
        function OnClientLoad(editor, args) {
            editor.removeShortCut("InsertTab");
        }

        function ShowSeriesOPMTitleWindowClient(mode, id) {
            var navigateurl;
            var title;

            if (mode == "Insert") {
                navigateurl = "../Admin/AddSeriesOPMTitle.aspx?mode=Insert&SeriesId=" + id;
                title = "Add Series OPM Title";
            }
            else if (mode == "Edit") {
                navigateurl = "../Admin/AddSeriesOPMTitle.aspx?mode=Edit&SeriesId=" + id;
                title = "Edit Series OPM Title";
            }
            else {
                navigateurl = "../Admin/AddSeriesOPMTitle.aspx?mode=View&SeriesId=" + id;
                title = "View Series OPM Title";
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
    </script>
</telerik:RadCodeBlock>

<telerik:RadWindowManager ID="RWM" runat="server" Skin="WebBlue">
    <Windows>
        <telerik:RadWindow ID="rwQ" runat="server" RegisterWithScriptManager="true"
            Skin="WebBlue" Height="400px" Width="990px" Behaviors="Close" VisibleStatusbar="false"
            Modal="true"  OnClientClose="OnPopupWindowClose">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>

<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btnSave">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="tblSeries" />                
                <telerik:AjaxUpdatedControl ControlID="pnlOPMTitles" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnRefresh">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="tblSeries" />                
                <telerik:AjaxUpdatedControl ControlID="pnlOPMTitles" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="gridOPMTitles">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="gridOPMTitles" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<table width="100%" class="blueTable" id="tblSeries" runat="server">
    <tr>
        <td>
            <asp:Label ID="Label2" runat="server" AssociatedControlID="rcbSeries"
                Text="Series:" ToolTip="Series"></asp:Label> &nbsp;<tooltip:ToolTip ID="ToolTip3" runat="server" ToolTipID="76" />
        </td>
        <td>
            <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server">
                <telerik:RadComboBox ID="rcbSeries" runat="server" AutoPostBack="true" Width="590" Height="140" 
                EmptyMessage="Type Series" onselectedindexchanged="rcbSeries_SelectedIndexChanged">
                </telerik:RadComboBox>
            </telerik:RadAjaxPanel>
        </td>
    </tr>
<%--
    <tr>
        <td>
            <asp:Label ID="Label1" runat="server" AssociatedControlID="txtTitle"
                Text="KSA Title" ToolTip="KSA Title"></asp:Label>&nbsp;<tooltip:ToolTip ID="ToolTip1" runat="server" ToolTipID="93" />
        </td>
        <td>
            <telerik:RadTextBox ID="txtTitle" runat="server" Width="453px"></telerik:RadTextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="TitleValidationGroup"
                ControlToValidate="txtTitle" ErrorMessage="KSA Title is required."
                Text="*" Display="Dynamic" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Label ID="lblKSAInstruction" runat="server" AssociatedControlID="RadEditKSAInstruction"
                Text="KSA Instruction" ToolTip="KSA Instruction"></asp:Label>&nbsp;<tooltip:ToolTip ID="ToolTip2" runat="server" ToolTipID="94" />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <telerik:RadEditor ID="RadEditKSAInstruction" runat="server" OnClientLoad="OnClientLoad">
            </telerik:RadEditor>
            <asp:RequiredFieldValidator ID="RequiredFieldValRadEditKSAInstruction" runat="server"
                ControlToValidate="RadEditKSAInstruction" ErrorMessage="KSA Instruction is required."
                Text="*" Display="Dynamic" />
        </td>
    </tr>
--%>
    <tr align="right">
        <td colspan="2">
            <asp:Label ID="lblmsg" runat="server" Font-Bold="true">
            </asp:Label>
        </td>
    </tr>
</table>
<div class="sectionTitle">
    OPM Titles
</div>
<asp:UpdatePanel ID="gridPanel" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="rcbSeries" />                    
                </Triggers>
                <ContentTemplate>
                    <telerik:RadGrid ID="gridOPMTitles" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                        GridLines="None" OnItemCommand="gridOPMTitles_ItemCommand" OnNeedDataSource="gridOPMTitles_NeedDataSource">
                        <MasterTableView DataKeyNames="SeriesID" CommandItemDisplay="Top" CommandItemSettings-AddNewRecordText="Add New OPM Title"
                            EditMode="PopUp" TableLayout="Auto">
                            <CommandItemSettings AddNewRecordText="Add New OPM Title" ExportToPdfText="Export to PDF">
                            </CommandItemSettings>
                            <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </RowIndicatorColumn>
                            <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                                <HeaderStyle Width="20px"></HeaderStyle>
                            </ExpandCollapseColumn>
                            <Columns>
                                <telerik:GridTemplateColumn Visible="false">
                                    <ItemStyle VerticalAlign="Top" Width="10" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButtonEdit" runat="server" ToolTip="Edit" CommandName="Edit"
                                            SkinID="editButton" />
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:ImageButton ID="ImageButtonUpdate" runat="server" ToolTip='<%# (Container is GridDataInsertItem) ? "Add OPM Title" : "Save OPM Title" %>'
                                            SkinID="updateButton" CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>' />
                                        <asp:LinkButton ID="LinkButtonUpdate" runat="server" Text='<%# (Container is GridDataInsertItem) ? "Add OPM Title" : "Save OPM Title" %>'
                                            CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>'>>Save OPM Title</asp:LinkButton>
                                        <asp:ImageButton ID="ImageButtonCancel" runat="server" ToolTip="Cancel" CommandName="Cancel" />
                                        <asp:LinkButton ID="LinkButtonCancel" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                                    </EditItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridButtonColumn ConfirmText="Delete this OPM Title?" ConfirmDialogType="RadWindow"
                                    ImageUrl="~/App_Themes/JNP_Default/Images/Icons/icon_delete.gif" ConfirmTitle="Delete"
                                    ButtonType="ImageButton" CommandName="Delete" Text="Delete" UniqueName="DeleteCommandColumn" Visible="false">
                                    <ItemStyle VerticalAlign="Top" Width="10" />
                                </telerik:GridButtonColumn>
                                <telerik:GridTemplateColumn HeaderText="OPM Title" Visible="true">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSeriesID" runat="server" Visible="false" Text='<%# Eval("SeriesID", "{0}") %>'></asp:Label>
                                        <asp:Label ID="lblOPMTitle" runat="server"  Text='<%# Eval("OPMTitle", "{0:s}") %>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                    </telerik:RadGrid>
    </ContentTemplate>
</asp:UpdatePanel>
<div style="display: none">
    <asp:Button ID="btnRefresh" runat="server" />
</div>

