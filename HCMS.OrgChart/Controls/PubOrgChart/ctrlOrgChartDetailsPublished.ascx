<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ctrlOrgChartDetailsPublished.ascx.cs" Inherits="HCMS.OrgChart.Controls.PubOrgChart.ctrlOrgChartDetailsPublished" %>
<%@ Register TagPrefix="custom" TagName="ReadOnlyLabel" Src="~/Controls/Common/readOnlyLabel.ascx" %>
<%@ Register TagPrefix="custom" TagName="PubOrgChartDetails" Src="~/Controls/PubOrgChart/Common/pubOrgChartDetailInformation.ascx" %>

<asp:Panel ID="panelMain" runat="server">
    <custom:ReadOnlyLabel id="customReadOnlyLabel" runat="server" LabelText="Published Chart -- Read-Only View" />
    <custom:PubOrgChartDetails id="customPubOrgChartDetails" runat="server" /><br />

    <asp:Button ID="buttonChartPositions" runat="server" Text="Chart Positions" CssClass="button" CausesValidation="false" Width="175px" />
    <br /><br />
</asp:Panel>





