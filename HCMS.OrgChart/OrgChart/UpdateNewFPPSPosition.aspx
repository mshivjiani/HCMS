<%@ Page Title="" Language="C#" MasterPageFile="~/OrgChartMaster.Master" AutoEventWireup="false" CodeBehind="UpdateNewFPPSPosition.aspx.cs" Inherits="HCMS.OrgChart.OrgChart.UpdateNewFPPSPosition" %>
<%@ Register TagPrefix="custom" TagName="UpdateFPPSPosition" Src="~/Controls/Positions/ctrlUpdateFPPSPosition.ascx"   %>

<asp:content id="Content1" contentplaceholderid="headContent" runat="server">
    <script type="text/javascript" src="../Src/windowDialogFunctions.js"></script>
</asp:content>

<asp:content id="Content2" contentplaceholderid="mainContent" runat="server">
        <custom:UpdateFPPSPosition id="customNewFPPSPosition" runat="server" />
</asp:content>
