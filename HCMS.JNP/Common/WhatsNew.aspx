﻿<%@ Page Title="" Language="C#" MasterPageFile="~/JNPMaster.master" AutoEventWireup="true" CodeBehind="WhatsNew.aspx.cs" Inherits="HCMS.JNP.Common.WhatsNew" %>
<%@ Register Assembly="HCMS.WebFramework" Namespace="HCMS.WebFramework.CustomControls" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainContent" runat="server">
<table class="sitePDFTable">
        <tr>
            <td>
                <cc1:ShowPdf ID="ShowPdf1" runat="server" FilePath="WhatsNew.pdf" Height="570px" Width="99.8%" />
            </td>
        </tr>
    </table>
</asp:Content>
