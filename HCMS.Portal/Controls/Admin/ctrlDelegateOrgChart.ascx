<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlDelegateOrgChart.ascx.cs"
    Inherits="HCMS.Portal.Controls.Admin.ctrlDelegateOrgChart" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:UpdatePanel ID="panelMain" runat="server">
    <ContentTemplate>
        <asp:Panel ID="panelSystemMessage" runat="server" Visible="false">
            <br />
            <hr class="separator" />
            <div align="center" class="systemMessage">
                <asp:Literal ID="literalSystem" runat="server" /></div>
        </asp:Panel>
        <asp:Panel ID="panelData" runat="server">
            <asp:GridView ID="gridViewUsers" SkinID="adminGridView" Width="100%" runat="server"
                AllowSorting="false" AllowPaging="true" PageSize="10" AutoGenerateColumns="false"
                DataKeyNames="OrganizationChartID">
                <RowStyle HorizontalAlign="Center" />
                <EmptyDataTemplate>
                    <div align="center" class="systemMessage">
                        There are no non-published Organization Charts currently assigned to this user.</div>
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField HeaderText="Action" ItemStyle-Width="75px" ItemStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:LinkButton ID="linkButtonDelegate" runat="server" Text="Delegate this Organization Chart to Another Individual"
                                CommandName="Edit" CausesValidation="false" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <telerik:RadComboBox ID="radComboUsers" runat="server" AutoPostBack="false" Width="290px" />
                            &nbsp;<asp:RequiredFieldValidator ID="requiredUsers" runat="server" ControlToValidate="radComboUsers"
                                ErrorMessage="You must first select an account from the list before delegating a JNP.">*</asp:RequiredFieldValidator><br />
                            <span id="spanAssign" runat="server">
                                <asp:LinkButton ID="linkButtonAssign" runat="server" Text="Assign" CausesValidation="true"
                                    CommandName="Update" />&nbsp;|&nbsp;</span><asp:LinkButton ID="linkButtonCancel"
                                        runat="server" Text="Cancel" CausesValidation="false" CommandName="Cancel" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="OrganizationChartID" ReadOnly="true" SortExpression="OrganizationChartID"
                        HeaderText="OrgChart ID" Visible="true" ItemStyle-Width ="30px" />
                    <asp:BoundField DataField="OrganizationCodeID" ReadOnly="true" SortExpression="OrganizationCodeID"
                        Visible="false" />
                    <asp:TemplateField HeaderText="Org Code" >
                    <HeaderStyle Width="120px" />
                      <ItemTemplate>
                            <%# (Container.DataItem as HCMS.Business.OrganizationChart.OrganizationChart).OrgCode.DetailLineLegacy %>
                       </ItemTemplate>
                    </asp:TemplateField>
                   
                    <asp:BoundField DataField="OrgWorkflowStatusID" ReadOnly="true" Visible="false" />
                    <asp:BoundField DataField="OrgWorkflowStatusName" ReadOnly="true" SortExpression="OrgWorkflowStatusName"
                        HeaderText="Status" ItemStyle-Width="45px" />
                </Columns>
            </asp:GridView>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<br />
<div align="center" class="sectionContainer">
    <asp:Button ID="buttonCancel" runat="server" Text="Go Back" CausesValidation="false"
        ToolTip="Go Back" /></div>
<br />
