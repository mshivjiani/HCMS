<%@ Page Title="" Language="C#" MasterPageFile="~/OrgChartMaster.Master" AutoEventWireup="false" CodeBehind="OrgChartDetails.aspx.cs" Inherits="HCMS.OrgChart.PubOrgChart.OrgChartDetails" %>
<%@ Register TagPrefix="custom" TagName="OrgChartDetailsPublished" Src="~/Controls/PubOrgChart/ctrlOrgChartDetailsPublished.ascx"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server" />

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <custom:OrgChartDetailsPublished ID="customOrgChartDetails" runat="server" />
</asp:Content>