<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlAddSeriesGradeKSATaskStatement.ascx.cs"
    Inherits="HCMS.Portal.Controls.Admin.ctrlAddSeriesGradeKSATaskStatement" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<script type="text/javascript" language="javascript">
    function GetRadWindow() {
        var oWindow = null;
        if (window.radWindow)
            oWindow = window.radWindow;
        else if (window.frameElement.radWindow)
            oWindow = window.frameElement.radWindow;
        return oWindow;
    }
    function AddSeriesGradeKSATSClose() {
        GetRadWindow().close();
    }       
</script>
<asp:Table ID="tableSeriesGradeKSATS" runat="server" CssClass="blueTable" Width="780px">
    <asp:TableRow ID="TableRow2" runat="server">
        <asp:TableCell ColumnSpan="2">
            <asp:Label ID="lblSeriesGradeKSATSHeader" runat="server"></asp:Label>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server">
        <asp:TableCell>
            <asp:Label ID="lblKSA" runat="server" Text="KSA: "></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
                <telerik:RadComboBox ID="ddlKSAs" runat="server" Width="590" Height="140" EmptyMessage="Type KSA"
                    OnItemDataBound="ddlKSAs_ItemDataBound" AutoPostBack="true">
                </telerik:RadComboBox>
                <asp:Literal ID="KSAText" runat="server" Visible="false" />
                <asp:RequiredFieldValidator ID="ddlKSAsreqval" runat="server" Display="None" ErrorMessage="KSA is required."
                    ControlToValidate="ddlKSAs" ValidationGroup="Group2"></asp:RequiredFieldValidator>
            </telerik:RadAjaxPanel>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow runat="server">
        <asp:TableCell>
            <asp:Label ID="lblTaskStatements" runat="server" Text="Task Statement: "></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <asp:UpdatePanel ID="updatePanel1" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddlKSAs" />
                </Triggers>
                <ContentTemplate>
                    <telerik:RadAjaxPanel ID="RadAjaxPanel2" runat="server">
                        <telerik:RadComboBox ID="ddlTaskStatement" runat="server" Width="590" Height="140"
                            EmptyMessage="Type Task Statement" OnItemDataBound="ddlTaskStatement_ItemDataBound">
                        </telerik:RadComboBox>
                        <asp:Literal ID="TaskStatementText" runat="server" Visible="false" />
                        <asp:RequiredFieldValidator ID="ddlTaskStatementreqval" runat="server" Display="None"
                            ErrorMessage="Task Statement is required." ControlToValidate="ddlTaskStatement"
                            ValidationGroup="Group2"></asp:RequiredFieldValidator>
                    </telerik:RadAjaxPanel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow ID="TableRow1" runat="server">
        <asp:TableCell>
            <asp:UpdatePanel ID="updatePanellblmsg" runat="server" UpdateMode="Conditional">
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnSave" />
                </Triggers>
                <ContentTemplate>
                    <asp:Label ID="lblmsg" runat="server" Font-Bold="true"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:TableCell>
        <asp:TableCell>
            <div style="float: right">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="formBtn" />
                &nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="formBtn" />
            </div>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
