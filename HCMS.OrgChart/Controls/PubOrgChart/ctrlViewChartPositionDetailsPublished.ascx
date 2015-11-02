<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ctrlViewChartPositionDetailsPublished.ascx.cs" Inherits="HCMS.OrgChart.Controls.PubOrgChart.ctrlViewChartPositionDetailsPublished" %>
<%@ Register TagPrefix="custom" TagName="ReadOnlyLabel" Src="~/Controls/Common/readOnlyLabel.ascx" %>
<%@ Register TagPrefix="custom" TagName="PubOrgChartDetails" Src="~/Controls/PubOrgChart/Common/pubOrgChartDetailInformation.ascx" %>
<%@ Register TagPrefix="custom" TagName="FPPSPositionInformation" Src="~/Controls/Common/ctrlFPPSPositionInformation.ascx" %>

<asp:Panel ID="panelMain" runat="server">
    <custom:ReadOnlyLabel id="customReadOnlyLabel" runat="server" LabelText="Published Chart -- Read-Only View" />

    <div class="highlight1">Published Organization Chart Details</div><br />
    <custom:PubOrgChartDetails id="customPubOrgChartDetails" runat="server" /><br />
    
    <br />
    <div><hr class="separator" /></div><br /> 
    <div class="highlight1">FPPS Published Position Information</div>
    <br />

    <custom:FPPSPositionInformation id="customFPPSPositionInformation" runat="server" /><br />
    
    <asp:Button ID="buttonChartPositions" runat="server" Text="Chart Positions" CssClass="button" CausesValidation="false" Width="175px" />
    <asp:Button ID="buttonOrganizationChartDetails" runat="server" Text="Organization Chart Manager" CssClass="button" CausesValidation="false" Width="225px" />
    <asp:Button ID="buttonCancel" runat="server" Text="Cancel" CssClass="button" CausesValidation="false" Width="125px" />
    <br /><br />
</asp:Panel>





