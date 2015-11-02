<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlJQInfo.ascx.cs" Inherits="HCMS.JNP.Controls.JQ.ctrlJQInfo" %>
<%@ Register Src="~/Controls/ToolTip/ToolTip.ascx" TagName="ToolTip" TagPrefix="tooltip" %>

<table class="blueTable" border="0" width="100%">
<col width="140px" />
<col width="280px" />
<col width="*" />
<col width="225px" />
<tr>
    <td>
        <asp:Label ID="payPlanLabel" runat="server" Text="Pay Plan: "></asp:Label>&nbsp;<tooltip:ToolTip ID="ToolTip1" runat="server" ToolTipID="2" />
    </td>
    <td colspan="3">
        <asp:Label ID="payPlanField" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
    <td>
        <asp:Label ID="seriesLabel" runat="server" Text="Series: "></asp:Label>&nbsp;<tooltip:ToolTip ID="ToolTip2" runat="server" ToolTipID="4" />
    </td>
    <td colspan="3">
        <asp:Label ID="seriesField" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
    <td>
        <asp:Label ID="isStandardLabel" runat="server" Text="Standard JQ: "></asp:Label>&nbsp;<tooltip:ToolTip ID="ToolTip3" runat="server" ToolTipID="176" />
    </td>
    <td colspan="3">
        <asp:Label ID="isStandardField" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
    <td>
        <asp:Label ID="isInterDisciplinaryLabel" runat="server" Text="Interdisciplinary: "></asp:Label>&nbsp;<tooltip:ToolTip ID="ToolTip4" runat="server" ToolTipID="78" />
     </td>
    <td colspan="3">
        <asp:Label ID="isInterDisciplinaryField" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
    <td>
        <asp:Label ID="addtlSeriesLabel" runat="server" Text="Additional Series: "></asp:Label>&nbsp;<tooltip:ToolTip ID="ToolTip5" runat="server" ToolTipID="68" />
    </td>
    <td colspan="3">
        <asp:Label ID="addtlSeriesField" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
    <td>
        <asp:Label ID="lowestAdvGradeLabel" runat="server" Text="Lowest Advertised Grade: "></asp:Label>&nbsp;<tooltip:ToolTip ID="ToolTip6" runat="server" ToolTipID="81" />
    </td>
    <td colspan="3">
        <asp:Label ID="lowestAdvGradeField" runat="server" Text=""></asp:Label>
    </td>
</tr>
<tr>
    <td>
        <asp:Label ID="highestAdvGradeLabel" runat="server" Text="Highest Advertised Grade: "></asp:Label>&nbsp;<tooltip:ToolTip ID="ToolTip7" runat="server" ToolTipID="127" />
    </td>
    <td colspan="3">
        <asp:Label ID="highestAdvGradeField" runat="server" Text=""></asp:Label>
    </td>
</tr>

<tr>
    <td>
        <asp:Label ID="jqPositionTitleLabel" runat="server" Text="OPM Job Title: "></asp:Label>&nbsp;<tooltip:ToolTip ID="ToolTip9" runat="server" ToolTipID="7" />
    </td>
    <td colspan="3">
        <asp:Label ID="jqPositionTitleField" runat="server" Text=""></asp:Label>
    </td>
</tr>
</table>
<br />

<span class="spanAction">
<asp:Button ID="btnSaveContinue" runat ="server" Text="Save & Continue" 
    onclick="btnSaveContinue_Click" />

</span>