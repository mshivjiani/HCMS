<%@ Page Title="" Language="C#" MasterPageFile="~/JNPMaster.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="HCMS.JNP.Common.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <div>An application error occurred.</div>
    <br />
    <asp:Literal ID="litError" runat="server"></asp:Literal>
</asp:Content>
