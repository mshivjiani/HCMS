
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctlFactor1PopUp.ascx.cs"
Inherits="HCMS.JNP.Controls.JA.ctlFactor1PopUp" %>
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
    function Factor1Close() {
        GetRadWindow().close(); 
    }       
</script>
<table id="Fac1" class="blueTable" width="500px">
    <tr>
        <td>
            <asp:Label ID="lblHeader" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblFacto1" runat="server" Text="Factor One Language: "></asp:Label>
            <br />
            <asp:TextBox TextMode="MultiLine" Rows="15" ID="FactorOneText" runat="server" Width="550px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <span class="spanAction">
                <asp:Button ID="btnCancel" runat="server" Text="Close" ToolTip="Close" OnClientClick="Factor1Close();"
                     />
            </span>
        </td>
    </tr>
</table>
