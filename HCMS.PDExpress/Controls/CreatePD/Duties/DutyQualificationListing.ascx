<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="DutyQualificationListing.ascx.cs"
    Inherits="HCMS.PDExpress.Controls.CreatePD.Duties.DutyQualificationListing" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="pde" %>
<asp:ValidationSummary ID="vsDutyQual" runat="server" CssClass="validationMessageBox"
    ShowSummary="true" HeaderText="<span class='systemMessage'>Validation Message</span><br>"
    DisplayMode="BulletList" />
<asp:Panel ID="panelDuty" runat="server" Style="border-bottom: solid 1px #9cb6c5;">
    <table width="100%" class="popupTable">
        <tr>
            <td>
                <div class="sectionTitle">
                    Duty
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtDutyQualification" runat="server" TextMode="MultiLine" CssClass="TelerikTextFont"
                    ReadOnly="true" Rows="5" Width="99%" />
            </td>
        </tr>
    </table>
</asp:Panel>
<br />
<div style="font-weight: bolder; color: Red; margin: 15px 5px;">
    NOTE: Ensure to list all qualifications for this position in language of Factor
    1 of the chosen factor format.
</div>
<div class="sectionTitle">
    Qualifications
</div>
<telerik:RadGrid ID="rgDutyQual" runat="server" SkinID="customRADGridView" Width="100%"
    Height="310px" AllowPaging="true" PageSize="5" PagerStyle-AlwaysVisible="false"
    OnNeedDataSource="rgDutyQual_NeedDataSource"
    OnItemDataBound="rgDutyQual_ItemDataBound" OnItemCommand="rgDutyQual_ItemCommand">
    <ItemStyle HorizontalAlign="Center" />
    <AlternatingItemStyle HorizontalAlign="Center" />
    <HeaderStyle HorizontalAlign="Center" />
    <PagerStyle AlwaysVisible="False" />
    <MasterTableView CommandItemDisplay="Top" CommandItemSettings-AddNewRecordText="Add new qualification"
        EditMode="InPlace" DataKeyNames="DutyCompetencyKSAID, DutyID">
        <RowIndicatorColumn>
            <HeaderStyle Width="20px"></HeaderStyle>
        </RowIndicatorColumn>
        <ExpandCollapseColumn>
            <HeaderStyle Width="20px"></HeaderStyle>
        </ExpandCollapseColumn>
        <Columns>
            <%-- <telerik:GridEditCommandColumn ButtonType="ImageButton" UniqueName="EditCommandColumn" >
            <ItemStyle VerticalAlign="Top" Width="10" />
        </telerik:GridEditCommandColumn>--%>
                <telerik:GridTemplateColumn>
                
                <ItemStyle VerticalAlign="Top" Width="10" />
                
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButtonEdit" runat="server" ToolTip="Edit" CommandName ="Edit" SkinID="editButton"  />                        
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:ImageButton ID="ImageButtonUpdate" runat="server" ToolTip ='<%# (Container is GridDataInsertItem) ? "Add Qualification" : "Save Qualification" %>'  SkinID ="updateButton" 
                            CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>' /> 
                        <asp:LinkButton ID="LinkButtonUpdate" runat="server" Text='<%# (Container is GridDataInsertItem) ? "Add Qualification" : "Save Qualification" %>' 
                            CommandName='<%# (Container is GridDataInsertItem) ? "PerformInsert" : "Update" %>'>>Save Qualification</asp:LinkButton> 
                        <asp:ImageButton ID="ImageButtonCancel" runat="server" ToolTip="Cancel" SkinID ="cancelButton"   CommandName="Cancel" /> 
                        <asp:LinkButton ID="LinkButtonCancel" runat="server" CommandName="Cancel">Cancel</asp:LinkButton> 

                    </EditItemTemplate>
                </telerik:GridTemplateColumn>
            <telerik:GridButtonColumn ConfirmText="Delete this qualification?" ConfirmDialogType="RadWindow"
                 ConfirmTitle="Delete"                ButtonType="ImageButton" CommandName="Delete" Text="Delete" UniqueName="DeleteCommandColumn">
                <ItemStyle VerticalAlign="Top" Width="10" />
            </telerik:GridButtonColumn>
            <telerik:GridTemplateColumn HeaderText="Qualification" DataField="QualificationName"
                UniqueName="QualificationName">
                <ItemStyle VerticalAlign="Top" Wrap="false" />
                <ItemTemplate>
                    <asp:Label ID="lblQualificationName" runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <span><span style="vertical-align: top;">
                        <telerik:RadComboBox ID="rcbQualificationName" runat="server" DataSourceID="odsQualification"
                            DataValueField="QualificationID" DataTextField="QualificationName" Width="150px"
                            DropDownWidth="300px" />
                    </span><span style="vertical-align: top;">&nbsp; </span><span style="vertical-align: top;">
                        <pde:ToolTip ID="ToolTip17" runat="server" ToolTipID="17" />
                    </span></span>
                </EditItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn HeaderText="Description" DataField="QualificationDescription"
                UniqueName="QualificationDescription">
                <ItemStyle VerticalAlign="Top" Wrap="true" />
                <ItemTemplate>
                    <asp:Label ID="lblQualificationDescription" runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <span><span style="vertical-align: top;">
                        <asp:TextBox ID="tbQualificationDescription" runat="server" CssClass="TelerikTextFont"
                            TextMode="MultiLine" Rows="10" Width="210px"></asp:TextBox>
                    </span><span style="vertical-align: top;">&nbsp; <span class="required">*</span> </span>
                        <asp:RequiredFieldValidator ID="tbQualificationDescriptionReqVal" runat="server"
                            ControlToValidate="tbQualificationDescription" Display="None" InitialValue=""
                            ErrorMessage="Qualification Description is required." />
                        <span style="vertical-align: top;">&nbsp;
                            <pde:ToolTip ID="ToolTip58" runat="server" ToolTipID="58" />
                        </span></span>
                </EditItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn HeaderText="Qualification Type" DataField="QualificationTypeName"
                UniqueName="QualificationTypeName">
                <ItemStyle VerticalAlign="Top" Wrap="false" />
                <ItemTemplate>
                    <asp:Label ID="lblQualificationTypeName" runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <span><span style="vertical-align: top;">
                        <telerik:RadComboBox ID="rcbQualificationTypeName" runat="server" DataSourceID="odsQualificationType"
                            DataValueField="QualificationTypeID" DataTextField="QualificationTypeName" Width="150px"
                            DropDownWidth="150px" />
                    </span><span style="vertical-align: top;">&nbsp; </span><span style="vertical-align: top;">
                        <pde:ToolTip ID="ToolTip59" runat="server" ToolTipID="59" />
                    </span></span>
                </EditItemTemplate>
            </telerik:GridTemplateColumn>
        </Columns>
    </MasterTableView>
</telerik:RadGrid>
<telerik:RadWindowManager ID="DutyQualificationPopupRadWindowManager" runat="server"
    Skin="WebBlue" />
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="rgDutyQual">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgDutyQual" LoadingPanelID="rlpDefault" />
                <telerik:AjaxUpdatedControl ControlID="DutyQualificationPopupRadWindowManager" />
            </UpdatedControls>
        </telerik:AjaxSetting>
    </AjaxSettings>
</telerik:RadAjaxManager>
<telerik:RadAjaxLoadingPanel ID="rlpDefault" runat="server" Skin="Web20" />
<asp:ObjectDataSource ID="odsQualification" runat="server" SelectMethod="GetObjects"
    TypeName="HCMS.Business.Lookups.QualificationDataSourceBusinessObject">
</asp:ObjectDataSource>
<asp:ObjectDataSource ID="odsQualificationType" runat="server" SelectMethod="GetObjects"
    TypeName="HCMS.Business.Lookups.QualificationTypeDataSourceBusinessObject">
</asp:ObjectDataSource>
