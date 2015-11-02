<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CreatePDMapStatusProgress.ascx.cs" Inherits="HCMS.PDExpress.Controls.CreatePD.CreatePDMapStatusProgress" %>
<%@ Register Src="~/Controls/ProgressBar/ProgressBar.ascx" TagName="ProgressBar" TagPrefix="FWSControls" %>

<asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />

<table class="siteMapTable">
    <tr>
        <td width="100%">
            <asp:SiteMapPath ID="SiteMapPath1" runat="server" />
        </td>
    </tr>
    <tr>
        <td width="100%">
            <FWSControls:ProgressBar ID="ctrlProgressBar" runat="server" PercentComplete="0" BarStyle="ieesque" BarWidth="777"  />
        </td>
    </tr>
    <tr>
        <td width="100%">
            <div class="PDMapTable">
                <span id="spnReadOnly" runat="server" />
                <span id="spnPDNumber" runat="server" />
                <span id="spnPublishedPDNumber" runat="server" />
                <span id="spnPayplanSeriesGrade" runat="server" />
                <span id="spnStatus" runat="server" />
                <span id="spnStandard" runat="server" />
                <span id="spnCopiedFrom" runat="server" />
                <span id="spnFullPerformance" runat="server" />
            </div>
        </td>
    </tr>
</table>



