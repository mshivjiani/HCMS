<%@ Page Title="" Language="C#" MasterPageFile="~/OrgChartMaster.Master" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="HCMS.OrgChart.Common.Help" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <table class="helpLinkTable">
        <tr>
            <td>
                <asp:Image ID="imgOrgExTrainingManual" runat="server" SkinID="pdfIcon" />&nbsp;<a href="~/Common/OrganizationChartExpressTrainingManual.pdf"
                    id="linkOrgExTrainingManual" runat="server" target="_blank" title="Organization Chart Express (OCX) Training Manual">Organization Chart Express (OCX) Training Manual</a>
            </td>
        </tr>
    </table>
</asp:Content>
