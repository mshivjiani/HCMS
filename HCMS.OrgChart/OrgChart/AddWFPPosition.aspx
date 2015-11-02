<%@ Page Title="" Language="C#" MasterPageFile="~/OrgChartMaster.Master" AutoEventWireup="false" CodeBehind="AddWFPPosition.aspx.cs" Inherits="HCMS.OrgChart.OrgChart.AddWFPPosition" %>
<%@ Register TagPrefix="custom" TagName="AddPosition" Src="~/Controls/Positions/ctrlAddWFPPosition.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <custom:AddPosition id="customAddWFPPosition" runat="server" />
</asp:Content>
