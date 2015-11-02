<%@ Page Title="FAQ" Language="C#" MasterPageFile="~/PDMaster.Master" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="HCMS.PDExpress.Common.FAQ" %>
<%@ Register Assembly="HCMS.WebFramework" Namespace="HCMS.WebFramework.CustomControls" TagPrefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="PDMasterMainContent" runat="server">
    <table class="sitePDFTable">
        <tr>
            <td align="center">
                <cc1:ShowPdf ID="ShowPdf1" runat="server" FilePath="FAQ.pdf" Height="570px" Width="99.8%" />
            </td>
        </tr>
    </table>
</asp:Content>
