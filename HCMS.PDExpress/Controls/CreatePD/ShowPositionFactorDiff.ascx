<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShowPositionFactorDiff.ascx.cs" Inherits="HCMS.PDExpress.Controls.CreatePD.ShowPositionFactorDiff" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Panel ID="pnlShowFactorDiff" runat="server" Width="90%">
    <span class="spanAction">
        <asp:Button ID="btnGoBackTop" runat="server" Text="Go Back" OnClick="GoBack" />
    </span>
    <telerik:RadGrid ID="rgFactorDiffGrid" runat="server" GridLines="Both" 
    ExportSettings-OpenInNewWindow="true" ExportSettings-FileName ="ShowDifference"
     
        ExportSettings-ExportOnlyData="True" ExportSettings-IgnorePaging="true"  
        AllowPaging="True" PageSize="5"  AutoGenerateColumns="False" OnItemDataBound="rgFactorDiffGrid_ItemDataBound" 
        OnPreRender="rgFactorDiffGrid_PreRender" SkinID="customRADGridView" 
          >
        <MasterTableView CommandItemDisplay="Top" ItemStyle-VerticalAlign="Top" AlternatingItemStyle-VerticalAlign="Top" >
            <RowIndicatorColumn>
                <HeaderStyle Width="20px"></HeaderStyle>
            </RowIndicatorColumn>
            <ExpandCollapseColumn>
                <HeaderStyle Width="20px"></HeaderStyle>
            </ExpandCollapseColumn>
           
            <Columns>
                <telerik:GridBoundColumn DataField="EFactorTitle" UniqueName="EFactorTitle" HeaderText="Factor Title">
                </telerik:GridBoundColumn>
                
                <telerik:GridBoundColumn DataField="ELanguage" UniqueName="ELanguage" Visible="true" HeaderText="Pre Populated Language">
                </telerik:GridBoundColumn>
                
                <telerik:GridTemplateColumn UniqueName="ELevelID" HeaderText="Factor Level">
                    <ItemTemplate>
                        <asp:Label ID="lblELevelID" runat="server" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                
                <telerik:GridTemplateColumn UniqueName="EPoint" HeaderText="Factor Point">
                    <ItemTemplate>
                        <asp:Label ID="lblEPoint" runat="server" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                
                <telerik:GridHTMLEditorColumn DataField="CLanguage" HeaderText="Current Language" Visible="true" UniqueName="CLanguage" ItemStyle-Wrap="true">
                </telerik:GridHTMLEditorColumn>
                
                <telerik:GridTemplateColumn UniqueName="CLevelID" HeaderText="Current Level">
                    <ItemTemplate>
                        <asp:Label ID="lblCLevelID" runat="server" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                
                <telerik:GridTemplateColumn UniqueName="CPoint" HeaderText="Current Point">
                    <ItemTemplate>
                        <asp:Label ID="lblCPoint" runat="server" />
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
                
                <telerik:GridTemplateColumn HeaderText="Difference" UniqueName="Diff">
                    <ItemTemplate>
                        <div id="divDiff" runat="server">
                        </div>
                    </ItemTemplate>
                </telerik:GridTemplateColumn>
            </Columns>
            <CommandItemTemplate>
            
                <div>
                    <asp:Literal ID="litmsg" runat="server"></asp:Literal>
                </div>
                <div style="color:black">
                <asp:Literal ID="litLegand" runat="server" Text ="Displayed below is the original Factor Language, based on OPM standards for the series/grade selected, and current Factor Language entered by the PD Creator.  Review the Difference column to determine if further edits are required."></asp:Literal></div>
                <div style="color:black"><ul><li><span class="diff_deleted">text</span>: cut from original factor language</li>
                <li><span class="diff_new">text</span>: added to original factor language</li></ul></div>
                <div align="right" >
                <asp:LinkButton ID="ExportToWord" runat="server" CommandName="ExportToWord" OnClick="ExportToWord_OnClick" CausesValidation="false" Text="Export To Word"></asp:LinkButton>
                </div>
            </CommandItemTemplate>
            
        </MasterTableView>
    </telerik:RadGrid>
    <span class="spanAction">
        <asp:Button ID="btnGoBackBottom" runat="server" Text="Go Back" OnClick="GoBack" />
    </span>
</asp:Panel>
