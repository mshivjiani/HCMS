<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="CreatePDChoice.ascx.cs" Inherits="HCMS.PDExpress.Controls.CreatePD.CreatePDChoice" %>
<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="pde" %>

<table id="tblCreatePD" class="blueTable" width="100%">
<tr><th    class="blueGroupHeader"><asp:Literal ID="litFromExisting" runat ="server" Text="Create From Existing"></asp:Literal></th></tr>
    <tr><td>&nbsp;</td></tr>

    <tr>
        <td class="leftImage">
            <asp:RadioButton ID="rbCreateUsingExisting" runat="server" GroupName="CreatePDGroup" ValidationGroup="CreatePDValGroup" Text="Create using Existing Position Description" Checked="true" />
            &nbsp;
            <pde:ToolTip ID="ToolTip60" runat="server" ToolTipID="60"/>
        </td>
    </tr>
   
    <tr>
        <td class="leftImage">
            <asp:RadioButton ID="rbCreateUsingStandard" runat="server" GroupName="CreatePDGroup" ValidationGroup="CreatePDValGroup" Text="Create using Standard Position Description" />
            &nbsp;
            <pde:ToolTip ID="ToolTip61" runat="server" ToolTipID="61"/>
        </td>
    </tr>
     <tr>
        <td class="leftImage">
            <asp:RadioButton ID="rbCreateUsingCL" runat="server" GroupName="CreatePDGroup" ValidationGroup="CreatePDValGroup" Text="Create using Existing Career Ladder Position Description" />
            &nbsp;
            <pde:ToolTip ID="ToolTipExistingCL" runat="server" ToolTipID="60"/>
        </td>
    </tr>
    <tr>
        <td class="leftImage">
            <asp:RadioButton ID="rbCreateSOD" runat="server" GroupName="CreatePDGroup" ValidationGroup="CreatePDValGroup" Text="Create Statement of Difference Position Description" />
            &nbsp;
            <pde:ToolTip ID="ToolTip62" runat="server" ToolTipID="62"/>
        </td>
    </tr>
    <tr><td>&nbsp;</td></tr>
    <tr><th  class="blueGroupHeader"><asp:Literal ID="litCreateNew" runat ="server" Text="Create New"></asp:Literal></th></tr>
        <tr><td>&nbsp;</td></tr>

 <tr>
        <td class="leftImage">
            <asp:RadioButton ID="rbCreateNewPD" runat="server" GroupName="CreatePDGroup" ValidationGroup="CreatePDValGroup" Text="Create New Position Description" />
            &nbsp;
            <pde:ToolTip ID="ToolTip64" runat="server" ToolTipID="64"/>
        </td>
    </tr>
    <tr>
        <td class="leftImage">
            <asp:RadioButton ID="rbCreateLadder" runat="server" GroupName="CreatePDGroup" ValidationGroup="CreatePDValGroup" Text="Create Career Ladder Position Description" />
            &nbsp;
            <pde:ToolTip ID="ToolTip63" runat="server" ToolTipID="63"/>
        </td>
    </tr>
   
    <tr>
        <td class="leftImage">
            <asp:RadioButton ID="rbCreateNewStandardPD" runat="server" GroupName="CreatePDGroup" ValidationGroup="CreatePDValGroup" Text="Create New Standard Position Description" />
            &nbsp;
            <pde:ToolTip ID="ToolTip65" runat="server" ToolTipID="65"/>
        </td>
    </tr>
        <tr><td>&nbsp;</td></tr>

</table>
<span class="spanAction">
    <asp:Button ID="btnContinue" runat="server"  Text="Continue" CssClass="formBtn" ToolTip="Continue" />
</span>

<br />
