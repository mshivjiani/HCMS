<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CareerLadderErrors.ascx.cs" Inherits="HCMS.PDExpress.Controls.CreatePD.CareerLadderErrors" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:GridView ID="gridViewErrors" runat="server" SkinID="adminGridView" Width="575px" HorizontalAlign="Center" AutoGenerateColumns="false" DataKeyNames="ErrorID">
    <EmptyDataTemplate>
        <span class="systemMessage">There are no validation actions for this position description.</span>
    </EmptyDataTemplate>
    <HeaderStyle HorizontalAlign="Left" />
    <Columns>
        <asp:BoundField HeaderText="Number" ItemStyle-Width="65px" ItemStyle-HorizontalAlign="Center" DataField="ErrorID" />
        <asp:BoundField HeaderText="Action Message" ItemStyle-HorizontalAlign="Left" DataField="ErrorMessage" />
    </Columns>
</asp:GridView>
