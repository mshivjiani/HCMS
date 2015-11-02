<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlMinimumQualifications.ascx.cs"
    Inherits="HCMS.JNP.Controls.CR.ctrlMinimumQualifications" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="tooltip" %>
<script type="text/javascript" language="javascript">
    function GetRadWindow() {
        var oWindow = null;
        if (window.radWindow)
            oWindow = window.radWindow;
        else if (window.frameElement.radWindow)
            oWindow = window.frameElement.radWindow;
        return oWindow;
    }
    function MinimumQualificationClose() {
        GetRadWindow().close();
    }       
</script>
<table id="tableSeriesGradeKSATS" class="blueTable" width="500px">
    <tr>
        <td>
            <asp:Label ID="lblHeader" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblMinQual" runat="server" Text="Minimum Qualification: "></asp:Label>&nbsp;<tooltip:ToolTip
                ID="ToolTip1" runat="server" ToolTipID="112" />
            <br />
            <asp:TextBox TextMode="MultiLine" Rows="5" ID="lMinQualText" runat="server" Width="500px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <span class="spanAction">
                <asp:Button ID="btnCancel" runat="server" Text="Close" ToolTip="Close" OnClientClick="MinimumQualificationClose();"
                    OnClick="btnCancel_Click" />
            </span>
        </td>
    </tr>
</table>
