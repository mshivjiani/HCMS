<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ctrlViewOrgChart.ascx.cs" Inherits="HCMS.OrgChart.Controls.OrgChart.ctrlViewOrgChart" %>
<%@ Register TagPrefix="custom" TagName="ReadOnlyLabel" Src="~/Controls/Common/readOnlyLabel.ascx" %>
<%@ Register TagPrefix="custom" TagName="OrgChartDetailInformation" Src="~/Controls/OrgChart/Common/orgChartDetailInformation.ascx" %>
<%@ Register TagPrefix="custom" TagName="DisplayChart" Src="~/Controls/Common/ctrlDisplayOrgChart.ascx" %>

<asp:Panel ID="panelMain" runat="server">
<custom:ReadOnlyLabel id="customReadOnlyLabel" runat="server" LabelText="In Process Chart -- Read-Only View" />
<custom:OrgChartDetailInformation id="customOrgChartDetails" runat="server" />

<custom:DisplayChart id="customDisplayChart" runat="server" />

<asp:Button ID="buttonChartPositions" runat="server" Text="Chart Positions" CssClass="button" CausesValidation="false" Width="175px" />
<asp:Button ID="buttonOrganizationChartDetails" runat="server" Text="Organization Chart Manager" CssClass="button" CausesValidation="false" Width="225px" />
        
<br /><br />
</asp:Panel>