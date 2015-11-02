<%@ Page Title="" Language="C#" MasterPageFile="~/Other.Master" AutoEventWireup="true" CodeBehind="PortalPage.aspx.cs" Inherits="HCMS.Portal.Common.PortalPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table ID="tblInto" class="tblIntro" runat="server">
        <tr>
            <td align="left">
                <h1>Welcome to Human Capital Management System</h1>
            </td>
        </tr>
        <tr>
            <td>
                <p>
                The Human Capital Management System (HCMS) combines technology with FWS business processes to create a portal for Managers and HR professionals to initiate
                federal hiring actions – including Classification and Staffing actions. 
                </p>
            </td>
        </tr>
        <tr>
            <td style="text-align:center;">
                <asp:Button ID="btnEnter" runat="server" CssClass="formBtn" onclick="btnEnter_Click" ToolTip="Enter" Text="Enter" />
            </td>
        </tr>
        <tr><td style="text-align:center; font-weight:bolder" ><p>To access online training course modules on DOI Learn, <asp:HyperLink ID="DOITrainingLink" runat="server" 
        Text="click here "
        NavigateUrl="https://gm2.geolearning.com/geonext/doi/login.geo" Target="_blank" ></asp:HyperLink> and search the catalog for 'PD Express'.</p></td></tr>
    </table>
</asp:Content>
