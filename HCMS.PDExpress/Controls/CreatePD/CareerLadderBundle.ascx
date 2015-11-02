<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CareerLadderBundle.ascx.cs" Inherits="HCMS.PDExpress.Controls.CreatePD.CareerLadderBundle" %>
<%@ Register Assembly="Microsoft.Practices.EnterpriseLibrary.Validation.Integration.AspNet"
    Namespace="Microsoft.Practices.EnterpriseLibrary.Validation.Integration.AspNet"
    TagPrefix="EntLibVal" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<telerik:RadScriptBlock runat="server">
    <script type="text/javascript">

        function OnCLPopupWindowClose(oWnd, eventArgs) {
            if ((eventArgs.get_argument() != null) && (eventArgs.get_argument() == 'true')) {
                document.location.reload();
            }
        }

        function ShowCLActionsPopup(PDID) {
            var oWnd = $find("<%=rwCLBundleActionsPopup.ClientID%>");
            oWnd.setUrl("../Controls/CreatePD/CLBundleActionsPopup.aspx?PDID=" + PDID);
            oWnd.show();
        }
               
    </script>
</telerik:RadScriptBlock>

<asp:Panel ID="panelCareerLadderStepPDs" runat="server" Visible="false">
       <div class="subTableHeader" width="100%">
        Associated Career Ladder Position Descriptions</div>
        <br />
        <asp:Panel id="pnlCLMessage" runat="server" GroupingText="Career Ladder Notice">
            <li>Signatures: You only need to sign the Full Performance (FPL) PD in the Career Ladder.</li>
           
        </asp:Panel>
        <asp:GridView ID="gridViewCareerLadderPDs" runat="server" Width="100%" SkinID="adminGridView"
        AutoGenerateColumns="false" DataKeyNames="PositionDescriptionID">
        <RowStyle HorizontalAlign="Center" />
        <Columns>
            <asp:TemplateField HeaderText="View PD" ItemStyle-Width="60px">
                <ItemTemplate>
                    <asp:LinkButton ID="linkButtonView" runat="server" CommandName="ViewPD" Text="View" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Edit PD" ItemStyle-Width="45px">
                <ItemTemplate>
                    <asp:LinkButton ID="linkButtonEdit" runat="server" CommandName="EditPD" Text="Edit" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Position" ItemStyle-Width="65px">
                <ItemTemplate>
                    <asp:Label ID="lblLadderPosition" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="PD No." ItemStyle-Width="75px" DataField="PositionDescriptionID" />
            <asp:BoundField HeaderText="Title" ItemStyle-HorizontalAlign="Left" DataField="AgencyPositionTitle" />
            <asp:BoundField HeaderText="OPM Job Title" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="225px"
                DataField="OPMJobTitle" />
            <asp:BoundField HeaderText="Grade" ItemStyle-Width="65px" DataField="ProposedGrade" />
            <asp:TemplateField HeaderText="Actions" ItemStyle-Width="55px">
                <ItemTemplate>
                    <asp:Label ID="lblActions" runat="server"></asp:Label>              
                    <asp:Image ID="imgNoActions" runat="server" ToolTip="No action required" SkinID ="checkMarkIcon"/> 
                    <asp:ImageButton ID="imgAction" runat="server" ToolTip="Action required" ImageAlign="AbsBottom" 
                         SkinID ="actionRequired" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
</asp:Panel>

<asp:Panel runat="server" id="divActionMessageSummary" class="ActionSummary" visible="false" enableviewstate="false" GroupingText="Action Items" >
    <asp:Literal ID="literalSystemMessage" runat="server" />
</asp:Panel> 

<asp:Panel runat="server" ID="divSaveAndUnlock" class="ActionSummary" Visible ="false" enableviewstate="false" GroupingText="Action Items">
    <asp:Literal ID="literalSaveAndUnlock" runat ="server" 
    Text="All outstanding PD actions have been resolved.<br />Click the <b>Save and Unlock</b> button and notify your Supervisor that they can certify and sign the CLPD."></asp:Literal>
    <div style="text-align:right"><asp:Button ID="btnSaveAndUnlock" runat="server" Text="Save and Unlock" onclick="SaveAndUnlock_Click" /></div>
</asp:Panel>

<asp:Panel  runat="server" ID="divSignAndSubmit" class="ActionSummary" Visible ="false" enableviewstate="false" GroupingText="Action Items">
    <asp:Literal ID="literalSignAndSubmit" runat="server" 
    Text="All outstanding PD actions have been resolved.<br />Click the <b>Sign and Submit</b> button below to certify and sign CLPD."></asp:Literal>
    <div style="text-align:right"><asp:Button ID="btnSignAndSubmit" runat="server" Text="Sign and Submit" onclick="SignAndSubmit_Click" /></div>
</asp:Panel>

<telerik:RadWindow ID="rwCLBundleActionsPopup" runat="server" ReloadOnShow="true"
    Skin="WebBlue" Modal="true" Width="600px" Height="150px" Style="display: none;"
    VisibleOnPageLoad="false" Behaviors="Close" InitialBehaviors="None" VisibleStatusbar="False"
    OnClientClose="OnCLPopupWindowClose">
</telerik:RadWindow>
