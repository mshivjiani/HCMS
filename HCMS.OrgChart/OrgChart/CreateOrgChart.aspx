<%@ Page Title="" Language="C#" MasterPageFile="~/OrgChartMaster.Master" AutoEventWireup="false" CodeBehind="CreateOrgChart.aspx.cs" Inherits="HCMS.OrgChart.OrgChart.CreateOrgChart" %>
<%@ Register Src="~/Controls/OrgChart/ctrlCreateOrgChart.ascx" TagPrefix="custom" TagName="OrgChartCreate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
 
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <custom:OrgChartCreate ID="ctrlCreateOrgChart" runat="server" />
</asp:Content>
