<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlTest.ascx.cs" Inherits="HCMS.JNP.Controls.JQ.ctrlTest" %>
<telerik:RadCodeBlock runat ="server" >
<script type="text/javascript" >
    function moveUp(rowindex) {
        alert("Click on row instance: " + rowindex);
        var grid = $find("<%=rgFactors.ClientID %>");
        var masterTableView = grid.get_masterTableView();
        var items = masterTableView.get_dataItems();
        if (rowindex > 0)
        { rowindex }
        return false;
}
</script>
</telerik:RadCodeBlock>
<telerik:RadGrid ID="rgFactors" runat ="server" AutoGenerateColumns="false" 
    onneeddatasource="rgFactors_NeedDataSource" 
    onitemcommand="rgFactors_ItemCommand" 
    onitemdatabound="rgFactors_ItemDataBound"><ClientSettings AllowRowsDragDrop="true">
      <Selecting AllowRowSelect="True" />
</ClientSettings>

<MasterTableView >

<Columns>
<telerik:GridTemplateColumn>
<ItemTemplate><asp:ImageButton ID="imgUp" runat="server" 
ImageUrl="~/App_Themes/JNP_Default/Images/Icons/upDownArrowBlue.png" 
ToolTip="Please click to move row up"  /></ItemTemplate></telerik:GridTemplateColumn>
<telerik:GridBoundColumn DataField="JQFactorNo" HeaderText="Factor No"></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField="JQFactorTitle" HeaderText="Factor Title"></telerik:GridBoundColumn>
<telerik:GridBoundColumn DataField ="JQFactorInstruction" HeaderText="Factor Instruction"></telerik:GridBoundColumn>
</Columns></MasterTableView>
</telerik:RadGrid>