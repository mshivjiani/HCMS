<%@ Page Language="C#" MasterPageFile="~/OrgChartMaster.Master"  AutoEventWireup="false" CodeBehind="UpdatePosition.aspx.cs"
    Inherits="HCMS.OrgChart.OrgChart.UpdatePosition" %>

<%@ Register TagPrefix="custom" TagName="UpdatePosition" Src="~/Controls/Positions/ctrlUpdatePosition.ascx"   %>

<asp:content id="Content1" contentplaceholderid="headContent" runat="server">
    <script type="text/javascript" src="../Src/windowDialogFunctions.js"></script>
</asp:content>

<asp:content id="Content2" contentplaceholderid="mainContent" runat="server">
        <custom:UpdatePosition id="customUpdatePosition" runat="server" />
</asp:content>
