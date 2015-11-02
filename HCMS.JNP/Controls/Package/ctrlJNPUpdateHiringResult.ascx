<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlJNPUpdateHiringResult.ascx.cs"
    Inherits="HCMS.JNP.Controls.Package.ctrlJNPUpdateHiringResult" %>
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
    function UpdateHiringResultClose() {
        GetRadWindow().close();
    }
       
</script>
<asp:Panel ID="panelUpdateHiringResult" runat="server" Style="border-bottom: solid 1px #9cb6c5;">
    <table class="popupTable" width="100%">
        <col width="90%" />
        <tr>
            <td colspan="3">
                <div class="sectionTitle">
                    Update Hiring Result
                </div>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: bottom;" colspan="3">
                <asp:Label ID="lblJNPID" runat="server" Text="JAX ID:"></asp:Label>
                <asp:Label ID="lblJNPIDValue" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: bottom;" colspan="3">
                <asp:Label ID="lblWasSuccessfulHiring" runat="server" Text="Was someone selected for this job?"></asp:Label>
                <asp:DropDownList ID="dropWasSuccessfulHiring" runat="server">
                    <asp:ListItem Text="Yes" Value="True"></asp:ListItem>
                    <asp:ListItem Text="No" Value="False" Selected="True"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: bottom;" colspan="3">
                <asp:Label ID="lblVacancyID" runat="server" Text="Vacancy ID:"></asp:Label>
                <asp:TextBox ID="txtVacancyID" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: bottom;">
                <asp:Label ID="lblmsg" runat="server" Font-Bold="true"></asp:Label>
            </td>
            <td style="vertical-align: bottom;">
                <asp:Button ID="btnUpdateHiringResult" runat="server" Text="&nbsp;Update Hiring Result&nbsp;"
                    CssClass="formBtn" OnClick="btnUpdateHiringResult_Click" />
            </td>
            <td style="vertical-align: bottom;" align="right">
                <asp:Button ID="btnCancel" runat="server" Text="Close" ToolTip="Close" OnClick="btnCancel_Click"
                    CausesValidation="false" />
            </td>
        </tr>
    </table>
</asp:Panel>
