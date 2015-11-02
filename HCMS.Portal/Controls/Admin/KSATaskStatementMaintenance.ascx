<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KSATaskStatementMaintenance.ascx.cs"
    Inherits="HCMS.Portal.Controls.Admin.KSATaskStatementMaintenance" %>
<%@ Register Src="~/Controls/Admin/ctrlAddSeriesGradeKSATaskStatement.ascx" TagName="ctrlAddSeriesGradeKSATaskStatement"
    TagPrefix="uc1" %>
<%@ Register Src="~/Controls/Admin/ctrlAdminSearchKSA.ascx" TagName="ctrlAdminSearchKSA"
    TagPrefix="uc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadCodeBlock ID="rcbCodeBlock" runat="server">
    <script type="text/javascript">

        var TotalChkBx = 0;
        var Counter = 0;


        function HeaderClick(CheckBox) {
            //Get target base & child control.
            var TargetBaseControl =
       document.getElementById('<%= this.rgTaskStatements.ClientID %>');
            var TargetChildControl = "chkBxSelect";

            //Get all the control of the type INPUT in the base control.
            var Inputs = TargetBaseControl.getElementsByTagName("input");

            //Checked/Unchecked all the checkBoxes in side the GridView.
            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' &&
                Inputs[n].id.indexOf(TargetChildControl, 0) >= 0)
                    Inputs[n].checked = CheckBox.checked;

            //Reset Counter
            Counter = CheckBox.checked ? TotalChkBx : 0;
        }

        function ChildClick(CheckBox, HCheckBox) {
            //get target control.
            var HeaderCheckBox = document.getElementById(HCheckBox);

            //Modifiy Counter; 
            if (CheckBox.checked && Counter < TotalChkBx)
                Counter++;
            else if (Counter > 0)
                Counter--;

            //Change state of the header CheckBox.
            if (Counter < TotalChkBx)
                HeaderCheckBox.checked = false;
            else if (Counter == TotalChkBx)
                HeaderCheckBox.checked = true;
        }

        function ShowAddSeriesGradeKSATSPopUp(SeriesId, GradeId) {
            var oWnd = $find("<%=rwSeriesGradeKSATS.ClientID%>");
            oWnd.setUrl("../Admin/AddSeriesGradeKSATaskStatement.aspx?SeriesId=" + SeriesId + "&GradeId=" + GradeId);
            oWnd.show();
        }

        function ShowSearchKSA() {
            var oWnd = $find("<%=rwrgSearchKSA.ClientID%>");
            SeriesId = (this.document.getElementById('ctl00_mainContent_KSATaskStatementMaintenance1_rcbSeries').value).split("|")[0];
            alert(SeriesId);
            GradeId = (this.document.getElementById('ctl00_mainContent_KSATaskStatementMaintenance1_rcbGrades').value).split("|")[0]
            alert(GradeId);
            oWnd.setUrl("../Admin/SearchKSA.aspx?SeriesId=" + SeriesId + "&CurrentGrade=" + GradeId);
            //            oWnd.show();
        }

        function OnPopupWindowClose(oWnd, eventArgs) {
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

        function ClearExistingKSASearchTextbox() {
            document.getElementById('ctl00_mainContent_KSATaskStatementMaintenance1_txtExistingKSAKeyword').value = '';
        }

        function ClearExistingTSSearchTextbox() {
            document.getElementById('ctl00_mainContent_KSATaskStatementMaintenance1_txtExistingTaskStatementKeyword').value = '';
        }
    </script>
</telerik:RadCodeBlock>
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" UpdatePanelsRenderMode="Inline">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btnDeleteAllTaskStatements">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgKSA" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btnExistingKSAClear">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="btnExistingKSASearch" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btnExistingTaskStatementClear">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="txtExistingTaskStatementKeyword" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rcbGrades">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="lnkSearchKSA" />
                <telerik:AjaxUpdatedControl ControlID="lnkSearchTaskStatement" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rgKSA">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="lnkSearchTaskStatement" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<table style="width: 780px">
    <tr>
        <td>
            Series
            <br />
            <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server">
                <telerik:RadComboBox ID="rcbSeries" runat="server" Width="590" Height="140" OnItemDataBound="rcbSeries_ItemDataBound"
                    AutoPostBack="true">
                </telerik:RadComboBox>
                <asp:Literal ID="SeriesText" runat="server" Visible="false" />
                <asp:RequiredFieldValidator ID="rcbSeriesreqval" runat="server" Display="None" ErrorMessage="Series is required."
                    ControlToValidate="rcbSeries" ValidationGroup="Group2"></asp:RequiredFieldValidator>
            </telerik:RadAjaxPanel>
        </td>
    </tr>
    <tr>
        <td>
            Grades
            <br />
            <asp:UpdatePanel ID="updatePanelrcbGrades" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="rcbSeries" />
                </Triggers>
                <ContentTemplate>
                    <telerik:RadComboBox ID="rcbGrades" runat="server" DataTextField="GradeName" DataValueField="GradeID"
                        Width="390px" AutoPostBack="True" OnSelectedIndexChanged="rcbGrades_SelectedIndexChanged">
                    </telerik:RadComboBox>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td align="right">
            <asp:LinkButton ID="lnkSearchKSA" runat="server" OnClick="lnkSearchKSA_Click">Add New KSA Search</asp:LinkButton>
            <hr />
        </td>
    </tr>
    <tr>
        <td>
            <div class="subTableHeader" runat="server">
                <asp:Label ID="lblExistingKSASearch" runat="server" Text="Existing KSA Search"></asp:Label>
            </div>
            <asp:Panel ID="pnlSearchExistingKSA" runat="server" DefaultButton="btnExistingKSASearch">
                <table class="blueTable" width="100%">
                    <tr>
                        <td>
                            KSA Keyword:
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtExistingKSAKeyword" runat="server" Width="250px">
                            </telerik:RadTextBox>
                            &nbsp; &nbsp;
                            <asp:Button ID="btnExistingKSASearch" runat="server" Text="Search" OnClick="btnExistingKSASearch_Click" />&nbsp;
                            &nbsp;
                            <asp:Button ID="btnExistingKSAClear" runat="server" Text="Clear" OnClick="btnExistingKSAClear_Click"
                                OnClientClick="ClearExistingKSASearchTextbox();" />
                        </td>
                    </tr>
                </table>
                <br />
            </asp:Panel>
            <asp:ValidationSummary ID="valSummary" runat="server" CssClass="validationMessageBox"
                ShowSummary="true" HeaderText="<span class='systemMessage'>Validation Message</span><br>"
                DisplayMode="BulletList" ValidationGroup="internalValidation" />
            <asp:Label ID="lblKSAHeader" runat="server"></asp:Label>
            <asp:UpdatePanel ID="updatePanelrgKSA" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="rcbSeries" />
                    <asp:AsyncPostBackTrigger ControlID="rcbGrades" />
                    <asp:AsyncPostBackTrigger ControlID="btnExistingKSASearch" />
                    <asp:AsyncPostBackTrigger ControlID="btnExistingKSAClear" />
                </Triggers>
                <ContentTemplate>
                    <telerik:RadGrid ID="rgKSA" runat="server" AllowPaging="true" ValidationSettings-EnableValidation="true"
                        ValidationSettings-ValidationGroup="internalValidation" AutoGenerateColumns="False"
                        CellSpacing="0" GridLines="None" OnNeedDataSource="rgKSA_NeedDataSource" OnItemCommand="rgKSA_ItemCommand"
                        OnPreRender="rgKSA_PreRender" OnItemDataBound="rgKSA_ItemDataBound">
                        <MasterTableView Width="100%" DataKeyNames="KSAID">                           
                            <Columns>
                                <telerik:GridTemplateColumn>
                                    <ItemStyle VerticalAlign="Top" Width="10" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButtonEdit" runat="server" ToolTip="Edit" CommandName="Edit"
                                            SkinID="editButton" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridButtonColumn ConfirmText="Delete this ksa?" ConfirmDialogType="RadWindow"
                                    ConfirmTitle="Delete" ButtonType="ImageButton" CommandName="Delete" Text="Delete"
                                    UniqueName="DeleteCommandColumn">
                                    <ItemStyle VerticalAlign="Top" Width="10" />
                                </telerik:GridButtonColumn>
                                <telerik:GridTemplateColumn HeaderText="ID" UniqueName="KSAID" SortExpression="KSAID">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblKSAID" Text='<%# Eval("KSAID") %>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Text" SortExpression="KSAText" UniqueName="KSAText">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblKSAText" Text='<%# Eval("KSAText") %>'></asp:Label>
                                    </ItemTemplate>
                                    <%--<EditItemTemplate>
                                        <telerik:RadTextBox runat="server" ID="rtbEditKSAText" Width="500px" TextMode="MultiLine"
                                            Text='<%#Eval("KSAText") %>' Rows="2">
                                        </telerik:RadTextBox>
                                    </EditItemTemplate>--%>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <EditFormSettings EditFormType="Template">
                                <FormTemplate>
                                    <table id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td width="510px">
                                                <telerik:RadTextBox runat="server" ID="rtbEditKSAText" Width="500px" TextMode="MultiLine"
                                                    Text='<%#Eval("KSAText") %>' Rows="2">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Update" ToolTip="Update"
                                                    ImageAlign="AbsMiddle" ImageUrl="~/App_Themes/HCMS_Default/Images/RAD/Grid/Update.gif">
                                                </asp:ImageButton>&nbsp;&nbsp;&nbsp;
                                                <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Cancel" ToolTip="Cancel"
                                                    ImageAlign="AbsMiddle" ImageUrl="~/App_Themes/HCMS_Default/Images/RAD/Grid/Cancel.gif">
                                                </asp:ImageButton>
                                            </td>
                                        </tr>
                                    </table>
                                </FormTemplate>
                            </EditFormSettings>
                        </MasterTableView>
                        <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="true">
                            <Selecting AllowRowSelect="true" />
                        </ClientSettings>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                    </telerik:RadGrid>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <br />
        <br />
        <td align="right" runat="server">
            <br />
            <asp:LinkButton ID="lnkSearchTaskStatement" runat="server" OnClick="lnkSearchTaskStatement_Click">Add New Task Statment Search</asp:LinkButton>
            <hr />
        </td>
    </tr>
    <tr>
        <td>
            <div class="subTableHeader" runat="server">
                <asp:Label ID="lblExistingTaskStatementSearch" runat="server" Text="Existing TaskStatement Search"></asp:Label>
            </div>
            <asp:Panel ID="pnlSearchExistingTaskStatement" runat="server" DefaultButton="btnExistingTaskStatementSearch">
                <table class="blueTable" width="100%">
                    <tr>
                        <td>
                            TaskStatement Keyword:
                        </td>
                        <td>
                            <telerik:RadTextBox ID="txtExistingTaskStatementKeyword" runat="server" Width="250px">
                            </telerik:RadTextBox>
                            &nbsp; &nbsp;
                            <asp:Button ID="btnExistingTaskStatementSearch" runat="server" Text="Search" OnClick="btnExistingTaskStatementSearch_Click" />&nbsp;
                            &nbsp;
                            <asp:Button ID="btnExistingTaskStatementClear" runat="server" Text="Clear" OnClick="btnExistingTaskStatementClear_Click"
                                OnClientClick="ClearExistingTSSearchTextbox();" />
                        </td>
                    </tr>
                </table>
                <br />
            </asp:Panel>
            <asp:Label ID="lblTaskStatementsHeader" runat="server"></asp:Label>
            <asp:UpdatePanel ID="updatePanelTaskStatements" runat="server" UpdateMode="Always">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="rcbGrades" />
                    <asp:AsyncPostBackTrigger ControlID="rgKSA" />
                    <asp:AsyncPostBackTrigger ControlID="btnExistingKSASearch" />
                    <asp:AsyncPostBackTrigger ControlID="btnExistingKSAClear" />
                    <asp:AsyncPostBackTrigger ControlID="btnExistingTaskStatementSearch" />
                    <asp:AsyncPostBackTrigger ControlID="btnExistingTaskStatementClear" />
                </Triggers>
                <ContentTemplate>
                    <telerik:RadGrid ID="rgTaskStatements" runat="server" OnNeedDataSource="rgTaskStatements_NeedDataSource"
                        OnItemCommand="rgTaskStatements_ItemCommand" AllowPaging="true" AutoGenerateColumns="False"
                        CellSpacing="0" GridLines="None">
                        <MasterTableView Width="780px" DataKeyNames="TaskStatementID">
                            <Columns>
                                <telerik:GridTemplateColumn>
                                    <ItemStyle VerticalAlign="Top" Width="10" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButtonEdit" runat="server" ToolTip="Edit" CommandName="Edit"
                                            SkinID="editButton" />
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Select" SortExpression="">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkBxSelect" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="125px" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="chkBxHeader" onclick="javascript:HeaderClick(this);" runat="server"
                                            Text="Select To Delete" />
                                    </HeaderTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="ID" UniqueName="TaskStatementID" SortExpression="TaskStatementID">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblTaskStatementID" Text='<%# Eval("TaskStatementID") %>'></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                <telerik:GridTemplateColumn HeaderText="Text" SortExpression="TaskStatement" UniqueName="TaskStatement"
                                    DataField="TaskStatement">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="lblTaskStatementText" Text='<%# Eval("TaskStatement") %>'></asp:Label>
                                    </ItemTemplate>
                                    <%-- <EditItemTemplate>
                                        <telerik:RadTextBox runat="server" ID="rtbEditTaskStatementText" Width="500px" TextMode="MultiLine"
                                            Text='<%#Bind("TaskStatement") %>' Rows="3">
                                        </telerik:RadTextBox>
                                    </EditItemTemplate>--%>
                                </telerik:GridTemplateColumn>
                            </Columns>
                            <EditFormSettings EditFormType="Template">
                                <FormTemplate>
                                    <table id="Table2" cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td width="510px">
                                                <telerik:RadTextBox runat="server" ID="rtbEditTaskStatementText" Width="500px" TextMode="MultiLine"
                                                    Text='<%#Bind("TaskStatement") %>' Rows="3">
                                                </telerik:RadTextBox>
                                            </td>
                                            <td>
                                                <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Update" ToolTip="Update"
                                                    ImageAlign="AbsMiddle" ImageUrl="~/App_Themes/HCMS_Default/Images/RAD/Grid/Update.gif">
                                                </asp:ImageButton>&nbsp;&nbsp;&nbsp;
                                                <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Cancel" ToolTip="Cancel"
                                                    ImageAlign="AbsMiddle" ImageUrl="~/App_Themes/HCMS_Default/Images/RAD/Grid/Cancel.gif">
                                                </asp:ImageButton>
                                            </td>
                                        </tr>
                                    </table>
                                </FormTemplate>
                            </EditFormSettings>
                        </MasterTableView>
                        <FilterMenu EnableImageSprites="False">
                        </FilterMenu>
                    </telerik:RadGrid>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td colspan="2" align="right">
            <asp:Button ID="btnDeleteAllTaskStatements" runat="server" Text="Delete Selected TaskStatments"
                OnClick="btnDeleteAllTaskStatements_Click" />
        </td>
    </tr>
</table>
<br />
<div style="float: right">
    <asp:UpdatePanel ID="updatePanel1" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="rcbGrades" />
            <asp:AsyncPostBackTrigger ControlID="rgKSA" />
            <asp:AsyncPostBackTrigger ControlID="rgTaskStatements" />
            <asp:AsyncPostBackTrigger ControlID="btnExistingKSASearch" />
            <asp:AsyncPostBackTrigger ControlID="btnExistingKSAClear" />
            <asp:AsyncPostBackTrigger ControlID="btnExistingTaskStatementSearch" />
            <asp:AsyncPostBackTrigger ControlID="btnExistingTaskStatementClear" />
        </Triggers>
        <ContentTemplate>
            <asp:Label ID="lblmsg" runat="server" Font-Bold="true"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
<asp:ObjectDataSource ID="TaskStatementsObjectDataSource" runat="server" OldValuesParameterFormatString="original_{0}"
    TypeName="HCMS.Business.Admin.SeriesGradeKSATaskStatement" SelectMethod="SelectSeriesGradeKSATaskStatements"
    SelectCountMethod="SelectSeriesGradeKSATaskStatementsTotalCount" EnablePaging="true"
    StartRowIndexParameterName="startRowIndex" MaximumRowsParameterName="maximumRows">
    <SelectParameters>
        <asp:ControlParameter Name="seriesID" Type="Int32" ControlID="rcbSeries" PropertyName="SelectedValue" />
        <asp:ControlParameter Name="gradeID" Type="Int32" ControlID="rcbGrades" PropertyName="SelectedValue" />
        <asp:ControlParameter Name="ksaID" Type="Int64" ControlID="rgKSA" PropertyName="SelectedValue" />
    </SelectParameters>
</asp:ObjectDataSource>
<telerik:RadWindowManager ID="RadWindowManager1" runat="server" Skin="WebBlue">
    <Windows>
        <telerik:RadWindow ID="rwSeriesGradeKSATS" runat="server" RegisterWithScriptManager="true"
            Skin="WebBlue" Height="200px" Width="798px" Behaviors="Close" VisibleStatusbar="false"
            Modal="true" ReloadOnShow="true" OnClientClose="OnPopupWindowClose">
        </telerik:RadWindow>
        <telerik:RadWindow ID="rwrgSearchKSA" runat="server" RegisterWithScriptManager="true"
            Skin="WebBlue" Height="600px" Width="800px" Behaviors="Close" VisibleStatusbar="true"
            Modal="true" ReloadOnShow="true">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>
