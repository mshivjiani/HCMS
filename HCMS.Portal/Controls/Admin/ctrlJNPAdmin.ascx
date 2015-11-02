<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlJNPAdmin.ascx.cs" Inherits="HCMS.Portal.Controls.Admin.ctrlJNPAdmin" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<div class="requiredField">Use any and/or all of the criteria below to search for Job Announcement Packages in the system.</div>
<asp:Panel ID="pnlSearch" runat ="server" DefaultButton ="buttonSearch">
<div class="sectionContainer">

<table border="0" cellpadding="2" cellspacing="1" width="95%">
<col width="110px" />
<tr>
    <td>JAX ID:</td>
    <td><asp:TextBox ID="textboxJNPID" runat="server" Width="150px" Columns="25" /><asp:CompareValidator Display="None" Operator="DataTypeCheck" Type="Integer" ID="compareValJNPID" runat="server" ErrorMessage="The JAX ID specified is not a valid number." ControlToValidate="textboxJNPID" /></td>
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
    <td><asp:Button ID="buttonSearch" runat="server" Text="Search JAX" /></td>
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
<asp:GridView ID="gridViewJNP" runat="server" Width="100%" SkinID="adminGridView" AutoGenerateColumns="false" 
    DataKeyNames="JNPID" PageSize="10" AllowPaging="true">
<RowStyle HorizontalAlign="Center" />
<EmptyDataTemplate>There are no Job Announcement Packages in the system that match your search criteria.</EmptyDataTemplate>
<Columns>
<asp:TemplateField HeaderText="Activate/Inactivate" ItemStyle-Width="115px"><ItemTemplate>
<asp:ImageButton ID="imageButtonAction" runat="server" />
</ItemTemplate></asp:TemplateField>
<asp:BoundField HeaderText="JAX ID" ItemStyle-HorizontalAlign="Left" DataField="JNPID" SortExpression="JNPID" />
<asp:BoundField HeaderText="Title" ItemStyle-HorizontalAlign="Left" DataField="JNPTitle" />
<asp:BoundField HeaderText="Workflow Status" ItemStyle-Width="165px" DataField="JNPWorkflowStatus" />
</Columns>
</asp:GridView>
</asp:Panel>
<br />

</ContentTemplate>
</asp:UpdatePanel>
