<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ctrlDelegateJNP.ascx.cs" Inherits="HCMS.Portal.Controls.Admin.ctrlDelegateJNP" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>

<asp:UpdatePanel id="panelMain" runat="server">
<ContentTemplate>

<asp:Panel ID="panelSystemMessage" runat="server" Visible="false">
<br /><hr class="separator" /><div align="center" class="systemMessage"><asp:Literal ID="literalSystem" runat="server" /></div>
</asp:Panel>

<asp:Panel ID="panelData" runat="server">
    <asp:GridView ID="gridViewUsers" SkinID="adminGridView" Width="100%" runat="server" AllowSorting="false" AllowPaging="true" PageSize="10" AutoGenerateColumns="false" DataKeyNames="JNPID">
    <RowStyle HorizontalAlign="Center" />
    <EmptyDataTemplate><div align="center" class="systemMessage">There are no non-published Job Announcement Packages (JNP's) currently assigned to this user.</div></EmptyDataTemplate>
    <Columns>
        <asp:TemplateField HeaderText="Action" ItemStyle-Width="75px" ItemStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <asp:LinkButton ID="linkButtonDelegate" runat="server" Text="Delegate this JNP to Another Individual" CommandName="Edit" CausesValidation="false" />
            </ItemTemplate>
            <EditItemTemplate>
                <telerik:RadComboBox ID="radComboUsers" runat="server" AutoPostBack="false" Width="290px" />&nbsp;<asp:RequiredFieldValidator ID="requiredUsers" runat="server" ControlToValidate="radComboUsers" ErrorMessage="You must first select an account from the list before delegating a JNP.">*</asp:RequiredFieldValidator><br />
                <span id="spanAssign" runat="server"><asp:LinkButton ID="linkButtonAssign" runat="server" Text="Assign" CausesValidation="true" CommandName="Update" />&nbsp;|&nbsp;</span><asp:LinkButton ID="linkButtonCancel" runat="server" Text="Cancel" CausesValidation="false" CommandName="Cancel" />
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="JNPID" ReadOnly="true" SortExpression="JNPID" HeaderText="JAX ID" Visible="true" ItemStyle-Width="45px" />
        <asp:BoundField DataField="OrganizationCodeID" ReadOnly="true" SortExpression="OrganizationCodeID" Visible="false" />
        <asp:BoundField DataField="OrganizationDetailLineLegacy" ReadOnly="true" SortExpression="OrganizationDetailLineLegacy" HeaderText="Org Code" ItemStyle-Width="255px" ItemStyle-HorizontalAlign="Left" />
        <asp:BoundField DataField="OrganizationName" ReadOnly="true" SortExpression="OrganizationName" Visible="false"  />
        <asp:BoundField DataField="SeriesID" ReadOnly="true" Visible="false" />
        <asp:BoundField DataField="SeriesName" ReadOnly="true" SortExpression="SeriesName" HeaderText="Series Name" ItemStyle-Width="85px" ItemStyle-HorizontalAlign="Left" />
        <asp:BoundField DataField="JNPWorkflowStatusID" ReadOnly="true" Visible="false" />
        <asp:BoundField DataField="JNPWorkflowStatus" ReadOnly="true" SortExpression="JNPWorkflowStatus" HeaderText="Status" ItemStyle-Width="55px" />
        <asp:BoundField DataField="RegionID" ReadOnly="true" Visible="false" />
        <asp:BoundField DataField="RegionName" ReadOnly="true" SortExpression="RegionName"  HeaderText="Region" ItemStyle-Width="45px" /> 
    </Columns>
    </asp:GridView>
</asp:Panel>

</ContentTemplate>
</asp:UpdatePanel>

<br /><div align="center" class="sectionContainer"><asp:Button ID="buttonCancel" runat="server" Text="Go Back" CausesValidation="false" ToolTip ="Go Back"/></div>
<br />
