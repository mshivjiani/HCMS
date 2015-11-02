<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ToolTip.ascx.cs" Inherits="HCMS.Portal.Controls.ToolTip.ToolTip" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Image ID="ToolTipImage" runat="server" SkinID ="TooltipIcon" />

<telerik:RadToolTip ID="RadToolTip1" runat="server" TargetControlID="ToolTipImage" RelativeTo="Element" Position="BottomCenter" RenderInPageRoot="true" CssClass="RadToolTip_HCMS" Width="300px" EnableEmbeddedSkins="false" Animation="Fade" MouseTrailing="true" HideEvent="LeaveTargetAndToolTip" AutoCloseDelay="30000">
    <asp:FormView ID="ToolTipFormView" runat="server" DataSourceID="ToolTipDataSource" DataKeyNames="ToolTipID" ondatabound="ToolTipFormView_DataBound">
        <ItemTemplate>
        </ItemTemplate>
    </asp:FormView>
</telerik:RadToolTip>

<asp:ObjectDataSource ID="ToolTipDataSource" runat="server" TypeName="HCMS.Business.Lookups.ToolTipDataSource" SelectMethod="GetByID">
    <SelectParameters>
        <asp:ControlParameter ControlID="hdnToolTipID" Name="toolTipID" PropertyName="Value" Type="Int64" />
    </SelectParameters>
</asp:ObjectDataSource>

<asp:HiddenField ID="hdnToolTipID" runat="server" Value=""/>
