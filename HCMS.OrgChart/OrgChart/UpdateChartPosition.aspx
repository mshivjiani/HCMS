<%@ Page Language="C#" MasterPageFile="~/OrgChartMaster.Master"  AutoEventWireup="false" CodeBehind="UpdateChartPosition.aspx.cs"
    Inherits="HCMS.OrgChart.OrgChart.UpdateChartPosition" %>

<%@ Register TagPrefix="custom" TagName="UpdateChartPosition" Src="~/Controls/Positions/ctrlUpdateChartPosition.ascx"   %>

<asp:content id="Content1" contentplaceholderid="headContent" runat="server">
    <script type="text/javascript" src="../Src/windowDialogFunctions.js"></script>
</asp:content>

<asp:content id="Content2" contentplaceholderid="mainContent" runat="server">
        <custom:UpdateChartPosition id="customUpdateChartPosition" runat="server" />
</asp:content>
