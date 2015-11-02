<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlAddEditWorkflowAction.ascx.cs"
    Inherits="HCMS.Portal.Controls.Admin.ctrlAddEditWorkflowAction" %>
<%@ Register Assembly="Microsoft.Practices.EnterpriseLibrary.Validation.Integration.AspNet"
    Namespace="Microsoft.Practices.EnterpriseLibrary.Validation.Integration.AspNet"
    TagPrefix="EntLibVal" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="pde" %>
<%@ Register Src="~/Controls/Message/Message.ascx" TagName="Message" TagPrefix="CreateAction" %>
<telerik:RadWindowManager ID="RadWindowManagerActions" runat="server" Behaviors="Default"
    Skin="WebBlue" ReloadOnShow="false">
    <Windows>
        <telerik:RadWindow ID="rwrgWorkflowActions" runat="server" RegisterWithScriptManager="true"
            Skin="WebBlue" Height="600px" Width="800px" Behaviors="Close" VisibleStatusbar="false"
            Modal="true" ReloadOnShow="true">
        </telerik:RadWindow>
    </Windows>
</telerik:RadWindowManager>


<%--<div class="subTableHeader" id="divWorkflowRuleInfo" runat="server">
    Current Rule
</div>
<asp:Table ID="tableWorkflowRuleInfo" runat="server" CssClass="blueTable" Width="100%">
    <asp:TableRow ID="TableRow2" runat="server">
        <asp:TableCell>
            <asp:Label ID="lblWorkflowGroupNameValue" runat="server"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label ID="lblStaffingObjectNameValue" runat="server"></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label ID="lblCurrentStatusValue" runat="server"></asp:Label>
        </asp:TableCell>      
    </asp:TableRow>
</asp:Table>

<br />
<br />--%>
<div class="subTableHeader">
    <asp:Label ID="lblHeader" runat="server"></asp:Label>
</div>
<asp:Table ID="tableWorkflowAction" runat="server" CssClass="blueTable" Width="100%">
    <asp:TableRow runat="server" ID="trActionType">
        <asp:TableCell Width="20%">
            <asp:Label ID="lblActionType" runat="server" Text="Action Type:"></asp:Label>
            &nbsp; <span class="required">*</span> &nbsp;          
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadComboBox ID="ddlActionType" Width="300px" runat="server"
                MarkFirstMatch="true" />
            <asp:RequiredFieldValidator ID="ddlActionTypereqval" runat="server" Display="None"
                ErrorMessage="Action Type is required." ControlToValidate="ddlActionType" InitialValue="<<- Select Action Type ->>"
                ValidationGroup="Group2"></asp:RequiredFieldValidator>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow ID="TableRow1" runat="server">
        <asp:TableCell>
            <asp:Label ID="lblmsg" runat="server" Font-Bold="true"></asp:Label>
        </asp:TableCell>
        <asp:TableCell CssClass="Action">
            <asp:Button ID="btnContinue" runat="server" Text="Save and Continue" ToolTip="Save and Continue"
                CssClass="formBtn" ValidationGroup="Group4" /> &nbsp;&nbsp;
                 <asp:Button ID="btnCancel" runat="server" Text="Cancel" ToolTip="Cancel"
                CssClass="formBtn" ValidationGroup="Group4" />    
           <%-- <asp:Button ID="btnEditRule" runat="server" Text="Go to Edit Rule" ToolTip="Go to Edit Rule"
                CssClass="formBtn" ValidationGroup="Group5" />--%>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
