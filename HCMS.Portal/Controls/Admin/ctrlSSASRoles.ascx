<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlSSASRoles.ascx.cs" Inherits="HCMS.Portal.Controls.Admin.ctrlSSASRoles" %>
<div>

<asp:ImageButton  ID="imgPdf" runat ="server" SkinID="pdfIcon"  ToolTip="Export To Pdf"
        AlternateText="Export To PDF" CommandName="ExportToPdf" 
        onclick="imgPdf_Click" />&nbsp; &nbsp;
<asp:ImageButton ID="imgExcel" runat ="server" SkinID ="excelIcon" ToolTip="Export To Excel" AlternateText ="Export To Excel"  CommandName="ExportToExcel" OnClick ="imgExcel_Click" />


<telerik:RadGrid ID="rgSSASRoles" runat ="server" AllowPaging="True"  

        AutoGenerateColumns="False" CellSpacing="0" GridLines="None"  AllowFilteringByColumn="True" 
        onneeddatasource="rgSSASRoles_NeedDataSource">
         <ExportSettings IgnorePaging="true" OpenInNewWindow="true" ExportOnlyData ="true" FileName="SSAS Roles"> 
            <Pdf PageHeight="210mm" PageWidth="297mm" DefaultFontFamily="Arial Unicode MS" PageTopMargin="45mm"> </Pdf> 
            <Excel Format ="Biff" />
        </ExportSettings> 
        <GroupingSettings CaseSensitive ="false" />
<MasterTableView>
<CommandItemSettings ExportToPdfText="Export to PDF" ></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
        <telerik:GridBoundColumn DataField="RoleID" 
            FilterControlAltText="Filter RoleID column" HeaderText="Role ID" Visible="false" 
            UniqueName="RoleID">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="RoleName" 
            FilterControlAltText="Filter RoleName column" HeaderText="Role Name" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains" FilterControlWidth ="300px" 
            UniqueName="RoleName">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="MemberID" 
            FilterControlAltText="Filter MemberID column" HeaderText="Member ID"  Visible ="false" 
            UniqueName="MemberID">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="MemberName" 
            FilterControlAltText="Filter MemberName column" HeaderText="Member Name" AutoPostBackOnFilter="true" CurrentFilterFunction="Contains"  FilterControlWidth ="300px"
            UniqueName="MemberName">
        </telerik:GridBoundColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>
</MasterTableView>

<FilterMenu EnableImageSprites="False"></FilterMenu>
 
</telerik:RadGrid>
</div>