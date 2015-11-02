<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ViewFullPerformancePD.ascx.cs" Inherits="HCMS.PDExpress.Controls.CreatePD.ViewFullPerformancePD" %>
<%@ Register Src="~/Controls/CreatePD/CareerLadderErrors.ascx" TagPrefix="uc" TagName="CLErrors"  %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Panel ID="panelMain" runat="server" HorizontalAlign="Center">
    <div style="width: 100%; text-align:left;">
        This position description is a Career Ladder PD associated with a full performance PD.  Please note that
        the status of this PD cannot be changed on an individual basis.  To advance this position description, you must
        advance the position of the full performance PD. To view or edit the full performance PD associated with this PD, click the respective
        link in the <b>Associated Career Ladder Position Descriptions</b> list below.<br /><br />

        <asp:LinkButton ID="linkButtonEditFullPD" runat="server" CausesValidation="false" Visible="false" Text="Review the Full Performance Position Description" />
    </div>

    <asp:UpdatePanel ID="updatePanelValidate" runat="server" UpdateMode="Conditional">
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="buttonValidate" />
        </Triggers>
        <ContentTemplate>
            <asp:panel ID="panelValidate" runat="server">To verify that this career ladder PD contains all the required data, click the "Validate Data Fields" button below.<br /><br />
                <asp:Button ID="buttonValidate" runat="server" CausesValidation="false" Text="Validate Data Fields" />
                <br /><br />
            </asp:panel>
            <asp:Panel ID="panelErrors" runat="server" Visible="false">
                <uc:CLErrors id="ctrlCLErrors" runat="server" />
                <br />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
