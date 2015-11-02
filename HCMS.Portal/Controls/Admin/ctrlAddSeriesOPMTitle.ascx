<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlAddSeriesOPMTitle.ascx.cs"
    Inherits="HCMS.Portal.Controls.Admin.ctrlAddSeriesOPMTitle" %>
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
    function AddSeriesOPMTitleClose() {
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
            <asp:Label ID="lblKSA" runat="server" Text="OPM Title: "></asp:Label>
        </asp:TableCell>
        <asp:TableCell>
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
            <asp:TextBox ID="txtOPMTitle" runat="server" Width="580" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="opmTitle" runat="server" Display="None" ErrorMessage="OPM Title is required."
                    ControlToValidate="txtOPMTitle" ValidationGroup="Group2"></asp:RequiredFieldValidator>
            </telerik:RadAjaxPanel>
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
                <asp:Button ID="btnCancel" runat="server" Text="Close" ToolTip="Close" />
            </div>
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>
