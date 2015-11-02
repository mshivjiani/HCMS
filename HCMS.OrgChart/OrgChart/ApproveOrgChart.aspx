<%@ Page Language="C#"  MasterPageFile="~/OrgChartMaster.Master" AutoEventWireup="true" CodeBehind="ApproveOrgChart.aspx.cs" Inherits="HCMS.OrgChart.OrgChart.ApproveOrgChart" %>

<%@ Register Src="~/Controls/CreateOrgChart/ctrlApproveOrgChart.ascx" TagName="ApproveOrgChart" TagPrefix="Approve" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
 
</asp:Content>

<asp:content id="Content2" contentplaceholderid="mainContent" runat="server">
<Approve:ApproveOrgChart ID="ctrlApproveOrgChart" runat="server" />
</asp:content>
