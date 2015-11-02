<%@ Page Language="C#" MasterPageFile="~/OrgChartOther.Master" AutoEventWireup="true" CodeBehind="DeletePosition.aspx.cs"
    Inherits="HCMS.OrgChart.OrgChart.DeletePosition" %>

<%@ Register Src="~/Controls/CreateOrgChart/ctrlDeletePosition.ascx" TagName="OrgChartDeletePosition" TagPrefix="Delete" %>
<asp:content id="Content1" contentplaceholderid="headContent" runat="server">
 </asp:content>

<asp:content id="Content2" contentplaceholderid="mainContent" runat="server">
<Delete:OrgChartDeletePosition ID="ctrlDeletePosition" runat="server" />
</asp:content>