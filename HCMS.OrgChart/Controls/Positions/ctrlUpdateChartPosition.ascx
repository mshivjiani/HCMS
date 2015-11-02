<%@ Control Language="C#" AutoEventWireup="false" CodeBehind="ctrlUpdateChartPosition.ascx.cs" Inherits="HCMS.OrgChart.Controls.Positions.ctrlUpdateChartPosition" %>
<%@ Register TagPrefix="custom" TagName="UpdateWFPPosition" Src="~/Controls/Positions/ctrlUpdateWFPPosition.ascx"   %>
<%@ Register TagPrefix="custom" TagName="UpdateFPPSPosition" Src="~/Controls/Positions/ctrlUpdateFPPSPosition.ascx"   %>

<custom:UpdateWFPPosition id="customWFPPosition" runat="server" />
<custom:UpdateFPPSPosition id="customFPPSPosition" runat="server" />