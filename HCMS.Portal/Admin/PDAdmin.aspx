<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="false" CodeBehind="PDAdmin.aspx.cs" Inherits="HCMS.Portal.Admin.PDAdmin" Title="PD Activation / Inactivation" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server" >


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">

<div class="requiredField">Use any and/or all of the criteria below to search for position descriptions in the system.</div>
<asp:Panel ID="pnlSearch" runat ="server" DefaultButton ="buttonSearch">
<div class="sectionContainer">

<table border="0" cellpadding="2" cellspacing="1" width="95%">
<col width="110px" />
<tr>
    <td>PD No.:</td>
    <td><asp:TextBox ID="textboxPDID" runat="server" Width="150px" Columns="25" /><asp:CompareValidator Display="None" Operator="DataTypeCheck" Type="Integer" ID="compareValPDID" runat="server" ErrorMessage="The PD No. specified is not a valid number." ControlToValidate="textboxPDID" /></td>
</tr>

<tr id="rowRegion" runat="server" visible="false">
    <td>Region:</td>
    <td><telerik:RadComboBox ID="radDropdownRegions" runat="server" AutoPostBack="true" Width="450px" MarkFirstMatch="true" /></td>
</tr>

<tr>
    <td>Organization Code:</td>
    <td><telerik:RadComboBox ID="radDropdownOrgCodes" runat="server" AutoPostBack="false" Width="450px" MarkFirstMatch="true" /></td>
</tr>

<tr>
    <td>Creator:</td>
    <td><telerik:RadComboBox ID="radDropdownUsers" runat="server" AutoPostBack="false" Width="450px" MarkFirstMatch="true" /></td>
</tr>

<tr>
    <td></td>
    <td><asp:Button ID="buttonSearch" runat="server" Text="Search Position Descriptions" /></td>
</tr>
</table>
</div>
</asp:Panel>
<br />
<asp:UpdateProgress ID="progressSearch" runat="server">
<ProgressTemplate><br /><div align="center"><asp:Image ID="imageLoading" runat="server" SkinID="loadingIcon" /></div></ProgressTemplate>
</asp:UpdateProgress>

<asp:UpdatePanel ID="updatePanelMain" runat="server" RenderMode="Block" UpdateMode="Conditional">
<Triggers><asp:AsyncPostBackTrigger ControlID="buttonSearch" /></Triggers>

<ContentTemplate>

<asp:Panel ID="panelResults" runat="server">
<asp:GridView ID="gridViewPD" runat="server" Width="100%" SkinID="adminGridView" AutoGenerateColumns="false" 
    DataKeyNames="PositionDescriptionID" PageSize="10" AllowPaging="true">
<RowStyle HorizontalAlign="Center" />
<EmptyDataTemplate>There are no position descriptions in the system that match your search criteria.</EmptyDataTemplate>
<Columns>
<asp:TemplateField HeaderText="Activate/Inactivate" ItemStyle-Width="115px"><ItemTemplate>
<asp:ImageButton ID="imageButtonAction" runat="server" />
</ItemTemplate></asp:TemplateField>
<asp:TemplateField HeaderText="PD No." ItemStyle-Width="85px" SortExpression="PositionDescriptionID" >
<ItemTemplate>
<telerik:RadListBox ID="lstPDs" runat ="server" CssClass="borderlessRadListBox" ></telerik:RadListBox>
</ItemTemplate>
</asp:TemplateField>

<asp:BoundField HeaderText="Title" ItemStyle-HorizontalAlign="Left" DataField="AgencyPositionTitle" />
<asp:BoundField HeaderText="Workflow Status" ItemStyle-Width="165px" DataField="WorkflowStatusName" />
</Columns>
</asp:GridView>
</asp:Panel>
<br />

</ContentTemplate>
</asp:UpdatePanel>

</asp:Content>
