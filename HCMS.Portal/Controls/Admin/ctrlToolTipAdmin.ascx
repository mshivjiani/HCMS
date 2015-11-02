<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlToolTipAdmin.ascx.cs" Inherits="HCMS.Portal.Controls.Admin.ctrlToolTipAdmin" %>

 <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server"> 
        <AjaxSettings> 
            <telerik:AjaxSetting AjaxControlID="RadGrid1"> 
                <UpdatedControls> 
                    <telerik:AjaxUpdatedControl ControlID="rgToolTip" LoadingPanelID="RadAjaxLoadingPanel1"></telerik:AjaxUpdatedControl> 
                    
                </UpdatedControls> 
            </telerik:AjaxSetting> 
        </AjaxSettings> 
    </telerik:RadAjaxManager> 
    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server"> 
    </telerik:RadAjaxLoadingPanel> 
 
<asp:ImageButton ID="imgExcel" runat ="server" SkinID ="excelIcon" ToolTip="Export To Excel" AlternateText ="Export To Excel"  CommandName="ExportToExcel" OnClick ="imgExcel_Click" />
<br />
<telerik:RadGrid ID="rgToolTip" runat="server" AutoGenerateColumns="False" 
    AllowPaging="True" AllowSorting="True" 
    CellSpacing="0" GridLines="None" 
    onneeddatasource="rgToolTip_NeedDataSource" 
    onitemcommand="rgToolTip_ItemCommand">
    <ExportSettings IgnorePaging="true" OpenInNewWindow="true" ExportOnlyData ="true" FileName="HCMS ToolTips"> 
                                        <Pdf PageHeight="210mm" PageWidth="297mm" DefaultFontFamily="Arial Unicode MS" PageTopMargin="45mm"> </Pdf> 
                                        <Excel Format="Biff" />
                                    </ExportSettings> 
<MasterTableView DataKeyNames="ToolTipID" CommandItemDisplay="Top" CommandItemSettings-AddNewRecordText="Add New ToolTip"
                            EditMode="EditForms" TableLayout="Auto">
                            <CommandItemSettings AddNewRecordText="Add New ToolTip" ExportToPdfText="Export to PDF">
                            </CommandItemSettings>
                                     
                            <EditFormSettings EditFormType="Template">
                            <FormTemplate>
                            <table class="blueTable">
                            <tr class="EditFormHeader"> 
                                <td colspan="2"> <b>ToolTip Details</b> 
                                </td> 
                            </tr> 

                            <tr><td>ToolTip ID:</td><td><asp:Label ID="lblID" runat="server" Text='<% #Eval("ToolTipID")%>'></asp:Label></td></tr>
                            <tr><td>ToolTip Caption:<span class="required">*</span></td><td><asp:TextBox ID="txtCaption" runat ="server" Width="450px" Text ='<% #Bind("ToolTipCaption") %>'></asp:TextBox>
                            <asp:RequiredFieldValidator ID="requiredValCaption" runat="server" ControlToValidate ="txtCaption" ValidationGroup="valToolTip" Text="Tool Tip caption is required."></asp:RequiredFieldValidator></td></tr>
                            <tr><td>ToolTip Description:<span class="required">*</span></td><td><asp:TextBox ID="txtDescription" runat ="server" Width="450px" Text ='<% #Bind("ToolTipDescription")  %>' TextMode="MultiLine" Rows="6"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="requiredValDescription" runat="server" ControlToValidate ="txtDescription" ValidationGroup="valToolTip" Text="Tool Tip description is required."></asp:RequiredFieldValidator></td></tr>
                            <tr><td>ToolTip Sreen:<span class="required">*</span><br />(max-255 characters)</td><td><asp:TextBox ID="txtScreen" runat ="server" Width="450px" Text ='<% #Bind("ToolTipScreen") %>' TextMode="MultiLine" Rows="3" MaxLength="255"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="requiredValScreen" runat="server" ControlToValidate ="txtScreen" ValidationGroup="valToolTip" Text="Tool Tip screen is required."></asp:RequiredFieldValidator></td></tr>
                             <tr> 
                                <td align="right" colspan="2"> 
                                    <asp:Button ID="btnUpdate" Text='<%# (Container is GridEditFormInsertItem) ? "Insert" : "Update" %>' 
                                        runat="server" CommandName='<%# (Container is GridEditFormInsertItem) ? "PerformInsert" : "Update" %>' ValidationGroup ="valToolTip"></asp:Button>&nbsp; 
                                    <asp:Button ID="btnCancel" Text="Cancel" runat="server" CausesValidation="False"
                                        CommandName="Cancel"></asp:Button> 
                                </td> 

                            </table>
                            </FormTemplate>
                             </EditFormSettings> 

<Columns>
<telerik:GridButtonColumn ButtonType ="LinkButton" CommandName ="Edit" Text="Edit"></telerik:GridButtonColumn>
<telerik:GridBoundColumn DataField="ToolTipID" ReadOnly="true" HeaderText="ID" ></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="ToolTipCaption" HeaderText ="Caption" ></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField ="ToolTipDescription" HeaderText="Description"></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField ="ToolTipScreen" HeaderText="Screen"></telerik:GridBoundColumn>
</Columns>

</MasterTableView>
</telerik:RadGrid>