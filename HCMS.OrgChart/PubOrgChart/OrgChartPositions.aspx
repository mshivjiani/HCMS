<%@ Page Title="" Language="C#" MasterPageFile="~/OrgChartMaster.Master" AutoEventWireup="false" CodeBehind="OrgChartPositions.aspx.cs" Inherits="HCMS.OrgChart.PubOrgChart.OrgChartPositions" %>
<%@ Register TagPrefix="custom" TagName="OrgChartPositionsPublished" Src="~/Controls/PubOrgChart/ctrlOrgChartPositionsPublished.ascx"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server" />

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <custom:OrgChartPositionsPublished ID="customOrgChartPositionsPublished" runat="server" />
</asp:Content>
