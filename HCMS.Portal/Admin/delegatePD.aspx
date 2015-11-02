<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="delegatePD.aspx.cs" Inherits="HCMS.Portal.Admin.delegatePD" Title="PD Delegation Change" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
<style type="text/css"  >

</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

<asp:UpdatePanel id="panelMain" runat="server">
<ContentTemplate>

<asp:Panel ID="panelSystemMessage" runat="server" Visible="false">
<br /><hr class="separator" /><div align="center" class="systemMessage"><asp:Literal ID="literalSystem" runat="server" /></div>
</asp:Panel>

<asp:Panel ID="panelData" runat="server">
<asp:GridView ID="gridViewUsers" SkinID="adminGridView" Width="100%" runat="server" AllowSorting="false" AllowPaging="true" PageSize="10" AutoGenerateColumns="false" DataKeyNames="positionDescriptionID">
<RowStyle HorizontalAlign="Center" />
<EmptyDataTemplate><div align="center" class="systemMessage">There are no non-published position descriptions (PD's) currently assigned to this user.</div></EmptyDataTemplate>
<Columns>
<asp:TemplateField HeaderText="Action" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Center">
<ItemTemplate>
<asp:LinkButton ID="linkButtonDelegate" runat="server" Text="Delegate this PD to Another Individual" CommandName="Edit" CausesValidation="false" />
</ItemTemplate>
<EditItemTemplate>
<telerik:RadComboBox ID="radComboUsers" runat="server" AutoPostBack="false" Width="290px" />&nbsp;<asp:RequiredFieldValidator ID="requiredUsers" runat="server" ControlToValidate="radComboUsers" ErrorMessage="You must first select an account from the list before delegating a PD.">*</asp:RequiredFieldValidator><br />
<span id="spanAssign" runat="server"><asp:LinkButton ID="linkButtonAssign" runat="server" Text="Assign" CausesValidation="true" CommandName="Update" />&nbsp;|&nbsp;</span><asp:LinkButton ID="linkButtonCancel" runat="server" Text="Cancel" CausesValidation="false" CommandName="Cancel" />
</EditItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText ="PD No." SortExpression="PositionDescriptionID" ItemStyle-Width="65px" >
<ItemTemplate>
<div style="text-align:left;">
<telerik:RadListBox ID="lstPDs" runat ="server" CssClass="borderlessRadListBox" ></telerik:RadListBox></div>
</ItemTemplate>
<EditItemTemplate ><div style="text-align:left">
<telerik:RadListBox ID="lstPDs" runat ="server" CssClass="borderlessRadListBox"></telerik:RadListBox></div>
</EditItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="OrganizationCodeLegacy" ReadOnly="true" SortExpression="OrganizationCode" HeaderText="Org Code" ItemStyle-Width="55px" />
<asp:BoundField DataField="JobSeries" ReadOnly="true" SortExpression="JobSeries" HeaderText="Series" ItemStyle-Width="45px" Visible="false" />
<asp:BoundField DataField="SeriesDefinition" ReadOnly="true" SortExpression="SeriesDefinition" HeaderText="Series Name" />
<asp:BoundField DataField="CurrentWorkflowStatus" ReadOnly="true" HeaderText="Status" ItemStyle-Width="85px" />
</Columns>
</asp:GridView>
</asp:Panel>

</ContentTemplate>
</asp:UpdatePanel>

<br /><div align="center" class="sectionContainer"><asp:Button ID="buttonCancel" runat="server" Text="Go Back" CausesValidation="false" ToolTip ="Go Back"/></div>
<br />
</asp:Content>
