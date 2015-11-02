<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlAddEditJADuty.ascx.cs"
    Inherits="HCMS.JNP.Controls.JA.ctrlAddEditJADuty" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="tooltip" %>
<%@ Register Src="~/Controls/Search/ctrlSearchKSA.ascx" TagName="ctrlSearchKSA" TagPrefix="uc1" %>
<style type="text/css">
    .borderlessRadListBox li.rlbItem
    {
        list-style-position: inside;
        list-style-type: square !important;
    }
    .char-counter
    {
        font-weight: bold;
    }
    .tr-testing
    {
        font-weight: normal;
    }
</style>
<script type="text/javascript">
    String.prototype.left = function (n) {
        return this.substring(0, n);
    }

    // Initialize the character counter display
    maxChars = 1500;
    $(document).ready(function () {
        //alert('docReady');
        $(".char-counter").css({ color: 'black' });
        $(".char-counter").text("Character count: 0 (Count cannot exceed " + maxChars + ")");
    });

    function radEditorJAKSADescription_OnClientLoad(editor, args) {
        OnClientLoad(editor, args);
        editor.attachEventHandler("onkeyup", function (e) {
            // Do not call counter function on arrow keys pressed
            if (e.keyCode < 37 || e.keyCode > 40) ShowCharCount(editor, e);
        });
        editor.attachEventHandler("onfocusout", function (e) {
            ShowCharCount(editor, e);
        });
        editor.attachEventHandler("oncontextmenu", function (e) {
            ShowCharCount(editor, e);
        });
        editor.attachEventHandler("onmouseup", function (e) {
            ShowCharCount(editor, e);
        });
    }

    function OnClientLoad(editor, args) {
        editor.removeShortCut("InsertTab");
    }

    function ShowCharCount(editor, e) {
        var content = editor.get_text();
        var charCnt = content.length;
        if (charCnt < maxChars) {
            $(".char-counter").css({ color: 'black' });
        } else {
            editor.set_html(content.left(maxChars));
            charCnt = maxChars;
            $(".char-counter").css({ color: 'red' });
        }
        $(".char-counter").text("Character count: " + charCnt + " (Count cannot exceed " + maxChars + ")");
    }
</script>
<telerik:RadCodeBlock ID="radcodeblockEditDuty" runat="server">
    <script type="text/javascript">
        function ValidateMajorDutyPerc(sender, eventArgs) {

            var perc = eventArgs.Value;
            if (perc == 0) {
                eventArgs.IsValid = false;
                return;
            }
            eventArgs.IsValid = true;
        }
    </script>
</telerik:RadCodeBlock>
<telerik:RadCodeBlock ID="rcbCodeBlock" runat="server">
    <script type="text/javascript">
        function ShowKSAWindowClient(mode, id) {
            var navigateurl;
            var title;

            if (mode == "Insert") {
                navigateurl = "../JA/AddEditJADutyKSA.aspx?mode=Insert&JQFactorID=" + id;
                title = "Add Duty KSA";
            }
            else if (mode == "Edit") {
                navigateurl = "../JA/AddEditJADutyKSA.aspx?mode=Edit&JQFactorID=" + id;
                title = "Edit Duty KSA";
            }
            else {
                navigateurl = "../JA/AddEditJADutyKSA.aspx?mode=View&JQFactorID=" + id;
                title = "View Duty KSA";
            }
            var omanager = GetRadWindowManager();
            var ownd = omanager.getWindowByName('rwJADutyKSA');
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
        function OnWindowClose(oWnd, eventArgs) {
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
        }

    </script>
</telerik:RadCodeBlock>
<telerik:RadWindowManager ID="RadWindowMangerDutyKSA" runat="server" Skin="WebBlue">
    <Windows>
        <telerik:RadWindow ID="rwJADutyKSA" runat="server" RegisterWithScriptManager="true"
            Skin="WebBlue" Height="400px" Width="800px" Behaviors="Close" VisibleStatusbar="false"
            Modal="true" ReloadOnShow="true" OnClientClose="OnPopupWindowClose">
        </telerik:RadWindow>

    </Windows>
    <Windows>
</Windows>
</telerik:RadWindowManager>
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="radcomboPercentageofTime">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="tblJADuty" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnSave">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="tblJADuty" />
                <telerik:AjaxUpdatedControl ControlID="pnlDutyDetail" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="btnRefresh">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="tblJADuty" />
                <telerik:AjaxUpdatedControl ControlID="pnlDutyDetail" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="rgDutyKSA">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgDutyKSA" />
                <telerik:AjaxUpdatedControl ControlID="btnCancel" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="dutyOption_Copy">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="trKSACombo" />
            </UpdatedControls>
        </telerik:AjaxSetting>
        <telerik:AjaxSetting AjaxControlID="dutyOption_Std">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="trKSACombo" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<asp:ValidationSummary ID="valSummary" runat="server" ValidationGroup="DutyValidator"
    DisplayMode="BulletList" CssClass="validationMessageBox" />
<table width="100%" class="blueTable" id="tblJADuty" runat="server">
    <tr>
        <td colspan="2" class="toolTipleft">
            <asp:Label ID="lblDutyDescription" runat="server" AssociatedControlID="RadEditDutyDescription"
                Text="Duty Description: Please include a bulleted list summarizing each major duty statement that does not exceed 3 sentences in length."
                ToolTip="Duty Description"></asp:Label>
            &nbsp;<tooltip:ToolTip ID="ToolTip1" runat="server" ToolTipID="1" />
        </td>
    </tr> 
    <tr>
        <td colspan="2">
            <telerik:RadEditor ID="RadEditDutyDescription" runat="server" OnClientLoad="OnClientLoad">
            </telerik:RadEditor>
            <asp:RequiredFieldValidator ID="RequiredFieldValRadEditDutyDescription" runat="server"
                ControlToValidate="RadEditDutyDescription" ErrorMessage="Duty Description is required."
                ValidationGroup="DutyValidator" Text="*" Display="Dynamic" />
        </td>
    </tr>
    <tr>
        <td class="toolTipleft">
            <asp:Label ID="lblPercentageoftime" runat="server" AssociatedControlID="" Text="Percentage of Time:"
                ToolTip="Percentage of Time"></asp:Label>
            &nbsp;<tooltip:ToolTip ID="ToolTip2" runat="server" ToolTipID="14" />
        </td>
        <td>
            <telerik:RadComboBox ID="radcomboPercentageofTime" runat="server" DataSourceID="xmldsPercentageOfTime"
                DataTextField="p" DataValueField="p" MarkFirstMatch="true" AutoPostBack="true">
            </telerik:RadComboBox>
            <asp:CustomValidator ID="customValrcbPercentageOfTime" runat="server" Text="*" Display="Dynamic"
                ErrorMessage="Percentage of time for a major duty should be greater than zero."
                ValidationGroup="DutyValidator" ControlToValidate="radcomboPercentageofTime"
                ClientValidationFunction="ValidateMajorDutyPerc"></asp:CustomValidator>
        </td>
    </tr>
    <tr align="right">
        <td colspan="2">
            <asp:Label ID="lblmsg" runat="server" Font-Bold="true"></asp:Label><asp:Button ID="btnSave"
                ValidationGroup="DutyValidator" Text="Save" ToolTip="Save" runat="server" OnClick="btnSave_Click" />&nbsp;&nbsp;
        </td>
    </tr>
</table>
<br />
<asp:Panel ID="pnlDutyDetail" runat="server">
    <div runat="server" id="dutyDetail">
        <asp:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="server" TargetControlID="pnlDutyQual"
            CollapsedSize="0" ExpandedSize="150" Collapsed="True" ExpandControlID="LinkDutyQual"
            CollapseControlID="LinkDutyQual" AutoCollapse="False" AutoExpand="False" ScrollContents="True"
            CollapsedText="Show Duty Qualifications..." ExpandedText="Hide Duty Qualifications"
            ImageControlID="Image1" ExpandedImage="~/App_Themes/JNP_Default/images/icons/collapse.jpg"
            CollapsedImage="~/App_Themes/JNP_Default/images/icons/expand.jpg" ExpandDirection="Vertical">
        </asp:CollapsiblePanelExtender>
        <asp:LinkButton ID="LinkDutyQual" runat="server" Text="View Duty Qualifications"></asp:LinkButton>
        <asp:Panel ID="pnlDutyQual" runat="server">
            <telerik:RadGrid ID="rgDutyQual" runat="server" AutoGenerateColumns="False" CellSpacing="0"
                GridLines="None" OnNeedDataSource="rgDutyQual_NeedDataSource" OnItemDataBound="rgDutyQual_ItemDataBound">
                <MasterTableView DataKeyNames="JADutyQualID">
                    <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>
                    <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </RowIndicatorColumn>
                    <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                        <HeaderStyle Width="20px"></HeaderStyle>
                    </ExpandCollapseColumn>
                    <Columns>
                        <telerik:GridBoundColumn DataField="JAQualDescription" FilterControlAltText="Filter JAQualDescription column"
                            HeaderText="Description" SortExpression="JAQualDescription" UniqueName="JAQualDescription">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="QualificationTypeName" FilterControlAltText="Filter QualificationTypeName column"
                            HeaderText="Qualification Type" SortExpression="QualificationTypeName" UniqueName="QualificationTypeName">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="QualificationName" FilterControlAltText="Filter QualificationName column"
                            HeaderText="Qualification" SortExpression="QualificationName" UniqueName="QualificationName">
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
        <br />
        <div id="dutyKSA" class="sectionTitle">
            Duty KSA
        </div>
        <telerik:RadGrid ID="rgDutyKSA" runat="server" 
            AutoGenerateColumns="False" 
            CellSpacing="0"
            GridLines="None" 
            OnItemCommand="rgDutyKSA_ItemCommand" 
            OnNeedDataSource="rgDutyKSA_NeedDataSource"
            OnItemCreated="rgDutyKSA_ItemCreated" 
            OnItemDataBound="rgDutyKSA_ItemDataBound"
            OnPreRender="rgDutyKSA_PreRender">
            
            <MasterTableView 
                CommandItemDisplay="Top" 
                CommandItemSettings-AddNewRecordText="Add New Duty KSA"
                DataKeyNames="JQFactorID" 
                EditMode="EditForms">
                <NoRecordsTemplate>
                </NoRecordsTemplate>
                <CommandItemSettings AddNewRecordText="Add New Duty KSA" ExportToPdfText="Export to PDF" />
                <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                </RowIndicatorColumn>
                <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                </ExpandCollapseColumn>
                <Columns>
                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn column" UniqueName="TemplateColumn">
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImageButtonUpdate" runat="server" CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>'
                                SkinID="updateButton" ToolTip='<%# (Container is GridDataInsertItem) ? "Add KSA" : "Save KSA" %>' />
                            <asp:LinkButton ID="LinkButtonUpdate" runat="server" CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>'
                                Text='<%# (Container is GridDataInsertItem) ? "Add KSA" : "Save KSA" %>'>&gt;Save 
                            Duty</asp:LinkButton>
                            <asp:ImageButton ID="ImageButtonCancel" runat="server" CommandName="Cancel" ToolTip="Cancel" />
                            <asp:LinkButton ID="LinkButtonCancel" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButtonEdit" runat="server" CommandName="Edit" SkinID="editButton"
                                ToolTip="Edit" />
                        </ItemTemplate>
                        <ItemStyle VerticalAlign="Top" Width="10px" />
                    </telerik:GridTemplateColumn>
                    
                    <telerik:GridButtonColumn 
                        ButtonType="ImageButton" 
                        CommandName="Delete" 

                        ImageUrl="~/App_Themes/JNP_Default/Images/Icons/icon_delete.gif"
                        Text="Delete" 
                        UniqueName="DeleteCommandColumn">
                        <ItemStyle VerticalAlign="Top" Width="10" />
                    </telerik:GridButtonColumn>
                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn1 column"
                        UniqueName="ViewCommandColumn">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButtonView" runat="server" CommandName="View" SkinID="viewButton"
                                ToolTip="View" />
                        </ItemTemplate>
                        <ItemStyle VerticalAlign="Top" Width="10px" />
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn2 column"
                        HeaderText="Qualification" UniqueName="TemplateColumn2">
                        <ItemTemplate>
                            <asp:Label ID="lblQualification" runat="server" Text='<% #Eval("QualificationName") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn FilterControlAltText="Filter TemplateColumn3 column"
                        HeaderText="KSA Description" UniqueName="TemplateColumn3">
                        <ItemTemplate>
                            <asp:Label ID="lblJAKSADescription" runat="server" Text='<%#Eval("JQFactorTitle") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Qualification Type">
                        <ItemTemplate>
                            <asp:Label ID="lblQualificationType" runat="server" Text='<% #Eval("QualificationTypeName") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
                <EditFormSettings EditFormType="Template">
                    <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                    </EditColumn>
                    <FormTemplate>
                        <asp:ObjectDataSource ID="odsQualification" runat="server" SelectMethod="GetObjects"
                            TypeName="HCMS.Business.Lookups.QualificationDataSourceBusinessObject"></asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="odsQualificationType" runat="server" SelectMethod="GetObjects"
                            TypeName="HCMS.Business.Lookups.QualificationTypeDataSourceBusinessObject"></asp:ObjectDataSource>
                        <asp:ValidationSummary ID="valSummary" runat="server" CssClass="validationMessageBox"
                            DisplayMode="BulletList" ValidationGroup="AddKSAValGroup" />
                        <asp:Label ID="lblError" runat="server" CssClass="validationMessage"></asp:Label>
                        <table class="blueTable" width="100%">
                             <tr id="row1" runat="server" visible="true">
                                <td class="instruction" colspan="2" style="width:200px">
                                    <asp:Label ID="lblCopyDuty" OnPreRender="lblCopyDuty_PreRender" Text="Add a KSA from your Duty Description above by copying (Ctrl + C) them from your duty, above, and pasting (Ctrl + V) them as KSAs or select from the list of standard KSAs for this series and grade, below.   If you select a standard KSA, you can edit it so that it remains in sync with the duty, above."
                                        runat="server" Visible="true"></asp:Label>
                                </td>
                            </tr>
                            <tr id="trKSADutyOption" runat="server">
                                <td colspan="2">
                                    <span style="border: 1px solid black; padding: 7px 4px 4px 4px;">KSA:
                                        <asp:RadioButton runat="server" AutoPostBack="true" ID="dutyOption_Copy" GroupName="dutyOption"
                                            OnCheckedChanged="dutyOption_Copy_CheckedChanged" Checked="true" Text="Copy from Duty Description" />
                                        <asp:RadioButton runat="server" AutoPostBack="true" ID="dutyOption_Std" GroupName="dutyOption"
                                            OnCheckedChanged="dutyOption_Std_CheckedChanged" Text="Standard KSA Library" />
                                    </span>
                                    <asp:Literal ID="literalSearchmsg" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr id="trKSADD" runat="server" class="tr-testing">
                                <td class="toolTipleft">
                                    KSA:<span class="required">*</span> <span style="vertical-align: top;">&nbsp; </span>
                                    <tooltip:ToolTip ID="ToolTip3" runat="server" ToolTipID="91" />
                                </td>
                                <td>
                                    <table>
                                        <tr id="trKSACombo" runat="server" visible="false">
                                            <td>
                                                <telerik:RadComboBox ID="radcomboKSA" runat="server" AutoPostBack="true" CausesValidation="false"
                                                    DataTextField="KSAText" DataValueField="KSAID" MarkFirstMatch="True" Width="250px"
                                                    ExpandDirection="Down">
                                                </telerik:RadComboBox>
                                                <asp:RequiredFieldValidator ID="radcomboKSAReqVal" runat="server" ControlToValidate="radcomboKSA"
                                                    Display="Dynamic" ErrorMessage="Select KSA First" InitialValue="&lt;&lt;--Select KSA First--&gt;&gt;"
                                                    ValidationGroup="AddKSAValGroup"></asp:RequiredFieldValidator>
                                            </td>
                                            <td id="tdKSASearch" runat="server">
                                                <uc1:ctrlSearchKSA ID="SearchKSA" runat="server" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="toolTipleft" colspan="2">
                                    KSA Description: <span class="required">*</span> <span style="vertical-align: top;">
                                        <tooltip:ToolTip ID="ToolTip4" runat="server" ToolTipID="94" />
                                    </span>
                                    <telerik:RadEditor ID="radEditorJAKSADescription" runat="server" OnClientLoad="radEditorJAKSADescription_OnClientLoad"
                                        OnTextChanged="radEditorJAKSADescription_TextChanged" SkinID="limitedTextRadEditor">
                                    </telerik:RadEditor>
                                    <span id="charCntr2" class="char-counter" runat="server">Character count: 0</span>
                                    <asp:RequiredFieldValidator ID="radEditorJAKSADescriptionReqVal" runat="server" ControlToValidate="radEditorJAKSADescription"
                                        Display="Dynamic" ErrorMessage="KSA Description is required." InitialValue=""
                                        ValidationGroup="AddKSAValGroup" />
                                </td>
                            </tr>
                            <tr>
                                <td class="toolTipleft" style="width:200px">
                                    Qualification:
                                    <tooltip:ToolTip ID="ToolTip5" runat="server" ToolTipID="92" />
                                </td>
                                <td style="text-align:left">
                                    <%-- <telerik:RadComboBox ID="radComboDutyQualID" runat="server" DataSourceID="odsQualification"
                                        DataTextField="QualificationName" DataValueField="QualificationID" SelectedValue='<%# Bind("QualificationID") %>'
                                        Width="200px">
                                    </telerik:RadComboBox>--%>
                                    <telerik:RadComboBox ID="radComboDutyQualID" Width="250px" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td class="toolTipleft" style="width:200px">
                                    <!-- JA issue id 424: On Duty KSA Screen, use tool tip 59 for Qualification Type defintion -->
                                    Qualification Type:
                                    <tooltip:ToolTip ID="ToolTip6" runat="server" ToolTipID="59" />
                                </td>
                                <td style="text-align:left">
                                    <%-- <telerik:RadComboBox ID="radcomboQualificationTypeID" runat="server" 
                                        DataSourceID="odsQualificationType" DataTextField="QualificationTypeName" 
                                        DataValueField="QualificationTypeID" 
                                        SelectedValue='<%# Bind("QualificationTypeID") %>' Width="200px">
                                    </telerik:RadComboBox>--%>
                                   <div style="width:775px !important;"><telerik:RadComboBox ID="radcomboQualificationTypeID" Width="250px" runat="server" /></div>
                                </td>
                            </tr>
                        </table>
                        <table width="98%">
                            <tr align="right">
                                <td>
                                    <asp:Label ID="Label1" runat="server" Font-Bold="true"></asp:Label>
                                    <asp:Button ID="btnUpdate" runat="server" CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>'
                                        Text='<%# (Container is GridDataInsertItem) ? "Add KSA" : "Save KSA" %>' ToolTip='<%# (Container is GridDataInsertItem) ? "Add KSA" : "Save KSA" %>'
                                        ValidationGroup="AddKSAValGroup" />
                                    &nbsp;
                                    <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Cancel"
                                        Text="Close" ToolTip="Close" />
                                </td>
                            </tr>
                        </table>
                    </FormTemplate>
                </EditFormSettings>
            </MasterTableView>
        </telerik:RadGrid>
    </div>
</asp:Panel>
<span class="spanAction">
    <asp:Button ID="btnCancel" runat="server" Text="Close" ToolTip="Close" OnClick="btnCancel_Click"
        Visible="false" CausesValidation="false" />
</span>
<!--re- added btnRefresh - because it is called in js function OnPopupWindowClose()-->
<div style="display: none">
    <asp:Button ID="btnRefresh" runat="server" />
</div>
<asp:XmlDataSource ID="xmldsPercentageOfTime" runat="server" DataFile="~/App_Data/DutyPercentage.xml"
    XPath="Percentages/percentage"></asp:XmlDataSource>
<%--<asp:ObjectDataSource ID="odsQualification" runat="server" SelectMethod="GetObjects"
    TypeName="HCMS.Business.Lookups.QualificationDataSourceBusinessObject"></asp:ObjectDataSource>--%>
<%--<asp:ObjectDataSource ID="odsQualificationType" runat="server" SelectMethod="GetObjects"
    TypeName="HCMS.Business.Lookups.QualificationTypeDataSourceBusinessObject"></asp:ObjectDataSource>--%>
