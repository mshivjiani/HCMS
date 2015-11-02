<%@ Page Language="C#" MasterPageFile="~/OrgChartOther.Master" AutoEventWireup="true" CodeBehind="IncludePosition.aspx.cs"
    Inherits="HCMS.OrgChart.OrgChart.IncludePosition" %>


    <%@ Register Src="~/Controls/CreateOrgChart/ctrlIncludePosition.ascx" TagName="OrgChartIncludePosition"
    TagPrefix="Include" %>

<asp:content id="Content1" contentplaceholderid="headContent" runat="server">
 </asp:content>

<asp:content id="Content2" contentplaceholderid="mainContent" runat="server">
<Include:OrgChartIncludePosition ID="ctrlIncludePosition" runat="server" />
</asp:content>