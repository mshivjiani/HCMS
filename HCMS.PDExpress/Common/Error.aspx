<%@ Page Title="" Language="C#" MasterPageFile="~/Other.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="HCMS.PDExpress.Common.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>An application error occurred.</div>
    <br />
    <asp:Literal ID="litError" runat="server"></asp:Literal>
</asp:Content>
