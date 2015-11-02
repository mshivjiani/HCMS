<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlAdminSearchTaskStatement.ascx.cs"
    Inherits="HCMS.Portal.Controls.Admin.ctrlAdminSearchTaskStatement" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<telerik:RadCodeBlock ID="radcodeblockAddNewTaskStatement" runat="server">
    <script type="text/javascript">
        var TotalChkBx = 0;
        var Counter = 0;


        function HeaderClick(CheckBox) {
            //Get target base & child control.
            var TargetBaseControl =
       document.getElementById('<%= this.rgSearchTS.ClientID %>');
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

        function ClearExistingTSSearchTextbox() {
            document.getElementById('ctl00_mainContent_ctrlAdminSearchTaskStatement_txtTSKeyword').value = '';
        }
    </script>
</telerik:RadCodeBlock>
<telerik:RadAjaxManager ID="mainAJAXManager" runat="server" UpdatePanelsRenderMode="Inline">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rgSearchTS">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="chkTaskStatement" />
                <telerik:AjaxUpdatedControl ControlID="btnAddTaskStatement" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btnTSSearch">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="txtTSKeyword" />
                <telerik:AjaxUpdatedControl ControlID="lblTSHeader" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="btnTSClear">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="txtTSKeyword" />
                <telerik:AjaxUpdatedControl ControlID="radTSComboGrades" />
                <telerik:AjaxUpdatedControl ControlID="lblTSHeader" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<div class="subTableHeader" id="divWorkflowRuleInfo" runat="server">
    Search Task Statement
</div>
<asp:Panel ID="pnlSearchTS" runat="server">
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
</asp:Panel>
<asp:Panel ID="pnlSearchExistingKSA" runat="server" DefaultButton="btnTSSearch">
    <table class="blueTable" width="100%">
        <tr id="trCurrentKSA" runat="server">
            <td>
                Selected KSA:
            </td>
            <td>
                <asp:Label ID="lblCurrentKSA" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                TaskStatement Keyword:
            </td>
            <td>
                <telerik:RadTextBox ID="txtTSKeyword" runat="server" Width="250px">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                Select All Task Statements for Current KSA:
                <asp:RadioButton ID="rbFilterByKSA" runat="server" GroupName="rbSeriesKSATaskStatements"
                    Checked="true" />&nbsp;&nbsp;&nbsp;&nbsp; Select All Task Statements for Current
                Series:
                <asp:RadioButton ID="rbFilterBySeries" runat="server" GroupName="rbSeriesKSATaskStatements" />
            </td>
        </tr>
        <tr>
            <td>
                Select Grade(s):
            </td>
            <td>
                <telerik:RadComboBox ID="radTSComboGrades" CheckBoxes="true" EnableCheckAllItemsCheckBox="true"
                    runat="server" DataTextField="GradeName" DataValueField="GradeID">
                </telerik:RadComboBox>
                &nbsp; &nbsp;
                <asp:Button ID="btnTSSearch" runat="server" Text="Search" OnClick="btnTSSearch_Click"
                    UseSubmitBehavior="true" />&nbsp; &nbsp;
                <asp:Button ID="btnTSClear" runat="server" Text="Clear" OnClick="btnTSClear_Click"
                    OnClientClick="ClearExistingTSSearchTextbox();" />
            </td>
        </tr>
    </table>
</asp:Panel>
<div>
    <br />
    <asp:Label ID="lblTSHeader" runat="server" class="subTableHeader"></asp:Label>
</div>
<asp:UpdatePanel ID="updatePanelrgKSA" runat="server" UpdateMode="Conditional">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnTSSearch" />
        <asp:AsyncPostBackTrigger ControlID="btnTSClear" />
    </Triggers>
    <ContentTemplate>
        <telerik:RadGrid ID="rgSearchTS" runat="server" AutoGenerateColumns="False" CellSpacing="0"
            AllowPaging="true" GridLines="None" OnNeedDataSource="rgSearchTS_NeedDataSource"
            OnItemCommand="rgSearchTS_ItemCommand" OnRowCreated="rgSearchTS_RowCreated">
            <MasterTableView DataKeyNames="TaskStatementID" CommandItemDisplay="Top" EditMode="EditForms"
                EditFormSettings-EditFormType="AutoGenerated" CommandItemSettings-ShowRefreshButton="false"
                CommandItemSettings-AddNewRecordText="Add New TaskStatement">
                <CommandItemSettings ExportToPdfText="Export to PDF" />
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridTemplateColumn>
                        <ItemStyle VerticalAlign="Top" Width="10" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Select" SortExpression="">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkBxSelect" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="50px" />
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkBxHeader" onclick="javascript:HeaderClick(this);" Text="Select To Add"
                                runat="server" />
                        </HeaderTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="ID" SortExpression="TaskStatement" UniqueName="TaskStatement">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblTaskStatementID" Text='<%# Eval("TaskStatementID") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Text" SortExpression="TaskStatement" UniqueName="TaskStatement">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="lblTaskStatement" Text='<%# Eval("TaskStatement") %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtOtherTaskStatementDescription" runat="server" Rows="5" Width="500px"
                                TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="requiredKSAText" runat="server" Display="None" ErrorMessage="TaskStatement Text is required."
                                ControlToValidate="txtOtherTaskStatementDescription" ValidationGroup="internalValidation" />
                        </EditItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
                <EditFormSettings>
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                    </EditColumn>
                </EditFormSettings>
            </MasterTableView>
            <ClientSettings AllowKeyboardNavigation="true" EnablePostBackOnRowClick="false">
                <Selecting AllowRowSelect="true" />
            </ClientSettings>
            <FilterMenu EnableImageSprites="False">
            </FilterMenu>
        </telerik:RadGrid>
    </ContentTemplate>
</asp:UpdatePanel>
<div style="float: right">
    <asp:Button ID="btnAddTaskStatement" runat="server" Text="Add TaskStatment" OnClick="btnAddTaskStatement_Click" />
    <asp:Button ID="btnTaskStatementCancel" runat="server" Text="Cancel" OnClick="btnTaskStatementCancel_Click" />
    <br />
    <asp:Label ID="lblmsg" runat="server" Font-Bold="true"></asp:Label>
</div>
<telerik:RadWindowManager ID="RadWindowManagerSearchTS" runat="server" Behaviors="Default"
    Skin="WebBlue" ReloadOnShow="false">
    <Windows>
        <telerik:RadWindow ID="rwrgSearchTS" runat="server" RegisterWithScriptManager="true"
            Skin="WebBlue" Height="600px" Width="800px" Behaviors="Close" VisibleStatusbar="false"
            Modal="true" ReloadOnShow="true">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>
