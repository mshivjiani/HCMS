<%@ Page Language="C#" MasterPageFile="~/OrgChartMaster.Master" AutoEventWireup="false" CodeBehind="IncludePositions.aspx.cs"
    Inherits="HCMS.OrgChart.OrgChart.IncludePositions" %>
<%@ Register TagPrefix="custom" TagName="IncludePositions"  Src="~/Controls/Positions/ctrlIncludePositions.ascx"  %>

<asp:content id="Content1" contentplaceholderid="headContent" runat="server" />

<asp:content id="Content2" contentplaceholderid="mainContent" runat="server">
    <custom:IncludePositions ID="customIncludePositions" runat="server" />
</asp:content>