<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowExistingConfirmation.aspx.cs"
    Inherits="HCMS.PDExpress.CreatePD.ShowExistingConfirmation" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
 <style type="text/css">
.visibleMessage
{
    display:block; 
    margin:10px 10px; 
    padding:10px; 
    width:95%; 
    border:solid 1px black;     
    font-size:larger;
            
}
</style>
    <telerik:RadCodeBlock ID="rcbCodeBlock" runat="server">

        <script type="text/javascript">
            function GetRadWindow() {
                var oWindow = null;
                if (window.radWindow)
                    oWindow = window.radWindow;
                else if (window.frameElement.radWindow)
                    oWindow = window.frameElement.radWindow;
                return oWindow;
            }
            function GetVal() {
                var a = null;
                var f = document.forms[0];
                var e = f.elements["rblShowExisting"];

                for (var i = 0; i < e.length; i++) {
                    if (e[i].checked) {
                        a = e[i].value;
                        break;
                    }
                }
                return a;
            }

            function returnArg() {
                var oWnd = GetRadWindow();
                var val = GetVal();

                oWnd.close(val);
            } 
        </script>

    </telerik:RadCodeBlock>
</head>
<body style="background-color:#ffffff;">
    <form id="form1" runat="server">
  <div>
    <table width="100%" class="blueTable">
        <tr>
            <td>
                <asp:Literal ID="litWarning" runat="server" Text="Existing PDs of this Series/Grade are already classified in PD Express."></asp:Literal>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Literal ID="lit1" runat="server" Text="Select <b>'Show Existing PDs'</b> to go to the Search screen and copy one of these  PDs."></asp:Literal>
            </td>
        </tr>
        <tr>
            <td>
                Or
            </td>
        </tr>
        <tr>
            <td>
                <asp:Literal ID="lit2" runat="server" Text="To Save the information entered and create a new PD, select <b>'Save and Continue'</b>."></asp:Literal>
            </td>
        </tr>
    </table>
    </div>
    <div>
    <table width="100%" class="blueTable">
        <tr>
            <td>
                <asp:RadioButtonList ID="rblShowExisting" runat="server">
                    <asp:ListItem Text="Show Existing PDs" Value="1" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="Save and Continue" Value="2"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>
    </div>
    <div>
    <span id="spanAction" class="spanAction">
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="returnArg(); return false;" /></span>
        </div>
    </form>
</body>
</html>
