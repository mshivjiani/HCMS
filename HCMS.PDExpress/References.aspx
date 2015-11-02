<%@ Page Title="References" Language="C#" MasterPageFile="~/PDMaster.Master" AutoEventWireup="true" CodeBehind="References.aspx.cs" Inherits="HCMS.PDExpress.References" %>
<%@ Register Assembly="HCMS.WebFramework" Namespace="HCMS.WebFramework.CustomControls" TagPrefix="cc1" %>


<asp:Content ID="Content2" ContentPlaceHolderID="PDMasterMainContent" runat="server">
    <table class="sitePDFTable">
        <tr>
            <td>
                <cc1:ShowPdf ID="ShowPdf1" runat="server" FilePath="References.pdf" Height="570px" Width="99.8%" />
            </td>
        </tr>
    </table>
</asp:Content>
