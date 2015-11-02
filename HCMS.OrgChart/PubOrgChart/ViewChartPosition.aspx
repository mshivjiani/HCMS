<%@ Page Title="" Language="C#" MasterPageFile="~/OrgChartMaster.Master" AutoEventWireup="false" CodeBehind="ViewChartPosition.aspx.cs" Inherits="HCMS.OrgChart.PubOrgChart.ViewChartPosition" %>
<%@ Register TagPrefix="custom" TagName="ViewChartPositionDetails" Src="~/Controls/PubOrgChart/ctrlViewChartPositionDetailsPublished.ascx"  %>

<asp:content id="Content1" contentplaceholderid="headContent" runat="server" />

<asp:content id="Content2" contentplaceholderid="mainContent" runat="server">
        <custom:ViewChartPositionDetails id="customViewChartPositionDetails" runat="server" />
</asp:content>
