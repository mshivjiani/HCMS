<%@ Page Language="C#" MasterPageFile="~/OrgChartOther.Master" AutoEventWireup="true"
    CodeBehind="ExcludePosition.aspx.cs" Inherits="HCMS.OrgChart.OrgChart.ExcludePosition" %>

<%@ Register Src="~/Controls/CreateOrgChart/ctrlExcludePosition.ascx" TagName="OrgChartExcludePosition"
    TagPrefix="Exclude" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <Exclude:OrgChartExcludePosition ID="OrgChartExclude" runat="server" />
</asp:Content>
