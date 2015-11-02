<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PositionFactorReview.ascx.cs"
    Inherits="HCMS.PDExpress.Controls.CreatePD.Factors.PositionFactorReview" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">

    <script type="text/javascript">
        function GetRadWindow() {
            var oWindow = null;
            if (window.radWindow)
                oWindow = window.radWindow;
            else if (window.frameElement.radWindow)
                oWindow = window.frameElement.radWindow;
            return oWindow;
        }
        function FactorReviewPopupCtrlCancel() {
            GetRadWindow().close();
        }
        function FactorReviewSaveClose() {
        //setting var eventargs to true to indicate that accept/reject was clicked
            var eventargs = 'true';
        GetRadWindow().close(eventargs);
        }
    </script>

</telerik:RadCodeBlock>
<telerik:RadScriptManager ID="RadScriptManager1" runat="server" />
<div class="requiredField" ><asp:Literal ID="litReviewChangesmsg" runat="server" Text =" HR has made changes to factor language.  Review updates and 'Accept' or 'Reject' "></asp:Literal></div>
<telerik:RadGrid ID="rgPositionFactorComp" runat="server" 
    AllowPaging="True" PageSize="5" GridLines="Both"    
    AutoGenerateColumns="False" SkinID="customRADGridView" Width="80%"
    ExportSettings-HideStructureColumns="true" 
    ExportSettings-ExportOnlyData="True" ExportSettings-IgnorePaging="true"
   ExportSettings-OpenInNewWindow ="true"
ExportSettings-FileName ="ReviewChanges"
    OnItemDataBound="rgPositionFactorComp_ItemDataBound"
    OnItemCommand="rgPositionFactorComp_ItemCommand" 
    onneeddatasource="rgPositionFactorComp_NeedDataSource" >
    <MasterTableView CommandItemDisplay="Top" ItemStyle-VerticalAlign="Top" AlternatingItemStyle-VerticalAlign="Top" >
        <RowIndicatorColumn>
            <HeaderStyle Width="20px"></HeaderStyle>
        </RowIndicatorColumn>
        <ExpandCollapseColumn>
            <HeaderStyle Width="20px"></HeaderStyle>
        </ExpandCollapseColumn>
        <Columns>       
        <telerik:GridBoundColumn DataField ="CurrentFactorFormatTypeID" UniqueName ="CurrentFactorFormatTypeID" Visible="false">
        </telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="WorkflowFactorLevel" UniqueName="WorkflowFactorLevel" 
                HeaderText="Existing Level">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="WorkflowLanguage" UniqueName="WorkflowLanguage"
                HeaderText="Existing Language">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="CurrentFactorLevel" UniqueName="CurrentFactorLevel"
                HeaderText="Current Level">
            </telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="CurrentLanguage" UniqueName="CurrentLanguage"
                HeaderText="Current Language">
            </telerik:GridBoundColumn>
            <telerik:GridTemplateColumn>
                <HeaderTemplate>
                    Difference</HeaderTemplate>
                <ItemTemplate>
                    <div id="divDiff" runat="server">
                    </div>
                </ItemTemplate>
            </telerik:GridTemplateColumn>
            <telerik:GridTemplateColumn>
                <ItemTemplate>
                <%--Adding return false; in OnClientClick will not trigger server side code. So don't add that.--%>
                    <asp:Button ID="btnAccept" runat="server" Text="Accept" 
                        CommandName="Accept" ToolTip="Accept Changes"  OnClientClick ="FactorReviewSaveClose(); "/>&nbsp;
                  <%--  <asp:Button ID="btnReject" runat="server" Text="Reject & Close" ToolTip="Reject Changes and Close"
                         CommandName="Reject" />--%></ItemTemplate>
            </telerik:GridTemplateColumn>
               <telerik:GridButtonColumn CommandName="Reject" Text ="Reject"  
                ButtonType ="PushButton"
                UniqueName="btnReject"
                ConfirmText="Are you sure you want to Reject changes?"
                ConfirmTitle="Reject Changes?" ConfirmDialogType="RadWindow"   ></telerik:GridButtonColumn>

        </Columns>
        <CommandItemTemplate >
        <div align="right" >
        <asp:LinkButton ID="ExportToWord" runat="server"
 CommandName="ExportToWord" OnClick="ExportToWord_OnClick"
  CausesValidation="false" Text="Export To Word" ></asp:LinkButton></div>
</CommandItemTemplate>
    </MasterTableView>
</telerik:RadGrid>
<br />
<asp:Label ID="lblClose" runat ="server"></asp:Label>
<telerik:RadWindowManager ID="RadWindowManager1" runat="server" Skin="WebBlue" >

</telerik:RadWindowManager>





