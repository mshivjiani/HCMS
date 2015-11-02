<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EditDuty.ascx.cs" Inherits="HCMS.PDExpress.Controls.CreatePD.Duties.EditDuty" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="pde" %>
<%@ Register Src="~/Controls/Search/ctrlSearchKSA.ascx" TagPrefix="uc1" TagName="ctrlSearchKSA" %>

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

    function radEditorQualDescription_OnClientLoad(editor, args) {
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

    function ShowCharCount(editor,e) {
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

<style type="text/css" >
.borderlessRadListBox li.rlbItem 
{
    list-style-position:inside ;
    list-style-type: square  !important;
    
}
.char-counter 
{
    font-weight: bold;
}
</style>



<telerik:RadCodeBlock ID="RadCodeBlockEditDuty" runat="server">

    <script type="text/javascript">
        function OnDutyTypeSelectedIndexChanged(sender, eventArgs) {
            var item = eventArgs.get_item();
            var rcbPercOfTime = $find("<%= rcbPercentageOfTime.ClientID %>");
            rcbPercOfTime.enable();

            var dutytypeid = item.get_value();
            if (dutytypeid == "2") {
                rcbPercOfTime.set_value("0");
                rcbPercOfTime.disable();
            }
        }
        function ValidateMajorDutyPerc(sender, eventArgs) {

            var perc = eventArgs.Value;
            var rcbDutyType = $find("<%=rcbDutyType.ClientID %>");
            if (rcbDutyType.get_value() == "1" && perc == 0) {
                eventArgs.IsValid = false;
                return;
            }
            eventArgs.IsValid = true;
        }

        function PopUpShowing(sender, eventArgs) {
            var popUp = eventArgs.get_popUp();
            
        }
        function OnRGDutyQualCommand(sender, eventArgs) {
            var commandname = eventArgs.get_commandName();
           
        }
        function ScrollToBottom(sender) {
            var oWnd = GetRadWindow();
            window.scrollTo(0, document.body.scrollHeight);           
       }
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.radWindow;
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow;
            return oWindow;
        }


        function ShowDutyQualWindow(mode, navigateurl) {
            var title;
            if (mode == "Insert") {                       
                title = "Add Duty KSA";
            }
            else {
                title = "Edit Duty KSA";
            }
            var omanager = GetRadWindowManager();
            var ownd = omanager.getWindowByName('rwDutyQual');
            ownd.setUrl(navigateurl);
            ownd.set_title(title);
            ownd.show();
        }
        function OnPopupWindowClose(oWnd, eventArgs) {
            if (eventArgs.get_argument() != null) {
                var arr = eventArgs.get_argument().split('|');
                var mode = arr[0];
                var id = arr[1];
                $get("<%=btnRefresh.ClientID%>").click();

            }
            else {
                document.location.reload();
            }
        }

    </script>

</telerik:RadCodeBlock>
<asp:XmlDataSource ID="xmldsPercentageOfTime" runat="server" 
    DataFile="~/App_Data/DutyPercentage.xml"
    XPath="Percentages/percentage">
</asp:XmlDataSource>
<asp:ObjectDataSource ID="odsDutyType" runat="server" 
    SelectMethod="GetObjects" 
    TypeName="HCMS.Business.Lookups.DutyTypeDataSourceBusinessObject">
</asp:ObjectDataSource>

<%--Adding this to style delete confirm window--%>
<telerik:RadWindowManager ID="RadWindowManager1" runat="server" Skin="WebBlue">
<Windows>
 <telerik:RadWindow ID="rwDutyQual" runat="server" RegisterWithScriptManager="true"
            Skin="WebBlue" Height="600px" Width="865px" Behaviors="Close" VisibleStatusbar="false"
            Modal="true" ReloadOnShow="true" OnClientClose="OnPopupWindowClose">
        </telerik:RadWindow>
</Windows>
</telerik:RadWindowManager>

<asp:UpdatePanel ID="updtPanelDuty" runat="server">
    <ContentTemplate>
        <table class="blueTable" width="100%">
         
            <tr>
                <td colspan="4"  class="toolTipleft">
                    Description:
                    <pde:ToolTip ID="ToolTip13" runat="server" ToolTipID="13"/>
                </td>
                <tr>
                    <td colspan="4">
                        <telerik:RadEditor ID="RadEditDutyDescription" runat="server" NewLineMode="Br" OnPreRender="RadEditDutyDescription_PreRender" OnClientLoad="OnClientLoad"></telerik:RadEditor>
                        <asp:RequiredFieldValidator ID="RequiredFieldValRadEditDutyDescription" runat="server"
                            ControlToValidate="RadEditDutyDescription" ErrorMessage="Duty Description is required."
                            Text="*" Display="Dynamic" />
                    </td>
                </tr>
                <tr><td colspan="4"><br /></td></tr>
                <tr >
                    <td class="toolTipleft" >
                        Duty Type: <span style="vertical-align: top;">&nbsp;<pde:ToolTip ID="ToolTip16" runat="server" ToolTipID="16"/></span>
                    </td>
                    <td>
                        <telerik:RadComboBox ID="rcbDutyType" runat="server" DataSourceID="odsDutyType" DataValueField="DutyTypeID"
                            DataTextField="DutyTypeName" Width="200px" OnClientSelectedIndexChanged="OnDutyTypeSelectedIndexChanged" />
                    </td>
                    <td class="toolTipleft">
                        Percentage Of Time: <span style="vertical-align: top;">&nbsp;<pde:ToolTip ID="ToolTip14" runat="server" ToolTipID="14" /></span>
                    </td>
                    <td>
                        <telerik:RadComboBox ID="rcbPercentageOfTime" runat="server" DataSourceID="xmldsPercentageOfTime"
                            DataValueField="p" DataTextField="p" Width="200px" />
                        <asp:CustomValidator ID="customValrcbPercentageOfTime" runat="server" Text="*" Display="Dynamic"
                            ErrorMessage="Percentage of time for a major duty should be greater than zero."
                            ControlToValidate="rcbPercentageOfTime" ClientValidationFunction="ValidateMajorDutyPerc"></asp:CustomValidator>
                    </td>
                </tr>
                <tr align="right">
                    <td colspan="4"> 
                    <asp:Label ID="lblmsg" runat="server" Font-Bold="true" ></asp:Label>
                        <asp:Button ID="btnSave" Text="Save" ToolTip="Save" runat="server" OnClick="btnSave_Click" />&nbsp;&nbsp;
                        <asp:Button ID="btnClose" runat="server" Text="Close" ToolTip="Close" OnClick ="btnClose_Click" CausesValidation ="false"   />
                    </td>
                </tr>
            </table>
        <br />
        <asp:Panel ID="pnlDutyQual" runat ="server">
        <div style="font-weight: bolder; color: Red; margin: 15px 5px;">
    NOTE: Make sure you include these KSAs in your Factor 1 language on the factor screen. 
</div>
        <div class="sectionTitle">
            KSAs
        </div>



        <telerik:RadGrid ID="RGDutyQual" runat="server" SkinID="customRADGridView" Width="100%"   
            AllowPaging="True" PageSize="5" PagerStyle-AlwaysVisible="false" AllowSorting ="false"  GridLines="None"
            OnItemCommand       = "RGDutyQual_ItemCommand"
            OnNeedDataSource    = "RGDutyQual_NeedDataSource" 
            onitemdatabound     = "RGDutyQual_ItemDataBound" 
            oniteminserted      = "RGDutyQual_ItemInserted" 
            onitemupdated       = "RGDutyQual_ItemUpdated" 
            OnPreRender         = "RGDutyQual_PreRender">
             
            <ItemStyle HorizontalAlign="Center" />
            <AlternatingItemStyle HorizontalAlign="Center" />
            <HeaderStyle HorizontalAlign="Center" />
            <PagerStyle AlwaysVisible="False" />
           
            <MasterTableView 
                CommandItemDisplay="Top"  
                CommandItemSettings-AddNewRecordText="Add New Duty KSA" EnableNoRecordsTemplate="false" NoMasterRecordsText="" 
                EditMode="EditForms" DataKeyNames="DutyCompetencyKSAID" HierarchyLoadMode="ServerBind"> 
                 
                <Columns>
                    <telerik:GridTemplateColumn>
                        <ItemStyle VerticalAlign="Top" Width="10" />
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButtonEdit" runat="server" ToolTip="Edit" CommandName="Edit" SkinID ="editButton" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ID="ImageButtonUpdate" runat="server" ToolTip='<%# (Container is GridDataInsertItem) ? "Add Qualification" : "Save Qualification" %>'
                                 SkinID ="updateButton"  CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>' />
                            <asp:LinkButton ID="LinkButtonUpdate" runat="server" Text='<%# (Container is GridDataInsertItem) ? "Add Qualification" : "Save Qualification" %>'
                                CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>'>>Save Qualification</asp:LinkButton>
                            <asp:ImageButton ID="ImageButtonCancel" runat="server" ToolTip="Cancel" SkinID ="cancelButton" 
                                CommandName="Cancel" />
                            <asp:LinkButton ID="LinkButtonCancel" runat="server" CommandName="Cancel">Cancel</asp:LinkButton>
                        </EditItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridButtonColumn ConfirmText="Delete this KSA?" ConfirmDialogType="RadWindow" 
                         ConfirmTitle="Delete"
                        ButtonType="ImageButton" CommandName="Delete" Text="Delete" UniqueName="DeleteCommandColumn">
                        <ItemStyle VerticalAlign="Top" Width="10" />
                    </telerik:GridButtonColumn>
                    <telerik:GridTemplateColumn HeaderText="Qualification" DataField="QualificationName"
                        UniqueName="QualificationName">
                        <ItemStyle VerticalAlign="Top" Wrap="false" HorizontalAlign="Left" Width="150px" />
                        <ItemTemplate>
                            <asp:Label ID="lblQualificationName" runat="server" Text='<%#Eval ("QualificationName") %>'> </asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Description" DataField="CompetencyKSA" UniqueName="CompetencyKSA">
                        <ItemStyle VerticalAlign="Top" Wrap="true" HorizontalAlign="Left"  />
                        <ItemTemplate>
                            <asp:Label ID="lblQualificationDescription" runat="server" OnPreRender="lblQualificationDescription_PreRender" Text='<%#Eval("CompetencyKSA") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridTemplateColumn HeaderText="Qualification Type" DataField="QualificationTypeName"
                        UniqueName="QualificationTypeName">
                        <ItemStyle VerticalAlign="Top" Wrap="false" HorizontalAlign="Left"  Width="150px"/>
                        <ItemTemplate>
                            <asp:Label ID="lblQualificationTypeName" runat="server" Text='<%#Eval("QualificationTypeName") %>'></asp:Label>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                    <telerik:GridBoundColumn DataField="DutyCompetencyKSAID" UniqueName="DutyCompetencyKSAID"
                        Visible="False">
                    </telerik:GridBoundColumn>
                </Columns>


                <EditFormSettings EditFormType="Template" CaptionFormatString="Add New Duty Qualification"   >

                    <FormTemplate>
                    

                        <asp:ObjectDataSource ID="odsQualification" runat="server" SelectMethod="GetObjects"
                            TypeName="HCMS.Business.Lookups.QualificationDataSourceBusinessObject">
                        </asp:ObjectDataSource>

                        <asp:ObjectDataSource ID="odsQualificationType" runat="server" SelectMethod="GetDutyQualificationTypes" 
                            TypeName="HCMS.Business.Lookups.QualificationTypeDataSourceBusinessObject">
                        </asp:ObjectDataSource>

                        <table class="blueTable" style="width:100%">
                            <tr>
                                <td colspan="2">
                                    <asp:ValidationSummary ValidationGroup="KSAValGroup" ID="valSummary" runat="server" DisplayMode="BulletList" CssClass="validationMessageBox" />
            
                                </td>
                                </tr>
                             <tr id="trKSACopyFromDutyInst" runat="server" visible="true">
                                <td class="instruction" colspan="2">
                                    <asp:Label ID="lblCopyDuty" OnPreRender="lblCopyDuty_PreRender" Text="Add a KSA from your Duty Description above by copying (Ctrl + C) them from your duty, above, and pasting (Ctrl + V) them as KSAs or select from the list of standard KSAs for this series and grade, below.   If you select a standard KSA, you can edit it so that it remains in sync with the duty, above."
                                        runat="server" Visible="true"></asp:Label>
                                </td>
                            </tr>
                            <tr id="trKSADutyOption" runat ="server">
                                <td colspan="2">
                                    <span style="border:1px solid black;padding:7px 4px 4px 4px;">
                                        KSA: <asp:RadioButton runat="server" AutoPostBack="true" ID="dutyOption_Copy" groupname="dutyOption" OnCheckedChanged="dutyOption_Copy_CheckedChanged" checked="true" Text="Copy from Duty Description" /> 
                                        <asp:RadioButton runat="server" AutoPostBack="true" ID="dutyOption_Std" groupname="dutyOption" OnCheckedChanged="dutyOption_Std_CheckedChanged" Text="Standard KSA Library" />
                                    </span>
                                    <asp:Label ID="lblSearchmsg" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align:left;">
                                    <div style="width:60px;">
                                        KSA:<span class="required">*</span>&nbsp;<pde:ToolTip ID="ToolTip1" runat="server" ToolTipID="91" />
                                    </div>
                                </td>
                                </tr>
                            <tr id="trKSACombo" runat="server" visible="false">
                                <td class="style1" colspan="2">
                                    <telerik:RadComboBox ID="radcomboKSA" runat="server" CssClass="float-left" AutoPostBack="true" DataTextField="KSAText"
                                        DataValueField="KSAID" ExpandDirection="Down" MarkFirstMatch="True"  OnSelectedIndexChanged="radcomboKSA_SelectedIndexChanged" 
                                        CausesValidation="false" DropDownWidth="677px" Width="325px">
                                    </telerik:RadComboBox>&nbsp;<uc1:ctrlSearchKSA ID="SearchKSA" runat="server" />
                                    <asp:RequiredFieldValidator runat ="server" ID="radcomboKSAReqVal" ControlToValidate ="radcomboKSA"
                                        Display="None" ValidationGroup="KSAValGroup" ErrorMessage="Select KSA First" InitialValue ="<<--Select KSA First-->>"></asp:RequiredFieldValidator>
                                </td>
                                </tr>
                            <tr>
                                <td colspan="2">
                                    <div style="width:180px;">
                                        Description: <span class="required">*</span>&nbsp;
                                        <pde:ToolTip ID="ToolTip58" runat="server" ToolTipID="94" />
                                    </div>
                                </td>
                                </tr>
                            <tr>
                                <td class="style1" colspan="2">
                                    <telerik:RadEditor ID="radEditorQualDescription" runat="server"  SkinID="limitedTextRadEditor" NewLineMode="Br" OnPreRender="radEditorQualDescription_PreRender"  OnClientLoad="radEditorQualDescription_OnClientLoad"></telerik:RadEditor>
                                    <span id="charCntr2" class="char-counter" runat="server">Character count: 0</span>
                                    <asp:RequiredFieldValidator ID="radEditorQualDescriptionReqVal" runat="server" ControlToValidate="radEditorQualDescription"
                                        Display="Dynamic" ValidationGroup="KSAValGroup" InitialValue="" ErrorMessage="KSA Description is required." />
                                </td>
                                </tr>
                            <tr>
                                <td colspan="2" style="text-align:left;vertical-align:middle">
                                    <div style="width:165px;float:left">
                                        Qualification:&nbsp;
                                        <pde:ToolTip ID="ToolTip17" runat="server" ToolTipID="17" />
                                    </div>&nbsp;&nbsp;
                                    <telerik:RadComboBox ID="radComboDutyQualID" runat="server" DataSourceID="odsQualification"
                                        DataValueField="QualificationID" DataTextField="QualificationName" Width="200px">
                                    </telerik:RadComboBox>
                                </td>
                                </tr>
                            <tr>
                                <td colspan="2" style="text-align:left;vertical-align:middle">
                                    <div style="width:180px;float:left">
                                        Qualification Type:&nbsp;
                                        <pde:ToolTip ID="ToolTip59" runat="server" ToolTipID="59" />
                                    </div>&nbsp;&nbsp;
                                    <telerik:RadComboBox ID="radcomboQualificationTypeID" runat="server" DataSourceID="odsQualificationType"
                                        Width="200px" DataValueField="QualificationTypeID" DataTextField="QualificationTypeName">
                                    </telerik:RadComboBox>
                                </td>
                                </tr>
                        </table>
                        <br />

                        <table width="100%">
                            <tr align="right">
                                <td>
                                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                <asp:Label ID="lblmsg" runat="server" Font-Bold ="true" ></asp:Label>
                                    <asp:Button ID="btnUpdate" Text="Save and Close" runat="server"
                                     ValidationGroup="KSAValGroup" ToolTip='<%# (Container is GridDataInsertItem) ? "Add KSA" : "Save KSA" %>' CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>'>
                                    </asp:Button>&nbsp;
                                    <asp:Button ID="btnCancel" Text="Close" runat="server" OnClick="btnCancel_Click" CausesValidation="False" ToolTip="Close"></asp:Button>
                                </td>
                            </tr>
                        </table>



                    </FormTemplate>



                </EditFormSettings>


            </MasterTableView>
        </telerik:RadGrid>

        <asp:HiddenField ID="hiddenMode" runat="server" Value="Update" />
        <asp:HiddenField ID="hiddenID" runat="server" />

        </asp:Panel>



        <div style="display:none"><asp:Button ID="btnRefresh" runat="server" 
                onclick="btnRefresh_Click" />
    </ContentTemplate>
</asp:UpdatePanel>
