<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowDutyDiff.ascx.cs" Inherits="HCMS.PDExpress.Controls.CreatePD.Duties.ShowDutyDiff" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="pde" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<style type="text/css">
.rcbArrowCellRight 
{
    width: 60px;
    padding-left: 0px;
    padding-right: 0px;
}
</style>

<telerik:RadCodeBlock ID="rcbCodeBlock" runat="server">

    <script type="text/javascript">

        var radGridDuty;
        var radGridDutyAdds;
        var radGridDutyDeletes;
        var radGridQual;
        var radGridQualAdds;
        var radGridQualDeletes;
                    
        function GetGridObject(sender, eventArgs) {
            radGridDuty = sender;
        }
        function GetDutyAddsGridObject(sender, eventArgs) {
            radGridDutyAdds = sender;
        }
        function GetDutyDeletesGridObject(sender, eventArgs) {
            radGridDutyDeletes = sender;
        }

        function GetQualGridObject(sender, eventArgs) {
            radGridQual = sender;
        }
        function GetQualAddsGridObject(sender, eventArgs) {
            radGridQualAdds = sender;
        }
        function GetQualDeletesGridObject(sender, eventArgs) {
            radGridQualDeletes = sender;
        }

        function onRadComboActionTopSelectedIndexChanged(sender, eventArgs) {
            var selectedItem = eventArgs.get_item();
            var selectedItemText = selectedItem != null ? selectedItem.get_text() : sender.get_text();

            //Enable/Disable grid combo boxes based on selection            
            SetAction(selectedItemText);
        }

        function SetAction(actionType) {
        var row;
            if (radGridDuty) {
                var MasterTable = radGridDuty.get_masterTableView();
                if (actionType == 'Select Changes') {
                    MasterTable.showColumn(4);  //show Action column
                }
                else {
                    MasterTable.hideColumn(4);
                }
            }
            if (radGridDutyAdds) {

                var addsMasterTable = radGridDutyAdds.get_masterTableView();
                if (actionType == 'Select Changes') {
                    addsMasterTable.showColumn(4);
                }
                else {
                    addsMasterTable.hideColumn(4);
                }
            }
            if (radGridDutyDeletes) {
                var deletesMasterTable = radGridDutyDeletes.get_masterTableView();
                if (actionType == 'Select Changes') {
                    deletesMasterTable.showColumn(4);
                }
                else {
                    deletesMasterTable.hideColumn(4);
                }
            }


            //Qualification Grids
            if (radGridQual) {
                var MasterTable = radGridQual.get_masterTableView();
                if (actionType == 'Select Changes') {
                    MasterTable.showColumn(3);
                }
                else {
                    MasterTable.hideColumn(3);
                }
            }
            if (radGridQualAdds) {

                var addsMasterTable = radGridQualAdds.get_masterTableView();
                if (actionType == 'Select Changes') {
                    addsMasterTable.showColumn(3);
                }
                else {
                    addsMasterTable.hideColumn(3);
                }
            }
            if (radGridQualDeletes) {
                var deletesMasterTable = radGridQualDeletes.get_masterTableView();
                if (actionType == 'Select Changes') {
                    deletesMasterTable.showColumn(3);
                }
                else {
                    deletesMasterTable.hideColumn(3);
                }
            }            
        }

        window.blockConfirm = function(text, mozEvent, oWidth, oHeight, callerObj, oTitle) {
            var ev = mozEvent ? mozEvent : window.event; //Moz support requires passing the event argument manually
            //Cancel the event
            ev.cancelBubble = true;
            ev.returnValue = false;
            if (ev.stopPropagation) ev.stopPropagation();
            if (ev.preventDefault) ev.preventDefault();

            var callerObj = ev.srcElement ? ev.srcElement : ev.target;
            text = 'Are you sure you want to save the Duty Differences?';

            //Call the original radconfirm and pass it all necessary parameters
            if (callerObj) {
                //Show the confirm, then when it is closing, if returned value was true, automatically call the caller's click method again.
                var callBackFn = function(arg) {
                    if (arg) {
                        callerObj["onclick"] = "";
                        if (callerObj.click) callerObj.click(); 
                        else if (callerObj.tagName == "A") 
                        {
                            try {
                                eval(callerObj.href)
                            }
                            catch (e) { }
                        }
                    }
                }

                radconfirm(text, callBackFn, oWidth, oHeight, callerObj, oTitle);
            }
            return false;
        }

    </script>

</telerik:RadCodeBlock>

<style type="text/css">
    /*---- Overwriting a style coming from main.css -----*/
    .blueTable img {margin-top:0px !important; float:none !important;}
</style>

<telerik:RadAjaxLoadingPanel ID="rlpDefault" runat="server" Skin="Web20" />
<telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" EnableAJAX="true">
    <AjaxSettings>
        <telerik:AjaxSetting AjaxControlID="radComboActionTop">
            <UpdatedControls>
                <telerik:AjaxUpdatedControl ControlID="rgDuty" LoadingPanelID="rlpDefault" />
            </UpdatedControls>
        </telerik:AjaxSetting>

    </AjaxSettings>
</telerik:RadAjaxManager>
    
<div id="divSubmitActionTop" runat="server" class="blueTable" align="right" style="padding:4px; margin-top:10px; margin-bottom:15px;">
     
       <asp:Button ID="btnGoBackTop" runat="server" CssClass="formBtnLeft" Text="Go Back" ToolTip="Go Back"
        style="float:left" OnClick="GoBack" />   
        
        <div style="position:relative; float:right; margin-top:0px ">
    <telerik:RadComboBox ID="radComboActionTop" runat="server" Width="105px" ShowMoreResultsBox="false"
     Skin="WebBlue" EnableLoadOnDemand="false"
             OnClientSelectedIndexChanging = "onRadComboActionTopSelectedIndexChanged">
        <Items>
            <telerik:RadComboBoxItem Text="Accept All" Selected="true" Value="acceptall" />
            <telerik:RadComboBoxItem Text="Reject All" Selected="true" Value="rejectall" />
            <telerik:RadComboBoxItem Text="Select Changes" Selected="true" Value="select" />
        </Items>
    </telerik:RadComboBox>&nbsp;
         <pde:ToolTip ID="ToolTip70" runat="server" ToolTipID="70" />     
         </div>  
                        
                                

  
    <br /> <br /> 
    <asp:Label ID="lblSubmitInfo" CssClass="labelStyle" Text="Review HR recommended changes and Accept or Reject the changes made to each duty. 
        If you agree with only part of the change, you can accept the change and return to the duty screen to edit the duty." runat ="server" ></asp:Label>
    <asp:Button ID="btnExport" runat="server" OnClick="btnExport_Click" CssClass="formBtn" Text="Export to Word" CausesValidation="false" ToolTip="Export Duty Differences" />
</div>

<telerik:RadGrid ID="rgWrapper" runat="server"  Width="100%" ShowHeader="false" 
            BorderStyle="None" >
    <ExportSettings OpenInNewWindow="true" />
    <MasterTableView AutoGenerateColumns="true" BorderStyle="None">
        <ItemTemplate>
            <asp:Panel ID="pnlDuty" runat="server" Visible="true" Width="100%">
                <telerik:RadGrid ID="rgDuty" runat="server" Width="100%" SkinID="customRADGridView"
                    AllowPaging="false" PageSize="2" PagerStyle-AlwaysVisible="false" 
                    OnNeedDataSource="rgDuty_NeedDataSource" OnItemDataBound="rgDuty_ItemDataBound"
                    OnPreRender="rgDuty_PreRender" OnDetailTableDataBind="rgDuty_DetailTableDataBind" OnItemCommand="rgDuty_ItemCommand">
                    <PagerStyle AlwaysVisible="False" />
                    <ExportSettings ExportOnlyData="true" OpenInNewWindow="true" />
                    <MasterTableView CommandItemDisplay="None" EditMode="InPlace" Name="DutyMain" ClientDataKeyNames="DutyLogID, DutyID, PositionDescriptionID" DataKeyNames="DutyLogID, DutyID, PositionDescriptionID" 
                        ShowHeadersWhenNoRecords="false" HierarchyLoadMode="ServerBind" HierarchyDefaultExpanded="true" AutoGenerateColumns="false">
                        <RowIndicatorColumn>
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn>
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <DetailTables>
                            <telerik:GridTableView DataKeyNames="DutyCompetencyKSAID, DutyID" Name="EditedQualifications" Width="100%"
                                Caption="Qualifications Edited" BorderColor="#9cb6c5" BorderStyle="Solid" BorderWidth="1px" GridLines="Both" 
                                  ShowHeadersWhenNoRecords="false" AutoGenerateColumns="false" TableLayout="Auto">
                                <ParentTableRelation>
                                    <telerik:GridRelationFields DetailKeyField="DutyID" MasterKeyField="DutyID" />
                                </ParentTableRelation>
                                
                                 <Columns>
                                    <telerik:GridTemplateColumn HeaderText="Qualification" DataField="QualificationName" UniqueName="QualificationName">
                                        <ItemStyle VerticalAlign="Middle" Width="160px" Wrap="false" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblQualification" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                            
                                    <telerik:GridTemplateColumn HeaderText="Description" DataField="CompetencyKSA" UniqueName="CompetencyKSA">
                                        <ItemStyle VerticalAlign="Middle" Width="430px" Wrap="true" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblCompetencyKSA" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridTemplateColumn HeaderText="Qualification Type" DataField="QualificationTypeName" UniqueName="QualificationTypeName">
                                        <ItemStyle VerticalAlign="Middle" Width="232px" Wrap="false" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblQualificationTypeName" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                 </Columns>
                            </telerik:GridTableView>
                            <telerik:GridTableView DataKeyNames="DutyCompetencyKSAID, DutyID" Name="NewQualifications" Width="100%" AutoGenerateColumns="false"
                            Caption="Qualifications Added" BorderWidth="1px" BorderColor="#9cb6c5" BorderStyle="Solid" GridLines="Both"
                             ShowHeadersWhenNoRecords="false">
                                <ParentTableRelation>
                                    <telerik:GridRelationFields DetailKeyField="DutyID" MasterKeyField="DutyID" />
                                </ParentTableRelation>
                                <ItemStyle VerticalAlign="Middle" />
                                <AlternatingItemStyle VerticalAlign="Middle" />
                                 <Columns>
                                    <telerik:GridTemplateColumn HeaderText="Qualification" DataField="QualificationName" UniqueName="QualificationName">
                                        <ItemStyle VerticalAlign="Middle" Width="160px" Wrap="false" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblQualification" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                            
                                    <telerik:GridTemplateColumn HeaderText="Description" DataField="CompetencyKSA" UniqueName="CompetencyKSA">
                                        <ItemStyle VerticalAlign="Middle" Width="430px" Wrap="true" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblCompetencyKSA" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridTemplateColumn HeaderText="Qualification Type" DataField="QualificationTypeName" UniqueName="QualificationTypeName">
                                        <ItemStyle VerticalAlign="Middle" Width="232px" Wrap="false" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblQualificationTypeName" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                 </Columns>
                            </telerik:GridTableView>
                            <telerik:GridTableView DataKeyNames="DutyCompetencyKSAID, DutyID" Name="DeletedQualifications" Width="100%" Caption="Qualifications Deleted" BorderWidth="1px" 
                                BorderColor="#9cb6c5" BorderStyle="Solid" ShowHeadersWhenNoRecords="false" AutoGenerateColumns="false">
                                <ParentTableRelation>
                                    <telerik:GridRelationFields DetailKeyField="DutyID" MasterKeyField="DutyID" />
                                </ParentTableRelation>
                                <ItemStyle VerticalAlign="Middle" Font-Strikeout="true" ForeColor="Red" Font-Bold="true" />
                                <AlternatingItemStyle VerticalAlign="Middle" Font-Strikeout="true" ForeColor="Red" Font-Bold="true" />
                                 <Columns>
                                    <telerik:GridBoundColumn SortExpression="Qualification" HeaderText="Qualification" HeaderButtonType="TextButton" 
                                                            ItemStyle-Width="160px" ItemStyle-Wrap="false" DataField="QualificationName">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn SortExpression="CompetencyKSA" HeaderText="Description" HeaderButtonType="TextButton" 
                                                            ItemStyle-Width="430px" ItemStyle-Wrap="true" DataField="CompetencyKSA">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn SortExpression="QualificationTypeName" HeaderText="Qualification Type" HeaderButtonType="TextButton" 
                                                            ItemStyle-Width="232px" ItemStyle-Wrap="false" DataField="QualificationTypeName">
                                    </telerik:GridBoundColumn>
                                 </Columns>
                            </telerik:GridTableView>
                         </DetailTables>
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="Duty" DataField="DutyDescription" UniqueName="DutyDescription">
                                <ItemStyle VerticalAlign="Middle" Width="490px" Wrap="true" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDutyDescription" runat="server"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="% of Time" DataField="PercentageOfTime" UniqueName="PercentageOfTime">
                                <ItemStyle VerticalAlign="Middle" Wrap="true" Width="95px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPercentageOfTime" runat="server"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Duty Type" DataField="DutyTypeName" UniqueName="DutyTypeName">
                                <ItemStyle VerticalAlign="Middle" Wrap="false" Width="135px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDutyTypeName" runat="server"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Action" UniqueName="Action" Display="false">
                                <ItemStyle VerticalAlign="Middle" Width="175px" />
                                <ItemTemplate>
                                    <telerik:RadComboBox ID="rcbAction" runat="server" Width="140px" Skin="WebBlue" style="position:relative; float:left;">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Accept" Value="accept" Selected="true" />
                                            <telerik:RadComboBoxItem Text="Reject" Value="reject" />
                                        </Items>
                                    </telerik:RadComboBox>&nbsp;
                                    <pde:ToolTip ID="ToolTip71" runat="server" ToolTipID="71" style="position:relative; float:left;" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                         <NoRecordsTemplate>
                            No Duties have been edited during Review for this Position Description.
                         </NoRecordsTemplate>
                    </MasterTableView>
                    <ClientSettings>
                        <ClientEvents OnGridCreated="GetGridObject"></ClientEvents>
                    </ClientSettings>
                </telerik:RadGrid>
            </asp:Panel>
            <asp:Panel ID="pnlDutyAdds" runat="server" Visible="true" Width="100%">
                <br />
                <telerik:RadGrid ID="rgDutyAdds" runat="server" SkinID="customRADGridView" Width="100%"
                    AllowPaging="false" PageSize="3" PagerStyle-AlwaysVisible="false" 
                    OnNeedDataSource="rgDutyAdds_NeedDataSource" OnItemDataBound="rgDutyAdds_ItemDataBound"
                    OnPreRender="rgDutyAdds_PreRender" OnDetailTableDataBind="rgDutyAdds_DetailTableDataBind" OnItemCommand="rgDutyAdds_ItemCommand">
                    <PagerStyle AlwaysVisible="False" />
                    <ExportSettings OpenInNewWindow="true" />
                    <MasterTableView CommandItemDisplay="None" EditMode="InPlace" Name="DutyMain" ClientDataKeyNames="DutyLogID, DutyID, PositionDescriptionID" DataKeyNames="DutyLogID, DutyID, PositionDescriptionID" 
                        ShowHeadersWhenNoRecords="false" HierarchyLoadMode="ServerBind" HierarchyDefaultExpanded="true">
                        <RowIndicatorColumn>
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn>
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <DetailTables>
                            <telerik:GridTableView DataKeyNames="DutyCompetencyKSAID, DutyID" Name="EditedQualifications" Width="100%" 
                            Caption="Qualifications Edited" BorderWidth="1px" BorderColor="#9cb6c5" BorderStyle="Solid" ShowHeadersWhenNoRecords="false">
                                <ParentTableRelation>
                                    <telerik:GridRelationFields DetailKeyField="DutyID" MasterKeyField="DutyID" />
                                </ParentTableRelation>
                                 <Columns>
                                <telerik:GridTemplateColumn HeaderText="Qualification" DataField="QualificationName" UniqueName="QualificationName">
                                    <ItemStyle VerticalAlign="Middle" Width="160px" Wrap="false" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblQualification" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                        
                                <telerik:GridTemplateColumn HeaderText="Description" DataField="CompetencyKSA" UniqueName="CompetencyKSA">
                                    <ItemStyle VerticalAlign="Middle" Width="447px" Wrap="true" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCompetencyKSA" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn HeaderText="Qualification Type" DataField="QualificationTypeName" UniqueName="QualificationTypeName">
                                    <ItemStyle VerticalAlign="Middle" Width="220px" Wrap="false" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblQualificationTypeName" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                 </Columns>
                            </telerik:GridTableView>
                            <telerik:GridTableView DataKeyNames="DutyCompetencyKSAID, DutyID" Name="NewQualifications" Width="100%" Caption="Qualifications Added" BorderWidth="1px" 
                                BorderColor="#9cb6c5" BorderStyle="Solid" ShowHeadersWhenNoRecords="false" GridLines="Both" AutoGenerateColumns="false">
                                <ParentTableRelation>
                                    <telerik:GridRelationFields DetailKeyField="DutyID" MasterKeyField="DutyID" />
                                </ParentTableRelation>
                                <ItemStyle VerticalAlign="Middle" />
                                <AlternatingItemStyle VerticalAlign="Middle" />
                                 <Columns>
                                    <telerik:GridTemplateColumn HeaderText="Qualification" DataField="QualificationName" UniqueName="QualificationName">
                                        <ItemStyle VerticalAlign="Middle" Width="160px" Wrap="false" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblQualification" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                            
                                    <telerik:GridTemplateColumn HeaderText="Description" DataField="CompetencyKSA" UniqueName="CompetencyKSA">
                                        <ItemStyle VerticalAlign="Middle" Width="430px" Wrap="true" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblCompetencyKSA" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridTemplateColumn HeaderText="Qualification Type" DataField="QualificationTypeName" UniqueName="QualificationTypeName">
                                        <ItemStyle VerticalAlign="Middle" Width="232px" Wrap="false" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblQualificationTypeName" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                 </Columns>
                            </telerik:GridTableView>
                            <telerik:GridTableView DataKeyNames="DutyCompetencyKSAID, DutyID" Name="DeletedQualifications" Width="100%" Caption="Qualifications Deleted" BorderWidth="1px" 
                                BorderColor="#9cb6c5" BorderStyle="Solid" ShowHeadersWhenNoRecords="false">
                                <ParentTableRelation>
                                    <telerik:GridRelationFields DetailKeyField="DutyID" MasterKeyField="DutyID" />
                                </ParentTableRelation>
                                <ItemStyle VerticalAlign="Middle" Font-Strikeout="true" ForeColor="Red" Font-Bold="true" />
                                <AlternatingItemStyle VerticalAlign="Middle" Font-Strikeout="true" ForeColor="Red" Font-Bold="true" />
                                 <Columns>
                                    <telerik:GridBoundColumn SortExpression="Qualification" HeaderText="Qualification" HeaderButtonType="TextButton" 
                                                            ItemStyle-Width="160px" ItemStyle-Wrap="false" DataField="QualificationName">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn SortExpression="CompetencyKSA" HeaderText="Description" HeaderButtonType="TextButton" 
                                                            ItemStyle-Width="447px" ItemStyle-Wrap="true" DataField="CompetencyKSA">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn SortExpression="QualificationTypeName" HeaderText="Qualification Type" HeaderButtonType="TextButton" 
                                                            ItemStyle-Width="220px" ItemStyle-Wrap="false" DataField="QualificationTypeName">
                                    </telerik:GridBoundColumn>
                                 </Columns>
                            </telerik:GridTableView>
                         </DetailTables>
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="Duty" DataField="DutyDescription" UniqueName="DutyDescription">
                                <ItemStyle VerticalAlign="Middle" Width="490px" Wrap="true" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDutyDescription" runat="server"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="% of Time" DataField="PercentageOfTime" UniqueName="PercentageOfTime">
                                <ItemStyle VerticalAlign="Middle" Wrap="true" Width="95px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPercentageOfTime" runat="server"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Duty Type" DataField="DutyTypeName" UniqueName="DutyTypeName">
                                <ItemStyle VerticalAlign="Middle" Wrap="false" Width="135px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDutyTypeName" runat="server"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Action" UniqueName="Action" Display="false">
                                <ItemStyle VerticalAlign="Middle" Width="175px" />
                                <ItemTemplate>
                                    <telerik:RadComboBox ID="rcbAction" runat="server" Width="140px" Skin="WebBlue" style="position:relative; float:left;">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Accept" Value="accept" Selected="true" />
                                            <telerik:RadComboBoxItem Text="Reject" Value="reject" />
                                        </Items>
                                    </telerik:RadComboBox>&nbsp;
                                    <pde:ToolTip ID="ToolTip71" runat="server" ToolTipID="71" style="position:relative; float:left;" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                         <NoRecordsTemplate>
                            No Duties have been added for this Position Description during Review status.
                         </NoRecordsTemplate>
                    </MasterTableView>
                    <ClientSettings>
                        <ClientEvents OnGridCreated="GetDutyAddsGridObject"></ClientEvents>
                    </ClientSettings>
                </telerik:RadGrid>
            </asp:Panel>
            <asp:Panel ID="pnlDutyDeletes" runat="server" Visible="true" Width="100%">
                <br />
                <telerik:RadGrid ID="rgDutyDeletes" runat="server" SkinID="customRADGridView" Width="100%"
                    AllowPaging="false" PageSize="3" PagerStyle-AlwaysVisible="false" 
                    OnNeedDataSource="rgDutyDeletes_NeedDataSource" OnItemDataBound="rgDutyDeletes_ItemDataBound"
                    OnPreRender="rgDutyDeletes_PreRender" OnDetailTableDataBind="rgDutyDeletes_DetailTableDataBind" OnItemCommand="rgDutyDeletes_ItemCommand">
                    <PagerStyle AlwaysVisible="False" />
                    <ExportSettings OpenInNewWindow="true" />
                    <MasterTableView CommandItemDisplay="None" EditMode="InPlace" Name="DutyMain" ClientDataKeyNames="DutyLogID, DutyID, PositionDescriptionID" DataKeyNames="DutyLogID, DutyID, PositionDescriptionID" 
                        ShowHeadersWhenNoRecords="false" HierarchyLoadMode="ServerBind" HierarchyDefaultExpanded="true">
                        <RowIndicatorColumn>
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn>
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <DetailTables>
                            <telerik:GridTableView DataKeyNames="DutyCompetencyKSAID, DutyID" Name="EditedQualifications" Width="100%" Caption="Qualifications Edited" BorderWidth="1px" 
                                BorderColor="#9cb6c5" BorderStyle="Solid" ShowHeadersWhenNoRecords="false" AutoGenerateColumns="false" GridLines="Both">
                                <ParentTableRelation>
                                    <telerik:GridRelationFields DetailKeyField="DutyID" MasterKeyField="DutyID" />
                                </ParentTableRelation>
                                 <Columns>
                                <telerik:GridTemplateColumn HeaderText="Qualification" DataField="QualificationName" UniqueName="QualificationName">
                                    <ItemStyle VerticalAlign="Top" Width="160px" Wrap="false" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblQualification" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                        
                                <telerik:GridTemplateColumn HeaderText="Description" DataField="CompetencyKSA" UniqueName="CompetencyKSA">
                                    <ItemStyle VerticalAlign="Top" Width="447px" Wrap="true" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblCompetencyKSA" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>

                                <telerik:GridTemplateColumn HeaderText="Qualification Type" DataField="QualificationTypeName" UniqueName="QualificationTypeName">
                                    <ItemStyle VerticalAlign="Top" Width="220px" Wrap="false" />
                                    <ItemTemplate>
                                        <asp:Label ID="lblQualificationTypeName" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                                 </Columns>
                            </telerik:GridTableView>
                            <telerik:GridTableView DataKeyNames="DutyCompetencyKSAID, DutyID" Name="NewQualifications" Width="100%" Caption="Qualifications Added" BorderWidth="1px" 
                                BorderColor="#9cb6c5" BorderStyle="Solid" ShowHeadersWhenNoRecords="false" AutoGenerateColumns="false" GridLines="Both">
                                <ParentTableRelation>
                                    <telerik:GridRelationFields DetailKeyField="DutyID" MasterKeyField="DutyID" />
                                </ParentTableRelation>
                                <ItemStyle VerticalAlign="Middle" />
                                <AlternatingItemStyle VerticalAlign="Middle" />
                                 <Columns>
                                    <telerik:GridTemplateColumn HeaderText="Qualification" DataField="QualificationName" UniqueName="QualificationName">
                                        <ItemStyle VerticalAlign="Middle" Width="160px" Wrap="false" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblQualification" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                            
                                    <telerik:GridTemplateColumn HeaderText="Description" DataField="CompetencyKSA" UniqueName="CompetencyKSA">
                                        <ItemStyle VerticalAlign="Middle" Width="430px" Wrap="true" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblCompetencyKSA" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>

                                    <telerik:GridTemplateColumn HeaderText="Qualification Type" DataField="QualificationTypeName" UniqueName="QualificationTypeName">
                                        <ItemStyle VerticalAlign="Middle" Width="232px" Wrap="false" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblQualificationTypeName" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </telerik:GridTemplateColumn>
                                 </Columns>
                            </telerik:GridTableView>
                            <telerik:GridTableView DataKeyNames="DutyCompetencyKSAID, DutyID" Name="DeletedQualifications" Width="100%" Caption="Qualifications Deleted" BorderWidth="1px" 
                                BorderColor="#9cb6c5" BorderStyle="Solid" ShowHeadersWhenNoRecords="false">
                                <ParentTableRelation>
                                    <telerik:GridRelationFields DetailKeyField="DutyID" MasterKeyField="DutyID" />
                                </ParentTableRelation>
                                <ItemStyle VerticalAlign="Middle" Font-Strikeout="true" ForeColor="Red" Font-Bold="true" />
                                <AlternatingItemStyle VerticalAlign="Middle" Font-Strikeout="true" ForeColor="Red" Font-Bold="true" />
                                 <Columns>
                                    <telerik:GridBoundColumn SortExpression="Qualification" HeaderText="Qualification" HeaderButtonType="TextButton" 
                                                            ItemStyle-Width="160px" ItemStyle-Wrap="false" DataField="QualificationName">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn SortExpression="CompetencyKSA" HeaderText="Description" HeaderButtonType="TextButton" 
                                                            ItemStyle-Width="447px" ItemStyle-Wrap="true" DataField="CompetencyKSA">
                                    </telerik:GridBoundColumn>
                                    <telerik:GridBoundColumn SortExpression="QualificationTypeName" HeaderText="Qualification Type" HeaderButtonType="TextButton" 
                                                            ItemStyle-Width="220px" ItemStyle-Wrap="false" DataField="QualificationTypeName">
                                    </telerik:GridBoundColumn>
                                 </Columns>
                            </telerik:GridTableView>
                         </DetailTables>
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="Duty" DataField="DutyDescription" UniqueName="DutyDescription">
                                <ItemStyle VerticalAlign="Top" Width="490px" Wrap="true" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDutyDescription" runat="server"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="% of Time" DataField="PercentageOfTime" UniqueName="PercentageOfTime">
                                <ItemStyle VerticalAlign="Top" Wrap="true" Width="95px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblPercentageOfTime" runat="server"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Duty Type" DataField="DutyTypeName" UniqueName="DutyTypeName">
                                <ItemStyle VerticalAlign="Top" Wrap="false" Width="135px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblDutyTypeName" runat="server"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Action" UniqueName="Action" Display="false">
                                <ItemStyle VerticalAlign="Top" Width="175px" />
                                <ItemTemplate>
                                    <telerik:RadComboBox ID="rcbAction" runat="server" Width="140px" Skin="WebBlue" style="position:relative; float:left;">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Accept" Value="accept" Selected="true" />
                                            <telerik:RadComboBoxItem Text="Reject" Value="reject" />
                                        </Items>
                                    </telerik:RadComboBox>&nbsp;
                                    <pde:ToolTip ID="ToolTip71" runat="server" ToolTipID="71" style="position:relative; float:left;" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                         <NoRecordsTemplate>
                            No Duties have been deleted for this Position Description during Review status.
                         </NoRecordsTemplate>
                    </MasterTableView>
                    <ClientSettings>
                        <ClientEvents OnGridCreated="GetDutyDeletesGridObject"></ClientEvents>
                    </ClientSettings>
                </telerik:RadGrid>
            </asp:Panel>    

            <asp:Panel ID="pnlQual" runat="server" Visible="true" Width="100%">
                <br />
                <div class="subTableHeader" width="100%">
                    Overall Qualifications Edited During Review &nbsp;
                    <pde:ToolTip ID="ToolTip18" runat="server" ToolTipID="18" />
                </div>
                <br />
                <telerik:RadGrid ID="rgQual" runat="server" SkinID="customRADGridView" Width="100%"
                    AllowPaging="true" PageSize="5" PagerStyle-AlwaysVisible="false" 
                    OnNeedDataSource="rgQual_NeedDataSource" OnItemDataBound="rgQual_ItemDataBound" OnPreRender="rgQual_PreRender" >
                    <PagerStyle AlwaysVisible="false" />
                    <ExportSettings OpenInNewWindow="true" />
                    <MasterTableView Width="100%" CommandItemDisplay="None" EditMode="InPlace" Name="QualMain" ClientDataKeyNames="CompetencyKSAID, PositionDescriptionID" 
                                DataKeyNames="CompetencyKSAID, PositionDescriptionID" ShowHeadersWhenNoRecords="false">
                        <RowIndicatorColumn>
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn>
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="Qualification" DataField="QualificationName"
                                UniqueName="QualificationName">
                                <ItemStyle VerticalAlign="Top" Width="120px" Wrap="false" />
                                <ItemTemplate>
                                    <asp:Label ID="lblQualificationName" runat="server"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Description" DataField="QualificationDescription"
                                UniqueName="QualificationDescription">
                                <ItemStyle VerticalAlign="Top" Width="500px" Wrap="true" />
                                <ItemTemplate>
                                    <asp:Label ID="lblQualificationDescription" runat="server"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Qualification Type" DataField="QualificationTypeName"
                                UniqueName="QualificationTypeName">
                                <ItemStyle VerticalAlign="Top" Width="135px" Wrap="false" />
                                <ItemTemplate>
                                    <asp:Label ID="lblQualificationTypeName" runat="server"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Action" UniqueName="Action" Display="false">
                                <ItemStyle VerticalAlign="Top" Width="175px" />
                                <ItemTemplate>
                                    <telerik:RadComboBox ID="rcbAction" runat="server" Width="140px" Skin="WebBlue" style="position:relative; float:left;">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Accept" Value="accept" Selected="true" />
                                            <telerik:RadComboBoxItem Text="Reject" Value="reject" />
                                        </Items>
                                    </telerik:RadComboBox>&nbsp;
                                    <pde:ToolTip ID="ToolTip71" runat="server" ToolTipID="71" style="position:relative; float:left;" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                         <NoRecordsTemplate>
                            No Overall Qualifications have been edited for this Position Description.
                         </NoRecordsTemplate>
                    </MasterTableView>
                    <ClientSettings>
                        <ClientEvents OnGridCreated="GetQualGridObject"></ClientEvents>
                    </ClientSettings>
                </telerik:RadGrid>
            </asp:Panel>

            <asp:Panel ID="pnlQualAdded" runat="server" Visible="true" Width="100%">
                <br />
                <telerik:RadGrid ID="rgQualAdds" runat="server" SkinID="customRADGridView" Width="100%"
                    AllowPaging="true" PageSize="5" PagerStyle-AlwaysVisible="false" 
                    OnNeedDataSource="rgQualAdds_NeedDataSource" OnItemDataBound="rgQualAdds_ItemDataBound" OnPreRender="rgQualAdds_PreRender" >
                    <PagerStyle AlwaysVisible="false" />
                    <ExportSettings OpenInNewWindow="true" />
                    <MasterTableView Width="100%" CommandItemDisplay="None" EditMode="InPlace" Name="QualMain" ClientDataKeyNames="CompetencyKSAID, PositionDescriptionID" 
                                DataKeyNames="CompetencyKSAID, PositionDescriptionID" ShowHeadersWhenNoRecords="false">
                        <RowIndicatorColumn>
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn>
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="Qualification" DataField="QualificationName"
                                UniqueName="QualificationName">
                                <ItemStyle VerticalAlign="Top" Width="120px" Wrap="false" />
                                <ItemTemplate>
                                    <asp:Label ID="lblQualificationName" runat="server"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Description" DataField="QualificationDescription"
                                UniqueName="QualificationDescription">
                                <ItemStyle VerticalAlign="Top" Width="500px" Wrap="true" />
                                <ItemTemplate>
                                    <asp:Label ID="lblQualificationDescription" runat="server"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Qualification Type" DataField="QualificationTypeName"
                                UniqueName="QualificationTypeName">
                                <ItemStyle VerticalAlign="Top" Width="135px" Wrap="false" />
                                <ItemTemplate>
                                    <asp:Label ID="lblQualificationTypeName" runat="server"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Action" UniqueName ="Action" Display="false">
                                <ItemStyle VerticalAlign="Top" Width="175px" />
                                <ItemTemplate>
                                    <telerik:RadComboBox ID="rcbAction" runat="server" Width="140px" Skin="WebBlue" style="position:relative; float:left;">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Accept" Value="accept" Selected="true" />
                                            <telerik:RadComboBoxItem Text="Reject" Value="reject" />
                                        </Items>
                                    </telerik:RadComboBox>&nbsp;
                                    <pde:ToolTip ID="ToolTip71" runat="server" ToolTipID="71" style="position:relative; float:left;" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                         <NoRecordsTemplate>
                            No Overall Qualifications have been added for this Position Description.
                         </NoRecordsTemplate>
                    </MasterTableView>
                    <ClientSettings>
                        <ClientEvents OnGridCreated="GetQualAddsGridObject"></ClientEvents>
                    </ClientSettings>
                </telerik:RadGrid>
            </asp:Panel>

            <asp:Panel ID="pnlQualDeleted" runat="server" Visible="true" Width="100%">
                <br />
                 <telerik:RadGrid ID="rgQualDeletes" runat="server" SkinID="customRADGridView" Width="100%"
                    AllowPaging="true" PageSize="5" PagerStyle-AlwaysVisible="false" 
                    OnNeedDataSource="rgQualDeletes_NeedDataSource" OnItemDataBound="rgQualDeletes_ItemDataBound" OnPreRender="rgQualDeletes_PreRender" >
                    <PagerStyle AlwaysVisible="false" />
                    <ExportSettings OpenInNewWindow="true" />
                    <MasterTableView Width="100%" CommandItemDisplay="None" EditMode="InPlace" Name="QualMain" ClientDataKeyNames="CompetencyKSAID, PositionDescriptionID" 
                                DataKeyNames="CompetencyKSAID, PositionDescriptionID" ShowHeadersWhenNoRecords="false">
                        <RowIndicatorColumn>
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </RowIndicatorColumn>
                        <ExpandCollapseColumn>
                            <HeaderStyle Width="20px"></HeaderStyle>
                        </ExpandCollapseColumn>
                        <Columns>
                            <telerik:GridTemplateColumn HeaderText="Qualification" DataField="QualificationName"
                                UniqueName="QualificationName">
                                <ItemStyle VerticalAlign="Top" Width="120px" Wrap="false" />
                                <ItemTemplate>
                                    <asp:Label ID="lblQualificationName" runat="server"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Description" DataField="QualificationDescription"
                                UniqueName="QualificationDescription">
                                <ItemStyle VerticalAlign="Top" Width="500px" Wrap="true" />
                                <ItemTemplate>
                                    <asp:Label ID="lblQualificationDescription" runat="server"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Qualification Type" DataField="QualificationTypeName"
                                UniqueName="QualificationTypeName">
                                <ItemStyle VerticalAlign="Top" Width="135px" Wrap="false" />
                                <ItemTemplate>
                                    <asp:Label ID="lblQualificationTypeName" runat="server"></asp:Label>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridTemplateColumn HeaderText="Action" UniqueName="Action" Display="false">
                                <ItemStyle VerticalAlign="Top" Width="175px" />
                                <ItemTemplate>
                                    <telerik:RadComboBox ID="rcbAction" runat="server" Width="140px" Skin="WebBlue" style="position:relative; float:left;">
                                        <Items>
                                            <telerik:RadComboBoxItem Text="Accept" Value="accept" Selected="true" />
                                            <telerik:RadComboBoxItem Text="Reject" Value="reject" />
                                        </Items>
                                    </telerik:RadComboBox>&nbsp;
                                    <pde:ToolTip ID="ToolTip71" runat="server" ToolTipID="71" style="position:relative; float:left;" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                        </Columns>
                         <NoRecordsTemplate>
                            No Overall Qualifications have been deleted for this Position Description.
                         </NoRecordsTemplate>
                    </MasterTableView>
                    <ClientSettings>
                        <ClientEvents OnGridCreated="GetQualDeletesGridObject"></ClientEvents>
                    </ClientSettings>
                </telerik:RadGrid>
            </asp:Panel>
        </ItemTemplate>
    </MasterTableView>
</telerik:RadGrid>            

<span class="spanAction">
    <asp:Button ID="btnSaveTop" runat="server" Visible ="false" CssClass="formBtn"  OnCommand="btnSaveTop_Click" Text="Save and Revise" ToolTip="Save and Revise" 
        OnClientClick="return blockConfirm('Duty differences?', event, 330, 150,'','Confirm Duty Differences');"/>
        &nbsp;
    <asp:Button ID="btnSaveContinue" runat="server" CssClass="formBtn"  OnCommand="btnSaveTop_Click" Text="Save and Continue" ToolTip="Save and Continue"  
        OnClientClick="return blockConfirm('Duty differences?', event, 330, 150,'','Confirm Duty Differences');"/>
</span>
<div>
    <telerik:RadWindowManager ID="RadWindowManager1" runat="server" Skin="WebBlue">
    </telerik:RadWindowManager>
</div>
